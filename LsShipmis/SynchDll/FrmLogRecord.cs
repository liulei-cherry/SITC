using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms; 

namespace SynchDll
{
    public partial class FrmLogRecord : Form
    {
        #region 窗体变量
        SynchDllService businessSync = new SynchDllService();
        #endregion

        #region 构造函数

        public FrmLogRecord()
        {
            InitializeComponent();
        }

        public FrmLogRecord(string logId, string fileName)
        {
            InitializeComponent();
            string record, errMessage;
            if (businessSync.GetSynchRecordContax(logId, out record, out errMessage))
            {
                txtRecord.Text = record;
            }
            else
            {
                txtRecord.Visible = false;
                MessageBox.Show("数据读取失败！");
            }
            lbFileName.Text = fileName;
            this.Text = fileName;
        }
        #endregion
    }
}
