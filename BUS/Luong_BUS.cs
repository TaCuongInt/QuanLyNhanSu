using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
namespace BUS
{
    public class Luong_BUS
    {
        private KetNoi kn;
        public void Them(Luong_DTO dto)
        {
            kn = new KetNoi();
            string sql = "INSERT INTO Luong VALUES('"+dto.MaL+"','"+dto.LuongCoBan+"','"+dto.HeSoLuong+"','"+dto.HeSoPhuCap+"')";
            kn.ExecuteQuery(sql);
        }
        public void Sua(Luong_DTO dto)
        {
            kn = new KetNoi();
            string sql = "UPDATE Luong SET luongCoBan='"+dto.LuongCoBan+"', heSoLuong='"+dto.HeSoLuong+"',heSoPhuCap='"+dto.HeSoPhuCap+"' WHERE maL='"+dto.MaL+"'";
            kn.ExecuteQuery(sql);
        }
        public void Xoa(Luong_DTO dto)
        {
            kn = new KetNoi();
            string sql = "DELETE Luong WHERE maL='" + dto.MaL + "'";
            kn.ExecuteQuery(sql);
        }
    }
}
