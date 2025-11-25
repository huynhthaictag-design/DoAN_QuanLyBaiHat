using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAN_QuanLyBaiHat
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        private void AddUserControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            pnlBody.Controls.Clear();
            pnlBody.Controls.Add(uc);
            uc.BringToFront();
        }
        private void User_Load(object sender, EventArgs e)
        {

        }

        private void btnBaiHat_Click(object sender, EventArgs e)
        {
            UC_BaiHat uC_BaiHat = new UC_BaiHat();
            AddUserControl(uC_BaiHat);
        }
        private void btnPlayList_Click(object sender, EventArgs e)
        {

        }

        private void btnCaSi_Click(object sender, EventArgs e)
        {

        }

        private void btnAlbums_Click(object sender, EventArgs e)
        {

        }
    }
}
