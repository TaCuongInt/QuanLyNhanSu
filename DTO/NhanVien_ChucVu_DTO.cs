using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class NhanVien_ChucVu_DTO
    {
        private string maNV, maCV;

        public string MaCV
        {
            get { return maCV; }
            set { maCV = value; }
        }

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }
        private DateTime ngayNhanChuc;

        public DateTime NgayNhanChuc
        {
            get { return ngayNhanChuc; }
            set { ngayNhanChuc = value; }
        }
    }
}
