namespace QuanLyPhongKham
{
    partial class frmPatient
    {
        private System.ComponentModel.IContainer components = null!;

        private Label lblHoTen = null!;
        private TextBox txtHoTen = null!;
        private Label lblTuoi = null!;
        private NumericUpDown numTuoi = null!;
        private Label lblTrieuChung = null!;
        private TextBox txtTrieuChung = null!;
        private Button btnLuuTam = null!;
        private ListBox lstBenhNhan = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblTuoi = new Label();
            numTuoi = new NumericUpDown();
            lblTrieuChung = new Label();
            txtTrieuChung = new TextBox();
            btnLuuTam = new Button();
            lstBenhNhan = new ListBox();

            // lblHoTen
            lblHoTen.Text = "Họ tên:";
            lblHoTen.Location = new Point(15, 20);
            lblHoTen.AutoSize = true;

            // txtHoTen
            txtHoTen.Location = new Point(120, 17);
            txtHoTen.Size = new Size(220, 23);

            // lblTuoi
            lblTuoi.Text = "Tuổi:";
            lblTuoi.Location = new Point(15, 55);
            lblTuoi.AutoSize = true;

            // numTuoi
            numTuoi.Location = new Point(120, 52);
            numTuoi.Size = new Size(80, 23);
            numTuoi.Minimum = 0;
            numTuoi.Maximum = 120;

            // lblTrieuChung
            lblTrieuChung.Text = "Triệu chứng:";
            lblTrieuChung.Location = new Point(15, 90);
            lblTrieuChung.AutoSize = true;

            // txtTrieuChung
            txtTrieuChung.Location = new Point(120, 87);
            txtTrieuChung.Size = new Size(220, 23);

            // btnLuuTam
            btnLuuTam.Text = "Lưu tạm";
            btnLuuTam.Location = new Point(120, 125);
            btnLuuTam.Size = new Size(100, 30);
            btnLuuTam.Click += btnLuuTam_Click;

            // lstBenhNhan
            lstBenhNhan.Location = new Point(15, 170);
            lstBenhNhan.Size = new Size(360, 160);
            lstBenhNhan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // frmPatient
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(390, 350);
            Controls.Add(lblHoTen);
            Controls.Add(txtHoTen);
            Controls.Add(lblTuoi);
            Controls.Add(numTuoi);
            Controls.Add(lblTrieuChung);
            Controls.Add(txtTrieuChung);
            Controls.Add(btnLuuTam);
            Controls.Add(lstBenhNhan);
            Text = "Thông tin bệnh nhân";
        }
    }
}