namespace ShipCertification.Viewer
{
    partial class UcShipCertDepart
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
            this.txtDepartCountry = new CommonViewer.TextBoxEx();
            this.location = new System.Windows.Forms.Label();
            this.txtDepartName = new CommonViewer.TextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtDepartCountry, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.location, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDepartName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(349, 88);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtDepartCountry
            // 
            this.txtDepartCountry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDepartCountry.Location = new System.Drawing.Point(127, 29);
            this.txtDepartCountry.Multiline = true;
            this.txtDepartCountry.Name = "txtDepartCountry";
            this.txtDepartCountry.Size = new System.Drawing.Size(219, 20);
            this.txtDepartCountry.TabIndex = 15;
            // 
            // location
            // 
            this.location.Dock = System.Windows.Forms.DockStyle.Fill;
            this.location.Location = new System.Drawing.Point(3, 0);
            this.location.Name = "location";
            this.location.Size = new System.Drawing.Size(118, 26);
            this.location.TabIndex = 3;
            this.location.Text = "机构名称或代码*";
            this.location.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDepartName
            // 
            this.txtDepartName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDepartName.Location = new System.Drawing.Point(127, 3);
            this.txtDepartName.Name = "txtDepartName";
            this.txtDepartName.Size = new System.Drawing.Size(219, 21);
            this.txtDepartName.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label1.Size = new System.Drawing.Size(118, 26);
            this.label1.TabIndex = 21;
            this.label1.Text = "所属国家或组织";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // UcShipCertDepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UcShipCertDepart";
            this.Size = new System.Drawing.Size(349, 88);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label location;
        private CommonViewer.TextBoxEx txtDepartName;
        private CommonViewer.TextBoxEx txtDepartCountry;
        private System.Windows.Forms.Label label1;
    }
}
