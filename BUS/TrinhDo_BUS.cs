using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;

namespace BUS
{
    public class TrinhDo_BUS
    {
        private KetNoi kn;
        public void Them(TrinhDo_DTO dto)
        {
            kn = new KetNoi();
            string sql = "INSERT INTO TrinhDo VALUES('"+dto.MaTD+"',N'"+dto.TenTD+"')";
            kn.ExecuteQuery(sql);
        }
        public void Sua(TrinhDo_DTO dto)
        {
            kn = new KetNoi();
            string sql = "UPDATE TrinhDo SET tenTD=N'"+dto.TenTD+"' WHERE maTD='"+dto.MaTD+"'";
            kn.ExecuteQuery(sql);
        }
        public void Xoa(TrinhDo_DTO dto)
        {
            kn = new KetNoi();
            string sql = "DELETE TrinhDo WHERE maTD='"+dto.MaTD+"'";
            kn.ExecuteQuery(sql);
        }
    }
}
