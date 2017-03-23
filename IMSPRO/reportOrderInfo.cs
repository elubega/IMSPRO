using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace IMSPRO
{
    public class reportOrderInfo
    {
        public string orderNo { get; set; }
        public string branch { get; set; }
        public string customerName { get; set; }
        public string customerPhone { get; set; }
        public DateTime dateOrdered { get; set; }
    }
}
