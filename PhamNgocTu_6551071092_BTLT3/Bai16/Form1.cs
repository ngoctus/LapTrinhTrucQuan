namespace Bai16
{
    public partial class stepByStep2_18 : Form
    {
        private stepByStep2_19 form19;
        public stepByStep2_18()
        {
            InitializeComponent();

            

            form19 = new stepByStep2_19();

            textBox1.ContextMenuStrip = form19.MyContextMenu;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
