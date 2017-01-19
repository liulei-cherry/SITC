using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer;
using Cost.Services;
using Cost.DataObject;
using CommonViewer.BaseControl;
using CommonOperation.Interfaces;
using Repair.DataObject;
using Repair.Services;
using CommonOperation.Functions;
using FileOperation;
using FileOperationBase.Services;
using CommonOperation.Enum;
using FileOperationBase.FileServices;
using BaseInfo.Objects;
using BaseInfo.DataAccess;

namespace Repair.Viewer
{
    public partial class FrmDockRepairRecordEdit : CommonViewer.BaseForm.FormBase
    {
        /// <summary>
        /// 当前对象
        /// </summary>
        public RepairDockRepair currentObj = null;
        /// <summary>
        /// 0=添加;1=修改
        /// </summary>
        public int functionCode = 0;
        public FrmDockRepairRecordEdit()
        {
            InitializeComponent();
            functionCode = 0;
        }
        public FrmDockRepairRecordEdit(RepairDockRepair obj)
        {
            InitializeComponent();
            currentObj = obj;
            functionCode = 1;
        }
        /// <summary>
        /// 窗体加载时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDockRepairSummarize_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(false, true);
            if (functionCode == 0)
            {
                currentObj = new RepairDockRepair();
                currentObj.SHIP_ID = ucShipSelect1.GetId();
                currentObj.REPAIR_ANNUAL = DateTime.Now.Year.ToString();
            }
            ucShipSelect1.SelectedId(currentObj.SHIP_ID);
            dtpAnnual.Value = new DateTime(Convert.ToInt32(currentObj.REPAIR_ANNUAL), 1, 1);
            txtRemark.Text = currentObj.REMARK;
        }
        /// <summary>
        /// 保存操作.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (functionCode == 0)
            {
                DataTable dt = RepairDockRepairService.Instance.GetInfo(ucShipSelect1.GetId(), dtpAnnual.Value.Year.ToString());
                if (dt.Rows.Count > 0)
                {
                    MessageBoxEx.Show("已经存在" + ucShipSelect1.GetText() + "/" + dtpAnnual.Value.Year.ToString() + "年度厂修记录");
                    return;
                }
            }
            currentObj.SHIP_ID = ucShipSelect1.GetId();
            currentObj.REPAIR_ANNUAL = dtpAnnual.Value.Year.ToString();
            currentObj.REMARK = txtRemark.Text.Trim();
            currentObj.Update();
            MessageBoxEx.Show("操作成功");
            this.Close();
        }
        /// <summary>
        /// 关闭按钮.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
