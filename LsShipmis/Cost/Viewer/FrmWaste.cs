﻿/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：夏喜龙
 * 创建时间：2011-7-25
 * 功能描述：油品信息的管理
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
    /// 油品信息管理窗体.
    /// </summary>
    /// 
    public partial class FrmWaste : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmWaste instance = new FrmWaste();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmWaste Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmWaste.instance = new FrmWaste();
                }
                return FrmWaste.instance;
            }
        }
        #endregion

        #region 窗体对象
        
        private CostWaste currentObject;
        public CostWaste CurrentObject
        {
            get { return currentObject; }
            set
            {
                currentObject = value;
                showObject();
            }
        }
 
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
        private FrmWaste()
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
            setComboBox();                 //设置窗体所需的下拉列表框的数据源.
            loadMainData();

            setRightIni();

        }

        /// <summary>
        /// 设置船岸端界面功能按钮(初始设定)
        /// </summary>
        private void setRightIni()
        {
            AddButton.Visible = !CommonOperation.ConstParameter.IsLandVersion;
            deleteButton.Visible = !CommonOperation.ConstParameter.IsLandVersion;
            SaveButton.Visible = !CommonOperation.ConstParameter.IsLandVersion;
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
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            string err = ""; 
            //船舶费用类型.
            DataTable dtb1 = CostSimpleclassService.Instance.getInfoByType("A",out err);
            other.SetComboBoxValue(cboType, dtb1);
        }

        /// <summary>
        /// 加载主数据.
        /// </summary>
        public void loadMainData()
        { 
            string err = "";
            YearMonth = new DateTime(dateYear.Value.Year, 1, 1);

            DataTable dtb = CostWasteService.Instance.getInfoByYear(ucShipSelect1.GetId(), yearMonth, out err);
            dgvMain.DataSource = dtb;

            //加载主列项.
            if (isFirstLoadMain)
            {
                loadDataCol();
            }

            if (dtb.Rows.Count == 0) CurrentObject = null;// 没有对象则显示置空.
        }

        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataCol()
        {
            dictColumns.Clear();

            //设置列标题.
            dictColumns.Add("OCCURENCY_DATE", "费用发生日期");
            dictColumns.Add("NAME", "类别");
            dictColumns.Add("DESCRIPTION", "描述");
            dictColumns.Add("ESTIMATE_AMOUNT", "估值(人民币元)");

            dgvMain.SetDgvGridColumns(dictColumns);
            isFirstLoadMain = false;
        }

        private void dgvMain_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string err = "";
                DataGridViewRow dr = dgvMain.Rows[e.RowIndex];

                string objectID = "";
                if (DBNull.Value != dr.Cells["COSTS_ID"].Value && null != dr.Cells["COSTS_ID"].Value)
                    objectID = dr.Cells["COSTS_ID"].Value.ToString();

                CurrentObject = CostWasteService.Instance.getObject(objectID, out err);
            }

        }

        private void showObject()
        {
            if (currentObject != null)
            {
                date1.Value = currentObject.OCCURENCY_DATE;
                cboType.SelectedValue = currentObject.CLASS_ID;
                numeAmount.Value = currentObject.ESTIMATE_AMOUNT;
                txtRemark.Text = currentObject.DESCRIPTION;
            }
            else {
                numeAmount.Value = 0;
                txtRemark.Text = "";
            }
        }

        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            CostWaste tempObject = new CostWaste(null,null, "",DateTime.Now,0M,ucShipSelect1.GetId());

            FrmWasteEdit formNew = new FrmWasteEdit(tempObject);
            formNew.ShowDialog();

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

            if (currentObject != null)
            {
                string err;
                DialogResult response = MessageBoxEx.Show("您确定要删除该条数据吗？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (response == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                if (currentObject.Delete(out err))
                {
                    MessageBoxEx.Show("删除成功!", "", new MessageBoxButtons(), MessageBoxIcon.Information);
                    loadMainData();
                }
                else
                {
                    MessageBoxEx.Show("当前对象删除失败,错误原因是:\n\n" + err, "", new MessageBoxButtons(), MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBoxEx.Show("请先选择一条记录!", "", new MessageBoxButtons(), MessageBoxIcon.Warning);
            }

        }

        private bool check(out string err)
        {
            err = "";

            if ("".Equals(cboType.Text))
            {
                MessageBoxEx.Show("分类不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public void FormToObject(out string err)
        {
            err = "";
            if (currentObject != null)
            {
                currentObject.OCCURENCY_DATE = date1.Value;
                currentObject.CLASS_ID = cboType.SelectedValue.ToString();
                currentObject.ESTIMATE_AMOUNT = numeAmount.Value;
                currentObject.DESCRIPTION = txtRemark.Text;
            }
        }

        /// <summary>
        /// 保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {

            string err;
            if (currentObject != null)
            {
                if (!check(out err))
                {
                    return;
                }

                this.FormToObject(out err);      //从界面获取数据到对象中.

                //保存对象.
                if (!currentObject.Update( out err))
                {
                    MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBoxEx.Show("保存成功!", "", new MessageBoxButtons(), MessageBoxIcon.Information);
                    //刷新列表.
                    loadMainData();
                }
            }
        } 

        private void dateYear_ValueChanged(object sender, EventArgs e)
        {
            loadMainData();
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