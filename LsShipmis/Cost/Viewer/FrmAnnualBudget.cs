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
using CommonViewer.BaseControlService;
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using System.Runtime.InteropServices;
using Cost.DataObject;
using Cost.Services;
using Cost.Viewer;
using CommonViewer.BaseControl;

namespace Cost.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    /// 
    public partial class FrmAnnualBudget : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmAnnualBudget instance = new FrmAnnualBudget();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmAnnualBudget Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmAnnualBudget.instance = new FrmAnnualBudget();
                }
                return FrmAnnualBudget.instance;
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

        private IDBOperation commonOpt = CommonOperation.Functions.InterfaceInstantiation.NewADBOperation();//定义一个公共类CommonOpt对象.

        bool isFirstLoadMain = true;
        Dictionary<string, string> dictColumns = new Dictionary<string, string>();

        #endregion

        #region 其它公共业务类

        private FormControlOption other = FormControlOption.Instance;

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmAnnualBudget()
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

            string[] sCols = new string[] { "NODE_NAME", "Currency" };
            dgvMain.setDgvColumnsReadOnly(sCols);
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
        /// 加载主数据.
        /// </summary>
        public void loadMainData()
        { 
            
            string err = "";
            YearMonth = new DateTime(dateYear.Value.Year, 1, 1);      
            DataTable dtb =  ANNUAL_BUDGETService.Instance.getInfoByYear(ucShipSelect1.GetId(), yearMonth, out err);
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
            dictColumns.Add("NODE_NAME", "科目大类名称");
            dictColumns.Add("AMOUNT", "金额");
            dictColumns.Add("Currency", "币种");
            dgvMain.SetDgvGridColumns(dictColumns);
            isFirstLoadMain = false;
        }

        private void dateYear_ValueChanged(object sender, EventArgs e)
        {
            loadMainData();
        }

        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            string err = "";
            ANNUAL_BUDGETService.Instance.createByYear(ucShipSelect1.GetId(), yearMonth, out err);

            //刷新列表.
            loadMainData();
        }

        /// <summary>
        /// 删除操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            if (dgvMain.CurrentRow == null)
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }

            string err;
            DialogResult response = MessageBoxEx.Show("您确定要删除本条预算吗？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (response == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            if (ANNUAL_BUDGETService.Instance.deleteUnit(dgvMain.CurrentRow.Cells["BUDGET_ID"].Value.ToString(), out err))
            {
                MessageBoxEx.Show("删除成功!", "", new MessageBoxButtons(), MessageBoxIcon.Information);
                loadMainData();
            }
            else
            {
                MessageBoxEx.Show("当前对象删除失败,错误原因是:\n\n" + err, "", new MessageBoxButtons(), MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            string err="";

            if (saveDetails(out err))
            {
                MessageBoxEx.Show("保存成功!", "", new MessageBoxButtons(), MessageBoxIcon.Information);
            }
            else {
                MessageBoxEx.Show("当前操作失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
            }
        }

        private bool saveDetails(out string err)
        {
            err = "";

            dgvMain.EndEdit();

            if (dgvMain.Rows.Count == 0) return true;
            //***************数据校验*****************************************************************************
            if (this.validateDet() == false)
            {
                return false;
            }
            //***************数据保存*****************************************************************************
            DataTable dtb = (DataTable)dgvMain.DataSource;

            //批量保存数据.
            return commonOpt.SaveFormData(dtb, "T_COST_ANNUAL_BUDGET", 0, out err);//保存数据.
        }

        /// <summary>
        /// 明细数据保存时的校验函数.
        /// </summary>
        /// <returns>如果校验通过，返回true；否则返回false</returns>
        private bool validateDet()
        {
            if (dgvMain.HasEmptyVal("AMOUNT") == true)
            {
                MessageBoxEx.Show("金额是必填内容！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dgvMain.IsNumeric("AMOUNT") == false)
            {
                MessageBoxEx.Show("金额必须是数值型数据！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
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
    }
}