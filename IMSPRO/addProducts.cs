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
    public partial class addProducts : Form
    {
        public string loginNames;
        public addProducts(string loginName, String userID)
        {
            InitializeComponent();
            fillCombUnitMeasures();
            loginNames = userID;
            LoadData();
        }
        //decearing variables for the connection
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        public String time;

        //Creating connection execution command
        private void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

        //creating connection string
        private void SetConnection()
        {
            sql_con = new SQLiteConnection
                ("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txt_barcode.Text)|| String.IsNullOrWhiteSpace(txt_productName.Text) || String.IsNullOrWhiteSpace(txt_qty.Text) /*|| String.IsNullOrWhiteSpace(cbm_units.SelectedText)*/)
            {
                MessageBox.Show("Please Enter Missing Fields","Missing Fields",MessageBoxButtons.OK, MessageBoxIcon.Stop);

                clearEntryForm();
            }
            else
            { 
            SetConnection();
            sql_con.Open();
            string query = "INSERT INTO Products (productBarcode, productName, productQty, unitID, userID,  dateStocked)";
            query += " VALUES (@productBarcode, @productName, @productQty, @unitID, @userID, @dateStocked)";

            SQLiteCommand myCommand = new SQLiteCommand(query, sql_con);
            myCommand.Parameters.AddWithValue("@productBarcode", txt_barcode.Text);
            myCommand.Parameters.AddWithValue("@productName", txt_productName.Text);
            myCommand.Parameters.AddWithValue("@productQty", txt_qty.Text);
            myCommand.Parameters.AddWithValue("@unitID", cbm_units.SelectedValue);
            myCommand.Parameters.AddWithValue("@userID", loginNames);
            myCommand.Parameters.AddWithValue("@dateStocked", DateTime.Now.ToString("yyyy-MM-dd"));
            // ... other parameters
            int qSuccess = myCommand.ExecuteNonQuery();
            sql_con.Close();
            if(qSuccess==1)
            {
                LoadData();
                clearEntryForm();

            }
            else
            {
                MessageBox.Show("There is an Error","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
          }
        }
        private void LoadData()
        {
            //dispalays a list of products
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select productID, productBarcode, productName, productQty, unit_measure.unitName As 'unitName' , users.userName AS 'userName', dateStocked from Products  left Join unit_measure  ON unit_measure.unitID=Products.unitID left Join users  ON users.userID = Products.userID";
            SQLiteDataAdapter pdtList= new SQLiteDataAdapter(CommandText, sql_con);
            DataTable ds = new DataTable();
            pdtList.Fill(ds);
            lstProducts.Rows.Clear();
            foreach (DataRow item in ds.Rows)
            {
                lstProducts.Columns[0].Visible = false;
                int n = lstProducts.Rows.Add();
                lstProducts.Rows[n].Cells[0].Value = item["productID"].ToString();
                lstProducts.Rows[n].Cells[1].Value = item["productBarcode"].ToString();
                lstProducts.Rows[n].Cells[2].Value = item["productName"].ToString();
                lstProducts.Rows[n].Cells[3].Value = item["productQty"].ToString();
                lstProducts.Rows[n].Cells[4].Value = item["unitName"].ToString();
                lstProducts.Rows[n].Cells[5].Value = item["userName"].ToString();
                lstProducts.Rows[n].Cells[6].Value = Convert.ToDateTime(item["dateStocked"].ToString()).ToString("d");


            }
            //DT = DS.Tables[0];
            //lstProducts.DataSource = DT;
            sql_con.Close();

            //Autosizes the product name column
            //this.lstProducts.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
        }
        private void fillCombUnitMeasures()
        {
            try
            {
                //opening connection string
                SetConnection();
                sql_con.Open();
            }catch(Exception ex)
            {
                MessageBox.Show("Error in connection ..." + ex.Message);
            }

            //Binding data to the combox
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select unitID, unitName from unit_measure";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DataSet ds = new DataSet();
            DB.Fill(ds, "unitMeasures");
            cbm_units.DisplayMember = "unitName";
            cbm_units.ValueMember = "unitID";
            cbm_units.DataSource = ds.Tables["unitMeasures"];
            sql_con.Close();
        }
        private void clearEntryForm()
        {
            txt_barcode.Clear();
            txt_productName.Clear();
            txt_qty.Clear();
            cbm_units.SelectedIndex = -1;
            txt_barcode.Focus();
        }

        //Was for a button click to delete we changed to delete key pree
        /*private void btn_delete_Click(object sender, EventArgs e)
        {
            SetConnection();
            sql_con.Open();
            string query = "Delete from Products where productID = @productID";
            SQLiteCommand comm = new SQLiteCommand(query, sql_con);
            comm.Parameters.AddWithValue("@productID", txt_ProductId.Text);
            if (String.IsNullOrWhiteSpace(txt_productName.Text))
            {
                MessageBox.Show("Please select a Product to Delete", "No Item Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                clearEntryForm();
            } else
            { 
            //Warm user before deleting item from the product list
            DialogResult result = MessageBox.Show("Do you really want to delete the product \"" + txt_productName.Text + "\"?", "Confirm product deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {

                int qSuccess = comm.ExecuteNonQuery();
                MessageBox.Show("Product Deleted", "Product Deleted",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LoadData();
                    clearEntryForm();
            }
            if(result==DialogResult.No)
                {
                    clearEntryForm();
                }
        }
            sql_con.Close();
        }*/

        private void btn_clearForm_Click(object sender, EventArgs e)
        {
            clearEntryForm();
        }

        private void lstProducts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txt_ProductId.Text = lstProducts.SelectedRows[0].Cells[0].Value.ToString();
            txt_barcode.Text = lstProducts.SelectedRows[0].Cells[1].Value.ToString();
            txt_productName.Text = lstProducts.SelectedRows[0].Cells[2].Value.ToString();
            txt_qty.Text = lstProducts.SelectedRows[0].Cells[3].Value.ToString();
            String d = lstProducts.SelectedRows[0].Cells[4].Value.ToString();

            SQLiteConnection sql_con = new SQLiteConnection
                ("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
            SQLiteDataAdapter sda = new SQLiteDataAdapter("Select * from unit_measure where unitName = '" + d + "'", sql_con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            foreach (DataRow item in dt.Rows)
            {
                cbm_units.SelectedValue = item["unitID"].ToString();

            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            SetConnection();
            sql_con.Open();
            String query = "UPDATE Products SET productBarcode=@barcode, productName=@productName, productQty=@qty, unitID=@unitID where productID=@pID";
            SQLiteCommand comm = new SQLiteCommand(query,sql_con);
            comm.Parameters.AddWithValue("@barcode", txt_barcode.Text);
            comm.Parameters.AddWithValue("@productName",txt_productName.Text);
            comm.Parameters.AddWithValue("@qty",txt_qty.Text);
            comm.Parameters.AddWithValue("@unitID", cbm_units.SelectedValue);
            comm.Parameters.AddWithValue("@pID",txt_ProductId.Text);
            int confirmAction = comm.ExecuteNonQuery();
            if (confirmAction==1)
            {
                MessageBox.Show("Product has been updated successfully ","Product Updated", MessageBoxButtons.OK,MessageBoxIcon.Information);
                LoadData();
                clearEntryForm();
            }
            else
            {
                MessageBox.Show("Something Happened, Close and Try Again.. Sorry", "Ooops, Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearEntryForm();
            }

        }

        private void lstProducts_KeyDown(object sender, KeyEventArgs e)
        {
            //delete product using the delete key
            if(e.KeyCode==Keys.Delete)
            {

                string pdtID = lstProducts.SelectedRows[0].Cells[0].Value.ToString();
                SetConnection();
                sql_con.Open();
                string query = "Delete from Products where productID = @productID";
                SQLiteCommand comm = new SQLiteCommand(query, sql_con);
                comm.Parameters.AddWithValue("@productID",pdtID);
                
                    DialogResult result = MessageBox.Show("Do you really want to delete the product \"" + lstProducts.SelectedRows[0].Cells[2].Value.ToString() + "\"?", "Confirm product deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {

                        int qSuccess = comm.ExecuteNonQuery();
                        MessageBox.Show("Product Deleted", "Product Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                        clearEntryForm();
                    }
                    if (result == DialogResult.No)
                    {
                        clearEntryForm();
                    }
                
                sql_con.Close();
            }
        }
    }
}
