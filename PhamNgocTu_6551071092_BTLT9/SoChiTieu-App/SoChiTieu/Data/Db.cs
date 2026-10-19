using Microsoft.EntityFrameworkCore;

namespace SoChiTieu.Data;

/// <summary>Tạo DbContext từ connection string đọc ở appsettings.json (mỗi thao tác dùng một context ngắn hạn).</summary>
public static class Db
{
    private static DbContextOptions<QlChiTieuContext>? _options;

    public static void Init(string connectionString)
    {
        _options = new DbContextOptionsBuilder<QlChiTieuContext>()
            .UseSqlServer(connectionString)
            .Options;
    }

    public static QlChiTieuContext Create()
    {
        if (_options is null)
            throw new InvalidOperationException("Db chưa được khởi tạo. Hãy gọi Db.Init(...) khi ứng dụng khởi động.");

        return new QlChiTieuContext(_options);
    }
}
