/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：MappingAlert.cs
 * 创 建 人：王鹏程
 * 创建时间：2011-05-23
 * 标    题：映射报警
 * 功能描述：
 * 修 改 人： 
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using System.Windows.Forms;
using SAPFunction.Viewer;
using SAPFunction.DataObject;

namespace SAPFunction.Services
{
    public class MappingAlert : CommonOperation.Interfaces.IRemind
    {
        private static string message = "";
        /// <summary>
        /// 当前对象的报警颜色，以及鼠标tag信息.
        /// </summary>
        /// <param name="tag">图标上显示的鼠标tag</param>
        /// <returns>报警颜色值</returns>
        public remindColor getStatus(out string tag)
        {
            tag = message;

            return remindColor.Red;
        }

        /// <summary>
        /// 点击报警图标后需要打开的窗体或处理的事件.
        /// </summary>
        public void viewInfo()
        {
            FrmMapping frm = FrmMapping.Instance;
            if (CommonViewer.CommonViewConfig.MainForm != null) frm.MdiParent = CommonViewer.CommonViewConfig.MainForm;
            frm.BringToFront();
            frm.Show();
        }

        public static IRemind GetAlarmObject(string userId)
        {
            string err = "";         //错误信息返回参数.
            bool isalert;
            if (!CheckAlert(out isalert, out err))
                return null;// throw new Exception(err); 为调试避免中断,作此修改.
            if (isalert)
            {
                return (IRemind)new MappingAlert();
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 检查是否有需要报警的.
        /// </summary>
        /// <param name="isalert"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public static bool CheckAlert(out bool isalert, out string err)
        {
            err = "";
            isalert = false;
            DataTable dtbMaterialAlert;
            if (!MaterialMappingService.Instance.GetMapping(null, null, "'1','2','5'", out dtbMaterialAlert, out err))
                return false;
            if (dtbMaterialAlert.Rows.Count > 0)
            {
                message = "存在物料映射不存在或错误";
                isalert = true;
                return true;
            }

            DataTable dtbInternalOrderAlert;
            if (!InternalOrderMappingService.Instance.GetMapping(null, null, null, "'1','2','5'", out dtbInternalOrderAlert, out err))
                return false;
            if (dtbInternalOrderAlert.Rows.Count > 0)
            {
                message = "存在内部订单映射不存在或错误";
                isalert = true;
                return true;
            }

            DataTable dtbSupplierAlert;
            if (!SupplierMappingService.Instance.GetMapping(null, null, "'1','2','5'", out dtbSupplierAlert, out err))
                return false;
            if (dtbSupplierAlert.Rows.Count > 0)
            {
                message = "存在供应商映射不存在或错误";
                isalert = true;
                return true;
            }
            return true;
        }
    }
}
