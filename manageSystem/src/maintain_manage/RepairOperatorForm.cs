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
            Error error = spareToolConsume.CheckSpareToolName(maintainManageInfo);
            if(error != null)
            {
                MessageBox.Show(error.msg);
                return;
            }
            error = spareToolConsume.UpdateMaintainManageInfo(maintainManageInfo);
            if (error == null)
            {
                error = spareToolConsume.UpdateRepoSpareToolDb(maintainManageInfo);
                if (error == null)
                {
                    DialogResult = DialogResult.OK;
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
            if(textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("未使用任何零件，无法完成维修！");
                return;
            }
            maintainManageInfo.SuspendTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            maintainManageInfo.Status = Declare.RepairFinished;
            Error error = spareToolConsume.CheckSpareToolName(maintainManageInfo);
            if (error != null)
            {
                MessageBox.Show(error.msg);
                return;
            }
            error = spareToolConsume.UpdateMaintainManageInfo(maintainManageInfo);
            if (error == null)
            {
                error = spareToolConsume.UpdateRepoSpareToolDb(maintainManageInfo);
                if (error == null)
                {
                    DialogResult = DialogResult.OK;
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
