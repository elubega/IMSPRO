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
            fillUnitsCbm();
        }

        private void btn_addOrder_Click(object sender, EventArgs e)
        {
            string barcode = txt_barCode.Text;
            string productName = txt_productName.Text;
            string qty = txt_qty.Text;
            string unitMeasure = cbm_unitMeasure.SelectedText;
            string[] row = { barcode, productName, qty, unitMeasure};
            grdOrderForm.Rows.Add(row);

            clearFormOrder();
           

        }

        public void LoadProductsInGrid()
        {
            grdOrderForm.Rows.Clear();
            grdOrderForm.ColumnCount = 4;
            grdOrderForm.ColumnHeadersVisible = true;
            grdOrderForm.Columns[0].Name = "Barcode";
            grdOrderForm.Columns[1].Name = "Product Name";
            grdOrderForm.Columns[2].Name = "Qty";
            grdOrderForm.Columns[3].Name = "Measure";

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
        private void fillUnitsCbm()
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
        }

        private void txt_barCode_KeyDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode==Keys.Enter)
            {
                SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
                conn.Open();
                string CommandText = "select productBarcode, productName from Products where productBarcode=@barcode";
                SQLiteCommand DB = new SQLiteCommand(CommandText, conn);
                DB.Parameters.AddWithValue("@barcode", txt_barCode.Text);
                SQLiteDataReader reader = DB.ExecuteReader();
                while (reader.Read())
                {
                    txt_productName.Text = reader["productName"].ToString();
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
            txt_barCode.Focus();
        }

        /// <summary>
        /// Trying to Send Data from the Data Grid View to the Database
        /// </summary>

        private void btn_MakeOrder_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            for (int j = 0; j < grdOrderForm.Rows.Count; j++)
            {
                DataRow dr;
                DataGridViewRow row = grdOrderForm.Rows[j];
                dr = dt.NewRow();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dr[i] = row.Cells[i];
                }

                dt.Rows.Add(dr);
            }
        }

    }
}
