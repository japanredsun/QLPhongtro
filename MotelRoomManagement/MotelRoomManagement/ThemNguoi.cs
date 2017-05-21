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
    public partial class ThemNguoi : UserControl
    {
        public ThemNguoi()
        {
            InitializeComponent();
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void ThemNguoi_Load(object sender, EventArgs e)
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

        private void LoadData_ListPhong()
        {
            string khuvuc = cbKV.SelectedValue.ToString();
            string loaiphong = cbLoaiPhong.SelectedValue.ToString();
            Room data = new Room();
            var phong = data.GetDataPhong("SELECT * FROM Phong WHERE MaLoaiPhong='" + loaiphong + "'AND TrangThai=N'Đã thuê' AND MaKhuVuc='" + khuvuc + "'");

            for (int i = 0; i < phong.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(phong.Rows[i][3].ToString());
                item.SubItems.Add(phong.Rows[i][0].ToString());
                item.ImageIndex = 0;
                lvPhong.Items.Add(item);
            }


        }

        private void cbKV_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvPhong.Items.Clear();
            Load_CBLoaiPhong();
        }

        private void cbLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvPhong.Items.Clear();
            LoadData_ListPhong();
        }

        private void lvPhong_Click(object sender, EventArgs e)
        {
            Room data = new Room();
            string kv = cbKV.SelectedValue.ToString();
            string tp = lvPhong.SelectedItems[0].Text;
            string sql = "SELECT MaPhong FROM Phong WHERE TenPhong=N'" + tp + "'AND MaKhuVuc='" + kv + "'";
            var mp = data.GetDataPhong(sql);

            PhongBUS listphong = new PhongBUS();
            string maphong = mp.Rows[0][0].ToString();
            string sql1 = "SELECT p.TenPhong, lp.DonGia From Phong p, LoaiPhong lp WHERE p.MaPhong=N'" + maphong + "'AND p.MaLoaiPhong = lp.MaLoaiPhong";
            var dsphong = listphong.GetThongTinThuePhong(sql1);
            string tenphong = dsphong.Rows[0][0].ToString();
            string gia = string.Format("{0:#,##0}", Int32.Parse(dsphong.Rows[0][1].ToString()));
            lbMaPhong.Text = maphong; lbMaPhong.ForeColor = Color.Red;
            lbTenPhong.Text = tenphong; lbTenPhong.ForeColor = Color.Red;
            lbGia.Text = gia + " vnd"; lbGia.ForeColor = Color.Red;

            Load_ListKhach(maphong);
            
        }   
            
        private void Load_ListKhach(string maphong)
        {
            KhachThueBUS khach = new KhachThueBUS();
            var listkhach = khach.GetKhach(maphong);
            lvKhachThue.Items.Clear();
            for (int i = 0; i < listkhach.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(listkhach.Rows[i][0].ToString());
                if (listkhach.Rows[i][2].ToString() == "Nam") item.ImageIndex = 3; else item.ImageIndex = 2;
                item.SubItems.Add(listkhach.Rows[i][1].ToString());
                item.SubItems.Add(listkhach.Rows[i][3].ToString());
                item.SubItems.Add(listkhach.Rows[i][5].ToString());
                lvKhachThue.Items.Add(item);
            }
            lbSoNguoi.Text = listkhach.Rows.Count.ToString();
        }
    }
}
