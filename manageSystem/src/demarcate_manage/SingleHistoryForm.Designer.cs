﻿namespace manageSystem.src.demarcate_manage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.NumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DemarcateNumCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CycleCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlanDemaTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualDemaTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValidityCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckManCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TorqueMinCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TorqueMaxCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccuracyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SectionCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkstationCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QualityAssureDateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaintainContractStyleCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaintainContractDateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RepairTimesCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemarkCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.ValidityCol,
            this.CheckManCol,
            this.ModelCol,
            this.CategoryCol,
            this.NameCol,
            this.TorqueMinCol,
            this.TorqueMaxCol,
            this.AccuracyCol,
            this.SectionCol,
            this.WorkstationCol,
            this.StatusCol,
            this.QualityAssureDateCol,
            this.MaintainContractStyleCol,
            this.MaintainContractDateCol,
            this.RepairTimesCol,
            this.RemarkCol,
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
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
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
            this.NumCol.DataPropertyName = "ID";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.NumCol.DefaultCellStyle = dataGridViewCellStyle2;
            this.NumCol.HeaderText = "编号";
            this.NumCol.Name = "NumCol";
            this.NumCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NumCol.Width = 60;
            // 
            // DemarcateNumCol
            // 
            this.DemarcateNumCol.DataPropertyName = "DemarcateNum";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DemarcateNumCol.DefaultCellStyle = dataGridViewCellStyle3;
            this.DemarcateNumCol.HeaderText = "标定序列号";
            this.DemarcateNumCol.Name = "DemarcateNumCol";
            this.DemarcateNumCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TimeCol
            // 
            this.TimeCol.DataPropertyName = "SerialNum";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TimeCol.DefaultCellStyle = dataGridViewCellStyle4;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CycleCol.DefaultCellStyle = dataGridViewCellStyle5;
            this.CycleCol.HeaderText = "周期";
            this.CycleCol.Name = "CycleCol";
            this.CycleCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CycleCol.Width = 60;
            // 
            // PlanDemaTime
            // 
            this.PlanDemaTime.DataPropertyName = "LastTime";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PlanDemaTime.DefaultCellStyle = dataGridViewCellStyle6;
            this.PlanDemaTime.HeaderText = "上次标定时间";
            this.PlanDemaTime.Name = "PlanDemaTime";
            this.PlanDemaTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ActualDemaTime
            // 
            this.ActualDemaTime.DataPropertyName = "DemarcateTime";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ActualDemaTime.DefaultCellStyle = dataGridViewCellStyle7;
            this.ActualDemaTime.HeaderText = "标定时间";
            this.ActualDemaTime.Name = "ActualDemaTime";
            this.ActualDemaTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ValidityCol
            // 
            this.ValidityCol.DataPropertyName = "NextTime";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ValidityCol.DefaultCellStyle = dataGridViewCellStyle8;
            this.ValidityCol.HeaderText = "有效期";
            this.ValidityCol.Name = "ValidityCol";
            this.ValidityCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CheckManCol
            // 
            this.CheckManCol.DataPropertyName = "CheckMan";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CheckManCol.DefaultCellStyle = dataGridViewCellStyle9;
            this.CheckManCol.HeaderText = "检查员";
            this.CheckManCol.Name = "CheckManCol";
            this.CheckManCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ModelCol
            // 
            this.ModelCol.DataPropertyName = "Model";
            this.ModelCol.HeaderText = "工具型号";
            this.ModelCol.Name = "ModelCol";
            this.ModelCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CategoryCol
            // 
            this.CategoryCol.DataPropertyName = "Category";
            this.CategoryCol.HeaderText = "工具类别";
            this.CategoryCol.Name = "CategoryCol";
            this.CategoryCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NameCol
            // 
            this.NameCol.DataPropertyName = "Name";
            this.NameCol.HeaderText = "工具名称";
            this.NameCol.Name = "NameCol";
            this.NameCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TorqueMinCol
            // 
            this.TorqueMinCol.DataPropertyName = "TorqueMin";
            this.TorqueMinCol.HeaderText = "标定扭矩下限";
            this.TorqueMinCol.Name = "TorqueMinCol";
            this.TorqueMinCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TorqueMaxCol
            // 
            this.TorqueMaxCol.DataPropertyName = "TorqueMax";
            this.TorqueMaxCol.HeaderText = "标定扭矩上限";
            this.TorqueMaxCol.Name = "TorqueMaxCol";
            this.TorqueMaxCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // AccuracyCol
            // 
            this.AccuracyCol.DataPropertyName = "Accuracy";
            this.AccuracyCol.HeaderText = "精度";
            this.AccuracyCol.Name = "AccuracyCol";
            this.AccuracyCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.AccuracyCol.Width = 60;
            // 
            // SectionCol
            // 
            this.SectionCol.DataPropertyName = "Section";
            this.SectionCol.HeaderText = "工段";
            this.SectionCol.Name = "SectionCol";
            this.SectionCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SectionCol.Width = 70;
            // 
            // WorkstationCol
            // 
            this.WorkstationCol.DataPropertyName = "Workstation";
            this.WorkstationCol.HeaderText = "工位";
            this.WorkstationCol.Name = "WorkstationCol";
            this.WorkstationCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.WorkstationCol.Width = 70;
            // 
            // StatusCol
            // 
            this.StatusCol.DataPropertyName = "Status";
            this.StatusCol.HeaderText = "工具状态";
            this.StatusCol.Name = "StatusCol";
            this.StatusCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // QualityAssureDateCol
            // 
            this.QualityAssureDateCol.DataPropertyName = "QualityAssureDate";
            this.QualityAssureDateCol.HeaderText = "质保期至";
            this.QualityAssureDateCol.Name = "QualityAssureDateCol";
            this.QualityAssureDateCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MaintainContractStyleCol
            // 
            this.MaintainContractStyleCol.DataPropertyName = "MaintainContractStyle";
            this.MaintainContractStyleCol.HeaderText = "保养合同类型";
            this.MaintainContractStyleCol.Name = "MaintainContractStyleCol";
            this.MaintainContractStyleCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MaintainContractDateCol
            // 
            this.MaintainContractDateCol.DataPropertyName = "MaintainContractDate";
            this.MaintainContractDateCol.HeaderText = "保养合同至";
            this.MaintainContractDateCol.Name = "MaintainContractDateCol";
            this.MaintainContractDateCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RepairTimesCol
            // 
            this.RepairTimesCol.DataPropertyName = "RepairTimes";
            this.RepairTimesCol.HeaderText = "维修次数";
            this.RepairTimesCol.Name = "RepairTimesCol";
            this.RepairTimesCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // RemarkCol
            // 
            this.RemarkCol.DataPropertyName = "Remark";
            this.RemarkCol.HeaderText = "备注信息";
            this.RemarkCol.Name = "RemarkCol";
            this.RemarkCol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.Load += new System.EventHandler(this.SingleHistoryForm_Load);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ValidityCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CheckManCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TorqueMinCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn TorqueMaxCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccuracyCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SectionCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkstationCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn QualityAssureDateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaintainContractStyleCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaintainContractDateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn RepairTimesCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn RemarkCol;
        private System.Windows.Forms.DataGridViewButtonColumn ActionCol;
    }
}