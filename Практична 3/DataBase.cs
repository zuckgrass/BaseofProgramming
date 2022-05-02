using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Prac3
{
    public class DataBase
    {
        SqlConnection Connection =new SqlConnection(@"Data Source=ALLIF\SQLEXPRESS; initial Catalog=Prac3; Integrated Security=True");
        public void Open()
        {
            if (Connection.State == System.Data.ConnectionState.Closed)
            {
                Connection.Open();
            }
        }
        public void Close()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                Connection.Close();
            }
        }
        public SqlConnection GetConnection()
        {
            return Connection;
        }
    }
}
