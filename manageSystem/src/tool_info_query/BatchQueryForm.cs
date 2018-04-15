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
    public partial class BatchQueryForm : Form
    {
        public BatchQueryForm()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Excel文件(*.xls, *.xlsx)|*.xls;*.xlsx";
            InitTextBoxHint();
        }

        private string[] getHintFromDb()
        {
            string[] records = new string[] { };
            SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
            try
            {
                SQLiteDataReader reader = db.ReadTable("ToolsInfo", new string[] { "Model" }, new string[] { "Model" }, new string[] { "like" }, new string[] { "'%%'" });
                if (!reader.HasRows)
                {
                    Console.Write("no such record");
                    return null;
                }
                List<string> recordList = records.ToList();
                while (reader.Read())
                {
                    recordList.Add(reader.GetString(reader.GetOrdinal("Model")));

                }
                records = recordList.ToArray();
            }
            catch
            {
                Console.WriteLine("query db fail");
                return null;
            }

            return records;
        }

        private void InitTextBoxHint()
        {
            string[] str = this.getHintFromDb();
            if (str == null)
            {
                return;
            }
            Console.WriteLine(str);
            this.textBox1.AutoCompleteCustomSource.AddRange(str);
            this.textBox2.AutoCompleteCustomSource.AddRange(str);
            this.textBox3.AutoCompleteCustomSource.AddRange(str);
            this.textBox4.AutoCompleteCustomSource.AddRange(str);
            this.textBox5.AutoCompleteCustomSource.AddRange(str);
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
            SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
            SQLiteDataReader reader = db.ReadTable("ToolsInfo",new string[] { "*"},new string[] { "Model"},new string[] { "="},new string[] { str});
            if (reader == null)
            {
                return;
            }
            while (reader.Read())
            {
                comboBox.Items.Add(reader.GetString(reader.GetOrdinal("SerialNum")));
            }
            return;
        }

        private ToolsInfo getOneInput(TextBox txtBox, ComboBox comboBox)
        {
            ToolsInfo toolsInfo = new ToolsInfo();
            toolsInfo.Model = txtBox.Text;
            toolsInfo.SerialNum = comboBox.Text;
            SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
            SQLiteDataReader reader = db.ReadTable("ToolsInfo", new string[] { "*" }, new string[] { "SerialNum" }, new string[] { "=" }, new string[] { toolsInfo.SerialNum });
            if(!reader.HasRows)
            {
                MessageBox.Show("序列号:" + comboBox1.Text + ", " + "型号:" + textBox1.Text + ", " + "记录不存在!");
                return null;
            } 
            while (reader.Read())
            {
                toolsInfo.Workstation = reader.GetValues().Get("Workstation");
                toolsInfo.Torque = reader.GetString(reader.GetOrdinal("Torque"));
                toolsInfo.Status = reader.GetString(reader.GetOrdinal("Status"));
                toolsInfo.QualityAssureDate = reader.GetString(reader.GetOrdinal("QualityAssureDate"));
                toolsInfo.MaintainContractStyle = reader.GetString(reader.GetOrdinal("MaintainContractStyle"));
                toolsInfo.MaintainContractDate = reader.GetString(reader.GetOrdinal("MaintainContractDate"));
                toolsInfo.Remark = reader.GetString(reader.GetOrdinal("Remark"));
                toolsInfo.RepairList = reader.GetString(reader.GetOrdinal("RepairList"));
            }           
            Console.WriteLine("toolsInfo is {0}", toolsInfo);        
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
            if (this.isTextBoxNull())
            {
                MessageBox.Show("没有记录可以导出,请先查询！");
                return;
            }
            if (this.isInputConflict())
            {
                if (DialogResult.No == MessageBox.Show("至少有两个序列号是相同的，确定导出？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information)){
                    return;
                }
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExcelOperator excel = new ExcelOperator();
                int i = 0;
                foreach(ToolsInfo toolsInfo in this.getTextBox())
                {
                    if (toolsInfo == null)
                    {                       
                        continue;
                    }
                    if (i == 0)
                    {
                        if (excel.CreateAndSaveDateToExcel(toolsInfo, saveFileDialog1.FileName))
                        {
                            i++;
                            MessageBox.Show("导出Excel成功！");
                        }
                        else
                        {
                            MessageBox.Show("导出Excel失败！");
                            break;
                        }
                    }
                    else
                    {
                        if (excel.SaveDataTableToExcel(toolsInfo, saveFileDialog1.FileName))
                        {
                            MessageBox.Show("导出Excel成功！");
                        }
                        else
                        {
                            MessageBox.Show("导出Excel失败！");
                            break;
                        }
                    }
                    
                }               
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            this.comboBox1.Items.Clear();
            setComboBoxList(this.textBox1.Text, comboBox1);
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            this.comboBox2.Items.Clear();
            setComboBoxList(this.textBox2.Text, comboBox2);
        }

        private void comboBox3_DropDown(object sender, EventArgs e)
        {
            this.comboBox3.Items.Clear();
            setComboBoxList(this.textBox3.Text, comboBox3);
        }

        private void comboBox4_DropDown(object sender, EventArgs e)
        {
            this.comboBox4.Items.Clear();
            setComboBoxList(this.textBox4.Text, comboBox4);
        }

        private void comboBox5_DropDown(object sender, EventArgs e)
        {
            this.comboBox5.Items.Clear();
            setComboBoxList(this.textBox5.Text, comboBox5);
        }
    }
}
