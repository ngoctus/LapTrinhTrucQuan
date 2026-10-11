using Microsoft.EntityFrameworkCore;
using AnKhangClinic.Models;

namespace AnKhangClinic
{
    public partial class Form1 : Form
    {
        // Item cho ComboBox bác sĩ: "BS. Họ tên - Chuyên khoa"
        private record BacSiItem(int MaBS, string HienThi);

        // Một dòng hiển thị trên DataGridView
        private class LichRow
        {
            public int MaLich { get; set; }
            public string TenBenhNhan { get; set; } = "";
            public string? SDT { get; set; }
            public DateOnly? NgayKham { get; set; }
            public TimeOnly? GioKham { get; set; }
            public int? MaBS { get; set; }
            public string? BacSi { get; set; }
            public string? ChuyenKhoa { get; set; }
            public string? TrangThai { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object? sender, EventArgs e)
        {
            SetupGrid();
            cboTrangThai.SelectedIndex = 0;
            await LoadBacSiAsync();
            await LoadDataAsync();
        }

        private void SetupGrid()
        {
            dgvLichKham.AutoGenerateColumns = false;
            dgvLichKham.Columns.Clear();
            dgvLichKham.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên bệnh nhân", DataPropertyName = nameof(LichRow.TenBenhNhan), FillWeight = 110 });
            dgvLichKham.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "SĐT", DataPropertyName = nameof(LichRow.SDT), FillWeight = 70 });
            dgvLichKham.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngày khám", DataPropertyName = nameof(LichRow.NgayKham), FillWeight = 70, DefaultCellStyle = { Format = "dd/MM/yyyy" } });
            dgvLichKham.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giờ khám", DataPropertyName = nameof(LichRow.GioKham), FillWeight = 50, DefaultCellStyle = { Format = "HH:mm" } });
            dgvLichKham.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Bác sĩ", DataPropertyName = nameof(LichRow.BacSi), FillWeight = 90 });
            dgvLichKham.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Chuyên khoa", DataPropertyName = nameof(LichRow.ChuyenKhoa), FillWeight = 90 });
            dgvLichKham.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trạng thái", DataPropertyName = nameof(LichRow.TrangThai), FillWeight = 70 });
        }

        private async Task LoadBacSiAsync()
        {
            try
            {
                using var db = new AnKhangClinicContext();
                var ds = await db.BacSis.OrderBy(x => x.HoTen).ToListAsync();
                var items = ds.Select(b => new BacSiItem(b.MaBS, $"BS. {b.HoTen} - {b.ChuyenKhoa}")).ToList();

                cboBacSi.DataSource = null;
                cboBacSi.DisplayMember = nameof(BacSiItem.HienThi);
                cboBacSi.ValueMember = nameof(BacSiItem.MaBS);
                cboBacSi.DataSource = items.ToList();
                cboBacSi.SelectedIndex = -1;

                var tim = new List<BacSiItem> { new BacSiItem(0, "Tất cả") };
                tim.AddRange(items);
                cboTimBacSi.DataSource = null;
                cboTimBacSi.DisplayMember = nameof(BacSiItem.HienThi);
                cboTimBacSi.ValueMember = nameof(BacSiItem.MaBS);
                cboTimBacSi.DataSource = tim;
                cboTimBacSi.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách bác sĩ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tải danh sách lịch khám: Include + Where (>=, <=, ==)
        private async Task LoadDataAsync()
        {
            try
            {
                DateOnly? tuNgay = dtpTuNgay.Checked ? DateOnly.FromDateTime(dtpTuNgay.Value) : null;
                DateOnly? denNgay = dtpDenNgay.Checked ? DateOnly.FromDateTime(dtpDenNgay.Value) : null;
                int? maBS = cboTimBacSi.SelectedValue is int v && v > 0 ? v : null;

                if (tuNgay != null && denNgay != null && tuNgay > denNgay)
                {
                    MessageBox.Show("\"Từ ngày\" không được lớn hơn \"Đến ngày\".", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using var db = new AnKhangClinicContext();
                var lichs = await db.LichKhams
                    .Include(x => x.MaBSNavigation)
                    .Where(x => (tuNgay == null || x.NgayKham >= tuNgay)
                             && (denNgay == null || x.NgayKham <= denNgay)
                             && (maBS == null || x.MaBS == maBS))
                    .OrderBy(x => x.NgayKham).ThenBy(x => x.GioKham)
                    .ToListAsync();

                var rows = lichs.Select(x => new LichRow
                {
                    MaLich = x.MaLich,
                    TenBenhNhan = x.TenBenhNhan,
                    SDT = x.SDT,
                    NgayKham = x.NgayKham,
                    GioKham = x.GioKham,
                    MaBS = x.MaBS,
                    BacSi = x.MaBSNavigation?.HoTen,
                    ChuyenKhoa = x.MaBSNavigation?.ChuyenKhoa,
                    TrangThai = x.TrangThai
                }).ToList();

                dgvLichKham.DataSource = rows;
                dgvLichKham.ClearSelection();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu lịch khám: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtMaLich.Clear();
            txtTenBenhNhan.Clear();
            txtSDT.Clear();
            dtpNgayKham.Value = DateTime.Today;
            dtpGioKham.Value = DateTime.Today.AddHours(8);
            cboBacSi.SelectedIndex = -1;
            cboTrangThai.SelectedIndex = 0;
        }

        // Chọn dòng -> đổ dữ liệu lên Form
        private void dgvLichKham_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvLichKham.CurrentRow?.DataBoundItem is not LichRow r || !dgvLichKham.CurrentRow.Selected)
                return;

            txtMaLich.Text = r.MaLich.ToString();
            txtTenBenhNhan.Text = r.TenBenhNhan;
            txtSDT.Text = r.SDT ?? "";
            dtpNgayKham.Value = r.NgayKham.HasValue ? r.NgayKham.Value.ToDateTime(TimeOnly.MinValue) : DateTime.Today;
            dtpGioKham.Value = DateTime.Today.Add(r.GioKham?.ToTimeSpan() ?? TimeSpan.Zero);
            cboBacSi.SelectedValue = r.MaBS ?? -1;
            int idx = cboTrangThai.FindStringExact(r.TrangThai ?? "");
            cboTrangThai.SelectedIndex = idx >= 0 ? idx : 0;
        }

        // Validate. originalDate != null khi đang sửa (cho phép giữ nguyên ngày cũ của lịch đã có)
        private bool ValidateInput(DateOnly? originalDate)
        {
            if (string.IsNullOrWhiteSpace(txtTenBenhNhan.Text))
            {
                MessageBox.Show("Tên bệnh nhân không được để trống.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenBenhNhan.Focus();
                return false;
            }
            if (cboBacSi.SelectedValue is not int)
            {
                MessageBox.Show("Vui lòng chọn bác sĩ.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboBacSi.Focus();
                return false;
            }

            var ngay = DateOnly.FromDateTime(dtpNgayKham.Value);
            bool ngayDoiHoacMoi = originalDate == null || originalDate != ngay;
            if (ngayDoiHoacMoi && ngay < DateOnly.FromDateTime(DateTime.Today))
            {
                MessageBox.Show("Không được đặt lịch khám vào ngày trong quá khứ.", "Ngày không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNgayKham.Focus();
                return false;
            }
            return true;
        }

        private async void btnThem_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput(null)) return;

            try
            {
                using var db = new AnKhangClinicContext();
                db.LichKhams.Add(new LichKham
                {
                    TenBenhNhan = txtTenBenhNhan.Text.Trim(),
                    SDT = string.IsNullOrWhiteSpace(txtSDT.Text) ? null : txtSDT.Text.Trim(),
                    NgayKham = DateOnly.FromDateTime(dtpNgayKham.Value),
                    GioKham = TimeOnly.FromDateTime(dtpGioKham.Value),
                    MaBS = (int)cboBacSi.SelectedValue!,
                    TrangThai = cboTrangThai.Text
                });
                await db.SaveChangesAsync();

                MessageBox.Show("Thêm lịch khám thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Không thể thêm lịch khám.\n" + (ex.InnerException?.Message ?? ex.Message),
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaLich.Text, out int ma))
            {
                MessageBox.Show("Vui lòng chọn một lịch khám trong danh sách để sửa.", "Chưa chọn dòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var db = new AnKhangClinicContext();
                var lich = await db.LichKhams.FindAsync(ma);
                if (lich == null)
                {
                    MessageBox.Show("Lịch khám không còn tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadDataAsync();
                    return;
                }

                if (!ValidateInput(lich.NgayKham)) return;

                lich.TenBenhNhan = txtTenBenhNhan.Text.Trim();
                lich.SDT = string.IsNullOrWhiteSpace(txtSDT.Text) ? null : txtSDT.Text.Trim();
                lich.NgayKham = DateOnly.FromDateTime(dtpNgayKham.Value);
                lich.GioKham = TimeOnly.FromDateTime(dtpGioKham.Value);
                lich.MaBS = (int)cboBacSi.SelectedValue!;
                lich.TrangThai = cboTrangThai.Text;
                await db.SaveChangesAsync();

                MessageBox.Show("Cập nhật lịch khám thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Không thể cập nhật lịch khám.\n" + (ex.InnerException?.Message ?? ex.Message),
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaLich.Text, out int ma))
            {
                MessageBox.Show("Vui lòng chọn một lịch khám trong danh sách để xóa.", "Chưa chọn dòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa lịch khám của \"" + txtTenBenhNhan.Text + "\" không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using var db = new AnKhangClinicContext();
                var lich = await db.LichKhams.FindAsync(ma);
                if (lich == null)
                {
                    MessageBox.Show("Lịch khám không còn tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadDataAsync();
                    return;
                }

                db.LichKhams.Remove(lich);
                await db.SaveChangesAsync();

                MessageBox.Show("Xóa lịch khám thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Không thể xóa lịch khám vì đang được tham chiếu bởi dữ liệu khác.",
                    "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLamMoi_Click(object? sender, EventArgs e)
        {
            dtpTuNgay.Checked = false;
            dtpDenNgay.Checked = false;
            if (cboTimBacSi.Items.Count > 0) cboTimBacSi.SelectedIndex = 0;
            await LoadDataAsync();
        }

        private async void btnTimKiem_Click(object? sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async void btnBacSi_Click(object? sender, EventArgs e)
        {
            using (var frm = new FrmBacSi())
            {
                frm.ShowDialog(this);
            }
            await LoadBacSiAsync();   // cập nhật ComboBox sau khi sửa Bác sĩ
            await LoadDataAsync();
        }
    }
}
