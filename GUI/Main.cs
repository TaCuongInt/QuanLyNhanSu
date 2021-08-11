using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;
using DTO;
using GUI.NhanVien;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using GUI.ReportForm;

namespace GUI
{
    public partial class Main : Form
    {
        #region Khai báo biến
        private string name;
        private string role;
        private KetNoi kn;
        private SqlDataReader dr;
        private Color colorMenuBox;
        private string maNV;
        private string maHV;
        private string maCN;
        private string maTD;
        private string maCV;
        private string maPB;
        private string maL;
        private string maTK;
        private string all;
        private int itemClick;
        #endregion

        public Main(string name, string role)
        {
            InitializeComponent();
            colorMenuBox = Color.DarkCyan;
            this.name = name;
            this.role = role;
            itemClick = 0;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Text = "Quản Lý Nhân Sự - " + name;

            PhanQuyen();

            LoadListNhanVien();
            SetTableNhanVien();

            cbb_role.Items.Add("Admin");
            cbb_role.Items.Add("Manager");
            cbb_role.SelectedItem = "Manager";

            //LoadHieuUng(1);

            // Học Vấn
            LoadComboBox(cbb_tenCN, "SELECT DISTINCT tenCN FROM ChuyenNganh");
            LoadComboBox(cbb_tenTD, "SELECT DISTINCT tenTD FROM TrinhDo");

            // Report
            all = "---Tất Cả---";
            LoadComboBoxReport(cbb_phongBan, "SELECT DISTINCT tenPB FROM phongBan");
            LoadComboBoxReport(cbb_chucVu, "SELECT DISTINCT tenCV FROM ChucVu");
            LoadComboBoxReport(cbb_chuyenNganh, "SELECT DISTINCT tenCN FROM ChuyenNganh");
            LoadComboBoxReport(cbb_trinhDo, "SELECT DISTINCT tenTD FROM TrinhDo");
            SetParameter("", "", "", "");
            this.View_FilterTableAdapter.Fill(this.QLNSDataSet.View_Filter);
            this.report_nhanVien.RefreshReport();
        }

        private void PhanQuyen()
        {
            if (!role.Equals("Admin"))
            {
                btn_xemNhanVien.Visible = false;

                btn_themNhanVien.Visible = false;
                btn_themHV.Visible = false;
                btn_themCV.Visible = false;
                btn_themPB.Visible = false;
                btn_themL.Visible = false;
                btn_themTK.Visible = false;
                
                btn_suaNhanVien.Visible = false;
                btn_suaHV.Visible = false;
                btn_suaCV.Visible = false;
                btn_suaPB.Visible = false;
                btn_suaL.Visible = false;
                btn_suaTK.Visible = false;

                btn_xoaNhanVien.Visible = false;
                btn_xoaHV.Visible = false;
                btn_xoaCV.Visible = false;
                btn_xoaPB.Visible = false;
                btn_xoaL.Visible = false;
                btn_xoaTK.Visible = false;

                btn_capNhatBangNhanVien.Visible = false;
                btn_capNhatBangHV.Visible = false;
                btn_capNhatBangCV.Visible = false;
                btn_capNhatBangPB.Visible = false;
                btn_capNhatBangL.Visible = false;
                btn_capNhatBangTK.Visible = false;
            }
        }

        #region Load database vào bảng
        // Load DataBase table NhanVien
        public void LoadListNhanVien()
        {
            string sql = "SELECT NhanVien.maNV,hoTen,gioiTinh,ngaySinh,ngayVaoLam,queQuan,soDienThoai,tenCV,tenTD,tenCN,tenPB,luongCoBan FROM NhanVien,HoSoNhanVien,HocVan,TrinhDo,ChuyenNganh,ChucVu,PhongBan,Luong WHERE NhanVien.maNV=HoSoNhanVien.maNV AND TrinhDo.maTD=HocVan.maTD AND ChuyenNganh.maCN=HocVan.maCN AND HocVan.maHV=NhanVien.maHV AND ChucVu.maCV=NhanVien.maCV AND PhongBan.maPB=NhanVien.maPB AND Luong.maL=NhanVien.maL";
            dgv_nhanVien.DataSource = new KetNoi().GetTable(sql);
        }
        private void LoadListHocVan()
        {
            string sql = "SELECT HocVan.maHV,HocVan.maCN,tenCN,HocVan.maTD,tenTD FROM HocVan,ChuyenNganh,TrinhDo WHERE ChuyenNganh.maCN=HocVan.maCN AND TrinhDo.maTD=HocVan.maTD";
            dgv_hocVan.DataSource = new KetNoi().GetTable(sql);
        }
        private void LoadListChucVu()
        {
            string sql = "SELECT * FROM ChucVu";
            dgv_chucVu.DataSource = new KetNoi().GetTable(sql);
        }
        private void LoadListPhongBan()
        {
            string sql = "SELECT * FROM PhongBan";
            dgv_phongBan.DataSource = new KetNoi().GetTable(sql);
        }
        private void LoadListLuong()
        {
            string sql = "SELECT * FROM Luong";
            dgv_luong.DataSource = new KetNoi().GetTable(sql);
        }
        private void LoadListTaiKhoan()
        {
            string sql = "SELECT * FROM Account";
            dgv_taiKhoan.DataSource = new KetNoi().GetTable(sql);
        }

        #endregion

        #region Set Table
        // Set name, width table NhanVien
        private void SetTableNhanVien()
        {
            string[] nameCol = { "Mã NV", "Họ Tên", "Giới Tính", "Ngày Sinh", "Ngày Vào Làm", "Quê Quán", "SĐT", "Chức Vụ", "Trình Độ", "Ngành", "Phòng Ban", "Lương Cơ Bản" };
            for (int i = 0; i < nameCol.Length; i++)
            {
                dgv_nhanVien.Columns[i].HeaderText = nameCol[i];
            }
            dgv_nhanVien.Columns[0].Width = 62;
            dgv_nhanVien.Columns[1].Width = 120;
            dgv_nhanVien.Columns[2].Width = 84;
            dgv_nhanVien.Columns[3].Width = 104;
            dgv_nhanVien.Columns[4].Width = 104;
            dgv_nhanVien.Columns[5].Width = 120;
            dgv_nhanVien.Columns[6].Width = 75;
            dgv_nhanVien.Columns[7].Width = 88;
            dgv_nhanVien.Columns[8].Width = 78;
            dgv_nhanVien.Columns[9].Width = 115;
            dgv_nhanVien.Columns[10].Width = 104;
            dgv_nhanVien.Columns[11].Width = 102;
        }
        private void SetTableHocVan()
        {
            string[] nameCol = { "Mã Học Vấn", "Mã Chuyên Ngành", "Tên Chuyên Ngành", "Mã Trình Độ", "Tên Trình Độ" };
            for (int i = 0; i < nameCol.Length; i++)
            {
                dgv_hocVan.Columns[i].HeaderText = nameCol[i];
            }
        }
        private void SetTableChucVu()
        {
            string[] nameCol = { "Mã Chức Vụ", "Tên Chức Vụ" };
            for (int i = 0; i < nameCol.Length; i++)
            {
                dgv_chucVu.Columns[i].HeaderText = nameCol[i];
            }
        }
        private void SetTablePhongBan()
        {
            string[] nameCol = { "Mã Phòng Ban", "Tên Phòng Ban", "Tên Trưởng Phòng", "Địa Chỉ Phòng Ban", "Số Điện Thoại Phòng Ban" };
            for (int i = 0; i < nameCol.Length; i++)
            {
                dgv_phongBan.Columns[i].HeaderText = nameCol[i];
            }
        }
        private void SetTableLuong()
        {
            string[] nameCol = { "Mã Lương", "Lương Cơ Bản", "Hệ Số Lương", "Hệ Số Phụ Cấp" };
            for (int i = 0; i < nameCol.Length; i++)
            {
                dgv_luong.Columns[i].HeaderText = nameCol[i];
            }
        }
        private void SetTableTaiKhoan()
        {
            string[] nameCol = { "Ussername", "Password", "Role" };
            for (int i = 0; i < nameCol.Length; i++)
            {
                dgv_taiKhoan.Columns[i].HeaderText = nameCol[i];
            }
        }

        #endregion

        #region ItemMenuClick
        // Load Tab
        private void LoadTab(Panel panelMain, Panel panelMenuMain, Color colorItemMenu, Label lbClick, Label lb1, Label lb2, Label lb3, Label lb4, Label lb5, Label lb6)
        {
            lbClick.BackColor = Color.Transparent;
            lb1.BackColor = colorItemMenu;
            lb2.BackColor = colorItemMenu;
            lb3.BackColor = colorItemMenu;
            lb4.BackColor = colorItemMenu;
            lb5.BackColor = colorItemMenu;
            lb6.BackColor = colorItemMenu;
            panelMain.BringToFront();
            panelMenuMain.BringToFront();
        }

        private void itemMenuClick(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            if (lb.Equals(lb_home))
            {
                LoadTab(pnl_home, pnl_menuNhanVien, colorMenuBox, lb_home, lb_hocVan, lb_chucVu, lb_phongBan, lb_luong, lb_taiKhoan, lb_baoCao);
                LoadListNhanVien();
                SetTableNhanVien();
                //LoadHieuUng(1);
            }
            else if (lb.Equals(lb_hocVan))
            {
                LoadTab(pnl_hocVan, pnl_menuHV, colorMenuBox, lb_hocVan, lb_home, lb_chucVu, lb_phongBan, lb_luong, lb_taiKhoan, lb_baoCao);
                LoadListHocVan();
                SetTableHocVan();
                //LoadHieuUng(2);
                LoadMaHV();
            }
            else if (lb.Equals(lb_chucVu))
            {
                LoadTab(pnl_chucVu, pnl_menuCV, colorMenuBox, lb_chucVu, lb_hocVan, lb_home, lb_phongBan, lb_luong, lb_taiKhoan, lb_baoCao);
                LoadListChucVu();
                SetTableChucVu();
                //LoadHieuUng(3);
                LoadMaCV();
            }
            else if (lb.Equals(lb_phongBan))
            {
                LoadTab(pnl_phongBan, pnl_menuPB, colorMenuBox, lb_phongBan, lb_hocVan, lb_chucVu, lb_home, lb_luong, lb_taiKhoan, lb_baoCao);
                LoadListPhongBan();
                SetTablePhongBan();
                //LoadHieuUng(4);
                LoadMaPB();
            }
            else if (lb.Equals(lb_luong))
            {
                LoadTab(pnl_luong, pnl_menuL, colorMenuBox, lb_luong, lb_hocVan, lb_chucVu, lb_phongBan, lb_home, lb_taiKhoan, lb_baoCao);
                LoadListLuong();
                SetTableLuong();
                //LoadHieuUng(5);
                LoadMaL();
            }
            else if (lb.Equals(lb_taiKhoan))
            {
                LoadTab(pnl_taiKhoan, pnl_menuTK, colorMenuBox, lb_taiKhoan, lb_hocVan, lb_chucVu, lb_phongBan, lb_luong, lb_home, lb_baoCao);
                if (!role.Equals("Admin"))
                {
                    new ThayDoiMatKhau(name).Show();
                    return;
                }
                LoadListTaiKhoan();
                SetTableTaiKhoan();
                //LoadHieuUng(6);
            }
            else if (lb.Equals(lb_baoCao))
            {
                LoadTab(pnl_baoCao, pnl_menuBC, colorMenuBox, lb_baoCao, lb_hocVan, lb_chucVu, lb_phongBan, lb_luong, lb_taiKhoan, lb_home);
                //LoadHieuUng(7);
            }
        }
        #endregion

        private void btn_themClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            #region btn_themNhanVien
            if (button.Equals(btn_themNhanVien))
            {
                ThemNhanVien tnv = new ThemNhanVien(this);
                tnv.Show();
            }
            #endregion

            #region btn_themHV
            else if (button.Equals(btn_themHV))
            {
                string error = "Lỗi nhập dữ liệu!!!\n";
                bool hasError = false;
                LoadMaHV();
                HocVan_DTO hv_dto = new HocVan_DTO();
                hv_dto.MaHV = txt_maHV.Text;
                try
                {
                    hv_dto.MaCN = GetMaCN(cbb_tenCN.SelectedItem.ToString());
                }
                catch (Exception ex)
                {
                    hasError = true;
                    error += "- Lỗi chưa chọn chuyên ngành!\n";
                }
                try
                {
                    hv_dto.MaTD = GetMaTD(cbb_tenTD.SelectedItem.ToString());
                }
                catch (Exception ex)
                {
                    hasError = true;
                    error += "- Lỗi chưa chọn trình độ!\n";
                }

                if (hasError)
                {
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                HocVan_BUS hv_bus = new HocVan_BUS();
                try
                {
                    hv_bus.Them(hv_dto);
                    LoadListHocVan();
                    LoadMaHV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion

            #region btn_themCV
            else if (button.Equals(btn_themCV))
            {
                string error = "Lỗi nhập dữ liệu!!!\n";
                bool hasError = false;
                if (txt_tenCV.Text.Trim().Equals(""))
                {
                    hasError = true;
                    error += "- Lỗi chưa nhập tên chức vụ!\n";
                }
                if (hasError)
                {
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoadMaCV();
                ChucVu_DTO cv_dto = new ChucVu_DTO();
                cv_dto.MaCV = txt_maCV.Text;
                cv_dto.TenCV = txt_tenCV.Text;
                ChucVu_BUS cv_bus = new ChucVu_BUS();
                try
                {
                    cv_bus.Them(cv_dto);
                    LoadListChucVu();
                    LoadMaCV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion

            #region btn_themPB
            else if (button.Equals(btn_themPB))
            {
                string error = "Lỗi nhập dữ liệu!!!\n";
                bool hasError = false;
                if (txt_tenPB.Text.Trim().Equals(""))
                {
                    hasError = true;
                    error += "- Lỗi chưa nhập tên phòng ban!\n";
                }
                if (hasError)
                {
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoadMaPB();
                PhongBan_DTO pb_dto = new PhongBan_DTO();
                pb_dto.MaPB = txt_maPB.Text;
                pb_dto.TenPB = txt_tenPB.Text;
                pb_dto.TenTruongPhong = null;
                pb_dto.DiaChiPB = txt_diaChiPB.Text;
                pb_dto.SoDienThoaiPB = txt_soDienThoaiPB.Text;
                PhongBan_BUS pb_bus = new PhongBan_BUS();
                try
                {
                    pb_bus.Them(pb_dto);
                    LoadListPhongBan();
                    LoadMaPB();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion

            #region btn_themL
            else if (button.Equals(btn_themL))
            {
                LoadMaL();
                Luong_DTO l_dto = new Luong_DTO();
                l_dto.MaL = txt_maL.Text;
                l_dto.LuongCoBan = txt_luongCoBan.Text;
                l_dto.HeSoLuong = txt_heSoLuong.Text;
                l_dto.HeSoPhuCap = txt_heSoPhuCap.Text;
                Luong_BUS l_bus = new Luong_BUS();
                try
                {
                    l_bus.Them(l_dto);
                    LoadListLuong();
                    LoadMaL();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion

            #region btn_themTK
            else if (button.Equals(btn_themTK))
            {
                string error = "Lỗi nhập dữ liệu!!!\n";
                bool hasError = false;
                if (txt_username.Text.Trim().Equals(""))
                {
                    hasError = true;
                    error += "- Lỗi chưa nhập username!\n";
                }
                TaiKhoan_DTO tk_dto = new TaiKhoan_DTO();
                try
                {
                    tk_dto.Role = cbb_role.SelectedItem.ToString();
                }
                catch (Exception ex)
                {
                    hasError = true;
                    error += "-Lỗi chưa chọn Role!";
                }
                if (hasError)
                {
                    MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
              
                tk_dto.Username = txt_username.Text;
                tk_dto.Password = txt_password.Text;
                TaiKhoan_BUS tk_bus = new TaiKhoan_BUS();
                try
                {
                    tk_bus.Them(tk_dto);
                    LoadListTaiKhoan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion

        }

        private void btn_suaClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            #region btn_suaNhanVien
            if (button.Equals(btn_suaNhanVien))
            {
                if (maNV != null)
                {
                    SuaNhanVien snv = new SuaNhanVien(this, maNV);
                    snv.Show();
                }
                else
                    MessageBox.Show("Hãy chọn một bản ghi!!!");
            }
            #endregion

            #region btn_suaHV
            else if (button.Equals(btn_suaHV))
            {
                if (maHV != null)
                {
                    string error = "Lỗi nhập dữ liệu!!!\n";
                    bool hasError = false;
                    HocVan_DTO hv_dto = new HocVan_DTO();
                    hv_dto.MaHV = txt_maHV.Text;
                    try
                    {
                        hv_dto.MaCN = GetMaCN(cbb_tenCN.SelectedItem.ToString());
                    }
                    catch (Exception ex)
                    {
                        hasError = true;
                        error += "- Lỗi chưa chọn chuyên ngành!\n";
                    }
                    try
                    {
                        hv_dto.MaTD = GetMaTD(cbb_tenTD.SelectedItem.ToString());
                    }
                    catch (Exception ex)
                    {
                        hasError = true;
                        error += "- Lỗi chưa chọn trình độ!\n";
                    }

                    if (hasError)
                    {
                        MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    DialogResult sua = MessageBox.Show("Bạn có chắc chắn?", "Sửa Học Vấn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (sua == DialogResult.No)
                        return;

                    HocVan_BUS hv_bus = new HocVan_BUS();
                    try
                    {
                        hv_bus.Sua(hv_dto);
                        LoadListHocVan();
                        maHV = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sửa học vấn không thành công!!!");
                    }
                }
                else
                    MessageBox.Show("Hãy chọn một bản ghi!!!");

            }
            #endregion

            #region btn_suaCV
            else if (button.Equals(btn_suaCV))
            {
                if (maCV != null)
                {
                    ChucVu_DTO cv_dto = new ChucVu_DTO();
                    cv_dto.MaCV = txt_maCV.Text;
                    cv_dto.TenCV = txt_tenCV.Text;
                    ChucVu_BUS cv_bus = new ChucVu_BUS();

                    DialogResult sua = MessageBox.Show("Bạn có chắc chắn?", "Sửa Chức Vụ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (sua == DialogResult.No)
                        return;

                    try
                    {
                        cv_bus.Sua(cv_dto);
                        LoadListChucVu();
                        maCV = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Hãy chọn một bản ghi!!!");
            }
            #endregion

            #region btn_suaPB
            else if (button.Equals(btn_suaPB))
            {
                if (maPB != null)
                {
                    PhongBan_DTO pb_dto = new PhongBan_DTO();
                    pb_dto.MaPB = txt_maPB.Text;
                    pb_dto.TenPB = txt_tenPB.Text;
                    pb_dto.DiaChiPB = txt_diaChiPB.Text;
                    pb_dto.SoDienThoaiPB = txt_soDienThoaiPB.Text;
                    DataTable dt = new KetNoi().GetTable("SELECT * FROM PhongBan WHERE maPB='"+maPB+"'");
                    pb_dto.TenTruongPhong = dt.Rows[0][2].ToString();
                    PhongBan_BUS pb_bus = new PhongBan_BUS();

                    DialogResult sua = MessageBox.Show("Bạn có chắc chắn?", "Sửa Phòng Ban", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (sua == DialogResult.No)
                        return;

                    try
                    {
                        pb_bus.Sua(pb_dto);
                        LoadListPhongBan();
                        maPB = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Hãy chọn một bản ghi!!!");
            }
            #endregion

            #region btn_suaL
            else if (button.Equals(btn_suaL))
            {
                if (maL != null)
                {
                    Luong_DTO l_dto = new Luong_DTO();
                    l_dto.MaL = txt_maL.Text;
                    l_dto.LuongCoBan = txt_luongCoBan.Text;
                    l_dto.HeSoLuong = txt_heSoLuong.Text;
                    l_dto.HeSoPhuCap = txt_heSoPhuCap.Text;
                    Luong_BUS l_bus = new Luong_BUS();

                    DialogResult sua = MessageBox.Show("Bạn có chắc chắn?", "Sửa Lương", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (sua == DialogResult.No)
                        return;

                    try
                    {
                        l_bus.Sua(l_dto);
                        LoadListLuong();
                        maL = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Hãy chọn một bản ghi!!!");
            }
            #endregion

            #region btn_suaTK
            else if (button.Equals(btn_suaTK))
            {
                if (maTK != null)
                {
                    TaiKhoan_DTO tk_dto = new TaiKhoan_DTO();
                    tk_dto.Username = txt_username.Text;
                    tk_dto.Password = txt_password.Text;
                    tk_dto.Role = cbb_role.SelectedItem.ToString();
                    TaiKhoan_BUS tk_bus = new TaiKhoan_BUS();

                    DialogResult sua = MessageBox.Show("Bạn có chắc chắn?", "Sửa Tài Khoản", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (sua == DialogResult.No)
                        return;

                    try
                    {
                        tk_bus.Sua(tk_dto);
                        LoadListTaiKhoan();
                        maTK = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Hãy chọn một bản ghi!!!");
            }
            #endregion

        }

        private void btn_xoaClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            #region btn_xoaNhanVien
            if (button.Equals(btn_xoaNhanVien))
            {
                if (maNV != null)
                {
                    NhanVien_DTO nv_dto = new NhanVien_DTO();
                    nv_dto.MaNV = maNV;
                    HoSoNhanVien_DTO hsnv_dto = new HoSoNhanVien_DTO();
                    hsnv_dto.MaNV = maNV;
                    NhanVien_ChucVu_DTO nv_cv_dto = new NhanVien_ChucVu_DTO();
                    nv_cv_dto.MaNV = maNV;
                    NhanVien_Luong_DTO nv_l_dto = new NhanVien_Luong_DTO();
                    nv_l_dto.MaNV = maNV;

                    NhanVien_BUS nv_bus = new NhanVien_BUS();
                    HoSoNhanVien_BUS hsnv_bus = new HoSoNhanVien_BUS();
                    NhanVien_ChucVu_BUS nv_cv_bus = new NhanVien_ChucVu_BUS();
                    NhanVien_Luong_BUS nv_l_bus = new NhanVien_Luong_BUS();

                    DialogResult xoa = MessageBox.Show("Bạn có chắc chắn?", "Xóa Nhân Viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (xoa == DialogResult.No)
                        return;
                    try
                    {
                        nv_l_bus.Xoa(nv_l_dto);
                        nv_cv_bus.Xoa(nv_cv_dto);
                        hsnv_bus.Xoa(hsnv_dto);
                        nv_bus.Xoa(nv_dto);
                        LoadListNhanVien();
                        maNV = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                    MessageBox.Show("Hãy chọn một bản ghi!!!");
            }
            #endregion

            #region btn_xoaHV
            else if (button.Equals(btn_xoaHV))
            {
                if (maHV != null)
                {
                    HocVan_DTO hv_dto = new HocVan_DTO();
                    hv_dto.MaHV = txt_maHV.Text;

                    HocVan_BUS hv_bus = new HocVan_BUS();

                    DialogResult xoa = MessageBox.Show("Bạn có chắc chắn?", "Xóa Học Vấn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (xoa == DialogResult.No)
                        return;

                    try
                    {
                        hv_bus.Xoa(hv_dto);
                        LoadListHocVan();
                        maHV = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa Học Vấn không thành công!!!\n -Nếu xóa thì phải xóa hết nhân viên có học vấn này");
                    }
                }
                else
                    MessageBox.Show("Hãy chọn một bản ghi!!!");
            }
            #endregion

            #region btn_xoaCV
            else if (button.Equals(btn_xoaCV))
            {
                if (maCV != null)
                {
                    ChucVu_DTO cv_dto = new ChucVu_DTO();
                    cv_dto.MaCV = maCV;

                    ChucVu_BUS cv_bus = new ChucVu_BUS();

                    DialogResult xoa = MessageBox.Show("Bạn có chắc chắn?", "Xóa Chức Vụ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (xoa == DialogResult.No)
                        return;

                    try
                    {
                        cv_bus.Xoa(cv_dto);
                        LoadListChucVu();
                        maCV = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa Chức Vụ không thành công.!!!\n -Nếu xóa thì phải xóa hết nhân viên có chức vụ này");
                    }
                }
                else
                    MessageBox.Show("Hãy chọn một bản ghi!!!");
            }
            #endregion

            #region btn_xoaPB
            else if (button.Equals(btn_xoaPB))
            {
                if (maPB != null)
                {
                    PhongBan_DTO pb_dto = new PhongBan_DTO();
                    pb_dto.MaPB = maPB;

                    PhongBan_BUS pb_bus = new PhongBan_BUS();

                    DialogResult xoa = MessageBox.Show("Bạn có chắc chắn?", "Xóa Phòng Ban", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (xoa == DialogResult.No)
                        return;

                    try
                    {
                        pb_bus.Xoa(pb_dto);
                        LoadListPhongBan();
                        maPB = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa Phòng Ban không thành công!!!\n -Nếu xóa thì phải xóa hết nhân viên ở phòng ban này");
                    }
                }
                else
                    MessageBox.Show("Hãy chọn một bản ghi!!!");
            }
            #endregion

            #region btn_xoaL
            else if (button.Equals(btn_xoaL))
            {
                if (maL != null)
                {
                    Luong_DTO l_dto = new Luong_DTO();
                    l_dto.MaL = maL;

                    Luong_BUS l_bus = new Luong_BUS();

                    DialogResult xoa = MessageBox.Show("Bạn có chắc chắn?", "Xóa Lương", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (xoa == DialogResult.No)
                        return;

                    try
                    {
                        l_bus.Xoa(l_dto);
                        LoadListLuong();
                        maL = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa Lương không thành công!!!\n -Nếu xóa thì phải xóa hết nhân viên có lương này");
                    }
                }
                else
                    MessageBox.Show("Hãy chọn một bản ghi!!!");
            }
            #endregion

            #region btn_xoaTK
            else if (button.Equals(btn_xoaTK))
            {
                if (maTK != null)
                {
                    TaiKhoan_DTO tk_dto = new TaiKhoan_DTO();
                    tk_dto.Username = txt_username.Text;

                    TaiKhoan_BUS tk_bus = new TaiKhoan_BUS();

                    DialogResult xoa = MessageBox.Show("Bạn có chắc chắn?", "Xóa Tài Khoản", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (xoa == DialogResult.No)
                        return;

                    try
                    {
                        tk_bus.Xoa(tk_dto);
                        LoadListTaiKhoan();
                        maTK = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Hãy chọn một bản ghi!!!");
            }
            #endregion

        }

        private void btn_xemClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            #region btn_xemNhanVien
            if (button.Equals(btn_xemNhanVien))
            {
                if (maNV != null)
                {
                    XemNhanVien xnv = new XemNhanVien(maNV);
                    xnv.Show();
                }
                else
                    MessageBox.Show("Hãy chọn một bản ghi!!!");
            }
            #endregion
        }

        private void btn_capNhatBangClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            #region btn_capNhatBangNhanVien
            if (button.Equals(btn_capNhatBangNhanVien))
            {
                maNV = null;
                LoadListNhanVien();
                //LoadHieuUng(1);
            }
            #endregion

            #region btn_capNhatBangHV
            else if (button.Equals(btn_capNhatBangHV))
            {
                maHV = null;
                LoadListHocVan();
                //LoadHieuUng(2);
                LoadComboBox(cbb_tenCN, "SELECT DISTINCT tenCN FROM ChuyenNganh");
                LoadComboBox(cbb_tenTD, "SELECT DISTINCT tenTD FROM TrinhDo");
            }
            #endregion

            #region btn_capNhatBangCV
            else if (button.Equals(btn_capNhatBangCV))
            {
                maCV = null;
                LoadListChucVu();
                //LoadHieuUng(3);
                LoadMaCV();
                txt_tenCV.Clear();
            }
            #endregion

            #region btn_capNhatBangPB
            else if (button.Equals(btn_capNhatBangPB))
            {
                maPB = null;
                LoadListPhongBan();
                //LoadHieuUng(4);
                LoadMaPB();
                txt_tenPB.Clear();
                txt_diaChiPB.Clear();
                txt_soDienThoaiPB.Clear();

            }
            #endregion

            #region btn_capNhatBangL
            else if (button.Equals(btn_capNhatBangL))
            {
                maL = null;
                LoadListLuong();
                //LoadHieuUng(5);
                LoadMaL();
                txt_luongCoBan.Clear();
                txt_heSoLuong.Clear();
                txt_heSoPhuCap.Clear();
            }
            #endregion

            #region btn_capNhatBangTK
            else if (button.Equals(btn_capNhatBangTK))
            {
                maTK = null;
                LoadListTaiKhoan();
                //LoadHieuUng(6);
                txt_username.Clear();
                txt_password.Clear();
            }
            #endregion
        }

        private void dgv_cellClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRow = e.RowIndex;
            DataGridView dgv = (DataGridView)sender;
            if (currentRow >= dgv.RowCount - 1)
            {
                maNV = maHV = maCV = maPB = maL = maTK = null;
                return;
            }

            #region dgv_nhanVien
            if (dgv.Equals(dgv_nhanVien))
            {
                try
                {
                    maNV = dgv.Rows[currentRow].Cells[0].Value.ToString();
                }
                catch (Exception ex)
                {
                    maNV = null;
                }
            }
            #endregion

            #region dgv_hocVan
            else if (dgv.Equals(dgv_hocVan))
            {
                try
                {
                    txt_maHV.Text = dgv.Rows[currentRow].Cells[0].Value.ToString();
                    cbb_tenCN.SelectedItem = dgv.Rows[currentRow].Cells[2].Value.ToString();
                    cbb_tenTD.SelectedItem = dgv.Rows[currentRow].Cells[4].Value.ToString();
                    maHV = txt_maHV.Text;
                }
                catch (Exception ex)
                {
                    maHV = null;
                }
            }
            #endregion

            #region dgv_chucVu
            else if (dgv.Equals(dgv_chucVu))
            {
                try
                {
                    txt_maCV.Text = dgv.Rows[currentRow].Cells[0].Value.ToString();
                    txt_tenCV.Text = dgv.Rows[currentRow].Cells[1].Value.ToString();
                    maCV = txt_maCV.Text;
                }
                catch (Exception ex)
                {
                    maCV = null;
                }
            }
            #endregion

            #region phongBan
            else if (dgv.Equals(dgv_phongBan))
            {
                try
                {
                    txt_maPB.Text = dgv.Rows[currentRow].Cells[0].Value.ToString();
                    txt_tenPB.Text = dgv.Rows[currentRow].Cells[1].Value.ToString();
                    txt_diaChiPB.Text = dgv.Rows[currentRow].Cells[3].Value.ToString();
                    txt_soDienThoaiPB.Text = dgv.Rows[currentRow].Cells[4].Value.ToString();
                    maPB = txt_maPB.Text;
                }
                catch (Exception ex)
                {
                    maPB = null;
                }
            }
            #endregion

            #region dgv_luong
            else if (dgv.Equals(dgv_luong))
            {
                try
                {
                    txt_maL.Text = dgv.Rows[currentRow].Cells[0].Value.ToString();
                    txt_luongCoBan.Text = dgv.Rows[currentRow].Cells[1].Value.ToString();
                    txt_heSoLuong.Text = dgv.Rows[currentRow].Cells[2].Value.ToString();
                    txt_heSoPhuCap.Text = dgv.Rows[currentRow].Cells[3].Value.ToString();
                    maL = txt_maL.Text;
                }
                catch (Exception ex)
                {
                    maL = null;
                }
            }
            #endregion

            #region dgv_taiKhoan
            else if (dgv.Equals(dgv_taiKhoan))
            {
                try
                {
                    txt_username.Text = dgv.Rows[currentRow].Cells[0].Value.ToString();
                    txt_password.Text = dgv.Rows[currentRow].Cells[1].Value.ToString();
                    cbb_role.SelectedItem = dgv.Rows[currentRow].Cells[2].Value.ToString();
                    maTK = txt_username.Text;
                }
                catch (Exception ex)
                {
                    maTK = null;
                }
            }
            #endregion
        }

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

        #region Get mã
        //Get mã chuyên ngành
        private string GetMaCN(string tenCN)
        {
            kn = new KetNoi();
            DataTable dt = kn.GetTable("SELECT DISTINCT * FROM ChuyenNganh WHERE tenCN=N'" + tenCN + "'");
            if (dt.Rows.Count >= 1)
                return dt.Rows[0][0].ToString();
            return null;
        }
        //Get mã trình độ
        private string GetMaTD(string tenTD)
        {
            kn = new KetNoi();
            DataTable dt = kn.GetTable("SELECT DISTINCT * FROM TrinhDo WHERE tenTD=N'" + tenTD + "'");
            if (dt.Rows.Count >= 1)
                return dt.Rows[0][0].ToString();
            return null;
        }
        #endregion

        #region Load mã
        // Load mã Học Vấn
        private void LoadMaHV()
        {
            string maHV = KiemTraMaDauTien("SELECT *From HocVan WHERE maHV='HV000'") ? MaTuDong("SELECT TOP 1 maHV FROM HocVan ORDER BY maHV DESC", "HV") : "HV000";
            txt_maHV.Text = maHV;
        }
        // Load mã Chức Vụ
        public void LoadMaCV()
        {
            string maCV = KiemTraMaDauTien("SELECT *From ChucVu WHERE maCV='CV000'") ? MaTuDong("SELECT TOP 1 maCV FROM ChucVu ORDER BY maCV DESC", "CV") : "CV000";
            txt_maCV.Text = maCV;
        }
        // Load mã Phòng Ban
        public void LoadMaPB()
        {
            string maPB = KiemTraMaDauTien("SELECT *From PhongBan WHERE maPB='PB000'") ? MaTuDong("SELECT TOP 1 maPB FROM PhongBan ORDER BY maPB DESC", "PB") : "PB000";
            txt_maPB.Text = maPB;
        }
        // Load mã Lương
        public void LoadMaL()
        {
            string maL = KiemTraMaDauTien("SELECT *From Luong WHERE maL='L000'") ? MaTuDong("SELECT TOP 1 maL FROM Luong ORDER BY maL DESC", "L") : "L000";
            txt_maL.Text = maL;
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

        #region Search
        private void btn_search_Click(object sender, EventArgs e)
        {
            NhanVien_BUS nvb = new NhanVien_BUS();
            HoSoNhanVien_DTO hsnv_dto = new HoSoNhanVien_DTO();
            try
            {
                if (txt_search.Text.Substring(0, 1).Equals("@"))
                    hsnv_dto.MaNV = txt_search.Text;
                else
                    hsnv_dto.HoTen = txt_search.Text;
            }
            catch (Exception ex)
            {
                hsnv_dto.HoTen = txt_search.Text;
            }
            dgv_nhanVien.DataSource = nvb.GetSearch(hsnv_dto);
        }
        #endregion

        #region Hiệu Ứng
        /*
        public void LoadHieuUng(int itemClick)
        {
            this.itemClick = itemClick;
            timerHieuUng.Enabled = true;
            pnl_home.Location = new Point(5, 672);
            pnl_hocVan.Location = new Point(1195, 220);
            pnl_chucVu.Location = new Point(1195, 220);
            pnl_phongBan.Location = new Point(1195, 220);
            pnl_luong.Location = new Point(1195, 220);
            pnl_taiKhoan.Location = new Point(1195, 220);
            pnl_baoCao.Location = new Point(1195, 220);
        }

        private void timerHieuUng_Tick(object sender, EventArgs e)
        {
            if (itemClick == 1)
            {
                if (pnl_home.Location.Y >= 220 + 30)
                {
                    pnl_home.Location = new Point(5, pnl_home.Location.Y - 30);
                }
                else
                {
                    pnl_home.Location = new Point(5, 220);
                    timerHieuUng.Enabled = false;
                }
            }
            else if (itemClick == 2)
            {
                if (pnl_hocVan.Location.X >= 80 + 5)
                {
                    pnl_hocVan.Location = new Point(pnl_hocVan.Location.X - 80, 220);
                }
                else
                {
                    pnl_hocVan.Location = new Point(5, 220);
                    timerHieuUng.Enabled = false;
                }
            }
            else if (itemClick == 3)
            {
                if (pnl_chucVu.Location.X >= 80 + 5)
                {
                    pnl_chucVu.Location = new Point(pnl_chucVu.Location.X - 80, 220);
                }
                else
                {
                    pnl_chucVu.Location = new Point(5, 220);
                    timerHieuUng.Enabled = false;
                }
            }
            else if (itemClick == 4)
            {
                if (pnl_phongBan.Location.X >= 80 + 5)
                {
                    pnl_phongBan.Location = new Point(pnl_phongBan.Location.X - 80, 220);
                }
                else
                {
                    pnl_phongBan.Location = new Point(5, 220);
                    timerHieuUng.Enabled = false;
                }
            }
            else if (itemClick == 5)
            {
                if (pnl_luong.Location.X >= 80 + 5)
                {
                    pnl_luong.Location = new Point(pnl_luong.Location.X - 80, 220);
                }
                else
                {
                    pnl_luong.Location = new Point(5, 220);
                    timerHieuUng.Enabled = false;
                }
            }
            else if (itemClick == 6)
            {
                if (pnl_taiKhoan.Location.X >= 80 + 5)
                {
                    pnl_taiKhoan.Location = new Point(pnl_taiKhoan.Location.X - 80, 220);
                }
                else
                {
                    pnl_taiKhoan.Location = new Point(5, 220);
                    timerHieuUng.Enabled = false;
                }
            }
            else if (itemClick == 7)
            {
                if (pnl_baoCao.Location.X >= 80 + 5)
                {
                    pnl_baoCao.Location = new Point(pnl_baoCao.Location.X - 80, 220);
                }
                else
                {
                    pnl_baoCao.Location = new Point(5, 220);
                    timerHieuUng.Enabled = false;
                }
            }
        }
        */
        #endregion

        #region Report
        private void LoadComboBoxReport(ComboBox comboBox, string sql)
        {
            comboBox.Items.Clear();
            comboBox.Text = "";
            comboBox.Items.Add(all);
            comboBox.SelectedItem = all;
            dr = new KetNoi().GetData(sql);
            while (dr.Read())
            {
                comboBox.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void SetParameter(string tenPB, string tenCV, string tenCN, string tenTD)
        {
            View_FilterTableAdapter.Fill(this.QLNSDataSet.View_Filter);
            ReportParameter[] rp = new ReportParameter[4];
            rp[0] = new ReportParameter("tenPB");
            rp[1] = new ReportParameter("tenCV");
            rp[2] = new ReportParameter("tenCN");
            rp[3] = new ReportParameter("tenTD");

            rp[0].Values.Add("*" + tenPB + "*");
            rp[1].Values.Add("*" + tenCV + "*");
            rp[2].Values.Add("*" + tenCN + "*");
            rp[3].Values.Add("*" + tenTD + "*");

            report_nhanVien.LocalReport.SetParameters(rp);
            report_nhanVien.RefreshReport();
        }

        private void btn_tatCa_Click(object sender, EventArgs e)
        {
            SetParameter("", "", "", "");
            LoadComboBoxReport(cbb_phongBan, "SELECT DISTINCT tenPB FROM phongBan");
            LoadComboBoxReport(cbb_chucVu, "SELECT DISTINCT tenCV FROM ChucVu");
            LoadComboBoxReport(cbb_chuyenNganh, "SELECT DISTINCT tenCN FROM ChuyenNganh,HocVan WHERE ChuyenNganh.maCN=HocVan.maCN");
            LoadComboBoxReport(cbb_trinhDo, "SELECT DISTINCT tenTD FROM HocVan,TrinhDo WHERE TrinhDo.maTD=HocVan.maTD");
        }

        private void btn_loc_Click(object sender, EventArgs e)
        {
            string tenPB, tenCV, tenCN, tenTD;
            try
            {
                tenPB = cbb_phongBan.SelectedItem.ToString().Equals(all) ? "" : cbb_phongBan.SelectedItem.ToString();
                tenCV = cbb_chucVu.SelectedItem.ToString().Equals(all) ? "" : cbb_chucVu.SelectedItem.ToString();
                tenCN = cbb_chuyenNganh.SelectedItem.ToString().Equals(all) ? "" : cbb_chuyenNganh.SelectedItem.ToString();
                tenTD = cbb_trinhDo.SelectedItem.ToString().Equals(all) ? "" : cbb_trinhDo.SelectedItem.ToString();
                SetParameter(tenPB, tenCV, tenCN, tenTD);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Không được nhập vào ComboBox!!!");
            }
        }

        private void btn_baoCaoHocVan_Click(object sender, EventArgs e)
        {
            ReportHocVan rpHocVan = new ReportHocVan();
            rpHocVan.Show();
        }

        private void btn_baoCaoChucVu_Click(object sender, EventArgs e)
        {
            ReportChucVu rpChucVu = new ReportChucVu();
            rpChucVu.Show();
        }

        private void btn_baoCaoPhongBan_Click(object sender, EventArgs e)
        {
            ReportPhongBan rpPhongBan = new ReportPhongBan();
            rpPhongBan.Show();
        }

        private void btn_baoCaoLuong_Click(object sender, EventArgs e)
        {
            ReportLuong rpLuong = new ReportLuong();
            rpLuong.Show();
        }
        #endregion

        private void btn_chuyenNganh_Click(object sender, EventArgs e)
        {
            new ChuyenNganh().Show();
        }

        private void btn_trinhDo_Click(object sender, EventArgs e)
        {
            new TrinhDo().Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}