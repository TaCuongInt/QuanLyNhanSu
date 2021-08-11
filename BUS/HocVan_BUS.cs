using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
namespace BUS
{
    public class HocVan_BUS
    {
        private KetNoi kn;
        public void Them(HocVan_DTO dto)
        {
            kn = new KetNoi();
            string sql = "INSERT INTO HocVan VALUES('"+dto.MaHV+"','"+dto.MaCN+"','"+dto.MaTD+"')";
            kn.ExecuteQuery(sql);
        }
        public void Sua(HocVan_DTO dto)
        {
            kn = new KetNoi();
            string sql = "UPDATE HocVan SET maCN='"+dto.MaCN+"', maTD='"+dto.MaTD+"' WHERE maHV='"+dto.MaHV+"'";
            kn.ExecuteQuery(sql);
        }
        public void Xoa(HocVan_DTO dto)
        {
            kn = new KetNoi();
            string sql = "DELETE HocVan WHERE maHV='"+dto.MaHV+"'";
            kn.ExecuteQuery(sql);
        }
    }
}
