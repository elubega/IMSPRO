using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Drawing.Printing;
using CrystalDecisions.CrystalReports.Engine;

namespace IMSPRO
{
    public partial class reportsProducts : Form
    {
        List<OrdersReport> _list;
        reportOrderInfo _ordersInfo;

        public reportsProducts(reportOrderInfo orders, List<OrdersReport> list)
        {
            InitializeComponent();
            _list = list;
            _ordersInfo = orders;
        }

        private void reportsProducts_Load(object sender, EventArgs e)
        {
            var dialog = new PrintDialog();
            productsList1.SetDataSource(_list);
            productsList1.SetParameterValue("gCustomerName", _ordersInfo.customerName);
            productsList1.SetParameterValue("gShopName", _ordersInfo.branch);
            productsList1.SetParameterValue("gTelNo", _ordersInfo.customerPhone);
            productsList1.SetParameterValue("gRecieptNo", _ordersInfo.orderNo);
            productsList1.SetParameterValue("gDate", _ordersInfo.dateOrdered.ToString("MM/dd/yyyy"));

            
            crystalReportViewer1.ReportSource = productsList1;
            crystalReportViewer1.Refresh();
            /*
            productsList1.PrintToPrinter(1, false, 0, 0);
            */
        }

        private void btn_PrintReport_Click(object sender, EventArgs e)
        {
            PrinterSettings printerSettings = new PrinterSettings();
            PrintDialog printDialog = new PrintDialog();
            printDialog.PrinterSettings = printerSettings;
            printDialog.AllowPrintToFile = false;
            printDialog.AllowSomePages = true;
            printDialog.UseEXDialog = true;

            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                return;
            }

            this.productsList1.PrintOptions.PrinterName = printerSettings.PrinterName;
            this.productsList1.PrintToPrinter(printerSettings.Copies, false, 0, 0);
            this.Close();
        }
    }
}
