namespace NoteManagerDemo
{
    partial class FormChinh
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
            menuStrip1 = new MenuStrip();
            mnuTep = new ToolStripMenuItem();
            mnuMoGhiChuMoi = new ToolStripMenuItem();
            mnuSapXepCuaSo = new ToolStripMenuItem();
            mnuThoat = new ToolStripMenuItem();
            mnuCuaSo = new ToolStripMenuItem();
            mnuXepTang = new ToolStripMenuItem();
            mnuXepNgang = new ToolStripMenuItem();
            mnuXepDoc = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblSoGhiChu = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuTep, mnuCuaSo });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(900, 28);
            menuStrip1.TabIndex = 0;
            // 
            // mnuTep
            // 
            mnuTep.DropDownItems.AddRange(new ToolStripItem[] { mnuMoGhiChuMoi, mnuSapXepCuaSo, mnuThoat });
            mnuTep.Name = "mnuTep";
            mnuTep.Size = new Size(46, 24);
            mnuTep.Text = "Tệp";
            // 
            // mnuMoGhiChuMoi
            // 
            mnuMoGhiChuMoi.Name = "mnuMoGhiChuMoi";
            mnuMoGhiChuMoi.Size = new Size(224, 26);
            mnuMoGhiChuMoi.Text = "Mở ghi chú mới";
            // 
            // mnuSapXepCuaSo
            // 
            mnuSapXepCuaSo.Name = "mnuSapXepCuaSo";
            mnuSapXepCuaSo.Size = new Size(224, 26);
            mnuSapXepCuaSo.Text = "Sắp xếp cửa sổ";
            // 
            // mnuThoat
            // 
            mnuThoat.Name = "mnuThoat";
            mnuThoat.Size = new Size(224, 26);
            mnuThoat.Text = "Thoát";
            // 
            // mnuCuaSo
            // 
            mnuCuaSo.DropDownItems.AddRange(new ToolStripItem[] { mnuXepTang, mnuXepNgang, mnuXepDoc });
            mnuCuaSo.Name = "mnuCuaSo";
            mnuCuaSo.Size = new Size(72, 24);
            mnuCuaSo.Text = "Cửa sổ";
            // 
            // mnuXepTang
            // 
            mnuXepTang.Name = "mnuXepTang";
            mnuXepTang.Size = new Size(224, 26);
            mnuXepTang.Text = "Xếp tầng";
            // 
            // mnuXepNgang
            // 
            mnuXepNgang.Name = "mnuXepNgang";
            mnuXepNgang.Size = new Size(224, 26);
            mnuXepNgang.Text = "Xếp ngang";
            // 
            // mnuXepDoc
            // 
            mnuXepDoc.Name = "mnuXepDoc";
            mnuXepDoc.Size = new Size(224, 26);
            mnuXepDoc.Text = "Xếp dọc";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblSoGhiChu });
            statusStrip1.Location = new Point(0, 574);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(900, 26);
            statusStrip1.TabIndex = 1;
            // 
            // lblSoGhiChu
            // 
            lblSoGhiChu.Name = "lblSoGhiChu";
            lblSoGhiChu.Size = new Size(170, 20);
            lblSoGhiChu.Text = "Số ghi chú đang mở: 0";
            // 
            // FormChinh
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FormChinh";
            Text = "Quản lý ghi chú công việc";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuTep;
        private ToolStripMenuItem mnuMoGhiChuMoi;
        private ToolStripMenuItem mnuSapXepCuaSo;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem mnuCuaSo;
        private ToolStripMenuItem mnuXepTang;
        private ToolStripMenuItem mnuXepNgang;
        private ToolStripMenuItem mnuXepDoc;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblSoGhiChu;
    }
}