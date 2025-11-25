using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Dùng thư viện MySQL

namespace DoAN_QuanLyBaiHat
{
    public partial class Form1 : Form
    {
        // Khai báo biến toàn cục (Giống mẫu PDF của bạn)
        DataSet ds = new DataSet();
        MySqlDataAdapter daBaiHat;

        // Trạng thái hành động: 1=Thêm, 2=Sửa, 0=Không làm gì
        int flagMode = 0;

        public Form1()
        {
            InitializeComponent();
        }

        // --- 1. HÀM CHUYỂN ĐỔI GIAO DIỆN (QUAN TRỌNG NHẤT) ---
        // true = Hiện khung nhập (ẩn lưới), false = Hiện lưới (ẩn khung nhập)
        void HienKhungNhap(bool hien)
        {
            pnlNhapLieu.Visible = hien;   // Panel nhập liệu
            pnlDanhSach.Visible = !hien;  // Panel danh sách (Ngược lại)

            // Nếu hiện khung nhập thì xóa trắng các ô
            if (hien)
            {
               txtTenBaiHat.Clear();
                txtTheLoai.Clear();
                richLoiNhac.Clear();
                dtpNgayDang.Value = DateTime.Now;
                txtDuongDan.Clear();
            }
        }

        // --- 2. LOAD FORM VÀ DỮ LIỆU ---
        private void Form1_Load(object sender, EventArgs e)
        {
            HienKhungNhap(false); // Mặc định hiện danh sách
            LoadData();
        }

        void LoadData()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    // Lấy dữ liệu (Giống mẫu PDF)
                    string sql = "SELECT * FROM BaiHat";
                    daBaiHat = new MySqlDataAdapter(sql, conn);

                    // Tự động tạo lệnh Insert/Update/Delete (Thay thế cho đoạn code InsertCommand dài dòng)
                    MySqlCommandBuilder builder = new MySqlCommandBuilder(daBaiHat);

                    ds.Clear();
                    daBaiHat.Fill(ds, "tblBaiHat");
                    dgvBaiHat.DataSource = ds.Tables["tblBaiHat"];
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        // --- 3. CÁC NÚT Ở MÀN HÌNH DANH SÁCH ---

        private void btnThem_Click(object sender, EventArgs e)
        {
            flagMode = 1; // Đánh dấu là đang THÊM
            HienKhungNhap(true); // <--- Ẩn lưới, hiện khung nhập
            txtTenBaiHat.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvBaiHat.CurrentRow == null) return;

            flagMode = 2; // Đánh dấu là đang SỬA

            // Đổ dữ liệu cũ lên ô nhập trước khi hiện
            DataGridViewRow row = dgvBaiHat.CurrentRow;
            txtTenBaiHat.Text = row.Cells["Ten_Bai_Hat"].Value.ToString();
            txtTheLoai.Text = row.Cells["The_Loai"].Value.ToString();
            richLoiNhac.Text = row.Cells["Lyrics"].Value.ToString();
            // ... (các trường khác)

            HienKhungNhap(true); // <--- Ẩn lưới, hiện khung nhập
        }

        // --- 4. CÁC NÚT Ở MÀN HÌNH NHẬP LIỆU (Panel Nhập) ---

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra rỗng
            if (txtTenBaiHat.Text == "") { MessageBox.Show("Nhập tên bài hát!"); return; }

            // 2. Xử lý dữ liệu trên DataSet (Bộ nhớ tạm)
            DataRow row;
            if (flagMode == 1) // Đang THÊM
            {
                row = ds.Tables["tblBaiHat"].NewRow();
                GanDuLieu(row);
                ds.Tables["tblBaiHat"].Rows.Add(row);
            }
            else if (flagMode == 2) // Đang SỬA
            {
                int index = dgvBaiHat.CurrentRow.Index;
                row = ds.Tables["tblBaiHat"].Rows[index];
                GanDuLieu(row);
            }

            // 3. Cập nhật xuống CSDL (PHẦN QUAN TRỌNG ĐÃ SỬA)
            try
            {
                // Tạo kết nối mới tinh
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open(); // Mở cổng

                    // Gán kết nối mới này cho Adapter cũ
                    daBaiHat.SelectCommand.Connection = conn;

                    // Yêu cầu CommandBuilder tạo lại lệnh Lưu dựa trên kết nối mới
                    MySqlCommandBuilder builder = new MySqlCommandBuilder(daBaiHat);

                    // Thực hiện Lưu
                    daBaiHat.Update(ds, "tblBaiHat");
                    MessageBox.Show("Đã lưu thành công!");

                    // Tải lại dữ liệu để cập nhật ID mới nhất (quan trọng khi thêm mới)
                    ds.Clear();
                    daBaiHat.Fill(ds, "tblBaiHat");

                    HienKhungNhap(false); // Ẩn khung nhập, hiện lại lưới
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu: " + ex.Message);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ds.RejectChanges(); // Hủy bỏ thay đổi tạm
            HienKhungNhap(false); // <--- Quay về màn hình danh sách
        }

        // Hàm phụ trợ để gán dữ liệu cho gọn code
        void GanDuLieu(DataRow row)
        {
            row["Ten_Bai_Hat"] = txtTenBaiHat.Text;
            row["The_Loai"] = txtTheLoai.Text;
            row["Ngay_Dang"] = dtpNgayDang.Value;
            row["Lyrics"] = richLoiNhac.Text;
            row["DuongDan"] = txtDuongDan.Text;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnChonNhac_Click(object sender, EventArgs e)
        {
            
            // 1. Khởi tạo hộp thoại mở file
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // 2. Thiết lập bộ lọc CHỈ LẤY MP3 (Quan trọng)
            openFileDialog.Filter = "MP3 Files (*.mp3)|*.mp3|All Files (*.*)|*.*";
            openFileDialog.Title = "Chọn một file nhạc";

            // 3. Hiển thị hộp thoại và kiểm tra nếu người dùng bấm OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 4. Lấy đường dẫn file và gán vào TextBox
                txtDuongDan.Text = openFileDialog.FileName;
            }
        
    }
    }
}