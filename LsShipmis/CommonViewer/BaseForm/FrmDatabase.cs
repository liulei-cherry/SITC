using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer.BaseControl;
using CommonOperation.Functions;
using CommonOperation.Interfaces;

namespace CommonViewer.BaseForm
{
    public partial class FrmDatabase : CommonViewer.BaseForm.FormBase
    {
        public FrmDatabase()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = OpenFileDialogEx.ShowDialog(openFileDialog);
            if (result == DialogResult.OK)
            {
                richTextBox.Clear();
                richTextBox.LoadFile(openFileDialog.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string sql = richTextBox.Text;
            string err = "";
            if (!string.IsNullOrEmpty(sql))
            {
                List<string> listSql = new List<string>();
                string[] sqls = sql.Split('\n');
                StringBuilder nowSql = new StringBuilder();
                for (int i = 0; i < sqls.Length; i++)
                {
                    sqls[i] = sqls[i].Trim();
                    if (sqls[i].Length == 0)
                        continue;
                    if (sqls[i].ToUpper() == "GO")
                    {
                        listSql.Add(nowSql.ToString());
                        nowSql = new StringBuilder();
                    }
                    else if (!string.IsNullOrEmpty(sqls[i]))
                        nowSql.AppendLine(sqls[i]);
                }
                if (nowSql.ToString().Length > 0)
                {
                    listSql.Add(nowSql.ToString());
                }
                IDBAccess db = InterfaceInstantiation.NewADbAccess();
                if (db.ExecSql(listSql, out err))
                {
                    MessageBoxEx.Show("执行成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    richTextBox.Clear();
                    return;
                }

            }
            MessageBoxEx.Show(err, "执行失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}