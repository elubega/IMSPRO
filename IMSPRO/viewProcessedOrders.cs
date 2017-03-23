using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMSPRO
{
    public partial class viewProcessedOrders : Form
    {
        public string orderNumber;
        public int successEntryToDB;
        public int finalQty;
        public viewOrders ordersFrm;
        public string currentLoggedInUser;

        public viewProcessedOrders(string orderID, viewOrders frmOrders, string currentLoggedUser)
        {
            InitializeComponent();
            orderNumber = orderID;
            txt_OrderNumber.Text = orderNumber;
            //lbl_orderNumber.Text = Convert.ToString(orderNumber);
            loadOrderData();
            loadUsers();
            ordersFrm = frmOrders;
            currentLoggedInUser = currentLoggedUser;
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
        void loadOrderData()
        {
            //dispalays a list of products
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = @"select A.orderID as orderID,A.barcode as barcode,A.productName as productName, A.qty as qty,A.measure as measure,A.orderNo as orderNo,A.price as price, B.CustomerName as CustomerName, B.CustomerPhone as CustomerPhone, B.DateOrdered as dateOrdered,C.branchName as branch, D.firstName as firstName, D.lastName as lastName from orders A left join orderCustomers B on B.orderNo = A.orderNo left join branch C on C.branchID = B.BranchID left join users D on D.userID= B.OrderedBy where A.orderNo='" + txt_OrderNumber.Text.ToString() + "'";
            SQLiteDataAdapter pdtList = new SQLiteDataAdapter(CommandText, sql_con);
            DataTable ds = new DataTable();
            pdtList.Fill(ds);
            grdProcessOrder.Rows.Clear();
            grdProcessOrder.ColumnCount = 7;
            grdProcessOrder.ColumnHeadersVisible = true;

            grdProcessOrder.Columns[0].Name = "ID";
            grdProcessOrder.Columns[1].Name = "Barcode";
            grdProcessOrder.Columns[2].Name = "Product Name";
            grdProcessOrder.Columns[3].Name = "Qty";
            grdProcessOrder.Columns[4].Name = "Measure";
            grdProcessOrder.Columns[5].Name = "Price";
            grdProcessOrder.Columns[6].Name = "Total";
            foreach (DataRow item in ds.Rows)
            {
                grdProcessOrder.Columns[0].Visible = false;
                int n = grdProcessOrder.Rows.Add();
                grdProcessOrder.Rows[n].Cells[0].Value = item["orderID"].ToString();
                grdProcessOrder.Rows[n].Cells[1].Value = item["barcode"].ToString();
                grdProcessOrder.Rows[n].Cells[2].Value = item["productName"].ToString();
                grdProcessOrder.Rows[n].Cells[3].Value = item["qty"].ToString();
                grdProcessOrder.Rows[n].Cells[4].Value = item["measure"].ToString();
                grdProcessOrder.Rows[n].Cells[5].Value = item["price"].ToString();
                int qty = Int32.Parse(item["qty"].ToString());
                int price = Int32.Parse(item["price"].ToString());
                int total = qty * price;
                grdProcessOrder.Rows[n].Cells[6].Value = total;
                txt_dateOrdered.Text = Convert.ToDateTime(item["dateOrdered"].ToString()).ToString("d");
                string name = item["firstName"].ToString() + " " + item["lastName"].ToString();
                txt_orderedBy.Text = name;
                txt_Branch.Text = item["branch"].ToString();
                txt_customerName.Text = item["CustomerName"].ToString();
                txt_customerPhone.Text = item["CustomerPhone"].ToString();

            }
            this.grdProcessOrder.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            GroundTotal();



            sql_con.Close();

        }
        private void GroundTotal()
        {
            int GTotal = 0;
            for (int i = 0; i < grdProcessOrder.Rows.Count; i++)
            {
                string total = (grdProcessOrder.Rows[i].Cells[6].Value.ToString());
                GTotal += Int32.Parse(total);
                //totalZ = total;
            }
            txt_FinalTotal.Text = GTotal.ToString();
        }
        private void loadUsers()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
            conn.Open();
            string CommandText = "select userID, firstName,lastName from users";
            SQLiteDataAdapter DB = new SQLiteDataAdapter(CommandText, conn);
            DataSet ds = new DataSet();
            DB.Fill(ds, "users");
            cbm_deliveredBy.DisplayMember = "firstName";
            cbm_deliveredBy.ValueMember = "userID";
            cbm_deliveredBy.DataSource = ds.Tables["users"];

            conn.Close();
        }
    }
}
