namespace QuanLyPhongKham
{
    public partial class frmParent : Form
    {
        public frmParent()
        {
            InitializeComponent();
        }

        private void mnuThongTinBenhNhan_Click(object? sender, EventArgs e)
        {
            var f = new frmPatient();
            f.MdiParent = this;
            f.Show();
        }

        private void mnuDatLichHen_Click(object? sender, EventArgs e)
        {
            var f = new frmLichHen();
            f.MdiParent = this;
            f.Show();
        }
    }
}