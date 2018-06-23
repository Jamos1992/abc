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

namespace manageSystem.src.on_call_record
{
    public partial class ChartForm : Form
    {
        private List<OnCallRecord> onCallRecordList = new List<OnCallRecord>();
        public ChartForm()
        {
            InitializeComponent();
        }

        public ChartForm(OnCallRecord[] onCallRecords)
        {
            InitializeComponent();
            onCallRecordList = onCallRecords.ToList();
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            if (onCallRecordList.Count == 0) return;
            foreach(OnCallRecord record in onCallRecordList)
            {
                
            }
        }
    }
}
