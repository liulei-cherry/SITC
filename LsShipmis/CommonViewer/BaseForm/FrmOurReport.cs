using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using OfficeOperation;
using System.IO;
using System.Runtime.InteropServices;
using CommonViewer.BaseControl;
using CommonViewer.BaseForm;
namespace CommonViewer
{
    public partial class FrmOurReport : CommonViewer.BaseForm.FormBase
    {
        OperationExcel toOperExcel;
        List<OperationExcel> listToOperExcel;

        bool isOperating = false;
        private FrmOurReport()
        {
            InitializeComponent();
        }
        public FrmOurReport(string reportName, OperationExcel toOperExcel)
            : this()
        {
            this.buttonEx1.Text = reportName;
            this.toOperExcel = toOperExcel;
            listToOperExcel = new List<OperationExcel>();
            listToOperExcel.Add(toOperExcel);
        }
        public FrmOurReport(string reportName, List<OperationExcel> listToOperExcel)
            : this()
        {
            this.buttonEx1.Text = reportName;
            this.listToOperExcel = listToOperExcel;
            foreach (OperationExcel temp in listToOperExcel)
            {
                tsbAllPageName.Items.Add(temp.SheetName);
            }
            if (listToOperExcel.Count >= 1)
            {
                this.toOperExcel = listToOperExcel[0];
                tsbAllPageName.Text = toOperExcel.SheetName;
            } 
        }

        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            panel2.Focus();
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exporting()
        {
            if (!string.IsNullOrEmpty(saveFileDialog1.FileName) && listToOperExcel != null && listToOperExcel.Count > 0)
            {
                string err;
                foreach (OperationExcel temp in listToOperExcel)
                {
                    Application.DoEvents();
                    if (!temp.ExportToExcel(saveFileDialog1.FileName, true, out err))
                    {
                        MessageBoxEx.Show(err);
                        return;
                    }
                }
                WinExec("rundll32.exe shell32.dll,OpenAs_RunDLL " + saveFileDialog1.FileName, 5);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            isOperating = true;
            //首先选择一个文件路径,成功以后再进行导出操作.            
            if (SaveFileDialogEx.ShowDialog(saveFileDialog1) == DialogResult.Cancel) return;
            FrmBusy frm = new FrmBusy("正在处理形成Excel文件,请稍等!", exporting);
            frm.ShowDialog();
            isOperating = false;
        }

        [DllImport("kernel32.dll")]
        public static extern int WinExec(string exeName, int operType);
        int position;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (toOperExcel != null && !isOperating)
            {
                string err;

                if (!toOperExcel.ExportToOtherObject(e.Graphics, position, out err))
                {
                    e.Graphics.DrawString(err, new Font("宋体", 12), new SolidBrush(Color.Red), new RectangleF(0, 0, pictureBox1.Width, pictureBox1.Height));
                }
                else
                {
                    pictureBox1.Size = toOperExcel.GetSize + new Size(30, 30);
                }
            }
        }

        private void FrmOurReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            isOperating = true;
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            position = 1;
            bindingNavigatorPositionItem.Text = position.ToString();
            pictureBox1.Refresh();
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            if (position > 1)
            {
                position--;
                bindingNavigatorPositionItem.Text = position.ToString();
                pictureBox1.Refresh();
            }
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            if (position < toOperExcel.InsideObjectPageCount)
            {
                position++;
                bindingNavigatorPositionItem.Text = position.ToString();
                pictureBox1.Refresh();
            }
        }

        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            position = toOperExcel.InsideObjectPageCount;
            bindingNavigatorPositionItem.Text = position.ToString();
            pictureBox1.Refresh();
        }

        private void bindingNavigatorPositionItem_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(bindingNavigatorPositionItem.Text, out position))
            {
                bindingNavigatorPositionItem.Text = "1";
                pictureBox1.Refresh();
            }
        }

        private void FrmOurReport_Load(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            toOperExcel.PrepareToExportToOtherObject(g);
            g.Dispose();

            bindingNavigatorPositionItem.Text = "1";
            bindingNavigatorCountItem.Text = "/ {" + toOperExcel.InsideObjectPageCount + "}";
        }

        private void tsbAllPageName_DropDownClosed(object sender, EventArgs e)
        {
            if (toOperExcel != null && tsbAllPageName.Text == toOperExcel.SheetName) return;
            foreach (OperationExcel temp in listToOperExcel)
            {
                if (temp.SheetName == tsbAllPageName.Text)
                {
                    toOperExcel = temp;

                    break;
                }
            }
            bindingNavigatorMoveFirstItem_Click(null, null);
        }
    }
}
