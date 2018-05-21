using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using Model;
using DAL;

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
            ToolsInfo toolsInfo = new ToolsInfo();
            toolsInfo.Model = txtBox1.Text;
            toolsInfo.SerialNum = txtBox2.Text;            
            toolsInfo.Workstation = "";
            toolsInfo.Torque = "";
            toolsInfo.Status = "";
            toolsInfo.QualityAssureDate = "";
            toolsInfo.MaintainContractStyle = "";
            toolsInfo.MaintainContractDateStart = "";
            toolsInfo.MaintainContractDateEnd = "";
            toolsInfo.Remark = "";
            toolsInfo.RepairList = "";
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

        private void button4_Click(object sender, EventArgs e)
        {
            //Button btn = (Button)sender;
            ////lb.Parent.BackColor = Color.Red;

            ////ControlHelper是一个控件复制类，clone是类中的复制方法
            //Control gb = ControlHelper.Clone(btn.Parent, true) as Control;
            ////Control cp_lb_First_Menu = cp_pn_MenuBlock.Controls.Find(lb_First_Menu.Name, true)[0];

            //Control lb2 = gb.Controls.Find(button4.Name, true)[0];

            //Control lb1 = gb.Controls.Find(button2.Name, true)[0];
            ////lb1.Visible = false;
            //lb2.Visible = true;

            //lb1.BackColor = Color.Red;
            //this.Controls.Add(gb);
            ////保证复制后的控件都在原控件下方显示
            //gb.BringToFront();
        }
    }
}
