﻿using System;
using System.Configuration;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace manageSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPasswd.Text == "")
            {
                lblLoginHint.ForeColor = Color.Red;
                lblLoginHint.Text = "登录失败，密码不能为空";
                return;
            }
            if(txtPasswd.Text.Trim() != "Aa888888")
            {
                lblLoginHint.ForeColor = Color.Red;
                lblLoginHint.Text = "登录失败，密码错误";
                return;
            }
            if(chkIsRemeberPasswd.Checked == true)
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["LoginPasswd"].Value = txtPasswd.Text.Trim();
                config.AppSettings.Settings["LoginIsRemeberPasswd"].Value = "yes";
                config.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
            else
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["LoginPasswd"].Value = "";
                config.AppSettings.Settings["LoginIsRemeberPasswd"].Value = "no";
                config.Save();
                ConfigurationManager.RefreshSection("appSettings");
            }
            MainForm mainForm = new MainForm();
            Hide();
            if (mainForm.ShowDialog() == DialogResult.OK)
            {
                Show();
            }
        }

        private string isPasswdCurrect(string s)
        {
            return SHA1(s, Encoding.UTF8);
        }

        public string SHA1(string content, Encoding encode)
        {
            try
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] bytes_in = encode.GetBytes(content);
                byte[] bytes_out = sha1.ComputeHash(bytes_in);
                sha1.Dispose();
                string result = BitConverter.ToString(bytes_out);
                result = result.Replace("-", "");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("SHA1加密出错：" + ex.Message);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtPasswd.Text = ConfigurationManager.AppSettings["LoginPasswd"];
            if(ConfigurationManager.AppSettings["LoginIsRemeberPasswd"] == "yes")
            {
                chkIsRemeberPasswd.Checked = true;
            }
        }
    }
}
