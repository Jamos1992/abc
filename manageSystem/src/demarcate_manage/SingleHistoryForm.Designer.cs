namespace manageSystem.src.demarcate_manage
{
    partial class SingleHistoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.NumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DemarcateNumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CycleCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlanDemaTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualDemaTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResultCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckManCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActionCol = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumCol,
            this.DemarcateNumCol,
            this.TimeCol,
            this.CycleCol,
            this.PlanDemaTime,
            this.ActualDemaTime,
            this.ResultCol,
            this.CheckManCol,
            this.ActionCol});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.Silver;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dataGridView1.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.dataGridView1.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(923, 391);
            this.dataGridView1.TabIndex = 39;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.dataGridViewButtonColumn1.HeaderText = "操作";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Text = "打印标签";
            this.dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn1.Width = 120;
            // 
            // NumCol
            // 
            this.NumCol.HeaderText = "编号";
            this.NumCol.Name = "NumCol";
            this.NumCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NumCol.Width = 60;
            // 
            // DemarcateNumCol
            // 
            this.DemarcateNumCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DemarcateNumCol.DataPropertyName = "DemarcateNum";
            this.DemarcateNumCol.HeaderText = "标定序列号";
            this.DemarcateNumCol.Name = "DemarcateNumCol";
            this.DemarcateNumCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TimeCol
            // 
            this.TimeCol.DataPropertyName = "SerialNum";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TimeCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.TimeCol.FillWeight = 30F;
            this.TimeCol.HeaderText = "工具序列号";
            this.TimeCol.Name = "TimeCol";
            this.TimeCol.ReadOnly = true;
            this.TimeCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TimeCol.Width = 120;
            // 
            // CycleCol
            // 
            this.CycleCol.DataPropertyName = "Cycle";
            this.CycleCol.HeaderText = "周期";
            this.CycleCol.Name = "CycleCol";
            this.CycleCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CycleCol.Width = 60;
            // 
            // PlanDemaTime
            // 
            this.PlanDemaTime.DataPropertyName = "LastTime";
            this.PlanDemaTime.HeaderText = "上次标定时间";
            this.PlanDemaTime.Name = "PlanDemaTime";
            this.PlanDemaTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlanDemaTime.Width = 120;
            // 
            // ActualDemaTime
            // 
            this.ActualDemaTime.DataPropertyName = "DemarcateTime";
            this.ActualDemaTime.HeaderText = "标定时间";
            this.ActualDemaTime.Name = "ActualDemaTime";
            this.ActualDemaTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ActualDemaTime.Width = 120;
            // 
            // ResultCol
            // 
            this.ResultCol.DataPropertyName = "NextTime";
            this.ResultCol.HeaderText = "有效期";
            this.ResultCol.Name = "ResultCol";
            this.ResultCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ResultCol.Width = 120;
            // 
            // CheckManCol
            // 
            this.CheckManCol.DataPropertyName = "CheckMan";
            this.CheckManCol.HeaderText = "检查员";
            this.CheckManCol.Name = "CheckManCol";
            this.CheckManCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ActionCol
            // 
            this.ActionCol.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ActionCol.HeaderText = "操作";
            this.ActionCol.Name = "ActionCol";
            this.ActionCol.Text = "打印标签";
            this.ActionCol.UseColumnTextForButtonValue = true;
            this.ActionCol.Width = 120;
            // 
            // SingleHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 391);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SingleHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SingleHistoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DemarcateNumCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CycleCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlanDemaTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualDemaTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResultCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckManCol;
        private System.Windows.Forms.DataGridViewButtonColumn ActionCol;
    }
}