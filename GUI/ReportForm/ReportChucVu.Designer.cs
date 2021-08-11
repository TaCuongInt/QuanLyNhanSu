namespace GUI.ReportForm
{
    partial class ReportChucVu
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
            this.chucVuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QLNSDataSet = new GUI.QLNSDataSet();
            this.report_chucVu = new Microsoft.Reporting.WinForms.ReportViewer();
            this.chucVuTableAdapter = new GUI.QLNSDataSetTableAdapters.ChucVuTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.chucVuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLNSDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // chucVuBindingSource
            // 
            this.chucVuBindingSource.DataMember = "ChucVu";
            this.chucVuBindingSource.DataSource = this.QLNSDataSet;
            // 
            // QLNSDataSet
            // 
            this.QLNSDataSet.DataSetName = "QLNSDataSet";
            this.QLNSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // report_chucVu
            // 
            this.report_chucVu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.report_chucVu.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet";
            reportDataSource1.Value = this.chucVuBindingSource;
            this.report_chucVu.LocalReport.DataSources.Add(reportDataSource1);
            this.report_chucVu.LocalReport.ReportEmbeddedResource = "GUI.Report.ReportChucVu.rdlc";
            this.report_chucVu.Location = new System.Drawing.Point(0, 0);
            this.report_chucVu.Name = "report_chucVu";
            this.report_chucVu.Size = new System.Drawing.Size(790, 368);
            this.report_chucVu.TabIndex = 0;
            this.report_chucVu.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // chucVuTableAdapter
            // 
            this.chucVuTableAdapter.ClearBeforeFill = true;
            // 
            // ReportChucVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(790, 368);
            this.Controls.Add(this.report_chucVu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ReportChucVu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Chức Vụ";
            this.Load += new System.EventHandler(this.ReportChucVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chucVuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLNSDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer report_chucVu;
        private QLNSDataSet QLNSDataSet;
        private System.Windows.Forms.BindingSource chucVuBindingSource;
        private QLNSDataSetTableAdapters.ChucVuTableAdapter chucVuTableAdapter;
    }
}