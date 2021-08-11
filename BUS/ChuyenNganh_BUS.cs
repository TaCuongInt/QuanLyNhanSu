using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;

namespace BUS
{
    public class ChuyenNganh_BUS
    {
        private KetNoi kn;
        public void Them(ChuyenNganh_DTO dto)
        {
            kn = new KetNoi();
            string sql = "INSERT INTO ChuyenNganh VALUES('"+dto.MaCN+"',N'"+dto.TenCN+"')";
            kn.ExecuteQuery(sql);
        }
        public void Sua(ChuyenNganh_DTO dto)
        {
            kn = new KetNoi();
            string sql = "UPDATE ChuyenNganh SET tenCN=N'"+dto.TenCN+"' WHERE maCN='"+dto.MaCN+"'";
            kn.ExecuteQuery(sql);
        }
        public void Xoa(ChuyenNganh_DTO dto)
        {
            kn = new KetNoi();
            string sql = "DELETE ChuyenNganh WHERE maCN='"+dto.MaCN+"'";
            kn.ExecuteQuery(sql);
        }
    }
}
