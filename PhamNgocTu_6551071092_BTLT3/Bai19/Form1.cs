namespace Bai19
{
    public partial class StepByStep2_21 : Form
    {
        public StepByStep2_21()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToLongDateString();
            toolStripStatusLabel3.Text = DateTime.Now.ToShortTimeString();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void pasteToolStripButton1_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void goBackToolStripButton_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }
    }
}
