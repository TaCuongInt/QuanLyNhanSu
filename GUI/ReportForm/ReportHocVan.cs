using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI.ReportForm
{
    public partial class ReportHocVan : Form
    {
        public ReportHocVan()
        {
            InitializeComponent();
        }

        private void ReportHocVan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLNSDataSet.View_HocVan' table. You can move, or remove it, as needed.
            this.view_HocVanTableAdapter.Fill(this.QLNSDataSet.View_HocVan);
            this.report_hocVan.RefreshReport();
        }
    }
}
