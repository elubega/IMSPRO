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
        public addProducts()
        {
            InitializeComponent();
            fillCombUnitMeasures();
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
        
    }
}
