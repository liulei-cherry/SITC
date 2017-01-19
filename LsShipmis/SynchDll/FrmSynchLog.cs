using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer;

namespace SynchDll
{
    public partial class FrmSynchLog : Form
    {
        #region 窗体变量
        SynchDllService businessSync = new SynchDllService();
        /// <summary>
        /// 能否查看同步明细.
        /// </summary>
        private bool isSuperStart = false;
        /// <summary>
        /// 同步日志ID
        /// </summary>
        private string logId = string.Empty;
        /// <summary>
        /// 同步文件名.
        /// </summary>
        private string fileName = string.Empty;
        #endregion

        #region 窗体单实例模型


        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmSynchLog instance = new FrmSynchLog();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSynchLog Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSynchLog.instance = new FrmSynchLog();
                }

                return FrmSynchLog.instance;
            }
            set { instance = value; }
        }

        #endregion

        #region 构造函数

        public FrmSynchLog()
        {
            InitializeComponent();
        }
        public FrmSynchLog(bool isSuperStart)
        {
            InitializeComponent();
            this.isSuperStart = isSuperStart;
        }
        #endregion

        #region 窗体载入
        private void FrmSynchLog_Load(object sender, EventArgs e)
        {
            btnViewSyncDetail.Visible = this.isSuperStart;
            //1载入Combox数据.
            LoadComboxData();
            //2.载入主表数据.
            LoadData();
        }
        /// <summary>
        /// 载入同步日志数据和样式.
        /// </summary>
        private void LoadData()
        {

            string startDate = dtpStartDate.Value.ToShortDateString();  //起始日期.
            string endDate = dtpEndDate.Value.ToShortDateString();      //结束日期.
            string synchDirect = string.Empty;
            string synchStatus = string.Empty;

            if (cbSynchDirect.SelectedValue == null || cbSynchDirect.SelectedValue.ToString() == "2")
                synchDirect = "2";
            else
                synchDirect = cbSynchDirect.SelectedValue.ToString();

            if (cbSynchStatus.SelectedValue == null || cbSynchStatus.SelectedValue.ToString() == "1")
                synchStatus = "1";
            else
                synchStatus = cbSynchStatus.SelectedValue.ToString();
            DataTable dtSynchMain;
            string errMessage;

            if (businessSync.GetSynchMainList(synchDirect, synchStatus, startDate, endDate, CommonOperation.ConstParameter.IsLandVersion, out dtSynchMain, out errMessage))
            {
                dgvSyncMainData.DataSource = dtSynchMain;
                UcDataGridView dgv = dgvSyncMainData;
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("SYNCH_FILE_NAME", "同步文件名称");
                dic.Add("OPEARTION_SUCCESSFUL", "同步状态");
                dic.Add("IS_SENDING_DATA", "同步发起方");
                dgv.SetDgvGridColumns(dic);
                dgv.LoadGridView("FrmSynchLog.dgvSyncMainData");
            }
            else
                MessageBox.Show(errMessage);

        }

        private void LoadComboxData()
        {
            #region 同步方向数据绑定
            cbSynchDirect.DisplayMember = "State";
            cbSynchDirect.ValueMember = "Id";
            DataTable dtbChkState = new DataTable();
            dtbChkState.Columns.Add("Id", typeof(string));
            dtbChkState.Columns.Add("State", typeof(string));
            DataRow row0 = dtbChkState.NewRow();
            row0["Id"] = "2";
            row0["State"] = "全部";
            dtbChkState.Rows.Add(row0);

            DataRow row1 = dtbChkState.NewRow();
            row1["Id"] = "1";
            row1["State"] = "由我发起";
            dtbChkState.Rows.Add(row1);

            DataRow row2 = dtbChkState.NewRow();
            row2["Id"] = "0";
            row2["State"] = "发送给我";
            dtbChkState.Rows.Add(row2);
            cbSynchDirect.DataSource = dtbChkState;
            cbSynchDirect.SelectedIndex = 0;
            #endregion

            #region 同步状态数据绑定


            cbSynchStatus.DisplayMember = "State";
            cbSynchStatus.ValueMember = "Id";
            DataTable dtComboxStatus = new DataTable();
            dtComboxStatus.Columns.Add("Id", typeof(string));
            dtComboxStatus.Columns.Add("State", typeof(string));
            DataRow dr1 = dtComboxStatus.NewRow();
            DataRow dr3 = dtComboxStatus.NewRow();
            dr3["Id"] = "2";
            dr3["State"] = "全部";
            dtComboxStatus.Rows.Add(dr3);

            dr1["Id"] = "1";
            dr1["State"] = "成功";
            dtComboxStatus.Rows.Add(dr1);

            DataRow dr2 = dtComboxStatus.NewRow();
            dr2["Id"] = "0";
            dr2["State"] = "失败";
            dtComboxStatus.Rows.Add(dr2);

            cbSynchStatus.DataSource = dtComboxStatus;
            cbSynchStatus.SelectedIndex = 0;
            #endregion

            #region 时间段控制

            dtpStartDate.Value = DateTime.Now.AddDays(-7);
            #endregion
        }
        #endregion

        #region 窗体事件

        private void dgvSyncMainData_SelectedChanged(int rowNumber)
        {
            if (dgvSyncMainData.DataSource == null || dgvSyncMainData.Rows.Count == 0) return;

            fileName = Convert.ToString(dgvSyncMainData.Rows[rowNumber].Cells["SYNCH_FILE_NAME"].Value);
            if (String.IsNullOrEmpty(fileName)) return;
            LoadSyncDetailData(fileName);
        }

        private void dgvSyncDetailData_SelectedChanged(int rowNumber)
        {


        }
        private void dgvSyncDetailData_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (isSuperStart)
            {
                if (dgvSyncDetailData.CurrentRow == null)
                {
                    MessageBox.Show("未选中任何行!");
                    return;
                }
                LoadSynchRecordContax();
            }
        }
        private void btnViewSyncDetail_Click(object sender, EventArgs e)
        {
            if (isSuperStart)
            {
                LoadSynchRecordContax();
            }
        }

        private void FrmSynchLog_FormClosing(object sender, FormClosingEventArgs e)
        {           
            //instance = null;    //释放窗体实例变量.
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbSynchDirect_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbSynchStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void dtpEndDate_CloseUp(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtpStartDate_CloseUp(object sender, EventArgs e)
        {
            LoadData();
        }
        #endregion

        #region 窗体方法
        protected void LoadSyncDetailData(string fileName)
        {
            DataTable dtSynchDetail;
            string errMessage;
            if (businessSync.GetSynchDetailList(fileName, out dtSynchDetail, out errMessage))
            {
                dgvSyncDetailData.DataSource = dtSynchDetail;
                UcDataGridView dgv = dgvSyncDetailData;
                Dictionary<string, string> dic = new Dictionary<string, string>();

                dic.Add("SENDING_TIME", "同步时间");
                dic.Add("LOG_TYPE", "文件类型");
                dic.Add("FILE_SIZE", "文件大小");
                dic.Add("DATA_INFO", "文件描述");
                dic.Add("MORE_DETAILS", "备注");
                dic.Add("ROW_COUNT", "影响数据行数");
                dic.Add("SYNCH_DATA_TYPE", "处理状态");
                dgv.SetDgvGridColumns(dic);
                //dgv.LoadGridView("FrmSynchLog.dgvSyncDetailData");
            }
            else
                MessageBox.Show(errMessage);
        }

        protected void LoadSyncTableData(string logId)
        {
            DataTable dtSynchTable;
            string errMessage;
            if (businessSync.GetSynchTableList(logId, out dtSynchTable, out errMessage))
            {
                dgvSynchTableData.DataSource = dtSynchTable;
                UcDataGridView dgv = dgvSynchTableData;
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("TABLE_NAME", "表名");
                dic.Add("ROWS_COUNT", "影响记录数");
                dgv.SetDgvGridColumns(dic);
            }
            else
                MessageBox.Show(errMessage);
        }

        protected void LoadSynchRecordContax()
        {
            FrmLogRecord frmLogRecord = new FrmLogRecord(logId, fileName);
            frmLogRecord.ShowInTaskbar = false;
            frmLogRecord.StartPosition = FormStartPosition.CenterParent;
            frmLogRecord.ShowDialog();
        }
        #endregion

        private void dgvSyncDetailData_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSyncDetailData.DataSource == null || dgvSyncDetailData.Rows.Count == 0) return;

            logId = Convert.ToString(dgvSyncDetailData.Rows[e.RowIndex].Cells["LOG_ID"].Value);
            if (String.IsNullOrEmpty(logId)) return;
            LoadSyncTableData(logId);
        }

        #region 注册系统热键
        private void FrmSynchLog_Activated(object sender, EventArgs e)
        {
            //注册Ctrl+L为配置服务热键

            HotKey.RegisterHotKey(Handle, 120, HotKey.KeyModifiers.Ctrl, Keys.L);
        }

        private void FrmSynchLog_Deactivate(object sender, EventArgs e)
        {
            HotKey.UnregisterHotKey(Handle, 120);
        }



        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    this.Close();
                    break;
            }
            base.WndProc(ref m);
        }
        #endregion

    }
}
