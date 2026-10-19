namespace QL_TraSua.Models;

public partial class HoaDon
{
    public int MaHD { get; set; }

    public DateTime NgayLap { get; set; }

    public decimal TongTien { get; set; }

    public string HinhThucTT { get; set; } = null!;

    public bool DaThanhToan { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
}
