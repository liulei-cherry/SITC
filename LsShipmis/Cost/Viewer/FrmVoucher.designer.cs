namespace Cost.Viewer
{
    partial class FrmVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVoucher));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMain = new CommonViewer.UcDataGridView(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnNullify = new CommonViewer.ButtonEx();
            this.btnCheckRecode = new CommonViewer.ButtonEx();
            this.btnCommit = new CommonViewer.ButtonEx();
            this.btnBdFiles = new CommonViewer.ButtonEx();
            this.btnDelete = new CommonViewer.ButtonEx();
            this.btnReturn = new CommonViewer.ButtonEx();
            this.btnAdd = new CommonViewer.ButtonEx();
            this.btnManage = new CommonViewer.ButtonEx();
            this.btnExportReport = new CommonViewer.ButtonEx();
            this.buttonEx5 = new CommonViewer.ButtonEx();
            this.CloseButton = new CommonViewer.ButtonEx();
            this.cboDay = new System.Windows.Forms.ComboBox();
            this.cbxState = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateYear = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.labyear = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkClear = new System.Windows.Forms.LinkLabel();
            this.ckbSelectAll = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new CommonViewer.UcDataGridView(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxState2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.dateYear2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToOrderColumns = true;
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.AutoFit = true;
            this.dgvMain.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvMain.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.ExportColorToExcel = false;
            this.dgvMain.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvMain.Footer")));
            this.dgvMain.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvMain.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvMain.Header")));
            this.dgvMain.LoadedFinish = false;
            this.dgvMain.Location = new System.Drawing.Point(1, 41);
            this.dgvMain.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvMain.MergeColumnNames")));
            this.dgvMain.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvMain.MergeRowColumn")));
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMain.RowHeadersWidth = 30;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.ShowRowNumber = true;
            this.dgvMain.Size = new System.Drawing.Size(964, 346);
            this.dgvMain.TabIndex = 53;
            this.dgvMain.Title = "";
            this.dgvMain.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMain_CellMouseClick);
            this.dgvMain.CurrentCellChanged += new System.EventHandler(this.dgvMain_CurrentCellChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.btnNullify);
            this.panel3.Controls.Add(this.btnCheckRecode);
            this.panel3.Controls.Add(this.btnCommit);
            this.panel3.Controls.Add(this.btnBdFiles);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnReturn);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.btnManage);
            this.panel3.Controls.Add(this.btnExportReport);
            this.panel3.Controls.Add(this.buttonEx5);
            this.panel3.Controls.Add(this.CloseButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(972, 50);
            this.panel3.TabIndex = 50;
            // 
            // btnNullify
            // 
            this.btnNullify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNullify.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnNullify.BackColor = System.Drawing.Color.Transparent;
            this.btnNullify.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnNullify.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnNullify.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnNullify.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnNullify.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnNullify.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnNullify.FadingSpeed = 20;
            this.btnNullify.FlatAppearance.BorderSize = 0;
            this.btnNullify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNullify.Font = new System.Drawing.Font("宋体", 9F);
            this.btnNullify.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnNullify.Image = ((System.Drawing.Image)(resources.GetObject("btnNullify.Image")));
            this.btnNullify.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnNullify.ImageOffset = 5;
            this.btnNullify.IsPressed = false;
            this.btnNullify.KeepPress = false;
            this.btnNullify.Location = new System.Drawing.Point(721, 6);
            this.btnNullify.Margin = new System.Windows.Forms.Padding(0);
            this.btnNullify.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnNullify.MenuPos = new System.Drawing.Point(0, 0);
            this.btnNullify.Name = "btnNullify";
            this.btnNullify.Radius = 6;
            this.btnNullify.ShowBase = true;
            this.btnNullify.Size = new System.Drawing.Size(75, 40);
            this.btnNullify.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnNullify.SplitDistance = 0;
            this.btnNullify.TabIndex = 49;
            this.btnNullify.Text = "作废";
            this.btnNullify.Title = "";
            this.btnNullify.UseVisualStyleBackColor = true;
            this.btnNullify.Click += new System.EventHandler(this.btnNullify_Click);
            // 
            // btnCheckRecode
            // 
            this.btnCheckRecode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckRecode.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnCheckRecode.BackColor = System.Drawing.Color.Transparent;
            this.btnCheckRecode.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnCheckRecode.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnCheckRecode.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnCheckRecode.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnCheckRecode.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCheckRecode.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCheckRecode.FadingSpeed = 20;
            this.btnCheckRecode.FlatAppearance.BorderSize = 0;
            this.btnCheckRecode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckRecode.Font = new System.Drawing.Font("宋体", 9F);
            this.btnCheckRecode.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnCheckRecode.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckRecode.Image")));
            this.btnCheckRecode.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnCheckRecode.ImageOffset = 5;
            this.btnCheckRecode.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCheckRecode.IsPressed = false;
            this.btnCheckRecode.KeepPress = false;
            this.btnCheckRecode.Location = new System.Drawing.Point(421, 6);
            this.btnCheckRecode.Margin = new System.Windows.Forms.Padding(0);
            this.btnCheckRecode.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnCheckRecode.MenuPos = new System.Drawing.Point(0, 0);
            this.btnCheckRecode.Name = "btnCheckRecode";
            this.btnCheckRecode.Radius = 6;
            this.btnCheckRecode.ShowBase = true;
            this.btnCheckRecode.Size = new System.Drawing.Size(100, 40);
            this.btnCheckRecode.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnCheckRecode.SplitDistance = 0;
            this.btnCheckRecode.TabIndex = 48;
            this.btnCheckRecode.Text = "审批记录";
            this.btnCheckRecode.Title = "";
            this.btnCheckRecode.UseVisualStyleBackColor = true;
            this.btnCheckRecode.Click += new System.EventHandler(this.btnCheckRecode_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCommit.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnCommit.BackColor = System.Drawing.Color.Transparent;
            this.btnCommit.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnCommit.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnCommit.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnCommit.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnCommit.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCommit.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCommit.FadingSpeed = 20;
            this.btnCommit.FlatAppearance.BorderSize = 0;
            this.btnCommit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCommit.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnCommit.Image = ((System.Drawing.Image)(resources.GetObject("btnCommit.Image")));
            this.btnCommit.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnCommit.ImageOffset = 5;
            this.btnCommit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCommit.IsPressed = false;
            this.btnCommit.KeepPress = false;
            this.btnCommit.Location = new System.Drawing.Point(337, 6);
            this.btnCommit.Margin = new System.Windows.Forms.Padding(0);
            this.btnCommit.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnCommit.MenuPos = new System.Drawing.Point(0, 0);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Radius = 6;
            this.btnCommit.ShowBase = true;
            this.btnCommit.Size = new System.Drawing.Size(84, 40);
            this.btnCommit.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnCommit.SplitDistance = 0;
            this.btnCommit.TabIndex = 47;
            this.btnCommit.Text = "提交";
            this.btnCommit.Title = "";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnBdFiles
            // 
            this.btnBdFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBdFiles.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnBdFiles.BackColor = System.Drawing.Color.Transparent;
            this.btnBdFiles.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnBdFiles.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnBdFiles.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnBdFiles.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnBdFiles.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnBdFiles.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnBdFiles.FadingSpeed = 20;
            this.btnBdFiles.FlatAppearance.BorderSize = 0;
            this.btnBdFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBdFiles.Font = new System.Drawing.Font("宋体", 9F);
            this.btnBdFiles.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnBdFiles.Image = ((System.Drawing.Image)(resources.GetObject("btnBdFiles.Image")));
            this.btnBdFiles.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnBdFiles.ImageOffset = 7;
            this.btnBdFiles.IsPressed = false;
            this.btnBdFiles.KeepPress = false;
            this.btnBdFiles.Location = new System.Drawing.Point(521, 6);
            this.btnBdFiles.Margin = new System.Windows.Forms.Padding(0);
            this.btnBdFiles.MaxImageSize = new System.Drawing.Point(40, 40);
            this.btnBdFiles.MenuPos = new System.Drawing.Point(0, 0);
            this.btnBdFiles.Name = "btnBdFiles";
            this.btnBdFiles.Radius = 6;
            this.btnBdFiles.ShowBase = true;
            this.btnBdFiles.Size = new System.Drawing.Size(102, 40);
            this.btnBdFiles.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnBdFiles.SplitDistance = 0;
            this.btnBdFiles.TabIndex = 44;
            this.btnBdFiles.Text = "  附件";
            this.btnBdFiles.Title = "";
            this.btnBdFiles.UseVisualStyleBackColor = true;
            this.btnBdFiles.Click += new System.EventHandler(this.btnBdFiles_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnDelete.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnDelete.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnDelete.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnDelete.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDelete.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDelete.Enabled = false;
            this.btnDelete.FadingSpeed = 20;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("宋体", 9F);
            this.btnDelete.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnDelete.ImageOffset = 3;
            this.btnDelete.IsPressed = false;
            this.btnDelete.KeepPress = false;
            this.btnDelete.Location = new System.Drawing.Point(297, 6);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnDelete.MenuPos = new System.Drawing.Point(0, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Radius = 6;
            this.btnDelete.ShowBase = true;
            this.btnDelete.Size = new System.Drawing.Size(40, 40);
            this.btnDelete.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnDelete.SplitDistance = 0;
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "删除";
            this.btnDelete.Title = "";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturn.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnReturn.BackColor = System.Drawing.Color.Transparent;
            this.btnReturn.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnReturn.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnReturn.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnReturn.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnReturn.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnReturn.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnReturn.FadingSpeed = 20;
            this.btnReturn.FlatAppearance.BorderSize = 0;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("宋体", 9F);
            this.btnReturn.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnReturn.Image = ((System.Drawing.Image)(resources.GetObject("btnReturn.Image")));
            this.btnReturn.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnReturn.ImageOffset = 5;
            this.btnReturn.IsPressed = false;
            this.btnReturn.KeepPress = false;
            this.btnReturn.Location = new System.Drawing.Point(623, 6);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(0);
            this.btnReturn.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnReturn.MenuPos = new System.Drawing.Point(0, 0);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Radius = 6;
            this.btnReturn.ShowBase = true;
            this.btnReturn.Size = new System.Drawing.Size(98, 40);
            this.btnReturn.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnReturn.SplitDistance = 0;
            this.btnReturn.TabIndex = 29;
            this.btnReturn.Text = "打回机务";
            this.btnReturn.Title = "";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnAdd.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnAdd.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAdd.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAdd.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAdd.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAdd.FadingSpeed = 20;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("宋体", 9F);
            this.btnAdd.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnAdd.ImageOffset = 3;
            this.btnAdd.IsPressed = false;
            this.btnAdd.KeepPress = false;
            this.btnAdd.Location = new System.Drawing.Point(217, 6);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnAdd.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAdd.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Radius = 6;
            this.btnAdd.ShowBase = true;
            this.btnAdd.Size = new System.Drawing.Size(40, 40);
            this.btnAdd.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnAdd.SplitDistance = 0;
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "添加";
            this.btnAdd.Title = "";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnManage
            // 
            this.btnManage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManage.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnManage.BackColor = System.Drawing.Color.Transparent;
            this.btnManage.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnManage.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnManage.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnManage.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnManage.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnManage.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnManage.FadingSpeed = 20;
            this.btnManage.FlatAppearance.BorderSize = 0;
            this.btnManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManage.Font = new System.Drawing.Font("宋体", 9F);
            this.btnManage.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnManage.Image = ((System.Drawing.Image)(resources.GetObject("btnManage.Image")));
            this.btnManage.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnManage.ImageOffset = 7;
            this.btnManage.IsPressed = false;
            this.btnManage.KeepPress = false;
            this.btnManage.Location = new System.Drawing.Point(257, 6);
            this.btnManage.Margin = new System.Windows.Forms.Padding(0);
            this.btnManage.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnManage.MenuPos = new System.Drawing.Point(0, 0);
            this.btnManage.Name = "btnManage";
            this.btnManage.Radius = 6;
            this.btnManage.ShowBase = true;
            this.btnManage.Size = new System.Drawing.Size(40, 40);
            this.btnManage.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnManage.SplitDistance = 0;
            this.btnManage.TabIndex = 27;
            this.btnManage.Text = "修改";
            this.btnManage.Title = "";
            this.btnManage.UseVisualStyleBackColor = true;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // btnExportReport
            // 
            this.btnExportReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportReport.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnExportReport.BackColor = System.Drawing.Color.Transparent;
            this.btnExportReport.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnExportReport.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnExportReport.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnExportReport.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnExportReport.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnExportReport.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExportReport.FadingSpeed = 20;
            this.btnExportReport.FlatAppearance.BorderSize = 0;
            this.btnExportReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportReport.Font = new System.Drawing.Font("宋体", 9F);
            this.btnExportReport.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnExportReport.Image = ((System.Drawing.Image)(resources.GetObject("btnExportReport.Image")));
            this.btnExportReport.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnExportReport.ImageOffset = 8;
            this.btnExportReport.IsPressed = false;
            this.btnExportReport.KeepPress = false;
            this.btnExportReport.Location = new System.Drawing.Point(796, 6);
            this.btnExportReport.Margin = new System.Windows.Forms.Padding(0);
            this.btnExportReport.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnExportReport.MenuPos = new System.Drawing.Point(0, 0);
            this.btnExportReport.Name = "btnExportReport";
            this.btnExportReport.Radius = 6;
            this.btnExportReport.ShowBase = true;
            this.btnExportReport.Size = new System.Drawing.Size(97, 40);
            this.btnExportReport.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnExportReport.SplitDistance = 0;
            this.btnExportReport.TabIndex = 26;
            this.btnExportReport.Text = "导出报表";
            this.btnExportReport.Title = "";
            this.btnExportReport.UseVisualStyleBackColor = true;
            this.btnExportReport.Click += new System.EventHandler(this.btnExportReport_Click);
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
            this.buttonEx5.Location = new System.Drawing.Point(5, 6);
            this.buttonEx5.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx5.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx5.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx5.Name = "buttonEx5";
            this.buttonEx5.Radius = 6;
            this.buttonEx5.ShowBase = false;
            this.buttonEx5.Size = new System.Drawing.Size(168, 41);
            this.buttonEx5.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx5.SplitDistance = 0;
            this.buttonEx5.TabIndex = 25;
            this.buttonEx5.Text = "单日凭证管理";
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
            this.CloseButton.Location = new System.Drawing.Point(893, 6);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.CloseButton.MenuPos = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Radius = 6;
            this.CloseButton.ShowBase = true;
            this.CloseButton.Size = new System.Drawing.Size(75, 40);
            this.CloseButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.CloseButton.SplitDistance = 0;
            this.CloseButton.TabIndex = 21;
            this.CloseButton.Text = "关闭";
            this.CloseButton.Title = "";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.bdNgClose_Click);
            // 
            // cboDay
            // 
            this.cboDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDay.FormattingEnabled = true;
            this.cboDay.Location = new System.Drawing.Point(137, 6);
            this.cboDay.Name = "cboDay";
            this.cboDay.Size = new System.Drawing.Size(104, 20);
            this.cboDay.TabIndex = 42;
            this.cboDay.SelectedIndexChanged += new System.EventHandler(this.cboDay_SelectedIndexChanged);
            // 
            // cbxState
            // 
            this.cbxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxState.FormattingEnabled = true;
            this.cbxState.Location = new System.Drawing.Point(301, 6);
            this.cbxState.Name = "cbxState";
            this.cbxState.Size = new System.Drawing.Size(100, 20);
            this.cbxState.TabIndex = 41;
            this.cbxState.SelectedIndexChanged += new System.EventHandler(this.cbxState_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(264, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 18);
            this.label1.TabIndex = 40;
            this.label1.Text = "状态";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateYear
            // 
            this.dateYear.CustomFormat = "yyyy";
            this.dateYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateYear.Location = new System.Drawing.Point(28, 6);
            this.dateYear.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateYear.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateYear.Name = "dateYear";
            this.dateYear.ShowUpDown = true;
            this.dateYear.Size = new System.Drawing.Size(60, 21);
            this.dateYear.TabIndex = 35;
            this.dateYear.ValueChanged += new System.EventHandler(this.dateYear_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 34;
            this.label2.Text = "月日";
            // 
            // labyear
            // 
            this.labyear.AutoSize = true;
            this.labyear.Location = new System.Drawing.Point(6, 10);
            this.labyear.Name = "labyear";
            this.labyear.Size = new System.Drawing.Size(17, 12);
            this.labyear.TabIndex = 34;
            this.labyear.Text = "年";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tabControl1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.splitContainer1, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(972, 612);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lnkClear);
            this.groupBox1.Controls.Add(this.ckbSelectAll);
            this.groupBox1.Controls.Add(this.dgvMain);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(966, 392);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "凭证列表";
            // 
            // lnkClear
            // 
            this.lnkClear.AutoSize = true;
            this.lnkClear.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnkClear.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkClear.Location = new System.Drawing.Point(65, 20);
            this.lnkClear.Name = "lnkClear";
            this.lnkClear.Size = new System.Drawing.Size(29, 12);
            this.lnkClear.TabIndex = 57;
            this.lnkClear.TabStop = true;
            this.lnkClear.Text = "全清";
            this.lnkClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkClear_LinkClicked);
            // 
            // ckbSelectAll
            // 
            this.ckbSelectAll.AutoSize = true;
            this.ckbSelectAll.ForeColor = System.Drawing.Color.Blue;
            this.ckbSelectAll.Location = new System.Drawing.Point(12, 19);
            this.ckbSelectAll.Name = "ckbSelectAll";
            this.ckbSelectAll.Size = new System.Drawing.Size(48, 16);
            this.ckbSelectAll.TabIndex = 56;
            this.ckbSelectAll.Text = "全选";
            this.ckbSelectAll.UseVisualStyleBackColor = true;
            this.ckbSelectAll.CheckedChanged += new System.EventHandler(this.ckbSelectAll_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDetail);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(966, 90);
            this.groupBox2.TabIndex = 55;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "对应业务数据列表";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.AllowUserToOrderColumns = true;
            this.dgvDetail.AutoFit = true;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvDetail.ColumnDeep = 1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetail.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.EnableHeadersVisualStyles = false;
            this.dgvDetail.ExportColorToExcel = false;
            this.dgvDetail.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvDetail.Footer")));
            this.dgvDetail.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvDetail.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvDetail.Header")));
            this.dgvDetail.LoadedFinish = false;
            this.dgvDetail.Location = new System.Drawing.Point(3, 17);
            this.dgvDetail.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvDetail.MergeColumnNames")));
            this.dgvDetail.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvDetail.MergeRowColumn")));
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetail.RowHeadersWidth = 30;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.ShowRowNumber = true;
            this.dgvDetail.Size = new System.Drawing.Size(960, 70);
            this.dgvDetail.TabIndex = 54;
            this.dgvDetail.Title = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 53);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(966, 64);
            this.tabControl1.TabIndex = 56;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Transparent;
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(958, 38);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "单日查询";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.cbxState);
            this.panel2.Controls.Add(this.cboDay);
            this.panel2.Controls.Add(this.dateYear);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.labyear);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(958, 38);
            this.panel2.TabIndex = 43;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(958, 38);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "年月查询";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.cbxState2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cboMonth);
            this.panel1.Controls.Add(this.dateYear2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 38);
            this.panel1.TabIndex = 54;
            // 
            // cbxState2
            // 
            this.cbxState2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxState2.FormattingEnabled = true;
            this.cbxState2.Location = new System.Drawing.Point(301, 6);
            this.cbxState2.Name = "cbxState2";
            this.cbxState2.Size = new System.Drawing.Size(151, 20);
            this.cbxState2.TabIndex = 48;
            this.cbxState2.SelectedIndexChanged += new System.EventHandler(this.cbxState2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(264, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 18);
            this.label5.TabIndex = 47;
            this.label5.Text = "状态";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboMonth
            // 
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Location = new System.Drawing.Point(137, 6);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(104, 20);
            this.cboMonth.TabIndex = 46;
            this.cboMonth.SelectedIndexChanged += new System.EventHandler(this.cboMonth_SelectedIndexChanged);
            // 
            // dateYear2
            // 
            this.dateYear2.CustomFormat = "yyyy";
            this.dateYear2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateYear2.Location = new System.Drawing.Point(28, 6);
            this.dateYear2.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateYear2.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateYear2.Name = "dateYear2";
            this.dateYear2.ShowUpDown = true;
            this.dateYear2.Size = new System.Drawing.Size(60, 21);
            this.dateYear2.TabIndex = 45;
            this.dateYear2.ValueChanged += new System.EventHandler(this.dateYear2_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 44;
            this.label3.Text = "年";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 43;
            this.label4.Text = "月";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 123);
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
            this.splitContainer1.Size = new System.Drawing.Size(966, 486);
            this.splitContainer1.SplitterDistance = 392;
            this.splitContainer1.TabIndex = 57;
            // 
            // FrmVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 612);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "FrmVoucher";
            this.Text = "单日凭证管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmVoucher_FormClosed);
            this.Load += new System.EventHandler(this.FrmVoucher_Load);
            this.Shown += new System.EventHandler(this.FrmVoucher_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private CommonViewer.ButtonEx buttonEx5;
        private CommonViewer.ButtonEx CloseButton;
        private CommonViewer.ButtonEx btnExportReport;
        private System.Windows.Forms.DateTimePicker dateYear;
        private System.Windows.Forms.Label labyear;
        private CommonViewer.UcDataGridView dgvMain;
        private CommonViewer.ButtonEx btnManage;
        private CommonViewer.ButtonEx btnAdd;
        private CommonViewer.ButtonEx btnReturn;
        private CommonViewer.ButtonEx btnBdFiles;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private CommonViewer.UcDataGridView dgvDetail;
        private System.Windows.Forms.ComboBox cbxState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDay;
        private System.Windows.Forms.Label label2;
        private CommonViewer.ButtonEx btnCommit;
        private CommonViewer.ButtonEx btnCheckRecode;
        private CommonViewer.ButtonEx btnDelete;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateYear2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbxState2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lnkClear;
        private System.Windows.Forms.CheckBox ckbSelectAll;
        private CommonViewer.ButtonEx btnNullify;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}