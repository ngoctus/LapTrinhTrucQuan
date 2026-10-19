using System.Globalization;
using System.Net.Http.Headers;
using System.Text.Json;
using QuanLyNhaTro.Models;

namespace QuanLyNhaTro.Services;

/// <summary>Gọi API hành chính Việt Nam. Một HttpClient dùng chung cho cả ứng dụng, Timeout 10 giây.</summary>
public static class AddressApiService
{
    private const string BaseUrl = "https://provinces.open-api.vn/api/v2/";

    private static readonly HttpClient Http = CreateClient();

    private static readonly JsonSerializerOptions JsonOptions = new() { PropertyNameCaseInsensitive = true };

    private static HttpClient CreateClient()
    {
        var client = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return client;
    }

    /// <summary>GET https://provinces.open-api.vn/api/v2/</summary>
    public static async Task<List<AddressItem>> GetProvincesAsync(CancellationToken ct = default)
    {
        using var resp = await Http.GetAsync(BaseUrl, ct);
        resp.EnsureSuccessStatusCode();

        await using var stream = await resp.Content.ReadAsStreamAsync(ct);
        var list = await JsonSerializer.DeserializeAsync<List<AddressItem>>(stream, JsonOptions, ct) ?? new();
        if (list.Count == 0)
            throw new HttpRequestException("API trả về danh sách tỉnh/thành rỗng.");

        return Sort(list);
    }

    /// <summary>GET https://provinces.open-api.vn/api/v2/p/{code}?depth=2</summary>
    public static async Task<List<AddressItem>> GetWardsAsync(int provinceCode, CancellationToken ct = default)
    {
        using var resp = await Http.GetAsync($"{BaseUrl}p/{provinceCode}?depth=2", ct);
        resp.EnsureSuccessStatusCode();

        await using var stream = await resp.Content.ReadAsStreamAsync(ct);
        var detail = await JsonSerializer.DeserializeAsync<ProvinceDetail>(stream, JsonOptions, ct);
        var wards = detail?.wards ?? new();
        if (wards.Count == 0)
            throw new HttpRequestException("API trả về danh sách phường/xã rỗng.");

        return Sort(wards);
    }

    private static List<AddressItem> Sort(List<AddressItem> items)
    {
        var cmp = StringComparer.Create(new CultureInfo("vi-VN"), true);
        return items.OrderBy(x => x.name, cmp).ToList();
    }

    private class ProvinceDetail
    {
        public List<AddressItem> wards { get; set; } = new();
    }
}
