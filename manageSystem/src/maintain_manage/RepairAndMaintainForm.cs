using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace manageSystem.src.maintain_manage
{
    public partial class RepairAndMaintainForm : Form
    {
        public RepairAndMaintainForm()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            switch (e.Node.Text)
            {
                case "维修登记":
                    RepairRegisterForm rrf = new RepairRegisterForm();
                    rrf.Text = e.Node.Text;
                    rrf.TopLevel = false;
                    this.splitContainer1.Panel2.Controls.Add(rrf);
                    rrf.Show();
                    break;

                case "工具维修":
                    RepairOperatorForm rof = new RepairOperatorForm();
                    rof.Text = e.Node.Text;
                    rof.TopLevel = false;
                    this.splitContainer1.Panel2.Controls.Add(rof);
                    rof.Show();
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

        private void RepairAndMaintainForm_Load(object sender, EventArgs e)
        {
            this.treeView1.ExpandAll();
            this.treeView1.Nodes[0].ImageIndex = 0;
            this.treeView1.Nodes[0].SelectedImageIndex = 0;
            this.treeView1.Nodes[1].ImageIndex = 1;
            this.treeView1.Nodes[1].ImageIndex = 1;
            //Console.Write("node is {0}",treeView1.Nodes.)
            //treeView1.GetNodeCount();  
        }
    }
}
