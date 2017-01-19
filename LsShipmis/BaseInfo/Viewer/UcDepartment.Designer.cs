namespace BaseInfo.Viewer
{
    partial class UcDepartment
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

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cobType = new System.Windows.Forms.ComboBox();
            this.txtCode = new CommonViewer.TextBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDepartmentName = new CommonViewer.TextBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDetail = new CommonViewer.TextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.cboIsLand = new System.Windows.Forms.CheckBox();
            this.cboUnmodify = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtsort = new CommonViewer.TextBoxEx();
            this.ucDepartmentSelect1 = new BaseInfo.Viewer.UcDepartmentSelect();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel1.Controls.Add(this.cobType, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtCode, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDepartmentName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtDetail, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboIsLand, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboUnmodify, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtsort, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.ucDepartmentSelect1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 102F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(365, 362);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cobType
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cobType, 2);
            this.cobType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobType.FormattingEnabled = true;
            this.cobType.Items.AddRange(new object[] {
            "机务部门",
            "轮机部门",
            "甲板部门",
            "其它部门"});
            this.cobType.Location = new System.Drawing.Point(83, 81);
            this.cobType.Name = "cobType";
            this.cobType.Size = new System.Drawing.Size(279, 20);
            this.cobType.TabIndex = 76;
            // 
            // txtCode
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtCode, 2);
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Location = new System.Drawing.Point(83, 55);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(279, 21);
            this.txtCode.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 26);
            this.label5.TabIndex = 14;
            this.label5.Text = "部门编码";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "部门名称*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDepartmentName.Location = new System.Drawing.Point(83, 3);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Size = new System.Drawing.Size(176, 21);
            this.txtDepartmentName.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 53);
            this.label2.TabIndex = 1;
            this.label2.Text = "部门描述";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDetail
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtDetail, 2);
            this.txtDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetail.Location = new System.Drawing.Point(83, 133);
            this.txtDetail.MaxLength = 1000;
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.tableLayoutPanel1.SetRowSpan(this.txtDetail, 2);
            this.txtDetail.Size = new System.Drawing.Size(279, 124);
            this.txtDetail.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 26);
            this.label3.TabIndex = 1;
            this.label3.Text = "上级部门";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboIsLand
            // 
            this.cboIsLand.AutoSize = true;
            this.cboIsLand.Dock = System.Windows.Forms.DockStyle.Right;
            this.cboIsLand.ForeColor = System.Drawing.Color.Maroon;
            this.cboIsLand.Location = new System.Drawing.Point(290, 3);
            this.cboIsLand.Name = "cboIsLand";
            this.cboIsLand.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboIsLand.Size = new System.Drawing.Size(72, 20);
            this.cboIsLand.TabIndex = 16;
            this.cboIsLand.Text = "岸端部门";
            this.cboIsLand.UseVisualStyleBackColor = true;
            this.cboIsLand.CheckedChanged += new System.EventHandler(this.cboIsLand_CheckedChanged);
            // 
            // cboUnmodify
            // 
            this.cboUnmodify.AutoSize = true;
            this.cboUnmodify.Dock = System.Windows.Forms.DockStyle.Right;
            this.cboUnmodify.Enabled = false;
            this.cboUnmodify.ForeColor = System.Drawing.Color.Teal;
            this.cboUnmodify.Location = new System.Drawing.Point(278, 29);
            this.cboUnmodify.Name = "cboUnmodify";
            this.cboUnmodify.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboUnmodify.Size = new System.Drawing.Size(84, 20);
            this.cboUnmodify.TabIndex = 17;
            this.cboUnmodify.Text = "不允许修改";
            this.cboUnmodify.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 26);
            this.label4.TabIndex = 14;
            this.label4.Text = "排序号";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtsort
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtsort, 2);
            this.txtsort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtsort.Location = new System.Drawing.Point(83, 107);
            this.txtsort.Name = "txtsort";
            this.txtsort.Size = new System.Drawing.Size(279, 21);
            this.txtsort.TabIndex = 15;
            // 
            // ucDepartmentSelect1
            // 
            this.ucDepartmentSelect1.CanEdit = false;
            this.ucDepartmentSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDepartmentSelect1.DropDownWidth = 102;
            this.ucDepartmentSelect1.Location = new System.Drawing.Point(83, 29);
            this.ucDepartmentSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucDepartmentSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucDepartmentSelect1.Name = "ucDepartmentSelect1";
            this.ucDepartmentSelect1.NullValueShow = "";
            this.ucDepartmentSelect1.ShowButton = false;
            this.ucDepartmentSelect1.Size = new System.Drawing.Size(176, 20);
            this.ucDepartmentSelect1.TabIndex = 18;
            // 
            // label6
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.label6, 3);
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Crimson;
            this.label6.Location = new System.Drawing.Point(3, 260);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(5);
            this.label6.Size = new System.Drawing.Size(359, 102);
            this.label6.TabIndex = 19;
            this.label6.Text = "    说明:部门基本信息是系统中非常关键的表,其很多数据直接影响系统的运行,软件中对于有些部门采取了锁定,不允许用户对其名称和上下级关系进行修改.比如船舶上的甲" +
                "板部,轮机部等。";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 26);
            this.label7.TabIndex = 20;
            this.label7.Text = "部门类型";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UcDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UcDepartment";
            this.Size = new System.Drawing.Size(365, 362);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CommonViewer.TextBoxEx txtDepartmentName;
        private CommonViewer.TextBoxEx txtDetail;
        private System.Windows.Forms.Label label3;
        private CommonViewer.TextBoxEx txtCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cboIsLand;
        private System.Windows.Forms.CheckBox cboUnmodify;
        private System.Windows.Forms.Label label4;
        private CommonViewer.TextBoxEx txtsort;
        private UcDepartmentSelect ucDepartmentSelect1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cobType;
	}
}
