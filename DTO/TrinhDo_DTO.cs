using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class TrinhDo_DTO
    {
        private string maTD, tenTD;

        public string TenTD
        {
            get { return tenTD; }
            set { tenTD = value; }
        }

        public string MaTD
        {
            get { return maTD; }
            set { maTD = value; }
        }
    }
}
