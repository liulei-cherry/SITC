namespace Maintenance.Viewer
{
    partial class FrmWorkOrderHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWorkOrderHistory));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRepairState = new CommonViewer.ButtonEx();
            this.cmsIsRepairItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsm3All = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOnlyRepairItems = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOnlyNotRepairItems = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCheckState = new CommonViewer.ButtonEx();
            this.cmsIsCheckItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAllCheckItems = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOnlyCheckItems = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOnlyNotCheckItems = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWorkType = new CommonViewer.ButtonEx();
            this.cmsWorkType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsm2All = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm2Recycle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm2Timing = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm2Both = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm2NotTiming = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmIsComplex = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm2IsTemp = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWorkState = new CommonViewer.ButtonEx();
            this.cmsFinishState = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNotDo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDidIt = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmOverdueIt = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPrint = new CommonViewer.ButtonEx();
            this.buttonEx1 = new CommonViewer.ButtonEx();
            this.grpWorkOrderList = new System.Windows.Forms.GroupBox();
            this.dgvWorkOrderHis = new CommonViewer.UcDataGridView(this.components);
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rdoAllWorkOrder = new System.Windows.Forms.RadioButton();
            this.btnSelComponent = new System.Windows.Forms.Button();
            this.labelShip = new System.Windows.Forms.Label();
            this.dtpEndFinDate = new System.Windows.Forms.DateTimePicker();
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.dtpStartFinDate = new System.Windows.Forms.DateTimePicker();
            this.cboConfirmPost = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cboPrincipalPost = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.bdsWorkOrderHis = new System.Windows.Forms.BindingSource(this.components);
            this.toolTipBtnSelComp = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.cmsIsRepairItems.SuspendLayout();
            this.cmsIsCheckItem.SuspendLayout();
            this.cmsWorkType.SuspendLayout();
            this.cmsFinishState.SuspendLayout();
            this.grpWorkOrderList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrderHis)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsWorkOrderHis)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpWorkOrderList, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox7, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 466);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.btnRepairState);
            this.panel3.Controls.Add(this.btnCheckState);
            this.panel3.Controls.Add(this.btnWorkType);
            this.panel3.Controls.Add(this.btnWorkState);
            this.panel3.Controls.Add(this.btnPrint);
            this.panel3.Controls.Add(this.buttonEx1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(984, 64);
            this.panel3.TabIndex = 54;
            // 
            // btnRepairState
            // 
            this.btnRepairState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRepairState.Arrow = CommonViewer.ButtonEx.e_arrow.ToDown;
            this.btnRepairState.BackColor = System.Drawing.Color.Transparent;
            this.btnRepairState.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnRepairState.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnRepairState.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnRepairState.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnRepairState.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnRepairState.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnRepairState.ContextMenuStrip = this.cmsIsRepairItems;
            this.btnRepairState.FadingSpeed = 20;
            this.btnRepairState.FlatAppearance.BorderSize = 0;
            this.btnRepairState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRepairState.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnRepairState.Image = ((System.Drawing.Image)(resources.GetObject("btnRepairState.Image")));
            this.btnRepairState.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnRepairState.ImageOffset = 4;
            this.btnRepairState.IsPressed = false;
            this.btnRepairState.KeepPress = false;
            this.btnRepairState.Location = new System.Drawing.Point(746, 7);
            this.btnRepairState.Margin = new System.Windows.Forms.Padding(0);
            this.btnRepairState.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnRepairState.MenuPos = new System.Drawing.Point(0, 0);
            this.btnRepairState.Name = "btnRepairState";
            this.btnRepairState.Radius = 6;
            this.btnRepairState.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnRepairState.ShowBase = true;
            this.btnRepairState.Size = new System.Drawing.Size(133, 48);
            this.btnRepairState.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnRepairState.SplitDistance = 20;
            this.btnRepairState.TabIndex = 53;
            this.btnRepairState.Text = "修理项目";
            this.btnRepairState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRepairState.Title = "";
            this.btnRepairState.UseVisualStyleBackColor = true;
            // 
            // cmsIsRepairItems
            // 
            this.cmsIsRepairItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm3All,
            this.tsmOnlyRepairItems,
            this.tsmOnlyNotRepairItems});
            this.cmsIsRepairItems.Name = "contextMenuStrip1";
            this.cmsIsRepairItems.Size = new System.Drawing.Size(147, 70);
            // 
            // tsm3All
            // 
            this.tsm3All.Name = "tsm3All";
            this.tsm3All.Size = new System.Drawing.Size(146, 22);
            this.tsm3All.Text = "全部";
            this.tsm3All.Click += new System.EventHandler(this.tsmWorkOrderRepairItem_Click);
            // 
            // tsmOnlyRepairItems
            // 
            this.tsmOnlyRepairItems.Name = "tsmOnlyRepairItems";
            this.tsmOnlyRepairItems.Size = new System.Drawing.Size(146, 22);
            this.tsmOnlyRepairItems.Text = "仅修理项目";
            this.tsmOnlyRepairItems.Click += new System.EventHandler(this.tsmWorkOrderRepairItem_Click);
            // 
            // tsmOnlyNotRepairItems
            // 
            this.tsmOnlyNotRepairItems.Name = "tsmOnlyNotRepairItems";
            this.tsmOnlyNotRepairItems.Size = new System.Drawing.Size(146, 22);
            this.tsmOnlyNotRepairItems.Text = "仅非修理项目";
            this.tsmOnlyNotRepairItems.Click += new System.EventHandler(this.tsmWorkOrderRepairItem_Click);
            // 
            // btnCheckState
            // 
            this.btnCheckState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckState.Arrow = CommonViewer.ButtonEx.e_arrow.ToDown;
            this.btnCheckState.BackColor = System.Drawing.Color.Transparent;
            this.btnCheckState.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnCheckState.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCheckState.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnCheckState.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnCheckState.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCheckState.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCheckState.ContextMenuStrip = this.cmsIsCheckItem;
            this.btnCheckState.FadingSpeed = 20;
            this.btnCheckState.FlatAppearance.BorderSize = 0;
            this.btnCheckState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckState.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnCheckState.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckState.Image")));
            this.btnCheckState.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnCheckState.ImageOffset = 4;
            this.btnCheckState.IsPressed = false;
            this.btnCheckState.KeepPress = false;
            this.btnCheckState.Location = new System.Drawing.Point(613, 7);
            this.btnCheckState.Margin = new System.Windows.Forms.Padding(0);
            this.btnCheckState.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnCheckState.MenuPos = new System.Drawing.Point(0, 0);
            this.btnCheckState.Name = "btnCheckState";
            this.btnCheckState.Radius = 6;
            this.btnCheckState.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCheckState.ShowBase = true;
            this.btnCheckState.Size = new System.Drawing.Size(133, 48);
            this.btnCheckState.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnCheckState.SplitDistance = 20;
            this.btnCheckState.TabIndex = 52;
            this.btnCheckState.Text = "检验项目";
            this.btnCheckState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCheckState.Title = "";
            this.btnCheckState.UseVisualStyleBackColor = true;
            // 
            // cmsIsCheckItem
            // 
            this.cmsIsCheckItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAllCheckItems,
            this.tsmOnlyCheckItems,
            this.tsmOnlyNotCheckItems});
            this.cmsIsCheckItem.Name = "contextMenuStrip1";
            this.cmsIsCheckItem.Size = new System.Drawing.Size(147, 70);
            // 
            // tsmAllCheckItems
            // 
            this.tsmAllCheckItems.Name = "tsmAllCheckItems";
            this.tsmAllCheckItems.Size = new System.Drawing.Size(146, 22);
            this.tsmAllCheckItems.Text = "全部";
            this.tsmAllCheckItems.Click += new System.EventHandler(this.tsmWorkOrderCheckItem_Click);
            // 
            // tsmOnlyCheckItems
            // 
            this.tsmOnlyCheckItems.Name = "tsmOnlyCheckItems";
            this.tsmOnlyCheckItems.Size = new System.Drawing.Size(146, 22);
            this.tsmOnlyCheckItems.Text = "仅检验项目";
            this.tsmOnlyCheckItems.Click += new System.EventHandler(this.tsmWorkOrderCheckItem_Click);
            // 
            // tsmOnlyNotCheckItems
            // 
            this.tsmOnlyNotCheckItems.Name = "tsmOnlyNotCheckItems";
            this.tsmOnlyNotCheckItems.Size = new System.Drawing.Size(146, 22);
            this.tsmOnlyNotCheckItems.Text = "仅非检验项目";
            this.tsmOnlyNotCheckItems.Click += new System.EventHandler(this.tsmWorkOrderCheckItem_Click);
            // 
            // btnWorkType
            // 
            this.btnWorkType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWorkType.Arrow = CommonViewer.ButtonEx.e_arrow.ToDown;
            this.btnWorkType.BackColor = System.Drawing.Color.Transparent;
            this.btnWorkType.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnWorkType.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnWorkType.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnWorkType.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnWorkType.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnWorkType.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnWorkType.ContextMenuStrip = this.cmsWorkType;
            this.btnWorkType.FadingSpeed = 20;
            this.btnWorkType.FlatAppearance.BorderSize = 0;
            this.btnWorkType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkType.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnWorkType.Image = ((System.Drawing.Image)(resources.GetObject("btnWorkType.Image")));
            this.btnWorkType.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnWorkType.ImageOffset = 2;
            this.btnWorkType.IsPressed = false;
            this.btnWorkType.KeepPress = false;
            this.btnWorkType.Location = new System.Drawing.Point(480, 7);
            this.btnWorkType.Margin = new System.Windows.Forms.Padding(0);
            this.btnWorkType.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnWorkType.MenuPos = new System.Drawing.Point(0, 0);
            this.btnWorkType.Name = "btnWorkType";
            this.btnWorkType.Radius = 6;
            this.btnWorkType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnWorkType.ShowBase = true;
            this.btnWorkType.Size = new System.Drawing.Size(133, 48);
            this.btnWorkType.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnWorkType.SplitDistance = 20;
            this.btnWorkType.TabIndex = 51;
            this.btnWorkType.Text = "工单类型";
            this.btnWorkType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWorkType.Title = "";
            this.btnWorkType.UseVisualStyleBackColor = true;
            // 
            // cmsWorkType
            // 
            this.cmsWorkType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm2All,
            this.tsm2Recycle,
            this.tsm2Timing,
            this.tsm2Both,
            this.tsm2NotTiming,
            this.tsmIsComplex,
            this.tsm2IsTemp});
            this.cmsWorkType.Name = "contextMenuStrip1";
            this.cmsWorkType.Size = new System.Drawing.Size(135, 158);
            // 
            // tsm2All
            // 
            this.tsm2All.Name = "tsm2All";
            this.tsm2All.Size = new System.Drawing.Size(134, 22);
            this.tsm2All.Text = "全部";
            this.tsm2All.Click += new System.EventHandler(this.tsmWorkOrderType_Click);
            // 
            // tsm2Recycle
            // 
            this.tsm2Recycle.Name = "tsm2Recycle";
            this.tsm2Recycle.Size = new System.Drawing.Size(134, 22);
            this.tsm2Recycle.Text = "定期";
            this.tsm2Recycle.Click += new System.EventHandler(this.tsmWorkOrderType_Click);
            // 
            // tsm2Timing
            // 
            this.tsm2Timing.Name = "tsm2Timing";
            this.tsm2Timing.Size = new System.Drawing.Size(134, 22);
            this.tsm2Timing.Text = "定时";
            this.tsm2Timing.Click += new System.EventHandler(this.tsmWorkOrderType_Click);
            // 
            // tsm2Both
            // 
            this.tsm2Both.Name = "tsm2Both";
            this.tsm2Both.Size = new System.Drawing.Size(134, 22);
            this.tsm2Both.Text = "定期与定时";
            this.tsm2Both.Click += new System.EventHandler(this.tsmWorkOrderType_Click);
            // 
            // tsm2NotTiming
            // 
            this.tsm2NotTiming.Name = "tsm2NotTiming";
            this.tsm2NotTiming.Size = new System.Drawing.Size(134, 22);
            this.tsm2NotTiming.Text = "非周期工单";
            this.tsm2NotTiming.Click += new System.EventHandler(this.tsmWorkOrderType_Click);
            // 
            // tsmIsComplex
            // 
            this.tsmIsComplex.Name = "tsmIsComplex";
            this.tsmIsComplex.Size = new System.Drawing.Size(134, 22);
            this.tsmIsComplex.Text = "合并工单";
            this.tsmIsComplex.Click += new System.EventHandler(this.tsmWorkOrderType_Click);
            // 
            // tsm2IsTemp
            // 
            this.tsm2IsTemp.Name = "tsm2IsTemp";
            this.tsm2IsTemp.Size = new System.Drawing.Size(134, 22);
            this.tsm2IsTemp.Text = "临时工单";
            this.tsm2IsTemp.Click += new System.EventHandler(this.tsmWorkOrderType_Click);
            // 
            // btnWorkState
            // 
            this.btnWorkState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWorkState.Arrow = CommonViewer.ButtonEx.e_arrow.ToDown;
            this.btnWorkState.BackColor = System.Drawing.Color.Transparent;
            this.btnWorkState.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnWorkState.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnWorkState.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnWorkState.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnWorkState.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnWorkState.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnWorkState.ContextMenuStrip = this.cmsFinishState;
            this.btnWorkState.FadingSpeed = 20;
            this.btnWorkState.FlatAppearance.BorderSize = 0;
            this.btnWorkState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWorkState.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnWorkState.Image = ((System.Drawing.Image)(resources.GetObject("btnWorkState.Image")));
            this.btnWorkState.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnWorkState.ImageOffset = 2;
            this.btnWorkState.IsPressed = false;
            this.btnWorkState.KeepPress = false;
            this.btnWorkState.Location = new System.Drawing.Point(347, 7);
            this.btnWorkState.Margin = new System.Windows.Forms.Padding(0);
            this.btnWorkState.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnWorkState.MenuPos = new System.Drawing.Point(0, 0);
            this.btnWorkState.Name = "btnWorkState";
            this.btnWorkState.Radius = 6;
            this.btnWorkState.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnWorkState.ShowBase = true;
            this.btnWorkState.Size = new System.Drawing.Size(133, 48);
            this.btnWorkState.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnWorkState.SplitDistance = 20;
            this.btnWorkState.TabIndex = 50;
            this.btnWorkState.Text = "完成状态";
            this.btnWorkState.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnWorkState.Title = "";
            this.btnWorkState.UseVisualStyleBackColor = true;
            // 
            // cmsFinishState
            // 
            this.cmsFinishState.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAll,
            this.tsmNotDo,
            this.tsmDidIt,
            this.tsmOverdueIt});
            this.cmsFinishState.Name = "contextMenuStrip1";
            this.cmsFinishState.Size = new System.Drawing.Size(147, 92);
            // 
            // tsmAll
            // 
            this.tsmAll.Name = "tsmAll";
            this.tsmAll.Size = new System.Drawing.Size(146, 22);
            this.tsmAll.Text = "全部";
            this.tsmAll.Click += new System.EventHandler(this.tsmWorkOrderState_Click);
            // 
            // tsmNotDo
            // 
            this.tsmNotDo.Name = "tsmNotDo";
            this.tsmNotDo.Size = new System.Drawing.Size(146, 22);
            this.tsmNotDo.Text = "本次免做确认";
            this.tsmNotDo.Click += new System.EventHandler(this.tsmWorkOrderState_Click);
            // 
            // tsmDidIt
            // 
            this.tsmDidIt.Name = "tsmDidIt";
            this.tsmDidIt.Size = new System.Drawing.Size(146, 22);
            this.tsmDidIt.Text = "正常确认";
            this.tsmDidIt.Click += new System.EventHandler(this.tsmWorkOrderState_Click);
            // 
            // tsmOverdueIt
            // 
            this.tsmOverdueIt.Name = "tsmOverdueIt";
            this.tsmOverdueIt.Size = new System.Drawing.Size(146, 22);
            this.tsmOverdueIt.Text = "超期确认";
            this.tsmOverdueIt.Click += new System.EventHandler(this.tsmWorkOrderState_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnPrint.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnPrint.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnPrint.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnPrint.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPrint.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPrint.FadingSpeed = 20;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnPrint.ImageOffset = 4;
            this.btnPrint.IsPressed = false;
            this.btnPrint.KeepPress = false;
            this.btnPrint.Location = new System.Drawing.Point(879, 7);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrint.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnPrint.MenuPos = new System.Drawing.Point(0, 0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Radius = 6;
            this.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnPrint.ShowBase = true;
            this.btnPrint.Size = new System.Drawing.Size(102, 48);
            this.btnPrint.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnPrint.SplitDistance = 0;
            this.btnPrint.TabIndex = 46;
            this.btnPrint.Text = "关闭";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.Title = "";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.bdNgClose_Click);
            // 
            // buttonEx1
            // 
            this.buttonEx1.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx1.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx1.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx1.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonEx1.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx1.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx1.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx1.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx1.FadingSpeed = 20;
            this.buttonEx1.FlatAppearance.BorderSize = 0;
            this.buttonEx1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx1.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx1.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx1.Image")));
            this.buttonEx1.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx1.ImageOffset = 2;
            this.buttonEx1.IsPressed = false;
            this.buttonEx1.KeepPress = false;
            this.buttonEx1.Location = new System.Drawing.Point(3, 2);
            this.buttonEx1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx1.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx1.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx1.Name = "buttonEx1";
            this.buttonEx1.Radius = 6;
            this.buttonEx1.ShowBase = false;
            this.buttonEx1.Size = new System.Drawing.Size(135, 58);
            this.buttonEx1.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx1.SplitDistance = 0;
            this.buttonEx1.TabIndex = 48;
            this.buttonEx1.Text = "查询条件";
            this.buttonEx1.Title = "";
            this.buttonEx1.UseVisualStyleBackColor = true;
            // 
            // grpWorkOrderList
            // 
            this.grpWorkOrderList.Controls.Add(this.dgvWorkOrderHis);
            this.grpWorkOrderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpWorkOrderList.Location = new System.Drawing.Point(3, 142);
            this.grpWorkOrderList.Name = "grpWorkOrderList";
            this.grpWorkOrderList.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.grpWorkOrderList.Size = new System.Drawing.Size(978, 321);
            this.grpWorkOrderList.TabIndex = 12;
            this.grpWorkOrderList.TabStop = false;
            this.grpWorkOrderList.Text = "工单历史信息列表";
            // 
            // dgvWorkOrderHis
            // 
            this.dgvWorkOrderHis.AllowUserToAddRows = false;
            this.dgvWorkOrderHis.AllowUserToDeleteRows = false;
            this.dgvWorkOrderHis.AllowUserToOrderColumns = true;
            this.dgvWorkOrderHis.AutoFit = true;
            this.dgvWorkOrderHis.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvWorkOrderHis.ColumnDeep = 1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkOrderHis.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvWorkOrderHis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWorkOrderHis.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvWorkOrderHis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorkOrderHis.EnableHeadersVisualStyles = false;
            this.dgvWorkOrderHis.ExportColorToExcel = false;
            this.dgvWorkOrderHis.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkOrderHis.Footer")));
            this.dgvWorkOrderHis.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvWorkOrderHis.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkOrderHis.Header")));
            this.dgvWorkOrderHis.LoadedFinish = false;
            this.dgvWorkOrderHis.Location = new System.Drawing.Point(8, 17);
            this.dgvWorkOrderHis.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkOrderHis.MergeColumnNames")));
            this.dgvWorkOrderHis.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkOrderHis.MergeRowColumn")));
            this.dgvWorkOrderHis.Name = "dgvWorkOrderHis";
            this.dgvWorkOrderHis.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkOrderHis.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvWorkOrderHis.RowHeadersWidth = 25;
            this.dgvWorkOrderHis.RowTemplate.Height = 23;
            this.dgvWorkOrderHis.ShowRowNumber = false;
            this.dgvWorkOrderHis.Size = new System.Drawing.Size(962, 296);
            this.dgvWorkOrderHis.TabIndex = 6;
            this.dgvWorkOrderHis.Title = "";
            this.dgvWorkOrderHis.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvWorkOrderHis_CellMouseDoubleClick);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rdoAllWorkOrder);
            this.groupBox7.Controls.Add(this.btnSelComponent);
            this.groupBox7.Controls.Add(this.labelShip);
            this.groupBox7.Controls.Add(this.dtpEndFinDate);
            this.groupBox7.Controls.Add(this.ucShipSelect1);
            this.groupBox7.Controls.Add(this.dtpStartFinDate);
            this.groupBox7.Controls.Add(this.cboConfirmPost);
            this.groupBox7.Controls.Add(this.label25);
            this.groupBox7.Controls.Add(this.cboPrincipalPost);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.label24);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(3, 67);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(978, 69);
            this.groupBox7.TabIndex = 44;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "过滤条件";
            // 
            // rdoAllWorkOrder
            // 
            this.rdoAllWorkOrder.AutoSize = true;
            this.rdoAllWorkOrder.BackColor = System.Drawing.Color.AliceBlue;
            this.rdoAllWorkOrder.Checked = true;
            this.rdoAllWorkOrder.Location = new System.Drawing.Point(303, 31);
            this.rdoAllWorkOrder.Name = "rdoAllWorkOrder";
            this.rdoAllWorkOrder.Size = new System.Drawing.Size(71, 16);
            this.rdoAllWorkOrder.TabIndex = 30;
            this.rdoAllWorkOrder.TabStop = true;
            this.rdoAllWorkOrder.Text = "显示所有";
            this.rdoAllWorkOrder.UseVisualStyleBackColor = false;
            this.rdoAllWorkOrder.CheckedChanged += new System.EventHandler(this.rdoAllWorkOrder_CheckedChanged);
            // 
            // btnSelComponent
            // 
            this.btnSelComponent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelComponent.Image = ((System.Drawing.Image)(resources.GetObject("btnSelComponent.Image")));
            this.btnSelComponent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelComponent.Location = new System.Drawing.Point(183, 20);
            this.btnSelComponent.Name = "btnSelComponent";
            this.btnSelComponent.Size = new System.Drawing.Size(201, 39);
            this.btnSelComponent.TabIndex = 29;
            this.btnSelComponent.Text = "    指定设备…";
            this.btnSelComponent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTipBtnSelComp.SetToolTip(this.btnSelComponent, "根据设备及其子设备进行选择");
            this.btnSelComponent.UseVisualStyleBackColor = true;
            this.btnSelComponent.Click += new System.EventHandler(this.btnSelComponent_Click);
            // 
            // labelShip
            // 
            this.labelShip.AutoSize = true;
            this.labelShip.Location = new System.Drawing.Point(21, 34);
            this.labelShip.Name = "labelShip";
            this.labelShip.Size = new System.Drawing.Size(29, 12);
            this.labelShip.TabIndex = 31;
            this.labelShip.Text = "船舶";
            this.labelShip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpEndFinDate
            // 
            this.dtpEndFinDate.CustomFormat = "yyyy-MM-dd";
            this.dtpEndFinDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndFinDate.Location = new System.Drawing.Point(551, 28);
            this.dtpEndFinDate.Name = "dtpEndFinDate";
            this.dtpEndFinDate.Size = new System.Drawing.Size(82, 21);
            this.dtpEndFinDate.TabIndex = 1;
            this.dtpEndFinDate.CloseUp += new System.EventHandler(this.dtpEndFinDate_CloseUp);
            // 
            // ucShipSelect1
            // 
            this.ucShipSelect1.CanEdit = false;
            this.ucShipSelect1.DropDownWidth = 136;
            this.ucShipSelect1.Location = new System.Drawing.Point(56, 30);
            this.ucShipSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipSelect1.Name = "ucShipSelect1";
            this.ucShipSelect1.NullValueShow = "所有船";
            this.ucShipSelect1.ShowButton = false;
            this.ucShipSelect1.Size = new System.Drawing.Size(121, 20);
            this.ucShipSelect1.TabIndex = 49;            
            // 
            // dtpStartFinDate
            // 
            this.dtpStartFinDate.CustomFormat = "yyyy-MM-dd";
            this.dtpStartFinDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartFinDate.Location = new System.Drawing.Point(448, 28);
            this.dtpStartFinDate.Name = "dtpStartFinDate";
            this.dtpStartFinDate.Size = new System.Drawing.Size(82, 21);
            this.dtpStartFinDate.TabIndex = 0;
            this.dtpStartFinDate.CloseUp += new System.EventHandler(this.dtpStartFinDate_CloseUp);
            // 
            // cboConfirmPost
            // 
            this.cboConfirmPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConfirmPost.FormattingEnabled = true;
            this.cboConfirmPost.Location = new System.Drawing.Point(877, 29);
            this.cboConfirmPost.Name = "cboConfirmPost";
            this.cboConfirmPost.Size = new System.Drawing.Size(80, 20);
            this.cboConfirmPost.TabIndex = 5;
            this.cboConfirmPost.DropDownClosed += new System.EventHandler(this.cboConfirmPost_DropDownClosed);
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(809, 30);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 18);
            this.label25.TabIndex = 4;
            this.label25.Text = "确认人岗位";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPrincipalPost
            // 
            this.cboPrincipalPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrincipalPost.FormattingEnabled = true;
            this.cboPrincipalPost.Location = new System.Drawing.Point(715, 29);
            this.cboPrincipalPost.Name = "cboPrincipalPost";
            this.cboPrincipalPost.Size = new System.Drawing.Size(80, 20);
            this.cboPrincipalPost.TabIndex = 4;
            this.cboPrincipalPost.DropDownClosed += new System.EventHandler(this.cboPrincipalPost_DropDownClosed);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(536, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(9, 7);
            this.label2.TabIndex = 4;
            this.label2.Text = "~";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(390, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "完工日期";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(648, 30);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(68, 18);
            this.label24.TabIndex = 4;
            this.label24.Text = "责任人岗位";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmWorkOrderHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 466);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmWorkOrderHistory";
            this.Text = "工单历史信息查看";
            this.Load += new System.EventHandler(this.FrmWorkOrderHistory_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWorkOrderHistory_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.cmsIsRepairItems.ResumeLayout(false);
            this.cmsIsCheckItem.ResumeLayout(false);
            this.cmsWorkType.ResumeLayout(false);
            this.cmsFinishState.ResumeLayout(false);
            this.grpWorkOrderList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrderHis)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsWorkOrderHis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grpWorkOrderList;
        private CommonViewer.UcDataGridView dgvWorkOrderHis;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox cboConfirmPost;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cboPrincipalPost;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEndFinDate;
        private System.Windows.Forms.DateTimePicker dtpStartFinDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource bdsWorkOrderHis;
        private System.Windows.Forms.Button btnSelComponent;
        private System.Windows.Forms.ToolTip toolTipBtnSelComp;
        private CommonViewer.ButtonEx btnPrint;
        private System.Windows.Forms.Panel panel3;
        private CommonViewer.ButtonEx buttonEx1;
        private System.Windows.Forms.Label labelShip;
        private BaseInfo.Viewer.UcShipSelect ucShipSelect1;
        private System.Windows.Forms.ContextMenuStrip cmsFinishState;
        private System.Windows.Forms.ToolStripMenuItem tsmAll;
        private System.Windows.Forms.ToolStripMenuItem tsmNotDo;
        private System.Windows.Forms.ToolStripMenuItem tsmDidIt;
        private System.Windows.Forms.ToolStripMenuItem tsmOverdueIt;
        private CommonViewer.ButtonEx btnWorkState;
        private System.Windows.Forms.ContextMenuStrip cmsWorkType;
        private System.Windows.Forms.ToolStripMenuItem tsm2All;
        private System.Windows.Forms.ToolStripMenuItem tsm2Recycle;
        private System.Windows.Forms.ToolStripMenuItem tsm2Timing;
        private System.Windows.Forms.ToolStripMenuItem tsm2Both;
        private System.Windows.Forms.ToolStripMenuItem tsm2NotTiming;
        private System.Windows.Forms.ToolStripMenuItem tsmIsComplex;
        private System.Windows.Forms.ToolStripMenuItem tsm2IsTemp;
        private CommonViewer.ButtonEx btnWorkType;
        private System.Windows.Forms.RadioButton rdoAllWorkOrder;
        private CommonViewer.ButtonEx btnRepairState;
        private CommonViewer.ButtonEx btnCheckState;
        private System.Windows.Forms.ContextMenuStrip cmsIsCheckItem;
        private System.Windows.Forms.ToolStripMenuItem tsmAllCheckItems;
        private System.Windows.Forms.ToolStripMenuItem tsmOnlyCheckItems;
        private System.Windows.Forms.ToolStripMenuItem tsmOnlyNotCheckItems;
        private System.Windows.Forms.ContextMenuStrip cmsIsRepairItems;
        private System.Windows.Forms.ToolStripMenuItem tsm3All;
        private System.Windows.Forms.ToolStripMenuItem tsmOnlyRepairItems;
        private System.Windows.Forms.ToolStripMenuItem tsmOnlyNotRepairItems;
    }
}