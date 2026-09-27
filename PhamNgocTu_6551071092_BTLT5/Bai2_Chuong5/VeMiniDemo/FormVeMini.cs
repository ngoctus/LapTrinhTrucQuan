namespace VeMiniDemo
{
    public partial class FormVeMini : Form
    {
        private Bitmap _bitmap = null!;
        private bool _dangVe = false;
        private Point _diemTruoc;

        public FormVeMini()
        {
            InitializeComponent();
            TaoBitmapMoi(pnlCanvas.Width, pnlCanvas.Height);
            pnlCanvas.Resize += pnlCanvas_Resize;
        }

        private void TaoBitmapMoi(int w, int h)
        {
            if (w <= 0) w = 1;
            if (h <= 0) h = 1;

            var bmpMoi = new Bitmap(w, h);
            using (var g = Graphics.FromImage(bmpMoi))
            {
                g.Clear(Color.White);
                if (_bitmap != null)
                {
                    g.DrawImage(_bitmap, Point.Empty);
                }
            }

            _bitmap?.Dispose();
            _bitmap = bmpMoi;
        }

        private void pnlCanvas_Resize(object? sender, EventArgs e)
        {
            TaoBitmapMoi(pnlCanvas.Width, pnlCanvas.Height);
            pnlCanvas.Invalidate();
        }

        private void pnlCanvas_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(_bitmap, Point.Empty);
        }

        private void pnlCanvas_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _dangVe = true;
                _diemTruoc = e.Location;
                lblViTri.Text = $"Đang vẽ... X: {e.X}, Y: {e.Y}";
            }
        }

        private void pnlCanvas_MouseMove(object? sender, MouseEventArgs e)
        {
            if (_dangVe && e.Button == MouseButtons.Left)
            {
                using (var g = Graphics.FromImage(_bitmap))
                using (var pen = new Pen(Color.Black, 2f))
                {
                    pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                    pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                    g.DrawLine(pen, _diemTruoc, e.Location);
                }

                _diemTruoc = e.Location;
                pnlCanvas.Invalidate();

                lblViTri.Text = $"Đang vẽ... X: {e.X}, Y: {e.Y}";
            }
            else
            {
                lblViTri.Text = $"Sẵn sàng - X: {e.X}, Y: {e.Y}";
            }
        }

        private void pnlCanvas_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _dangVe = false;
                lblViTri.Text = $"Sẵn sàng - X: {e.X}, Y: {e.Y}";
            }
        }

        private void pnlCanvas_MouseClick(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                using (var g = Graphics.FromImage(_bitmap))
                {
                    g.Clear(Color.White);
                }
                pnlCanvas.Invalidate();
            }
        }
    }
}