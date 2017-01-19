namespace SeaChartManage.Forms
{
    partial class FrmDataStockAddEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCode = new CommonViewer.TextBoxEx();
            this.txtName = new CommonViewer.TextBoxEx();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cboKind = new System.Windows.Forms.ComboBox();
            this.txtContent = new System.Windows.Forms.RichTextBox();
            this.numTotle = new System.Windows.Forms.NumericUpDown();
            this.nulLeft = new System.Windows.Forms.NumericUpDown();
            this.chkContinue = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numTotle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nulLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "编号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "类别";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "名称*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "备注";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "总数量";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(292, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "剩余数量";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(83, 6);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(156, 21);
            this.txtCode.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(83, 35);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(344, 21);
            this.txtName.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(254, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(352, 245);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cboKind
            // 
            this.cboKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKind.FormattingEnabled = true;
            this.cboKind.Items.AddRange(new object[] {
            "海图",
            "资料"});
            this.cboKind.Location = new System.Drawing.Point(306, 6);
            this.cboKind.Name = "cboKind";
            this.cboKind.Size = new System.Drawing.Size(121, 20);
            this.cboKind.TabIndex = 14;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(83, 63);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(344, 145);
            this.txtContent.TabIndex = 15;
            this.txtContent.Text = "";
            // 
            // numTotle
            // 
            this.numTotle.Location = new System.Drawing.Point(83, 214);
            this.numTotle.Name = "numTotle";
            this.numTotle.Size = new System.Drawing.Size(74, 21);
            this.numTotle.TabIndex = 16;
            this.numTotle.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // nulLeft
            // 
            this.nulLeft.Location = new System.Drawing.Point(351, 214);
            this.nulLeft.Name = "nulLeft";
            this.nulLeft.Size = new System.Drawing.Size(76, 21);
            this.nulLeft.TabIndex = 17;
            this.nulLeft.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // chkContinue
            // 
            this.chkContinue.AutoSize = true;
            this.chkContinue.Location = new System.Drawing.Point(161, 249);
            this.chkContinue.Name = "chkContinue";
            this.chkContinue.Size = new System.Drawing.Size(72, 16);
            this.chkContinue.TabIndex = 18;
            this.chkContinue.Text = "连续添加";
            this.chkContinue.UseVisualStyleBackColor = true;
            // 
            // FrmDataStockAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 277);
            this.Controls.Add(this.chkContinue);
            this.Controls.Add(this.nulLeft);
            this.Controls.Add(this.numTotle);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.cboKind);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FrmDataStockAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加修改";
            ((System.ComponentModel.ISupportInitialize)(this.numTotle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nulLeft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private CommonViewer.TextBoxEx txtCode;
        private CommonViewer.TextBoxEx txtName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cboKind;
        private System.Windows.Forms.RichTextBox txtContent;
        private System.Windows.Forms.NumericUpDown numTotle;
        private System.Windows.Forms.NumericUpDown nulLeft;
        private System.Windows.Forms.CheckBox chkContinue;
    }
}