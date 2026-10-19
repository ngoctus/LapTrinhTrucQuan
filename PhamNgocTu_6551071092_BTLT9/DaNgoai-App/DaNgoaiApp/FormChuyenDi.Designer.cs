#nullable disable
namespace DaNgoaiApp
{
    partial class FormChuyenDi
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            grpThongTin = new GroupBox();
            lblTen = new Label(); txtTen = new TextBox();
            lblDiaDiem = new Label(); txtDiaDiem = new TextBox();
            lblNgayDi = new Label(); dtpNgayDi = new DateTimePicker();
            lblSoNguoi = new Label(); nudSoNguoi = new NumericUpDown();
            lblNganSach = new Label(); nudNganSach = new NumericUpDown();
            lblPhuongTien = new Label(); cboPhuongTien = new ComboBox();
            chkDaHoanThanh = new CheckBox();
            lblGhiChu = new Label(); txtGhiChu = new TextBox();
            btnThem = new Button(); btnSua = new Button(); btnXoa = new Button(); btnLamMoi = new Button();

            grpNgonNgu = new GroupBox(); rdoVi = new RadioButton(); rdoEn = new RadioButton();

            grpThoiTiet = new GroupBox();
            btnThoiTiet = new Button(); progressBar = new ProgressBar();
            panelWeather = new Panel();
            lblIcon = new Label(); lblDesc = new Label(); lblWhere = new Label();
            lblTemp = new Label(); lblRain = new Label(); lblAdvice = new Label(); lblInfo = new Label();

            grpLoc = new GroupBox();
            lblTimKiem = new Label(); txtTimKiem = new TextBox();
            chkChuaHT = new CheckBox(); chkLocNgay = new CheckBox();
            lblTu = new Label(); dtpTu = new DateTimePicker();
            lblDen = new Label(); dtpDen = new DateTimePicker();

            dgv = new DataGridView();

            ((System.ComponentModel.ISupportInitialize)nudSoNguoi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNganSach).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            grpThongTin.SuspendLayout();
            grpNgonNgu.SuspendLayout();
            grpThoiTiet.SuspendLayout();
            panelWeather.SuspendLayout();
            grpLoc.SuspendLayout();
            SuspendLayout();

            // ===== grpThongTin =====
            grpThongTin.Location = new Point(10, 10);
            grpThongTin.Size = new Size(560, 290);
            grpThongTin.TabIndex = 0; grpThongTin.TabStop = false;
            grpThongTin.Controls.AddRange(new Control[] {
                lblTen, txtTen, lblDiaDiem, txtDiaDiem, lblNgayDi, dtpNgayDi, lblSoNguoi, nudSoNguoi,
                lblNganSach, nudNganSach, lblPhuongTien, cboPhuongTien, chkDaHoanThanh, lblGhiChu, txtGhiChu,
                btnThem, btnSua, btnXoa, btnLamMoi });

            lblTen.AutoSize = true; lblTen.Location = new Point(15, 33);
            txtTen.Location = new Point(130, 30); txtTen.Size = new Size(410, 23); txtTen.MaxLength = 100; txtTen.TabIndex = 0;

            lblDiaDiem.AutoSize = true; lblDiaDiem.Location = new Point(15, 65);
            txtDiaDiem.Location = new Point(130, 62); txtDiaDiem.Size = new Size(410, 23); txtDiaDiem.MaxLength = 100; txtDiaDiem.TabIndex = 1;

            lblNgayDi.AutoSize = true; lblNgayDi.Location = new Point(15, 97);
            dtpNgayDi.Location = new Point(130, 94); dtpNgayDi.Size = new Size(130, 23); dtpNgayDi.TabIndex = 2;
            dtpNgayDi.Format = DateTimePickerFormat.Custom;

            lblSoNguoi.AutoSize = true; lblSoNguoi.Location = new Point(300, 97);
            nudSoNguoi.Location = new Point(420, 94); nudSoNguoi.Size = new Size(80, 23);
            nudSoNguoi.Minimum = 1; nudSoNguoi.Maximum = 1000; nudSoNguoi.Value = 1; nudSoNguoi.TabIndex = 3;

            lblNganSach.AutoSize = true; lblNganSach.Location = new Point(15, 129);
            nudNganSach.Location = new Point(130, 126); nudNganSach.Size = new Size(170, 23);
            nudNganSach.Minimum = 0; nudNganSach.Maximum = 999999999999M; nudNganSach.Increment = 100000;
            nudNganSach.DecimalPlaces = 0; nudNganSach.ThousandsSeparator = true; nudNganSach.TabIndex = 4;

            lblPhuongTien.AutoSize = true; lblPhuongTien.Location = new Point(320, 129);
            cboPhuongTien.Location = new Point(420, 126); cboPhuongTien.Size = new Size(120, 23);
            cboPhuongTien.DropDownStyle = ComboBoxStyle.DropDownList; cboPhuongTien.TabIndex = 5;

            chkDaHoanThanh.AutoSize = true; chkDaHoanThanh.Location = new Point(130, 160); chkDaHoanThanh.TabIndex = 6;

            lblGhiChu.AutoSize = true; lblGhiChu.Location = new Point(15, 192);
            txtGhiChu.Location = new Point(130, 189); txtGhiChu.Size = new Size(410, 40);
            txtGhiChu.Multiline = true; txtGhiChu.MaxLength = 200; txtGhiChu.TabIndex = 7;

            btnThem.Location = new Point(15, 245); btnThem.Size = new Size(115, 32); btnThem.TabIndex = 8;
            btnSua.Location = new Point(145, 245); btnSua.Size = new Size(115, 32); btnSua.TabIndex = 9;
            btnXoa.Location = new Point(275, 245); btnXoa.Size = new Size(115, 32); btnXoa.TabIndex = 10;
            btnLamMoi.Location = new Point(405, 245); btnLamMoi.Size = new Size(115, 32); btnLamMoi.TabIndex = 11;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;

            // ===== grpNgonNgu =====
            grpNgonNgu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpNgonNgu.Location = new Point(580, 10); grpNgonNgu.Size = new Size(500, 55);
            grpNgonNgu.TabIndex = 1; grpNgonNgu.TabStop = false;
            grpNgonNgu.Controls.AddRange(new Control[] { rdoVi, rdoEn });
            rdoVi.AutoSize = true; rdoVi.Location = new Point(20, 24); rdoVi.TabIndex = 0;
            rdoEn.AutoSize = true; rdoEn.Location = new Point(160, 24); rdoEn.TabIndex = 1;
            rdoVi.CheckedChanged += rdoLang_CheckedChanged;
            rdoEn.CheckedChanged += rdoLang_CheckedChanged;

            // ===== grpThoiTiet =====
            grpThoiTiet.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpThoiTiet.Location = new Point(580, 70); grpThoiTiet.Size = new Size(500, 230);
            grpThoiTiet.TabIndex = 2; grpThoiTiet.TabStop = false;
            grpThoiTiet.Controls.AddRange(new Control[] { btnThoiTiet, progressBar, panelWeather });

            btnThoiTiet.Location = new Point(15, 25); btnThoiTiet.Size = new Size(140, 32); btnThoiTiet.TabIndex = 0;
            btnThoiTiet.Click += btnThoiTiet_Click;

            progressBar.Location = new Point(170, 33); progressBar.Size = new Size(315, 16);
            progressBar.Style = ProgressBarStyle.Marquee; progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Visible = false;

            panelWeather.Location = new Point(15, 68); panelWeather.Size = new Size(470, 150);
            panelWeather.BorderStyle = BorderStyle.FixedSingle;
            panelWeather.Controls.AddRange(new Control[] { lblIcon, lblDesc, lblWhere, lblTemp, lblRain, lblAdvice, lblInfo });

            lblIcon.BackColor = Color.Transparent; lblIcon.Font = new Font("Segoe UI Emoji", 36F);
            lblIcon.Location = new Point(8, 8); lblIcon.Size = new Size(95, 90); lblIcon.TextAlign = ContentAlignment.MiddleCenter;

            lblDesc.BackColor = Color.Transparent; lblDesc.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDesc.Location = new Point(108, 8); lblDesc.Size = new Size(350, 30);

            lblWhere.BackColor = Color.Transparent; lblWhere.Location = new Point(110, 40); lblWhere.Size = new Size(348, 20);

            lblTemp.BackColor = Color.Transparent; lblTemp.Font = new Font("Segoe UI", 10F);
            lblTemp.Location = new Point(110, 64); lblTemp.Size = new Size(348, 22);

            lblRain.BackColor = Color.Transparent; lblRain.Font = new Font("Segoe UI", 10F);
            lblRain.Location = new Point(110, 88); lblRain.Size = new Size(348, 22);

            lblAdvice.BackColor = Color.Transparent; lblAdvice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAdvice.Location = new Point(10, 116); lblAdvice.Size = new Size(448, 24); lblAdvice.Visible = false;

            lblInfo.BackColor = Color.Transparent; lblInfo.Font = new Font("Segoe UI", 10.5F);
            lblInfo.Location = new Point(110, 10); lblInfo.Size = new Size(350, 128); lblInfo.Visible = false;

            // ===== grpLoc =====
            grpLoc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpLoc.Location = new Point(10, 308); grpLoc.Size = new Size(1070, 62);
            grpLoc.TabIndex = 3; grpLoc.TabStop = false;
            grpLoc.Controls.AddRange(new Control[] { lblTimKiem, txtTimKiem, chkChuaHT, chkLocNgay, lblTu, dtpTu, lblDen, dtpDen });

            lblTimKiem.AutoSize = true; lblTimKiem.Location = new Point(15, 28);
            txtTimKiem.Location = new Point(85, 25); txtTimKiem.Size = new Size(210, 23); txtTimKiem.TabIndex = 0;
            txtTimKiem.TextChanged += FilterChanged;

            chkChuaHT.AutoSize = true; chkChuaHT.Location = new Point(315, 27); chkChuaHT.TabIndex = 1;
            chkChuaHT.CheckedChanged += FilterChanged;

            chkLocNgay.AutoSize = true; chkLocNgay.Location = new Point(580, 27); chkLocNgay.TabIndex = 2;
            chkLocNgay.CheckedChanged += FilterChanged;

            lblTu.AutoSize = true; lblTu.Location = new Point(690, 28);
            dtpTu.Location = new Point(730, 25); dtpTu.Size = new Size(120, 23); dtpTu.TabIndex = 3;
            dtpTu.ValueChanged += FilterChanged;

            lblDen.AutoSize = true; lblDen.Location = new Point(865, 28);
            dtpDen.Location = new Point(905, 25); dtpDen.Size = new Size(120, 23); dtpDen.TabIndex = 4;
            dtpDen.ValueChanged += FilterChanged;

            // ===== dgv =====
            dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv.Location = new Point(10, 380); dgv.Size = new Size(1070, 290); dgv.TabIndex = 4;
            dgv.SelectionChanged += dgv_SelectionChanged;

            // ===== Form =====
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1090, 680);
            MinimumSize = new Size(1106, 719);
            StartPosition = FormStartPosition.CenterScreen;
            Controls.Add(grpThongTin);
            Controls.Add(grpNgonNgu);
            Controls.Add(grpThoiTiet);
            Controls.Add(grpLoc);
            Controls.Add(dgv);
            Name = "FormChuyenDi";

            ((System.ComponentModel.ISupportInitialize)nudSoNguoi).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNganSach).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            grpThongTin.ResumeLayout(false); grpThongTin.PerformLayout();
            grpNgonNgu.ResumeLayout(false); grpNgonNgu.PerformLayout();
            grpThoiTiet.ResumeLayout(false);
            panelWeather.ResumeLayout(false);
            grpLoc.ResumeLayout(false); grpLoc.PerformLayout();
            ResumeLayout(false);
        }

        private GroupBox grpThongTin;
        private Label lblTen; private TextBox txtTen;
        private Label lblDiaDiem; private TextBox txtDiaDiem;
        private Label lblNgayDi; private DateTimePicker dtpNgayDi;
        private Label lblSoNguoi; private NumericUpDown nudSoNguoi;
        private Label lblNganSach; private NumericUpDown nudNganSach;
        private Label lblPhuongTien; private ComboBox cboPhuongTien;
        private CheckBox chkDaHoanThanh;
        private Label lblGhiChu; private TextBox txtGhiChu;
        private Button btnThem, btnSua, btnXoa, btnLamMoi;

        private GroupBox grpNgonNgu; private RadioButton rdoVi; private RadioButton rdoEn;

        private GroupBox grpThoiTiet;
        private Button btnThoiTiet; private ProgressBar progressBar;
        private Panel panelWeather;
        private Label lblIcon, lblDesc, lblWhere, lblTemp, lblRain, lblAdvice, lblInfo;

        private GroupBox grpLoc;
        private Label lblTimKiem; private TextBox txtTimKiem;
        private CheckBox chkChuaHT, chkLocNgay;
        private Label lblTu; private DateTimePicker dtpTu;
        private Label lblDen; private DateTimePicker dtpDen;

        private DataGridView dgv;
    }
}
