using ItemsManage.Viewer;
namespace LSShipMis_Land.SysLs.Forms
 {
    partial class FrmComponentCopy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmComponentCopy));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ucEquipmentClassTreeWithEquipment1 = new ItemsManage.Viewer.UcEquipmentClassTreeWithEquipment();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvWorkInfo = new CommonViewer.UcDataGridView(this.components);
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dtpAnnual = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvWorkOrder = new CommonViewer.UcDataGridView(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CloseButton = new CommonViewer.ButtonEx();
            this.btnAnnualCopy = new CommonViewer.ButtonEx();
            this.btnBdFiles = new CommonViewer.ButtonEx();
            this.btnCompHistory = new CommonViewer.ButtonEx();
            this.buttonEx3 = new CommonViewer.ButtonEx();
            this.btnSpareInfo = new CommonViewer.ButtonEx();
            this.buttonSearch = new CommonViewer.ButtonEx();
            this.buttonEx5 = new CommonViewer.ButtonEx();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkInfo)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrder)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(5, 5);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(988, 657);
            this.splitContainer1.SplitterDistance = 390;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ucEquipmentClassTreeWithEquipment1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 657);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设备信息树";
            // 
            // ucEquipmentClassTreeWithEquipment1
            // 
            this.ucEquipmentClassTreeWithEquipment1.AllowDrop = true;
            this.ucEquipmentClassTreeWithEquipment1.AllowEquipmentClassDragToOtherClass = false;
            this.ucEquipmentClassTreeWithEquipment1.AllowUserDrag = true;
            this.ucEquipmentClassTreeWithEquipment1.AllowUserEdit = false;
            this.ucEquipmentClassTreeWithEquipment1.AllowUserMultiSelect = false;
            this.ucEquipmentClassTreeWithEquipment1.AllowUserSort = true;
            this.ucEquipmentClassTreeWithEquipment1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEquipmentClassTreeWithEquipment1.Font = new System.Drawing.Font("宋体", 12F);
            this.ucEquipmentClassTreeWithEquipment1.ImageIndex = 0;
            this.ucEquipmentClassTreeWithEquipment1.ItemHeight = 22;
            this.ucEquipmentClassTreeWithEquipment1.Location = new System.Drawing.Point(3, 17);
            this.ucEquipmentClassTreeWithEquipment1.Name = "ucEquipmentClassTreeWithEquipment1";
            this.ucEquipmentClassTreeWithEquipment1.OneShipMode = false;
            this.ucEquipmentClassTreeWithEquipment1.OnlyShowNotClassifedEquipment = false;
            this.ucEquipmentClassTreeWithEquipment1.SelectedImageIndex = 0;
            this.ucEquipmentClassTreeWithEquipment1.ShowAllClass = false;
            this.ucEquipmentClassTreeWithEquipment1.ShowEquipment = true;
            this.ucEquipmentClassTreeWithEquipment1.ShowEquipmentHaveSpare = true;
            this.ucEquipmentClassTreeWithEquipment1.ShowNotClassifedEquipment = true;
            this.ucEquipmentClassTreeWithEquipment1.Size = new System.Drawing.Size(384, 637);
            this.ucEquipmentClassTreeWithEquipment1.TabIndex = 1;
            this.ucEquipmentClassTreeWithEquipment1.ItemChanged += new ItemsManage.Viewer.UcEquipmentClassTreeWithEquipment.itemChanged(this.ucEquipmentClassTreeWithEquipment1_ItemChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer2.Panel1.Controls.Add(this.groupBox5);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer2.Size = new System.Drawing.Size(594, 657);
            this.splitContainer2.SplitterDistance = 360;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvWorkInfo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 308);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "年度工作计划列表";
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
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWorkInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWorkInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorkInfo.EnableHeadersVisualStyles = false;
            this.dgvWorkInfo.ExportColorToExcel = false;
            this.dgvWorkInfo.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkInfo.Footer")));
            this.dgvWorkInfo.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvWorkInfo.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkInfo.Header")));
            this.dgvWorkInfo.LoadedFinish = false;
            this.dgvWorkInfo.Location = new System.Drawing.Point(3, 17);
            this.dgvWorkInfo.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkInfo.MergeColumnNames")));
            this.dgvWorkInfo.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkInfo.MergeRowColumn")));
            this.dgvWorkInfo.Name = "dgvWorkInfo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvWorkInfo.RowHeadersWidth = 30;
            this.dgvWorkInfo.RowTemplate.Height = 23;
            this.dgvWorkInfo.ShowRowNumber = true;
            this.dgvWorkInfo.Size = new System.Drawing.Size(588, 288);
            this.dgvWorkInfo.TabIndex = 0;
            this.dgvWorkInfo.Title = "";
            this.dgvWorkInfo.CurrentCellChanged += new System.EventHandler(this.dgvWorkInfo_CurrentCellChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dtpAnnual);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(594, 52);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "查询条件";
            // 
            // dtpAnnual
            // 
            this.dtpAnnual.CustomFormat = "yyyy";
            this.dtpAnnual.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAnnual.Location = new System.Drawing.Point(54, 20);
            this.dtpAnnual.Name = "dtpAnnual";
            this.dtpAnnual.ShowUpDown = true;
            this.dtpAnnual.Size = new System.Drawing.Size(52, 21);
            this.dtpAnnual.TabIndex = 1;
            this.dtpAnnual.ValueChanged += new System.EventHandler(this.dtpAnnual_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "年度";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvWorkOrder);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(594, 293);
            this.groupBox4.TabIndex = 28;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "工单信息列表";
            // 
            // dgvWorkOrder
            // 
            this.dgvWorkOrder.AllowUserToAddRows = false;
            this.dgvWorkOrder.AllowUserToDeleteRows = false;
            this.dgvWorkOrder.AllowUserToOrderColumns = true;
            this.dgvWorkOrder.AutoFit = true;
            this.dgvWorkOrder.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvWorkOrder.ColumnDeep = 1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvWorkOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWorkOrder.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvWorkOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorkOrder.EnableHeadersVisualStyles = false;
            this.dgvWorkOrder.ExportColorToExcel = false;
            this.dgvWorkOrder.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkOrder.Footer")));
            this.dgvWorkOrder.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvWorkOrder.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkOrder.Header")));
            this.dgvWorkOrder.LoadedFinish = false;
            this.dgvWorkOrder.Location = new System.Drawing.Point(3, 17);
            this.dgvWorkOrder.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkOrder.MergeColumnNames")));
            this.dgvWorkOrder.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkOrder.MergeRowColumn")));
            this.dgvWorkOrder.Name = "dgvWorkOrder";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvWorkOrder.RowHeadersWidth = 30;
            this.dgvWorkOrder.RowTemplate.Height = 23;
            this.dgvWorkOrder.ShowRowNumber = true;
            this.dgvWorkOrder.Size = new System.Drawing.Size(588, 273);
            this.dgvWorkOrder.TabIndex = 0;
            this.dgvWorkOrder.Title = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 53);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Controls.Add(this.buttonEx5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 53);
            this.panel3.TabIndex = 51;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.CloseButton);
            this.flowLayoutPanel1.Controls.Add(this.btnAnnualCopy);
            this.flowLayoutPanel1.Controls.Add(this.btnBdFiles);
            this.flowLayoutPanel1.Controls.Add(this.btnCompHistory);
            this.flowLayoutPanel1.Controls.Add(this.buttonEx3);
            this.flowLayoutPanel1.Controls.Add(this.btnSpareInfo);
            this.flowLayoutPanel1.Controls.Add(this.buttonSearch);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(248, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(760, 53);
            this.flowLayoutPanel1.TabIndex = 45;
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
            this.CloseButton.Location = new System.Drawing.Point(709, 2);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.MaxImageSize = new System.Drawing.Point(40, 40);
            this.CloseButton.MenuPos = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Radius = 6;
            this.CloseButton.ShowBase = true;
            this.CloseButton.Size = new System.Drawing.Size(49, 46);
            this.CloseButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.CloseButton.SplitDistance = 0;
            this.CloseButton.TabIndex = 21;
            this.CloseButton.Title = "";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnAnnualCopy
            // 
            this.btnAnnualCopy.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnAnnualCopy.BackColor = System.Drawing.Color.Transparent;
            this.btnAnnualCopy.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnAnnualCopy.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnAnnualCopy.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnAnnualCopy.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnAnnualCopy.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAnnualCopy.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAnnualCopy.FadingSpeed = 20;
            this.btnAnnualCopy.FlatAppearance.BorderSize = 0;
            this.btnAnnualCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnualCopy.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAnnualCopy.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnAnnualCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnAnnualCopy.Image")));
            this.btnAnnualCopy.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnAnnualCopy.ImageOffset = 2;
            this.btnAnnualCopy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAnnualCopy.IsPressed = false;
            this.btnAnnualCopy.KeepPress = false;
            this.btnAnnualCopy.Location = new System.Drawing.Point(591, 2);
            this.btnAnnualCopy.Margin = new System.Windows.Forms.Padding(0);
            this.btnAnnualCopy.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnAnnualCopy.MenuPos = new System.Drawing.Point(0, 0);
            this.btnAnnualCopy.Name = "btnAnnualCopy";
            this.btnAnnualCopy.Radius = 6;
            this.btnAnnualCopy.ShowBase = true;
            this.btnAnnualCopy.Size = new System.Drawing.Size(118, 46);
            this.btnAnnualCopy.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnAnnualCopy.SplitDistance = 0;
            this.btnAnnualCopy.TabIndex = 49;
            this.btnAnnualCopy.Text = "年度复制";
            this.btnAnnualCopy.Title = "";
            this.btnAnnualCopy.UseVisualStyleBackColor = true;
            this.btnAnnualCopy.Click += new System.EventHandler(this.btnAnnualCopy_Click);
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
            this.btnBdFiles.ImageOffset = 4;
            this.btnBdFiles.IsPressed = false;
            this.btnBdFiles.KeepPress = false;
            this.btnBdFiles.Location = new System.Drawing.Point(489, 2);
            this.btnBdFiles.Margin = new System.Windows.Forms.Padding(0);
            this.btnBdFiles.MaxImageSize = new System.Drawing.Point(40, 40);
            this.btnBdFiles.MenuPos = new System.Drawing.Point(0, 0);
            this.btnBdFiles.Name = "btnBdFiles";
            this.btnBdFiles.Radius = 6;
            this.btnBdFiles.ShowBase = true;
            this.btnBdFiles.Size = new System.Drawing.Size(102, 46);
            this.btnBdFiles.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnBdFiles.SplitDistance = 0;
            this.btnBdFiles.TabIndex = 43;
            this.btnBdFiles.Text = "电子资料";
            this.btnBdFiles.Title = "";
            this.btnBdFiles.UseVisualStyleBackColor = true;
            this.btnBdFiles.Visible = false;
            this.btnBdFiles.Click += new System.EventHandler(this.btnBdFiles_Click);
            // 
            // btnCompHistory
            // 
            this.btnCompHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompHistory.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnCompHistory.BackColor = System.Drawing.Color.Transparent;
            this.btnCompHistory.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnCompHistory.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnCompHistory.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnCompHistory.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnCompHistory.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCompHistory.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCompHistory.FadingSpeed = 20;
            this.btnCompHistory.FlatAppearance.BorderSize = 0;
            this.btnCompHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompHistory.Font = new System.Drawing.Font("宋体", 9F);
            this.btnCompHistory.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnCompHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnCompHistory.Image")));
            this.btnCompHistory.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnCompHistory.ImageOffset = 1;
            this.btnCompHistory.IsPressed = false;
            this.btnCompHistory.KeepPress = false;
            this.btnCompHistory.Location = new System.Drawing.Point(384, 2);
            this.btnCompHistory.Margin = new System.Windows.Forms.Padding(0);
            this.btnCompHistory.MaxImageSize = new System.Drawing.Point(40, 40);
            this.btnCompHistory.MenuPos = new System.Drawing.Point(0, 0);
            this.btnCompHistory.Name = "btnCompHistory";
            this.btnCompHistory.Radius = 6;
            this.btnCompHistory.ShowBase = true;
            this.btnCompHistory.Size = new System.Drawing.Size(105, 46);
            this.btnCompHistory.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnCompHistory.SplitDistance = 0;
            this.btnCompHistory.TabIndex = 44;
            this.btnCompHistory.Text = "保养历史";
            this.btnCompHistory.Title = "";
            this.btnCompHistory.UseVisualStyleBackColor = true;
            this.btnCompHistory.Visible = false;
            this.btnCompHistory.Click += new System.EventHandler(this.btnCompHistory_Click);
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
            this.buttonEx3.Font = new System.Drawing.Font("宋体", 9F);
            this.buttonEx3.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx3.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx3.Image")));
            this.buttonEx3.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx3.ImageOffset = 0;
            this.buttonEx3.IsPressed = false;
            this.buttonEx3.KeepPress = false;
            this.buttonEx3.Location = new System.Drawing.Point(287, 2);
            this.buttonEx3.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx3.MaxImageSize = new System.Drawing.Point(40, 40);
            this.buttonEx3.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx3.Name = "buttonEx3";
            this.buttonEx3.Radius = 6;
            this.buttonEx3.ShowBase = true;
            this.buttonEx3.Size = new System.Drawing.Size(97, 46);
            this.buttonEx3.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx3.SplitDistance = 0;
            this.buttonEx3.TabIndex = 47;
            this.buttonEx3.Text = "操作说明";
            this.buttonEx3.Title = "";
            this.buttonEx3.UseVisualStyleBackColor = true;
            this.buttonEx3.Visible = false;
            this.buttonEx3.Click += new System.EventHandler(this.buttonEx3_Click);
            // 
            // btnSpareInfo
            // 
            this.btnSpareInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSpareInfo.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnSpareInfo.BackColor = System.Drawing.Color.Transparent;
            this.btnSpareInfo.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnSpareInfo.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnSpareInfo.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnSpareInfo.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnSpareInfo.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnSpareInfo.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnSpareInfo.FadingSpeed = 20;
            this.btnSpareInfo.FlatAppearance.BorderSize = 0;
            this.btnSpareInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSpareInfo.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSpareInfo.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnSpareInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnSpareInfo.Image")));
            this.btnSpareInfo.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnSpareInfo.ImageOffset = 4;
            this.btnSpareInfo.IsPressed = false;
            this.btnSpareInfo.KeepPress = false;
            this.btnSpareInfo.Location = new System.Drawing.Point(179, 2);
            this.btnSpareInfo.Margin = new System.Windows.Forms.Padding(0);
            this.btnSpareInfo.MaxImageSize = new System.Drawing.Point(40, 40);
            this.btnSpareInfo.MenuPos = new System.Drawing.Point(0, 0);
            this.btnSpareInfo.Name = "btnSpareInfo";
            this.btnSpareInfo.Radius = 6;
            this.btnSpareInfo.ShowBase = true;
            this.btnSpareInfo.Size = new System.Drawing.Size(108, 46);
            this.btnSpareInfo.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnSpareInfo.SplitDistance = 0;
            this.btnSpareInfo.TabIndex = 40;
            this.btnSpareInfo.Text = "备件图";
            this.btnSpareInfo.Title = "";
            this.btnSpareInfo.UseVisualStyleBackColor = true;
            this.btnSpareInfo.Visible = false;
            this.btnSpareInfo.Click += new System.EventHandler(this.btnSpareInfo_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.buttonSearch.BackColor = System.Drawing.Color.Transparent;
            this.buttonSearch.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.buttonSearch.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.buttonSearch.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.buttonSearch.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.buttonSearch.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.buttonSearch.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.buttonSearch.FadingSpeed = 20;
            this.buttonSearch.FlatAppearance.BorderSize = 0;
            this.buttonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSearch.Font = new System.Drawing.Font("宋体", 9F);
            this.buttonSearch.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonSearch.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearch.Image")));
            this.buttonSearch.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonSearch.ImageOffset = 2;
            this.buttonSearch.IsPressed = false;
            this.buttonSearch.KeepPress = false;
            this.buttonSearch.Location = new System.Drawing.Point(132, 2);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSearch.MaxImageSize = new System.Drawing.Point(40, 40);
            this.buttonSearch.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Radius = 6;
            this.buttonSearch.ShowBase = true;
            this.buttonSearch.Size = new System.Drawing.Size(47, 46);
            this.buttonSearch.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonSearch.SplitDistance = 0;
            this.buttonSearch.TabIndex = 28;
            this.buttonSearch.Title = "";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Visible = false;
            this.buttonSearch.Click += new System.EventHandler(this.toolStripButton2_Click);
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
            this.buttonEx5.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonEx5.Enabled = false;
            this.buttonEx5.FadingSpeed = 20;
            this.buttonEx5.FlatAppearance.BorderSize = 0;
            this.buttonEx5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx5.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonEx5.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx5.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx5.Image")));
            this.buttonEx5.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx5.ImageOffset = 0;
            this.buttonEx5.IsPressed = false;
            this.buttonEx5.KeepPress = false;
            this.buttonEx5.Location = new System.Drawing.Point(0, 0);
            this.buttonEx5.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx5.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx5.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx5.Name = "buttonEx5";
            this.buttonEx5.Radius = 6;
            this.buttonEx5.ShowBase = false;
            this.buttonEx5.Size = new System.Drawing.Size(248, 53);
            this.buttonEx5.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx5.SplitDistance = 0;
            this.buttonEx5.TabIndex = 25;
            this.buttonEx5.Text = "船舶设备复制";
            this.buttonEx5.Title = "";
            this.buttonEx5.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 53);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(1008, 677);
            this.panel2.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(998, 667);
            this.tableLayoutPanel1.TabIndex = 33;
            // 
            // FrmComponentCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmComponentCopy";
            this.Text = "船舶设备复制";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmComponentManage_FormClosed);
            this.Load += new System.EventHandler(this.FrmComponentManage_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkInfo)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkOrder)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private CommonViewer.ButtonEx buttonEx5;
        private CommonViewer.ButtonEx CloseButton;
        private CommonViewer.ButtonEx btnSpareInfo;
        private CommonViewer.ButtonEx btnCompHistory;
        private CommonViewer.ButtonEx btnBdFiles;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private UcEquipmentClassTreeWithEquipment ucEquipmentClassTreeWithEquipment1;
        private CommonViewer.ButtonEx buttonEx3;
        public CommonViewer.ButtonEx btnAnnualCopy;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CommonViewer.ButtonEx buttonSearch;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private CommonViewer.UcDataGridView dgvWorkInfo;
        private CommonViewer.UcDataGridView dgvWorkOrder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DateTimePicker dtpAnnual;
        private System.Windows.Forms.Label label2;
    }
}