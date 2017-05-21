using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MRBUS;
using MRDTO;

namespace MotelRoomManagement
{
    public partial class frmDKPhong : Form
    {
        public frmDKPhong()
        {
            InitializeComponent();
        }

        string ho, ten, ngaysinh, gioitinh, cmnd, quequan, nghenghiep, makhuvuc, maloaiphong;

        private void frmDKPhong_Load(object sender, EventArgs e)
        {
            LoadKV();

        }
        private void LoadKV()
        {
            Room data = new Room();
            var kv = data.GetDataTW();
            cbKhuVuc.DisplayMember = "TenKhuVuc";
            cbKhuVuc.ValueMember = "MaKhuVuc";
            cbKhuVuc.DataSource = kv;
        }

        private void cbKhuVuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstLoaiPhong.Items.Clear();
            string makv = cbKhuVuc.SelectedValue.ToString();

            string sql = "SELECT lp.MaLoaiPhong, lp.TenLoaiPhong, lp.DienTichPhong, lp.DonGia, p.TrangThai FROM LoaiPhong lp, Phong p WHERE p.MaKhuVuc = N'" + makv + "' AND p.TrangThai = N'Trống' AND p.MaLoaiPhong = lp.MaLoaiPhong";
            Room ListLoai = new Room();
            var loaiphong = ListLoai.GetDataPhong(sql);
            for (int i = 0; i < loaiphong.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(loaiphong.Rows[i][0].ToString().TrimEnd());
                item.SubItems.Add(loaiphong.Rows[i][1].ToString().TrimEnd());
                item.SubItems.Add(loaiphong.Rows[i][2].ToString().TrimEnd());
                item.SubItems.Add(loaiphong.Rows[i][3].ToString().TrimEnd());

                lstLoaiPhong.Items.Add(item);
            }


        }

        private void lstLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstLoaiPhong.SelectedItems.Count == 0)
                return;
            else
            {
                ListViewItem item = lstLoaiPhong.SelectedItems[0];
                lbLoai.Text = item.SubItems[1].Text;
                lbKhuvuc.Text = cbKhuVuc.Text;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            try
            {
                ThongTinDKBUS ttdk = new ThongTinDKBUS();
                string sql = "SELECT * FROM ThongTinDangKyPhong";
                int id = ttdk.GetThongTinDK(sql).Rows.Count + 1;
                ho = txtHo.Text;
                ten = txtTen.Text;
                ngaysinh = dtiNgaySinh.Text;
                gioitinh = "Nam";
                if (cbGioiTinh.SelectedItem.ToString() == "Nam")
                    gioitinh = "Nam";
                else
                    gioitinh = "Nữ";
                cmnd = txtCmnd.Text;
                quequan = txtQuequan.Text;
                nghenghiep = txtNghenghiep.Text;
                makhuvuc = cbKhuVuc.SelectedValue.ToString();
                maloaiphong = lstLoaiPhong.SelectedItems[0].Text;

                string sqlInsert = "INSERT INTO ThongTinDangKyPhong(Id,Ho,Ten,GioiTinh,NgaySinh,CMND,QueQuan,NgheNghiep,MaKhuVuc,MaLoaiPhong) VALUES(@id,@ho,@ten,@gioitinh,@ngaysinh,@cmnd,@quequan,@nghenghiep,@makhuvuc,@maloaiphong)";
                int i = new ThongTinDKBUS().Insert(sqlInsert, id, ho, ten, gioitinh, ngaysinh, cmnd, quequan, nghenghiep, makhuvuc, maloaiphong);

                MessageBox.Show("Đã thêm thành công!");
            }
            catch (FormatException)
            {
                MessageBox.Show("Phải nhập đầy đủ thông tin!");
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtHo.Text = "";
            txtTen.Text = "";
            txtCmnd.Text = "";
            txtQuequan.Text = "";
            txtNghenghiep.Text = "";
        }
    }
}
