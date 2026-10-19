namespace QuanLyNhaTro;

partial class FormKhachThue
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleGia = new System.Windows.Forms.DataGridViewCellStyle();
        grpThongTin = new GroupBox();
        lblHoTen = new Label();
        txtHoTen = new TextBox();
        grpGioiTinh = new GroupBox();
        rdoNam = new RadioButton();
        rdoNu = new RadioButton();
        lblNgaySinh = new Label();
        dtpNgaySinh = new DateTimePicker();
        lblSDT = new Label();
        txtSDT = new TextBox();
        lblPhong = new Label();
        cboPhong = new ComboBox();
        lblTinh = new Label();
        cboTinh = new ComboBox();
        lblPhuongXa = new Label();
        cboPhuongXa = new ComboBox();
        chkTamTru = new CheckBox();
        btnThem = new Button();
        btnSua = new Button();
        btnXoa = new Button();
        btnLamMoi = new Button();
        btnGayLoi = new Button();
        grpTimKiem = new GroupBox();
        lblTim = new Label();
        txtTimKiem = new TextBox();
        lblLocPhong = new Label();
        cboLocPhong = new ComboBox();
        lblLocTinh = new Label();
        cboLocTinh = new ComboBox();
        btnBoLoc = new Button();
        dgvKhach = new DataGridView();
        colHoTen = new DataGridViewTextBoxColumn();
        colSDT = new DataGridViewTextBoxColumn();
        colTenPhong = new DataGridViewTextBoxColumn();
        colGiaThue = new DataGridViewTextBoxColumn();
        colQueQuan = new DataGridViewTextBoxColumn();
        colTamTru = new DataGridViewCheckBoxColumn();
        lblTrangThai = new Label();
        grpThongTin.SuspendLayout();
        grpGioiTinh.SuspendLayout();
        grpTimKiem.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvKhach).BeginInit();
        SuspendLayout();
        //
        // grpThongTin
        //
        grpThongTin.Controls.Add(lblHoTen);
        grpThongTin.Controls.Add(txtHoTen);
        grpThongTin.Controls.Add(grpGioiTinh);
        grpThongTin.Controls.Add(lblNgaySinh);
        grpThongTin.Controls.Add(dtpNgaySinh);
        grpThongTin.Controls.Add(lblSDT);
        grpThongTin.Controls.Add(txtSDT);
        grpThongTin.Controls.Add(lblPhong);
        grpThongTin.Controls.Add(cboPhong);
        grpThongTin.Controls.Add(lblTinh);
        grpThongTin.Controls.Add(cboTinh);
        grpThongTin.Controls.Add(lblPhuongXa);
        grpThongTin.Controls.Add(cboPhuongXa);
        grpThongTin.Controls.Add(chkTamTru);
        grpThongTin.Controls.Add(btnThem);
        grpThongTin.Controls.Add(btnSua);
        grpThongTin.Controls.Add(btnXoa);
        grpThongTin.Controls.Add(btnLamMoi);
        grpThongTin.Controls.Add(btnGayLoi);
        grpThongTin.Location = new Point(12, 12);
        grpThongTin.Name = "grpThongTin";
        grpThongTin.Size = new Size(1060, 190);
        grpThongTin.TabIndex = 0;
        grpThongTin.TabStop = false;
        grpThongTin.Text = "Thông tin khách thuê";
        //
        // lblHoTen
        //
        lblHoTen.AutoSize = true;
        lblHoTen.Location = new Point(15, 32);
        lblHoTen.Name = "lblHoTen";
        lblHoTen.Size = new Size(48, 15);
        lblHoTen.Text = "Họ tên:";
        //
        // txtHoTen
        //
        txtHoTen.Location = new Point(100, 29);
        txtHoTen.MaxLength = 100;
        txtHoTen.Name = "txtHoTen";
        txtHoTen.Size = new Size(230, 23);
        txtHoTen.TabIndex = 0;
        //
        // grpGioiTinh
        //
        grpGioiTinh.Controls.Add(rdoNam);
        grpGioiTinh.Controls.Add(rdoNu);
        grpGioiTinh.Location = new Point(360, 14);
        grpGioiTinh.Name = "grpGioiTinh";
        grpGioiTinh.Size = new Size(190, 48);
        grpGioiTinh.TabIndex = 1;
        grpGioiTinh.TabStop = false;
        grpGioiTinh.Text = "Giới tính";
        //
        // rdoNam
        //
        rdoNam.AutoSize = true;
        rdoNam.Checked = true;
        rdoNam.Location = new Point(15, 19);
        rdoNam.Name = "rdoNam";
        rdoNam.Size = new Size(23, 19);
        rdoNam.TabIndex = 0;
        rdoNam.TabStop = true;
        rdoNam.Text = "Nam";
        //
        // rdoNu
        //
        rdoNu.AutoSize = true;
        rdoNu.Location = new Point(95, 19);
        rdoNu.Name = "rdoNu";
        rdoNu.Size = new Size(23, 19);
        rdoNu.TabIndex = 1;
        rdoNu.Text = "Nữ";
        //
        // lblNgaySinh
        //
        lblNgaySinh.AutoSize = true;
        lblNgaySinh.Location = new Point(580, 32);
        lblNgaySinh.Name = "lblNgaySinh";
        lblNgaySinh.Size = new Size(64, 15);
        lblNgaySinh.Text = "Ngày sinh:";
        //
        // dtpNgaySinh
        //
        dtpNgaySinh.Format = DateTimePickerFormat.Short;
        dtpNgaySinh.Location = new Point(660, 29);
        dtpNgaySinh.Name = "dtpNgaySinh";
        dtpNgaySinh.Size = new Size(140, 23);
        dtpNgaySinh.TabIndex = 2;
        //
        // lblSDT
        //
        lblSDT.AutoSize = true;
        lblSDT.Location = new Point(15, 72);
        lblSDT.Name = "lblSDT";
        lblSDT.Size = new Size(79, 15);
        lblSDT.Text = "Số điện thoại:";
        //
        // txtSDT
        //
        txtSDT.Location = new Point(100, 69);
        txtSDT.MaxLength = 15;
        txtSDT.Name = "txtSDT";
        txtSDT.Size = new Size(230, 23);
        txtSDT.TabIndex = 3;
        //
        // lblPhong
        //
        lblPhong.AutoSize = true;
        lblPhong.Location = new Point(360, 72);
        lblPhong.Name = "lblPhong";
        lblPhong.Size = new Size(43, 15);
        lblPhong.Text = "Phòng:";
        //
        // cboPhong
        //
        cboPhong.DropDownStyle = ComboBoxStyle.DropDownList;
        cboPhong.FormattingEnabled = true;
        cboPhong.Location = new Point(430, 69);
        cboPhong.Name = "cboPhong";
        cboPhong.Size = new Size(240, 23);
        cboPhong.TabIndex = 4;
        //
        // lblTinh
        //
        lblTinh.AutoSize = true;
        lblTinh.Location = new Point(15, 112);
        lblTinh.Name = "lblTinh";
        lblTinh.Size = new Size(68, 15);
        lblTinh.Text = "Tỉnh/Thành:";
        //
        // cboTinh
        //
        cboTinh.DropDownStyle = ComboBoxStyle.DropDownList;
        cboTinh.FormattingEnabled = true;
        cboTinh.Location = new Point(100, 109);
        cboTinh.Name = "cboTinh";
        cboTinh.Size = new Size(230, 23);
        cboTinh.TabIndex = 5;
        cboTinh.SelectedIndexChanged += cboTinh_SelectedIndexChanged;
        //
        // lblPhuongXa
        //
        lblPhuongXa.AutoSize = true;
        lblPhuongXa.Location = new Point(360, 112);
        lblPhuongXa.Name = "lblPhuongXa";
        lblPhuongXa.Size = new Size(66, 15);
        lblPhuongXa.Text = "Phường/Xã:";
        //
        // cboPhuongXa
        //
        cboPhuongXa.DropDownStyle = ComboBoxStyle.DropDownList;
        cboPhuongXa.FormattingEnabled = true;
        cboPhuongXa.Location = new Point(430, 109);
        cboPhuongXa.MaxLength = 100;
        cboPhuongXa.Name = "cboPhuongXa";
        cboPhuongXa.Size = new Size(240, 23);
        cboPhuongXa.TabIndex = 6;
        //
        // chkTamTru
        //
        chkTamTru.AutoSize = true;
        chkTamTru.Location = new Point(100, 148);
        chkTamTru.Name = "chkTamTru";
        chkTamTru.Size = new Size(140, 19);
        chkTamTru.TabIndex = 7;
        chkTamTru.Text = "Đã đăng ký tạm trú";
        chkTamTru.UseVisualStyleBackColor = true;
        //
        // btnThem
        //
        btnThem.Location = new Point(840, 25);
        btnThem.Name = "btnThem";
        btnThem.Size = new Size(100, 32);
        btnThem.TabIndex = 8;
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = true;
        btnThem.Click += btnThem_Click;
        //
        // btnSua
        //
        btnSua.Location = new Point(840, 65);
        btnSua.Name = "btnSua";
        btnSua.Size = new Size(100, 32);
        btnSua.TabIndex = 9;
        btnSua.Text = "Sửa";
        btnSua.UseVisualStyleBackColor = true;
        btnSua.Click += btnSua_Click;
        //
        // btnXoa
        //
        btnXoa.Location = new Point(840, 105);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new Size(100, 32);
        btnXoa.TabIndex = 10;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = true;
        btnXoa.Click += btnXoa_Click;
        //
        // btnLamMoi
        //
        btnLamMoi.Location = new Point(840, 145);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new Size(100, 32);
        btnLamMoi.TabIndex = 11;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.UseVisualStyleBackColor = true;
        btnLamMoi.Click += btnLamMoi_Click;
        //
        // btnGayLoi (nút ẩn: bấm Ctrl+Shift+F12 để hiện)
        //
        btnGayLoi.Location = new Point(950, 145);
        btnGayLoi.Name = "btnGayLoi";
        btnGayLoi.Size = new Size(100, 32);
        btnGayLoi.TabIndex = 12;
        btnGayLoi.Text = "Gây lỗi thử";
        btnGayLoi.UseVisualStyleBackColor = true;
        btnGayLoi.Visible = false;
        btnGayLoi.Click += btnGayLoi_Click;
        //
        // grpTimKiem
        //
        grpTimKiem.Controls.Add(lblTim);
        grpTimKiem.Controls.Add(txtTimKiem);
        grpTimKiem.Controls.Add(lblLocPhong);
        grpTimKiem.Controls.Add(cboLocPhong);
        grpTimKiem.Controls.Add(lblLocTinh);
        grpTimKiem.Controls.Add(cboLocTinh);
        grpTimKiem.Controls.Add(btnBoLoc);
        grpTimKiem.Location = new Point(12, 210);
        grpTimKiem.Name = "grpTimKiem";
        grpTimKiem.Size = new Size(1060, 62);
        grpTimKiem.TabIndex = 1;
        grpTimKiem.TabStop = false;
        grpTimKiem.Text = "Tìm kiếm và lọc";
        //
        // lblTim
        //
        lblTim.AutoSize = true;
        lblTim.Location = new Point(15, 28);
        lblTim.Name = "lblTim";
        lblTim.Size = new Size(58, 15);
        lblTim.Text = "Tìm kiếm:";
        //
        // txtTimKiem
        //
        txtTimKiem.Location = new Point(80, 25);
        txtTimKiem.Name = "txtTimKiem";
        txtTimKiem.PlaceholderText = "Họ tên hoặc số điện thoại";
        txtTimKiem.Size = new Size(230, 23);
        txtTimKiem.TabIndex = 0;
        txtTimKiem.TextChanged += LocThayDoi;
        //
        // lblLocPhong
        //
        lblLocPhong.AutoSize = true;
        lblLocPhong.Location = new Point(330, 28);
        lblLocPhong.Name = "lblLocPhong";
        lblLocPhong.Size = new Size(43, 15);
        lblLocPhong.Text = "Phòng:";
        //
        // cboLocPhong
        //
        cboLocPhong.DropDownStyle = ComboBoxStyle.DropDownList;
        cboLocPhong.FormattingEnabled = true;
        cboLocPhong.Location = new Point(380, 25);
        cboLocPhong.Name = "cboLocPhong";
        cboLocPhong.Size = new Size(150, 23);
        cboLocPhong.TabIndex = 1;
        cboLocPhong.SelectedIndexChanged += LocThayDoi;
        //
        // lblLocTinh
        //
        lblLocTinh.AutoSize = true;
        lblLocTinh.Location = new Point(550, 28);
        lblLocTinh.Name = "lblLocTinh";
        lblLocTinh.Size = new Size(68, 15);
        lblLocTinh.Text = "Tỉnh/Thành:";
        //
        // cboLocTinh
        //
        cboLocTinh.DropDownStyle = ComboBoxStyle.DropDownList;
        cboLocTinh.FormattingEnabled = true;
        cboLocTinh.Location = new Point(630, 25);
        cboLocTinh.Name = "cboLocTinh";
        cboLocTinh.Size = new Size(230, 23);
        cboLocTinh.TabIndex = 2;
        cboLocTinh.SelectedIndexChanged += LocThayDoi;
        //
        // btnBoLoc
        //
        btnBoLoc.Location = new Point(880, 22);
        btnBoLoc.Name = "btnBoLoc";
        btnBoLoc.Size = new Size(100, 28);
        btnBoLoc.TabIndex = 3;
        btnBoLoc.Text = "Bỏ lọc";
        btnBoLoc.UseVisualStyleBackColor = true;
        btnBoLoc.Click += btnBoLoc_Click;
        //
        // dgvKhach
        //
        dgvKhach.AllowUserToAddRows = false;
        dgvKhach.AllowUserToDeleteRows = false;
        dgvKhach.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvKhach.AutoGenerateColumns = false;
        dgvKhach.BackgroundColor = SystemColors.Window;
        dgvKhach.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvKhach.Columns.AddRange(new DataGridViewColumn[] { colHoTen, colSDT, colTenPhong, colGiaThue, colQueQuan, colTamTru });
        dgvKhach.Location = new Point(12, 280);
        dgvKhach.MultiSelect = false;
        dgvKhach.Name = "dgvKhach";
        dgvKhach.ReadOnly = true;
        dgvKhach.RowHeadersVisible = false;
        dgvKhach.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvKhach.Size = new Size(1060, 370);
        dgvKhach.TabIndex = 2;
        dgvKhach.SelectionChanged += dgvKhach_SelectionChanged;
        //
        // colHoTen
        //
        colHoTen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        colHoTen.DataPropertyName = "HoTen";
        colHoTen.FillWeight = 25F;
        colHoTen.HeaderText = "Họ tên";
        colHoTen.Name = "colHoTen";
        colHoTen.ReadOnly = true;
        //
        // colSDT
        //
        colSDT.DataPropertyName = "SoDienThoai";
        colSDT.HeaderText = "SĐT";
        colSDT.Name = "colSDT";
        colSDT.ReadOnly = true;
        colSDT.Width = 120;
        //
        // colTenPhong
        //
        colTenPhong.DataPropertyName = "TenPhong";
        colTenPhong.HeaderText = "Tên phòng";
        colTenPhong.Name = "colTenPhong";
        colTenPhong.ReadOnly = true;
        colTenPhong.Width = 90;
        //
        // colGiaThue
        //
        dataGridViewCellStyleGia.Alignment = DataGridViewContentAlignment.MiddleRight;
        dataGridViewCellStyleGia.Format = "N0";
        colGiaThue.DataPropertyName = "GiaThue";
        colGiaThue.DefaultCellStyle = dataGridViewCellStyleGia;
        colGiaThue.HeaderText = "Giá thuê";
        colGiaThue.Name = "colGiaThue";
        colGiaThue.ReadOnly = true;
        colGiaThue.Width = 110;
        //
        // colQueQuan
        //
        colQueQuan.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        colQueQuan.DataPropertyName = "QueQuan";
        colQueQuan.FillWeight = 40F;
        colQueQuan.HeaderText = "Quê quán (Phường/Xã – Tỉnh)";
        colQueQuan.Name = "colQueQuan";
        colQueQuan.ReadOnly = true;
        //
        // colTamTru
        //
        colTamTru.DataPropertyName = "DaDangKyTamTru";
        colTamTru.HeaderText = "Tạm trú";
        colTamTru.Name = "colTamTru";
        colTamTru.ReadOnly = true;
        colTamTru.Width = 70;
        //
        // lblTrangThai
        //
        lblTrangThai.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblTrangThai.AutoSize = true;
        lblTrangThai.Location = new Point(12, 660);
        lblTrangThai.Name = "lblTrangThai";
        lblTrangThai.Size = new Size(49, 15);
        lblTrangThai.Text = "Sẵn sàng";
        //
        // FormKhachThue
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1084, 685);
        Controls.Add(grpThongTin);
        Controls.Add(grpTimKiem);
        Controls.Add(dgvKhach);
        Controls.Add(lblTrangThai);
        KeyPreview = true;
        MinimumSize = new Size(1000, 600);
        Name = "FormKhachThue";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Quản lý nhà trọ - Khách thuê";
        Load += FormKhachThue_Load;
        KeyDown += FormKhachThue_KeyDown;
        grpThongTin.ResumeLayout(false);
        grpThongTin.PerformLayout();
        grpGioiTinh.ResumeLayout(false);
        grpGioiTinh.PerformLayout();
        grpTimKiem.ResumeLayout(false);
        grpTimKiem.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvKhach).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private GroupBox grpThongTin;
    private Label lblHoTen;
    private TextBox txtHoTen;
    private GroupBox grpGioiTinh;
    private RadioButton rdoNam;
    private RadioButton rdoNu;
    private Label lblNgaySinh;
    private DateTimePicker dtpNgaySinh;
    private Label lblSDT;
    private TextBox txtSDT;
    private Label lblPhong;
    private ComboBox cboPhong;
    private Label lblTinh;
    private ComboBox cboTinh;
    private Label lblPhuongXa;
    private ComboBox cboPhuongXa;
    private CheckBox chkTamTru;
    private Button btnThem;
    private Button btnSua;
    private Button btnXoa;
    private Button btnLamMoi;
    private Button btnGayLoi;
    private GroupBox grpTimKiem;
    private Label lblTim;
    private TextBox txtTimKiem;
    private Label lblLocPhong;
    private ComboBox cboLocPhong;
    private Label lblLocTinh;
    private ComboBox cboLocTinh;
    private Button btnBoLoc;
    private DataGridView dgvKhach;
    private DataGridViewTextBoxColumn colHoTen;
    private DataGridViewTextBoxColumn colSDT;
    private DataGridViewTextBoxColumn colTenPhong;
    private DataGridViewTextBoxColumn colGiaThue;
    private DataGridViewTextBoxColumn colQueQuan;
    private DataGridViewCheckBoxColumn colTamTru;
    private Label lblTrangThai;
}
