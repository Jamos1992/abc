using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace manageSystem.src.maintain_manage
{
    public partial class MaintainCaclForm : Form
    {
        public MaintainCaclForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {               
                Int64 harvestOfYear = Int64.Parse(txtHarvestOfYear.Text.Trim());
                Int64 timesOfOnce = Int64.Parse(txtTimesOfOnce.Text.Trim());
                Int64 total = (Int64)(harvestOfYear * timesOfOnce * (nudCycle.Value / 12));
                txtTotalTimes.Text = total.ToString();
                if (total > Int64.MaxValue)
                {
                    MessageBox.Show("拧紧次数太多，暂不支持！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (total > 250000)
                {
                    lblHint.Text = "拧紧次数大于25万次，建议保养！";
                    lblHint.ForeColor = Color.Red;
                }
                else
                {
                    lblHint.Text = string.Empty;
                }
                
            }catch(Exception ex)
            {
                MessageBox.Show($"输入有误，必须是整数！原因：{ex.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHarvestOfYear.Text = string.Empty;
            txtTimesOfOnce.Text = string.Empty;
            txtTotalTimes.Text = string.Empty;
            lblHint.Text = string.Empty;
            nudCycle.ResetText();
        }
    }
}
