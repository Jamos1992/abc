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

            this.treeViewQuery.ExpandAll();
            // this.tabPage2.Width = this.tabControl1.Size.Width / 2;
        }

        private void treeViewQuery_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            switch (e.Node.Text)
            {
                case "单个序列号查询":
                    QueryInfoBySNForm qibsnf = new QueryInfoBySNForm();
                    qibsnf.Text = e.Node.Text;
                    qibsnf.TopLevel = false;
                    this.splitContainer1.Panel2.Controls.Add(qibsnf);
                    qibsnf.Show();
                    break;

                case "多个序列号查询":
                    BatchQueryForm bqm = new BatchQueryForm();
                    bqm.Text = e.Node.Text;
                    bqm.TopLevel = false;
                    this.splitContainer1.Panel2.Controls.Add(bqm);
                    bqm.Show();
                    break;
                case "根据型号查询":
                    QueryByModelForm qbmf = new QueryByModelForm();
                    qbmf.Text = e.Node.Text;
                    qbmf.TopLevel = false;
                    this.splitContainer1.Panel2.Controls.Add(qbmf);
                    qbmf.Show();
                    break;
                default:
                    break;
            }
        }
    }
}
