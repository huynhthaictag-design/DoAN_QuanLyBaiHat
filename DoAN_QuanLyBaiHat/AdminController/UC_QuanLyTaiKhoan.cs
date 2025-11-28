using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DoAN_QuanLyBaiHat.AdminController
{
    public partial class UC_QuanLyTaiKhoan : UserControl
    {
        public UC_QuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void UC_QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // --- 1. TẢI DANH SÁCH TÀI KHOẢN ---
        private void LoadData()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Chỉ lấy các cột cần thiết, KHÔNG lấy mật khẩu để bảo mật
                    string sql = "SELECT Id, NickName, Email, Role FROM TaiKhoan";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvTaiKhoan.DataSource = dt;

                    // Trang trí cột cho đẹp
                    if (dgvTaiKhoan.Columns.Contains("Id")) dgvTaiKhoan.Columns["Id"].Width = 50;
                    if (dgvTaiKhoan.Columns.Contains("NickName")) dgvTaiKhoan.Columns["NickName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // --- 2. HÀM DÙNG CHUNG ĐỂ CẬP NHẬT ROLE (QUYỀN) ---
        private void CapNhatQuyen(string newRole)
        {
            if (dgvTaiKhoan.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản!");
                return;
            }

            string id = dgvTaiKhoan.CurrentRow.Cells["Id"].Value.ToString();
            string nickName = dgvTaiKhoan.CurrentRow.Cells["NickName"].Value.ToString();

            if (MessageBox.Show($"Bạn muốn đổi quyền của '{nickName}' thành '{newRole}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "UPDATE TaiKhoan SET Role = @Role WHERE Id = @Id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Role", newRole);
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Đã cập nhật '{nickName}' thành {newRole}!");
                    LoadData();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // --- 3. NÚT NÂNG LÊN ADMIN ---
        private void btnNangQuyen_Click(object sender, EventArgs e)
        {
            CapNhatQuyen("admin");
        }

        // --- 4. NÚT HẠ XUỐNG USER ---
        private void btnHaQuyen_Click(object sender, EventArgs e)
        {
            // Kiểm tra: Không cho phép tự hạ quyền chính mình (nếu bạn có lưu ID đăng nhập)
            // Tạm thời chỉ cảnh báo chung
            CapNhatQuyen("user");
        }

        // --- 5. NÚT XÓA TÀI KHOẢN ---
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTaiKhoan.CurrentRow == null) return;

            string id = dgvTaiKhoan.CurrentRow.Cells["Id"].Value.ToString();
            string role = dgvTaiKhoan.CurrentRow.Cells["Role"].Value.ToString();

            // Cảnh báo nếu xóa Admin
            if (role == "admin")
            {
                if (MessageBox.Show("CẢNH BÁO: Bạn đang xóa một tài khoản ADMIN. Điều này rất nguy hiểm!\nBạn có chắc chắn không?", "Cảnh báo đỏ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;
            }
            else
            {
                if (MessageBox.Show("Bạn muốn xóa tài khoản này vĩnh viễn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Xóa tài khoản (Lưu ý: Do có khóa ngoại, các Playlist của user này cũng sẽ bị xóa theo nếu DB thiết lập ON DELETE CASCADE)
                    string sql = "DELETE FROM TaiKhoan WHERE Id = @Id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã xóa tài khoản!");
                    LoadData();
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi xóa: " + ex.Message); }
        }

       
       
    }
}