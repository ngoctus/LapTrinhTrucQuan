namespace QuanLyNhaTro.Models;

/// <summary>Một dòng của API hành chính (tỉnh/thành hoặc phường/xã). Tên thuộc tính viết thường để khớp JSON và DisplayMember="name", ValueMember="code".</summary>
public class AddressItem
{
    public int code { get; set; }
    public string name { get; set; } = "";

    public override string ToString() => name;
}

/// <summary>Mục của ComboBox phòng.</summary>
public record RoomItem(int MaPhong, string Text);

/// <summary>Một dòng của DataGridView (kết quả JOIN KhachThue + PhongTro).</summary>
public class KhachView
{
    public int MaKhach { get; set; }
    public string HoTen { get; set; } = "";
    public string GioiTinh { get; set; } = "";
    public DateOnly NgaySinh { get; set; }
    public string SoDienThoai { get; set; } = "";
    public int MaPhong { get; set; }
    public string TenPhong { get; set; } = "";
    public decimal GiaThue { get; set; }
    public int? MaTinh { get; set; }
    public string TenTinh { get; set; } = "";
    public int? MaPhuongXa { get; set; }
    public string TenPhuongXa { get; set; } = "";
    public bool DaDangKyTamTru { get; set; }

    public string QueQuan => $"{TenPhuongXa} – {TenTinh}";
}
