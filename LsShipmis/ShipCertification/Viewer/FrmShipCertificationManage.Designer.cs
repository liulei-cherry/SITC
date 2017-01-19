namespace ShipCertification.Viewer
{
    partial class FrmShipCertificationManage
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
            this.gunterToolBar1 = new ShipCertification.Viewer.ShipCertGunterToolBar();
            this.gunterBox1 = new GunterControl.ViewLayer.GunterBox();
            this.SuspendLayout();
            // 
            // gunterToolBar1
            // 
            this.gunterToolBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.gunterToolBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunterToolBar1.Location = new System.Drawing.Point(0, 0);
            this.gunterToolBar1.Name = "gunterToolBar1";
            this.gunterToolBar1.Size = new System.Drawing.Size(806, 54);
            this.gunterToolBar1.TabIndex = 0;
            // 
            // gunterBox1
            // 
            this.gunterBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunterBox1.InitControl = false;
            this.gunterBox1.Location = new System.Drawing.Point(0, 54);
            this.gunterBox1.Name = "gunterBox1";
            this.gunterBox1.Size = new System.Drawing.Size(806, 442);
            this.gunterBox1.TabIndex = 1;
            // 
            // FrmShipCertificationManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(806, 496);
            this.Controls.Add(this.gunterBox1);
            this.Controls.Add(this.gunterToolBar1);
            this.Name = "FrmShipCertificationManage";
            this.Text = "船舶证书管理";
            this.Load += new System.EventHandler(this.FrmShipCertificationManage_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmShipCertificationManage_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private ShipCertGunterToolBar gunterToolBar1;
        private GunterControl.ViewLayer.GunterBox gunterBox1;
    }
}
