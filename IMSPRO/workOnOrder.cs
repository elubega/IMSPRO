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
    public partial class workOnOrder : Form
    {
        public string orderNumber;
        public int successEntryToDB;
        public int finalQty;
        public viewOrders ordersFrm;
        public string currentLoggedInUser;
        public workOnOrder( string orderID, viewOrders frmOrders, string currentLoggedUser)
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
        private void btn_processOrder_Click(object sender, EventArgs e)
        {
            
            string StrQuery;
            try
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");

                conn.Open();
                for (int i = 0; i < grdProcessOrder.Rows.Count; i++)
                {
                    StrQuery = @"INSERT INTO completedordersDetails(barcode,productName,qty,measure, price, orderNo) VALUES (@barcode,@productName,@qty,@measure, @price, @orderNo)";
                    SQLiteCommand comm = new SQLiteCommand(StrQuery, conn);
                    comm.Parameters.AddWithValue("@barcode", grdProcessOrder.Rows[i].Cells["Barcode"].Value);
                    comm.Parameters.AddWithValue("@productName", grdProcessOrder.Rows[i].Cells[2].Value);
                    comm.Parameters.AddWithValue("@qty", grdProcessOrder.Rows[i].Cells["Qty"].Value);
                    comm.Parameters.AddWithValue("@measure", grdProcessOrder.Rows[i].Cells["Measure"].Value);
                    comm.Parameters.AddWithValue("@price", grdProcessOrder.Rows[i].Cells["Price"].Value);
                    comm.Parameters.AddWithValue("@orderNo", txt_OrderNumber.Text);
                    //comm.Parameters.AddWithValue("@dateOrdered", DateTime.Now.ToString("yyyy-MM-dd"));
                    //comm.Parameters.AddWithValue("@orderNo", txt_OrderNumber.Text);
                    //comm.Parameters.AddWithValue("@branch", txt_Branch.Text);
                    //comm.Parameters.AddWithValue("@orderedBy", txt_orderedBy.Text);
                    successEntryToDB = comm.ExecuteNonQuery();
                    comm.Parameters.Clear();

                    //Update Table Products With a reduction in product qty

                    string yb = grdProcessOrder.Rows[i].Cells["Barcode"].Value.ToString();
                    int yf =Int32.Parse(grdProcessOrder.Rows[i].Cells["Qty"].Value.ToString());
                    int orderNumber = Int32.Parse(txt_OrderNumber.Text.ToString());

                    string query = "Select productQty, productName from Products where productBarcode=@productBarcode";
                    SQLiteCommand comm5 = new SQLiteCommand(query, conn);
                    comm5.Parameters.AddWithValue("@productBarcode", yb);
                    SQLiteDataReader reader = comm5.ExecuteReader();
                    while (reader.Read())
                    {
                        int qty = Int32.Parse(reader["productQty"].ToString());
                        string productName = reader["productName"].ToString();
                        //Subtract old from new order qty
                        if (qty>yf)
                        {
                            finalQty = qty - yf;
                        }
                        else
                        {
                            MessageBox.Show(productName+ "is out of Stock, Remove it From List","Product out of Stock",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                        }
                        
                    }
                    
                    //update products table with new qty
                    StrQuery = @"UPDATE Products SET productQty=@productQty where productBarcode=@barcode";
                    SQLiteCommand commUpdateQty = new SQLiteCommand(StrQuery, conn);
                    commUpdateQty.Parameters.AddWithValue("@barcode", grdProcessOrder.Rows[i].Cells["Barcode"].Value);
                    commUpdateQty.Parameters.AddWithValue("@productQty", finalQty);
                    successEntryToDB = commUpdateQty.ExecuteNonQuery();

                    //update orders table with the status
                    StrQuery = @"UPDATE orders SET processedOrderStatus = 1 where barcode=@barcode and orderNo=@orderNumber";
                    SQLiteCommand commOrderStatus = new SQLiteCommand(StrQuery, conn);
                    commOrderStatus.Parameters.AddWithValue("@barcode", grdProcessOrder.Rows[i].Cells["Barcode"].Value);
                    commOrderStatus.Parameters.AddWithValue("@productQty", finalQty);
                    commOrderStatus.Parameters.AddWithValue("@orderNumber", orderNumber);
                    successEntryToDB = commOrderStatus.ExecuteNonQuery();

                    //


                }
                //insert order details into processed table for future reference

                StrQuery = @"INSERT INTO completedOrders (orderNo, deliveredBy, processedBy, processedOn, customerName, customerPhone) VALUES(@orderNo,@deliveredBy,@processedBy,@processedOn,@customerNumber,@customerPhone)";
                SQLiteCommand commCompleteOrder = new SQLiteCommand(StrQuery, conn);
                commCompleteOrder.Parameters.AddWithValue("@orderNo", txt_OrderNumber.Text);
                commCompleteOrder.Parameters.AddWithValue("@deliveredBy", cbm_deliveredBy.SelectedValue);
                commCompleteOrder.Parameters.AddWithValue("@processedBy", currentLoggedInUser);
                commCompleteOrder.Parameters.AddWithValue("@processedOn", DateTime.Now.ToString("yyyy-MM-dd"));
                commCompleteOrder.Parameters.AddWithValue("@customerNumber", txt_customerName.Text);
                commCompleteOrder.Parameters.AddWithValue("@customerPhone", txt_customerPhone.Text);
                successEntryToDB = commCompleteOrder.ExecuteNonQuery();

                if (successEntryToDB > 0)
                {

                    try
                    {
                        /*string query = "Insert into orderNumbers (orderNo,dateGenerated) values(@orderNumber,@dateCreated)";
                        SQLiteCommand myCommand = new SQLiteCommand(query, conn);
                        myCommand.Parameters.AddWithValue("@orderNumber", txt_orderNo.Text);
                        myCommand.Parameters.AddWithValue("@dateCreated", DateTime.Now.ToString("yyyy-MM-dd"));
                        myCommand.ExecuteNonQuery();*/
                    }
                    catch (Exception ec)

                    {
                        MessageBox.Show("Error..... Contact Developer for Help. info@ingtep.com"+ec);
                    }

                    MessageBox.Show("Order is ready for Delivery", "Order Processed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //OrderNumbers();
                    //grdOrderForm.Rows.Clear();
                    ordersFrm.LoadData();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error..... Contact Developer for Help. info@ingtep.com"+ex);
            }
        }
        void loadOrderData()
        {
            //dispalays a list of products
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = @"select A.orderID as orderID,A.barcode as barcode,A.productName as productName, A.qty as qty,A.measure as measure,A.orderNo as orderNo,A.price as price, B.CustomerName as CustomerName, B.CustomerPhone as CustomerPhone, B.DateOrdered as dateOrdered,C.branchName as branch, D.firstName as firstName, D.lastName as lastName from orders A left join orderCustomers B on B.orderNo = A.orderNo left join branch C on C.branchID = B.BranchID left join users D on D.userID= B.OrderedBy where A.orderNo='" + txt_OrderNumber.Text.ToString()+"'";
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
            int GTotal=0;
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

        private void grdProcessOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
