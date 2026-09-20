using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bai16
{
    public partial class stepByStep2_19 : Form
    {
        public ContextMenuStrip MyContextMenu
        {
            get { return contextMenuStrip1; }
        }

        public stepByStep2_19()
        {
            InitializeComponent();

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contextMenuStrip1.SourceControl is TextBoxBase textBox)
            {
                textBox.Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contextMenuStrip1.SourceControl is TextBoxBase textBox)
            {
                textBox.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (contextMenuStrip1.SourceControl is TextBoxBase textBox)
            {
                textBox.Paste();
            }
        }
    }
}
