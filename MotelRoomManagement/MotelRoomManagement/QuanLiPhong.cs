using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MRBUS;
using MRDTO;

namespace MotelRoomManagement
{
    public partial class QuanLiPhong : UserControl
    {
        public QuanLiPhong()
        {
            InitializeComponent();
        }

        private void bar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void QuanLiPhong_Load(object sender, EventArgs e)
        {
            Load_CBKV();
        }

        private void Load_CBKV()
        {
            Room data = new Room();
            var kv = data.GetDataTW();
            cbKV.ValueMember = "MaKhuVuc";
            cbKV.DisplayMember = "TenKhuVuc";
            cbKV.DataSource = kv;
        }

        private void cbKV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string makv = cbKV.SelectedValue.ToString();
            List<Phong> phong = new List<Phong>();
            string sql = "SELECT * From Phong WHERE MaKhuVuc='"+makv+"'";
            phong = new PhongBUS().GetPhong(sql);
            dgvQLPhong.DataSource = phong;
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            frmAddRoom form = new frmAddRoom();
            form.Show();
        }
    }
}
