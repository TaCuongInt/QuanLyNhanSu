using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;

namespace BUS
{
    public class NhanVien_Luong_BUS
    {
        private KetNoi kn;
        public void Them(NhanVien_Luong_DTO dto)
        {
            kn = new KetNoi();
            string sql = "INSERT INTO NhanVien_Luong VALUES('" + dto.MaNV + "','" + dto.MaL + "','" + dto.NgayCapNhat.ToString("MM/dd/yyyy") + "')";
            kn.ExecuteQuery(sql);
        }
        public void Xoa(NhanVien_Luong_DTO dto)
        {
            kn = new KetNoi();
            string sql = "DELETE NhanVien_Luong WHERE maNV='"+dto.MaNV+"'";
            kn.ExecuteQuery(sql);
        }
    }
}
