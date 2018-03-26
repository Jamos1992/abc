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

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox2.Text == "")
            {
                label4.ForeColor = Color.Red;
                label4.Text = "登录失败，密码不能为空";
                return;
            }

            MainForm mf = new MainForm();
            this.Hide();
            //mf.Show();
            if (mf.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }
    }
}
