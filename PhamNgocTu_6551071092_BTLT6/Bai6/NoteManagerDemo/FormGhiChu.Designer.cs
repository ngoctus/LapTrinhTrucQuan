namespace NoteManagerDemo
{
    partial class FormGhiChu
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
            lblTieuDe = new Label();
            txtTieuDe = new TextBox();
            lblNoiDung = new Label();
            txtNoiDung = new TextBox();
            lblDem = new Label();
            lblMucDo = new Label();
            cboMucDoUuTien = new ComboBox();
            btnLuuGhiChu = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Location = new Point(15, 14);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(58, 20);
            lblTieuDe.TabIndex = 8;
            lblTieuDe.Text = "Tiêu đề";
            // 
            // txtTieuDe
            // 
            txtTieuDe.Location = new Point(15, 37);
            txtTieuDe.Name = "txtTieuDe";
            txtTieuDe.Size = new Size(460, 27);
            txtTieuDe.TabIndex = 1;
            // 
            // lblNoiDung
            // 
            lblNoiDung.AutoSize = true;
            lblNoiDung.Location = new Point(15, 77);
            lblNoiDung.Name = "lblNoiDung";
            lblNoiDung.Size = new Size(71, 20);
            lblNoiDung.TabIndex = 7;
            lblNoiDung.Text = "Nội dung";
            // 
            // txtNoiDung
            // 
            txtNoiDung.Location = new Point(15, 100);
            txtNoiDung.MaxLength = 500;
            txtNoiDung.Multiline = true;
            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.ScrollBars = ScrollBars.Vertical;
            txtNoiDung.Size = new Size(460, 150);
            txtNoiDung.TabIndex = 2;
            // 
            // lblDem
            // 
            lblDem.AutoSize = true;
            lblDem.Location = new Point(15, 255);
            lblDem.Name = "lblDem";
            lblDem.Size = new Size(55, 20);
            lblDem.TabIndex = 6;
            lblDem.Text = "0 / 500";
            // 
            // lblMucDo
            // 
            lblMucDo.AutoSize = true;
            lblMucDo.Location = new Point(15, 290);
            lblMucDo.Name = "lblMucDo";
            lblMucDo.Size = new Size(88, 20);
            lblMucDo.TabIndex = 5;
            lblMucDo.Text = "Mức ưu tiên";
            // 
            // cboMucDoUuTien
            // 
            cboMucDoUuTien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMucDoUuTien.FormattingEnabled = true;
            cboMucDoUuTien.Items.AddRange(new object[] { "Thấp", "Trung bình", "Cao" });
            cboMucDoUuTien.Location = new Point(15, 313);
            cboMucDoUuTien.Name = "cboMucDoUuTien";
            cboMucDoUuTien.Size = new Size(200, 28);
            cboMucDoUuTien.TabIndex = 3;
            // 
            // btnLuuGhiChu
            // 
            btnLuuGhiChu.Location = new Point(315, 307);
            btnLuuGhiChu.Name = "btnLuuGhiChu";
            btnLuuGhiChu.Size = new Size(160, 38);
            btnLuuGhiChu.TabIndex = 4;
            btnLuuGhiChu.Text = "Lưu (Ctrl+S)";
            btnLuuGhiChu.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FormGhiChu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(494, 363);
            Controls.Add(btnLuuGhiChu);
            Controls.Add(cboMucDoUuTien);
            Controls.Add(lblMucDo);
            Controls.Add(lblDem);
            Controls.Add(txtNoiDung);
            Controls.Add(lblNoiDung);
            Controls.Add(txtTieuDe);
            Controls.Add(lblTieuDe);
            KeyPreview = true;
            Name = "FormGhiChu";
            Text = "Ghi chú mới";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblTieuDe;
        private TextBox txtTieuDe;
        private Label lblNoiDung;
        private TextBox txtNoiDung;
        private Label lblDem;
        private Label lblMucDo;
        private ComboBox cboMucDoUuTien;
        private Button btnLuuGhiChu;
        private ErrorProvider errorProvider1;
    }
}