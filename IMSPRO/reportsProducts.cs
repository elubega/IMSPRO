using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            productsList1.SetDataSource(_list);
           // productsList1.SetParameterValue("gCustomerName", _ordersInfo.customerName);
           // productsList1.SetParameterValue("gShopName", _ordersInfo.branch);
           // productsList1.SetParameterValue("gTelNo", _ordersInfo.customerPhone);
           // productsList1.SetParameterValue("gRecieptNo", _ordersInfo.orderNo);
           // productsList1.SetParameterValue("gDate", _ordersInfo.dateOrdered.ToString("MM/dd/yyyy"));
            crystalReportViewer1.ReportSource = productsList1;
            crystalReportViewer1.Refresh();
        }
    }
}
