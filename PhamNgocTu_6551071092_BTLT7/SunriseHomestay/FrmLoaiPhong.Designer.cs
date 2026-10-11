namespace SunriseHomestay
{
    partial class FrmLoaiPhong
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
            lblMaLoai = new Label();
            txtMaLoai = new TextBox();
            lblTenLoai = new Label();
            txtTenLoai = new TextBox();
            lblGia = new Label();
            txtGiaMoiDem = new TextBox();
            lblMoTa = new Label();
            txtMoTa = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvLoaiPhong = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLoaiPhong).BeginInit();
            SuspendLayout();
            // lblMaLoai
            lblMaLoai.Location = new Point(20, 20);
            lblMaLoai.Name = "lblMaLoai";
            lblMaLoai.Size = new Size(100, 23);
            lblMaLoai.Text = "Mã loại";
            lblMaLoai.AutoSize = false;
            lblMaLoai.TextAlign = ContentAlignment.MiddleLeft;
            // txtMaLoai
            txtMaLoai.Location = new Point(130, 17);
            txtMaLoai.Name = "txtMaLoai";
            txtMaLoai.Size = new Size(120, 27);
            txtMaLoai.ReadOnly = true;
            // lblTenLoai
            lblTenLoai.Location = new Point(20, 55);
            lblTenLoai.Name = "lblTenLoai";
            lblTenLoai.Size = new Size(100, 23);
            lblTenLoai.Text = "Tên loại";
            lblTenLoai.AutoSize = false;
            lblTenLoai.TextAlign = ContentAlignment.MiddleLeft;
            // txtTenLoai
            txtTenLoai.Location = new Point(130, 52);
            txtTenLoai.Name = "txtTenLoai";
            txtTenLoai.Size = new Size(300, 27);
            txtTenLoai.MaxLength = 100;
            // lblGia
            lblGia.Location = new Point(20, 90);
            lblGia.Name = "lblGia";
            lblGia.Size = new Size(100, 23);
            lblGia.Text = "Giá mỗi đêm";
            lblGia.AutoSize = false;
            lblGia.TextAlign = ContentAlignment.MiddleLeft;
            // txtGiaMoiDem
            txtGiaMoiDem.Location = new Point(130, 87);
            txtGiaMoiDem.Name = "txtGiaMoiDem";
            txtGiaMoiDem.Size = new Size(300, 27);
            // lblMoTa
            lblMoTa.Location = new Point(20, 125);
            lblMoTa.Name = "lblMoTa";
            lblMoTa.Size = new Size(100, 23);
            lblMoTa.Text = "Mô tả";
            lblMoTa.AutoSize = false;
            lblMoTa.TextAlign = ContentAlignment.MiddleLeft;
            // txtMoTa
            txtMoTa.Location = new Point(130, 122);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(300, 60);
            txtMoTa.Multiline = true;
            txtMoTa.MaxLength = 255;
            txtMoTa.ScrollBars = ScrollBars.Vertical;
            // btnThem
            btnThem.Location = new Point(480, 17);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(110, 34);
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // btnSua
            btnSua.Location = new Point(480, 61);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(110, 34);
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // btnXoa
            btnXoa.Location = new Point(480, 105);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(110, 34);
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // btnLamMoi
            btnLamMoi.Location = new Point(480, 149);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(110, 34);
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // dgvLoaiPhong
            dgvLoaiPhong.Location = new Point(20, 200);
            dgvLoaiPhong.Name = "dgvLoaiPhong";
            dgvLoaiPhong.Size = new Size(570, 230);
            dgvLoaiPhong.AllowUserToAddRows = false;
            dgvLoaiPhong.AllowUserToDeleteRows = false;
            dgvLoaiPhong.ReadOnly = true;
            dgvLoaiPhong.MultiSelect = false;
            dgvLoaiPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLoaiPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLoaiPhong.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLoaiPhong.RowHeadersVisible = false;
            this.Load += FrmLoaiPhong_Load;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            dgvLoaiPhong.SelectionChanged += dgvLoaiPhong_SelectionChanged;
            // FrmLoaiPhong
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(610, 450);
            Controls.Add(lblMaLoai);
            Controls.Add(txtMaLoai);
            Controls.Add(lblTenLoai);
            Controls.Add(txtTenLoai);
            Controls.Add(lblGia);
            Controls.Add(txtGiaMoiDem);
            Controls.Add(lblMoTa);
            Controls.Add(txtMoTa);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(dgvLoaiPhong);
            Text = "Quản lý Loại phòng";
            StartPosition = FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)dgvLoaiPhong).EndInit();
            lblMaLoai.TabIndex = 0;
            txtMaLoai.TabIndex = 1;
            lblTenLoai.TabIndex = 2;
            txtTenLoai.TabIndex = 3;
            lblGia.TabIndex = 4;
            txtGiaMoiDem.TabIndex = 5;
            lblMoTa.TabIndex = 6;
            txtMoTa.TabIndex = 7;
            btnThem.TabIndex = 8;
            btnSua.TabIndex = 9;
            btnXoa.TabIndex = 10;
            btnLamMoi.TabIndex = 11;
            dgvLoaiPhong.TabIndex = 12;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaLoai;
        private TextBox txtMaLoai;
        private Label lblTenLoai;
        private TextBox txtTenLoai;
        private Label lblGia;
        private TextBox txtGiaMoiDem;
        private Label lblMoTa;
        private TextBox txtMoTa;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private DataGridView dgvLoaiPhong;
    }
}
