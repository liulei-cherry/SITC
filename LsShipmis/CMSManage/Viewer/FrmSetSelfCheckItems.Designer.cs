namespace CMSManage.Viewer
{
    partial class FrmSetSelfCheckItems
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
            this.components = new System.ComponentModel.Container();
            this.gunterToolBar1 = new GunterControl.GunterToolBar();
            this.gunterBox1 = new GunterControl.ViewLayer.GunterBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // gunterToolBar1
            // 
            this.gunterToolBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.gunterToolBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunterToolBar1.Location = new System.Drawing.Point(0, 0);
            this.gunterToolBar1.Name = "gunterToolBar1";
            this.gunterToolBar1.Size = new System.Drawing.Size(1177, 53);
            this.gunterToolBar1.TabIndex = 1;
            // 
            // gunterBox1
            // 
            this.gunterBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gunterBox1.InitControl = false;
            this.gunterBox1.Location = new System.Drawing.Point(0, 53);
            this.gunterBox1.Name = "gunterBox1";
            this.gunterBox1.Size = new System.Drawing.Size(1177, 628);
            this.gunterBox1.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmSetSelfCheckItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 681);
            this.Controls.Add(this.gunterBox1);
            this.Controls.Add(this.gunterToolBar1);
            this.Name = "FrmSetSelfCheckItems";
            this.Text = "自查类项目时间设定";
            this.Load += new System.EventHandler(this.FrmSetSelfCheckItems_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GunterControl.GunterToolBar gunterToolBar1;
        private GunterControl.ViewLayer.GunterBox gunterBox1;
        private System.Windows.Forms.Timer timer1;
    }
}