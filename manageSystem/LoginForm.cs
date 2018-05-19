using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace manageSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox2.Text == "")
            {
                label4.ForeColor = Color.Red;
                label4.Text = "登录失败，密码不能为空";
                return;
            }

            MainForm mainForm = new MainForm();
            Hide();
            if (mainForm.ShowDialog() == DialogResult.OK)
            {
                Show();
            }
        }
    }
}
