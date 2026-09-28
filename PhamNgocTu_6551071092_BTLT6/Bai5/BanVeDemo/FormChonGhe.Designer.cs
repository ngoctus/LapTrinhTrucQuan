namespace BanVeDemo
{
    partial class FormChonGhe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstGhe = new ListBox();
            lblGheDaChon = new Label();
            btnXacNhan = new Button();
            btnBoQua = new Button();
            SuspendLayout();
            // 
            // lstGhe
            // 
            lstGhe.FormattingEnabled = true;
            lstGhe.Location = new Point(46, 59);
            lstGhe.Name = "lstGhe";
            lstGhe.Size = new Size(400, 224);
            lstGhe.TabIndex = 0;
            // 
            // lblGheDaChon
            // 
            lblGheDaChon.AutoSize = true;
            lblGheDaChon.Location = new Point(46, 295);
            lblGheDaChon.Name = "lblGheDaChon";
            lblGheDaChon.Size = new Size(88, 20);
            lblGheDaChon.TabIndex = 1;
            lblGheDaChon.Text = "Đang chọn: ";
            // 
            // btnXacNhan
            // 
            btnXacNhan.Location = new Point(46, 334);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(186, 26);
            btnXacNhan.TabIndex = 2;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.UseVisualStyleBackColor = true;
            // 
            // btnBoQua
            // 
            btnBoQua.Location = new Point(260, 334);
            btnBoQua.Name = "btnBoQua";
            btnBoQua.Size = new Size(186, 26);
            btnBoQua.TabIndex = 3;
            btnBoQua.Text = "Bỏ qua";
            btnBoQua.UseVisualStyleBackColor = true;
            // 
            // FormChonGhe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 386);
            Controls.Add(btnBoQua);
            Controls.Add(btnXacNhan);
            Controls.Add(lblGheDaChon);
            Controls.Add(lstGhe);
            Name = "FormChonGhe";
            Text = "FormChonGhe";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstGhe;
        private Label lblGheDaChon;
        private Button btnXacNhan;
        private Button btnBoQua;
    }
}