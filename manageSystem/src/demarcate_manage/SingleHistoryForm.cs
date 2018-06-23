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
                        CheckMan = demarcate.CheckMan
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
    }
}
