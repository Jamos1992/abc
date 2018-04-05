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
    public partial class QueryToolSpareForm : Form
    {
        public QueryToolSpareForm()
        {
            InitializeComponent();
        }

        private void QueryToolSpareForm_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.desouttertools.com.cn/fu-wu/service-link");
        }
    }
}
