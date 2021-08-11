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
    public partial class XemNhanVien : Form
    {
        private string maNV;
        private KetNoi kn;
        public XemNhanVien()
        {
            InitializeComponent();
        }
        public XemNhanVien(string maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }

        private void XemNhanVien_Load(object sender, EventArgs e)
        {
            kn=new KetNoi();
            DataTable dt = kn.GetTable("SELECT NhanVien.maNV,hoTen,gioiTinh,ngaySinh,ngayVaoLam,queQuan,danToc,soDienThoai,soCMTND,email,NhanVien.maHV,HocVan.maCN,HocVan.maTD,tenTD,tenCN,NhanVien.maPB,tenPB,tenTruongPhong,diaChiPB,soDienThoaiPB,NhanVien.maCV,tenCV,NhanVien.maL,luongCoBan,heSoLuong,heSoPhuCap FROM NhanVien,HoSoNhanVien,HocVan,TrinhDo,ChuyenNganh,ChucVu,PhongBan,Luong WHERE NhanVien.maNV='" + maNV + "' AND NhanVien.maNV=HoSoNhanVien.maNV AND TrinhDo.maTD=HocVan.maTD AND ChuyenNganh.maCN=HocVan.maCN AND HocVan.maHV=NhanVien.maHV AND ChucVu.maCV=NhanVien.maCV AND PhongBan.maPB=NhanVien.maPB AND Luong.maL=NhanVien.maL");
            txt_maNV.Text = dt.Rows[0][0].ToString();
            txt_hoTen.Text = dt.Rows[0][1].ToString();
            cbb_gioiTinh.Text = dt.Rows[0][2].ToString();
            dtp_ngaySinh.Value = Convert.ToDateTime(dt.Rows[0][3].ToString());
            dtp_ngayVaoLam.Value = Convert.ToDateTime(dt.Rows[0][4].ToString());

            txt_queQuan.Text = dt.Rows[0][5].ToString();
            txt_danToc.Text = dt.Rows[0][6].ToString();
            txt_soDienThoai.Text = dt.Rows[0][7].ToString();
            txt_soCMTND.Text = dt.Rows[0][8].ToString();
            txt_email.Text = dt.Rows[0][9].ToString();

            txt_maHV.Text = dt.Rows[0][10].ToString();
            txt_maCN.Text = dt.Rows[0][11].ToString();
            txt_maTD.Text = dt.Rows[0][12].ToString();
            cbb_tenTrinhDo.Text = dt.Rows[0][13].ToString();
            cbb_tenCN.Text = dt.Rows[0][14].ToString();

            txt_maPB.Text = dt.Rows[0][15].ToString();
            cbb_tenPB.Text = dt.Rows[0][16].ToString();
            cbb_tenTruongPhong.Text = dt.Rows[0][17].ToString();
            txt_diaChiPB.Text = dt.Rows[0][18].ToString();
            txt_soDienThoaiPB.Text = dt.Rows[0][19].ToString();

            txt_maCV.Text = dt.Rows[0][20].ToString();

            cbb_tenCV.Text = dt.Rows[0][21].ToString();

            txt_maL.Text = dt.Rows[0][22].ToString();
            cbb_luongCoBan.Text = dt.Rows[0][23].ToString();

            cbb_heSoLuong.Text = dt.Rows[0][24].ToString();
            cbb_heSoPhuCap.Text = dt.Rows[0][25].ToString();

        }

        private void btn_quayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ptb_showNhanVien_ChucVu_Click(object sender, EventArgs e)
        {
            NhanVien_ChucVu nv_cv = new NhanVien_ChucVu(maNV);
            nv_cv.Show();
        }

        private void ptb_showNhanVien_Luong_Click(object sender, EventArgs e)
        {
            NhanVien_Luong nv_l = new NhanVien_Luong(maNV);
            nv_l.Show();
        }
    }
}
