﻿using manageSystem.src.spare_manage;
using System.Drawing;
using System.Windows.Forms;

namespace manageSystem
{
    public partial class SpareManageForm : Form
    {
        public static string inputHint = @"
操作说明：
1、在表格内填入工具所有信息
2、点击“录入”存盘
3、点击“备件消耗”跳转到备件消耗页面
3、点击“清空”删除所有表格内容
4、点击“备件消耗”跳转到备件消耗页面";

        public static string queryHint = @"
操作说明：
1、勾选日期，输入起始日期和终止日期，点击“查询”可查询该时间区间的所有记录
2、勾选备件型号，选择或输入备件型号，点击“查询”可查询该型号的备件记录
3、点击“清空”清除筛选条件
4、点击“查询结果导出”可导出所有勾选的结果至excel";

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
                    addForm2Panel(new SpareInfoInputForm(), tableLayoutPanel1, ref e, inputHint);
                    break;

                case "仓库备件清单":
                    addForm2Panel(new RepoSpareListForm(), tableLayoutPanel1, ref e, queryHint);
                    break;
                case "建议采购备件查询":
                    addForm2Panel(new SpareRecommandForm(), tableLayoutPanel1, ref e, queryHint);
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
