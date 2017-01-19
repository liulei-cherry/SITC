namespace Maintenance.Viewer
{
    partial class FrmToolWorkInfoPH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmToolWorkInfoPH));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpYear = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cobreportType = new System.Windows.Forms.ComboBox();
            this.ImportButton = new CommonViewer.ButtonEx();
            this.autoLinkButton = new CommonViewer.ButtonEx();
            this.saveButton = new CommonViewer.ButtonEx();
            this.buttonEx5 = new CommonViewer.ButtonEx();
            this.CloseButton = new CommonViewer.ButtonEx();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvOne = new CommonViewer.UcDataGridView(this.components);
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvTwo = new CommonViewer.UcDataGridView(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvThree = new CommonViewer.UcDataGridView(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOne)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTwo)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThree)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(878, 616);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dtpYear);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cobreportType);
            this.panel3.Controls.Add(this.ImportButton);
            this.panel3.Controls.Add(this.autoLinkButton);
            this.panel3.Controls.Add(this.saveButton);
            this.panel3.Controls.Add(this.buttonEx5);
            this.panel3.Controls.Add(this.CloseButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(878, 50);
            this.panel3.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 50;
            this.label2.Text = "年份";
            // 
            // dtpYear
            // 
            this.dtpYear.CustomFormat = "yyyy";
            this.dtpYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpYear.Location = new System.Drawing.Point(341, 17);
            this.dtpYear.Name = "dtpYear";
            this.dtpYear.Size = new System.Drawing.Size(69, 21);
            this.dtpYear.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 48;
            this.label1.Text = "报表类型";
            // 
            // cobreportType
            // 
            this.cobreportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobreportType.FormattingEnabled = true;
            this.cobreportType.Items.AddRange(new object[] {
            "甲板类型",
            "轮机类型"});
            this.cobreportType.Location = new System.Drawing.Point(196, 18);
            this.cobreportType.Name = "cobreportType";
            this.cobreportType.Size = new System.Drawing.Size(95, 20);
            this.cobreportType.TabIndex = 47;
            // 
            // ImportButton
            // 
            this.ImportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.ImportButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ImportButton.BackColor = System.Drawing.Color.Transparent;
            this.ImportButton.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.ImportButton.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.ImportButton.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.ImportButton.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.ImportButton.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ImportButton.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ImportButton.FadingSpeed = 20;
            this.ImportButton.FlatAppearance.BorderSize = 0;
            this.ImportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImportButton.Font = new System.Drawing.Font("宋体", 9F);
            this.ImportButton.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.ImportButton.Image = ((System.Drawing.Image)(resources.GetObject("ImportButton.Image")));
            this.ImportButton.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.ImportButton.ImageOffset = 4;
            this.ImportButton.IsPressed = false;
            this.ImportButton.KeepPress = false;
            this.ImportButton.Location = new System.Drawing.Point(525, 3);
            this.ImportButton.Margin = new System.Windows.Forms.Padding(0);
            this.ImportButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.ImportButton.MenuPos = new System.Drawing.Point(0, 0);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Radius = 6;
            this.ImportButton.ShowBase = true;
            this.ImportButton.Size = new System.Drawing.Size(83, 45);
            this.ImportButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.ImportButton.SplitDistance = 0;
            this.ImportButton.TabIndex = 46;
            this.ImportButton.Text = "导入";
            this.ImportButton.Title = "";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // autoLinkButton
            // 
            this.autoLinkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoLinkButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.autoLinkButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.autoLinkButton.BackColor = System.Drawing.Color.Transparent;
            this.autoLinkButton.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.autoLinkButton.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.autoLinkButton.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.autoLinkButton.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.autoLinkButton.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.autoLinkButton.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.autoLinkButton.FadingSpeed = 20;
            this.autoLinkButton.FlatAppearance.BorderSize = 0;
            this.autoLinkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.autoLinkButton.Font = new System.Drawing.Font("宋体", 9F);
            this.autoLinkButton.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.autoLinkButton.Image = ((System.Drawing.Image)(resources.GetObject("autoLinkButton.Image")));
            this.autoLinkButton.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.autoLinkButton.ImageOffset = 4;
            this.autoLinkButton.IsPressed = false;
            this.autoLinkButton.KeepPress = false;
            this.autoLinkButton.Location = new System.Drawing.Point(610, 3);
            this.autoLinkButton.Margin = new System.Windows.Forms.Padding(0);
            this.autoLinkButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.autoLinkButton.MenuPos = new System.Drawing.Point(0, 0);
            this.autoLinkButton.Name = "autoLinkButton";
            this.autoLinkButton.Radius = 6;
            this.autoLinkButton.ShowBase = true;
            this.autoLinkButton.Size = new System.Drawing.Size(105, 45);
            this.autoLinkButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.autoLinkButton.SplitDistance = 0;
            this.autoLinkButton.TabIndex = 45;
            this.autoLinkButton.Text = "自动匹配";
            this.autoLinkButton.Title = "";
            this.autoLinkButton.UseVisualStyleBackColor = true;
            this.autoLinkButton.Click += new System.EventHandler(this.autoLinkButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.saveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.saveButton.BackColor = System.Drawing.Color.Transparent;
            this.saveButton.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.saveButton.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.saveButton.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.saveButton.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.saveButton.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.saveButton.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.saveButton.FadingSpeed = 20;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("宋体", 9F);
            this.saveButton.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.saveButton.ImageOffset = 4;
            this.saveButton.IsPressed = false;
            this.saveButton.KeepPress = false;
            this.saveButton.Location = new System.Drawing.Point(716, 2);
            this.saveButton.Margin = new System.Windows.Forms.Padding(0);
            this.saveButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.saveButton.MenuPos = new System.Drawing.Point(0, 0);
            this.saveButton.Name = "saveButton";
            this.saveButton.Radius = 6;
            this.saveButton.ShowBase = true;
            this.saveButton.Size = new System.Drawing.Size(82, 45);
            this.saveButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.saveButton.SplitDistance = 0;
            this.saveButton.TabIndex = 44;
            this.saveButton.Text = "保存";
            this.saveButton.Title = "";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
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
            this.buttonEx5.Size = new System.Drawing.Size(132, 43);
            this.buttonEx5.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx5.SplitDistance = 0;
            this.buttonEx5.TabIndex = 25;
            this.buttonEx5.Text = "字段映射";
            this.buttonEx5.Title = "";
            this.buttonEx5.UseVisualStyleBackColor = true;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.CloseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
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
            this.CloseButton.Location = new System.Drawing.Point(799, 3);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.CloseButton.MenuPos = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Radius = 6;
            this.CloseButton.ShowBase = true;
            this.CloseButton.Size = new System.Drawing.Size(76, 43);
            this.CloseButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.CloseButton.SplitDistance = 0;
            this.CloseButton.TabIndex = 21;
            this.CloseButton.Text = "关闭";
            this.CloseButton.Title = "";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.bdNgClose_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 53);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer1.Size = new System.Drawing.Size(872, 560);
            this.splitContainer1.SplitterDistance = 410;
            this.splitContainer1.TabIndex = 49;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvOne);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 560);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工具信息临时表列";
            // 
            // dgvOne
            // 
            this.dgvOne.AllowUserToAddRows = false;
            this.dgvOne.AllowUserToDeleteRows = false;
            this.dgvOne.AllowUserToOrderColumns = true;
            this.dgvOne.AutoFit = true;
            this.dgvOne.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOne.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvOne.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOne.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOne.DefaultCellStyle = dataGridViewCellStyle2;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOne.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOne.RowHeadersWidth = 30;
            this.dgvOne.RowTemplate.Height = 23;
            this.dgvOne.ShowRowNumber = true;
            this.dgvOne.Size = new System.Drawing.Size(404, 540);
            this.dgvOne.TabIndex = 0;
            this.dgvOne.Title = null;
            this.dgvOne.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvOne_MouseDown);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.splitContainer3, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 560F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(458, 560);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer3.Size = new System.Drawing.Size(452, 554);
            this.splitContainer3.SplitterDistance = 262;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvTwo);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(452, 262);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "工作信息表列";
            // 
            // dgvTwo
            // 
            this.dgvTwo.AllowDrop = true;
            this.dgvTwo.AllowUserToAddRows = false;
            this.dgvTwo.AllowUserToDeleteRows = false;
            this.dgvTwo.AllowUserToOrderColumns = true;
            this.dgvTwo.AutoFit = true;
            this.dgvTwo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTwo.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvTwo.ColumnDeep = 1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTwo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTwo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTwo.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTwo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTwo.EnableHeadersVisualStyles = false;
            this.dgvTwo.ExportColorToExcel = false;
            this.dgvTwo.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvTwo.Footer")));
            this.dgvTwo.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvTwo.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvTwo.Header")));
            this.dgvTwo.LoadedFinish = false;
            this.dgvTwo.Location = new System.Drawing.Point(3, 17);
            this.dgvTwo.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvTwo.MergeColumnNames")));
            this.dgvTwo.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvTwo.MergeRowColumn")));
            this.dgvTwo.Name = "dgvTwo";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTwo.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTwo.RowHeadersWidth = 30;
            this.dgvTwo.RowTemplate.Height = 23;
            this.dgvTwo.ShowRowNumber = true;
            this.dgvTwo.Size = new System.Drawing.Size(446, 242);
            this.dgvTwo.TabIndex = 0;
            this.dgvTwo.Title = null;
            this.dgvTwo.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvTwo_DragEnter);
            this.dgvTwo.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvTwo_DragDrop);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvThree);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(452, 288);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "工作信息表格显示列";
            // 
            // dgvThree
            // 
            this.dgvThree.AllowDrop = true;
            this.dgvThree.AllowUserToAddRows = false;
            this.dgvThree.AllowUserToDeleteRows = false;
            this.dgvThree.AllowUserToOrderColumns = true;
            this.dgvThree.AutoFit = true;
            this.dgvThree.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThree.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvThree.ColumnDeep = 1;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThree.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvThree.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvThree.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvThree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvThree.EnableHeadersVisualStyles = false;
            this.dgvThree.ExportColorToExcel = false;
            this.dgvThree.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvThree.Footer")));
            this.dgvThree.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvThree.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvThree.Header")));
            this.dgvThree.LoadedFinish = false;
            this.dgvThree.Location = new System.Drawing.Point(3, 17);
            this.dgvThree.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvThree.MergeColumnNames")));
            this.dgvThree.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvThree.MergeRowColumn")));
            this.dgvThree.Name = "dgvThree";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThree.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvThree.RowHeadersWidth = 30;
            this.dgvThree.RowTemplate.Height = 23;
            this.dgvThree.ShowRowNumber = true;
            this.dgvThree.Size = new System.Drawing.Size(446, 268);
            this.dgvThree.TabIndex = 0;
            this.dgvThree.Title = null;
            this.dgvThree.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvThree_DragEnter);
            this.dgvThree.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvThree_DragDrop);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmToolWorkInfoPH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 616);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmToolWorkInfoPH";
            this.Text = "字段映射";
            this.Load += new System.EventHandler(this.FrmPortInfo_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPortInfo_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOne)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTwo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private CommonViewer.ButtonEx buttonEx5;
        private CommonViewer.ButtonEx CloseButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private CommonViewer.ButtonEx saveButton;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox1;
        private CommonViewer.UcDataGridView dgvOne;
        private System.Windows.Forms.GroupBox groupBox3;
        private CommonViewer.UcDataGridView dgvThree;
        private System.Windows.Forms.GroupBox groupBox2;
        private CommonViewer.UcDataGridView dgvTwo;
        private CommonViewer.ButtonEx autoLinkButton;
        private CommonViewer.ButtonEx ImportButton;
        private System.Windows.Forms.ComboBox cobreportType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpYear;

    }
}