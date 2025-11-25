using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAN_QuanLyBaiHat.UserConTroller;

namespace DoAN_QuanLyBaiHat
{
    public partial class UC_BaiHat : UserControl
    {
        public UC_BaiHat()
        {
            InitializeComponent();
        }
        public void loadDanhSachBaiHat()
        {
            // Giả sử bạn có vòng lặp lấy dữ liệu từ CSDL hoặc List bài hát
            for (int i = 1; i <= 10; i++)
            {
                // 1. Tạo mới một SongItem
                SongItem item = new SongItem();

                // 2. Gán dữ liệu (Ví dụ giả lập)
                // Lưu ý: Bạn cần có hình ảnh trong Resources hoặc đường dẫn file
                item.SetData("Bài hát số " + i, "Ca sĩ A");

                // 3. Thêm margin để các bài hát cách nhau ra một chút cho đẹp
                item.Margin = new Padding(10);

                // 4. Thêm vào FlowLayoutPanel
                flpDanhSachBaiHat.Controls.Add(item);
            }
        }

        private void UC_BaiHat_Load(object sender, EventArgs e)
        {
            loadDanhSachBaiHat();
        }
    }
}
