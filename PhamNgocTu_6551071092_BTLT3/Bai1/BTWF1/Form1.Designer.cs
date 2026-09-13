namespace BTWF1
{
    partial class SuDungLableVaTextBox
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
            btnHienThi = new Button();
            btnTiep = new Button();
            btnDong = new Button();
            lblNhapMK = new Label();
            lblHienThi = new Label();
            txtNhapMK = new TextBox();
            txtHienThi = new TextBox();
            SuspendLayout();
            // 
            // btnHienThi
            // 
            btnHienThi.Location = new Point(46, 234);
            btnHienThi.Name = "btnHienThi";
            btnHienThi.Size = new Size(138, 45);
            btnHienThi.TabIndex = 0;
            btnHienThi.Text = "Hiển thị";
            btnHienThi.UseVisualStyleBackColor = true;
            btnHienThi.Click += btnHienThi_Click;
            // 
            // btnTiep
            // 
            btnTiep.Location = new Point(275, 234);
            btnTiep.Name = "btnTiep";
            btnTiep.Size = new Size(138, 45);
            btnTiep.TabIndex = 1;
            btnTiep.Text = "Tiếp";
            btnTiep.UseVisualStyleBackColor = true;
            btnTiep.Click += btnTiep_Click;
            // 
            // btnDong
            // 
            btnDong.Location = new Point(502, 234);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(138, 45);
            btnDong.TabIndex = 2;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = true;
            btnDong.Click += btnDong_Click;
            // 
            // lblNhapMK
            // 
            lblNhapMK.AutoSize = true;
            lblNhapMK.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNhapMK.Location = new Point(131, 67);
            lblNhapMK.Name = "lblNhapMK";
            lblNhapMK.Size = new Size(117, 20);
            lblNhapMK.TabIndex = 3;
            lblNhapMK.Text = "Nhập mật khẩu";
            // 
            // lblHienThi
            // 
            lblHienThi.AutoSize = true;
            lblHienThi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHienThi.Location = new Point(184, 151);
            lblHienThi.Name = "lblHienThi";
            lblHienThi.Size = new Size(64, 20);
            lblHienThi.TabIndex = 4;
            lblHienThi.Text = "Hiển thị";
            // 
            // txtNhapMK
            // 
            txtNhapMK.Location = new Point(275, 60);
            txtNhapMK.Name = "txtNhapMK";
            txtNhapMK.PasswordChar = '#';
            txtNhapMK.Size = new Size(273, 27);
            txtNhapMK.TabIndex = 5;
            // 
            // txtHienThi
            // 
            txtHienThi.Location = new Point(275, 144);
            txtHienThi.Name = "txtHienThi";
            txtHienThi.Size = new Size(273, 27);
            txtHienThi.TabIndex = 6;
            txtHienThi.TextAlign = HorizontalAlignment.Center;
            // 
            // SuDungLableVaTextBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(699, 354);
            Controls.Add(txtHienThi);
            Controls.Add(txtNhapMK);
            Controls.Add(lblHienThi);
            Controls.Add(lblNhapMK);
            Controls.Add(btnDong);
            Controls.Add(btnTiep);
            Controls.Add(btnHienThi);
            Name = "SuDungLableVaTextBox";
            Text = "Sử dụng Lable và Textbox";
            FormClosing += SuDungLableVaTextBox_FormClosing;
            Load += SuDungLableVaTextBox_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnHienThi;
        private Button btnTiep;
        private Button btnDong;
        private Label lblNhapMK;
        private Label lblHienThi;
        private TextBox txtNhapMK;
        private TextBox txtHienThi;
    }
}
