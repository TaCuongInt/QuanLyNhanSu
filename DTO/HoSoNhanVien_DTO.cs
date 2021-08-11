using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class HoSoNhanVien_DTO
    {
        private string maNV, hoTen, gioiTinh, queQuan, danToc, soDienThoai, soCMTND, email;
        private DateTime ngaySinh, ngayVaoLam;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string SoCMTND
        {
            get { return soCMTND; }
            set { soCMTND = value; }
        }

        public string SoDienThoai
        {
            get { return soDienThoai; }
            set { soDienThoai = value; }
        }

        public string DanToc
        {
            get { return danToc; }
            set { danToc = value; }
        }

        public string QueQuan
        {
            get { return queQuan; }
            set { queQuan = value; }
        }

        public string GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public DateTime NgayVaoLam
        {
            get { return ngayVaoLam; }
            set { ngayVaoLam = value; }
        }

        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }
    }
}
