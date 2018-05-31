using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace manageSystem.src.demarcate_manage
{
    public partial class ComSettingForm : Form
    {
        int[] BaudRateArr = new int[] { 110, 300, 600, 1200, 2400, 4800, 9600, 19200, 38400, 43000, 56000, 57600, 115200 };
        int[] DataBitArr = new int[] { 6, 7, 8 };
        int[] StopBitArr = new int[] { 1, 2, 3 };
        int[] TimeoutArr = new int[] { 500, 1000, 2000, 5000, 10000 };
        object[] CheckBitArr = new object[] { "None","Odd", "Even", "Mark", "Space" };
        public ComSettingForm()
        {
            InitializeComponent();
            InitView();
        }

        private void InitView()
        {
            cb_portNameReceive.DataSource = SerialPort.GetPortNames();
            cb_baudRate.DataSource = BaudRateArr;
            cb_dataBit.DataSource = DataBitArr;
            cb_stopBit.DataSource = StopBitArr;
            cb_checkBit.DataSource = CheckBitArr;
            cb_timeout.DataSource = TimeoutArr;
            if (cb_portNameReceive.Items.Count > 0)
            {
                cb_portNameReceive.SelectedIndex = 0;
            }
            cb_baudRate.SelectedIndex = 5;

            serialPort1.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);//绑定事件
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cb_portNameReceive.Items.Count <= 0)
            {
                MessageBox.Show("没有发现串口,请检查线路！");
                return;
            }            
            if (!serialPort1.IsOpen)
            {
                serialPort1.PortName = cb_portNameReceive.Text.Trim();
                serialPort1.BaudRate = int.Parse(cb_baudRate.Text);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), cb_checkBit.Text);
                serialPort1.DataBits = int.Parse(cb_dataBit.Text);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), cb_stopBit.Text);
                serialPort1.ReadTimeout = int.Parse(cb_timeout.Text);
                try
                {
                    serialPort1.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            cb_portNameReceive.Enabled = !serialPort1.IsOpen;
            cb_baudRate.Enabled = !serialPort1.IsOpen;
            cb_checkBit.Enabled = !serialPort1.IsOpen;
            cb_dataBit.Enabled = !serialPort1.IsOpen;
            cb_stopBit.Enabled = !serialPort1.IsOpen;
            cb_timeout.Enabled = !serialPort1.IsOpen;
            button1.Enabled = !serialPort1.IsOpen;
        }

        private void button2_Click(object sender, EventArgs e)
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
            cb_portNameReceive.Enabled = !serialPort1.IsOpen;
            cb_baudRate.Enabled = !serialPort1.IsOpen;
            cb_checkBit.Enabled = !serialPort1.IsOpen;
            cb_dataBit.Enabled = !serialPort1.IsOpen;
            cb_stopBit.Enabled = !serialPort1.IsOpen;
            cb_timeout.Enabled = !serialPort1.IsOpen;
            button1.Enabled = !serialPort1.IsOpen;
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
                richTextBox1.AppendText("\r\n" + content);
            }));
        }
    }
}
