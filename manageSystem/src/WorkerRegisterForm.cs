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

namespace manageSystem.src
{
    public partial class WorkerRegisterForm : Form
    {
        private CheckManManage checkManManage = new CheckManManage();
        public WorkerRegisterForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtWorkerName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请先输入要登记人员的姓名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (checkManManage.IsNameExist(txtWorkerName.Text.Trim()))
            {
                MessageBox.Show("该驻场人员已经登记！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int affected = checkManManage.AddOneName(txtWorkerName.Text.Trim());
            if(affected < 1)
            {
                Console.WriteLine("添加出错");
                return;
            }
            Close();
        }
    }
}
