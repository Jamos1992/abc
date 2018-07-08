using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using DAL;

namespace manageSystem.src.demarcate_manage
{
    public partial class QRCodePrintForm : Form
    {
        public DemarcateRecords demarcateRecords = new DemarcateRecords();
        private DemarcateRecordService demarcateRecordService = new DemarcateRecordService();
        public QRCodePrintForm()
        {
            InitializeComponent();
            //this.printDocument1.OriginAtMargins = true;//启用页边距
            this.pageSetupDialog1.EnableMetric = true; //以毫米为单位
            this.printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custom", 500, 300);
        }

        public QRCodePrintForm(DemarcateRecords records)
        {
            demarcateRecords = records;
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
            //printDocument1.OriginAtMargins = true;//启用页边距
            pageSetupDialog1.EnableMetric = true; //以毫米为单位

            txtSerialName.BorderStyle = BorderStyle.None;
            txtDemarNum.BorderStyle = BorderStyle.None;
            txtWorkstation.BorderStyle = BorderStyle.None;
            txtValid.BorderStyle = BorderStyle.None;
            txtCheckman.BorderStyle = BorderStyle.None;
        }

        private void QRCodePrintForm_Load(object sender, EventArgs e)
        {
            txtSerialName.Text = demarcateRecords.SerialNum;
            txtDemarNum.Text = demarcateRecords.DemarcateNum;
            txtWorkstation.Text = demarcateRecords.WorkStation;
            txtValid.Text = demarcateRecords.Validity;
            txtCheckman.Text = demarcateRecords.Examinant;
            picQRcode.Image = demarcateRecordService.CreateQRCode(demarcateRecords.SerialNum);
            picQRcode.Focus();
        }

        //打印设置
        private void btnSetPrint_Click(object sender, EventArgs e)
        {
            this.pageSetupDialog1.ShowDialog();
        }

        //打印预览
        private void btnPrePrint_Click(object sender, EventArgs e)
        {
            this.printPreviewDialog1.ShowDialog();
        }

        //打印
        private void btnPrint_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custom", 500, 300);
            printDocument1.PrinterSettings.Copies = (short)nudPrintNum.Value;
            printPreviewDialog1.Document = printDocument1;
            //显示打印预览
            DialogResult result = printPreviewDialog1.ShowDialog();
            //printDocument1.Print();
        }

        //打印内容的设置
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ////打印内容 为 整个Form
            //Image myFormImage;
            //myFormImage = new Bitmap(this.Width, this.Height);
            //Graphics g = Graphics.FromImage(myFormImage);
            //g.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            //e.Graphics.DrawImage(myFormImage, 0, 0);

            ////打印内容 为 局部的 this.groupBox1
            //Bitmap _NewBitmap = new Bitmap((int)(panel1.Width * 1.25), (int)(panel1.Height * 1.25));
            //panel1.DrawToBitmap(_NewBitmap, new Rectangle(0, 0, _NewBitmap.Width, _NewBitmap.Height));
            //e.Graphics.DrawImage(_NewBitmap, 0, 0, _NewBitmap.Width, _NewBitmap.Height);

            //打印内容 为 自定义文本内容 
            Font font = new Font("宋体", 12);
            Brush brush = Brushes.Blue;
            e.Graphics.DrawString($"标定序列号： {txtDemarNum.Text.Trim()}", new Font(new FontFamily("黑体"), 8), Brushes.Black, 80, 80);
            e.Graphics.DrawString($"工具序列号： {txtSerialName.Text.Trim()}", new Font(new FontFamily("黑体"), 8), Brushes.Black, 80, 110);
            e.Graphics.DrawString($"工      位： {txtWorkstation.Text.Trim()}", new Font(new FontFamily("黑体"), 8), Brushes.Black, 80, 140);
            e.Graphics.DrawString($"标定有效期： {txtValid.Text.Trim()}", new Font(new FontFamily("黑体"), 8), Brushes.Black, 80, 170);
            e.Graphics.DrawString($"检  查  员： {txtCheckman.Text.Trim()}", new Font(new FontFamily("黑体"), 8), Brushes.Black, 80, 200);
            e.Graphics.DrawImage(picQRcode.Image, 280, 80, 135, 135);
        }

        private void QRCodePrintForm_Resize(object sender, EventArgs e)
        {
            foreach (Control c in panel1.Controls)
            {
                c.Location = new Point(c.Location.X + 70, c.Location.Y + 5);
            }
            foreach(Control c in panel3.Controls)
            {
                c.Location = new Point(c.Location.X + 70, c.Location.Y);
            }
        }
    }
}
