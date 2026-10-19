using QuanLyNhaTro.Data;
using Serilog;

namespace QuanLyNhaTro;

internal static class Program
{
    private const string FriendlyMessage = "Đã xảy ra lỗi, thông tin đã được ghi lại.\nỨng dụng vẫn tiếp tục chạy, bạn có thể thao tác tiếp.";

    [STAThread]
    private static void Main()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(
                Path.Combine(AppContext.BaseDirectory, "logs", "nhatro-.log"),
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 30,
                shared: true)
            .CreateLogger();

        // 9.3 - Xử lý lỗi toàn cục (phải đăng ký trước khi tạo bất kỳ form nào)
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (_, e) => HandleUnhandled(e.Exception, "Application.ThreadException", showMessage: true);
        AppDomain.CurrentDomain.UnhandledException += (_, e) =>
            HandleUnhandled(e.ExceptionObject as Exception, "AppDomain.UnhandledException", showMessage: true);
        TaskScheduler.UnobservedTaskException += (_, e) =>
        {
            Log.Error(e.Exception, "Lỗi Task không được quan sát (UnobservedTaskException)");
            e.SetObserved();
        };

        try
        {
            Log.Information("=== Khởi động ứng dụng Quản lý nhà trọ ===");
            ApplicationConfiguration.Initialize();

            try
            {
                DatabaseInitializer.EnsureDatabase();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Không kết nối/khởi tạo được CSDL trên {Server}", AppConfig.ServerName);
                MessageBox.Show(
                    $"Không kết nối được SQL Server ({AppConfig.ServerName}).\nHãy kiểm tra dịch vụ SQL Server Express đã chạy rồi mở lại ứng dụng.\n\nThông tin lỗi đã được ghi vào thư mục logs.",
                    "Quản lý nhà trọ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new FormKhachThue());
        }
        finally
        {
            Log.Information("=== Thoát ứng dụng ===");
            Log.CloseAndFlush();
        }
    }

    private static void HandleUnhandled(Exception? ex, string source, bool showMessage)
    {
        try
        {
            if (ex != null)
                Log.Error(ex, "Lỗi chưa được bắt ({Source})", source);
            else
                Log.Error("Lỗi chưa được bắt ({Source}) nhưng không có đối tượng Exception", source);

            if (showMessage)
                MessageBox.Show(FriendlyMessage, "Quản lý nhà trọ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch
        {
            // Tuyệt đối không để trình xử lý lỗi tự gây lỗi.
        }
    }
}
