using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using MRDTO;
using MRBUS;

namespace MotelRoomManagement
{
    public partial class frmInformation : Form
    {
        //string a;
        string _id, ho, ten, birthday, cmnd, quequan, job, gioitinh, ghichu;
        public frmInformation()
        {
            InitializeComponent();
        }

        public frmInformation(string id):this()
        {
            _id = id;

        }
        private void frmInformation_Load(object sender, EventArgs e)
        {
            txtTen.Enabled = false;
            txtHo.Enabled = false;
            txtHoTen.Enabled = false;
            dtpNgaySinh.Enabled = false;
            cbGioiTinh.Enabled = false;
            txtCMND.Enabled = false;
            txtQue.Enabled = false;
            txtNghe.Enabled = false;
            txtGhiChu.Enabled = false;
            string sql = "SELECT * FROM ThongTinKhach WHERE MaKhachTro = '" + _id + "'";
            List<KhachThue> tmp = new KhachThueBUS().GetKhach_List(sql);
            lbMaKt.DataBindings.Add("Text", tmp, "MaKhachTro");
            cbGioiTinh.DataBindings.Add("Text", tmp, "GioiTinh");
            txtTen.DataBindings.Add("Text", tmp, "Ten");
            txtHo.DataBindings.Add("Text", tmp, "Ho"); ;
            txtHoTen.Text = txtHo.Text + " " + txtTen.Text;
            dtpNgaySinh.DataBindings.Add("Text", tmp, "NgaySinh");
            txtCMND.DataBindings.Add("Text", tmp, "CMND");
            txtQue.DataBindings.Add("Text", tmp, "QueQuan");
            txtNghe.DataBindings.Add("Text", tmp, "NgheNghiep");
            txtGhiChu.DataBindings.Add("Text", tmp, "GhiChu");
        }


        private void btUpdate_Click(object sender, EventArgs e)
        {
            txtHo.Enabled = true; 
            txtTen.Enabled = true; 
            txtHoTen.Visible = false;
            dtpNgaySinh.Enabled = true;
            cbGioiTinh.Enabled = true;
            txtCMND.Enabled = true;
            txtQue.Enabled = true;
            txtNghe.Enabled = true;
            txtGhiChu.Enabled = true;
            btnSave.Visible = true;
            btnCancel.Visible = true;
            btnUpdate.Visible = false;
            btnExit.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtHo.Enabled = false; 
            txtTen.Enabled = false;
            txtHoTen.Visible = true; txtHoTen.Enabled = false;
            dtpNgaySinh.Enabled = false;
            cbGioiTinh.Enabled = false;
            txtCMND.Enabled = false;
            txtQue.Enabled = false;
            txtNghe.Enabled = false;
            txtGhiChu.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnUpdate.Visible = true;
            btnExit.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ho = txtHo.Text;
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
            txtHoTen.Visible = true; txtHoTen.Enabled = false;
            dtpNgaySinh.Enabled = false;
            cbGioiTinh.Enabled = false;
            txtCMND.Enabled = false;
            txtQue.Enabled = false;
            txtNghe.Enabled = false;
            txtGhiChu.Enabled = false;
            btnSave.Visible = false;
            btnCancel.Visible = false;
            btnUpdate.Visible = true;
            btnExit.Visible = true;

            string sql = "UPDATE ThongTinKhach SET Ho=N'" + ho + "', Ten=N'" + ten + "', GioiTinh=N'" + gioitinh + "', NgaySinh='" + birthday + "', CMND='" + cmnd + "', QueQuan=N'" + quequan + "', NgheNghiep=N'" + job + "', GhiChu=N'"+ghichu+"' WHERE MaKhachTro = '" + _id + "'";
            List<KhachThue> tmp = new KhachThueBUS().GetKhach_List(sql);
            MessageBox.Show("Đã sửa thông tin khách!");
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
