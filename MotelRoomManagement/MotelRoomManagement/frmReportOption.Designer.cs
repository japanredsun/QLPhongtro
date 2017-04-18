namespace MotelRoomManagement
{
    partial class frmReportOption
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDT = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDSKT = new System.Windows.Forms.Button();
            this.lbHeader = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.btnDT);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnDSKT);
            this.panel1.Location = new System.Drawing.Point(18, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 150);
            this.panel1.TabIndex = 0;
            // 
            // btnDT
            // 
            this.btnDT.BackColor = System.Drawing.Color.Tomato;
            this.btnDT.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDT.Location = new System.Drawing.Point(123, 77);
            this.btnDT.Name = "btnDT";
            this.btnDT.Size = new System.Drawing.Size(130, 62);
            this.btnDT.TabIndex = 0;
            this.btnDT.Text = "Tổng doanh thu";
            this.btnDT.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Lime;
            this.button2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(203, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 62);
            this.button2.TabIndex = 0;
            this.button2.Text = "Danh sách phòng";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // btnDSKT
            // 
            this.btnDSKT.BackColor = System.Drawing.Color.Lime;
            this.btnDSKT.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDSKT.Location = new System.Drawing.Point(43, 9);
            this.btnDSKT.Name = "btnDSKT";
            this.btnDSKT.Size = new System.Drawing.Size(130, 62);
            this.btnDSKT.TabIndex = 0;
            this.btnDSKT.Text = "Danh sách khách trọ";
            this.btnDSKT.UseVisualStyleBackColor = false;
            this.btnDSKT.Click += new System.EventHandler(this.btnDSKT_Click);
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Font = new System.Drawing.Font("Tahoma", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHeader.ForeColor = System.Drawing.Color.Khaki;
            this.lbHeader.Location = new System.Drawing.Point(4, 13);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(405, 35);
            this.lbHeader.TabIndex = 2;
            this.lbHeader.Text = "Chọn loại báo cáo cần xem";
            // 
            // frmReportOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(412, 213);
            this.Controls.Add(this.lbHeader);
            this.Controls.Add(this.panel1);
            this.Name = "frmReportOption";
            this.Text = "frmReportOption";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.Button btnDT;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnDSKT;
    }
}