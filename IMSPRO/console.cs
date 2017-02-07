using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMSPRO
{
    public partial class console : Form
    {
        private int childFormNumber = 0;

        public console()
        {
            InitializeComponent();
        }

        private void console_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void newProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addProducts nuPdtWind = new addProducts();
            nuPdtWind.MdiParent = this;
            nuPdtWind.Show();
        }
    }
}
