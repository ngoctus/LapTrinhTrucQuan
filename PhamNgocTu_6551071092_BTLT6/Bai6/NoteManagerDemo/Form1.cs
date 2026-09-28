namespace NoteManagerDemo
{
    public partial class FormChinh : Form
    {
        public FormChinh()
        {
            InitializeComponent();

            mnuMoGhiChuMoi.Click += mnuMoGhiChuMoi_Click;
            mnuSapXepCuaSo.Click += mnuXepTang_Click;   // "Sắp xếp cửa sổ" = xếp tầng
            mnuThoat.Click += mnuThoat_Click;
            mnuXepTang.Click += mnuXepTang_Click;
            mnuXepNgang.Click += mnuXepNgang_Click;
            mnuXepDoc.Click += mnuXepDoc_Click;

            CapNhatStatus();
        }

        private void mnuMoGhiChuMoi_Click(object? sender, EventArgs e)
        {
            var frm = new FormGhiChu();
            frm.MdiParent = this;
            // Sau khi form đóng xong mới đếm lại, để MdiChildren.Length chính xác
            frm.FormClosed += (s, args) => BeginInvoke(CapNhatStatus);
            frm.Show(); // MDI Child: dùng Show(), không dùng ShowDialog()
            CapNhatStatus();
        }

        private void mnuXepTang_Click(object? sender, EventArgs e) => LayoutMdi(MdiLayout.Cascade);
        private void mnuXepNgang_Click(object? sender, EventArgs e) => LayoutMdi(MdiLayout.TileHorizontal);
        private void mnuXepDoc_Click(object? sender, EventArgs e) => LayoutMdi(MdiLayout.TileVertical);

        private void mnuThoat_Click(object? sender, EventArgs e) => Close();

        private void CapNhatStatus()
        {
            lblSoGhiChu.Text = $"Số ghi chú đang mở: {MdiChildren.Length}";
        }
    }
}