using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace manageSystem.src.maintain_manage
{
    public partial class RepairOperatorForm : Form
    {
        private SpareToolConsume spareToolConsume = new SpareToolConsume();
        private string status;
        public RepairOperatorForm()
        {
            InitializeComponent();
            status = RepairManageForm.Status;
        }

        private string[] getHintFromDb()
        {
            string[] records = new string[] { };
            SqLiteHelper db = new SqLiteHelper(Declare.DbConnectionString);
            try
            {
                SQLiteDataReader reader = db.ReadTable("MaintainManageInfo", new string[] { "ToolSerialName" }, new string[] { "ToolSerialName" }, new string[] { "like" }, new string[] { "'%%'" });
                if (!reader.HasRows)
                {
                    Console.Write("no such record");
                    return null;
                }
                List<string> recordList = records.ToList();
                while (reader.Read())
                {
                    recordList.Add(reader.GetString(reader.GetOrdinal("ToolSerialName")));

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

        private void button6_Click(object sender, EventArgs e)
        {
            MaintainManageInfo maintainManageInfo = getAllInput();
            if (maintainManageInfo == null) return;
            maintainManageInfo.SuspendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            maintainManageInfo.Status = Declare.Suspend;
            Error error = spareToolConsume.UpdateMaintainManageInfo(maintainManageInfo);
            if (error == null)
            {
                error = spareToolConsume.UpdateRepoSpareToolDb(maintainManageInfo);
                if (error == null)
                {
                    Close();
                }
                else
                {
                    MessageBox.Show(error.msg);
                }
            }
            else
            {
                MessageBox.Show(error.msg);
            }
        }

        private MaintainManageInfo getAllInput()
        {
            if (!checkInput()) return null;
            MaintainManageInfo maintainManageInfo = new MaintainManageInfo();
            maintainManageInfo.ToolSerialName = comboBox1.Text;
            maintainManageInfo.UsedRepoSpareToolInfo = spareToolConsume.ConvertStr2Dic(textBox1.Text);
            maintainManageInfo.UsedOtherSpareToolInfo = spareToolConsume.ConvertStr2Dic(textBox2.Text);
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

        private void button5_Click(object sender, EventArgs e)
        {
            MaintainManageInfo maintainManageInfo = getAllInput();
            if (maintainManageInfo == null) return;
            maintainManageInfo.SuspendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            maintainManageInfo.Status = Declare.RepairFinished;
            Error error = spareToolConsume.UpdateMaintainManageInfo(maintainManageInfo);
            if (error == null)
            {
                error = spareToolConsume.UpdateRepoSpareToolDb(maintainManageInfo);
                if (error == null)
                {
                    Close();
                }
                else
                {
                    MessageBox.Show(error.msg);
                }
            }
            else
            {
                MessageBox.Show(error.msg);
            }
        }

        private void setAllInputWhenSuspendBefore()
        {
            if (string.Compare(status,Declare.Suspend) == 0)
            {
                MaintainManageInfo maintainManageInfo = spareToolConsume.GetSuspendInfoFromDb(RepairManageForm.ToolSerialName);
                if (maintainManageInfo == null)
                {
                    Console.WriteLine("maintainManageInfo is nil");
                    return;
                }
                textBox1.Text = spareToolConsume.ConvertDic2Str(maintainManageInfo.UsedRepoSpareToolInfo);
                textBox2.Text = spareToolConsume.ConvertDic2Str(maintainManageInfo.UsedOtherSpareToolInfo);
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
    }
}
