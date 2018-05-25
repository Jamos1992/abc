using manageSystem.src.spare_manage;
using System.Drawing;
using System.Windows.Forms;

namespace manageSystem
{
    public partial class SpareManageForm : Form
    {
        public static string singleInputHint = @"
操作说明：
1、在表格内填入工具所有信息
2、点击“录入”存盘
3、点击“备件消耗”跳转到备件消耗页面
3、点击“清空”删除所有表格内容";

        public static string singleQueryHint = @"
操作说明：
1、输入型号和序列号，点击“查询”；
2、点击“修改”，对查询结果进行修改；
3、点击“保存”，保存修改结果；
4、点击“导出至excel表格”，查询结果导出。";

        public SpareManageForm()
        {
            InitializeComponent();
            MaximizeBox = false;
            MinimizeBox = false;
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
                treeNode.ForeColor = Color.Black;
            }
            switch (e.Node.Text)
            {
                case "备件信息录入":
                    addForm2Panel(new SpareInfoInputForm(), tableLayoutPanel1, ref e, singleInputHint);
                    //SpareInfoInputForm siif = new SpareInfoInputForm();
                    //siif.Text = e.Node.Text;
                    //siif.TopLevel = false;
                    //this.splitContainer1.Panel2.Controls.Add(siif);
                    //siif.Show();
                    break;

                case "仓库备件清单":
                    addForm2Panel(new RepoSpareListForm(), tableLayoutPanel1, ref e, singleInputHint);
                    //QueryRepoSpareForm qrsf = new QueryRepoSpareForm();
                    //qrsf.Text = e.Node.Text;
                    //qrsf.TopLevel = false;
                    //this.splitContainer1.Panel2.Controls.Add(qrsf);
                    //qrsf.Show();
                    break;
                //case "工具零备件查询":
                //    addForm2Panel(new QueryToolSpareForm(), tableLayoutPanel1, ref e, singleInputHint);
                //    //QueryToolSpareForm qtsf = new QueryToolSpareForm();
                //    //qtsf.Text = e.Node.Text;
                //    //qtsf.TopLevel = false;
                //    //this.splitContainer1.Panel2.Controls.Add(qtsf);
                //    //qtsf.Show();
                //    break;
                case "建议采购备件查询":
                    break;
                default:
                    break;
            }
        }
        private void setFormSize(Form form, Panel panel)
        {
            form.Width = panel.Width;
            form.Height = panel.Height - 30;
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
