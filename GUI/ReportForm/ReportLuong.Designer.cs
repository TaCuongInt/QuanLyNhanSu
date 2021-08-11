namespace GUI.ReportForm
{
    partial class ReportLuong
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.report_luong = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QLNSDataSet = new GUI.QLNSDataSet();
            this.luongBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.luongTableAdapter = new GUI.QLNSDataSetTableAdapters.LuongTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QLNSDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luongBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // report_luong
            // 
            this.report_luong.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.report_luong.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet";
            reportDataSource2.Value = this.luongBindingSource;
            this.report_luong.LocalReport.DataSources.Add(reportDataSource2);
            this.report_luong.LocalReport.ReportEmbeddedResource = "GUI.Report.ReportLuong.rdlc";
            this.report_luong.Location = new System.Drawing.Point(0, 0);
            this.report_luong.Name = "report_luong";
            this.report_luong.Size = new System.Drawing.Size(784, 362);
            this.report_luong.TabIndex = 0;
            this.report_luong.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // QLNSDataSet
            // 
            this.QLNSDataSet.DataSetName = "QLNSDataSet";
            this.QLNSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // luongBindingSource
            // 
            this.luongBindingSource.DataMember = "Luong";
            this.luongBindingSource.DataSource = this.QLNSDataSet;
            // 
            // luongTableAdapter
            // 
            this.luongTableAdapter.ClearBeforeFill = true;
            // 
            // ReportLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(784, 362);
            this.Controls.Add(this.report_luong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ReportLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Lương";
            this.Load += new System.EventHandler(this.ReportLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QLNSDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luongBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer report_luong;
        private QLNSDataSet QLNSDataSet;
        private System.Windows.Forms.BindingSource luongBindingSource;
        private QLNSDataSetTableAdapters.LuongTableAdapter luongTableAdapter;
    }
}