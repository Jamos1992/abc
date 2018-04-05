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
    public partial class SpareManageForm : Form
    {
        public SpareManageForm()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            switch (e.Node.Text)
            {
                case "备件信息录入":
                    SpareInfoInputForm siif = new SpareInfoInputForm();
                    siif.Text = e.Node.Text;
                    siif.TopLevel = false;
                    this.splitContainer1.Panel2.Controls.Add(siif);
                    siif.Show();
                    break;

                case "仓库备件查询":
                    QueryRepoSpareForm qrsf = new QueryRepoSpareForm();
                    qrsf.Text = e.Node.Text;
                    qrsf.TopLevel = false;
                    this.splitContainer1.Panel2.Controls.Add(qrsf);
                    qrsf.Show();
                    break;
                case "工具零备件查询":
                    QueryToolSpareForm qtsf = new QueryToolSpareForm();
                    qtsf.Text = e.Node.Text;
                    qtsf.TopLevel = false;
                    this.splitContainer1.Panel2.Controls.Add(qtsf);
                    qtsf.Show();
                    break;
                case "建议采购备件查询":
                    break;
                default:
                    break;
            }
        }
    }
}
