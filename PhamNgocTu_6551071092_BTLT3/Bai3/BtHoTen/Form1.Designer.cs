namespace BtHoTen
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
            lblHo = new Label();
            lblTen = new Label();
            txtHo = new TextBox();
            txtTen = new TextBox();
            btnHo = new Button();
            btnTen = new Button();
            btnHoTen = new Button();
            btnThoat = new Button();
            lblHoTen = new Label();
            SuspendLayout();
            // 
            // lblHo
            // 
            lblHo.AutoSize = true;
            lblHo.Location = new Point(128, 119);
            lblHo.Name = "lblHo";
            lblHo.Size = new Size(51, 20);
            lblHo.TabIndex = 0;
            lblHo.Text = "Họ lót";
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Location = new Point(128, 179);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(32, 20);
            lblTen.TabIndex = 1;
            lblTen.Text = "Tên";
            // 
            // txtHo
            // 
            txtHo.Location = new Point(226, 112);
            txtHo.Name = "txtHo";
            txtHo.Size = new Size(412, 27);
            txtHo.TabIndex = 2;
            // 
            // txtTen
            // 
            txtTen.BackColor = Color.MistyRose;
            txtTen.Location = new Point(226, 179);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(412, 27);
            txtTen.TabIndex = 3;
            // 
            // btnHo
            // 
            btnHo.Location = new Point(78, 236);
            btnHo.Name = "btnHo";
            btnHo.Size = new Size(121, 49);
            btnHo.TabIndex = 4;
            btnHo.Text = "Họ lót";
            btnHo.UseVisualStyleBackColor = true;
            btnHo.Click += btnHo_Click;
            // 
            // btnTen
            // 
            btnTen.Location = new Point(321, 236);
            btnTen.Name = "btnTen";
            btnTen.Size = new Size(121, 49);
            btnTen.TabIndex = 5;
            btnTen.Text = "Tên";
            btnTen.UseVisualStyleBackColor = true;
            btnTen.Click += btnTen_Click;
            // 
            // btnHoTen
            // 
            btnHoTen.Location = new Point(561, 236);
            btnHoTen.Name = "btnHoTen";
            btnHoTen.Size = new Size(121, 49);
            btnHoTen.TabIndex = 6;
            btnHoTen.Text = "Họ và Tên";
            btnHoTen.UseVisualStyleBackColor = true;
            btnHoTen.Click += btnHoTen_Click;
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(249, 323);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(250, 53);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoát Chương Trình";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.BackColor = SystemColors.MenuHighlight;
            lblHoTen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHoTen.ForeColor = SystemColors.HighlightText;
            lblHoTen.Location = new Point(-108, -2);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Padding = new Padding(450, 30, 450, 30);
            lblHoTen.Size = new Size(987, 83);
            lblHoTen.TabIndex = 8;
            lblHoTen.Text = "Họ và tên";
            lblHoTen.TextAlign = ContentAlignment.MiddleCenter;
            lblHoTen.DoubleClick += lblHoTen_DoubleClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(777, 421);
            Controls.Add(lblHoTen);
            Controls.Add(btnThoat);
            Controls.Add(btnHoTen);
            Controls.Add(btnTen);
            Controls.Add(btnHo);
            Controls.Add(txtTen);
            Controls.Add(txtHo);
            Controls.Add(lblTen);
            Controls.Add(lblHo);
            Name = "Form1";
            Text = "Bài tập họ tên";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHo;
        private Label lblTen;
        private TextBox txtHo;
        private TextBox txtTen;
        private Button btnHo;
        private Button btnTen;
        private Button btnHoTen;
        private Button btnThoat;
        private Label lblHoTen;
    }
}
