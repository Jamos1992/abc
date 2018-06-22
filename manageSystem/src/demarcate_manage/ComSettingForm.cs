using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace manageSystem.src.demarcate_manage
{
    public partial class ComSettingForm : Form
    {
        int[] BaudRateArr = new int[] { 110, 300, 600, 1200, 2400, 4800, 9600, 19200, 38400, 43000, 56000, 57600, 115200 };
        int[] DataBitArr = new int[] { 6, 7, 8 };
        int[] StopBitArr = new int[] { 1, 2, 3 };
        int[] TimeoutArr = new int[] { 500, 1000, 2000, 5000, 10000 };
        object[] CheckBitArr = new object[] { "None", "Odd", "Even", "Mark", "Space" };

        private string _portNameReceive = ConfigurationManager.AppSettings["PortName"];
        private string _baudRate = ConfigurationManager.AppSettings["BaudRate"];
        private string _dataBit = ConfigurationManager.AppSettings["DataBits"];
        private string _stopBit = ConfigurationManager.AppSettings["StopBits"];
        private string _checkBit = ConfigurationManager.AppSettings["Parity"];
        private string _timeout = ConfigurationManager.AppSettings["ReadTimeout"];
        public ComSettingForm()
        {
            InitializeComponent();
            InitView();
            MinimizeBox = false;
            MaximizeBox = false;
        }

        private void InitView()
        {
            cb_portNameReceive.DataSource = SerialPort.GetPortNames();
            cb_baudRate.DataSource = BaudRateArr;
            cb_dataBit.DataSource = DataBitArr;
            cb_stopBit.DataSource = StopBitArr;
            cb_checkBit.DataSource = CheckBitArr;
            cb_timeout.DataSource = TimeoutArr;

            cb_portNameReceive.Text = _portNameReceive;
            cb_baudRate.Text = _baudRate;
            cb_dataBit.Text = _dataBit;
            cb_stopBit.Text = _stopBit;
            cb_checkBit.Text = _checkBit;
            cb_timeout.Text = _timeout;

            if (cb_portNameReceive.Items.Count <= 0)
            {
                cb_portNameReceive.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["PortName"].Value = cb_portNameReceive.Text.Trim();
                config.AppSettings.Settings["BaudRate"].Value = cb_baudRate.Text.Trim();
                config.AppSettings.Settings["DataBits"].Value = cb_dataBit.Text.Trim();
                config.AppSettings.Settings["StopBits"].Value = cb_stopBit.Text.Trim();
                config.AppSettings.Settings["Parity"].Value = cb_checkBit.Text.Trim();
                config.AppSettings.Settings["ReadTimeout"].Value = cb_timeout.Text.Trim();
                config.Save();
                ConfigurationManager.RefreshSection("appSettings");               
                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch(Exception)
            {
                MessageBox.Show("保存失败！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            //if (serialPort1.IsOpen)
            //{
            //    try
            //    {
            //        serialPort1.Close();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }    
            //}
            //cb_portNameReceive.Enabled = !serialPort1.IsOpen;
            //cb_baudRate.Enabled = !serialPort1.IsOpen;
            //cb_checkBit.Enabled = !serialPort1.IsOpen;
            //cb_dataBit.Enabled = !serialPort1.IsOpen;
            //cb_stopBit.Enabled = !serialPort1.IsOpen;
            //cb_timeout.Enabled = !serialPort1.IsOpen;
            //button1.Enabled = !serialPort1.IsOpen;
        }

        //private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    byte[] ReDatas = new byte[serialPort1.BytesToRead];
        //    try
        //    {
        //        serialPort1.Read(ReDatas, 0, ReDatas.Length);//读取数据
        //        AddContent(new UTF8Encoding().GetString(ReDatas)); ;//输出数据
        //    }
        //    catch (TimeoutException ex)         //超时处理  
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void AddContent(string content)
        //{
        //    this.BeginInvoke(new MethodInvoker(delegate
        //    {
        //        //richTextBox1.AppendText("\r\n" + content);
        //    }));
        //}
    }
}
