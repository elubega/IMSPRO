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
    public partial class unitMeasures : Form
    {
        public unitMeasures()
        {
            InitializeComponent();
            listUnitMeasures();
        }
        //decearing variables for the connection
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        //creating connection string
        private void SetConnection()
        {
            sql_con = new SQLiteConnection
                ("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_measure_Click(object sender, EventArgs e)
        {
            SetConnection();
            sql_con.Open();
            string query = "INSERT INTO unit_measure (unitName, dateAdded)";
            query += " VALUES (@unitName, @dateAdded)";
            SQLiteCommand myCommand = new SQLiteCommand(query, sql_con);
            myCommand.Parameters.AddWithValue("@unitName", txt_untiMeasure.Text);
            myCommand.Parameters.AddWithValue("@dateAdded", DateTime.Now.ToString("yyyy-MM-dd"));
            int qSuccess = myCommand.ExecuteNonQuery();
            sql_con.Close();
            if (qSuccess == 1)
            {
                listUnitMeasures();
                txt_untiMeasure.Clear();
                txt_untiMeasure.Focus();     
            }
            else
            {
                MessageBox.Show("There is an Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

        private void listUnitMeasures()
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select unitName AS 'Unit Name' from unit_measure";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            grd_UnitMeasures.DataSource = DT;
            sql_con.Close(); ;

            this.grd_UnitMeasures.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
