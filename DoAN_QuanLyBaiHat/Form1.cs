using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Thư viện MySQL
using DoAN_QuanLyBaiHat.UserControls; // Đảm bảo dòng này có để nhận diện UC

namespace DoAN_QuanLyBaiHat
{
    public partial class Form1 : Form
    {
        // Khai báo biến toàn cục để quản lý dữ liệu
        DataSet ds = new DataSet();
        MySqlDataAdapter daBaiHat;

        public Form1()
        {
            InitializeComponent();
        }

        // --- 1. SỰ KIỆN LOAD FORM ---
        private void Form1_Load(object sender, EventArgs e)
        {
            // Khi mở form, tải dữ liệu lên lưới ngay
            LoadData();
        }

        // --- 2. HÀM TẢI DỮ LIỆU TỪ MYSQL ---
        void LoadData()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT * FROM BaiHat";
                    daBaiHat = new MySqlDataAdapter(sql, conn);

                    // Tự động tạo lệnh Insert/Update/Delete
                    MySqlCommandBuilder builder = new MySqlCommandBuilder(daBaiHat);

                    ds.Clear();
                    daBaiHat.Fill(ds, "tblBaiHat");
                    dgvBaiHat.DataSource = ds.Tables["tblBaiHat"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message);
            }
        }

        // --- 3. HÀM GỌI USER CONT--
        private void HienThiUC_ThemBaiHat(int mode, DataGridViewRow rowData = null)
        {
            // A. Ẩn Panel danh sách đi
            pnlDanhSach.Visible = false;

            // B. Tạo mới UserControl
            UC_ThemBaiHat uc = new UC_ThemBaiHat();

          
            uc.Dock = DockStyle.Fill;  
            uc.Visible = true;         // Bắt buộc hiện


            tabBaiHat.Controls.Add(uc);
            uc.BringToFront(); // Đưa lên trên cùng

            // Ẩn cái pnlDanhSach đi để chắc chắn không bị đè
            pnlDanhSach.Visible = false;
            if (mode == 1) // Thêm mới
            {
                // Truyền dữ liệu rỗng
                uc.SetData(1, "", "", "", DateTime.Now, "", "");
            }
            else if (mode == 2 && rowData != null) // Sửa
            {
                // Lấy dữ liệu từ dòng đang chọn truyền sang
                string id = rowData.Cells["Bai_Hat_Id"].Value.ToString();
                string ten = rowData.Cells["Ten_Bai_Hat"].Value.ToString();
                string tl = rowData.Cells["The_Loai"].Value.ToString();
                string loi = rowData.Cells["Lyrics"].Value.ToString();
                string link = rowData.Cells["DuongDan"].Value.ToString();

                DateTime ngay = DateTime.Now;
                if (rowData.Cells["Ngay_Dang"].Value != DBNull.Value)
                {
                    ngay = Convert.ToDateTime(rowData.Cells["Ngay_Dang"].Value);
                }

                uc.SetData(2, id, ten, tl, ngay, loi, link);
            }

            // D. LẮNG NGHE SỰ KIỆN TỪ UC (QUAN TRỌNG NHẤT)

            // Khi người dùng bấm nút "Quay Lại" bên UC
            uc.OnHuy += (s, e) =>
            {
                pnlDanhSach.Visible = true; // Hiện lại danh sách
                tabBaiHat.Controls.Remove(uc); // Xóa UC đi cho nhẹ máy
            };

            // Khi người dùng bấm nút "Lưu" thành công bên UC
            uc.OnLuuThanhCong += (s, e) =>
            {
                pnlDanhSach.Visible = true; // Hiện lại danh sách
                tabBaiHat.Controls.Remove(uc); // Xóa UC
                LoadData(); // Tải lại dữ liệu mới nhất từ CSDL
            };

            // E. Thêm UC vào TabPage và đưa lên trên cùng
            tabBaiHat.Controls.Add(uc);
            uc.BringToFront();
        }

        // --- 4. CÁC NÚT CHỨC NĂNG (GỌI HÀM TRÊN) ---

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Gọi chế độ 1: Thêm
            HienThiUC_ThemBaiHat(1);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Gọi chế độ 2: Sửa (Kiểm tra xem có chọn dòng nào chưa)
            if (dgvBaiHat.CurrentRow != null)
            {
                HienThiUC_ThemBaiHat(2, dgvBaiHat.CurrentRow);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bài hát cần sửa!");
            }
        }

        // --- 5. NÚT XÓA (XỬ LÝ TRỰC TIẾP TẠI FORM 1) ---
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvBaiHat.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn bài hát cần xóa!");
                return;
            }

            DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    // Xóa dòng trên lưới (Dataset)
                    dgvBaiHat.Rows.RemoveAt(dgvBaiHat.CurrentRow.Index);

                    // Cập nhật xuống CSDL
                    using (MySqlConnection conn = DatabaseConnection.GetConnection())
                    {
                        conn.Open();
                        daBaiHat.SelectCommand.Connection = conn;
                        MySqlCommandBuilder builder = new MySqlCommandBuilder(daBaiHat);
                        daBaiHat.Update(ds, "tblBaiHat");
                    }

                    MessageBox.Show("Đã xóa thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa: " + ex.Message);
                    LoadData(); // Tải lại nếu lỗi để hồi phục dữ liệu
                }
            }
        }

    
    }
}