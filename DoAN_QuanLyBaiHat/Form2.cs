using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DoAN_QuanLyBaiHat
{
    public partial class Form2 : Form
    {
        string connectionString = "Server=localhost;Database=qlBaiHat;Uid=root;Pwd=123456;";
        public Form2()
        {
            InitializeComponent();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string nickname = txtName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (nickname == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập tên và mật khẩu!", "Cảnh báo");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Câu lệnh tìm người dùng có tên và mật khẩu khớp
                    string query = "SELECT Role FROM TaiKhoan WHERE NickName = @nick AND Hash_PassWord = @pass";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nick", nickname);
                    cmd.Parameters.AddWithValue("@pass", password);

                    // ExecuteScalar lấy về giá trị đầu tiên (ở đây là Role)
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string role = result.ToString();
                        MessageBox.Show($"Đăng nhập thành công! Bạn là: {role}", "Chào mừng");

                        // Tại đây bạn sẽ viết code mở Form chính
                        // Ví dụ:
                        // FormTrangChu f = new FormTrangChu();
                        // f.Show();
                        // this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
}
