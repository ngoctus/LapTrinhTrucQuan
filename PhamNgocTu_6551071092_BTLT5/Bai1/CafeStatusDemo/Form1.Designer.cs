namespace CafeStatusDemo
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
            menuStrip1 = new MenuStrip();
            mnuHeThong = new ToolStripMenuItem();
            mnuDoiMauNen = new ToolStripMenuItem();
            mnuThoat = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblGioHienTai = new ToolStripStatusLabel();
            lblTenQuan = new ToolStripStatusLabel();
            lblTrangThai = new ToolStripStatusLabel();
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            //
            // menuStrip1
            //
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuHeThong });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(600, 24);
            menuStrip1.TabIndex = 0;
            //
            // mnuHeThong
            //
            mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { mnuDoiMauNen, mnuThoat });
            mnuHeThong.Name = "mnuHeThong";
            mnuHeThong.Text = "Hệ thống";
            //
            // mnuDoiMauNen
            //
            mnuDoiMauNen.Name = "mnuDoiMauNen";
            mnuDoiMauNen.Text = "Đổi màu nền";
            mnuDoiMauNen.Click += mnuDoiMauNen_Click;
            //
            // mnuThoat
            //
            mnuThoat.Name = "mnuThoat";
            mnuThoat.Text = "Thoát";
            mnuThoat.Click += mnuThoat_Click;
            //
            // statusStrip1
            //
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblGioHienTai, lblTenQuan, lblTrangThai });
            statusStrip1.Location = new Point(0, 278);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(600, 22);
            statusStrip1.TabIndex = 1;
            //
            // lblGioHienTai (căn trái)
            //
            lblGioHienTai.Name = "lblGioHienTai";
            lblGioHienTai.TextAlign = ContentAlignment.MiddleLeft;
            lblGioHienTai.Text = "00:00:00";
            //
            // lblTenQuan (Spring = true -> tự giãn, nằm giữa)
            //
            lblTenQuan.Name = "lblTenQuan";
            lblTenQuan.Spring = true;
            lblTenQuan.Text = "CAFE ÁNH DƯƠNG";
            lblTenQuan.TextAlign = ContentAlignment.MiddleCenter;
            lblTenQuan.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            //
            // lblTrangThai (căn phải)
            //
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.TextAlign = ContentAlignment.MiddleRight;
            lblTrangThai.Text = "Trạng thái";
            //
            // timer1
            //
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            //
            // Form1
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 300);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cafe Ánh Dương - Màn hình quầy lễ tân";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuDoiMauNen;
        private ToolStripMenuItem mnuThoat;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblGioHienTai;
        private ToolStripStatusLabel lblTenQuan;
        private ToolStripStatusLabel lblTrangThai;
        private System.Windows.Forms.Timer timer1;
    }
}