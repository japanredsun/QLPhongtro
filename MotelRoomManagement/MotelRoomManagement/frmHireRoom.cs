using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using MRDTO;
using MRBUS;

namespace MotelRoomManagement
{
    public partial class frmHireRoom : Form
    {
        string makt, ho, ten, gioitinh, cmnd, ngaythue, ngaysinh, quequan, nghenghiep, maphong;
        double tiendatcoc;

        public frmHireRoom()
        {
            InitializeComponent();
        }

        private void frmHireRoom_Load(object sender, EventArgs e)
        {
            string sql = "SELECT p.MaPhong,p.TenPhong,lp.TenLoaiPhong,lp.DonGia FROM Phong p,LoaiPhong lp WHERE p.TrangThai = N'Trống' AND p.MaLoaiPhong = lp.MaLoaiPhong";
           
            PhongBUS ListPhong = new PhongBUS();
            for (int i = 0; i < ListPhong.GetPhongTrong(sql).Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(ListPhong.GetPhongTrong(sql).Rows[i][0].ToString());
                item.SubItems.Add(ListPhong.GetPhongTrong(sql).Rows[i][1].ToString());
                item.SubItems.Add(ListPhong.GetPhongTrong(sql).Rows[i][2].ToString());
                item.SubItems.Add(ListPhong.GetPhongTrong(sql).Rows[i][3].ToString());

                lstPhongTrong.Items.Add(item);
            }
        }

        //private List<KhachThue> getKhachThue()
        //{
        //    string sql = "SELECT * FROM ThongTinKhach";
        //    List<KhachThue> khach = new KhachThueBUS().GetKhach_List(sql);
        //    return khach;
        //}

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void btSave_Click(object sender, EventArgs e)
        {
            makt = txtMaKhach.Text.Trim();
            ho = txtHo.Text.Trim();
            ten = txtTen.Text.Trim();
            ngaysinh = dtpNgaySinh.Text;
            if (cbGioiTinh.SelectedItem.ToString() == "Nam")
                gioitinh = "Nam";
            else
                gioitinh = "Nữ";
            cmnd = txtCMND.Text.Trim();
            quequan = txtQueQuan.Text.Trim();
            nghenghiep = txtNgheNghiep.Text.Trim();
            maphong = lbMaPhong.Text.Trim();
            //tiendatcoc = (double)txtTienDatCoc.Text.Trim();
            
            //Them vao bang ThongTinKhach

            string sqlAddKhachInfo = "INSERT INTO ThongTinKhach(MaKhachTro,Ho,Ten,GioiTinh,NgaySinh,CMND,QueQuan,NgheNghiep,MaPhong) VALUES('"+makt+"',N'"+ho+"',N'"+ten+"',N'"+gioitinh+"','"+ngaysinh+"','"+cmnd+"',N'"+quequan+"',N'"+nghenghiep+"','"+maphong+"')";
            List<KhachThue> tmp = new KhachThueBUS().GetKhach_List(sqlAddKhachInfo);

            //Them vao bang ThongTinThuePhong

            //string select_maphong = lbMaPhong.Text;
            


            MessageBox.Show("Đã thêm thành công!");
        }


        
        
        private void lstPhongTrong_Click(object sender, EventArgs e)
        {
            //ListViewItem item = new ListViewItem();
            //string maphong = lbMaPhong.Text;
            //string ten = lbTenPhong.Text;
            //string dongia = lbGia.Text;
            PhongBUS listphong = new PhongBUS();
            string maphong = lstPhongTrong.SelectedItems[0].Text;
            string sql1 = "SELECT p.TenPhong, lp.DonGia From Phong p, LoaiPhong lp WHERE p.MaPhong=N'"+maphong+"'AND p.MaLoaiPhong = lp.MaLoaiPhong";
            var dsphong = listphong.GetPhongTrong(sql1);
            string tenphong = dsphong.Rows[0][0].ToString();
            string dongia = dsphong.Rows[0][1].ToString();

            lbMaPhong.Text = maphong;
            lbTenPhong.Text = tenphong;
            lbGia.Text = dongia;
            
        }

       
    }
}
