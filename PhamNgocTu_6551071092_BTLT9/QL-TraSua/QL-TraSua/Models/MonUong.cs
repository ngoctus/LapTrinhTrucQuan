namespace QL_TraSua.Models;

public partial class MonUong
{
    public int MaMon { get; set; }

    public string TenMon { get; set; } = null!;

    public decimal GiaBan { get; set; }

    public bool DangBan { get; set; }

    public int MaDM { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual DanhMucMon MaDmNavigation { get; set; } = null!;
}
