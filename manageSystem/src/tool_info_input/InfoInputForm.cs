using System;
using System.Drawing;
using System.Windows.Forms;

namespace manageSystem
{
    public partial class InfoInputForm : Form
    {
        public static string singleInputHint  = @"
操作说明：
1、在表格内填入工具所有信息
2、点击“录入”存盘
3、点击“清空”删除所有表格内容";

        public static string singleQueryHint = @"
操作说明：
1、输入型号和序列号，点击“查询”；
2、点击“修改”，对查询结果进行修改；
3、点击“保存”，保存修改结果；
4、点击“导出至excel表格”，查询结果导出。";

        public InfoInputForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
        }

        private void InfoInputForm_Load(object sender, EventArgs e)
        {
            treeviewInput.ExpandAll();
            treeviewInput.Nodes[0].ImageIndex = 0;
            treeviewInput.Nodes[0].SelectedImageIndex = 0;
            treeviewInput.Nodes[0].Nodes[0].ImageIndex = 0;
            treeviewInput.Nodes[0].Nodes[0].SelectedImageIndex = 0;
            treeviewInput.Nodes[0].Nodes[1].ImageIndex = 0;
            treeviewInput.Nodes[0].Nodes[1].SelectedImageIndex = 0;
            treeviewInput.Nodes[1].ImageIndex = 1;
            treeviewInput.Nodes[1].SelectedImageIndex = 1;
            treeviewInput.Nodes[1].Nodes[0].ImageIndex = 1;
            treeviewInput.Nodes[1].Nodes[0].SelectedImageIndex = 1;
            treeviewInput.Nodes[1].Nodes[1].ImageIndex = 1;
            treeviewInput.Nodes[1].Nodes[1].SelectedImageIndex = 1;
            richTextBox1.Clear();
            label2.Text = "";
        }

        private void InfoInputForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void treeviewInput_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // lablHint.Text = treeviewInput.SelectedNode.Text;
            
            foreach(Control c in tableLayoutPanel1.Controls)
            {
                if(c is Form)
                {
                    (c as Form).Close();
                    //tableLayoutPanel1.Controls.Remove(c);
                }
            }

            foreach (TreeNode treeNode in treeviewInput.Nodes)
            {
                foreach (TreeNode subTreeNode in treeNode.Nodes)
                {
                    subTreeNode.ForeColor = Color.Black;
                }                  
            }
            switch (e.Node.Text)
            {
                case "单条录入":                   
                    addForm2Panel(new SingleInputForm(), tableLayoutPanel1, ref e, singleInputHint);
                    break;
                case "批量录入":
                    addForm2Panel(new BatchInputForm(), tableLayoutPanel1,ref e, singleInputHint);
                    break;
                case "单条查询":
                    addForm2Panel(new QueryInfoBySNForm(), tableLayoutPanel1, ref e, singleQueryHint);
                    break;
                case "批量查询":
                    addForm2Panel(new BatchQueryForm(), tableLayoutPanel1,ref e, singleQueryHint);                   
                    break;
                default:
                    label2.Text = "";
                    break;
            }
        }

        private void setFormSize(Form form, Panel panel)
        {
            //form.Width = panel.Width;
            //form.Height = panel.Height-30;
            form.Dock = DockStyle.Fill;
        }

        private void addForm2Panel(Form form, Panel panel,ref TreeViewEventArgs e,string hint)
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
