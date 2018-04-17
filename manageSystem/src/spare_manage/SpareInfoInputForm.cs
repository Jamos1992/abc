using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace manageSystem
{
    public partial class SpareInfoInputForm : Form
    {
        public SpareInfoInputForm()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            //domainUpDown1.Text = "1";
        }

        private RepoSpareTool getOneInput(TextBox txtBox, NumericUpDown upDown)
        {
            RepoSpareTool repoSpareTool = new RepoSpareTool();
            repoSpareTool.SpareToolModel = txtBox.Text;
            repoSpareTool.Num = (int)upDown.Value;
            repoSpareTool.Time = DateTime.Now;
            repoSpareTool.SerialNum = "";
            return repoSpareTool;
        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void insertValue2Db(RepoSpareTool[] repoSpareTools)
        {
            SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
            foreach (RepoSpareTool repoSpareTool in repoSpareTools)
            {
                try
                {
                    SQLiteDataReader reader = db.ReadTable("RepoSpareTool", new string[] { "*" }, new string[] { "SpareToolModel" }, new string[] { "=" }, new string[] { repoSpareTool.SpareToolModel });
                    if (reader.HasRows)
                    {
                        MessageBox.Show("序列号(" + repoSpareTool.SpareToolModel + ") 插入失败, 已存在序列号相同的记录！");
                        return;
                    }
                    db.InsertValuesByStruct("RepoSpareTool", repoSpareTool);
                }
                catch
                {
                    MessageBox.Show("插入数据失败！");
                }
            }
        }
    }
}
