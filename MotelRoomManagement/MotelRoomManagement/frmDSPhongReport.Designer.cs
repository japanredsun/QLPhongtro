namespace MotelRoomManagement
{
    partial class frmDSPhongReport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dSPhongBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSPhong = new MotelRoomManagement.DSPhong();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.phongTableAdapter1 = new MotelRoomManagement.DSPhongTableAdapters.PhongTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dSPhongBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // dSPhongBindingSource
            // 
            this.dSPhongBindingSource.DataSource = this.dSPhong;
            this.dSPhongBindingSource.Position = 0;
            // 
            // dSPhong
            // 
            this.dSPhong.DataSetName = "DSPhong";
            this.dSPhong.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dSPhongBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MotelRoomManagement.DSPhongReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(857, 377);
            this.reportViewer1.TabIndex = 0;
            // 
            // phongTableAdapter1
            // 
            this.phongTableAdapter1.ClearBeforeFill = true;
            // 
            // frmDSPhongReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 377);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.Name = "frmDSPhongReport";
            this.Text = "frmDSPhongReport";
            this.Load += new System.EventHandler(this.frmDSPhongReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dSPhongBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSPhong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dSPhongBindingSource;
        private DSPhong dSPhong;
        private DSPhongTableAdapters.PhongTableAdapter phongTableAdapter1;
    }
}