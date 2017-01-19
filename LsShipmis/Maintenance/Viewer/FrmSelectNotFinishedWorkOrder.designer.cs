namespace Maintenance.Viewer
{
    partial class FrmSelectNotFinishedWorkOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectNotFinishedWorkOrder));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bdsStock = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonEx1 = new CommonViewer.ButtonEx();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.CloseButton = new CommonViewer.ButtonEx();
            this.bdNgSelect = new CommonViewer.ButtonEx();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvNotFinishedWorkOrder = new CommonViewer.UcDataGridView(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.rdoAllWorkOrder = new System.Windows.Forms.RadioButton();
            this.label24 = new System.Windows.Forms.Label();
            this.btnSelComponent = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ucPostSelect1 = new BaseInfo.Viewer.UcPostSelect();
            this.ucPostSelect2 = new BaseInfo.Viewer.UcPostSelect();
            ((System.ComponentModel.ISupportInitialize)(this.bdsStock)).BeginInit();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotFinishedWorkOrder)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.buttonEx1);
            this.panel3.Controls.Add(this.flowLayoutPanel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(5);
            this.panel3.Size = new System.Drawing.Size(1204, 56);
            this.panel3.TabIndex = 53;
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
            this.buttonEx1.ImageOffset = 3;
            this.buttonEx1.IsPressed = false;
            this.buttonEx1.KeepPress = false;
            this.buttonEx1.Location = new System.Drawing.Point(3, 3);
            this.buttonEx1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx1.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx1.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx1.Name = "buttonEx1";
            this.buttonEx1.Radius = 6;
            this.buttonEx1.ShowBase = false;
            this.buttonEx1.Size = new System.Drawing.Size(378, 47);
            this.buttonEx1.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx1.SplitDistance = 0;
            this.buttonEx1.TabIndex = 35;
            this.buttonEx1.Text = "选择未完成工单";
            this.buttonEx1.Title = "";
            this.buttonEx1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.CloseButton);
            this.flowLayoutPanel2.Controls.Add(this.bdNgSelect);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(425, 5);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel2.Size = new System.Drawing.Size(774, 46);
            this.flowLayoutPanel2.TabIndex = 34;
            // 
            // CloseButton
            // 
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
            this.CloseButton.Location = new System.Drawing.Point(727, 0);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.CloseButton.MenuPos = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Radius = 6;
            this.CloseButton.ShowBase = true;
            this.CloseButton.Size = new System.Drawing.Size(47, 46);
            this.CloseButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.CloseButton.SplitDistance = 0;
            this.CloseButton.TabIndex = 21;
            this.CloseButton.Title = "";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // bdNgSelect
            // 
            this.bdNgSelect.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.bdNgSelect.BackColor = System.Drawing.Color.Transparent;
            this.bdNgSelect.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.bdNgSelect.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.bdNgSelect.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.bdNgSelect.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.bdNgSelect.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bdNgSelect.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bdNgSelect.FadingSpeed = 20;
            this.bdNgSelect.FlatAppearance.BorderSize = 0;
            this.bdNgSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bdNgSelect.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bdNgSelect.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.bdNgSelect.Image = ((System.Drawing.Image)(resources.GetObject("bdNgSelect.Image")));
            this.bdNgSelect.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgSelect.ImageOffset = 3;
            this.bdNgSelect.IsPressed = false;
            this.bdNgSelect.KeepPress = false;
            this.bdNgSelect.Location = new System.Drawing.Point(617, 0);
            this.bdNgSelect.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgSelect.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgSelect.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgSelect.Name = "bdNgSelect";
            this.bdNgSelect.Radius = 6;
            this.bdNgSelect.ShowBase = true;
            this.bdNgSelect.Size = new System.Drawing.Size(110, 46);
            this.bdNgSelect.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgSelect.SplitDistance = 0;
            this.bdNgSelect.TabIndex = 28;
            this.bdNgSelect.Text = "选择";
            this.bdNgSelect.Title = "";
            this.bdNgSelect.UseVisualStyleBackColor = true;
            this.bdNgSelect.Click += new System.EventHandler(this.bdNgSelect_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvNotFinishedWorkOrder);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(8, 3, 8, 8);
            this.groupBox2.Size = new System.Drawing.Size(1198, 438);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "未完成工单清单";
            // 
            // dgvNotFinishedWorkOrder
            // 
            this.dgvNotFinishedWorkOrder.AllowUserToAddRows = false;
            this.dgvNotFinishedWorkOrder.AllowUserToDeleteRows = false;
            this.dgvNotFinishedWorkOrder.AllowUserToOrderColumns = true;
            this.dgvNotFinishedWorkOrder.AutoFit = true;
            this.dgvNotFinishedWorkOrder.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvNotFinishedWorkOrder.ColumnDeep = 1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNotFinishedWorkOrder.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvNotFinishedWorkOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNotFinishedWorkOrder.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvNotFinishedWorkOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNotFinishedWorkOrder.EnableHeadersVisualStyles = false;
            this.dgvNotFinishedWorkOrder.Footer = null;
            this.dgvNotFinishedWorkOrder.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvNotFinishedWorkOrder.Header = null;
            this.dgvNotFinishedWorkOrder.LoadedFinish = false;
            this.dgvNotFinishedWorkOrder.Location = new System.Drawing.Point(8, 17);
            this.dgvNotFinishedWorkOrder.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvNotFinishedWorkOrder.MergeColumnNames")));
            this.dgvNotFinishedWorkOrder.MergeRowColumn = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvNotFinishedWorkOrder.MergeRowColumn")));
            this.dgvNotFinishedWorkOrder.Name = "dgvNotFinishedWorkOrder";
            this.dgvNotFinishedWorkOrder.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNotFinishedWorkOrder.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvNotFinishedWorkOrder.RowHeadersWidth = 25;
            this.dgvNotFinishedWorkOrder.RowTemplate.Height = 23;
            this.dgvNotFinishedWorkOrder.ShowRowNumber = true;
            this.dgvNotFinishedWorkOrder.Size = new System.Drawing.Size(1182, 413);
            this.dgvNotFinishedWorkOrder.TabIndex = 3;
            this.dgvNotFinishedWorkOrder.Title = "";
            this.dgvNotFinishedWorkOrder.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNotFinishedWorkOrder_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ucPostSelect2);
            this.groupBox3.Controls.Add(this.ucPostSelect1);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.rdoAllWorkOrder);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.btnSelComponent);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 59);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1198, 58);
            this.groupBox3.TabIndex = 57;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "查询";
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(585, 19);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(100, 18);
            this.label25.TabIndex = 39;
            this.label25.Text = "确认人岗位";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rdoAllWorkOrder
            // 
            this.rdoAllWorkOrder.AutoSize = true;
            this.rdoAllWorkOrder.BackColor = System.Drawing.Color.AliceBlue;
            this.rdoAllWorkOrder.Checked = true;
            this.rdoAllWorkOrder.Location = new System.Drawing.Point(189, 23);
            this.rdoAllWorkOrder.Name = "rdoAllWorkOrder";
            this.rdoAllWorkOrder.Size = new System.Drawing.Size(71, 16);
            this.rdoAllWorkOrder.TabIndex = 38;
            this.rdoAllWorkOrder.TabStop = true;
            this.rdoAllWorkOrder.Text = "显示所有";
            this.rdoAllWorkOrder.UseVisualStyleBackColor = false;
            this.rdoAllWorkOrder.Click += new System.EventHandler(this.rdoAllWorkOrder_Click);
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(287, 21);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(129, 18);
            this.label24.TabIndex = 36;
            this.label24.Text = "责任人岗位";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSelComponent
            // 
            this.btnSelComponent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelComponent.Image = ((System.Drawing.Image)(resources.GetObject("btnSelComponent.Image")));
            this.btnSelComponent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelComponent.Location = new System.Drawing.Point(45, 13);
            this.btnSelComponent.Name = "btnSelComponent";
            this.btnSelComponent.Size = new System.Drawing.Size(231, 35);
            this.btnSelComponent.TabIndex = 37;
            this.btnSelComponent.Text = "    指定设备…";
            this.btnSelComponent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelComponent.UseVisualStyleBackColor = true;
            this.btnSelComponent.Click += new System.EventHandler(this.btnSelComponent_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1204, 564);
            this.tableLayoutPanel1.TabIndex = 58;
            // 
            // ucPostSelect1
            // 
            this.ucPostSelect1.CanEdit = false;
            this.ucPostSelect1.DropDownWidth = 152;
            this.ucPostSelect1.Location = new System.Drawing.Point(422, 19);
            this.ucPostSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucPostSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucPostSelect1.Name = "ucPostSelect1";
            this.ucPostSelect1.NullValueShow = "所有岗位";
            this.ucPostSelect1.ShowButton = false;
            this.ucPostSelect1.Size = new System.Drawing.Size(152, 20);
            this.ucPostSelect1.TabIndex = 40;
            this.ucPostSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucPostSelect1_TheSelectedChanged);
            // 
            // ucPostSelect2
            // 
            this.ucPostSelect2.CanEdit = false;
            this.ucPostSelect2.DropDownWidth = 127;
            this.ucPostSelect2.Location = new System.Drawing.Point(691, 17);
            this.ucPostSelect2.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucPostSelect2.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucPostSelect2.Name = "ucPostSelect2";
            this.ucPostSelect2.NullValueShow = "所有岗位";
            this.ucPostSelect2.ShowButton = false;
            this.ucPostSelect2.Size = new System.Drawing.Size(152, 20);
            this.ucPostSelect2.TabIndex = 41;
            this.ucPostSelect2.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucPostSelect2_TheSelectedChanged);
            // 
            // FrmSelectNotFinishedWorkOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 564);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmSelectNotFinishedWorkOrder";
            this.Text = "选择未完成工单";
            this.Load += new System.EventHandler(this.FrmMaterialOutMethod_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSelectNotFinishedWorkOrder_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.bdsStock)).EndInit();
            this.panel3.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotFinishedWorkOrder)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bdsStock;
        private System.Windows.Forms.GroupBox groupBox2;
        private CommonViewer.UcDataGridView dgvNotFinishedWorkOrder;
        private System.Windows.Forms.Panel panel3;
        private CommonViewer.ButtonEx CloseButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CommonViewer.ButtonEx bdNgSelect;
        private CommonViewer.ButtonEx buttonEx1;
        private System.Windows.Forms.RadioButton rdoAllWorkOrder;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnSelComponent;
        private System.Windows.Forms.Label label25;
        private BaseInfo.Viewer.UcPostSelect ucPostSelect2;
        private BaseInfo.Viewer.UcPostSelect ucPostSelect1;
    }
}