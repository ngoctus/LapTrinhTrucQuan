namespace FormBanHangDemo
{
    partial class FormBanHang
    {
        private System.ComponentModel.IContainer components = null!;

        private Label lblMaSP = null!;
        private TextBox txtMaSP = null!;
        private Label lblSoLuong = null!;
        private TextBox txtSoLuong = null!;
        private Label lblDonGia = null!;
        private TextBox txtDonGia = null!;
        private Button btnThem = null!;
        private Button btnXoaTrang = null!;
        private ListBox lstKetQua = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblMaSP = new Label();
            txtMaSP = new TextBox();
            lblSoLuong = new Label();
            txtSoLuong = new TextBox();
            lblDonGia = new Label();
            txtDonGia = new TextBox();
            btnThem = new Button();
            btnXoaTrang = new Button();
            lstKetQua = new ListBox();

            // lblMaSP
            lblMaSP.Text = "Mã sản phẩm:";
            lblMaSP.Location = new Point(15, 20);
            lblMaSP.AutoSize = true;

            // txtMaSP
            txtMaSP.Location = new Point(130, 17);
            txtMaSP.Size = new Size(200, 23);

            // lblSoLuong
            lblSoLuong.Text = "Số lượng:";
            lblSoLuong.Location = new Point(15, 55);
            lblSoLuong.AutoSize = true;

            // txtSoLuong
            txtSoLuong.Location = new Point(130, 52);
            txtSoLuong.Size = new Size(200, 23);
            txtSoLuong.KeyPress += txtSoNguyen_KeyPress;

            // lblDonGia
            lblDonGia.Text = "Đơn giá:";
            lblDonGia.Location = new Point(15, 90);
            lblDonGia.AutoSize = true;

            // txtDonGia
            txtDonGia.Location = new Point(130, 87);
            txtDonGia.Size = new Size(200, 23);
            txtDonGia.KeyPress += txtSoNguyen_KeyPress;

            // btnThem
            btnThem.Text = "Thêm (F2)";
            btnThem.Location = new Point(130, 125);
            btnThem.Size = new Size(100, 30);
            btnThem.Click += btnThem_Click;

            // btnXoaTrang
            btnXoaTrang.Text = "Xóa trắng (F5)";
            btnXoaTrang.Location = new Point(240, 125);
            btnXoaTrang.Size = new Size(100, 30);
            btnXoaTrang.Click += btnXoaTrang_Click;

            // lstKetQua
            lstKetQua.Location = new Point(15, 170);
            lstKetQua.Size = new Size(370, 160);
            lstKetQua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // FormBanHang
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 350);
            Controls.Add(lblMaSP);
            Controls.Add(txtMaSP);
            Controls.Add(lblSoLuong);
            Controls.Add(txtSoLuong);
            Controls.Add(lblDonGia);
            Controls.Add(txtDonGia);
            Controls.Add(btnThem);
            Controls.Add(btnXoaTrang);
            Controls.Add(lstKetQua);
            KeyPreview = true;
            Text = "Form bán hàng";
            KeyDown += FormBanHang_KeyDown;
            FormClosing += FormBanHang_FormClosing;
        }
    }
}