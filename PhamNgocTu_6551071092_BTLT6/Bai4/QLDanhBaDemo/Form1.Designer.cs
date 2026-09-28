namespace QLDanhBaDemo
{
    partial class FormDanhBa
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
            lstLienHe = new ListBox();
            txtTen = new TextBox();
            lblTen = new Label();
            lblSDT = new Label();
            txtSDT = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            SuspendLayout();
            // 
            // lstLienHe
            // 
            lstLienHe.FormattingEnabled = true;
            lstLienHe.Location = new Point(17, 19);
            lstLienHe.Name = "lstLienHe";
            lstLienHe.Size = new Size(367, 324);
            lstLienHe.TabIndex = 0;
            // 
            // txtTen
            // 
            txtTen.Location = new Point(413, 51);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(362, 27);
            txtTen.TabIndex = 1;
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Location = new Point(413, 28);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(32, 20);
            lblTen.TabIndex = 2;
            lblTen.Text = "Tên";
            // 
            // lblSDT
            // 
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(413, 98);
            lblSDT.Name = "lblSDT";
            lblSDT.Size = new Size(97, 20);
            lblSDT.TabIndex = 4;
            lblSDT.Text = "Số điện thoại";
            // 
            // txtSDT
            // 
            txtSDT.Location = new Point(413, 121);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(362, 27);
            txtSDT.TabIndex = 3;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(413, 199);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(170, 40);
            btnThem.TabIndex = 5;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(605, 199);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(170, 40);
            btnSua.TabIndex = 6;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(413, 287);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(170, 40);
            btnXoa.TabIndex = 7;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(605, 287);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(170, 40);
            btnThoat.TabIndex = 8;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // FormDanhBa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 362);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(lblSDT);
            Controls.Add(txtSDT);
            Controls.Add(lblTen);
            Controls.Add(txtTen);
            Controls.Add(lstLienHe);
            Name = "FormDanhBa";
            Text = "Quản lý danh bạ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstLienHe;
        private TextBox txtTen;
        private Label lblTen;
        private Label lblSDT;
        private TextBox txtSDT;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnThoat;
    }
}
