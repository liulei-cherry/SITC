namespace LSShipMis_Ship.SysLs.Forms
{
    partial class FrmRightSet
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRightSet));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvShipHead = new CommonViewer.UcDataGridView(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvUser = new CommonViewer.UcDataGridView(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvRight = new CommonViewer.UcDataGridView(this.components);
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bindingSourceUser = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceShipHead = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceRight = new System.Windows.Forms.BindingSource(this.components);
            this.btnBlank = new CommonViewer.ButtonEx();
            this.btnAll = new CommonViewer.ButtonEx();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdNgMain)).BeginInit();
            this.bdNgMain.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipHead)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceShipHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRight)).BeginInit();
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
            this.tableLayoutPanel1.TabIndex = 1;
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
            // bdNgClose
            // 
            this.bdNgClose.Image = global::LSShipMis_Ship.Properties.Resources.close;
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
            this.groupBox1.Controls.Add(this.tabMain);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 3, 5, 5);
            this.groupBox1.Size = new System.Drawing.Size(332, 435);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户角色";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.ItemSize = new System.Drawing.Size(60, 25);
            this.tabMain.Location = new System.Drawing.Point(5, 17);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(322, 413);
            this.tabMain.TabIndex = 0;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvShipHead);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(314, 380);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "岗位信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvShipHead
            // 
            this.dgvShipHead.AllowUserToAddRows = false;
            this.dgvShipHead.AllowUserToDeleteRows = false;
            this.dgvShipHead.AllowUserToOrderColumns = true;
            this.dgvShipHead.AutoFit = true;
            this.dgvShipHead.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvShipHead.ColumnDeep = 1;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShipHead.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvShipHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShipHead.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvShipHead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShipHead.EnableHeadersVisualStyles = false;
            this.dgvShipHead.ExportColorToExcel = false;
            this.dgvShipHead.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvShipHead.Footer")));
            this.dgvShipHead.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvShipHead.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvShipHead.Header")));
            this.dgvShipHead.LoadedFinish = false;
            this.dgvShipHead.Location = new System.Drawing.Point(3, 3);
            this.dgvShipHead.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvShipHead.MergeColumnNames")));
            this.dgvShipHead.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvShipHead.MergeRowColumn")));
            this.dgvShipHead.Name = "dgvShipHead";
            this.dgvShipHead.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShipHead.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvShipHead.RowHeadersWidth = 25;
            this.dgvShipHead.RowTemplate.Height = 23;
            this.dgvShipHead.ShowRowNumber = true;
            this.dgvShipHead.Size = new System.Drawing.Size(308, 374);
            this.dgvShipHead.TabIndex = 12;
            this.dgvShipHead.Title = null;
            this.dgvShipHead.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShipHead_RowEnter);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvUser);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(314, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "船员";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.AllowUserToOrderColumns = true;
            this.dgvUser.AutoFit = true;
            this.dgvUser.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvUser.ColumnDeep = 1;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUser.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUser.EnableHeadersVisualStyles = false;
            this.dgvUser.ExportColorToExcel = false;
            this.dgvUser.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvUser.Footer")));
            this.dgvUser.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvUser.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvUser.Header")));
            this.dgvUser.LoadedFinish = false;
            this.dgvUser.Location = new System.Drawing.Point(3, 3);
            this.dgvUser.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvUser.MergeColumnNames")));
            this.dgvUser.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvUser.MergeRowColumn")));
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvUser.RowHeadersWidth = 25;
            this.dgvUser.RowTemplate.Height = 23;
            this.dgvUser.ShowRowNumber = true;
            this.dgvUser.Size = new System.Drawing.Size(308, 382);
            this.dgvUser.TabIndex = 12;
            this.dgvUser.Title = null;
            this.dgvUser.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUser_RowEnter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnBlank);
            this.groupBox3.Controls.Add(this.btnAll);
            this.groupBox3.Controls.Add(this.dgvRight);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(8, 30, 8, 8);
            this.groupBox3.Size = new System.Drawing.Size(350, 435);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "权限信息";
            // 
            // dgvRight
            // 
            this.dgvRight.AllowUserToAddRows = false;
            this.dgvRight.AllowUserToDeleteRows = false;
            this.dgvRight.AllowUserToOrderColumns = true;
            this.dgvRight.AutoFit = true;
            this.dgvRight.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvRight.ColumnDeep = 1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRight.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRight.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRight.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRight.EnableHeadersVisualStyles = false;
            this.dgvRight.ExportColorToExcel = false;
            this.dgvRight.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvRight.Footer")));
            this.dgvRight.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvRight.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvRight.Header")));
            this.dgvRight.LoadedFinish = false;
            this.dgvRight.Location = new System.Drawing.Point(8, 44);
            this.dgvRight.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvRight.MergeColumnNames")));
            this.dgvRight.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvRight.MergeRowColumn")));
            this.dgvRight.Name = "dgvRight";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRight.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvRight.RowHeadersWidth = 25;
            this.dgvRight.RowTemplate.Height = 23;
            this.dgvRight.ShowRowNumber = true;
            this.dgvRight.Size = new System.Drawing.Size(334, 383);
            this.dgvRight.TabIndex = 13;
            this.dgvRight.Title = null;
            // 
            // select
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle5.NullValue = false;
            this.select.DefaultCellStyle = dataGridViewCellStyle5;
            this.select.HeaderText = "选择";
            this.select.Name = "select";
            this.select.Width = 60;
            // 
            // btnBlank
            // 
            this.btnBlank.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnBlank.BackColor = System.Drawing.Color.Transparent;
            this.btnBlank.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnBlank.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnBlank.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnBlank.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnBlank.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnBlank.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnBlank.FadingSpeed = 20;
            this.btnBlank.FlatAppearance.BorderSize = 0;
            this.btnBlank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlank.Font = new System.Drawing.Font("宋体", 9F);
            this.btnBlank.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnBlank.Image = ((System.Drawing.Image)(resources.GetObject("btnBlank.Image")));
            this.btnBlank.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnBlank.ImageOffset = 5;
            this.btnBlank.IsPressed = false;
            this.btnBlank.KeepPress = false;
            this.btnBlank.Location = new System.Drawing.Point(68, 16);
            this.btnBlank.Margin = new System.Windows.Forms.Padding(0);
            this.btnBlank.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnBlank.MenuPos = new System.Drawing.Point(0, 0);
            this.btnBlank.Name = "btnBlank";
            this.btnBlank.Radius = 6;
            this.btnBlank.ShowBase = true;
            this.btnBlank.Size = new System.Drawing.Size(55, 25);
            this.btnBlank.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnBlank.SplitDistance = 0;
            this.btnBlank.TabIndex = 33;
            this.btnBlank.Text = "全清";
            this.btnBlank.Title = "";
            this.btnBlank.UseVisualStyleBackColor = true;
            this.btnBlank.Click += new System.EventHandler(this.btnBlank_Click);
            // 
            // btnAll
            // 
            this.btnAll.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnAll.BackColor = System.Drawing.Color.Transparent;
            this.btnAll.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnAll.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnAll.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAll.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAll.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAll.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAll.FadingSpeed = 20;
            this.btnAll.FlatAppearance.BorderSize = 0;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Font = new System.Drawing.Font("宋体", 9F);
            this.btnAll.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnAll.Image = ((System.Drawing.Image)(resources.GetObject("btnAll.Image")));
            this.btnAll.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnAll.ImageOffset = 5;
            this.btnAll.IsPressed = false;
            this.btnAll.KeepPress = false;
            this.btnAll.Location = new System.Drawing.Point(8, 16);
            this.btnAll.Margin = new System.Windows.Forms.Padding(0);
            this.btnAll.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAll.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAll.Name = "btnAll";
            this.btnAll.Radius = 6;
            this.btnAll.ShowBase = true;
            this.btnAll.Size = new System.Drawing.Size(55, 25);
            this.btnAll.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnAll.SplitDistance = 0;
            this.btnAll.TabIndex = 32;
            this.btnAll.Text = "全选";
            this.btnAll.Title = "";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // FrmRightSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 466);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmRightSet";
            this.Text = "权限设置";
            this.Load += new System.EventHandler(this.FrmRoleRight_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRightSet_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdNgMain)).EndInit();
            this.bdNgMain.ResumeLayout(false);
            this.bdNgMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipHead)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceShipHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRight)).EndInit();
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
        private System.Windows.Forms.BindingSource bindingSourceUser;
        private System.Windows.Forms.BindingSource bindingSourceShipHead;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private CommonViewer.UcDataGridView dgvShipHead;
        private CommonViewer.UcDataGridView dgvUser;
        private CommonViewer.UcDataGridView dgvRight;
        private System.Windows.Forms.BindingSource bindingSourceRight;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;
        private CommonViewer.ButtonEx btnBlank;
        private CommonViewer.ButtonEx btnAll;
    }
}