using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Repair.DataObject;
using CommonOperation.Functions;
using Repair.Services;
using CommonViewer.BaseControl;
using BaseInfo.DataAccess;
using BaseInfo.Objects;

namespace Repair.Viewer
{
    public partial class FrmFollowDelegateEdit : CommonViewer.BaseForm.FormBase
    {
        private ShipRepairProject srp = null;
        private ShipInfo shipInfo = null;
        public FrmFollowDelegateEdit(string projectID)
        {
            InitializeComponent();
            string err;
            srp = ShipRepairProjectService.Instance.getObject(projectID, out err);
            dtpREPAIRDATE.Value = DateTime.Now;

            shipInfo = ShipInfoService.Instance.getObject(srp.SHIP_ID, out err);
        }
        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmFollowDelegateEdit_Load(object sender, EventArgs e)
        {
            txtShip.Text = shipInfo.SHIP_NAME;
            txtARRANGEDPERSON.Text = CommonOperation.ConstParameter.UserName;
        }
        /// <summary>
        /// 表单验证.
        /// </summary>
        /// <returns></returns>
        private bool CheckForm()
        {
            if (string.IsNullOrEmpty(txtARRANGEDPERSON.Text.Trim()))
            {
                MessageBoxEx.Show("安排人不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(ucRepairPortSelect1.Text.Trim()))
            {
                MessageBoxEx.Show("修理港口不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(ucManufacturerSelect1.GetId()))
            {
                MessageBoxEx.Show("服务商不能为空");
                return false;
            }
            return true;
        }
        /// <summary>
        /// 保存.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string err = "";
            if (!CheckForm())
                return;
            ShipRepairEvent sre = new ShipRepairEvent();
            sre.REPAIRCODE = shipInfo.SHIP_CODE + DateTime.Now.ToString("yyyyMM") + ShipRepairEventService.Instance.CreateSerialNumber();
            sre.REPAIRPORT = ucRepairPortSelect1.Text.Trim();
            sre.SHIP_ID = shipInfo.SHIP_ID;
            sre.SERVICEPROVIDER = ucManufacturerSelect1.GetId();
            sre.REPAIRDATE = dtpREPAIRDATE.Value;
            sre.ARRANGEDPERSON = txtARRANGEDPERSON.Text.Trim();
            sre.REMARK = txtREMARK.Text.Trim();
            sre.ARRANGED = 1;

            srp.PROJECTSTATE = 8;
            srp.SERVICEPROVIDER = ucManufacturerSelect1.GetId();

            ShipRunningRepairRelation obj = new ShipRunningRepairRelation();
            obj.PROJECTID = srp.PROJECTID;
            obj.STATE = 3;
            obj.SORTNO = 1;

            using (TransactionClass tc = new TransactionClass())
            {
                string repairid;
                ShipRepairEventService.Instance.InsertUnit(sre, out repairid, out err);
                obj.REPAIRID = repairid;
                ShipRepairProjectService.Instance.saveUnit(srp, out err);
                ShipRunningRepairRelationService.Instance.saveUnit(obj, out err);
                tc.CommitTransaction();
            }
            if (string.IsNullOrEmpty(err))
            {
                MessageBoxEx.Show("操作成功！", "提示");
            }
            else
            {
                MessageBoxEx.Show(err, "操作失败");
            }
            this.Close();
        }
        /// <summary>
        /// 关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
