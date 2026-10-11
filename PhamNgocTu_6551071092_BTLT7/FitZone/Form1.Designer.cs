namespace FitZone
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
            lblMaHV = new Label();
            txtMaHV = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblGioiTinh = new Label();
            rdoNam = new RadioButton();
            rdoNu = new RadioButton();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            lblSDT = new Label();
            txtSDT = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblHang = new Label();
            cboHang = new ComboBox();
            chkTrangThai = new CheckBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTimTen = new Label();
            txtTimTen = new TextBox();
            lblTimHang = new Label();
            cboTimHang = new ComboBox();
            btnTimKiem = new Button();
            dgvHoiVien = new DataGridView();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)dgvHoiVien).BeginInit();
            SuspendLayout();
            // lblMaHV
            lblMaHV.Location = new Point(20, 20);
            lblMaHV.Name = "lblMaHV";
            lblMaHV.Size = new Size(100, 23);
            lblMaHV.Text = "Mã hội viên";
            lblMaHV.AutoSize = false;
            lblMaHV.TextAlign = ContentAlignment.MiddleLeft;
            // txtMaHV
            txtMaHV.Location = new Point(140, 17);
            txtMaHV.Name = "txtMaHV";
            txtMaHV.Size = new Size(120, 27);
            txtMaHV.ReadOnly = true;
            // lblHoTen
            lblHoTen.Location = new Point(20, 55);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(100, 23);
            lblHoTen.Text = "Họ tên";
            lblHoTen.AutoSize = false;
            lblHoTen.TextAlign = ContentAlignment.MiddleLeft;
            // txtHoTen
            txtHoTen.Location = new Point(140, 52);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(300, 27);
            txtHoTen.MaxLength = 100;
            // lblGioiTinh
            lblGioiTinh.Location = new Point(20, 90);
            lblGioiTinh.Name = "lblGioiTinh";
            lblGioiTinh.Size = new Size(100, 23);
            lblGioiTinh.Text = "Giới tính";
            lblGioiTinh.AutoSize = false;
            lblGioiTinh.TextAlign = ContentAlignment.MiddleLeft;
            // rdoNam
            rdoNam.Location = new Point(140, 90);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(70, 24);
            rdoNam.Text = "Nam";
            rdoNam.Checked = true;
            rdoNam.AutoSize = true;
            rdoNam.UseVisualStyleBackColor = true;
            // rdoNu
            rdoNu.Location = new Point(220, 90);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(70, 24);
            rdoNu.Text = "Nữ";
            rdoNu.AutoSize = true;
            rdoNu.UseVisualStyleBackColor = true;
            // lblNgaySinh
            lblNgaySinh.Location = new Point(20, 125);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Size = new Size(100, 23);
            lblNgaySinh.Text = "Ngày sinh";
            lblNgaySinh.AutoSize = false;
            lblNgaySinh.TextAlign = ContentAlignment.MiddleLeft;
            // dtpNgaySinh
            dtpNgaySinh.Location = new Point(140, 122);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(150, 27);
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.MaxDate = DateTime.Today;
            // lblSDT
            lblSDT.Location = new Point(20, 160);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(100, 23);
            lblSDT.Text = "SĐT";
            lblSDT.AutoSize = false;
            lblSDT.TextAlign = ContentAlignment.MiddleLeft;
            // txtSDT
            txtSDT.Location = new Point(140, 157);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(300, 27);
            txtSDT.MaxLength = 15;
            // lblEmail
            lblEmail.Location = new Point(20, 195);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(100, 23);
            lblEmail.Text = "Email";
            lblEmail.AutoSize = false;
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;
            // txtEmail
            txtEmail.Location = new Point(140, 192);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(300, 27);
            txtEmail.MaxLength = 100;
            // lblHang
            lblHang.Location = new Point(20, 230);
            lblHang.Name = "lblHang";
            lblHang.Size = new Size(120, 23);
            lblHang.Text = "Hạng thành viên";
            lblHang.AutoSize = false;
            lblHang.TextAlign = ContentAlignment.MiddleLeft;
            // cboHang
            cboHang.Location = new Point(140, 227);
            cboHang.Name = "cboHang";
            cboHang.Size = new Size(150, 28);
            cboHang.Items.AddRange(new object[] { "Basic", "VIP", "Premium" });
            cboHang.DropDownStyle = ComboBoxStyle.DropDownList;
            // chkTrangThai
            chkTrangThai.Location = new Point(140, 265);
            chkTrangThai.Name = "chkTrangThai";
            chkTrangThai.Size = new Size(140, 24);
            chkTrangThai.Text = "Đang hoạt động";
            chkTrangThai.AutoSize = true;
            chkTrangThai.Checked = true;
            chkTrangThai.UseVisualStyleBackColor = true;
            // btnThem
            btnThem.Location = new Point(520, 17);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(120, 34);
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // btnSua
            btnSua.Location = new Point(520, 61);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(120, 34);
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // btnXoa
            btnXoa.Location = new Point(520, 105);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(120, 34);
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // btnLamMoi
            btnLamMoi.Location = new Point(520, 149);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(120, 34);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // lblTimTen
            lblTimTen.Location = new Point(20, 310);
            lblTimTen.Name = "lblTimTen";
            lblTimTen.Size = new Size(100, 23);
            lblTimTen.Text = "Tìm họ tên";
            lblTimTen.AutoSize = false;
            lblTimTen.TextAlign = ContentAlignment.MiddleLeft;
            // txtTimTen
            txtTimTen.Location = new Point(140, 307);
            txtTimTen.Name = "txtTimTen";
            txtTimTen.Size = new Size(200, 27);
            // lblTimHang
            lblTimHang.Location = new Point(360, 310);
            lblTimHang.Name = "lblTimHang";
            lblTimHang.Size = new Size(50, 23);
            lblTimHang.Text = "Hạng";
            lblTimHang.AutoSize = false;
            lblTimHang.TextAlign = ContentAlignment.MiddleLeft;
            // cboTimHang
            cboTimHang.Location = new Point(415, 307);
            cboTimHang.Name = "cboTimHang";
            cboTimHang.Size = new Size(130, 28);
            cboTimHang.Items.AddRange(new object[] { "Tất cả", "Basic", "VIP", "Premium" });
            cboTimHang.DropDownStyle = ComboBoxStyle.DropDownList;
            // btnTimKiem
            btnTimKiem.Location = new Point(560, 305);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(110, 32);
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // dgvHoiVien
            dgvHoiVien.Location = new Point(20, 350);
            dgvHoiVien.Name = "dgvHoiVien";
            dgvHoiVien.Size = new Size(880, 220);
            dgvHoiVien.AllowUserToAddRows = false;
            dgvHoiVien.AllowUserToDeleteRows = false;
            dgvHoiVien.ReadOnly = true;
            dgvHoiVien.MultiSelect = false;
            dgvHoiVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHoiVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHoiVien.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvHoiVien.RowHeadersVisible = false;
            // errorProvider1
            errorProvider1.ContainerControl = this;
            this.Load += Form1_Load;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            dgvHoiVien.SelectionChanged += dgvHoiVien_SelectionChanged;
            dgvHoiVien.CellFormatting += dgvHoiVien_CellFormatting;
            // Form1
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 590);
            Controls.Add(lblMaHV);
            Controls.Add(txtMaHV);
            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);
            Controls.Add(lblGioiTinh);
            Controls.Add(rdoNam);
            Controls.Add(rdoNu);
            Controls.Add(lblNgaySinh);
            Controls.Add(dtpNgaySinh);
            Controls.Add(lblSDT);
            Controls.Add(txtSDT);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblHang);
            Controls.Add(cboHang);
            Controls.Add(chkTrangThai);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(lblTimTen);
            Controls.Add(txtTimTen);
            Controls.Add(lblTimHang);
            Controls.Add(cboTimHang);
            Controls.Add(btnTimKiem);
            Controls.Add(dgvHoiVien);
            Text = "Quản lý Hội viên - FitZone";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)dgvHoiVien).EndInit();
            lblMaHV.TabIndex = 0;
            txtMaHV.TabIndex = 1;
            lblHoTen.TabIndex = 2;
            txtHoTen.TabIndex = 3;
            lblGioiTinh.TabIndex = 4;
            rdoNam.TabIndex = 5;
            rdoNu.TabIndex = 6;
            lblNgaySinh.TabIndex = 7;
            dtpNgaySinh.TabIndex = 8;
            lblSDT.TabIndex = 9;
            txtSDT.TabIndex = 10;
            lblEmail.TabIndex = 11;
            txtEmail.TabIndex = 12;
            lblHang.TabIndex = 13;
            cboHang.TabIndex = 14;
            chkTrangThai.TabIndex = 15;
            btnThem.TabIndex = 16;
            btnSua.TabIndex = 17;
            btnXoa.TabIndex = 18;
            btnLamMoi.TabIndex = 19;
            lblTimTen.TabIndex = 20;
            txtTimTen.TabIndex = 21;
            lblTimHang.TabIndex = 22;
            cboTimHang.TabIndex = 23;
            btnTimKiem.TabIndex = 24;
            dgvHoiVien.TabIndex = 25;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaHV;
        private TextBox txtMaHV;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblGioiTinh;
        private RadioButton rdoNam;
        private RadioButton rdoNu;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private Label lblSDT;
        private TextBox txtSDT;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblHang;
        private ComboBox cboHang;
        private CheckBox chkTrangThai;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblTimTen;
        private TextBox txtTimTen;
        private Label lblTimHang;
        private ComboBox cboTimHang;
        private Button btnTimKiem;
        private DataGridView dgvHoiVien;
        private ErrorProvider errorProvider1;
    }
}
