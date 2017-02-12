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
    public partial class editeUser : Form
    {
       private userManagement userManagementForm;
        public int userIDNew = 0;
        public editeUser(int UserID, userManagement owner)
        {
            
            InitializeComponent();
            userIDNew = UserID;
            loadUsersInTextBox();
            txt_password.Enabled = (chk_Password.CheckState == CheckState.Checked);

            userManagementForm = owner;
        }
        


        private void btn_edit_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
            conn.Open();
            string query = "UPDATE users SET userName=@username, password=@password, firstName=@fName, lastName=@lName, level=@level, phone=@phone where userID=@userID";
            SQLiteCommand comm = new SQLiteCommand(query, conn);
            comm.Parameters.AddWithValue("@username", txt_username.Text);
            comm.Parameters.AddWithValue("@password", txt_password.Text);
            comm.Parameters.AddWithValue("@fName", txt_firstName.Text);
            comm.Parameters.AddWithValue("@lName", txt_lastName.Text);
            comm.Parameters.AddWithValue("@level", cbm_level.SelectedItem);
            comm.Parameters.AddWithValue("@phone", txt_phone.Text);
            comm.Parameters.AddWithValue("@userID", userIDNew);
            int confirmAction = comm.ExecuteNonQuery();
            if (confirmAction == 1)
            {
                MessageBox.Show("User has been updated successfully ", "User Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                userManagementForm.loadUsers();
                this.Close();
            }
        }
        private void loadUsersInTextBox()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
            conn.Open();
            string query = "Select userName, password, firstName, lastName, level, phone from users where userID=@userID";
            SQLiteCommand comm = new SQLiteCommand(query, conn);
            comm.Parameters.AddWithValue("@userID", userIDNew);
            SQLiteDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                txt_username.Text = reader["userName"].ToString();
                txt_password.Text = reader["password"].ToString();
                txt_firstName.Text = reader["firstName"].ToString();
                txt_lastName.Text = reader["lastName"].ToString();
                cbm_level.SelectedItem = reader["level"].ToString();
                txt_phone.Text = reader["phone"].ToString();
            }
            conn.Close();
        }
       



        private void chk_Password_CheckStateChanged(object sender, EventArgs e)
        {
            txt_password.Enabled = (chk_Password.CheckState == CheckState.Checked);
        }

        private void editeUser_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
