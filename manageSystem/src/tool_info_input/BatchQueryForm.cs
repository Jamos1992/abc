using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Model;
using BLL;

namespace manageSystem
{
    public partial class BatchQueryForm : Form
    {
        private ToolsInfoManage toolsInfoManage = new ToolsInfoManage();
        public BatchQueryForm()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Excel文件(*.xls, *.xlsx)|*.xls;*.xlsx";
            InitTextBoxHint();
        }
        private void InitTextBoxHint()
        {
            List<string> list = toolsInfoManage.GetModelHintFromDb();
            textBox1.AutoCompleteCustomSource.AddRange(list.ToArray());
            textBox2.AutoCompleteCustomSource.AddRange(list.ToArray());
            textBox3.AutoCompleteCustomSource.AddRange(list.ToArray());
            textBox4.AutoCompleteCustomSource.AddRange(list.ToArray());
            textBox5.AutoCompleteCustomSource.AddRange(list.ToArray());
        }

        private bool isTextBoxNull()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    if (c.Text != "")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void setComboBoxList(string str,ComboBox comboBox)
        {
            comboBox.Items.AddRange(toolsInfoManage.GetSerialNumHintFromDb(comboBox1.Text.Trim()).ToArray());
        }

        private ToolsInfo getOneInput(TextBox txtBox, ComboBox comboBox)
        {
            ToolsInfo toolsInfo = toolsInfoManage.QueryOneToolsInfoBySerialAndModel(comboBox.Text.Trim(),txtBox.Text.Trim());
            if(toolsInfo == null)
            {
                MessageBox.Show("序列号:" + comboBox1.Text + ", " + "型号:" + textBox1.Text + ", " + "记录不存在!");
                return null;
            }
            return toolsInfo;
        }

        private ToolsInfo[] getTextBox()
        {
            ToolsInfo[] toolsInfos = new ToolsInfo[] { };
            List<ToolsInfo> ktls = toolsInfos.ToList();
            if (textBox1.Text != "" && comboBox1.Text != "")
            {
                ktls.Add(this.getOneInput(textBox1, comboBox1));
            }
            if (textBox2.Text != "" && comboBox2.Text != "")
            {
                ktls.Add(this.getOneInput(textBox2, comboBox2));
            }
            if (textBox3.Text != "" && comboBox3.Text != "")
            {
                ktls.Add(this.getOneInput(textBox3, comboBox3));
            }
            if (textBox4.Text != "" && comboBox4.Text != "")
            {
                ktls.Add(this.getOneInput(textBox4, comboBox4));
            }
            if (textBox5.Text != "" && comboBox5.Text != "")
            {
                ktls.Add(this.getOneInput(textBox5, comboBox5));
            }
            toolsInfos = ktls.ToArray();
            return toolsInfos;
        }

        private bool isInputConflict()
        {
            List<string> inputList = new List<string>();
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(ComboBox))
                {
                    string a = inputList.Find(s => s == c.Text);
                    Console.WriteLine("a is ", a);
                    if (inputList.Find(s=> s==c.Text) != null)
                    {
                        return true;
                    }
                    if (c.Text != "")inputList.Add(c.Text);
                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isTextBoxNull())
            {
                MessageBox.Show("没有记录可以导出,请先查询！");
                return;
            }
            if (isInputConflict())
            {
                if (DialogResult.No == MessageBox.Show("至少有两个序列号是相同的，确定导出？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information)){
                    return;
                }
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string msg = toolsInfoManage.ExportBatchData2Excel(saveFileDialog1.FileName, getTextBox());
                MessageBox.Show(msg);
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            this.comboBox1.Items.Clear();
            setComboBoxList(textBox1.Text, comboBox1);
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            this.comboBox2.Items.Clear();
            setComboBoxList(textBox2.Text, comboBox2);
        }

        private void comboBox3_DropDown(object sender, EventArgs e)
        {
            this.comboBox3.Items.Clear();
            setComboBoxList(textBox3.Text, comboBox3);
        }

        private void comboBox4_DropDown(object sender, EventArgs e)
        {
            this.comboBox4.Items.Clear();
            setComboBoxList(textBox4.Text, comboBox4);
        }

        private void comboBox5_DropDown(object sender, EventArgs e)
        {
            this.comboBox5.Items.Clear();
            setComboBoxList(textBox5.Text, comboBox5);
        }
    }
}
