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
        public string  userIDx;
        public console(String loginAs, String userID)
        {
            InitializeComponent();
            lbl_login.Text = loginAs.ToUpper();
            userIDx = userID;
        }

        private void console_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void newProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userIDd = userIDx;
            addProducts nuPdtWind = new addProducts(lbl_login.Text, userIDx);
            nuPdtWind.MdiParent = this;
            nuPdtWind.Show();
        }

        private void mnu_unitMeasures_Click(object sender, EventArgs e)
        {
            unitMeasures unitWindow = new unitMeasures();
            unitWindow.MdiParent = this;
            unitWindow.Show();
        }

        private void mnu_users_Click(object sender, EventArgs e)
        {
            userManagement userWindow = new userManagement();
            userWindow.MdiParent = this;
            userWindow.Show();
        }
    }
}
