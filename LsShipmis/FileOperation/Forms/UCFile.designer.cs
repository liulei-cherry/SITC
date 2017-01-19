namespace FileOperation.Forms
{
    partial class UCFile
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
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.导出文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件下发ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.重命名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtSize = new System.Windows.Forms.Label();
            this.txtKeyWords = new CommonViewer.TextBoxEx();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.optDate = new System.Windows.Forms.Label();
            this.Operator = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtshipInfo = new System.Windows.Forms.Label();
            this.FileList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuAdd,
            this.导出文件ToolStripMenuItem,
            this.文件下发ToolStripMenuItem,
            this.ToolStripMenuEdit,
            this.toolStripMenuItem1,
            this.重命名ToolStripMenuItem,
            this.ToolStripMenuDelete});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(123, 142);
            // 
            // ToolStripMenuAdd
            // 
            this.ToolStripMenuAdd.Name = "ToolStripMenuAdd";
            this.ToolStripMenuAdd.Size = new System.Drawing.Size(122, 22);
            this.ToolStripMenuAdd.Text = "导入文件";
            this.ToolStripMenuAdd.Click += new System.EventHandler(this.ToolStripMenuAdd_Click);
            // 
            // 导出文件ToolStripMenuItem
            // 
            this.导出文件ToolStripMenuItem.Name = "导出文件ToolStripMenuItem";
            this.导出文件ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.导出文件ToolStripMenuItem.Text = "导出文件";
            this.导出文件ToolStripMenuItem.Click += new System.EventHandler(this.导出文件ToolStripMenuItem_Click);
            // 
            // 文件下发ToolStripMenuItem
            // 
            this.文件下发ToolStripMenuItem.Name = "文件下发ToolStripMenuItem";
            this.文件下发ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.文件下发ToolStripMenuItem.Text = "文件下发";
            this.文件下发ToolStripMenuItem.Click += new System.EventHandler(this.文件下发ToolStripMenuItem_Click);
            // 
            // ToolStripMenuEdit
            // 
            this.ToolStripMenuEdit.Name = "ToolStripMenuEdit";
            this.ToolStripMenuEdit.Size = new System.Drawing.Size(122, 22);
            this.ToolStripMenuEdit.Text = "修改属性";
            this.ToolStripMenuEdit.Click += new System.EventHandler(this.ToolStripMenuItem_Click_1);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(119, 6);
            // 
            // 重命名ToolStripMenuItem
            // 
            this.重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            this.重命名ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.重命名ToolStripMenuItem.Text = "重命名";
            this.重命名ToolStripMenuItem.Click += new System.EventHandler(this.重命名ToolStripMenuItem_Click);
            // 
            // ToolStripMenuDelete
            // 
            this.ToolStripMenuDelete.Name = "ToolStripMenuDelete";
            this.ToolStripMenuDelete.Size = new System.Drawing.Size(122, 22);
            this.ToolStripMenuDelete.Text = "删除";
            this.ToolStripMenuDelete.Click += new System.EventHandler(this.ToolStripMenuDelete_Click);
            // 
            // imageListSmall
            // 
            this.imageListSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageListSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.tableLayoutPanel1);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(3, 17);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(605, 130);
            this.pnlBottom.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.txtSize, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtKeyWords, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.optDate, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.Operator, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtshipInfo, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(605, 130);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(369, 0);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(98, 25);
            this.txtSize.TabIndex = 14;
            this.txtSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtKeyWords
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtKeyWords, 3);
            this.txtKeyWords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKeyWords.Location = new System.Drawing.Point(69, 29);
            this.txtKeyWords.Multiline = true;
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.ReadOnly = true;
            this.txtKeyWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKeyWords.Size = new System.Drawing.Size(533, 64);
            this.txtKeyWords.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(307, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 26);
            this.label8.TabIndex = 7;
            this.label8.Text = "文件大小";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(307, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 34);
            this.label4.TabIndex = 3;
            this.label4.Text = "操作日期";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 34);
            this.label7.TabIndex = 6;
            this.label7.Text = "维护者";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 70);
            this.label5.TabIndex = 4;
            this.label5.Text = "摘要";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // optDate
            // 
            this.optDate.AutoSize = true;
            this.optDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optDate.Location = new System.Drawing.Point(369, 96);
            this.optDate.Name = "optDate";
            this.optDate.Size = new System.Drawing.Size(233, 34);
            this.optDate.TabIndex = 12;
            this.optDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Operator
            // 
            this.Operator.AutoSize = true;
            this.Operator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Operator.Location = new System.Drawing.Point(69, 96);
            this.Operator.Name = "Operator";
            this.Operator.Size = new System.Drawing.Size(232, 34);
            this.Operator.TabIndex = 13;
            this.Operator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 26);
            this.label1.TabIndex = 15;
            this.label1.Text = "所属船舶";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtshipInfo
            // 
            this.txtshipInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtshipInfo.Location = new System.Drawing.Point(69, 0);
            this.txtshipInfo.Name = "txtshipInfo";
            this.txtshipInfo.Size = new System.Drawing.Size(232, 26);
            this.txtshipInfo.TabIndex = 14;
            this.txtshipInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FileList
            // 
            this.FileList.AllowDrop = true;
            this.FileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.FileList.ContextMenuStrip = this.contextMenuStrip;
            this.FileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileList.FullRowSelect = true;
            this.FileList.LabelEdit = true;
            this.FileList.Location = new System.Drawing.Point(3, 17);
            this.FileList.Name = "FileList";
            this.FileList.ShowItemToolTips = true;
            this.FileList.Size = new System.Drawing.Size(605, 310);
            this.FileList.TabIndex = 1;
            this.FileList.UseCompatibleStateImageBehavior = false;
            this.FileList.View = System.Windows.Forms.View.Details;
            this.FileList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FileList_MouseDoubleClick);
            this.FileList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.FileList_AfterLabelEdit);
            this.FileList.Click += new System.EventHandler(this.FileList_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 330;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "大小";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "类型";
            this.columnHeader3.Width = 160;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "修改日期";
            this.columnHeader4.Width = 120;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2MinSize = 150;
            this.splitContainer1.Size = new System.Drawing.Size(611, 484);
            this.splitContainer1.SplitterDistance = 330;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FileList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 330);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "目录中的文件情况";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlBottom);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(611, 150);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "所选文件属性";
            // 
            // UCFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UCFile";
            this.Size = new System.Drawing.Size(611, 484);
            this.Load += new System.EventHandler(this.UCFile_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        public System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label txtSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label optDate;
        private System.Windows.Forms.Label Operator;
        public System.Windows.Forms.ListView FileList;
        public System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.ColumnHeader columnHeader2;
        public System.Windows.Forms.ColumnHeader columnHeader3;
        public System.Windows.Forms.ColumnHeader columnHeader4;
        public System.Windows.Forms.ToolStripMenuItem ToolStripMenuAdd;
        public System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        public System.Windows.Forms.ToolStripMenuItem ToolStripMenuDelete;
        public System.Windows.Forms.ToolStripMenuItem ToolStripMenuEdit;
        private System.Windows.Forms.ToolStripMenuItem 文件下发ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重命名ToolStripMenuItem;
        private CommonViewer.TextBoxEx txtKeyWords;
        private System.Windows.Forms.ToolStripMenuItem 导出文件ToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtshipInfo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;

    }
}
