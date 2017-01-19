namespace Maintenance.Viewer
{
    partial class FrmToolWorkInfoMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmToolWorkInfoMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cobReportType = new System.Windows.Forms.ComboBox();
            this.monthButton = new CommonViewer.ButtonEx();
            this.postButton = new CommonViewer.ButtonEx();
            this.wfPersistHistoryButton = new CommonViewer.ButtonEx();
            this.cobShip = new System.Windows.Forms.ComboBox();
            this.CompentUnitLinkButton = new CommonViewer.ButtonEx();
            this.timingAutoButton = new CommonViewer.ButtonEx();
            this.circleAutoButton = new CommonViewer.ButtonEx();
            this.ClearButton = new CommonViewer.ButtonEx();
            this.ParamButton = new CommonViewer.ButtonEx();
            this.buttonEx5 = new CommonViewer.ButtonEx();
            this.CloseButton = new CommonViewer.ButtonEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvOne = new CommonViewer.UcDataGridView(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 730);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.cobReportType);
            this.panel3.Controls.Add(this.monthButton);
            this.panel3.Controls.Add(this.postButton);
            this.panel3.Controls.Add(this.wfPersistHistoryButton);
            this.panel3.Controls.Add(this.cobShip);
            this.panel3.Controls.Add(this.CompentUnitLinkButton);
            this.panel3.Controls.Add(this.timingAutoButton);
            this.panel3.Controls.Add(this.circleAutoButton);
            this.panel3.Controls.Add(this.ClearButton);
            this.panel3.Controls.Add(this.ParamButton);
            this.panel3.Controls.Add(this.buttonEx5);
            this.panel3.Controls.Add(this.CloseButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 50);
            this.panel3.TabIndex = 50;
            // 
            // cobReportType
            // 
            this.cobReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobReportType.FormattingEnabled = true;
            this.cobReportType.Items.AddRange(new object[] {
            "甲板部",
            "轮机部"});
            this.cobReportType.Location = new System.Drawing.Point(321, 21);
            this.cobReportType.Name = "cobReportType";
            this.cobReportType.Size = new System.Drawing.Size(121, 20);
            this.cobReportType.TabIndex = 36;
            this.cobReportType.SelectedIndexChanged += new System.EventHandler(this.cobReportType_SelectedIndexChanged);
            // 
            // monthButton
            // 
            this.monthButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.monthButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.monthButton.BackColor = System.Drawing.Color.Transparent;
            this.monthButton.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.monthButton.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.monthButton.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.monthButton.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.monthButton.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.monthButton.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.monthButton.FadingSpeed = 20;
            this.monthButton.FlatAppearance.BorderSize = 0;
            this.monthButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.monthButton.Font = new System.Drawing.Font("宋体", 9F);
            this.monthButton.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.monthButton.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Right;
            this.monthButton.ImageOffset = 10;
            this.monthButton.IsPressed = false;
            this.monthButton.KeepPress = false;
            this.monthButton.Location = new System.Drawing.Point(541, 7);
            this.monthButton.Margin = new System.Windows.Forms.Padding(0);
            this.monthButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.monthButton.MenuPos = new System.Drawing.Point(0, 0);
            this.monthButton.Name = "monthButton";
            this.monthButton.Radius = 6;
            this.monthButton.ShowBase = true;
            this.monthButton.Size = new System.Drawing.Size(76, 37);
            this.monthButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.monthButton.SplitDistance = 0;
            this.monthButton.TabIndex = 35;
            this.monthButton.Text = " 初始化周期";
            this.monthButton.Title = "   月勾选";
            this.monthButton.UseVisualStyleBackColor = false;
            this.monthButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.monthButton_MouseMove);
            this.monthButton.Click += new System.EventHandler(this.monthButton_Click);
            // 
            // postButton
            // 
            this.postButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.postButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.postButton.BackColor = System.Drawing.Color.Transparent;
            this.postButton.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.postButton.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.postButton.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.postButton.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.postButton.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.postButton.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.postButton.FadingSpeed = 20;
            this.postButton.FlatAppearance.BorderSize = 0;
            this.postButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.postButton.Font = new System.Drawing.Font("宋体", 9F);
            this.postButton.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.postButton.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Right;
            this.postButton.ImageOffset = 0;
            this.postButton.IsPressed = false;
            this.postButton.KeepPress = false;
            this.postButton.Location = new System.Drawing.Point(764, 7);
            this.postButton.Margin = new System.Windows.Forms.Padding(0);
            this.postButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.postButton.MenuPos = new System.Drawing.Point(0, 0);
            this.postButton.Name = "postButton";
            this.postButton.Radius = 6;
            this.postButton.ShowBase = true;
            this.postButton.Size = new System.Drawing.Size(39, 37);
            this.postButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.postButton.SplitDistance = 0;
            this.postButton.TabIndex = 33;
            this.postButton.Text = " 生成";
            this.postButton.Title = " 岗位";
            this.postButton.UseVisualStyleBackColor = true;
            this.postButton.Click += new System.EventHandler(this.postButton_Click);
            // 
            // wfPersistHistoryButton
            // 
            this.wfPersistHistoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.wfPersistHistoryButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.wfPersistHistoryButton.BackColor = System.Drawing.Color.Transparent;
            this.wfPersistHistoryButton.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.wfPersistHistoryButton.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.wfPersistHistoryButton.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.wfPersistHistoryButton.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.wfPersistHistoryButton.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.wfPersistHistoryButton.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.wfPersistHistoryButton.FadingSpeed = 20;
            this.wfPersistHistoryButton.FlatAppearance.BorderSize = 0;
            this.wfPersistHistoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wfPersistHistoryButton.Font = new System.Drawing.Font("宋体", 9F);
            this.wfPersistHistoryButton.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.wfPersistHistoryButton.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Right;
            this.wfPersistHistoryButton.ImageOffset = 0;
            this.wfPersistHistoryButton.IsPressed = false;
            this.wfPersistHistoryButton.KeepPress = false;
            this.wfPersistHistoryButton.Location = new System.Drawing.Point(617, 7);
            this.wfPersistHistoryButton.Margin = new System.Windows.Forms.Padding(0);
            this.wfPersistHistoryButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.wfPersistHistoryButton.MenuPos = new System.Drawing.Point(0, 0);
            this.wfPersistHistoryButton.Name = "wfPersistHistoryButton";
            this.wfPersistHistoryButton.Radius = 6;
            this.wfPersistHistoryButton.ShowBase = true;
            this.wfPersistHistoryButton.Size = new System.Drawing.Size(66, 37);
            this.wfPersistHistoryButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.wfPersistHistoryButton.SplitDistance = 0;
            this.wfPersistHistoryButton.TabIndex = 32;
            this.wfPersistHistoryButton.Text = "  工作表";
            this.wfPersistHistoryButton.Title = " 导入真实";
            this.wfPersistHistoryButton.UseVisualStyleBackColor = true;
            this.wfPersistHistoryButton.Click += new System.EventHandler(this.wfPersistHistoryButton_Click);
            // 
            // cobShip
            // 
            this.cobShip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobShip.FormattingEnabled = true;
            this.cobShip.Location = new System.Drawing.Point(192, 21);
            this.cobShip.Name = "cobShip";
            this.cobShip.Size = new System.Drawing.Size(123, 20);
            this.cobShip.TabIndex = 31;
            this.cobShip.SelectedValueChanged += new System.EventHandler(this.cobShip_SelectedValueChanged);
            // 
            // CompentUnitLinkButton
            // 
            this.CompentUnitLinkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CompentUnitLinkButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.CompentUnitLinkButton.BackColor = System.Drawing.Color.Transparent;
            this.CompentUnitLinkButton.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.CompentUnitLinkButton.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.CompentUnitLinkButton.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.CompentUnitLinkButton.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.CompentUnitLinkButton.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CompentUnitLinkButton.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.CompentUnitLinkButton.FadingSpeed = 20;
            this.CompentUnitLinkButton.FlatAppearance.BorderSize = 0;
            this.CompentUnitLinkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CompentUnitLinkButton.Font = new System.Drawing.Font("宋体", 9F);
            this.CompentUnitLinkButton.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.CompentUnitLinkButton.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Right;
            this.CompentUnitLinkButton.ImageOffset = 0;
            this.CompentUnitLinkButton.IsPressed = false;
            this.CompentUnitLinkButton.KeepPress = false;
            this.CompentUnitLinkButton.Location = new System.Drawing.Point(803, 7);
            this.CompentUnitLinkButton.Margin = new System.Windows.Forms.Padding(0);
            this.CompentUnitLinkButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.CompentUnitLinkButton.MenuPos = new System.Drawing.Point(0, 0);
            this.CompentUnitLinkButton.Name = "CompentUnitLinkButton";
            this.CompentUnitLinkButton.Radius = 6;
            this.CompentUnitLinkButton.ShowBase = true;
            this.CompentUnitLinkButton.Size = new System.Drawing.Size(40, 37);
            this.CompentUnitLinkButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.CompentUnitLinkButton.SplitDistance = 0;
            this.CompentUnitLinkButton.TabIndex = 30;
            this.CompentUnitLinkButton.Text = " 关联";
            this.CompentUnitLinkButton.Title = " 设备";
            this.CompentUnitLinkButton.UseVisualStyleBackColor = true;
            this.CompentUnitLinkButton.Click += new System.EventHandler(this.CompentUnitLinkButton_Click);
            // 
            // timingAutoButton
            // 
            this.timingAutoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timingAutoButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.timingAutoButton.BackColor = System.Drawing.Color.Transparent;
            this.timingAutoButton.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.timingAutoButton.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.timingAutoButton.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.timingAutoButton.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.timingAutoButton.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.timingAutoButton.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.timingAutoButton.FadingSpeed = 20;
            this.timingAutoButton.FlatAppearance.BorderSize = 0;
            this.timingAutoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timingAutoButton.Font = new System.Drawing.Font("宋体", 9F);
            this.timingAutoButton.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.timingAutoButton.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Right;
            this.timingAutoButton.ImageOffset = 0;
            this.timingAutoButton.IsPressed = false;
            this.timingAutoButton.KeepPress = false;
            this.timingAutoButton.Location = new System.Drawing.Point(683, 7);
            this.timingAutoButton.Margin = new System.Windows.Forms.Padding(0);
            this.timingAutoButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.timingAutoButton.MenuPos = new System.Drawing.Point(0, 0);
            this.timingAutoButton.Name = "timingAutoButton";
            this.timingAutoButton.Radius = 6;
            this.timingAutoButton.ShowBase = true;
            this.timingAutoButton.Size = new System.Drawing.Size(40, 37);
            this.timingAutoButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.timingAutoButton.SplitDistance = 0;
            this.timingAutoButton.TabIndex = 29;
            this.timingAutoButton.Text = " 生成";
            this.timingAutoButton.Title = " 定时";
            this.timingAutoButton.UseVisualStyleBackColor = true;
            this.timingAutoButton.Click += new System.EventHandler(this.timingAutoButton_Click);
            // 
            // circleAutoButton
            // 
            this.circleAutoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.circleAutoButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.circleAutoButton.BackColor = System.Drawing.Color.Transparent;
            this.circleAutoButton.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.circleAutoButton.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.circleAutoButton.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.circleAutoButton.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.circleAutoButton.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.circleAutoButton.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.circleAutoButton.FadingSpeed = 20;
            this.circleAutoButton.FlatAppearance.BorderSize = 0;
            this.circleAutoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circleAutoButton.Font = new System.Drawing.Font("宋体", 9F);
            this.circleAutoButton.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.circleAutoButton.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Right;
            this.circleAutoButton.ImageOffset = 0;
            this.circleAutoButton.IsPressed = false;
            this.circleAutoButton.KeepPress = false;
            this.circleAutoButton.Location = new System.Drawing.Point(723, 7);
            this.circleAutoButton.Margin = new System.Windows.Forms.Padding(0);
            this.circleAutoButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.circleAutoButton.MenuPos = new System.Drawing.Point(0, 0);
            this.circleAutoButton.Name = "circleAutoButton";
            this.circleAutoButton.Radius = 6;
            this.circleAutoButton.ShowBase = true;
            this.circleAutoButton.Size = new System.Drawing.Size(41, 37);
            this.circleAutoButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.circleAutoButton.SplitDistance = 0;
            this.circleAutoButton.TabIndex = 28;
            this.circleAutoButton.Text = " 生成";
            this.circleAutoButton.Title = " 周期";
            this.circleAutoButton.UseVisualStyleBackColor = true;
            this.circleAutoButton.Click += new System.EventHandler(this.circleAutoButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.ClearButton.BackColor = System.Drawing.Color.Transparent;
            this.ClearButton.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.ClearButton.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClearButton.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.ClearButton.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.ClearButton.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClearButton.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClearButton.FadingSpeed = 20;
            this.ClearButton.FlatAppearance.BorderSize = 0;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearButton.Font = new System.Drawing.Font("宋体", 9F);
            this.ClearButton.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.ClearButton.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Right;
            this.ClearButton.ImageOffset = 0;
            this.ClearButton.IsPressed = false;
            this.ClearButton.KeepPress = false;
            this.ClearButton.Location = new System.Drawing.Point(883, 7);
            this.ClearButton.Margin = new System.Windows.Forms.Padding(0);
            this.ClearButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.ClearButton.MenuPos = new System.Drawing.Point(0, 0);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Radius = 6;
            this.ClearButton.ShowBase = true;
            this.ClearButton.Size = new System.Drawing.Size(39, 37);
            this.ClearButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.ClearButton.SplitDistance = 0;
            this.ClearButton.TabIndex = 27;
            this.ClearButton.Text = " 数据";
            this.ClearButton.Title = " 清空";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ParamButton
            // 
            this.ParamButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ParamButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.ParamButton.BackColor = System.Drawing.Color.Transparent;
            this.ParamButton.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.ParamButton.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ParamButton.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.ParamButton.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.ParamButton.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ParamButton.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ParamButton.FadingSpeed = 20;
            this.ParamButton.FlatAppearance.BorderSize = 0;
            this.ParamButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ParamButton.Font = new System.Drawing.Font("宋体", 9F);
            this.ParamButton.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.ParamButton.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Right;
            this.ParamButton.ImageOffset = 0;
            this.ParamButton.IsPressed = false;
            this.ParamButton.KeepPress = false;
            this.ParamButton.Location = new System.Drawing.Point(843, 7);
            this.ParamButton.Margin = new System.Windows.Forms.Padding(0);
            this.ParamButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.ParamButton.MenuPos = new System.Drawing.Point(0, 0);
            this.ParamButton.Name = "ParamButton";
            this.ParamButton.Radius = 6;
            this.ParamButton.ShowBase = true;
            this.ParamButton.Size = new System.Drawing.Size(40, 37);
            this.ParamButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.ParamButton.SplitDistance = 0;
            this.ParamButton.TabIndex = 26;
            this.ParamButton.Text = " 参数";
            this.ParamButton.Title = " 配置";
            this.ParamButton.UseVisualStyleBackColor = true;
            this.ParamButton.Click += new System.EventHandler(this.ParamButton_Click);
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
            this.buttonEx5.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonEx5.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx5.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx5.Image")));
            this.buttonEx5.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx5.ImageOffset = 3;
            this.buttonEx5.IsPressed = false;
            this.buttonEx5.KeepPress = false;
            this.buttonEx5.Location = new System.Drawing.Point(3, 3);
            this.buttonEx5.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx5.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx5.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx5.Name = "buttonEx5";
            this.buttonEx5.Radius = 6;
            this.buttonEx5.ShowBase = false;
            this.buttonEx5.Size = new System.Drawing.Size(181, 43);
            this.buttonEx5.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx5.SplitDistance = 0;
            this.buttonEx5.TabIndex = 25;
            this.buttonEx5.Text = "PMS初始化工具";
            this.buttonEx5.Title = "";
            this.buttonEx5.UseVisualStyleBackColor = true;
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
            this.CloseButton.Location = new System.Drawing.Point(925, 7);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.CloseButton.MenuPos = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Radius = 6;
            this.CloseButton.ShowBase = true;
            this.CloseButton.Size = new System.Drawing.Size(78, 37);
            this.CloseButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.CloseButton.SplitDistance = 0;
            this.CloseButton.TabIndex = 21;
            this.CloseButton.Text = "关闭";
            this.CloseButton.Title = "";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.bdNgClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvOne);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1002, 674);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工作信息临时表";
            // 
            // dgvOne
            // 
            this.dgvOne.AllowDrop = true;
            this.dgvOne.AllowUserToAddRows = false;
            this.dgvOne.AllowUserToDeleteRows = false;
            this.dgvOne.AllowUserToOrderColumns = true;
            this.dgvOne.AutoFit = true;
            this.dgvOne.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvOne.ColumnDeep = 1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOne.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOne.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOne.EnableHeadersVisualStyles = false;
            this.dgvOne.ExportColorToExcel = false;
            this.dgvOne.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvOne.Footer")));
            this.dgvOne.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvOne.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvOne.Header")));
            this.dgvOne.LoadedFinish = false;
            this.dgvOne.Location = new System.Drawing.Point(3, 17);
            this.dgvOne.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvOne.MergeColumnNames")));
            this.dgvOne.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvOne.MergeRowColumn")));
            this.dgvOne.Name = "dgvOne";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOne.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvOne.RowHeadersWidth = 30;
            this.dgvOne.RowTemplate.Height = 23;
            this.dgvOne.ShowRowNumber = true;
            this.dgvOne.Size = new System.Drawing.Size(996, 654);
            this.dgvOne.TabIndex = 0;
            this.dgvOne.Title = null;
            this.dgvOne.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOne_CellValueChanged);
            this.dgvOne.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvOne_CellMouseClick);
            this.dgvOne.Sorted += new System.EventHandler(this.dgvOne_Sorted);
            this.dgvOne.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvOne_MouseMove);
            this.dgvOne.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvOne_CellMouseDown);
            this.dgvOne.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvOne_CellMouseMove);
            this.dgvOne.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvOne_DragEnter);
            this.dgvOne.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvOne_DragDrop);
            // 
            // FrmToolWorkInfoMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmToolWorkInfoMain";
            this.Text = "PMS初始化工具";
            this.Load += new System.EventHandler(this.FrmPortInfo_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPortInfo_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private CommonViewer.ButtonEx buttonEx5;
        private CommonViewer.ButtonEx CloseButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private CommonViewer.UcDataGridView dgvOne;
        private CommonViewer.ButtonEx ParamButton;
        private CommonViewer.ButtonEx ClearButton;
        private System.Windows.Forms.BindingSource bindingSource1;
        private CommonViewer.ButtonEx timingAutoButton;
        private CommonViewer.ButtonEx circleAutoButton;
        private CommonViewer.ButtonEx CompentUnitLinkButton;
        private System.Windows.Forms.ComboBox cobShip;
        private CommonViewer.ButtonEx wfPersistHistoryButton;
        private CommonViewer.ButtonEx postButton;
        private CommonViewer.ButtonEx monthButton;
        private System.Windows.Forms.ComboBox cobReportType;

    }
}