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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Load_Data();   
        }
        private List<Phong> GetPhong()
        {
            string sql = "SELECT * FROM Phong";
            List<Phong> tmp = new PhongBUS().GetPhong(sql);
            return tmp;
        }

        private void Load_Data()
        {
            Room _Class = new Room();
            dataGridView1.DataSource = _Class.GetData();

            Load_Data_TreeView1();
            
            
        }

        private void Load_Data_TreeView1()
        {
            Room _TW = new Room();
            for (int i = 0; i < _TW.GetDataTW().Rows.Count; i++)
            {
                treeView1.Nodes.Add(_TW.GetDataTW().Rows[i][0].ToString());
                treeView1.Nodes[i].Tag = "1";
            }

            for (int i = 0; i < _TW.GetDataTW().Rows.Count; i++)
            {
                treeView2.Nodes.Add(_TW.GetDataTW().Rows[i][0].ToString());
                treeView2.Nodes[i].Tag = "1";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        
       
      

       

      

        
    }
}
