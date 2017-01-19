using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Repair.Services;
using Repair.DataObject;
using CommonViewer.BaseControl;
using CommonOperation.Interfaces;
using CommonOperation.Functions;

namespace Repair.Viewer
{
    public partial class FrmRepairDuoAudit : CommonViewer.BaseForm.FormBase
    {
        private List<string> idList = null;
        private FrmRepairDuoAudit()
        {
            InitializeComponent();
        }
        public FrmRepairDuoAudit(List<string> parmList)
        {
            InitializeComponent();
            idList = parmList;
        }

        private void btnAgree_Click(object sender, EventArgs e)
        {
            string err = "";
            string errMess = "";

            using (TransactionClass tc = new TransactionClass())
            {
                foreach (string item in idList)
                {
                    ShipRepairProject obj = ShipRepairProjectService.Instance.getObject(item, out err);
                    obj.REMARK += "\r\n" + txtRemark.Text.Trim();
                    if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)
                        obj.PROJECTSTATE = 4;
                    else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER)
                        obj.PROJECTSTATE = 3;
                    else if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务主管.
                        obj.PROJECTSTATE = 5;
                    else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理.
                        obj.PROJECTSTATE = 6;
                    else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理.
                    {
                        obj.PROJECTSTATE = 7;
                        obj.AFFIRMANT = CommonOperation.ConstParameter.UserName;
                    }
                    if (!ShipRepairProjectService.Instance.saveUnit(obj, out err))
                    {
                        errMess += err;
                    }
                }
                tc.CommitTransaction();
            }
            if ("".Equals(errMess))
            {
                MessageBoxEx.Show("操作成功！", "提示");
            }
            else
            {
                MessageBoxEx.Show(errMess, "操作失败");
            }
            this.Close();
        }

        private void btnDisagree_Click(object sender, EventArgs e)
        {
            string err;
            using (TransactionClass tc = new TransactionClass())
            {
                foreach (string item in idList)
                {
                    ShipRepairProject obj = ShipRepairProjectService.Instance.getObject(item, out err);
                    obj.REMARK += "\r\n" + txtRemark.Text.Trim();
                    if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS)
                        obj.PROJECTSTATE = 1;
                    else if (CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER)
                        obj.PROJECTSTATE = 1;
                    else if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务主管.
                        obj.PROJECTSTATE = 3;
                    else if ("机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是机务经理.
                        obj.PROJECTSTATE = 4;
                    else if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME)) //假如是船管总经理.
                        obj.PROJECTSTATE = 5;
                    if (!ShipRepairProjectService.Instance.saveUnit(obj, out err))
                    {
                        MessageBoxEx.Show(err, "操作失败");
                    }
                }
                tc.CommitTransaction();
            }
            MessageBoxEx.Show("操作成功！", "提示");
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmRepairDuoAudit_Load(object sender, EventArgs e)
        {
        }
    }
}
