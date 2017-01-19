/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：夏喜龙
 * 创建时间：2011-5-12
 * 功能描述：船舶设备分类信息管理的相关功能
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
    /// 
    public partial class FrmShipBill : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmShipBill instance = new FrmShipBill();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmShipBill Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmShipBill.instance = new FrmShipBill();
                }
                return FrmShipBill.instance;
            }
        }
        #endregion

        #region 窗体对象

        public string ShipID
        {
            set
            {
                ucShipSelect1.SelectedId(value);
            }
        }

        private DateTime yearMonth;
        public DateTime YearMonth
        {
            get { return yearMonth; }
            set { yearMonth = value; }
        }

        bool isFirstLoadMain = true;
        Dictionary<string, string> dictColumns = new Dictionary<string, string>();

        #endregion

        #region 其它公共业务类

        private FormControlOption other = FormControlOption.Instance;

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmShipBill()
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
            ucShipSelect1.ChangeSelectedState(false, true);
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

            YearMonth = dateYear.Value;

            DataTable dtb = ACTUAL_COSTSService.Instance.getShipBill(yearMonth, ucShipSelect1.GetId(), out err);//获取实际费用.
            dgvMain.DataSource = dtb;

            //加载主列项.

            if (isFirstLoadMain)
            {
                loadDataCol();
            }
            dgvMain.SetDataGridViewNoSort();

            setColorState();
        }

        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataCol()
        {
            dictColumns.Clear();

            //设置列标题.

            dictColumns.Add("NODE_NAME", "科目");
            dictColumns.Add("OCCURENCY_DATE", "发生日期");
            dictColumns.Add("COMPLETE_DATE", "完成日期");
            dictColumns.Add("COMPLETE_PALCE", "完成地点");
            dictColumns.Add("REMARK", "项目内容");
            dictColumns.Add("CUSTOMER", "收款/施工单位");
            dictColumns.Add("INVOICE_DATE", "开票日期");
            dictColumns.Add("PAYMENT_DATE", "付款日期");         
            dictColumns.Add("INVOICE_NUM", "发票号码");
            dictColumns.Add("CURRENCYNAME", "币种");
            dictColumns.Add("AMOUNT", "金额");
            dictColumns.Add("CONVERT_MONEY", "折算美金(USD)");
            dictColumns.Add("bamount", "预算金额");
            dgvMain.SetDgvGridColumns(dictColumns);

            dgvMain.Columns["NODE_NAME"].Width = 200;       //设列宽

            isFirstLoadMain = false;
        }

        private void dateYear_ValueChanged(object sender, EventArgs e)
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

            OperationExcel operationExcel = null;
            try
            {
                string err;
                string title = ucShipSelect1.GetText() + yearMonth.Year.ToString() + "年度费用清单";
                if (!ACTUAL_COSTSService.Instance.GetOperationExcelOfShipBill(yearMonth, ucShipSelect1.GetId(), title, out operationExcel, out err))
                {
                    MessageBoxEx.Show("未正常获取信息,不能输出,错误信息为:\r" + err);
                }
                else
                {
                    FrmOurReport frm = new FrmOurReport("全年单船费用核算导出", operationExcel);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
            }
            catch(Exception ex) {
                MessageBoxEx.Show("不能输出,错误信息为:\r" + ex);
            }
            finally
            {
                if (operationExcel != null)
                    operationExcel.Dispose();
            }

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

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            loadMainData();
        }

        /// <summary>
        /// 给合计、小计设置颜色.
        /// </summary>
        private void setColorState()
        {
            string alertState = "";

            foreach (DataGridViewRow dgvRow in dgvMain.Rows)
            {
                alertState = dgvRow.Cells["NODE_NAME"].Value.ToString();
                if (alertState.Contains(" 小计"))
                {
                    dgvRow.DefaultCellStyle.BackColor = Color.LightYellow;
                }
                if (alertState.Contains(" 合计"))
                {
                    dgvRow.DefaultCellStyle.BackColor = Color.Gold;
                }
            }
        }

        private void FrmShipBill_Shown(object sender, EventArgs e)
        {
            setColorState();
        }
    }
}