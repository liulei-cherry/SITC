namespace SynchDll
{
partial class FrmLogRecord
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
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogRecord));
this.txtRecord = new System.Windows.Forms.TextBox();
this.lbFileName = new System.Windows.Forms.Label();
this.SuspendLayout();
//
// txtRecord
//
this.txtRecord.Location = new System.Drawing.Point(38, 61);
this.txtRecord.Multiline = true;
this.txtRecord.Name = "txtRecord";
this.txtRecord.ReadOnly = true;
this.txtRecord.Size = new System.Drawing.Size(428, 199);
this.txtRecord.TabIndex = 0;
//
// lbFileName
//
this.lbFileName.AutoSize = true;
this.lbFileName.Location = new System.Drawing.Point(38, 22);
this.lbFileName.Name = "lbFileName";
this.lbFileName.Size = new System.Drawing.Size(41, 12);
this.lbFileName.TabIndex = 1;
this.lbFileName.Text = "label1";
//
// FrmLogRecord
//
this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
this.ClientSize = new System.Drawing.Size(507, 295);
this.Controls.Add(this.lbFileName);
this.Controls.Add(this.txtRecord);
this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
this.MaximizeBox = false;
this.MinimizeBox = false;
this.Name = "FrmLogRecord";
this.ShowInTaskbar = false;
this.Text = "FrmLogRecord";
this.ResumeLayout(false);
this.PerformLayout();

}

#endregion

private System.Windows.Forms.TextBox txtRecord;
private System.Windows.Forms.Label lbFileName;
}
}