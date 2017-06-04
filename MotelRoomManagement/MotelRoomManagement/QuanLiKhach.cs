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
    public partial class QuanLiKhach : UserControl
    {
        Room data = new Room();
        public QuanLiKhach()
        {
            InitializeComponent();
        }

        private void QuanLiKhach_Load(object sender, EventArgs e)
        {
            Load_CBKV();
        }

        private void Load_CBKV()
        {           
            var kv = data.GetDataTW();
            cbKV.ValueMember = "MaKhuVuc";
            cbKV.DisplayMember = "TenKhuVuc";
            cbKV.DataSource = kv;
        }

        private void Load_datagrid(string sql)
        {
            dgvQLKhach.Rows.Clear();

            dgvQLKhach.ColumnCount = 5;
            dgvQLKhach.Columns[0].Name = "Mã Khách";
            dgvQLKhach.Columns[1].Name = "Mã Phòng";
            dgvQLKhach.Columns[2].Name = "Họ và tên";
            dgvQLKhach.Columns[3].Name = "Giới Tính";
            dgvQLKhach.Columns[4].Name = "Ngày Sinh";
  
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
                dgvQLKhach.Rows.Add(row.ToArray());
            }


        }

        private void Load_DSKhach()
        {
            string makv = cbKV.SelectedValue.ToString();
            string sql = "SELECT MaKhachTro, ttk.MaPhong,Ho + ' ' + Ten AS HoTen,GioiTinh,CONVERT(varchar(10),NgaySinh,103) From ThongTinKhach ttk, Phong p Where ttk.MaPhong=p.MaPhong AND p.MaKhuVuc='" + makv + "'";
            var dskhach = data.GetDataPhong(sql);

            Load_datagrid(sql);

        }

        private void cbKV_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DSKhach();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string makv = cbKV.SelectedValue.ToString();
            string word = txtSearch.Text;
            string sql = "SELECT MaKhachTro,ttk.MaPhong, Ho + ' ' + Ten AS HoTen,CONVERT(varchar(10),NgaySinh,103),NgheNghiep From ThongTinKhach ttk, Phong p Where ttk.MaPhong=p.MaPhong AND p.MaKhuVuc='" + makv + "' AND (ttk.MaPhong LIKE '%" + word + "%' OR ttk.Ten LIKE '%" + word + "%')";
            Load_datagrid(sql);
        }

        private void dgvQLKhach_SelectionChanged(object sender, EventArgs e)
        {
            clearall();
            if (dgvQLKhach.SelectedCells.Count > 0)
            {
                int index = dgvQLKhach.SelectedCells[0].RowIndex;
                DataGridViewRow selectedrow = dgvQLKhach.Rows[index];
                string makhach = Convert.ToString(selectedrow.Cells["Mã Khách"].Value);

                string sql = "SELECT * FROM ThongTinKhach WHERE MaKhachTro = '" + makhach + "'";
                List<KhachThue> tmp = new KhachThueBUS().GetKhach_List(sql);
                lbMaKt.DataBindings.Add("Text", tmp, "MaKhachTro");
                cbGioiTinh.DataBindings.Add("Text", tmp, "GioiTinh");
                txtTen.DataBindings.Add("Text", tmp, "Ten");
                txtHo.DataBindings.Add("Text", tmp, "Ho"); ;
                dtpNgaySinh.DataBindings.Add("Text", tmp, "NgaySinh");
                txtCMND.DataBindings.Add("Text", tmp, "CMND");
                txtQue.DataBindings.Add("Text", tmp, "QueQuan");
                txtNghe.DataBindings.Add("Text", tmp, "NgheNghiep");
                txtGhiChu.DataBindings.Add("Text", tmp, "GhiChu");
            }
            btnCancel.Visible = false;
            btnSave.Visible = false;
            btnSua.Visible = true;
        }

        private void clearall()
        {
            lbMaKt.DataBindings.Clear();
            cbGioiTinh.DataBindings.Clear();
            txtTen.DataBindings.Clear();
            txtHo.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Clear();
            txtCMND.DataBindings.Clear();
            txtQue.DataBindings.Clear();
            txtNghe.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
            //
            dtpNgaySinh.Value = DateTime.Today;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtHo.Enabled = true;
            txtTen.Enabled = true;
            dtpNgaySinh.Enabled = true;
            cbGioiTinh.Enabled = true;
            txtCMND.Enabled = true;
            txtQue.Enabled = true;
            txtNghe.Enabled = true;
            txtGhiChu.Enabled = true;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            
            btnSua.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtHo.Enabled = false;
            txtTen.Enabled = false;
            dtpNgaySinh.Enabled = false;
            cbGioiTinh.Enabled = false;
            txtCMND.Enabled = false;
            txtQue.Enabled = false;
            txtNghe.Enabled = false;
            txtGhiChu.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnSua.Visible = true;
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string _id, ho, ten, birthday, cmnd, quequan, job, gioitinh, ghichu;
            _id = lbMaKt.Text;
            ho = txtHo.Text.Trim();
            ten = txtTen.Text;            
            birthday = dtpNgaySinh.Text.Trim();
            if (cbGioiTinh.SelectedItem.ToString() == "Nam")
                gioitinh = "Nam";
            else
                gioitinh = "Nữ";

            cmnd = txtCMND.Text.Trim();
            quequan = txtQue.Text.Trim();
            job = txtNghe.Text.Trim();
            ghichu = txtGhiChu.Text.Trim();

            txtHo.Enabled = false;
            txtTen.Enabled = false;           
            dtpNgaySinh.Enabled = false;
            cbGioiTinh.Enabled = false;
            txtCMND.Enabled = false;
            txtQue.Enabled = false;
            txtNghe.Enabled = false;
            txtGhiChu.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnSua.Visible = true;
           

            string sql = "UPDATE ThongTinKhach SET Ho=N'" + ho + "', Ten=N'" + ten + "', GioiTinh=N'" + gioitinh + "', NgaySinh='" + birthday + "', CMND='" + cmnd + "', QueQuan=N'" + quequan + "', NgheNghiep=N'" + job + "', GhiChu=N'" + ghichu + "' WHERE MaKhachTro = '" + _id + "'";
            List<KhachThue> tmp = new KhachThueBUS().GetKhach_List(sql);
            MessageBox.Show("Đã sửa thông tin khách!");

            //Refresh
            Load_DSKhach();
        }

    }
}
