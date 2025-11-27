using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAN_QuanLyBaiHat
{
    public class DatabaseConnection
    {
        // SỬA LẠI DÒNG NÀY: Điền Password=1234 vào
        private static string strConn = "Server=localhost;" +
            "Database=qlbaihat;" +
            "User=root;" +
            "Password=1234;" +  // <-- QUAN TRỌNG: Phải có 1234 ở đây
            "Charset=utf8;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(strConn);
        }
    }
}