using System;
using System.Drawing;
using System.Windows.Forms;

namespace manageSystem.src.maintain_manage
{
    public partial class RepairAndMaintainForm : Form
    {
        public static string inputHint = @"
操作说明：
1、在表格内填入所有信息
2、点击“登记”存盘
3、点击“清空”删除所有表格内容";

        public static string queryHint = @"
操作说明：
1、勾选工具状态，点击“查询”可查询所有该状态的记录
2、点击记录中“维修”可以进入维修页面
3、点击“导出”可以导出查询的所有结果";
        public RepairAndMaintainForm()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is Form)
                {
                    tableLayoutPanel1.Controls.Remove(c);
                }
            }

            foreach (TreeNode treeNode in treeView1.Nodes)
            {
                foreach (TreeNode subTreeNode in treeNode.Nodes)
                {
                    subTreeNode.ForeColor = Color.Black;
                }
            }
            switch (e.Node.Text)
            {
                case "维修工具登记":
                    addForm2Panel(new RepairRegisterForm(), tableLayoutPanel1, ref e, inputHint);
                    break;

                case "工具维修操作":
                    addForm2Panel(new RepairManageForm(), tableLayoutPanel1, ref e, queryHint);
                    break;
                case "制定保养计划":
                    addForm2Panel(new MaintainRegisterForm(), tableLayoutPanel1, ref e, queryHint);
                    break;
                case "实施保养操作":
                    //addForm2Panel(new QueryByModelForm(), tableLayoutPanel1, ref e, queryHint);
                    break;
                default:
                    break;
            }
        }

        private void RepairAndMaintainForm_Load(object sender, EventArgs e)
        {
            treeView1.ExpandAll();
            treeView1.Nodes[0].ImageIndex = 0;
            treeView1.Nodes[0].SelectedImageIndex = 0;
            treeView1.Nodes[0].Nodes[0].ImageIndex = 0;
            treeView1.Nodes[0].Nodes[0].SelectedImageIndex = 0;
            treeView1.Nodes[0].Nodes[1].ImageIndex = 0;
            treeView1.Nodes[0].Nodes[1].SelectedImageIndex = 0;
            treeView1.Nodes[1].ImageIndex = 1;
            treeView1.Nodes[1].SelectedImageIndex = 1;
            treeView1.Nodes[1].Nodes[0].ImageIndex = 1;
            treeView1.Nodes[1].Nodes[0].SelectedImageIndex = 1;
            treeView1.Nodes[1].Nodes[1].ImageIndex = 1;
            treeView1.Nodes[1].Nodes[1].SelectedImageIndex = 1;
            richTextBox1.Clear();
            label2.Text = "";
        }

        private void setFormSize(Form form, Panel panel)
        {
            form.Dock = DockStyle.Fill;
        }

        private void addForm2Panel(Form form, Panel panel, ref TreeViewEventArgs e, string hint)
        {
            e.Node.ForeColor = Color.Gray;
            form.Text = e.Node.Text;
            form.TopLevel = false;
            setFormSize(form, tableLayoutPanel1);
            tableLayoutPanel1.Controls.Add(form, 0, 1);
            form.Show();
            label2.Text = e.Node.Text;
            richTextBox1.Text = hint;
        }
    }
}
