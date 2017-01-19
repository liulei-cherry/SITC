using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Repair.Services;
using CommonViewer;
using CommonViewer.BaseControl;
using CommonOperation.Functions;
using Repair.DataObject;
using BaseInfo.DataAccess;
using BaseInfo.Objects;

namespace Repair.Viewer
{
    public partial class FrmRepairDelegateEdit : CommonViewer.BaseForm.FormBase
    {
        private ShipRepairEvent sre = null;
        public FrmRepairDelegateEdit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parmRepairid"></param>
        public FrmRepairDelegateEdit(string parmRepairid)
        {
            InitializeComponent();
            repairid = parmRepairid;
        }
        /// <summary>
        /// 船舶ID
        /// </summary>
        private string shipID = "";
        /// <summary>
        /// 参数传过来的修理委托ID 不为空表示维护.
        /// </summary>
        private string repairid = "";
        /// <summary>
        /// 未委托申请当前选择.
        /// </summary>
        private int lastApplyRowNumber = 0;
        /// <summary>
        /// 委托详细当前选择.
        /// </summary>
        private int lastDetailRowNumber = 0;
        /// <summary>
        /// 记录添加的ID
        /// </summary>
        private List<string> addList = new List<string>();
        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRepairDelegateEdit_Load(object sender, EventArgs e)
        {
            ucManufacturerSelect1.ChangeMode(true, true, false, "");
            
            ucShipSelect1.ChangeSelectedState(false, true);
            InitializeControl();
        }
        /// <summary>
        /// 初始化控件.
        /// </summary>
        private void InitializeControl()
        {
            string err;
            dtpREPAIRDATE.Value = DateTime.Now;
            //是维护.
            if (!string.IsNullOrEmpty(repairid))
            {
                DataTable dtsrr = ShipRunningRepairRelationService.Instance.GetInfo(null, repairid, "1", out err);
                if (dtsrr.Rows.Count > 0)
                {
                    ucShipSelect1.Enabled = false;
                    ucRepairPortSelect1.Enabled = false;
                    ucManufacturerSelect1.Enabled = false;
                    dtpREPAIRDATE.Enabled = false;
                    btnSave.Visible = false;
                }
                DataTable dtbDetail = ShipRepairProjectService.Instance.GetDelegateOperation(repairid, null, null);
                dgvDetail.DataSource = dtbDetail;
                sre = ShipRepairEventService.Instance.getObject(repairid, out err);
                ucRepairPortSelect1.SelectedText(sre.REPAIRPORT);
                shipID = sre.SHIP_ID;
                ucShipSelect1.SelectedId(sre.SHIP_ID);
                ucManufacturerSelect1.SelectedId(sre.SERVICEPROVIDER);
                dtpREPAIRDATE.Value = sre.REPAIRDATE;
                txtARRANGEDPERSON.Text = sre.ARRANGEDPERSON;
                txtREMARK.Text = sre.REMARK;
            }
            else
            {
                txtARRANGEDPERSON.Text = CommonOperation.ConstParameter.UserName;
                DataTable dtbDetail = ShipRepairProjectService.Instance.GetDelegateOperation("---", null, null);
                dgvDetail.DataSource = dtbDetail;
                sre = new ShipRepairEvent();
            }
            setDetailDataGridView();
            this.setApplyBindingSource(shipID);
            this.setApplyDataGridView();
        }
        /// <summary>
        /// 设置修理项目信息的bindingSource数据源，每次查询的都是指定船名的修理项目信息。.
        /// </summary>
        private void setApplyBindingSource(string shipID)
        {
            DataTable dtbApply;
            if (!string.IsNullOrEmpty(shipID))
                //可以委托,并没有被绑定.
                dtbApply = ShipRepairProjectService.Instance.GetDelegateOperation(null, shipID, "7");
            else
                //只是为了取得DataTable列格式,左右倒的时候用.
                dtbApply = ShipRepairProjectService.Instance.GetDelegateOperation(null, "---", "7");
            dgvApply.DataSource = dtbApply;
        }
        /// <summary>
        ///  设置修理项目信息网格控件dtbDelegate的隐藏列与显示标题.
        /// </summary>
        private void setApplyDataGridView()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("SHIP_NAME", "船舶");
            dic.Add("PROJECTNAME", "修理项目名称");
            dic.Add("PROJECTDETAIL", "修理项目详细");
            dic.Add("APPLICANT", "申请人");
            dic.Add("HEADSHIP_NAME", "申请人岗位");
            dic.Add("APPLYDATE", "申请日期");
            dic.Add("APPLYCOMPLETEDATE", "期望完成日期");
            dic.Add("RUNNINGORDOCK_NAME", "航修或坞修");
            dic.Add("COMP_CHINESE_NAME", "修理设备");
            dic.Add("NODE_NAME", "修理科目");
            dic.Add("AFFIRMANT", "申请最终确认人");
            dic.Add("REMARK", "备注");
            dgvApply.SetDgvGridColumns(dic);
            dgvApply.LoadGridView("FrmRepairDelegateEdit.dgvApply");
        }
        /// <summary>
        ///  设置详细grid的隐藏列与显示标题.
        /// </summary>
        private void setDetailDataGridView()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("SHIP_NAME", "船舶");
            dic.Add("PROJECTNAME", "修理项目名称");
            dic.Add("PROJECTDETAIL", "修理项目详细");
            dic.Add("APPLICANT", "申请人");
            dic.Add("HEADSHIP_NAME", "申请人岗位");
            dic.Add("APPLYDATE", "申请日期");
            dic.Add("APPLYCOMPLETEDATE", "期望完成日期");
            dic.Add("RUNNINGORDOCK_NAME", "航修或坞修");
            dic.Add("COMP_CHINESE_NAME", "修理设备");
            dic.Add("NODE_NAME", "修理科目");
            dic.Add("AFFIRMANT", "申请最终确认人");
            dic.Add("REMARK", "备注");
            dgvDetail.SetDgvGridColumns(dic);
            dgvDetail.LoadGridView("FrmRepairDelegateEdit.dgvDetail");
        }
        /// <summary>
        /// 选择船舶绑定委托申请.
        /// </summary>
        /// <param name="theSelectedObject"></param>
        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            if (shipID == theSelectedObject) return;
            if (dgvDetail.Rows.Count > 0)
            {
                if (DialogResult.No == MessageBoxEx.Show("更改船舶会解除已绑定的修理申请,确认吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    ucShipSelect1.SelectedId(shipID, false);
                    return;
                }
                else
                {
                    string err;
                    DataTable dtbDetail = (DataTable)dgvDetail.DataSource;
                    if (!string.IsNullOrEmpty(repairid))
                    {
                        using (TransactionClass tc = new TransactionClass())
                        {
                            for (int i = 0; i < dtbDetail.Rows.Count; i++)
                            {
                                ShipRunningRepairRelationService.Instance.DeleteUnit(dtbDetail.Rows[i]["PROJECTID"].ToString(), repairid, null);
                                ShipRepairProject srp = ShipRepairProjectService.Instance.getObject(dtbDetail.Rows[i]["PROJECTID"].ToString(), out err);
                                srp.PROJECTSTATE = 7;
                                srp.SERVICEPROVIDER = "";
                                srp.Update(out err);
                            }
                            tc.CommitTransaction();
                        }
                    }
                    dtbDetail.Rows.Clear();
                    dgvDetail.DataSource = dtbDetail;
                }
            }
            shipID = theSelectedObject;
            this.setApplyBindingSource(shipID);
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
            if (string.IsNullOrEmpty(ucShipSelect1.GetId()))
            {
                MessageBoxEx.Show("船舶不能为空");
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
            DataTable dtbDetail = (DataTable)dgvDetail.DataSource;
            if (dtbDetail.Rows.Count == 0)
            {
                MessageBoxEx.Show("请先添加委托单详细项");
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

            ShipInfo shipInfo = ShipInfoService.Instance.getObject(shipID, out err);
            sre.REPAIRID = repairid;
            sre.REPAIRCODE = shipInfo.SHIP_CODE + DateTime.Now.ToString("yyyyMM") + ShipRepairEventService.Instance.CreateSerialNumber();
            sre.REPAIRPORT = ucRepairPortSelect1.Text.Trim();
            sre.SHIP_ID = ucShipSelect1.GetId();
            sre.SERVICEPROVIDER = ucManufacturerSelect1.GetId();
            sre.REPAIRDATE = dtpREPAIRDATE.Value;
            sre.ARRANGEDPERSON = txtARRANGEDPERSON.Text.Trim();
            sre.REMARK = txtREMARK.Text.Trim();
            sre.ARRANGED = 1;

            using (TransactionClass tc = new TransactionClass())
            {
                ShipRepairEventService.Instance.InsertUnit(sre, out repairid, out err);
                //ShipRunningRepairRelationService.Instance.DeleteUnit(null, repairid, "3");
                DataTable dtbDetail = (DataTable)dgvDetail.DataSource;
                for (int i = 0; i < dtbDetail.Rows.Count; i++)
                {
                    if (dtbDetail.Rows[i]["PROJECTSTATE"].ToString() == "7")
                    {
                        ShipRepairProject srp = ShipRepairProjectService.Instance.getObject(dtbDetail.Rows[i]["PROJECTID"].ToString(), out err);
                        if (srp.PROJECTSTATE != 7)
                        {
                            MessageBoxEx.Show("修理项目名称为 " + srp.PROJECTNAME + " 的项目已被其他人委托");
                            continue;
                        }
                        int index = 0;
                        DataTable dtsortno = ShipRunningRepairRelationService.Instance.GetInfo(null, repairid, null, out err);
                        if (dtsortno.Rows.Count > 0)
                        {
                            index = Convert.ToInt32(dtsortno.Rows[dtsortno.Rows.Count - 1]["sortno"]);
                        }
                        DataRow dr = dtbDetail.Rows[i];
                        ShipRunningRepairRelation obj = new ShipRunningRepairRelation();
                        obj.PROJECTID = dr["PROJECTID"].ToString();
                        obj.REPAIRID = repairid;
                        obj.STATE = 3;
                        obj.SORTNO = ++index;
                        if (!ShipRunningRepairRelationService.Instance.saveUnit(obj, out err))
                            break;
                        srp.PROJECTSTATE = 8;
                        srp.SERVICEPROVIDER = sre.SERVICEPROVIDER;
                        if (!ShipRepairProjectService.Instance.saveUnit(srp, out err))
                            break;
                    }
                }
                tc.CommitTransaction();
            }
            if (string.IsNullOrEmpty(err))
            {
                MessageBoxEx.Show("操作成功！", "提示");
                this.Close();
            }
            else
            {
                MessageBoxEx.Show(err, "操作失败");
            }
        }

        /// <summary>
        /// 加入委托单.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvApply.Rows.Count == 0 && dgvApply.CurrentRow == null)
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            DataTable dtbApply = (DataTable)dgvApply.DataSource;
            DataTable dtbDetail = (DataTable)dgvDetail.DataSource;
            string addlyID = dgvApply.Rows[lastApplyRowNumber].Cells["PROJECTID"].Value.ToString();
            DataRow[] foundRows = dtbApply.Select("PROJECTID ='" + addlyID + "'");
            object[] obj = foundRows[0].ItemArray;
            dtbDetail.Rows.Add(obj);
            dtbApply.Rows.Remove(foundRows[0]);
            dgvDetail.DataSource = dtbDetail;
            dgvApply.DataSource = dtbApply;
        }
        /// <summary>
        /// 从委托单移除.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            string err;
            if (dgvDetail.Rows.Count == 0 && dgvDetail.CurrentRow == null)
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            string detailID = dgvDetail.Rows[lastDetailRowNumber].Cells["PROJECTID"].Value.ToString();
            string PROJECTSTATE = dgvDetail.Rows[lastDetailRowNumber].Cells["PROJECTSTATE"].Value.ToString();
            if (PROJECTSTATE == "9")
            {
                MessageBoxEx.Show("该修理项目已经完成,不能解除委托");
                return;
            }
            if (PROJECTSTATE == "8")
            {
                ShipRepairProject srp = ShipRepairProjectService.Instance.getObject(detailID, out err);
                srp.PROJECTSTATE = 7;
                srp.SERVICEPROVIDER = "";
                using (TransactionClass tc = new TransactionClass())
                {
                    DataTable dtsrr = ShipRunningRepairRelationService.Instance.GetInfo(detailID, repairid, "3", out err);
                    ShipRunningRepairRelation srr = ShipRunningRepairRelationService.Instance.getObject(dtsrr.Rows[0]["RELATIONID"].ToString(), out err);
                    srr.STATE = 2;
                    ShipRunningRepairRelationService.Instance.saveUnit(srr, out err);
                    ShipRepairProjectService.Instance.saveUnit(srp, out err);
                    tc.CommitTransaction();
                }
                if (!string.IsNullOrEmpty(err))
                {
                    MessageBoxEx.Show(err, "操作失败");
                    return;
                }
                dgvDetail.Rows[lastDetailRowNumber].Cells["PROJECTSTATE"].Value = 7;
            }
            DataTable dtbApply = (DataTable)dgvApply.DataSource;
            DataTable dtbDetail = (DataTable)dgvDetail.DataSource;
            DataRow[] foundRows = dtbDetail.Select("PROJECTID ='" + detailID + "'");
            object[] obj = foundRows[0].ItemArray;
            dtbApply.Rows.Add(obj);
            dtbDetail.Rows.Remove(foundRows[0]);
            dgvDetail.DataSource = dtbDetail;
            dgvApply.DataSource = dtbApply;
        }
        /// <summary>
        /// 未委托的申请当前选择.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvApply_SelectedChanged(int rowNumber)
        {
            lastApplyRowNumber = rowNumber;
        }
        /// <summary>
        /// 委托单详细当前选择.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDetail_SelectedChanged(int rowNumber)
        {
            lastDetailRowNumber = rowNumber;
        }
        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRepairApply_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvDetail.SaveGridView("FrmRepairDelegateEdit.dgvApply");
            dgvApply.SaveGridView("FrmRepairDelegateEdit.dgvDetail");
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
