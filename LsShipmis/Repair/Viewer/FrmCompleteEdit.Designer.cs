namespace Repair.Viewer
{
    partial class FrmCompleteEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompleteEdit));
            this.bdNgEditItem = new CommonViewer.ButtonEx();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonEx2 = new CommonViewer.ButtonEx();
            this.btnClose = new CommonViewer.ButtonEx();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtREMARK = new CommonViewer.TextBoxEx();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.ucCurrencySelect1 = new BaseInfo.Viewer.UcCurrencySelect();
            this.dateTimePickerEx1 = new CommonViewer.DateTimePickerEx();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // bdNgEditItem
            // 
            this.bdNgEditItem.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.bdNgEditItem.BackColor = System.Drawing.Color.Transparent;
            this.bdNgEditItem.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.bdNgEditItem.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.bdNgEditItem.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.bdNgEditItem.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.bdNgEditItem.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bdNgEditItem.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bdNgEditItem.Dock = System.Windows.Forms.DockStyle.Right;
            this.bdNgEditItem.FadingSpeed = 20;
            this.bdNgEditItem.FlatAppearance.BorderSize = 0;
            this.bdNgEditItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bdNgEditItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bdNgEditItem.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.bdNgEditItem.Image = ((System.Drawing.Image)(resources.GetObject("bdNgEditItem.Image")));
            this.bdNgEditItem.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.bdNgEditItem.ImageOffset = 5;
            this.bdNgEditItem.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bdNgEditItem.IsPressed = false;
            this.bdNgEditItem.KeepPress = false;
            this.bdNgEditItem.Location = new System.Drawing.Point(415, 6);
            this.bdNgEditItem.Margin = new System.Windows.Forms.Padding(0);
            this.bdNgEditItem.MaxImageSize = new System.Drawing.Point(0, 0);
            this.bdNgEditItem.MenuPos = new System.Drawing.Point(0, 0);
            this.bdNgEditItem.Name = "bdNgEditItem";
            this.bdNgEditItem.Radius = 6;
            this.bdNgEditItem.ShowBase = true;
            this.bdNgEditItem.Size = new System.Drawing.Size(130, 43);
            this.bdNgEditItem.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.bdNgEditItem.SplitDistance = 0;
            this.bdNgEditItem.TabIndex = 38;
            this.bdNgEditItem.Text = "完工确认";
            this.bdNgEditItem.Title = "";
            this.bdNgEditItem.UseVisualStyleBackColor = true;
            this.bdNgEditItem.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.bdNgEditItem);
            this.panel4.Controls.Add(this.buttonEx2);
            this.panel4.Controls.Add(this.btnClose);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(6);
            this.panel4.Size = new System.Drawing.Size(629, 55);
            this.panel4.TabIndex = 11;
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
            this.buttonEx2.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonEx2.Enabled = false;
            this.buttonEx2.FadingSpeed = 20;
            this.buttonEx2.FlatAppearance.BorderSize = 0;
            this.buttonEx2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEx2.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.buttonEx2.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.buttonEx2.Image = ((System.Drawing.Image)(resources.GetObject("buttonEx2.Image")));
            this.buttonEx2.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.buttonEx2.ImageOffset = 3;
            this.buttonEx2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonEx2.IsPressed = false;
            this.buttonEx2.KeepPress = false;
            this.buttonEx2.Location = new System.Drawing.Point(6, 6);
            this.buttonEx2.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEx2.MaxImageSize = new System.Drawing.Point(0, 0);
            this.buttonEx2.MenuPos = new System.Drawing.Point(0, 0);
            this.buttonEx2.Name = "buttonEx2";
            this.buttonEx2.Radius = 6;
            this.buttonEx2.ShowBase = false;
            this.buttonEx2.Size = new System.Drawing.Size(198, 43);
            this.buttonEx2.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.buttonEx2.SplitDistance = 0;
            this.buttonEx2.TabIndex = 23;
            this.buttonEx2.Text = "完工确认";
            this.buttonEx2.Title = "";
            this.buttonEx2.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Arrow = CommonViewer.ButtonEx.e_arrow.None;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.ColorBase = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(209)))), ((int)(((byte)(240)))));
            this.btnClose.ColorBaseStroke = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(187)))), ((int)(((byte)(213)))));
            this.btnClose.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(214)))), ((int)(((byte)(78)))));
            this.btnClose.ColorOnStroke = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(177)))), ((int)(((byte)(118)))));
            this.btnClose.ColorPress = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClose.ColorPressStroke = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FadingSpeed = 20;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.GroupPos = CommonViewer.ButtonEx.e_groupPos.None;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageLocation = CommonViewer.ButtonEx.e_imagelocation.Left;
            this.btnClose.ImageOffset = 5;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.IsPressed = false;
            this.btnClose.KeepPress = false;
            this.btnClose.Location = new System.Drawing.Point(545, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.MaxImageSize = new System.Drawing.Point(0, 0);
            this.btnClose.MenuPos = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Radius = 5;
            this.btnClose.ShowBase = true;
            this.btnClose.Size = new System.Drawing.Size(78, 43);
            this.btnClose.SplitButton = CommonViewer.ButtonEx.e_splitbutton.No;
            this.btnClose.SplitDistance = 0;
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.Title = "";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.bdNgClose_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(629, 264);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(623, 203);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "完工信息";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.87076F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.27141F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.38611F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.47172F));
            this.tableLayoutPanel3.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label10, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtREMARK, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.nudAmount, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.ucCurrencySelect1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.dateTimePickerEx1, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(617, 183);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(299, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 31);
            this.label3.TabIndex = 9;
            this.label3.Text = "金额";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 31);
            this.label4.TabIndex = 0;
            this.label4.Text = "币种";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 34);
            this.label10.TabIndex = 0;
            this.label10.Text = "完成日期";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 32);
            this.label7.TabIndex = 0;
            this.label7.Text = "备注";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtREMARK
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.txtREMARK, 3);
            this.txtREMARK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtREMARK.Location = new System.Drawing.Point(125, 68);
            this.txtREMARK.MaxLength = 2000;
            this.txtREMARK.Multiline = true;
            this.txtREMARK.Name = "txtREMARK";
            this.tableLayoutPanel3.SetRowSpan(this.txtREMARK, 2);
            this.txtREMARK.Size = new System.Drawing.Size(489, 112);
            this.txtREMARK.TabIndex = 1;
            // 
            // nudAmount
            // 
            this.nudAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudAmount.Location = new System.Drawing.Point(418, 3);
            this.nudAmount.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(196, 21);
            this.nudAmount.TabIndex = 53;
            this.nudAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudAmount.ThousandsSeparator = true;
            // 
            // ucCurrencySelect1
            // 
            this.ucCurrencySelect1.CanEdit = true;
            this.ucCurrencySelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCurrencySelect1.DropDownWidth = 168;
            this.ucCurrencySelect1.Location = new System.Drawing.Point(125, 3);
            this.ucCurrencySelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucCurrencySelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucCurrencySelect1.Name = "ucCurrencySelect1";
            this.ucCurrencySelect1.NullValueShow = "请选择币种";
            this.ucCurrencySelect1.ShowButton = false;
            this.ucCurrencySelect1.Size = new System.Drawing.Size(168, 20);
            this.ucCurrencySelect1.TabIndex = 54;
            // 
            // dateTimePickerEx1
            // 
            this.dateTimePickerEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePickerEx1.Location = new System.Drawing.Point(125, 34);
            this.dateTimePickerEx1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.dateTimePickerEx1.MaxValue = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dateTimePickerEx1.MimValue = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerEx1.Name = "dateTimePickerEx1";
            this.dateTimePickerEx1.ReadOnly = false;
            this.dateTimePickerEx1.Size = new System.Drawing.Size(168, 31);
            this.dateTimePickerEx1.TabIndex = 55;
            this.dateTimePickerEx1.Value = new System.DateTime(((long)(0)));
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            // 
            // FrmCompleteEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(629, 264);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmCompleteEdit";
            this.Text = "完工确认";
            this.Load += new System.EventHandler(this.FrmCompleteEdit_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCompleteEdit_FormClosing);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public CommonViewer.ButtonEx bdNgEditItem;
        protected System.Windows.Forms.Panel panel4;
        public CommonViewer.ButtonEx buttonEx2;
        protected CommonViewer.ButtonEx btnClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private BaseInfo.Viewer.UcCurrencySelect ucCurrencySelect1;
        private System.Windows.Forms.Label label7;
        private CommonViewer.TextBoxEx txtREMARK;
        private CommonViewer.DateTimePickerEx dateTimePickerEx1;
    }
}