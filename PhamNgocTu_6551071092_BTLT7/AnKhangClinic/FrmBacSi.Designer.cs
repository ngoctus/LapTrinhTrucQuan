namespace AnKhangClinic
{
    partial class FrmBacSi
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
            lblMaBS = new Label();
            txtMaBS = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblChuyenKhoa = new Label();
            txtChuyenKhoa = new TextBox();
            lblSDT = new Label();
            txtSDT = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            dgvBacSi = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvBacSi).BeginInit();
            SuspendLayout();
            // lblMaBS
            lblMaBS.Location = new Point(20, 20);
            lblMaBS.Name = "lblMaBS";
            lblMaBS.Size = new Size(100, 23);
            lblMaBS.Text = "Mã bác sĩ";
            lblMaBS.AutoSize = false;
            lblMaBS.TextAlign = ContentAlignment.MiddleLeft;
            // txtMaBS
            txtMaBS.Location = new Point(130, 17);
            txtMaBS.Name = "txtMaBS";
            txtMaBS.Size = new Size(120, 27);
            txtMaBS.ReadOnly = true;
            // lblHoTen
            lblHoTen.Location = new Point(20, 55);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(100, 23);
            lblHoTen.Text = "Họ tên";
            lblHoTen.AutoSize = false;
            lblHoTen.TextAlign = ContentAlignment.MiddleLeft;
            // txtHoTen
            txtHoTen.Location = new Point(130, 52);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(300, 27);
            txtHoTen.MaxLength = 100;
            // lblChuyenKhoa
            lblChuyenKhoa.Location = new Point(20, 90);
            lblChuyenKhoa.Name = "lblChuyenKhoa";
            lblChuyenKhoa.Size = new Size(100, 23);
            lblChuyenKhoa.Text = "Chuyên khoa";
            lblChuyenKhoa.AutoSize = false;
            lblChuyenKhoa.TextAlign = ContentAlignment.MiddleLeft;
            // txtChuyenKhoa
            txtChuyenKhoa.Location = new Point(130, 87);
            txtChuyenKhoa.Name = "txtChuyenKhoa";
            txtChuyenKhoa.Size = new Size(300, 27);
            txtChuyenKhoa.MaxLength = 100;
            // lblSDT
            lblSDT.Location = new Point(20, 125);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(100, 23);
            lblSDT.Text = "SĐT";
            lblSDT.AutoSize = false;
            lblSDT.TextAlign = ContentAlignment.MiddleLeft;
            // txtSDT
            txtSDT.Location = new Point(130, 122);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(300, 27);
            txtSDT.MaxLength = 15;
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
            // dgvBacSi
            dgvBacSi.Location = new Point(20, 200);
            dgvBacSi.Name = "dgvBacSi";
            dgvBacSi.Size = new Size(570, 230);
            dgvBacSi.AllowUserToAddRows = false;
            dgvBacSi.AllowUserToDeleteRows = false;
            dgvBacSi.ReadOnly = true;
            dgvBacSi.MultiSelect = false;
            dgvBacSi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBacSi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBacSi.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBacSi.RowHeadersVisible = false;
            this.Load += FrmBacSi_Load;
            btnThem.Click += btnThem_Click;
            btnSua.Click += btnSua_Click;
            btnXoa.Click += btnXoa_Click;
            btnLamMoi.Click += btnLamMoi_Click;
            dgvBacSi.SelectionChanged += dgvBacSi_SelectionChanged;
            // FrmBacSi
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(610, 450);
            Controls.Add(lblMaBS);
            Controls.Add(txtMaBS);
            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);
            Controls.Add(lblChuyenKhoa);
            Controls.Add(txtChuyenKhoa);
            Controls.Add(lblSDT);
            Controls.Add(txtSDT);
            Controls.Add(btnThem);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(btnLamMoi);
            Controls.Add(dgvBacSi);
            Text = "Quản lý Bác sĩ";
            StartPosition = FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)dgvBacSi).EndInit();
            lblMaBS.TabIndex = 0;
            txtMaBS.TabIndex = 1;
            lblHoTen.TabIndex = 2;
            txtHoTen.TabIndex = 3;
            lblChuyenKhoa.TabIndex = 4;
            txtChuyenKhoa.TabIndex = 5;
            lblSDT.TabIndex = 6;
            txtSDT.TabIndex = 7;
            btnThem.TabIndex = 8;
            btnSua.TabIndex = 9;
            btnXoa.TabIndex = 10;
            btnLamMoi.TabIndex = 11;
            dgvBacSi.TabIndex = 12;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaBS;
        private TextBox txtMaBS;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblChuyenKhoa;
        private TextBox txtChuyenKhoa;
        private Label lblSDT;
        private TextBox txtSDT;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private DataGridView dgvBacSi;
    }
}
