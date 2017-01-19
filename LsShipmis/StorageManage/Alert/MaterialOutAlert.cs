/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有 * 文 件 名：MaterialOutAlert.cs
 * 创 建 人：李景育 * 创建时间：2008-04-20
 * 标    题：船舶物资出库报警接口模块
 * 功能描述：实现船舶物资出库报警接口模块的业务类 * 修 改 人： 
 * 修改时间： * 修改内容： ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data; 
using CommonOperation.Interfaces;
using StorageManage.Viewer;

namespace StorageManage.Alert
{
    /// <summary>
    /// 物资出库报警业务类.
    /// </summary>
    public class MaterialOutAlert : CommonOperation.Interfaces.IRemind
    {
        /// <summary>
        /// 定义数据操作层对象.
        /// </summary>
        private static IDBAccess dbAccess = CommonOperation.Functions.InterfaceInstantiation.NewADbAccess();

        /// <summary>
        /// 当前对象的报警颜色，以及鼠标tag信息.
        /// </summary>
        /// <param name="tag">图标上显示的鼠标tag</param>
        /// <returns>报警颜色值</returns>
        public remindColor getStatus(out string tag)
        {
            tag = "存在等待审核的物料出库单"; 
            return remindColor.Yellow;
        }

        /// <summary>
        /// 点击报警图标后需要打开的窗体或处理的事件.
        /// </summary>
        public void viewInfo()
        {
            //取得未审核的最小日期.
            FrmMaterialOut frm = FrmMaterialOut.Instance;
            if(CommonViewer.CommonViewConfig.MainForm!=null)frm.MdiParent = CommonViewer.CommonViewConfig.MainForm;
            frm.BringToFront();
            frm.Show();
            frm.SetRemindViewApprovalState();
        }

        public static IRemind GetAlarmObject(string userId)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;//权限代理业务类.
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                if ((proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_CHECK, out err)
                  || proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_LEADER_CHECK, out err)
                  || proxyRight.CheckRight(CommonOperation.ConstParameter.ITEM_LAND_MANAGER_CHECK, out err)
                    ) && CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME == "机务主管岗位")
                {
                    sSql = "and state=2";
                }
                else
                    return null;
            }
            else
            {
                if ((CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER || CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS))
                    sSql = "and state=1";
                else
                    return null;
            }
            if (string.IsNullOrEmpty(sSql)) return null;
            //状态(1.等待船端确认,2等待岸端确认,3岸端打回,4岸端确认,5已经盘点)
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select top 1 DEPOTOPERID from T_MATERIAL_DEPOT_OPERATION ");
            if (CommonOperation.ConstParameter.IsLandVersion)
                sb.AppendLine(" inner join T_USER_SHIP us on us.ship_id=T_MATERIAL_DEPOT_OPERATION.ship_id and us.userid = '" + CommonOperation.ConstParameter.UserId + "'");

            sb.AppendLine("where IN_OR_OUT=2 and ISCOMPLETE=1"); sb.AppendLine(sSql);
            dbAccess.GetDataTable(sb.ToString(), out dtb, out err);
            if (dtb != null && dtb.Rows.Count > 0)
            {
                return (IRemind)new MaterialOutAlert();
            }
            else
            {
                return null;
            }
        }
       
    }
}