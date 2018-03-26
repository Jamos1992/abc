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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Database db = new Database();
            db.QueryBySql("select * from table1");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.DialogResult = DialogResult.OK;
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InfoInputForm iif = new InfoInputForm();
            //this.Hide();
            if (iif.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QueryInfoForm qif = new QueryInfoForm();
            if (qif.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }
    }
}
