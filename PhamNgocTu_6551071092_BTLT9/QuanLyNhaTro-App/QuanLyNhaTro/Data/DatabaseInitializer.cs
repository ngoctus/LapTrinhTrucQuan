using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using Serilog;

namespace QuanLyNhaTro.Data;

/// <summary>Tự tạo CSDL QL_NhaTro + 2 bảng + dữ liệu mẫu nếu chưa có (chạy file Database\QL_NhaTro.sql).</summary>
public static class DatabaseInitializer
{
    public static void EnsureDatabase()
    {
        var scriptPath = Path.Combine(AppContext.BaseDirectory, "Database", "QL_NhaTro.sql");
        if (!File.Exists(scriptPath))
            throw new FileNotFoundException("Không tìm thấy file script CSDL.", scriptPath);

        var script = File.ReadAllText(scriptPath);
        var batches = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

        using var conn = new SqlConnection(AppConfig.MasterConnectionString);
        conn.Open();

        foreach (var batch in batches)
        {
            if (string.IsNullOrWhiteSpace(batch)) continue;
            using var cmd = conn.CreateCommand();
            cmd.CommandText = batch;
            cmd.CommandTimeout = 60;
            cmd.ExecuteNonQuery();
        }

        Log.Information("CSDL {Db} trên {Server} đã sẵn sàng", AppConfig.DatabaseName, AppConfig.ServerName);
    }
}
