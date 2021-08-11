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
    public partial class ReportChucVu : Form
    {
        public ReportChucVu()
        {
            InitializeComponent();
        }

        private void ReportChucVu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLNSDataSet.ChucVu' table. You can move, or remove it, as needed.
            this.chucVuTableAdapter.Fill(this.QLNSDataSet.ChucVu);

            this.report_chucVu.RefreshReport();
        }
    }
}
