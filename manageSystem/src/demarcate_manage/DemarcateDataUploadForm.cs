using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Collections;
using BLL;
using Model;
using System.Configuration;
using System.Text.RegularExpressions;

namespace manageSystem.src.demarcate_manage
{
    public partial class DemarcateDataUploadForm : Form
    {
        private DemarcateRecordManage demarcateRecordManage = new DemarcateRecordManage();
        private ToolsInfoManage toolsInfoManage = new ToolsInfoManage();
        private List<DemarcateData> list = new List<DemarcateData>();
        public setFormBtnDelegate setOperatorFormBtnDelegate;
        private string _portNameReceive;
        private string _baudRate;
        private string _dataBit;
        private string _stopBit;
        private string _checkBit;
        private string _timeout;

        public string SerialNum;
        public string CheckMan;

        //private bool comOpenStatus = false;

        public bool DemarcateResult = false;
        public DemarcateDataUploadForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            initSerialPort();
        }
        private void initSerialPort()
        {
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);//绑定事件
        }

        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] ReDatas = new byte[serialPort1.BytesToRead];
            try
            {
                serialPort1.Read(ReDatas, 0, ReDatas.Length);//读取数据
                AddContent(new UTF8Encoding().GetString(ReDatas)); ;//输出数据
            }
            catch (TimeoutException ex)         //超时处理  
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void AddContent(string content)
        {
            this.BeginInvoke(new MethodInvoker(delegate
            {
                list.Add(DemarcateDataParse(content));
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = list;
            }));
        }
        private void openComListen(object sender, EventArgs e)
        {
            setSerialPort();
            if (SerialPort.GetPortNames().Length <= 0)
            {
                MessageBox.Show("没有发现串口,请检查线路！");
                return;
            }
            if (!((IList)SerialPort.GetPortNames()).Contains(_portNameReceive))
            {
                MessageBox.Show("串口端口设置错误,请重新设置！");
                return;
            }
            if (!serialPort1.IsOpen)
            {
                serialPort1.PortName = _portNameReceive;
                serialPort1.BaudRate = int.Parse(_baudRate);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), _checkBit);
                serialPort1.DataBits = int.Parse(_dataBit);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _stopBit);
                serialPort1.ReadTimeout = int.Parse(_timeout);
                try
                {
                    serialPort1.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            btnListenCom.Enabled = false;
            setOperatorFormBtnDelegate();
        }

        private void btnListenCom_Click(object sender, EventArgs e)
        {
            openComListen(sender,e);
            //toolStripButton1.Enabled = !serialPort1.IsOpen;
        }

        private void setSerialPort()
        {
            _portNameReceive = ConfigurationManager.AppSettings["PortName"];
            _baudRate = ConfigurationManager.AppSettings["BaudRate"];
            _dataBit = ConfigurationManager.AppSettings["DataBits"];
            _stopBit = ConfigurationManager.AppSettings["StopBits"];
            _checkBit = ConfigurationManager.AppSettings["Parity"];
            _timeout = ConfigurationManager.AppSettings["ReadTimeout"];
        }

        private DemarcateData DemarcateDataParse(string input)
        {
            string[] mm = Regex.Split(input, "\\s+", RegexOptions.IgnoreCase);
            for (int i = 0; i < mm.Length; i++)
            {
                Console.Write(mm[i] + '\n');
            }
            DemarcateData demarcateData = new DemarcateData();
            demarcateData.Order = mm[0];
            demarcateData.Date = mm[1];
            demarcateData.Time = mm[2];
            demarcateData.Torque = mm[3];
            try
            {
                if (mm[4] == "A" || mm[4] == "R")
                {
                    demarcateData.Angle = "";
                }
                else
                {
                    demarcateData.Angle = mm[4];
                }
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            return demarcateData;
        }
        public void reDemarcateActon()
        {
            list = null;
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1)
            {
                DataGridViewButtonCell btnCell = dataGridView1.CurrentCell as DataGridViewButtonCell;
                if (btnCell != null)
                {
                    if(MessageBox.Show("确认要删除吗？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.Cancel)
                    {
                        return;
                    }
                    DemarcateData demarcateData = GetOneToolsInfoFromGrid();
                    for (int i = list.Count - 1; i >= 0; i--)
                    {
                        if (list[i].Order == demarcateData.Order && list[i].Time == demarcateData.Time)
                        {
                            list.Remove(list[i]);
                        }
                    }
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = list;
                }
            }
        }

        private DemarcateData GetOneToolsInfoFromGrid() 
        {
            if (dataGridView1.SelectedRows.Count == 0) return null;
            return new DemarcateData
            {
                Order = dataGridView1.SelectedRows[0].Cells[1].Value.ToString(),
                Date = dataGridView1.SelectedRows[0].Cells[2].Value.ToString(),
                Time = dataGridView1.SelectedRows[0].Cells[3].Value.ToString(),
                Torque = dataGridView1.SelectedRows[0].Cells[4].Value.ToString(),
                Angle = dataGridView1.SelectedRows[0].Cells[5].Value.ToString(),
            };
        }

        private List<DemarcateData> GetAllToolsInfoFromGrid()
        {
            if (dataGridView1.Rows.Count <= 0) return null;
            List<DemarcateData> demarcateDatas = new List<DemarcateData>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                demarcateDatas.Add(new DemarcateData
                {
                    Order = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                    Date = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                    Time = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                    Torque = dataGridView1.Rows[i].Cells[4].Value.ToString(),
                    Angle = dataGridView1.Rows[i].Cells[5].Value.ToString(),
                });
            }
            return demarcateDatas;
        }

        public DemarcateRecords GetDemarcateRecords()
        {
            ToolsInfo toolsInfo = toolsInfoManage.QueryOneToolsInfo(SerialNum);
            DemarcateTools demarcateTools = demarcateRecordManage.getOneDemarcateToolBySerialNum(SerialNum);
            if (toolsInfo == null || demarcateTools == null)
            {
                MessageBox.Show("工具序列号有误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            string nextTime = DateTime.Now.AddDays(demarcateTools.Cycle).ToString("d");
            return new DemarcateRecords
            {
                DemarcateNum = DateTime.Now.ToString("yyyyMMdd") + toolsInfo.SerialNum,
                SerialNum = toolsInfo.SerialNum,
                WorkStation = toolsInfo.Workstation,
                Validity = nextTime,
                Examinant = CheckMan,
                CheckTime = DateTime.Now.ToString("d")
            };
        }

        public bool CalcDemarcateResult()
        {
            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("请先使用标定仪器标定！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            List<DemarcateData> demarcateDatas = GetAllToolsInfoFromGrid();
            ToolsInfo toolsInfo = toolsInfoManage.QueryOneToolsInfo(SerialNum);
            foreach (DemarcateData demarcate in demarcateDatas)
            {
                if (double.Parse(demarcate.Torque) > toolsInfo.TorqueMax || double.Parse(demarcate.Torque) < toolsInfo.TorqueMin)
                {
                    DemarcateResult = false;
                    return true;
                }
            }
            DemarcateResult = true;
            return true;
        }

        public void setResultLabel(string s)
        {
            lblResult.Text = s;
        }
        
        public void CloseSerialPort()
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            dataGridView1.DataSource = new List<DemarcateData>();
            Visible = false;
            //Close();
        }

        private void DemarcateDataUploadForm_Load(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            dataGridView1.DataSource = new List<DemarcateData>();
            btnListenCom.Visible = false;
            openComListen(sender, e);
        }
    }

    public delegate void setFormBtnDelegate();
}
