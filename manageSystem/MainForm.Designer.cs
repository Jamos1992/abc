namespace manageSystem
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnMaintain = new System.Windows.Forms.Button();
            this.btnKPI = new System.Windows.Forms.Button();
            this.btnSpareTool = new System.Windows.Forms.Button();
            this.btnDemarcate = new System.Windows.Forms.Button();
            this.btnOnCall = new System.Windows.Forms.Button();
            this.btnToolsInfo = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWorkerRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWorkerList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具信息录入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具信息查询导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.标定管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.备件管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具KPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.维修保养管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.邮件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRecieveMan = new System.Windows.Forms.ToolStripMenuItem();
            this.btnsendMail = new System.Windows.Forms.ToolStripMenuItem();
            this.数据管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnToolsInfoImport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnToolDataExport = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSpareToolExport = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOnCallExport = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMaintainExport = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDemarcateExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.大屏KPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnComSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblWelcome = new System.Windows.Forms.ToolStripStatusLabel();
            this.importExcelFile = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(202, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 31);
            this.label1.TabIndex = 15;
            this.label1.Text = "Desoutter工具管理系统";
            // 
            // btnMaintain
            // 
            this.btnMaintain.Location = new System.Drawing.Point(112, 338);
            this.btnMaintain.Name = "btnMaintain";
            this.btnMaintain.Size = new System.Drawing.Size(185, 63);
            this.btnMaintain.TabIndex = 13;
            this.btnMaintain.Text = "维修保养管理";
            this.btnMaintain.UseVisualStyleBackColor = true;
            this.btnMaintain.Click += new System.EventHandler(this.btnMaintain_Click);
            // 
            // btnKPI
            // 
            this.btnKPI.Location = new System.Drawing.Point(0, 396);
            this.btnKPI.Name = "btnKPI";
            this.btnKPI.Size = new System.Drawing.Size(71, 29);
            this.btnKPI.TabIndex = 12;
            this.btnKPI.Text = "服务报告管理";
            this.btnKPI.UseVisualStyleBackColor = true;
            this.btnKPI.Click += new System.EventHandler(this.btnKPI_Click);
            // 
            // btnSpareTool
            // 
            this.btnSpareTool.Location = new System.Drawing.Point(388, 237);
            this.btnSpareTool.Name = "btnSpareTool";
            this.btnSpareTool.Size = new System.Drawing.Size(185, 63);
            this.btnSpareTool.TabIndex = 11;
            this.btnSpareTool.Text = "备件管理";
            this.btnSpareTool.UseVisualStyleBackColor = true;
            this.btnSpareTool.Click += new System.EventHandler(this.btnSpareTool_Click);
            // 
            // btnDemarcate
            // 
            this.btnDemarcate.Location = new System.Drawing.Point(112, 237);
            this.btnDemarcate.Name = "btnDemarcate";
            this.btnDemarcate.Size = new System.Drawing.Size(185, 63);
            this.btnDemarcate.TabIndex = 10;
            this.btnDemarcate.Text = "校准管理";
            this.btnDemarcate.UseVisualStyleBackColor = true;
            this.btnDemarcate.Click += new System.EventHandler(this.btnDemarcate_Click);
            // 
            // btnOnCall
            // 
            this.btnOnCall.Location = new System.Drawing.Point(388, 126);
            this.btnOnCall.Name = "btnOnCall";
            this.btnOnCall.Size = new System.Drawing.Size(185, 63);
            this.btnOnCall.TabIndex = 9;
            this.btnOnCall.Text = "巡线On Call记录";
            this.btnOnCall.UseVisualStyleBackColor = true;
            this.btnOnCall.Click += new System.EventHandler(this.btnOnCall_Click);
            // 
            // btnToolsInfo
            // 
            this.btnToolsInfo.Location = new System.Drawing.Point(112, 126);
            this.btnToolsInfo.Name = "btnToolsInfo";
            this.btnToolsInfo.Size = new System.Drawing.Size(185, 63);
            this.btnToolsInfo.TabIndex = 8;
            this.btnToolsInfo.Text = "工具信息录入、查询";
            this.btnToolsInfo.UseVisualStyleBackColor = true;
            this.btnToolsInfo.Click += new System.EventHandler(this.btnToolsInfo_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.菜单ToolStripMenuItem,
            this.功能ToolStripMenuItem,
            this.邮件ToolStripMenuItem,
            this.数据管理ToolStripMenuItem,
            this.设置ToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(686, 25);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 菜单ToolStripMenuItem
            // 
            this.菜单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnWorkerRegister,
            this.btnWorkerList,
            this.toolStripSeparator2,
            this.btnExit});
            this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            this.菜单ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.菜单ToolStripMenuItem.Text = "菜单";
            // 
            // btnWorkerRegister
            // 
            this.btnWorkerRegister.Name = "btnWorkerRegister";
            this.btnWorkerRegister.Size = new System.Drawing.Size(180, 22);
            this.btnWorkerRegister.Text = "驻场人员登记";
            this.btnWorkerRegister.Click += new System.EventHandler(this.btnWorkerRegister_Click);
            // 
            // btnWorkerList
            // 
            this.btnWorkerList.Name = "btnWorkerList";
            this.btnWorkerList.Size = new System.Drawing.Size(180, 22);
            this.btnWorkerList.Text = "查看驻场人员信息";
            this.btnWorkerList.Click += new System.EventHandler(this.btnWorkerList_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // btnExit
            // 
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(180, 22);
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // 功能ToolStripMenuItem
            // 
            this.功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工具信息录入ToolStripMenuItem,
            this.工具信息查询导出ToolStripMenuItem,
            this.标定管理ToolStripMenuItem,
            this.备件管理ToolStripMenuItem,
            this.工具KPIToolStripMenuItem,
            this.维修保养管理ToolStripMenuItem});
            this.功能ToolStripMenuItem.Name = "功能ToolStripMenuItem";
            this.功能ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.功能ToolStripMenuItem.Text = "功能";
            this.功能ToolStripMenuItem.Visible = false;
            // 
            // 工具信息录入ToolStripMenuItem
            // 
            this.工具信息录入ToolStripMenuItem.Name = "工具信息录入ToolStripMenuItem";
            this.工具信息录入ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.工具信息录入ToolStripMenuItem.Text = "工具信息录入、查询";
            this.工具信息录入ToolStripMenuItem.Click += new System.EventHandler(this.btnToolsInfo_Click);
            // 
            // 工具信息查询导出ToolStripMenuItem
            // 
            this.工具信息查询导出ToolStripMenuItem.Name = "工具信息查询导出ToolStripMenuItem";
            this.工具信息查询导出ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.工具信息查询导出ToolStripMenuItem.Text = "巡线On Call记录";
            this.工具信息查询导出ToolStripMenuItem.Click += new System.EventHandler(this.btnOnCall_Click);
            // 
            // 标定管理ToolStripMenuItem
            // 
            this.标定管理ToolStripMenuItem.Name = "标定管理ToolStripMenuItem";
            this.标定管理ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.标定管理ToolStripMenuItem.Text = "标定管理";
            this.标定管理ToolStripMenuItem.Click += new System.EventHandler(this.btnDemarcate_Click);
            // 
            // 备件管理ToolStripMenuItem
            // 
            this.备件管理ToolStripMenuItem.Name = "备件管理ToolStripMenuItem";
            this.备件管理ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.备件管理ToolStripMenuItem.Text = "备件管理";
            this.备件管理ToolStripMenuItem.Click += new System.EventHandler(this.btnSpareTool_Click);
            // 
            // 工具KPIToolStripMenuItem
            // 
            this.工具KPIToolStripMenuItem.Name = "工具KPIToolStripMenuItem";
            this.工具KPIToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.工具KPIToolStripMenuItem.Text = "服务报告管理";
            this.工具KPIToolStripMenuItem.Click += new System.EventHandler(this.btnKPI_Click);
            // 
            // 维修保养管理ToolStripMenuItem
            // 
            this.维修保养管理ToolStripMenuItem.Name = "维修保养管理ToolStripMenuItem";
            this.维修保养管理ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.维修保养管理ToolStripMenuItem.Text = "维修保养管理";
            this.维修保养管理ToolStripMenuItem.Click += new System.EventHandler(this.btnMaintain_Click);
            // 
            // 邮件ToolStripMenuItem
            // 
            this.邮件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRecieveMan,
            this.btnsendMail});
            this.邮件ToolStripMenuItem.Name = "邮件ToolStripMenuItem";
            this.邮件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.邮件ToolStripMenuItem.Text = "邮件";
            // 
            // btnRecieveMan
            // 
            this.btnRecieveMan.Name = "btnRecieveMan";
            this.btnRecieveMan.Size = new System.Drawing.Size(136, 22);
            this.btnRecieveMan.Text = "收件人管理";
            this.btnRecieveMan.Click += new System.EventHandler(this.btnRecieveMan_Click);
            // 
            // btnsendMail
            // 
            this.btnsendMail.Name = "btnsendMail";
            this.btnsendMail.Size = new System.Drawing.Size(136, 22);
            this.btnsendMail.Text = "发送邮件";
            this.btnsendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // 数据管理ToolStripMenuItem
            // 
            this.数据管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnToolsInfoImport,
            this.toolStripSeparator1,
            this.btnToolDataExport,
            this.btnSpareToolExport,
            this.btnOnCallExport,
            this.btnMaintainExport,
            this.btnDemarcateExport,
            this.toolStripSeparator3,
            this.大屏KPIToolStripMenuItem});
            this.数据管理ToolStripMenuItem.Name = "数据管理ToolStripMenuItem";
            this.数据管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.数据管理ToolStripMenuItem.Text = "数据管理";
            // 
            // btnToolsInfoImport
            // 
            this.btnToolsInfoImport.Name = "btnToolsInfoImport";
            this.btnToolsInfoImport.Size = new System.Drawing.Size(172, 22);
            this.btnToolsInfoImport.Text = "工具零件信息导入";
            this.btnToolsInfoImport.Click += new System.EventHandler(this.toolsInfoImport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // btnToolDataExport
            // 
            this.btnToolDataExport.Name = "btnToolDataExport";
            this.btnToolDataExport.Size = new System.Drawing.Size(172, 22);
            this.btnToolDataExport.Text = "工具数据导出";
            this.btnToolDataExport.Click += new System.EventHandler(this.btnToolDataExport_Click);
            // 
            // btnSpareToolExport
            // 
            this.btnSpareToolExport.Name = "btnSpareToolExport";
            this.btnSpareToolExport.Size = new System.Drawing.Size(172, 22);
            this.btnSpareToolExport.Text = "仓库零件导出";
            this.btnSpareToolExport.Click += new System.EventHandler(this.btnSpareToolExport_Click);
            // 
            // btnOnCallExport
            // 
            this.btnOnCallExport.Name = "btnOnCallExport";
            this.btnOnCallExport.Size = new System.Drawing.Size(172, 22);
            this.btnOnCallExport.Text = "OnCall记录导出";
            this.btnOnCallExport.Click += new System.EventHandler(this.btnOnCallExport_Click);
            // 
            // btnMaintainExport
            // 
            this.btnMaintainExport.Name = "btnMaintainExport";
            this.btnMaintainExport.Size = new System.Drawing.Size(172, 22);
            this.btnMaintainExport.Text = "维修数据导出";
            this.btnMaintainExport.Click += new System.EventHandler(this.btnMaintainExport_Click);
            // 
            // btnDemarcateExport
            // 
            this.btnDemarcateExport.Name = "btnDemarcateExport";
            this.btnDemarcateExport.Size = new System.Drawing.Size(172, 22);
            this.btnDemarcateExport.Text = "标定历史记录导出";
            this.btnDemarcateExport.Click += new System.EventHandler(this.btnDemarcateExport_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
            // 
            // 大屏KPIToolStripMenuItem
            // 
            this.大屏KPIToolStripMenuItem.Name = "大屏KPIToolStripMenuItem";
            this.大屏KPIToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.大屏KPIToolStripMenuItem.Text = "大屏KPI导出";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnComSetting});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // btnComSetting
            // 
            this.btnComSetting.Name = "btnComSetting";
            this.btnComSetting.Size = new System.Drawing.Size(148, 22);
            this.btnComSetting.Text = "串口参数设置";
            this.btnComSetting.Click += new System.EventHandler(this.btnComSetting_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblWelcome});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(686, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblWelcome
            // 
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(192, 17);
            this.lblWelcome.Text = "欢迎进入Desoutte工具管理系统！";
            // 
            // importExcelFile
            // 
            this.importExcelFile.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(157, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(363, 50);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMaintain);
            this.Controls.Add(this.btnKPI);
            this.Controls.Add(this.btnSpareTool);
            this.Controls.Add(this.btnDemarcate);
            this.Controls.Add(this.btnOnCall);
            this.Controls.Add(this.btnToolsInfo);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Desoutter工具管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMaintain;
        private System.Windows.Forms.Button btnKPI;
        private System.Windows.Forms.Button btnSpareTool;
        private System.Windows.Forms.Button btnDemarcate;
        private System.Windows.Forms.Button btnOnCall;
        private System.Windows.Forms.Button btnToolsInfo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem 功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具信息录入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具信息查询导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 标定管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 备件管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具KPIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 维修保养管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnWorkerRegister;
        private System.Windows.Forms.ToolStripMenuItem btnWorkerList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem 邮件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnRecieveMan;
        private System.Windows.Forms.ToolStripMenuItem btnsendMail;
        private System.Windows.Forms.ToolStripMenuItem 数据管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnToolDataExport;
        private System.Windows.Forms.ToolStripMenuItem btnSpareToolExport;
        private System.Windows.Forms.ToolStripMenuItem btnToolsInfoImport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog importExcelFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem btnOnCallExport;
        private System.Windows.Forms.ToolStripMenuItem btnMaintainExport;
        private System.Windows.Forms.ToolStripMenuItem btnDemarcateExport;
        private System.Windows.Forms.ToolStripStatusLabel lblWelcome;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnComSetting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 大屏KPIToolStripMenuItem;
    }
}