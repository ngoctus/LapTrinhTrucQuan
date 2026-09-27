#nullable disable
using System.Windows.Forms;

namespace TodoListDemo
{
    public partial class Form1 : Form
    {
        private const string TienTo = "[Hoàn thành] ";

        public Form1()
        {
            InitializeComponent();
        }

        // Nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            string noiDung = txtCongViecMoi.Text.Trim();
            if (noiDung != "")
            {
                lstCongViec.Items.Add(noiDung);
                txtCongViecMoi.Clear();
            }
            txtCongViecMoi.Focus();
        }

        // Mặc định chuột phải KHÔNG chọn dòng trong ListBox,
        // nên ta tự chọn dòng nằm dưới con trỏ để menu tác động đúng dòng vừa nhấp.
        private void lstCongViec_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int index = lstCongViec.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                    lstCongViec.SelectedIndex = index;
                else
                    lstCongViec.ClearSelected();
            }
        }

        // Menu: Đánh dấu hoàn thành
        private void mnuHoanThanh_Click(object sender, EventArgs e)
        {
            if (lstCongViec.SelectedItem != null)
            {
                int index = lstCongViec.SelectedIndex;
                string noiDung = lstCongViec.SelectedItem.ToString();

                // Chưa có tiền tố mới chèn -> không bị lặp khi bấm nhiều lần
                if (!noiDung.StartsWith(TienTo))
                {
                    lstCongViec.Items[index] = TienTo + noiDung;
                }
            }
        }

        // Menu: Xóa công việc này
        private void mnuXoaMot_Click(object sender, EventArgs e)
        {
            if (lstCongViec.SelectedItem != null)
            {
                lstCongViec.Items.Remove(lstCongViec.SelectedItem);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một công việc trước khi xóa",
                                "Chưa chọn công việc",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        // Menu: Xóa tất cả
        private void mnuXoaTatCa_Click(object sender, EventArgs e)
        {
            DialogResult kq = MessageBox.Show("Bạn có chắc muốn xóa tất cả công việc?",
                                              "Xác nhận",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                lstCongViec.Items.Clear();
            }
        }
    }
}