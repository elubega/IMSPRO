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
    public partial class ViewReport : Form
    {
        public ViewReport()
        {
            InitializeComponent();
        }

        private void btn_LoadReport_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
            conn.Open();
            string CommandText = @"select C.orderCustomerID AS orderID, C.orderNo AS orderNo, A.branchName AS branch,C.CustomerName AS CustomerName," +
                                            "C.CustomerPhone AS CustomerPhone,C.DateOrdered AS dateOrdered,B.firstName AS firstName, B.lastName AS lastName " +
                                            $"from orderCustomers C left join branch A on A.branchID=C.BranchID left join users B on B.userID=C.OrderedBy";
            SQLiteDataAdapter pdtList = new SQLiteDataAdapter(CommandText, conn);
            DataTable table = new DataTable();
            pdtList.Fill(table);

            reportViewCustomers.DataSource = table;
        }

        public reportOrderInfo obj;

        private void btn_ViewReport_Click(object sender, EventArgs e)
        {
            //var currentObject = reportViewCustomers.CurrentRow.DataBoundItem as reportOrderInfo;
            
            foreach (DataGridViewRow row in reportViewCustomers.SelectedRows)
            {
                obj = row.DataBoundItem as reportOrderInfo;
                List<OrdersReport> list = new List<OrdersReport>();

           if (obj != null)
            {
                try
                {
                    SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
                    conn.Open();
                    SQLiteCommand Command = conn.CreateCommand();
                    Command.CommandText = @"select A.productName as productName, A.qty as qty, A.measure as measure, A.price as price from completedordersDetails A left join orderCustomers B on B.orderNo=A.orderNo";
                    Command.CommandType = CommandType.Text;

                    SQLiteDataReader r = Command.ExecuteReader();
                    while (r.Read())
                    {
                    var person = new OrdersReport();
                    person.productName = Convert.ToString(r["productName"]);
                    person.measure = Convert.ToString(r["measure"]);
                    person.price = Convert.ToInt32(r["price"]);
                    person.qty = Convert.ToInt32(r["qty"]);
                    list.Add(person);
                    }

                using (reportsProducts frmReports = new reportsProducts(obj, list))
                {
                    frmReports.ShowDialog();
                }
                }
                catch (Exception ex)
                {

               
          
                        MessageBox.Show("Error"+ ex);
                   
                }

                 }
                else
                {
                    MessageBox.Show("Error Can't Pick Selected Values");
                }
            }
        }
    }
}
