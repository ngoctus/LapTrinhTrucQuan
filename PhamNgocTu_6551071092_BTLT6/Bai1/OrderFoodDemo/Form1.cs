namespace OrderFoodDemo
{
    public partial class FormDangKy : Form
    {
        public FormDangKy()
        {
            InitializeComponent();
        }

        private bool KiemTraHopLe()
        {
            bool hopLe = true;

            // 1: Họ tên k đc trống, tối thiểu 3
            string hoTen = txtHoten.Text.Trim();
            if (string.IsNullOrEmpty(hoTen))
            {
                errorProvider1.SetError(txtHoten, "Họ tên không được để trống.");
                hopLe = false;
            }
            else if (hoTen.Length < 3)
            {
                errorProvider1.SetError(txtHoten, "Độ dài tên không được thấp hơn 3 từ.");
                hopLe = false;
            }
            else
            {
                errorProvider1.SetError(txtHoten, "");
            }

            //2: txtSDT đúng 10 chữ số, bắt đầu bằng "0"
            string sdt = txtSDT.Text.Trim();
            if (sdt.Length != 10 || !sdt.StartsWith("0") || !sdt.All(char.IsAsciiDigit))
            {
                errorProvider1.SetError(txtSDT, "Số điện thoại phải gồm đúng 10 chữ số và bắt đầu bằng 0");
                hopLe = false;
            }
            else
            {
                errorProvider1.SetError(txtSDT, "");
            }

            // (3) Email: chứa "@" và có "." phía sau "@"
            string email = txtEmail.Text.Trim();
            int viTriAt = email.IndexOf('@');
            if (viTriAt <= 0 || email.IndexOf('.', viTriAt) < 0)
            {
                errorProvider1.SetError(txtEmail, "Email phải chứa \"@\" và có dấu \".\" phía sau \"@\"");
                hopLe = false;
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }

            // (4) Mật khẩu: tối thiểu 6 ký tự
            if (txtMatKhau.Text.Length < 6)
            {
                errorProvider1.SetError(txtMatKhau, "Mật khẩu phải có tối thiểu 6 ký tự");
                hopLe = false;
            }
            else
            {
                errorProvider1.SetError(txtMatKhau, "");
            }

            // (5) Xác nhận mật khẩu: phải khớp
            if (txtXacNhanMK.Text != txtMatKhau.Text)
            {
                errorProvider1.SetError(txtXacNhanMK, "Xác nhận mật khẩu không khớp");
                hopLe = false;
            }
            else
            {
                errorProvider1.SetError(txtXacNhanMK, "");
            }

            return hopLe;
        }


        private void btnDangKy_Click_1(object sender, EventArgs e)
        {
            if (!KiemTraHopLe())
                return;

            MessageBox.Show(
                "Đăng ký thành công! Chào mừng " + txtHoten.Text,
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnHuy.CausesValidation = false;
            errorProvider1.Clear();
            this.Close();
        }
    }
}
