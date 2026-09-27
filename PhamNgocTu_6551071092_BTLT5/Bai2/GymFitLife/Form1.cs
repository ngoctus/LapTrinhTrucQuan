#nullable disable
using System.Windows.Forms;

namespace GymFitLife
{
    public partial class Form1 : Form
    {
        private readonly System.Windows.Forms.Timer hideTimer = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();

            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 500;
            toolTip1.ReshowDelay = 100;
            toolTip1.ShowAlways = true;

            // Trên một số máy Windows 11, AutoPopDelay không được áp dụng nên tooltip không tự ẩn.
            // Mỗi lần tooltip sắp hiện (Popup) ta bật timer 5 giây; hết giờ thì tắt/bật lại
            // ToolTip để nó đóng lại.
            hideTimer.Interval = toolTip1.AutoPopDelay;
            hideTimer.Tick += HideTimer_Tick;
            toolTip1.Popup += ToolTip1_Popup;
        }

        private void ToolTip1_Popup(object sender, PopupEventArgs e)
        {
            hideTimer.Stop();
            hideTimer.Start();
        }

        private void HideTimer_Tick(object sender, EventArgs e)
        {
            hideTimer.Stop();
            toolTip1.Active = false;
            toolTip1.Active = true;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string hoTen = txtHoTen.Text.Trim();
            string sdt = txtSDT.Text.Trim();

            if (hoTen == "" || sdt == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Họ tên và Số điện thoại",
                                "Thiếu thông tin",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            string goiTap = cboGoiTap.SelectedItem.ToString();
            string thongTin =
                "Họ tên: " + hoTen + "\n" +
                "SĐT: " + sdt + "\n" +
                "Gói tập: " + goiTap + "\n" +
                "Số buổi/tuần: " + numSoBuoiTuan.Value;

            MessageBox.Show(thongTin,
                            "Đăng ký thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
    }
}