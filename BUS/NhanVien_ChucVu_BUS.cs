using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;

namespace BUS
{
    public class NhanVien_ChucVu_BUS
    {
        private KetNoi kn;
        public void Them(NhanVien_ChucVu_DTO dto)
        {
            kn = new KetNoi();
            string sql = "INSERT INTO NhanVien_ChucVu VALUES('"+dto.MaNV+"','"+dto.MaCV+"','"+dto.NgayNhanChuc.ToString("MM/dd/yyyy")+"')";
            kn.ExecuteQuery(sql);
        }
        public void Xoa(NhanVien_ChucVu_DTO dto)
        {
            kn = new KetNoi();
            string sql = "DELETE NhanVien_ChucVu WHERE maNV='"+dto.MaNV+"'";
            kn.ExecuteQuery(sql);
        }
    }
}
