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
    public partial class SapPhong : UserControl
    {
        public SapPhong()
        {
            InitializeComponent();
        }

        private void radDSDK_CheckedChanged(object sender, EventArgs e)
        {
            if (radDSDK.Checked)
            {
                listKDK.Enabled = true;
            }
            else
                listKDK.Enabled = false;
        }

        private void rdnTuNhap_CheckedChanged(object sender, EventArgs e)
        {
            if (rdnTuNhap.Checked)
            {
                lbPKC.Visible = false;

            }
            else
                lbPKC.Visible = true;

        }

        private void SapPhong_Load(object sender, EventArgs e)
        {
            Load_CBKV();
            Load_CBLoaiPhong();
        }

        private void Load_CBKV()
        {
            Room data = new Room();
            var kv = data.GetDataTW();
            cbKV.ValueMember = "MaKhuVuc";
            cbKV.DisplayMember = "TenKhuVuc";
            cbKV.DataSource = kv;
        }
        private void Load_CBLoaiPhong()
        {
            LoaiPhongBUS data = new LoaiPhongBUS();
            var loaiphong = data.GetLoaiPhongDA();
            cbLoaiPhong.ValueMember = "MaLoaiPhong";
            cbLoaiPhong.DisplayMember = "TenLoaiPhong";
            cbLoaiPhong.DataSource = loaiphong;
        }

        private void cbKV_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvPhong.Items.Clear();
            Load_CBLoaiPhong();

        }
       
        private void LoadData_ListPhong()
        {
            string khuvuc = cbKV.SelectedValue.ToString();
            string loaiphong = cbLoaiPhong.SelectedValue.ToString();
            Room data = new Room();
            var phong = data.GetDataPhong("SELECT * FROM Phong WHERE MaLoaiPhong='" + loaiphong + "'AND TrangThai=N'Trống' AND MaKhuVuc='" + khuvuc + "'");

            for (int i = 0; i < phong.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(phong.Rows[i][0].ToString());
                item.SubItems.Add(phong.Rows[i][3].ToString());
                item.ImageIndex = 0;
                lvPhong.Items.Add(item);
            }
        }

        private void cbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvPhong.Items.Clear();
            LoadData_ListPhong();
        }

        private void lvPhong_Click(object sender, EventArgs e)
        {
            PhongBUS listphong = new PhongBUS();
            string maphong = lvPhong.SelectedItems[0].Text;
            string sql1 = "SELECT p.TenPhong, lp.DonGia From Phong p, LoaiPhong lp WHERE p.MaPhong=N'" + maphong + "'AND p.MaLoaiPhong = lp.MaLoaiPhong";
            var dsphong = listphong.GetThongTinThuePhong(sql1);
            string tenphong = dsphong.Rows[0][0].ToString();
            string dongia = dsphong.Rows[0][1].ToString();

            lbMaPhong.Text = maphong;
            lbTenPhong.Text = tenphong;
            lbGia.Text = dongia;
        }


      

        
    }
}
