using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

using MRBUS;
using MRDTO;

namespace MotelRoomManagement
{
    public partial class frmMain : Form
    {
        private string USER, PASS;
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(string username, string password): this()
        {
            USER = username;
            PASS = password;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Load_Data();   
        }

        private void Load_Data()
        {
            Load_Data_TreeView1();
            Load_Data_TreeView2();
            Load_CB_KV();
            
            
            
            
            
        }

        private void Load_Data_TreeView1()
        {
            Room _TW = new Room();
            treeView1.ImageList = TwImgList;
            for (int i = 0; i < _TW.GetDataTW().Rows.Count; i++)
            {
                string item_TenKV = _TW.GetDataTW().Rows[i][1].ToString();
                string item_MaKV = _TW.GetDataTW().Rows[i][0].ToString();
                TreeNode nodecha = treeView1.Nodes.Add(item_TenKV);
                treeView1.Nodes[i].Tag = "1";
                nodecha.ImageIndex = 0;
                for (int j = 0; j < _TW.GetDataTWChild(item_MaKV, "NoVacant").Rows.Count; j++)
                {
                    TreeNode nodecon = treeView1.Nodes[i].Nodes.Add(_TW.GetDataTWChild(item_MaKV, "NoVacant").Rows[j][1].ToString());
                    treeView1.Nodes[i].Nodes[j].Tag = "2";
                    treeView1.Nodes[i].Nodes[j].Name = _TW.GetDataTWChild(item_MaKV, "NoVacant").Rows[j][0].ToString();
                    nodecon.ImageIndex = 1;
                    nodecon.SelectedImageIndex = 1;
                }


            } treeView1.ExpandAll();
        }

        private void Load_Data_TreeView2()
        {
            Room _TW2 = new Room();
            treeView2.ImageList = TwImgList;
            for (int i = 0; i < _TW2.GetDataTW().Rows.Count; i++)
            {
                string item_MaKV = _TW2.GetDataTW().Rows[i][0].ToString();
                string item_TenKV = _TW2.GetDataTW().Rows[i][1].ToString();

                TreeNode nodecha = treeView2.Nodes.Add(item_TenKV);
                treeView2.Nodes[i].Tag = "1";
                nodecha.ImageIndex = 0;
                for (int j = 0; j < _TW2.GetDataTWChild(item_MaKV, "Vacant").Rows.Count; j++)
                {
                    TreeNode nodecon = treeView2.Nodes[i].Nodes.Add(_TW2.GetDataTWChild(item_MaKV, "Vacant").Rows[j][1].ToString());
                    treeView2.Nodes[i].Nodes[j].Tag = "2";
                    treeView2.Nodes[i].Nodes[j].Name = _TW2.GetDataTWChild(item_MaKV, "Vacant").Rows[j][0].ToString();
                    nodecon.ImageIndex = 1;
                    nodecon.SelectedImageIndex = 1;
                }

            } treeView2.ExpandAll();
        }

        private void Load_CB_KV()
        {
            Room _CbData = new Room();
            cbKhuVuc.DisplayMember = "TenKhuVuc";
            cbKhuVuc.ValueMember = "MaKhuVuc";
            cbKhuVuc.DataSource = _CbData.GetDataTW();



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)

        {

            listKhach.Items.Clear();
            TreeNode theNode = this.treeView1.SelectedNode;
            KhachThueBUS _ListKT = new KhachThueBUS();
            if (theNode.Tag.ToString() == "2")
            {
                for (int i = 0; i < _ListKT.GetKhach(theNode.Name.ToString()).Rows.Count; i++)
                {
                    ListViewItem item = new ListViewItem(_ListKT.GetKhach(theNode.Name.ToString()).Rows[i][0].ToString());
                    if (_ListKT.GetKhach(theNode.Name.ToString()).Rows[i][2].ToString() == "Nam") item.ImageIndex = 3; else item.ImageIndex = 2;
                    item.SubItems.Add(_ListKT.GetKhach(theNode.Name.ToString()).Rows[i][1].ToString());
                    DateTime dt = DateTime.ParseExact(_ListKT.GetKhach(theNode.Name.ToString()).Rows[i][3].ToString(), "M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                    string s = dt.ToString("dd/M/yyyy", CultureInfo.InvariantCulture);
                    item.SubItems.Add(s);
                    item.SubItems.Add(_ListKT.GetKhach(theNode.Name.ToString()).Rows[i][4].ToString());
                    item.SubItems.Add(_ListKT.GetKhach(theNode.Name.ToString()).Rows[i][5].ToString());

                    listKhach.Items.Add(item);                  
                }             
            }           
        }

        private void cbKhuVuc_SelectedIndexChanged(object sender, EventArgs e)
        {

            listHoaDon.Items.Clear();
            string khuvuc = cbKhuVuc.SelectedValue.ToString();
            HoadonBUS dsHoaDon = new HoadonBUS();
            for (int i = 0; i < dsHoaDon.GetInfo(khuvuc).Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(dsHoaDon.GetInfo(khuvuc).Rows[i][0].ToString());
                item.SubItems.Add(dsHoaDon.GetInfo(khuvuc).Rows[i][2].ToString().Substring(6));
                item.SubItems.Add("50000");
                listHoaDon.Items.Add(item);

            }
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSoftInfo form = new frmSoftInfo();
            form.Show();
        }

        private void listHoaDon_Click(object sender, EventArgs e)
        {
            ListViewItem item = listHoaDon.SelectedItems[0];
            string id = item.Text;
            grCTHD.Visible = true;
            grCTHD.Text = "Chi tiết hóa đơn " + id;
        }

        private void listKhach_Click(object sender, EventArgs e)
        {
            ListViewItem item = listKhach.SelectedItems[0];
            string id = item.Text;

            frmInformation frmInfo = new frmInformation(id);
            frmInfo.Show();
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listKhach.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmTinhTien form = new frmTinhTien();
            form.Show();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoginOption frm = new frmLoginOption(USER, PASS);
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmReportOption frmRO = new frmReportOption();
            frmRO.Show();
        }

        private void phòngTrọToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRoomManagement frm = new frmRoomManagement();
            frm.Show();
        }

   

        

        
       
      

       

      

        
    }
}
