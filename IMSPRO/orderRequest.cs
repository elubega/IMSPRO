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
    public partial class orderRequest : Form
    {
        
        public orderRequest()
        {
            InitializeComponent();
            AutoCompleteBarcode();
            AutoCompleteProductName();
            OrderNumbers();
            LoadProductsInGrid();
            txt_dateOrdered.Text = DateTime.Now.ToString("dd-MM-yyyy");
            loadBranches();
            loadUsers();
            //fillUnitsCbm();
        }

        public string unitMeasureName;
        public int successEntryToDB;

        private void btn_addOrder_Click(object sender, EventArgs e)
        {
            addProductsToGrid();
        }

        void addProductsToGrid()
        {
            if(string.IsNullOrWhiteSpace(txt_barCode.Text)|| string.IsNullOrWhiteSpace(txt_productName.Text)|| string.IsNullOrWhiteSpace(txt_qty.Text))
            {
                MessageBox.Show("Please Fill all Forms","Empty Fields",MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                string barcode = txt_barCode.Text;
                string productName = txt_productName.Text;
                int qty = Int32.Parse(txt_qty.Text);

                SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
                conn.Open();
                string query = "Select productQty, productName from Products where productBarcode=@productBarcode";
                SQLiteCommand comm5 = new SQLiteCommand(query, conn);
                comm5.Parameters.AddWithValue("@productBarcode", barcode);
                SQLiteDataReader reader = comm5.ExecuteReader();
                while (reader.Read())
                {
                    int qtyInDB = Int32.Parse(reader["productQty"].ToString());
                    string productNameInDB = reader["productName"].ToString();
                    //Subtract old from new order qty
                    if (qtyInDB > qty)
                    {
                        //string unitMeasure = cbm_unitMeasure.SelectedText; //removed the combox to replace it with a text because we already know the units
                        String unitMeasure = txt_UnitMeasure.Text;
                        int price = Int32.Parse(txt_price.Text);

                        int totalPrice = qty * price;
                        string[] row = { barcode, productName, Convert.ToString(qty), unitMeasure, Convert.ToString(price), Convert.ToString(totalPrice) };
                        grdOrderForm.Rows.Add(row);

                        clearFormOrder();
                    }
                    else
                    {
                        MessageBox.Show(productNameInDB + " is out of Stock or Less \r\n Current Quantity="+ qtyInDB + "\r\n Remove it From List or Reduce Quantity", "Product Out of Stock", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txt_qty.Clear();
                    }

                }
                conn.Close();

            }
            


        }
        public void LoadProductsInGrid()
        {
            grdOrderForm.Rows.Clear();
            grdOrderForm.ColumnCount = 6;
            grdOrderForm.ColumnHeadersVisible = true;
            grdOrderForm.Columns[0].Name = "Barcode";
            grdOrderForm.Columns[1].Name = "Product Name";
            grdOrderForm.Columns[2].Name = "Qty";
            grdOrderForm.Columns[3].Name = "Measure";
            grdOrderForm.Columns[4].Name = "Price";
            grdOrderForm.Columns[5].Name = "Total";

            this.grdOrderForm.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void OrderNumbers()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
            conn.Open();
            string query = "Select max(orderNoID) AS 'OrderNumber' from orderNumbers";
            SQLiteCommand comm = new SQLiteCommand(query, conn);
            //comm.Parameters.AddWithValue("@branchID", branchIdFromDb);
            SQLiteDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                txt_orderNo.Text = reader["OrderNumber"].ToString();

            }
            conn.Close();
        }
        private void loadBranches()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
            conn.Open();
            string CommandText = "select branchID, branchName from branch";
            SQLiteDataAdapter DB = new SQLiteDataAdapter(CommandText, conn);
            DataSet ds = new DataSet();
            DB.Fill(ds, "branch");
            cbm_branchName.DisplayMember = "branchName";
            cbm_branchName.ValueMember = "branchID";
            cbm_branchName.DataSource = ds.Tables["branch"];
            
            conn.Close();
        }
        private void loadUsers()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
            conn.Open();
            string CommandText = "select userID, firstName,lastName from users";
            SQLiteDataAdapter DB = new SQLiteDataAdapter(CommandText, conn);
            DataSet ds = new DataSet();
            DB.Fill(ds, "users");
            cbm_orderedBy.DisplayMember = "firstName";
            cbm_orderedBy.ValueMember = "userID";
            cbm_orderedBy.DataSource = ds.Tables["users"];
            conn.Close();
        }
        /*private void fillUnitsCbm()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
            conn.Open();
            string CommandText = "select unitID, unitName from unit_measure";
            SQLiteDataAdapter DB = new SQLiteDataAdapter(CommandText, conn);
            DataSet ds = new DataSet();
            DB.Fill(ds, "unitMeasures");
            cbm_unitMeasure.DisplayMember = "unitName";
            cbm_unitMeasure.ValueMember = "unitID";
            cbm_unitMeasure.DataSource = ds.Tables["unitMeasures"];
            conn.Close();
        }*/

        private void txt_barCode_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode==Keys.Enter)
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
                conn.Open();
                string CommandText = "select productBarcode, productName, unitID, unitCost from Products where productBarcode=@barcode";
                SQLiteCommand DB = new SQLiteCommand(CommandText, conn);
                DB.Parameters.AddWithValue("@barcode", txt_barCode.Text);
                SQLiteDataReader reader = DB.ExecuteReader();
                while (reader.Read())
                {
                    txt_productName.Text = reader["productName"].ToString();
                    unitMeasureName = reader["unitID"].ToString();
                    txt_price.Text = reader["unitCost"].ToString();

                }
                //finds the unit names
                string CommandUnitMeasure = "select unitName from unit_measure where unitID=@unitMeasureName";
                SQLiteCommand unitMeasireCmd = new SQLiteCommand(CommandUnitMeasure, conn);
                unitMeasireCmd.Parameters.AddWithValue("@unitMeasureName", unitMeasureName);
                SQLiteDataReader readerUnitMeasure = unitMeasireCmd.ExecuteReader();
                while (readerUnitMeasure.Read())
                {
                    txt_UnitMeasure.Text = readerUnitMeasure["unitName"].ToString();
                }

                conn.Close();
                txt_qty.Focus();
            }
        }
        void AutoCompleteBarcode()
        {
            txt_barCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_barCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
            conn.Open();
            string CommandText = "select productBarcode, productName from Products";
            SQLiteCommand DB = new SQLiteCommand(CommandText, conn);
            DB.Parameters.AddWithValue("@barcode", txt_barCode.Text);
            SQLiteDataReader reader = DB.ExecuteReader();
            while (reader.Read())
            {
                String barcode = reader["productBarcode"].ToString();
                coll.Add(barcode);
                
            }
            conn.Close();

            txt_barCode.AutoCompleteCustomSource = coll;
        }
        void AutoCompleteProductName()
        {
            txt_productName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt_productName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
            conn.Open();
            string CommandText = "select productBarcode, productName from Products";
            SQLiteCommand DB = new SQLiteCommand(CommandText, conn);
            SQLiteDataReader reader = DB.ExecuteReader();
            while (reader.Read())
            {
                String barcode = reader["productName"].ToString();
                coll.Add(barcode);
            }
            conn.Close();

            txt_productName.AutoCompleteCustomSource = coll;
        }
        void clearFormOrder()
        {
            txt_qty.Clear();
            txt_barCode.Clear();
            txt_productName.Clear();
            txt_UnitMeasure.Clear();
            txt_barCode.Focus();
            txt_price.Clear();
            
        }

        /// <summary>
        /// Trying to Send Data from the Data Grid View to the Database
        /// </summary>

        private void btn_MakeOrder_Click(object sender, EventArgs e)
        {
            

        string StrQuery;
            try
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");

                conn.Open();

                string OrderDetailsquery = @"Insert into orderCustomers (orderNo, BranchID, CustomerName, CustomerPhone, DateOrdered, OrderedBy)"+ 
                    $"values(@orderNumber,@branch, @CustomerName, @CustomerPhone, @dateCreated, @orderedBy)";
                SQLiteCommand OrderDetailsCommand = new SQLiteCommand(OrderDetailsquery, conn);
                OrderDetailsCommand.Parameters.AddWithValue("@orderNumber", txt_orderNo.Text);
                OrderDetailsCommand.Parameters.AddWithValue("@dateCreated", DateTime.Now.ToString("yyyy-MM-dd"));
                OrderDetailsCommand.Parameters.AddWithValue("@branch", cbm_branchName.SelectedValue);
                OrderDetailsCommand.Parameters.AddWithValue("@CustomerName", txt_customer.Text);
                OrderDetailsCommand.Parameters.AddWithValue("@CustomerPhone", txt_phoneNo.Text);
                OrderDetailsCommand.Parameters.AddWithValue("@orderedBy", cbm_orderedBy.SelectedValue);
                OrderDetailsCommand.ExecuteNonQuery();

                for (int i = 0; i < grdOrderForm.Rows.Count; i++)
                    {
                    StrQuery = @"INSERT INTO orders(barcode,productName,qty,measure,orderNo,price) VALUES (@barcode,@productName,@qty,@measure, @orderNo,@price)";
                    SQLiteCommand comm = new SQLiteCommand(StrQuery, conn);
                    comm.Parameters.AddWithValue("@barcode", grdOrderForm.Rows[i].Cells["Barcode"].Value);
                    comm.Parameters.AddWithValue("@productName", grdOrderForm.Rows[i].Cells[1].Value);
                    comm.Parameters.AddWithValue("@qty", grdOrderForm.Rows[i].Cells["Qty"].Value);
                    comm.Parameters.AddWithValue("@measure", grdOrderForm.Rows[i].Cells["Measure"].Value);
                    //comm.Parameters.AddWithValue("@dateOrdered", DateTime.Now.ToString("yyyy-MM-dd"));
                    comm.Parameters.AddWithValue("@orderNo", txt_orderNo.Text);
                    comm.Parameters.AddWithValue("@price", grdOrderForm.Rows[i].Cells["Price"].Value);
                    //comm.Parameters.AddWithValue("@branch", cbm_branchName.SelectedValue);
                    //comm.Parameters.AddWithValue("@orderedBy", cbm_orderedBy.SelectedValue);
                    successEntryToDB = comm.ExecuteNonQuery();
                            comm.Parameters.Clear();

                }
                        if(successEntryToDB > 0)
                {

                    try
                    {
                        string query = "Insert into orderNumbers (orderNo,dateGenerated) values(@orderNumber,@dateCreated)";
                        SQLiteCommand myCommand = new SQLiteCommand(query, conn);
                        myCommand.Parameters.AddWithValue("@orderNumber", txt_orderNo.Text);
                        myCommand.Parameters.AddWithValue("@dateCreated", DateTime.Now.ToString("yyyy-MM-dd"));
                        myCommand.ExecuteNonQuery();
                    }
                    catch (Exception ec)

                    {
                        MessageBox.Show("Error..... Contact Developer for Help. info@ingtep.com"+ec);
                    }

                    MessageBox.Show("Your Order Has Been Sent","Order Request Sent",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    OrderNumbers();
                    grdOrderForm.Rows.Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error..... Contact Developer for Help. info@ingtep.com"+ex);
            }
        }
        private void txt_qty_TextChanged(object sender, EventArgs e)
        {
            //Modifies the unit measure if unit is greater than or equal to 2
            int myInt;
            if (int.TryParse(txt_qty.Text.Trim(), out myInt) && (myInt >= 2))
            {
                if (txt_UnitMeasure.Text == "Box" && myInt >= 2)
                {
                    txt_UnitMeasure.Text = txt_UnitMeasure.Text + "es";
                }
            }
            else
            {
                if (txt_UnitMeasure.Text == "Boxes" && myInt <2)
                {
                    txt_UnitMeasure.Text = txt_UnitMeasure.Text.Remove(txt_UnitMeasure.Text.Length - 2);

                }
            }
            int myIntOther;
            if (int.TryParse(txt_qty.Text.Trim(), out myIntOther) && (myIntOther >= 2))
            {
                if (!txt_UnitMeasure.Text.EndsWith("s") && txt_UnitMeasure.Text != "Box" && txt_UnitMeasure.Text != "Boxes" && myIntOther >= 2)
                {
                    txt_UnitMeasure.Text = txt_UnitMeasure.Text + "s";
                }
            }
            else
            {

                if (txt_UnitMeasure.Text.EndsWith("s"))
                {
                    txt_UnitMeasure.Text = txt_UnitMeasure.Text.Remove(txt_UnitMeasure.Text.Length - 1);
                    

                }

            }
        }

        private void btn_CancelOrder_Click(object sender, EventArgs e)
        {
            grdOrderForm.Rows.Clear();
        }

        private void txt_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addProductsToGrid();
            }
        }

        private void txt_productName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
                conn.Open();
                string CommandText = "select productBarcode, productName, unitID, unitCost from Products where productName=@productName";
                SQLiteCommand DB = new SQLiteCommand(CommandText, conn);
                DB.Parameters.AddWithValue("@productName", txt_productName.Text);
                SQLiteDataReader reader = DB.ExecuteReader();
                while (reader.Read())
                {
                    txt_barCode.Text = reader["productBarcode"].ToString();
                    unitMeasureName = reader["unitID"].ToString();
                    txt_price.Text = reader["unitCost"].ToString();

                }
                //finds the unit names
                string CommandUnitMeasure = "select unitName from unit_measure where unitID=@unitMeasureName";
                SQLiteCommand unitMeasireCmd = new SQLiteCommand(CommandUnitMeasure, conn);
                unitMeasireCmd.Parameters.AddWithValue("@unitMeasureName", unitMeasureName);
                SQLiteDataReader readerUnitMeasure = unitMeasireCmd.ExecuteReader();
                while (readerUnitMeasure.Read())
                {
                    txt_UnitMeasure.Text = readerUnitMeasure["unitName"].ToString();
                }

                conn.Close();
                txt_qty.Focus();
            }
        }

        private void grdOrderForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult result = MessageBox.Show("Do you really want to remove this product(s)", "Confirm product removal", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {

                    foreach (DataGridViewRow item in this.grdOrderForm.SelectedRows)
                    {
                        grdOrderForm.Rows.RemoveAt(item.Index);

                    }
                }
            }
        }
    }
}
