using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QL_TraSua.Models;

namespace QL_TraSua;

public static class AppServices
{
    private static string _connectionString = "";

    public static PaymentSettings Payment { get; private set; } = new();

    public static void Init(IConfiguration config)
    {
        Payment = config.GetSection("Payment").Get<PaymentSettings>() ?? new PaymentSettings();
        _connectionString = config.GetConnectionString("QL_TraSua")
            ?? throw new InvalidOperationException("Thiếu ConnectionStrings:QL_TraSua trong appsettings.json");
    }

    public static QlTraSuaContext CreateDb()
    {
        var options = new DbContextOptionsBuilder<QlTraSuaContext>()
            .UseSqlServer(_connectionString)
            .Options;
        return new QlTraSuaContext(options);
    }
}
