using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class ChuyenNganh_DTO
    {
        private string maCN, tenCN;

        public string TenCN
        {
            get { return tenCN; }
            set { tenCN = value; }
        }

        public string MaCN
        {
            get { return maCN; }
            set { maCN = value; }
        }
    }
}
