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
           

            Load_Data_TreeView1();
            Load_Data_TreeView2();
            
            
        }

        private void Load_Data_TreeView1()
        {
            Room _TW = new Room();
            for (int i = 0; i < _TW.GetDataTW().Rows.Count; i++)
            {
                string item_TenKV = _TW.GetDataTW().Rows[i][1].ToString();
                string item_MaKV = _TW.GetDataTW().Rows[i][0].ToString();
                treeView1.Nodes.Add(item_TenKV);
                treeView1.Nodes[i].Tag = "1";
                for (int j = 0; j < _TW.GetDataTWChild(item_MaKV, "NoVacant").Rows.Count; j++)
                {
                    treeView1.Nodes[i].Nodes.Add(_TW.GetDataTWChild(item_MaKV, "NoVacant").Rows[j][0].ToString());
                    treeView1.Nodes[i].Nodes[j].Tag = "2";
                }


            } treeView1.ExpandAll();
        }

        private void Load_Data_TreeView2()
        {
            Room _TW2 = new Room();

            for (int i = 0; i < _TW2.GetDataTW().Rows.Count; i++)
            {
                string item_MaKV = _TW2.GetDataTW().Rows[i][0].ToString();
                string item_TenKV = _TW2.GetDataTW().Rows[i][1].ToString();

                treeView2.Nodes.Add(item_TenKV);
                treeView2.Nodes[i].Tag = "1";
                for (int j = 0; j < _TW2.GetDataTWChild(item_MaKV, "Vacant").Rows.Count; j++)
                {
                    treeView2.Nodes[i].Nodes.Add(_TW2.GetDataTWChild(item_MaKV, "Vacant").Rows[j][0].ToString());
                    treeView2.Nodes[i].Nodes[j].Tag = "2";
                }

            } treeView2.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode theNode = this.treeView1.SelectedNode;
            if (theNode.Tag == "2")
            {
                Room _Class = new Room();
                dataGridView1.DataSource = _Class.GetData(theNode.Text);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        
       
      

       

      

        
    }
}
