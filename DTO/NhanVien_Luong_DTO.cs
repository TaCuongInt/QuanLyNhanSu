using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class NhanVien_Luong_DTO
    {
        private string maNV, maL;

        public string MaL
        {
            get { return maL; }
            set { maL = value; }
        }

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }
        private DateTime ngayCapNhat;

        public DateTime NgayCapNhat
        {
            get { return ngayCapNhat; }
            set { ngayCapNhat = value; }
        }

    }
}
