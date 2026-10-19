using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Serilog;
using SoChiTieu.Data;
using SoChiTieu.Models;

namespace SoChiTieu;

public partial class FormChiTieu : Form
{
    private static readonly CultureInfo Vi = new("vi-VN");
    private const string TatCa = "Tất cả";

    private bool _dangNap;        // true khi đang nạp dữ liệu / đặt giá trị cho control -> bỏ qua sự kiện
    private int? _maDangChon;     // MaCT của dòng đang chọn trên lưới

    public FormChiTieu()
    {
        InitializeComponent();

        _dangNap = true;
        cboLoaiChi.Items.AddRange(LoaiChiList.DanhSach);
        cboLoaiChi.SelectedIndex = 0;

        cboLocLoai.Items.Add(TatCa);
        cboLocLoai.Items.AddRange(LoaiChiList.DanhSach);
        cboLocLoai.SelectedIndex = 0;

        DatKhoangThangNay();
        _dangNap = false;

        Shown += (_, _) => LoadData();
    }

    // ---------------------------------------------------------------- Nạp dữ liệu + lọc

    /// <summary>Đọc CSDL theo bộ lọc hiện tại, đổ vào lưới và cập nhật "Tổng chi".</summary>
    private void LoadData()
    {
        if (_dangNap) return;

        var tuKhoa = txtTim.Text.Trim();
        var loai = cboLocLoai.SelectedIndex > 0 ? cboLocLoai.SelectedItem?.ToString() : null;
        DateOnly? tu = null, den = null;

        if (chkLocNgay.Checked)
        {
            tu = DateOnly.FromDateTime(dtpTu.Value);
            den = DateOnly.FromDateTime(dtpDen.Value);
            if (tu > den)
            {
                HienKetQua(new List<ChiTieu>(), "Khoảng ngày không hợp lệ: \"Từ ngày\" lớn hơn \"Đến ngày\"");
                return;
            }
        }

        List<ChiTieu> ds;
        try
        {
            using var db = Db.Create();
            var q = db.ChiTieus.AsNoTracking().AsQueryable();

            if (tuKhoa.Length > 0)
                q = q.Where(x => x.NoiDung.Contains(tuKhoa));
            if (loai != null)
                q = q.Where(x => x.LoaiChi == loai);
            if (tu != null)
                q = q.Where(x => x.NgayChi >= tu.Value);
            if (den != null)
                q = q.Where(x => x.NgayChi <= den.Value);

            ds = q.OrderByDescending(x => x.NgayChi).ThenByDescending(x => x.MaCt).ToList();
        }
        catch (Exception ex)
        {
            BaoLoiCsdl("tải danh sách khoản chi", ex);
            return;
        }

        HienKetQua(ds, $"{ds.Count} khoản chi");
    }

    private void HienKetQua(List<ChiTieu> ds, string thongTin)
    {
        _dangNap = true;
        try
        {
            dgv.DataSource = ds;
            dgv.CurrentCell = null;
            dgv.ClearSelection();

            // Giữ lại dòng đang chọn (nếu còn nằm trong kết quả lọc)
            if (_maDangChon is int ma)
            {
                var dong = dgv.Rows.Cast<DataGridViewRow>()
                    .FirstOrDefault(r => (r.DataBoundItem as ChiTieu)?.MaCt == ma);
                if (dong != null)
                {
                    dong.Selected = true;
                    dgv.CurrentCell = dong.Cells[colNoiDung.Index];
                }
                else
                {
                    _maDangChon = null;
                }
            }
        }
        finally
        {
            _dangNap = false;
        }

        var tong = ds.Sum(x => x.SoTien);
        lblTong.Text = $"Tổng chi: {tong.ToString("N0", Vi)} đ";
        lblSoDong.Text = thongTin;
    }

    // ---------------------------------------------------------------- Lưới

    private void dgv_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.ColumnIndex == colNgayChi.Index && e.Value is DateOnly d)
        {
            e.Value = d.ToString("dd/MM/yyyy", Vi);
            e.FormattingApplied = true;
        }
    }

    /// <summary>Bấm vào một dòng (hoặc dùng phím mũi tên) thì đưa dữ liệu lên các control để sửa.</summary>
    private void dgv_SelectionChanged(object? sender, EventArgs e)
    {
        if (_dangNap) return;
        if (dgv.CurrentRow?.DataBoundItem is not ChiTieu ct) return;

        _maDangChon = ct.MaCt;
        dtpNgayChi.Value = ct.NgayChi.ToDateTime(TimeOnly.MinValue);
        txtNoiDung.Text = ct.NoiDung;
        var idx = cboLoaiChi.Items.IndexOf(ct.LoaiChi);
        cboLoaiChi.SelectedIndex = idx >= 0 ? idx : cboLoaiChi.Items.Count - 1; // không khớp -> "Khác"
        nudSoTien.Value = Math.Clamp(ct.SoTien, nudSoTien.Minimum, nudSoTien.Maximum);
        txtGhiChu.Text = ct.GhiChu ?? "";
    }

    // ---------------------------------------------------------------- Thêm / Sửa / Xóa / Làm mới

    private void btnThem_Click(object? sender, EventArgs e)
    {
        if (!KiemTraHopLe()) return;

        try
        {
            using var db = Db.Create();
            var ct = new ChiTieu();
            DocTuForm(ct);
            db.ChiTieus.Add(ct);
            db.SaveChanges();

            Log.Information("Thêm khoản chi MaCT={MaCT}: \"{NoiDung}\", {LoaiChi}, {SoTien:N0} đ, ngày {NgayChi:dd/MM/yyyy}",
                ct.MaCt, ct.NoiDung, ct.LoaiChi, ct.SoTien, ct.NgayChi);
        }
        catch (Exception ex)
        {
            BaoLoiCsdl("thêm khoản chi", ex);
            return;
        }

        XoaForm();
        LoadData();
    }

    private void btnSua_Click(object? sender, EventArgs e)
    {
        if (_maDangChon is not int ma)
        {
            MessageBox.Show(this, "Hãy bấm chọn một dòng trong danh sách để sửa.", "Chưa chọn khoản chi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        if (!KiemTraHopLe()) return;

        try
        {
            using var db = Db.Create();
            var ct = db.ChiTieus.Find(ma);
            if (ct is null)
            {
                MessageBox.Show(this, "Khoản chi này không còn tồn tại (có thể đã bị xóa).", "Không tìm thấy",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _maDangChon = null;
                LoadData();
                return;
            }

            DocTuForm(ct);
            db.SaveChanges();

            Log.Information("Sửa khoản chi MaCT={MaCT}: \"{NoiDung}\", {LoaiChi}, {SoTien:N0} đ, ngày {NgayChi:dd/MM/yyyy}",
                ct.MaCt, ct.NoiDung, ct.LoaiChi, ct.SoTien, ct.NgayChi);
        }
        catch (Exception ex)
        {
            BaoLoiCsdl("sửa khoản chi", ex);
            return;
        }

        LoadData();
    }

    private void btnXoa_Click(object? sender, EventArgs e)
    {
        if (_maDangChon is not int ma)
        {
            MessageBox.Show(this, "Hãy bấm chọn một dòng trong danh sách để xóa.", "Chưa chọn khoản chi",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var hoi = MessageBox.Show(this,
            $"Bạn có chắc muốn xóa khoản chi \"{txtNoiDung.Text.Trim()}\" (Mã {ma}) không?\nThao tác này không thể hoàn tác.",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        if (hoi != DialogResult.Yes) return;

        try
        {
            using var db = Db.Create();
            var ct = db.ChiTieus.Find(ma);
            if (ct is not null)
            {
                db.ChiTieus.Remove(ct);
                db.SaveChanges();
                Log.Information("Xóa khoản chi MaCT={MaCT}: \"{NoiDung}\", {SoTien:N0} đ", ma, ct.NoiDung, ct.SoTien);
            }
        }
        catch (Exception ex)
        {
            BaoLoiCsdl("xóa khoản chi", ex);
            return;
        }

        XoaForm();
        LoadData();
    }

    private void btnLamMoi_Click(object? sender, EventArgs e)
    {
        XoaForm();
        LoadData();
    }

    // ---------------------------------------------------------------- Bộ lọc

    private void BoLocThayDoi(object? sender, EventArgs e) => LoadData();

    private void chkLocNgay_CheckedChanged(object? sender, EventArgs e)
    {
        dtpTu.Enabled = dtpDen.Enabled = chkLocNgay.Checked;
        LoadData();
    }

    private void btnThangNay_Click(object? sender, EventArgs e)
    {
        _dangNap = true;
        DatKhoangThangNay();
        chkLocNgay.Checked = true;
        _dangNap = false;
        LoadData();
    }

    private void btnBoLoc_Click(object? sender, EventArgs e)
    {
        _dangNap = true;
        txtTim.Clear();
        cboLocLoai.SelectedIndex = 0;
        chkLocNgay.Checked = false;
        DatKhoangThangNay();
        _dangNap = false;
        LoadData();
    }

    // ---------------------------------------------------------------- Hàm phụ

    private void DatKhoangThangNay()
    {
        var homNay = DateTime.Today;
        dtpTu.Value = new DateTime(homNay.Year, homNay.Month, 1);
        dtpDen.Value = new DateTime(homNay.Year, homNay.Month, DateTime.DaysInMonth(homNay.Year, homNay.Month));
    }

    private void XoaForm()
    {
        _maDangChon = null;
        dtpNgayChi.Value = DateTime.Today;
        txtNoiDung.Clear();
        cboLoaiChi.SelectedIndex = 0;
        nudSoTien.Value = 0;
        txtGhiChu.Clear();
        txtNoiDung.Focus();
    }

    private void DocTuForm(ChiTieu ct)
    {
        ct.NgayChi = DateOnly.FromDateTime(dtpNgayChi.Value);
        ct.NoiDung = txtNoiDung.Text.Trim();
        ct.LoaiChi = cboLoaiChi.SelectedItem?.ToString() ?? "Khác";
        ct.SoTien = nudSoTien.Value;
        ct.GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim();
    }

    /// <summary>Nội dung không rỗng, số tiền &gt; 0, ngày chi không lớn hơn hôm nay.</summary>
    private bool KiemTraHopLe()
    {
        if (string.IsNullOrWhiteSpace(txtNoiDung.Text))
            return Canh("Nội dung không được để trống.", txtNoiDung);

        if (cboLoaiChi.SelectedIndex < 0)
            return Canh("Hãy chọn loại chi.", cboLoaiChi);

        if (nudSoTien.Value <= 0)
            return Canh("Số tiền phải lớn hơn 0.", nudSoTien);

        if (DateOnly.FromDateTime(dtpNgayChi.Value) > DateOnly.FromDateTime(DateTime.Today))
            return Canh("Ngày chi không được lớn hơn ngày hôm nay.", dtpNgayChi);

        return true;
    }

    private bool Canh(string thongBao, Control control)
    {
        MessageBox.Show(this, thongBao, "Dữ liệu chưa hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        control.Focus();
        return false;
    }

    /// <summary>Ghi log mức Error kèm exception, rồi báo người dùng một thông báo thân thiện.</summary>
    private void BaoLoiCsdl(string viecDangLam, Exception ex)
    {
        Log.Error(ex, "Lỗi CSDL khi {ViecDangLam}", viecDangLam);
        MessageBox.Show(this,
            $"Không thể {viecDangLam} vì chưa truy cập được cơ sở dữ liệu.\n\n" +
            "Hãy kiểm tra SQL Server đã chạy chưa và chuỗi kết nối trong file appsettings.json, rồi thử lại.\n" +
            "(Chi tiết lỗi đã được ghi vào thư mục Logs.)",
            "Lỗi cơ sở dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
