using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace manageSystem
{
    public partial class BatchInputForm : Form
    {
        public BatchInputForm()
        {
            InitializeComponent();
            InitTextBoxHint();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToolsInfo[] toolsInfos = new ToolsInfo[] { };
            List<ToolsInfo> ktls = toolsInfos.ToList();
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                ktls.Add(this.getOneInput(textBox1, textBox2));
            }
            if (textBox3.Text != "" && textBox4.Text != "")
            {
                ktls.Add(this.getOneInput(textBox3, textBox4));
            }
            if (textBox5.Text != "" && textBox6.Text != "")
            {
                ktls.Add(this.getOneInput(textBox5, textBox6));
            }
            if (textBox7.Text != "" && textBox8.Text != "")
            {
                ktls.Add(this.getOneInput(textBox7, textBox8));
            }
            if (textBox9.Text != "" && textBox10.Text != "")
            {
                ktls.Add(this.getOneInput(textBox9, textBox10));
            }
            toolsInfos = ktls.ToArray();
            insertValue2Db(toolsInfos);

        }

        private ToolsInfo getOneInput(TextBox txtBox1,TextBox txtBox2)
        {


            ToolsInfo toolsInfo = new ToolsInfo()
            {
                SerialNum = txtBox1.Text.Trim(),
                Model = txtBox2.Text.Trim(),
                //Category = "",
                //Name = "",
                //TorqueMin = "",
                //TorqueMax = "",
                //Accuracy = int.Parse(accuracyBox.Text.Trim()),
                //Section = sectionBox.Text.Trim(),
                //DemarcateCycle = (int)cycleBox.Value,
                //Workstation = workstationBox.Text.Trim(),
                //Status = statusBox.Text.Trim(),
                //QualityAssureDate = qualityBox.Text.Trim(),
                //MaintainContractStyle = contractBox.Text.Trim(),
                //MaintainContractDate = maintainBox.Text.Trim(),
                //RepairTimes = (int)repairTimeBox.Value,
                //ChangeRecord = repairBox.Text.Trim(),
                //Remark = remarkBox.Text.Trim()
            };
            return toolsInfo;
        }

        private void insertValue2Db(ToolsInfo[] toolsInfos)
        {
           
            foreach(ToolsInfo toolsInfo in toolsInfos)
            {
                try
                {
                    if(new ToolsInfoService().IsToolExist(toolsInfo))
                    {
                        MessageBox.Show("序列号(" + toolsInfo.SerialNum + ") 插入失败, 已存在序列号相同的记录！");
                        return;
                    }
                    int affectedRow = new ToolsInfoService().AddTools(toolsInfo);
                    if(affectedRow < 1)
                    {
                        MessageBox.Show("插入数据失败！");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("插入数据失败！");
                }
            }            
        }

        private string[] getHintFromDb()
        {
            string[] records = new string[] { };
            try
            {
                List<ToolsInfo> list = new ToolsInfoService().getAllToolsInfo();
                if (list == null)
                {
                    Console.Write("no such record");
                    return null;
                }
                List<string> recordList = records.ToList();
                foreach(ToolsInfo tools in list)
                {
                    recordList.Add(tools.Model);
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
            this.textBox3.AutoCompleteCustomSource.AddRange(str);
            this.textBox5.AutoCompleteCustomSource.AddRange(str);
            this.textBox7.AutoCompleteCustomSource.AddRange(str);
            this.textBox9.AutoCompleteCustomSource.AddRange(str);
        }
    }
}
