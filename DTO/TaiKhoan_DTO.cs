using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class TaiKhoan_DTO
    {
        private string username, password, role;

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
    }
}
