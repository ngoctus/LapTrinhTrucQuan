namespace Formater
{
    partial class Formater
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
            lblNhapTen = new Label();
            txtNhapTen = new TextBox();
            lblLapTrinh = new TextBox();
            lblLapTrinhBoi = new Label();
            btnClose = new Button();
            groupBox1 = new GroupBox();
            radBlack = new RadioButton();
            radBlue = new RadioButton();
            radGreen = new RadioButton();
            radRed = new RadioButton();
            groupBox2 = new GroupBox();
            chkUnderline = new CheckBox();
            chkItalic = new CheckBox();
            chkBold = new CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // lblNhapTen
            // 
            lblNhapTen.AutoSize = true;
            lblNhapTen.BackColor = SystemColors.ActiveCaptionText;
            lblNhapTen.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblNhapTen.ForeColor = Color.Lime;
            lblNhapTen.Location = new Point(95, 24);
            lblNhapTen.Name = "lblNhapTen";
            lblNhapTen.Size = new Size(76, 20);
            lblNhapTen.TabIndex = 0;
            lblNhapTen.Text = "Nhập Tên";
            // 
            // txtNhapTen
            // 
            txtNhapTen.Location = new Point(184, 21);
            txtNhapTen.Name = "txtNhapTen";
            txtNhapTen.Size = new Size(470, 27);
            txtNhapTen.TabIndex = 1;
            // 
            // lblLapTrinh
            // 
            lblLapTrinh.Font = new Font("Segoe UI", 9F);
            lblLapTrinh.Location = new Point(209, 389);
            lblLapTrinh.Name = "lblLapTrinh";
            lblLapTrinh.Size = new Size(371, 27);
            lblLapTrinh.TabIndex = 3;
            lblLapTrinh.TextChanged += lblLapTrinh_TextChanged;
            // 
            // lblLapTrinhBoi
            // 
            lblLapTrinhBoi.AutoSize = true;
            lblLapTrinhBoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLapTrinhBoi.ForeColor = Color.DarkRed;
            lblLapTrinhBoi.Location = new Point(96, 392);
            lblLapTrinhBoi.Name = "lblLapTrinhBoi";
            lblLapTrinhBoi.Size = new Size(98, 20);
            lblLapTrinhBoi.TabIndex = 2;
            lblLapTrinhBoi.Text = "Lập trình bởi";
            // 
            // btnClose
            // 
            btnClose.Location = new Point(595, 388);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 29);
            btnClose.TabIndex = 4;
            btnClose.Text = "Thoát";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ActiveCaption;
            groupBox1.Controls.Add(radBlack);
            groupBox1.Controls.Add(radBlue);
            groupBox1.Controls.Add(radGreen);
            groupBox1.Controls.Add(radRed);
            groupBox1.Location = new Point(95, 86);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(234, 238);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Color";
            // 
            // radBlack
            // 
            radBlack.AutoSize = true;
            radBlack.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            radBlack.ForeColor = Color.Black;
            radBlack.Location = new Point(68, 151);
            radBlack.Name = "radBlack";
            radBlack.Size = new Size(67, 24);
            radBlack.TabIndex = 3;
            radBlack.TabStop = true;
            radBlack.Text = "Black";
            radBlack.UseVisualStyleBackColor = true;
            radBlack.CheckedChanged += radBlack_CheckedChanged;
            // 
            // radBlue
            // 
            radBlue.AutoSize = true;
            radBlue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            radBlue.ForeColor = Color.MediumBlue;
            radBlue.Location = new Point(68, 112);
            radBlue.Name = "radBlue";
            radBlue.Size = new Size(61, 24);
            radBlue.TabIndex = 2;
            radBlue.TabStop = true;
            radBlue.Text = "Blue";
            radBlue.UseVisualStyleBackColor = true;
            radBlue.CheckedChanged += radBlue_CheckedChanged;
            // 
            // radGreen
            // 
            radGreen.AutoSize = true;
            radGreen.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            radGreen.ForeColor = Color.Green;
            radGreen.Location = new Point(68, 76);
            radGreen.Name = "radGreen";
            radGreen.Size = new Size(72, 24);
            radGreen.TabIndex = 1;
            radGreen.TabStop = true;
            radGreen.Text = "Green";
            radGreen.UseVisualStyleBackColor = true;
            radGreen.CheckedChanged += radGreen_CheckedChanged;
            // 
            // radRed
            // 
            radRed.AutoSize = true;
            radRed.Checked = true;
            radRed.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            radRed.ForeColor = Color.Red;
            radRed.Location = new Point(68, 46);
            radRed.Name = "radRed";
            radRed.Size = new Size(57, 24);
            radRed.TabIndex = 0;
            radRed.TabStop = true;
            radRed.Text = "Red";
            radRed.UseVisualStyleBackColor = true;
            radRed.CheckedChanged += radRed_CheckedChanged;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(255, 224, 192);
            groupBox2.Controls.Add(chkUnderline);
            groupBox2.Controls.Add(chkItalic);
            groupBox2.Controls.Add(chkBold);
            groupBox2.Location = new Point(420, 86);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(234, 238);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Font";
            // 
            // chkUnderline
            // 
            chkUnderline.AutoSize = true;
            chkUnderline.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Underline);
            chkUnderline.ForeColor = Color.MediumBlue;
            chkUnderline.Location = new Point(57, 157);
            chkUnderline.Name = "chkUnderline";
            chkUnderline.Size = new Size(103, 24);
            chkUnderline.TabIndex = 2;
            chkUnderline.Text = "Gạch chân";
            chkUnderline.UseVisualStyleBackColor = true;
            chkUnderline.CheckedChanged += chkUnderline_CheckedChanged;
            // 
            // chkItalic
            // 
            chkItalic.AutoSize = true;
            chkItalic.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic);
            chkItalic.ForeColor = Color.MediumBlue;
            chkItalic.Location = new Point(57, 107);
            chkItalic.Name = "chkItalic";
            chkItalic.Size = new Size(133, 24);
            chkItalic.TabIndex = 1;
            chkItalic.Text = "Nghiêng Italic";
            chkItalic.UseVisualStyleBackColor = true;
            chkItalic.CheckedChanged += chkItalic_CheckedChanged;
            // 
            // chkBold
            // 
            chkBold.AutoSize = true;
            chkBold.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            chkBold.ForeColor = Color.MediumBlue;
            chkBold.Location = new Point(57, 56);
            chkBold.Name = "chkBold";
            chkBold.Size = new Size(100, 24);
            chkBold.TabIndex = 0;
            chkBold.Text = "Đậm Bold";
            chkBold.UseVisualStyleBackColor = true;
            chkBold.CheckedChanged += chkBold_CheckedChanged;
            // 
            // Formater
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(767, 450);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnClose);
            Controls.Add(lblLapTrinh);
            Controls.Add(lblLapTrinhBoi);
            Controls.Add(txtNhapTen);
            Controls.Add(lblNhapTen);
            Font = new Font("Segoe UI", 9F);
            Name = "Formater";
            Text = "Định dạng (Formarter)";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNhapTen;
        private TextBox txtNhapTen;
        private TextBox lblLapTrinh;
        private Label lblLapTrinhBoi;
        private Button btnClose;
        private GroupBox groupBox1;
        private RadioButton radRed;
        private GroupBox groupBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox chkBold;
        private RadioButton radBlack;
        private RadioButton radBlue;
        private RadioButton radGreen;
        private CheckBox chkItalic;
        private CheckBox chkUnderline;
    }
}
