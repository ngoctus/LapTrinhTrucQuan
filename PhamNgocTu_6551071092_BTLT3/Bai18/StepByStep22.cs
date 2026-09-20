namespace Bai18
{
    public partial class StepByStep22 : Form
    {
        public StepByStep22()
        {
            InitializeComponent();
        }

        private void tileHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void newDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stepByStep2_23 formCon = new stepByStep2_23();

            formCon.MdiParent = this;

            formCon.Show();
        }

    }
}
