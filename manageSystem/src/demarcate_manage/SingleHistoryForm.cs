using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using BLL;

namespace manageSystem.src.demarcate_manage
{
    public partial class SingleHistoryForm : Form
    {
        private DemarcateRecordManage demarcateRecordManage = new DemarcateRecordManage();
        private List<DbShow> dbShowList = new List<DbShow>();
        private ToolsInfoManage toolsInfoManage = new ToolsInfoManage();
        public string serialNum;
        public SingleHistoryForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        private void SingleHistoryForm_Load(object sender, EventArgs e)
        {
            List<DemarcateHistory> demacateHistoryList = demarcateRecordManage.GetDemarcateHistoriesBySerial(serialNum);
            if(demacateHistoryList == null)
            {
                MessageBox.Show("该工具尚未进行过任何标定，无记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
                Close();
                return;
            }
            if (demacateHistoryList != null)
            {
                int i = 0;
                foreach (DemarcateHistory demarcate in demacateHistoryList)
                {
                    i++;
                    dbShowList.Add(new DbShow
                    {
                        ID = i,
                        DemarcateNum = demarcate.DemarcateNum,
                        SerialNum = demarcate.SerialNum,
                        Cycle = demarcate.Cycle,
                        LastTime = demarcate.LastTime,
                        DemarcateTime = demarcate.DemarcateTime,
                        NextTime = demarcate.NextTime,
                        CheckMan = demarcate.CheckMan,
                        Model = demarcate.Model,
                        Category = demarcate.Category,
                        Name = demarcate.Name,
                        TorqueMin = demarcate.TorqueMin,
                        TorqueMax = demarcate.TorqueMax,
                        Accuracy = demarcate.Accuracy,
                        Section = demarcate.Section,
                        Workstation = demarcate.Workstation,
                        Status = demarcate.Status,
                        QualityAssureDate = demarcate.QualityAssureDate,
                        MaintainContractStyle = demarcate.MaintainContractStyle,
                        MaintainContractDate = demarcate.MaintainContractDate,
                        RepairTimes = demarcate.RepairTimes,
                        Remark = demarcate.Remark
                    });
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dbShowList;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1)
            {
                DataGridViewButtonCell btnCell = dataGridView1.CurrentCell as DataGridViewButtonCell;
                if (btnCell != null)
                {
                    QRCodePrintForm qRCodePrintForm = new QRCodePrintForm();
                    qRCodePrintForm.demarcateRecords = GetDemarcateHistoryFromGrid();
                    qRCodePrintForm.ShowDialog();
                }
            }
        }

        private DemarcateRecords GetDemarcateHistoryFromGrid()
        {
            if (dataGridView1.SelectedRows.Count == 0) return null;
            return new DemarcateRecords
            {
                DemarcateNum = dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),
                SerialNum = dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),
                WorkStation = toolsInfoManage.QueryOneToolsInfo(serialNum).Workstation,
                Validity = dataGridView1.SelectedRows[0].Cells[6].Value.ToString(),
                Examinant = dataGridView1.SelectedRows[0].Cells[7].Value.ToString()
            };
        }
    }

    public struct DbShow
    {
        public int ID { get; set; }
        public string DemarcateNum { get; set; }            //标定序列号，primary key
        public string SerialNum { get; set; }               //工具的序列号
        public int Cycle { get; set; }                      //周期
        public string LastTime { get; set; }                //上次标定时间
        public string DemarcateTime { get; set; }           //标定时间      
        public string NextTime { get; set; }                //有效期
        public string CheckMan { get; set; }                //检查员
        public string Model { get; set; }                            //型号
        public string Category { get; set; }                         //类别
        public string Name { get; set; }                             //名称
        public double TorqueMin { get; set; }                           //扭矩下限
        public double TorqueMax { get; set; }                           //扭矩上限
        public double Accuracy { get; set; }                            //精度
        public string Section { get; set; }                          //工段
        public string Workstation { get; set; }                      //工位
        public string Status { get; set; }                           //工具状态
        public string QualityAssureDate { get; set; }                //质保期至
        public string MaintainContractStyle { get; set; }            //保养合同类型
        public string MaintainContractDate { get; set; }             //保养合同至
        public int RepairTimes { get; set; }                         //累计维修次数
        public string Remark { get; set; }                           //备注信息
    }
}
