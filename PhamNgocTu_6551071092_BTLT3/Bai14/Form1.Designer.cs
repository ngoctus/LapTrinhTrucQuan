namespace Bai14
{
    partial class formUpdateListBox2
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
            lstLopA = new ListBox();
            lstLopB = new ListBox();
            lblHoTen = new Label();
            txtTen = new TextBox();
            btnUpdate = new Button();
            btnNextItem = new Button();
            menuStrip1 = new MenuStrip();
            cậpNhậtToolStripMenuItem = new ToolStripMenuItem();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            btnNextLstBox = new Button();
            btnLastItem = new Button();
            btnLastLstBox = new Button();
            btnDeleteA = new Button();
            btnClose = new Button();
            btnDeleteB = new Button();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lstLopA
            // 
            lstLopA.FormattingEnabled = true;
            lstLopA.Location = new Point(131, 122);
            lstLopA.Name = "lstLopA";
            lstLopA.SelectionMode = SelectionMode.MultiExtended;
            lstLopA.Size = new Size(264, 244);
            lstLopA.TabIndex = 2;
            // 
            // lstLopB
            // 
            lstLopB.FormattingEnabled = true;
            lstLopB.Location = new Point(507, 122);
            lstLopB.Name = "lstLopB";
            lstLopB.SelectionMode = SelectionMode.MultiExtended;
            lstLopB.Size = new Size(264, 244);
            lstLopB.TabIndex = 7;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHoTen.Location = new Point(131, 63);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(60, 20);
            lblHoTen.TabIndex = 2;
            lblHoTen.Text = "Tên SV:";
            // 
            // txtTen
            // 
            txtTen.Location = new Point(197, 56);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(490, 27);
            txtTen.TabIndex = 0;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.Location = new Point(693, 56);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(78, 27);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnNextItem
            // 
            btnNextItem.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnNextItem.Location = new Point(414, 122);
            btnNextItem.Name = "btnNextItem";
            btnNextItem.Size = new Size(72, 47);
            btnNextItem.TabIndex = 3;
            btnNextItem.Text = ">";
            btnNextItem.UseVisualStyleBackColor = true;
            btnNextItem.Click += btnNextItem_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(255, 192, 192);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { cậpNhậtToolStripMenuItem, hệThốngToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(887, 28);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // cậpNhậtToolStripMenuItem
            // 
            cậpNhậtToolStripMenuItem.Name = "cậpNhậtToolStripMenuItem";
            cậpNhậtToolStripMenuItem.Size = new Size(82, 24);
            cậpNhậtToolStripMenuItem.Text = "Cập nhật";
            // 
            // hệThốngToolStripMenuItem
            // 
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(85, 24);
            hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = Color.FromArgb(255, 192, 192);
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2 });
            statusStrip1.Location = new Point(0, 489);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(887, 26);
            statusStrip1.TabIndex = 12;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(151, 20);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new Size(179, 20);
            toolStripStatusLabel2.Text = "Design by: Phạm Ngọc Tú";
            // 
            // btnNextLstBox
            // 
            btnNextLstBox.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnNextLstBox.Location = new Point(414, 185);
            btnNextLstBox.Name = "btnNextLstBox";
            btnNextLstBox.Size = new Size(72, 47);
            btnNextLstBox.TabIndex = 4;
            btnNextLstBox.Text = ">>";
            btnNextLstBox.UseVisualStyleBackColor = true;
            btnNextLstBox.Click += btnNextLstBox_Click;
            // 
            // btnLastItem
            // 
            btnLastItem.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnLastItem.Location = new Point(414, 250);
            btnLastItem.Name = "btnLastItem";
            btnLastItem.Size = new Size(72, 47);
            btnLastItem.TabIndex = 5;
            btnLastItem.Text = "<";
            btnLastItem.UseVisualStyleBackColor = true;
            btnLastItem.Click += btnLastItem_Click;
            // 
            // btnLastLstBox
            // 
            btnLastLstBox.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            btnLastLstBox.Location = new Point(414, 319);
            btnLastLstBox.Name = "btnLastLstBox";
            btnLastLstBox.Size = new Size(72, 47);
            btnLastLstBox.TabIndex = 6;
            btnLastLstBox.Text = "<<";
            btnLastLstBox.UseVisualStyleBackColor = true;
            btnLastLstBox.Click += btnLastLstBox_Click;
            // 
            // btnDeleteA
            // 
            btnDeleteA.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDeleteA.Location = new Point(131, 407);
            btnDeleteA.Name = "btnDeleteA";
            btnDeleteA.Size = new Size(173, 47);
            btnDeleteA.TabIndex = 8;
            btnDeleteA.Text = "Xóa Lớp A";
            btnDeleteA.UseVisualStyleBackColor = true;
            btnDeleteA.Click += btnDeleteA_Click;
            // 
            // btnClose
            // 
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClose.Location = new Point(364, 407);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(173, 47);
            btnClose.TabIndex = 9;
            btnClose.Text = "Kết thúc";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnDeleteB
            // 
            btnDeleteB.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDeleteB.Location = new Point(598, 407);
            btnDeleteB.Name = "btnDeleteB";
            btnDeleteB.Size = new Size(173, 47);
            btnDeleteB.TabIndex = 10;
            btnDeleteB.Text = "Xóa Lớp B";
            btnDeleteB.UseVisualStyleBackColor = true;
            btnDeleteB.Click += btnDeleteB_Click;
            // 
            // formUpdateListBox2
            // 
            AcceptButton = btnUpdate;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(887, 515);
            Controls.Add(btnDeleteB);
            Controls.Add(btnClose);
            Controls.Add(btnDeleteA);
            Controls.Add(btnLastLstBox);
            Controls.Add(btnLastItem);
            Controls.Add(btnNextLstBox);
            Controls.Add(statusStrip1);
            Controls.Add(btnNextItem);
            Controls.Add(btnUpdate);
            Controls.Add(txtTen);
            Controls.Add(lblHoTen);
            Controls.Add(lstLopB);
            Controls.Add(lstLopA);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "formUpdateListBox2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form Cập Nhật Listbox 2";
            Load += formUpdateListBox2_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstLopA;
        private ListBox lstLopB;
        private Label lblHoTen;
        private TextBox txtTen;
        private Button btnUpdate;
        private Button btnNextItem;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem cậpNhậtToolStripMenuItem;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button btnNextLstBox;
        private Button btnLastItem;
        private Button btnLastLstBox;
        private Button btnDeleteA;
        private Button btnClose;
        private Button btnDeleteB;
        private ToolStripStatusLabel toolStripStatusLabel2;
    }
}
