namespace DatPhongDemo
{
    partial class frmDatPhong
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
            lblTitle = new Label();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            txtCCCD = new TextBox();
            lblCCCD = new Label();
            txtNgayTra = new TextBox();
            lblNgayTraPhong = new Label();
            txtSoTreEm = new TextBox();
            lblSoTreEm = new Label();
            txtSoNguoiLon = new TextBox();
            lblSoNguoiLon = new Label();
            btnDatPhong = new Button();
            errorProvider1 = new ErrorProvider(components);
            txtNgayNhan = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            lblTitle.Location = new Point(255, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(268, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Form Đặt Phòng";
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(152, 91);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(54, 20);
            lblHoTen.TabIndex = 1;
            lblHoTen.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(152, 114);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(466, 27);
            txtHoTen.TabIndex = 2;
            // 
            // txtCCCD
            // 
            txtCCCD.Location = new Point(152, 187);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(466, 27);
            txtCCCD.TabIndex = 4;
            // 
            // lblCCCD
            // 
            lblCCCD.AutoSize = true;
            lblCCCD.Location = new Point(152, 164);
            lblCCCD.Name = "lblCCCD";
            lblCCCD.Size = new Size(68, 20);
            lblCCCD.TabIndex = 3;
            lblCCCD.Text = "Số CCCD";
            // 
            // txtNgayTra
            // 
            txtNgayTra.Location = new Point(152, 334);
            txtNgayTra.Name = "txtNgayTra";
            txtNgayTra.Size = new Size(466, 27);
            txtNgayTra.TabIndex = 6;
            // 
            // lblNgayTraPhong
            // 
            lblNgayTraPhong.AutoSize = true;
            lblNgayTraPhong.Location = new Point(152, 311);
            lblNgayTraPhong.Name = "lblNgayTraPhong";
            lblNgayTraPhong.Size = new Size(114, 20);
            lblNgayTraPhong.TabIndex = 5;
            lblNgayTraPhong.Text = "Ngày Trả Phòng";
            // 
            // txtSoTreEm
            // 
            txtSoTreEm.Location = new Point(152, 414);
            txtSoTreEm.Name = "txtSoTreEm";
            txtSoTreEm.Size = new Size(466, 27);
            txtSoTreEm.TabIndex = 8;
            // 
            // lblSoTreEm
            // 
            lblSoTreEm.AutoSize = true;
            lblSoTreEm.Location = new Point(152, 391);
            lblSoTreEm.Name = "lblSoTreEm";
            lblSoTreEm.Size = new Size(73, 20);
            lblSoTreEm.TabIndex = 7;
            lblSoTreEm.Text = "Số trẻ em";
            // 
            // txtSoNguoiLon
            // 
            txtSoNguoiLon.Location = new Point(152, 489);
            txtSoNguoiLon.Name = "txtSoNguoiLon";
            txtSoNguoiLon.Size = new Size(466, 27);
            txtSoNguoiLon.TabIndex = 10;
            // 
            // lblSoNguoiLon
            // 
            lblSoNguoiLon.AutoSize = true;
            lblSoNguoiLon.Location = new Point(152, 466);
            lblSoNguoiLon.Name = "lblSoNguoiLon";
            lblSoNguoiLon.Size = new Size(94, 20);
            lblSoNguoiLon.TabIndex = 9;
            lblSoNguoiLon.Text = "Số người lớn";
            // 
            // btnDatPhong
            // 
            btnDatPhong.Location = new Point(276, 547);
            btnDatPhong.Name = "btnDatPhong";
            btnDatPhong.Size = new Size(221, 42);
            btnDatPhong.TabIndex = 11;
            btnDatPhong.Text = "Đặt Phòng";
            btnDatPhong.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // txtNgayNhan
            // 
            txtNgayNhan.Location = new Point(152, 260);
            txtNgayNhan.Name = "txtNgayNhan";
            txtNgayNhan.Size = new Size(466, 27);
            txtNgayNhan.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(152, 237);
            label1.Name = "label1";
            label1.Size = new Size(129, 20);
            label1.TabIndex = 12;
            label1.Text = "Ngày Nhận Phòng";
            // 
            // frmDatPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 605);
            Controls.Add(txtNgayNhan);
            Controls.Add(label1);
            Controls.Add(btnDatPhong);
            Controls.Add(txtSoNguoiLon);
            Controls.Add(lblSoNguoiLon);
            Controls.Add(txtSoTreEm);
            Controls.Add(lblSoTreEm);
            Controls.Add(txtNgayTra);
            Controls.Add(lblNgayTraPhong);
            Controls.Add(txtCCCD);
            Controls.Add(lblCCCD);
            Controls.Add(txtHoTen);
            Controls.Add(lblHoTen);
            Controls.Add(lblTitle);
            Name = "frmDatPhong";
            Text = "Đặt phòng";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private TextBox txtCCCD;
        private Label lblCCCD;
        private TextBox txtNgayTra;
        private Label lblNgayTraPhong;
        private TextBox txtSoTreEm;
        private Label lblSoTreEm;
        private TextBox txtSoNguoiLon;
        private Label lblSoNguoiLon;
        private Button btnDatPhong;
        private ErrorProvider errorProvider1;
        private TextBox txtNgayNhan;
        private Label label1;
    }
}
