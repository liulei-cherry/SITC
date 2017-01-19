namespace StorageManage.Viewer
{
    partial class FrmMaterialPurchaseOrderEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMaterialPurchaseOrderEdit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel4 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new CommonViewer.ButtonEx();
            this.btn_disgree = new CommonViewer.ButtonEx();
            this.btn_Agree = new CommonViewer.ButtonEx();
            this.btnPass = new CommonViewer.ButtonEx();
            this.btnSubmit = new CommonViewer.ButtonEx();
            this.btnSave = new CommonViewer.ButtonEx();
            this.btnDeleteDetail = new CommonViewer.ButtonEx();
            this.btnAddDetail = new CommonViewer.ButtonEx();
            this.btnBdFiles = new CommonViewer.ButtonEx();
            this.buttonEx6 = new CommonViewer.ButtonEx();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPURCHASE_ORDER_CODE = new CommonViewer.TextBoxEx();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPURCHASE_ORDER_PERSON = new CommonViewer.TextBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtREMARK = new CommonViewer.TextBoxEx();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labShip = new System.Windows.Forms.Label();
            this.dtpPURCHASE_ORDER_DATE = new CommonViewer.DateTimePickerEx();
            this.txtLANDCHECKER = new CommonViewer.TextBoxEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDetail = new CommonViewer.UcDataGridView(this.components);
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.ucManufacturerSelect1 = new BaseInfo.Viewer.UcManufacturerSelect();
            this.ucCurrencySelect1 = new BaseInfo.Viewer.UcCurrencySelect();
            this.nudTOTALPRICE = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCHECKDATE = new CommonViewer.TextBoxEx();
            this.txtSENDDATE = new CommonViewer.TextBoxEx();
            this.ucPortSelect1 = new BaseInfo.Viewer.UcPortSelect();
            this.bindingSourceDetail = new System.Windows.Forms.BindingSource(this.components);
            this.panel4.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTOTALPRICE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).BeginInit();
            this.SuspendLayout();
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
            this.panel4.Size = new System.Drawing.Size(1167, 56);
            this.panel4.TabIndex = 43;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.btnClose);
            this.flowLayoutPanel1.Controls.Add(this.btn_disgree);
            this.flowLayoutPanel1.Controls.Add(this.btn_Agree);
            this.flowLayoutPanel1.Controls.Add(this.btnPass);
            this.flowLayoutPanel1.Controls.Add(this.btnSubmit);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Controls.Add(this.btnDeleteDetail);
            this.flowLayoutPanel1.Controls.Add(this.btnAddDetail);
            this.flowLayoutPanel1.Controls.Add(this.btnBdFiles);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(185, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(977, 46);
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
            this.btnClose.Location = new System.Drawing.Point(935, 8);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.btnClose.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnClose.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 6;
            this.btnClose.ShowBase = true;
            this.btnClose.Size = new System.Drawing.Size(42, 37);
            this.btnClose.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnClose.SplitDistance = 0;
            this.btnClose.TabIndex = 22;
            this.btnClose.Title = "";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.bdNgClose_Click);
            // 
            // btn_disgree
            // 
            this.btn_disgree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_disgree.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btn_disgree.BackColor = System.Drawing.Color.Transparent;
            this.btn_disgree.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btn_disgree.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btn_disgree.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btn_disgree.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btn_disgree.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_disgree.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_disgree.FadingSpeed = 20;
            this.btn_disgree.FlatAppearance.BorderSize = 0;
            this.btn_disgree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_disgree.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_disgree.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btn_disgree.Image = ((System.Drawing.Image)(resources.GetObject("btn_disgree.Image")));
            this.btn_disgree.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btn_disgree.ImageOffset = 3;
            this.btn_disgree.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_disgree.IsPressed = false;
            this.btn_disgree.KeepPress = false;
            this.btn_disgree.Location = new System.Drawing.Point(845, 8);
            this.btn_disgree.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.btn_disgree.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btn_disgree.MenuPos = new System.Drawing.Point(0, 0);
            this.btn_disgree.Name = "btn_disgree";
            this.btn_disgree.Radius = 6;
            this.btn_disgree.ShowBase = true;
            this.btn_disgree.Size = new System.Drawing.Size(90, 37);
            this.btn_disgree.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btn_disgree.SplitDistance = 0;
            this.btn_disgree.TabIndex = 41;
            this.btn_disgree.Text = "不同意";
            this.btn_disgree.Title = "";
            this.btn_disgree.UseVisualStyleBackColor = true;
            this.btn_disgree.Visible = false;
            this.btn_disgree.Click += new System.EventHandler(this.btn_disgree_Click);
            // 
            // btn_Agree
            // 
            this.btn_Agree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Agree.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btn_Agree.BackColor = System.Drawing.Color.Transparent;
            this.btn_Agree.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btn_Agree.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btn_Agree.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btn_Agree.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btn_Agree.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Agree.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btn_Agree.FadingSpeed = 20;
            this.btn_Agree.FlatAppearance.BorderSize = 0;
            this.btn_Agree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Agree.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_Agree.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btn_Agree.Image = ((System.Drawing.Image)(resources.GetObject("btn_Agree.Image")));
            this.btn_Agree.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btn_Agree.ImageOffset = 3;
            this.btn_Agree.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Agree.IsPressed = false;
            this.btn_Agree.KeepPress = false;
            this.btn_Agree.Location = new System.Drawing.Point(762, 8);
            this.btn_Agree.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.btn_Agree.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btn_Agree.MenuPos = new System.Drawing.Point(0, 0);
            this.btn_Agree.Name = "btn_Agree";
            this.btn_Agree.Radius = 6;
            this.btn_Agree.ShowBase = true;
            this.btn_Agree.Size = new System.Drawing.Size(83, 37);
            this.btn_Agree.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btn_Agree.SplitDistance = 0;
            this.btn_Agree.TabIndex = 40;
            this.btn_Agree.Text = "同意";
            this.btn_Agree.Title = "";
            this.btn_Agree.UseVisualStyleBackColor = true;
            this.btn_Agree.Visible = false;
            this.btn_Agree.Click += new System.EventHandler(this.btn_Agree_Click);
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
            this.btnPass.Location = new System.Drawing.Point(648, 8);
            this.btnPass.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.btnPass.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnPass.MenuPos = new System.Drawing.Point(0, 0);
            this.btnPass.Name = "btnPass";
            this.btnPass.Radius = 6;
            this.btnPass.ShowBase = true;
            this.btnPass.Size = new System.Drawing.Size(114, 37);
            this.btnPass.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnPass.SplitDistance = 0;
            this.btnPass.TabIndex = 24;
            this.btnPass.Text = "审批通过";
            this.btnPass.Title = "";
            this.btnPass.UseVisualStyleBackColor = true;
            this.btnPass.Visible = false;
            this.btnPass.Click += new System.EventHandler(this.btnPass_Click);
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
            this.btnSubmit.Location = new System.Drawing.Point(554, 8);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.btnSubmit.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSubmit.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Radius = 6;
            this.btnSubmit.ShowBase = true;
            this.btnSubmit.Size = new System.Drawing.Size(94, 37);
            this.btnSubmit.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnSubmit.SplitDistance = 0;
            this.btnSubmit.TabIndex = 24;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.Title = "";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Visible = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
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
            this.btnSave.Location = new System.Drawing.Point(455, 8);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.btnSave.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnSave.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Radius = 6;
            this.btnSave.ShowBase = true;
            this.btnSave.Size = new System.Drawing.Size(99, 37);
            this.btnSave.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnSave.SplitDistance = 0;
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "保存草稿";
            this.btnSave.Title = "";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDeleteDetail
            // 
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
            this.btnDeleteDetail.Location = new System.Drawing.Point(355, 8);
            this.btnDeleteDetail.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.btnDeleteDetail.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnDeleteDetail.MenuPos = new System.Drawing.Point(0, 0);
            this.btnDeleteDetail.Name = "btnDeleteDetail";
            this.btnDeleteDetail.Radius = 6;
            this.btnDeleteDetail.ShowBase = true;
            this.btnDeleteDetail.Size = new System.Drawing.Size(100, 37);
            this.btnDeleteDetail.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnDeleteDetail.SplitDistance = 0;
            this.btnDeleteDetail.TabIndex = 38;
            this.btnDeleteDetail.Text = "删除明细";
            this.btnDeleteDetail.Title = "";
            this.btnDeleteDetail.UseVisualStyleBackColor = true;
            this.btnDeleteDetail.Visible = false;
            this.btnDeleteDetail.Click += new System.EventHandler(this.btnDeleteDetail_Click);
            // 
            // btnAddDetail
            // 
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
            this.btnAddDetail.Location = new System.Drawing.Point(255, 8);
            this.btnAddDetail.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.btnAddDetail.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAddDetail.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Radius = 6;
            this.btnAddDetail.ShowBase = true;
            this.btnAddDetail.Size = new System.Drawing.Size(100, 37);
            this.btnAddDetail.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnAddDetail.SplitDistance = 0;
            this.btnAddDetail.TabIndex = 38;
            this.btnAddDetail.Text = "添加明细";
            this.btnAddDetail.Title = "";
            this.btnAddDetail.UseVisualStyleBackColor = true;
            this.btnAddDetail.Visible = false;
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            // 
            // btnBdFiles
            // 
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
            this.btnBdFiles.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBdFiles.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnBdFiles.Image = ((System.Drawing.Image)(resources.GetObject("btnBdFiles.Image")));
            this.btnBdFiles.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnBdFiles.ImageOffset = 7;
            this.btnBdFiles.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBdFiles.IsPressed = false;
            this.btnBdFiles.KeepPress = false;
            this.btnBdFiles.Location = new System.Drawing.Point(178, 8);
            this.btnBdFiles.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.btnBdFiles.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnBdFiles.MenuPos = new System.Drawing.Point(0, 0);
            this.btnBdFiles.Name = "btnBdFiles";
            this.btnBdFiles.Radius = 6;
            this.btnBdFiles.ShowBase = true;
            this.btnBdFiles.Size = new System.Drawing.Size(77, 37);
            this.btnBdFiles.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnBdFiles.SplitDistance = 0;
            this.btnBdFiles.TabIndex = 39;
            this.btnBdFiles.Text = "附件";
            this.btnBdFiles.Title = "";
            this.btnBdFiles.UseVisualStyleBackColor = true;
            this.btnBdFiles.Click += new System.EventHandler(this.btnBdFiles_Click);
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
            this.buttonEx6.Size = new System.Drawing.Size(180, 46);
            this.buttonEx6.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx6.SplitDistance = 0;
            this.buttonEx6.TabIndex = 23;
            this.buttonEx6.Text = "物资采购订单";
            this.buttonEx6.Title = "";
            this.buttonEx6.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(1167, 572);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "订单信息";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.label7, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtPURCHASE_ORDER_CODE, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label12, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label8, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtPURCHASE_ORDER_PERSON, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtREMARK, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label11, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.labShip, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.dtpPURCHASE_ORDER_DATE, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtLANDCHECKER, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.ucShipSelect1, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.ucManufacturerSelect1, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.ucCurrencySelect1, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.nudTOTALPRICE, 7, 1);
            this.tableLayoutPanel2.Controls.Add(this.label10, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtCHECKDATE, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtSENDDATE, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.ucPortSelect1, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1147, 538);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(581, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 30);
            this.label7.TabIndex = 56;
            this.label7.Text = "船舶*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(581, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 30);
            this.label2.TabIndex = 51;
            this.label2.Text = "岸端确认日期";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "处理单号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPURCHASE_ORDER_CODE
            // 
            this.txtPURCHASE_ORDER_CODE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPURCHASE_ORDER_CODE.Enabled = false;
            this.txtPURCHASE_ORDER_CODE.Location = new System.Drawing.Point(85, 3);
            this.txtPURCHASE_ORDER_CODE.MaxLength = 50;
            this.txtPURCHASE_ORDER_CODE.Name = "txtPURCHASE_ORDER_CODE";
            this.txtPURCHASE_ORDER_CODE.Size = new System.Drawing.Size(200, 21);
            this.txtPURCHASE_ORDER_CODE.TabIndex = 21;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(882, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 30);
            this.label12.TabIndex = 1;
            this.label12.Text = "总价*";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 30);
            this.label5.TabIndex = 1;
            this.label5.Text = "发起日期*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(882, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 30);
            this.label8.TabIndex = 1;
            this.label8.Text = "货币*";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPURCHASE_ORDER_PERSON
            // 
            this.txtPURCHASE_ORDER_PERSON.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPURCHASE_ORDER_PERSON.Enabled = false;
            this.txtPURCHASE_ORDER_PERSON.Location = new System.Drawing.Point(375, 3);
            this.txtPURCHASE_ORDER_PERSON.MaxLength = 20;
            this.txtPURCHASE_ORDER_PERSON.Name = "txtPURCHASE_ORDER_PERSON";
            this.txtPURCHASE_ORDER_PERSON.Size = new System.Drawing.Size(200, 21);
            this.txtPURCHASE_ORDER_PERSON.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(291, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 30);
            this.label6.TabIndex = 1;
            this.label6.Text = "申请人";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 65);
            this.label4.TabIndex = 1;
            this.label4.Text = "备注";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtREMARK
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtREMARK, 7);
            this.txtREMARK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtREMARK.Enabled = false;
            this.txtREMARK.Location = new System.Drawing.Point(85, 93);
            this.txtREMARK.MaxLength = 1500;
            this.txtREMARK.Multiline = true;
            this.txtREMARK.Name = "txtREMARK";
            this.txtREMARK.Size = new System.Drawing.Size(1059, 59);
            this.txtREMARK.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(581, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 30);
            this.label11.TabIndex = 1;
            this.label11.Text = "供应商*";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 30);
            this.label1.TabIndex = 47;
            this.label1.Text = "送货港口*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labShip
            // 
            this.labShip.AutoSize = true;
            this.labShip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labShip.Location = new System.Drawing.Point(291, 60);
            this.labShip.Name = "labShip";
            this.labShip.Size = new System.Drawing.Size(78, 30);
            this.labShip.TabIndex = 49;
            this.labShip.Text = "岸端审核人";
            this.labShip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpPURCHASE_ORDER_DATE
            // 
            this.dtpPURCHASE_ORDER_DATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpPURCHASE_ORDER_DATE.Enabled = false;
            this.dtpPURCHASE_ORDER_DATE.Location = new System.Drawing.Point(85, 33);
            this.dtpPURCHASE_ORDER_DATE.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dtpPURCHASE_ORDER_DATE.MaxValue = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpPURCHASE_ORDER_DATE.MimValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpPURCHASE_ORDER_DATE.Name = "dtpPURCHASE_ORDER_DATE";
            this.dtpPURCHASE_ORDER_DATE.ReadOnly = false;
            this.dtpPURCHASE_ORDER_DATE.Size = new System.Drawing.Size(200, 27);
            this.dtpPURCHASE_ORDER_DATE.TabIndex = 53;
            this.dtpPURCHASE_ORDER_DATE.Value = new System.DateTime(((long)(0)));
            // 
            // txtLANDCHECKER
            // 
            this.txtLANDCHECKER.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLANDCHECKER.Enabled = false;
            this.txtLANDCHECKER.Location = new System.Drawing.Point(375, 63);
            this.txtLANDCHECKER.MaxLength = 20;
            this.txtLANDCHECKER.Name = "txtLANDCHECKER";
            this.txtLANDCHECKER.Size = new System.Drawing.Size(200, 21);
            this.txtLANDCHECKER.TabIndex = 28;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.groupBox1, 8);
            this.groupBox1.Controls.Add(this.dgvDetail);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1141, 377);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "采购详细";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.AllowUserToOrderColumns = true;
            this.dgvDetail.AutoFit = true;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvDetail.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetail.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetail.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDetail.Enabled = false;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDetail.RowHeadersWidth = 30;
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.ShowRowNumber = true;
            this.dgvDetail.Size = new System.Drawing.Size(1135, 357);
            this.dgvDetail.TabIndex = 54;
            this.dgvDetail.Title = "";
            this.dgvDetail.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetail_CellContentClick);
            // 
            // ucShipSelect1
            // 
            this.ucShipSelect1.CanEdit = false;
            this.ucShipSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucShipSelect1.DropDownWidth = 102;
            this.ucShipSelect1.Enabled = false;
            this.ucShipSelect1.Location = new System.Drawing.Point(676, 3);
            this.ucShipSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipSelect1.Name = "ucShipSelect1";
            this.ucShipSelect1.NullValueShow = "所有船";
            this.ucShipSelect1.ShowButton = true;
            this.ucShipSelect1.Size = new System.Drawing.Size(200, 20);
            this.ucShipSelect1.TabIndex = 60;
            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            // 
            // ucManufacturerSelect1
            // 
            this.ucManufacturerSelect1.CanEdit = true;
            this.ucManufacturerSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucManufacturerSelect1.DropDownWidth = 350;
            this.ucManufacturerSelect1.Enabled = false;
            this.ucManufacturerSelect1.Location = new System.Drawing.Point(676, 33);
            this.ucManufacturerSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucManufacturerSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucManufacturerSelect1.Name = "ucManufacturerSelect1";
            this.ucManufacturerSelect1.NullValueShow = "";
            this.ucManufacturerSelect1.ShowButton = true;
            this.ucManufacturerSelect1.Size = new System.Drawing.Size(200, 20);
            this.ucManufacturerSelect1.TabIndex = 61;
            // 
            // ucCurrencySelect1
            // 
            this.ucCurrencySelect1.CanEdit = false;
            this.ucCurrencySelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCurrencySelect1.DropDownWidth = 132;
            this.ucCurrencySelect1.Enabled = false;
            this.ucCurrencySelect1.Location = new System.Drawing.Point(941, 3);
            this.ucCurrencySelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucCurrencySelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucCurrencySelect1.Name = "ucCurrencySelect1";
            this.ucCurrencySelect1.NullValueShow = "";
            this.ucCurrencySelect1.ShowButton = true;
            this.ucCurrencySelect1.Size = new System.Drawing.Size(203, 20);
            this.ucCurrencySelect1.TabIndex = 62;
            // 
            // nudTOTALPRICE
            // 
            this.nudTOTALPRICE.DecimalPlaces = 2;
            this.nudTOTALPRICE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudTOTALPRICE.Enabled = false;
            this.nudTOTALPRICE.Location = new System.Drawing.Point(941, 33);
            this.nudTOTALPRICE.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.nudTOTALPRICE.Name = "nudTOTALPRICE";
            this.nudTOTALPRICE.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nudTOTALPRICE.Size = new System.Drawing.Size(203, 21);
            this.nudTOTALPRICE.TabIndex = 63;
            this.nudTOTALPRICE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(291, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 30);
            this.label10.TabIndex = 1;
            this.label10.Text = "到货日期";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCHECKDATE
            // 
            this.txtCHECKDATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCHECKDATE.Enabled = false;
            this.txtCHECKDATE.Location = new System.Drawing.Point(676, 63);
            this.txtCHECKDATE.MaxLength = 20;
            this.txtCHECKDATE.Name = "txtCHECKDATE";
            this.txtCHECKDATE.Size = new System.Drawing.Size(200, 21);
            this.txtCHECKDATE.TabIndex = 28;
            // 
            // txtSENDDATE
            // 
            this.txtSENDDATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSENDDATE.Enabled = false;
            this.txtSENDDATE.Location = new System.Drawing.Point(375, 33);
            this.txtSENDDATE.MaxLength = 20;
            this.txtSENDDATE.Name = "txtSENDDATE";
            this.txtSENDDATE.Size = new System.Drawing.Size(200, 21);
            this.txtSENDDATE.TabIndex = 28;
            // 
            // ucPortSelect1
            // 
            this.ucPortSelect1.CanEdit = true;
            this.ucPortSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPortSelect1.DropDownWidth = 107;
            this.ucPortSelect1.Location = new System.Drawing.Point(85, 63);
            this.ucPortSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucPortSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucPortSelect1.Name = "ucPortSelect1";
            this.ucPortSelect1.NullValueShow = "";
            this.ucPortSelect1.ShowButton = true;
            this.ucPortSelect1.Size = new System.Drawing.Size(200, 20);
            this.ucPortSelect1.TabIndex = 68;
            // 
            // FrmMaterialPurchaseOrderEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 628);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel4);
            this.Name = "FrmMaterialPurchaseOrderEdit";
            this.Text = "物资采购订单";
            this.Load += new System.EventHandler(this.FrmMaterialPurchaseOrderEdit_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTOTALPRICE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        protected CommonViewer.ButtonEx btnClose;
        public CommonViewer.ButtonEx btnSubmit;
        public CommonViewer.ButtonEx btnPass;
        public CommonViewer.ButtonEx btnSave;
        public CommonViewer.ButtonEx btnDeleteDetail;
        public CommonViewer.ButtonEx btnAddDetail;
        public CommonViewer.ButtonEx buttonEx6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private CommonViewer.TextBoxEx txtPURCHASE_ORDER_CODE;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private CommonViewer.TextBoxEx txtPURCHASE_ORDER_PERSON;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private CommonViewer.TextBoxEx txtREMARK;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labShip;
        private CommonViewer.DateTimePickerEx dtpPURCHASE_ORDER_DATE;
        private CommonViewer.TextBoxEx txtLANDCHECKER;
        private System.Windows.Forms.GroupBox groupBox1;
        private CommonViewer.UcDataGridView dgvDetail;
        private BaseInfo.Viewer.UcShipSelect ucShipSelect1;
        private System.Windows.Forms.BindingSource bindingSourceDetail;
        private BaseInfo.Viewer.UcManufacturerSelect ucManufacturerSelect1;
        private BaseInfo.Viewer.UcCurrencySelect ucCurrencySelect1;
        private System.Windows.Forms.NumericUpDown nudTOTALPRICE;
        private System.Windows.Forms.Label label10;
        private CommonViewer.TextBoxEx txtCHECKDATE;
        private CommonViewer.TextBoxEx txtSENDDATE;
        private BaseInfo.Viewer.UcPortSelect ucPortSelect1;
        public CommonViewer.ButtonEx btnBdFiles;
        public CommonViewer.ButtonEx btn_Agree;
        public CommonViewer.ButtonEx btn_disgree;

    }
}