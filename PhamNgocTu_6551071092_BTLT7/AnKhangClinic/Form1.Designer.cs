namespace AnKhangClinic
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
            lblMaLich = new Label();
            txtMaLich = new TextBox();
            lblTenBN = new Label();
            txtTenBenhNhan = new TextBox();
            lblSDT = new Label();
            txtSDT = new TextBox();
            lblNgayKham = new Label();
            dtpNgayKham = new DateTimePicker();
            lblGioKham = new Label();
            dtpGioKham = new DateTimePicker();
            lblBacSi = new Label();
            cboBacSi = new ComboBox();
            lblTrangThai = new Label();
            cboTrangThai = new ComboBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            btnBacSi = new Button();
            lblTuNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            lblDenNgay = new Label();
            dtpDenNgay = new DateTimePicker();
            lblTimBS = new Label();
            cboTimBacSi = new ComboBox();
            btnTimKiem = new Button();
            dgvLichKham = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLichKham).BeginInit();
            SuspendLayout();
            // lblMaLich
            lblMaLich.Location = new Point(20, 20);
            lblMaLich.Name = "lblMaLich";
            lblMaLich.Size = new Size(100, 23);
            lblMaLich.Text = "Mã lịch";
            lblMaLich.AutoSize = false;
            lblMaLich.TextAlign = ContentAlignment.MiddleLeft;
            // txtMaLich
            txtMaLich.Location = new Point(140, 17);
            txtMaLich.Name = "txtMaLich";
            txtMaLich.Size = new Size(120, 27);
            txtMaLich.ReadOnly = true;
            // lblTenBN
            lblTenBN.Location = new Point(20, 55);
            lblTenBN.Name = "lblTenBN";
            lblTenBN.Size = new Size(115, 23);
            lblTenBN.Text = "Tên bệnh nhân";
            lblTenBN.AutoSize = false;
            lblTenBN.TextAlign = ContentAlignment.MiddleLeft;
            // txtTenBenhNhan
            txtTenBenhNhan.Location = new Point(140, 52);
            txtTenBenhNhan.Name = "txtTenBenhNhan";
            txtTenBenhNhan.Size = new Size(300, 27);
            txtTenBenhNhan.MaxLength = 100;
            // lblSDT
            lblSDT.Location = new Point(20, 90);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(100, 23);
            lblSDT.Text = "SĐT";
            lblSDT.AutoSize = false;
            lblSDT.TextAlign = ContentAlignment.MiddleLeft;
            // txtSDT
            txtSDT.Location = new Point(140, 87);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(300, 27);
            txtSDT.MaxLength = 15;
            // lblNgayKham
            lblNgayKham.Location = new Point(20, 125);
            lblNgayKham.Name = "lblNgayKham";
            lblNgayKham.Size = new Size(100, 23);
            lblNgayKham.Text = "Ngày khám";
            lblNgayKham.AutoSize = false;
            lblNgayKham.TextAlign = ContentAlignment.MiddleLeft;
            // dtpNgayKham
            dtpNgayKham.Location = new Point(140, 122);
            dtpNgayKham.Name = "dtpNgayKham";
            dtpNgayKham.Size = new Size(150, 27);
            dtpNgayKham.Format = DateTimePickerFormat.Short;
            // lblGioKham
            lblGioKham.Location = new Point(20, 160);
            lblGioKham.Name = "lblGioKham";
            lblGioKham.Size = new Size(100, 23);
            lblGioKham.Text = "Giờ khám";
            lblGioKham.AutoSize = false;
            lblGioKham.TextAlign = ContentAlignment.MiddleLeft;
            // dtpGioKham
            dtpGioKham.Location = new Point(140, 157);
            dtpGioKham.Name = "dtpGioKham";
            dtpGioKham.Size = new Size(100, 27);
            dtpGioKham.Format = DateTimePickerFormat.Custom;
            dtpGioKham.CustomFormat = "HH:mm";
            dtpGioKham.ShowUpDown = true;
            // lblBacSi
            lblBacSi.Location = new Point(20, 195);
            lblBacSi.Name = "lblBacSi";
            lblBacSi.Size = new Size(100, 23);
            lblBacSi.Text = "Bác sĩ";
            lblBacSi.AutoSize = false;
            lblBacSi.TextAlign = ContentAlignment.MiddleLeft;
            // cboBacSi
            cboBacSi.Location = new Point(140, 192);
            cboBacSi.Name = "cboBacSi";
            cboBacSi.Size = new Size(300, 28);
            cboBacSi.DropDownStyle = ComboBoxStyle.DropDownList;
            // lblTrangThai
            lblTrangThai.Location = new Point(20, 230);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(100, 23);
            lblTrangThai.Text = "Trạng thái";
            lblTrangThai.AutoSize = false;
            lblTrangThai.TextAlign = ContentAlignment.MiddleLeft;
            // cboTrangThai
            cboTrangThai.Location = new Point(140, 227);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(150, 28);
            cboTrangThai.Items.AddRange(new object[] { "Chờ khám", "Đã khám", "Đã hủy" });
            cboTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
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
            // btnBacSi
            btnBacSi.Location = new Point(520, 193);
            btnBacSi.Name = "btnBacSi";
            btnBacSi.Size = new Size(120, 34);
            btnBacSi.Text = "Bác sĩ";
            btnBacSi.UseVisualStyleBackColor = true;
            // lblTuNgay
            lblTuNgay.Location = new Point(20, 275);
            lblTuNgay.Name = "lblTuNgay";
            lblTuNgay.Size = new Size(70, 23);
            lblTuNgay.Text = "Từ ngày";
            lblTuNgay.AutoSize = false;
            lblTuNgay.TextAlign = ContentAlignment.MiddleLeft;
            // dtpTuNgay
            dtpTuNgay.Location = new Point(95, 272);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(140, 27);
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.ShowCheckBox = true;
            dtpTuNgay.Checked = false;
            // lblDenNgay
            lblDenNgay.Location = new Point(250, 275);
            lblDenNgay.Name = "lblDenNgay";
            lblDenNgay.Size = new Size(70, 23);
            lblDenNgay.Text = "Đến ngày";
            lblDenNgay.AutoSize = false;
            lblDenNgay.TextAlign = ContentAlignment.MiddleLeft;
            // dtpDenNgay
            dtpDenNgay.Location = new Point(325, 272);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(140, 27);
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.ShowCheckBox = true;
            dtpDenNgay.Checked = false;
            // lblTimBS
            lblTimBS.Location = new Point(485, 275);
            lblTimBS.Name = "lblTimBS";
            lblTimBS.Size = new Size(50, 23);
            lblTimBS.Text = "Bác sĩ";
            lblTimBS.AutoSize = false;
            lblTimBS.TextAlign = ContentAlignment.MiddleLeft;
            // cboTimBacSi
            cboTimBacSi.Location = new Point(540, 272);
            cboTimBacSi.Name = "cboTimBacSi";
            cboTimBacSi.Size = new Size(210, 28);
            cboTimBacSi.DropDownStyle = ComboBoxStyle.DropDownList;
            // btnTimKiem
            btnTimKiem.Location = new Point(765, 270);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(110, 32);
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // dgvLichKham
            dgvLichKham.Location = new Point(20, 315);
            dgvLichKham.Name = "dgvLichKham";
            dgvLichKham.Size = new Size(855, 245);
            dgvLichKham.AllowUserToAddRows = false;
            dgvLichKham.AllowUserToDeleteRows = false;
            dgvLichKham.ReadOnly = true;
            dgvLichKham.MultiSelect = false;
            dgvLichKham.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLichKham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLichKham.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLichKham.RowHeadersVisible = false;
            this.Load += Form1_Load;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnBacSi.Click += btnBacSi_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            dgvLichKham.SelectionChanged += dgvLichKham_SelectionChanged;
            // Form1
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(895, 580);
            Controls.Add(lblMaLich);
            Controls.Add(txtMaLich);
            Controls.Add(lblTenBN);
            Controls.Add(txtTenBenhNhan);
            Controls.Add(lblSDT);
            Controls.Add(txtSDT);
            Controls.Add(lblNgayKham);
            Controls.Add(dtpNgayKham);
            Controls.Add(lblGioKham);
            Controls.Add(dtpGioKham);
            Controls.Add(lblBacSi);
            Controls.Add(cboBacSi);
            Controls.Add(lblTrangThai);
            Controls.Add(cboTrangThai);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(btnBacSi);
            Controls.Add(lblTuNgay);
            Controls.Add(dtpTuNgay);
            Controls.Add(lblDenNgay);
            Controls.Add(dtpDenNgay);
            Controls.Add(lblTimBS);
            Controls.Add(cboTimBacSi);
            Controls.Add(btnTimKiem);
            Controls.Add(dgvLichKham);
            Text = "Quản lý Lịch khám - An Khang Clinic";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)dgvLichKham).EndInit();
            lblMaLich.TabIndex = 0;
            txtMaLich.TabIndex = 1;
            lblTenBN.TabIndex = 2;
            txtTenBenhNhan.TabIndex = 3;
            lblSDT.TabIndex = 4;
            txtSDT.TabIndex = 5;
            lblNgayKham.TabIndex = 6;
            dtpNgayKham.TabIndex = 7;
            lblGioKham.TabIndex = 8;
            dtpGioKham.TabIndex = 9;
            lblBacSi.TabIndex = 10;
            cboBacSi.TabIndex = 11;
            lblTrangThai.TabIndex = 12;
            cboTrangThai.TabIndex = 13;
            btnThem.TabIndex = 14;
            btnSua.TabIndex = 15;
            btnXoa.TabIndex = 16;
            btnLamMoi.TabIndex = 17;
            btnBacSi.TabIndex = 18;
            lblTuNgay.TabIndex = 19;
            dtpTuNgay.TabIndex = 20;
            lblDenNgay.TabIndex = 21;
            dtpDenNgay.TabIndex = 22;
            lblTimBS.TabIndex = 23;
            cboTimBacSi.TabIndex = 24;
            btnTimKiem.TabIndex = 25;
            dgvLichKham.TabIndex = 26;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaLich;
        private TextBox txtMaLich;
        private Label lblTenBN;
        private TextBox txtTenBenhNhan;
        private Label lblSDT;
        private TextBox txtSDT;
        private Label lblNgayKham;
        private DateTimePicker dtpNgayKham;
        private Label lblGioKham;
        private DateTimePicker dtpGioKham;
        private Label lblBacSi;
        private ComboBox cboBacSi;
        private Label lblTrangThai;
        private ComboBox cboTrangThai;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Button btnBacSi;
        private Label lblTuNgay;
        private DateTimePicker dtpTuNgay;
        private Label lblDenNgay;
        private DateTimePicker dtpDenNgay;
        private Label lblTimBS;
        private ComboBox cboTimBacSi;
        private Button btnTimKiem;
        private DataGridView dgvLichKham;
    }
}
