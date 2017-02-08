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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
            cbm_level.SelectedIndex = 2;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
            con.Open();
            SQLiteDataAdapter sda = new SQLiteDataAdapter(@"select userID, userName, password, level 
            from users where username='" + txt_username.Text+"' and password='"+txt_password.Text+"' and level='"+cbm_level.Text+"'", con);
            DataTable userDT = new DataTable();
            sda.Fill(userDT);

            string result;
            string query = @"select userID from users where username = 
            '" + txt_username.Text+"' and password = '"+txt_password.Text+"' and level = '"+cbm_level.Text+"'";
            SQLiteCommand cmd = new SQLiteCommand( );
           
            cmd = con.CreateCommand();
            cmd.CommandText = query;  //set the passed query
            result = cmd.ExecuteScalar().ToString();

            //checks to see if you are Manager and loads the Managers Interface
            if (userDT.Rows.Count ==1 && cbm_level.Text=="Manager"){
                this.Hide();
                console hc = new console(txt_username.Text, result);
                hc.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password or Level","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                btn_cancel_Click(sender, e);
            }
            con.Close();
            
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();
            cbm_level.SelectedIndex = -1;
            txt_username.Focus();
            
        }

        
    }
}
