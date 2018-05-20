using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DAL;
using Model;
using System.Configuration;

namespace manageSystem.src.maintain_manage
{
    public partial class RepairOperatorForm : Form
    {
        private static string _suspendStatus = "挂起";
        private static string _finishStatus = "已完成";
        private string status;
        public RepairOperatorForm()
        {
            InitializeComponent();
            status = RepairManageForm.Status;
        }

        private string[] getHintFromDb()
        {
            string[] records = new string[] { };
            List<MaintainManageInfo> list = new List<MaintainManageInfo>();
            try
            {
                list = new MaintainManageInfoService().getAllBreakTools();
                if(list == null)
                {
                    Console.Write("no such record");
                    return null;
                }
                List<string> recordList = records.ToList();
                foreach(MaintainManageInfo item in list)
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
            string[] str = getHintFromDb();
            if (str == null)
            {
                return;
            }
            Console.WriteLine(str);
            comboBox1.Items.AddRange(str);
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
            updateAllData(finishTime, finishStatus);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string suspendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string suspendStatus = _suspendStatus;
            updateAllData(suspendTime, suspendStatus);
        }

        private void updateAllData(string time,string nextStatus)
        {
            MaintainManageInfo maintainManageInfo = getAllInput();
            if (maintainManageInfo == null) return;
            maintainManageInfo.SuspendTime = time;
            maintainManageInfo.Status = nextStatus;
            if (!new MaintainManageInfoService().IsNotFinishBreakToolExist(maintainManageInfo))
            {
                return;
            }
            foreach (var item in maintainManageInfo.UsedRepoSpareToolInfo)
            {
                RepoSpareTool repoSpareTool = new RepoSpareToolService().getOneRepoSpareToolFromDb(item.Key);
                if (repoSpareTool == null)
                {
                    MessageBox.Show("数据库中不包含型号为：" + item.Key + "的备件信息");
                    return;
                }
                if (repoSpareTool.Num < item.Value)
                {
                    MessageBox.Show("数据库中型号为：" + item.Key + "的备件个数不足" + item.Value.ToString() + "个");
                    return;
                }
            }
            try
            {
                new MaintainManageInfoService().UpdateMaintainManageInfo(maintainManageInfo);
                if(nextStatus != _suspendStatus)
                {
                    foreach (var item in maintainManageInfo.UsedRepoSpareToolInfo)
                    {
                        RepoSpareTool repoSpareTool = new RepoSpareToolService().getOneRepoSpareToolFromDb(item.Key);
                        int num = repoSpareTool.Num - item.Value;
                        int affectedRow = new RepoSpareToolService().updateRepoSpareToolNum(num, item.Key);
                        if (affectedRow < 1)
                        {
                            MessageBox.Show("更新数据库失败！");
                            return;
                        }
                    }
                } 
                DialogResult = DialogResult.OK;
                Close();
            }
            catch
            {
                return;
            }
        }

        private MaintainManageInfo getAllInput()
        {
            if (!checkInput()) return null;
            MaintainManageInfo maintainManageInfo = new MaintainManageInfo();
            maintainManageInfo.ToolSerialName = comboBox1.Text;
            maintainManageInfo.UsedRepoSpareToolInfo = new MaintainManageInfoService().ConvertStr2Dic(textBox1.Text);
            maintainManageInfo.UsedOtherSpareToolInfo = new MaintainManageInfoService().ConvertStr2Dic(textBox2.Text);
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
                MaintainManageInfo maintainManageInfo = new MaintainManageInfoService().getOneBreakToolFromDb(RepairManageForm.ToolSerialName);
                if (maintainManageInfo == null)
                {
                    Console.WriteLine("maintainManageInfo is nil");
                    return;
                }
                textBox1.Text = new MaintainManageInfoService().ConvertDic2Str(maintainManageInfo.UsedRepoSpareToolInfo);
                textBox2.Text = new MaintainManageInfoService().ConvertDic2Str(maintainManageInfo.UsedOtherSpareToolInfo);
            }
        }

        private void RepairOperatorForm_Load(object sender, EventArgs e)
        {
            InitTextBoxHint();
            comboBox1.Text = RepairManageForm.ToolSerialName;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            setAllInputWhenSuspendBefore();
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
    }
}
