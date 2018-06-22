using System;
using System.Windows.Forms;

namespace manageSystem.src.demarcate_manage
{
    public partial class ScanCodeForm : Form
    {
        public event setTextValue setFormTextValue;
        public ScanCodeForm()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void ScanCodeForm_Load(object sender, EventArgs e)
        {
            txtSerialNum.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            setFormTextValue(txtSerialNum.Text.Trim());
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public delegate void setTextValue(string serialNum);
}
