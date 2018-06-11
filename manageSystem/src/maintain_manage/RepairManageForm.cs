using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using BLL;
using Model;
using Util;

namespace manageSystem.src.maintain_manage
{
    public partial class RepairManageForm : Form
    {
        private MaintainInfoManage maintainInfoManage = new MaintainInfoManage();
        public static string ToolSerialName;
        public static string Status;
        public RepairManageForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            saveFileDialog1.Filter = "Excel文件(*.xls, *.xlsx)|*.xls;*.xlsx";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoGenerateColumns = false;
            DataGridViewDisableButtonColumn column1 = new DataGridViewDisableButtonColumn();
            column1.Name = "ActionCol";
            column1.HeaderText = "操作";
            column1.Text = "维修";
            column1.UseColumnTextForButtonValue = true;
            column1.FlatStyle = FlatStyle.Popup;
            column1.Width = 80;
            dataGridView1.Columns.Add(column1);
        }

        private MaintainManageInfo[] GetMaintainManageInfoFromGrid()
        {
            MaintainManageInfo[] maintainManageInfo = new MaintainManageInfo[] { };
            List<MaintainManageInfo> ktls = maintainManageInfo.ToList();
            //遍历 DataGridView 所有行
            int row = dataGridView1.Rows.Count;//得到总行数    
            int cell = dataGridView1.Rows[0].Cells.Count;//得到总列数
            for (int i = 0; i < row; i++)//得到总行数并在之内循环    
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].EditedFormattedValue))
                {
                    ktls.Add(new MaintainManageInfo
                    {
                        ToolModeName = dataGridView1.Rows[i].Cells[1].Value.ToString(),
                        ToolSerialName = dataGridView1.Rows[i].Cells[2].Value.ToString(),
                        SendFixTime = dataGridView1.Rows[i].Cells[3].Value.ToString(),
                        Status = dataGridView1.Rows[i].Cells[4].Value.ToString(),
                        Detail = dataGridView1.Rows[i].Cells[5].Value.ToString(),
                    });
                }
            }
            return ktls.ToArray();
        }
        private void BindData2Grid(List<OutputStruct> list)
        {
            dataGridView1.DataSource = list;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.ClearSelection();
            //if (dataGridView1.Rows.Count > 0) dataGridView1.Rows[0].Selected = false;
            setRepairBtnDisable();
        }

        private void RepairManageForm_Load(object sender, EventArgs e)
        {
            List<OutputStruct> list = maintainInfoManage.GetAllBreakToolsBySql("select ToolSerialName,ToolModeName,SendFixTime,Status,Detail from MaintainManageInfo order by SendFixTime desc");
            if (list == null) return;
            BindData2Grid(list);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<OutputStruct> list = new List<OutputStruct>();
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                list = maintainInfoManage.GetAllBreakToolsBySql("select ToolSerialName,ToolModeName,SendFixTime,Status,Detail from MaintainManageInfo order by SendFixTime desc");
            }
            else
            {
                string sql = "select ToolSerialName,ToolModeName,SendFixTime,Status,Detail from MaintainManageInfo where";
                if (radioButton1.Checked) sql += " Status='" + MaintainDeclare.Repairing + "'";
                if (radioButton2.Checked) sql += " Status='" + MaintainDeclare.Suspend + "'";
                if (radioButton3.Checked) sql += " Status='" + MaintainDeclare.RepairFinished + "'";
                sql += " order by SendFixTime desc";
                list = maintainInfoManage.GetAllBreakToolsBySql(sql);
            }
            if (list == null)
            {
                dataGridView1.DataSource = new List<OutputStruct>();
                MessageBox.Show("记录不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            BindData2Grid(list);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("没有记录可以导出,请先查询！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string msg = maintainInfoManage.ExportBatchData2Excel(saveFileDialog1.FileName, GetMaintainManageInfoFromGrid());
                MessageBox.Show(msg);
            }
        }

        private void gotoRepair_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolSerialName = getSerialNumFromGrid();
            Status = getStatusFromGrid();
            RepairOperatorForm repairOperatorForm = new RepairOperatorForm();
            if (repairOperatorForm.ShowDialog() == DialogResult.OK)
            {
                button1_Click(sender, e);
                Show();
            }
        }
        private string getSerialNumFromGrid()
        {
            if (dataGridView1.SelectedRows.Count == 0) return null;
            return dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private string getStatusFromGrid()
        {
            if (dataGridView1.SelectedRows.Count == 0) return null;
            return dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (getStatusFromGrid() == MaintainDeclare.RepairFinished)
            {
                contextMenuStrip1.Enabled = false;
            }
            else
            {
                contextMenuStrip1.Enabled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1)
            {
                DataGridViewDisableButtonCell btnCell =  dataGridView1.CurrentCell as DataGridViewDisableButtonCell;
                if(dataGridView1.Rows[e.RowIndex].Cells["StatusCol"].Value.ToString() == MaintainDeclare.RepairFinished)
                {
                    btnCell.Enabled = false;
                    return;
                }
                if (btnCell != null)
                {
                    ToolSerialName = getSerialNumFromGrid();
                    Status = getStatusFromGrid();
                    RepairOperatorForm repairOperatorForm = new RepairOperatorForm();
                    if (repairOperatorForm.ShowDialog() == DialogResult.OK)
                    {
                        button1_Click(sender, e);
                        Show();
                    }
                }
            }
        }

        private void setRepairBtnDisable()
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                DataGridViewDisableButtonCell btnCell = dataGridView1.Rows[i].Cells["ActionCol"] as DataGridViewDisableButtonCell;
                if (dataGridView1.Rows[i].Cells["StatusCol"].Value.ToString() == MaintainDeclare.RepairFinished)
                {
                    btnCell.Enabled = false;
                }
            }
        }

        private void RepairManageForm_Resize(object sender, EventArgs e)
        {
            setRepairBtnDisable();
        }
    }

    public class DataGridViewDisableButtonColumn : DataGridViewButtonColumn
    {
        public DataGridViewDisableButtonColumn()
        {
            this.CellTemplate = new DataGridViewDisableButtonCell();
        }
    }

    public class DataGridViewDisableButtonCell : DataGridViewButtonCell
    {
        private bool enabledValue;
        public bool Enabled
        {
            get
            {
                return enabledValue;
            }
            set
            {
                enabledValue = value;
            }
        }

        // Override the Clone method so that the Enabled property is copied.
        public override object Clone()
        {
            DataGridViewDisableButtonCell cell =
                (DataGridViewDisableButtonCell)base.Clone();
            cell.Enabled = this.Enabled;
            return cell;
        }

        // By default, enable the button cell.
        public DataGridViewDisableButtonCell()
        {
            this.enabledValue = true;
        }

        protected override void Paint(Graphics graphics,
            Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates elementState, object value,
            object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            // The button cell is disabled, so paint the border,  
            // background, and disabled button for the cell.
            if (!this.enabledValue)
            {
                // Draw the cell background, if specified.
                if ((paintParts & DataGridViewPaintParts.Background) ==
                    DataGridViewPaintParts.Background)
                {
                    SolidBrush cellBackground =
                        new SolidBrush(cellStyle.BackColor);
                    graphics.FillRectangle(cellBackground, cellBounds);
                    cellBackground.Dispose();
                }

                // Draw the cell borders, if specified.
                if ((paintParts & DataGridViewPaintParts.Border) ==
                    DataGridViewPaintParts.Border)
                {
                    PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                        advancedBorderStyle);
                }

                // Calculate the area in which to draw the button.
                Rectangle buttonArea = cellBounds;
                Rectangle buttonAdjustment =
                    this.BorderWidths(advancedBorderStyle);
                buttonArea.X += buttonAdjustment.X;
                buttonArea.Y += buttonAdjustment.Y;
                buttonArea.Height -= buttonAdjustment.Height;
                buttonArea.Width -= buttonAdjustment.Width;

                // Draw the disabled button.                
                ButtonRenderer.DrawButton(graphics, buttonArea,
                    PushButtonState.Disabled);

                // Draw the disabled button text. 
                if (this.FormattedValue is String)
                {
                    TextRenderer.DrawText(graphics,
                        (string)this.FormattedValue,
                        this.DataGridView.Font,
                        buttonArea, SystemColors.GrayText);
                }
            }
            else
            {
                // The button cell is enabled, so let the base class 
                // handle the painting.
                base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                    elementState, value, formattedValue, errorText,
                    cellStyle, advancedBorderStyle, paintParts);
            }
        }
    }
}
