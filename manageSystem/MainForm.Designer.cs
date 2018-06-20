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
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.驻场人员登记ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看驻场人员信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具信息录入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具信息查询导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.标定管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.备件管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具KPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.维修保养管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.邮件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RecieveManBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMailbtn = new System.Windows.Forms.ToolStripMenuItem();
            this.数据管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsInfoImport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.工具数据导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.仓库零件导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.importExcelFile = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
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
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(388, 346);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(185, 63);
            this.button6.TabIndex = 13;
            this.button6.Text = "维修保养管理";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(112, 346);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(185, 63);
            this.button5.TabIndex = 12;
            this.button5.Text = "服务报告管理";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(388, 237);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(185, 63);
            this.button4.TabIndex = 11;
            this.button4.Text = "备件管理";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(112, 237);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(185, 63);
            this.button3.TabIndex = 10;
            this.button3.Text = "标定管理";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(388, 126);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 63);
            this.button2.TabIndex = 9;
            this.button2.Text = "巡线On Call记录";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(112, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 63);
            this.button1.TabIndex = 8;
            this.button1.Text = "工具信息录入、查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.菜单ToolStripMenuItem,
            this.功能ToolStripMenuItem,
            this.邮件ToolStripMenuItem,
            this.数据管理ToolStripMenuItem});
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
            this.驻场人员登记ToolStripMenuItem,
            this.查看驻场人员信息ToolStripMenuItem,
            this.toolStripSeparator2,
            this.退出ToolStripMenuItem});
            this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            this.菜单ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.菜单ToolStripMenuItem.Text = "菜单";
            // 
            // 驻场人员登记ToolStripMenuItem
            // 
            this.驻场人员登记ToolStripMenuItem.Name = "驻场人员登记ToolStripMenuItem";
            this.驻场人员登记ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.驻场人员登记ToolStripMenuItem.Text = "驻场人员登记";
            // 
            // 查看驻场人员信息ToolStripMenuItem
            // 
            this.查看驻场人员信息ToolStripMenuItem.Name = "查看驻场人员信息ToolStripMenuItem";
            this.查看驻场人员信息ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.查看驻场人员信息ToolStripMenuItem.Text = "查看驻场人员信息";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.退出ToolStripMenuItem.Text = "退出";
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
            // 
            // 工具信息录入ToolStripMenuItem
            // 
            this.工具信息录入ToolStripMenuItem.Name = "工具信息录入ToolStripMenuItem";
            this.工具信息录入ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.工具信息录入ToolStripMenuItem.Text = "工具信息录入";
            // 
            // 工具信息查询导出ToolStripMenuItem
            // 
            this.工具信息查询导出ToolStripMenuItem.Name = "工具信息查询导出ToolStripMenuItem";
            this.工具信息查询导出ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.工具信息查询导出ToolStripMenuItem.Text = "工具信息查询、导出";
            // 
            // 标定管理ToolStripMenuItem
            // 
            this.标定管理ToolStripMenuItem.Name = "标定管理ToolStripMenuItem";
            this.标定管理ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.标定管理ToolStripMenuItem.Text = "标定管理";
            // 
            // 备件管理ToolStripMenuItem
            // 
            this.备件管理ToolStripMenuItem.Name = "备件管理ToolStripMenuItem";
            this.备件管理ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.备件管理ToolStripMenuItem.Text = "备件管理";
            // 
            // 工具KPIToolStripMenuItem
            // 
            this.工具KPIToolStripMenuItem.Name = "工具KPIToolStripMenuItem";
            this.工具KPIToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.工具KPIToolStripMenuItem.Text = "工具KPI";
            // 
            // 维修保养管理ToolStripMenuItem
            // 
            this.维修保养管理ToolStripMenuItem.Name = "维修保养管理ToolStripMenuItem";
            this.维修保养管理ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.维修保养管理ToolStripMenuItem.Text = "维修保养管理";
            // 
            // 邮件ToolStripMenuItem
            // 
            this.邮件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RecieveManBtn,
            this.sendMailbtn});
            this.邮件ToolStripMenuItem.Name = "邮件ToolStripMenuItem";
            this.邮件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.邮件ToolStripMenuItem.Text = "邮件";
            // 
            // RecieveManBtn
            // 
            this.RecieveManBtn.Name = "RecieveManBtn";
            this.RecieveManBtn.Size = new System.Drawing.Size(136, 22);
            this.RecieveManBtn.Text = "收件人管理";
            this.RecieveManBtn.Click += new System.EventHandler(this.RecieveManBtn_Click);
            // 
            // sendMailbtn
            // 
            this.sendMailbtn.Name = "sendMailbtn";
            this.sendMailbtn.Size = new System.Drawing.Size(136, 22);
            this.sendMailbtn.Text = "发送邮件";
            this.sendMailbtn.Click += new System.EventHandler(this.sendMailbtn_Click);
            // 
            // 数据管理ToolStripMenuItem
            // 
            this.数据管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsInfoImport,
            this.toolStripSeparator1,
            this.工具数据导出ToolStripMenuItem,
            this.仓库零件导出ToolStripMenuItem});
            this.数据管理ToolStripMenuItem.Name = "数据管理ToolStripMenuItem";
            this.数据管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.数据管理ToolStripMenuItem.Text = "数据管理";
            // 
            // toolsInfoImport
            // 
            this.toolsInfoImport.Name = "toolsInfoImport";
            this.toolsInfoImport.Size = new System.Drawing.Size(180, 22);
            this.toolsInfoImport.Text = "工具零件信息导入";
            this.toolsInfoImport.Click += new System.EventHandler(this.toolsInfoImport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // 工具数据导出ToolStripMenuItem
            // 
            this.工具数据导出ToolStripMenuItem.Name = "工具数据导出ToolStripMenuItem";
            this.工具数据导出ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.工具数据导出ToolStripMenuItem.Text = "工具数据导出";
            this.工具数据导出ToolStripMenuItem.Click += new System.EventHandler(this.工具数据导出ToolStripMenuItem_Click);
            // 
            // 仓库零件导出ToolStripMenuItem
            // 
            this.仓库零件导出ToolStripMenuItem.Name = "仓库零件导出ToolStripMenuItem";
            this.仓库零件导出ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.仓库零件导出ToolStripMenuItem.Text = "仓库零件导出";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(686, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(157, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(363, 50);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // importExcelFile
            // 
            this.importExcelFile.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Desoutter工具管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具信息录入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具信息查询导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 标定管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 备件管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具KPIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 维修保养管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 驻场人员登记ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看驻场人员信息ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem 邮件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RecieveManBtn;
        private System.Windows.Forms.ToolStripMenuItem sendMailbtn;
        private System.Windows.Forms.ToolStripMenuItem 数据管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具数据导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 仓库零件导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsInfoImport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog importExcelFile;
    }
}