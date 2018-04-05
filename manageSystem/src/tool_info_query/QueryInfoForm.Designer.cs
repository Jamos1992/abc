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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("单个序列号查询");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("多个序列号查询");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("根据型号查询");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryInfoForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewQuery = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            treeNode1.Name = "节点0";
            treeNode1.Text = "单个序列号查询";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "节点1";
            treeNode2.Text = "多个序列号查询";
            treeNode3.ImageIndex = 2;
            treeNode3.Name = "节点2";
            treeNode3.Text = "根据型号查询";
            this.treeViewQuery.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeViewQuery;
        private System.Windows.Forms.ImageList imageList1;
    }
}