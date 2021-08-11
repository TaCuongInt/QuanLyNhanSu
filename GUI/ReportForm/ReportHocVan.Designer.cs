namespace GUI.ReportForm
{
    partial class ReportHocVan
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
            this.viewHocVanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QLNSDataSet = new GUI.QLNSDataSet();
            this.report_hocVan = new Microsoft.Reporting.WinForms.ReportViewer();
            this.view_HocVanTableAdapter = new GUI.QLNSDataSetTableAdapters.View_HocVanTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.viewHocVanBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLNSDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // viewHocVanBindingSource
            // 
            this.viewHocVanBindingSource.DataMember = "View_HocVan";
            this.viewHocVanBindingSource.DataSource = this.QLNSDataSet;
            // 
            // QLNSDataSet
            // 
            this.QLNSDataSet.DataSetName = "QLNSDataSet";
            this.QLNSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // report_hocVan
            // 
            this.report_hocVan.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.report_hocVan.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet";
            reportDataSource1.Value = this.viewHocVanBindingSource;
            this.report_hocVan.LocalReport.DataSources.Add(reportDataSource1);
            this.report_hocVan.LocalReport.ReportEmbeddedResource = "GUI.Report.ReportHocVan.rdlc";
            this.report_hocVan.Location = new System.Drawing.Point(0, 0);
            this.report_hocVan.Name = "report_hocVan";
            this.report_hocVan.Size = new System.Drawing.Size(790, 368);
            this.report_hocVan.TabIndex = 0;
            this.report_hocVan.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // view_HocVanTableAdapter
            // 
            this.view_HocVanTableAdapter.ClearBeforeFill = true;
            // 
            // ReportHocVan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(790, 368);
            this.Controls.Add(this.report_hocVan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ReportHocVan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Học Vấn";
            this.Load += new System.EventHandler(this.ReportHocVan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewHocVanBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLNSDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer report_hocVan;
        private QLNSDataSet QLNSDataSet;
        private System.Windows.Forms.BindingSource viewHocVanBindingSource;
        private QLNSDataSetTableAdapters.View_HocVanTableAdapter view_HocVanTableAdapter;

    }
}