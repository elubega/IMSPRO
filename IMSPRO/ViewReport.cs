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
using Dapper;
using CrystalDecisions.CrystalReports.Engine;

namespace IMSPRO
{
    public partial class ViewReport : Form
    {
        public ViewReport()
        {
            InitializeComponent();
            showFullReport();
        }


        public void showFullReport()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
            conn.Open();
            string CommandText = @"select DISTINCT C.orderCustomerID AS orderID, C.orderNo AS orderNo, A.branchName AS branch,C.CustomerName AS CustomerName," +
                                            "C.CustomerPhone AS CustomerPhone,C.DateOrdered AS dateOrdered " +
                                            $"from orderCustomers C left join branch A on A.branchID=C.BranchID left join users B on B.userID=C.OrderedBy left join orders D on D.orderNo=C.orderNo where D.processedOrderStatus=1 order by C.DateOrdered";
            reportOrderInfoBindingSource.DataSource = conn.Query<reportOrderInfo>(CommandText, commandType: CommandType.Text);
        }
        private void btn_LoadReport_Click(object sender, EventArgs e)
        {

        }
        private void btn_ViewReport_Click(object sender, EventArgs e)
        {
            reportOrderInfo obj = reportOrderInfoBindingSource.Current as reportOrderInfo;
            if (obj != null)
            {
                try
                {
                    SQLiteConnection conn = new SQLiteConnection("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
                    conn.Open();
                    string CommandText = @"select A.productName as productName, A.qty as qty, A.measure as measure, A.price as price from completedordersDetails A left join orderCustomers B on B.orderNo=A.orderNo where A.orderNo='" + (obj.orderNo) + "'";
                    List<OrdersReport> list = conn.Query<OrdersReport>(CommandText, commandType: CommandType.Text).ToList();

                    //Load the Form to show the 
                    reportsProducts frmReports = new reportsProducts(obj, list);
                    frmReports.MdiParent = this.ParentForm;
                    frmReports.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }

            }
            else
            {
                MessageBox.Show("Error Can't Pick Selected Values");
            }
        }


    }
}
