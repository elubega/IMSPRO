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

    public partial class editBranch : Form
    {
        public branchManager frmEditBranchHere;
        public int branchIdFromDb;
        public editBranch(int BranchIDToEdit, branchManager frmEditBranch)
        {
            InitializeComponent();
            frmEditBranchHere = frmEditBranch;
            branchIdFromDb = BranchIDToEdit;
            loadBranchNameTxt();
        }

        private void btn_saveBranch_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
            conn.Open();
            string CommandText = "UPDATE branch SET branchName=@branchNameUpdated where branchID=@branchID";
            SQLiteCommand cmdUnitMeasures = new SQLiteCommand(CommandText, conn);
            cmdUnitMeasures.Parameters.AddWithValue("@branchNameUpdated", txt_BranchName.Text);
            cmdUnitMeasures.Parameters.AddWithValue("@branchID", branchIdFromDb);
            int confirmAction = cmdUnitMeasures.ExecuteNonQuery();
            if (confirmAction == 1)
            {
                MessageBox.Show("Branch has been updated successfully ", "Branch Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmEditBranchHere.loadBranchName();
                this.Close();
            }
            conn.Close();
        }
    
        private void loadBranchNameTxt()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
            conn.Open();
            string query = "Select branchName from branch where branchID=@branchID";
            SQLiteCommand comm = new SQLiteCommand(query, conn);
            comm.Parameters.AddWithValue("@branchID", branchIdFromDb);
            SQLiteDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                txt_BranchName.Text = reader["branchName"].ToString();
               
            }
            conn.Close();
        }
    }
}
