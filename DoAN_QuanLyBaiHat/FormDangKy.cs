using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography; // Thư viện mã hóa
using MySql.Data.MySqlClient;       // Thư viện MySQL

namespace DoAN_QuanLyBaiHat
{
    public partial class FormDangKy : Form
    {
        public FormDangKy()
        {
            InitializeComponent();
        }

        private void FormDangKy_Load(object sender, EventArgs e)
        {
            // Để trống hoặc thêm code khởi tạo nếu cần
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra nhập liệu
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) ||
                string.IsNullOrWhiteSpace(txtMatKhau.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtMatKhau.Text != txtNhapLaiMatKhau.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Mã hóa mật khẩu trước khi lưu (Để giống với lúc Đăng nhập)
            string passwordHash = GetMD5(txtMatKhau.Text);

            // 3. Kết nối CSDL và Lưu
            // Sử dụng class chung DatabaseConnection thay vì viết cứng chuỗi kết nối
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Kiểm tra xem tên đăng nhập đã tồn tại chưa (Tùy chọn, giúp báo lỗi rõ hơn)
                    string checkSql = "SELECT COUNT(*) FROM TaiKhoan WHERE NickName = @NickName";
                    MySqlCommand checkCmd = new MySqlCommand(checkSql, conn);
                    checkCmd.Parameters.AddWithValue("@NickName", txtTenDangNhap.Text);
                    int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Tên đăng nhập này đã có người sử dụng!", "Trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Thực hiện Insert
                    string sql = "INSERT INTO TaiKhoan (Email, NickName, Hash_PassWord, Role) VALUES (@Email, @NickName, @Pass, @Role)";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                        cmd.Parameters.AddWithValue("@NickName", txtTenDangNhap.Text);
                        cmd.Parameters.AddWithValue("@Pass", passwordHash); // Lưu pass đã mã hóa
                        cmd.Parameters.AddWithValue("@Role", "User");       // Mặc định là User

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Đăng ký thành công! Bạn có thể đăng nhập ngay bây giờ.", "Thông báo");
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối hoặc đăng ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- HÀM MÃ HÓA MD5 (Bắt buộc phải giống hệt bên FormDangNhap) ---
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

        // Nút chuyển sang đăng nhập (nếu user lỡ bấm vào form đăng ký)
        private void lkDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormDangNhap dn = new FormDangNhap();
            dn.ShowDialog();
        }
    }
}