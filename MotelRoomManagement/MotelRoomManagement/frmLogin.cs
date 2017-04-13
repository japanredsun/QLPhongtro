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
            //string a, b;
            string sql = "SELECT * FROM GhiNho";
            List<GhiNho> tmp = new PhongBUS().getGN(sql);
            txtLogin.DataBindings.Add("Text", tmp, "ID");
            txtPassword.DataBindings.Add("Text", tmp, "Pass");
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            string sql = "SELECT Count(*) FROM DangNhap WHERE ID=@id AND PassWord=@pw";
            string a = txtLogin.Text.Trim();
            string b = txtPassword.Text;
            int x = new PhongBUS().Log(sql, a, b);
            if (x == 1)
            {
                frmMain frmM = new frmMain();
                frmM.Show();
                if (cbSave.Checked)
                {
                    int i = new PhongBUS().Save(a, b);
                }
                else
                {
                    int j = new PhongBUS().Xoa();
                }
            }
            else
            {
                MessageBox.Show("NoOK");
            }

        }

        private void btReset_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
