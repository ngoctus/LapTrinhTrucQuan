namespace BanVeDemo
{
    public partial class FormBanVe : Form
    {
        public FormBanVe()
        {
            InitializeComponent();

            // Dữ liệu mẫu (sửa tùy ý)
            cboPhim.Items.AddRange(new object[] { "Mai", "Đào, Phở và Piano", "Lật Mặt 7" });
            cboSuatChieu.Items.AddRange(new object[] { "09:00", "13:30", "18:00", "21:15" });

            btnChonGhe.Click += btnChonGhe_Click;
            btnDatVe.Click += btnDatVe_Click;
            btnHuy.Click += btnHuy_Click;
        }

        private void btnChonGhe_Click(object? sender, EventArgs e)
        {
            using (var dlg = new FormChonGhe(txtGheDaChon.Text))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    txtGheDaChon.Text = dlg.GheChon;
            }
        }

        private void btnDatVe_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKhach.Text)
                || cboPhim.SelectedItem == null
                || cboSuatChieu.SelectedItem == null
                || string.IsNullOrEmpty(txtGheDaChon.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ tên khách, phim, suất chiếu và chọn ghế.",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(
                $"Đặt vé thành công!\n" +
                $"Khách: {txtTenKhach.Text.Trim()}\n" +
                $"Phim: {cboPhim.SelectedItem}\n" +
                $"Suất chiếu: {cboSuatChieu.SelectedItem}\n" +
                $"Ghế: {txtGheDaChon.Text}\n" +
                $"Giá: 75.000đ/vé",
                "Xác nhận đặt vé", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnHuy_Click(object? sender, EventArgs e)
        {
            txtTenKhach.Clear();
            cboPhim.SelectedIndex = -1;
            cboSuatChieu.SelectedIndex = -1;
            txtGheDaChon.Clear();
        }
    }
}