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
        string _id, ho, ten, birthday, cmnd, quequan, job, gioitinh;
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
            dtpNgaySinh.Enabled = false;
            cbGioiTinh.Enabled = false;
            txtCMND.Enabled = false;
            txtQue.Enabled = false;
            txtNghe.Enabled = false;
            txtGhiChu.Enabled = false;
            string sql = "SELECT * FROM ThongTinKhach WHERE MaKhachTro = '" + _id + "'";
            List<KhachThue> tmp = new KhachThueBUS().GetKhach_List(sql);
            lbMaKt.DataBindings.Add("Text", tmp, "MaKhachTro");
            //foreach (var i in tmp)
            //{
            //    a = i.Ho;
            //    //a = a + " ";
            //    a = a +' '+ i.Ten;
            //}
            cbGioiTinh.DataBindings.Add("Text", tmp, "GioiTinh");
            //a += txtHoTen.DataBindings.Add("Text", tmp, "Ten").ToString();
            txtTen.DataBindings.Add("Text", tmp, "Ten");
            txtHo.DataBindings.Add("Text", tmp, "Ho"); ;
            //txtHoTen.DataBindings.Add("Text", tmp, "Ho").ToString();
            //txtHoTen += txtHoTen.DataBindings.Add("Text", tmp, "Ten");
            dtpNgaySinh.DataBindings.Add("Text", tmp, "NgaySinh");
            txtCMND.DataBindings.Add("Text", tmp, "CMND");
            txtQue.DataBindings.Add("Text", tmp, "QueQuan");
            txtNghe.DataBindings.Add("Text", tmp, "NgheNghiep");
            txtGhiChu.DataBindings.Add("Text", tmp, "GhiChu");
            //load(_id);
        }

        //public void load(string makt)
        //{
            
        //    Customer khach = new Customer();
        //    for (int i = 0; i < khach.GetData(makt).Rows.Count; i++)
        //    {
        //        DateTime dt = DateTime.ParseExact(khach.GetData(makt).Rows[i][5].ToString(), "M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
        //        string s = dt.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
        //        gioitinh = khach.GetData(makt).Rows[i][3].ToString();
        //        name = khach.GetData(makt).Rows[i][1].ToString() + ' ' + khach.GetData(makt).Rows[i][2].ToString();
        //        birthday = s;
        //        cmnd = khach.GetData(makt).Rows[i][6].ToString();
        //        quequan = khach.GetData(makt).Rows[i][7].ToString();
        //        job = khach.GetData(makt).Rows[i][8].ToString();
        //    }
        //    lbMaKt.Text = makt;
        //    txtHoTen.Text = name;
        //    txtNgaySinh.Text = birthday;
        //    txtCMND.Text = cmnd;
        //    txtQue.Text = quequan;
        //    txtNghe.Text = job;
        //}

        private void btUpdate_Click(object sender, EventArgs e)
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
            btnUpdate.Visible = false;
            btnExit.Visible = false;
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
            btnUpdate.Visible = true;
            btnExit.Visible = true;

            string sql = "UPDATE ThongTinKhach SET Ho=N'" + ho + "', Ten=N'" + ten + "', GioiTinh=N'" + gioitinh + "', NgaySinh='" + birthday + "', CMND='" + cmnd + "', QueQuan=N'" + quequan + "', NgheNghiep=N'" + job + "' WHERE MaKhachTro = '" + _id + "'";
            List<KhachThue> tmp = new KhachThueBUS().GetKhach_List(sql);
            MessageBox.Show("Đã sửa thông tin khách!");
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
