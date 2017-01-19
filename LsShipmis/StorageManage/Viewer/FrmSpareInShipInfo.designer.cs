namespace StorageManage.Viewer
{
    partial class FrmSpareInShipInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSpareInShipInfo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new CommonViewer.UcDataGridView(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new CommonViewer.ButtonEx();
            this.buttonEx3 = new CommonViewer.ButtonEx();
            this.buttonEx1 = new CommonViewer.ButtonEx();
            this.buttonEx4 = new CommonViewer.ButtonEx();
            this.buttonEx2 = new CommonViewer.ButtonEx();
            this.bdsStock = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label18 = new System.Windows.Forms.Label();
            this.txtRemark = new CommonViewer.TextBoxEx();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSpareName = new CommonViewer.TextBoxEx();
            this.label21 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSpareEName = new CommonViewer.TextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAlertStock = new CommonViewer.TextBoxEx();
            this.label17 = new System.Windows.Forms.Label();
            this.txtSpareStuff = new CommonViewer.TextBoxEx();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPicNumber = new CommonViewer.TextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPicCode = new CommonViewer.TextBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPartNumberHis1 = new CommonViewer.TextBoxEx();
            this.txtPartNumberHis2 = new CommonViewer.TextBoxEx();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPartNumber = new CommonViewer.TextBoxEx();
            this.txtUnit = new CommonViewer.TextBoxEx();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStock)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AutoFit = true;
            this.dgv.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgv.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.ExportColorToExcel = false;
            this.dgv.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv.Footer")));
            this.dgv.GridColor = System.Drawing.Color.SteelBlue;
            this.dgv.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv.Header")));
            this.dgv.LoadedFinish = false;
            this.dgv.Location = new System.Drawing.Point(3, 17);
            this.dgv.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv.MergeColumnNames")));
            this.dgv.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv.MergeRowColumn")));
            this.dgv.Name = "dgv";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.RowHeadersWidth = 30;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.ShowRowNumber = true;
            this.dgv.Size = new System.Drawing.Size(518, 430);
            this.dgv.TabIndex = 0;
            this.dgv.Title = "";
            this.dgv.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv_CellValidating);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.buttonEx2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(897, 55);
            this.panel1.TabIndex = 9;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.buttonEx3);
            this.flowLayoutPanel1.Controls.Add(this.buttonEx1);
            this.flowLayoutPanel1.Controls.Add(this.buttonEx4);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(510, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(380, 49);
            this.flowLayoutPanel1.TabIndex = 27;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnClose.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnClose.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnClose.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnClose.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnClose.FadingSpeed = 20;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnClose.ImageOffset = 6;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.IsPressed = false;
            this.btnClose.KeepPress = false;
            this.btnClose.Location = new System.Drawing.Point(333, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnClose.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 6;
            this.btnClose.ShowBase = true;
            this.btnClose.Size = new System.Drawing.Size(47, 45);
            this.btnClose.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnClose.SplitDistance = 0;
            this.btnClose.TabIndex = 27;
            this.btnClose.Title = "";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.tsbtnclose_Click);
            // 
            // buttonEx3
            // 
            this.buttonEx3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEx3.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx3.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx3.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx3.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.buttonEx3.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx3.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx3.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx3.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx3.FadingSpeed = 20;
            this.buttonEx3.FlatAppearance.BorderSize = 0;
            this.buttonEx3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonEx3.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx3.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx3.Image")));
            this.buttonEx3.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx3.ImageOffset = 6;
            this.buttonEx3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonEx3.IsPressed = false;
            this.buttonEx3.KeepPress = false;
            this.buttonEx3.Location = new System.Drawing.Point(213, 0);
            this.buttonEx3.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx3.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx3.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx3.Name = "buttonEx3";
            this.buttonEx3.Radius = 6;
            this.buttonEx3.ShowBase = true;
            this.buttonEx3.Size = new System.Drawing.Size(120, 45);
            this.buttonEx3.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx3.SplitDistance = 0;
            this.buttonEx3.TabIndex = 29;
            this.buttonEx3.Text = "快速出库";
            this.buttonEx3.Title = "";
            this.buttonEx3.UseVisualStyleBackColor = true;
            this.buttonEx3.Visible = false;
            this.buttonEx3.Click += new System.EventHandler(this.buttonEx3_Click);
            // 
            // buttonEx1
            // 
            this.buttonEx1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEx1.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx1.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx1.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx1.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.buttonEx1.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx1.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx1.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx1.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx1.FadingSpeed = 20;
            this.buttonEx1.FlatAppearance.BorderSize = 0;
            this.buttonEx1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonEx1.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx1.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx1.Image")));
            this.buttonEx1.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx1.ImageOffset = 6;
            this.buttonEx1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonEx1.IsPressed = false;
            this.buttonEx1.KeepPress = false;
            this.buttonEx1.Location = new System.Drawing.Point(102, 0);
            this.buttonEx1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx1.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx1.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx1.Name = "buttonEx1";
            this.buttonEx1.Radius = 6;
            this.buttonEx1.ShowBase = true;
            this.buttonEx1.Size = new System.Drawing.Size(111, 45);
            this.buttonEx1.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx1.SplitDistance = 0;
            this.buttonEx1.TabIndex = 28;
            this.buttonEx1.Text = "快速入库";
            this.buttonEx1.Title = "";
            this.buttonEx1.UseVisualStyleBackColor = true;
            this.buttonEx1.Visible = false;
            this.buttonEx1.Click += new System.EventHandler(this.buttonEx1_Click);
            // 
            // buttonEx4
            // 
            this.buttonEx4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEx4.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx4.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx4.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx4.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.buttonEx4.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx4.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx4.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx4.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx4.FadingSpeed = 20;
            this.buttonEx4.FlatAppearance.BorderSize = 0;
            this.buttonEx4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonEx4.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx4.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx4.Image")));
            this.buttonEx4.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx4.ImageOffset = 1;
            this.buttonEx4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonEx4.IsPressed = false;
            this.buttonEx4.KeepPress = false;
            this.buttonEx4.Location = new System.Drawing.Point(12, 0);
            this.buttonEx4.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx4.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx4.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx4.Name = "buttonEx4";
            this.buttonEx4.Radius = 6;
            this.buttonEx4.ShowBase = true;
            this.buttonEx4.Size = new System.Drawing.Size(90, 45);
            this.buttonEx4.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx4.SplitDistance = 0;
            this.buttonEx4.TabIndex = 30;
            this.buttonEx4.Text = "刷新";
            this.buttonEx4.Title = "";
            this.buttonEx4.UseVisualStyleBackColor = true;
            this.buttonEx4.Click += new System.EventHandler(this.buttonEx4_Click);
            // 
            // buttonEx2
            // 
            this.buttonEx2.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx2.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx2.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx2.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.buttonEx2.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx2.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx2.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx2.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx2.Enabled = false;
            this.buttonEx2.FadingSpeed = 20;
            this.buttonEx2.FlatAppearance.BorderSize = 0;
            this.buttonEx2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonEx2.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx2.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx2.Image")));
            this.buttonEx2.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx2.ImageOffset = 3;
            this.buttonEx2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonEx2.IsPressed = false;
            this.buttonEx2.KeepPress = false;
            this.buttonEx2.Location = new System.Drawing.Point(4, 5);
            this.buttonEx2.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx2.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx2.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx2.Name = "buttonEx2";
            this.buttonEx2.Radius = 6;
            this.buttonEx2.ShowBase = false;
            this.buttonEx2.Size = new System.Drawing.Size(172, 43);
            this.buttonEx2.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx2.SplitDistance = 0;
            this.buttonEx2.TabIndex = 23;
            this.buttonEx2.Text = "备件在船情况一览";
            this.buttonEx2.Title = "";
            this.buttonEx2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 55);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(897, 450);
            this.splitContainer1.SplitterDistance = 369;
            this.splitContainer1.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 450);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "备件基本信息";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label18, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.txtRemark, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.label14, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtSpareName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label21, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtSpareEName, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.txtAlertStock, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.label17, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.txtSpareStuff, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.label15, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.txtPicNumber, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.txtPicCode, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtPartNumberHis1, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtPartNumberHis2, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.label16, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtPartNumber, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtUnit, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 11;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(363, 430);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Location = new System.Drawing.Point(3, 260);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(94, 170);
            this.label18.TabIndex = 0;
            this.label18.Text = "备注";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemark
            // 
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.Location = new System.Drawing.Point(103, 263);
            this.txtRemark.MaxLength = 1000;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ReadOnly = true;
            this.txtRemark.Size = new System.Drawing.Size(257, 164);
            this.txtRemark.TabIndex = 41;
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 26);
            this.label14.TabIndex = 0;
            this.label14.Text = "备件名称*";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSpareName
            // 
            this.txtSpareName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSpareName.Location = new System.Drawing.Point(103, 3);
            this.txtSpareName.MaxLength = 50;
            this.txtSpareName.Name = "txtSpareName";
            this.txtSpareName.ReadOnly = true;
            this.txtSpareName.Size = new System.Drawing.Size(257, 21);
            this.txtSpareName.TabIndex = 31;
            // 
            // label21
            // 
            this.label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label21.Location = new System.Drawing.Point(3, 52);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(94, 26);
            this.label21.TabIndex = 0;
            this.label21.Text = "默认计量单位*";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "第二语言名称*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSpareEName
            // 
            this.txtSpareEName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSpareEName.Location = new System.Drawing.Point(103, 29);
            this.txtSpareEName.MaxLength = 50;
            this.txtSpareEName.Name = "txtSpareEName";
            this.txtSpareEName.ReadOnly = true;
            this.txtSpareEName.Size = new System.Drawing.Size(257, 21);
            this.txtSpareEName.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 26);
            this.label1.TabIndex = 45;
            this.label1.Text = "警戒库存";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAlertStock
            // 
            this.txtAlertStock.CausesValidation = false;
            this.txtAlertStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAlertStock.Location = new System.Drawing.Point(103, 211);
            this.txtAlertStock.MaxLength = 50;
            this.txtAlertStock.Name = "txtAlertStock";
            this.txtAlertStock.ReadOnly = true;
            this.txtAlertStock.Size = new System.Drawing.Size(257, 21);
            this.txtAlertStock.TabIndex = 39;
            this.txtAlertStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(3, 234);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 26);
            this.label17.TabIndex = 0;
            this.label17.Text = "构成材料";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSpareStuff
            // 
            this.txtSpareStuff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSpareStuff.Location = new System.Drawing.Point(103, 237);
            this.txtSpareStuff.MaxLength = 200;
            this.txtSpareStuff.Name = "txtSpareStuff";
            this.txtSpareStuff.ReadOnly = true;
            this.txtSpareStuff.Size = new System.Drawing.Size(257, 21);
            this.txtSpareStuff.TabIndex = 40;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(3, 156);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 26);
            this.label15.TabIndex = 0;
            this.label15.Text = "备件图号";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPicNumber
            // 
            this.txtPicNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPicNumber.Location = new System.Drawing.Point(103, 159);
            this.txtPicNumber.MaxLength = 50;
            this.txtPicNumber.Name = "txtPicNumber";
            this.txtPicNumber.ReadOnly = true;
            this.txtPicNumber.Size = new System.Drawing.Size(257, 21);
            this.txtPicNumber.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 26);
            this.label3.TabIndex = 45;
            this.label3.Text = "在图编号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPicCode
            // 
            this.txtPicCode.CausesValidation = false;
            this.txtPicCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPicCode.Location = new System.Drawing.Point(103, 185);
            this.txtPicCode.MaxLength = 40;
            this.txtPicCode.Name = "txtPicCode";
            this.txtPicCode.ReadOnly = true;
            this.txtPicCode.Size = new System.Drawing.Size(257, 21);
            this.txtPicCode.TabIndex = 38;
            this.txtPicCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 26);
            this.label5.TabIndex = 0;
            this.label5.Text = "历史配件号2";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 26);
            this.label4.TabIndex = 0;
            this.label4.Text = "历史配件号1";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPartNumberHis1
            // 
            this.txtPartNumberHis1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPartNumberHis1.Location = new System.Drawing.Point(103, 107);
            this.txtPartNumberHis1.MaxLength = 50;
            this.txtPartNumberHis1.Name = "txtPartNumberHis1";
            this.txtPartNumberHis1.ReadOnly = true;
            this.txtPartNumberHis1.Size = new System.Drawing.Size(257, 21);
            this.txtPartNumberHis1.TabIndex = 35;
            // 
            // txtPartNumberHis2
            // 
            this.txtPartNumberHis2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPartNumberHis2.Location = new System.Drawing.Point(103, 133);
            this.txtPartNumberHis2.MaxLength = 50;
            this.txtPartNumberHis2.Name = "txtPartNumberHis2";
            this.txtPartNumberHis2.ReadOnly = true;
            this.txtPartNumberHis2.Size = new System.Drawing.Size(257, 21);
            this.txtPartNumberHis2.TabIndex = 36;
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(3, 78);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 26);
            this.label16.TabIndex = 0;
            this.label16.Text = "当前配件号";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPartNumber
            // 
            this.txtPartNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPartNumber.Location = new System.Drawing.Point(103, 81);
            this.txtPartNumber.MaxLength = 50;
            this.txtPartNumber.Name = "txtPartNumber";
            this.txtPartNumber.ReadOnly = true;
            this.txtPartNumber.Size = new System.Drawing.Size(257, 21);
            this.txtPartNumber.TabIndex = 34;
            // 
            // txtUnit
            // 
            this.txtUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUnit.Location = new System.Drawing.Point(103, 55);
            this.txtUnit.MaxLength = 50;
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(257, 21);
            this.txtUnit.TabIndex = 32;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(524, 450);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "备件在库信息,如果一条记录都不存在,说明没有库存";
            // 
            // FrmSpareInShipInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 505);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSpareInShipInfo";
            this.Text = "备件在船情况一览";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSpareInShipInfo_FormClosing);
            this.Load += new System.EventHandler(this.FrmSpareInShipInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdsStock)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CommonViewer.UcDataGridView dgv;
        protected System.Windows.Forms.Panel panel1;
        public CommonViewer.ButtonEx buttonEx2;
        private System.Windows.Forms.BindingSource bdsStock;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label18;
        private CommonViewer.TextBoxEx txtRemark;
        private System.Windows.Forms.Label label14;
        private CommonViewer.TextBoxEx txtSpareName;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label2;
        private CommonViewer.TextBoxEx txtSpareEName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private CommonViewer.TextBoxEx txtPicNumber;
        private CommonViewer.TextBoxEx txtPartNumber;
        private System.Windows.Forms.Label label1;
        private CommonViewer.TextBoxEx txtAlertStock;
        private System.Windows.Forms.Label label3;
        private CommonViewer.TextBoxEx txtPicCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private CommonViewer.TextBoxEx txtPartNumberHis1;
        private CommonViewer.TextBoxEx txtPartNumberHis2;
        private System.Windows.Forms.Label label17;
        private CommonViewer.TextBoxEx txtSpareStuff;
        private System.Windows.Forms.GroupBox groupBox2;
        private CommonViewer.TextBoxEx txtUnit;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        protected CommonViewer.ButtonEx btnClose;
        protected CommonViewer.ButtonEx buttonEx3;
        protected CommonViewer.ButtonEx buttonEx1;
        protected CommonViewer.ButtonEx buttonEx4;
    }
}