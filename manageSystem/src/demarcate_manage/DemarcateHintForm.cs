using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using Model;

namespace manageSystem.src.demarcate_manage
{
    public partial class DemarcateHintForm : Form
    {
        private DemarcateRecordManage demarcateRecordManage = new DemarcateRecordManage();
        private List<DemarcateTools> demarcateToolList = new List<DemarcateTools>();
        public GotoDemarcatePageDelegate gotoDemarcate;
        public DemarcateHintForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView3.AutoGenerateColumns = false;
        }

        private void DemarcateHintForm_Load(object sender, EventArgs e)
        {
            demarcateToolList = demarcateRecordManage.GetAllDemarcateTools();
            List<DemarcateTools> unFinisnedList = new List<DemarcateTools>();
            List<DemarcateTools> todayList = new List<DemarcateTools>();
            List<DemarcateTools> weekList = new List<DemarcateTools>();
            int iNowOfWeek = (int)DateTime.Now.DayOfWeek;
            if (iNowOfWeek == 0)
            {
                iNowOfWeek = 7;
            }
            foreach (DemarcateTools tool in demarcateToolList)
            {

                try
                {
                    if (Convert.ToDateTime(tool.NextTime) < DateTime.Now.Date)
                    {
                        unFinisnedList.Add(tool);

                    }
                    else if (Convert.ToDateTime(tool.NextTime) == DateTime.Now.Date)
                    {
                        todayList.Add(tool);
                    }
                    if (Convert.ToDateTime(tool.NextTime) >= DateTime.Now.AddDays(1 - iNowOfWeek).Date
                       && Convert.ToDateTime(tool.NextTime) <= DateTime.Now.AddDays(7 - iNowOfWeek).Date)
                    {

                        weekList.Add(tool);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            lblUnFinished.Text = $"总条数：{unFinisnedList.Count}";
            lblToday.Text = $"总条数：{todayList.Count}";
            lblWeek.Text = $"总条数：{weekList.Count}";
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = unFinisnedList;
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = todayList;
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = weekList;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1)
            {
                DataGridViewButtonCell btnCell = dataGridView1.CurrentCell as DataGridViewButtonCell;
                if (btnCell != null)
                {
                    gotoDemarcate(getSerialNumFromUnfinishedGrid());
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.RowIndex > -1)
            {
                DataGridViewLinkCell linkCell = dataGridView1.CurrentCell as DataGridViewLinkCell;
                if (linkCell != null)
                {
                    gotoDemarcate(getSerialNumFromUnfinishedGrid());
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1)
            {
                DataGridViewButtonCell btnCell = dataGridView2.CurrentCell as DataGridViewButtonCell;
                if (btnCell != null)
                {
                    gotoDemarcate(getSerialNumFromTodayGrid());
                }
            }
            if (dataGridView2.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.RowIndex > -1)
            {
                DataGridViewLinkCell linkCell = dataGridView2.CurrentCell as DataGridViewLinkCell;
                if (linkCell != null)
                {
                    gotoDemarcate(getSerialNumFromTodayGrid());
                }
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1)
            {
                DataGridViewButtonCell btnCell = dataGridView3.CurrentCell as DataGridViewButtonCell;
                if (btnCell != null)
                {
                    gotoDemarcate(getSerialNumFromWeekGrid());
                }
            }
            if (dataGridView3.Columns[e.ColumnIndex] is DataGridViewLinkColumn && e.RowIndex > -1)
            {
                DataGridViewLinkCell linkCell = dataGridView3.CurrentCell as DataGridViewLinkCell;
                if (linkCell != null)
                {
                    gotoDemarcate(getSerialNumFromWeekGrid());
                }
            }
        }

        private string getSerialNumFromUnfinishedGrid()
        {
            return dataGridView1.SelectedRows[0].Cells["SerialNumCol"].Value.ToString();
        }

        private string getSerialNumFromTodayGrid()
        {
            return dataGridView2.SelectedRows[0].Cells["todaySerialNumCol"].Value.ToString();
        }

        private string getSerialNumFromWeekGrid()
        {
            return dataGridView3.SelectedRows[0].Cells["weekSerialNumCol"].Value.ToString();
        }
    }

    public delegate void GotoDemarcatePageDelegate(string s);
}
