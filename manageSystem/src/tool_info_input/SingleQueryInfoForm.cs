using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using BLL;
using Model;

namespace manageSystem
{
    public partial class QueryInfoBySNForm : Form
    {
        private ToolsInfoManage toolsInfoManage = new ToolsInfoManage();
        public QueryInfoBySNForm()
        {
            InitializeComponent();
            this.setBtnLocation();
        }

        private void setBtnLocation()
        {
            this.button2.Left = this.button1.Left;
            this.button2.Width = this.button3.Right - this.button1.Left;
        }

        private void QueryInfoBySNForm_Load(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Excel文件(*.xls, *.xlsx)|*.xls;*.xlsx";
            this.button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {              
            if (textBox1.Text == "")
            {
                MessageBox.Show("查询失败，请输入查询序列号！");
                clearTextBox4Query();
                button3.Enabled = false;
                return;
            }
            ToolsInfo toolsInfo = toolsInfoManage.QueryOneToolsInfo(textBox1.Text.Trim());
            if (toolsInfo == null)
            {
                MessageBox.Show("查询失败，该记录不存在！");
                clearTextBox4Query();
                button3.Enabled = false;
                return;
            }
            setTextBox(toolsInfo);
            //MessageBox.Show("查询成功！");
            changeTextBoxReadOnly();
            button3.Enabled = true;
        }

        private void setTextBox(ToolsInfo toolsInfo)
        {
            this.textBox1.Text = toolsInfo.SerialNum;
            this.textBox2.Text = toolsInfo.Model;
            this.textBox3.Text = toolsInfo.Workstation;
            this.textBox4.Text = toolsInfo.Torque;
            this.textBox5.Text = toolsInfo.Status;
            this.textBox6.Text = toolsInfo.QualityAssureDate;
            this.textBox7.Text = toolsInfo.RepoSpareTool;
            this.textBox8.Text = toolsInfo.MaintainContractStyle;
            this.textBox9.Text = toolsInfo.MaintainContractDateStart;
            this.textBox10.Text = toolsInfo.MaintainContractDateEnd;
            this.textBox11.Text = toolsInfo.Remark;
            this.textBox12.Text = toolsInfo.MaintainInfo;
            this.textBox13.Text = toolsInfo.RepairList;
        }

        private ToolsInfo getTextBox()
        {
            ToolsInfo toolsInfo = new ToolsInfo();
            toolsInfo.SerialNum = this.textBox1.Text;
            toolsInfo.Model = this.textBox2.Text;
            toolsInfo.Workstation = this.textBox3.Text;
            toolsInfo.Torque = this.textBox4.Text;
            toolsInfo.Status = this.textBox5.Text;
            toolsInfo.QualityAssureDate = this.textBox6.Text;
            toolsInfo.RepoSpareTool = this.textBox7.Text;
            toolsInfo.MaintainContractStyle = this.textBox8.Text;
            toolsInfo.MaintainContractDateStart = this.textBox9.Text;
            toolsInfo.MaintainContractDateEnd = this.textBox10.Text;
            toolsInfo.Remark = this.textBox11.Text;
            toolsInfo.RepairList = this.textBox12.Text;
            toolsInfo.MaintainInfo = this.textBox13.Text;
            return toolsInfo;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            changeTextBoxWrite();
            if (this.button3.Text == "保存")
            {
                try
                {
                    toolsInfoManage.UpdateOneToolsInfo(getTextBox(), textBox1.Text.Trim());
                }                                            
                catch(Exception ex)
                {
                    label11.ForeColor = Color.Red;
                    label11.Text = "修改失败";
                    MessageBox.Show("修改失败,原因：{0}",ex.Message);
                    return;
                }
                button3.Text = "修改";
                label11.ForeColor = Color.Green;
                label11.Text = "修改成功!";
                clearTextBox();
                button1.Enabled = true;
                return;
            }
            button3.Text = "保存";
            button1.Enabled = false;
        }

        private bool isTextBoxNull()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    if (c.Text != "" && c.Name != "textBox1")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void clearTextBox()
        {
            foreach(Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    c.Text = "";
                }
            }
        }

        private void clearTextBox4Query()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    TextBox txtBox = (TextBox)c;
                    if (c != textBox1)
                    {
                        c.Text = "";
                    }                       
                }
            }
        }

        private void changeTextBoxReadOnly()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    TextBox txtBox = (TextBox)c;
                    if (c != textBox1)
                    {
                        txtBox.ReadOnly = true;
                    }   
                }
            }
        }

        private void changeTextBoxWrite()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    TextBox txtBox = (TextBox)c;
                    txtBox.ReadOnly = false;
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (isTextBoxNull())
            {
                MessageBox.Show("没有记录可以导出,请先查询！");
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string msg = toolsInfoManage.ExportSingleData2Excel(saveFileDialog1.FileName, getTextBox());
                MessageBox.Show(msg);
            }
        }
    }
}
