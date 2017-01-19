namespace ItemsManage.Viewer
{
    partial class FrmSelectComponent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectComponent));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSelect = new CommonViewer.TextBoxEx();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvSelect = new CommonViewer.BaseControl.UCObjectsGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonEx1 = new CommonViewer.ButtonEx();
            this.buttonEx5 = new CommonViewer.ButtonEx();
            this.AddButton = new CommonViewer.ButtonEx();
            this.CloseButton = new CommonViewer.ButtonEx();
            this.ucShipSelect1 = new BaseInfo.Viewer.UcShipSelect();
            this.ucEquipmentClassTreeWithEquipment1 = new ItemsManage.Viewer.UcEquipmentClassTreeWithEquipment();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(387, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "过滤";
            // 
            // txtSelect
            // 
            this.txtSelect.Location = new System.Drawing.Point(422, 19);
            this.txtSelect.Name = "txtSelect";
            this.txtSelect.Size = new System.Drawing.Size(206, 21);
            this.txtSelect.TabIndex = 2;
            this.txtSelect.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSelect_KeyPress);
            this.txtSelect.Enter += new System.EventHandler(this.txtSelect_Enter);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(0, 58);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvSelect);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(843, 484);
            this.splitContainer1.SplitterDistance = 281;
            this.splitContainer1.TabIndex = 6;
            // 
            // dgvSelect
            // 
            this.dgvSelect.AutoColumnsFill = false;
            this.dgvSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSelect.Location = new System.Drawing.Point(0, 0);
            this.dgvSelect.Name = "dgvSelect";
            this.dgvSelect.ReadOnly = false;
            this.dgvSelect.ShowText = "搜索结果";
            this.dgvSelect.Size = new System.Drawing.Size(277, 480);
            this.dgvSelect.TabIndex = 3;
            this.dgvSelect.UserDoubleClick += new CommonViewer.BaseControl.UCObjectsGridView.deleDoubleClick(this.ucObjectsGridView1_UserDoubleClick);
            this.dgvSelect.TheObjectChanged += new CommonViewer.BaseControl.UCObjectsGridView.ObjectChanged(this.ucObjectsGridView1_TheObjectChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(554, 480);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucEquipmentClassTreeWithEquipment1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 474);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备信息树";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.ucShipSelect1);
            this.panel3.Controls.Add(this.buttonEx1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.buttonEx5);
            this.panel3.Controls.Add(this.AddButton);
            this.panel3.Controls.Add(this.txtSelect);
            this.panel3.Controls.Add(this.CloseButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(843, 55);
            this.panel3.TabIndex = 51;
            this.panel3.MouseLeave += new System.EventHandler(this.panel3_MouseLeave);
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseDown);
            this.panel3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseUp);
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
            this.buttonEx1.FadingSpeed = 20;
            this.buttonEx1.FlatAppearance.BorderSize = 0;
            this.buttonEx1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx1.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx1.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx1.Image")));
            this.buttonEx1.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx1.ImageOffset = -13;
            this.buttonEx1.IsPressed = false;
            this.buttonEx1.KeepPress = false;
            this.buttonEx1.Location = new System.Drawing.Point(631, 15);
            this.buttonEx1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx1.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx1.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx1.Name = "buttonEx1";
            this.buttonEx1.Radius = 6;
            this.buttonEx1.ShowBase = true;
            this.buttonEx1.Size = new System.Drawing.Size(31, 29);
            this.buttonEx1.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx1.SplitDistance = 0;
            this.buttonEx1.TabIndex = 28;
            this.buttonEx1.Title = "";
            this.buttonEx1.UseVisualStyleBackColor = true;
            this.buttonEx1.Click += new System.EventHandler(this.btnSelect_Click);
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
            this.buttonEx5.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx5.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx5.Image")));
            this.buttonEx5.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx5.ImageOffset = 3;
            this.buttonEx5.IsPressed = false;
            this.buttonEx5.KeepPress = false;
            this.buttonEx5.Location = new System.Drawing.Point(5, 3);
            this.buttonEx5.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx5.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx5.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx5.Name = "buttonEx5";
            this.buttonEx5.Radius = 6;
            this.buttonEx5.ShowBase = false;
            this.buttonEx5.Size = new System.Drawing.Size(196, 47);
            this.buttonEx5.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx5.SplitDistance = 0;
            this.buttonEx5.TabIndex = 25;
            this.buttonEx5.Text = "船舶设备快速选择";
            this.buttonEx5.Title = "";
            this.buttonEx5.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.AddButton.BackColor = System.Drawing.Color.Transparent;
            this.AddButton.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.AddButton.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.AddButton.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.AddButton.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.AddButton.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.AddButton.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.AddButton.FadingSpeed = 20;
            this.AddButton.FlatAppearance.BorderSize = 0;
            this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddButton.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.AddButton.Image = ((System.Drawing.Image)(resources.GetObject("AddButton.Image")));
            this.AddButton.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.AddButton.ImageOffset = 10;
            this.AddButton.IsPressed = false;
            this.AddButton.KeepPress = false;
            this.AddButton.Location = new System.Drawing.Point(682, 8);
            this.AddButton.Margin = new System.Windows.Forms.Padding(0);
            this.AddButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.AddButton.MenuPos = new System.Drawing.Point(0, 0);
            this.AddButton.Name = "AddButton";
            this.AddButton.Radius = 6;
            this.AddButton.ShowBase = true;
            this.AddButton.Size = new System.Drawing.Size(81, 40);
            this.AddButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.AddButton.SplitDistance = 0;
            this.AddButton.TabIndex = 22;
            this.AddButton.Text = "确定";
            this.AddButton.Title = "";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.CloseButton.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.CloseButton.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.CloseButton.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.CloseButton.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CloseButton.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.CloseButton.FadingSpeed = 20;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.CloseButton.ImageOffset = 8;
            this.CloseButton.IsPressed = false;
            this.CloseButton.KeepPress = false;
            this.CloseButton.Location = new System.Drawing.Point(763, 8);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(0);
            this.CloseButton.MaxImageSize = new System.Drawing.Point(0, 0);
            this.CloseButton.MenuPos = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Radius = 6;
            this.CloseButton.ShowBase = true;
            this.CloseButton.Size = new System.Drawing.Size(75, 40);
            this.CloseButton.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.CloseButton.SplitDistance = 0;
            this.CloseButton.TabIndex = 21;
            this.CloseButton.Text = "关闭";
            this.CloseButton.Title = "";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ucShipSelect1
            // 
            this.ucShipSelect1.CanEdit = false;
            this.ucShipSelect1.DropDownWidth = 129;
            this.ucShipSelect1.Location = new System.Drawing.Point(225, 20);
            this.ucShipSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucShipSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucShipSelect1.Name = "ucShipSelect1";
            this.ucShipSelect1.NullValueShow = "所有船";
            this.ucShipSelect1.ShowButton = true;
            this.ucShipSelect1.Size = new System.Drawing.Size(129, 20);
            this.ucShipSelect1.TabIndex = 29;
            this.ucShipSelect1.TheSelectedChanged += new CommonViewer.BaseControl.ComboxEx.ObjectChanged(this.ucShipSelect1_TheSelectedChanged);
            // 
            // ucEquipmentClassTreeWithEquipment1
            // 
            this.ucEquipmentClassTreeWithEquipment1.AllowDrop = true;
            this.ucEquipmentClassTreeWithEquipment1.AllowEquipmentClassDragToOtherClass = false;
            this.ucEquipmentClassTreeWithEquipment1.AllowUserDrag = true;
            this.ucEquipmentClassTreeWithEquipment1.AllowUserEdit = true;
            this.ucEquipmentClassTreeWithEquipment1.AllowUserMultiSelect = false;
            this.ucEquipmentClassTreeWithEquipment1.AllowUserSort = true;
            this.ucEquipmentClassTreeWithEquipment1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEquipmentClassTreeWithEquipment1.Font = new System.Drawing.Font("宋体", 12F);
            this.ucEquipmentClassTreeWithEquipment1.ImageIndex = 0;
            this.ucEquipmentClassTreeWithEquipment1.ItemHeight = 22;
            this.ucEquipmentClassTreeWithEquipment1.Location = new System.Drawing.Point(3, 17);
            this.ucEquipmentClassTreeWithEquipment1.Name = "ucEquipmentClassTreeWithEquipment1";
            this.ucEquipmentClassTreeWithEquipment1.OneShipMode = true;
            this.ucEquipmentClassTreeWithEquipment1.OnlyShowNotClassifedEquipment = false;
            this.ucEquipmentClassTreeWithEquipment1.SelectedImageIndex = 0;
            this.ucEquipmentClassTreeWithEquipment1.ShowAllClass = false;
            this.ucEquipmentClassTreeWithEquipment1.ShowEquipment = true;
            this.ucEquipmentClassTreeWithEquipment1.ShowEquipmentHaveSpare = false;
            this.ucEquipmentClassTreeWithEquipment1.ShowNotClassifedEquipment = true;
            this.ucEquipmentClassTreeWithEquipment1.Size = new System.Drawing.Size(542, 454);
            this.ucEquipmentClassTreeWithEquipment1.TabIndex = 0;
            // 
            // FrmSelectComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(843, 543);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.splitContainer1);
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FrmSelectComponent";
            this.Text = "选择设备";
            this.Load += new System.EventHandler(this.FrmSelectComponent_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSelectComponent_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CommonViewer.TextBoxEx txtSelect;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel3;
        private CommonViewer.ButtonEx buttonEx5;
        private CommonViewer.ButtonEx AddButton;
        private CommonViewer.ButtonEx CloseButton;
        private CommonViewer.ButtonEx buttonEx1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CommonViewer.BaseControl.UCObjectsGridView dgvSelect;
        private System.Windows.Forms.GroupBox groupBox1;
        private UcEquipmentClassTreeWithEquipment ucEquipmentClassTreeWithEquipment1;
        private BaseInfo.Viewer.UcShipSelect ucShipSelect1;
    }
}