namespace TriThucBooks
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
            lblMaTL = new Label();
            txtMaTL = new TextBox();
            lblTenTheLoai = new Label();
            txtTenTheLoai = new TextBox();
            lblMoTa = new Label();
            txtMoTa = new TextBox();
            lblSoLuongSach = new Label();
            nudSoLuongSach = new NumericUpDown();
            lblNgayTao = new Label();
            dtpNgayTao = new DateTimePicker();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            lblTimKiem = new Label();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvTheLoai = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).BeginInit();
            SuspendLayout();
            // lblMaTL
            lblMaTL.Location = new Point(20, 20);
            lblMaTL.Name = "lblMaTL";
            lblMaTL.Size = new Size(100, 23);
            lblMaTL.Text = "Mã thể loại";
            lblMaTL.AutoSize = false;
            lblMaTL.TextAlign = ContentAlignment.MiddleLeft;
            // txtMaTL
            txtMaTL.Location = new Point(140, 17);
            txtMaTL.Name = "txtMaTL";
            txtMaTL.Size = new Size(120, 27);
            txtMaTL.ReadOnly = true;
            // lblTenTheLoai
            lblTenTheLoai.Location = new Point(20, 55);
            lblTenTheLoai.Name = "lblTenTheLoai";
            lblTenTheLoai.Size = new Size(100, 23);
            lblTenTheLoai.Text = "Tên thể loại";
            lblTenTheLoai.AutoSize = false;
            lblTenTheLoai.TextAlign = ContentAlignment.MiddleLeft;
            // txtTenTheLoai
            txtTenTheLoai.Location = new Point(140, 52);
            txtTenTheLoai.Name = "txtTenTheLoai";
            txtTenTheLoai.Size = new Size(320, 27);
            txtTenTheLoai.MaxLength = 100;
            // lblMoTa
            lblMoTa.Location = new Point(20, 90);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(100, 23);
            lblMoTa.Text = "Mô tả";
            lblMoTa.AutoSize = false;
            lblMoTa.TextAlign = ContentAlignment.MiddleLeft;
            // txtMoTa
            txtMoTa.Location = new Point(140, 87);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(320, 60);
            txtMoTa.Multiline = true;
            txtMoTa.MaxLength = 255;
            txtMoTa.ScrollBars = ScrollBars.Vertical;
            // lblSoLuongSach
            lblSoLuongSach.Location = new Point(20, 160);
            lblSoLuongSach.Name = "lblSoLuongSach";
            lblSoLuongSach.Size = new Size(100, 23);
            lblSoLuongSach.Text = "Số lượng sách";
            lblSoLuongSach.AutoSize = false;
            lblSoLuongSach.TextAlign = ContentAlignment.MiddleLeft;
            // nudSoLuongSach
            nudSoLuongSach.Location = new Point(140, 157);
            nudSoLuongSach.Name = "nudSoLuongSach";
            nudSoLuongSach.Size = new Size(120, 27);
            nudSoLuongSach.Maximum = 1000000;
            // lblNgayTao
            lblNgayTao.Location = new Point(20, 195);
            lblNgayTao.Name = "lblNgayTao";
            lblNgayTao.Size = new Size(100, 23);
            lblNgayTao.Text = "Ngày tạo";
            lblNgayTao.AutoSize = false;
            lblNgayTao.TextAlign = ContentAlignment.MiddleLeft;
            // dtpNgayTao
            dtpNgayTao.Location = new Point(140, 192);
            dtpNgayTao.Name = "dtpNgayTao";
            dtpNgayTao.Size = new Size(200, 27);
            dtpNgayTao.Format = DateTimePickerFormat.Custom;
            dtpNgayTao.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpNgayTao.Enabled = false;
            // btnThem
            btnThem.Location = new Point(500, 17);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(120, 34);
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // btnSua
            btnSua.Location = new Point(500, 61);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(120, 34);
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // btnXoa
            btnXoa.Location = new Point(500, 105);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(120, 34);
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // btnLamMoi
            btnLamMoi.Location = new Point(500, 149);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(120, 34);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // lblTimKiem
            lblTimKiem.Location = new Point(20, 245);
            lblTimKiem.Name = "lblTimKiem";
            lblTimKiem.Size = new Size(100, 23);
            lblTimKiem.Text = "Tìm theo tên";
            lblTimKiem.AutoSize = false;
            lblTimKiem.TextAlign = ContentAlignment.MiddleLeft;
            // txtTimKiem
            txtTimKiem.Location = new Point(140, 242);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(320, 27);
            // btnTimKiem
            btnTimKiem.Location = new Point(500, 240);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(120, 32);
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            // dgvTheLoai
            dgvTheLoai.Location = new Point(20, 285);
            dgvTheLoai.Name = "dgvTheLoai";
            dgvTheLoai.Size = new Size(840, 250);
            dgvTheLoai.AllowUserToAddRows = false;
            dgvTheLoai.AllowUserToDeleteRows = false;
            dgvTheLoai.ReadOnly = true;
            dgvTheLoai.MultiSelect = false;
            dgvTheLoai.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTheLoai.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTheLoai.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTheLoai.RowHeadersVisible = false;
            this.Load += Form1_Load;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            btnTimKiem.Click += btnTimKiem_Click;
            dgvTheLoai.SelectionChanged += dgvTheLoai_SelectionChanged;
            // Form1
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 555);
            Controls.Add(lblMaTL);
            Controls.Add(txtMaTL);
            Controls.Add(lblTenTheLoai);
            Controls.Add(txtTenTheLoai);
            Controls.Add(lblMoTa);
            Controls.Add(txtMoTa);
            Controls.Add(lblSoLuongSach);
            Controls.Add(nudSoLuongSach);
            Controls.Add(lblNgayTao);
            Controls.Add(dtpNgayTao);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(lblTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(btnTimKiem);
            Controls.Add(dgvTheLoai);
            Text = "Quản lý Thể loại Sách - Tri Thức Books";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)dgvTheLoai).EndInit();
            lblMaTL.TabIndex = 0;
            txtMaTL.TabIndex = 1;
            lblTenTheLoai.TabIndex = 2;
            txtTenTheLoai.TabIndex = 3;
            lblMoTa.TabIndex = 4;
            txtMoTa.TabIndex = 5;
            lblSoLuongSach.TabIndex = 6;
            nudSoLuongSach.TabIndex = 7;
            lblNgayTao.TabIndex = 8;
            dtpNgayTao.TabIndex = 9;
            btnThem.TabIndex = 10;
            btnSua.TabIndex = 11;
            btnXoa.TabIndex = 12;
            btnLamMoi.TabIndex = 13;
            lblTimKiem.TabIndex = 14;
            txtTimKiem.TabIndex = 15;
            btnTimKiem.TabIndex = 16;
            dgvTheLoai.TabIndex = 17;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaTL;
        private TextBox txtMaTL;
        private Label lblTenTheLoai;
        private TextBox txtTenTheLoai;
        private Label lblMoTa;
        private TextBox txtMoTa;
        private Label lblSoLuongSach;
        private NumericUpDown nudSoLuongSach;
        private Label lblNgayTao;
        private DateTimePicker dtpNgayTao;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblTimKiem;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private DataGridView dgvTheLoai;
    }
}
