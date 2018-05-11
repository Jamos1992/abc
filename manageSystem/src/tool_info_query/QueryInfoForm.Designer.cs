namespace manageSystem
{
    partial class QueryInfoForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("单个序列号查询");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("多个序列号查询");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("根据型号查询");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryInfoForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewQuery = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.treeViewQuery);
            this.splitContainer1.Size = new System.Drawing.Size(800, 404);
            this.splitContainer1.SplitterDistance = 164;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeViewQuery
            // 
            this.treeViewQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewQuery.ImageIndex = 0;
            this.treeViewQuery.ImageList = this.imageList1;
            this.treeViewQuery.Location = new System.Drawing.Point(0, 0);
            this.treeViewQuery.Name = "treeViewQuery";
            treeNode4.Name = "节点0";
            treeNode4.Text = "单个序列号查询";
            treeNode5.Name = "节点1";
            treeNode5.Text = "多个序列号查询";
            treeNode6.Name = "节点2";
            treeNode6.Text = "根据型号查询";
            this.treeViewQuery.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            this.treeViewQuery.SelectedImageIndex = 0;
            this.treeViewQuery.Size = new System.Drawing.Size(164, 404);
            this.treeViewQuery.TabIndex = 2;
            this.treeViewQuery.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewQuery_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "table_tab_search.png");
            this.imageList1.Images.SetKeyName(1, "box_search.png");
            this.imageList1.Images.SetKeyName(2, "search_field.png");
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 181);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(164, 223);
            this.panel1.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(162, 222);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "\n操作说明：\n1、输入型号和序列号，点击“查询”；\n2、点击“修改”，对查询结果进行修改；\n3、点击“保存”，保存修改结果；\n4、点击“导出至excel表格”，查" +
    "询结果导出。";
            // 
            // QueryInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 404);
            this.Controls.Add(this.splitContainer1);
            this.Name = "QueryInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "工具信息查询";
            this.Load += new System.EventHandler(this.QueryInfoForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewQuery;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}