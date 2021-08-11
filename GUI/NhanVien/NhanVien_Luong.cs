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
    public partial class NhanVien_Luong : Form
    {
        private string maNV;
        public NhanVien_Luong()
        {
            InitializeComponent();
        }

        public NhanVien_Luong(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }

        private void NhanVien_Luong_Load(object sender, EventArgs e)
        {
            dgv_nhanVien_Luong.DataSource = new KetNoi().GetTable("SELECT luongCoBan,heSoLuong,heSoPhuCap,ngayCapNhat FROM NhanVien,Luong,NhanVien_Luong WHERE NhanVien.maNV=NhanVien_Luong.maNV AND Luong.maL=NhanVien_Luong.maL AND NhanVien_Luong.maNV='" + maNV + "' ORDER BY ngayCapNhat DESC");
            SetTableNhanVien_Luong();
        }
        private void SetTableNhanVien_Luong()
        {
            string[] nameCol = { "Lương Cơ Bản", "Hệ Số Lương","Hệ Số Phụ Cấp","Ngày Cập Nhật" };
            for (int i = 0; i < nameCol.Length; i++)
            {
                dgv_nhanVien_Luong.Columns[i].HeaderText = nameCol[i];
            }
        }
    }
}
