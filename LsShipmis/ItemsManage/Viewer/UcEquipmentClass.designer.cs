namespace ItemsManage.Viewer
{
    partial class UcEquipmentClass
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtSub = new CommonViewer.TextBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new CommonViewer.TextBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDetail = new CommonViewer.TextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.rbnType2 = new System.Windows.Forms.RadioButton();
            this.rbnType1 = new System.Windows.Forms.RadioButton();
            this.rbnType3 = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCode = new CommonViewer.TextBoxEx();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtCode, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSub, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtDetail, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(365, 362);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtSub
            // 
            this.txtSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSub.Location = new System.Drawing.Point(83, 63);
            this.txtSub.Name = "txtSub";
            this.txtSub.ReadOnly = true;
            this.txtSub.Size = new System.Drawing.Size(279, 21);
            this.txtSub.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 30);
            this.label5.TabIndex = 14;
            this.label5.Text = "分类类型";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "分类名称*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(83, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(279, 21);
            this.txtName.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 53);
            this.label2.TabIndex = 1;
            this.label2.Text = "分类描述";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDetail
            // 
            this.txtDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDetail.Location = new System.Drawing.Point(83, 123);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.tableLayoutPanel1.SetRowSpan(this.txtDetail, 2);
            this.txtDetail.Size = new System.Drawing.Size(279, 236);
            this.txtDetail.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 30);
            this.label3.TabIndex = 1;
            this.label3.Text = "上级分类";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rbnType2
            // 
            this.rbnType2.AutoSize = true;
            this.rbnType2.Location = new System.Drawing.Point(56, 3);
            this.rbnType2.Name = "rbnType2";
            this.rbnType2.Size = new System.Drawing.Size(47, 16);
            this.rbnType2.TabIndex = 1;
            this.rbnType2.TabStop = true;
            this.rbnType2.Text = "系统";
            this.rbnType2.UseVisualStyleBackColor = true;
            // 
            // rbnType1
            // 
            this.rbnType1.AutoSize = true;
            this.rbnType1.Location = new System.Drawing.Point(3, 3);
            this.rbnType1.Name = "rbnType1";
            this.rbnType1.Size = new System.Drawing.Size(47, 16);
            this.rbnType1.TabIndex = 0;
            this.rbnType1.TabStop = true;
            this.rbnType1.Text = "部门";
            this.rbnType1.UseVisualStyleBackColor = true;
            // 
            // rbnType3
            // 
            this.rbnType3.AutoSize = true;
            this.rbnType3.Location = new System.Drawing.Point(109, 3);
            this.rbnType3.Name = "rbnType3";
            this.rbnType3.Size = new System.Drawing.Size(71, 16);
            this.rbnType3.TabIndex = 2;
            this.rbnType3.TabStop = true;
            this.rbnType3.Text = "设备类型";
            this.rbnType3.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.rbnType1);
            this.flowLayoutPanel1.Controls.Add(this.rbnType2);
            this.flowLayoutPanel1.Controls.Add(this.rbnType3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(83, 93);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(279, 24);
            this.flowLayoutPanel1.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 30);
            this.label6.TabIndex = 20;
            this.label6.Text = "分类代码";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCode
            // 
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Location = new System.Drawing.Point(83, 33);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(279, 21);
            this.txtCode.TabIndex = 21;
            // 
            // UcEquipmentClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UcEquipmentClass";
            this.Size = new System.Drawing.Size(365, 362);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CommonViewer.TextBoxEx txtName;
        private CommonViewer.TextBoxEx txtDetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private CommonViewer.TextBoxEx txtSub;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton rbnType1;
        private System.Windows.Forms.RadioButton rbnType2;
        private System.Windows.Forms.RadioButton rbnType3;
        private CommonViewer.TextBoxEx txtCode;
        private System.Windows.Forms.Label label6;
        //    private UcDepartmentSelect ucDepartmentSelect1;
	}
}
