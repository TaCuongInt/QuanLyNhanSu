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
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace GUI.NhanVien
{
    public partial class ThemNhanVien : Form
    {
        private Main main;
        private SqlDataReader dr;
        private KetNoi kn;
        private string itemSelectHVTrinhDo, itemSelectHVChuyenNganh, itemSelectCV, itemSelectPB,itemSelectLCB,itemSelectHSL,itemSelectHSPC;

        public ThemNhanVien()
        {
            InitializeComponent();
        }

        public ThemNhanVien(Main main)
        {
            InitializeComponent();
            this.main = main; 
        }

        private void ThemNhanVien_Load(object sender, EventArgs e)
        {
            LoadMaNV();
            LoadData();
        }
        
        private void btn_them_Click(object sender, EventArgs e)
        {
            string error = "Lỗi nhập dữ liệu !!!\n";
            bool hasError = false;

            if (txt_hoTen.Text.Trim().Equals(""))
            {
                hasError = true;
                error += "- Lỗi chưa nhập họ tên!\n";
            }

            if (dtp_ngaySinh.Value.CompareTo(dtp_ngayVaoLam.Value) >= 0)
            {
                hasError = true;
                error += "- Lỗi chọn ngày vào làm!\n";
            }

            if (txt_queQuan.Text.Trim().Equals(""))
            {
                hasError = true;
                error += "- Lỗi chưa nhập quê quán!\n";
            }

            if (txt_danToc.Text.Trim().Equals(""))
            {
                hasError = true;
                error += "- Lỗi chưa nhập dân tộc!\n";
            }

            if (!Regex.IsMatch(txt_soDienThoai.Text, @"^0\d{9,10}$"))
            {
                hasError = true;
                error += "- Nhập chưa đúng số điện thoại!\n";
            }

            if (!Regex.IsMatch(txt_soCMTND.Text, @"^\d{9}$"))
            {
                hasError = true;
                error += "- Nhập chưa đúng số chứng minh!\n";
            }

            if (!Regex.IsMatch(txt_email.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                hasError=true;
                error+="- Nhập chưa đúng email!\n";
            }

            #region Bắt lỗi ComboBox
            try
            {
                itemSelectHVTrinhDo = cbb_tenTD.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                hasError = true;
                error += "- Lỗi chưa chọn trình độ học vấn!\n";
            }
            try
            {
                itemSelectHVChuyenNganh=cbb_tenCN.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                hasError = true;
                error+="- Lỗi chưa chọn chuyên ngành học vấn!\n";
            }
            try
            {
                itemSelectCV = cbb_tenCV.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                hasError = true;
                error+="- Lỗi chưa chọn chức vụ!\n";
            }
            try
            {
                itemSelectPB = cbb_tenPB.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                hasError = true;
                error += "- Lỗi chưa chọn phòng ban!\n";
            }
            try
            {
                itemSelectLCB = cbb_luongCoBan.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                hasError = true;
                error += "- Lỗi chưa chọn lương cơ bản!\n";
            }
            try
            {
                itemSelectHSL = cbb_heSoLuong.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                hasError = true;
                error += "- Lỗi chưa chọn hệ số lương!\n";
            }
            try
            {
                itemSelectHSPC = cbb_heSoPhuCap.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                hasError = true;
                error += "- Lỗi chưa chọn hệ số phụ cấp!\n";
            }
            #endregion

            if (hasError)
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (itemSelectCV.Equals("Trưởng Phòng"))
            {
                DataTable dt = new KetNoi().GetTable("SELECT * FROM NhanVien,PhongBan,ChucVu WHERE PhongBan.maPB=NhanVien.maPB AND ChucVu.maCV=NhanVien.maCV AND tenCV=N'" + itemSelectCV + "' AND tenPB=N'" + itemSelectPB + "'");
                if (dt.Rows.Count == 1)
                {
                    DialogResult dr= MessageBox.Show("Phòng ban "+itemSelectPB+" đã có "+itemSelectCV+".\nĐể người này làm trưởng phòng thì bạn\nphải thay đổi chức vụ của Trưởng Phòng hiện tại! ","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        SuaNhanVien snv = new SuaNhanVien(main,dt.Rows[0][0].ToString());
                        snv.Show();
                    }
                    return;
                }
            }

            NhanVien_DTO nv_dto = new NhanVien_DTO();
            nv_dto.MaNV = txt_maNV.Text;
            nv_dto.MaHV = GetMaHV(itemSelectHVTrinhDo, itemSelectHVChuyenNganh); 
            nv_dto.MaCV = GetMaCV(itemSelectCV);
            nv_dto.MaPB = GetMaPB(itemSelectPB);
            nv_dto.MaL = GetMaL(itemSelectLCB,itemSelectHSL,itemSelectHSPC);
            HoSoNhanVien_DTO hsnv_dto=new HoSoNhanVien_DTO();
            hsnv_dto.MaNV = txt_maNV.Text;
            hsnv_dto.HoTen=txt_hoTen.Text;
            hsnv_dto.GioiTinh=cbb_gioiTinh.SelectedItem.ToString();
            hsnv_dto.NgaySinh=dtp_ngaySinh.Value;
            hsnv_dto.NgayVaoLam=dtp_ngayVaoLam.Value;
            hsnv_dto.QueQuan=txt_queQuan.Text;
            hsnv_dto.DanToc=txt_danToc.Text;
            hsnv_dto.SoDienThoai=txt_soDienThoai.Text;
            hsnv_dto.SoCMTND=txt_soCMTND.Text;
            hsnv_dto.Email=txt_email.Text;
            NhanVien_ChucVu_DTO nv_cv_dto = new NhanVien_ChucVu_DTO();
            nv_cv_dto.MaNV = txt_maNV.Text;
            nv_cv_dto.MaCV = GetMaCV(itemSelectCV);
            nv_cv_dto.NgayNhanChuc = dtp_ngayVaoLam.Value;
            NhanVien_Luong_DTO nv_l_dto = new NhanVien_Luong_DTO();
            nv_l_dto.MaNV = txt_maNV.Text;
            nv_l_dto.MaL = GetMaL(itemSelectLCB, itemSelectHSL, itemSelectHSPC);
            nv_l_dto.NgayCapNhat = dtp_ngayVaoLam.Value;
            try
            {
                NhanVien_BUS nv_bus = new NhanVien_BUS();
                nv_bus.Them(nv_dto);
                HoSoNhanVien_BUS hsnv_bus = new HoSoNhanVien_BUS();
                hsnv_bus.Them(hsnv_dto);
                NhanVien_ChucVu_BUS nv_cv_bus = new NhanVien_ChucVu_BUS();
                nv_cv_bus.Them(nv_cv_dto);
                NhanVien_Luong_BUS nv_l_bus = new NhanVien_Luong_BUS();
                nv_l_bus.Them(nv_l_dto);
                if (itemSelectCV.Equals("Trưởng Phòng"))
                {
                    DataTable dt = new KetNoi().GetTable("SELECT * FROM PhongBan WHERE maPB='"+GetMaPB(itemSelectPB)+"'");
                    PhongBan_DTO pb_dto = new PhongBan_DTO();
                    pb_dto.MaPB = dt.Rows[0][0].ToString();
                    pb_dto.TenPB = dt.Rows[0][1].ToString();
                    pb_dto.TenTruongPhong = txt_hoTen.Text;
                    pb_dto.DiaChiPB = dt.Rows[0][3].ToString();
                    pb_dto.SoDienThoaiPB = dt.Rows[0][4].ToString();
                    PhongBan_BUS pb_bus = new PhongBan_BUS();
                    pb_bus.Sua(pb_dto);
                }
                main.LoadListNhanVien();
                //main.LoadHieuUng(1);
                if (!cb_themNhieu.Checked)
                    this.Close();
                LoadMaNV();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMaNV()
        {
            string maNV = KiemTraMaDauTien("SELECT *From NhanVien WHERE maNV='NV000'") ? MaTuDong("SELECT TOP 1 maNV FROM NhanVien ORDER BY maNV DESC", "NV") : "NV000";
            txt_maNV.Text = maNV;
        }

        private void LoadData()
        {
            kn = new KetNoi();
            // Load ComboBox Gioi Tinh
            cbb_gioiTinh.Items.Add("Nam");
            cbb_gioiTinh.Items.Add("Nữ");
            cbb_gioiTinh.SelectedItem = "Nam";
            // Load ComboBox Tên Trình Độ
            LoadComboBox(cbb_tenTD, "SELECT DISTINCT tenTD FROM HocVan,TrinhDo WHERE TrinhDo.maTD=HocVan.maTD");
            // Load ComboBox Chuc Vu
            LoadComboBox(cbb_tenCV, "SELECT DISTINCT tenCV FROM ChucVu");
            // Load ComboBox Phong Ban
            LoadComboBox(cbb_tenPB, "SELECT DISTINCT tenPB FROM PhongBan");
            //Load ComboBox Luong Co Ban
            LoadComboBox(cbb_luongCoBan, "SELECT DISTINCT luongCoBan FROM LUONG");
        }

        #region Get mã
        // Get maHV
        private string GetMaHV(string tenTD, string tenCN)
        {
            kn = new KetNoi();
            DataTable dt = kn.GetTable("SELECT DISTINCT * FROM HocVan,TrinhDo,ChuyenNganh WHERE TrinhDo.maTD=HocVan.maTD AND ChuyenNganh.maCN=HocVan.maCN AND tenTD=N'" + tenTD + "' AND tenCN=N'" + tenCN + "'");
            if (dt.Rows.Count >= 1)
                return dt.Rows[0][0].ToString();
            return null;
        }
        // Get maCV
        private string GetMaCV(string tenCV)
        {
            kn = new KetNoi();
            DataTable dt = kn.GetTable("SELECT DISTINCT * FROM ChucVu WHERE tenCV=N'" + tenCV + "'");
            if (dt.Rows.Count >= 1)
                return dt.Rows[0][0].ToString();
            return null;
        }
        // Get maPB
        private string GetMaPB(string tenPB)
        {
            kn = new KetNoi();
            DataTable dt = kn.GetTable("SELECT DISTINCT * FROM PhongBan WHERE tenPB=N'" + tenPB + "'");
            if (dt.Rows.Count >= 1)
                return dt.Rows[0][0].ToString();
            return null;
        }
        // Get maL
        private string GetMaL(string luogCoBan, string heSoLuong, string heSoPhuCap)
        {
            kn = new KetNoi();
            DataTable dt = kn.GetTable("SELECT DISTINCT * FROM Luong WHERE luongCoBan='" + luogCoBan + "' AND heSoLuong='" + heSoLuong + "' AND heSoPhuCap='" + heSoPhuCap + "'");
            if (dt.Rows.Count >= 1)
                return dt.Rows[0][0].ToString();
            return null;
        }
        #endregion

        #region Get mã tự động
        // Get mã tự động
        public string MaTuDong(string sqlSelect, string loaiMa)
        {
            string maNV, phanSo;
            int number = 0;
            maNV = new KetNoi().GetTable(sqlSelect).Rows[0][0].ToString();
            phanSo = maNV.Substring(loaiMa.Length, 3).ToString(); ;
            number = int.Parse(phanSo);
            number++;
            if (number < 10)
                return loaiMa + "00" + number.ToString();
            else if (number >= 10 && number < 100)
                return loaiMa.ToString() + "0" + number.ToString();
            return loaiMa + number.ToString();
        }
        public bool KiemTraMaDauTien(string sqlSelect)
        {
            DataTable dt = new KetNoi().GetTable(sqlSelect);
            if (dt.Rows.Count == 1)
                return true;
            return false;
        }
        #endregion

        #region ComboBox select
        // ComboBox Trình Độ Select
        private void cbb_tenTD_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Load ComboBox Chuyên ngành
            LoadComboBox(cbb_tenCN, "SELECT DISTINCT tenCN FROM ChuyenNganh,TrinhDo,HocVan WHERE TrinhDo.maTD=HocVan.maTD AND ChuyenNganh.maCN=HocVan.maCN AND tenTD=N'" + cbb_tenTD.SelectedItem.ToString() + "'");
        }
        // ComboBox Lương Cơ Bản Select
        private void cbb_luongCoBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Load ComboBox hệ số lương
            LoadComboBox(cbb_heSoLuong, "SELECT DISTINCT heSoLuong FROM Luong WHERE luongCoBan='" + cbb_luongCoBan.SelectedItem.ToString() + "'");
        }
        // ComboBox Hệ Số Lương Select
        private void cbb_heSoLuong_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Load ComboBox hệ số phụ cấp
            LoadComboBox(cbb_heSoPhuCap, "SELECT DISTINCT heSoPhuCap FROM Luong WHERE luongCoBan='" + cbb_luongCoBan.SelectedItem.ToString() + "' AND heSoLuong='" + cbb_heSoLuong.SelectedItem.ToString() + "'");
        } 
        #endregion

        private void LoadComboBox(ComboBox comboBox,string sql)
        {
            comboBox.Items.Clear();
            comboBox.Text = "";
            dr = new KetNoi().GetData(sql);
            while (dr.Read())
            {
                comboBox.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            txt_hoTen.Clear();
            txt_queQuan.Clear();
            txt_danToc.Clear();
            txt_soDienThoai.Clear();
            txt_soCMTND.Clear();
            txt_email.Clear();
        }

        private void btn_quayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
    }
}
