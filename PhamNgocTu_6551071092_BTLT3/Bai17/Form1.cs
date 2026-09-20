namespace Bai14
{
    public partial class formUpdateListBox2 : Form
    {
        public formUpdateListBox2()
        {
            InitializeComponent();
        }

        private void formUpdateListBox2_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtTen.Text == "")
            {
                MessageBox.Show("Bạn ko được phép nhập dữ liệu rỗng!", "Thông Báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                //đưa | vào ô txtTen
                txtTen.Focus();
            }
            else
            {
                //truyền dữ liệu vô list box
                string strDuLieu = txtTen.Text;
                lstLopA.Items.Add(strDuLieu);
                //xóa nội dung trong ô txtTen vào đưa con nháy vào ô này
                txtTen.Clear();
                txtTen.Focus();
            }
        }

        // hàm hỗ trợ câu 5, >
        void chuyenDuLieu(ListBox lst1, ListBox lst2)
        {
            int i = 0;
            while (i < lst1.Items.Count)
                if (lst1.GetSelected(i))
                {
                    string stDuLieu = lst1.Items[i].ToString();
                    lst2.Items.Add(stDuLieu);
                    lst1.Items.RemoveAt(i);
                }
                else
                    i++;
        }

        void chuyenToanBo(ListBox lst1, ListBox lst2)
        {
            while (lst1.Items.Count != 0)
            {
                string stDuLieu = lst1.Items[0].ToString();
                lst2.Items.Add(stDuLieu);
                lst1.Items.RemoveAt(0);
            }
        }

        void xoaNhieuPtu(ListBox lst)
        {
            int i = 0;
            while (i < lst.Items.Count)
                if (lst.GetSelected(i))
                    lst.Items.RemoveAt(i);
                else
                    i++;
        }

        // ======================== CHỨC NĂNG
        private void btnNextItem_Click(object sender, EventArgs e)
        {
            DialogResult hoiChuyen;
            if (lstLopA.Items.Count > 0)
            {
                hoiChuyen = MessageBox.Show("Bạn có chắc chuyển những dữ liệu đang chọn k? ", "Thông Báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (hoiChuyen == DialogResult.Yes)
                    chuyenDuLieu(lstLopA, lstLopB);
            }
            else
                MessageBox.Show("Danh sách hiện đang rỗng!", "Chú ý");
        }

        private void btnLastItem_Click(object sender, EventArgs e)
        {
            DialogResult hoiChuyen;
            if (lstLopB.Items.Count > 0)
            {
                hoiChuyen = MessageBox.Show("Bạn có chắc chuyển những dữ liệu đang chọn k? ", "Thông Báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (hoiChuyen == DialogResult.Yes)
                    chuyenDuLieu(lstLopB, lstLopA);
            }
            else
                MessageBox.Show("Danh sách hiện đang rỗng!", "Chú ý");
        }

        private void btnNextLstBox_Click(object sender, EventArgs e)
        {
            DialogResult hoiChuyen;
            if (lstLopA.Items.Count > 0)
            {
                hoiChuyen = MessageBox.Show("Bạn có chắc chuyển toàn bộ dữ liệu đang chọn k? ", "Thông Báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
                if (hoiChuyen == DialogResult.Yes)
                    chuyenToanBo(lstLopA, lstLopB);
            }
            else
                MessageBox.Show("Danh sách hiện đang rỗng!", "Chú ý");
        }

        private void btnLastLstBox_Click(object sender, EventArgs e)
        {
            DialogResult hoiChuyen;
            if (lstLopB.Items.Count > 0)
            {
                hoiChuyen = MessageBox.Show("Bạn có chắc chuyển toàn bộ dữ liệu đang chọn k? ", "Thông Báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
                if (hoiChuyen == DialogResult.Yes)
                    chuyenToanBo(lstLopB, lstLopA);
            }
            else
                MessageBox.Show("Danh sách hiện đang rỗng!", "Chú ý");
        }

        private void btnDeleteA_Click(object sender, EventArgs e)
        {
            DialogResult hoiXoa;
            if (lstLopA.Items.Count > 0)
            {
                hoiXoa = MessageBox.Show("Bạn có chắc xóa những phần tử này?", "Chú ý",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
                if (hoiXoa == DialogResult.Yes)
                    xoaNhieuPtu(lstLopA);
            }
            else
                MessageBox.Show("Hiện danh sáchh đang rỗng!", "Chú ý");

        }

        private void btnDeleteB_Click(object sender, EventArgs e)
        {
            DialogResult hoiXoa;
            if (lstLopB.Items.Count > 0)
            {
                hoiXoa = MessageBox.Show("Bạn có chắc xóa những phần tử này?", "Chú ý",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
                if (hoiXoa == DialogResult.Yes)
                    xoaNhieuPtu(lstLopB);
            }
            else
                MessageBox.Show("Hiện danh sách đang rỗng!", "Chú ý");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chuyểnPhầnTửChọnSangLớpAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLastItem_Click(sender, e);
        }

        private void chuyểnPhầnTửChọnSangLớpBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNextItem_Click(sender, e);
        }

        private void cậpNhậtLớpBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtTen.Text == "")
            {
                MessageBox.Show(
                    "Bạn không được phép nhập dữ liệu rỗng!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtTen.Focus();
            }
            else
            {
                string strDuLieu = txtTen.Text;
                lstLopB.Items.Add(strDuLieu);

                txtTen.Clear();
                txtTen.Focus();
            }
        }

        private void chuyểnHếtDanhSáchSangLớpAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnNextLstBox_Click(sender, e);
        }

        private void chuyểnHếtDanhSáchSangLớpBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnLastLstBox_Click(sender, e);
        }

        private void xóaDanhSáchLớpAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDeleteA_Click(sender, e);
        }

        private void xóaDanhSáchLớpBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDeleteB_Click(sender, e);
        }

        private void kếtThúcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnClose_Click(sender, e);
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Họ tên: Phạm Ngọc Tú\n" +
                "MSSV: 6551071092\n",
                "Thông tin sinh viên",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void cậpNhậtLớpAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnUpdate_Click(sender, e);
        }
    }
}
