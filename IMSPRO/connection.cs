using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace IMSPRO
{
    class connection
    {
        public SQLiteConnection sqlCon;
        private void SetConnection()
        {
            sqlCon = new SQLiteConnection
                ("Data Source=ismpro_db.sqlite;Version=3;New=False;Compress=True;");
        }
    }
}
