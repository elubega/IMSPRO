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
            catch(Exception ex)
            {
                MessageBox.Show("There is an Error .. "+ ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadBranchName()
        {
            try
            {
                SetConnection();
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
                string CommandText = "select branch.branchName AS 'Branch Name', branch.dateAdded AS 'Date Estabulished', users.userName As 'Added By' from branch LEFT JOIN users on users.userID = branch.addedBy";
                DB = new SQLiteDataAdapter(CommandText, sql_con);
                DS.Reset();
                DB.Fill(DS);
                DT = DS.Tables[0];
                grdBranchNames.DataSource = DT;
                sql_con.Close();

                this.grdBranchNames.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }catch(Exception ex)
            {
                MessageBox.Show("There is an Error .. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
