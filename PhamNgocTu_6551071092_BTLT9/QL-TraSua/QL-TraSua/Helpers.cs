using System.Globalization;

namespace QL_TraSua;

public static class Helper
{
    private static readonly CultureInfo Vi = new("vi-VN");

    public static string Money(decimal v) => v.ToString("N0", Vi) + " đ";

    /// <summary>Che số tài khoản, chỉ giữ 4 số cuối (dùng khi ghi log).</summary>
    public static string MaskAccount(string acc)
    {
        if (string.IsNullOrEmpty(acc)) return "";
        if (acc.Length <= 4) return new string('*', acc.Length);
        return new string('*', acc.Length - 4) + acc[^4..];
    }

    public static Label Lbl(string text, int x, int y, int w = 90) =>
        new() { Text = text, Bounds = new Rectangle(x, y, w, 23), TextAlign = ContentAlignment.MiddleLeft };

    public static void StyleGrid(DataGridView g)
    {
        g.ReadOnly = true;
        g.AllowUserToAddRows = false;
        g.AllowUserToDeleteRows = false;
        g.MultiSelect = false;
        g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        g.RowHeadersVisible = false;
        g.AutoGenerateColumns = false;
        g.BackgroundColor = SystemColors.Window;
    }

    public static DataGridViewTextBoxColumn Col(string prop, string header, float weight = 100, string? format = null)
    {
        var c = new DataGridViewTextBoxColumn { DataPropertyName = prop, HeaderText = header, FillWeight = weight };
        if (format != null) c.DefaultCellStyle.Format = format;
        return c;
    }
}

public record DmItem(int MaDM, string TenDM);
