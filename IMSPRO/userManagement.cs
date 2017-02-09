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
        
        private void loadUsers()
        {
            try
            {
                SetConnection();
                sql_con.Open();
                sql_cmd = sql_con.CreateCommand();
                string CommandText = "select userName AS 'Username', firstName AS 'First Name', lastName AS 'Last Name', phone AS 'Phone No.:', level As 'Level', dateCreated As 'Account Open' from users";
                DB = new SQLiteDataAdapter(CommandText, sql_con);
                DS.Reset();
                DB.Fill(DS);
                DT = DS.Tables[0];
                grdUserMgt.DataSource = DT;
                sql_con.Close();

                this.grdUserMgt.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void button1_Click(object sender, EventArgs e)
        {
            editeUser editUserFrame = new editeUser();
            editUserFrame.MdiParent = this.ParentForm;
            editUserFrame.Show();
        }
    }
}
