namespace BanVeDemo
{
    public partial class FormChonGhe : Form
    {
        public string GheChon { get; private set; } = "";

        public FormChonGhe(string gheHienTai)
        {
            InitializeComponent();

            foreach (char hang in "ABC")
                for (int i = 1; i <= 5; i++)
                    lstGhe.Items.Add($"{hang}{i}");

            lblGheDaChon.Text = "Đang chọn: (chưa chọn)";

            lstGhe.SelectedIndexChanged += lstGhe_SelectedIndexChanged;
            btnXacNhan.Click += btnXacNhan_Click;
            btnBoQua.Click += btnBoQua_Click;

            // Chọn sẵn ghế cũ (gán sau khi đăng ký event để label tự cập nhật)
            if (!string.IsNullOrEmpty(gheHienTai))
                lstGhe.SelectedItem = gheHienTai;
        }

        private void lstGhe_SelectedIndexChanged(object? sender, EventArgs e)
        {
            lblGheDaChon.Text = lstGhe.SelectedItem == null
                ? "Đang chọn: (chưa chọn)"
                : $"Đang chọn: {lstGhe.SelectedItem}";
        }

        private void btnXacNhan_Click(object? sender, EventArgs e)
        {
            if (lstGhe.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một ghế.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // dialog không đóng
            }

            GheChon = lstGhe.SelectedItem.ToString()!;
            DialogResult = DialogResult.OK;
        }

        private void btnBoQua_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}