using System.Globalization;

namespace FrmNhapDiemDemo
{
    public partial class FormNhapDiem : Form
    {
        public FormNhapDiem()
        {
            InitializeComponent();

            DangKyEnterChuyenField();

            txtToan.Enter += txtDiem_Enter;
            txtVan.Enter += txtDiem_Enter;
            txtAnh.Enter += txtDiem_Enter;

            btnLuu.Click += btnLuu_Click;
            btnXoaTrang.Click += btnXoaTrang_Click;
        }

        private void DangKyEnterChuyenField()
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox tb)
                    tb.KeyPress += TextBox_KeyPress;
            }
        }

        private void TextBox_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter)
                return;

            e.Handled = true; // chặn tiếng "ding"

            if (sender == txtAnh)
                btnLuu.PerformClick();
            else
                SelectNextControl((Control)sender!, true, true, true, true);
        }

        private void txtDiem_Enter(object? sender, EventArgs e)
        {
            if (sender is TextBox tb)
                tb.BeginInvoke(() => tb.SelectAll()); // BeginInvoke để click chuột cũng không bị mất bôi xanh
        }

        // Cho phép gõ 8.5 hoặc 8,5 đều được (tránh lỗi dấu phân cách theo culture vi-VN)
        private static bool TryParseDiem(string s, out decimal diem)
        {
            s = s.Trim().Replace(',', '.');
            return decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out diem)
                   && diem >= 0m && diem <= 10m;
        }

        private void btnLuu_Click(object? sender, EventArgs e)
        {
            errorProvider1.Clear();

            bool okToan = TryParseDiem(txtToan.Text, out decimal toan);
            bool okVan = TryParseDiem(txtVan.Text, out decimal van);
            bool okAnh = TryParseDiem(txtAnh.Text, out decimal anh);

            if (!okToan) errorProvider1.SetError(txtToan, "Điểm Toán phải là số từ 0.0 đến 10.0");
            if (!okVan) errorProvider1.SetError(txtVan, "Điểm Văn phải là số từ 0.0 đến 10.0");
            if (!okAnh) errorProvider1.SetError(txtAnh, "Điểm Anh phải là số từ 0.0 đến 10.0");

            if (!okToan || !okVan || !okAnh)
            {
                // Đưa focus về ô sai đầu tiên
                if (!okToan) txtToan.Focus();
                else if (!okVan) txtVan.Focus();
                else txtAnh.Focus();
                return;
            }

            string dong = string.Format(CultureInfo.InvariantCulture,
                "{0} | {1} | T:{2} V:{3} A:{4}",
                txtMaHS.Text.Trim(), txtHoTen.Text.Trim(), toan, van, anh);
            listBox1.Items.Add(dong);

            XoaTrangForm();
        }

        private void btnXoaTrang_Click(object? sender, EventArgs e)
        {
            XoaTrangForm();
        }

        private void XoaTrangForm()
        {
            txtMaHS.Clear();
            txtHoTen.Clear();
            txtToan.Clear();
            txtVan.Clear();
            txtAnh.Clear();
            errorProvider1.Clear();
            txtMaHS.Focus();
        }
    }
}