using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;

namespace BUS
{
    public class HoSoNhanVien_BUS
    {
        private KetNoi kn;
        public void Them(HoSoNhanVien_DTO dto)
        {
            kn = new KetNoi();
            string sql = "INSERT INTO HoSoNhanVien VALUES(N'" + dto.MaNV + "',N'" + dto.HoTen + "',N'" + dto.GioiTinh + "','" + dto.NgaySinh.ToString("MM/dd/yyyy") + "','" + dto.NgayVaoLam.ToString("MM/dd/yyyy") + "',N'" + dto.QueQuan + "',N'" + dto.DanToc + "',N'" + dto.SoDienThoai + "',N'" + dto.SoCMTND + "',N'" + dto.Email + "')";
            kn.ExecuteQuery(sql);
        }
        public void Sua(HoSoNhanVien_DTO dto)
        {
            kn = new KetNoi();
            string sql = "UPDATE HoSoNhanVien SET hoTen=N'"+dto.HoTen+"',gioiTinh=N'"+dto.GioiTinh+"',ngaySinh='"+dto.NgaySinh.ToString("MM/dd/yyyy")+"',ngayVaoLam='"+dto.NgayVaoLam.ToString("MM/dd/yyy")+"',queQuan=N'"+dto.QueQuan+"',danToc=N'"+dto.DanToc+"',soDienThoai='"+dto.SoDienThoai+"',soCMTND='"+dto.SoCMTND+"',email='"+dto.Email+"' WHERE maNV='"+dto.MaNV+"'";
            kn.ExecuteQuery(sql);
        }
        public void Xoa(HoSoNhanVien_DTO dto)
        {
            kn = new KetNoi();
            string sql = "DELETE HoSoNhanVien WHERE maNV='" + dto.MaNV + "'";
            kn.ExecuteQuery(sql);
        }
    }
}
