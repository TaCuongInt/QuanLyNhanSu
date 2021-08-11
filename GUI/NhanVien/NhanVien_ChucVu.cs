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

namespace GUI.NhanVien
{
    public partial class NhanVien_ChucVu : Form
    {
        private string maNV;
        public NhanVien_ChucVu()
        {
            InitializeComponent();
        }

        public NhanVien_ChucVu(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }

        private void NhanVien_ChucVu_Load(object sender, EventArgs e)
        {
            dgv_nhanVien_ChucVu.DataSource = new KetNoi().GetTable("SELECT tenCV,ngayNhanChuc FROM NhanVien,ChucVu,NhanVien_ChucVu WHERE NhanVien.maNV=NhanVien_ChucVu.maNV AND ChucVu.maCV=NhanVien_ChucVu.maCV AND NhanVien_ChucVu.maNV='"+maNV+"' ORDER BY ngayNhanChuc DESC");
            SetTableNhanVien_HocVan();
        }
        private void SetTableNhanVien_HocVan()
        {
            string[] nameCol = {"Tên Chức Vụ","Ngày Nhận Chức"};
            for (int i = 0; i < nameCol.Length; i++)
            {
                dgv_nhanVien_ChucVu.Columns[i].HeaderText = nameCol[i];
            }
        }
    }
}
