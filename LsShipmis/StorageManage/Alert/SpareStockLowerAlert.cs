/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有 * 文 件 名：SpareStockckAlert.cs
 * 创 建 人：徐正本 * 创建时间：2010-8-12
 * 标    题：船舶备件低于警戒库存报警
 * 功能描述： * 修 改 人： 
 * 修改时间： * 修改内容： ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using StorageManage.Viewer;
namespace StorageManage.Alert
{
    /// <summary>
    /// 备件盘点报警业务类.
    /// </summary>
    public class SpareStockLowerAlert : CommonOperation.Interfaces.IRemind
    {
        /// <summary>
        /// 定义数据操作层对象.
        /// </summary>
        private static IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        /// <summary>
        /// 当前对象的报警颜色，以及鼠标tag信息.
        /// </summary>
        /// <param name="tag">图标上显示的鼠标tag</param>
        /// <returns>报警颜色值</returns>
        public remindColor getStatus(out string tag)
        {
            tag = "存在低于警戒库存的备件";
            return remindColor.Red;
        }

        /// <summary>
        /// 点击报警图标后需要打开的窗体或处理的事件.
        /// </summary>
        public void viewInfo()
        {
            //取得未审核的最小日期.
            FrmSpareOperation frm = FrmSpareOperation.Instance;
            if (CommonViewer.CommonViewConfig.MainForm != null) frm.MdiParent = CommonViewer.CommonViewConfig.MainForm;
            frm.BringToFront();
            frm.Show();
            frm.SwitchToAlertStock();
        }

        public static IRemind GetAlarmObject(string userId)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            StringBuilder sb = new StringBuilder();
            //需要报警的最早的最高级别.
            sb.AppendLine("select top 1 a.spare_id from (select spare_id,ship_id, sum(STOCKSAll) stocks from V_SPARE_STOCKS group by spare_id,ship_id) a ");
            sb.AppendLine(" inner join t_spare b on  a.spare_id=b.spare_id");
            if (CommonOperation.ConstParameter.IsLandVersion)
                sb.AppendLine(" inner join T_USER_SHIP us on us.ship_id=a.ship_id and us.userid = '" + CommonOperation.ConstParameter.UserId + "'");

            sb.AppendLine(" where b.ALERTSTOCK > a.stocks");

            if (dbAccess.GetDataTable(sb.ToString(), out dtb, out err))
            {
                if (dtb != null && dtb.Rows.Count > 0)
                {
                    return (IRemind)new SpareStockLowerAlert();
                }
            }
            return null;
        }
    }
}