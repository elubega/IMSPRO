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
            //maximize winow without covering taskbar
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.WindowState = FormWindowState.Maximized;
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

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void branchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            branchManager brchWindow = new branchManager(userIDx);
            brchWindow.MdiParent = this;
            brchWindow.Show();
        }

        private void requestOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            orderRequest frmOrderRequest = new orderRequest();
            frmOrderRequest.MdiParent = this;
            frmOrderRequest.Show();
        }

        private void console_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "A")
            {
               
                orderRequest frmOrderRequest = new orderRequest();
                frmOrderRequest.MdiParent = this;
               frmOrderRequest.Show();
            }
            if(e.KeyCode == Keys.F7)
            {
                openViewOrdersFrm();
            }
        }

        private void viewOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openViewOrdersFrm();
        }

        //Opens the View Orders Form
        void openViewOrdersFrm()
        {
            viewOrders frmViewOrders = new viewOrders();
            frmViewOrders.MdiParent = this;
            frmViewOrders.Show();
        }
    }
}
