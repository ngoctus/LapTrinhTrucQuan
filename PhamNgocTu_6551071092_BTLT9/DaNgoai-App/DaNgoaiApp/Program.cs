using DaNgoaiApp.Services;

namespace DaNgoaiApp;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        // Đọc ngôn ngữ đã lưu (usersettings.json) trước khi tạo form
        var settings = SettingsService.Load();
        Lang.Set(settings.Language);

        Application.Run(new FormChuyenDi());
    }
}
