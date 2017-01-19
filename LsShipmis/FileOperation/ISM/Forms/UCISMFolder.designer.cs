namespace FileOperation.ISM.Forms
{
    partial class UCISMFolder
    {
        /// <summary> 
        /// 必需的设计器变量。.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。.
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要.
        /// 使用代码编辑器修改此方法的内容。.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCISMFolder));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importFile = new System.Windows.Forms.ToolStripMenuItem();
            this.导出文件夹ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRefFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.下发文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator(); 
            this.addNewFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.rename = new System.Windows.Forms.ToolStripMenuItem();
            this.search = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.up = new System.Windows.Forms.ToolStripMenuItem();
            this.down = new System.Windows.Forms.ToolStripMenuItem();
            this.top = new System.Windows.Forms.ToolStripMenuItem();
            this.bottom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.delete = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.contextMenuStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFile,
            this.导出文件夹ToolStripMenuItem,
            this.mnuRefFiles,
            this.下发文件ToolStripMenuItem,
            this.toolStripMenuItem1, 
            this.addNewFolder,
            this.rename,
            this.search,
            this.toolStripMenuItem2,
            this.up,
            this.down,
            this.top,
            this.bottom,
            this.toolStripMenuItem3,
            this.delete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(149, 308);
            // 
            // importFile
            // 
            this.importFile.Name = "importFile";
            this.importFile.Size = new System.Drawing.Size(148, 22);
            this.importFile.Text = "导入文件";
            this.importFile.Click += new System.EventHandler(this.importFile_Click);
            // 
            // 导出文件夹ToolStripMenuItem
            // 
            this.导出文件夹ToolStripMenuItem.Name = "导出文件夹ToolStripMenuItem";
            this.导出文件夹ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.导出文件夹ToolStripMenuItem.Text = "导出文件夹";
            this.导出文件夹ToolStripMenuItem.Click += new System.EventHandler(this.导出文件夹ToolStripMenuItem_Click);
            // 
            // mnuRefFiles
            // 
            this.mnuRefFiles.Name = "mnuRefFiles";
            this.mnuRefFiles.Size = new System.Drawing.Size(148, 22);
            this.mnuRefFiles.Text = "引用已有文件";
            this.mnuRefFiles.Click += new System.EventHandler(this.mnuRefFiles_Click);
            // 
            // 下发文件ToolStripMenuItem
            // 
            this.下发文件ToolStripMenuItem.Name = "下发文件ToolStripMenuItem";
            this.下发文件ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.下发文件ToolStripMenuItem.Text = "文件下发";
            this.下发文件ToolStripMenuItem.Click += new System.EventHandler(this.下发文件ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(145, 6);
            // 
            // addNewFolder
            // 
            this.addNewFolder.Name = "addNewFolder";
            this.addNewFolder.Size = new System.Drawing.Size(148, 22);
            this.addNewFolder.Text = "新建文件夹";
            this.addNewFolder.Click += new System.EventHandler(this.新建文件夹ToolStripMenuItem_Click);
            // 
            // rename
            // 
            this.rename.Name = "rename";
            this.rename.Size = new System.Drawing.Size(148, 22);
            this.rename.Text = "重命名";
            this.rename.Click += new System.EventHandler(this.rename_Click);
            // 
            // search
            // 
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(148, 22);
            this.search.Text = "搜索";
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(145, 6);
            // 
            // up
            // 
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(148, 22);
            this.up.Text = "上移一位";
            this.up.Visible = false;
            // 
            // down
            // 
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(148, 22);
            this.down.Text = "下移一位";
            this.down.Visible = false;
            // 
            // top
            // 
            this.top.Name = "top";
            this.top.Size = new System.Drawing.Size(148, 22);
            this.top.Text = "移到顶部";
            this.top.Visible = false;
            // 
            // bottom
            // 
            this.bottom.Name = "bottom";
            this.bottom.Size = new System.Drawing.Size(148, 22);
            this.bottom.Text = "移到底部";
            this.bottom.Visible = false;
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(145, 6);
            this.toolStripMenuItem3.Visible = false;
            // 
            // delete
            // 
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(148, 22);
            this.delete.Text = "删除";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(269, 369);
            this.tabControl.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.TreeView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(261, 343);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ISM模板";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TreeView
            // 
            this.TreeView.AllowDrop = true;
            this.TreeView.ContextMenuStrip = this.contextMenuStrip;
            this.TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView.HotTracking = true;
            this.TreeView.ImageIndex = 0;
            this.TreeView.ImageList = this.imageList1;
            this.TreeView.LabelEdit = true;
            this.TreeView.Location = new System.Drawing.Point(3, 3);
            this.TreeView.Name = "TreeView";
            this.TreeView.SelectedImageIndex = 1;
            this.TreeView.Size = new System.Drawing.Size(255, 337);
            this.TreeView.TabIndex = 3;
            this.TreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.TreeView_AfterLabelEdit);
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Close.gif");
            this.imageList1.Images.SetKeyName(1, "Open.gif");
            this.imageList1.Images.SetKeyName(2, "ship.jpg");
            // 
            // UCISMFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "UCISMFolder";
            this.Size = new System.Drawing.Size(269, 369);
            this.contextMenuStrip.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem importFile;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1; 
        private System.Windows.Forms.ToolStripMenuItem rename;
        private System.Windows.Forms.ToolStripMenuItem search;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem up;
        private System.Windows.Forms.ToolStripMenuItem down;
        private System.Windows.Forms.ToolStripMenuItem top;
        private System.Windows.Forms.ToolStripMenuItem bottom;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem delete;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TreeView TreeView;
        public System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ToolStripMenuItem addNewFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuRefFiles;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem 导出文件夹ToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem 下发文件ToolStripMenuItem;
    }
}
