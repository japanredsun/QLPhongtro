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
    public partial class DSThuTien : UserControl
    {
        public DSThuTien()
        {
            InitializeComponent();
        }

        private void DSThuTien_Load(object sender, EventArgs e)
        {
            LoadCB();
        }
        private void LoadCB()
        {
            Room data = new Room();
            DataTable kv = data.GetDataTW();
            cbKhuVuc.DisplayMember = "TenKhuVuc";
            cbKhuVuc.ValueMember = "MaKhuVuc";
            cbKhuVuc.DataSource = kv;
        }

        private void cbKhuVuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            listHoaDon.Items.Clear();
            LoadList();
        }
        private void LoadList()
        {
            string makv = cbKhuVuc.SelectedValue.ToString();

            string sql = "SELECT MaPT, pt.MaPhong, TongTien FROM PhieuThu pt, Phong p WHERE p.MaKhuVuc = '" + makv + "' AND pt.TrangThai = N'Chưa thu' AND pt.MaPhong = p.MaPhong";
            Room ListLoai = new Room();
            var loaiphong = ListLoai.GetDataPhong(sql);
            for (int i = 0; i < loaiphong.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(loaiphong.Rows[i][0].ToString().TrimEnd());
                item.SubItems.Add(loaiphong.Rows[i][1].ToString().TrimEnd());
                item.SubItems.Add(loaiphong.Rows[i][2].ToString().TrimEnd());

                listHoaDon.Items.Add(item);
            }
        }
        private void listHoaDon_Click(object sender, EventArgs e)
        {
            ListViewItem item = listHoaDon.SelectedItems[0];
            string thang = item.Text;
            string sql = "SELECT * FROM PhieuThu WHERE MaPT = '" + thang + "'";
            DataTable table = new Room().GetDataPhong(sql);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                grCTHD.Text = "Chi tiết hóa đơn số: " + table.Rows[i][0].ToString().TrimEnd();
                lbLoaiphong.Text = table.Rows[i][1].ToString().TrimEnd();
                lbTienPhong.Text = table.Rows[i][4].ToString().TrimEnd();
                lbDienSK.Text = table.Rows[i][5].ToString().TrimEnd();
                lbTienDien.Text = table.Rows[i][6].ToString().TrimEnd();
                lbNuocSK.Text = table.Rows[i][7].ToString().TrimEnd();
                lbTienNuoc.Text = table.Rows[i][8].ToString().TrimEnd();
                lbTT.Text = table.Rows[i][9].ToString().TrimEnd();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            ListViewItem item = listHoaDon.SelectedItems[0];
            string thang = item.Text;
            int i = new PhieuThuBUS().XNDongTien(thang);
            MessageBox.Show("Đã đóng thành công!");
            listHoaDon.Items.Clear();
            LoadList();
        }
    }
}
