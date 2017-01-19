namespace Maintenance.Viewer
{
    partial class FrmEquipmentWorkInfoAddEdit
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ucWorkInfo = new Maintenance.Viewer.UcWorkInfo();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(532, 531);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(451, 531);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ucWorkInfo
            // 
            this.ucWorkInfo.BackColor = System.Drawing.Color.AliceBlue;
            this.ucWorkInfo.Component_unit = null;
            this.ucWorkInfo.Location = new System.Drawing.Point(12, 12);
            this.ucWorkInfo.Name = "ucWorkInfo";
            this.ucWorkInfo.Size = new System.Drawing.Size(600, 506);
            this.ucWorkInfo.TabIndex = 0;
            this.ucWorkInfo.WorkInfo = null;
            // 
            // FrmEquipmentWorkInfoAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(619, 566);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucWorkInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEquipmentWorkInfoAddEdit";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "工作信息详细内容";
            this.Load += new System.EventHandler(this.FrmEquipmentWorkInfoAddEdit_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UcWorkInfo ucWorkInfo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;

    }
}