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
1、在表格内填入工具所有信息
2、点击“录入”存盘
3、点击“清空”删除所有表格内容";

        public static string singleQueryHint = @"
操作说明：
1、输入型号和序列号，点击“查询”；
2、点击“修改”，对查询结果进行修改；
3、点击“保存”，保存修改结果；
4、点击“导出至excel表格”，查询结果导出。";
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
                    //addForm2Panel(new BatchInputForm(), tableLayoutPanel1, ref e, singleInputHint);
                    break;
                case "标定报告管理":
                    //addForm2Panel(new QueryInfoBySNForm(), tableLayoutPanel1, ref e, singleQueryHint);
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
