﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using MRBUS;
using MRDTO;

namespace MotelRoomManagement
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {      
            cbSave.Checked = true;
            string sql = "SELECT * FROM GhiNho";
            List<GhiNho> tmp = new DangNhapBUS().getGN(sql);
            txtLogin.DataBindings.Add("Text", tmp, "ID");
            txtPassword.DataBindings.Add("Text", tmp, "Pass");
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            string sql = "SELECT Count(*) FROM DangNhap WHERE ID=@id AND PassWord=@pw";
            string a = txtLogin.Text.Trim();
            string b = txtPassword.Text;
            int x = new DangNhapBUS().Log(sql, a, b);
            if (x == 1)
            {
                FrmGeneral frmM = new FrmGeneral(a, b);
                frmM.Show();
                if (cbSave.Checked)
                {
                    int i = new DangNhapBUS().Save(a, b);
                }
                else
                {
                    int j = new DangNhapBUS().Xoa();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai thông tin tài khoản hoặc mật khẩu", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btReset_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void frmLogin_Load_1(object sender, EventArgs e)
        {

        }
    }
}
