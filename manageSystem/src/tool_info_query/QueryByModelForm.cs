using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace manageSystem
{
    public partial class QueryByModelForm : Form
    {
        public QueryByModelForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.desouttertools.com.cn/fu-wu/service-link");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QueryToolBySpareForm qtbsf = new QueryToolBySpareForm();
            qtbsf.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QuerySpareByToolForm qsbtf = new QuerySpareByToolForm();
            qsbtf.Show();
        }
    }
}
