﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using DAL;
using Model;

namespace manageSystem.src.maintain_manage
{
    public partial class RepairRegisterForm : Form
    {
        private static string Repairing = "维修中";

        public RepairRegisterForm()
        {
            InitializeComponent();
            controlLocation();
            setDateTimePickerEmpty(dateTimePicker1);
            InitTextBoxHint();
        }

        private void controlLocation()
        {
            //TableLayoutPanelCellPosition pos = tableLayoutPanel2.GetCellPosition(textBox1);
            //int width = tableLayoutPanel2.GetColumnWidths()[pos.Column];
            //int height = tableLayoutPanel2.GetRowHeights()[pos.Row];

            //textBox1.Margin = new Padding(0, (int)tableLayoutPanel2.RowStyles[0].Height/2,0,0);
            //textBox1.Top = height / 2;
        }

        private void setDateTimePickerNormal(DateTimePicker dateTimePicker)
        {
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }

        private void setDateTimePickerEmpty(Control c)
        {
            (c as DateTimePicker).Format = DateTimePickerFormat.Custom;
            (c as DateTimePicker).CustomFormat = " ";
        }

        private void dateTimePicker1_DropDown(object sender, EventArgs e)
        {
            setDateTimePickerNormal(dateTimePicker1);
        }

        private MaintainManageInfo getAllInput()
        {
            MaintainManageInfo maintainManageInfo = new MaintainManageInfo();
            maintainManageInfo.ToolModeName = comboBox1.Text;
            maintainManageInfo.ToolSerialName = textBox2.Text;
            maintainManageInfo.SendFixTime = dateTimePicker1.Text;
            maintainManageInfo.Detail = richTextBox1.Text;
            maintainManageInfo.Status = Repairing;
            maintainManageInfo.UsedOtherSpareToolInfo = null;
            maintainManageInfo.UsedRepoSpareToolInfo = null;
            return maintainManageInfo;
        }
        private void inputAllData()
        {
            MaintainManageInfo maintainManageInfo = getAllInput();
            if (maintainManageInfo.ToolModeName == "" || maintainManageInfo.ToolSerialName == "" || maintainManageInfo.SendFixTime == "" ||maintainManageInfo.Detail == "")
            {
                MessageBox.Show("录入失败，请补全所有信息！");
                return;
            }
            try
            {
                if(new MaintainManageInfoService().IsNotFinishBreakToolExist(maintainManageInfo))
                {
                    MessageBox.Show("登记失败，该工具已经在维修中！");
                    return;
                }
                int affected = new MaintainManageInfoService().AddMaintainManageInfol(maintainManageInfo);
                if(affected < 1)
                {
                    MessageBox.Show("录入失败！");
                    return;
                }
            }
            catch
            {
                return;
            }
            MessageBox.Show("数据录入成功！");            
            return;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            inputAllData();
        }

        private void clearAllInputData()
        {
            foreach (Control c in tableLayoutPanel2.Controls)
            {
                if (c.GetType() == typeof(TextBox) || c.GetType() == typeof(ComboBox) || c is RichTextBox)
                {
                    c.Text = "";
                }
            }
            setDateTimePickerEmpty(dateTimePicker1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clearAllInputData();
        }

        private string[] getHintFromDb()
        {
            string[] records = new string[] { };
            List<MaintainManageInfo> list = new List<MaintainManageInfo>();
            try
            {
                list = new MaintainManageInfoService().getAllBreakTools();
                if (list == null)
                {
                    Console.Write("no such record");
                    return null;
                }
                List<string> recordList = records.ToList();
                foreach (MaintainManageInfo item in list)
                {
                    recordList.Add(item.ToolSerialName);
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
            comboBox1.Items.AddRange(str);
        }
    }
}
