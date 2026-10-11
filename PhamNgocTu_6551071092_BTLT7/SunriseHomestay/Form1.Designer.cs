namespace SunriseHomestay
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblMaPhong = new Label();
            txtMaPhong = new TextBox();
            lblSoPhong = new Label();
            txtSoPhong = new TextBox();
            lblTangSo = new Label();
            nudTangSo = new NumericUpDown();
            lblLoaiPhong = new Label();
            cboLoaiPhong = new ComboBox();
            lblTinhTrang = new Label();
            cboTinhTrang = new ComboBox();
            picHinhAnh = new PictureBox();
            btnChonAnh = new Button();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnLoaiPhong = new Button();
            lblTimTinhTrang = new Label();
            cboTimTinhTrang = new ComboBox();
            lblTimLoai = new Label();
            cboTimLoai = new ComboBox();
            btnTimKiem = new Button();
            dgvPhong = new DataGridView();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)dgvPhong).BeginInit();
            SuspendLayout();
            // lblMaPhong
            lblMaPhong.Location = new Point(20, 20);
            lblMaPhong.Name = "lblMaPhong";
            lblMaPhong.Size = new Size(100, 23);
            lblMaPhong.Text = "Mã phòng";
            lblMaPhong.AutoSize = false;
            lblMaPhong.TextAlign = ContentAlignment.MiddleLeft;
            // txtMaPhong
            txtMaPhong.Location = new Point(130, 17);
            txtMaPhong.Name = "txtMaPhong";
            txtMaPhong.Size = new Size(120, 27);
            txtMaPhong.ReadOnly = true;
            // lblSoPhong
            lblSoPhong.Location = new Point(20, 55);
            lblSoPhong.Name = "lblSoPhong";
            lblSoPhong.Size = new Size(100, 23);
            lblSoPhong.Text = "Số phòng";
            lblSoPhong.AutoSize = false;
            lblSoPhong.TextAlign = ContentAlignment.MiddleLeft;
            // txtSoPhong
            txtSoPhong.Location = new Point(130, 52);
            txtSoPhong.Name = "txtSoPhong";
            txtSoPhong.Size = new Size(200, 27);
            txtSoPhong.MaxLength = 10;
            // lblTangSo
            lblTangSo.Location = new Point(20, 90);
            lblTangSo.Name = "lblTangSo";
            lblTangSo.Size = new Size(100, 23);
            lblTangSo.Text = "Tầng số";
            lblTangSo.AutoSize = false;
            lblTangSo.TextAlign = ContentAlignment.MiddleLeft;
            // nudTangSo
            nudTangSo.Location = new Point(130, 87);
            nudTangSo.Name = "nudTangSo";
            nudTangSo.Size = new Size(80, 27);
            nudTangSo.Minimum = 1;
            nudTangSo.Maximum = 100;
            nudTangSo.Value = 1;
            // lblLoaiPhong
            lblLoaiPhong.Location = new Point(20, 125);
            lblLoaiPhong.Name = "lblLoaiPhong";
            lblLoaiPhong.Size = new Size(100, 23);
            lblLoaiPhong.Text = "Loại phòng";
            lblLoaiPhong.AutoSize = false;
            lblLoaiPhong.TextAlign = ContentAlignment.MiddleLeft;
            // cboLoaiPhong
            cboLoaiPhong.Location = new Point(130, 122);
            cboLoaiPhong.Name = "cboLoaiPhong";
            cboLoaiPhong.Size = new Size(200, 28);
            cboLoaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            // lblTinhTrang
            lblTinhTrang.Location = new Point(20, 160);
            lblTinhTrang.Name = "lblTinhTrang";
            lblTinhTrang.Size = new Size(100, 23);
            lblTinhTrang.Text = "Tình trạng";
            lblTinhTrang.AutoSize = false;
            lblTinhTrang.TextAlign = ContentAlignment.MiddleLeft;
            // cboTinhTrang
            cboTinhTrang.Location = new Point(130, 157);
            cboTinhTrang.Name = "cboTinhTrang";
            cboTinhTrang.Size = new Size(200, 28);
            cboTinhTrang.Items.AddRange(new object[] { "Trống", "Đang ở", "Đang dọn" });
            cboTinhTrang.DropDownStyle = ComboBoxStyle.DropDownList;
            // picHinhAnh
            picHinhAnh.Location = new Point(370, 17);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(200, 150);
            picHinhAnh.BorderStyle = BorderStyle.FixedSingle;
            picHinhAnh.SizeMode = PictureBoxSizeMode.Zoom;
            // btnChonAnh
            btnChonAnh.Location = new Point(370, 175);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.Size = new Size(200, 30);
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.UseVisualStyleBackColor = true;
            // btnThem
            btnThem.Location = new Point(620, 17);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(120, 34);
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // btnSua
            btnSua.Location = new Point(620, 61);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(120, 34);
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // btnXoa
            btnXoa.Location = new Point(620, 105);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(120, 34);
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // btnLamMoi
            btnLamMoi.Location = new Point(620, 149);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(120, 34);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // btnLoaiPhong
            btnLoaiPhong.Location = new Point(620, 193);
            btnLoaiPhong.Name = "btnLoaiPhong";
            btnLoaiPhong.Size = new Size(120, 34);
            btnLoaiPhong.Text = "Loại phòng";
            btnLoaiPhong.UseVisualStyleBackColor = true;
            // lblTimTinhTrang
            lblTimTinhTrang.Location = new Point(20, 235);
            lblTimTinhTrang.Name = "lblTimTinhTrang";
            lblTimTinhTrang.Size = new Size(100, 23);
            lblTimTinhTrang.Text = "Tình trạng";
            lblTimTinhTrang.AutoSize = false;
            lblTimTinhTrang.TextAlign = ContentAlignment.MiddleLeft;
            // cboTimTinhTrang
            cboTimTinhTrang.Location = new Point(130, 232);
            cboTimTinhTrang.Name = "cboTimTinhTrang";
            cboTimTinhTrang.Size = new Size(150, 28);
            cboTimTinhTrang.DropDownStyle = ComboBoxStyle.DropDownList;
            // lblTimLoai
            lblTimLoai.Location = new Point(300, 235);
            lblTimLoai.Name = "lblTimLoai";
            lblTimLoai.Size = new Size(100, 23);
            lblTimLoai.Text = "Loại phòng";
            lblTimLoai.AutoSize = false;
            lblTimLoai.TextAlign = ContentAlignment.MiddleLeft;
            // cboTimLoai
            cboTimLoai.Location = new Point(400, 232);
            cboTimLoai.Name = "cboTimLoai";
            cboTimLoai.Size = new Size(170, 28);
            cboTimLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            // btnTimKiem
            btnTimKiem.Location = new Point(590, 230);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(110, 32);
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // dgvPhong
            dgvPhong.Location = new Point(20, 275);
            dgvPhong.Name = "dgvPhong";
            dgvPhong.Size = new Size(860, 280);
            dgvPhong.AllowUserToAddRows = false;
            dgvPhong.AllowUserToDeleteRows = false;
            dgvPhong.ReadOnly = true;
            dgvPhong.MultiSelect = false;
            dgvPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPhong.RowHeadersVisible = false;
            dgvPhong.RowTemplate = new DataGridViewRow() { Height = 50 };
            // openFileDialog1
            openFileDialog1.Filter = "Ảnh (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog1.Title = "Chọn ảnh phòng";
            this.Load += Form1_Load;
            btnChonAnh.Click += btnChonAnh_Click;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnLoaiPhong.Click += btnLoaiPhong_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            dgvPhong.SelectionChanged += dgvPhong_SelectionChanged;
            // Form1
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 575);
            Controls.Add(lblMaPhong);
            Controls.Add(txtMaPhong);
            Controls.Add(lblSoPhong);
            Controls.Add(txtSoPhong);
            Controls.Add(lblTangSo);
            Controls.Add(nudTangSo);
            Controls.Add(lblLoaiPhong);
            Controls.Add(cboLoaiPhong);
            Controls.Add(lblTinhTrang);
            Controls.Add(cboTinhTrang);
            Controls.Add(picHinhAnh);
            Controls.Add(btnChonAnh);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(btnLoaiPhong);
            Controls.Add(lblTimTinhTrang);
            Controls.Add(cboTimTinhTrang);
            Controls.Add(lblTimLoai);
            Controls.Add(cboTimLoai);
            Controls.Add(btnTimKiem);
            Controls.Add(dgvPhong);
            Text = "Quản lý Phòng - Sunrise Homestay";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)dgvPhong).EndInit();
            lblMaPhong.TabIndex = 0;
            txtMaPhong.TabIndex = 1;
            lblSoPhong.TabIndex = 2;
            txtSoPhong.TabIndex = 3;
            lblTangSo.TabIndex = 4;
            nudTangSo.TabIndex = 5;
            lblLoaiPhong.TabIndex = 6;
            cboLoaiPhong.TabIndex = 7;
            lblTinhTrang.TabIndex = 8;
            cboTinhTrang.TabIndex = 9;
            picHinhAnh.TabIndex = 10;
            btnChonAnh.TabIndex = 11;
            btnThem.TabIndex = 12;
            btnSua.TabIndex = 13;
            btnXoa.TabIndex = 14;
            btnLamMoi.TabIndex = 15;
            btnLoaiPhong.TabIndex = 16;
            lblTimTinhTrang.TabIndex = 17;
            cboTimTinhTrang.TabIndex = 18;
            lblTimLoai.TabIndex = 19;
            cboTimLoai.TabIndex = 20;
            btnTimKiem.TabIndex = 21;
            dgvPhong.TabIndex = 22;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaPhong;
        private TextBox txtMaPhong;
        private Label lblSoPhong;
        private TextBox txtSoPhong;
        private Label lblTangSo;
        private NumericUpDown nudTangSo;
        private Label lblLoaiPhong;
        private ComboBox cboLoaiPhong;
        private Label lblTinhTrang;
        private ComboBox cboTinhTrang;
        private PictureBox picHinhAnh;
        private Button btnChonAnh;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnLoaiPhong;
        private Label lblTimTinhTrang;
        private ComboBox cboTimTinhTrang;
        private Label lblTimLoai;
        private ComboBox cboTimLoai;
        private Button btnTimKiem;
        private DataGridView dgvPhong;
        private OpenFileDialog openFileDialog1;
    }
}
