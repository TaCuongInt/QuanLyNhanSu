using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class Luong_DTO
    {
        private string maL, luongCoBan, heSoLuong, heSoPhuCap;

        public string HeSoPhuCap
        {
            get { return heSoPhuCap; }
            set { heSoPhuCap = value; }
        }

        public string HeSoLuong
        {
            get { return heSoLuong; }
            set { heSoLuong = value; }
        }

        public string LuongCoBan
        {
            get { return luongCoBan; }
            set { luongCoBan = value; }
        }

        public string MaL
        {
            get { return maL; }
            set { maL = value; }
        }

    }
}
