namespace CMSManage.Viewer
{
    partial class FrmCMSDateSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCMSDateSetting));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonEx1 = new CommonViewer.ButtonEx();
            this.btnGunter = new CommonViewer.ButtonEx();
            this.btn_BandingWorkinfo = new CommonViewer.ButtonEx();
            this.btnClose = new CommonViewer.ButtonEx();
            this.btnCreate = new CommonViewer.ButtonEx();
            this.btnSave = new CommonViewer.ButtonEx();
            this.grpWorkOrderList = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtDetail = new CommonViewer.TextBoxEx();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCheckPlace = new CommonViewer.TextBoxEx();
            this.dtCheckDate = new CommonViewer.DateTimePickerEx();
            this.dtBegin = new CommonViewer.DateTimePickerEx();
            this.dtEnd = new CommonViewer.DateTimePickerEx();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCheckName = new CommonViewer.TextBoxEx();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dgvCMSWorkOrder = new CommonViewer.UcDataGridView(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.dt_other = new System.Windows.Forms.DateTimePicker();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btn_sel_null = new System.Windows.Forms.Button();
            this.btn_selAll = new System.Windows.Forms.Button();
            this.toolTipBtnSelComp = new System.Windows.Forms.ToolTip(this.components);
            this.bdsCMSCheck = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grpWorkOrderList.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCMSWorkOrder)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCMSCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grpWorkOrderList, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 571);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.buttonEx1);
            this.panel3.Controls.Add(this.btnGunter);
            this.panel3.Controls.Add(this.btn_BandingWorkinfo);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.btnCreate);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(978, 50);
            this.panel3.TabIndex = 55;
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
            this.buttonEx1.Enabled = false;
            this.buttonEx1.FadingSpeed = 20;
            this.buttonEx1.FlatAppearance.BorderSize = 0;
            this.buttonEx1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx1.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.buttonEx1.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx1.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx1.Image")));
            this.buttonEx1.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx1.ImageOffset = 2;
            this.buttonEx1.IsPressed = false;
            this.buttonEx1.KeepPress = false;
            this.buttonEx1.Location = new System.Drawing.Point(0, 0);
            this.buttonEx1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx1.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx1.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx1.Name = "buttonEx1";
            this.buttonEx1.Radius = 6;
            this.buttonEx1.ShowBase = false;
            this.buttonEx1.Size = new System.Drawing.Size(220, 44);
            this.buttonEx1.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx1.SplitDistance = 0;
            this.buttonEx1.TabIndex = 47;
            this.buttonEx1.Text = "CMS检验项目安排";
            this.buttonEx1.Title = "";
            this.buttonEx1.UseVisualStyleBackColor = true;
            // 
            // btnGunter
            // 
            this.btnGunter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGunter.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnGunter.BackColor = System.Drawing.Color.Transparent;
            this.btnGunter.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnGunter.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnGunter.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnGunter.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnGunter.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnGunter.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnGunter.FadingSpeed = 20;
            this.btnGunter.FlatAppearance.BorderSize = 0;
            this.btnGunter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGunter.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnGunter.Image = ((System.Drawing.Image)(resources.GetObject("btnGunter.Image")));
            this.btnGunter.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnGunter.ImageOffset = 5;
            this.btnGunter.IsPressed = false;
            this.btnGunter.KeepPress = false;
            this.btnGunter.Location = new System.Drawing.Point(510, 4);
            this.btnGunter.Margin = new System.Windows.Forms.Padding(0);
            this.btnGunter.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnGunter.MenuPos = new System.Drawing.Point(0, 0);
            this.btnGunter.Name = "btnGunter";
            this.btnGunter.Radius = 6;
            this.btnGunter.ShowBase = true;
            this.btnGunter.Size = new System.Drawing.Size(162, 43);
            this.btnGunter.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnGunter.SplitDistance = 0;
            this.btnGunter.TabIndex = 54;
            this.btnGunter.Text = "自查项目日期调整";
            this.btnGunter.Title = "";
            this.toolTipBtnSelComp.SetToolTip(this.btnGunter, "将所有的CMS标准项目自动产生一条计划，\r\n如果找到上次检验记录，则翻转记录,并在上次检验日期上加5年\r\n船级社检验时,直接拷贝预计检验日期。");
            this.btnGunter.UseVisualStyleBackColor = true;
            this.btnGunter.Click += new System.EventHandler(this.btnGunter_Click);
            // 
            // btn_BandingWorkinfo
            // 
            this.btn_BandingWorkinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_BandingWorkinfo.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btn_BandingWorkinfo.BackColor = System.Drawing.Color.Transparent;
            this.btn_BandingWorkinfo.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btn_BandingWorkinfo.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_BandingWorkinfo.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btn_BandingWorkinfo.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btn_BandingWorkinfo.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_BandingWorkinfo.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_BandingWorkinfo.FadingSpeed = 20;
            this.btn_BandingWorkinfo.FlatAppearance.BorderSize = 0;
            this.btn_BandingWorkinfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BandingWorkinfo.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btn_BandingWorkinfo.Image = ((System.Drawing.Image)(resources.GetObject("btn_BandingWorkinfo.Image")));
            this.btn_BandingWorkinfo.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btn_BandingWorkinfo.ImageOffset = 5;
            this.btn_BandingWorkinfo.IsPressed = false;
            this.btn_BandingWorkinfo.KeepPress = false;
            this.btn_BandingWorkinfo.Location = new System.Drawing.Point(755, 4);
            this.btn_BandingWorkinfo.Margin = new System.Windows.Forms.Padding(0);
            this.btn_BandingWorkinfo.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btn_BandingWorkinfo.MenuPos = new System.Drawing.Point(0, 0);
            this.btn_BandingWorkinfo.Name = "btn_BandingWorkinfo";
            this.btn_BandingWorkinfo.Radius = 6;
            this.btn_BandingWorkinfo.ShowBase = true;
            this.btn_BandingWorkinfo.Size = new System.Drawing.Size(133, 43);
            this.btn_BandingWorkinfo.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btn_BandingWorkinfo.SplitDistance = 0;
            this.btn_BandingWorkinfo.TabIndex = 53;
            this.btn_BandingWorkinfo.Text = "关联工单";
            this.btn_BandingWorkinfo.Title = "";
            this.toolTipBtnSelComp.SetToolTip(this.btn_BandingWorkinfo, "将所有绑定过工作信息的检验项目与工单相关联。已经关联过的也可以在此进行调整");
            this.btn_BandingWorkinfo.UseVisualStyleBackColor = true;
            this.btn_BandingWorkinfo.Click += new System.EventHandler(this.btn_BandingWorkinfo_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnClose.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnClose.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnClose.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnClose.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnClose.FadingSpeed = 20;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnClose.ImageOffset = 2;
            this.btnClose.IsPressed = false;
            this.btnClose.KeepPress = false;
            this.btnClose.Location = new System.Drawing.Point(888, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnClose.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 6;
            this.btnClose.ShowBase = true;
            this.btnClose.Size = new System.Drawing.Size(87, 43);
            this.btnClose.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnClose.SplitDistance = 0;
            this.btnClose.TabIndex = 46;
            this.btnClose.Text = "关闭";
            this.btnClose.Title = "";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.bdNgClose_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnCreate.BackColor = System.Drawing.Color.Transparent;
            this.btnCreate.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnCreate.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCreate.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnCreate.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnCreate.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCreate.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCreate.FadingSpeed = 20;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnCreate.Image = ((System.Drawing.Image)(resources.GetObject("btnCreate.Image")));
            this.btnCreate.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnCreate.ImageOffset = 5;
            this.btnCreate.IsPressed = false;
            this.btnCreate.KeepPress = false;
            this.btnCreate.Location = new System.Drawing.Point(381, 4);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(0);
            this.btnCreate.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnCreate.MenuPos = new System.Drawing.Point(0, 0);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Radius = 6;
            this.btnCreate.ShowBase = true;
            this.btnCreate.Size = new System.Drawing.Size(129, 43);
            this.btnCreate.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnCreate.SplitDistance = 0;
            this.btnCreate.TabIndex = 52;
            this.btnCreate.Text = "形成明细项";
            this.btnCreate.Title = "";
            this.toolTipBtnSelComp.SetToolTip(this.btnCreate, "将所有的CMS标准项目自动产生一条计划，\r\n如果找到上次检验记录，则翻转记录,并在上次检验日期上加5年\r\n船级社检验时,直接拷贝预计检验日期。");
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnSave.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSave.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnSave.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnSave.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSave.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSave.FadingSpeed = 20;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnSave.ImageOffset = 5;
            this.btnSave.IsPressed = false;
            this.btnSave.KeepPress = false;
            this.btnSave.Location = new System.Drawing.Point(672, 4);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSave.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Radius = 6;
            this.btnSave.ShowBase = true;
            this.btnSave.Size = new System.Drawing.Size(83, 43);
            this.btnSave.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnSave.SplitDistance = 0;
            this.btnSave.TabIndex = 51;
            this.btnSave.Text = "保存";
            this.btnSave.Title = "";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpWorkOrderList
            // 
            this.grpWorkOrderList.Controls.Add(this.tableLayoutPanel2);
            this.grpWorkOrderList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpWorkOrderList.Location = new System.Drawing.Point(3, 59);
            this.grpWorkOrderList.Name = "grpWorkOrderList";
            this.grpWorkOrderList.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.grpWorkOrderList.Size = new System.Drawing.Size(978, 509);
            this.grpWorkOrderList.TabIndex = 12;
            this.grpWorkOrderList.TabStop = false;
            this.grpWorkOrderList.Text = "检验项目内容";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 17);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.15126F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.84874F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(962, 484);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(956, 121);
            this.panel1.TabIndex = 7;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.txtDetail, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.label6, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtCheckPlace, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.dtCheckDate, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.dtBegin, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.dtEnd, 5, 1);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.ucShipSelect1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtCheckName, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(956, 121);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // txtDetail
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.txtDetail, 5);
            this.txtDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetail.Location = new System.Drawing.Point(123, 55);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.tableLayoutPanel3.SetRowSpan(this.txtDetail, 2);
            this.txtDetail.Size = new System.Drawing.Size(830, 63);
            this.txtDetail.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(321, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 26);
            this.label4.TabIndex = 9;
            this.label4.Text = "自检跨度开始";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(639, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "预计检验地点";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(639, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 26);
            this.label6.TabIndex = 9;
            this.label6.Text = "自检跨度结束";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCheckPlace
            // 
            this.txtCheckPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCheckPlace.Location = new System.Drawing.Point(759, 3);
            this.txtCheckPlace.Name = "txtCheckPlace";
            this.txtCheckPlace.Size = new System.Drawing.Size(194, 21);
            this.txtCheckPlace.TabIndex = 2;
            // 
            // dtCheckDate
            // 
            this.dtCheckDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtCheckDate.Location = new System.Drawing.Point(123, 29);
            this.dtCheckDate.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dtCheckDate.MaxValue = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtCheckDate.MimValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtCheckDate.Name = "dtCheckDate";
            this.dtCheckDate.ReadOnly = false;
            this.dtCheckDate.Size = new System.Drawing.Size(192, 23);
            this.dtCheckDate.TabIndex = 3;
            this.dtCheckDate.Value = new System.DateTime(((long)(0)));
            this.dtCheckDate.Enter += new System.EventHandler(this.dtCheckDate_Enter);
            // 
            // dtBegin
            // 
            this.dtBegin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtBegin.Location = new System.Drawing.Point(441, 29);
            this.dtBegin.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dtBegin.MaxValue = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtBegin.MimValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtBegin.Name = "dtBegin";
            this.dtBegin.ReadOnly = false;
            this.dtBegin.Size = new System.Drawing.Size(192, 23);
            this.dtBegin.TabIndex = 4;
            this.dtBegin.Value = new System.DateTime(((long)(0)));
            // 
            // dtEnd
            // 
            this.dtEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtEnd.Location = new System.Drawing.Point(759, 29);
            this.dtEnd.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dtEnd.MaxValue = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtEnd.MimValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.ReadOnly = false;
            this.dtEnd.Size = new System.Drawing.Size(194, 23);
            this.dtEnd.TabIndex = 5;
            this.dtEnd.Value = new System.DateTime(((long)(0)));
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(3, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 23);
            this.label7.TabIndex = 9;
            this.label7.Text = "检验说明";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 26);
            this.label2.TabIndex = 9;
            this.label2.Text = "检验船舶*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucShipSelect1
            // 
            this.ucShipSelect1.CanEdit = false;
            this.ucShipSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucShipSelect1.DropDownWidth = 192;
            this.ucShipSelect1.Location = new System.Drawing.Point(123, 3);
            this.ucShipSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipSelect1.Name = "ucShipSelect1";
            this.ucShipSelect1.NullValueShow = "";
            this.ucShipSelect1.ShowButton = false;
            this.ucShipSelect1.Size = new System.Drawing.Size(192, 20);
            this.ucShipSelect1.TabIndex = 0;
            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "预计检验日期*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(321, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 26);
            this.label1.TabIndex = 9;
            this.label1.Text = "检验编码*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCheckName
            // 
            this.txtCheckName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCheckName.Location = new System.Drawing.Point(441, 3);
            this.txtCheckName.Name = "txtCheckName";
            this.txtCheckName.Size = new System.Drawing.Size(192, 21);
            this.txtCheckName.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.dgvCMSWorkOrder);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 160);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(956, 321);
            this.panel2.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(5, 29);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 21);
            this.dateTimePicker1.TabIndex = 9;
            this.dateTimePicker1.Visible = false;
            // 
            // dgvCMSWorkOrder
            // 
            this.dgvCMSWorkOrder.AllowUserToAddRows = false;
            this.dgvCMSWorkOrder.AllowUserToDeleteRows = false;
            this.dgvCMSWorkOrder.AllowUserToOrderColumns = true;
            this.dgvCMSWorkOrder.AutoFit = true;
            this.dgvCMSWorkOrder.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvCMSWorkOrder.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCMSWorkOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCMSWorkOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCMSWorkOrder.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCMSWorkOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCMSWorkOrder.EnableHeadersVisualStyles = false;
            this.dgvCMSWorkOrder.ExportColorToExcel = false;
            this.dgvCMSWorkOrder.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvCMSWorkOrder.Footer")));
            this.dgvCMSWorkOrder.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvCMSWorkOrder.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvCMSWorkOrder.Header")));
            this.dgvCMSWorkOrder.LoadedFinish = false;
            this.dgvCMSWorkOrder.Location = new System.Drawing.Point(0, 0);
            this.dgvCMSWorkOrder.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvCMSWorkOrder.MergeColumnNames")));
            this.dgvCMSWorkOrder.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvCMSWorkOrder.MergeRowColumn")));
            this.dgvCMSWorkOrder.Name = "dgvCMSWorkOrder";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCMSWorkOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCMSWorkOrder.RowHeadersWidth = 25;
            this.dgvCMSWorkOrder.RowTemplate.Height = 23;
            this.dgvCMSWorkOrder.ShowRowNumber = false;
            this.dgvCMSWorkOrder.Size = new System.Drawing.Size(956, 321);
            this.dgvCMSWorkOrder.TabIndex = 7;
            this.dgvCMSWorkOrder.Title = "";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.radioButton3);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.dt_other);
            this.panel4.Controls.Add(this.radioButton2);
            this.panel4.Controls.Add(this.radioButton1);
            this.panel4.Controls.Add(this.btn_sel_null);
            this.panel4.Controls.Add(this.btn_selAll);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 127);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(962, 30);
            this.panel4.TabIndex = 54;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(238, 6);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(107, 16);
            this.radioButton3.TabIndex = 6;
            this.radioButton3.Text = "轮机长其他日期";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(534, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "统一设置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dt_other
            // 
            this.dt_other.Enabled = false;
            this.dt_other.Location = new System.Drawing.Point(351, 4);
            this.dt_other.Name = "dt_other";
            this.dt_other.Size = new System.Drawing.Size(112, 21);
            this.dt_other.TabIndex = 4;
            this.dt_other.ValueChanged += new System.EventHandler(this.dt_other_ValueChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(469, 6);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 16);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.Text = "船级社";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(143, 6);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(89, 16);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "轮机长2年半";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // btn_sel_null
            // 
            this.btn_sel_null.Location = new System.Drawing.Point(57, 3);
            this.btn_sel_null.Name = "btn_sel_null";
            this.btn_sel_null.Size = new System.Drawing.Size(55, 23);
            this.btn_sel_null.TabIndex = 1;
            this.btn_sel_null.Text = "全清";
            this.btn_sel_null.UseVisualStyleBackColor = true;
            this.btn_sel_null.Click += new System.EventHandler(this.btn_sel_null_Click);
            // 
            // btn_selAll
            // 
            this.btn_selAll.Location = new System.Drawing.Point(3, 3);
            this.btn_selAll.Name = "btn_selAll";
            this.btn_selAll.Size = new System.Drawing.Size(55, 23);
            this.btn_selAll.TabIndex = 0;
            this.btn_selAll.Text = "全选";
            this.btn_selAll.UseVisualStyleBackColor = true;
            this.btn_selAll.Click += new System.EventHandler(this.btn_selAll_Click);
            // 
            // FrmCMSDateSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 571);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmCMSDateSetting";
            this.Text = "CMS检验项目安排";
            this.Load += new System.EventHandler(this.FrmWorkOrderHistory_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmWorkOrderHistory_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.grpWorkOrderList.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCMSWorkOrder)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCMSCheck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grpWorkOrderList;
        private System.Windows.Forms.BindingSource bdsCMSCheck;
        private System.Windows.Forms.ToolTip toolTipBtnSelComp;
        private CommonViewer.ButtonEx btnClose;
        private CommonViewer.ButtonEx buttonEx1;
        private CommonViewer.ButtonEx btnCreate;
        private CommonViewer.ButtonEx btnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private CommonViewer.TextBoxEx txtCheckName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private CommonViewer.TextBoxEx txtCheckPlace;
        private CommonViewer.DateTimePickerEx dtCheckDate;
        private CommonViewer.DateTimePickerEx dtBegin;
        private CommonViewer.DateTimePickerEx dtEnd;
        private CommonViewer.TextBoxEx txtDetail;
        private BaseInfo.Viewer.UcShipSelect ucShipSelect1;
        private System.Windows.Forms.Label label7;
        private CommonViewer.ButtonEx btn_BandingWorkinfo;
        private System.Windows.Forms.Panel panel2;
        private CommonViewer.UcDataGridView dgvCMSWorkOrder;
        private CommonViewer.ButtonEx btnGunter;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_sel_null;
        private System.Windows.Forms.Button btn_selAll;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dt_other;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}