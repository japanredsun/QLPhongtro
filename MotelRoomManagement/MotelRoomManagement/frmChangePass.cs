using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MotelRoomManagement
{
    public partial class frmChangePass : Form
    {
        private string id, pass;
        public frmChangePass()
        {
            InitializeComponent();
        }
        public frmChangePass(string username, string pas):this()
        {
            id = username;
            pass = pas;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmChangePass_Load(object sender, EventArgs e)
        {
            
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            string oldP, newP, rewrite;
            oldP = txtOldPass.Text;
            newP = txtNewPass.Text;
            rewrite = txtRewrite.Text;
            if (pass == oldP)
            {
                if (newP == rewrite)
                    MessageBox.Show("OK");
                else
                    MessageBox.Show("Vui lòng nhập lại mật khẩu mới", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Mật khẩu không đúng", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
