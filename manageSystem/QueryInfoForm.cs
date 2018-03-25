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
            this.tabControl1.ItemSize = new Size(this.tabControl1.Size.Width / 2-2,30);
           // this.tabPage2.Width = this.tabControl1.Size.Width / 2;
        }
    }
}
