namespace GUI
{
    partial class ThayDoiMatKhau
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_newPassword1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_newPassword2 = new System.Windows.Forms.TextBox();
            this.btn_thayDoiMatKhau = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkGreen;
            this.label1.Location = new System.Drawing.Point(49, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(49, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // txt_username
            // 
            this.txt_username.Enabled = false;
            this.txt_username.Location = new System.Drawing.Point(135, 28);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(100, 20);
            this.txt_username.TabIndex = 1;
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(135, 57);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(100, 20);
            this.txt_password.TabIndex = 2;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(49, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "NewPassword";
            // 
            // txt_newPassword1
            // 
            this.txt_newPassword1.Location = new System.Drawing.Point(135, 86);
            this.txt_newPassword1.Name = "txt_newPassword1";
            this.txt_newPassword1.Size = new System.Drawing.Size(100, 20);
            this.txt_newPassword1.TabIndex = 3;
            this.txt_newPassword1.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkGreen;
            this.label4.Location = new System.Drawing.Point(49, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "NewPassword";
            // 
            // txt_newPassword2
            // 
            this.txt_newPassword2.Location = new System.Drawing.Point(135, 115);
            this.txt_newPassword2.Name = "txt_newPassword2";
            this.txt_newPassword2.Size = new System.Drawing.Size(100, 20);
            this.txt_newPassword2.TabIndex = 4;
            this.txt_newPassword2.UseSystemPasswordChar = true;
            // 
            // btn_thayDoiMatKhau
            // 
            this.btn_thayDoiMatKhau.ForeColor = System.Drawing.Color.Crimson;
            this.btn_thayDoiMatKhau.Image = global::GUI.Properties.Resources.Edit;
            this.btn_thayDoiMatKhau.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_thayDoiMatKhau.Location = new System.Drawing.Point(89, 151);
            this.btn_thayDoiMatKhau.Name = "btn_thayDoiMatKhau";
            this.btn_thayDoiMatKhau.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btn_thayDoiMatKhau.Size = new System.Drawing.Size(106, 42);
            this.btn_thayDoiMatKhau.TabIndex = 5;
            this.btn_thayDoiMatKhau.Text = "Thay Đổi";
            this.btn_thayDoiMatKhau.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_thayDoiMatKhau.UseVisualStyleBackColor = true;
            this.btn_thayDoiMatKhau.Click += new System.EventHandler(this.btn_thayDoiMatKhau_Click);
            // 
            // ThayDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(284, 221);
            this.Controls.Add(this.btn_thayDoiMatKhau);
            this.Controls.Add(this.txt_newPassword2);
            this.Controls.Add(this.txt_newPassword1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ThayDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thay Đổi Mật Khẩu";
            this.Load += new System.EventHandler(this.ThayDoiMatKhau_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_newPassword1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_newPassword2;
        private System.Windows.Forms.Button btn_thayDoiMatKhau;
    }
}