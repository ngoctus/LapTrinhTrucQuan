using System.Globalization;
using System.Text.Json;

namespace DaNgoaiApp.Services;

public enum WeatherStatus { Ok, PlaceNotFound, NoData, NetworkError, Timeout, Error }

public sealed record WeatherInfo(int Code, double TempMin, double TempMax, int RainProbability);

public sealed record WeatherResult(
    WeatherStatus Status,
    WeatherInfo? Info = null,
    string? PlaceName = null,
    string? Detail = null);

/// <summary>Gọi Open-Meteo: geocoding -> forecast 16 ngày.</summary>
public static class WeatherService
{
    // HttpClient dùng chung, Timeout 8 giây
    private static readonly HttpClient Http = CreateClient();

    private static HttpClient CreateClient()
    {
        var c = new HttpClient { Timeout = TimeSpan.FromSeconds(8) };
        c.DefaultRequestHeaders.UserAgent.ParseAdd("DaNgoaiApp/1.0");
        return c;
    }

    public static async Task<WeatherResult> GetForecastAsync(
        string place, DateTime tripDate, string lang, CancellationToken ct = default)
    {
        // forecast_days=16 -> chỉ có hôm nay .. hôm nay + 15
        int offset = (tripDate.Date - DateTime.Today).Days;
        if (offset < 0 || offset > 15)
            return new WeatherResult(WeatherStatus.NoData);

        try
        {
            // Bước 1: geocoding
            string geoUrl = "https://geocoding-api.open-meteo.com/v1/search?name="
                            + Uri.EscapeDataString(place) + "&count=1&language=" + lang;
            using var geoDoc = JsonDocument.Parse(await Http.GetStringAsync(geoUrl, ct));

            if (!geoDoc.RootElement.TryGetProperty("results", out var results)
                || results.ValueKind != JsonValueKind.Array
                || results.GetArrayLength() == 0)
                return new WeatherResult(WeatherStatus.PlaceNotFound);

            var first = results[0];
            double lat = first.GetProperty("latitude").GetDouble();
            double lon = first.GetProperty("longitude").GetDouble();
            string name = first.TryGetProperty("name", out var n) ? (n.GetString() ?? place) : place;

            // Bước 2: forecast
            string fcUrl = "https://api.open-meteo.com/v1/forecast?latitude="
               + lat.ToString(CultureInfo.InvariantCulture)
               + "&longitude=" + lon.ToString(CultureInfo.InvariantCulture)
               + "&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max"
               + "&timezone=auto&forecast_days=16";
            using var doc = JsonDocument.Parse(await Http.GetStringAsync(fcUrl, ct));

            var daily = doc.RootElement.GetProperty("daily");
            string target = tripDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);

            int idx = -1, i = 0;
            foreach (var t in daily.GetProperty("time").EnumerateArray())
            {
                if (t.GetString() == target) { idx = i; break; }
                i++;
            }
            if (idx < 0) return new WeatherResult(WeatherStatus.NoData);

            double? code = Num(daily.GetProperty("weather_code"), idx);
            double? tMax = Num(daily.GetProperty("temperature_2m_max"), idx);
            double? tMin = Num(daily.GetProperty("temperature_2m_min"), idx);
            double? rain = Num(daily.GetProperty("precipitation_probability_max"), idx);

            if (code is null || tMax is null || tMin is null)
                return new WeatherResult(WeatherStatus.NoData);

            var info = new WeatherInfo((int)code.Value, tMin.Value, tMax.Value, (int)Math.Round(rain ?? 0));
            return new WeatherResult(WeatherStatus.Ok, info, name);
        }
        catch (OperationCanceledException) when (ct.IsCancellationRequested)
        {
            throw; // người dùng đóng form
        }
        catch (TaskCanceledException)
        {
            return new WeatherResult(WeatherStatus.Timeout);   // hết 8 giây
        }
        catch (HttpRequestException)
        {
            return new WeatherResult(WeatherStatus.NetworkError);
        }
        catch (Exception ex) when (ex is JsonException or KeyNotFoundException or InvalidOperationException or FormatException)
        {
            return new WeatherResult(WeatherStatus.Error, Detail: ex.Message);
        }
    }

    private static double? Num(JsonElement array, int index)
    {
        var e = array[index];
        return e.ValueKind == JsonValueKind.Number ? e.GetDouble() : null;
    }
}

public static class WeatherCodes
{
    public static string Icon(int code) => Key(code) switch
    {
        "w_clear" => "☀️",
        "w_cloudy" => "⛅",
        "w_fog" => "🌫️",
        "w_rain" => "🌧️",
        "w_snow" => "❄️",
        "w_storm" => "⛈️",
        _ => "🌡️",
    };

    /// <summary>Khóa chuỗi trong Lang cho mô tả thời tiết.</summary>
    public static string Key(int code) => code switch
    {
        0 => "w_clear",
        >= 1 and <= 3 => "w_cloudy",
        45 or 48 => "w_fog",
        (>= 51 and <= 67) or (>= 80 and <= 82) => "w_rain",
        (>= 71 and <= 77) or 85 or 86 => "w_snow",
        >= 95 and <= 99 => "w_storm",
        _ => "w_other",
    };
}
