using BUS;
using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class Login : Form
    {
        int count = 0;
        private KetNoi kn;

        public Login()
        {
            InitializeComponent();
        }

        //Show password
        private void cb_showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_showPassword.Checked)
                txt_password.UseSystemPasswordChar = false;
            else
                txt_password.UseSystemPasswordChar = true;
        }

        //Clear click
        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();
        }

        //Exit click
        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
                this.Close();
        }

        //Khi click button
        private void btn_Mouse_Down(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.DarkTurquoise;
            btn.ForeColor = Color.White;
        }

        //Khi thả click
        private void btn_Mouse_Up(object sender, MouseEventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.ForestGreen;
        }

        //Login click
        private void btn_login_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string username = txt_username.Text;
            string password = txt_password.Text;

            try
            {
                if (count > 2)
                {
                    MessageBox.Show("Nhập sai tối đa 3 lần", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (username.Equals(""))
                    {
                        sb.Append("\nTên tài khoản không hợp lệ\n");
                    }

                    if (password.Equals(""))
                    {
                        sb.Append("\nMật khẩu không hợp lệ\n");
                    }

                    if (sb.Length > 0)
                    {
                        MessageBox.Show(sb.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        kn = new KetNoi();
                        DataTable dt = new DataTable();
                        dt = kn.GetTable("SELECT *FROM Account WHERE username='" + txt_username.Text + "' AND password='" + txt_password.Text + "'");
                        if (dt.Rows.Count == 1)
                        {
                            Main main = new Main(dt.Rows[0][0].ToString(), dt.Rows[0][2].ToString());
                            main.Show();
                            this.Hide();
                        }
                        else
                        {
                            count++;
                            MessageBox.Show("Sai username hoặc password", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
