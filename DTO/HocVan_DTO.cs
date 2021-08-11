using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class HocVan_DTO
    {
        private string maHV, maCN, maTD;

        public string MaTD
        {
            get { return maTD; }
            set { maTD = value; }
        }

        public string MaCN
        {
            get { return maCN; }
            set { maCN = value; }
        }

        public string MaHV
        {
            get { return maHV; }
            set { maHV = value; }
        }
    }
}
