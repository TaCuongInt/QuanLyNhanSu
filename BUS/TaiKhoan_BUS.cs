using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
namespace BUS
{
    public class TaiKhoan_BUS
    {
        private KetNoi kn;
        public void Them(TaiKhoan_DTO dto)
        {
            kn = new KetNoi();
            string sql = "INSERT INTO Account VALUES('"+dto.Username+"','"+dto.Password+"','"+dto.Role+"')";
            kn.ExecuteQuery(sql);
        }
        public void Sua(TaiKhoan_DTO dto)
        {
            kn = new KetNoi();
            string sql = "UPDATE Account SET username='" + dto.Username + "', password='" + dto.Password + "', role='" + dto.Role + "' WHERE username='" + dto.Username + "'";
            kn.ExecuteQuery(sql);
        }
        public void Xoa(TaiKhoan_DTO dto)
        {
            kn = new KetNoi();
            string sql = "DELETE Account WHERE username='" + dto.Username + "'";
            kn.ExecuteQuery(sql);
        }
    }
}
