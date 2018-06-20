using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DAL;
using Model;
using System.Configuration;
using BLL;

namespace manageSystem.src.maintain_manage
{
    public partial class RepairOperatorForm : Form
    {
        private static string _suspendStatus = "挂起";
        private static string _finishStatus = "已完成";
        private string status;
        private MaintainInfoManage maintainInfoManage = new MaintainInfoManage();
        private CommonManage commonManage = new CommonManage();
        public RepairOperatorForm()
        {
            InitializeComponent();
            status = RepairManageForm.Status;
            setComboBoxItems();
        }
        private void RepairOperatorForm_Load(object sender, EventArgs e)
        {
            cboSerialNum.Text = RepairManageForm.ToolSerialName;
            txtRepoSpare.Enabled = false;
            txtOtherSpare.Enabled = false;
            setAllInputWhenSuspendBefore();
        }
        private void setComboBoxItems()
        {
            List<string> list = maintainInfoManage.GetSerialNameHintFromDb();
            if (list == null) return;
            cboSerialNum.Items.AddRange(list.ToArray());
        }

        private void updateAllData(string time, string nextStatus, string state)
        {
            MaintainManageInfo maintainManageInfo = getAllInput();
            if (maintainManageInfo == null) return;
            if (nextStatus == _finishStatus) maintainManageInfo.FinishFixTime = time;
            if (nextStatus == _suspendStatus) maintainManageInfo.SuspendTime = time;
            maintainManageInfo.Status = nextStatus;
            maintainManageInfo.State = state;
            string msg = maintainInfoManage.UpdateBreakToolInfo(maintainManageInfo);
            if (msg == "挂起" || msg == "未使用任何零件")
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }
            MessageBox.Show(msg, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private MaintainManageInfo getAllInput()
        {
            if (!checkInput()) return null;
            MaintainManageInfo maintainManageInfo = new MaintainManageInfo();
            maintainManageInfo.ToolSerialName = cboSerialNum.Text;
            maintainManageInfo.UsedRepoSpareToolInfo = commonManage.ConvertStr2Dic(txtRepoSpare.Text);
            maintainManageInfo.UsedOtherSpareToolInfo = commonManage.ConvertStr2Dic(txtOtherSpare.Text);
            return maintainManageInfo;
        }

        private bool checkInput()
        {
            if (cboSerialNum.Text == "")
            {
                MessageBox.Show("工具序列号不允许为空！");
                return false;
            }
            if (cboSerialNum.Items.IndexOf(cboSerialNum.Text) < 0)
            {
                MessageBox.Show("工具尚未登记，请先登记再进行维修");
                return false;
            }
            return true;
        }

        private void setAllInputWhenSuspendBefore()
        {
            if (string.Compare(status, _suspendStatus) == 0)
            {
                MaintainManageInfo maintainManageInfo = maintainInfoManage.GetOneBreakToolFromDb(RepairManageForm.ToolSerialName);
                if (maintainManageInfo == null)
                {
                    Console.WriteLine("maintainManageInfo is nil");
                    return;
                }
                txtRepoSpare.Text = commonManage.ConvertDic2Str(maintainManageInfo.UsedRepoSpareToolInfo);
                txtOtherSpare.Text = commonManage.ConvertDic2Str(maintainManageInfo.UsedOtherSpareToolInfo);
            }
        }
        private void btnRepoAdd_Click(object sender, EventArgs e)
        {
            AddSpareToolForm addSpareToolForm = new AddSpareToolForm();
            addSpareToolForm.setFormTextValue += new setTextValue(textBox1_setFormTextValue);
            addSpareToolForm.ShowDialog();
        }

        void textBox1_setFormTextValue(string value, int num)
        {
            if (txtRepoSpare.Text == "")
            {
                txtRepoSpare.Text += value + ":" + num.ToString();
                return;
            }
            txtRepoSpare.Text += ", " + value + ":" + num.ToString();
        }

        private void btnRepoRemove_Click(object sender, EventArgs e)
        {
            if (txtRepoSpare.Text == "") return;
            string[] kvList = txtRepoSpare.Text.Split(',');
            List<string> list = kvList.ToList<string>();
            list.RemoveAt(list.Count - 1);
            txtRepoSpare.Text = string.Join(",", list.ToArray());
        }

        private void btnOtherAdd_Click(object sender, EventArgs e)
        {
            AddSpareToolForm addSpareToolForm = new AddSpareToolForm();
            addSpareToolForm.setFormTextValue += new setTextValue(textBox2_setFormTextValue);
            addSpareToolForm.ShowDialog();
        }

        private void btnOtherRemove_Click(object sender, EventArgs e)
        {
            if (txtOtherSpare.Text == "") return;
            string[] kvList = txtOtherSpare.Text.Split(',');
            List<string> list = kvList.ToList<string>();
            list.RemoveAt(list.Count - 1);
            txtOtherSpare.Text = string.Join(",", list.ToArray());
        }

        void textBox2_setFormTextValue(string value, int num)
        {
            if (txtOtherSpare.Text == "")
            {
                txtOtherSpare.Text += value + ":" + num.ToString();
                return;
            }
            txtOtherSpare.Text += ", " + value + ":" + num.ToString();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (txtRepoSpare.Text == "" && txtOtherSpare.Text == "")
            {
                MessageBox.Show("未使用任何零件，无法完成维修！");
                return;
            }
            string finishTime = DateTime.Now.ToString("yyyy-MM-dd");
            string finishStatus = _finishStatus;
            try
            {
                updateAllData(finishTime, finishStatus, "1");
            }
            catch
            {
                return;
            }
        }

        private void btnSuspend_Click(object sender, EventArgs e)
        {
            string suspendTime = DateTime.Now.ToString("yyyy-MM-dd");
            string suspendStatus = _suspendStatus;
            try
            {
                updateAllData(suspendTime, suspendStatus, "0");
            }
            catch
            {
                return;
            }
        }
    }
}
