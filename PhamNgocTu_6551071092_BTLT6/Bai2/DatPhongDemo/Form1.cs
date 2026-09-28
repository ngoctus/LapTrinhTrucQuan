using System.ComponentModel;
using System.Globalization;

namespace DatPhongDemo
{
    public partial class frmDatPhong : Form
    {
        public frmDatPhong()
        {
            InitializeComponent();

            txtHoTen.Validating += txtHoTen_Validating;
            txtCCCD.Validating += txtCCCD_Validating;
            txtNgayNhan.Validating += txtNgayNhan_Validating;
            txtNgayTra.Validating += txtNgayTra_Validating;
            txtSoNguoiLon.Validating += txtSoNguoiLon_Validating;
            txtSoTreEm.Validating += txtSoTreEm_Validating;

            // Dùng chung 1 handler Validated cho cả 6 TextBox
            txtHoTen.Validated += txt_Validated;
            txtCCCD.Validated += txt_Validated;
            txtNgayNhan.Validated += txt_Validated;
            txtNgayTra.Validated += txt_Validated;
            txtSoNguoiLon.Validated += txt_Validated;
            txtSoTreEm.Validated += txt_Validated;

            btnDatPhong.Click += btnDatPhong_Click;
        }

        // ===== Hàm phụ =====
        private void BaoLoi(TextBox txt, string msg, CancelEventArgs e)
        {
            e.Cancel = true;
            errorProvider1.SetError(txt, msg);
            txt.BackColor = Color.MistyRose;
        }

        private void BaoDung(TextBox txt)
        {
            errorProvider1.SetError(txt, "");
            txt.BackColor = Color.Honeydew;
        }

        private static bool TryParseNgay(string s, out DateTime ngay)
        {
            return DateTime.TryParseExact(s.Trim(), "dd/MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out ngay);
        }

        // ===== Validating =====
        private void txtHoTen_Validating(object? sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
                BaoLoi(txtHoTen, "Họ tên không được để trống", e);
            else
                BaoDung(txtHoTen);
        }

        private void txtCCCD_Validating(object? sender, CancelEventArgs e)
        {
            string s = txtCCCD.Text.Trim();
            if (s.Length != 12 || !s.All(char.IsAsciiDigit))
                BaoLoi(txtCCCD, "CCCD phải gồm đúng 12 chữ số", e);
            else
                BaoDung(txtCCCD);
        }

        private void txtNgayNhan_Validating(object? sender, CancelEventArgs e)
        {
            if (!TryParseNgay(txtNgayNhan.Text, out DateTime nhan))
                BaoLoi(txtNgayNhan, "Ngày nhận không hợp lệ (định dạng dd/MM/yyyy)", e);
            else if (nhan < DateTime.Today)
                BaoLoi(txtNgayNhan, "Ngày nhận phải từ hôm nay trở đi", e);
            else
                BaoDung(txtNgayNhan);
        }

        private void txtNgayTra_Validating(object? sender, CancelEventArgs e)
        {
            if (!TryParseNgay(txtNgayTra.Text, out DateTime tra))
            {
                BaoLoi(txtNgayTra, "Ngày trả không hợp lệ (định dạng dd/MM/yyyy)", e);
                return;
            }

            if (!TryParseNgay(txtNgayNhan.Text, out DateTime nhan))
                BaoLoi(txtNgayTra, "Vui lòng nhập ngày nhận hợp lệ trước", e);
            else if (tra <= nhan)
                BaoLoi(txtNgayTra, "Ngày trả phải sau ngày nhận", e);
            else
                BaoDung(txtNgayTra);
        }

        private void txtSoNguoiLon_Validating(object? sender, CancelEventArgs e)
        {
            if (!int.TryParse(txtSoNguoiLon.Text.Trim(), out int n) || n < 1 || n > 4)
                BaoLoi(txtSoNguoiLon, "Số người lớn phải là số nguyên từ 1 đến 4", e);
            else
                BaoDung(txtSoNguoiLon);
        }

        private void txtSoTreEm_Validating(object? sender, CancelEventArgs e)
        {
            if (!int.TryParse(txtSoTreEm.Text.Trim(), out int n) || n < 0 || n > 3)
                BaoLoi(txtSoTreEm, "Số trẻ em phải là số nguyên từ 0 đến 3", e);
            else
                BaoDung(txtSoTreEm);
        }

        // ===== Validated =====
        private void txt_Validated(object? sender, EventArgs e)
        {
            if (sender is TextBox txt)
                txt.BackColor = Color.Honeydew;
        }

        // ===== Đặt phòng =====
        private void btnDatPhong_Click(object? sender, EventArgs e)
        {
            // Kiểm tra lại tất cả field (kể cả field chưa từng được focus)
            if (!ValidateChildren())
                return;

            DateTime nhan = DateTime.ParseExact(txtNgayNhan.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime tra = DateTime.ParseExact(txtNgayTra.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            int soDem = (tra - nhan).Days;

            MessageBox.Show(
                $"Đặt phòng thành công!\n" +
                $"Khách: {txtHoTen.Text.Trim()}\n" +
                $"Số đêm: {soDem}\n" +
                $"Người lớn: {txtSoNguoiLon.Text.Trim()} - Trẻ em: {txtSoTreEm.Text.Trim()}",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}