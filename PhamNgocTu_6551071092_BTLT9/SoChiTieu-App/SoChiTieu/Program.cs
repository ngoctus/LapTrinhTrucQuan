using Serilog;
using Serilog.Events;
using SoChiTieu.Configuration;
using SoChiTieu.Data;

namespace SoChiTieu;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        AppSettings settings;
        try
        {
            settings = AppSettings.Load();
            if (string.IsNullOrWhiteSpace(settings.ConnectionStrings.QL_ChiTieu))
                throw new InvalidOperationException("Thiếu ConnectionStrings:QL_ChiTieu trong appsettings.json.");
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không đọc được file cấu hình appsettings.json (phải nằm cạnh file .exe).\n\n" + ex.Message,
                "Sổ chi tiêu cá nhân", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var logDir = Path.Combine(AppContext.BaseDirectory, settings.Logging.Folder);
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Is(ParseLevel(settings.Logging.MinimumLevel))
            // "log-.txt" + RollingInterval.Day => log-yyyyMMdd.txt
            .WriteTo.File(
                Path.Combine(logDir, "log-.txt"),
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: settings.Logging.RetainedDays,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();

        Application.ThreadException += (_, e) =>
        {
            Log.Error(e.Exception, "Lỗi không xử lý trên luồng giao diện");
            MessageBox.Show("Đã xảy ra lỗi không mong muốn. Chi tiết đã được ghi vào thư mục Logs.",
                "Sổ chi tiêu cá nhân", MessageBoxButtons.OK, MessageBoxIcon.Error);
        };
        AppDomain.CurrentDomain.UnhandledException += (_, e) =>
            Log.Fatal(e.ExceptionObject as Exception, "Lỗi nghiêm trọng, ứng dụng sẽ đóng");

        try
        {
            Log.Information("Khởi động ứng dụng Sổ chi tiêu cá nhân");
            Db.Init(settings.ConnectionStrings.QL_ChiTieu);
            Application.Run(new FormChiTieu());
        }
        finally
        {
            Log.Information("Đóng ứng dụng");
            Log.CloseAndFlush();
        }
    }

    private static LogEventLevel ParseLevel(string? text) =>
        Enum.TryParse<LogEventLevel>(text, ignoreCase: true, out var level) ? level : LogEventLevel.Information;
}
