namespace ItemsManage.Viewer
{
    partial class UcMaterialInfo
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

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要.
		/// 使用代码编辑器修改此方法的内容。.
		/// </summary>
		private void InitializeComponent()
		{
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txtUnit = new CommonViewer.TextBoxEx();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMaterialName = new CommonViewer.TextBoxEx();
            this.txtRemark = new CommonViewer.TextBoxEx();
            this.txtMaterialType = new CommonViewer.TextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaterialCode = new CommonViewer.TextBoxEx();
            this.txtMaterialSpec = new CommonViewer.TextBoxEx();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.txtUnit, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtMaterialName, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtRemark, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.txtMaterialType, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtMaterialCode, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtMaterialSpec, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(637, 171);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // txtUnit
            // 
            this.txtUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUnit.Location = new System.Drawing.Point(93, 63);
            this.txtUnit.MaxLength = 50;
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(222, 21);
            this.txtUnit.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 30);
            this.label8.TabIndex = 0;
            this.label8.Text = "计量单位*";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 110);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 61);
            this.label9.TabIndex = 0;
            this.label9.Text = "备注";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 30);
            this.label10.TabIndex = 0;
            this.label10.Text = "物资名称*";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaterialName.Location = new System.Drawing.Point(93, 3);
            this.txtMaterialName.MaxLength = 200;
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.Size = new System.Drawing.Size(222, 21);
            this.txtMaterialName.TabIndex = 24;
            // 
            // txtRemark
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.txtRemark, 3);
            this.txtRemark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemark.Location = new System.Drawing.Point(93, 93);
            this.txtRemark.MaxLength = 200;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(541, 75);
            this.txtRemark.TabIndex = 27;
            // 
            // txtMaterialType
            // 
            this.txtMaterialType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaterialType.Location = new System.Drawing.Point(411, 3);
            this.txtMaterialType.MaxLength = 50;
            this.txtMaterialType.Name = "txtMaterialType";
            this.txtMaterialType.ReadOnly = true;
            this.txtMaterialType.Size = new System.Drawing.Size(223, 21);
            this.txtMaterialType.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "物资编码";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(321, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "所属分类*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaterialCode
            // 
            this.txtMaterialCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaterialCode.Location = new System.Drawing.Point(93, 33);
            this.txtMaterialCode.MaxLength = 50;
            this.txtMaterialCode.Name = "txtMaterialCode";
            this.txtMaterialCode.Size = new System.Drawing.Size(222, 21);
            this.txtMaterialCode.TabIndex = 21;
            // 
            // txtMaterialSpec
            // 
            this.txtMaterialSpec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaterialSpec.Location = new System.Drawing.Point(411, 33);
            this.txtMaterialSpec.MaxLength = 200;
            this.txtMaterialSpec.Name = "txtMaterialSpec";
            this.txtMaterialSpec.Size = new System.Drawing.Size(223, 21);
            this.txtMaterialSpec.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(321, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 30);
            this.label7.TabIndex = 0;
            this.label7.Text = "规格型号";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UcMaterialInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel4);
            this.Name = "UcMaterialInfo";
            this.Size = new System.Drawing.Size(637, 171);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private CommonViewer.TextBoxEx txtUnit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private CommonViewer.TextBoxEx txtMaterialType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private CommonViewer.TextBoxEx txtMaterialName;
        private CommonViewer.TextBoxEx txtRemark;
        private CommonViewer.TextBoxEx txtMaterialSpec;
        private System.Windows.Forms.Label label2;
        private CommonViewer.TextBoxEx txtMaterialCode;

        //    private UcDepartmentSelect ucDepartmentSelect1;
	}
}
