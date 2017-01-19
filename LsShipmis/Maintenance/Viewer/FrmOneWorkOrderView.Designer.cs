namespace Maintenance.Viewer
{
    partial class FrmOneWorkOrderView
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
            this.ucWorkOrder1 = new Maintenance.Viewer.UcWorkOrder();
            this.SuspendLayout();
            // 
            // ucWorkOrder1
            // 
            this.ucWorkOrder1.BackColor = System.Drawing.Color.AliceBlue;
            this.ucWorkOrder1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucWorkOrder1.Location = new System.Drawing.Point(0, 0);
            this.ucWorkOrder1.Name = "ucWorkOrder1";
            this.ucWorkOrder1.Size = new System.Drawing.Size(747, 570);
            this.ucWorkOrder1.TabIndex = 0;
            this.ucWorkOrder1.TaskId = null;
            this.ucWorkOrder1.ThisWorkOrder = null;
            // 
            // FrmOneWorkOrderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 570);
            this.Controls.Add(this.ucWorkOrder1);
            this.Name = "FrmOneWorkOrderView";
            this.Text = "工单信息显示";
            this.ResumeLayout(false);

        }

        #endregion

        private UcWorkOrder ucWorkOrder1;
    }
}