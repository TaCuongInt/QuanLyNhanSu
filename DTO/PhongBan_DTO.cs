using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class PhongBan_DTO
    {
        private string maPB, tenPB, tenTruongPhong, diaChiPB, soDienThoaiPB;

        public string SoDienThoaiPB
        {
            get { return soDienThoaiPB; }
            set { soDienThoaiPB = value; }
        }

        public string DiaChiPB
        {
            get { return diaChiPB; }
            set { diaChiPB = value; }
        }

        public string TenTruongPhong
        {
            get { return tenTruongPhong; }
            set { tenTruongPhong = value; }
        }

        public string TenPB
        {
            get { return tenPB; }
            set { tenPB = value; }
        }

        public string MaPB
        {
            get { return maPB; }
            set { maPB = value; }
        }
    }
}
