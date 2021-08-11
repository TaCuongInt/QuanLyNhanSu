using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO;
using BUS;
using System.Text.RegularExpressions;

namespace GUI
{
    public partial class ThayDoiMatKhau : Form
    {
        private string username;
        public ThayDoiMatKhau()
        {
            InitializeComponent();
        }

        public ThayDoiMatKhau(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void ThayDoiMatKhau_Load(object sender, EventArgs e)
        {
            txt_username.Text = username;
        }

        private void btn_thayDoiMatKhau_Click(object sender, EventArgs e)
        {
            bool hasError = false;
            string error = "Lỗi Nhập dữ liệu!!!\n";
            DataTable dt = new KetNoi().GetTable("SELECT * FROM Account WHERE username='" + txt_username.Text + "'");

            if (!dt.Rows[0][1].Equals(txt_password.Text))
            {
                hasError = true;
                error += "-Không nhập đúng mật khẩu cũ!\n";
            }

            if (!txt_newPassword1.Text.Equals(txt_newPassword2.Text))
            {
                hasError = true;
                error += "-Mật khẩu mới nhập không trùng nhau!\n";
            }
            else if (!Regex.IsMatch(txt_newPassword1.Text, @"^\w+$"))
            {
                hasError = true;
                error += "-Mật khẩu không được phép có kí tự đặc biệt!\n";
            }

            if (txt_newPassword1.Text.Length < 6)
            {
                hasError = true;
                error += "-Mật khẩu mới nên đặt phức tạp hơn!\n";
            }

            if (hasError)
            {
                MessageBox.Show(error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TaiKhoan_DTO tk_dto = new TaiKhoan_DTO();
            tk_dto.Username = username;
            tk_dto.Password = txt_newPassword1.Text;
            tk_dto.Role = dt.Rows[0][2].ToString();
            TaiKhoan_BUS tk_bus = new TaiKhoan_BUS();
            try
            {
                tk_bus.Sua(tk_dto);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
