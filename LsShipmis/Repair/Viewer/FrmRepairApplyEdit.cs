/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有 
 * 文 件 名：FrmRepairApplyEdit.cs
 * 创 建 人：王鹏程
 * 创建时间：2011-7-26
 * 标    题：修理申请业务编辑窗体 
 * 功能描述：
 * 修 改 人： 
 * 修改时间： 
 * 修改内容： 
 ****************************************************************************************************/
using System;
using System.Windows.Forms;
using CommonViewer.BaseControl;
using Repair.DataObject;
using Repair.Services;
using System.Data;
using Cost.Services;
using Cost.DataObject;
using BaseInfo.Objects;
using BaseInfo.DataAccess;

namespace Repair.Viewer
{
    public partial class FrmRepairApplyEdit : CommonViewer.BaseForm.FormBase
    {
        //项目状态(1.未审核,2.等待部门长审批,3等待船长审批,4等待岸端机务主管审批,
        //5等待岸端机务经理审批,6等待船管总经理审批,7.申请通过等待委托,8,已经委托,9已经完成,10已经取消)
        public ShipRepairProject repairProject = null;
        private string applyID = "";
        private string shipId;
        private DataTable dtProject = null;
        /// <summary>
        /// 1=新申请; 2=修改; 3=审核; 4=完工单添加新项; 5=完工单修改项; 6=双击进来查看详细(全只读)
        /// </summary>
        private int functionCode = 1;
        /// <summary>
        /// 构造函数，.
        /// </summary>
        /// <param name="applyId">申请id</param>
        /// <param name="functionIn">操作类型</param>
        public FrmRepairApplyEdit(string shipId, string paramApplyId, int functionIn)
        {
            InitializeComponent();
            this.shipId = shipId;
            string err;
            if (string.IsNullOrEmpty(paramApplyId))
            {
                repairProject = new ShipRepairProject();
                repairProject.SHIP_ID = shipId;
            }
            else
            {
                applyID = paramApplyId;
                dtProject = ShipRepairProjectService.Instance.GetInfo(applyID, null, null, null, null, null);
                repairProject = ShipRepairProjectService.Instance.getObject(applyID, out err);
            }
            functionCode = functionIn;
        }
        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRepairApplyEdit_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(false, true);
            if (!string.IsNullOrEmpty(shipId)) ucShipSelect1.SelectedId(shipId);
            setComboBox();
            showDataToForm();
            setButtonsAndControls();
        }
        /// <summary>
        /// 设置空间可见权限.
        /// </summary>
        private void setButtonsAndControls()
        {
            btnSave.Visible = "1,2,3".Contains(functionCode.ToString());//仅保存按钮.
            btnDisagree.Visible = 3 == functionCode;//不同意.
            btnAgree.Visible = 3 == functionCode;//同意.
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME) //假如是机务主管.
               || "机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理.
                {
                    btnPass.Visible = "1,2,3".Contains(functionCode.ToString());
                    btnSubmit.Visible = "1,2,3".Contains(functionCode.ToString());
                }
                txtJWComfirm.ReadOnly = (functionCode == 1 || functionCode == 2);
            }
            else
            {
                txtJWComfirm.ReadOnly = true;
            }
            if (functionCode == 6)
            {
                txtProjectName.ReadOnly = true;
                txtApplicant.ReadOnly = true;
                txtApplypost.ReadOnly = true;
                dtpApplyDate.Enabled = false;
                dtpApplyCompleteDate.Enabled = false;
                cbxRepairType.Enabled = false;
                cbxCostType.Enabled = false;
                txtProjectDetail.ReadOnly = true;
                txtRemark.ReadOnly = true;
                ucShipSelect1.Enabled = false;
                ucComponentSelect1.Enabled = false;
                txtJWComfirm.ReadOnly = true;
            }
            if ("1,2".Contains(functionCode.ToString()) && repairProject.PROJECTSTATE == 1)
                btnSubmit.Visible = true;
            if (functionCode != 1)
                ucShipSelect1.Enabled = false;
            if (functionCode == 4 || functionCode == 5)//从完工单添加.
            {
                btnPass.Visible = true;
                btnSave.Visible = false;
                btnDisagree.Visible = false;
                btnAgree.Visible = false;
            }
        }
        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            #region 类型数据绑定
            cbxRepairType.DisplayMember = "State";
            cbxRepairType.ValueMember = "Id";
            DataTable dtbRepairType = new DataTable();
            dtbRepairType.Columns.Add("Id", typeof(string));
            dtbRepairType.Columns.Add("State", typeof(string));
            DataRow row31 = dtbRepairType.NewRow();
            row31["Id"] = "VoyageRepair";
            row31["State"] = "航修";
            dtbRepairType.Rows.Add(row31);
            DataRow row32 = dtbRepairType.NewRow();
            row32["Id"] = "SlipwayRepair";
            row32["State"] = "坞修";
            dtbRepairType.Rows.Add(row32);
            cbxRepairType.DataSource = dtbRepairType;
            cbxRepairType.SelectedIndex = 0;
            #endregion
        }
        /// <summary>
        /// 显示数据到控件上.
        /// </summary>
        private void showDataToForm()
        {
            if ("2,3,5,6".Contains(functionCode.ToString()))
            {
                txtProjectName.Text = repairProject.PROJECTNAME;
                txtApplicant.Text = repairProject.APPLICANT;
                txtApplypost.Text = dtProject.Rows[0]["HEADSHIP_NAME"].ToString();
                dtpApplyDate.Value = repairProject.APPLYDATE;
                if (repairProject.APPLYCOMPLETEDATE != DateTime.MinValue)
                    dtpApplyCompleteDate.Value = repairProject.APPLYCOMPLETEDATE;
                cbxRepairType.SelectedValue = repairProject.RUNNINGORDOCK == 1 ? "VoyageRepair" : "SlipwayRepair";
                if (repairProject.REPAIRSUBJECT != null)
                    cbxCostType.SelectedValue = repairProject.REPAIRSUBJECT;
                txtProjectDetail.Text = repairProject.PROJECTDETAIL;
                txtRemark.Text = repairProject.REMARK;
                ucShipSelect1.SelectedId(repairProject.SHIP_ID);
                ucComponentSelect1.SelectedId(repairProject.EQUIPMENTID);
                txtJWComfirm.Text = repairProject.LandOpinion;
            }
            else
            {
                txtApplicant.Text = CommonOperation.ConstParameter.UserName;
                txtApplypost.Text = CommonOperation.ConstParameter.LoginUserInfo.ShipHeadShipName;
                dtpApplyDate.Value = DateTime.Now;
                dtpApplyCompleteDate.Value = DateTime.Now;
            }

        }
        /// <summary>
        /// 保存按钮事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string err;
            if (!updateObjectFromForm())
                return;
            if ("1".Contains(functionCode.ToString()))
                repairProject.PROJECTSTATE = 1;
            if (!repairProject.Update(out err))
            {
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.Close();
        }
        /// <summary>
        /// 从表单取得数据,并校验.
        /// </summary>
        /// <returns></returns>
        private bool updateObjectFromForm()
        {
            if (!CheckForm()) return false;
            repairProject.PROJECTNAME = txtProjectName.Text.Trim();
            repairProject.APPLICANT = txtApplicant.Text.Trim();
            repairProject.APPLYDATE = dtpApplyDate.Value;
            if (!string.IsNullOrEmpty(dtpApplyCompleteDate.Text))
                repairProject.APPLYCOMPLETEDATE = dtpApplyCompleteDate.Value;
            repairProject.RUNNINGORDOCK = cbxRepairType.SelectedValue.ToString() == "VoyageRepair" ? 1 : 2;
            repairProject.REPAIRSUBJECT = cbxCostType.SelectedValue.ToString();
            repairProject.PROJECTDETAIL = txtProjectDetail.Text.Trim();
            repairProject.REMARK = txtRemark.Text.Trim();
            repairProject.EQUIPMENTID = ucComponentSelect1.GetId();
            repairProject.SENDTOWARRANT = 0;
            repairProject.LandOpinion = txtJWComfirm.Text;
            if ("1,4,5".Contains(functionCode.ToString()))
            {
                repairProject.APPLYPOST = CommonOperation.ConstParameter.LoginUserInfo.PostId;
            }
            if (CommonOperation.ConstParameter.IsLandVersion)
                repairProject.SHIP_ID = ucShipSelect1.GetId();
            else
                repairProject.SHIP_ID = CommonOperation.ConstParameter.ShipId;
            return true;
        }
        /// <summary>
        /// form验证.
        /// </summary>
        /// <returns></returns>
        private bool CheckForm()
        {
            if (string.IsNullOrEmpty(txtProjectName.Text.Trim()))
            {
                MessageBoxEx.Show("修理项目名称不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProjectName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtpApplyDate.Value.ToString()))
            {
                MessageBoxEx.Show("申请日期不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpApplyDate.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dtpApplyCompleteDate.Value.ToString()))
            {
                MessageBoxEx.Show("希望完成日期不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpApplyCompleteDate.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtApplicant.Text.Trim()))
            {
                MessageBoxEx.Show("申请人不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpApplyDate.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(CommonOperation.ConstParameter.LoginUserInfo.PostId))
            {
                MessageBoxEx.Show("申请岗位不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpApplyDate.Focus();
                return false;
            }
            if (CommonOperation.ConstParameter.IsLandVersion && string.IsNullOrEmpty(ucShipSelect1.GetId()))
            {
                MessageBoxEx.Show("船舶不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ucShipSelect1.Focus();
                return false;
            }
            //if (string.IsNullOrEmpty(ucComponentSelect1.GetId()))
            //{
            //    MessageBoxEx.Show("修理设备不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    ucComponentSelect1.Focus();
            //    return false;
            //}
            return true;
        }
        /// <summary>
        /// 普通员工的提交.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!CheckForm()) return;
            if (MessageBoxEx.Show("是否提交上级审批？", "提示信息", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == System.Windows.Forms.DialogResult.No) return;
            string err;
            if (!updateObjectFromForm())
                return;
            if ("1,2".Contains(functionCode.ToString()))
            {
                if (CommonOperation.ConstParameter.IsLandVersion)//是岸端.
                {
                    if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务主管.
                        repairProject.PROJECTSTATE = 5;
                    else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理.
                        repairProject.PROJECTSTATE = 6;
                    else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理.
                    {
                        repairProject.PROJECTSTATE = 7;
                        repairProject.AFFIRMANT = CommonOperation.ConstParameter.UserName;
                    }
                    else
                    {
                        repairProject.PROJECTSTATE = 4;
                    }
                }
                else//是船端.
                {
                    if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)//是船长.
                        repairProject.PROJECTSTATE = 4;
                    else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER)//是部门长.
                        repairProject.PROJECTSTATE = 3;
                    else
                        repairProject.PROJECTSTATE = 2;
                }
            }
            if (!repairProject.Update(out err))
            {
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            this.Close();
        }
        /// <summary>
        /// 不提交上级直接通过.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPass_Click(object sender, EventArgs e)
        {
            if (!CheckForm()) return;
            if (MessageBoxEx.Show("是否直接通过这次申请？", "提示信息", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == System.Windows.Forms.DialogResult.No) return;
            string err;
            if (!updateObjectFromForm())
                return;
            repairProject.PROJECTSTATE = 7;
            repairProject.AFFIRMANT = CommonOperation.ConstParameter.UserName;
            if (!repairProject.Update(out err))
            {
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            RemindService.Instance.CreateRemindOnce(1, repairProject.SHIP_ID, repairProject.PROJECTID);
            MessageBoxEx.Show("操作成功！", "提示");
            this.Close();
        }
        /// <summary>
        /// 同意按钮事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgree_Click(object sender, EventArgs e)
        {
            if (!CheckForm()) return;

            if (MessageBoxEx.Show("是否同意？", "提示信息", MessageBoxButtons.YesNo,
              MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
              == System.Windows.Forms.DialogResult.No) return;
            string err;
            if (!updateObjectFromForm())
                return;
            if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)
                repairProject.PROJECTSTATE = 4;
            else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER)
                repairProject.PROJECTSTATE = 3;
            else if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务主管
                repairProject.PROJECTSTATE = 5;
            else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理
                repairProject.PROJECTSTATE = 6;
            else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理
            {
                repairProject.PROJECTSTATE = 7;
                repairProject.AFFIRMANT = CommonOperation.ConstParameter.UserName;
            }
            if (!repairProject.Update(out err))
            {
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (repairProject.PROJECTSTATE == 7)
                RemindService.Instance.CreateRemindOnce(1, repairProject.SHIP_ID, repairProject.PROJECTID);
            MessageBoxEx.Show("操作成功！", "提示");
            this.Close();
        }
        /// <summary>
        /// 不同意按钮事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisagree_Click(object sender, EventArgs e)
        {
            string err;
            if (!updateObjectFromForm())
                return;
            if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)
                repairProject.PROJECTSTATE = 1;
            else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER)
                repairProject.PROJECTSTATE = 1;
            else if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务主管
                repairProject.PROJECTSTATE = 3;
            else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理
                repairProject.PROJECTSTATE = 4;
            else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理
                repairProject.PROJECTSTATE = 5;
            if (!repairProject.Update(out err))
            {
                MessageBoxEx.Show(err, "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            MessageBoxEx.Show("操作成功！", "提示");
            this.Close();
        }
        /// <summary>
        /// 修理类型事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbRepairType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string err;
            if (cbxRepairType.SelectedValue != null)
            {
                CostAccountPositionCondition capc = null;
                DataTable dt;
                if (cbxRepairType.SelectedValue.ToString() == "VoyageRepair")
                {
                    capc = new CostAccountPositionCondition(null, null, "3");
                }
                else
                {
                    capc = new CostAccountPositionCondition(null, null, "4");
                }
                if (!CostAccountPositionService.Instance.GetInfoByCondition(capc, out dt, out err))
                {
                    MessageBoxEx.Show(err);
                    return;
                }
                cbxCostType.DataSource = dt;
                cbxCostType.DisplayMember = "path";
                cbxCostType.ValueMember = "NODE_ID";
            }
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

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            ucComponentSelect1.ChangeShip("", theSelectedObject);
        }
    }
}
