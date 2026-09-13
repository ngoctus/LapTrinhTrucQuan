namespace BTWF1
{
    public partial class SuDungLableVaTextBox : Form
    {
        public SuDungLableVaTextBox()
        {
            InitializeComponent();
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            txtHienThi.Text = txtNhapMK.Text;
        }

        private void btnTiep_Click(object sender, EventArgs e)
        {
            lblHienThi.Text = "";
            txtNhapMK.Clear();
            txtNhapMK.Focus();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SuDungLableVaTextBox_Load(object sender, EventArgs e) { }

        private void SuDungLableVaTextBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dl;
            dl = MessageBox.Show("Có chắc bạn muốn đóng ứng dụng?", "Thông báo!",
           
            MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button1);
            if (dl == DialogResult.No)
                e.Cancel = true;
        }
    }
}
