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
            comboBox1.Text = RepairManageForm.ToolSerialName;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            setAllInputWhenSuspendBefore();
        }
        private void setComboBoxItems()
        {
            List<string> list = maintainInfoManage.GetSerialNameHintFromDb();
            if (list == null) return;
            comboBox1.Items.AddRange(list.ToArray());
        }

        private void updateAllData(string time, string nextStatus,string state)
        {
            MaintainManageInfo maintainManageInfo = getAllInput();
            if (maintainManageInfo == null) return;
            maintainManageInfo.SuspendTime = time;
            maintainManageInfo.Status = nextStatus;
            maintainManageInfo.State = state;
            string msg = maintainInfoManage.UpdateBreakToolInfo(maintainManageInfo);
            if(msg == "挂起" || msg == "未使用任何零件")
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }
            MessageBox.Show(msg);
        }

        private MaintainManageInfo getAllInput()
        {
            if (!checkInput()) return null;
            MaintainManageInfo maintainManageInfo = new MaintainManageInfo();
            maintainManageInfo.ToolSerialName = comboBox1.Text;
            maintainManageInfo.UsedRepoSpareToolInfo = commonManage.ConvertStr2Dic(textBox1.Text);
            maintainManageInfo.UsedOtherSpareToolInfo = commonManage.ConvertStr2Dic(textBox2.Text);
            return maintainManageInfo;
        }

        private bool checkInput()
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("工具序列号不允许为空！");
                return false;
            }
            if (comboBox1.Items.IndexOf(comboBox1.Text) < 0)
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
                textBox1.Text = commonManage.ConvertDic2Str(maintainManageInfo.UsedRepoSpareToolInfo);
                textBox2.Text = commonManage.ConvertDic2Str(maintainManageInfo.UsedOtherSpareToolInfo);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddSpareToolForm addSpareToolForm = new AddSpareToolForm();
            addSpareToolForm.setFormTextValue += new setTextValue(textBox1_setFormTextValue);
            addSpareToolForm.ShowDialog();
        }

        void textBox1_setFormTextValue(string value,int num)
        {
            if(textBox1.Text == "")
            {
                textBox1.Text += value + ":" + num.ToString();
                return;
            }
            textBox1.Text += ", "+ value + ":" + num.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;
            string[] kvList = textBox1.Text.Split(',');
            List<string> list = kvList.ToList<string>();
            list.RemoveAt(list.Count - 1);
            textBox1.Text = string.Join(",", list.ToArray());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddSpareToolForm addSpareToolForm = new AddSpareToolForm();
            addSpareToolForm.setFormTextValue += new setTextValue(textBox2_setFormTextValue);
            addSpareToolForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "") return;
            string[] kvList = textBox2.Text.Split(',');
            List<string> list = kvList.ToList<string>();
            list.RemoveAt(list.Count - 1);
            textBox2.Text = string.Join(",", list.ToArray());
        }

        void textBox2_setFormTextValue(string value, int num)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text += value + ":" + num.ToString();
                return;
            }
            textBox2.Text += ", " + value + ":" + num.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("未使用任何零件，无法完成维修！");
                return;
            }
            string finishTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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

        private void button6_Click(object sender, EventArgs e)
        {
            string suspendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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
