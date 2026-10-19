using Microsoft.Extensions.Configuration;

namespace SoChiTieu.Configuration;

/// <summary>Lớp cấu hình có kiểu (strongly-typed), ánh xạ 1-1 với appsettings.json.</summary>
public sealed class AppSettings
{
    public ConnectionStringsSettings ConnectionStrings { get; set; } = new();

    public LoggingSettings Logging { get; set; } = new();

    /// <summary>
    /// Đọc appsettings.json (bắt buộc) rồi ghi đè bằng appsettings.{môi trường}.json (nếu có).
    /// Môi trường lấy từ biến DOTNET_ENVIRONMENT, mặc định là Production.
    /// File luôn được tìm cạnh file .exe, không phụ thuộc thư mục đang chạy.
    /// </summary>
    public static AppSettings Load()
    {
        var env = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT");
        if (string.IsNullOrWhiteSpace(env))
            env = "Production";

        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: false)
            .Build();

        return config.Get<AppSettings>() ?? new AppSettings();
    }
}

public sealed class ConnectionStringsSettings
{
    public string QL_ChiTieu { get; set; } = "";
}

public sealed class LoggingSettings
{
    /// <summary>Verbose, Debug, Information, Warning, Error, Fatal.</summary>
    public string MinimumLevel { get; set; } = "Information";

    /// <summary>Thư mục log; đường dẫn tương đối được tính từ thư mục chứa file .exe.</summary>
    public string Folder { get; set; } = "Logs";

    public int RetainedDays { get; set; } = 30;
}
