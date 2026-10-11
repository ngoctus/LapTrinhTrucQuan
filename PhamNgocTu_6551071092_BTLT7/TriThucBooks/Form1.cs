using Microsoft.EntityFrameworkCore;
using TriThucBooks.Models;

namespace TriThucBooks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object? sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        // Tải danh sách (có thể lọc theo TenTheLoai bằng LINQ Contains)
        private async Task LoadDataAsync(string? keyword = null)
        {
            try
            {
                using var db = new TriThucBooksContext();
                var query = db.TheLoaiSaches.AsQueryable();
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    string kw = keyword.Trim();
                    query = query.Where(x => x.TenTheLoai.Contains(kw));
                }

                var list = await query.OrderBy(x => x.MaTL).ToListAsync();
                dgvTheLoai.DataSource = list;

                if (dgvTheLoai.Columns.Count > 0)
                {
                    dgvTheLoai.Columns[nameof(TheLoaiSach.MaTL)]!.HeaderText = "Mã TL";
                    dgvTheLoai.Columns[nameof(TheLoaiSach.TenTheLoai)]!.HeaderText = "Tên thể loại";
                    dgvTheLoai.Columns[nameof(TheLoaiSach.MoTa)]!.HeaderText = "Mô tả";
                    dgvTheLoai.Columns[nameof(TheLoaiSach.SoLuongSach)]!.HeaderText = "Số lượng sách";
                    dgvTheLoai.Columns[nameof(TheLoaiSach.NgayTao)]!.HeaderText = "Ngày tạo";
                    dgvTheLoai.Columns[nameof(TheLoaiSach.NgayTao)]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }

                dgvTheLoai.ClearSelection();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtMaTL.Clear();
            txtTenTheLoai.Clear();
            txtMoTa.Clear();
            nudSoLuongSach.Value = 0;
            dtpNgayTao.Value = DateTime.Now;
        }

        // Chọn dòng -> đổ dữ liệu lên control
        private void dgvTheLoai_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvTheLoai.CurrentRow?.DataBoundItem is not TheLoaiSach tl || !dgvTheLoai.CurrentRow.Selected)
                return;

            txtMaTL.Text = tl.MaTL.ToString();
            txtTenTheLoai.Text = tl.TenTheLoai;
            txtMoTa.Text = tl.MoTa ?? "";
            nudSoLuongSach.Value = Math.Clamp(tl.SoLuongSach ?? 0, (int)nudSoLuongSach.Minimum, (int)nudSoLuongSach.Maximum);
            dtpNgayTao.Value = tl.NgayTao ?? DateTime.Now;
        }

        private bool ValidateInput(out string ten)
        {
            ten = txtTenTheLoai.Text.Trim();
            if (ten.Length == 0)
            {
                MessageBox.Show("Tên thể loại không được để trống.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTheLoai.Focus();
                return false;
            }
            return true;
        }

        private async void btnThem_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput(out string ten)) return;

            try
            {
                using var db = new TriThucBooksContext();
                if (await db.TheLoaiSaches.AnyAsync(x => x.TenTheLoai == ten))
                {
                    MessageBox.Show("Tên thể loại \"" + ten + "\" đã tồn tại.", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTheLoai.Focus();
                    return;
                }

                var tl = new TheLoaiSach
                {
                    TenTheLoai = ten,
                    MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim(),
                    SoLuongSach = (int)nudSoLuongSach.Value
                    // NgayTao: để null -> SQL Server tự gán GETDATE()
                };
                db.TheLoaiSaches.Add(tl);
                await db.SaveChangesAsync();

                MessageBox.Show("Thêm thể loại thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Không thể thêm thể loại (có thể trùng tên hoặc vi phạm ràng buộc).\n" + (ex.InnerException?.Message ?? ex.Message),
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaTL.Text, out int ma))
            {
                MessageBox.Show("Vui lòng chọn một thể loại trong danh sách để sửa.", "Chưa chọn dòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput(out string ten)) return;

            try
            {
                using var db = new TriThucBooksContext();
                var tl = await db.TheLoaiSaches.FindAsync(ma);
                if (tl == null)
                {
                    MessageBox.Show("Thể loại không còn tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadDataAsync();
                    return;
                }

                if (await db.TheLoaiSaches.AnyAsync(x => x.TenTheLoai == ten && x.MaTL != ma))
                {
                    MessageBox.Show("Tên thể loại \"" + ten + "\" đã tồn tại.", "Trùng dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTheLoai.Focus();
                    return;
                }

                tl.TenTheLoai = ten;
                tl.MoTa = string.IsNullOrWhiteSpace(txtMoTa.Text) ? null : txtMoTa.Text.Trim();
                tl.SoLuongSach = (int)nudSoLuongSach.Value;
                await db.SaveChangesAsync();

                MessageBox.Show("Cập nhật thể loại thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Không thể cập nhật thể loại.\n" + (ex.InnerException?.Message ?? ex.Message),
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaTL.Text, out int ma))
            {
                MessageBox.Show("Vui lòng chọn một thể loại trong danh sách để xóa.", "Chưa chọn dòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa thể loại \"" + txtTenTheLoai.Text + "\" không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using var db = new TriThucBooksContext();
                var tl = await db.TheLoaiSaches.FindAsync(ma);
                if (tl == null)
                {
                    MessageBox.Show("Thể loại không còn tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadDataAsync();
                    return;
                }

                db.TheLoaiSaches.Remove(tl);
                await db.SaveChangesAsync();

                MessageBox.Show("Xóa thể loại thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Không thể xóa vì thể loại này đang được tham chiếu bởi dữ liệu khác.",
                    "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLamMoi_Click(object? sender, EventArgs e)
        {
            txtTimKiem.Clear();
            await LoadDataAsync();
        }

        private async void btnTimKiem_Click(object? sender, EventArgs e)
        {
            await LoadDataAsync(txtTimKiem.Text);
        }
    }
}
