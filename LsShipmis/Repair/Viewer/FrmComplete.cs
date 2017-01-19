using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Repair.Services;
using CommonViewer.BaseControl;
using CommonViewer;
using Repair.DataObject;
using CommonOperation.Functions;
using BaseInfo.DataAccess;

namespace Repair.Viewer
{
    public partial class FrmComplete : CommonViewer.BaseForm.FormBase
    {
        private string lastRepairID = "";
        private string lastDetailID = "";
        private string lastRelationID = "";
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmComplete instance = new FrmComplete();
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmComplete Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmComplete.instance = new FrmComplete();
                }

                return FrmComplete.instance;
            }
        }
        public FrmComplete()
        {
            InitializeComponent();
        }
        #endregion
        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmComplete_Load(object sender, EventArgs e)
        {
            this.setComboBox();     //设置窗体所需的下拉列表框的数据源.
            this.WindowState = FormWindowState.Maximized;//窗体最大化.
            this.setBindingSource();//设置数据源.
            this.setDataGridView(); //设置网格控件dtbDelegate的隐藏列与标头的设置.
            setDetailDataGridView();
            ucShipSelect1.ChangeSelectedState(true, true);
            if (!CommonOperation.ConstParameter.IsLandVersion)
            {
                bdNgAddNewItem.Visible = false;
                bdNgEditItem.Visible = false;
                bdNgDeleteItem.Visible = false;
                btnAddProject.Visible = false;
                btnDisannul.Visible = false;
                btnProjectOff.Visible = false;
                btnEditRemark.Visible = false;
            }
        }
        /// <summary>
        /// 设置修理项目信息的bindingSource数据源，每次查询的都是指定船名的修理项目信息。.
        /// </summary>
        private void setBindingSource()
        {
            string shipId = ucShipSelect1.GetId();//船舶.
            string err;
            DataTable dtbDelegate = ShipRepairEventService.Instance.GetInfo(shipId, "1");
            dgvDelegate.DataSource = dtbDelegate;
            StringBuilder ownerShipStr = new StringBuilder();
            if (ckbOnlySelf.Checked)
                ownerShipStr.Append(" ARRANGEDPERSON='" + CommonOperation.ConstParameter.UserName + "' ");
            else
                ownerShipStr.Append(" 1=1 ");
            if (string.IsNullOrEmpty(ucShipSelect1.GetId()))
            {
                DataTable dtOwnerShip = ShipInfoService.Instance.GetOwnerShip(out err);
                if (dtOwnerShip.Rows.Count > 0)
                {
                    ownerShipStr.Append(" and ship_id in ('1'");
                    foreach (DataRow item in dtOwnerShip.Rows)
                        ownerShipStr.Append(",'" + item["ship_id"].ToString() + "'");
                    ownerShipStr.Append(")");
                }

                DataTable newdt = new DataTable();
                newdt = dtbDelegate.Clone();
                foreach (DataRow item in dtbDelegate.Select(ownerShipStr.ToString()))
                    newdt.Rows.Add(item.ItemArray);
                dgvDelegate.DataSource = newdt;
            }
            if (dtbDelegate.Rows.Count == 0)
                lastRepairID = "";
            setDetailBindingSource();
        }
        /// <summary>
        ///  设置修理项目信息网格控件dtbDelegate的隐藏列与显示标题.
        /// </summary>
        private void setDataGridView()
        {
            UcDataGridView dgv = dgvDelegate;
            foreach (DataGridViewColumn item in dgv.Columns)
            {
                item.ReadOnly = true;
            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("REPAIRPORT", "修理港口");
            dic.Add("SHIP_NAME", "船舶");
            dic.Add("ARRANGED_NAME", "委托状态");
            dic.Add("ARRANGEDPERSON", "安排人");
            //dic.Add("SHIPAFFIRMANT", "完工船端确认人");
            //dic.Add("COMPAFFIRMANT", "完工岸端确认人");
            //dic.Add("REPAIRDATE", "修理开始日期");
            dic.Add("MANUFACTURER_NAME", "服务商");
            //dic.Add("COMPLETEDATE", "修理完成日期");
            //dic.Add("REMARK", "备注");
            dgv.LoadGridView("FrmComplete.dgvDelegate");
            dgv.SetDgvGridColumns(dic);

        }
        /// <summary>
        /// 绑定详细grid
        /// </summary>
        private void setDetailBindingSource()
        {
            DataTable dtbDetail = ShipRepairProjectService.Instance.GetCompleteInfo(lastRepairID);
            dgvDetail.DataSource = dtbDetail;
            foreach (DataGridViewRow item in dgvDetail.Rows)
            {
                if (item.Cells["STATE"].Value.ToString() != "1")
                {
                    item.Cells["REALCOMPLETEDATE"].Value = null;
                    item.Cells["COMPLETEAFFIRMANT"].Value = null;
                    item.Cells["CURRENCYCODE"].Value = null;
                    item.Cells["COSTCOUNT"].Value = null;
                }
            }
        }
        /// <summary>
        ///  设置详细grid的隐藏列与显示标题.
        /// </summary>
        private void setDetailDataGridView()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("STATE_NAME", "完工状态");
            dic.Add("PROJECTNAME", "修理项目名称");
            dic.Add("PROJECTDETAIL", "修理项目详细");
            dic.Add("APPLYDATE", "申请日期");
            dic.Add("APPLICANT", "申请人");
            dic.Add("APPLYCOMPLETEDATE", "期望完成日期");
            dic.Add("REALCOMPLETEDATE", "完成日期");
            dic.Add("AFFIRMANT", "申请最终确认人");
            dic.Add("COMPLETEAFFIRMANT", "完成确认人");
            dic.Add("RUNNINGORDOCK_NAME", "航修或坞修");
            dic.Add("REMARK", "修理备注");
            dic.Add("CURRENCYCODE", "货币");
            dic.Add("COSTCOUNT", "金额");
            dic.Add("COMP_CHINESE_NAME", "修理设备");
            dic.Add("NODE_NAME", "修理科目");
            dic.Add("SRREMARK", "委托备注");
            dgvDetail.SetDgvGridColumns(dic);
            dgvDetail.LoadGridView("FrmComplete.dgvDetail");
        }
        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
        }
        #region 筛选条件控件事件
        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            this.setBindingSource();
        }
        private void ckbOnlySelf_CheckedChanged(object sender, EventArgs e)
        {
            this.setBindingSource();
        }
        #endregion
        /// <summary>
        /// 当申请单信息网格行改变时，显示当前行的申请单明细信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtbDelegate_SelectedChanged(int rowNumber)
        {
            if (dgvDelegate.Rows.Count > 0)
            {
                lastRepairID = dgvDelegate.Rows[rowNumber].Cells["REPAIRID"].Value.ToString();

                txtREPAIRCODE.Text = dgvDelegate.Rows[rowNumber].Cells["REPAIRCODE"].Value.ToString();
                txtARRANGEDPERSON.Text = dgvDelegate.Rows[rowNumber].Cells["ARRANGEDPERSON"].Value.ToString();
                txtREPAIRPORT.Text = dgvDelegate.Rows[rowNumber].Cells["REPAIRPORT"].Value.ToString();
                txtSHIP_NAME.Text = dgvDelegate.Rows[rowNumber].Cells["SHIP_NAME"].Value.ToString();
                txtSHIPAFFIRMANT.Text = dgvDelegate.Rows[rowNumber].Cells["SHIPAFFIRMANT"].Value.ToString();
                txtCOMPAFFIRMANT.Text = dgvDelegate.Rows[rowNumber].Cells["COMPAFFIRMANT"].Value.ToString();
                txtREPAIRDATE.Text = dgvDelegate.Rows[rowNumber].Cells["REPAIRDATE"].Value.ToString();
                txtMANUFACTURER_NAME.Text = dgvDelegate.Rows[rowNumber].Cells["MANUFACTURER_NAME"].Value.ToString();
                txtCOMPLETEDATE.Text = dgvDelegate.Rows[rowNumber].Cells["COMPLETEDATE"].Value.ToString();
                txtREMARK.Text = dgvDelegate.Rows[rowNumber].Cells["REMARK"].Value.ToString();
                //dgvDetail.SaveGridView("FrmComplete.dgvDetail");
                setDetailBindingSource();
            }
        }
        /// <summary>
        /// 详细.
        /// </summary>
        /// <param name="rowNumber"></param>
        private void dgvDetail_SelectedChanged(int rowNumber)
        {
            if (dgvDetail.Rows.Count > 0)
            {
                if (lastDetailID != dgvDetail.Rows[rowNumber].Cells["PROJECTID"].Value.ToString())
                {
                    lastDetailID = dgvDetail.Rows[rowNumber].Cells["PROJECTID"].Value.ToString();
                    lastRelationID = dgvDetail.Rows[rowNumber].Cells["RELATIONID"].Value.ToString();
                }
            }
        }
        /// <summary>
        /// 添加新项.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddProject_Click(object sender, EventArgs e)
        {
            string shipId = null;
            if (dgvDelegate.CurrentRow != null)
            {
                shipId = dgvDelegate.CurrentRow.Cells["SHIP_ID"].Value.ToString();
            }
            if (string.IsNullOrEmpty(shipId)) return;
            FrmRepairApplyEdit frm = new FrmRepairApplyEdit(shipId, null, 4);

            frm.ShowDialog();
            if (frm.repairProject != null && !string.IsNullOrEmpty(frm.repairProject.PROJECTID))
            {
                string err;
                int index = 0;
                DataTable dtsortno = ShipRunningRepairRelationService.Instance.GetInfo(null, lastRepairID, null, out err);
                if (dtsortno.Rows.Count > 0)
                {
                    index = Convert.ToInt32(dtsortno.Rows[dtsortno.Rows.Count - 1]["sortno"]);
                }
                ShipRunningRepairRelation obj = new ShipRunningRepairRelation();
                obj.PROJECTID = frm.repairProject.PROJECTID;
                obj.REPAIRID = lastRepairID;
                obj.STATE = 3;
                obj.SORTNO = ++index;

                frm.repairProject.PROJECTSTATE = 8;
                frm.repairProject.SERVICEPROVIDER = dgvDelegate.CurrentRow.Cells["SERVICEPROVIDER"].Value.ToString();

                using (TransactionClass tc = new TransactionClass())
                {
                    ShipRunningRepairRelationService.Instance.saveUnit(obj, out err);
                    frm.repairProject.Update(out err);
                    tc.CommitTransaction();
                }
                if (string.IsNullOrEmpty(err))
                {
                    MessageBoxEx.Show("操作成功！", "提示");
                    this.setBindingSource();
                }
                else
                {
                    MessageBoxEx.Show(err, "操作失败");
                }
            }
        }
        /// <summary>
        /// 完工.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (dgvDetail.CurrentRow == null || string.IsNullOrEmpty(lastDetailID))
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                if ("1" == (dgvDetail.CurrentRow.Cells["STATE"].Value.ToString()))
                {
                    MessageBoxEx.Show("该修理项目已经完成,不能做其他操作");
                    return;
                }
                else if ("2" == (dgvDetail.CurrentRow.Cells["STATE"].Value.ToString()))
                {
                    MessageBoxEx.Show("该修理项目已经在本次完工单里取消,不能做其他操作");
                    return;
                }
                else if ("4" == (dgvDetail.CurrentRow.Cells["STATE"].Value.ToString()))
                {
                    MessageBoxEx.Show("该修理项目已经关闭,不能做其他操作");
                    return;
                }
            }
            FrmCompleteEdit frm = new FrmCompleteEdit(lastRepairID, lastDetailID, lastRelationID);
            frm.ShowDialog();
            setBindingSource();
        }
        /// <summary>
        /// 作废按钮.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisannul_Click(object sender, EventArgs e)
        {
            if (dgvDetail.CurrentRow == null || string.IsNullOrEmpty(lastDetailID))
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            if ("1" == (dgvDetail.CurrentRow.Cells["STATE"].Value.ToString()))
            {
                MessageBoxEx.Show("该修理项目已经完成,不能做其他操作");
                return;
            }
            else if ("2" == (dgvDetail.CurrentRow.Cells["STATE"].Value.ToString()))
            {
                MessageBoxEx.Show("该修理项目已经在本次完工单里取消,不能做其他操作");
                return;
            }
            else if ("4" == (dgvDetail.CurrentRow.Cells["STATE"].Value.ToString()))
            {
                MessageBoxEx.Show("该修理项目已经关闭,不能做其他操作");
                return;
            }
            FrmCompleteDisannul frm = new FrmCompleteDisannul(lastRepairID, lastDetailID, lastRelationID);
            frm.ShowDialog();
            setBindingSource();
        }
        /// <summary>
        /// 项目关闭.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProjectOff_Click(object sender, EventArgs e)
        {
            if (dgvDetail.CurrentRow == null || string.IsNullOrEmpty(lastDetailID))
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            if ("1" == (dgvDetail.CurrentRow.Cells["STATE"].Value.ToString()))
            {
                MessageBoxEx.Show("该修理项目已经完成,不能做其他操作");
                return;
            }
            else if ("2" == (dgvDetail.CurrentRow.Cells["STATE"].Value.ToString()))
            {
                MessageBoxEx.Show("该修理项目已经在本次完工单里取消,不能做其他操作");
                return;
            }
            else if ("4" == (dgvDetail.CurrentRow.Cells["STATE"].Value.ToString()))
            {
                MessageBoxEx.Show("该修理项目已经关闭,不能做其他操作");
                return;
            }
            FrmCompleteProjectOff frm = new FrmCompleteProjectOff(lastRepairID, lastDetailID, lastRelationID);
            frm.ShowDialog();
            setBindingSource();
        }
        /// <summary>
        /// 编辑按钮事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgEditItem_Click(object sender, EventArgs e)
        {
            if (dgvDelegate.CurrentRow == null || string.IsNullOrEmpty(lastRepairID))
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            FrmRepairDelegateEdit frm = new FrmRepairDelegateEdit(lastRepairID);
            frm.ShowDialog();
            setBindingSource();
        }
        /// <summary>
        /// 全部完工.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompleteAll_Click(object sender, EventArgs e)
        {
            if (dgvDelegate.CurrentRow == null || string.IsNullOrEmpty(lastRepairID))
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                bool isHasUnfinished = false;
                foreach (DataGridViewRow item in dgvDetail.Rows)
                {
                    if (item.Cells["STATE"].Value.ToString() == "3")
                        isHasUnfinished = true;
                }
                if (!isHasUnfinished)
                {
                    MessageBoxEx.Show("该项已经全部完工");
                    return;
                }
            }
            FrmCompleteAll frm = new FrmCompleteAll(lastRepairID);
            frm.ShowDialog();
            setBindingSource();
        }
        /// <summary>
        /// 添加按钮.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            FrmRepairDelegateEdit frm = new FrmRepairDelegateEdit();
            frm.ShowDialog();
            setBindingSource();
        }
        /// <summary>
        /// 删除按钮.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            string err;
            if (dgvDelegate.CurrentRow == null || string.IsNullOrEmpty(lastRepairID))
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            DataTable dtsrr = ShipRunningRepairRelationService.Instance.GetInfo(null, lastRepairID, "1", out err);
            if (dtsrr.Rows.Count > 0)
            {
                MessageBoxEx.Show("已经存在完成的项目,不能删除");
                return;
            }
            if (DialogResult.No == MessageBoxEx.Show("确认要删除该条信息吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                return;
            using (TransactionClass tc = new TransactionClass())
            {
                DataTable dtundone = ShipRunningRepairRelationService.Instance.GetInfo(null, lastRepairID, "3", out err);
                foreach (DataRow item in dtundone.Rows)
                {
                    ShipRepairProject srp = ShipRepairProjectService.Instance.getObject(item["PROJECTID"].ToString(), out err);
                    srp.PROJECTSTATE = 7;
                    srp.SERVICEPROVIDER = "";
                    ShipRepairProjectService.Instance.saveUnit(srp, out err);
                }
                ShipRunningRepairRelationService.Instance.DeleteUnit(null, lastRepairID, null);
                ShipRepairEventService.Instance.deleteUnit(lastRepairID, out err);
                tc.CommitTransaction();
            }
            if (string.IsNullOrEmpty(err))
                MessageBoxEx.Show("操作成功");
            else
                MessageBoxEx.Show("操作失败,原因如下:" + err);
            setBindingSource();
        }

        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmComplete_FormClosing(object sender, FormClosingEventArgs e)
        {
            //清除大文档绑定功能.
            // FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, "");
            dgvDelegate.SaveGridView("FrmComplete.dgvDelegate");
            dgvDetail.SaveGridView("FrmComplete.dgvDetail");
            instance = null;    //释放窗体实例变量.
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

        private void buttonEx1_Click(object sender, EventArgs e)
        {
            if (dgvDetail.CurrentRow == null || string.IsNullOrEmpty(lastDetailID))
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }
            else if ("2" == (dgvDetail.CurrentRow.Cells["STATE"].Value.ToString()))
            {
                MessageBoxEx.Show("该修理项目已经在本次完工单里取消,不能做其他操作");
                return;
            }
            else if ("4" == (dgvDetail.CurrentRow.Cells["STATE"].Value.ToString()))
            {
                MessageBoxEx.Show("该修理项目已经关闭,不能做其他操作");
                return;
            }
            FrmCompleteEditRemark frm = new FrmCompleteEditRemark(lastRepairID, lastDetailID, lastRelationID);
            frm.ShowDialog();
            setBindingSource();
        }

    }
}
