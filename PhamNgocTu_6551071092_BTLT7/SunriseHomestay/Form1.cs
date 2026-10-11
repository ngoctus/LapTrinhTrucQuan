using Microsoft.EntityFrameworkCore;
using SunriseHomestay.Models;

namespace SunriseHomestay
{
    public partial class Form1 : Form
    {
        // Một dòng hiển thị trên DataGridView (thumbnail + dữ liệu phòng)
        private class PhongRow
        {
            public int MaPhong { get; set; }
            public string SoPhong { get; set; } = "";
            public int? TangSo { get; set; }
            public string? TenLoai { get; set; }
            public string? TinhTrang { get; set; }
            public string? HinhAnh { get; set; }      // chỉ TÊN FILE
            public Image? Thumbnail { get; set; }
            public int? MaLoai { get; set; }
        }

        private static string ImagesFolder => Path.Combine(Application.StartupPath, "Images");

        private string? _selectedImagePath;           // ảnh vừa chọn từ máy, chưa copy vào thư mục Images
        private readonly List<Image> _thumbs = new();

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object? sender, EventArgs e)
        {
            SetupGrid();
            cboTinhTrang.SelectedIndex = 0;
            cboTimTinhTrang.Items.AddRange(new object[] { "Tất cả", "Trống", "Đang ở", "Đang dọn" });
            cboTimTinhTrang.SelectedIndex = 0;
            await LoadLoaiPhongAsync();
            await LoadDataAsync();
        }

        private void SetupGrid()
        {
            dgvPhong.AutoGenerateColumns = false;
            dgvPhong.Columns.Clear();
            dgvPhong.Columns.Add(new DataGridViewImageColumn
            {
                Name = "colHinh",
                HeaderText = "Hình",
                DataPropertyName = nameof(PhongRow.Thumbnail),
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                FillWeight = 40
            });
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã phòng", DataPropertyName = nameof(PhongRow.MaPhong), FillWeight = 40 });
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số phòng", DataPropertyName = nameof(PhongRow.SoPhong), FillWeight = 50 });
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tầng", DataPropertyName = nameof(PhongRow.TangSo), FillWeight = 35 });
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Loại phòng", DataPropertyName = nameof(PhongRow.TenLoai), FillWeight = 80 });
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tình trạng", DataPropertyName = nameof(PhongRow.TinhTrang), FillWeight = 70 });
            dgvPhong.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên file ảnh", DataPropertyName = nameof(PhongRow.HinhAnh), FillWeight = 90 });
        }

        // Đọc ảnh từ thư mục Images mà không khóa file
        private static Image? LoadImage(string? fileName, int? maxSize = null)
        {
            if (string.IsNullOrWhiteSpace(fileName)) return null;
            string path = Path.Combine(ImagesFolder, fileName);
            if (!File.Exists(path)) return null;
            try
            {
                using var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                using var src = Image.FromStream(fs);
                if (maxSize == null) return new Bitmap(src);
                double ratio = Math.Min((double)maxSize.Value / src.Width, (double)maxSize.Value / src.Height);
                ratio = Math.Min(ratio, 1);
                return new Bitmap(src, Math.Max(1, (int)(src.Width * ratio)), Math.Max(1, (int)(src.Height * ratio)));
            }
            catch
            {
                return null;
            }
        }

        private async Task LoadLoaiPhongAsync()
        {
            try
            {
                using var db = new SunriseHomestayContext();
                var loai = await db.LoaiPhongs.OrderBy(x => x.TenLoai).ToListAsync();

                // ComboBox nhập liệu
                cboLoaiPhong.DataSource = null;
                cboLoaiPhong.DisplayMember = nameof(LoaiPhong.TenLoai);
                cboLoaiPhong.ValueMember = nameof(LoaiPhong.MaLoai);
                cboLoaiPhong.DataSource = loai.ToList();
                cboLoaiPhong.SelectedIndex = -1;

                // ComboBox tìm kiếm (thêm mục "Tất cả")
                var tim = new List<LoaiPhong> { new LoaiPhong { MaLoai = 0, TenLoai = "Tất cả" } };
                tim.AddRange(loai);
                cboTimLoai.DataSource = null;
                cboTimLoai.DisplayMember = nameof(LoaiPhong.TenLoai);
                cboTimLoai.ValueMember = nameof(LoaiPhong.MaLoai);
                cboTimLoai.DataSource = tim;
                cboTimLoai.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải danh sách loại phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tải danh sách phòng: Where + Include, lọc đồng thời Tình trạng và Loại phòng
        private async Task LoadDataAsync()
        {
            try
            {
                string? tinhTrang = cboTimTinhTrang.SelectedIndex > 0 ? cboTimTinhTrang.Text : null;
                int? maLoai = cboTimLoai.SelectedValue is int v && v > 0 ? v : null;

                using var db = new SunriseHomestayContext();
                var phongs = await db.Phongs
                    .Include(x => x.MaLoaiNavigation)
                    .Where(x => (tinhTrang == null || x.TinhTrang == tinhTrang) && (maLoai == null || x.MaLoai == maLoai))
                    .OrderBy(x => x.MaPhong)
                    .ToListAsync();

                foreach (var img in _thumbs) img.Dispose();
                _thumbs.Clear();

                var rows = phongs.Select(p =>
                {
                    var thumb = LoadImage(p.HinhAnh, 80);
                    if (thumb != null) _thumbs.Add(thumb);
                    return new PhongRow
                    {
                        MaPhong = p.MaPhong,
                        SoPhong = p.SoPhong,
                        TangSo = p.TangSo,
                        TenLoai = p.MaLoaiNavigation?.TenLoai,
                        TinhTrang = p.TinhTrang,
                        HinhAnh = p.HinhAnh,
                        Thumbnail = thumb,
                        MaLoai = p.MaLoai
                    };
                }).ToList();

                dgvPhong.DataSource = rows;
                dgvPhong.ClearSelection();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải dữ liệu phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtMaPhong.Clear();
            txtSoPhong.Clear();
            nudTangSo.Value = nudTangSo.Minimum;
            cboLoaiPhong.SelectedIndex = -1;
            cboTinhTrang.SelectedIndex = 0;
            _selectedImagePath = null;
            SetPreview(null);
        }

        private void SetPreview(Image? img)
        {
            var old = picHinhAnh.Image;
            picHinhAnh.Image = img;
            old?.Dispose();
        }

        // Chọn dòng -> đổ dữ liệu lên Form và hiển thị ảnh
        private void dgvPhong_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvPhong.CurrentRow?.DataBoundItem is not PhongRow r || !dgvPhong.CurrentRow.Selected)
                return;

            txtMaPhong.Text = r.MaPhong.ToString();
            txtSoPhong.Text = r.SoPhong;
            nudTangSo.Value = Math.Clamp(r.TangSo ?? 1, (int)nudTangSo.Minimum, (int)nudTangSo.Maximum);
            cboLoaiPhong.SelectedValue = r.MaLoai ?? -1;
            int idx = cboTinhTrang.FindStringExact(r.TinhTrang ?? "");
            cboTinhTrang.SelectedIndex = idx >= 0 ? idx : 0;
            _selectedImagePath = null;
            SetPreview(LoadImage(r.HinhAnh));
        }

        private void btnChonAnh_Click(object? sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

            try
            {
                using var fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                using var src = Image.FromStream(fs);
                SetPreview(new Bitmap(src));
                _selectedImagePath = openFileDialog1.FileName;
            }
            catch
            {
                MessageBox.Show("File được chọn không phải là ảnh hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Copy ảnh đã chọn vào thư mục Images của ứng dụng, trả về TÊN FILE để lưu database
        private string CopyImageToImagesFolder(string sourcePath)
        {
            Directory.CreateDirectory(ImagesFolder);
            string fileName = Path.GetFileName(sourcePath);
            string dest = Path.Combine(ImagesFolder, fileName);

            if (File.Exists(dest) && !string.Equals(Path.GetFullPath(dest), Path.GetFullPath(sourcePath), StringComparison.OrdinalIgnoreCase))
            {
                // Trùng tên với ảnh khác -> thêm hậu tố thời gian để không ghi đè
                fileName = Path.GetFileNameWithoutExtension(fileName) + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(fileName);
                dest = Path.Combine(ImagesFolder, fileName);
            }

            if (!File.Exists(dest))
                File.Copy(sourcePath, dest);
            return fileName;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtSoPhong.Text))
            {
                MessageBox.Show("Số phòng không được để trống.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoPhong.Focus();
                return false;
            }
            if (cboLoaiPhong.SelectedValue is not int)
            {
                MessageBox.Show("Vui lòng chọn loại phòng.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiPhong.Focus();
                return false;
            }
            if (cboTinhTrang.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn tình trạng phòng.", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTinhTrang.Focus();
                return false;
            }
            return true;
        }

        private async void btnThem_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                string? fileName = _selectedImagePath != null ? CopyImageToImagesFolder(_selectedImagePath) : null;

                using var db = new SunriseHomestayContext();
                db.Phongs.Add(new Phong
                {
                    SoPhong = txtSoPhong.Text.Trim(),
                    TangSo = (int)nudTangSo.Value,
                    TinhTrang = cboTinhTrang.Text,
                    HinhAnh = fileName,
                    MaLoai = (int)cboLoaiPhong.SelectedValue!
                });
                await db.SaveChangesAsync();

                MessageBox.Show("Thêm phòng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Không thể thêm phòng.\n" + (ex.InnerException?.Message ?? ex.Message),
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaPhong.Text, out int ma))
            {
                MessageBox.Show("Vui lòng chọn một phòng trong danh sách để sửa.", "Chưa chọn dòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;

            try
            {
                using var db = new SunriseHomestayContext();
                var p = await db.Phongs.FindAsync(ma);
                if (p == null)
                {
                    MessageBox.Show("Phòng không còn tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadDataAsync();
                    return;
                }

                p.SoPhong = txtSoPhong.Text.Trim();
                p.TangSo = (int)nudTangSo.Value;
                p.TinhTrang = cboTinhTrang.Text;
                p.MaLoai = (int)cboLoaiPhong.SelectedValue!;
                if (_selectedImagePath != null)
                    p.HinhAnh = CopyImageToImagesFolder(_selectedImagePath);   // chỉ lưu tên file
                await db.SaveChangesAsync();

                MessageBox.Show("Cập nhật phòng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Không thể cập nhật phòng.\n" + (ex.InnerException?.Message ?? ex.Message),
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(txtMaPhong.Text, out int ma))
            {
                MessageBox.Show("Vui lòng chọn một phòng trong danh sách để xóa.", "Chưa chọn dòng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa phòng " + txtSoPhong.Text + " không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using var db = new SunriseHomestayContext();
                var p = await db.Phongs.FindAsync(ma);
                if (p == null)
                {
                    MessageBox.Show("Phòng không còn tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    await LoadDataAsync();
                    return;
                }

                db.Phongs.Remove(p);
                await db.SaveChangesAsync();

                MessageBox.Show("Xóa phòng thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadDataAsync();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Không thể xóa vì phòng này đang được tham chiếu bởi dữ liệu khác.",
                    "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLamMoi_Click(object? sender, EventArgs e)
        {
            cboTimTinhTrang.SelectedIndex = 0;
            if (cboTimLoai.Items.Count > 0) cboTimLoai.SelectedIndex = 0;
            await LoadDataAsync();
        }

        private async void btnTimKiem_Click(object? sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async void btnLoaiPhong_Click(object? sender, EventArgs e)
        {
            using (var frm = new FrmLoaiPhong())
            {
                frm.ShowDialog(this);
            }
            await LoadLoaiPhongAsync();   // cập nhật lại ComboBox sau khi sửa Loại phòng
            await LoadDataAsync();
        }
    }
}
