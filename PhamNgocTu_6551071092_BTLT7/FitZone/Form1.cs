using Microsoft.EntityFrameworkCore;
using FitZone.Models;

namespace FitZone
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object? sender, EventArgs e)
        {
            cboHang.SelectedIndex = 0;
            cboTimHang.SelectedIndex = 0;
            await LoadDataAsync();
        }

        // Tải danh sách; tìm kiếm kết hợp Họ tên (Contains) && Hạng thành viên
        private async Task LoadDataAsync()
        {
            try
            {
                string ten = txtTimTen.Text.Trim();
                string hang = cboTimHang.SelectedIndex > 0 ? cboTimHang.Text : "";

                using var db = new FitZoneContext();
                var list = await db.HoiViens
                    .Where(x => (ten == "" || x.HoTen.Contains(ten)) && (hang == "" || x.HangThanhVien == hang))
                    .OrderBy(x => x.MaHV)
                    .ToListAsync();

                dgvHoiVien.DataSource = list;

                if (dgvHoiVien.Columns.Count > 0)
                {
                    dgvHoiVien.Columns[nameof(HoiVien.MaHV)]!.HeaderText = "Mã HV";
                    dgvHoiVien.Columns[nameof(HoiVien.HoTen)]!.HeaderText = "Họ tên";
                    dgvHoiVien.Columns[nameof(HoiVien.GioiTinh)]!.HeaderText = "Giới tính";
                    dgvHoiVien.Columns[nameof(HoiVien.NgaySinh)]!.HeaderText = "Ngày sinh";
                    dgvHoiVien.Columns[nameof(HoiVien.NgaySinh)]!.DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvHoiVien.Columns[nameof(HoiVien.SDT)]!.HeaderText = "SĐT";
                    dgvHoiVien.Columns[nameof(HoiVien.Email)]!.HeaderText = "Email";
                    dgvHoiVien.Columns[nameof(HoiVien.HangThanhVien)]!.HeaderText = "Hạng";
                    dgvHoiVien.Columns[nameof(HoiVien.NgayDangKy)]!.HeaderText = "Ngày đăng ký";
                    dgvHoiVien.Columns[nameof(HoiVien.NgayDangKy)]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvHoiVien.Columns[nameof(HoiVien.TrangThai)]!.HeaderText = "Trạng thái";
                }

                dgvHoiVien.ClearSelection();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hiển thị bit -> chữ cho 2 cột GioiTinh, TrangThai
        private void dgvHoiVien_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            string col = dgvHoiVien.Columns[e.ColumnIndex].DataPropertyName;
            if (col == nameof(HoiVien.GioiTinh))
            {
                e.Value = e.Value is bool b ? (b ? "Nam" : "Nữ") : "";
                e.FormattingApplied = true;
            }
            else if (col == nameof(HoiVien.TrangThai))
            {
                e.Value = e.Value is bool b ? (b ? "Đang hoạt động" : "Ngừng") : "";
                e.FormattingApplied = true;
            }
        }

        private void ClearInputs()
        {
            txtMaHV.Clear();
            txtHoTen.Clear();
            rdoNam.Checked = true;
            dtpNgaySinh.Value = new DateTime(2000, 1, 1);
            txtSDT.Clear();
            txtEmail.Clear();
            cboHang.SelectedIndex = 0;
            chkTrangThai.Checked = true;
            ClearErrors();
        }

        private void ClearErrors()
        {
            foreach (Control c in new Control[] { txtHoTen, dtpNgaySinh, txtSDT, txtEmail, cboHang })
                errorProvider1.SetError(c, "");
        }

        // Chọn dòng -> đổ toàn bộ dữ liệu lên Form
        private void dgvHoiVien_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvHoiVien.CurrentRow?.DataBoundItem is not HoiVien hv || !dgvHoiVien.CurrentRow.Selected)
                return;

            ClearErrors();
            txtMaHV.Text = hv.MaHV.ToString();
            txtHoTen.Text = hv.HoTen;
            if (hv.GioiTinh == false) rdoNu.Checked = true; else rdoNam.Checked = true;
            dtpNgaySinh.Value = hv.NgaySinh.HasValue
                ? hv.NgaySinh.Value.ToDateTime(TimeOnly.MinValue)
                : new DateTime(2000, 1, 1);
            txtSDT.Text = hv.SDT ?? "";
            txtEmail.Text = hv.Email ?? "";
            int idx = cboHang.FindStringExact(hv.HangThanhVien ?? "");
            cboHang.SelectedIndex = idx >= 0 ? idx : 0;
            chkTrangThai.Checked = hv.TrangThai ?? false;
        }

        // Validate từng trường, báo lỗi riêng bằng ErrorProvider. Trả về true nếu hợp lệ.
        private bool ValidateInput()
        {
            ClearErrors();
            Control? first = null;

            void Fail(Control c, string msg)
            {
                errorProvider1.SetError(c, msg);
                first ??= c;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
                Fail(txtHoTen, "Họ tên không được để trống.");

            string sdt = txtSDT.Text.Trim();
            if (sdt.Length == 0)
                Fail(txtSDT, "SĐT không được để trống.");
            else if (!sdt.All(char.IsAsciiDigit))
                Fail(txtSDT, "SĐT chỉ được chứa chữ số.");
            else if (sdt.Length < 9 || sdt.Length > 11)
                Fail(txtSDT, "SĐT phải dài từ 9 đến 11 ký tự.");

            string email = txtEmail.Text.Trim();
            if (email.Length == 0)
                Fail(txtEmail, "Email không được để trống.");
            else if (!email.Contains('@'))
                Fail(txtEmail, "Email phải chứa ký tự @.");

            DateTime ns = dtpNgaySinh.Value.Date;
            int tuoi = DateTime.Today.Year - ns.Year;
            if (ns > DateTime.Today.AddYears(-tuoi)) tuoi--;
            if (tuoi < 15)
                Fail(dtpNgaySinh, "Hội viên phải từ 15 tuổi trở lên.");

            if (cboHang.SelectedIndex < 0)
                Fail(cboHang, "Vui lòng chọn hạng thành viên.");

            if (first != null)
            {
                MessageBox.Show("Dữ liệu chưa hợp lệ, vui lòng xem các thông báo lỗi bên cạnh từng ô.",
                    "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                first.Focus();
                return false;
            }
            return true;
        }

        private void FillFromInputs(HoiVien hv)
        {
            hv.HoTen = txtHoTen.Text.Trim();
            hv.GioiTinh = rdoNam.Checked;
            hv.NgaySinh = DateOnly.FromDateTime(dtpNgaySinh.Value);
            hv.SDT = txtSDT.Text.Trim();
            hv.Email = txtEmail.Text.Trim();
            hv.HangThanhVien = cboHang.Text;
            hv.TrangThai = chkTrangThai.Checked;
        }

        private async void btnThem_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using var db = new FitZoneContext();
                var hv = new HoiVien();   // NgayDangKy để null -> SQL Server gán GETDATE()
                FillFromInputs(hv);
                db.HoiViens.Add(hv);
                await db.SaveChangesAsync();

                MessageBox.Show("Thêm hội viên thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Không thể thêm hội viên.\n" + (ex.InnerException?.Message ?? ex.Message),
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaHV.Text, out int ma))
            {
                MessageBox.Show("Vui lòng chọn một hội viên trong danh sách để sửa.", "Chưa chọn dòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;

            try
            {
                using var db = new FitZoneContext();
                var hv = await db.HoiViens.FindAsync(ma);
                if (hv == null)
                {
                    MessageBox.Show("Hội viên không còn tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadDataAsync();
                    return;
                }

                FillFromInputs(hv);
                await db.SaveChangesAsync();

                MessageBox.Show("Cập nhật hội viên thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Không thể cập nhật hội viên.\n" + (ex.InnerException?.Message ?? ex.Message),
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaHV.Text, out int ma))
            {
                MessageBox.Show("Vui lòng chọn một hội viên trong danh sách để xóa.", "Chưa chọn dòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa hội viên \"" + txtHoTen.Text + "\" không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using var db = new FitZoneContext();
                var hv = await db.HoiViens.FindAsync(ma);
                if (hv == null)
                {
                    MessageBox.Show("Hội viên không còn tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadDataAsync();
                    return;
                }

                db.HoiViens.Remove(hv);
                await db.SaveChangesAsync();

                MessageBox.Show("Xóa hội viên thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Không thể xóa vì hội viên này đang được tham chiếu bởi dữ liệu khác.",
                    "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLamMoi_Click(object? sender, EventArgs e)
        {
            txtTimTen.Clear();
            cboTimHang.SelectedIndex = 0;
            await LoadDataAsync();
        }

        private async void btnTimKiem_Click(object? sender, EventArgs e)
        {
            await LoadDataAsync();
        }
    }
}
