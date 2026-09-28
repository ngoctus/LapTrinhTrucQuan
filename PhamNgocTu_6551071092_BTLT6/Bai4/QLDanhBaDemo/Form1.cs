namespace QLDanhBaDemo
{
    public partial class FormDanhBa : Form
    {
        private int _indexDangSua = -1; // -1: đang ở chế độ thêm mới

        public FormDanhBa()
        {
            InitializeComponent();

            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnThoat.Click += btnThoat_Click;
            FormClosing += FormDanhBa_FormClosing;
        }

        // Lấy tên từ chuỗi "Ten - SDT"
        private static string LayTen(string item)
        {
            int i = item.LastIndexOf(" - ");
            return i >= 0 ? item[..i] : item;
        }

        private void btnThem_Click(object? sender, EventArgs e)
        {
            string ten = txtTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();

            if (ten == "" || sdt == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên và số điện thoại.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dong = $"{ten} - {sdt}";

            if (_indexDangSua >= 0)
            {
                lstLienHe.Items[_indexDangSua] = dong;
                _indexDangSua = -1;
                txtTen.Clear();
                txtSDT.Clear();
                MessageBox.Show("Cập nhật thành công.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                lstLienHe.Items.Add(dong);
                txtTen.Clear();
                txtSDT.Clear();
                MessageBox.Show("Thêm thành công", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object? sender, EventArgs e)
        {
            if (lstLienHe.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn một liên hệ để sửa",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string item = lstLienHe.SelectedItem!.ToString()!;
            int i = item.LastIndexOf(" - ");

            txtTen.Text = LayTen(item);
            txtSDT.Text = i >= 0 ? item[(i + 3)..] : "";
            _indexDangSua = lstLienHe.SelectedIndex;
            txtTen.Focus();
        }

        private void btnXoa_Click(object? sender, EventArgs e)
        {
            int index = lstLienHe.SelectedIndex;

            if (index < 0)
            {
                MessageBox.Show("Vui lòng chọn một liên hệ để xóa",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ten = LayTen(lstLienHe.SelectedItem!.ToString()!);

            DialogResult kq = MessageBox.Show(
                $"Bạn có chắc muốn xóa liên hệ {ten}? Thao tác này không thể hoàn tác!",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (kq != DialogResult.Yes)
                return;

            lstLienHe.Items.RemoveAt(index);

            // Giữ _indexDangSua đúng sau khi xóa
            if (_indexDangSua == index)
            {
                _indexDangSua = -1;
                txtTen.Clear();
                txtSDT.Clear();
            }
            else if (_indexDangSua > index)
            {
                _indexDangSua--;
            }

            MessageBox.Show("Xóa thành công", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThoat_Click(object? sender, EventArgs e)
        {
            Close(); // sẽ đi qua FormClosing
        }

        private void FormDanhBa_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (txtTen.Text.Trim() == "" && txtSDT.Text.Trim() == "")
                return;

            DialogResult kq = MessageBox.Show(
                "Bạn có dữ liệu chưa được lưu. Bạn muốn thoát không?",
                "Xác nhận thoát", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (kq == DialogResult.Cancel)
                e.Cancel = true;
            else if (kq == DialogResult.No)
            {
                txtTen.Clear();
                txtSDT.Clear();
            }
            // Yes: cứ thoát
        }
    }
}