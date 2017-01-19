namespace CustomTable.Haifeng.Viewer
{
    partial class FrmDeckMaintain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeckMaintain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtSHUI_SHOU = new CommonViewer.TextBoxEx();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bdNgEditItem = new CommonViewer.ButtonEx();
            this.btnPrint = new CommonViewer.ButtonEx();
            this.buttonEx5 = new CommonViewer.ButtonEx();
            this.AddButton = new CommonViewer.ButtonEx();
            this.deleteButton = new CommonViewer.ButtonEx();
            this.CloseButton = new CommonViewer.ButtonEx();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvMain = new CommonViewer.UcDataGridView(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label19 = new System.Windows.Forms.Label();
            this.txtREPORT_DATE = new CommonViewer.TextBoxEx();
            this.label16 = new System.Windows.Forms.Label();
            this.txtVOYAGE = new CommonViewer.TextBoxEx();
            this.label14 = new System.Windows.Forms.Label();
            this.txtEND_DATE = new CommonViewer.TextBoxEx();
            this.label15 = new System.Windows.Forms.Label();
            this.txtBEGIN_DATE = new CommonViewer.TextBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAIR_LINE = new CommonViewer.TextBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUNDONE_PROJECT = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTEMPORARY_PROJECT = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPROBLEM = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtVERIFY_SUGGESTION = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCHUAN_ZHANG = new CommonViewer.TextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDA_FU = new CommonViewer.TextBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.txtER_FU = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSAN_FU = new CommonViewer.TextBoxEx();
            this.label17 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMU_JIANG = new CommonViewer.TextBoxEx();
            this.dgvDetail = new CommonViewer.UcDataGridView(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.label7 = new System.Windows.Forms.Label();
            this.dateYear = new System.Windows.Forms.DateTimePicker();
            this.labyear = new System.Windows.Forms.Label();
            this.folderBD = new System.Windows.Forms.FolderBrowserDialog();
            this.bindingSourceMain = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSHUI_SHOU
            // 
            this.txtSHUI_SHOU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSHUI_SHOU.Location = new System.Drawing.Point(330, 513);
            this.txtSHUI_SHOU.MaxLength = 100;
            this.txtSHUI_SHOU.Name = "txtSHUI_SHOU";
            this.txtSHUI_SHOU.ReadOnly = true;
            this.txtSHUI_SHOU.Size = new System.Drawing.Size(121, 21);
            this.txtSHUI_SHOU.TabIndex = 82;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 668);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.bdNgEditItem);
            this.panel3.Controls.Add(this.btnPrint);
            this.panel3.Controls.Add(this.buttonEx5);
            this.panel3.Controls.Add(this.AddButton);
            this.panel3.Controls.Add(this.deleteButton);
            this.panel3.Controls.Add(this.CloseButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 50);
            this.panel3.TabIndex = 50;
            // 
            // bdNgEditItem
            // 
            this.bdNgEditItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bdNgEditItem.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.bdNgEditItem.BackColor = System.Drawing.Color.Transparent;
            this.bdNgEditItem.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.bdNgEditItem.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.bdNgEditItem.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.bdNgEditItem.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.bdNgEditItem.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bdNgEditItem.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bdNgEditItem.FadingSpeed = 20;
            this.bdNgEditItem.FlatAppearance.BorderSize = 0;
            this.bdNgEditItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bdNgEditItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bdNgEditItem.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.bdNgEditItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgEditItem.Image")));
            this.bdNgEditItem.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgEditItem.ImageOffset = 3;
            this.bdNgEditItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bdNgEditItem.IsPressed = false;
            this.bdNgEditItem.KeepPress = false;
            this.bdNgEditItem.Location = new System.Drawing.Point(581, 3);
            this.bdNgEditItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgEditItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgEditItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgEditItem.Name = "bdNgEditItem";
            this.bdNgEditItem.Radius = 6;
            this.bdNgEditItem.ShowBase = true;
            this.bdNgEditItem.Size = new System.Drawing.Size(81, 44);
            this.bdNgEditItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgEditItem.SplitDistance = 0;
            this.bdNgEditItem.TabIndex = 40;
            this.bdNgEditItem.Text = "编辑";
            this.bdNgEditItem.Title = "";
            this.bdNgEditItem.UseVisualStyleBackColor = true;
            this.bdNgEditItem.Click += new System.EventHandler(this.bdNgEditItem_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnPrint.ImageOffset = 5;
            this.btnPrint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPrint.IsPressed = false;
            this.btnPrint.KeepPress = false;
            this.btnPrint.Location = new System.Drawing.Point(827, 3);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(0);
            this.btnPrint.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnPrint.MenuPos = new System.Drawing.Point(0, 0);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Radius = 6;
            this.btnPrint.ShowBase = true;
            this.btnPrint.Size = new System.Drawing.Size(98, 44);
            this.btnPrint.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnPrint.SplitDistance = 0;
            this.btnPrint.TabIndex = 39;
            this.btnPrint.Text = "导出报表";
            this.btnPrint.Title = "";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.buttonEx5.Location = new System.Drawing.Point(3, 5);
            this.buttonEx5.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx5.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx5.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx5.Name = "buttonEx5";
            this.buttonEx5.Radius = 6;
            this.buttonEx5.ShowBase = false;
            this.buttonEx5.Size = new System.Drawing.Size(301, 41);
            this.buttonEx5.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx5.SplitDistance = 0;
            this.buttonEx5.TabIndex = 25;
            this.buttonEx5.Text = "甲板部维修保养月度报告";
            this.buttonEx5.Title = "";
            this.buttonEx5.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.AddButton.BackColor = System.Drawing.Color.Transparent;
            this.AddButton.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.AddButton.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.AddButton.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.AddButton.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.AddButton.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.AddButton.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.AddButton.FadingSpeed = 20;
            this.AddButton.FlatAppearance.BorderSize = 0;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.Font = new System.Drawing.Font("宋体", 9F);
            this.AddButton.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.AddButton.Image = ((System.Drawing.Image)(resources.GetObject("AddButton.Image")));
            this.AddButton.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.AddButton.ImageOffset = 3;
            this.AddButton.IsPressed = false;
            this.AddButton.KeepPress = false;
            this.AddButton.Location = new System.Drawing.Point(663, 3);
            this.AddButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.AddButton.MenuPos = new System.Drawing.Point(0, 0);
            this.AddButton.Name = "AddButton";
            this.AddButton.Radius = 6;
            this.AddButton.ShowBase = true;
            this.AddButton.Size = new System.Drawing.Size(81, 44);
            this.AddButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.AddButton.SplitDistance = 0;
            this.AddButton.TabIndex = 22;
            this.AddButton.Text = "添加";
            this.AddButton.Title = "";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.bdNgAddNewItem_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.deleteButton.BackColor = System.Drawing.Color.Transparent;
            this.deleteButton.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.deleteButton.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.deleteButton.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.deleteButton.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.deleteButton.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.deleteButton.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.deleteButton.FadingSpeed = 20;
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("宋体", 9F);
            this.deleteButton.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.deleteButton.ImageOffset = 3;
            this.deleteButton.IsPressed = false;
            this.deleteButton.KeepPress = false;
            this.deleteButton.Location = new System.Drawing.Point(745, 3);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(0);
            this.deleteButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.deleteButton.MenuPos = new System.Drawing.Point(0, 0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Radius = 6;
            this.deleteButton.ShowBase = true;
            this.deleteButton.Size = new System.Drawing.Size(81, 44);
            this.deleteButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.deleteButton.SplitDistance = 0;
            this.deleteButton.TabIndex = 23;
            this.deleteButton.Text = "删除";
            this.deleteButton.Title = "";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.bdNgDeleteItem_Click);
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
            this.CloseButton.Location = new System.Drawing.Point(926, 3);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.CloseButton.MenuPos = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Radius = 6;
            this.CloseButton.ShowBase = true;
            this.CloseButton.Size = new System.Drawing.Size(81, 44);
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
            this.splitContainer1.Location = new System.Drawing.Point(3, 103);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(1002, 562);
            this.splitContainer1.SplitterDistance = 309;
            this.splitContainer1.TabIndex = 49;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvMain);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 562);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "甲板部维修保养月度报告列表";
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.AllowUserToOrderColumns = true;
            this.dgvMain.AutoFit = true;
            this.dgvMain.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvMain.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMain.EnableHeadersVisualStyles = false;
            this.dgvMain.ExportColorToExcel = false;
            this.dgvMain.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvMain.Footer")));
            this.dgvMain.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvMain.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvMain.Header")));
            this.dgvMain.LoadedFinish = false;
            this.dgvMain.Location = new System.Drawing.Point(3, 17);
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
            this.dgvMain.ShowRowNumber = true;
            this.dgvMain.Size = new System.Drawing.Size(303, 542);
            this.dgvMain.TabIndex = 0;
            this.dgvMain.Title = "";
            this.dgvMain.CurrentCellChanged += new System.EventHandler(this.dgvMain_CurrentCellChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(689, 562);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "甲板部维修保养月度报告信息";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(683, 542);
            this.panel2.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.label19, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtREPORT_DATE, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label16, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtVOYAGE, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label14, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtEND_DATE, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label15, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtBEGIN_DATE, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtAIR_LINE, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtUNDONE_PROJECT, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.label9, 4, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtTEMPORARY_PROJECT, 4, 6);
            this.tableLayoutPanel2.Controls.Add(this.label8, 4, 8);
            this.tableLayoutPanel2.Controls.Add(this.txtPROBLEM, 4, 9);
            this.tableLayoutPanel2.Controls.Add(this.label10, 4, 11);
            this.tableLayoutPanel2.Controls.Add(this.txtVERIFY_SUGGESTION, 4, 12);
            this.tableLayoutPanel2.Controls.Add(this.label18, 0, 14);
            this.tableLayoutPanel2.Controls.Add(this.txtCHUAN_ZHANG, 1, 14);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 14);
            this.tableLayoutPanel2.Controls.Add(this.txtDA_FU, 3, 14);
            this.tableLayoutPanel2.Controls.Add(this.label2, 4, 14);
            this.tableLayoutPanel2.Controls.Add(this.txtER_FU, 5, 14);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 15);
            this.tableLayoutPanel2.Controls.Add(this.txtSAN_FU, 1, 15);
            this.tableLayoutPanel2.Controls.Add(this.label17, 2, 15);
            this.tableLayoutPanel2.Controls.Add(this.txtSHUI_SHOU, 3, 15);
            this.tableLayoutPanel2.Controls.Add(this.label4, 4, 15);
            this.tableLayoutPanel2.Controls.Add(this.txtMU_JIANG, 5, 15);
            this.tableLayoutPanel2.Controls.Add(this.dgvDetail, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 17;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(683, 542);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(230, 26);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(94, 26);
            this.label19.TabIndex = 77;
            this.label19.Text = "结束日期";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtREPORT_DATE
            // 
            this.txtREPORT_DATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtREPORT_DATE.Location = new System.Drawing.Point(330, 3);
            this.txtREPORT_DATE.MaxLength = 10;
            this.txtREPORT_DATE.Name = "txtREPORT_DATE";
            this.txtREPORT_DATE.ReadOnly = true;
            this.txtREPORT_DATE.Size = new System.Drawing.Size(121, 21);
            this.txtREPORT_DATE.TabIndex = 74;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(230, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(94, 26);
            this.label16.TabIndex = 73;
            this.label16.Text = "日期";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVOYAGE
            // 
            this.txtVOYAGE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVOYAGE.Location = new System.Drawing.Point(103, 3);
            this.txtVOYAGE.MaxLength = 10;
            this.txtVOYAGE.Name = "txtVOYAGE";
            this.txtVOYAGE.ReadOnly = true;
            this.txtVOYAGE.Size = new System.Drawing.Size(121, 21);
            this.txtVOYAGE.TabIndex = 72;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 26);
            this.label14.TabIndex = 71;
            this.label14.Text = "航次";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEND_DATE
            // 
            this.txtEND_DATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEND_DATE.Location = new System.Drawing.Point(330, 29);
            this.txtEND_DATE.Name = "txtEND_DATE";
            this.txtEND_DATE.ReadOnly = true;
            this.txtEND_DATE.Size = new System.Drawing.Size(121, 21);
            this.txtEND_DATE.TabIndex = 83;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(3, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 26);
            this.label15.TabIndex = 75;
            this.label15.Text = "开始日期";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBEGIN_DATE
            // 
            this.txtBEGIN_DATE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBEGIN_DATE.Location = new System.Drawing.Point(103, 29);
            this.txtBEGIN_DATE.MaxLength = 10;
            this.txtBEGIN_DATE.Name = "txtBEGIN_DATE";
            this.txtBEGIN_DATE.ReadOnly = true;
            this.txtBEGIN_DATE.Size = new System.Drawing.Size(121, 21);
            this.txtBEGIN_DATE.TabIndex = 76;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(457, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 26);
            this.label5.TabIndex = 79;
            this.label5.Text = "航线";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAIR_LINE
            // 
            this.txtAIR_LINE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAIR_LINE.Location = new System.Drawing.Point(557, 3);
            this.txtAIR_LINE.MaxLength = 10;
            this.txtAIR_LINE.Name = "txtAIR_LINE";
            this.txtAIR_LINE.ReadOnly = true;
            this.txtAIR_LINE.Size = new System.Drawing.Size(123, 21);
            this.txtAIR_LINE.TabIndex = 74;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label6, 2);
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(457, 55);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(223, 30);
            this.label6.TabIndex = 86;
            this.label6.Text = "月度维护保养计划，未完成项目，何原因，预计何时完成？";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUNDONE_PROJECT
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtUNDONE_PROJECT, 2);
            this.txtUNDONE_PROJECT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUNDONE_PROJECT.Location = new System.Drawing.Point(457, 91);
            this.txtUNDONE_PROJECT.Multiline = true;
            this.txtUNDONE_PROJECT.Name = "txtUNDONE_PROJECT";
            this.txtUNDONE_PROJECT.ReadOnly = true;
            this.tableLayoutPanel2.SetRowSpan(this.txtUNDONE_PROJECT, 2);
            this.txtUNDONE_PROJECT.Size = new System.Drawing.Size(223, 66);
            this.txtUNDONE_PROJECT.TabIndex = 91;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label9, 2);
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(457, 163);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(223, 30);
            this.label9.TabIndex = 86;
            this.label9.Text = "临修的工程及原因，修理费及影响营运的时间多少？";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTEMPORARY_PROJECT
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtTEMPORARY_PROJECT, 2);
            this.txtTEMPORARY_PROJECT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTEMPORARY_PROJECT.Location = new System.Drawing.Point(457, 199);
            this.txtTEMPORARY_PROJECT.Multiline = true;
            this.txtTEMPORARY_PROJECT.Name = "txtTEMPORARY_PROJECT";
            this.txtTEMPORARY_PROJECT.ReadOnly = true;
            this.tableLayoutPanel2.SetRowSpan(this.txtTEMPORARY_PROJECT, 2);
            this.txtTEMPORARY_PROJECT.Size = new System.Drawing.Size(223, 66);
            this.txtTEMPORARY_PROJECT.TabIndex = 91;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label8, 2);
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(457, 268);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(223, 36);
            this.label8.TabIndex = 86;
            this.label8.Text = "现存在的疑难问题及合理化建议（包括技术革新项目）";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPROBLEM
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtPROBLEM, 2);
            this.txtPROBLEM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPROBLEM.Location = new System.Drawing.Point(457, 307);
            this.txtPROBLEM.Multiline = true;
            this.txtPROBLEM.Name = "txtPROBLEM";
            this.txtPROBLEM.ReadOnly = true;
            this.tableLayoutPanel2.SetRowSpan(this.txtPROBLEM, 2);
            this.txtPROBLEM.Size = new System.Drawing.Size(223, 66);
            this.txtPROBLEM.TabIndex = 91;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label10, 2);
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(457, 376);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(223, 36);
            this.label10.TabIndex = 86;
            this.label10.Text = "机务主管审核意见：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtVERIFY_SUGGESTION
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtVERIFY_SUGGESTION, 2);
            this.txtVERIFY_SUGGESTION.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtVERIFY_SUGGESTION.Location = new System.Drawing.Point(457, 415);
            this.txtVERIFY_SUGGESTION.Multiline = true;
            this.txtVERIFY_SUGGESTION.Name = "txtVERIFY_SUGGESTION";
            this.txtVERIFY_SUGGESTION.ReadOnly = true;
            this.tableLayoutPanel2.SetRowSpan(this.txtVERIFY_SUGGESTION, 2);
            this.txtVERIFY_SUGGESTION.Size = new System.Drawing.Size(223, 66);
            this.txtVERIFY_SUGGESTION.TabIndex = 91;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(3, 484);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(94, 26);
            this.label18.TabIndex = 79;
            this.label18.Text = "船长";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCHUAN_ZHANG
            // 
            this.txtCHUAN_ZHANG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCHUAN_ZHANG.Location = new System.Drawing.Point(103, 487);
            this.txtCHUAN_ZHANG.Name = "txtCHUAN_ZHANG";
            this.txtCHUAN_ZHANG.ReadOnly = true;
            this.txtCHUAN_ZHANG.Size = new System.Drawing.Size(121, 21);
            this.txtCHUAN_ZHANG.TabIndex = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(230, 484);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 26);
            this.label1.TabIndex = 84;
            this.label1.Text = "大副";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDA_FU
            // 
            this.txtDA_FU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDA_FU.Location = new System.Drawing.Point(330, 487);
            this.txtDA_FU.Name = "txtDA_FU";
            this.txtDA_FU.ReadOnly = true;
            this.txtDA_FU.Size = new System.Drawing.Size(121, 21);
            this.txtDA_FU.TabIndex = 87;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(457, 484);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 26);
            this.label2.TabIndex = 85;
            this.label2.Text = "二副";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtER_FU
            // 
            this.txtER_FU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtER_FU.Location = new System.Drawing.Point(557, 487);
            this.txtER_FU.Name = "txtER_FU";
            this.txtER_FU.ReadOnly = true;
            this.txtER_FU.Size = new System.Drawing.Size(123, 21);
            this.txtER_FU.TabIndex = 92;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 510);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 26);
            this.label3.TabIndex = 86;
            this.label3.Text = "三副";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSAN_FU
            // 
            this.txtSAN_FU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSAN_FU.Location = new System.Drawing.Point(103, 513);
            this.txtSAN_FU.Name = "txtSAN_FU";
            this.txtSAN_FU.ReadOnly = true;
            this.txtSAN_FU.Size = new System.Drawing.Size(121, 21);
            this.txtSAN_FU.TabIndex = 89;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(230, 510);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 26);
            this.label17.TabIndex = 81;
            this.label17.Text = "水手长";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(457, 510);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 26);
            this.label4.TabIndex = 90;
            this.label4.Text = "木匠";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMU_JIANG
            // 
            this.txtMU_JIANG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMU_JIANG.Location = new System.Drawing.Point(557, 513);
            this.txtMU_JIANG.MaxLength = 10;
            this.txtMU_JIANG.Name = "txtMU_JIANG";
            this.txtMU_JIANG.ReadOnly = true;
            this.txtMU_JIANG.Size = new System.Drawing.Size(123, 21);
            this.txtMU_JIANG.TabIndex = 72;
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.AllowUserToOrderColumns = true;
            this.dgvDetail.AutoFit = true;
            this.dgvDetail.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvDetail.ColumnDeep = 1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tableLayoutPanel2.SetColumnSpan(this.dgvDetail, 4);
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
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
            this.dgvDetail.Location = new System.Drawing.Point(15, 55);
            this.dgvDetail.Margin = new System.Windows.Forms.Padding(15, 3, 3, 3);
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
            this.tableLayoutPanel2.SetRowSpan(this.dgvDetail, 12);
            this.dgvDetail.RowTemplate.Height = 23;
            this.dgvDetail.ShowRowNumber = true;
            this.dgvDetail.Size = new System.Drawing.Size(436, 426);
            this.dgvDetail.TabIndex = 93;
            this.dgvDetail.Title = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ucShipSelect1);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.dateYear);
            this.groupBox3.Controls.Add(this.labyear);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 53);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1002, 44);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询";
            // 
            // ucShipSelect1
            // 
            this.ucShipSelect1.CanEdit = false;
            this.ucShipSelect1.DropDownWidth = 102;
            this.ucShipSelect1.Location = new System.Drawing.Point(47, 18);
            this.ucShipSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipSelect1.Name = "ucShipSelect1";
            this.ucShipSelect1.NullValueShow = "所有船";
            this.ucShipSelect1.ShowButton = true;
            this.ucShipSelect1.Size = new System.Drawing.Size(102, 20);
            this.ucShipSelect1.TabIndex = 37;
            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(9, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 18);
            this.label7.TabIndex = 36;
            this.label7.Text = "船舶";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateYear
            // 
            this.dateYear.CustomFormat = "yyyy";
            this.dateYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateYear.Location = new System.Drawing.Point(211, 17);
            this.dateYear.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateYear.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dateYear.Name = "dateYear";
            this.dateYear.ShowUpDown = true;
            this.dateYear.Size = new System.Drawing.Size(60, 21);
            this.dateYear.TabIndex = 35;
            this.dateYear.ValueChanged += new System.EventHandler(this.dateYear_ValueChanged);
            // 
            // labyear
            // 
            this.labyear.AutoSize = true;
            this.labyear.Location = new System.Drawing.Point(164, 21);
            this.labyear.Name = "labyear";
            this.labyear.Size = new System.Drawing.Size(41, 12);
            this.labyear.TabIndex = 34;
            this.labyear.Text = "发生年";
            // 
            // FrmDeckMaintain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 668);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmDeckMaintain";
            this.Text = "甲板部维修保养月度报告";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDeckMaintain_FormClosing);
            this.Load += new System.EventHandler(this.FrmDeckMaintain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CommonViewer.TextBoxEx txtSHUI_SHOU;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        public CommonViewer.ButtonEx bdNgEditItem;
        public CommonViewer.ButtonEx btnPrint;
        private CommonViewer.ButtonEx buttonEx5;
        private CommonViewer.ButtonEx AddButton;
        private CommonViewer.ButtonEx deleteButton;
        private CommonViewer.ButtonEx CloseButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label17;
        private CommonViewer.TextBoxEx txtCHUAN_ZHANG;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private CommonViewer.TextBoxEx txtBEGIN_DATE;
        private System.Windows.Forms.Label label15;
        private CommonViewer.TextBoxEx txtREPORT_DATE;
        private System.Windows.Forms.Label label16;
        private CommonViewer.TextBoxEx txtVOYAGE;
        private System.Windows.Forms.Label label14;
        private CommonViewer.TextBoxEx txtEND_DATE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private CommonViewer.TextBoxEx txtDA_FU;
        private CommonViewer.TextBoxEx txtSAN_FU;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateYear;
        private System.Windows.Forms.Label labyear;
        private System.Windows.Forms.BindingSource bindingSourceMain;
        private System.Windows.Forms.FolderBrowserDialog folderBD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUNDONE_PROJECT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPROBLEM;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTEMPORARY_PROJECT;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtVERIFY_SUGGESTION;
        private CommonViewer.TextBoxEx txtMU_JIANG;
        private System.Windows.Forms.TextBox txtER_FU;
        private BaseInfo.Viewer.UcShipSelect ucShipSelect1;
        private CommonViewer.UcDataGridView dgvMain;
        private System.Windows.Forms.Label label5;
        private CommonViewer.TextBoxEx txtAIR_LINE;
        private CommonViewer.UcDataGridView dgvDetail;
    }
}