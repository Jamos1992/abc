using System;
using System.Windows.Forms;
using BLL;
using Model;

namespace manageSystem
{
    public partial class QueryRepoSpareForm : Form
    {
        private RepoSpareToolManage repoSpareToolManage = new RepoSpareToolManage();
        public QueryRepoSpareForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            queryOneRecord(textBox1, textBox7, textBox13);
            queryOneRecord(textBox2, textBox8, textBox14);
            queryOneRecord(textBox3, textBox9, textBox15);
            queryOneRecord(textBox4, textBox10, textBox16);
            queryOneRecord(textBox5, textBox11, textBox17);
            queryOneRecord(textBox6, textBox12, textBox18);
        }

        private void queryOneRecord(TextBox txtBox1, TextBox txtBox2, TextBox txtBox3)
        {
            if (txtBox1.Text == "")
            {
                txtBox2.Text = "";
                txtBox3.Text = "";
                return;
            }
            RepoSpareTool repoSpareTool = repoSpareToolManage.QueryOneRepoSpare(textBox1.Text.Trim());
            if (repoSpareTool == null)
            {
                txtBox2.Text = "0";
                txtBox3.Text = "null";
                return;
            }
            txtBox2.Text = repoSpareTool.Num.ToString();
            txtBox3.Text = repoSpareTool.Time;
        }
    }
}
