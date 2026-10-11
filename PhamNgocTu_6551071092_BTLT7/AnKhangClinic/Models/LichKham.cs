namespace AnKhangClinic.Models;

public partial class LichKham
{
    public int MaLich { get; set; }

    public string TenBenhNhan { get; set; } = null!;

    public string? SDT { get; set; }

    public DateOnly? NgayKham { get; set; }

    public TimeOnly? GioKham { get; set; }

    public int? MaBS { get; set; }

    public string? TrangThai { get; set; }

    public virtual BacSi? MaBSNavigation { get; set; }
}
