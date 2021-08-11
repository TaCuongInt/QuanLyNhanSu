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
    public partial class ReportLuong : Form
    {
        public ReportLuong()
        {
            InitializeComponent();
        }

        private void ReportLuong_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLNSDataSet.Luong' table. You can move, or remove it, as needed.
            this.luongTableAdapter.Fill(this.QLNSDataSet.Luong);
            this.report_luong.RefreshReport();
        }
    }
}
