namespace Maintenance.Viewer
{
    partial class FrmWorkInfoFirstArrange
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWorkInfoFirstArrange));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCircleBackLimit = new CommonViewer.TextBoxEx();
            this.txtCircleFrontLimit = new CommonViewer.TextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCircleLimitUnit = new CommonViewer.TextBoxEx();
            this.txtCircleUnit = new CommonViewer.TextBoxEx();
            this.txtCirclePeriod = new CommonViewer.TextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTimingBackLimit = new CommonViewer.TextBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTimingFrontLimit = new CommonViewer.TextBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTimingPeriod = new CommonViewer.TextBoxEx();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtWorkDescription = new CommonViewer.TextBoxEx();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkIsCheckProject = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkIsRepairProject = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtWorkInfoDetail = new CommonViewer.TextBoxEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpCircleBackLimit = new System.Windows.Forms.DateTimePicker();
            this.dtpCircleFrontLimit = new System.Windows.Forms.DateTimePicker();
            this.dtpPlanExeDate = new System.Windows.Forms.DateTimePicker();
            this.cboConfirmPostGrid = new System.Windows.Forms.ComboBox();
            this.cboPrincipalPostGrid = new System.Windows.Forms.ComboBox();
            this.dgvWorkInfo = new CommonViewer.UcDataGridView(this.components);
            this.bdsFirstArrangeWorkInfo = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSave = new CommonViewer.ButtonEx();
            this.CloseButton = new CommonViewer.ButtonEx();
            this.buttonEx5 = new CommonViewer.ButtonEx();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsFirstArrangeWorkInfo)).BeginInit();
            this.panel3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(992, 404);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "工作信息内容";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox6, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox5, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(986, 384);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(506, 64);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "定期周期及允差";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.txtCircleBackLimit);
            this.panel1.Controls.Add(this.txtCircleFrontLimit);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCircleLimitUnit);
            this.panel1.Controls.Add(this.txtCircleUnit);
            this.panel1.Controls.Add(this.txtCirclePeriod);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 44);
            this.panel1.TabIndex = 0;
            // 
            // txtCircleBackLimit
            // 
            this.txtCircleBackLimit.Location = new System.Drawing.Point(353, 8);
            this.txtCircleBackLimit.Name = "txtCircleBackLimit";
            this.txtCircleBackLimit.ReadOnly = true;
            this.txtCircleBackLimit.Size = new System.Drawing.Size(70, 21);
            this.txtCircleBackLimit.TabIndex = 34;
            this.txtCircleBackLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCircleBackLimit.Visible = false;
            // 
            // txtCircleFrontLimit
            // 
            this.txtCircleFrontLimit.Location = new System.Drawing.Point(229, 8);
            this.txtCircleFrontLimit.Name = "txtCircleFrontLimit";
            this.txtCircleFrontLimit.ReadOnly = true;
            this.txtCircleFrontLimit.Size = new System.Drawing.Size(70, 21);
            this.txtCircleFrontLimit.TabIndex = 33;
            this.txtCircleFrontLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCircleFrontLimit.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(305, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "后允差";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(181, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "前允差";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Visible = false;
            // 
            // txtCircleLimitUnit
            // 
            this.txtCircleLimitUnit.Location = new System.Drawing.Point(429, 8);
            this.txtCircleLimitUnit.Name = "txtCircleLimitUnit";
            this.txtCircleLimitUnit.ReadOnly = true;
            this.txtCircleLimitUnit.Size = new System.Drawing.Size(50, 21);
            this.txtCircleLimitUnit.TabIndex = 35;
            this.txtCircleLimitUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCircleLimitUnit.Visible = false;
            // 
            // txtCircleUnit
            // 
            this.txtCircleUnit.Location = new System.Drawing.Point(124, 8);
            this.txtCircleUnit.Name = "txtCircleUnit";
            this.txtCircleUnit.ReadOnly = true;
            this.txtCircleUnit.Size = new System.Drawing.Size(50, 21);
            this.txtCircleUnit.TabIndex = 32;
            this.txtCircleUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCirclePeriod
            // 
            this.txtCirclePeriod.Location = new System.Drawing.Point(48, 8);
            this.txtCirclePeriod.Name = "txtCirclePeriod";
            this.txtCirclePeriod.ReadOnly = true;
            this.txtCirclePeriod.Size = new System.Drawing.Size(70, 21);
            this.txtCirclePeriod.TabIndex = 31;
            this.txtCirclePeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "周期";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(515, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(468, 64);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "定时周期及允差";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.txtTimingBackLimit);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtTimingFrontLimit);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtTimingPeriod);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 44);
            this.panel2.TabIndex = 2;
            // 
            // txtTimingBackLimit
            // 
            this.txtTimingBackLimit.Location = new System.Drawing.Point(358, 8);
            this.txtTimingBackLimit.Name = "txtTimingBackLimit";
            this.txtTimingBackLimit.ReadOnly = true;
            this.txtTimingBackLimit.Size = new System.Drawing.Size(90, 21);
            this.txtTimingBackLimit.TabIndex = 38;
            this.txtTimingBackLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTimingBackLimit.Visible = false;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(307, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "后允差";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Visible = false;
            // 
            // txtTimingFrontLimit
            // 
            this.txtTimingFrontLimit.Location = new System.Drawing.Point(205, 8);
            this.txtTimingFrontLimit.Name = "txtTimingFrontLimit";
            this.txtTimingFrontLimit.ReadOnly = true;
            this.txtTimingFrontLimit.Size = new System.Drawing.Size(90, 21);
            this.txtTimingFrontLimit.TabIndex = 37;
            this.txtTimingFrontLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTimingFrontLimit.Visible = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(154, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "前允差";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Visible = false;
            // 
            // txtTimingPeriod
            // 
            this.txtTimingPeriod.Location = new System.Drawing.Point(51, 8);
            this.txtTimingPeriod.Name = "txtTimingPeriod";
            this.txtTimingPeriod.ReadOnly = true;
            this.txtTimingPeriod.Size = new System.Drawing.Size(90, 21);
            this.txtTimingPeriod.TabIndex = 36;
            this.txtTimingPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(14, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "周期";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtWorkDescription);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(515, 113);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.groupBox6.Size = new System.Drawing.Size(468, 268);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "补充说明";
            // 
            // txtWorkDescription
            // 
            this.txtWorkDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWorkDescription.Location = new System.Drawing.Point(8, 17);
            this.txtWorkDescription.Multiline = true;
            this.txtWorkDescription.Name = "txtWorkDescription";
            this.txtWorkDescription.Size = new System.Drawing.Size(452, 243);
            this.txtWorkDescription.TabIndex = 52;
            this.txtWorkDescription.TextChanged += new System.EventHandler(this.txtWorkDescription_TextChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.chkIsCheckProject);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.chkIsRepairProject);
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 73);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(506, 34);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // chkIsCheckProject
            // 
            this.chkIsCheckProject.Enabled = false;
            this.chkIsCheckProject.Location = new System.Drawing.Point(3, 3);
            this.chkIsCheckProject.Name = "chkIsCheckProject";
            this.chkIsCheckProject.Size = new System.Drawing.Size(14, 37);
            this.chkIsCheckProject.TabIndex = 39;
            this.chkIsCheckProject.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(23, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 40);
            this.label7.TabIndex = 1;
            this.label7.Text = "检验项目";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkIsRepairProject
            // 
            this.chkIsRepairProject.Enabled = false;
            this.chkIsRepairProject.Location = new System.Drawing.Point(89, 3);
            this.chkIsRepairProject.Name = "chkIsRepairProject";
            this.chkIsRepairProject.Size = new System.Drawing.Size(14, 37);
            this.chkIsRepairProject.TabIndex = 40;
            this.chkIsRepairProject.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(109, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 40);
            this.label9.TabIndex = 1;
            this.label9.Text = "修理项目";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtWorkInfoDetail);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 113);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.groupBox5.Size = new System.Drawing.Size(506, 268);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "工作信息描述";
            // 
            // txtWorkInfoDetail
            // 
            this.txtWorkInfoDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtWorkInfoDetail.Location = new System.Drawing.Point(8, 17);
            this.txtWorkInfoDetail.Multiline = true;
            this.txtWorkInfoDetail.Name = "txtWorkInfoDetail";
            this.txtWorkInfoDetail.ReadOnly = true;
            this.txtWorkInfoDetail.Size = new System.Drawing.Size(490, 243);
            this.txtWorkInfoDetail.TabIndex = 51;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpCircleBackLimit);
            this.groupBox1.Controls.Add(this.dtpCircleFrontLimit);
            this.groupBox1.Controls.Add(this.dtpPlanExeDate);
            this.groupBox1.Controls.Add(this.cboConfirmPostGrid);
            this.groupBox1.Controls.Add(this.cboPrincipalPostGrid);
            this.groupBox1.Controls.Add(this.dgvWorkInfo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.groupBox1.Size = new System.Drawing.Size(992, 143);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工作信息列表";
            // 
            // dtpCircleBackLimit
            // 
            this.dtpCircleBackLimit.CustomFormat = "yyyy-MM-dd";
            this.dtpCircleBackLimit.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCircleBackLimit.Location = new System.Drawing.Point(14, 126);
            this.dtpCircleBackLimit.Name = "dtpCircleBackLimit";
            this.dtpCircleBackLimit.Size = new System.Drawing.Size(121, 21);
            this.dtpCircleBackLimit.TabIndex = 11;
            this.dtpCircleBackLimit.Visible = false;
            // 
            // dtpCircleFrontLimit
            // 
            this.dtpCircleFrontLimit.CustomFormat = "yyyy-MM-dd";
            this.dtpCircleFrontLimit.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCircleFrontLimit.Location = new System.Drawing.Point(14, 99);
            this.dtpCircleFrontLimit.Name = "dtpCircleFrontLimit";
            this.dtpCircleFrontLimit.Size = new System.Drawing.Size(121, 21);
            this.dtpCircleFrontLimit.TabIndex = 11;
            this.dtpCircleFrontLimit.Visible = false;
            // 
            // dtpPlanExeDate
            // 
            this.dtpPlanExeDate.CustomFormat = "yyyy-MM-dd";
            this.dtpPlanExeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPlanExeDate.Location = new System.Drawing.Point(14, 72);
            this.dtpPlanExeDate.Name = "dtpPlanExeDate";
            this.dtpPlanExeDate.Size = new System.Drawing.Size(121, 21);
            this.dtpPlanExeDate.TabIndex = 11;
            this.dtpPlanExeDate.Visible = false;
            // 
            // cboConfirmPostGrid
            // 
            this.cboConfirmPostGrid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConfirmPostGrid.FormattingEnabled = true;
            this.cboConfirmPostGrid.Location = new System.Drawing.Point(14, 46);
            this.cboConfirmPostGrid.Name = "cboConfirmPostGrid";
            this.cboConfirmPostGrid.Size = new System.Drawing.Size(121, 20);
            this.cboConfirmPostGrid.TabIndex = 44;
            this.cboConfirmPostGrid.Visible = false;
            // 
            // cboPrincipalPostGrid
            // 
            this.cboPrincipalPostGrid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrincipalPostGrid.FormattingEnabled = true;
            this.cboPrincipalPostGrid.Location = new System.Drawing.Point(14, 20);
            this.cboPrincipalPostGrid.Name = "cboPrincipalPostGrid";
            this.cboPrincipalPostGrid.Size = new System.Drawing.Size(121, 20);
            this.cboPrincipalPostGrid.TabIndex = 43;
            this.cboPrincipalPostGrid.Visible = false;
            // 
            // dgvWorkInfo
            // 
            this.dgvWorkInfo.AllowUserToAddRows = false;
            this.dgvWorkInfo.AllowUserToDeleteRows = false;
            this.dgvWorkInfo.AllowUserToOrderColumns = true;
            this.dgvWorkInfo.AutoFit = true;
            this.dgvWorkInfo.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvWorkInfo.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWorkInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWorkInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWorkInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorkInfo.EnableHeadersVisualStyles = false;
            this.dgvWorkInfo.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkInfo.Footer")));
            this.dgvWorkInfo.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvWorkInfo.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkInfo.Header")));
            this.dgvWorkInfo.LoadedFinish = false;
            this.dgvWorkInfo.Location = new System.Drawing.Point(8, 17);
            this.dgvWorkInfo.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkInfo.MergeColumnNames")));
            this.dgvWorkInfo.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkInfo.MergeRowColumn")));
            this.dgvWorkInfo.Name = "dgvWorkInfo";
            this.dgvWorkInfo.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvWorkInfo.RowHeadersWidth = 25;
            this.dgvWorkInfo.RowTemplate.Height = 23;
            this.dgvWorkInfo.ShowRowNumber = false;
            this.dgvWorkInfo.Size = new System.Drawing.Size(976, 118);
            this.dgvWorkInfo.TabIndex = 21;
            this.dgvWorkInfo.Title = null;
            this.dgvWorkInfo.Sorted += new System.EventHandler(this.dgvWorkInfo_Sorted);
            this.dgvWorkInfo.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWorkInfo_RowEnter);
            this.dgvWorkInfo.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvWorkInfo_CellValidating);
            this.dgvWorkInfo.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvWorkInfo_CellMouseDoubleClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.CloseButton);
            this.panel3.Controls.Add(this.buttonEx5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(992, 65);
            this.panel3.TabIndex = 54;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnSave.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnSave.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnSave.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnSave.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSave.FadingSpeed = 20;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSave.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnSave.ImageOffset = 2;
            this.btnSave.IsPressed = false;
            this.btnSave.KeepPress = false;
            this.btnSave.Location = new System.Drawing.Point(778, 12);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSave.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Radius = 6;
            this.btnSave.ShowBase = true;
            this.btnSave.Size = new System.Drawing.Size(111, 44);
            this.btnSave.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnSave.SplitDistance = 0;
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "确认操作";
            this.btnSave.Title = "";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.bdNgSaveItem_Click);
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
            this.CloseButton.Location = new System.Drawing.Point(889, 12);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.CloseButton.MenuPos = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Radius = 6;
            this.CloseButton.ShowBase = true;
            this.CloseButton.Size = new System.Drawing.Size(100, 44);
            this.CloseButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.CloseButton.SplitDistance = 0;
            this.CloseButton.TabIndex = 26;
            this.CloseButton.Text = "取消操作";
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
            this.buttonEx5.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx5.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx5.Image")));
            this.buttonEx5.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx5.ImageOffset = 3;
            this.buttonEx5.IsPressed = false;
            this.buttonEx5.KeepPress = false;
            this.buttonEx5.Location = new System.Drawing.Point(9, 8);
            this.buttonEx5.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx5.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx5.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx5.Name = "buttonEx5";
            this.buttonEx5.Radius = 6;
            this.buttonEx5.ShowBase = false;
            this.buttonEx5.Size = new System.Drawing.Size(121, 53);
            this.buttonEx5.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx5.SplitDistance = 0;
            this.buttonEx5.TabIndex = 27;
            this.buttonEx5.Text = "工单首排";
            this.buttonEx5.Title = "";
            this.buttonEx5.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 65);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(992, 551);
            this.splitContainer1.SplitterDistance = 143;
            this.splitContainer1.TabIndex = 55;
            // 
            // FrmWorkInfoFirstArrange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 616);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel3);
            this.Name = "FrmWorkInfoFirstArrange";
            this.Text = "工单的首排";
            this.Load += new System.EventHandler(this.FrmWorkInfoFirstArrange_Load);
            this.Shown += new System.EventHandler(this.FrmWorkInfoFirstArrange_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWorkInfoFirstArrange_FormClosing);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsFirstArrangeWorkInfo)).EndInit();
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private CommonViewer.UcDataGridView dgvWorkInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel1;
        private CommonViewer.TextBoxEx txtCirclePeriod;
        private System.Windows.Forms.Label label1;
        private CommonViewer.TextBoxEx txtCircleBackLimit;
        private CommonViewer.TextBoxEx txtCircleFrontLimit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private CommonViewer.TextBoxEx txtTimingPeriod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private CommonViewer.TextBoxEx txtTimingBackLimit;
        private System.Windows.Forms.Label label6;
        private CommonViewer.TextBoxEx txtTimingFrontLimit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox chkIsCheckProject;
        private System.Windows.Forms.CheckBox chkIsRepairProject;
        private CommonViewer.TextBoxEx txtWorkInfoDetail;
        private CommonViewer.TextBoxEx txtWorkDescription;
        private System.Windows.Forms.BindingSource bdsFirstArrangeWorkInfo;
        private System.Windows.Forms.ComboBox cboConfirmPostGrid;
        private System.Windows.Forms.ComboBox cboPrincipalPostGrid;
        private CommonViewer.TextBoxEx txtCircleLimitUnit;
        private CommonViewer.TextBoxEx txtCircleUnit;
        private System.Windows.Forms.DateTimePicker dtpPlanExeDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpCircleFrontLimit;
        private System.Windows.Forms.DateTimePicker dtpCircleBackLimit;
        private System.Windows.Forms.Panel panel3;
        private CommonViewer.ButtonEx btnSave;
        private CommonViewer.ButtonEx CloseButton;
        private CommonViewer.ButtonEx buttonEx5;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}