namespace VeMiniDemo
{
    partial class FormVeMini
    {
        private System.ComponentModel.IContainer components = null!;

        private Panel pnlCanvas = null!;
        private Label lblViTri = null!;

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

            pnlCanvas = new Panel();
            lblViTri = new Label();

            // lblViTri
            lblViTri.Text = "Sẵn sàng";
            lblViTri.Location = new Point(15, 10);
            lblViTri.AutoSize = true;
            lblViTri.Font = new Font(lblViTri.Font.FontFamily, 10F);

            // pnlCanvas
            pnlCanvas.BackColor = Color.White;
            pnlCanvas.Location = new Point(15, 40);
            pnlCanvas.Size = new Size(600, 400);
            pnlCanvas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlCanvas.BorderStyle = BorderStyle.FixedSingle;
            pnlCanvas.Paint += pnlCanvas_Paint;
            pnlCanvas.MouseDown += pnlCanvas_MouseDown;
            pnlCanvas.MouseMove += pnlCanvas_MouseMove;
            pnlCanvas.MouseUp += pnlCanvas_MouseUp;
            pnlCanvas.MouseClick += pnlCanvas_MouseClick;

            // FormVeMini
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 460);
            Controls.Add(lblViTri);
            Controls.Add(pnlCanvas);
            Text = "Bảng vẽ mini";
        }
    }
}