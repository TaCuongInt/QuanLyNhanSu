using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class NhanVien_DTO
    {
        private string maNV, maHV, maCV, maPB, maL;

        public string MaL
        {
            get { return maL; }
            set { maL = value; }
        }

        public string MaPB
        {
            get { return maPB; }
            set { maPB = value; }
        }

        public string MaCV
        {
            get { return maCV; }
            set { maCV = value; }
        }

        public string MaHV
        {
            get { return maHV; }
            set { maHV = value; }
        }

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }
    }
}
