namespace SynchDll
{
partial class FrmSynchLog
{
/// <summary>
/// Required designer variable.
/// </summary>
private System.ComponentModel.IContainer components = null;

/// <summary>
/// Clean up any resources being used.
/// </summary>
/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
protected override void Dispose(bool disposing)
{
if (disposing && (components != null))
{
components.Dispose();
}
base.Dispose(disposing);
}

#region Windows Form Designer generated code

/// <summary>
/// Required method for Designer support - do not modify
/// the contents of this method with the code editor.
/// </summary>
private void InitializeComponent()
{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSynchLog));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new CommonViewer.ButtonEx();
            this.btnPrint = new CommonViewer.ButtonEx();
            this.btnViewSyncDetail = new CommonViewer.ButtonEx();
            this.buttonEx2 = new CommonViewer.ButtonEx();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSynchDirect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSynchStatus = new System.Windows.Forms.ComboBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvSyncMainData = new CommonViewer.UcDataGridView(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvSyncDetailData = new CommonViewer.UcDataGridView(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvSynchTableData = new CommonViewer.UcDataGridView(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSyncMainData)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSyncDetailData)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSynchTableData)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(968, 506);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.flowLayoutPanel2);
            this.panel4.Controls.Add(this.buttonEx2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(6);
            this.panel4.Size = new System.Drawing.Size(968, 51);
            this.panel4.TabIndex = 11;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.Controls.Add(this.btnPrint);
            this.flowLayoutPanel2.Controls.Add(this.btnViewSyncDetail);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(183, 6);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(779, 39);
            this.flowLayoutPanel2.TabIndex = 42;
            // 
            // btnClose
            // 
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
            this.btnClose.Location = new System.Drawing.Point(737, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnClose.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 6;
            this.btnClose.ShowBase = true;
            this.btnClose.Size = new System.Drawing.Size(42, 39);
            this.btnClose.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnClose.SplitDistance = 0;
            this.btnClose.TabIndex = 1;
            this.btnClose.Title = "";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnPrint.BackColor = System.Drawing.Color.Transparent;
            this.btnPrint.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnPrint.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnPrint.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnPrint.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnPrint.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPrint.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPrint.FadingSpeed = 20;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrint.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnPrint.ImageOffset = 3;
            this.btnPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrint.IsPressed = false;
            this.btnPrint.KeepPress = false;
            this.btnPrint.Location = new System.Drawing.Point(693, 0);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrint.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnPrint.MenuPos = new System.Drawing.Point(0, 0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Radius = 6;
            this.btnPrint.ShowBase = true;
            this.btnPrint.Size = new System.Drawing.Size(44, 39);
            this.btnPrint.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnPrint.SplitDistance = 0;
            this.btnPrint.TabIndex = 28;
            this.btnPrint.Title = "";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Visible = false;
            // 
            // btnViewSyncDetail
            // 
            this.btnViewSyncDetail.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnViewSyncDetail.BackColor = System.Drawing.Color.Transparent;
            this.btnViewSyncDetail.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnViewSyncDetail.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnViewSyncDetail.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnViewSyncDetail.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnViewSyncDetail.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnViewSyncDetail.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnViewSyncDetail.FadingSpeed = 20;
            this.btnViewSyncDetail.FlatAppearance.BorderSize = 0;
            this.btnViewSyncDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewSyncDetail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnViewSyncDetail.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnViewSyncDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnViewSyncDetail.Image")));
            this.btnViewSyncDetail.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnViewSyncDetail.ImageOffset = 3;
            this.btnViewSyncDetail.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnViewSyncDetail.IsPressed = false;
            this.btnViewSyncDetail.KeepPress = false;
            this.btnViewSyncDetail.Location = new System.Drawing.Point(598, 0);
            this.btnViewSyncDetail.Margin = new System.Windows.Forms.Padding(0);
            this.btnViewSyncDetail.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnViewSyncDetail.MenuPos = new System.Drawing.Point(0, 0);
            this.btnViewSyncDetail.Name = "btnViewSyncDetail";
            this.btnViewSyncDetail.Radius = 6;
            this.btnViewSyncDetail.ShowBase = true;
            this.btnViewSyncDetail.Size = new System.Drawing.Size(95, 39);
            this.btnViewSyncDetail.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnViewSyncDetail.SplitDistance = 0;
            this.btnViewSyncDetail.TabIndex = 30;
            this.btnViewSyncDetail.Text = "明细";
            this.btnViewSyncDetail.Title = "查看";
            this.btnViewSyncDetail.UseVisualStyleBackColor = true;
            this.btnViewSyncDetail.Visible = false;
            this.btnViewSyncDetail.Click += new System.EventHandler(this.btnViewSyncDetail_Click);
            // 
            // buttonEx2
            // 
            this.buttonEx2.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx2.AutoSize = true;
            this.buttonEx2.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx2.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx2.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.buttonEx2.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx2.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx2.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx2.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx2.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonEx2.Enabled = false;
            this.buttonEx2.FadingSpeed = 20;
            this.buttonEx2.FlatAppearance.BorderSize = 0;
            this.buttonEx2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx2.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.buttonEx2.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx2.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx2.Image")));
            this.buttonEx2.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx2.ImageOffset = 3;
            this.buttonEx2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonEx2.IsPressed = false;
            this.buttonEx2.KeepPress = false;
            this.buttonEx2.Location = new System.Drawing.Point(6, 6);
            this.buttonEx2.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx2.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx2.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx2.Name = "buttonEx2";
            this.buttonEx2.Radius = 6;
            this.buttonEx2.ShowBase = false;
            this.buttonEx2.Size = new System.Drawing.Size(177, 39);
            this.buttonEx2.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx2.SplitDistance = 0;
            this.buttonEx2.TabIndex = 23;
            this.buttonEx2.Text = "同步日志";
            this.buttonEx2.Title = "";
            this.buttonEx2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(962, 52);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询条件";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.cbSynchDirect);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.cbSynchStatus);
            this.flowLayoutPanel1.Controls.Add(this.dtpStartDate);
            this.flowLayoutPanel1.Controls.Add(this.label4);
            this.flowLayoutPanel1.Controls.Add(this.dtpEndDate);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(956, 32);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(15, 7, 0, 0);
            this.label3.Size = new System.Drawing.Size(68, 19);
            this.label3.TabIndex = 26;
            this.label3.Text = "同步方向";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbSynchDirect
            // 
            this.cbSynchDirect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSynchDirect.FormattingEnabled = true;
            this.cbSynchDirect.Location = new System.Drawing.Point(77, 3);
            this.cbSynchDirect.Name = "cbSynchDirect";
            this.cbSynchDirect.Size = new System.Drawing.Size(121, 20);
            this.cbSynchDirect.TabIndex = 27;
            this.cbSynchDirect.SelectedIndexChanged += new System.EventHandler(this.cbSynchDirect_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(15, 7, 0, 0);
            this.label1.Size = new System.Drawing.Size(68, 19);
            this.label1.TabIndex = 28;
            this.label1.Text = "同步状态";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cbSynchStatus
            // 
            this.cbSynchStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSynchStatus.FormattingEnabled = true;
            this.cbSynchStatus.Location = new System.Drawing.Point(278, 3);
            this.cbSynchStatus.Name = "cbSynchStatus";
            this.cbSynchStatus.Size = new System.Drawing.Size(121, 20);
            this.cbSynchStatus.TabIndex = 29;
            this.cbSynchStatus.SelectedIndexChanged += new System.EventHandler(this.cbSynchStatus_SelectedIndexChanged);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "yyyy-MM-dd";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(405, 3);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(87, 21);
            this.dtpStartDate.TabIndex = 30;
            this.dtpStartDate.CloseUp += new System.EventHandler(this.dtpStartDate_CloseUp);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(498, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 22);
            this.label4.TabIndex = 32;
            this.label4.Text = "~";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy-MM-dd";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(515, 3);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(87, 21);
            this.dtpEndDate.TabIndex = 31;
            this.dtpEndDate.CloseUp += new System.EventHandler(this.dtpEndDate_CloseUp);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 112);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Size = new System.Drawing.Size(962, 391);
            this.splitContainer1.SplitterDistance = 224;
            this.splitContainer1.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvSyncMainData);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.groupBox1.Size = new System.Drawing.Size(224, 391);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "同步文件信息";
            // 
            // dgvSyncMainData
            // 
            this.dgvSyncMainData.AllowUserToAddRows = false;
            this.dgvSyncMainData.AllowUserToDeleteRows = false;
            this.dgvSyncMainData.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.dgvSyncMainData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSyncMainData.AutoFit = true;
            this.dgvSyncMainData.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvSyncMainData.ColumnDeep = 1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSyncMainData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSyncMainData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSyncMainData.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSyncMainData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSyncMainData.EnableHeadersVisualStyles = false;
            this.dgvSyncMainData.ExportColorToExcel = false;
            this.dgvSyncMainData.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSyncMainData.Footer")));
            this.dgvSyncMainData.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvSyncMainData.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSyncMainData.Header")));
            this.dgvSyncMainData.LoadedFinish = false;
            this.dgvSyncMainData.Location = new System.Drawing.Point(8, 17);
            this.dgvSyncMainData.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSyncMainData.MergeColumnNames")));
            this.dgvSyncMainData.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSyncMainData.MergeRowColumn")));
            this.dgvSyncMainData.Name = "dgvSyncMainData";
            this.dgvSyncMainData.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSyncMainData.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSyncMainData.RowHeadersWidth = 4;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(231)))), ((int)(((byte)(162)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSyncMainData.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSyncMainData.RowTemplate.Height = 23;
            this.dgvSyncMainData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSyncMainData.ShowRowNumber = true;
            this.dgvSyncMainData.Size = new System.Drawing.Size(208, 366);
            this.dgvSyncMainData.TabIndex = 12;
            this.dgvSyncMainData.Title = "";
            this.dgvSyncMainData.SelectedChanged += new CommonViewer.UcDataGridView.DeleSelectedChanged(this.dgvSyncMainData_SelectedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvSyncDetailData);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox3.Size = new System.Drawing.Size(734, 196);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "同步内容明细";
            // 
            // dgvSyncDetailData
            // 
            this.dgvSyncDetailData.AllowUserToAddRows = false;
            this.dgvSyncDetailData.AllowUserToDeleteRows = false;
            this.dgvSyncDetailData.AllowUserToOrderColumns = true;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.dgvSyncDetailData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSyncDetailData.AutoFit = true;
            this.dgvSyncDetailData.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvSyncDetailData.ColumnDeep = 1;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSyncDetailData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvSyncDetailData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSyncDetailData.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvSyncDetailData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSyncDetailData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSyncDetailData.EnableHeadersVisualStyles = false;
            this.dgvSyncDetailData.ExportColorToExcel = false;
            this.dgvSyncDetailData.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSyncDetailData.Footer")));
            this.dgvSyncDetailData.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvSyncDetailData.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSyncDetailData.Header")));
            this.dgvSyncDetailData.LoadedFinish = false;
            this.dgvSyncDetailData.Location = new System.Drawing.Point(10, 24);
            this.dgvSyncDetailData.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSyncDetailData.MergeColumnNames")));
            this.dgvSyncDetailData.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSyncDetailData.MergeRowColumn")));
            this.dgvSyncDetailData.Name = "dgvSyncDetailData";
            this.dgvSyncDetailData.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSyncDetailData.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvSyncDetailData.RowHeadersWidth = 30;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(231)))), ((int)(((byte)(162)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSyncDetailData.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSyncDetailData.RowTemplate.Height = 23;
            this.dgvSyncDetailData.ShowRowNumber = true;
            this.dgvSyncDetailData.Size = new System.Drawing.Size(714, 162);
            this.dgvSyncDetailData.TabIndex = 55;
            this.dgvSyncDetailData.Title = "";
            this.dgvSyncDetailData.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSyncDetailData_RowEnter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvSynchTableData);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(0, 196);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox4.Size = new System.Drawing.Size(734, 195);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "同步数据明细";
            // 
            // dgvSynchTableData
            // 
            this.dgvSynchTableData.AllowUserToAddRows = false;
            this.dgvSynchTableData.AllowUserToDeleteRows = false;
            this.dgvSynchTableData.AllowUserToOrderColumns = true;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.dgvSynchTableData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvSynchTableData.AutoFit = true;
            this.dgvSynchTableData.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvSynchTableData.ColumnDeep = 1;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSynchTableData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvSynchTableData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSynchTableData.DefaultCellStyle = dataGridViewCellStyle13;
            this.dgvSynchTableData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSynchTableData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSynchTableData.EnableHeadersVisualStyles = false;
            this.dgvSynchTableData.ExportColorToExcel = false;
            this.dgvSynchTableData.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSynchTableData.Footer")));
            this.dgvSynchTableData.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvSynchTableData.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSynchTableData.Header")));
            this.dgvSynchTableData.LoadedFinish = false;
            this.dgvSynchTableData.Location = new System.Drawing.Point(10, 24);
            this.dgvSynchTableData.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSynchTableData.MergeColumnNames")));
            this.dgvSynchTableData.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvSynchTableData.MergeRowColumn")));
            this.dgvSynchTableData.Name = "dgvSynchTableData";
            this.dgvSynchTableData.ReadOnly = true;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSynchTableData.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgvSynchTableData.RowHeadersWidth = 30;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(231)))), ((int)(((byte)(162)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSynchTableData.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvSynchTableData.RowTemplate.Height = 23;
            this.dgvSynchTableData.ShowRowNumber = true;
            this.dgvSynchTableData.Size = new System.Drawing.Size(714, 161);
            this.dgvSynchTableData.TabIndex = 55;
            this.dgvSynchTableData.Title = "";
            // 
            // FrmSynchLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 506);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmSynchLog";
            this.Text = "同步程序日志";
            this.Activated += new System.EventHandler(this.FrmSynchLog_Activated);
            this.Deactivate += new System.EventHandler(this.FrmSynchLog_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSynchLog_FormClosing);
            this.Load += new System.EventHandler(this.FrmSynchLog_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSyncMainData)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSyncDetailData)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSynchTableData)).EndInit();
            this.ResumeLayout(false);

}

#endregion

private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
protected System.Windows.Forms.Panel panel4;
private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
protected CommonViewer.ButtonEx btnClose;
public CommonViewer.ButtonEx btnPrint;
public CommonViewer.ButtonEx buttonEx2;
private System.Windows.Forms.GroupBox groupBox2;
private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
private System.Windows.Forms.SplitContainer splitContainer1;
private System.Windows.Forms.GroupBox groupBox1;
private CommonViewer.UcDataGridView dgvSyncMainData;
private System.Windows.Forms.GroupBox groupBox4;
private System.Windows.Forms.Label label3;
private CommonViewer.UcDataGridView dgvSynchTableData;
private System.Windows.Forms.ComboBox cbSynchDirect;
public CommonViewer.ButtonEx btnViewSyncDetail;
private System.Windows.Forms.Label label1;
private System.Windows.Forms.ComboBox cbSynchStatus;
public System.Windows.Forms.DateTimePicker dtpStartDate;
public System.Windows.Forms.DateTimePicker dtpEndDate;
private System.Windows.Forms.Label label4;
private System.Windows.Forms.GroupBox groupBox3;
private CommonViewer.UcDataGridView dgvSyncDetailData;
}
}