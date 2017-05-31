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
using System.Collections;

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

        private void Load_datagrid(string sql)
        {
            dgvQLPhong.Rows.Clear();

            dgvQLPhong.ColumnCount = 7;
            dgvQLPhong.Columns[0].Name = "Mã Phòng";
            dgvQLPhong.Columns[1].Name = "Loại phòng";
            dgvQLPhong.Columns[2].Name = "Dãy";
            dgvQLPhong.Columns[3].Name = "Tên phòng";
            dgvQLPhong.Columns[4].Name = "Trạng Thái";
            dgvQLPhong.Columns[5].Name = "Diện tích";
            dgvQLPhong.Columns[6].Name = "Đơn giá";
            

            string makv = cbKV.SelectedValue.ToString();
            var dsphong = new Room().GetDataPhong(sql);

            for (int i = 0; i < dsphong.Rows.Count; i++)
            {
                ArrayList row = new ArrayList();
                row.Add(dsphong.Rows[i][0].ToString());
                row.Add(dsphong.Rows[i][1].ToString());
                row.Add(dsphong.Rows[i][2].ToString());
                row.Add(dsphong.Rows[i][3].ToString());
                row.Add(dsphong.Rows[i][4].ToString());
                row.Add(dsphong.Rows[i][5].ToString());
                row.Add(dsphong.Rows[i][6].ToString());

                dgvQLPhong.Rows.Add(row.ToArray());
            }
            

        }

        private void Load_CBKV()
        {
            Room data = new Room();
            var kv = data.GetDataTW();
            cbKV.ValueMember = "MaKhuVuc";
            cbKV.DisplayMember = "TenKhuVuc";
            cbKV.DataSource = kv;
        }

        private void Load_Default()
        {
            string makv = cbKV.SelectedValue.ToString();
            string sql = "select p.MaPhong, TenLoaiPhong, p.Day, TenPhong,TrangThai, DienTichPhong, DonGia from Phong p ,LoaiPhong lp where lp.MaLoaiPhong=p.MaLoaiPhong and  MaKhuVuc='" + makv + "'";
            Load_datagrid(sql);
        }

        private void cbKV_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Default();
            
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            frmAddRoom form = new frmAddRoom();
            form.Show();
        }

        private void btnF5_Click(object sender, EventArgs e)
        {
            Load_Default();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string makv = cbKV.SelectedValue.ToString();
            string word = txtSearch.Text;
            string sql = "SELECT p.MaPhong,lp.TenLoaiPhong,p.Day,p.TenPhong,p.TrangThai,lp.DienTichPhong,lp.DonGia From Phong p, LoaiPhong lp WHERE p.MaLoaiPhong=lp.MaLoaiPhong AND MaKhuVuc='" + makv + "'AND (p.MaPhong LIKE '%" + word + "%' OR p.TenPhong LIKE N'%" + word + "%')";
            Load_datagrid(sql);

        }

      
    }
}
