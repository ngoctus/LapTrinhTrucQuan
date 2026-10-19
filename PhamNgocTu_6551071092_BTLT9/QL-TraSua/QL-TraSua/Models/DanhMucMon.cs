namespace QL_TraSua.Models;

public partial class DanhMucMon
{
    public int MaDM { get; set; }

    public string TenDM { get; set; } = null!;

    public virtual ICollection<MonUong> MonUongs { get; set; } = new List<MonUong>();
}
