using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data;
namespace BUS
{
    public class NhanVien_BUS
    {
        private KetNoi kn;
        public void Them(NhanVien_DTO dto)
        {
            kn = new KetNoi();
            string sql = "INSERT INTO NhanVien VALUES('"+dto.MaNV+"','"+dto.MaHV+"','"+dto.MaCV+"','"+dto.MaPB+"','"+dto.MaL+"')";
            kn.ExecuteQuery(sql);
        }
        public void Sua(NhanVien_DTO dto)
        {
            kn = new KetNoi();
            string sql = "UPDATE NhanVien SET maHV='" + dto.MaHV + "',maCV='" + dto.MaCV + "',maPB='" + dto.MaPB + "',maL='" + dto.MaL + "' WHERE maNV='"+dto.MaNV+"'";
            kn.ExecuteQuery(sql);
        }
        public void Xoa(NhanVien_DTO dto)
        {
            kn = new KetNoi();
            string sql = "DELETE NhanVien WHERE maNV='" + dto.MaNV + "'";
            kn.ExecuteQuery(sql);
        }
        public DataTable GetSearch(HoSoNhanVien_DTO dto)
        {
            kn = new KetNoi();
            string sql;
            if (dto.HoTen!=null)
            {
                sql = "SELECT NhanVien.maNV,hoTen,gioiTinh,ngaySinh,ngayVaoLam,queQuan,soDienThoai,tenCV,tenTD,tenCN,tenPB,luongCoBan FROM NhanVien,HoSoNhanVien,HocVan,TrinhDo,ChuyenNganh,ChucVu,PhongBan,Luong WHERE NhanVien.maNV=HoSoNhanVien.maNV AND TrinhDo.maTD=HocVan.maTD AND ChuyenNganh.maCN=HocVan.maCN AND HocVan.maHV=NhanVien.maHV AND ChucVu.maCV=NhanVien.maCV AND PhongBan.maPB=NhanVien.maPB AND Luong.maL=NhanVien.maL AND HoSoNhanVien.hoTen LIKE N'%" + dto.HoTen + "%'";
            }
            else
            {
                sql = "SELECT NhanVien.maNV,hoTen,gioiTinh,ngaySinh,ngayVaoLam,queQuan,soDienThoai,tenCV,tenTD,tenCN,tenPB,luongCoBan FROM NhanVien,HoSoNhanVien,HocVan,TrinhDo,ChuyenNganh,ChucVu,PhongBan,Luong WHERE NhanVien.maNV=HoSoNhanVien.maNV AND TrinhDo.maTD=HocVan.maTD AND ChuyenNganh.maCN=HocVan.maCN AND HocVan.maHV=NhanVien.maHV AND ChucVu.maCV=NhanVien.maCV AND PhongBan.maPB=NhanVien.maPB AND Luong.maL=NhanVien.maL AND HoSoNhanVien.maNV LIKE N'%" + dto.MaNV.Substring(1) + "%'";
            }
            return kn.GetTable(sql);
        }
    }
}
