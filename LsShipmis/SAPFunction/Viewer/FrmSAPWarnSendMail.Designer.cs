namespace SAPFunction.Viewer
{
    partial class FrmSAPWarnSendMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSAPWarnSendMail));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.bindingSourceMain = new System.Windows.Forms.BindingSource(this.components);
            this.CloseButton = new CommonViewer.ButtonEx();
            this.btnSave = new CommonViewer.ButtonEx();
            this.btnAddDetail = new CommonViewer.ButtonEx();
            this.btnDeleteDetail = new CommonViewer.ButtonEx();
            this.buttonEx2 = new CommonViewer.ButtonEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSmtpWarnServer = new System.Windows.Forms.TextBox();
            this.txtSmtpWarnUserName = new System.Windows.Forms.TextBox();
            this.txtSSLWarnPort = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtSpotWarnName = new System.Windows.Forms.TextBox();
            this.txtWarnPassword = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
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
            this.CloseButton.Location = new System.Drawing.Point(688, 9);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.CloseButton.MenuPos = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Radius = 6;
            this.CloseButton.ShowBase = true;
            this.CloseButton.Size = new System.Drawing.Size(81, 44);
            this.CloseButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.CloseButton.SplitDistance = 0;
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "关闭";
            this.CloseButton.Title = "";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
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
            this.btnSave.ImageOffset = 3;
            this.btnSave.IsPressed = false;
            this.btnSave.KeepPress = false;
            this.btnSave.Location = new System.Drawing.Point(584, 9);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSave.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Radius = 6;
            this.btnSave.ShowBase = true;
            this.btnSave.Size = new System.Drawing.Size(103, 44);
            this.btnSave.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnSave.SplitDistance = 0;
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存修改";
            this.btnSave.Title = "";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddDetail
            // 
            this.btnAddDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDetail.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnAddDetail.BackColor = System.Drawing.Color.Transparent;
            this.btnAddDetail.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnAddDetail.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnAddDetail.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAddDetail.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAddDetail.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAddDetail.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAddDetail.FadingSpeed = 20;
            this.btnAddDetail.FlatAppearance.BorderSize = 0;
            this.btnAddDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDetail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddDetail.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnAddDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnAddDetail.Image")));
            this.btnAddDetail.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnAddDetail.ImageOffset = 2;
            this.btnAddDetail.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAddDetail.IsPressed = false;
            this.btnAddDetail.KeepPress = false;
            this.btnAddDetail.Location = new System.Drawing.Point(352, 9);
            this.btnAddDetail.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddDetail.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAddDetail.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Radius = 6;
            this.btnAddDetail.ShowBase = true;
            this.btnAddDetail.Size = new System.Drawing.Size(115, 44);
            this.btnAddDetail.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnAddDetail.SplitDistance = 0;
            this.btnAddDetail.TabIndex = 26;
            this.btnAddDetail.Text = "添加发送点";
            this.btnAddDetail.Title = "";
            this.btnAddDetail.UseVisualStyleBackColor = true;
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            // 
            // btnDeleteDetail
            // 
            this.btnDeleteDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteDetail.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnDeleteDetail.BackColor = System.Drawing.Color.Transparent;
            this.btnDeleteDetail.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnDeleteDetail.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnDeleteDetail.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnDeleteDetail.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnDeleteDetail.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDeleteDetail.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDeleteDetail.FadingSpeed = 20;
            this.btnDeleteDetail.FlatAppearance.BorderSize = 0;
            this.btnDeleteDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDetail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDeleteDetail.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnDeleteDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteDetail.Image")));
            this.btnDeleteDetail.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnDeleteDetail.ImageOffset = 2;
            this.btnDeleteDetail.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDeleteDetail.IsPressed = false;
            this.btnDeleteDetail.KeepPress = false;
            this.btnDeleteDetail.Location = new System.Drawing.Point(468, 9);
            this.btnDeleteDetail.Margin = new System.Windows.Forms.Padding(0);
            this.btnDeleteDetail.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnDeleteDetail.MenuPos = new System.Drawing.Point(0, 0);
            this.btnDeleteDetail.Name = "btnDeleteDetail";
            this.btnDeleteDetail.Radius = 6;
            this.btnDeleteDetail.ShowBase = true;
            this.btnDeleteDetail.Size = new System.Drawing.Size(115, 44);
            this.btnDeleteDetail.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnDeleteDetail.SplitDistance = 0;
            this.btnDeleteDetail.TabIndex = 25;
            this.btnDeleteDetail.Text = "删除发送点";
            this.btnDeleteDetail.Title = "";
            this.btnDeleteDetail.UseVisualStyleBackColor = true;
            this.btnDeleteDetail.Click += new System.EventHandler(this.btnDeleteDetail_Click);
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
            this.buttonEx2.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.buttonEx2.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx2.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx2.Image")));
            this.buttonEx2.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx2.ImageOffset = 3;
            this.buttonEx2.IsPressed = false;
            this.buttonEx2.KeepPress = false;
            this.buttonEx2.Location = new System.Drawing.Point(9, 8);
            this.buttonEx2.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx2.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx2.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx2.Name = "buttonEx2";
            this.buttonEx2.Radius = 6;
            this.buttonEx2.ShowBase = false;
            this.buttonEx2.Size = new System.Drawing.Size(197, 48);
            this.buttonEx2.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx2.SplitDistance = 0;
            this.buttonEx2.TabIndex = 27;
            this.buttonEx2.Text = "邮件报警发送设置";
            this.buttonEx2.Title = "";
            this.buttonEx2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.buttonEx2);
            this.panel1.Controls.Add(this.btnDeleteDetail);
            this.panel1.Controls.Add(this.btnAddDetail);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 65);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 152);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(772, 254);
            this.panel4.TabIndex = 60;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 65);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(772, 87);
            this.panel3.TabIndex = 59;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.groupBox1.Size = new System.Drawing.Size(772, 87);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "站点信息";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSmtpWarnServer, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSmtpWarnUserName, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSSLWarnPort, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label17, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label18, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSpotWarnName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtWarnPassword, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(756, 62);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(250, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "SMTP服务器";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(458, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "SMTP用户名";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 32);
            this.label13.TabIndex = 0;
            this.label13.Text = "端口号";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSmtpWarnServer
            // 
            this.txtSmtpWarnServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSmtpWarnServer.BackColor = System.Drawing.Color.MintCream;
            this.txtSmtpWarnServer.Location = new System.Drawing.Point(322, 4);
            this.txtSmtpWarnServer.MaxLength = 50;
            this.txtSmtpWarnServer.Name = "txtSmtpWarnServer";
            this.txtSmtpWarnServer.Size = new System.Drawing.Size(130, 21);
            this.txtSmtpWarnServer.TabIndex = 4;
            // 
            // txtSmtpWarnUserName
            // 
            this.txtSmtpWarnUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSmtpWarnUserName.BackColor = System.Drawing.Color.MintCream;
            this.txtSmtpWarnUserName.Location = new System.Drawing.Point(553, 4);
            this.txtSmtpWarnUserName.MaxLength = 50;
            this.txtSmtpWarnUserName.Name = "txtSmtpWarnUserName";
            this.txtSmtpWarnUserName.Size = new System.Drawing.Size(200, 21);
            this.txtSmtpWarnUserName.TabIndex = 5;
            // 
            // txtSSLWarnPort
            // 
            this.txtSSLWarnPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSSLWarnPort.BackColor = System.Drawing.Color.MintCream;
            this.txtSSLWarnPort.Location = new System.Drawing.Point(83, 35);
            this.txtSSLWarnPort.MaxLength = 50;
            this.txtSSLWarnPort.Name = "txtSSLWarnPort";
            this.txtSSLWarnPort.Size = new System.Drawing.Size(161, 21);
            this.txtSSLWarnPort.TabIndex = 6;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(250, 30);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 32);
            this.label17.TabIndex = 0;
            this.label17.Text = "邮箱密码";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Location = new System.Drawing.Point(3, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 30);
            this.label18.TabIndex = 0;
            this.label18.Text = "站点名称";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSpotWarnName
            // 
            this.txtSpotWarnName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSpotWarnName.BackColor = System.Drawing.Color.MintCream;
            this.txtSpotWarnName.Location = new System.Drawing.Point(83, 4);
            this.txtSpotWarnName.MaxLength = 50;
            this.txtSpotWarnName.Name = "txtSpotWarnName";
            this.txtSpotWarnName.Size = new System.Drawing.Size(161, 21);
            this.txtSpotWarnName.TabIndex = 1;
            // 
            // txtWarnPassword
            // 
            this.txtWarnPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWarnPassword.BackColor = System.Drawing.Color.MintCream;
            this.txtWarnPassword.Location = new System.Drawing.Point(322, 35);
            this.txtWarnPassword.MaxLength = 50;
            this.txtWarnPassword.Name = "txtWarnPassword";
            this.txtWarnPassword.PasswordChar = '*';
            this.txtWarnPassword.Size = new System.Drawing.Size(130, 21);
            this.txtWarnPassword.TabIndex = 9;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvMain);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6, 3, 6, 6);
            this.groupBox3.Size = new System.Drawing.Size(772, 254);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送点信息";
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.BackgroundColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.Location = new System.Drawing.Point(6, 17);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersWidth = 25;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.Size = new System.Drawing.Size(760, 231);
            this.dgvMain.TabIndex = 21;
            // 
            // FrmSAPWarnSendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 406);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "FrmSAPWarnSendMail";
            this.Text = "邮件报警发送设置";
            this.Load += new System.EventHandler(this.FrmSAPWarnSendMail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.BindingSource bindingSourceMain;
        private CommonViewer.ButtonEx CloseButton;
        private CommonViewer.ButtonEx btnSave;
        public CommonViewer.ButtonEx btnAddDetail;
        public CommonViewer.ButtonEx btnDeleteDetail;
        private CommonViewer.ButtonEx buttonEx2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSmtpWarnServer;
        private System.Windows.Forms.TextBox txtSmtpWarnUserName;
        private System.Windows.Forms.TextBox txtSSLWarnPort;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtSpotWarnName;
        private System.Windows.Forms.TextBox txtWarnPassword;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvMain;
    }
}