namespace QuanLyPhongKham
{
    public partial class frmLichHen : Form
    {
        private class LichHen
        {
            public DateTime NgayGio { get; set; }
            public string TenBenhNhan { get; set; } = "";
        }

        private readonly List<LichHen> _dsLichHen = new();

        public frmLichHen()
        {
            InitializeComponent();
        }

        private void btnDatLich_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenBenhNhan.Text))
            {
                MessageBox.Show("Vui lòng nhập tên bệnh nhân.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var lh = new LichHen
            {
                NgayGio = dtpNgayGio.Value,
                TenBenhNhan = txtTenBenhNhan.Text.Trim()
            };

            _dsLichHen.Add(lh);
            lstLichHen.Items.Add($"{lh.NgayGio:dd/MM/yyyy HH:mm} - {lh.TenBenhNhan}");

            txtTenBenhNhan.Clear();
            txtTenBenhNhan.Focus();
        }
    }
}