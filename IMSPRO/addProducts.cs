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
        private void LoadData()
        {
            //dispalays a list of products
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select productBarcode As 'Barcode',productName AS 'Product Name',productQty AS 'Qty',unit_measure.unitName AS 'Unit', users.userName AS 'Entered By', dateStocked AS 'Date Stocked' from Products  left Join unit_measure  ON unit_measure.unitID=Products.unitID left Join users  ON users.userID = Products.userID";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            lstProducts.DataSource = DT;
            sql_con.Close();

            //Autosizes the product name column
            this.lstProducts.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
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
    }
}
