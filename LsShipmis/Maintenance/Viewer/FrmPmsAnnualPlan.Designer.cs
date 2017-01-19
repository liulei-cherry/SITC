namespace Maintenance.Viewer
{
    partial class FrmPmsAnnualPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPmsAnnualPlan));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("编码");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("工单名称");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("岗位名称");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("工作内容");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("一月");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("二月");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("三月");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("四月");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("五月");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("六月");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("七月");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("八月");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("九月");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("十月");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("十一月");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("十二月");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("月份", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgv = new CommonViewer.UcDataGridView(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnExportToExcel = new CommonViewer.ButtonEx();
            this.buttonEx5 = new CommonViewer.ButtonEx();
            this.CloseButton = new CommonViewer.ButtonEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboDepartMent = new System.Windows.Forms.ComboBox();
            this.cboyear = new System.Windows.Forms.ComboBox();
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labyear = new System.Windows.Forms.Label();
            this.workorderid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workinfocode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workinfodetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plandate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.completedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.executor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.completeinfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bdDgvSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdDgvSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgv, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1124, 550);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToOrderColumns = true;
            this.dgv.AutoFit = true;
            this.dgv.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgv.ColumnDeep = 2;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeight = 46;
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
            treeNode1.Name = "workinfocode";
            treeNode1.Text = "编码";
            treeNode2.Name = "workname";
            treeNode2.Text = "工单名称";
            treeNode2.ToolTipText = "工单名称";
            treeNode3.Name = "HEADSHIP_NAME";
            treeNode3.Text = "岗位名称";
            treeNode4.Name = "WORKINFODETAIL";
            treeNode4.Text = "工作内容";
            treeNode4.ToolTipText = "工作内容";
            treeNode5.Name = "1";
            treeNode5.Text = "一月";
            treeNode6.Name = "2";
            treeNode6.Text = "二月";
            treeNode7.Name = "3";
            treeNode7.Text = "三月";
            treeNode8.Name = "4";
            treeNode8.Text = "四月";
            treeNode9.Name = "5";
            treeNode9.Text = "五月";
            treeNode10.Name = "6";
            treeNode10.Text = "六月";
            treeNode11.Name = "7";
            treeNode11.Text = "七月";
            treeNode12.Name = "8";
            treeNode12.Text = "八月";
            treeNode13.Name = "9";
            treeNode13.Text = "九月";
            treeNode14.Name = "10";
            treeNode14.Text = "十月";
            treeNode15.Name = "11";
            treeNode15.Text = "十一月";
            treeNode16.Name = "12";
            treeNode16.Text = "十二月";
            treeNode17.Name = "nodeChangeName";
            treeNode17.Text = "月份";
            this.dgv.HeadSource.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode17});
            this.dgv.LoadedFinish = false;
            this.dgv.Location = new System.Drawing.Point(3, 103);
            this.dgv.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv.MergeColumnNames")));
            this.dgv.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv.MergeRowColumn")));
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.RowHeadersWidth = 30;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.ShowRowNumber = true;
            this.dgv.Size = new System.Drawing.Size(1118, 444);
            this.dgv.TabIndex = 1;
            this.dgv.Title = "";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.BtnExportToExcel);
            this.panel3.Controls.Add(this.buttonEx5);
            this.panel3.Controls.Add(this.CloseButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1124, 50);
            this.panel3.TabIndex = 53;
            // 
            // BtnExportToExcel
            // 
            this.BtnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExportToExcel.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.BtnExportToExcel.BackColor = System.Drawing.Color.Transparent;
            this.BtnExportToExcel.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.BtnExportToExcel.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.BtnExportToExcel.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.BtnExportToExcel.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.BtnExportToExcel.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BtnExportToExcel.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.BtnExportToExcel.FadingSpeed = 20;
            this.BtnExportToExcel.FlatAppearance.BorderSize = 0;
            this.BtnExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExportToExcel.Font = new System.Drawing.Font("宋体", 9F);
            this.BtnExportToExcel.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.BtnExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("BtnExportToExcel.Image")));
            this.BtnExportToExcel.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.BtnExportToExcel.ImageOffset = 5;
            this.BtnExportToExcel.IsPressed = false;
            this.BtnExportToExcel.KeepPress = false;
            this.BtnExportToExcel.Location = new System.Drawing.Point(886, 5);
            this.BtnExportToExcel.Margin = new System.Windows.Forms.Padding(0);
            this.BtnExportToExcel.MaxImageSize = new System.Drawing.Point(0, 0);
            this.BtnExportToExcel.MenuPos = new System.Drawing.Point(0, 0);
            this.BtnExportToExcel.Name = "BtnExportToExcel";
            this.BtnExportToExcel.Radius = 6;
            this.BtnExportToExcel.ShowBase = true;
            this.BtnExportToExcel.Size = new System.Drawing.Size(149, 41);
            this.BtnExportToExcel.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.BtnExportToExcel.SplitDistance = 0;
            this.BtnExportToExcel.TabIndex = 26;
            this.BtnExportToExcel.Text = "维护保养年度计划";
            this.BtnExportToExcel.Title = "导出全部";
            this.BtnExportToExcel.UseVisualStyleBackColor = true;
            this.BtnExportToExcel.Click += new System.EventHandler(this.BtnExportToExcel_Click);
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
            this.buttonEx5.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.buttonEx5.Size = new System.Drawing.Size(273, 41);
            this.buttonEx5.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx5.SplitDistance = 0;
            this.buttonEx5.TabIndex = 25;
            this.buttonEx5.Text = "维护保养年度计划";
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
            this.CloseButton.Location = new System.Drawing.Point(1035, 5);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.CloseButton.MenuPos = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Radius = 6;
            this.CloseButton.ShowBase = true;
            this.CloseButton.Size = new System.Drawing.Size(80, 41);
            this.CloseButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.CloseButton.SplitDistance = 0;
            this.CloseButton.TabIndex = 21;
            this.CloseButton.Text = "关闭";
            this.CloseButton.Title = "";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboDepartMent);
            this.groupBox1.Controls.Add(this.cboyear);
            this.groupBox1.Controls.Add(this.ucShipSelect1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.labyear);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1118, 44);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // cboDepartMent
            // 
            this.cboDepartMent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartMent.FormattingEnabled = true;
            this.cboDepartMent.Location = new System.Drawing.Point(216, 19);
            this.cboDepartMent.Name = "cboDepartMent";
            this.cboDepartMent.Size = new System.Drawing.Size(121, 20);
            this.cboDepartMent.TabIndex = 29;
            this.cboDepartMent.SelectedValueChanged += new System.EventHandler(this.cboDepartMent_SelectedValueChanged);
            // 
            // cboyear
            // 
            this.cboyear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboyear.FormattingEnabled = true;
            this.cboyear.Location = new System.Drawing.Point(387, 18);
            this.cboyear.Name = "cboyear";
            this.cboyear.Size = new System.Drawing.Size(63, 20);
            this.cboyear.TabIndex = 13;
            this.cboyear.SelectedValueChanged += new System.EventHandler(this.cboyear_SelectedValueChanged);
            // 
            // ucShipSelect1
            // 
            this.ucShipSelect1.CanEdit = false;
            this.ucShipSelect1.DropDownWidth = 98;
            this.ucShipSelect1.Location = new System.Drawing.Point(53, 18);
            this.ucShipSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipSelect1.Name = "ucShipSelect1";
            this.ucShipSelect1.NullValueShow = "";
            this.ucShipSelect1.ShowButton = false;
            this.ucShipSelect1.Size = new System.Drawing.Size(100, 20);
            this.ucShipSelect1.TabIndex = 28;
            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(18, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "船舶";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(181, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "部门";
            // 
            // labyear
            // 
            this.labyear.AutoSize = true;
            this.labyear.Location = new System.Drawing.Point(456, 22);
            this.labyear.Name = "labyear";
            this.labyear.Size = new System.Drawing.Size(17, 12);
            this.labyear.TabIndex = 15;
            this.labyear.Text = "年";
            // 
            // workorderid
            // 
            this.workorderid.HeaderText = "workorderid";
            this.workorderid.Name = "workorderid";
            this.workorderid.Visible = false;
            // 
            // workinfocode
            // 
            this.workinfocode.HeaderText = "项目";
            this.workinfocode.Name = "workinfocode";
            this.workinfocode.Width = 60;
            // 
            // workinfodetail
            // 
            this.workinfodetail.HeaderText = "检修内容";
            this.workinfodetail.Name = "workinfodetail";
            this.workinfodetail.Width = 300;
            // 
            // plandate
            // 
            this.plandate.HeaderText = "本月计划检修日期";
            this.plandate.Name = "plandate";
            this.plandate.Width = 120;
            // 
            // completedate
            // 
            this.completedate.HeaderText = "实际完成时间";
            this.completedate.Name = "completedate";
            // 
            // executor
            // 
            this.executor.HeaderText = "检修负责人";
            this.executor.Name = "executor";
            this.executor.Width = 80;
            // 
            // completeinfo
            // 
            this.completeinfo.HeaderText = "检修情况及存在问题";
            this.completeinfo.Name = "completeinfo";
            this.completeinfo.Width = 400;
            // 
            // FrmPmsAnnualPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 550);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmPmsAnnualPlan";
            this.Text = "维护保养年度计划";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPmsAnnualPlan_FormClosing);
            this.Load += new System.EventHandler(this.FrmPmsAnnualPlan_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdDgvSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CommonViewer.UcDataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn workorderid;
        private System.Windows.Forms.DataGridViewTextBoxColumn workinfocode;
        private System.Windows.Forms.DataGridViewTextBoxColumn workinfodetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn plandate;
        private System.Windows.Forms.DataGridViewTextBoxColumn completedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn executor;
        private System.Windows.Forms.DataGridViewTextBoxColumn completeinfo;
        private System.Windows.Forms.Panel panel3;
        private CommonViewer.ButtonEx buttonEx5;
        private CommonViewer.ButtonEx CloseButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboyear;
        private BaseInfo.Viewer.UcShipSelect ucShipSelect1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labyear;
        private CommonViewer.ButtonEx BtnExportToExcel;
        private System.Windows.Forms.ComboBox cboDepartMent;
        private System.Windows.Forms.BindingSource bdDgvSource;
    }
}