using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Model;
using manageSystem.src.spare_manage;

namespace manageSystem
{
    public partial class SpareInfoInputForm : Form
    {
        private RepoSpareToolManage repoSpareToolManage = new RepoSpareToolManage();
        public SpareInfoInputForm()
        {
            InitializeComponent();
        }

        private RepoSpareTool getOneInput(TextBox txtBox, NumericUpDown upDown)
        {
            RepoSpareTool repoSpareTool = new RepoSpareTool();
            repoSpareTool.SpareToolModel = txtBox.Text;
            repoSpareTool.Num = (int)upDown.Value;
            repoSpareTool.AddTime = DateTime.Now.ToString("yyyy-MM-dd");
            return repoSpareTool;
        }

        private void insertValue2Db(RepoSpareTool[] repoSpareTools)
        {
            if (repoSpareTools.Length == 0)
            {
                MessageBox.Show("录入失败，输入的记录个数为0", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            foreach (RepoSpareTool repoSpareTool in repoSpareTools)
            {
                try
                {
                    if (repoSpareToolManage.IsRepoSpareToolExist(repoSpareTool.SpareToolModel))
                    {
                        RepoSpareTool repoSpare = repoSpareToolManage.QueryOneRepoSpare(repoSpareTool.SpareToolModel);
                        repoSpare.Num += repoSpareTool.Num;
                        int affected = repoSpareToolManage.UpdateRepoSpareNum(repoSpare.SpareToolModel, repoSpare.Num);
                        if(affected < 1)
                        {
                            MessageBox.Show("序列号(" + repoSpareTool.SpareToolModel + ") 插入失败, 已存在序列号相同的记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        MessageBox.Show("数据录入成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    int affectedRow = repoSpareToolManage.AddRepoSpareTool(repoSpareTool);
                    if(affectedRow < 1)
                    {
                        MessageBox.Show("录入失败，操作数据库失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    MessageBox.Show("数据录入成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                catch
                {
                    MessageBox.Show("数据录入失败，操作数据库失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
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

        private void btnSpareInfo_Click(object sender, EventArgs e)
        {
            RepoSpareListForm repoSpareListForm = new RepoSpareListForm();
            repoSpareListForm.FormBorderStyle = FormBorderStyle.Sizable;
            repoSpareListForm.MinimizeBox = false;
            repoSpareListForm.MaximizeBox = false;
            repoSpareListForm.Text = "备件消耗";
            repoSpareListForm.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach(Control c in Controls)
            {
                if(c is TextBox || c is NumericUpDown)
                {
                    c.Text = "";
                }
            }
        }
    }
}
