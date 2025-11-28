using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace DoAN_QuanLyBaiHat
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
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

            // 1. Mã hóa mật khẩu
            string passwordHash = GetMD5(password);

            // 2. Kết nối và kiểm tra
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Lấy Role từ database dựa trên tên và pass
                    string query = "SELECT Role FROM TaiKhoan WHERE NickName = @nick AND Hash_PassWord = @pass";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nick", nickname);
                    cmd.Parameters.AddWithValue("@pass", passwordHash);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string role = result.ToString();
                        MessageBox.Show($"Đăng nhập thành công! Vai trò: {role}", "Chào mừng");

                      

                        // Kiểm tra Role để mở Form tương ứng
                        if (role == "User")
                        {
                            User f = new User();
                            f.Show();
                        }
                        else
                        {
                           
                            Form1 f = new Form1();
                            f.Show();
                        }

                       this.Hide();

                       
                    }
                    else
                    {
                        MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }

        // Hàm mã hóa MD5
        public string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            StringBuilder byte2String = new StringBuilder();

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String.Append(targetData[i].ToString("x2"));
            }
            return byte2String.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FormDangKy frm = new FormDangKy();
            frm.ShowDialog();
            this.Show();
        }

        private void FormDangNhap_Load(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}