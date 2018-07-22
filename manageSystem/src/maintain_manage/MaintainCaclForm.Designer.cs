namespace manageSystem.src.maintain_manage
{
    partial class MaintainCaclForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtHarvestOfYear = new System.Windows.Forms.TextBox();
            this.txtTimesOfOnce = new System.Windows.Forms.TextBox();
            this.btnCalc = new System.Windows.Forms.Button();
            this.txtTotalTimes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nudCycle = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudCycle)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "产量（个/年度）   ：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "工位拧紧次数（次）：";
            // 
            // txtHarvestOfYear
            // 
            this.txtHarvestOfYear.Location = new System.Drawing.Point(398, 126);
            this.txtHarvestOfYear.Name = "txtHarvestOfYear";
            this.txtHarvestOfYear.Size = new System.Drawing.Size(126, 21);
            this.txtHarvestOfYear.TabIndex = 2;
            // 
            // txtTimesOfOnce
            // 
            this.txtTimesOfOnce.Location = new System.Drawing.Point(398, 165);
            this.txtTimesOfOnce.Name = "txtTimesOfOnce";
            this.txtTimesOfOnce.Size = new System.Drawing.Size(126, 21);
            this.txtTimesOfOnce.TabIndex = 3;
            // 
            // btnCalc
            // 
            this.btnCalc.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCalc.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnCalc.Location = new System.Drawing.Point(314, 309);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 23);
            this.btnCalc.TabIndex = 4;
            this.btnCalc.Text = "计算";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // txtTotalTimes
            // 
            this.txtTotalTimes.Location = new System.Drawing.Point(398, 247);
            this.txtTotalTimes.Name = "txtTotalTimes";
            this.txtTotalTimes.ReadOnly = true;
            this.txtTotalTimes.Size = new System.Drawing.Size(126, 21);
            this.txtTotalTimes.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 251);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "累计拧紧次数（次）：";
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnClear.Location = new System.Drawing.Point(407, 309);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Location = new System.Drawing.Point(533, 255);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(0, 12);
            this.lblHint.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "推荐保养周期（月）：";
            // 
            // nudCycle
            // 
            this.nudCycle.Location = new System.Drawing.Point(398, 208);
            this.nudCycle.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCycle.Name = "nudCycle";
            this.nudCycle.Size = new System.Drawing.Size(126, 21);
            this.nudCycle.TabIndex = 10;
            this.nudCycle.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MaintainCaclForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 422);
            this.Controls.Add(this.nudCycle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtTotalTimes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.txtTimesOfOnce);
            this.Controls.Add(this.txtHarvestOfYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MaintainCaclForm";
            this.Text = "MaintainCaclForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudCycle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHarvestOfYear;
        private System.Windows.Forms.TextBox txtTimesOfOnce;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.TextBox txtTotalTimes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudCycle;
    }
}