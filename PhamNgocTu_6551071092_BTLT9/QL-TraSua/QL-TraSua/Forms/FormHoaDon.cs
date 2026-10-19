using Microsoft.EntityFrameworkCore;

namespace QL_TraSua;

public class FormHoaDon : Form
{
    private class HdRow
    {
        public int MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public string HinhThucTT { get; set; } = "";
        public decimal TongTien { get; set; }
        public bool DaThanhToan { get; set; }
    }

    private class CtRow
    {
        public string TenMon { get; set; } = "";
        public int SoLy { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }

    private readonly DateTimePicker dtp = new() { Format = DateTimePickerFormat.Short, Bounds = new Rectangle(90, 12, 130, 25) };
    private readonly Label lblDoanhThu = new()
    {
        Bounds = new Rectangle(250, 8, 420, 32), Font = new Font("Segoe UI", 13, FontStyle.Bold),
        ForeColor = Color.Firebrick, TextAlign = ContentAlignment.MiddleLeft
    };
    private readonly DataGridView dgvHD = new()
    {
        Bounds = new Rectangle(10, 70, 760, 220), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
    };
    private readonly DataGridView dgvCT = new()
    {
        Bounds = new Rectangle(10, 320, 760, 220), Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
    };

    public FormHoaDon()
    {
        Text = "Danh sách hóa đơn";
        ClientSize = new Size(780, 550);
        StartPosition = FormStartPosition.CenterParent;

        Helper.StyleGrid(dgvHD);
        dgvHD.Columns.Add(Helper.Col("MaHD", "Mã HD", 50));
        dgvHD.Columns.Add(Helper.Col("NgayLap", "Giờ lập", 80, "HH:mm:ss"));
        dgvHD.Columns.Add(Helper.Col("HinhThucTT", "Hình thức", 90));
        dgvHD.Columns.Add(Helper.Col("TongTien", "Tổng tiền", 90, "N0"));
        dgvHD.SelectionChanged += (_, _) => LoadChiTiet();

        Helper.StyleGrid(dgvCT);
        dgvCT.Columns.Add(Helper.Col("TenMon", "Tên món", 200));
        dgvCT.Columns.Add(Helper.Col("SoLy", "SL", 40));
        dgvCT.Columns.Add(Helper.Col("DonGia", "Đơn giá", 80, "N0"));
        dgvCT.Columns.Add(Helper.Col("ThanhTien", "Thành tiền", 90, "N0"));

        Controls.AddRange(new Control[]
        {
            Helper.Lbl("Chọn ngày:", 10, 13), dtp, lblDoanhThu,
            Helper.Lbl("Hóa đơn trong ngày", 10, 45, 200),
            dgvHD,
            Helper.Lbl("Chi tiết hóa đơn đang chọn", 10, 295, 220),
            dgvCT
        });

        dtp.ValueChanged += (_, _) => LoadHoaDon();
        Load += (_, _) => LoadHoaDon();
    }

    private void LoadHoaDon()
    {
        try
        {
            var from = dtp.Value.Date;
            var to = from.AddDays(1);
            using var db = AppServices.CreateDb();
            var list = db.HoaDons
                .Where(h => h.NgayLap >= from && h.NgayLap < to)
                .OrderByDescending(h => h.NgayLap)
                .Select(h => new HdRow
                {
                    MaHD = h.MaHD, NgayLap = h.NgayLap, HinhThucTT = h.HinhThucTT,
                    TongTien = h.TongTien, DaThanhToan = h.DaThanhToan
                })
                .ToList();

            dgvHD.DataSource = list;
            var doanhThu = list.Where(x => x.DaThanhToan).Sum(x => x.TongTien);
            lblDoanhThu.Text = $"Doanh thu ngày: {Helper.Money(doanhThu)}";
            LoadChiTiet();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không đọc được hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadChiTiet()
    {
        if (dgvHD.CurrentRow?.DataBoundItem is not HdRow hd)
        {
            dgvCT.DataSource = null;
            return;
        }
        using var db = AppServices.CreateDb();
        dgvCT.DataSource = db.ChiTietHoaDons
            .Where(c => c.MaHD == hd.MaHD)
            .Select(c => new CtRow
            {
                TenMon = c.MaMonNavigation.TenMon, SoLy = c.SoLy, DonGia = c.DonGia, ThanhTien = c.SoLy * c.DonGia
            })
            .ToList();
    }
}
