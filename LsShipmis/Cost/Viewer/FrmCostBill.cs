/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：夏喜龙
 * 创建时间：2011-5-12
 * 功能描述：
 * 修 改 人： 
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using CommonOperation.BaseClass;
using CommonViewer.BaseForm;
using CommonViewer.BaseControlService;
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using System.Runtime.InteropServices;
using Cost.DataObject;
using Cost.Services;
using Cost.Viewer;
using CommonViewer.BaseControl;
using CommonViewer;
using OfficeOperation;

namespace Cost.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    public partial class FrmCostBill : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmCostBill instance = new FrmCostBill();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmCostBill Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmCostBill.instance = new FrmCostBill();
                }
                return FrmCostBill.instance;
            }
        }
        #endregion

        #region 窗体对象

        bool isFirstLoadMain = true;
        Dictionary<string, string> dictColumns = new Dictionary<string, string>();

        #endregion

        #region 其它公共业务类

        private FormControlOption other = FormControlOption.Instance;

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmCostBill()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPortInfo_Load(object sender, EventArgs e)
        {
            dateStart.Value = DateTime.Now.AddMonths(-6);
            loadMainData();
        }

        /// <summary>
        /// 主窗体关闭.
        /// </summary>
        private void FrmWorkinfoTempletClass_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
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

        /// <summary>
        /// 加载主列表数据.
        /// </summary>
        public void loadMainData()
        {
            string err = "";
            DataTable dtb = VOUCHERService.Instance.GetPayDateInfo(dateStart.Value, dateEnd.Value,chkRecord.Checked, out err);//获取实际费用.
            bindingSource1.DataSource = dtb;
            dgvMain.DataSource = bindingSource1;

            //加载主列项.
            if (isFirstLoadMain)
            {
                loadDataCol();
            }

        }

        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataCol()
        {
            dictColumns.Clear();

            //设置列标题.
            dictColumns.Add("ESTIMATE_PAY_DATE", "预计付款日期");
            dictColumns.Add("PAY_DATE", "实际付款日期");
            dictColumns.Add("VOUCHER_NUM", "凭证号");
            dictColumns.Add("VOUCHER_DATE", "凭证日期");
            dictColumns.Add("SHIP_OWNER", "应收船东");
        //    dictColumns.Add("APPLICANT", "提交人");
            dictColumns.Add("NODE_NAME", "科目");
            dictColumns.Add("Code", "费用科目编码");
            dictColumns.Add("DESCRIPTION", "项目说明");
            dictColumns.Add("PAYEE", "收款人");
            dictColumns.Add("AMOUNT", "项目金额");
            dictColumns.Add("CURRENCYNAME", "币种");
            dictColumns.Add("CURRENT_STATE_NAME", "状态");
            dictColumns.Add("remark", "费用说明");
            dictColumns.Add("INVOICE_NUM", "附发票份数"); 
         //   dictColumns.Add("APPLY_COMPANY", "申请单位");

            dgvMain.SetDgvGridColumns(dictColumns, "mulselect");
            isFirstLoadMain = false;
        }

        private void dateYear_ValueChanged(object sender, EventArgs e)
        {
            loadMainData();
        }

        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            loadMainData();
        }

        private void chkRecord_CheckedChanged(object sender, EventArgs e)
        {
            loadMainData();
        }

        /// <summary>
        /// 打开导出报表窗口.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {

            //OperationExcel operationExcel = null;
            //try
            //{
            //    string err;
            //    string title = ucShipSelect1.GetText() + yearMonth.Year.ToString() + "年度费用清单";
            //    if (!ACTUAL_COSTSService.Instance.GetOperationExcelOfShipBill(yearMonth, ucShipSelect1.GetId(), title, out operationExcel, out err))
            //    {
            //        MessageBoxEx.Show("未正常获取信息,不能输出,错误信息为:\r" + err);
            //    }
            //    else
            //    {
            //        FrmOurReport frm = new FrmOurReport("全年单船费用核算导出", operationExcel);
            //        frm.StartPosition = FormStartPosition.CenterScreen;
            //        frm.ShowDialog();
            //    }
            //}
            //catch(Exception ex) {
            //    MessageBoxEx.Show("不能输出,错误信息为:\r" + ex);
            //}
            //finally
            //{
            //    if (operationExcel != null)
            //        operationExcel.Dispose();
            //}

        }

        #region IFunctionChildWindow 成员

        public new List<CommonOperation.BaseClass.Authority> GetAllAuthorityCanOpenThisWindow()
        {
            List<CommonOperation.BaseClass.Authority> re = new List<CommonOperation.BaseClass.Authority>();
            re.Add(CommonOperation.BaseClass.Authority.GetALoginUserAuthority());//最低权限即可.

            return re;
        }

        //本窗体不受限制.
        public new bool JudgeTheAuthorityCanOpenThisWindow(CommonOperation.BaseClass.Authority theAuthority)
        {
            return true;
        }

        private IFunctionMainWindow theMainForm;
        public new IFunctionMainWindow TheMainForm
        {
            get { return theMainForm; }
            set { theMainForm = value; }
        }

        #endregion

        /// <summary>
        /// 过滤，查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (txtFilter.Text.Trim().Length > 0)
            {
                string theFilterString = txtFilter.Text.Trim().Replace("'", "''");
                bindingSource1.Filter = "VOUCHER_NUM like '%" + theFilterString + "%' or PAYEE like '%" + theFilterString + "%'";
            } else bindingSource1.Filter = null;
        }


        /// <summary>
        /// 保存预计付款日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreDateSave_Click(object sender, EventArgs e)
        {
            List<string> voucher_idsAdd = new List<string>();
            List<string> voucher_idsUpdate = new List<string>();

            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                if (row.Cells["mulselect"].Value != null)
                {
                    if (string.IsNullOrEmpty(row.Cells["ESTIMATE_PAY_DATE"].Value.ToString()) && string.IsNullOrEmpty(row.Cells["PAY_DATE"].Value.ToString()))
                    {
                        voucher_idsAdd.Add(row.Cells["VOUCHER_ID"].Value.ToString());
                    }
                    else
                    {
                        voucher_idsUpdate.Add(row.Cells["VOUCHER_ID"].Value.ToString());
                    }
                }
            }

            string err = "";
            if (!VOUCHERService.Instance.AddCostBillPrePayDate(datePay.Value, voucher_idsAdd, voucher_idsUpdate, out err))
            {
                MessageBoxEx.Show("报错:" + err);
                return;
            }

            loadMainData();//刷新界面
        }


        /// <summary>
        /// 保存实际付款日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDateSave_Click(object sender, EventArgs e)
        {
            List<string> voucher_idsAdd = new List<string>();
            List<string> voucher_idsUpdate = new List<string>();

            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                if (row.Cells["mulselect"].Value != null)
                {
                    if (string.IsNullOrEmpty(row.Cells["ESTIMATE_PAY_DATE"].Value.ToString()) && string.IsNullOrEmpty(row.Cells["PAY_DATE"].Value.ToString()))
                    {
                        voucher_idsAdd.Add(row.Cells["VOUCHER_ID"].Value.ToString());
                    }
                    else
                    {
                        voucher_idsUpdate.Add(row.Cells["VOUCHER_ID"].Value.ToString());
                    }
                }
            }

            string err = "";
            if (!VOUCHERService.Instance.AddCostBillPayDate(datePay.Value, voucher_idsAdd, voucher_idsUpdate, out err))
            {
                MessageBoxEx.Show("报错:" + err);
                return;
            }

            loadMainData();//刷新界面
        }





        
    }
}