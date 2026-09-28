namespace BanVeDemo
{
    partial class FormBanVe
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
            txtTenKhach = new TextBox();
            lblTenKhach = new Label();
            lblCboPhim = new Label();
            lblCboXuatChieu = new Label();
            lblGheDaChon = new Label();
            btnChonGhe = new Button();
            btnDatVe = new Button();
            btnHuy = new Button();
            cboSuatChieu = new ComboBox();
            txtGheDaChon = new TextBox();
            cboPhim = new ComboBox();
            SuspendLayout();
            // 
            // txtTenKhach
            // 
            txtTenKhach.Location = new Point(22, 52);
            txtTenKhach.Name = "txtTenKhach";
            txtTenKhach.Size = new Size(509, 27);
            txtTenKhach.TabIndex = 0;
            // 
            // lblTenKhach
            // 
            lblTenKhach.AutoSize = true;
            lblTenKhach.Location = new Point(22, 29);
            lblTenKhach.Name = "lblTenKhach";
            lblTenKhach.Size = new Size(74, 20);
            lblTenKhach.TabIndex = 1;
            lblTenKhach.Text = "Tên khách";
            // 
            // lblCboPhim
            // 
            lblCboPhim.AutoSize = true;
            lblCboPhim.Location = new Point(22, 101);
            lblCboPhim.Name = "lblCboPhim";
            lblCboPhim.Size = new Size(42, 20);
            lblCboPhim.TabIndex = 2;
            lblCboPhim.Text = "Phim";
            // 
            // lblCboXuatChieu
            // 
            lblCboXuatChieu.AutoSize = true;
            lblCboXuatChieu.Location = new Point(22, 181);
            lblCboXuatChieu.Name = "lblCboXuatChieu";
            lblCboXuatChieu.Size = new Size(77, 20);
            lblCboXuatChieu.TabIndex = 3;
            lblCboXuatChieu.Text = "Suất chiếu";
            // 
            // lblGheDaChon
            // 
            lblGheDaChon.AutoSize = true;
            lblGheDaChon.Location = new Point(22, 252);
            lblGheDaChon.Name = "lblGheDaChon";
            lblGheDaChon.Size = new Size(92, 20);
            lblGheDaChon.TabIndex = 4;
            lblGheDaChon.Text = "Ghế đã chọn";
            // 
            // btnChonGhe
            // 
            btnChonGhe.Location = new Point(22, 350);
            btnChonGhe.Name = "btnChonGhe";
            btnChonGhe.Size = new Size(130, 27);
            btnChonGhe.TabIndex = 8;
            btnChonGhe.Text = "Chọn ghế";
            btnChonGhe.UseVisualStyleBackColor = true;
            // 
            // btnDatVe
            // 
            btnDatVe.Location = new Point(207, 350);
            btnDatVe.Name = "btnDatVe";
            btnDatVe.Size = new Size(130, 27);
            btnDatVe.TabIndex = 9;
            btnDatVe.Text = "Đặt vé";
            btnDatVe.UseVisualStyleBackColor = true;
            // 
            // btnHuy
            // 
            btnHuy.Location = new Point(401, 350);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(130, 27);
            btnHuy.TabIndex = 10;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = true;
            // 
            // cboSuatChieu
            // 
            cboSuatChieu.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSuatChieu.FormattingEnabled = true;
            cboSuatChieu.Location = new Point(22, 204);
            cboSuatChieu.Name = "cboSuatChieu";
            cboSuatChieu.Size = new Size(509, 28);
            cboSuatChieu.TabIndex = 11;
            // 
            // txtGheDaChon
            // 
            txtGheDaChon.Location = new Point(22, 275);
            txtGheDaChon.Name = "txtGheDaChon";
            txtGheDaChon.ReadOnly = true;
            txtGheDaChon.Size = new Size(509, 27);
            txtGheDaChon.TabIndex = 7;
            // 
            // cboPhim
            // 
            cboPhim.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPhim.FormattingEnabled = true;
            cboPhim.Location = new Point(22, 124);
            cboPhim.Name = "cboPhim";
            cboPhim.Size = new Size(509, 28);
            cboPhim.TabIndex = 12;
            // 
            // FormBanVe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(557, 450);
            Controls.Add(cboPhim);
            Controls.Add(cboSuatChieu);
            Controls.Add(btnHuy);
            Controls.Add(btnDatVe);
            Controls.Add(btnChonGhe);
            Controls.Add(txtGheDaChon);
            Controls.Add(lblGheDaChon);
            Controls.Add(lblCboXuatChieu);
            Controls.Add(lblCboPhim);
            Controls.Add(lblTenKhach);
            Controls.Add(txtTenKhach);
            Name = "FormBanVe";
            Text = "Bán vé xem phim";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTenKhach;
        private Label lblTenKhach;
        private Label lblCboPhim;
        private Label lblCboXuatChieu;
        private Label lblGheDaChon;
        private Button btnChonGhe;
        private Button btnDatVe;
        private Button btnHuy;
        private ComboBox cboSuatChieu;
        private TextBox txtGheDaChon;
        private ComboBox cboPhim;
    }
}
