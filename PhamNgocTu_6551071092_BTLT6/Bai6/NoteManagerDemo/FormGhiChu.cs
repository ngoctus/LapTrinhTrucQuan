using System.ComponentModel;

namespace NoteManagerDemo
{
    public partial class FormGhiChu : Form
    {
        private const int GioiHanKyTu = 500;
        private bool _daThayDoi = false;
        private Color _mauNutGoc;

        public FormGhiChu()
        {
            InitializeComponent();

            KeyPreview = true;
            cboMucDoUuTien.SelectedIndex = 0;
            _mauNutGoc = btnLuuGhiChu.BackColor;

            // Keyboard
            KeyDown += FormGhiChu_KeyDown;
            txtNoiDung.KeyPress += txtNoiDung_KeyPress;
            txtNoiDung.TextChanged += txtNoiDung_TextChanged;
            txtTieuDe.TextChanged += (s, e) => _daThayDoi = true;

            // Mouse
            btnLuuGhiChu.MouseEnter += btnLuuGhiChu_MouseEnter;
            btnLuuGhiChu.MouseLeave += btnLuuGhiChu_MouseLeave;

            // Validating / Validated
            txtTieuDe.Validating += txtTieuDe_Validating;
            txtTieuDe.Validated += txtTieuDe_Validated;
            btnLuuGhiChu.Click += btnLuuGhiChu_Click;
        }

        // ===== KEYBOARD =====
        private void FormGhiChu_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                e.SuppressKeyPress = true;
                btnLuuGhiChu.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;

                if (!_daThayDoi)
                {
                    Close();
                    return;
                }

                DialogResult kq = MessageBox.Show(
                    "Nội dung đã thay đổi. Bạn có chắc muốn đóng ghi chú này không?",
                    "Xác nhận đóng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (kq == DialogResult.Yes)
                {
                    _daThayDoi = false;
                    Close();
                }
            }
        }

        private void txtNoiDung_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // Cho phép phím điều khiển (Backspace, Ctrl+...) và khi đang bôi đen để gõ đè
            if (char.IsControl(e.KeyChar))
                return;

            if (txtNoiDung.TextLength >= GioiHanKyTu && txtNoiDung.SelectionLength == 0)
                e.Handled = true; // chặn ký tự thêm
        }

        private void txtNoiDung_TextChanged(object? sender, EventArgs e)
        {
            _daThayDoi = true;
            lblDem.Text = $"{txtNoiDung.TextLength} / {GioiHanKyTu}";
        }

        // ===== MOUSE =====

        private void btnLuuGhiChu_MouseEnter(object? sender, EventArgs e)
        {
            btnLuuGhiChu.BackColor = Color.LightSkyBlue;
        }

        private void btnLuuGhiChu_MouseLeave(object? sender, EventArgs e)
        {
            btnLuuGhiChu.BackColor = _mauNutGoc;
        }

        // ===== VALIDATING / VALIDATED =====
        private void txtTieuDe_Validating(object? sender, CancelEventArgs e)
        {
            string s = txtTieuDe.Text.Trim();

            if (s.Length == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTieuDe, "Tiêu đề không được để trống");
                txtTieuDe.BackColor = Color.MistyRose;
            }
            else if (s.Length > 50)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTieuDe, "Tiêu đề tối đa 50 ký tự");
                txtTieuDe.BackColor = Color.MistyRose;
            }
        }

        private void txtTieuDe_Validated(object? sender, EventArgs e)
        {
            txtTieuDe.BackColor = Color.White;
            errorProvider1.SetError(txtTieuDe, "");
        }

        private void btnLuuGhiChu_Click(object? sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            Text = txtTieuDe.Text.Trim();
            _daThayDoi = false;

            MessageBox.Show("Đã lưu ghi chú", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}