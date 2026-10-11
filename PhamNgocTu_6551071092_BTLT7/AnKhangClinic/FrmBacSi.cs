using Microsoft.EntityFrameworkCore;
using AnKhangClinic.Models;

namespace AnKhangClinic
{
    public partial class FrmBacSi : Form
    {
        public FrmBacSi()
        {
            InitializeComponent();
        }

        private async void FrmBacSi_Load(object? sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                using var db = new AnKhangClinicContext();
                dgvBacSi.DataSource = await db.BacSis.OrderBy(x => x.MaBS).ToListAsync();

                if (dgvBacSi.Columns.Count > 0)
                {
                    dgvBacSi.Columns[nameof(BacSi.MaBS)]!.HeaderText = "Mã BS";
                    dgvBacSi.Columns[nameof(BacSi.HoTen)]!.HeaderText = "Họ tên";
                    dgvBacSi.Columns[nameof(BacSi.ChuyenKhoa)]!.HeaderText = "Chuyên khoa";
                    dgvBacSi.Columns[nameof(BacSi.SDT)]!.HeaderText = "SĐT";
                    if (dgvBacSi.Columns[nameof(BacSi.LichKhams)] != null)
                        dgvBacSi.Columns[nameof(BacSi.LichKhams)]!.Visible = false;
                }

                dgvBacSi.ClearSelection();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtMaBS.Clear();
            txtHoTen.Clear();
            txtChuyenKhoa.Clear();
            txtSDT.Clear();
        }

        private void dgvBacSi_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvBacSi.CurrentRow?.DataBoundItem is not BacSi bs || !dgvBacSi.CurrentRow.Selected)
                return;

            txtMaBS.Text = bs.MaBS.ToString();
            txtHoTen.Text = bs.HoTen;
            txtChuyenKhoa.Text = bs.ChuyenKhoa ?? "";
            txtSDT.Text = bs.SDT ?? "";
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên bác sĩ không được để trống.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }
            return true;
        }

        private static string? NullIfEmpty(string s) => string.IsNullOrWhiteSpace(s) ? null : s.Trim();

        private async void btnThem_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using var db = new AnKhangClinicContext();
                db.BacSis.Add(new BacSi
                {
                    HoTen = txtHoTen.Text.Trim(),
                    ChuyenKhoa = NullIfEmpty(txtChuyenKhoa.Text),
                    SDT = NullIfEmpty(txtSDT.Text)
                });
                await db.SaveChangesAsync();

                MessageBox.Show("Thêm bác sĩ thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Không thể thêm bác sĩ.\n" + (ex.InnerException?.Message ?? ex.Message),
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaBS.Text, out int ma))
            {
                MessageBox.Show("Vui lòng chọn một bác sĩ trong danh sách để sửa.", "Chưa chọn dòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;

            try
            {
                using var db = new AnKhangClinicContext();
                var bs = await db.BacSis.FindAsync(ma);
                if (bs == null)
                {
                    MessageBox.Show("Bác sĩ không còn tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadDataAsync();
                    return;
                }

                bs.HoTen = txtHoTen.Text.Trim();
                bs.ChuyenKhoa = NullIfEmpty(txtChuyenKhoa.Text);
                bs.SDT = NullIfEmpty(txtSDT.Text);
                await db.SaveChangesAsync();

                MessageBox.Show("Cập nhật bác sĩ thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Không thể cập nhật bác sĩ.\n" + (ex.InnerException?.Message ?? ex.Message),
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaBS.Text, out int ma))
            {
                MessageBox.Show("Vui lòng chọn một bác sĩ trong danh sách để xóa.", "Chưa chọn dòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa bác sĩ \"" + txtHoTen.Text + "\" không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using var db = new AnKhangClinicContext();
                var bs = await db.BacSis.FindAsync(ma);
                if (bs == null)
                {
                    MessageBox.Show("Bác sĩ không còn tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadDataAsync();
                    return;
                }

                db.BacSis.Remove(bs);
                await db.SaveChangesAsync();

                MessageBox.Show("Xóa bác sĩ thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Không thể xóa vì bác sĩ này đang có lịch khám.",
                    "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLamMoi_Click(object? sender, EventArgs e)
        {
            await LoadDataAsync();
        }
    }
}
