namespace LSShipMis_Land.SysLs.Forms
{
    partial class FrmEquipmentWorkInfoCopy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEquipmentWorkInfoCopy));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvWorkState = new CommonViewer.UcDataGridView(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCreateWorkOrder = new CommonViewer.ButtonEx();
            this.btnStart = new CommonViewer.ButtonEx();
            this.CloseButton = new CommonViewer.ButtonEx();
            this.buttonEx5 = new CommonViewer.ButtonEx();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ucShipSource = new BaseInfo.Viewer.UcShipSelect();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpAnnual = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbkIsCopyWorkInfo = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkState)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvWorkState);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(885, 439);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "船舶列表";
            // 
            // dgvWorkState
            // 
            this.dgvWorkState.AllowUserToAddRows = false;
            this.dgvWorkState.AllowUserToDeleteRows = false;
            this.dgvWorkState.AllowUserToOrderColumns = true;
            this.dgvWorkState.AutoFit = true;
            this.dgvWorkState.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvWorkState.ColumnDeep = 1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkState.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWorkState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWorkState.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWorkState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWorkState.EnableHeadersVisualStyles = false;
            this.dgvWorkState.ExportColorToExcel = false;
            this.dgvWorkState.Footer = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkState.Footer")));
            this.dgvWorkState.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvWorkState.Header = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkState.Header")));
            this.dgvWorkState.LoadedFinish = false;
            this.dgvWorkState.Location = new System.Drawing.Point(3, 17);
            this.dgvWorkState.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkState.MergeColumnNames")));
            this.dgvWorkState.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvWorkState.MergeRowColumn")));
            this.dgvWorkState.Name = "dgvWorkState";
            this.dgvWorkState.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWorkState.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvWorkState.RowHeadersWidth = 25;
            this.dgvWorkState.RowTemplate.Height = 23;
            this.dgvWorkState.ShowRowNumber = true;
            this.dgvWorkState.Size = new System.Drawing.Size(879, 419);
            this.dgvWorkState.TabIndex = 2;
            this.dgvWorkState.Title = "";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.btnCreateWorkOrder);
            this.panel3.Controls.Add(this.btnStart);
            this.panel3.Controls.Add(this.CloseButton);
            this.panel3.Controls.Add(this.buttonEx5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(891, 59);
            this.panel3.TabIndex = 55;
            // 
            // btnCreateWorkOrder
            // 
            this.btnCreateWorkOrder.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnCreateWorkOrder.BackColor = System.Drawing.Color.Transparent;
            this.btnCreateWorkOrder.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnCreateWorkOrder.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnCreateWorkOrder.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnCreateWorkOrder.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnCreateWorkOrder.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCreateWorkOrder.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCreateWorkOrder.FadingSpeed = 20;
            this.btnCreateWorkOrder.FlatAppearance.BorderSize = 0;
            this.btnCreateWorkOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateWorkOrder.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCreateWorkOrder.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnCreateWorkOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateWorkOrder.Image")));
            this.btnCreateWorkOrder.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnCreateWorkOrder.ImageOffset = 5;
            this.btnCreateWorkOrder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCreateWorkOrder.IsPressed = false;
            this.btnCreateWorkOrder.KeepPress = false;
            this.btnCreateWorkOrder.Location = new System.Drawing.Point(579, 8);
            this.btnCreateWorkOrder.Margin = new System.Windows.Forms.Padding(0);
            this.btnCreateWorkOrder.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnCreateWorkOrder.MenuPos = new System.Drawing.Point(0, 0);
            this.btnCreateWorkOrder.Name = "btnCreateWorkOrder";
            this.btnCreateWorkOrder.Radius = 6;
            this.btnCreateWorkOrder.ShowBase = true;
            this.btnCreateWorkOrder.Size = new System.Drawing.Size(141, 44);
            this.btnCreateWorkOrder.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnCreateWorkOrder.SplitDistance = 0;
            this.btnCreateWorkOrder.TabIndex = 51;
            this.btnCreateWorkOrder.Text = "生成初始工单";
            this.btnCreateWorkOrder.Title = "";
            this.btnCreateWorkOrder.UseVisualStyleBackColor = true;
            this.btnCreateWorkOrder.Click += new System.EventHandler(this.btnCreateWorkOrder_Click);
            // 
            // btnStart
            // 
            this.btnStart.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnStart.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnStart.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnStart.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnStart.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnStart.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnStart.FadingSpeed = 20;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnStart.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnStart.ImageOffset = 5;
            this.btnStart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnStart.IsPressed = false;
            this.btnStart.KeepPress = false;
            this.btnStart.Location = new System.Drawing.Point(720, 8);
            this.btnStart.Margin = new System.Windows.Forms.Padding(0);
            this.btnStart.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnStart.MenuPos = new System.Drawing.Point(0, 0);
            this.btnStart.Name = "btnStart";
            this.btnStart.Radius = 6;
            this.btnStart.ShowBase = true;
            this.btnStart.Size = new System.Drawing.Size(88, 44);
            this.btnStart.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnStart.SplitDistance = 0;
            this.btnStart.TabIndex = 50;
            this.btnStart.Text = "复制";
            this.btnStart.Title = "";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
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
            this.CloseButton.Location = new System.Drawing.Point(808, 8);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.CloseButton.MenuPos = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Radius = 6;
            this.CloseButton.ShowBase = true;
            this.CloseButton.Size = new System.Drawing.Size(78, 44);
            this.CloseButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.CloseButton.SplitDistance = 0;
            this.CloseButton.TabIndex = 26;
            this.CloseButton.Text = "关闭";
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
            this.buttonEx5.Location = new System.Drawing.Point(4, 5);
            this.buttonEx5.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx5.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx5.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx5.Name = "buttonEx5";
            this.buttonEx5.Radius = 6;
            this.buttonEx5.ShowBase = false;
            this.buttonEx5.Size = new System.Drawing.Size(227, 51);
            this.buttonEx5.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx5.SplitDistance = 0;
            this.buttonEx5.TabIndex = 27;
            this.buttonEx5.Text = "设备工作信息等初始化复制";
            this.buttonEx5.Title = "";
            this.buttonEx5.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flowLayoutPanel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(885, 56);
            this.groupBox3.TabIndex = 56;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "复制参数";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.ucShipSource);
            this.flowLayoutPanel2.Controls.Add(this.label4);
            this.flowLayoutPanel2.Controls.Add(this.dtpAnnual);
            this.flowLayoutPanel2.Controls.Add(this.cbkIsCopyWorkInfo);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(879, 36);
            this.flowLayoutPanel2.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(20, 10, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "船舶";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucShipSource
            // 
            this.ucShipSource.CanEdit = false;
            this.ucShipSource.DropDownWidth = 110;
            this.ucShipSource.Location = new System.Drawing.Point(55, 5);
            this.ucShipSource.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.ucShipSource.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipSource.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipSource.Name = "ucShipSource";
            this.ucShipSource.NullValueShow = "所有船";
            this.ucShipSource.ShowButton = false;
            this.ucShipSource.Size = new System.Drawing.Size(170, 20);
            this.ucShipSource.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(238, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "年度";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpAnnual
            // 
            this.dtpAnnual.CustomFormat = "yyyy";
            this.dtpAnnual.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpAnnual.Location = new System.Drawing.Point(273, 5);
            this.dtpAnnual.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.dtpAnnual.Name = "dtpAnnual";
            this.dtpAnnual.ShowUpDown = true;
            this.dtpAnnual.Size = new System.Drawing.Size(55, 21);
            this.dtpAnnual.TabIndex = 28;
            this.dtpAnnual.ValueChanged += new System.EventHandler(this.dtpAnnual_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 59);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(891, 507);
            this.tableLayoutPanel1.TabIndex = 57;
            // 
            // cbkIsCopyWorkInfo
            // 
            this.cbkIsCopyWorkInfo.AutoSize = true;
            this.cbkIsCopyWorkInfo.Location = new System.Drawing.Point(334, 3);
            this.cbkIsCopyWorkInfo.Name = "cbkIsCopyWorkInfo";
            this.cbkIsCopyWorkInfo.Size = new System.Drawing.Size(120, 16);
            this.cbkIsCopyWorkInfo.TabIndex = 29;
            this.cbkIsCopyWorkInfo.Text = "是否复制工作信息";
            this.cbkIsCopyWorkInfo.UseVisualStyleBackColor = true;
            // 
            // FrmEquipmentWorkInfoCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(891, 566);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel3);
            this.Name = "FrmEquipmentWorkInfoCopy";
            this.Text = "设备工作信息等初始化复制";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEquipmentWorkInfo_FormClosing);
            this.Load += new System.EventHandler(this.FrmEquipmentWorkInfo_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkState)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private CommonViewer.UcDataGridView dgvWorkState;
        private System.Windows.Forms.Panel panel3;
        private CommonViewer.ButtonEx CloseButton;
        private CommonViewer.ButtonEx buttonEx5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private BaseInfo.Viewer.UcShipSelect ucShipSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpAnnual;
        public CommonViewer.ButtonEx btnCreateWorkOrder;
        public CommonViewer.ButtonEx btnStart;
        private System.Windows.Forms.CheckBox cbkIsCopyWorkInfo;
    }
}