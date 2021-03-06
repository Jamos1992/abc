﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace manageSystem
{
    public partial class InfoInputForm : Form
    {
        public static string inputHint  = @"
操作说明：
1、在表格内填入工具所有信息
2、点击“录入”存盘
3、点击“清空”删除所有表格内容
4、点击“从excel导入”可以批量导入工具数据";

        public static string queryHint = @"
操作说明：
1、输入型号和序列号，点击“+”可增加一组型号和序列号；
2、点击“查询”；
3、在查询表格中点击“修改”，可修改查询结果；
4、点击“导出至excel表格”导出查询结果。";

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
            DialogResult = DialogResult.OK;
        }

        private void treeviewInput_AfterSelect(object sender, TreeViewEventArgs e)
        {   
            foreach(Control c in tableLayoutPanel1.Controls)
            {
                if(c is Form)
                {
                    (c as Form).Close();
                }
            }

            foreach (TreeNode treeNode in treeviewInput.Nodes)
            {
                treeNode.ForeColor = Color.Black;
                foreach (TreeNode subTreeNode in treeNode.Nodes)
                {
                    subTreeNode.ForeColor = Color.Black;
                }                  
            }
            switch (e.Node.Text)
            {
                case "工具录入":                   
                    addForm2Panel(new SingleInputForm(), tableLayoutPanel1, ref e, inputHint);
                    break;
                case "现场工具信息查询":
                    addForm2Panel(new BatchQueryForm(), tableLayoutPanel1, ref e, queryHint);
                    break;
                case "Service Link查询工具信息":
                    System.Diagnostics.Process.Start("https://www.desouttertools.com.cn/fu-wu/service-link");              
                    break;
                default:
                    label2.Text = "";
                    break;
            }
        }

        private void setFormSize(Form form, Panel panel)
        {
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
