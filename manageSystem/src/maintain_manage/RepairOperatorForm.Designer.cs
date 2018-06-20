namespace manageSystem.src.maintain_manage
{
    partial class RepairOperatorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RepairOperatorForm));
            this.label1 = new System.Windows.Forms.Label();
            this.cboSerialNum = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRepoSpare = new System.Windows.Forms.TextBox();
            this.btnRepoAdd = new System.Windows.Forms.Button();
            this.txtOtherSpare = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnSuspend = new System.Windows.Forms.Button();
            this.btnRepoRemove = new System.Windows.Forms.Button();
            this.btn = new System.Windows.Forms.Button();
            this.btnOtherAdd = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择送修工具：";
            // 
            // cboSerialNum
            // 
            this.cboSerialNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cboSerialNum.FormattingEnabled = true;
            this.cboSerialNum.Location = new System.Drawing.Point(180, 47);
            this.cboSerialNum.Name = "cboSerialNum";
            this.cboSerialNum.Size = new System.Drawing.Size(185, 20);
            this.cboSerialNum.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "使用仓库备件：";
            // 
            // txtRepoSpare
            // 
            this.txtRepoSpare.Location = new System.Drawing.Point(181, 92);
            this.txtRepoSpare.Multiline = true;
            this.txtRepoSpare.Name = "txtRepoSpare";
            this.txtRepoSpare.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRepoSpare.Size = new System.Drawing.Size(184, 41);
            this.txtRepoSpare.TabIndex = 3;
            // 
            // btnRepoAdd
            // 
            this.btnRepoAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRepoAdd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRepoAdd.Location = new System.Drawing.Point(389, 101);
            this.btnRepoAdd.Name = "btnRepoAdd";
            this.btnRepoAdd.Size = new System.Drawing.Size(44, 23);
            this.btnRepoAdd.TabIndex = 4;
            this.btnRepoAdd.Text = "＋";
            this.btnRepoAdd.UseVisualStyleBackColor = true;
            this.btnRepoAdd.Click += new System.EventHandler(this.btnRepoAdd_Click);
            // 
            // txtOtherSpare
            // 
            this.txtOtherSpare.Location = new System.Drawing.Point(181, 149);
            this.txtOtherSpare.Multiline = true;
            this.txtOtherSpare.Name = "txtOtherSpare";
            this.txtOtherSpare.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOtherSpare.Size = new System.Drawing.Size(184, 42);
            this.txtOtherSpare.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "使用其他备件：";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnFinish, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSuspend, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 227);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(579, 76);
            this.tableLayoutPanel1.TabIndex = 51;
            // 
            // btnFinish
            // 
            this.btnFinish.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFinish.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnFinish.Image = ((System.Drawing.Image)(resources.GetObject("btnFinish.Image")));
            this.btnFinish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinish.Location = new System.Drawing.Point(292, 3);
            this.btnFinish.Margin = new System.Windows.Forms.Padding(3, 3, 3, 35);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(87, 28);
            this.btnFinish.TabIndex = 51;
            this.btnFinish.Text = "   维修完成";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnSuspend
            // 
            this.btnSuspend.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSuspend.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSuspend.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSuspend.Image = ((System.Drawing.Image)(resources.GetObject("btnSuspend.Image")));
            this.btnSuspend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuspend.Location = new System.Drawing.Point(197, 3);
            this.btnSuspend.Margin = new System.Windows.Forms.Padding(3, 3, 3, 35);
            this.btnSuspend.Name = "btnSuspend";
            this.btnSuspend.Size = new System.Drawing.Size(89, 28);
            this.btnSuspend.TabIndex = 40;
            this.btnSuspend.Text = "   维修挂起";
            this.btnSuspend.UseVisualStyleBackColor = true;
            this.btnSuspend.Click += new System.EventHandler(this.btnSuspend_Click);
            // 
            // btnRepoRemove
            // 
            this.btnRepoRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRepoRemove.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRepoRemove.ForeColor = System.Drawing.Color.Red;
            this.btnRepoRemove.Location = new System.Drawing.Point(446, 101);
            this.btnRepoRemove.Name = "btnRepoRemove";
            this.btnRepoRemove.Size = new System.Drawing.Size(44, 23);
            this.btnRepoRemove.TabIndex = 54;
            this.btnRepoRemove.Text = "－";
            this.btnRepoRemove.UseVisualStyleBackColor = true;
            this.btnRepoRemove.Click += new System.EventHandler(this.btnRepoRemove_Click);
            // 
            // btn
            // 
            this.btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn.ForeColor = System.Drawing.Color.Red;
            this.btn.Location = new System.Drawing.Point(446, 159);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(44, 23);
            this.btn.TabIndex = 56;
            this.btn.Text = "－";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btnOtherRemove_Click);
            // 
            // btnOtherAdd
            // 
            this.btnOtherAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOtherAdd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOtherAdd.Location = new System.Drawing.Point(389, 159);
            this.btnOtherAdd.Name = "btnOtherAdd";
            this.btnOtherAdd.Size = new System.Drawing.Size(44, 23);
            this.btnOtherAdd.TabIndex = 55;
            this.btnOtherAdd.Text = "＋";
            this.btnOtherAdd.UseVisualStyleBackColor = true;
            this.btnOtherAdd.Click += new System.EventHandler(this.btnOtherAdd_Click);
            // 
            // RepairOperatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 303);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.btnOtherAdd);
            this.Controls.Add(this.btnRepoRemove);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txtOtherSpare);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRepoAdd);
            this.Controls.Add(this.txtRepoSpare);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboSerialNum);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RepairOperatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工具维修";
            this.Load += new System.EventHandler(this.RepairOperatorForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSerialNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRepoSpare;
        private System.Windows.Forms.Button btnRepoAdd;
        private System.Windows.Forms.TextBox txtOtherSpare;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnSuspend;
        private System.Windows.Forms.Button btnRepoRemove;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Button btnOtherAdd;
    }
}