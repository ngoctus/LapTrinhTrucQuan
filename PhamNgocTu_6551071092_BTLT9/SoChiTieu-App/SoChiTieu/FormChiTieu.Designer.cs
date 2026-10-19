#nullable disable

namespace SoChiTieu;

partial class FormChiTieu
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
        var dataGridViewCellStyleAlt = new DataGridViewCellStyle();
        var dataGridViewCellStyleMoney = new DataGridViewCellStyle();

        grpNhap = new GroupBox();
        lblNgay = new Label();
        dtpNgayChi = new DateTimePicker();
        lblLoai = new Label();
        cboLoaiChi = new ComboBox();
        lblTien = new Label();
        nudSoTien = new NumericUpDown();
        lblNoiDung = new Label();
        txtNoiDung = new TextBox();
        lblGhiChu = new Label();
        txtGhiChu = new TextBox();
        btnThem = new Button();
        btnSua = new Button();
        btnXoa = new Button();
        btnLamMoi = new Button();
        grpLoc = new GroupBox();
        lblTim = new Label();
        txtTim = new TextBox();
        lblLocLoai = new Label();
        cboLocLoai = new ComboBox();
        chkLocNgay = new CheckBox();
        lblTu = new Label();
        dtpTu = new DateTimePicker();
        lblDen = new Label();
        dtpDen = new DateTimePicker();
        btnThangNay = new Button();
        btnBoLoc = new Button();
        pnlDuoi = new Panel();
        lblSoDong = new Label();
        lblTong = new Label();
        dgv = new DataGridView();
        colMaCT = new DataGridViewTextBoxColumn();
        colNgayChi = new DataGridViewTextBoxColumn();
        colNoiDung = new DataGridViewTextBoxColumn();
        colLoaiChi = new DataGridViewTextBoxColumn();
        colSoTien = new DataGridViewTextBoxColumn();
        colGhiChu = new DataGridViewTextBoxColumn();

        grpNhap.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudSoTien).BeginInit();
        grpLoc.SuspendLayout();
        pnlDuoi.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
        SuspendLayout();

        // grpNhap
        grpNhap.Controls.Add(lblNgay);
        grpNhap.Controls.Add(dtpNgayChi);
        grpNhap.Controls.Add(lblLoai);
        grpNhap.Controls.Add(cboLoaiChi);
        grpNhap.Controls.Add(lblTien);
        grpNhap.Controls.Add(nudSoTien);
        grpNhap.Controls.Add(lblNoiDung);
        grpNhap.Controls.Add(txtNoiDung);
        grpNhap.Controls.Add(lblGhiChu);
        grpNhap.Controls.Add(txtGhiChu);
        grpNhap.Controls.Add(btnThem);
        grpNhap.Controls.Add(btnSua);
        grpNhap.Controls.Add(btnXoa);
        grpNhap.Controls.Add(btnLamMoi);
        grpNhap.Dock = DockStyle.Top;
        grpNhap.Location = new Point(0, 0);
        grpNhap.Name = "grpNhap";
        grpNhap.Padding = new Padding(8);
        grpNhap.Size = new Size(1000, 190);
        grpNhap.TabIndex = 0;
        grpNhap.TabStop = false;
        grpNhap.Text = "Thông tin khoản chi";

        // lblNgay
        lblNgay.AutoSize = true;
        lblNgay.Location = new Point(16, 31);
        lblNgay.Name = "lblNgay";
        lblNgay.Text = "Ngày chi";

        // dtpNgayChi
        dtpNgayChi.CustomFormat = "dd/MM/yyyy";
        dtpNgayChi.Format = DateTimePickerFormat.Custom;
        dtpNgayChi.Location = new Point(100, 27);
        dtpNgayChi.Name = "dtpNgayChi";
        dtpNgayChi.Size = new Size(140, 25);
        dtpNgayChi.TabIndex = 0;

        // lblLoai
        lblLoai.AutoSize = true;
        lblLoai.Location = new Point(270, 31);
        lblLoai.Name = "lblLoai";
        lblLoai.Text = "Loại chi";

        // cboLoaiChi
        cboLoaiChi.DropDownStyle = ComboBoxStyle.DropDownList;
        cboLoaiChi.Location = new Point(340, 27);
        cboLoaiChi.Name = "cboLoaiChi";
        cboLoaiChi.Size = new Size(150, 25);
        cboLoaiChi.TabIndex = 1;

        // lblTien
        lblTien.AutoSize = true;
        lblTien.Location = new Point(520, 31);
        lblTien.Name = "lblTien";
        lblTien.Text = "Số tiền (đ)";

        // nudSoTien
        nudSoTien.Increment = 1000M;
        nudSoTien.Location = new Point(600, 27);
        nudSoTien.Maximum = 999999999999M;
        nudSoTien.Minimum = 0M;
        nudSoTien.Name = "nudSoTien";
        nudSoTien.Size = new Size(170, 25);
        nudSoTien.TabIndex = 2;
        nudSoTien.TextAlign = HorizontalAlignment.Right;
        nudSoTien.ThousandsSeparator = true;

        // lblNoiDung
        lblNoiDung.AutoSize = true;
        lblNoiDung.Location = new Point(16, 69);
        lblNoiDung.Name = "lblNoiDung";
        lblNoiDung.Text = "Nội dung";

        // txtNoiDung
        txtNoiDung.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtNoiDung.Location = new Point(100, 65);
        txtNoiDung.MaxLength = 100;
        txtNoiDung.Name = "txtNoiDung";
        txtNoiDung.Size = new Size(670, 25);
        txtNoiDung.TabIndex = 3;

        // lblGhiChu
        lblGhiChu.AutoSize = true;
        lblGhiChu.Location = new Point(16, 107);
        lblGhiChu.Name = "lblGhiChu";
        lblGhiChu.Text = "Ghi chú";

        // txtGhiChu
        txtGhiChu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtGhiChu.Location = new Point(100, 103);
        txtGhiChu.MaxLength = 200;
        txtGhiChu.Multiline = true;
        txtGhiChu.Name = "txtGhiChu";
        txtGhiChu.ScrollBars = ScrollBars.Vertical;
        txtGhiChu.Size = new Size(670, 70);
        txtGhiChu.TabIndex = 4;

        // btnThem
        btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnThem.Location = new Point(830, 25);
        btnThem.Name = "btnThem";
        btnThem.Size = new Size(140, 32);
        btnThem.TabIndex = 5;
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = true;
        btnThem.Click += btnThem_Click;

        // btnSua
        btnSua.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnSua.Location = new Point(830, 62);
        btnSua.Name = "btnSua";
        btnSua.Size = new Size(140, 32);
        btnSua.TabIndex = 6;
        btnSua.Text = "Sửa";
        btnSua.UseVisualStyleBackColor = true;
        btnSua.Click += btnSua_Click;

        // btnXoa
        btnXoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnXoa.Location = new Point(830, 99);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new Size(140, 32);
        btnXoa.TabIndex = 7;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = true;
        btnXoa.Click += btnXoa_Click;

        // btnLamMoi
        btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnLamMoi.Location = new Point(830, 136);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new Size(140, 32);
        btnLamMoi.TabIndex = 8;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.UseVisualStyleBackColor = true;
        btnLamMoi.Click += btnLamMoi_Click;

        // grpLoc
        grpLoc.Controls.Add(lblTim);
        grpLoc.Controls.Add(txtTim);
        grpLoc.Controls.Add(lblLocLoai);
        grpLoc.Controls.Add(cboLocLoai);
        grpLoc.Controls.Add(chkLocNgay);
        grpLoc.Controls.Add(lblTu);
        grpLoc.Controls.Add(dtpTu);
        grpLoc.Controls.Add(lblDen);
        grpLoc.Controls.Add(dtpDen);
        grpLoc.Controls.Add(btnThangNay);
        grpLoc.Controls.Add(btnBoLoc);
        grpLoc.Dock = DockStyle.Top;
        grpLoc.Location = new Point(0, 190);
        grpLoc.Name = "grpLoc";
        grpLoc.Size = new Size(1000, 100);
        grpLoc.TabIndex = 1;
        grpLoc.TabStop = false;
        grpLoc.Text = "Tìm kiếm / lọc";

        // lblTim
        lblTim.AutoSize = true;
        lblTim.Location = new Point(16, 31);
        lblTim.Name = "lblTim";
        lblTim.Text = "Tìm nội dung";

        // txtTim
        txtTim.Location = new Point(110, 27);
        txtTim.Name = "txtTim";
        txtTim.PlaceholderText = "Gõ để tìm theo nội dung...";
        txtTim.Size = new Size(260, 25);
        txtTim.TabIndex = 0;
        txtTim.TextChanged += BoLocThayDoi;

        // lblLocLoai
        lblLocLoai.AutoSize = true;
        lblLocLoai.Location = new Point(400, 31);
        lblLocLoai.Name = "lblLocLoai";
        lblLocLoai.Text = "Loại chi";

        // cboLocLoai
        cboLocLoai.DropDownStyle = ComboBoxStyle.DropDownList;
        cboLocLoai.Location = new Point(470, 27);
        cboLocLoai.Name = "cboLocLoai";
        cboLocLoai.Size = new Size(150, 25);
        cboLocLoai.TabIndex = 1;
        cboLocLoai.SelectedIndexChanged += BoLocThayDoi;

        // chkLocNgay
        chkLocNgay.AutoSize = true;
        chkLocNgay.Location = new Point(18, 64);
        chkLocNgay.Name = "chkLocNgay";
        chkLocNgay.TabIndex = 2;
        chkLocNgay.Text = "Lọc theo ngày";
        chkLocNgay.UseVisualStyleBackColor = true;
        chkLocNgay.CheckedChanged += chkLocNgay_CheckedChanged;

        // lblTu
        lblTu.AutoSize = true;
        lblTu.Location = new Point(150, 65);
        lblTu.Name = "lblTu";
        lblTu.Text = "Từ ngày";

        // dtpTu
        dtpTu.CustomFormat = "dd/MM/yyyy";
        dtpTu.Enabled = false;
        dtpTu.Format = DateTimePickerFormat.Custom;
        dtpTu.Location = new Point(215, 61);
        dtpTu.Name = "dtpTu";
        dtpTu.Size = new Size(130, 25);
        dtpTu.TabIndex = 3;
        dtpTu.ValueChanged += BoLocThayDoi;

        // lblDen
        lblDen.AutoSize = true;
        lblDen.Location = new Point(365, 65);
        lblDen.Name = "lblDen";
        lblDen.Text = "Đến ngày";

        // dtpDen
        dtpDen.CustomFormat = "dd/MM/yyyy";
        dtpDen.Enabled = false;
        dtpDen.Format = DateTimePickerFormat.Custom;
        dtpDen.Location = new Point(440, 61);
        dtpDen.Name = "dtpDen";
        dtpDen.Size = new Size(130, 25);
        dtpDen.TabIndex = 4;
        dtpDen.ValueChanged += BoLocThayDoi;

        // btnThangNay
        btnThangNay.Location = new Point(600, 58);
        btnThangNay.Name = "btnThangNay";
        btnThangNay.Size = new Size(100, 30);
        btnThangNay.TabIndex = 5;
        btnThangNay.Text = "Tháng này";
        btnThangNay.UseVisualStyleBackColor = true;
        btnThangNay.Click += btnThangNay_Click;

        // btnBoLoc
        btnBoLoc.Location = new Point(710, 58);
        btnBoLoc.Name = "btnBoLoc";
        btnBoLoc.Size = new Size(100, 30);
        btnBoLoc.TabIndex = 6;
        btnBoLoc.Text = "Bỏ lọc";
        btnBoLoc.UseVisualStyleBackColor = true;
        btnBoLoc.Click += btnBoLoc_Click;

        // pnlDuoi
        pnlDuoi.Controls.Add(lblTong);
        pnlDuoi.Controls.Add(lblSoDong);
        pnlDuoi.Dock = DockStyle.Bottom;
        pnlDuoi.Location = new Point(0, 616);
        pnlDuoi.Name = "pnlDuoi";
        pnlDuoi.Padding = new Padding(12, 0, 12, 0);
        pnlDuoi.Size = new Size(1000, 44);
        pnlDuoi.TabIndex = 3;

        // lblSoDong
        lblSoDong.Dock = DockStyle.Left;
        lblSoDong.Name = "lblSoDong";
        lblSoDong.Size = new Size(420, 44);
        lblSoDong.TabIndex = 0;
        lblSoDong.Text = "0 khoản chi";
        lblSoDong.TextAlign = ContentAlignment.MiddleLeft;

        // lblTong
        lblTong.Dock = DockStyle.Fill;
        lblTong.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
        lblTong.ForeColor = Color.FromArgb(192, 57, 43);
        lblTong.Name = "lblTong";
        lblTong.TabIndex = 1;
        lblTong.Text = "Tổng chi: 0 đ";
        lblTong.TextAlign = ContentAlignment.MiddleRight;

        // dgv
        dataGridViewCellStyleAlt.BackColor = Color.FromArgb(245, 248, 252);
        dgv.AllowUserToAddRows = false;
        dgv.AllowUserToDeleteRows = false;
        dgv.AllowUserToResizeRows = false;
        dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyleAlt;
        dgv.AutoGenerateColumns = false;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.BackgroundColor = SystemColors.Window;
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgv.Columns.AddRange(new DataGridViewColumn[] { colMaCT, colNgayChi, colNoiDung, colLoaiChi, colSoTien, colGhiChu });
        dgv.Dock = DockStyle.Fill;
        dgv.Location = new Point(0, 290);
        dgv.MultiSelect = false;
        dgv.Name = "dgv";
        dgv.ReadOnly = true;
        dgv.RowHeadersVisible = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.Size = new Size(1000, 326);
        dgv.TabIndex = 2;
        dgv.CellFormatting += dgv_CellFormatting;
        dgv.SelectionChanged += dgv_SelectionChanged;

        // colMaCT
        colMaCT.DataPropertyName = "MaCt";
        colMaCT.FillWeight = 8F;
        colMaCT.HeaderText = "Mã";
        colMaCT.Name = "colMaCT";
        colMaCT.ReadOnly = true;
        colMaCT.SortMode = DataGridViewColumnSortMode.NotSortable;

        // colNgayChi
        colNgayChi.DataPropertyName = "NgayChi";
        colNgayChi.FillWeight = 14F;
        colNgayChi.HeaderText = "Ngày chi";
        colNgayChi.Name = "colNgayChi";
        colNgayChi.ReadOnly = true;
        colNgayChi.SortMode = DataGridViewColumnSortMode.NotSortable;

        // colNoiDung
        colNoiDung.DataPropertyName = "NoiDung";
        colNoiDung.FillWeight = 30F;
        colNoiDung.HeaderText = "Nội dung";
        colNoiDung.Name = "colNoiDung";
        colNoiDung.ReadOnly = true;
        colNoiDung.SortMode = DataGridViewColumnSortMode.NotSortable;

        // colLoaiChi
        colLoaiChi.DataPropertyName = "LoaiChi";
        colLoaiChi.FillWeight = 14F;
        colLoaiChi.HeaderText = "Loại chi";
        colLoaiChi.Name = "colLoaiChi";
        colLoaiChi.ReadOnly = true;
        colLoaiChi.SortMode = DataGridViewColumnSortMode.NotSortable;

        // colSoTien
        dataGridViewCellStyleMoney.Alignment = DataGridViewContentAlignment.MiddleRight;
        dataGridViewCellStyleMoney.Format = "N0";
        colSoTien.DataPropertyName = "SoTien";
        colSoTien.DefaultCellStyle = dataGridViewCellStyleMoney;
        colSoTien.FillWeight = 16F;
        colSoTien.HeaderText = "Số tiền (đ)";
        colSoTien.Name = "colSoTien";
        colSoTien.ReadOnly = true;
        colSoTien.SortMode = DataGridViewColumnSortMode.NotSortable;

        // colGhiChu
        colGhiChu.DataPropertyName = "GhiChu";
        colGhiChu.FillWeight = 28F;
        colGhiChu.HeaderText = "Ghi chú";
        colGhiChu.Name = "colGhiChu";
        colGhiChu.ReadOnly = true;
        colGhiChu.SortMode = DataGridViewColumnSortMode.NotSortable;

        // FormChiTieu
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        ClientSize = new Size(1000, 660);
        Controls.Add(dgv);
        Controls.Add(pnlDuoi);
        Controls.Add(grpLoc);
        Controls.Add(grpNhap);
        Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        MinimumSize = new Size(1016, 699);
        Name = "FormChiTieu";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Sổ chi tiêu cá nhân";

        grpNhap.ResumeLayout(false);
        grpNhap.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudSoTien).EndInit();
        grpLoc.ResumeLayout(false);
        grpLoc.PerformLayout();
        pnlDuoi.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox grpNhap;
    private Label lblNgay;
    private DateTimePicker dtpNgayChi;
    private Label lblLoai;
    private ComboBox cboLoaiChi;
    private Label lblTien;
    private NumericUpDown nudSoTien;
    private Label lblNoiDung;
    private TextBox txtNoiDung;
    private Label lblGhiChu;
    private TextBox txtGhiChu;
    private Button btnThem;
    private Button btnSua;
    private Button btnXoa;
    private Button btnLamMoi;
    private GroupBox grpLoc;
    private Label lblTim;
    private TextBox txtTim;
    private Label lblLocLoai;
    private ComboBox cboLocLoai;
    private CheckBox chkLocNgay;
    private Label lblTu;
    private DateTimePicker dtpTu;
    private Label lblDen;
    private DateTimePicker dtpDen;
    private Button btnThangNay;
    private Button btnBoLoc;
    private Panel pnlDuoi;
    private Label lblSoDong;
    private Label lblTong;
    private DataGridView dgv;
    private DataGridViewTextBoxColumn colMaCT;
    private DataGridViewTextBoxColumn colNgayChi;
    private DataGridViewTextBoxColumn colNoiDung;
    private DataGridViewTextBoxColumn colLoaiChi;
    private DataGridViewTextBoxColumn colSoTien;
    private DataGridViewTextBoxColumn colGhiChu;
}
