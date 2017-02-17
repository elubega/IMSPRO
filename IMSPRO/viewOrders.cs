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
        public viewOrders()
        {
            InitializeComponent();
            LoadData();
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
        private void LoadData()
        {
            //dispalays a list of products
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select DISTINCT orderID, dateOrdered, orderNo, branch.branchName As branch, users.firstName As firstName, users.lastName As lastName from orders  left Join branch  ON branch.branchID=orders.branchID left Join users  ON users.userID = orders.userID  group by orders.orderNo order by dateOrdered ASC";
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
    }
}
