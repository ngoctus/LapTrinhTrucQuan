using Microsoft.EntityFrameworkCore;
using SunriseHomestay.Models;

namespace SunriseHomestay
{
    public partial class FrmLoaiPhong : Form
    {
        public FrmLoaiPhong()
        {
            InitializeComponent();
        }

        private async void FrmLoaiPhong_Load(object? sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                using var db = new SunriseHomestayContext();
                dgvLoaiPhong.DataSource = await db.LoaiPhongs.OrderBy(x => x.MaLoai).ToListAsync();

                if (dgvLoaiPhong.Columns.Count > 0)
                {
                    dgvLoaiPhong.Columns[nameof(LoaiPhong.MaLoai)]!.HeaderText = "Mã loại";
                    dgvLoaiPhong.Columns[nameof(LoaiPhong.TenLoai)]!.HeaderText = "Tên loại";
                    dgvLoaiPhong.Columns[nameof(LoaiPhong.GiaMoiDem)]!.HeaderText = "Giá mỗi đêm";
                    dgvLoaiPhong.Columns[nameof(LoaiPhong.GiaMoiDem)]!.DefaultCellStyle.Format = "N0";
                    dgvLoaiPhong.Columns[nameof(LoaiPhong.MoTa)]!.HeaderText = "Mô tả";
                    // Cột navigation (ICollection<Phong>) không cần hiển thị
                    if (dgvLoaiPhong.Columns[nameof(LoaiPhong.Phongs)] != null)
                        dgvLoaiPhong.Columns[nameof(LoaiPhong.Phongs)]!.Visible = false;
                }

                dgvLoaiPhong.ClearSelection();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtMaLoai.Clear();
            txtTenLoai.Clear();
            txtGiaMoiDem.Clear();
            txtMoTa.Clear();
        }

        private void dgvLoaiPhong_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvLoaiPhong.CurrentRow?.DataBoundItem is not LoaiPhong lp || !dgvLoaiPhong.CurrentRow.Selected)
                return;

            txtMaLoai.Text = lp.MaLoai.ToString();
            txtTenLoai.Text = lp.TenLoai;
            txtGiaMoiDem.Text = lp.GiaMoiDem?.ToString("0.##") ?? "";
            txtMoTa.Text = lp.MoTa ?? "";
        }

        private bool ValidateInput(out decimal gia)
        {
            gia = 0;
            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
            {
                MessageBox.Show("Tên loại phòng không được để trống.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoai.Focus();
                return false;
            }
            if (!decimal.TryParse(txtGiaMoiDem.Text.Trim(), out gia) || gia < 0)
            {
                MessageBox.Show("Giá mỗi đêm phải là số không âm.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaMoiDem.Focus();
                return false;
            }
            return true;
        }

        private async void btnThem_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput(out decimal gia)) return;

            try
            {
                using var db = new SunriseHomestayContext();
                db.LoaiPhongs.Add(new LoaiPhong
                {
                    TenLoai = txtTenLoai.Text.Trim(),
                    GiaMoiDem = gia,
                    MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim()
                });
                await db.SaveChangesAsync();

                MessageBox.Show("Thêm loại phòng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Không thể thêm loại phòng.\n" + (ex.InnerException?.Message ?? ex.Message),
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaLoai.Text, out int ma))
            {
                MessageBox.Show("Vui lòng chọn một loại phòng trong danh sách để sửa.", "Chưa chọn dòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput(out decimal gia)) return;

            try
            {
                using var db = new SunriseHomestayContext();
                var lp = await db.LoaiPhongs.FindAsync(ma);
                if (lp == null)
                {
                    MessageBox.Show("Loại phòng không còn tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadDataAsync();
                    return;
                }

                lp.TenLoai = txtTenLoai.Text.Trim();
                lp.GiaMoiDem = gia;
                lp.MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim();
                await db.SaveChangesAsync();

                MessageBox.Show("Cập nhật loại phòng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Không thể cập nhật loại phòng.\n" + (ex.InnerException?.Message ?? ex.Message),
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaLoai.Text, out int ma))
            {
                MessageBox.Show("Vui lòng chọn một loại phòng trong danh sách để xóa.", "Chưa chọn dòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa loại phòng \"" + txtTenLoai.Text + "\" không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using var db = new SunriseHomestayContext();
                var lp = await db.LoaiPhongs.FindAsync(ma);
                if (lp == null)
                {
                    MessageBox.Show("Loại phòng không còn tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadDataAsync();
                    return;
                }

                db.LoaiPhongs.Remove(lp);
                await db.SaveChangesAsync();

                MessageBox.Show("Xóa loại phòng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Không thể xóa vì loại phòng này đang có phòng sử dụng.",
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
