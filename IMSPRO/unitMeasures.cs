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
    

        public void listUnitMeasures()
        {
            SetConnection();
            sql_con.Open();
            string CommandText = "select unitID, unitName, dateAdded from unit_measure";
            SQLiteDataAdapter showUnits = new SQLiteDataAdapter(CommandText, sql_con);
                       
            DataTable ds = new DataTable();
            showUnits.Fill(ds);
            grd_UnitMeasures.Rows.Clear();

            grd_UnitMeasures.ColumnCount = 3;
            grd_UnitMeasures.ColumnHeadersVisible = true;
            grd_UnitMeasures.Columns[0].Name = "ID";
            grd_UnitMeasures.Columns[1].Name = "Unit Name";
            grd_UnitMeasures.Columns[2].Name = "Date Added";

            foreach (DataRow item in ds.Rows)
            {
                grd_UnitMeasures.Columns[0].Visible = false;
                int n = grd_UnitMeasures.Rows.Add();
                grd_UnitMeasures.Rows[n].Cells[0].Value = item["unitID"].ToString();
                grd_UnitMeasures.Rows[n].Cells[1].Value = item["unitName"].ToString();
                grd_UnitMeasures.Rows[n].Cells[2].Value = Convert.ToDateTime(item["dateAdded"].ToString()).ToString("d");


            }
            sql_con.Close(); ;

            this.grd_UnitMeasures.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void grd_UnitMeasures_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                SetConnection();
                sql_con.Open();
                string CommandText = "Delete from unit_measure where unitID = @ID";
                SQLiteCommand comm = new SQLiteCommand(CommandText, sql_con);
                comm.Parameters.AddWithValue("@ID", grd_UnitMeasures.SelectedRows[0].Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Do you really want to delete Unit Measure \"" + grd_UnitMeasures.SelectedRows[0].Cells[1].Value.ToString() + "\"?", "Confirm Branch deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int qSuccess = comm.ExecuteNonQuery();
                    MessageBox.Show("Unit has been Deleted Successfully", "Unit Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listUnitMeasures();
                }
                sql_con.Close();
            }
        }

        private void grd_UnitMeasures_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int unitID = Int32.Parse(grd_UnitMeasures.SelectedRows[0].Cells[0].Value.ToString());
            editUnitMeasure frmEditMeasure = new editUnitMeasure(unitID, this);
            frmEditMeasure.MdiParent = this.MdiParent;
            frmEditMeasure.Show();
        }
    }
}
