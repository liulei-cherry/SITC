namespace LSShipMis_Land.SysLs.Forms
{
    partial class FrmShipUserHead
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要.
        /// 使用代码编辑器修改此方法的内容。.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmShipUserHead));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bdNgMain = new System.Windows.Forms.BindingNavigator(this.components);
            this.bdNgCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bdNgMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bdNgPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bdNgSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bdNgMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bdNgAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgNewItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgOpenItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgSaveItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgCancelItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgPrintItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgRightSet = new System.Windows.Forms.ToolStripButton();
            this.bdNgClose = new System.Windows.Forms.ToolStripButton();
            this.bdNgPrintViewItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bdNgCutItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgCopyItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgPasteItem = new System.Windows.Forms.ToolStripButton();
            this.bdNgSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bdNgHelpItem = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvUser = new CommonViewer.UcDataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvShipHead = new CommonViewer.UcDataGridView();
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bindingSourceUser = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceShipHead = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdNgMain)).BeginInit();
            this.bdNgMain.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceShipHead)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.bdNgMain, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(692, 466);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // bdNgMain
            // 
            this.bdNgMain.AddNewItem = null;
            this.bdNgMain.CountItem = this.bdNgCountItem;
            this.bdNgMain.DeleteItem = null;
            this.bdNgMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bdNgMoveFirstItem,
            this.bdNgMovePreviousItem,
            this.bdNgSeparator,
            this.bdNgPositionItem,
            this.bdNgCountItem,
            this.bdNgSeparator1,
            this.bdNgMoveNextItem,
            this.bdNgMoveLastItem,
            this.bdNgSeparator2,
            this.bdNgAddNewItem,
            this.bdNgDeleteItem,
            this.bdNgNewItem,
            this.bdNgOpenItem,
            this.bdNgSaveItem,
            this.bdNgCancelItem,
            this.bdNgPrintItem,
            this.bdNgRightSet,
            this.bdNgClose,
            this.bdNgPrintViewItem,
            this.bdNgSeparator3,
            this.bdNgCutItem,
            this.bdNgCopyItem,
            this.bdNgPasteItem,
            this.bdNgSeparator4,
            this.bdNgHelpItem});
            this.bdNgMain.Location = new System.Drawing.Point(0, 0);
            this.bdNgMain.MoveFirstItem = this.bdNgMoveFirstItem;
            this.bdNgMain.MoveLastItem = this.bdNgMoveLastItem;
            this.bdNgMain.MoveNextItem = this.bdNgMoveNextItem;
            this.bdNgMain.MovePreviousItem = this.bdNgMovePreviousItem;
            this.bdNgMain.Name = "bdNgMain";
            this.bdNgMain.PositionItem = this.bdNgPositionItem;
            this.bdNgMain.Size = new System.Drawing.Size(692, 25);
            this.bdNgMain.TabIndex = 8;
            this.bdNgMain.Text = "bindingNavigator1";
            // 
            // bdNgCountItem
            // 
            this.bdNgCountItem.Name = "bdNgCountItem";
            this.bdNgCountItem.Size = new System.Drawing.Size(35, 22);
            this.bdNgCountItem.Text = "/ {0}";
            this.bdNgCountItem.ToolTipText = "总项数";
            // 
            // bdNgMoveFirstItem
            // 
            this.bdNgMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgMoveFirstItem.Image")));
            this.bdNgMoveFirstItem.Name = "bdNgMoveFirstItem";
            this.bdNgMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bdNgMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgMoveFirstItem.Text = "移到第一条记录";
            // 
            // bdNgMovePreviousItem
            // 
            this.bdNgMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgMovePreviousItem.Image")));
            this.bdNgMovePreviousItem.Name = "bdNgMovePreviousItem";
            this.bdNgMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bdNgMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgMovePreviousItem.Text = "移到上一条记录";
            // 
            // bdNgSeparator
            // 
            this.bdNgSeparator.Name = "bdNgSeparator";
            this.bdNgSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bdNgPositionItem
            // 
            this.bdNgPositionItem.AccessibleName = "位置";
            this.bdNgPositionItem.AutoSize = false;
            this.bdNgPositionItem.Name = "bdNgPositionItem";
            this.bdNgPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bdNgPositionItem.Text = "0";
            this.bdNgPositionItem.ToolTipText = "当前位置";
            // 
            // bdNgSeparator1
            // 
            this.bdNgSeparator1.Name = "bdNgSeparator1";
            this.bdNgSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bdNgMoveNextItem
            // 
            this.bdNgMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgMoveNextItem.Image")));
            this.bdNgMoveNextItem.Name = "bdNgMoveNextItem";
            this.bdNgMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bdNgMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgMoveNextItem.Text = "移到下一条记录";
            // 
            // bdNgMoveLastItem
            // 
            this.bdNgMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgMoveLastItem.Image")));
            this.bdNgMoveLastItem.Name = "bdNgMoveLastItem";
            this.bdNgMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bdNgMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgMoveLastItem.Text = "移到最后一条记录";
            // 
            // bdNgSeparator2
            // 
            this.bdNgSeparator2.Name = "bdNgSeparator2";
            this.bdNgSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // bdNgAddNewItem
            // 
            this.bdNgAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgAddNewItem.Image")));
            this.bdNgAddNewItem.Name = "bdNgAddNewItem";
            this.bdNgAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bdNgAddNewItem.Size = new System.Drawing.Size(67, 22);
            this.bdNgAddNewItem.Text = "新添(&A)";
            this.bdNgAddNewItem.Visible = false;
            // 
            // bdNgDeleteItem
            // 
            this.bdNgDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgDeleteItem.Image")));
            this.bdNgDeleteItem.Name = "bdNgDeleteItem";
            this.bdNgDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bdNgDeleteItem.Size = new System.Drawing.Size(67, 22);
            this.bdNgDeleteItem.Text = "删除(&D)";
            this.bdNgDeleteItem.Visible = false;
            // 
            // bdNgNewItem
            // 
            this.bdNgNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgNewItem.Image")));
            this.bdNgNewItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bdNgNewItem.Name = "bdNgNewItem";
            this.bdNgNewItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgNewItem.Text = "新建(&N)";
            this.bdNgNewItem.Visible = false;
            // 
            // bdNgOpenItem
            // 
            this.bdNgOpenItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgOpenItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgOpenItem.Image")));
            this.bdNgOpenItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bdNgOpenItem.Name = "bdNgOpenItem";
            this.bdNgOpenItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgOpenItem.Text = "打开(&O)";
            this.bdNgOpenItem.Visible = false;
            // 
            // bdNgSaveItem
            // 
            this.bdNgSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgSaveItem.Image")));
            this.bdNgSaveItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bdNgSaveItem.Name = "bdNgSaveItem";
            this.bdNgSaveItem.Size = new System.Drawing.Size(67, 22);
            this.bdNgSaveItem.Text = "保存(&S)";
            this.bdNgSaveItem.Click += new System.EventHandler(this.bdNgSaveItem_Click);
            // 
            // bdNgCancelItem
            // 
            this.bdNgCancelItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgCancelItem.Image")));
            this.bdNgCancelItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bdNgCancelItem.Name = "bdNgCancelItem";
            this.bdNgCancelItem.Size = new System.Drawing.Size(67, 22);
            this.bdNgCancelItem.Text = "取消(&R)";
            this.bdNgCancelItem.Click += new System.EventHandler(this.bdNgCancelItem_Click);
            // 
            // bdNgPrintItem
            // 
            this.bdNgPrintItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgPrintItem.Image")));
            this.bdNgPrintItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bdNgPrintItem.Name = "bdNgPrintItem";
            this.bdNgPrintItem.Size = new System.Drawing.Size(67, 22);
            this.bdNgPrintItem.Text = "打印(&P)";
            this.bdNgPrintItem.Visible = false;
            // 
            // bdNgRightSet
            // 
            this.bdNgRightSet.Image = ((System.Drawing.Image)(resources.GetObject("bdNgRightSet.Image")));
            this.bdNgRightSet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bdNgRightSet.Name = "bdNgRightSet";
            this.bdNgRightSet.Size = new System.Drawing.Size(73, 22);
            this.bdNgRightSet.Text = "权限设置";
            this.bdNgRightSet.ToolTipText = "权限设置";
            this.bdNgRightSet.Visible = false;
            this.bdNgRightSet.Click += new System.EventHandler(this.bdNgRightSet_Click);
            // 
            // bdNgClose
            // 
            this.bdNgClose.Image = global::LSShipMis_Land.Properties.Resources.close;
            this.bdNgClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bdNgClose.Name = "bdNgClose";
            this.bdNgClose.Size = new System.Drawing.Size(67, 22);
            this.bdNgClose.Text = "关闭(&C)";
            this.bdNgClose.ToolTipText = "关闭";
            this.bdNgClose.Click += new System.EventHandler(this.bdNgClose_Click);
            // 
            // bdNgPrintViewItem
            // 
            this.bdNgPrintViewItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgPrintViewItem.Image")));
            this.bdNgPrintViewItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bdNgPrintViewItem.Name = "bdNgPrintViewItem";
            this.bdNgPrintViewItem.Size = new System.Drawing.Size(49, 22);
            this.bdNgPrintViewItem.Text = "预览";
            this.bdNgPrintViewItem.Visible = false;
            // 
            // bdNgSeparator3
            // 
            this.bdNgSeparator3.Name = "bdNgSeparator3";
            this.bdNgSeparator3.Size = new System.Drawing.Size(6, 25);
            this.bdNgSeparator3.Visible = false;
            // 
            // bdNgCutItem
            // 
            this.bdNgCutItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgCutItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgCutItem.Image")));
            this.bdNgCutItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bdNgCutItem.Name = "bdNgCutItem";
            this.bdNgCutItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgCutItem.Text = "剪切(&U)";
            this.bdNgCutItem.Visible = false;
            // 
            // bdNgCopyItem
            // 
            this.bdNgCopyItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgCopyItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgCopyItem.Image")));
            this.bdNgCopyItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bdNgCopyItem.Name = "bdNgCopyItem";
            this.bdNgCopyItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgCopyItem.Text = "复制(&C)";
            this.bdNgCopyItem.Visible = false;
            // 
            // bdNgPasteItem
            // 
            this.bdNgPasteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgPasteItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgPasteItem.Image")));
            this.bdNgPasteItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bdNgPasteItem.Name = "bdNgPasteItem";
            this.bdNgPasteItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgPasteItem.Text = "粘贴(&P)";
            this.bdNgPasteItem.Visible = false;
            // 
            // bdNgSeparator4
            // 
            this.bdNgSeparator4.Name = "bdNgSeparator4";
            this.bdNgSeparator4.Size = new System.Drawing.Size(6, 25);
            this.bdNgSeparator4.Visible = false;
            // 
            // bdNgHelpItem
            // 
            this.bdNgHelpItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgHelpItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgHelpItem.Image")));
            this.bdNgHelpItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bdNgHelpItem.Name = "bdNgHelpItem";
            this.bdNgHelpItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgHelpItem.Text = "帮助(&L)";
            this.bdNgHelpItem.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(686, 435);
            this.splitContainer1.SplitterDistance = 332;
            this.splitContainer1.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvUser);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.groupBox1.Size = new System.Drawing.Size(332, 435);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "船员信息";
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUser.Location = new System.Drawing.Point(8, 17);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.ReadOnly = true;
            this.dgvUser.RowHeadersWidth = 25;
            this.dgvUser.RowTemplate.Height = 23;
            this.dgvUser.Size = new System.Drawing.Size(316, 410);
            this.dgvUser.TabIndex = 13;
            this.dgvUser.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_RowEnter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvShipHead);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.groupBox3.Size = new System.Drawing.Size(350, 435);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "职务信息";
            // 
            // dgvShipHead
            // 
            this.dgvShipHead.AllowUserToAddRows = false;
            this.dgvShipHead.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShipHead.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvShipHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShipHead.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select});
            this.dgvShipHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShipHead.Location = new System.Drawing.Point(8, 17);
            this.dgvShipHead.Name = "dgvShipHead";
            this.dgvShipHead.RowHeadersWidth = 25;
            this.dgvShipHead.RowTemplate.Height = 23;
            this.dgvShipHead.Size = new System.Drawing.Size(334, 410);
            this.dgvShipHead.TabIndex = 13;
            // 
            // select
            // 
            this.select.HeaderText = "选择";
            this.select.Name = "select";
            this.select.Width = 40;
            // 
            // FrmShipUserHead
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 466);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmShipUserHead";
            this.Text = "船员职务设置";
            this.Load += new System.EventHandler(this.FrmShipUserHead_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmShipUserHead_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdNgMain)).EndInit();
            this.bdNgMain.ResumeLayout(false);
            this.bdNgMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceShipHead)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingNavigator bdNgMain;
        private System.Windows.Forms.ToolStripLabel bdNgCountItem;
        private System.Windows.Forms.ToolStripButton bdNgMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bdNgMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bdNgSeparator;
        private System.Windows.Forms.ToolStripTextBox bdNgPositionItem;
        private System.Windows.Forms.ToolStripSeparator bdNgSeparator1;
        private System.Windows.Forms.ToolStripButton bdNgMoveNextItem;
        private System.Windows.Forms.ToolStripButton bdNgMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bdNgSeparator2;
        private System.Windows.Forms.ToolStripButton bdNgAddNewItem;
        private System.Windows.Forms.ToolStripButton bdNgDeleteItem;
        private System.Windows.Forms.ToolStripButton bdNgNewItem;
        private System.Windows.Forms.ToolStripButton bdNgOpenItem;
        private System.Windows.Forms.ToolStripButton bdNgSaveItem;
        private System.Windows.Forms.ToolStripButton bdNgCancelItem;
        private System.Windows.Forms.ToolStripButton bdNgPrintItem;
        private System.Windows.Forms.ToolStripButton bdNgClose;
        private System.Windows.Forms.ToolStripButton bdNgPrintViewItem;
        private System.Windows.Forms.ToolStripSeparator bdNgSeparator3;
        private System.Windows.Forms.ToolStripButton bdNgCutItem;
        private System.Windows.Forms.ToolStripButton bdNgCopyItem;
        private System.Windows.Forms.ToolStripButton bdNgPasteItem;
        private System.Windows.Forms.ToolStripSeparator bdNgSeparator4;
        private System.Windows.Forms.ToolStripButton bdNgHelpItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private CommonViewer.UcDataGridView dgvUser;
        private System.Windows.Forms.GroupBox groupBox3;
        private CommonViewer.UcDataGridView dgvShipHead;
        private System.Windows.Forms.ToolStripButton bdNgRightSet;
        private System.Windows.Forms.BindingSource bindingSourceUser;
        private System.Windows.Forms.BindingSource bindingSourceShipHead;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;

    }
}