using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSPRO
{
    public class OrdersReport
    {
        public string productName { get; set; }
        public int qty { get; set; }
        public string measure { get; set; }
        public int price { get; set; }
        public int total
        {
            get
            {
                return qty * price;
            }
        }
    }
}
