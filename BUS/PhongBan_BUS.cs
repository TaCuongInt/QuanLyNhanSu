using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
namespace BUS
{
    public class PhongBan_BUS
    {
        private KetNoi kn;
        public void Them(PhongBan_DTO dto)
        {
            kn = new KetNoi();
            string sql = "INSERT INTO PhongBan VALUES('"+dto.MaPB+"',N'"+dto.TenPB+"',N'"+dto.TenTruongPhong+"',N'"+dto.DiaChiPB+"','"+dto.SoDienThoaiPB+"')";
            kn.ExecuteQuery(sql);
        }
        public void Sua(PhongBan_DTO dto)
        {
            kn = new KetNoi();
            string sql = "UPDATE PhongBan SET tenPB=N'"+dto.TenPB+"', tenTruongPhong=N'"+dto.TenTruongPhong+"', diaChiPB=N'"+dto.DiaChiPB+"', soDienThoaiPB='"+dto.SoDienThoaiPB+"' WHERE maPB='"+dto.MaPB+"'";
            kn.ExecuteQuery(sql);
        }
        public void Xoa(PhongBan_DTO dto)
        {
            kn = new KetNoi();
            string sql = "DELETE PhongBan WHERE maPB='" + dto.MaPB + "'";
            kn.ExecuteQuery(sql);
        }
    }
}
