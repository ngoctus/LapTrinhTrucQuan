#nullable disable
namespace GymFitLife
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            toolTip1 = new ToolTip(components);
            lblTieuDe = new Label();
            lblHoTen = new Label();
            lblSDT = new Label();
            lblEmail = new Label();
            lblNgaySinh = new Label();
            lblGoiTap = new Label();
            lblSoBuoi = new Label();
            txtHoTen = new TextBox();
            txtSDT = new TextBox();
            txtEmail = new TextBox();
            dtpNgaySinh = new DateTimePicker();
            cboGoiTap = new ComboBox();
            numSoBuoiTuan = new NumericUpDown();
            btnDangKy = new Button();
            ((System.ComponentModel.ISupportInitialize)numSoBuoiTuan).BeginInit();
            SuspendLayout();
            //
            // lblTieuDe
            //
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTieuDe.Location = new Point(70, 15);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Text = "ĐĂNG KÝ HỘI VIÊN FITLIFE";
            //
            // lblHoTen
            //
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(30, 68);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Text = "Họ tên:";
            //
            // lblSDT
            //
            lblSDT.AutoSize = true;
            lblSDT.Location = new Point(30, 108);
            lblSDT.Name = "lblSDT";
            lblSDT.Text = "Số điện thoại:";
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(30, 148);
            lblEmail.Name = "lblEmail";
            lblEmail.Text = "Email:";
            //
            // lblNgaySinh
            //
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(30, 188);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Text = "Ngày sinh:";
            //
            // lblGoiTap
            //
            lblGoiTap.AutoSize = true;
            lblGoiTap.Location = new Point(30, 228);
            lblGoiTap.Name = "lblGoiTap";
            lblGoiTap.Text = "Gói tập:";
            //
            // lblSoBuoi
            //
            lblSoBuoi.AutoSize = true;
            lblSoBuoi.Location = new Point(30, 268);
            lblSoBuoi.Name = "lblSoBuoi";
            lblSoBuoi.Text = "Số buổi/tuần:";
            //
            // txtHoTen
            //
            txtHoTen.Location = new Point(150, 65);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(220, 23);
            txtHoTen.TabIndex = 0;
            toolTip1.SetToolTip(txtHoTen, "Nhập họ và tên đầy đủ của hội viên");
            //
            // txtSDT
            //
            txtSDT.Location = new Point(150, 105);
            txtSDT.Name = "txtSDT";
            txtSDT.Size = new Size(220, 23);
            txtSDT.TabIndex = 1;
            toolTip1.SetToolTip(txtSDT, "Nhập đúng 10 chữ số, không chứa khoảng trắng hay ký tự đặc biệt");
            //
            // txtEmail
            //
            txtEmail.Location = new Point(150, 145);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 23);
            txtEmail.TabIndex = 2;
            toolTip1.SetToolTip(txtEmail, "Email dùng để nhận thông báo lịch tập và khuyến mãi");
            //
            // dtpNgaySinh
            //
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(150, 185);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(220, 23);
            dtpNgaySinh.TabIndex = 3;
            toolTip1.SetToolTip(dtpNgaySinh, "Chọn ngày sinh của hội viên");
            //
            // cboGoiTap
            //
            cboGoiTap.DropDownStyle = ComboBoxStyle.DropDownList;
            cboGoiTap.Items.AddRange(new object[] { "Basic", "VIP", "Premium" });
            cboGoiTap.Location = new Point(150, 225);
            cboGoiTap.Name = "cboGoiTap";
            cboGoiTap.Size = new Size(220, 23);
            cboGoiTap.TabIndex = 4;
            cboGoiTap.SelectedIndex = 0;
            toolTip1.SetToolTip(cboGoiTap, "Gói VIP và Premium có kèm huấn luyện viên riêng");
            //
            // numSoBuoiTuan
            //
            numSoBuoiTuan.Location = new Point(150, 265);
            numSoBuoiTuan.Maximum = new decimal(new int[] { 7, 0, 0, 0 });
            numSoBuoiTuan.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSoBuoiTuan.Name = "numSoBuoiTuan";
            numSoBuoiTuan.Size = new Size(80, 23);
            numSoBuoiTuan.TabIndex = 5;
            numSoBuoiTuan.Value = new decimal(new int[] { 1, 0, 0, 0 });
            toolTip1.SetToolTip(numSoBuoiTuan, "Số buổi tập mỗi tuần, từ 1 đến 7");
            //
            // btnDangKy
            //
            btnDangKy.Location = new Point(150, 315);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(120, 35);
            btnDangKy.TabIndex = 6;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = true;
            btnDangKy.Click += btnDangKy_Click;
            toolTip1.SetToolTip(btnDangKy, "Bấm để hoàn tất đăng ký hội viên");
            //
            // Form1
            //
            AcceptButton = btnDangKy;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 380);
            Controls.Add(lblTieuDe);
            Controls.Add(lblHoTen);
            Controls.Add(lblSDT);
            Controls.Add(lblEmail);
            Controls.Add(lblNgaySinh);
            Controls.Add(lblGoiTap);
            Controls.Add(lblSoBuoi);
            Controls.Add(txtHoTen);
            Controls.Add(txtSDT);
            Controls.Add(txtEmail);
            Controls.Add(dtpNgaySinh);
            Controls.Add(cboGoiTap);
            Controls.Add(numSoBuoiTuan);
            Controls.Add(btnDangKy);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Phòng Gym FitLife - Đăng ký hội viên";
            ((System.ComponentModel.ISupportInitialize)numSoBuoiTuan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolTip toolTip1;
        private Label lblTieuDe;
        private Label lblHoTen;
        private Label lblSDT;
        private Label lblEmail;
        private Label lblNgaySinh;
        private Label lblGoiTap;
        private Label lblSoBuoi;
        private TextBox txtHoTen;
        private TextBox txtSDT;
        private TextBox txtEmail;
        private DateTimePicker dtpNgaySinh;
        private ComboBox cboGoiTap;
        private NumericUpDown numSoBuoiTuan;
        private Button btnDangKy;
    }
}