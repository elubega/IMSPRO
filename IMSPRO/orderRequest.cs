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
            OrderNumbers();
            LoadProductsInGrid();
            txt_dateOrdered.Text = DateTime.Now.ToString("dd-MM-yyyy");
            loadBranches();
            loadUsers();
            fillUnitsCbm();
            fillUnitsCbm();
        }

        private void btn_addOrder_Click(object sender, EventArgs e)
        {

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
            }
        }
    }
}
