using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace DoAN_QuanLyBaiHat
{
    
    public class DatabaseConnection
    {
  
        private static string strConn = "Server=localhost;" +
            "Database=qlbaihat;" +
            "User=root;" +
            "Password=1234;" +
            "Charset=utf8;";
        // Thêm Charset=utf8 vào cuối
     

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(strConn);
        }
    }
}
