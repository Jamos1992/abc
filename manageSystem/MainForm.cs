using BLL;
using manageSystem.src;
using manageSystem.src.demarcate_manage;
using manageSystem.src.maintain_manage;
using manageSystem.src.on_call_record;
using manageSystem.src.tool_KPI_manage;
using System;
using System.Windows.Forms;
using Model;
using System.Collections.Generic;

namespace manageSystem
{
    public partial class MainForm : Form
    {
        private EmailManage emailManage = new EmailManage();
        private ToolsInfoManage toolsInfoManage = new ToolsInfoManage();
        private RepoSpareToolManage repoSpareToolManage = new RepoSpareToolManage();
        private OnCallRecordManage onCallRecordManage = new OnCallRecordManage();
        private MaintainInfoManage maintainInfoManage = new MaintainInfoManage();
        private DemarcateRecordManage demarcateRecordManage = new DemarcateRecordManage();
        public MainForm()
        {
            InitializeComponent();
            //MinimizeBox = false;
            MaximizeBox = false;
            saveFileDialog1.Filter = "Excel文件(*.xls, *.xlsx)|*.xls;*.xlsx";
            importExcelFile.Filter = "Excel文件(*.xls, *.xlsx)|*.xls;*.xlsx";
            importExcelFile.FileName = "";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("确定要退出系统？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            FormClosing -= new FormClosingEventHandler(this.MainForm_FormClosing);
            Application.Exit();
        }

        private void btnToolsInfo_Click(object sender, EventArgs e)
        {
            InfoInputForm infoInputForm = new InfoInputForm();
            if (infoInputForm.ShowDialog() == DialogResult.OK)
            {
                Show();
            }
        }

        private void btnOnCall_Click(object sender, EventArgs e)
        {
            OnCallForm onCallFrom = new OnCallForm();
            if (onCallFrom.ShowDialog() == DialogResult.OK)
            {
                Show();
            }
        }

        private void btnSpareTool_Click(object sender, EventArgs e)
        {
            SpareManageForm spareManageForm = new SpareManageForm();
            if (spareManageForm.ShowDialog() == DialogResult.OK)
            {
                Show();
            }
        }

        private void btnKPI_Click(object sender, EventArgs e)
        {
            ToolKPIManageForm toolKPIManageForm = new ToolKPIManageForm();
            if (toolKPIManageForm.ShowDialog() == DialogResult.OK)
            {
                Show();
            }
        }

        private void btnMaintain_Click(object sender, EventArgs e)
        {
            RepairAndMaintainForm repairAndMaintainForm = new RepairAndMaintainForm();
            if (repairAndMaintainForm.ShowDialog() == DialogResult.OK)
            {
                Show();
            }
        }

        private void btnRecieveMan_Click(object sender, EventArgs e)
        {
            EmailAddressManageForm emailAddressManageForm = new EmailAddressManageForm();
            if (emailAddressManageForm.ShowDialog() == DialogResult.OK)
            {
                Show();
            } 
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            emailManage.SendEmail();
        }

        private void btnToolDataExport_Click(object sender, EventArgs e)
        {
            List<ToolsInfo> toolsInfoList = toolsInfoManage.GetAllToolsInfoFromDb();
            if(toolsInfoList == null)
            {
                MessageBox.Show("仓库中没有任何工具", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            saveFileDialog1.FileName = "工具信息导出" + DateTime.Now.Date.ToString("yyyy-MM-dd");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {                
                string msg = toolsInfoManage.ExportBatchData2Excel(saveFileDialog1.FileName, toolsInfoList.ToArray());
                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }

        private void btnDemarcate_Click(object sender, EventArgs e)
        {
            DemarcateManageForm demarcateManageForm = new DemarcateManageForm();
            if (demarcateManageForm.ShowDialog() == DialogResult.OK)
            {

                Show();
            }
        }

        private void toolsInfoImport_Click(object sender, EventArgs e)
        {
            if (importExcelFile.ShowDialog() == DialogResult.OK)
            {
                string msg = toolsInfoManage.ImportBatchTools2Db(importExcelFile.FileName);
                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSpareToolExport_Click(object sender, EventArgs e)
        {
            List<RepoSpareTool> repoSpareList = repoSpareToolManage.GetAllRepoSpareTools();
            if (repoSpareList == null)
            {
                MessageBox.Show("仓库中没有任何零件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            saveFileDialog1.FileName = "工具零件导出" + DateTime.Now.Date.ToString("yyyy-MM-dd");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {               
                string msg = repoSpareToolManage.ExportBatchData2Excel(saveFileDialog1.FileName, repoSpareList.ToArray());
                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnOnCallExport_Click(object sender, EventArgs e)
        {
            List<OnCallRecord> onCallRecordList = onCallRecordManage.GetAllOnCallRecords();
            if (onCallRecordList == null)
            {
                MessageBox.Show("系统不存在有效的On-Call记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            saveFileDialog1.FileName = "On-Call记录导出" + DateTime.Now.Date.ToString("yyyy-MM-dd");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {               
                string msg = onCallRecordManage.ExportBatchData2Excel(saveFileDialog1.FileName, onCallRecordList.ToArray());
                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMaintainExport_Click(object sender, EventArgs e)
        {
            List<OutputStruct> outputList = maintainInfoManage.GetAllBreakTools();
            if (outputList == null)
            {
                MessageBox.Show("系统不存在维修的零件记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            saveFileDialog1.FileName = "维修记录导出" + DateTime.Now.Date.ToString("yyyy-MM-dd");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {                
                string msg = maintainInfoManage.ExportBatchData2Excel(saveFileDialog1.FileName, outputList.ToArray());
                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDemarcateExport_Click(object sender, EventArgs e)
        {
            List<DemarcateHistory> demarcateHistoryList = demarcateRecordManage.GetAllDemarcateHistories();
            if (demarcateHistoryList == null)
            {
                MessageBox.Show("系统不存在工具标定记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            saveFileDialog1.FileName = "标定历史记录导出" + DateTime.Now.Date.ToString("yyyy-MM-dd");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {                
                string msg = demarcateRecordManage.ExportBatchData2Excel(saveFileDialog1.FileName, demarcateHistoryList.ToArray());
                MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
