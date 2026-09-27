namespace QuanLyPhongKham
{
    public partial class frmPatient : Form
    {
        private class BenhNhan
        {
            public string HoTen { get; set; } = "";
            public int Tuoi { get; set; }
            public string TrieuChung { get; set; } = "";
        }

        private readonly List<BenhNhan> _dsBenhNhan = new();

        public frmPatient()
        {
            InitializeComponent();
        }

        private void btnLuuTam_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var bn = new BenhNhan
            {
                HoTen = txtHoTen.Text.Trim(),
                Tuoi = (int)numTuoi.Value,
                TrieuChung = txtTrieuChung.Text.Trim()
            };

            _dsBenhNhan.Add(bn);
            lstBenhNhan.Items.Add($"{bn.HoTen} - {bn.Tuoi} tuổi - {bn.TrieuChung}");

            txtHoTen.Clear();
            numTuoi.Value = 0;
            txtTrieuChung.Clear();
            txtHoTen.Focus();
        }
    }
}