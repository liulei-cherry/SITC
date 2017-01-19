namespace ShipMisZHJ_WorkFlow.Forms
{
    partial class FrmWorkFlowDefine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWorkFlowDefine));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.ucDataGridView = new CommonViewer.UcDataGridView(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton9 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.panel = new System.Windows.Forms.Panel();
            this.dragControl = new ShipMisZHJ_WorkFlow.UserControls.DragControl();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdNgMain)).BeginInit();
            this.bdNgMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.52843F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 78.47157F));
            this.tableLayoutPanel1.Controls.Add(this.bdNgMain, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ucDataGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(972, 630);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // bdNgMain
            // 
            this.bdNgMain.AddNewItem = null;
            this.tableLayoutPanel1.SetColumnSpan(this.bdNgMain, 2);
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
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnClose});
            this.bdNgMain.Location = new System.Drawing.Point(0, 0);
            this.bdNgMain.MoveFirstItem = this.bdNgMoveFirstItem;
            this.bdNgMain.MoveLastItem = this.bdNgMoveLastItem;
            this.bdNgMain.MoveNextItem = this.bdNgMoveNextItem;
            this.bdNgMain.MovePreviousItem = this.bdNgMovePreviousItem;
            this.bdNgMain.Name = "bdNgMain";
            this.bdNgMain.PositionItem = this.bdNgPositionItem;
            this.bdNgMain.Size = new System.Drawing.Size(972, 25);
            this.bdNgMain.TabIndex = 49;
            this.bdNgMain.Text = "bindingNavigator1";
            // 
            // bdNgCountItem
            // 
            this.bdNgCountItem.Name = "bdNgCountItem";
            this.bdNgCountItem.Size = new System.Drawing.Size(31, 22);
            this.bdNgCountItem.Text = "/ {0}";
            this.bdNgCountItem.ToolTipText = "总项数";
            this.bdNgCountItem.Visible = false;
            // 
            // bdNgMoveFirstItem
            // 
            this.bdNgMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgMoveFirstItem.Image")));
            this.bdNgMoveFirstItem.Name = "bdNgMoveFirstItem";
            this.bdNgMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bdNgMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgMoveFirstItem.Text = "移到第一条记录";
            this.bdNgMoveFirstItem.Visible = false;
            // 
            // bdNgMovePreviousItem
            // 
            this.bdNgMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgMovePreviousItem.Image")));
            this.bdNgMovePreviousItem.Name = "bdNgMovePreviousItem";
            this.bdNgMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bdNgMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgMovePreviousItem.Text = "移到上一条记录";
            this.bdNgMovePreviousItem.Visible = false;
            // 
            // bdNgSeparator
            // 
            this.bdNgSeparator.Name = "bdNgSeparator";
            this.bdNgSeparator.Size = new System.Drawing.Size(6, 25);
            this.bdNgSeparator.Visible = false;
            // 
            // bdNgPositionItem
            // 
            this.bdNgPositionItem.AccessibleName = "位置";
            this.bdNgPositionItem.AutoSize = false;
            this.bdNgPositionItem.Name = "bdNgPositionItem";
            this.bdNgPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bdNgPositionItem.Text = "0";
            this.bdNgPositionItem.ToolTipText = "当前位置";
            this.bdNgPositionItem.Visible = false;
            // 
            // bdNgSeparator1
            // 
            this.bdNgSeparator1.Name = "bdNgSeparator1";
            this.bdNgSeparator1.Size = new System.Drawing.Size(6, 25);
            this.bdNgSeparator1.Visible = false;
            // 
            // bdNgMoveNextItem
            // 
            this.bdNgMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgMoveNextItem.Image")));
            this.bdNgMoveNextItem.Name = "bdNgMoveNextItem";
            this.bdNgMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bdNgMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgMoveNextItem.Text = "移到下一条记录";
            this.bdNgMoveNextItem.Visible = false;
            // 
            // bdNgMoveLastItem
            // 
            this.bdNgMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bdNgMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgMoveLastItem.Image")));
            this.bdNgMoveLastItem.Name = "bdNgMoveLastItem";
            this.bdNgMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bdNgMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bdNgMoveLastItem.Text = "移到最后一条记录";
            this.bdNgMoveLastItem.Visible = false;
            // 
            // bdNgSeparator2
            // 
            this.bdNgSeparator2.Name = "bdNgSeparator2";
            this.bdNgSeparator2.Size = new System.Drawing.Size(6, 25);
            this.bdNgSeparator2.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.RightToLeftAutoMirrorImage = true;
            this.btnAdd.Size = new System.Drawing.Size(67, 22);
            this.btnAdd.Text = "新添(&A)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(50, 22);
            this.btnEdit.Text = "修改(&E)";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.RightToLeftAutoMirrorImage = true;
            this.btnDelete.Size = new System.Drawing.Size(68, 22);
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(51, 22);
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.ToolTipText = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ucDataGridView
            // 
            this.ucDataGridView.AllowUserToAddRows = false;
            this.ucDataGridView.AllowUserToDeleteRows = false;
            this.ucDataGridView.AllowUserToOrderColumns = true;
            this.ucDataGridView.AutoFit = true;
            this.ucDataGridView.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.ucDataGridView.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ucDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ucDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ucDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.ucDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDataGridView.EnableHeadersVisualStyles = false;
            this.ucDataGridView.ExportColorToExcel = false;
            this.ucDataGridView.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("ucDataGridView.Footer")));
            this.ucDataGridView.GridColor = System.Drawing.Color.SteelBlue;
            this.ucDataGridView.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("ucDataGridView.Header")));
            this.ucDataGridView.LoadedFinish = false;
            this.ucDataGridView.Location = new System.Drawing.Point(3, 28);
            this.ucDataGridView.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("ucDataGridView.MergeColumnNames")));
            this.ucDataGridView.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("ucDataGridView.MergeRowColumn")));
            this.ucDataGridView.Name = "ucDataGridView";
            this.ucDataGridView.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ucDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ucDataGridView.RowHeadersWidth = 25;
            this.tableLayoutPanel1.SetRowSpan(this.ucDataGridView, 2);
            this.ucDataGridView.RowTemplate.Height = 23;
            this.ucDataGridView.ShowRowNumber = true;
            this.ucDataGridView.Size = new System.Drawing.Size(203, 599);
            this.ucDataGridView.TabIndex = 50;
            this.ucDataGridView.Title = "";
            this.ucDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ucDataGridView_CellMouseClick);
            this.ucDataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ucDataGridView_CellMouseDoubleClick);
            this.ucDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.ucDataGridView_RowEnter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bindingNavigator1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(212, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(757, 24);
            this.panel1.TabIndex = 51;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.CountItem = this.toolStripLabel1;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripTextBox1,
            this.toolStripLabel1,
            this.toolStripSeparator3,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripSeparator5,
            this.toolStripButton10,
            this.toolStripButton8,
            this.toolStripButton9,
            this.toolStripSeparator6,
            this.toolDelete});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = this.toolStripButton1;
            this.bindingNavigator1.MoveLastItem = this.toolStripButton4;
            this.bindingNavigator1.MoveNextItem = this.toolStripButton3;
            this.bindingNavigator1.MovePreviousItem = this.toolStripButton2;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.toolStripTextBox1;
            this.bindingNavigator1.Size = new System.Drawing.Size(757, 25);
            this.bindingNavigator1.TabIndex = 50;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabel1.Text = "/ {0}";
            this.toolStripLabel1.ToolTipText = "总项数";
            this.toolStripLabel1.Visible = false;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.RightToLeftAutoMirrorImage = true;
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "移到第一条记录";
            this.toolStripButton1.Visible = false;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.RightToLeftAutoMirrorImage = true;
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "移到上一条记录";
            this.toolStripButton2.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator2.Visible = false;
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.AccessibleName = "位置";
            this.toolStripTextBox1.AutoSize = false;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(50, 21);
            this.toolStripTextBox1.Text = "0";
            this.toolStripTextBox1.ToolTipText = "当前位置";
            this.toolStripTextBox1.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator3.Visible = false;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.RightToLeftAutoMirrorImage = true;
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "移到下一条记录";
            this.toolStripButton3.Visible = false;
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.RightToLeftAutoMirrorImage = true;
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "移到最后一条记录";
            this.toolStripButton4.Visible = false;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator4.Visible = false;
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.RightToLeftAutoMirrorImage = true;
            this.toolStripButton5.Size = new System.Drawing.Size(91, 22);
            this.toolStripButton5.Text = "添加岗位(&A)";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(66, 22);
            this.toolStripButton6.Text = "保存(&S)";
            this.toolStripButton6.Click += new System.EventHandler(this.toolStripButton6_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton10
            // 
            this.toolStripButton10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton10.Image")));
            this.toolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton10.Name = "toolStripButton10";
            this.toolStripButton10.Size = new System.Drawing.Size(51, 22);
            this.toolStripButton10.Text = "选择";
            this.toolStripButton10.Click += new System.EventHandler(this.toolStripButton10_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(51, 22);
            this.toolStripButton8.Text = "通过";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // toolStripButton9
            // 
            this.toolStripButton9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton9.Image")));
            this.toolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton9.Name = "toolStripButton9";
            this.toolStripButton9.Size = new System.Drawing.Size(51, 22);
            this.toolStripButton9.Text = "拒绝";
            this.toolStripButton9.Click += new System.EventHandler(this.toolStripButton9_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // toolDelete
            // 
            this.toolDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolDelete.Image")));
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.RightToLeftAutoMirrorImage = true;
            this.toolDelete.Size = new System.Drawing.Size(68, 22);
            this.toolDelete.Text = "删除(&D)";
            this.toolDelete.Click += new System.EventHandler(this.toolDelete_Click);
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel.Controls.Add(this.dragControl);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(212, 58);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(757, 569);
            this.panel.TabIndex = 52;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            this.panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_MouseClick);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            this.panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MouseUp);
            // 
            // dragControl
            // 
            this.dragControl.Location = new System.Drawing.Point(647, 12);
            this.dragControl.Name = "dragControl";
            this.dragControl.Size = new System.Drawing.Size(86, 53);
            this.dragControl.TabIndex = 0;
            this.dragControl.Visible = false;
            // 
            // FrmWorkFlowDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 630);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmWorkFlowDefine";
            this.Text = "流程审批定义表";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmWorkFlowDefine_FormClosed);
            this.Load += new System.EventHandler(this.FrmWorkFlowDefine_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdNgMain)).EndInit();
            this.bdNgMain.ResumeLayout(false);
            this.bdNgMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.panel.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private CommonViewer.UcDataGridView ucDataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel;
        private ShipMisZHJ_WorkFlow.UserControls.DragControl dragControl;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.ToolStripButton toolStripButton9;
        private System.Windows.Forms.ToolStripButton toolStripButton10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}