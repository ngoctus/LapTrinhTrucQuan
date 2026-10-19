using Microsoft.EntityFrameworkCore;
using QuanLyNhaTro.Models;

namespace QuanLyNhaTro.Data;

/// <summary>Lỗi nghiệp vụ: thông điệp hiển thị thẳng cho người dùng, không cần ghi log lỗi nghiêm trọng.</summary>
public class NghiepVuException : Exception
{
    public NghiepVuException(string message) : base(message) { }
}

public static class NhaTroRepository
{
    public const string Trong = "Trống";
    public const string DangThue = "Đang thuê";

    public static List<PhongTro> GetAllPhong()
    {
        using var db = new QlNhaTroContext();
        return db.PhongTros.AsNoTracking().OrderBy(p => p.TenPhong).ToList();
    }

    /// <summary>Phòng hợp lệ để nhập khách: chỉ phòng "Trống" (cộng thêm phòng hiện tại của khách khi đang sửa).</summary>
    public static List<PhongTro> GetPhongChoNhap(int? includeMaPhong)
    {
        int inc = includeMaPhong ?? -1;
        using var db = new QlNhaTroContext();
        return db.PhongTros.AsNoTracking()
            .Where(p => p.TinhTrang == Trong || p.MaPhong == inc)
            .OrderBy(p => p.TenPhong)
            .ToList();
    }

    public static List<string> GetDanhSachTinh()
    {
        using var db = new QlNhaTroContext();
        return db.KhachThues.AsNoTracking().Select(k => k.TenTinh).Distinct().OrderBy(t => t).ToList();
    }

    public static List<KhachView> GetKhachViews(string? keyword, int? maPhong, string? tenTinh)
    {
        using var db = new QlNhaTroContext();
        var q = db.KhachThues.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            var kw = keyword.Trim();
            q = q.Where(k => k.HoTen.Contains(kw) || k.SoDienThoai.Contains(kw));
        }
        if (maPhong.HasValue)
            q = q.Where(k => k.MaPhong == maPhong.Value);
        if (!string.IsNullOrEmpty(tenTinh))
            q = q.Where(k => k.TenTinh == tenTinh);

        // JOIN KhachThue - PhongTro thông qua navigation property
        return q.OrderBy(k => k.MaKhach)
            .Select(k => new KhachView
            {
                MaKhach = k.MaKhach,
                HoTen = k.HoTen,
                GioiTinh = k.GioiTinh,
                NgaySinh = k.NgaySinh,
                SoDienThoai = k.SoDienThoai,
                MaPhong = k.MaPhong,
                TenPhong = k.MaPhongNavigation.TenPhong,
                GiaThue = k.MaPhongNavigation.GiaThue,
                MaTinh = k.MaTinh,
                TenTinh = k.TenTinh,
                MaPhuongXa = k.MaPhuongXa,
                TenPhuongXa = k.TenPhuongXa,
                DaDangKyTamTru = k.DaDangKyTamTru
            })
            .ToList();
    }

    public static void AddKhach(KhachThue k)
    {
        using var db = new QlNhaTroContext();
        using var tx = db.Database.BeginTransaction();

        var phong = db.PhongTros.Find(k.MaPhong)
                    ?? throw new NghiepVuException("Phòng được chọn không còn tồn tại.");
        if (phong.TinhTrang != Trong)
            throw new NghiepVuException($"Phòng {phong.TenPhong} đang có người thuê, vui lòng chọn phòng trống.");

        db.KhachThues.Add(k);
        db.SaveChanges();

        CapNhatTinhTrangPhong(db, k.MaPhong);
        tx.Commit();
    }

    public static void UpdateKhach(KhachThue k)
    {
        using var db = new QlNhaTroContext();
        using var tx = db.Database.BeginTransaction();

        var cur = db.KhachThues.Find(k.MaKhach)
                  ?? throw new NghiepVuException("Khách thuê này đã bị xóa, vui lòng bấm Làm mới.");
        int phongCu = cur.MaPhong;

        if (k.MaPhong != phongCu)
        {
            var phongMoi = db.PhongTros.Find(k.MaPhong)
                           ?? throw new NghiepVuException("Phòng được chọn không còn tồn tại.");
            if (phongMoi.TinhTrang != Trong)
                throw new NghiepVuException($"Phòng {phongMoi.TenPhong} đang có người thuê, vui lòng chọn phòng trống.");
        }

        cur.HoTen = k.HoTen;
        cur.GioiTinh = k.GioiTinh;
        cur.NgaySinh = k.NgaySinh;
        cur.SoDienThoai = k.SoDienThoai;
        cur.MaTinh = k.MaTinh;
        cur.TenTinh = k.TenTinh;
        cur.MaPhuongXa = k.MaPhuongXa;
        cur.TenPhuongXa = k.TenPhuongXa;
        cur.DaDangKyTamTru = k.DaDangKyTamTru;
        cur.MaPhong = k.MaPhong;
        db.SaveChanges();

        CapNhatTinhTrangPhong(db, phongCu);
        if (k.MaPhong != phongCu)
            CapNhatTinhTrangPhong(db, k.MaPhong);

        tx.Commit();
    }

    public static void DeleteKhach(int maKhach)
    {
        using var db = new QlNhaTroContext();
        using var tx = db.Database.BeginTransaction();

        var cur = db.KhachThues.Find(maKhach)
                  ?? throw new NghiepVuException("Khách thuê này đã bị xóa, vui lòng bấm Làm mới.");
        int maPhong = cur.MaPhong;

        db.KhachThues.Remove(cur);
        db.SaveChanges();

        CapNhatTinhTrangPhong(db, maPhong); // xóa người cuối cùng -> phòng trở lại "Trống"
        tx.Commit();
    }

    /// <summary>Phòng còn ít nhất 1 khách -> "Đang thuê", không còn ai -> "Trống".</summary>
    private static void CapNhatTinhTrangPhong(QlNhaTroContext db, int maPhong)
    {
        var phong = db.PhongTros.Find(maPhong);
        if (phong == null) return;

        bool conKhach = db.KhachThues.Any(x => x.MaPhong == maPhong);
        phong.TinhTrang = conKhach ? DangThue : Trong;
        db.SaveChanges();
    }
}
