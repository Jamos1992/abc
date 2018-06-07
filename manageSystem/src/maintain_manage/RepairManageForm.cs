﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using BLL;
using Model;
using Util;

namespace manageSystem.src.maintain_manage
{
    public partial class RepairManageForm : Form
    {
        private MaintainInfoManage maintainInfoManage = new MaintainInfoManage();
        public static string ToolSerialName;
        public static string Status;
        public RepairManageForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            saveFileDialog1.Filter = "Excel文件(*.xls, *.xlsx)|*.xls;*.xlsx";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoGenerateColumns = false;
        }

        private MaintainManageInfo[] GetMaintainManageInfoFromGrid()
        {
            MaintainManageInfo[] maintainManageInfo = new MaintainManageInfo[] { };
            List<MaintainManageInfo> ktls = maintainManageInfo.ToList();
            //遍历 DataGridView 所有行
            int row = dataGridView1.Rows.Count;//得到总行数    
            int cell = dataGridView1.Rows[0].Cells.Count;//得到总列数
            for (int i = 0; i < row; i++)//得到总行数并在之内循环    
            {
                ktls.Add(new MaintainManageInfo
                {
                    ToolModeName = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                    ToolSerialName = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                    SendFixTime = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                    Status = dataGridView1.Rows[i].Cells[4].Value.ToString(),
                    Detail = dataGridView1.Rows[i].Cells[5].Value.ToString(),
                });
            }
            return ktls.ToArray();
        }
        private void BindData2Grid(List<OutputStruct> list)
        {
            dataGridView1.DataSource = list;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.ClearSelection();
            //if (dataGridView1.Rows.Count > 0) dataGridView1.Rows[0].Selected = false;
        }

        private void RepairManageForm_Load(object sender, EventArgs e)
        {
            List<OutputStruct> list = maintainInfoManage.GetAllBreakToolsBySql("select ToolSerialName,ToolModeName,SendFixTime,Status,Detail from MaintainManageInfo order by SendFixTime desc");
            if (list == null) return;
            BindData2Grid(list);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<OutputStruct> list = new List<OutputStruct>();           
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                list = maintainInfoManage.GetAllBreakToolsBySql("select ToolSerialName,ToolModeName,SendFixTime,Status,Detail from MaintainManageInfo order by SendFixTime desc");
            }
            else
            {
                string sql = "select ToolSerialName,ToolModeName,SendFixTime,Status,Detail from MaintainManageInfo where";
                if (radioButton1.Checked) sql += " Status='" + MaintainDeclare.Repairing + "'";
                if (radioButton2.Checked) sql += " Status='" + MaintainDeclare.Suspend + "'";
                if (radioButton3.Checked) sql += " Status='" + MaintainDeclare.RepairFinished + "'";
                sql += " order by SendFixTime desc";
                list = maintainInfoManage.GetAllBreakToolsBySql(sql);
            }
            if (list == null)
            {
                dataGridView1.DataSource = new List<OutputStruct>();
                MessageBox.Show("记录不存在！");
                return;
            }
            BindData2Grid(list);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("没有记录可以导出,请先查询！");
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string msg = maintainInfoManage.ExportBatchData2Excel(saveFileDialog1.FileName, GetMaintainManageInfoFromGrid());
                MessageBox.Show(msg);
            }
        }

        private void gotoRepair_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolSerialName = getSerialNumFromGrid();
            Status = getStatusFromGrid();
            RepairOperatorForm repairOperatorForm = new RepairOperatorForm();
            if (repairOperatorForm.ShowDialog() == DialogResult.OK)
            {
                button1_Click(sender, e);
                Show();
            }
        }
        private string getSerialNumFromGrid()
        {
            if (dataGridView1.SelectedRows.Count == 0) return null;
            return dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private string getStatusFromGrid()
        {
            if (dataGridView1.SelectedRows.Count == 0) return null;
            return dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (getStatusFromGrid() == MaintainDeclare.RepairFinished)
            {
                contextMenuStrip1.Enabled = false;
            }
            else
            {
                contextMenuStrip1.Enabled = true;
            }
        }
    }
}
