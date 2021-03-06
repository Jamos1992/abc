﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using BLL;
using Model;
using Util;

namespace manageSystem.src.demarcate_manage
{
    public partial class DemarcateOperatorForm : Form
    {
        private int pageNum = 1;
        private DemarcateRecordManage demarcateRecordManage = new DemarcateRecordManage();
        private ToolsInfoManage toolsInfoManage = new ToolsInfoManage();

        private DemarcateDataUploadForm demarcateDataUploadForm = new DemarcateDataUploadForm();
        private QRCodePrintForm qRCodePrintForm = new QRCodePrintForm();
        private MaintainInfoManage maintainInfoManage = new MaintainInfoManage();

        private CheckManManage checkManManage = new CheckManManage();
        private Button btnFinsih = new Button();

        private Graphics g;
        public string serialNum;

        private bool IsdemarcateFinsih = false;
        public DemarcateOperatorForm()
        {
            InitializeComponent();
            btnLastStep.Visible = false;
            FormBorderStyle = FormBorderStyle.None;
            //paint_stepLine();
            demarcateDataUploadForm.setOperatorFormBtnDelegate += new setFormBtnDelegate(setFormComBtn);
            g = gbStep.CreateGraphics();
            toolStripButton1.Visible = false;

            
            btnFinsih.Text = "完成";
            btnFinsih.Font = btnNextStep.Font;
            btnFinsih.ForeColor = btnNextStep.ForeColor;
            btnFinsih.FlatStyle = FlatStyle.Popup;
            btnFinsih.Visible = false;
            btnFinsih.Height = btnNextStep.Height;
            btnFinsih.Click += new EventHandler(btnFinish_Click);
        }

        private void setFormComBtn()
        {
            toolStripButton1.Enabled = false;
        }

        private void btnScanInput_Click(object sender, EventArgs e)
        {
            ScanCodeForm scanCodeForm = new ScanCodeForm();
            scanCodeForm.setFormTextValue += new setTextValue(txtSerialNum_setValue);
            scanCodeForm.ShowDialog();
        }
        void txtSerialNum_setValue(string serialNum)
        {
            txtSerialNum.Text = serialNum;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ComSettingForm comSettingForm = new ComSettingForm();
            if (comSettingForm.ShowDialog() == DialogResult.OK)
            {
                Show();
            }
        }
        private bool isToolsExist(string serialNum)
        {
            return demarcateRecordManage.IsDemarcateToolExist(serialNum);
        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            if(pageNum == 1)
            {
                if(txtSerialNum.Text.Trim() == "")
                {
                    MessageBox.Show("序列号不能为空，请输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(cmbCheckMan.Text.Trim() == "")
                {
                    MessageBox.Show("校准检查员不能为空，请输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!isToolsExist(txtSerialNum.Text.Trim()))
                {
                    if (!toolsInfoManage.IsToolExistInDb(txtSerialNum.Text.Trim()))
                    {
                        MessageBox.Show("仓库中不存在序列号为" + txtSerialNum.Text.Trim() + "的工具，请先录入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (MessageBox.Show("工具序列号不在校准计划中，是否继续？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                try
                {
                    checkManManage.AddOneName(cmbCheckMan.Text.Trim());
                }
                catch (Exception ex)
                {
                    Console.Write("add name fail",ex.Message);
                }
                
            }
            pageNum++;
            DemarcateTools demarcateTools = demarcateRecordManage.getOneDemarcateToolBySerialNum(txtSerialNum.Text.Trim());
            if (pageNum == 2)
            {
                if (Convert.ToDateTime(demarcateTools.NextTime) > DateTime.Now)
                {
                    pageNum--;
                    if(MessageBox.Show($"该工具的预计校准日期为{demarcateTools.NextTime}，确定要继续校准吗？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                
                btnNextStep.Text = "下一步";
                //btnLastStep.Visible = true;
                btnNextStep.Enabled = true;
                btnLastStep.Enabled = true;
                foreach (Control c in panel2.Controls)
                {
                    c.Visible = false;
                }                
                demarcateDataUploadForm.FormBorderStyle = FormBorderStyle.None;
                demarcateDataUploadForm.Dock = DockStyle.Fill;
                demarcateDataUploadForm.TopLevel = false;
                demarcateDataUploadForm.SerialNum = txtSerialNum.Text.Trim();
                demarcateDataUploadForm.CheckMan = cmbCheckMan.Text.Trim();
                panel2.Controls.Add(demarcateDataUploadForm);
                demarcateDataUploadForm.Show();                
            }
            if (pageNum == 3)
            {
                if (!demarcateDataUploadForm.CalcDemarcateResult())
                {
                    pageNum--;
                    return;
                }
                if (!demarcateDataUploadForm.DemarcateResult)
                {
                    pageNum--;
                    demarcateDataUploadForm.setResultLabel("校准结果：不合格");
                    if(MessageBox.Show("校准结果不合格，是否重新校准？\n点击确定将会清除校准数据\n点击取消将会把工具标记为待修", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)== DialogResult.OK)
                    {
                        demarcateDataUploadForm.reDemarcateActon();
                        demarcateDataUploadForm.setResultLabel("校准结果：");
                    }
                    else
                    {
                        MaintainManageInfo maintainManageInfo = new MaintainManageInfo
                        {
                            ToolSerialName = txtSerialNum.Text.Trim(),
                            ToolModeName = toolsInfoManage.QueryOneToolsInfo(txtSerialNum.Text.Trim()).Model,
                            SendFixTime = DateTime.Now.ToString("yyyy-MM-dd"),
                            Detail = DemarcateStatusDeclare.OffGrade
                        };
                        string msg = maintainInfoManage.RegisterBreakTool(maintainManageInfo);
                        if (!msg.Contains("成功"))
                        {
                            MessageBox.Show($"移至待修出错！原因：{msg}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    return;
                }
                btnNextStep.Text = "进入下一个工具校准";
                //btnNextStep.Location = new Point(btnNextStep.Location.X -90, btnNextStep.Location.Y);
                btnNextStep.Enabled = true;
                //btnLastStep.Visible = true;
                btnLastStep.Enabled = true;
                btnFinsih.Visible = true;
                btnFinsih.Location = new Point(btnNextStep.Location.X - btnFinsih.Width - 15, btnNextStep.Location.Y);
                panel3.Controls.Add(btnFinsih);
                btnFinsih.BringToFront();
                foreach (Control c in panel2.Controls)
                {
                    c.Visible = false;
                }
                qRCodePrintForm.demarcateRecords = demarcateDataUploadForm.GetDemarcateRecords();
                qRCodePrintForm.FormBorderStyle = FormBorderStyle.None;
                qRCodePrintForm.Dock = DockStyle.Fill;
                //qRCodePrintForm.Location = new Point(panel2.Location.X + (panel2.Width - qRCodePrintForm.Width)/2, 0);
                qRCodePrintForm.Width = panel2.Width;
                qRCodePrintForm.TopLevel = false;
                panel2.Controls.Add(qRCodePrintForm);
                qRCodePrintForm.Show();

                //Graphics g = gbStep.CreateGraphics();
               
            }
            if(pageNum == 4)
            {
                if (IsdemarcateFinsih)
                {
                    toolStripButton2_Click(null, null);
                    return;
                }
                try
                {
                    DemarcateHistory demarcateHistory = new DemarcateHistory
                    {
                        DemarcateNum = qRCodePrintForm.demarcateRecords.DemarcateNum,
                        SerialNum = qRCodePrintForm.demarcateRecords.SerialNum,
                        Cycle = demarcateTools.Cycle,
                        LastTime = demarcateTools.LastTime,
                        DemarcateTime = DateTime.Now.ToString("yyyy-MM-dd"),
                        NextTime = DateTime.Now.AddDays(demarcateTools.Cycle).ToString("yyyy-MM-dd"),
                        CheckMan = qRCodePrintForm.demarcateRecords.Examinant
                    };
                    int affected = demarcateRecordManage.AddDemarcateHistory(demarcateHistory);
                    if (affected < 1)
                    {
                        throw new Exception("系统出现错误，请重新校准!");
                    }
                    string sql = $"update DemarcateTools set LastTime='{demarcateHistory.DemarcateTime}',NextTime='{demarcateHistory.NextTime}' where SerialNum='{demarcateDataUploadForm.SerialNum}'";
                    affected = demarcateRecordManage.UpdateOneDemarcateToolBySql(sql);
                    if (affected < 1)
                    {
                        throw new Exception("系统出现错误，请重新校准!");
                    }
                    //更新维修次数
                    ToolsInfo toolsInfo = toolsInfoManage.QueryOneToolsInfo(qRCodePrintForm.demarcateRecords.SerialNum);
                    int repairTimes = toolsInfo.RepairTimes++;
                    sql = $"update ToolsInfo set RepairTimes={repairTimes} where SerialNum='{toolsInfo.SerialNum}'";
                    affected = toolsInfoManage.UpdateToolsInfoBySql(sql);
                    if (affected < 1)
                    {
                        throw new Exception("系统出现错误，请重新校准!");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                toolStripButton2_Click(null, null);
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            DemarcateTools demarcateTools = demarcateRecordManage.getOneDemarcateToolBySerialNum(txtSerialNum.Text.Trim());
            try
            {
                DemarcateHistory demarcateHistory = new DemarcateHistory
                {
                    DemarcateNum = qRCodePrintForm.demarcateRecords.DemarcateNum,
                    SerialNum = qRCodePrintForm.demarcateRecords.SerialNum,
                    Cycle = demarcateTools.Cycle,
                    LastTime = demarcateTools.LastTime,
                    DemarcateTime = DateTime.Now.ToString("yyyy-MM-dd"),
                    NextTime = DateTime.Now.AddDays(demarcateTools.Cycle).ToString("yyyy-MM-dd"),
                    CheckMan = qRCodePrintForm.demarcateRecords.Examinant
                };
                int affected = demarcateRecordManage.AddDemarcateHistory(demarcateHistory);
                if (affected < 1)
                {
                    throw new Exception("系统出现错误，请重新校准!");
                }
                string sql = $"update DemarcateTools set LastTime='{demarcateHistory.DemarcateTime}',NextTime='{demarcateHistory.NextTime}' where SerialNum='{demarcateDataUploadForm.SerialNum}'";
                affected = demarcateRecordManage.UpdateOneDemarcateToolBySql(sql);
                if (affected < 1)
                {
                    throw new Exception("系统出现错误，请重新校准!");
                }
                //更新维修次数
                ToolsInfo toolsInfo = toolsInfoManage.QueryOneToolsInfo(qRCodePrintForm.demarcateRecords.SerialNum);
                int repairTimes = toolsInfo.RepairTimes++;
                sql = $"update ToolsInfo set RepairTimes={repairTimes} where SerialNum='{toolsInfo.SerialNum}'";
                affected = toolsInfoManage.UpdateToolsInfoBySql(sql);
                if (affected < 1)
                {
                    throw new Exception("系统出现错误，请重新校准!");
                }
                MessageBox.Show($"工具{txtSerialNum.Text.Trim()}校准完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IsdemarcateFinsih = true;
        }

        private void btnLastStep_Click(object sender, EventArgs e)
        {
            pageNum--;
            if(pageNum == 1)
            {
                btnNextStep.Text = "下一步";
                btnLastStep.Enabled = false;
                btnLastStep.Visible = false;
                btnNextStep.Enabled = true;
                foreach (Control c in panel2.Controls)
                {
                    if(c is Form)
                    {
                        c.Visible = false;
                    }
                    else
                    {
                        c.Visible = true;
                    }
                }
            }
            if (pageNum == 2)
            {
                btnNextStep.Text = "下一步";
                btnLastStep.Enabled = true;
                btnLastStep.Visible = true;
                btnNextStep.Enabled = true;
                foreach (Control c in panel2.Controls)
                {
                    if (c is Form && c.Name == "DemarcateDataUploadForm")
                    {
                        c.Visible = true;
                    }
                    else
                    {
                        c.Visible = false;
                    }
                }
            }
        }
        private void paint_stepLine()
        {            
            Pen pen = new Pen(Color.Black, 1);
            //g.DrawEllipse(pen, 10, 10, 100, 100);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            pen.DashPattern = new float[] { 5, 5 };
            g.DrawLine(pen, 5, gbStep.Height / 2, gbStep.Width - 5, gbStep.Height / 2);
            g.DrawEllipse(new Pen(Color.Green,2), 50, gbStep.Height / 2 - 5, 10, 10);
            g.FillEllipse(new SolidBrush(Color.Green), 50, gbStep.Height / 2 - 5, 10, 10);
            g.DrawString("扫码输入", label7.Font, new SolidBrush(Color.Black), 32, gbStep.Height / 2 + 12);

            g.DrawEllipse(new Pen(Color.Yellow, 2), 385, gbStep.Height / 2 - 5, 10, 10);
            g.FillEllipse(new SolidBrush(Color.Yellow), 385, gbStep.Height / 2 - 5, 10, 10);
            g.DrawString("校准仪器校准", label7.Font, new SolidBrush(Color.Black), 352, gbStep.Height / 2 + 12);

            g.DrawEllipse(new Pen(Color.Yellow, 2), 720, gbStep.Height / 2 - 5, 10, 10);
            g.FillEllipse(new SolidBrush(Color.Yellow), 720, gbStep.Height / 2 - 5, 10, 10);
            g.DrawString("打印标签", label7.Font, new SolidBrush(Color.Black), 700, gbStep.Height / 2 + 12);

            //g.DrawEllipse(new Pen(Color.Yellow, 2), 650, gbStep.Height / 2 - 5, 10, 10);
            //g.FillEllipse(new SolidBrush(Color.Yellow), 650, gbStep.Height / 2 - 5, 10, 10);
        }

        private void DemarcateOperatorForm_Paint(object sender, PaintEventArgs e)
        {
            if(pageNum == 1)
            {
                paint_stepLine();
            }
            else if(pageNum == 2)
            {
                g.DrawEllipse(new Pen(Color.Gray, 2), 50, gbStep.Height / 2 - 5, 10, 10);
                g.FillEllipse(new SolidBrush(Color.Gray), 50, gbStep.Height / 2 - 5, 10, 10);

                g.DrawEllipse(new Pen(Color.Green, 2), 385, gbStep.Height / 2 - 5, 10, 10);
                g.FillEllipse(new SolidBrush(Color.Green), 385, gbStep.Height / 2 - 5, 10, 10);

                g.DrawEllipse(new Pen(Color.Yellow, 2), 720, gbStep.Height / 2 - 5, 10, 10);
                g.FillEllipse(new SolidBrush(Color.Yellow), 720, gbStep.Height / 2 - 5, 10, 10);
            }
            else if(pageNum == 3)
            {
                g.DrawEllipse(new Pen(Color.Gray, 2), 50, gbStep.Height / 2 - 5, 10, 10);
                g.FillEllipse(new SolidBrush(Color.Gray), 50, gbStep.Height / 2 - 5, 10, 10);

                g.DrawEllipse(new Pen(Color.Gray, 2), 385, gbStep.Height / 2 - 5, 10, 10);
                g.FillEllipse(new SolidBrush(Color.Gray), 385, gbStep.Height / 2 - 5, 10, 10);

                g.DrawEllipse(new Pen(Color.Green, 2), 720, gbStep.Height / 2 - 5, 10, 10);
                g.FillEllipse(new SolidBrush(Color.Green), 720, gbStep.Height / 2 - 5, 10, 10);
            }
            else
            {
                g.DrawEllipse(new Pen(Color.Gray, 2), 50, gbStep.Height / 2 - 5, 10, 10);
                g.FillEllipse(new SolidBrush(Color.Gray), 50, gbStep.Height / 2 - 5, 10, 10);

                g.DrawEllipse(new Pen(Color.Gray, 2), 385, gbStep.Height / 2 - 5, 10, 10);
                g.FillEllipse(new SolidBrush(Color.Gray), 385, gbStep.Height / 2 - 5, 10, 10);

                g.DrawEllipse(new Pen(Color.Green, 2), 720, gbStep.Height / 2 - 5, 10, 10);
                g.FillEllipse(new SolidBrush(Color.Gray), 720, gbStep.Height / 2 - 5, 10, 10);
            }
            
            //Thread t1 = new Thread(new ThreadStart(paint_stepLine));
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            btnNextStep.Text = "下一步";
            txtSerialNum.Text = "";
            demarcateDataUploadForm.CloseSerialPort();           
            qRCodePrintForm.Close();
            pageNum = 1;
            toolStripButton1.Enabled = true;
            foreach(Control c in panel2.Controls)
            {
                c.Visible = true;
            }
            demarcateDataUploadForm.Visible = false;
            //demarcateDataUploadForm.setOperatorFormBtnDelegate -= new setFormBtnDelegate(setFormComBtn);
            //demarcateDataUploadForm = new DemarcateDataUploadForm();

            qRCodePrintForm = new QRCodePrintForm();
            //demarcateDataUploadForm.setOperatorFormBtnDelegate += new setFormBtnDelegate(setFormComBtn);
        }

        private void DemarcateOperatorForm_Load(object sender, EventArgs e)
        {
            txtSerialNum.Text = serialNum;
        }

        private void cmbCheckMan_DropDown(object sender, EventArgs e)
        {
            cmbCheckMan.Items.Clear();
            List<CheckMan> checkMen = checkManManage.GetAllName();
            if (checkMen == null) return;
            foreach(CheckMan c in checkMen)
            {
                cmbCheckMan.Items.Add(c.Name);
            }
        }
    }
}
