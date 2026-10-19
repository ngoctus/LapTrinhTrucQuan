using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using QL_TraSua.Models;
using Serilog;

namespace QL_TraSua;

public class FormBanHang : Form
{
    private class CartItem
    {
        public int MaMon { get; set; }
        public string TenMon { get; set; } = "";
        public int SoLy { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien => SoLy * DonGia;
    }

    private record MonItem(int MaMon, string TenMon, decimal GiaBan)
    {
        public override string ToString() => $"{TenMon}  -  {Helper.Money(GiaBan)}";
    }

    // --- Điều khiển ---
    private readonly ComboBox cboDM = new() { Bounds = new Rectangle(10, 32, 300, 25), DropDownStyle = ComboBoxStyle.DropDownList };
    private readonly ListBox lstMon = new() { Bounds = new Rectangle(10, 90, 300, 300) };
    private readonly NumericUpDown numSL = new() { Bounds = new Rectangle(70, 402, 80, 25), Minimum = 1, Maximum = 99, Value = 1 };
    private readonly Button btnThem = new() { Text = "Thêm vào đơn", Bounds = new Rectangle(160, 398, 150, 32) };

    private readonly DataGridView dgvGio = new() { Bounds = new Rectangle(320, 10, 390, 400) };
    private readonly Button btnXoa = new() { Text = "Xóa dòng", Bounds = new Rectangle(320, 420, 120, 32) };
    private readonly Label lblTong = new()
    {
        Bounds = new Rectangle(320, 462, 390, 40), Font = new Font("Segoe UI", 14, FontStyle.Bold),
        TextAlign = ContentAlignment.MiddleLeft, ForeColor = Color.Firebrick
    };
    private readonly Button btnQR = new() { Text = "Thanh toán chuyển khoản", Bounds = new Rectangle(320, 520, 190, 44) };
    private readonly Button btnTienMat = new() { Text = "Tiền mặt", Bounds = new Rectangle(520, 520, 190, 44) };

    private readonly PictureBox pic = new()
    {
        Bounds = new Rectangle(725, 10, 260, 260), SizeMode = PictureBoxSizeMode.Zoom, BorderStyle = BorderStyle.FixedSingle
    };
    private readonly Label lblInfo = new() { Bounds = new Rectangle(725, 278, 260, 220), Font = new Font("Segoe UI", 10) };
    private readonly Button btnDaNhan = new() { Text = "Đã nhận tiền", Bounds = new Rectangle(725, 510, 260, 40), Enabled = false };
    private readonly Button btnHuyQR = new() { Text = "Hủy thanh toán / sửa đơn", Bounds = new Rectangle(725, 556, 260, 32), Enabled = false };

    // --- Trạng thái ---
    private readonly BindingList<CartItem> _cart = new();
    private Stream? _qrStream;
    private int _pendingMaHD;
    private decimal _pendingAmount;
    private string _pendingContent = "";

    private decimal Total => _cart.Sum(c => c.ThanhTien);

    public FormBanHang()
    {
        Text = "Bán hàng";
        ClientSize = new Size(1000, 600);
        StartPosition = FormStartPosition.CenterParent;
        BuildUi();
        Load += (_, _) => LoadCategories();
        FormClosed += (_, _) => { pic.Image?.Dispose(); _qrStream?.Dispose(); };
    }

    private void BuildUi()
    {
        Helper.StyleGrid(dgvGio);
        dgvGio.Columns.Add(Helper.Col(nameof(CartItem.TenMon), "Tên món", 150));
        dgvGio.Columns.Add(Helper.Col(nameof(CartItem.SoLy), "SL", 40));
        dgvGio.Columns.Add(Helper.Col(nameof(CartItem.DonGia), "Đơn giá", 80, "N0"));
        dgvGio.Columns.Add(Helper.Col(nameof(CartItem.ThanhTien), "Thành tiền", 90, "N0"));
        dgvGio.DataSource = _cart;

        btnDaNhan.BackColor = Color.LightGreen;
        lblInfo.AutoSize = false;

        Controls.AddRange(new Control[]
        {
            Helper.Lbl("Danh mục:", 10, 8), cboDM,
            Helper.Lbl("Món đang bán:", 10, 64, 150), lstMon,
            Helper.Lbl("Số ly:", 10, 403, 55), numSL, btnThem,
            dgvGio, btnXoa, lblTong, btnQR, btnTienMat,
            pic, lblInfo, btnDaNhan, btnHuyQR
        });

        cboDM.SelectedIndexChanged += (_, _) => LoadMon();
        btnThem.Click += (_, _) => ThemVaoDon();
        lstMon.DoubleClick += (_, _) => ThemVaoDon();
        btnXoa.Click += (_, _) => XoaDong();
        _cart.ListChanged += (_, _) => UpdateTotal();
        btnQR.Click += async (_, _) => await ThanhToanChuyenKhoanAsync();
        btnTienMat.Click += (_, _) => ThanhToanTienMat();
        btnDaNhan.Click += (_, _) => LuuHoaDon("Chuyển khoản");
        btnHuyQR.Click += (_, _) => HuyThanhToan();
        UpdateTotal();
    }

    // ------------------------------------------------------------ Thực đơn
    private void LoadCategories()
    {
        try
        {
            using var db = AppServices.CreateDb();
            var list = db.DanhMucMons.OrderBy(x => x.TenDM).Select(x => new DmItem(x.MaDM, x.TenDM)).ToList();
            cboDM.DataSource = list;
            cboDM.DisplayMember = nameof(DmItem.TenDM);
            cboDM.ValueMember = nameof(DmItem.MaDM);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Không đọc được danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadMon()
    {
        lstMon.Items.Clear();
        if (cboDM.SelectedItem is not DmItem dm) return;
        using var db = AppServices.CreateDb();
        var mons = db.MonUongs.Where(m => m.MaDM == dm.MaDM && m.DangBan)
                              .OrderBy(m => m.TenMon)
                              .Select(m => new MonItem(m.MaMon, m.TenMon, m.GiaBan))
                              .ToList();
        foreach (var m in mons) lstMon.Items.Add(m);
    }

    // ------------------------------------------------------------ Giỏ hàng
    private void ThemVaoDon()
    {
        if (lstMon.SelectedItem is not MonItem m)
        {
            MessageBox.Show("Hãy chọn một món.", "Chưa chọn món", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        var sl = (int)numSL.Value;
        var existing = _cart.FirstOrDefault(c => c.MaMon == m.MaMon);
        if (existing != null)
        {
            existing.SoLy += sl;              // cộng dồn
            _cart.ResetBindings();
        }
        else
        {
            _cart.Add(new CartItem { MaMon = m.MaMon, TenMon = m.TenMon, SoLy = sl, DonGia = m.GiaBan });
        }
        numSL.Value = 1;
    }

    private void XoaDong()
    {
        if (dgvGio.CurrentRow?.DataBoundItem is CartItem item)
            _cart.Remove(item);
        else
            MessageBox.Show("Hãy chọn dòng cần xóa.", "Chưa chọn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void UpdateTotal() => lblTong.Text = "Tổng tiền: " + Helper.Money(Total);

    // ------------------------------------------------------------ Thanh toán
    private void SetPaying(bool on)
    {
        cboDM.Enabled = lstMon.Enabled = numSL.Enabled = btnThem.Enabled = btnXoa.Enabled = !on;
        btnDaNhan.Enabled = btnHuyQR.Enabled = on;
    }

    private void HuyThanhToan()
    {
        SetPaying(false);
        pic.Image?.Dispose(); pic.Image = null;
        _qrStream?.Dispose(); _qrStream = null;
        lblInfo.Text = "";
    }

    /// <summary>Dự đoán mã HD kế tiếp (hóa đơn chỉ được lưu khi bấm "Đã nhận tiền").</summary>
    private int GetNextMaHD()
    {
        using var db = AppServices.CreateDb();
        try
        {
            var last = db.Database
                .SqlQueryRaw<decimal?>("SELECT CAST(last_value AS decimal(18,0)) AS [Value] FROM sys.identity_columns WHERE object_id = OBJECT_ID('dbo.HoaDon')")
                .AsEnumerable().FirstOrDefault();
            return (int)(last ?? 0) + 1;
        }
        catch
        {
            return (db.HoaDons.Max(h => (int?)h.MaHD) ?? 0) + 1;
        }
    }

    private string BuildInfoText(string note)
    {
        var p = AppServices.Payment;
        return $"Số tiền: {Helper.Money(_pendingAmount)}\r\n" +
               $"Nội dung CK: {_pendingContent}\r\n" +
               $"Ngân hàng: {p.BankId}\r\n" +
               $"Số TK: {p.AccountNo}\r\n" +
               $"Chủ TK: {p.AccountName}" +
               (note.Length > 0 ? "\r\n\r\n" + note : "");
    }

    private async Task ThanhToanChuyenKhoanAsync()
    {
        if (_cart.Count == 0)
        {
            MessageBox.Show("Đơn hàng đang trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        btnQR.Enabled = false;
        try
        {
            _pendingAmount = Total;
            _pendingMaHD = GetNextMaHD();
            _pendingContent = $"TRASUA HD{_pendingMaHD}";

            SetPaying(true);
            lblInfo.ForeColor = SystemColors.ControlText;
            lblInfo.Text = BuildInfoText("Đang tải mã QR...");

            var p = AppServices.Payment;
            Log.Information("Tạo QR thanh toán: HD {MaHD}, số tiền {SoTien}, TK {TaiKhoan}",
                _pendingMaHD, _pendingAmount, Helper.MaskAccount(p.AccountNo));

            try
            {
                var url = QrService.BuildUrl(p, _pendingAmount, _pendingContent);
                var bytes = await QrService.DownloadAsync(url);

                var ms = new MemoryStream(bytes);          // giữ stream sống cùng với Image
                var oldImg = pic.Image;
                pic.Image = Image.FromStream(ms);
                oldImg?.Dispose();
                _qrStream?.Dispose();
                _qrStream = ms;

                lblInfo.Text = BuildInfoText("Quét mã bằng app ngân hàng, kiểm tra tin nhắn rồi bấm \"Đã nhận tiền\".");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Tải ảnh QR thất bại cho HD {MaHD}", _pendingMaHD);
                pic.Image?.Dispose();
                pic.Image = null;
                lblInfo.ForeColor = Color.Firebrick;
                lblInfo.Text = BuildInfoText(
                    "Không tải được mã QR (có thể mất mạng). Khách có thể chuyển khoản tay theo thông tin trên, " +
                    "hoặc bấm \"Hủy thanh toán\" rồi chọn \"Tiền mặt\".");
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lỗi khi chuẩn bị thanh toán chuyển khoản");
            MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            HuyThanhToan();
        }
        finally
        {
            btnQR.Enabled = true;
        }
    }

    private void ThanhToanTienMat()
    {
        if (_cart.Count == 0)
        {
            MessageBox.Show("Đơn hàng đang trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        var ok = MessageBox.Show($"Thu tiền mặt {Helper.Money(Total)} và lưu hóa đơn?", "Xác nhận",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (ok == DialogResult.Yes) LuuHoaDon("Tiền mặt");
    }

    /// <summary>Lưu HoaDon + ChiTietHoaDon trong cùng một lần SaveChanges.</summary>
    private void LuuHoaDon(string hinhThuc)
    {
        try
        {
            using var db = AppServices.CreateDb();
            var hd = new HoaDon
            {
                NgayLap = DateTime.Now,
                TongTien = Total,
                HinhThucTT = hinhThuc,
                DaThanhToan = true
            };
            foreach (var c in _cart)
                hd.ChiTietHoaDons.Add(new ChiTietHoaDon { MaMon = c.MaMon, SoLy = c.SoLy, DonGia = c.DonGia });

            db.HoaDons.Add(hd);
            db.SaveChanges();

            Log.Information("Đã lưu hóa đơn HD {MaHD}, {HinhThuc}, tổng {TongTien}", hd.MaHD, hinhThuc, hd.TongTien);

            var msg = $"Đã lưu hóa đơn HD{hd.MaHD} ({hinhThuc}) - {Helper.Money(hd.TongTien)}.";
            if (hinhThuc == "Chuyển khoản" && hd.MaHD != _pendingMaHD)
                msg += $"\r\nLưu ý: mã HD thực tế ({hd.MaHD}) khác nội dung CK đã hiển thị ({_pendingContent}).";

            _cart.Clear();
            HuyThanhToan();
            MessageBox.Show(msg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Lưu hóa đơn thất bại");
            MessageBox.Show("Không lưu được hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
