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
    public partial class editUnitMeasure : Form
    {
        public int unitIDData;
        public unitMeasures frmUnitMeasure;
        public editUnitMeasure(int unitID, unitMeasures getFrmUnitMeasure)
        {
            InitializeComponent();
            unitIDData = unitID;
            fillUnitName();
            frmUnitMeasure = getFrmUnitMeasure;
        }

        private void btn_saveUnitMeasure_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
            conn.Open();
            string CommandText = "UPDATE unit_measure SET unitName=@unitNameUpdated where unitID=@unitID";
            SQLiteCommand cmdUnitMeasures = new SQLiteCommand(CommandText, conn);
            cmdUnitMeasures.Parameters.AddWithValue("@unitNameUpdated", txt_UnitMeasure.Text);
            cmdUnitMeasures.Parameters.AddWithValue("@unitID", unitIDData);
            int confirmAction = cmdUnitMeasures.ExecuteNonQuery();
            if (confirmAction == 1)
            {
                MessageBox.Show("Unit Measure has been updated successfully ", "Unit Measure Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmUnitMeasure.listUnitMeasures();
                this.Close();
            }
            conn.Close();
        }
        private void fillUnitName()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
            conn.Open();
            string CommandText = "select unitName from unit_measure where unitID=@unitID";
            SQLiteCommand cmdUnitMeasures = new SQLiteCommand(CommandText, conn);
            cmdUnitMeasures.Parameters.AddWithValue("@unitID", unitIDData);
            SQLiteDataReader reader = cmdUnitMeasures.ExecuteReader();
            while (reader.Read())
            {
                txt_UnitMeasure.Text = reader["unitName"].ToString();
            }
            conn.Close();
        }
    }
}
