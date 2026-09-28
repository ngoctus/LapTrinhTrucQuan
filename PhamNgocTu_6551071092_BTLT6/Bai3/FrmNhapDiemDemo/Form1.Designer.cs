namespace FrmNhapDiemDemo
{
    partial class FormNhapDiem
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
            lblMaHS = new Label();
            txtMaHS = new TextBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            txtToan = new TextBox();
            lblToan = new Label();
            txtVan = new TextBox();
            lblVan = new Label();
            txtAnh = new TextBox();
            lblAnh = new Label();
            btnLuu = new Button();
            btnXoaTrang = new Button();
            listBox1 = new ListBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblMaHS
            // 
            lblMaHS.AutoSize = true;
            lblMaHS.Location = new Point(55, 42);
            lblMaHS.Name = "lblMaHS";
            lblMaHS.Size = new Size(53, 20);
            lblMaHS.TabIndex = 0;
            lblMaHS.Text = "Mã HS";
            // 
            // txtMaHS
            // 
            txtMaHS.Location = new Point(55, 65);
            txtMaHS.Name = "txtMaHS";
            txtMaHS.Size = new Size(91, 27);
            txtMaHS.TabIndex = 0;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(186, 42);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(54, 20);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Họ tên";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(186, 65);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(91, 27);
            txtHoTen.TabIndex = 1;
            // 
            // txtToan
            // 
            txtToan.Location = new Point(326, 65);
            txtToan.Name = "txtToan";
            txtToan.Size = new Size(91, 27);
            txtToan.TabIndex = 2;
            // 
            // lblToan
            // 
            lblToan.AutoSize = true;
            lblToan.Location = new Point(326, 42);
            lblToan.Name = "lblToan";
            lblToan.Size = new Size(79, 20);
            lblToan.TabIndex = 4;
            lblToan.Text = "Điểm toán";
            // 
            // txtVan
            // 
            txtVan.Location = new Point(461, 65);
            txtVan.Name = "txtVan";
            txtVan.Size = new Size(91, 27);
            txtVan.TabIndex = 3;
            // 
            // lblVan
            // 
            lblVan.AutoSize = true;
            lblVan.Location = new Point(461, 42);
            lblVan.Name = "lblVan";
            lblVan.Size = new Size(72, 20);
            lblVan.TabIndex = 3;
            lblVan.Text = "Điểm văn";
            // 
            // txtAnh
            // 
            txtAnh.Location = new Point(593, 65);
            txtAnh.Name = "txtAnh";
            txtAnh.Size = new Size(91, 27);
            txtAnh.TabIndex = 4;
            // 
            // lblAnh
            // 
            lblAnh.AutoSize = true;
            lblAnh.Location = new Point(593, 42);
            lblAnh.Name = "lblAnh";
            lblAnh.Size = new Size(73, 20);
            lblAnh.TabIndex = 6;
            lblAnh.Text = "Điểm anh";
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.FromArgb(192, 255, 192);
            btnLuu.ForeColor = SystemColors.ControlText;
            btnLuu.Location = new Point(55, 118);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(98, 31);
            btnLuu.TabIndex = 5;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnXoaTrang
            // 
            btnXoaTrang.BackColor = SystemColors.ActiveBorder;
            btnXoaTrang.Location = new Point(179, 118);
            btnXoaTrang.Name = "btnXoaTrang";
            btnXoaTrang.Size = new Size(98, 31);
            btnXoaTrang.TabIndex = 6;
            btnXoaTrang.Text = "Xóa trắng";
            btnXoaTrang.UseVisualStyleBackColor = false;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(55, 180);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(629, 224);
            listBox1.TabIndex = 7;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FormNhapDiem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(729, 450);
            Controls.Add(listBox1);
            Controls.Add(btnXoaTrang);
            Controls.Add(btnLuu);
            Controls.Add(txtAnh);
            Controls.Add(lblAnh);
            Controls.Add(txtVan);
            Controls.Add(lblVan);
            Controls.Add(txtToan);
            Controls.Add(lblToan);
            Controls.Add(txtHoTen);
            Controls.Add(lblHoTen);
            Controls.Add(txtMaHS);
            Controls.Add(lblMaHS);
            Name = "FormNhapDiem";
            Text = "Nhập điểm học sinh";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaHS;
        private TextBox txtMaHS;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private TextBox txtToan;
        private Label lblToan;
        private TextBox txtVan;
        private Label lblVan;
        private TextBox txtAnh;
        private Label lblAnh;
        private Button btnLuu;
        private Button btnXoaTrang;
        private ListBox listBox1;
        private ErrorProvider errorProvider1;
    }
}
