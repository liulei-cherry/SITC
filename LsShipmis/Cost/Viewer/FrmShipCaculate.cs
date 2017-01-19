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
    public partial class FrmShipCaculate : FormBase
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmShipCaculate instance = new FrmShipCaculate();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmShipCaculate Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmShipCaculate.instance = new FrmShipCaculate();
                }
                return FrmShipCaculate.instance;
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
        private FrmShipCaculate()
        {
            InitializeComponent();
        }

        #region 主窗体加载
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
        #endregion

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

            DataTable dtb = ACTUAL_COSTSService.Instance.getShipCaculate(yearMonth, ucShipSelect1.GetId(), out err);//获取实际费用.
            dgvMain.DataSource = dtb;

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

            dictColumns.Add("OCCURENCY_DATE", "发生日期");
            dictColumns.Add("PAYMENT_DATE", "付款日期");            
            dictColumns.Add("CUSTOMER", "付款对象");
            dictColumns.Add("DESCRIPTION", "付款说明");
            dictColumns.Add("CURRENCYNAME", "币种");
            dictColumns.Add("AMOUNT", "金额");
            dictColumns.Add("CONVERT_MONEY", "折算美金(USD)");

            dgvMain.SetDgvGridColumns(dictColumns);
            dgvMain.Columns["CUSTOMER"].Width = 300;
            dgvMain.Columns["DESCRIPTION"].Width = 200;
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
                string title = ucShipSelect1.GetText() + yearMonth.Year.ToString() + "年全年单船费用核算";
                if (!ACTUAL_COSTSService.Instance.GetOperationExcelOfShipCaculate(yearMonth, ucShipSelect1.GetId(), title, out operationExcel, out err))
                {
                    MessageBoxEx.Show("未正常获取信息,不能输出,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                }
                else
                {
                    FrmOurReport frm = new FrmOurReport("全年单船费用核算导出", operationExcel);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
            }
            catch (Exception ex){
                MessageBoxEx.Show(ex.Message, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
            }
            finally
            {
                if (operationExcel != null)
                    operationExcel.Dispose();
            }

        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            loadMainData();
        }
    }
}