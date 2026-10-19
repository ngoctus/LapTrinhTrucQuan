namespace DaNgoaiApp.Services;

/// <summary>Dòng hiển thị trên DataGridView (ngày dạng DateTime, phương tiện đã dịch).</summary>
public sealed class ChuyenDiRow
{
    public int MaChuyen { get; set; }
    public string TenChuyen { get; set; } = "";
    public string DiaDiem { get; set; } = "";
    public DateTime NgayDi { get; set; }
    public int SoNguoi { get; set; }
    public decimal NganSach { get; set; }
    public string PhuongTien { get; set; } = "";      // chữ hiển thị theo ngôn ngữ
    public string PhuongTienKey { get; set; } = "";   // giá trị lưu trong CSDL (tiếng Việt)
    public bool DaHoanThanh { get; set; }
    public string? GhiChu { get; set; }
}
