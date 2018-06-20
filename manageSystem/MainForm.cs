using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using manageSystem.src.tool_KPI_manage;
using manageSystem.src.maintain_manage;
using manageSystem.src;
using System.Data.SQLite;
using manageSystem.src.on_call_record;
using manageSystem.src.demarcate_manage;
using BLL;
using Model;

namespace manageSystem
{
    public partial class MainForm : Form
    {
        private EmailManage emailManage = new EmailManage();
        private ToolsInfoManage toolsInfoManage = new ToolsInfoManage();
        public MainForm()
        {
            InitializeComponent();
        }

        static void Log(string s)
        {
            Console.WriteLine("" + s);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InfoInputForm iif = new InfoInputForm();
            if (iif.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //QueryInfoForm qif = new QueryInfoForm();
            //if (qif.ShowDialog() == DialogResult.OK)
            //{
            //    this.Show();
            //}
            OnCallForm onCallFrom = new OnCallForm();
            if (onCallFrom.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SpareManageForm smf = new SpareManageForm();
            if (smf.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ToolKPIManageForm tkmf = new ToolKPIManageForm();
            if (tkmf.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RepairAndMaintainForm rmf = new RepairAndMaintainForm();
            if (rmf.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void RecieveManBtn_Click(object sender, EventArgs e)
        {
            EmailAddressManageForm eamf = new EmailAddressManageForm();
            if (eamf.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            } 
        }

        private void sendMailbtn_Click(object sender, EventArgs e)
        {
            emailManage.SendEmail();
        }

        private void 工具数据导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolDataExportForm tdef = new ToolDataExportForm();
            if (tdef.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
    }
}
