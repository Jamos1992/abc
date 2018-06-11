using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace manageSystem.src.demarcate_manage
{
    public partial class DemarcateManageForm : Form
    {
        public static string singleInputHint = @"
操作说明：
1、输入工具型号、工具序列号和日期
2、点击“添加”将记录添加到标定计划中";

        public static string demarcateHint = @"
操作说明：
1、点击“扫码输入”，待扫码枪扫码完
2、扫码完成后，点击“监听标定仪器数据”开始监听数据
3、数据显示在下方表格，通过“删除”可删除不合格数据
4、点击“计算标定结果”可以计算此次标定是否合格
5、合格后便可以“打印标签”
6、点击“串口参数设置”可以设置串口以接收标定仪器的数据
7、点击“重新标定”可以进入下一把工具的标定";
        public static string resultHint = @"
操作说明
1、输入工位号、工具型号或者工具序列号
2、点击“查询”可查询相关工具信息
3、点击“标定记录导出至excel”可以将相关工具的标定历史导出到excel中";
        public DemarcateManageForm()
        {
            InitializeComponent();
        }
        private void treeviewInput_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // lablHint.Text = treeviewInput.SelectedNode.Text;

            foreach (Control c in tableLayoutPanel1.Controls)
            {
                if (c is Form)
                {
                    tableLayoutPanel1.Controls.Remove(c);
                }
            }

            foreach (TreeNode treeNode in treeviewInput.Nodes)
            {
                treeNode.ForeColor = Color.Black;
            }
            switch (e.Node.Text)
            {
                case "标定计划管理":
                    addForm2Panel(new AddDemarcateForm(), tableLayoutPanel1, ref e, singleInputHint);
                    break;
                case "进入标定":
                    addForm2Panel(new DemarcateOperationForm(), tableLayoutPanel1, ref e, demarcateHint);
                    break;
                case "标定报告管理":
                    addForm2Panel(new DemarcateHistoryForm(), tableLayoutPanel1, ref e, resultHint);
                    break;
                default:
                    label2.Text = "";
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
