using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace IMSPRO
{
    public partial class viewOrders : Form
    {
        public string loggedUsername;
        public viewOrders(string userLoggedIn)
        {
            InitializeComponent();
            LoadData();
            loggedUsername = userLoggedIn;
            LoadCompletedOrders();
        }

        //decearing variables for the connection
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        private void SetConnection()
        {
            sql_con = new SQLiteConnection
                ("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
        }
        private void btn_searchOrders_Click(object sender, EventArgs e)
        {
            searchOrderNumber();
            txt_searchOrder.Clear();
            txt_searchOrder.Focus();

        }
        public void LoadData()
        {
            //dispalays a list of products
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select DISTINCT orderID, dateOrdered, orderNo, branch.branchName As branch, users.firstName As firstName, users.lastName As lastName from orders  left Join branch  ON branch.branchID=orders.branchID left Join users  ON users.userID = orders.userID  where orders.processedOrderStatus = 0 group by orders.orderNo order by dateOrdered ASC";
            SQLiteDataAdapter pdtList = new SQLiteDataAdapter(CommandText, sql_con);
            DataTable ds = new DataTable();
            pdtList.Fill(ds);
            grdPendingOrders.Rows.Clear();
            grdPendingOrders.ColumnCount = 5;
            grdPendingOrders.ColumnHeadersVisible = true;

            grdPendingOrders.Columns[0].Name = "ID";
            grdPendingOrders.Columns[1].Name = "Ordered By";
            grdPendingOrders.Columns[2].Name = "Branch";
            grdPendingOrders.Columns[3].Name = "Order No.:";
            grdPendingOrders.Columns[4].Name = "Date Ordered";
            foreach (DataRow item in ds.Rows)
            {
                grdPendingOrders.Columns[0].Visible = false;
                int n = grdPendingOrders.Rows.Add();
                grdPendingOrders.Rows[n].Cells[0].Value = item["orderID"].ToString();
                string name = item["firstName"].ToString() + " " + item["lastName"].ToString();
                grdPendingOrders.Rows[n].Cells[1].Value = name;
                grdPendingOrders.Rows[n].Cells[2].Value = item["branch"].ToString();
                grdPendingOrders.Rows[n].Cells[3].Value = item["orderNo"].ToString();
                string dateOrdered = Convert.ToDateTime(item["dateOrdered"].ToString()).ToString("d");
                

                DateTime startDate = DateTime.Parse(dateOrdered);
                DateTime expiryDate = startDate.AddDays(1);
                if (DateTime.Now > expiryDate)
                {
                    grdPendingOrders.Rows[n].Cells[4].Value = dateOrdered;
                    grdPendingOrders.Rows[n].Cells[4]. Style.ForeColor = Color.Red;
                }
                else
                {
                    grdPendingOrders.Rows[n].Cells[4].Value = dateOrdered;
                }
                
            }
            sql_con.Close();
            this.grdPendingOrders.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            LoadData();
            txt_searchOrder.Clear();
            txt_searchOrder.Focus();
        }

        private void txt_searchOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                searchOrderNumber();
                txt_searchOrder.Clear();
                txt_searchOrder.Focus();
            }

        }

        void searchOrderNumber()
        {
            try
            {
                SetConnection();
                sql_con.Open();
                string CommandText = "select DISTINCT orderID, dateOrdered, orderNo, branch.branchName As branch, users.firstName As firstName, users.lastName As lastName from orders  left Join branch  ON branch.branchID=orders.branchID left Join users  ON users.userID = orders.userID  where orders.orderNo='" + txt_searchOrder.Text.Trim() + "' group by orders.orderNo order by dateOrdered ASC";
                SQLiteDataAdapter pdtLists = new SQLiteDataAdapter(CommandText, sql_con);
                DataTable ds = new DataTable();
                pdtLists.Fill(ds);
                grdPendingOrders.Rows.Clear();
                grdPendingOrders.ColumnCount = 5;
                grdPendingOrders.ColumnHeadersVisible = true;

                grdPendingOrders.Columns[0].Name = "ID";
                grdPendingOrders.Columns[1].Name = "Ordered By";
                grdPendingOrders.Columns[2].Name = "Branch";
                grdPendingOrders.Columns[3].Name = "Order No.:";
                grdPendingOrders.Columns[4].Name = "Date Ordered";

                if (ds.Rows.Count < 1)
                {
                    MessageBox.Show("There is no such Order", "Order No Recieved", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txt_searchOrder.Clear();
                    txt_searchOrder.Focus();
                }
                foreach (DataRow item in ds.Rows)
                {
                    grdPendingOrders.Columns[0].Visible = false;
                    int n = grdPendingOrders.Rows.Add();
                    grdPendingOrders.Rows[n].Cells[0].Value = item["orderID"].ToString();
                    string name = item["firstName"].ToString() + " " + item["lastName"].ToString();
                    grdPendingOrders.Rows[n].Cells[1].Value = name;
                    grdPendingOrders.Rows[n].Cells[2].Value = item["branch"].ToString();
                    grdPendingOrders.Rows[n].Cells[3].Value = item["orderNo"].ToString();
                    string dateOrdered = Convert.ToDateTime(item["dateOrdered"].ToString()).ToString("d");


                    DateTime startDate = DateTime.Parse(dateOrdered);
                    DateTime expiryDate = startDate.AddDays(1);
                    if (DateTime.Now > expiryDate)
                    {
                        grdPendingOrders.Rows[n].Cells[4].Value = dateOrdered;
                        grdPendingOrders.Rows[n].Cells[4].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        grdPendingOrders.Rows[n].Cells[4].Value = dateOrdered;
                    }

                }
                sql_con.Close();
                this.grdPendingOrders.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception a)
            {
                MessageBox.Show("Error..... Contact info@ingtep.com");
            }
        }

        private void grdPendingOrders_DoubleClick(object sender, EventArgs e)
        {
            string orderID = grdPendingOrders.SelectedRows[0].Cells[3].Value.ToString();
            workOnOrder workOrdersFrm = new workOnOrder(orderID,  this , loggedUsername);
            workOrdersFrm.MdiParent = this.MdiParent;
            workOrdersFrm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void LoadCompletedOrders()
        {
            //dispalays a list of products
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            //string CommandText = "select DISTINCT orderID, dateOrdered, orders.orderNo as orderNo, branch.branchName As branch, users.firstName As firstName, users.lastName As lastName,users.firstName as deliveredBy, users.firstName as processedBy from orders left Join branch ON branch.branchID = orders.branchID left Join users ON users.userID = orders.userID  left Join completedOrders on completedOrders.processedBy = orders.userID and completedOrders.deliveredBy = orders.userID where orders.processedOrderStatus = 1 group by orders.orderNo order by dateOrdered ASC";
            string CommandText = "select completedOrders.orderNo as 'orderNo', C.firstName as 'deliveredBy', B.firstName as 'processedBy', D.dateOrdered as dateOrdered, E.firstName as orderBy, branch.branchName as branch from completedOrders left join users as C on completedOrders.deliveredBy=C.userID left join users as B on completedOrders.processedBy=B.userID left Join orders as D on D.orderNo=completedOrders.OrderNo left join users as E on E.userID=D.userID left join branch on branch.branchID=D.branchID group by completedOrders.orderNo";
            SQLiteDataAdapter pdtList = new SQLiteDataAdapter(CommandText, sql_con);
            DataTable ds = new DataTable();
            pdtList.Fill(ds);
            grdCompletedOrders.Rows.Clear();
            grdCompletedOrders.ColumnCount = 7;
            grdCompletedOrders.ColumnHeadersVisible = true;

            grdCompletedOrders.Columns[0].Name = "ID";
            grdCompletedOrders.Columns[1].Name = "Order No.:";
            grdCompletedOrders.Columns[2].Name = "Ordered By";
            grdCompletedOrders.Columns[3].Name = "Branch";
            grdCompletedOrders.Columns[4].Name = "Date Ordered";
            grdCompletedOrders.Columns[5].Name = "Delivered By";
            grdCompletedOrders.Columns[6].Name = "Processed By";

            foreach (DataRow item in ds.Rows)
            {
                grdCompletedOrders.Columns[0].Visible = false;
                int n = grdCompletedOrders.Rows.Add();
                //grdCompletedOrders.Rows[n].Cells[0].Value = item["orderID"].ToString();
                grdCompletedOrders.Rows[n].Cells[1].Value = item["orderNo"].ToString();
                //string name = item["firstName"].ToString() + " " + item["lastName"].ToString();
                //grdCompletedOrders.Rows[n].Cells[2].Value = name;
                grdCompletedOrders.Rows[n].Cells[2].Value = item["orderBy"].ToString();
                grdCompletedOrders.Rows[n].Cells[3].Value = item["branch"].ToString();
                string dateOrdered = Convert.ToDateTime(item["dateOrdered"].ToString()).ToString("d");
                grdCompletedOrders.Rows[n].Cells[4].Value = dateOrdered;
                grdCompletedOrders.Rows[n].Cells[5].Value = item["deliveredBy"].ToString();
                grdCompletedOrders.Rows[n].Cells[6].Value = item["processedBy"].ToString();

            }
            sql_con.Close();
            this.grdPendingOrders.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void allOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (allOrders.SelectedIndex)
            {
                case 0:
                    {
                        LoadData();
                    }
                    break;
                case 1:
                    {
                       LoadCompletedOrders();
                    }
                    break;
            }
            
        }
    }
}
