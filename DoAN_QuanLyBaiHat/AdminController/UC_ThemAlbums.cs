using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic; // Để dùng List

namespace DoAN_QuanLyBaiHat.AdminController
{
    public partial class UC_ThemAlbums : UserControl
    {
       
            

        
            private int _flagMode = 1; 
            private string _idAlbumCanSua = "";

          
        
        public event EventHandler OnHuy;
        public event EventHandler OnLuuThanhCong;

        private string duongDanAnhLuuDB = ""; // Biến lưu đường dẫn ảnh để ghi vào DB

        public UC_ThemAlbums()
        {
            InitializeComponent();
        }

        // --- SỰ KIỆN LOAD FORM ---
        private void UC_ThemAlbums_Load(object sender, EventArgs e)
        {
            LoadComboBoxCaSi();
            LoadDanhSachBaiHat(); // Tải danh sách bài hát để chọn
            dtpNgayPhatHanh.Value = DateTime.Now;
        }

        // 1. Tải danh sách Ca Sĩ vào ComboBox
        private void LoadComboBoxCaSi()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string sql = "SELECT Cs_Id, TenCS FROM casi";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbbCaSi.DataSource = dt;
                    cbbCaSi.DisplayMember = "TenCS";
                    cbbCaSi.ValueMember = "Cs_Id";
                    cbbCaSi.SelectedIndex = -1;
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải Ca sĩ: " + ex.Message); }
        }

        public void SetData(int mode, string idAlbum, string tenAlbum, string idCaSi, DateTime ngayPhatHanh, string duongDanAnh)
        {
            _flagMode = mode;
            _idAlbumCanSua = idAlbum;

            // Load lại danh sách ca sĩ để đảm bảo có dữ liệu
            LoadComboBoxCaSi();

            if (mode == 2) // Chế độ Sửa
            {
                labelTitle.Text = "CẬP NHẬT ALBUM"; // Sửa tiêu đề (labelTitle là tên label chữ to ở trên cùng)
                txtTenAlbum.Text = tenAlbum;
                dtpNgayPhatHanh.Value = ngayPhatHanh;

                // Chọn đúng ca sĩ
                cbbCaSi.SelectedValue = idCaSi;

                // Hiển thị ảnh cũ (nếu có)
                if (!string.IsNullOrEmpty(duongDanAnh))
                {
                    string fullPath = Path.Combine(Application.StartupPath, duongDanAnh);
                    if (File.Exists(fullPath))
                    {
                        pbAnh.ImageLocation = fullPath;
                        duongDanAnhLuuDB = duongDanAnh; // Giữ lại đường dẫn cũ
                    }
                }

                btnLuu.Text = "Cập Nhật";
            }
            else // Chế độ Thêm
            {
                labelTitle.Text = "THÊM ALBUM";
                txtTenAlbum.Clear();
                cbbCaSi.SelectedIndex = -1;
                dtpNgayPhatHanh.Value = DateTime.Now;
                pbAnh.Image = null;
                btnLuu.Text = "Thêm Mới";
            }
        }
        private void LoadDanhSachBaiHat()
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                   
                    string sql = "SELECT Bai_Hat_Id, Ten_Bai_Hat FROM baihat";
                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                 
                    ((ListBox)clbBaiHat).DataSource = dt;
                    ((ListBox)clbBaiHat).DisplayMember = "Ten_Bai_Hat";
                    ((ListBox)clbBaiHat).ValueMember = "Bai_Hat_Id";
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải Bài hát: " + ex.Message); }
        }

    
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            open.Title = "Chọn ảnh bìa Album";

            if (open.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Tạo thư mục Images_Album nếu chưa có
                    string folderPath = Path.Combine(Application.StartupPath, "Images_Album");
                    if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

                    // Tạo tên file duy nhất
                    string fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_Alb" + Path.GetExtension(open.FileName);
                    string destPath = Path.Combine(folderPath, fileName);

                    // Copy file
                    File.Copy(open.FileName, destPath, true);

                    // Hiển thị và lưu đường dẫn
                    pbAnh.ImageLocation = destPath;
                    duongDanAnhLuuDB = Path.Combine("Images_Album", fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi chọn ảnh: " + ex.Message);
                }
            }
        }


        private void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra nhập liệu
            if (txtTenAlbum.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên Album!");
                return;
            }
            if (cbbCaSi.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Ca sĩ!");
                return;
            }

            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                MySqlTransaction tran = conn.BeginTransaction(); // Bắt đầu giao dịch

                try
                {
                    int idAlbumXuLy = 0; // Biến này để lưu ID (dù là Thêm mới hay Sửa)

                    // --- TRƯỜNG HỢP 1: THÊM MỚI ---
                    if (_flagMode == 1)
                    {
                        string sqlInsert = "INSERT INTO albums (Ten_Ab, Cs_Id, Ngay_Dang, AnhAlbum) VALUES (@Ten, @IdCS, @Ngay, @Anh); SELECT LAST_INSERT_ID();";
                        MySqlCommand cmd = new MySqlCommand(sqlInsert, conn, tran);
                        cmd.Parameters.AddWithValue("@Ten", txtTenAlbum.Text.Trim());
                        cmd.Parameters.AddWithValue("@IdCS", cbbCaSi.SelectedValue);
                        cmd.Parameters.AddWithValue("@Ngay", dtpNgayPhatHanh.Value);
                        cmd.Parameters.AddWithValue("@Anh", duongDanAnhLuuDB);

                        // Lấy ID vừa tạo
                        idAlbumXuLy = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    // --- TRƯỜNG HỢP 2: SỬA (CẬP NHẬT) ---
                    else if (_flagMode == 2)
                    {
                        // Lấy ID album cần sửa (đã lưu ở biến toàn cục khi gọi SetData)
                        idAlbumXuLy = int.Parse(_idAlbumCanSua);

                        string sqlUpdate = "UPDATE albums SET Ten_Ab=@Ten, Cs_Id=@IdCS, Ngay_Dang=@Ngay, AnhAlbum=@Anh WHERE Ab_Id=@Id";
                        MySqlCommand cmd = new MySqlCommand(sqlUpdate, conn, tran);
                        cmd.Parameters.AddWithValue("@Ten", txtTenAlbum.Text.Trim());
                        cmd.Parameters.AddWithValue("@IdCS", cbbCaSi.SelectedValue);
                        cmd.Parameters.AddWithValue("@Ngay", dtpNgayPhatHanh.Value);
                        cmd.Parameters.AddWithValue("@Anh", duongDanAnhLuuDB);
                        cmd.Parameters.AddWithValue("@Id", idAlbumXuLy);

                        cmd.ExecuteNonQuery();
                    }

                    // --- CẬP NHẬT DANH SÁCH BÀI HÁT ---
                    // (Đoạn này chạy cho cả 2 trường hợp: Thêm và Sửa)
                    // Duyệt qua các bài hát được tích chọn trong CheckedListBox
                    foreach (object itemChecked in clbBaiHat.CheckedItems)
                    {
                        DataRowView row = itemChecked as DataRowView;
                        int baiHatId = Convert.ToInt32(row["Bai_Hat_Id"]);

                        // Cập nhật bài hát đó thuộc về Album này
                        string sqlUpdateBaiHat = "UPDATE baihat SET ab_Id = @AbId, Album = @TenAb WHERE Bai_Hat_Id = @BhId";
                        MySqlCommand cmd2 = new MySqlCommand(sqlUpdateBaiHat, conn, tran);
                        cmd2.Parameters.AddWithValue("@AbId", idAlbumXuLy); // Sử dụng ID chung đã lấy ở trên
                        cmd2.Parameters.AddWithValue("@TenAb", txtTenAlbum.Text.Trim());
                        cmd2.Parameters.AddWithValue("@BhId", baiHatId);

                        cmd2.ExecuteNonQuery();
                    }

                    // Chốt giao dịch
                    tran.Commit();

                    if (_flagMode == 1) MessageBox.Show("Tạo Album thành công!");
                    else MessageBox.Show("Cập nhật Album thành công!");

                    // Reset form
                    txtTenAlbum.Clear();
                    cbbCaSi.SelectedIndex = -1;
                    pbAnh.Image = null;
                    duongDanAnhLuuDB = "";

                    // Tải lại danh sách bài hát để cập nhật trạng thái
                    LoadDanhSachBaiHat();

                    // Báo cho Form cha biết để tải lại lưới
                    OnLuuThanhCong?.Invoke(this, EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi Database: " + ex.Message);
                }
            }
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
            OnHuy?.Invoke(this, EventArgs.Empty);
        }
    }
}