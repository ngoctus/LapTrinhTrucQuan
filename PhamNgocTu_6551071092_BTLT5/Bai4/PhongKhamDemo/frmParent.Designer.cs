namespace QuanLyPhongKham
{
    partial class frmParent
    {
        private System.ComponentModel.IContainer components = null!;

        private MenuStrip menuStrip1 = null!;
        private ToolStripMenuItem mnuNghiepVu = null!;
        private ToolStripMenuItem mnuThongTinBenhNhan = null!;
        private ToolStripMenuItem mnuDatLichHen = null!;
        private ToolStripMenuItem mnuCuaSo = null!;

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

            menuStrip1 = new MenuStrip();
            mnuNghiepVu = new ToolStripMenuItem();
            mnuThongTinBenhNhan = new ToolStripMenuItem();
            mnuDatLichHen = new ToolStripMenuItem();
            mnuCuaSo = new ToolStripMenuItem();

            // mnuThongTinBenhNhan
            mnuThongTinBenhNhan.Text = "Thông tin bệnh nhân";
            mnuThongTinBenhNhan.Click += mnuThongTinBenhNhan_Click;

            // mnuDatLichHen
            mnuDatLichHen.Text = "Đặt lịch hẹn";
            mnuDatLichHen.Click += mnuDatLichHen_Click;

            // mnuNghiepVu
            mnuNghiepVu.Text = "Nghiệp vụ";
            mnuNghiepVu.DropDownItems.AddRange(new ToolStripItem[]
            {
                mnuThongTinBenhNhan,
                mnuDatLichHen
            });

            // mnuCuaSo (rỗng - sẽ được MenuStrip tự động điền danh sách cửa sổ con)
            mnuCuaSo.Text = "Cửa sổ";

            // menuStrip1
            menuStrip1.Items.AddRange(new ToolStripItem[]
            {
                mnuNghiepVu,
                mnuCuaSo
            });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(900, 24);
            menuStrip1.MdiWindowListItem = mnuCuaSo;

            // frmParent
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 550);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Controls.Add(menuStrip1);
            Text = "Phần mềm quản lý phòng khám mini";
            WindowState = FormWindowState.Maximized;
        }
    }
}