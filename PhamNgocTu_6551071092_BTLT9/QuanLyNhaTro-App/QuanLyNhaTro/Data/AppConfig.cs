using Microsoft.Data.SqlClient;

namespace QuanLyNhaTro.Data;

public static class AppConfig
{
    /// <summary>Tên SQL Server instance. Đổi ở đây nếu máy khác dùng tên khác.</summary>
    public const string ServerName = @".\SQLEXPRESS";

    public const string DatabaseName = "QL_NhaTro";

    public static string ConnectionString => Build(DatabaseName);

    public static string MasterConnectionString => Build("master");

    private static string Build(string database) => new SqlConnectionStringBuilder
    {
        DataSource = ServerName,
        InitialCatalog = database,
        IntegratedSecurity = true,
        TrustServerCertificate = true,
        Encrypt = SqlConnectionEncryptOption.Optional,
        ConnectTimeout = 10
    }.ConnectionString;
}
