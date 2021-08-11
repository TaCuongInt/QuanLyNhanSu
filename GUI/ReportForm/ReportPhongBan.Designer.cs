namespace GUI.ReportForm
{
    partial class ReportPhongBan
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
            this.phongBanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QLNSDataSet = new GUI.QLNSDataSet();
            this.report_phongBan = new Microsoft.Reporting.WinForms.ReportViewer();
            this.phongBanTableAdapter = new GUI.QLNSDataSetTableAdapters.PhongBanTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.phongBanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLNSDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // phongBanBindingSource
            // 
            this.phongBanBindingSource.DataMember = "PhongBan";
            this.phongBanBindingSource.DataSource = this.QLNSDataSet;
            // 
            // QLNSDataSet
            // 
            this.QLNSDataSet.DataSetName = "QLNSDataSet";
            this.QLNSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // report_phongBan
            // 
            this.report_phongBan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.report_phongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet";
            reportDataSource1.Value = this.phongBanBindingSource;
            this.report_phongBan.LocalReport.DataSources.Add(reportDataSource1);
            this.report_phongBan.LocalReport.ReportEmbeddedResource = "GUI.Report.ReportPhongBan.rdlc";
            this.report_phongBan.Location = new System.Drawing.Point(0, 0);
            this.report_phongBan.Name = "report_phongBan";
            this.report_phongBan.Size = new System.Drawing.Size(784, 362);
            this.report_phongBan.TabIndex = 0;
            this.report_phongBan.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // phongBanTableAdapter
            // 
            this.phongBanTableAdapter.ClearBeforeFill = true;
            // 
            // ReportPhongBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Controls.Add(this.report_phongBan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ReportPhongBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Phòng Ban";
            this.Load += new System.EventHandler(this.ReportPhongBan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.phongBanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLNSDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer report_phongBan;
        private QLNSDataSet QLNSDataSet;
        private System.Windows.Forms.BindingSource phongBanBindingSource;
        private QLNSDataSetTableAdapters.PhongBanTableAdapter phongBanTableAdapter;
    }
}