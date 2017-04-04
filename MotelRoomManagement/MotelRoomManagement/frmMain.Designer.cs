namespace MotelRoomManagement
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Day = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhongSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trangthai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thongtin = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ThuePhong = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Kind,
            this.Day,
            this.PhongSo,
            this.Trangthai,
            this.Thongtin,
            this.ThuePhong});
            this.dataGridView1.Location = new System.Drawing.Point(3, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(744, 253);
            this.dataGridView1.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Kind
            // 
            this.Kind.DataPropertyName = "Kind";
            this.Kind.HeaderText = "Loại phòng";
            this.Kind.Name = "Kind";
            // 
            // Day
            // 
            this.Day.DataPropertyName = "Day";
            this.Day.HeaderText = "Dãy";
            this.Day.Name = "Day";
            // 
            // PhongSo
            // 
            this.PhongSo.DataPropertyName = "Phongso";
            this.PhongSo.HeaderText = "Phòng số";
            this.PhongSo.Name = "PhongSo";
            // 
            // Trangthai
            // 
            this.Trangthai.DataPropertyName = "Trangthai";
            this.Trangthai.HeaderText = "Trạng thái";
            this.Trangthai.Name = "Trangthai";
            // 
            // Thongtin
            // 
            this.Thongtin.HeaderText = "Thông Tin Phòng";
            this.Thongtin.Name = "Thongtin";
            this.Thongtin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Thongtin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Thongtin.Text = "Xem thông tin";
            this.Thongtin.UseColumnTextForButtonValue = true;
            // 
            // ThuePhong
            // 
            this.ThuePhong.HeaderText = "Thuê Phòng";
            this.ThuePhong.Name = "ThuePhong";
            this.ThuePhong.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ThuePhong.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ThuePhong.Text = "Cho Thuê";
            this.ThuePhong.UseColumnTextForButtonValue = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 40);
            this.button1.TabIndex = 1;
            this.button1.Text = "Tài khoản";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(101, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "Thêm phòng";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 363);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kind;
        private System.Windows.Forms.DataGridViewTextBoxColumn Day;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhongSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trangthai;
        private System.Windows.Forms.DataGridViewButtonColumn Thongtin;
        private System.Windows.Forms.DataGridViewButtonColumn ThuePhong;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}