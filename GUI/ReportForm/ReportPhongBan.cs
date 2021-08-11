using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI.ReportForm
{
    public partial class ReportPhongBan : Form
    {
        public ReportPhongBan()
        {
            InitializeComponent();
        }

        private void ReportPhongBan_Load(object sender, EventArgs e)
        {
            this.phongBanTableAdapter.Fill(this.QLNSDataSet.PhongBan);

            this.report_phongBan.RefreshReport();
        }
    }
}
