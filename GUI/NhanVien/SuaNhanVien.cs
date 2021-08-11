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

namespace GUI.NhanVien
{
    public partial class SuaNhanVien : Form
    {
        private Main main;
        private string maNV;
        private KetNoi kn;
        private DataTable dt;
        private SqlDataReader dr;
        private string itemSelectHVTrinhDo, itemSelectHVChuyenNganh, itemSelectCV, itemSelectPB, itemSelectLCB, itemSelectHSL, itemSelectHSPC;
        private string tenCV, tenPB, luongCoBan, heSoLuong, heSoPhuCap;

        public SuaNhanVien()
        {
            InitializeComponent();
        }

        public SuaNhanVien(Main main,string maNV)
        {
            InitializeComponent();
            this.main = main;
            this.maNV = maNV;
        }

        private void SuaNhanVien_Load(object sender, EventArgs e)
        {
            kn = new KetNoi();
            dt = kn.GetTable("SELECT NhanVien.maNV,hoTen,gioiTinh,ngaySinh,ngayVaoLam,queQuan,danToc,soDienThoai,soCMTND,email,tenTD,tenCN,tenCV,tenPB,luongCoBan,heSoLuong,heSoPhuCap FROM NhanVien,HoSoNhanVien,HocVan,TrinhDo,ChuyenNganh,ChucVu,PhongBan,Luong WHERE NhanVien.maNV=HoSoNhanVien.maNV AND TrinhDo.maTD=HocVan.maTD AND ChuyenNganh.maCN=HocVan.maCN AND HocVan.maHV=NhanVien.maHV AND ChucVu.maCV=NhanVien.maCV AND PhongBan.maPB=NhanVien.maPB AND Luong.maL=NhanVien.maL AND NhanVien.maNV='" + maNV + "'");
            LoadData();
            txt_maNV.Text = dt.Rows[0][0].ToString();
            txt_hoTen.Text = dt.Rows[0][1].ToString();
            //
            dtp_ngaySinh.Value = Convert.ToDateTime(dt.Rows[0][3].ToString());
            dtp_ngayVaoLam.Value = Convert.ToDateTime(dt.Rows[0][4].ToString());
            txt_queQuan.Text = dt.Rows[0][5].ToString();
            txt_danToc.Text = dt.Rows[0][6].ToString();
            txt_soDienThoai.Text = dt.Rows[0][7].ToString();
            txt_soCMTND.Text = dt.Rows[0][8].ToString();
            txt_email.Text = dt.Rows[0][9].ToString();
            //
            //
            //
            //
            //
            //
            //
        }

        private void btn_sua_Click(object sender, EventArgs e)
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
                hasError = true;
                error += "- Nhập chưa đúng email!\n";
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
                itemSelectHVChuyenNganh = cbb_tenCN.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                hasError = true;
                error += "- Lỗi chưa chọn chuyên ngành học vấn!\n";
            }
            try
            {
                itemSelectCV = cbb_tenCV.SelectedItem.ToString();
            }
            catch (Exception ex)
            {
                hasError = true;
                error += "- Lỗi chưa chọn chức vụ!\n";
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
                DataTable dt = new KetNoi().GetTable("SELECT * FROM NhanVien,PhongBan,ChucVu WHERE PhongBan.maPB=NhanVien.maPB AND ChucVu.maCV=NhanVien.maCV AND maNV!='"+maNV+"' AND tenCV=N'" + itemSelectCV + "' AND tenPB=N'" + itemSelectPB + "'");
                if (dt.Rows.Count == 1)
                {
                    DialogResult dr = MessageBox.Show("Phòng ban " + itemSelectPB + " đã có " + itemSelectCV + ".\nĐể nhân viên này làm trưởng phòng thì bạn\nphải thay đổi chức vụ của Trưởng Phòng hiện tại! ", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        SuaNhanVien snv = new SuaNhanVien(main, dt.Rows[0][0].ToString());
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
            nv_dto.MaL = GetMaL(itemSelectLCB, itemSelectHSL, itemSelectHSPC);        
            HoSoNhanVien_DTO hsnv_dto = new HoSoNhanVien_DTO();
            hsnv_dto.MaNV = txt_maNV.Text;
            hsnv_dto.HoTen = txt_hoTen.Text;
            hsnv_dto.GioiTinh = cbb_gioiTinh.SelectedItem.ToString();
            hsnv_dto.NgaySinh = dtp_ngaySinh.Value;
            hsnv_dto.NgayVaoLam = dtp_ngayVaoLam.Value;
            hsnv_dto.QueQuan = txt_queQuan.Text;
            hsnv_dto.DanToc = txt_danToc.Text;
            hsnv_dto.SoDienThoai = txt_soDienThoai.Text;
            hsnv_dto.SoCMTND = txt_soCMTND.Text;
            hsnv_dto.Email = txt_email.Text;
            NhanVien_ChucVu_DTO nv_cv_dto = new NhanVien_ChucVu_DTO();
            nv_cv_dto.MaNV = txt_maNV.Text;
            nv_cv_dto.MaCV = GetMaCV(itemSelectCV);
            nv_cv_dto.NgayNhanChuc = DateTime.Now;
            NhanVien_Luong_DTO nv_l_dto = new NhanVien_Luong_DTO();
            nv_l_dto.MaNV = txt_maNV.Text;
            nv_l_dto.MaL = GetMaL(itemSelectLCB, itemSelectHSL, itemSelectHSPC);
            nv_l_dto.NgayCapNhat = DateTime.Now;

            DialogResult sua = MessageBox.Show("Bạn có chắc chắn?", "Sửa Nhân Viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sua == DialogResult.No)
                return;

            try
            {  
                NhanVien_BUS nv_bus = new NhanVien_BUS();
                nv_bus.Sua(nv_dto);
                HoSoNhanVien_BUS hsnv_bus = new HoSoNhanVien_BUS();
                hsnv_bus.Sua(hsnv_dto);
                if (!tenCV.Equals(itemSelectCV))
                {
                    NhanVien_ChucVu_BUS nv_cv_bus = new NhanVien_ChucVu_BUS();
                    nv_cv_bus.Them(nv_cv_dto);
                }
                if (!luongCoBan.Equals(itemSelectLCB) || !heSoLuong.Equals(itemSelectHSL) || !heSoPhuCap.Equals(itemSelectHSPC))
                {
                    NhanVien_Luong_BUS nv_l_bus = new NhanVien_Luong_BUS();
                    nv_l_bus.Them(nv_l_dto);
                }

                if (tenCV.Equals("Trưởng Phòng"))
                {
                    DataTable dt = new KetNoi().GetTable("SELECT * FROM PhongBan WHERE maPB='" + GetMaPB(tenPB) + "'");
                    PhongBan_DTO pb_dto = new PhongBan_DTO();
                    pb_dto.MaPB = dt.Rows[0][0].ToString();
                    pb_dto.TenPB = dt.Rows[0][1].ToString();
                    pb_dto.TenTruongPhong = null;
                    pb_dto.DiaChiPB = dt.Rows[0][3].ToString();
                    pb_dto.SoDienThoaiPB = dt.Rows[0][4].ToString();
                    PhongBan_BUS pb_bus = new PhongBan_BUS();
                    pb_bus.Sua(pb_dto);
                }

                if (itemSelectCV.Equals("Trưởng Phòng"))
                {
                    DataTable dt = new KetNoi().GetTable("SELECT * FROM PhongBan WHERE maPB='" + GetMaPB(itemSelectPB) + "'");
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
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            // ComboBox Giới tính
            cbb_gioiTinh.Items.Add("Nam");
            cbb_gioiTinh.Items.Add("Nữ");
            cbb_gioiTinh.SelectedItem = dt.Rows[0][2].ToString();

            // ComboBox Tên Trình độ
            LoadComboBox(cbb_tenTD, "SELECT DISTINCT tenTD FROM HocVan,TrinhDo WHERE TrinhDo.maTD=HocVan.maTD");
            cbb_tenTD.SelectedItem = dt.Rows[0][10].ToString();

            // Load ComboBox Chuyên ngành
            LoadComboBox(cbb_tenCN, "SELECT DISTINCT tenCN FROM (ChuyenNganh INNER JOIN HocVan ON ChuyenNganh.maCN=HocVan.maCN) INNER JOIN TrinhDo ON TrinhDo.maTD=HocVan.maTD WHERE tenTD=N'" + cbb_tenTD.SelectedItem.ToString() + "'");
            cbb_tenCN.SelectedItem = dt.Rows[0][11].ToString();

            // Load ComboBox Chuc Vu
            LoadComboBox(cbb_tenCV, "SELECT DISTINCT tenCV FROM ChucVu");
            cbb_tenCV.SelectedItem = dt.Rows[0][12].ToString();
            tenCV = dt.Rows[0][12].ToString();

            // Load ComboBox Phong Ban
            LoadComboBox(cbb_tenPB, "SELECT DISTINCT tenPB FROM PhongBan");
            cbb_tenPB.SelectedItem = dt.Rows[0][13].ToString();
            tenPB = dt.Rows[0][13].ToString();

            //Load ComboBox Luong Co Ban
            LoadComboBox(cbb_luongCoBan, "SELECT DISTINCT luongCoBan FROM LUONG");
            cbb_luongCoBan.SelectedItem = dt.Rows[0][14].ToString();
            luongCoBan = dt.Rows[0][14].ToString();
            
            // Load ComboBox hệ số lương
            LoadComboBox(cbb_heSoLuong, "SELECT DISTINCT heSoLuong FROM Luong WHERE luongCoBan='" + cbb_luongCoBan.SelectedItem.ToString() + "'");
            cbb_heSoLuong.SelectedItem = dt.Rows[0][15].ToString();
            heSoLuong = dt.Rows[0][15].ToString();

            // Load ComboBox hệ số phụ cấp
            LoadComboBox(cbb_heSoPhuCap, "SELECT heSoPhuCap FROM Luong WHERE luongCoBan='" + cbb_luongCoBan.SelectedItem.ToString() + "' AND heSoLuong='" + cbb_heSoLuong.SelectedItem.ToString() + "'");
            cbb_heSoPhuCap.SelectedItem = dt.Rows[0][16].ToString();
            heSoPhuCap = dt.Rows[0][16].ToString();
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

        #region ComboBox Select
        // ComboBox Trình Độ Select
        private void cbb_tenTD_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Load ComboBox Chuyên ngành
            LoadComboBox(cbb_tenCN, "SELECT DISTINCT tenCN FROM (ChuyenNganh INNER JOIN HocVan ON ChuyenNganh.maCN=HocVan.maCN) INNER JOIN TrinhDo ON TrinhDo.maTD=HocVan.maTD WHERE tenTD=N'" + cbb_tenTD.SelectedItem.ToString() + "'");
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
            LoadComboBox(cbb_heSoPhuCap, "SELECT heSoPhuCap FROM Luong WHERE luongCoBan='" + cbb_luongCoBan.SelectedItem.ToString() + "' AND heSoLuong='" + cbb_heSoLuong.SelectedItem.ToString() + "'");
        } 
        #endregion

        private void LoadComboBox(ComboBox comboBox, string sql)
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
