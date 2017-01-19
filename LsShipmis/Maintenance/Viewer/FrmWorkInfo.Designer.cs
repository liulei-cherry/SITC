namespace Maintenance.Viewer
{
    partial class FrmWorkInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWorkInfo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bdNgDeleteItem = new CommonViewer.ButtonEx();
            this.bdNgAddNewItem = new CommonViewer.ButtonEx();
            this.buttonEx7 = new CommonViewer.ButtonEx();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修理项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.仅显示修理项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.仅显示非修理项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.是否检验项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.仅显示检验项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.仅显示非检验项目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.全部启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部停止ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bdNgArrangeOrder = new CommonViewer.ButtonEx();
            this.bdNgDeleteOrder = new CommonViewer.ButtonEx();
            this.bdNgEditItem = new CommonViewer.ButtonEx();
            this.CloseButton = new CommonViewer.ButtonEx();
            this.buttonEx5 = new CommonViewer.ButtonEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoAllComponent = new System.Windows.Forms.CheckBox();
            this.btnSelComponent = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.cboCircleOrTiming = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboPrincipalPost = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboWorkInfoState = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.dgvWork = new CommonViewer.UcDataGridView(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ucWorkInfo = new Maintenance.Viewer.UcWorkInfo();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvWorkOrder = new CommonViewer.UcDataGridView(this.components);
            this.bindingSourceMain = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bdsWorkOrder = new System.Windows.Forms.BindingSource(this.components);
            this.select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWork)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsWorkOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1184, 566);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.bdNgDeleteItem);
            this.panel2.Controls.Add(this.bdNgAddNewItem);
            this.panel2.Controls.Add(this.buttonEx7);
            this.panel2.Controls.Add(this.bdNgArrangeOrder);
            this.panel2.Controls.Add(this.bdNgDeleteOrder);
            this.panel2.Controls.Add(this.bdNgEditItem);
            this.panel2.Controls.Add(this.CloseButton);
            this.panel2.Controls.Add(this.buttonEx5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1178, 54);
            this.panel2.TabIndex = 54;
            // 
            // bdNgDeleteItem
            // 
            this.bdNgDeleteItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bdNgDeleteItem.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.bdNgDeleteItem.BackColor = System.Drawing.Color.Transparent;
            this.bdNgDeleteItem.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.bdNgDeleteItem.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.bdNgDeleteItem.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.bdNgDeleteItem.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.bdNgDeleteItem.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bdNgDeleteItem.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bdNgDeleteItem.FadingSpeed = 20;
            this.bdNgDeleteItem.FlatAppearance.BorderSize = 0;
            this.bdNgDeleteItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bdNgDeleteItem.Font = new System.Drawing.Font("宋体", 9F);
            this.bdNgDeleteItem.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.bdNgDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgDeleteItem.Image")));
            this.bdNgDeleteItem.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgDeleteItem.ImageOffset = 7;
            this.bdNgDeleteItem.IsPressed = false;
            this.bdNgDeleteItem.KeepPress = false;
            this.bdNgDeleteItem.Location = new System.Drawing.Point(743, 4);
            this.bdNgDeleteItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgDeleteItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgDeleteItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgDeleteItem.Name = "bdNgDeleteItem";
            this.bdNgDeleteItem.Radius = 6;
            this.bdNgDeleteItem.ShowBase = true;
            this.bdNgDeleteItem.Size = new System.Drawing.Size(99, 44);
            this.bdNgDeleteItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgDeleteItem.SplitDistance = 0;
            this.bdNgDeleteItem.TabIndex = 37;
            this.bdNgDeleteItem.Text = "   删除";
            this.bdNgDeleteItem.Title = "工作信息";
            this.bdNgDeleteItem.UseVisualStyleBackColor = true;
            this.bdNgDeleteItem.Click += new System.EventHandler(this.bdNgDeleteItem_Click);
            // 
            // bdNgAddNewItem
            // 
            this.bdNgAddNewItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bdNgAddNewItem.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.bdNgAddNewItem.BackColor = System.Drawing.Color.Transparent;
            this.bdNgAddNewItem.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.bdNgAddNewItem.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.bdNgAddNewItem.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.bdNgAddNewItem.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.bdNgAddNewItem.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bdNgAddNewItem.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bdNgAddNewItem.FadingSpeed = 20;
            this.bdNgAddNewItem.FlatAppearance.BorderSize = 0;
            this.bdNgAddNewItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bdNgAddNewItem.Font = new System.Drawing.Font("宋体", 9F);
            this.bdNgAddNewItem.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.bdNgAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgAddNewItem.Image")));
            this.bdNgAddNewItem.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgAddNewItem.ImageOffset = 5;
            this.bdNgAddNewItem.IsPressed = false;
            this.bdNgAddNewItem.KeepPress = false;
            this.bdNgAddNewItem.Location = new System.Drawing.Point(545, 4);
            this.bdNgAddNewItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgAddNewItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgAddNewItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgAddNewItem.Name = "bdNgAddNewItem";
            this.bdNgAddNewItem.Radius = 6;
            this.bdNgAddNewItem.ShowBase = true;
            this.bdNgAddNewItem.Size = new System.Drawing.Size(99, 44);
            this.bdNgAddNewItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgAddNewItem.SplitDistance = 0;
            this.bdNgAddNewItem.TabIndex = 36;
            this.bdNgAddNewItem.Text = "  增加";
            this.bdNgAddNewItem.Title = "工作信息";
            this.bdNgAddNewItem.UseVisualStyleBackColor = true;
            this.bdNgAddNewItem.Click += new System.EventHandler(this.bdNgAddNewItem_Click);
            // 
            // buttonEx7
            // 
            this.buttonEx7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEx7.Arrow = CommonViewer.ButtonEx.e_arrow.ToDown;
            this.buttonEx7.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx7.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx7.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.buttonEx7.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx7.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx7.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx7.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx7.ContextMenuStrip = this.contextMenuStrip1;
            this.buttonEx7.FadingSpeed = 20;
            this.buttonEx7.FlatAppearance.BorderSize = 0;
            this.buttonEx7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx7.Font = new System.Drawing.Font("宋体", 9F);
            this.buttonEx7.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx7.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx7.Image")));
            this.buttonEx7.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx7.ImageOffset = 2;
            this.buttonEx7.IsPressed = false;
            this.buttonEx7.KeepPress = false;
            this.buttonEx7.Location = new System.Drawing.Point(1017, 4);
            this.buttonEx7.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx7.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx7.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx7.Name = "buttonEx7";
            this.buttonEx7.Radius = 6;
            this.buttonEx7.ShowBase = true;
            this.buttonEx7.Size = new System.Drawing.Size(113, 44);
            this.buttonEx7.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx7.SplitDistance = 0;
            this.buttonEx7.TabIndex = 35;
            this.buttonEx7.Text = "更多操作";
            this.buttonEx7.Title = "";
            this.buttonEx7.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修理项目ToolStripMenuItem,
            this.是否检验项目ToolStripMenuItem,
            this.toolStripButton1,
            this.全部启动ToolStripMenuItem,
            this.全部停止ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(199, 156);
            // 
            // 修理项目ToolStripMenuItem
            // 
            this.修理项目ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.全部ToolStripMenuItem,
            this.仅显示修理项目ToolStripMenuItem,
            this.仅显示非修理项目ToolStripMenuItem});
            this.修理项目ToolStripMenuItem.Name = "修理项目ToolStripMenuItem";
            this.修理项目ToolStripMenuItem.Size = new System.Drawing.Size(198, 30);
            this.修理项目ToolStripMenuItem.Text = "是否修理项目";
            // 
            // 全部ToolStripMenuItem
            // 
            this.全部ToolStripMenuItem.Name = "全部ToolStripMenuItem";
            this.全部ToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.全部ToolStripMenuItem.Text = "全部项目";
            this.全部ToolStripMenuItem.Click += new System.EventHandler(this.全部ToolStripMenuItem_Click);
            // 
            // 仅显示修理项目ToolStripMenuItem
            // 
            this.仅显示修理项目ToolStripMenuItem.Name = "仅显示修理项目ToolStripMenuItem";
            this.仅显示修理项目ToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.仅显示修理项目ToolStripMenuItem.Text = "仅显示修理项目";
            this.仅显示修理项目ToolStripMenuItem.Click += new System.EventHandler(this.仅显示修理项目ToolStripMenuItem_Click);
            // 
            // 仅显示非修理项目ToolStripMenuItem
            // 
            this.仅显示非修理项目ToolStripMenuItem.Name = "仅显示非修理项目ToolStripMenuItem";
            this.仅显示非修理项目ToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.仅显示非修理项目ToolStripMenuItem.Text = "仅显示非修理项目";
            this.仅显示非修理项目ToolStripMenuItem.Click += new System.EventHandler(this.仅显示非修理项目ToolStripMenuItem_Click);
            // 
            // 是否检验项目ToolStripMenuItem
            // 
            this.是否检验项目ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.全部项目ToolStripMenuItem,
            this.仅显示检验项目ToolStripMenuItem,
            this.仅显示非检验项目ToolStripMenuItem});
            this.是否检验项目ToolStripMenuItem.Name = "是否检验项目ToolStripMenuItem";
            this.是否检验项目ToolStripMenuItem.Size = new System.Drawing.Size(198, 30);
            this.是否检验项目ToolStripMenuItem.Text = "是否检验项目";
            // 
            // 全部项目ToolStripMenuItem
            // 
            this.全部项目ToolStripMenuItem.Name = "全部项目ToolStripMenuItem";
            this.全部项目ToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.全部项目ToolStripMenuItem.Text = "全部项目";
            this.全部项目ToolStripMenuItem.Click += new System.EventHandler(this.全部项目ToolStripMenuItem_Click);
            // 
            // 仅显示检验项目ToolStripMenuItem
            // 
            this.仅显示检验项目ToolStripMenuItem.Name = "仅显示检验项目ToolStripMenuItem";
            this.仅显示检验项目ToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.仅显示检验项目ToolStripMenuItem.Text = "仅显示检验项目";
            this.仅显示检验项目ToolStripMenuItem.Click += new System.EventHandler(this.仅显示检验项目ToolStripMenuItem_Click);
            // 
            // 仅显示非检验项目ToolStripMenuItem
            // 
            this.仅显示非检验项目ToolStripMenuItem.Name = "仅显示非检验项目ToolStripMenuItem";
            this.仅显示非检验项目ToolStripMenuItem.Size = new System.Drawing.Size(236, 30);
            this.仅显示非检验项目ToolStripMenuItem.Text = "仅显示非检验项目";
            this.仅显示非检验项目ToolStripMenuItem.Click += new System.EventHandler(this.仅显示非检验项目ToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(130, 29);
            this.toolStripButton1.Text = "快速关联设备";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // 全部启动ToolStripMenuItem
            // 
            this.全部启动ToolStripMenuItem.Name = "全部启动ToolStripMenuItem";
            this.全部启动ToolStripMenuItem.Size = new System.Drawing.Size(198, 30);
            this.全部启动ToolStripMenuItem.Text = "全部启动";
            this.全部启动ToolStripMenuItem.Click += new System.EventHandler(this.全部启动ToolStripMenuItem_Click);
            // 
            // 全部停止ToolStripMenuItem
            // 
            this.全部停止ToolStripMenuItem.Name = "全部停止ToolStripMenuItem";
            this.全部停止ToolStripMenuItem.Size = new System.Drawing.Size(198, 30);
            this.全部停止ToolStripMenuItem.Text = "全部停止";
            this.全部停止ToolStripMenuItem.Click += new System.EventHandler(this.全部停止ToolStripMenuItem_Click);
            // 
            // bdNgArrangeOrder
            // 
            this.bdNgArrangeOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bdNgArrangeOrder.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.bdNgArrangeOrder.BackColor = System.Drawing.Color.Transparent;
            this.bdNgArrangeOrder.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.bdNgArrangeOrder.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.bdNgArrangeOrder.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.bdNgArrangeOrder.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.bdNgArrangeOrder.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bdNgArrangeOrder.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bdNgArrangeOrder.FadingSpeed = 20;
            this.bdNgArrangeOrder.FlatAppearance.BorderSize = 0;
            this.bdNgArrangeOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bdNgArrangeOrder.Font = new System.Drawing.Font("宋体", 9F);
            this.bdNgArrangeOrder.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.bdNgArrangeOrder.Image = ((System.Drawing.Image)(resources.GetObject("bdNgArrangeOrder.Image")));
            this.bdNgArrangeOrder.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgArrangeOrder.ImageOffset = 5;
            this.bdNgArrangeOrder.IsPressed = false;
            this.bdNgArrangeOrder.KeepPress = false;
            this.bdNgArrangeOrder.Location = new System.Drawing.Point(842, 4);
            this.bdNgArrangeOrder.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgArrangeOrder.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgArrangeOrder.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgArrangeOrder.Name = "bdNgArrangeOrder";
            this.bdNgArrangeOrder.Radius = 6;
            this.bdNgArrangeOrder.ShowBase = true;
            this.bdNgArrangeOrder.Size = new System.Drawing.Size(100, 44);
            this.bdNgArrangeOrder.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgArrangeOrder.SplitDistance = 0;
            this.bdNgArrangeOrder.TabIndex = 32;
            this.bdNgArrangeOrder.Text = "安排";
            this.bdNgArrangeOrder.Title = "工单";
            this.bdNgArrangeOrder.UseVisualStyleBackColor = true;
            this.bdNgArrangeOrder.Click += new System.EventHandler(this.bdNgArrangeOrder_Click);
            // 
            // bdNgDeleteOrder
            // 
            this.bdNgDeleteOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bdNgDeleteOrder.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.bdNgDeleteOrder.BackColor = System.Drawing.Color.Transparent;
            this.bdNgDeleteOrder.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.bdNgDeleteOrder.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.bdNgDeleteOrder.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.bdNgDeleteOrder.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.bdNgDeleteOrder.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bdNgDeleteOrder.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bdNgDeleteOrder.FadingSpeed = 20;
            this.bdNgDeleteOrder.FlatAppearance.BorderSize = 0;
            this.bdNgDeleteOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bdNgDeleteOrder.Font = new System.Drawing.Font("宋体", 9F);
            this.bdNgDeleteOrder.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.bdNgDeleteOrder.Image = ((System.Drawing.Image)(resources.GetObject("bdNgDeleteOrder.Image")));
            this.bdNgDeleteOrder.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgDeleteOrder.ImageOffset = 5;
            this.bdNgDeleteOrder.IsPressed = false;
            this.bdNgDeleteOrder.KeepPress = false;
            this.bdNgDeleteOrder.Location = new System.Drawing.Point(942, 4);
            this.bdNgDeleteOrder.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgDeleteOrder.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgDeleteOrder.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgDeleteOrder.Name = "bdNgDeleteOrder";
            this.bdNgDeleteOrder.Radius = 6;
            this.bdNgDeleteOrder.ShowBase = true;
            this.bdNgDeleteOrder.Size = new System.Drawing.Size(75, 44);
            this.bdNgDeleteOrder.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgDeleteOrder.SplitDistance = 0;
            this.bdNgDeleteOrder.TabIndex = 31;
            this.bdNgDeleteOrder.Text = "删除";
            this.bdNgDeleteOrder.Title = "工单";
            this.bdNgDeleteOrder.UseVisualStyleBackColor = true;
            this.bdNgDeleteOrder.Click += new System.EventHandler(this.bdNgDeleteOrder_Click);
            // 
            // bdNgEditItem
            // 
            this.bdNgEditItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bdNgEditItem.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.bdNgEditItem.BackColor = System.Drawing.Color.Transparent;
            this.bdNgEditItem.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.bdNgEditItem.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.bdNgEditItem.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.bdNgEditItem.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.bdNgEditItem.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bdNgEditItem.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bdNgEditItem.FadingSpeed = 20;
            this.bdNgEditItem.FlatAppearance.BorderSize = 0;
            this.bdNgEditItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bdNgEditItem.Font = new System.Drawing.Font("宋体", 9F);
            this.bdNgEditItem.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.bdNgEditItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgEditItem.Image")));
            this.bdNgEditItem.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgEditItem.ImageOffset = 5;
            this.bdNgEditItem.IsPressed = false;
            this.bdNgEditItem.KeepPress = false;
            this.bdNgEditItem.Location = new System.Drawing.Point(644, 4);
            this.bdNgEditItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgEditItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgEditItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgEditItem.Name = "bdNgEditItem";
            this.bdNgEditItem.Radius = 6;
            this.bdNgEditItem.ShowBase = true;
            this.bdNgEditItem.Size = new System.Drawing.Size(99, 44);
            this.bdNgEditItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgEditItem.SplitDistance = 0;
            this.bdNgEditItem.TabIndex = 30;
            this.bdNgEditItem.Text = "  编辑";
            this.bdNgEditItem.Title = "工作信息";
            this.bdNgEditItem.UseVisualStyleBackColor = true;
            this.bdNgEditItem.Click += new System.EventHandler(this.bdNgEditItem_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.CloseButton.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.CloseButton.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.CloseButton.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.CloseButton.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CloseButton.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.CloseButton.FadingSpeed = 20;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("宋体", 9F);
            this.CloseButton.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.CloseButton.ImageOffset = 5;
            this.CloseButton.IsPressed = false;
            this.CloseButton.KeepPress = false;
            this.CloseButton.Location = new System.Drawing.Point(1130, 4);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.CloseButton.MenuPos = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Radius = 6;
            this.CloseButton.ShowBase = true;
            this.CloseButton.Size = new System.Drawing.Size(45, 44);
            this.CloseButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.CloseButton.SplitDistance = 0;
            this.CloseButton.TabIndex = 26;
            this.CloseButton.Title = "";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.bdNgClose_Click);
            // 
            // buttonEx5
            // 
            this.buttonEx5.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx5.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx5.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx5.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.buttonEx5.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx5.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx5.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx5.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx5.Enabled = false;
            this.buttonEx5.FadingSpeed = 20;
            this.buttonEx5.FlatAppearance.BorderSize = 0;
            this.buttonEx5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx5.Font = new System.Drawing.Font("宋体", 9F);
            this.buttonEx5.ForeColor = System.Drawing.Color.Maroon;
            this.buttonEx5.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx5.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx5.Image")));
            this.buttonEx5.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx5.ImageOffset = 0;
            this.buttonEx5.IsPressed = false;
            this.buttonEx5.KeepPress = false;
            this.buttonEx5.Location = new System.Drawing.Point(4, 4);
            this.buttonEx5.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx5.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx5.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx5.Name = "buttonEx5";
            this.buttonEx5.Radius = 6;
            this.buttonEx5.ShowBase = false;
            this.buttonEx5.Size = new System.Drawing.Size(301, 48);
            this.buttonEx5.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx5.SplitDistance = 0;
            this.buttonEx5.TabIndex = 27;
            this.buttonEx5.Text = "工作信息是形成工单的基础\r\n工作信息定义完毕必须对其进行安排才能执行";
            this.buttonEx5.Title = "工作信息定义";
            this.buttonEx5.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1178, 55);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工作信息选择查询";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.ucShipSelect1);
            this.flowLayoutPanel1.Controls.Add(this.checkBox1);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.label11);
            this.flowLayoutPanel1.Controls.Add(this.cboCircleOrTiming);
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Controls.Add(this.cboPrincipalPost);
            this.flowLayoutPanel1.Controls.Add(this.label10);
            this.flowLayoutPanel1.Controls.Add(this.cboWorkInfoState);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1172, 35);
            this.flowLayoutPanel1.TabIndex = 21;
            // 
            // ucShipSelect1
            // 
            this.ucShipSelect1.CanEdit = false;
            this.ucShipSelect1.DropDownWidth = 189;
            this.ucShipSelect1.Location = new System.Drawing.Point(3, 3);
            this.ucShipSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipSelect1.Name = "ucShipSelect1";
            this.ucShipSelect1.NullValueShow = "所有船";
            this.ucShipSelect1.ShowButton = false;
            this.ucShipSelect1.Size = new System.Drawing.Size(196, 20);
            this.ucShipSelect1.TabIndex = 20;
            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(205, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(132, 16);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "仅显示未安排的工作";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoAllComponent);
            this.panel1.Controls.Add(this.btnSelComponent);
            this.panel1.Location = new System.Drawing.Point(340, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 29);
            this.panel1.TabIndex = 22;
            // 
            // rdoAllComponent
            // 
            this.rdoAllComponent.AutoSize = true;
            this.rdoAllComponent.BackColor = System.Drawing.Color.Transparent;
            this.rdoAllComponent.Checked = true;
            this.rdoAllComponent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rdoAllComponent.Location = new System.Drawing.Point(80, 5);
            this.rdoAllComponent.Name = "rdoAllComponent";
            this.rdoAllComponent.Size = new System.Drawing.Size(72, 16);
            this.rdoAllComponent.TabIndex = 18;
            this.rdoAllComponent.Text = "所有设备";
            this.rdoAllComponent.UseVisualStyleBackColor = false;
            this.rdoAllComponent.CheckedChanged += new System.EventHandler(this.rdoAllComponent_CheckedChanged);
            // 
            // btnSelComponent
            // 
            this.btnSelComponent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelComponent.Image = ((System.Drawing.Image)(resources.GetObject("btnSelComponent.Image")));
            this.btnSelComponent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelComponent.Location = new System.Drawing.Point(1, 0);
            this.btnSelComponent.Name = "btnSelComponent";
            this.btnSelComponent.Size = new System.Drawing.Size(164, 25);
            this.btnSelComponent.TabIndex = 17;
            this.btnSelComponent.Text = "    设备…";
            this.btnSelComponent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelComponent.UseVisualStyleBackColor = true;
            this.btnSelComponent.Click += new System.EventHandler(this.btnSelComponent_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(516, 0);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label11.Size = new System.Drawing.Size(53, 17);
            this.label11.TabIndex = 9;
            this.label11.Text = "工作类型";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboCircleOrTiming
            // 
            this.cboCircleOrTiming.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCircleOrTiming.FormattingEnabled = true;
            this.cboCircleOrTiming.Location = new System.Drawing.Point(575, 3);
            this.cboCircleOrTiming.Name = "cboCircleOrTiming";
            this.cboCircleOrTiming.Size = new System.Drawing.Size(61, 20);
            this.cboCircleOrTiming.TabIndex = 5;
            this.cboCircleOrTiming.DropDownClosed += new System.EventHandler(this.cboCircleOrTiming_DropDownClosed);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(642, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "责任人岗位";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPrincipalPost
            // 
            this.cboPrincipalPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrincipalPost.FormattingEnabled = true;
            this.cboPrincipalPost.Location = new System.Drawing.Point(713, 3);
            this.cboPrincipalPost.Name = "cboPrincipalPost";
            this.cboPrincipalPost.Size = new System.Drawing.Size(99, 20);
            this.cboPrincipalPost.TabIndex = 7;
            this.cboPrincipalPost.DropDownClosed += new System.EventHandler(this.cboPrincipalPost_DropDownClosed);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(818, 0);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label10.Size = new System.Drawing.Size(53, 17);
            this.label10.TabIndex = 8;
            this.label10.Text = "工作状态";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboWorkInfoState
            // 
            this.cboWorkInfoState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWorkInfoState.FormattingEnabled = true;
            this.cboWorkInfoState.Location = new System.Drawing.Point(877, 3);
            this.cboWorkInfoState.Name = "cboWorkInfoState";
            this.cboWorkInfoState.Size = new System.Drawing.Size(50, 20);
            this.cboWorkInfoState.TabIndex = 12;
            this.cboWorkInfoState.DropDownClosed += new System.EventHandler(this.cboWorkInfoState_DropDownClosed);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 124);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(1178, 439);
            this.splitContainer1.SplitterDistance = 471;
            this.splitContainer1.TabIndex = 45;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.dgvWork);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.groupBox2.Size = new System.Drawing.Size(471, 439);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "工作信息列表";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(43, 22);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // dgvWork
            // 
            this.dgvWork.AllowUserToAddRows = false;
            this.dgvWork.AllowUserToDeleteRows = false;
            this.dgvWork.AllowUserToOrderColumns = true;
            this.dgvWork.AutoFit = true;
            this.dgvWork.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvWork.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWork.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvWork.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWork.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWork.EnableHeadersVisualStyles = false;
            this.dgvWork.ExportColorToExcel = false;
            this.dgvWork.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWork.Footer")));
            this.dgvWork.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvWork.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWork.Header")));
            this.dgvWork.LoadedFinish = false;
            this.dgvWork.Location = new System.Drawing.Point(8, 17);
            this.dgvWork.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWork.MergeColumnNames")));
            this.dgvWork.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWork.MergeRowColumn")));
            this.dgvWork.Name = "dgvWork";
            this.dgvWork.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWork.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvWork.RowHeadersWidth = 25;
            this.dgvWork.RowTemplate.Height = 23;
            this.dgvWork.ShowRowNumber = true;
            this.dgvWork.Size = new System.Drawing.Size(455, 414);
            this.dgvWork.TabIndex = 2;
            this.dgvWork.Title = "";
            this.dgvWork.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWork_RowEnter);
            this.dgvWork.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWork_CellDoubleClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.splitContainer2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(703, 439);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.ucWorkInfo);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer2.Size = new System.Drawing.Size(697, 433);
            this.splitContainer2.SplitterDistance = 343;
            this.splitContainer2.TabIndex = 1;
            // 
            // ucWorkInfo
            // 
            this.ucWorkInfo.BackColor = System.Drawing.Color.AliceBlue;
            this.ucWorkInfo.Component_unit = null;
            this.ucWorkInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWorkInfo.Location = new System.Drawing.Point(0, 0);
            this.ucWorkInfo.Name = "ucWorkInfo";
            this.ucWorkInfo.Size = new System.Drawing.Size(697, 343);
            this.ucWorkInfo.TabIndex = 0;
            this.ucWorkInfo.WorkInfo = null;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvWorkOrder);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.groupBox4.Size = new System.Drawing.Size(697, 86);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "工作信息产生的工单";
            // 
            // dgvWorkOrder
            // 
            this.dgvWorkOrder.AllowUserToAddRows = false;
            this.dgvWorkOrder.AllowUserToDeleteRows = false;
            this.dgvWorkOrder.AllowUserToOrderColumns = true;
            this.dgvWorkOrder.AutoFit = true;
            this.dgvWorkOrder.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvWorkOrder.ColumnDeep = 1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvWorkOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWorkOrder.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvWorkOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorkOrder.EnableHeadersVisualStyles = false;
            this.dgvWorkOrder.ExportColorToExcel = false;
            this.dgvWorkOrder.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkOrder.Footer")));
            this.dgvWorkOrder.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvWorkOrder.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkOrder.Header")));
            this.dgvWorkOrder.LoadedFinish = false;
            this.dgvWorkOrder.Location = new System.Drawing.Point(8, 17);
            this.dgvWorkOrder.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkOrder.MergeColumnNames")));
            this.dgvWorkOrder.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkOrder.MergeRowColumn")));
            this.dgvWorkOrder.Name = "dgvWorkOrder";
            this.dgvWorkOrder.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvWorkOrder.RowHeadersWidth = 25;
            this.dgvWorkOrder.RowTemplate.Height = 23;
            this.dgvWorkOrder.ShowRowNumber = false;
            this.dgvWorkOrder.Size = new System.Drawing.Size(681, 61);
            this.dgvWorkOrder.TabIndex = 3;
            this.dgvWorkOrder.Title = "";
            this.dgvWorkOrder.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWorkOrder_CellDoubleClick);
            // 
            // select
            // 
            this.select.DataPropertyName = "sel";
            this.select.HeaderText = "";
            this.select.Name = "select";
            this.select.ReadOnly = true;
            this.select.Width = 30;
            // 
            // FrmWorkInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1184, 566);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmWorkInfo";
            this.Text = "工作信息";
            this.Load += new System.EventHandler(this.FrmWorkInfo_Load);
            this.Shown += new System.EventHandler(this.FrmWorkInfo_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWorkInfo_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWork)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsWorkOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingSource bindingSourceMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private UcWorkInfo ucWorkInfo;
        private System.Windows.Forms.GroupBox groupBox4;
        private CommonViewer.UcDataGridView dgvWork;
        private CommonViewer.UcDataGridView dgvWorkOrder;
        private System.Windows.Forms.ComboBox cboWorkInfoState;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboPrincipalPost;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboCircleOrTiming;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.BindingSource bdsWorkOrder;
        private System.Windows.Forms.Button btnSelComponent;
        private System.Windows.Forms.CheckBox rdoAllComponent;
        private System.Windows.Forms.CheckBox checkBox1;
        private BaseInfo.Viewer.UcShipSelect ucShipSelect1;
        private System.Windows.Forms.Panel panel2;
        private CommonViewer.ButtonEx buttonEx7;
        private CommonViewer.ButtonEx bdNgArrangeOrder;
        private CommonViewer.ButtonEx bdNgDeleteOrder;
        private CommonViewer.ButtonEx bdNgEditItem;
        private CommonViewer.ButtonEx CloseButton;
        private CommonViewer.ButtonEx buttonEx5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 修理项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 仅显示修理项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 仅显示非修理项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 是否检验项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 仅显示检验项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 仅显示非检验项目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private CommonViewer.ButtonEx bdNgDeleteItem;
        private CommonViewer.ButtonEx bdNgAddNewItem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem 全部启动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部停止ToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn select;


    }
}