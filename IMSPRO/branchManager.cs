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
    public partial class branchManager : Form
    {
        public String userIDLog;
        public branchManager(String userID)
        {
            InitializeComponent();
            userIDLog = userID;
            loadBranchName();
        }

        //decearing variables for the connection
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        private void SetConnection()
        {
            sql_con = new SQLiteConnection
                ("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
        }

        private void btn_addBranch_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(txt_branchName.Text))
                {
                    MessageBox.Show("Ooops you didn't anything.... Look at you", "Empty Form Field", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    SetConnection();
                    sql_con.Open();
                    string query = "INSERT INTO branch (branchName, dateAdded, addedBy)";
                    query += " VALUES (@branchName, @dateAdded, @addedBy)";

                    SQLiteCommand myCommand = new SQLiteCommand(query, sql_con);
                    myCommand.Parameters.AddWithValue("@branchName", txt_branchName.Text);
                    myCommand.Parameters.AddWithValue("@dateAdded", DateTime.Now.ToString("yyyy-MM-dd"));
                    myCommand.Parameters.AddWithValue("@addedBy", userIDLog);
                    // ... other parameters
                    int qSuccess = myCommand.ExecuteNonQuery();
                    sql_con.Close();
                    if (qSuccess == 1)
                    {

                        txt_branchName.Clear();
                        txt_branchName.Focus();
                        //Loads Branch Names
                        loadBranchName();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an Error .. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadBranchName()
        {
            try
            {

                SetConnection();
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
                string CommandText = "select branch.branchID AS 'branchID', branch.branchName AS 'BranchName', branch.dateAdded DateAdded, users.userName AddedBy from branch LEFT JOIN users on users.userID = branch.addedBy";
                SQLiteDataAdapter cmdBranch = new SQLiteDataAdapter(CommandText, sql_con);
                DataTable brachDataTable = new DataTable();
                cmdBranch.Fill(brachDataTable);
                grdBranchNames.Rows.Clear();
                grdBranchNames.ColumnCount = 4;
                grdBranchNames.ColumnHeadersVisible = true;

                grdBranchNames.Columns[0].Name = "Brach ID";
                grdBranchNames.Columns[1].Name = "Branch Name";
                grdBranchNames.Columns[2].Name = "Date Added";
                grdBranchNames.Columns[3].Name = "Added By";

                grdBranchNames.Columns[0].Visible = false;
                foreach (DataRow item in brachDataTable.Rows)
                {

                    int n = grdBranchNames.Rows.Add();
                    grdBranchNames.Rows[n].Cells[0].Value = item["branchID"].ToString();
                    grdBranchNames.Rows[n].Cells[1].Value = item["BranchName"].ToString();
                    grdBranchNames.Rows[n].Cells[2].Value = item["AddedBy"].ToString();
                    grdBranchNames.Rows[n].Cells[3].Value = Convert.ToDateTime(item["DateAdded"].ToString()).ToString("d");
                }
                this.grdBranchNames.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                sql_con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an Error .. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void grdBranchNames_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Console.Beep();
                SetConnection();
                sql_con.Open();
                string query = "Delete from branch where branchID = @ID";
                SQLiteCommand comm = new SQLiteCommand(query, sql_con);
                comm.Parameters.AddWithValue("@ID", grdBranchNames.SelectedRows[0].Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Do you really want to delete the User \"" + grdBranchNames.SelectedRows[0].Cells[2].Value.ToString() + "\"?", "Confirm User deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {

                    int qSuccess = comm.ExecuteNonQuery();
                    MessageBox.Show("Branch Deleted Sucessfully", "Branch Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadBranchName();
                    txt_branchName.Focus();
                }
                if (result == DialogResult.No)
                {
                    txt_branchName.Focus();
                }

                sql_con.Close();
            }
        }

        private void grdBranchNames_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int branchID = Int32.Parse(grdBranchNames.SelectedRows[0].Cells[0].Value.ToString());
            editBranch frmEditBranch = new editBranch(branchID, this);
            frmEditBranch.MdiParent = this.MdiParent;
            frmEditBranch.Show();
        }
    }
}
