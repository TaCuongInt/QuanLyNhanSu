namespace GUI
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_username = new System.Windows.Forms.Label();
            this.lb_password = new System.Windows.Forms.Label();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.cb_showPassword = new System.Windows.Forms.CheckBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_login = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_username
            // 
            this.lb_username.AutoSize = true;
            this.lb_username.BackColor = System.Drawing.Color.Transparent;
            this.lb_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_username.ForeColor = System.Drawing.Color.Black;
            this.lb_username.Location = new System.Drawing.Point(40, 40);
            this.lb_username.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(124, 29);
            this.lb_username.TabIndex = 0;
            this.lb_username.Text = "Username";
            // 
            // lb_password
            // 
            this.lb_password.AutoSize = true;
            this.lb_password.BackColor = System.Drawing.Color.Transparent;
            this.lb_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_password.ForeColor = System.Drawing.Color.Black;
            this.lb_password.Location = new System.Drawing.Point(40, 115);
            this.lb_password.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_password.Name = "lb_password";
            this.lb_password.Size = new System.Drawing.Size(120, 29);
            this.lb_password.TabIndex = 1;
            this.lb_password.Text = "Password";
            // 
            // txt_username
            // 
            this.txt_username.BackColor = System.Drawing.Color.White;
            this.txt_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_username.ForeColor = System.Drawing.Color.DarkGreen;
            this.txt_username.Location = new System.Drawing.Point(200, 37);
            this.txt_username.Margin = new System.Windows.Forms.Padding(4);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(200, 34);
            this.txt_username.TabIndex = 1;
            // 
            // txt_password
            // 
            this.txt_password.BackColor = System.Drawing.Color.White;
            this.txt_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txt_password.ForeColor = System.Drawing.Color.DarkGreen;
            this.txt_password.Location = new System.Drawing.Point(200, 112);
            this.txt_password.Margin = new System.Windows.Forms.Padding(4);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(200, 34);
            this.txt_password.TabIndex = 2;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // cb_showPassword
            // 
            this.cb_showPassword.BackColor = System.Drawing.Color.Transparent;
            this.cb_showPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_showPassword.ForeColor = System.Drawing.Color.Black;
            this.cb_showPassword.Location = new System.Drawing.Point(200, 154);
            this.cb_showPassword.Margin = new System.Windows.Forms.Padding(4);
            this.cb_showPassword.Name = "cb_showPassword";
            this.cb_showPassword.Size = new System.Drawing.Size(200, 30);
            this.cb_showPassword.TabIndex = 3;
            this.cb_showPassword.Text = "Show password";
            this.cb_showPassword.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cb_showPassword.UseVisualStyleBackColor = false;
            this.cb_showPassword.CheckedChanged += new System.EventHandler(this.cb_showPassword_CheckedChanged);
            // 
            // btn_clear
            // 
            this.btn_clear.BackColor = System.Drawing.Color.White;
            this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_clear.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_clear.Image = global::GUI.Properties.Resources.Clear;
            this.btn_clear.Location = new System.Drawing.Point(166, 245);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(4);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(132, 43);
            this.btn_clear.TabIndex = 5;
            this.btn_clear.Text = "Clear";
            this.btn_clear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_clear.UseVisualStyleBackColor = false;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            this.btn_clear.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Mouse_Down);
            this.btn_clear.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Mouse_Up);
            // 
            // btn_exit
            // 
            this.btn_exit.AutoSize = true;
            this.btn_exit.BackColor = System.Drawing.Color.White;
            this.btn_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_exit.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_exit.Image = global::GUI.Properties.Resources.Exit;
            this.btn_exit.Location = new System.Drawing.Point(306, 245);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(4);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(132, 43);
            this.btn_exit.TabIndex = 6;
            this.btn_exit.Text = "Exit";
            this.btn_exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            this.btn_exit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Mouse_Down);
            this.btn_exit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Mouse_Up);
            // 
            // btn_login
            // 
            this.btn_login.AutoSize = true;
            this.btn_login.BackColor = System.Drawing.Color.White;
            this.btn_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btn_login.ForeColor = System.Drawing.Color.ForestGreen;
            this.btn_login.Image = global::GUI.Properties.Resources.Login;
            this.btn_login.Location = new System.Drawing.Point(26, 244);
            this.btn_login.Margin = new System.Windows.Forms.Padding(4);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(132, 43);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "Login";
            this.btn_login.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_login.UseVisualStyleBackColor = false;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            this.btn_login.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Mouse_Down);
            this.btn_login.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Mouse_Up);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Cornsilk;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(458, 100);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txt_username);
            this.panel1.Controls.Add(this.lb_username);
            this.panel1.Controls.Add(this.cb_showPassword);
            this.panel1.Controls.Add(this.lb_password);
            this.panel1.Controls.Add(this.btn_clear);
            this.panel1.Controls.Add(this.txt_password);
            this.panel1.Controls.Add(this.btn_exit);
            this.panel1.Controls.Add(this.btn_login);
            this.panel1.Location = new System.Drawing.Point(12, 112);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 329);
            this.panel1.TabIndex = 7;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lb_username;
        private System.Windows.Forms.Label lb_password;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.CheckBox cb_showPassword;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}