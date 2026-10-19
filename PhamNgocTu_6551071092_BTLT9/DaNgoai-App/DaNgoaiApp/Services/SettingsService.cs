using System.Text.Json;

namespace DaNgoaiApp.Services;

public sealed class UserSettings
{
    public string Language { get; set; } = "vi";
}

public static class SettingsService
{
    // %LocalAppData%\usersettings.json
    private static string FilePath => Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "usersettings.json");

    public static UserSettings Load()
    {
        try
        {
            if (File.Exists(FilePath))
                return JsonSerializer.Deserialize<UserSettings>(File.ReadAllText(FilePath)) ?? new UserSettings();
        }
        catch { /* file hỏng -> dùng mặc định */ }
        return new UserSettings();
    }

    public static void Save(UserSettings settings)
    {
        try
        {
            File.WriteAllText(FilePath, JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true }));
        }
        catch { /* không ghi được thì bỏ qua, không làm sập ứng dụng */ }
    }
}
