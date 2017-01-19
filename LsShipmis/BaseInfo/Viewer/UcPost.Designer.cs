namespace BaseInfo.Viewer
{
    partial class UcPost
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
            this.label7 = new System.Windows.Forms.Label();
            this.cboIsHighLevelShipMan = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPostName = new CommonViewer.TextBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new CommonViewer.TextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLevel = new CommonViewer.TextBoxEx();
            this.cboIsLeader = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboForLand = new System.Windows.Forms.CheckBox();
            this.txtDetail = new CommonViewer.TextBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.ucDepartmentSelect1 = new BaseInfo.Viewer.UcDepartmentSelect();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPostType = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.cboIsHighLevelShipMan, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPostName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtCode, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtLevel, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cboIsLeader, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.cboForLand, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDetail, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ucDepartmentSelect1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbPostType, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(435, 315);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label7, 3);
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(3, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(429, 98);
            this.label7.TabIndex = 16;
            this.label7.Text = "是否高级岗位(船舶专有): 用于登录用户的岗位定义,通常与船上所说的高级船员等同;\r\n特殊情况下,如果有其他非高级船员的人员希望用软件管理其物资或者保养等,也可以" +
    "为其岗位设置为高级岗位,比如科考船的实验室主任,调研部组员等.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboIsHighLevelShipMan
            // 
            this.cboIsHighLevelShipMan.AutoSize = true;
            this.cboIsHighLevelShipMan.Dock = System.Windows.Forms.DockStyle.Right;
            this.cboIsHighLevelShipMan.ForeColor = System.Drawing.Color.Black;
            this.cboIsHighLevelShipMan.Location = new System.Drawing.Point(336, 55);
            this.cboIsHighLevelShipMan.Name = "cboIsHighLevelShipMan";
            this.cboIsHighLevelShipMan.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboIsHighLevelShipMan.Size = new System.Drawing.Size(96, 20);
            this.cboIsHighLevelShipMan.TabIndex = 15;
            this.cboIsHighLevelShipMan.Text = "是否高级岗位";
            this.cboIsHighLevelShipMan.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(18, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "岗位名称*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPostName
            // 
            this.txtPostName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPostName.Location = new System.Drawing.Point(83, 3);
            this.txtPostName.Name = "txtPostName";
            this.txtPostName.Size = new System.Drawing.Size(226, 21);
            this.txtPostName.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(18, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "岗位编号 ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCode
            // 
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Location = new System.Drawing.Point(83, 29);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(226, 21);
            this.txtCode.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(18, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 26);
            this.label3.TabIndex = 13;
            this.label3.Text = "岗位级别*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLevel
            // 
            this.txtLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLevel.Location = new System.Drawing.Point(83, 81);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(226, 21);
            this.txtLevel.TabIndex = 11;
            // 
            // cboIsLeader
            // 
            this.cboIsLeader.AutoSize = true;
            this.cboIsLeader.Dock = System.Windows.Forms.DockStyle.Right;
            this.cboIsLeader.ForeColor = System.Drawing.Color.Maroon;
            this.cboIsLeader.Location = new System.Drawing.Point(354, 3);
            this.cboIsLeader.Name = "cboIsLeader";
            this.cboIsLeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboIsLeader.Size = new System.Drawing.Size(78, 20);
            this.cboIsLeader.TabIndex = 12;
            this.cboIsLeader.Text = "部门领导*";
            this.cboIsLeader.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(315, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 26);
            this.label4.TabIndex = 13;
            this.label4.Text = "此列同时用于排序";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Location = new System.Drawing.Point(18, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 63);
            this.label5.TabIndex = 13;
            this.label5.Text = "岗位说明 ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboForLand
            // 
            this.cboForLand.AutoSize = true;
            this.cboForLand.Dock = System.Windows.Forms.DockStyle.Right;
            this.cboForLand.ForeColor = System.Drawing.Color.Maroon;
            this.cboForLand.Location = new System.Drawing.Point(330, 29);
            this.cboForLand.Name = "cboForLand";
            this.cboForLand.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboForLand.Size = new System.Drawing.Size(102, 20);
            this.cboForLand.TabIndex = 12;
            this.cboForLand.Text = "是否岸端岗位*";
            this.cboForLand.UseVisualStyleBackColor = true;
            this.cboForLand.CheckedChanged += new System.EventHandler(this.cboForLand_CheckedChanged);
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
            this.txtDetail.Size = new System.Drawing.Size(349, 81);
            this.txtDetail.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(18, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 26);
            this.label6.TabIndex = 13;
            this.label6.Text = "所属部门*";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucDepartmentSelect1
            // 
            this.ucDepartmentSelect1.CanEdit = false;
            this.ucDepartmentSelect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDepartmentSelect1.DropDownWidth = 226;
            this.ucDepartmentSelect1.Location = new System.Drawing.Point(83, 55);
            this.ucDepartmentSelect1.MaximumSize = new System.Drawing.Size(2000, 20);
            this.ucDepartmentSelect1.MinimumSize = new System.Drawing.Size(60, 20);
            this.ucDepartmentSelect1.Name = "ucDepartmentSelect1";
            this.ucDepartmentSelect1.NullValueShow = "";
            this.ucDepartmentSelect1.ShowButton = false;
            this.ucDepartmentSelect1.Size = new System.Drawing.Size(226, 20);
            this.ucDepartmentSelect1.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Right;
            this.label8.ForeColor = System.Drawing.Color.Maroon;
            this.label8.Location = new System.Drawing.Point(24, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 26);
            this.label8.TabIndex = 13;
            this.label8.Text = "岗位类型";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbPostType
            // 
            this.cmbPostType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPostType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPostType.FormattingEnabled = true;
            this.cmbPostType.Items.AddRange(new object[] {
            "其它岗位",
            "船长岗位",
            "轮机长岗位",
            "大副岗位",
            "机务主管岗位",
            "机务经理岗位",
            "机务总经理岗位",
            "总经理岗位",
            "机务财务岗位",
            "财务主管岗位",
            "财务经理岗位"});
            this.cmbPostType.Location = new System.Drawing.Point(83, 107);
            this.cmbPostType.Name = "cmbPostType";
            this.cmbPostType.Size = new System.Drawing.Size(226, 20);
            this.cmbPostType.TabIndex = 17;
            // 
            // UcPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UcPost";
            this.Size = new System.Drawing.Size(435, 315);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CommonViewer.TextBoxEx txtPostName;
        private CommonViewer.TextBoxEx txtCode;
        private System.Windows.Forms.CheckBox cboIsLeader;
        private System.Windows.Forms.Label label3;
        private CommonViewer.TextBoxEx txtLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cboForLand;
        private CommonViewer.TextBoxEx txtDetail;
        private System.Windows.Forms.Label label6;
        private UcDepartmentSelect ucDepartmentSelect1;
        private System.Windows.Forms.CheckBox cboIsHighLevelShipMan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbPostType;
	}
}
