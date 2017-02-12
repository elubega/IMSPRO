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
    public partial class userManagement : Form
    {
        public userManagement()
        {
            InitializeComponent();
            loadUsers();
        }
        private void SetConnection()
        {
            sql_con = new SQLiteConnection
                ("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
        }
        //decearing variables for the connection
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();


        private void clearEntryForm()
        {
            txt_userName.Clear();
            txt_password.Clear();
            txt_firstName.Clear();
            txt_lastName.Clear();
            txt_phone.Clear();
            cbm_level.SelectedIndex = -1;
            txt_userName.Focus();
        }


        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                SetConnection();
                sql_con.Open();
                string query = "Insert into users(userName, password, firstName, lastName, level, dateCreated, phone)";
                query += "values(@userName,@password,@firstName,@lastName,@level,@dateCreated, @phone)";

            SQLiteCommand myCommand = new SQLiteCommand(query, sql_con);
            myCommand.Parameters.AddWithValue("@userName", txt_userName.Text);
            myCommand.Parameters.AddWithValue("@password", txt_password.Text);
            myCommand.Parameters.AddWithValue("@firstName", txt_firstName.Text);
            myCommand.Parameters.AddWithValue("@lastName", txt_lastName.Text);
            myCommand.Parameters.AddWithValue("@level", cbm_level.SelectedItem);
            myCommand.Parameters.AddWithValue("@dateCreated", DateTime.Now.ToString("yyyy-MM-dd"));
            myCommand.Parameters.AddWithValue("@phone", txt_phone.Text);

                int qSuccess = myCommand.ExecuteNonQuery();

            sql_con.Close();
            if (qSuccess == 1)
                {

                MessageBox.Show("User has been added", "Success.....!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadUsers();
                clearEntryForm();


                }
               
            }
           catch(Exception ex)
            {
                MessageBox.Show("There is an Error..."+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public void loadUsers()
        {
            try
            {
                SetConnection();
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
                string CommandText = "select userID, userName, firstName, lastName, phone, level, dateCreated from users";
                SQLiteDataAdapter DB = new SQLiteDataAdapter(CommandText, sql_con);
                
                DataTable userDataTable = new DataTable();
                DB.Fill(userDataTable);
                grdUserMgt.Rows.Clear();
                grdUserMgt.ColumnCount = 7;
                grdUserMgt.ColumnHeadersVisible = true;

                //DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

                //columnHeaderStyle.BackColor = Color.Beige;
                //columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
               //grdUserMgt.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

                grdUserMgt.Columns[0].Name = "ID";
                grdUserMgt.Columns[1].Name = "Username";
                grdUserMgt.Columns[2].Name = "First Name";
                grdUserMgt.Columns[3].Name = "Last Name";
                grdUserMgt.Columns[4].Name = "Phone No.:";
                grdUserMgt.Columns[5].Name = "Level";
                grdUserMgt.Columns[6].Name = "Account Open";

                this.grdUserMgt.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grdUserMgt.Columns[0].Visible = false;
                foreach (DataRow item in userDataTable.Rows)
                {
                    
                    int n = grdUserMgt.Rows.Add();
                    grdUserMgt.Rows[n].Cells[0].Value = item["userID"].ToString();
                    grdUserMgt.Rows[n].Cells[1].Value = item["userName"].ToString();
                    grdUserMgt.Rows[n].Cells[2].Value = item["firstName"].ToString();
                    grdUserMgt.Rows[n].Cells[3].Value = item["lastName"].ToString();
                    grdUserMgt.Rows[n].Cells[4].Value = item["phone"].ToString();
                    grdUserMgt.Rows[n].Cells[5].Value = item["level"].ToString();
                    grdUserMgt.Rows[n].Cells[6].Value = Convert.ToDateTime( item["dateCreated"].ToString()).ToString("d");
                }
                
                sql_con.Close();

                
            }
            catch(Exception e)
            {
                MessageBox.Show("Error in connection ..." + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btn_clear_Click(object sender, EventArgs e)
        {
            clearEntryForm();
        }


        private void grdUserMgt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Console.Beep();
                SetConnection();
                sql_con.Open();
                string query = "Delete from users where userID = @ID";
                SQLiteCommand comm = new SQLiteCommand(query, sql_con);
                comm.Parameters.AddWithValue("@ID", grdUserMgt.SelectedRows[0].Cells[0].Value.ToString());
                DialogResult result = MessageBox.Show("Do you really want to delete the User \"" + grdUserMgt.SelectedRows[0].Cells[3].Value.ToString() + "\"?", "Confirm User deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {

                    int qSuccess = comm.ExecuteNonQuery();
                    MessageBox.Show("User Deleted Sucessfully", "User Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadUsers();
                    clearEntryForm();
                }
                if (result == DialogResult.No)
                {
                    clearEntryForm();
                }

                sql_con.Close();
            }
        }

        private void grdUserMgt_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int userID = Int32.Parse(grdUserMgt.SelectedRows[0].Cells[0].Value.ToString());
            editeUser editUserFrame = new editeUser(userID, this);
            editUserFrame.MdiParent = this.ParentForm;
            editUserFrame.Show();
        }
    }
}
