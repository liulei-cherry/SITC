namespace Repair.Viewer
{
    partial class FrmRepairApplyEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRepairApplyEdit));
            this.label3 = new System.Windows.Forms.Label();
            this.txtProjectName = new CommonViewer.TextBoxEx();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new CommonViewer.ButtonEx();
            this.btnDisagree = new CommonViewer.ButtonEx();
            this.btnAgree = new CommonViewer.ButtonEx();
            this.btnSubmit = new CommonViewer.ButtonEx();
            this.btnPass = new CommonViewer.ButtonEx();
            this.btnSave = new CommonViewer.ButtonEx();
            this.buttonEx6 = new CommonViewer.ButtonEx();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.folderBD = new System.Windows.Forms.FolderBrowserDialog();
            this.txtRemark = new CommonViewer.TextBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtApplicant = new CommonViewer.TextBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.toolTipMain = new System.Windows.Forms.ToolTip();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtJWComfirm = new CommonViewer.TextBoxEx();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxCostType = new System.Windows.Forms.ComboBox();
            this.cbxRepairType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProjectDetail = new CommonViewer.TextBoxEx();
            this.label11 = new System.Windows.Forms.Label();
            this.txtApplypost = new CommonViewer.TextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.labShip = new System.Windows.Forms.Label();
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.ucComponentSelect1 = new ItemsManage.Viewer.UcComponentSelect();
            this.dtpApplyDate = new CommonViewer.DateTimePickerEx();
            this.dtpApplyCompleteDate = new CommonViewer.DateTimePickerEx();
            this.bindingSourceDetail = new System.Windows.Forms.BindingSource();
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "修理项目名称*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProjectName
            // 
            this.txtProjectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProjectName.Location = new System.Drawing.Point(113, 3);
            this.txtProjectName.MaxLength = 50;
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(145, 21);
            this.txtProjectName.TabIndex = 21;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.flowLayoutPanel1);
            this.panel4.Controls.Add(this.buttonEx6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5);
            this.panel4.Size = new System.Drawing.Size(1025, 56);
            this.panel4.TabIndex = 13;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btnDisagree);
            this.flowLayoutPanel1.Controls.Add(this.btnAgree);
            this.flowLayoutPanel1.Controls.Add(this.btnSubmit);
            this.flowLayoutPanel1.Controls.Add(this.btnPass);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(300, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(720, 46);
            this.flowLayoutPanel1.TabIndex = 25;
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
            this.btnClose.Location = new System.Drawing.Point(678, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnClose.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 6;
            this.btnClose.ShowBase = true;
            this.btnClose.Size = new System.Drawing.Size(42, 42);
            this.btnClose.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnClose.SplitDistance = 0;
            this.btnClose.TabIndex = 22;
            this.btnClose.Title = "";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.bdNgClose_Click);
            // 
            // btnDisagree
            // 
            this.btnDisagree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisagree.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnDisagree.BackColor = System.Drawing.Color.Transparent;
            this.btnDisagree.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnDisagree.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnDisagree.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnDisagree.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnDisagree.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDisagree.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDisagree.FadingSpeed = 20;
            this.btnDisagree.FlatAppearance.BorderSize = 0;
            this.btnDisagree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDisagree.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDisagree.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnDisagree.Image = ((System.Drawing.Image)(resources.GetObject("btnDisagree.Image")));
            this.btnDisagree.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnDisagree.ImageOffset = 3;
            this.btnDisagree.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDisagree.IsPressed = false;
            this.btnDisagree.KeepPress = false;
            this.btnDisagree.Location = new System.Drawing.Point(576, 0);
            this.btnDisagree.Margin = new System.Windows.Forms.Padding(0);
            this.btnDisagree.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnDisagree.MenuPos = new System.Drawing.Point(0, 0);
            this.btnDisagree.Name = "btnDisagree";
            this.btnDisagree.Radius = 6;
            this.btnDisagree.ShowBase = true;
            this.btnDisagree.Size = new System.Drawing.Size(102, 42);
            this.btnDisagree.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnDisagree.SplitDistance = 0;
            this.btnDisagree.TabIndex = 24;
            this.btnDisagree.Text = "不同意";
            this.btnDisagree.Title = "";
            this.btnDisagree.UseVisualStyleBackColor = true;
            this.btnDisagree.Visible = false;
            this.btnDisagree.Click += new System.EventHandler(this.btnDisagree_Click);
            // 
            // btnAgree
            // 
            this.btnAgree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgree.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnAgree.BackColor = System.Drawing.Color.Transparent;
            this.btnAgree.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnAgree.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnAgree.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAgree.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAgree.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAgree.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAgree.FadingSpeed = 20;
            this.btnAgree.FlatAppearance.BorderSize = 0;
            this.btnAgree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgree.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAgree.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnAgree.Image = ((System.Drawing.Image)(resources.GetObject("btnAgree.Image")));
            this.btnAgree.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnAgree.ImageOffset = 3;
            this.btnAgree.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAgree.IsPressed = false;
            this.btnAgree.KeepPress = false;
            this.btnAgree.Location = new System.Drawing.Point(486, 0);
            this.btnAgree.Margin = new System.Windows.Forms.Padding(0);
            this.btnAgree.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAgree.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAgree.Name = "btnAgree";
            this.btnAgree.Radius = 6;
            this.btnAgree.ShowBase = true;
            this.btnAgree.Size = new System.Drawing.Size(90, 42);
            this.btnAgree.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnAgree.SplitDistance = 0;
            this.btnAgree.TabIndex = 24;
            this.btnAgree.Text = "同意";
            this.btnAgree.Title = "";
            this.btnAgree.UseVisualStyleBackColor = true;
            this.btnAgree.Visible = false;
            this.btnAgree.Click += new System.EventHandler(this.btnAgree_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnSubmit.BackColor = System.Drawing.Color.Transparent;
            this.btnSubmit.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnSubmit.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnSubmit.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnSubmit.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnSubmit.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSubmit.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSubmit.FadingSpeed = 20;
            this.btnSubmit.FlatAppearance.BorderSize = 0;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSubmit.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnSubmit.Image = ((System.Drawing.Image)(resources.GetObject("btnSubmit.Image")));
            this.btnSubmit.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnSubmit.ImageOffset = 3;
            this.btnSubmit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSubmit.IsPressed = false;
            this.btnSubmit.KeepPress = false;
            this.btnSubmit.Location = new System.Drawing.Point(370, 0);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(0);
            this.btnSubmit.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSubmit.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Radius = 6;
            this.btnSubmit.ShowBase = true;
            this.btnSubmit.Size = new System.Drawing.Size(116, 42);
            this.btnSubmit.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnSubmit.SplitDistance = 0;
            this.btnSubmit.TabIndex = 24;
            this.btnSubmit.Text = "提交上级";
            this.btnSubmit.Title = "";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Visible = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnPass
            // 
            this.btnPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPass.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnPass.BackColor = System.Drawing.Color.Transparent;
            this.btnPass.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnPass.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnPass.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnPass.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnPass.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnPass.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnPass.FadingSpeed = 20;
            this.btnPass.FlatAppearance.BorderSize = 0;
            this.btnPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPass.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnPass.Image = ((System.Drawing.Image)(resources.GetObject("btnPass.Image")));
            this.btnPass.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnPass.ImageOffset = 3;
            this.btnPass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPass.IsPressed = false;
            this.btnPass.KeepPress = false;
            this.btnPass.Location = new System.Drawing.Point(231, 0);
            this.btnPass.Margin = new System.Windows.Forms.Padding(0);
            this.btnPass.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnPass.MenuPos = new System.Drawing.Point(0, 0);
            this.btnPass.Name = "btnPass";
            this.btnPass.Radius = 6;
            this.btnPass.ShowBase = true;
            this.btnPass.Size = new System.Drawing.Size(139, 42);
            this.btnPass.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnPass.SplitDistance = 0;
            this.btnPass.TabIndex = 24;
            this.btnPass.Text = "审批通过";
            this.btnPass.Title = "";
            this.btnPass.UseVisualStyleBackColor = true;
            this.btnPass.Visible = false;
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
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
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnSave.ImageOffset = 5;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.IsPressed = false;
            this.btnSave.KeepPress = false;
            this.btnSave.Location = new System.Drawing.Point(118, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSave.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Radius = 6;
            this.btnSave.ShowBase = true;
            this.btnSave.Size = new System.Drawing.Size(113, 42);
            this.btnSave.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnSave.SplitDistance = 0;
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "保存草稿";
            this.btnSave.Title = "";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // buttonEx6
            // 
            this.buttonEx6.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonEx6.BackColor = System.Drawing.Color.Transparent;
            this.buttonEx6.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonEx6.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.buttonEx6.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonEx6.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonEx6.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonEx6.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonEx6.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonEx6.Enabled = false;
            this.buttonEx6.FadingSpeed = 20;
            this.buttonEx6.FlatAppearance.BorderSize = 0;
            this.buttonEx6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx6.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.buttonEx6.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx6.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx6.Image")));
            this.buttonEx6.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx6.ImageOffset = 3;
            this.buttonEx6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonEx6.IsPressed = false;
            this.buttonEx6.KeepPress = false;
            this.buttonEx6.Location = new System.Drawing.Point(5, 5);
            this.buttonEx6.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx6.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx6.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx6.Name = "buttonEx6";
            this.buttonEx6.Radius = 6;
            this.buttonEx6.ShowBase = false;
            this.buttonEx6.Size = new System.Drawing.Size(295, 46);
            this.buttonEx6.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx6.SplitDistance = 0;
            this.buttonEx6.TabIndex = 23;
            this.buttonEx6.Text = "修船申请明细编辑";
            this.buttonEx6.Title = "";
            this.buttonEx6.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(766, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(84, 30);
            this.label12.TabIndex = 1;
            this.label12.Text = "申请日期*";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 277);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 80);
            this.label9.TabIndex = 1;
            this.label9.Text = "备    注";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemark
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtRemark, 7);
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.Location = new System.Drawing.Point(113, 280);
            this.txtRemark.MaxLength = 2000;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(889, 74);
            this.txtRemark.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "希望完成时间*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(515, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 30);
            this.label8.TabIndex = 1;
            this.label8.Text = "申请人岗位*";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtApplicant
            // 
            this.txtApplicant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtApplicant.Location = new System.Drawing.Point(364, 3);
            this.txtApplicant.MaxLength = 20;
            this.txtApplicant.Name = "txtApplicant";
            this.txtApplicant.ReadOnly = true;
            this.txtApplicant.Size = new System.Drawing.Size(145, 21);
            this.txtApplicant.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(264, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 30);
            this.label6.TabIndex = 1;
            this.label6.Text = "申请人*";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(1025, 464);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "申请单信息";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.txtJWComfirm, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cbxCostType, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.cbxRepairType, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtProjectName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label12, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label8, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtApplicant, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtProjectDetail, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label11, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtApplypost, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtRemark, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label1, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.labShip, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.ucShipSelect1, 7, 1);
            this.tableLayoutPanel2.Controls.Add(this.ucComponentSelect1, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.dtpApplyDate, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.dtpApplyCompleteDate, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1005, 430);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // txtJWComfirm
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtJWComfirm, 7);
            this.txtJWComfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtJWComfirm.Location = new System.Drawing.Point(113, 360);
            this.txtJWComfirm.MaxLength = 2000;
            this.txtJWComfirm.Multiline = true;
            this.txtJWComfirm.Name = "txtJWComfirm";
            this.txtJWComfirm.Size = new System.Drawing.Size(889, 74);
            this.txtJWComfirm.TabIndex = 56;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 357);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 80);
            this.label7.TabIndex = 55;
            this.label7.Text = "机务审批意见";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 30);
            this.label2.TabIndex = 51;
            this.label2.Text = "修理设备";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxCostType
            // 
            this.cbxCostType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxCostType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCostType.DropDownWidth = 245;
            this.cbxCostType.FormattingEnabled = true;
            this.cbxCostType.Location = new System.Drawing.Point(615, 33);
            this.cbxCostType.Name = "cbxCostType";
            this.cbxCostType.Size = new System.Drawing.Size(145, 20);
            this.cbxCostType.TabIndex = 48;
            // 
            // cbxRepairType
            // 
            this.cbxRepairType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxRepairType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRepairType.FormattingEnabled = true;
            this.cbxRepairType.Location = new System.Drawing.Point(364, 33);
            this.cbxRepairType.Name = "cbxRepairType";
            this.cbxRepairType.Size = new System.Drawing.Size(145, 20);
            this.cbxRepairType.TabIndex = 46;
            this.cbxRepairType.SelectedIndexChanged += new System.EventHandler(this.ckbRepairType_SelectedIndexChanged);
            this.cbxRepairType.TextChanged += new System.EventHandler(this.ckbRepairType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 187);
            this.label4.TabIndex = 1;
            this.label4.Text = "修理项目内容";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProjectDetail
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtProjectDetail, 7);
            this.txtProjectDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProjectDetail.Location = new System.Drawing.Point(113, 93);
            this.txtProjectDetail.MaxLength = 500;
            this.txtProjectDetail.Multiline = true;
            this.txtProjectDetail.Name = "txtProjectDetail";
            this.txtProjectDetail.Size = new System.Drawing.Size(889, 181);
            this.txtProjectDetail.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(264, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 30);
            this.label11.TabIndex = 1;
            this.label11.Text = "航修或坞修*";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtApplypost
            // 
            this.txtApplypost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtApplypost.Location = new System.Drawing.Point(615, 3);
            this.txtApplypost.MaxLength = 20;
            this.txtApplypost.Name = "txtApplypost";
            this.txtApplypost.ReadOnly = true;
            this.txtApplypost.Size = new System.Drawing.Size(145, 21);
            this.txtApplypost.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(515, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 30);
            this.label1.TabIndex = 47;
            this.label1.Text = "费用类型*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labShip
            // 
            this.labShip.AutoSize = true;
            this.labShip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labShip.Location = new System.Drawing.Point(766, 30);
            this.labShip.Name = "labShip";
            this.labShip.Size = new System.Drawing.Size(84, 30);
            this.labShip.TabIndex = 49;
            this.labShip.Text = "船舶*";
            this.labShip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucShipSelect1
            // 
            this.ucShipSelect1.CanEdit = false;
            this.ucShipSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucShipSelect1.DropDownWidth = 240;
            this.ucShipSelect1.Location = new System.Drawing.Point(856, 33);
            this.ucShipSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipSelect1.Name = "ucShipSelect1";
            this.ucShipSelect1.NullValueShow = "";
            this.ucShipSelect1.ShowButton = false;
            this.ucShipSelect1.Size = new System.Drawing.Size(146, 20);
            this.ucShipSelect1.TabIndex = 50;
            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            // 
            // ucComponentSelect1
            // 
            this.ucComponentSelect1.CanEdit = true;
            this.tableLayoutPanel2.SetColumnSpan(this.ucComponentSelect1, 3);
            this.ucComponentSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucComponentSelect1.Location = new System.Drawing.Point(110, 60);
            this.ucComponentSelect1.Margin = new System.Windows.Forms.Padding(0);
            this.ucComponentSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucComponentSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucComponentSelect1.Name = "ucComponentSelect1";
            this.ucComponentSelect1.ShipId = "2e09fa8d-955c-44d7-8acd-fc151db84e89";
            this.ucComponentSelect1.Size = new System.Drawing.Size(402, 20);
            this.ucComponentSelect1.TabIndex = 52;
            // 
            // dtpApplyDate
            // 
            this.dtpApplyDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpApplyDate.Location = new System.Drawing.Point(856, 3);
            this.dtpApplyDate.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dtpApplyDate.MaxValue = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpApplyDate.MimValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpApplyDate.Name = "dtpApplyDate";
            this.dtpApplyDate.ReadOnly = false;
            this.dtpApplyDate.Size = new System.Drawing.Size(146, 27);
            this.dtpApplyDate.TabIndex = 53;
            this.dtpApplyDate.Value = new System.DateTime(((long)(0)));
            // 
            // dtpApplyCompleteDate
            // 
            this.dtpApplyCompleteDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpApplyCompleteDate.Location = new System.Drawing.Point(113, 33);
            this.dtpApplyCompleteDate.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dtpApplyCompleteDate.MaxValue = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpApplyCompleteDate.MimValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpApplyCompleteDate.Name = "dtpApplyCompleteDate";
            this.dtpApplyCompleteDate.ReadOnly = false;
            this.dtpApplyCompleteDate.Size = new System.Drawing.Size(145, 27);
            this.dtpApplyCompleteDate.TabIndex = 54;
            this.dtpApplyCompleteDate.Value = new System.DateTime(((long)(0)));
            // 
            // FrmRepairApplyEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 520);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel4);
            this.Name = "FrmRepairApplyEdit";
            this.Text = "修船申请明细编辑";
            this.Load += new System.EventHandler(this.FrmRepairApplyEdit_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private CommonViewer.TextBoxEx txtProjectName;
        protected System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        protected CommonViewer.ButtonEx btnClose;
        public CommonViewer.ButtonEx btnDisagree;
        public CommonViewer.ButtonEx btnAgree;
        public CommonViewer.ButtonEx btnSave;
        public CommonViewer.ButtonEx buttonEx6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private CommonViewer.TextBoxEx txtRemark;
        private System.Windows.Forms.ToolTip toolTipMain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private CommonViewer.TextBoxEx txtApplicant;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FolderBrowserDialog folderBD;
        private System.Windows.Forms.BindingSource bindingSourceDetail;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private CommonViewer.TextBoxEx txtProjectDetail;
        private System.Windows.Forms.Label label11;
        private CommonViewer.TextBoxEx txtApplypost;
        private System.Windows.Forms.ComboBox cbxCostType;
        private System.Windows.Forms.ComboBox cbxRepairType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labShip;
        private BaseInfo.Viewer.UcShipSelect ucShipSelect1;
        private System.Windows.Forms.Label label2;
        private ItemsManage.Viewer.UcComponentSelect ucComponentSelect1;
        public CommonViewer.ButtonEx btnSubmit;
        private CommonViewer.DateTimePickerEx dtpApplyDate;
        private CommonViewer.DateTimePickerEx dtpApplyCompleteDate;
        public CommonViewer.ButtonEx btnPass;
        private CommonViewer.TextBoxEx txtJWComfirm;
        private System.Windows.Forms.Label label7;
    }
}