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
            /*string CommandText = @"select DISTINCT orderID, dateOrdered, orderNo, branch.branchName As branch, users.firstName As firstName, users.lastName As lastName from orders"+
               $"left Join branch  ON branch.branchID=orders.branchID left Join users  ON users.userID = orders.userID  where orders.processedOrderStatus = 0 group by orders.orderNo order by dateOrdered ASC";*/
            string CommandText = @"select DISTINCT C.orderCustomerID AS orderID, C.orderNo AS orderNo, A.branchName AS branch,C.CustomerName AS CustomerName," +
                                 "C.CustomerPhone AS CustomerPhone,C.DateOrdered AS dateOrdered,B.firstName AS firstName, B.lastName AS lastName " +  
                                 $"from orderCustomers C left join branch A on A.branchID=C.BranchID left join users B on B.userID=C.OrderedBy left join orders D on D.orderNo=C.orderNo where D.processedOrderStatus=0 order by C.DateOrdered DESC";
            SQLiteDataAdapter pdtList = new SQLiteDataAdapter(CommandText, sql_con);
            DataTable ds = new DataTable();
            pdtList.Fill(ds);
            grdPendingOrders.Rows.Clear();
            grdPendingOrders.ColumnCount = 7;
            grdPendingOrders.ColumnHeadersVisible = true;

            grdPendingOrders.Columns[0].Name = "ID";
            grdPendingOrders.Columns[1].Name = "Order No";
            grdPendingOrders.Columns[2].Name = "Branch";
            grdPendingOrders.Columns[3].Name = "Customer Name";
            grdPendingOrders.Columns[4].Name = "Customer Phone";
            grdPendingOrders.Columns[5].Name = "Ordered By";
            grdPendingOrders.Columns[6].Name = "Date Ordered";


            foreach (DataRow item in ds.Rows)
            {
                grdPendingOrders.Columns[0].Visible = false;
                int n = grdPendingOrders.Rows.Add();
                grdPendingOrders.Rows[n].Cells[0].Value = item["orderID"].ToString();
                grdPendingOrders.Rows[n].Cells[1].Value = item["orderNo"].ToString();
                grdPendingOrders.Rows[n].Cells[2].Value = item["branch"].ToString();
                grdPendingOrders.Rows[n].Cells[3].Value = item["CustomerName"].ToString();
                grdPendingOrders.Rows[n].Cells[4].Value = item["CustomerPhone"].ToString();
                string name = item["firstName"].ToString() + " " + item["lastName"].ToString();
                grdPendingOrders.Rows[n].Cells[5].Value = name;
                string dateOrdered = Convert.ToDateTime(item["dateOrdered"].ToString()).ToString("d");
                grdPendingOrders.Rows[n].Cells[6].Value = dateOrdered;

                DateTime startDate = DateTime.Parse(dateOrdered);
                DateTime expiryDate = startDate.AddDays(1);
                if (DateTime.Now > expiryDate)
                {
                    grdPendingOrders.Rows[n].Cells[6].Value = dateOrdered;
                    grdPendingOrders.Rows[n].Cells[6]. Style.ForeColor = Color.Red;
                }
                else
                {
                    grdPendingOrders.Rows[n].Cells[6].Value = dateOrdered;
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
            string orderID = grdPendingOrders.SelectedRows[0].Cells[1].Value.ToString();
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
            string CommandText = @"Select DISTINCT A.completedOrdersID AS completedOrdersID, A.orderNo AS orderNo, A.deliveredBy AS 
                                    deliveredBy, A.processedBy As processedBy, A.processedOn AS processedOn, A.CustomerName AS 
                                    CustomerName, A.customerPhone AS customerPhone, C.firstName AS firstName, C.lastName As 
                                    lastName, F.firstName AS DeliveredfirstName, F.lastName As DeliveredlastName, F.firstName AS ProcessedfirstName, 
                                    F.lastName As ProcessedlastName, D.customerName As CustomerName, D.customerPhone AS CustomerPhone, E.branchName as branch, 
                                    D.DateOrdered AS dateOrdered from completedOrders A left join branch B on B.branchID=B.BranchID left join 
                                    users C on C.userID=A.processedBy left join orderCustomers D on D.orderNo=A.orderNo 
                                    left join branch E on E.branchID=D.BranchID left join users F on F.userID=A.deliveredBy 
                                    left join users G on G.userID=A.processedBy order by D.DateOrdered DESC";
            SQLiteDataAdapter pdtList = new SQLiteDataAdapter(CommandText, sql_con);
            DataTable ds = new DataTable();
            pdtList.Fill(ds);
            grdCompletedOrders.Rows.Clear();
            grdCompletedOrders.ColumnCount = 10;
            grdCompletedOrders.ColumnHeadersVisible = true;

            grdCompletedOrders.Columns[0].Name = "ID";
            grdCompletedOrders.Columns[1].Name = "Order No";
            grdCompletedOrders.Columns[2].Name = "Branch";
            grdCompletedOrders.Columns[3].Name = "Delivered By";
            grdCompletedOrders.Columns[4].Name = "Processed By";
            grdCompletedOrders.Columns[5].Name = "Processed On";
            grdCompletedOrders.Columns[6].Name = "Customer Name";
            grdCompletedOrders.Columns[7].Name = "Customer Phone";
            grdCompletedOrders.Columns[8].Name = "Ordered By";
            grdCompletedOrders.Columns[9].Name = "Date Ordered";

            foreach (DataRow item in ds.Rows)
            {
                grdCompletedOrders.Columns[0].Visible = false;
                int n = grdCompletedOrders.Rows.Add();
                grdCompletedOrders.Rows[n].Cells[0].Value = item["completedOrdersID"].ToString();
                grdCompletedOrders.Rows[n].Cells[1].Value = item["orderNo"].ToString();
                grdCompletedOrders.Rows[n].Cells[2].Value = item["branch"].ToString();
                string DeliveredByname = item["DeliveredfirstName"].ToString() + " " + item["DeliveredlastName"].ToString();
                grdCompletedOrders.Rows[n].Cells[3].Value = DeliveredByname;
                string ProcessedByname = item["ProcessedfirstName"].ToString() + " " + item["ProcessedlastName"].ToString();
                grdCompletedOrders.Rows[n].Cells[4].Value = ProcessedByname;
                grdCompletedOrders.Rows[n].Cells[5].Value = item["processedOn"].ToString();
                grdCompletedOrders.Rows[n].Cells[6].Value = item["CustomerName"].ToString();
                grdCompletedOrders.Rows[n].Cells[7].Value = item["CustomerPhone"].ToString();
                string name = item["firstName"].ToString() + " " + item["lastName"].ToString();
                grdCompletedOrders.Rows[n].Cells[8].Value = name;
                string dateOrdered = Convert.ToDateTime(item["dateOrdered"].ToString()).ToString("d");
                grdCompletedOrders.Rows[n].Cells[9].Value = dateOrdered;

            }
            sql_con.Close();
            this.grdCompletedOrders.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void viewOrders_Load(object sender, EventArgs e)
        {

        }

        private void grdCompletedOrders_DoubleClick(object sender, EventArgs e)
        {
            string orderID = grdCompletedOrders.SelectedRows[0].Cells[1].Value.ToString();
            viewProcessedOrders workOrdersFrm = new viewProcessedOrders(orderID, this, loggedUsername);
            workOrdersFrm.MdiParent = this.MdiParent;
            workOrdersFrm.Show();
        }
    }
}
