namespace FileOperation.Forms
{
    partial class frmFileBoundShow
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
            this.ucFile = new FileOperation.Forms.UCFile();
            this.SuspendLayout();
            // 
            // ucFile
            // 
            this.ucFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFile.Location = new System.Drawing.Point(0, 0);
            this.ucFile.Name = "ucFile";
            this.ucFile.Size = new System.Drawing.Size(616, 478);
            this.ucFile.TabIndex = 0;
            // 
            // frmFileBoundShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 478);
            this.Controls.Add(this.ucFile);
            this.Name = "frmFileBoundShow";
            this.Text = "信息绑定窗口";
            this.Load += new System.EventHandler(this.frmFileBoundShow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FileOperation.Forms.UCFile ucFile;
    }
}