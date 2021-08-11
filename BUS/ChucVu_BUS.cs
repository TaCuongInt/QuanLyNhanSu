using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
namespace BUS
{
    public class ChucVu_BUS
    {
        private KetNoi kn;
        public void Them(ChucVu_DTO dto)
        {
            kn = new KetNoi();
            string sql = "INSERT INTO ChucVu VALUES('" + dto.MaCV + "',N'" + dto.TenCV + "')";
            kn.ExecuteQuery(sql);
        }
        public void Sua(ChucVu_DTO dto)
        {
            kn = new KetNoi();
            string sql = "UPDATE ChucVu SET tenCV=N'" + dto.TenCV + "' WHERE maCV='" + dto.MaCV + "'";
            kn.ExecuteQuery(sql);
        }
        public void Xoa(ChucVu_DTO dto)
        {
            kn = new KetNoi();
            string sql = "DELETE ChucVu WHERE maCV='"+dto.MaCV+"'";
            kn.ExecuteQuery(sql);
        }
    }
}
