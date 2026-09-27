namespace QuanLyPhongKham
{
    partial class frmLichHen
    {
        private System.ComponentModel.IContainer components = null!;

        private Label lblNgayGio = null!;
        private DateTimePicker dtpNgayGio = null!;
        private Label lblTenBenhNhan = null!;
        private TextBox txtTenBenhNhan = null!;
        private Button btnDatLich = null!;
        private ListBox lstLichHen = null!;

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

            lblNgayGio = new Label();
            dtpNgayGio = new DateTimePicker();
            lblTenBenhNhan = new Label();
            txtTenBenhNhan = new TextBox();
            btnDatLich = new Button();
            lstLichHen = new ListBox();

            // lblNgayGio
            lblNgayGio.Text = "Ngày giờ hẹn:";
            lblNgayGio.Location = new Point(15, 20);
            lblNgayGio.AutoSize = true;

            // dtpNgayGio
            dtpNgayGio.Location = new Point(130, 17);
            dtpNgayGio.Size = new Size(220, 23);
            dtpNgayGio.Format = DateTimePickerFormat.Custom;
            dtpNgayGio.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpNgayGio.ShowUpDown = true;

            // lblTenBenhNhan
            lblTenBenhNhan.Text = "Tên bệnh nhân:";
            lblTenBenhNhan.Location = new Point(15, 55);
            lblTenBenhNhan.AutoSize = true;

            // txtTenBenhNhan
            txtTenBenhNhan.Location = new Point(130, 52);
            txtTenBenhNhan.Size = new Size(220, 23);

            // btnDatLich
            btnDatLich.Text = "Đặt lịch";
            btnDatLich.Location = new Point(130, 90);
            btnDatLich.Size = new Size(100, 30);
            btnDatLich.Click += btnDatLich_Click;

            // lstLichHen
            lstLichHen.Location = new Point(15, 135);
            lstLichHen.Size = new Size(370, 160);
            lstLichHen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // frmLichHen
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 320);
            Controls.Add(lblNgayGio);
            Controls.Add(dtpNgayGio);
            Controls.Add(lblTenBenhNhan);
            Controls.Add(txtTenBenhNhan);
            Controls.Add(btnDatLich);
            Controls.Add(lstLichHen);
            Text = "Đặt lịch hẹn";
        }
    }
}