#nullable disable
namespace TodoListDemo
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
            cmsCongViec = new ContextMenuStrip(components);
            mnuHoanThanh = new ToolStripMenuItem();
            mnuXoaMot = new ToolStripMenuItem();
            mnuXoaTatCa = new ToolStripMenuItem();
            txtCongViecMoi = new TextBox();
            btnThem = new Button();
            lstCongViec = new ListBox();
            cmsCongViec.SuspendLayout();
            SuspendLayout();
            //
            // cmsCongViec
            //
            cmsCongViec.Items.AddRange(new ToolStripItem[] { mnuHoanThanh, mnuXoaMot, mnuXoaTatCa });
            cmsCongViec.Name = "cmsCongViec";
            //
            // mnuHoanThanh
            //
            mnuHoanThanh.Name = "mnuHoanThanh";
            mnuHoanThanh.Text = "Đánh dấu hoàn thành";
            mnuHoanThanh.Click += mnuHoanThanh_Click;
            //
            // mnuXoaMot
            //
            mnuXoaMot.Name = "mnuXoaMot";
            mnuXoaMot.Text = "Xóa công việc này";
            mnuXoaMot.Click += mnuXoaMot_Click;
            //
            // mnuXoaTatCa
            //
            mnuXoaTatCa.Name = "mnuXoaTatCa";
            mnuXoaTatCa.Text = "Xóa tất cả";
            mnuXoaTatCa.Click += mnuXoaTatCa_Click;
            //
            // txtCongViecMoi
            //
            txtCongViecMoi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCongViecMoi.Location = new Point(12, 13);
            txtCongViecMoi.Name = "txtCongViecMoi";
            txtCongViecMoi.PlaceholderText = "Nhập công việc cần làm...";
            txtCongViecMoi.Size = new Size(320, 23);
            txtCongViecMoi.TabIndex = 0;
            //
            // btnThem
            //
            btnThem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnThem.Location = new Point(340, 12);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(85, 25);
            btnThem.TabIndex = 1;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            //
            // lstCongViec
            //
            lstCongViec.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstCongViec.ContextMenuStrip = cmsCongViec;
            lstCongViec.FormattingEnabled = true;
            lstCongViec.ItemHeight = 15;
            lstCongViec.Location = new Point(12, 50);
            lstCongViec.Name = "lstCongViec";
            lstCongViec.Size = new Size(413, 394);
            lstCongViec.TabIndex = 2;
            lstCongViec.MouseDown += lstCongViec_MouseDown;
            //
            // Form1
            //
            AcceptButton = btnThem;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 461);
            Controls.Add(lstCongViec);
            Controls.Add(btnThem);
            Controls.Add(txtCongViecMoi);
            MinimumSize = new Size(300, 300);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh sách việc cần làm hằng ngày";
            cmsCongViec.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip cmsCongViec;
        private ToolStripMenuItem mnuHoanThanh;
        private ToolStripMenuItem mnuXoaMot;
        private ToolStripMenuItem mnuXoaTatCa;
        private TextBox txtCongViecMoi;
        private Button btnThem;
        private ListBox lstCongViec;
    }
}