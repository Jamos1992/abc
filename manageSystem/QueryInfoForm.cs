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
    public partial class QueryInfoForm : Form
    {
        public QueryInfoForm()
        {
            InitializeComponent();
        }

        private void QueryInfoForm_Load(object sender, EventArgs e)
        {
        
           // this.tabPage2.Width = this.tabControl1.Size.Width / 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QueryInfoBySNForm qibsf = new QueryInfoBySNForm();
            qibsf.TopLevel = false;
            this.splitContainer1.Panel2.Controls.Add(qibsf);
            qibsf.Show();
        }
    }
}
