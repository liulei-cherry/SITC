/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：夏喜龙
 * 创建时间：2011-5-12
 * 功能描述：实际发生费用的管理
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
using Oil.DataObject;
using Oil.Services;
using Oil.Viewer;
using CommonViewer.BaseControl;
 
namespace Oil.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    /// 
    public partial class FrmOilAdd : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmOilAdd instance = new FrmOilAdd();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmOilAdd Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmOilAdd.instance = new FrmOilAdd();
                }
                return FrmOilAdd.instance;
            }
        }
        #endregion

        #region 窗体对象

        private HOilAdd currentObject;
        public HOilAdd CurrentObject
        {
            get { return currentObject; }
            set
            {
                currentObject = value;
                showObject(currentObject);
            }
        }

        private string shipID;
        public string ShipID
        {
            get { return shipID; }
            set
            {
                shipID = value;
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
        Dictionary<string, string> discRate = new Dictionary<string, string>();

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmOilAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOilAdd_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(false, true);

            setComboBox();                 //设置窗体所需的下拉列表框的数据源.

            loadMainData();
        }

        /// <summary>
        /// 主窗体关闭.
        /// </summary>
        private void FrmOilAdd_FormClosed(object sender, FormClosedEventArgs e)
        {
            dgvMain.SaveGridView("FrmOilAdd.dgvMain");
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

            //港口.
            DataTable dtb1 = PortInfoService.Instance.getInfo(out err);
            other.SetComboBoxValue(cobPort, dtb1);

            //燃油类型.
            DataTable dtb2 = HOilService.Instance.getFuelOilType(out err);
            other.SetComboBoxValue(cob2, dtb2);
        }

        /// <summary>
        /// 加载主数据.
        /// </summary>
        public void loadMainData()
        {

            shipID = ucShipSelect1.GetId();
            if (string.IsNullOrEmpty(shipID)) return;
            string err = "";
            YearMonth = new DateTime(dateYear.Value.Year, 1, 1);

            DataTable dtb =  HOilAddService.Instance.getInfoByYear(shipID, yearMonth, out err);
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
            dgvMain.LoadGridView("FrmOilAdd.dgvMain");
            //设置列标题.
            dictColumns.Add("ADD_DATE", "加油日期");
            dictColumns.Add("CNAME", "港口");
            dictColumns.Add("OIL_TYPE", "燃油类型");
            dictColumns.Add("SPECIFICATION", "规格型号");
            dictColumns.Add("AMOUNT", "数量(吨)");
            dictColumns.Add("SULPHUR", "含硫量(%)");
            dictColumns.Add("DENSITY", "比重(KG/L)");
            dictColumns.Add("REMARK", "备注");

            dgvMain.SetDgvGridColumns(dictColumns);
            isFirstLoadMain = false;
        } 
        private void dateYear_ValueChanged(object sender, EventArgs e)
        {
            loadMainData();
        }

        private void dgvMain_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string err = "";
                DataGridViewRow dr = dgvMain.Rows[e.RowIndex];

                string objectID = "";
                if (DBNull.Value != dr.Cells["FUEL_ID"].Value && null != dr.Cells["FUEL_ID"].Value)
                    objectID = dr.Cells["FUEL_ID"].Value.ToString();

                CurrentObject =HOilAddService.Instance.getObject(objectID, out err);
            }
        }

        private void showObject(HOilAdd tempObject)
        {
            if (tempObject != null)
            {
                date1.Value = tempObject.ADD_DATE;
                cobPort.SelectedValue = tempObject.PORT_ID;
                cob2.SelectedValue = tempObject.OIL_TYPE;
                txtSpe.Text = tempObject.SPECIFICATION;
                numAmount.Value = tempObject.AMOUNT;
                numSul.Value = tempObject.SULPHUR;
                numDensity.Value = tempObject.DENSITY;
                txtRemark.Text = tempObject.REMARK;
            }
            else {
                date1.Value = DateTime.Now;
                txtSpe.Text = "";
                numAmount.Value = 0;
                numSul.Value = 0;
                numDensity.Value = 0;
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
            if (string.IsNullOrEmpty(shipID))
            {
                MessageBoxEx.Show("船舶为空，不能添加!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime date = new DateTime();
            HOilAdd tempObject = new HOilAdd(null, shipID, "", date,"","", 0, 0,0, "");

            FrmEditOneOilAdd formNew = new FrmEditOneOilAdd(tempObject);
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
                    MessageBoxEx.Show("删除成功!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
                    loadMainData();
                }
                else
                {
                    MessageBoxEx.Show("当前对象删除失败,错误原因是:\n\n" + err, "", new MessageBoxButtons(), MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBoxEx.Show("请先选择一条记录!", "提示", new MessageBoxButtons(), MessageBoxIcon.Warning);
            }

        }

        private bool check(out string err)
        {
            err = "";

            if ("".Equals(cobPort.Text))
            {
                MessageBoxEx.Show("港口不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public void FormToObject(out string err)
        {
            err = "";
            if (currentObject != null)
            {
                currentObject.ADD_DATE = date1.Value;
                currentObject.AMOUNT = numAmount.Value;
                currentObject.DENSITY = numDensity.Value;
                currentObject.OIL_TYPE = cob2.SelectedValue.ToString();
                currentObject.PORT_ID = cobPort.SelectedValue.ToString();
                currentObject.REMARK = txtRemark.Text;
                currentObject.SPECIFICATION = txtSpe.Text;
                currentObject.SULPHUR = numSul.Value;
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
                if (!HOilAddService.Instance.saveUnit(currentObject, out err))
                {
                    MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBoxEx.Show("保存成功!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
                    //刷新列表.
                    loadMainData();
                }
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
    }
}