using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using Model;
using manageSystem.src.spare_manage;

namespace manageSystem
{
    public partial class SpareInfoInputForm : Form
    {
        public SpareInfoInputForm()
        {
            InitializeComponent();
        }

        private RepoSpareTool getOneInput(TextBox txtBox, NumericUpDown upDown)
        {
            RepoSpareTool repoSpareTool = new RepoSpareTool();
            repoSpareTool.SpareToolModel = txtBox.Text;
            repoSpareTool.Num = (int)upDown.Value;
            repoSpareTool.AddTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return repoSpareTool;
        }

        private void insertValue2Db(RepoSpareTool[] repoSpareTools)
        {
            if (repoSpareTools.Length == 0)
            {
                MessageBox.Show("录入失败，输入的记录个数为0");
                return;
            }
            foreach (RepoSpareTool repoSpareTool in repoSpareTools)
            {
                try
                {
                    if (new RepoSpareToolService().IsRepoSpareToolExist(repoSpareTool.SpareToolModel))
                    {
                        MessageBox.Show("序列号(" + repoSpareTool.SpareToolModel + ") 插入失败, 已存在序列号相同的记录！");
                        return;
                    }
                    int affectedRow = new RepoSpareToolService().AddRepoSpareTool(repoSpareTool);
                    if(affectedRow < 1)
                    {
                        MessageBox.Show("录入失败，操作数据库失败！");
                        return;
                    }
                    MessageBox.Show("数据录入成功");
                    return;
                }
                catch
                {
                    MessageBox.Show("数据录入失败，操作数据库失败！");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RepoSpareTool[] repoSpareTools = new RepoSpareTool[] { };
            List<RepoSpareTool> ktls = repoSpareTools.ToList();
            if (textBox1.Text != "" && numericUpDown1.Value != 0)
            {
                ktls.Add(this.getOneInput(textBox1, numericUpDown1));
            }
            if (textBox2.Text != "" && numericUpDown2.Value != 0)
            {
                ktls.Add(this.getOneInput(textBox2, numericUpDown2));
            }
            if (textBox3.Text != "" && numericUpDown3.Value != 0)
            {
                ktls.Add(this.getOneInput(textBox3, numericUpDown3));
            }
            if (textBox4.Text != "" && numericUpDown4.Value != 0)
            {
                ktls.Add(this.getOneInput(textBox4, numericUpDown4));
            }
            if (textBox5.Text != "" && numericUpDown5.Value != 0)
            {
                ktls.Add(this.getOneInput(textBox5, numericUpDown5));
            }
            repoSpareTools = ktls.ToArray();
            insertValue2Db(repoSpareTools);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RepoSpareListForm repoSpareListForm = new RepoSpareListForm();
            repoSpareListForm.FormBorderStyle = FormBorderStyle.Sizable;
            repoSpareListForm.MinimizeBox = false;
            repoSpareListForm.MaximizeBox = false;
            repoSpareListForm.Text = "备件消耗";
            repoSpareListForm.ShowDialog();
        }
    }
}
