namespace OrderFoodDemo
{
    partial class FormDangKy
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
            lblHoTen = new Label();
            txtHoten = new TextBox();
            txtSDT = new TextBox();
            lblSDT = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtMatKhau = new TextBox();
            lblMatKhau = new Label();
            errorProvider1 = new ErrorProvider(components);
            txtXacNhanMK = new TextBox();
            lblXacNhanMK = new Label();
            btnDangKy = new Button();
            btnHuy = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(123, 99);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(54, 20);
            lblHoTen.TabIndex = 0;
            lblHoTen.Text = "Họ tên";
            // 
            // txtHoten
            // 
            txtHoten.Location = new Point(282, 92);
            txtHoten.Name = "txtHoten";
            txtHoten.Size = new Size(402, 27);
            txtHoten.TabIndex = 1;
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(282, 150);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(402, 27);
            txtSDT.TabIndex = 3;
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(123, 157);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(36, 20);
            lblSDT.TabIndex = 2;
            lblSDT.Text = "SĐT";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(282, 199);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(402, 27);
            txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(123, 206);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email";
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new Point(282, 262);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PasswordChar = '*';
            txtMatKhau.Size = new Size(402, 27);
            txtMatKhau.TabIndex = 7;
            // 
            // lblMatKhau
            // 
            lblMatKhau.AutoSize = true;
            lblMatKhau.Location = new Point(123, 269);
            lblMatKhau.Name = "lblMatKhau";
            lblMatKhau.Size = new Size(70, 20);
            lblMatKhau.TabIndex = 6;
            lblMatKhau.Text = "Mật khẩu";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // txtXacNhanMK
            // 
            txtXacNhanMK.Location = new Point(282, 317);
            txtXacNhanMK.Name = "txtXacNhanMK";
            txtXacNhanMK.Size = new Size(402, 27);
            txtXacNhanMK.TabIndex = 8;
            // 
            // lblXacNhanMK
            // 
            lblXacNhanMK.AutoSize = true;
            lblXacNhanMK.Location = new Point(123, 324);
            lblXacNhanMK.Name = "lblXacNhanMK";
            lblXacNhanMK.Size = new Size(134, 20);
            lblXacNhanMK.TabIndex = 9;
            lblXacNhanMK.Text = "Xác nhận mật khẩu";
            // 
            // btnDangKy
            // 
            btnDangKy.Location = new Point(123, 380);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(216, 40);
            btnDangKy.TabIndex = 10;
            btnDangKy.Text = "Đăng Ký";
            btnDangKy.UseVisualStyleBackColor = true;
            btnDangKy.Click += btnDangKy_Click_1;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(453, 380);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(231, 40);
            btnHuy.TabIndex = 11;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            btnHuy.Click += btnHuy_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19F, FontStyle.Bold);
            label1.Location = new Point(240, 22);
            label1.Name = "label1";
            label1.Size = new Size(293, 45);
            label1.TabIndex = 12;
            label1.Text = "Đăng ký tài khoản";
            // 
            // FormDangKy
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnHuy);
            Controls.Add(btnDangKy);
            Controls.Add(lblXacNhanMK);
            Controls.Add(txtXacNhanMK);
            Controls.Add(txtMatKhau);
            Controls.Add(lblMatKhau);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtSDT);
            Controls.Add(lblSDT);
            Controls.Add(txtHoten);
            Controls.Add(lblHoTen);
            Name = "FormDangKy";
            Text = "Form Đăng Ký";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHoTen;
        private TextBox txtHoten;
        private TextBox txtSDT;
        private Label lblSDT;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtMatKhau;
        private Label lblMatKhau;
        private ErrorProvider errorProvider1;
        private Button btnHuy;
        private Button btnDangKy;
        private Label lblXacNhanMK;
        private TextBox txtXacNhanMK;
        private Label label1;
    }
}
