using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using MRDTO;
using MRBUS;

namespace MotelRoomManagement
{
    public partial class frmRoomManagement : Form
    {
        public frmRoomManagement()
        {
            InitializeComponent();
        }

        private void frmRoomManagement_Load(object sender, EventArgs e)
        {
            LoaiPhongBUS _Data = new LoaiPhongBUS();
            DataTable da = _Data.GetLoaiPhongDA();
            comboBox1.DataSource = da;
            comboBox1.DisplayMember = "TenLoaiPhong";
            comboBox1.ValueMember = "MaLoaiPhong";

            string maloaiphong = "1";
            string sql = "SELECT MaPhong,TenPhong,kv.TenKhuVuc,TenPhong,Day,TrangThai FROM Phong p, KhuVuc kv WHERE kv.MaKhuVuc = p.MaKhuVuc AND MaLoaiPhong = '" + maloaiphong + "'";
            List<Phong> dsphong = new PhongBUS().GetPhong(sql);
            foreach (var i in dsphong)
            {
                ListViewItem item = new ListViewItem(i.maphong);
                item.SubItems.Add(i.KhuVuc);
                item.SubItems.Add(i.tenphong);
                item.SubItems.Add(i.Day);
                item.SubItems.Add(i.Trangthai);
                listView1.Items.Add(item);
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAddRoom frm = new frmAddRoom();
            frm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string maloaiphong = comboBox1.SelectedValue.ToString();
            string sql = "SELECT MaPhong,TenPhong,kv.TenKhuVuc,TenPhong,Day,TrangThai FROM Phong p, KhuVuc kv WHERE kv.MaKhuVuc = p.MaKhuVuc AND MaLoaiPhong = '" + maloaiphong + "'";
            List<Phong> dsphong = new PhongBUS().GetPhong(sql);
            foreach (var i in dsphong)
            {
                ListViewItem item = new ListViewItem(i.maphong);
                item.SubItems.Add(i.KhuVuc);
                item.SubItems.Add(i.tenphong);
                item.SubItems.Add(i.Day);
                item.SubItems.Add(i.Trangthai);
                listView1.Items.Add(item);
            }            
        }
    }
}
