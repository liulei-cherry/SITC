using BaseInfo.DataAccess;
using BaseInfo.Objects;
using Maintenance.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Maintenance.Viewer
{
    public partial class FrmPmsAnnualPlan : CommonViewer.BaseForm.FormBase
    {
        #region 窗体变量
        #region  窗体实例化
        private static FrmPmsAnnualPlan instance;
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmPmsAnnualPlan Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmPmsAnnualPlan.instance = new FrmPmsAnnualPlan();
                }
                return FrmPmsAnnualPlan.instance;
            }
        }
        #endregion

        #region 输出参数，错误信息
        /// <summary>
        /// 输出参数，错误信息.
        /// </summary>
        String errMessage;
        #endregion

        #endregion

        #region 窗体构造函数
        /// <summary>
        /// 窗体构造函数.
        /// </summary>
        public FrmPmsAnnualPlan()
        {
            InitializeComponent();
        }

        #endregion

        #region 窗体方法

        #region 初始化部门下拉框，其中value为部门长的岗位id.
        /// <summary>
        /// 初始化部门下拉框，其中value为部门长的岗位id.
        /// </summary>
        private void LoadDepartMent()
        { 
            cboDepartMent.DisplayMember = "name";
            cboDepartMent.ValueMember = "Id";
            DataTable dtbDepart = new DataTable();
            dtbDepart.Columns.Add("Id", typeof(string));
            dtbDepart.Columns.Add("name", typeof(string));
            
            PostService postService =BaseInfo.DataAccess.PostService.Instance; 

            dtbDepart.Rows.Add(postService.getObjectByType("轮机长岗位", out errMessage).PostId, "轮机部");
            dtbDepart.Rows.Add(postService.getObjectByType("大副岗位", out errMessage).PostId, "甲板部");    
            cboDepartMent.DataSource = dtbDepart;
            cboDepartMent.Text = "轮机部";
        }

        #endregion

        #region  初始化年份下拉框，允许自动向前向后各推5年.
        /// <summary>
        /// 初始化年份下拉框，允许自动向前向后各推5年.
        /// </summary>
        private void LoadYear()
        {
            cboyear.DisplayMember = "name";
            cboyear.ValueMember = "Id";
            int year = DateTime.Now.Year;
            DataTable dtbYear = new DataTable();
            dtbYear.Columns.Add("Id", typeof(string));
            dtbYear.Columns.Add("name", typeof(string));

            for (int i = year-5; i < year+6; i++)
            {
                dtbYear.Rows.Add(i-year+5, i);
            }

            cboyear.DataSource = dtbYear;
            cboyear.SelectedValue = 5;
        }

        #endregion

        #region 为grid绑定数据源
        /// <summary>
        /// 为grid绑定数据源.
        /// </summary>
        /// <param name="shipId">船舶id.</param>
        /// <param name="departmentHeaderPostId">部门长岗位id.</param>
        /// <param name="year">年份.</param>
        private void SetDgvDataSouce(String shipId,String departmentHeaderPostId,int year)
        {
            DateTime dateTime = new DateTime(year, 1, 1, 0, 0, 0);
            String beginDate = dateTime.ToString();
            String endDate = dateTime.AddYears(1).AddSeconds(-1).ToString();

            bdDgvSource.DataSource = PmsAnnualPlanAccess.Instance.GetPmsAnnualPlan(shipId, departmentHeaderPostId, beginDate,endDate, out errMessage);
            
            dgv.DataSource = bdDgvSource;
        }

        #endregion 

        #region 加载维护保养年度计划内容
        /// <summary>
        /// 加载维护保养年度计划内容.
        /// </summary>
        private void LoadPmsAnnualPlan()
        {
            if (String.IsNullOrEmpty(ucShipSelect1.GetId())
                || null == cboDepartMent.SelectedValue
                ||String.IsNullOrEmpty(cboyear.Text))
            {
                return;
            }
            SetDgvDataSouce(ucShipSelect1.GetId(), cboDepartMent.SelectedValue.ToString(), int.Parse(cboyear.Text));

            SetDgvSortable();


        }

        #endregion

        #region 设置grid不可排序
        /// <summary>
        /// 设置grid不可排序.
        /// </summary>
        private void SetDgvSortable()
        {
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (i>3)
                {
                    dgv.Columns[i].Width = 40;
                }
            }
            SetGridWidth();
        }
        #endregion 

        #region 设置grid的宽度
        /// <summary>
        /// 设置grid的宽度.
        /// </summary>
        private void SetGridWidth()
        {
            if (null != dgv.HeadSource && dgv.HeadSource.Find("nodeChangeName", false).Length>0)
            {
                dgv.HeadSource["nodeChangeName"].Text =cboyear.Text+ "年";  
            }
            if (null != dgv.Columns && dgv.Columns.Count > 0)
            {
                dgv.Columns["workinfocode"].Width = 60;
                dgv.Columns["HEADSHIP_NAME"].Width = 60;
                dgv.Columns["workname"].Width = 250;
                dgv.Columns["WORKINFODETAIL"].Width = 450;
            }
        }
        #endregion

        #endregion

        #region 窗体事件

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPmsAnnualPlan_Load(object sender, EventArgs e)
        {
            LoadDepartMent();
            LoadYear();
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                ucShipSelect1.ChangeSelectedState(false, false);
                ucShipSelect1.Enabled = true;
            }
            else
            {
                //ucShipSelect1.SelectedId(CommonOperation.ConstParameter.ShipId);
                ucShipSelect1.Enabled = false;
            }
            LoadPmsAnnualPlan();
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            LoadPmsAnnualPlan();
        }

        private void cboDepartMent_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadPmsAnnualPlan();
        }

        private void cboyear_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadPmsAnnualPlan();
        }

        private void FrmPmsAnnualPlan_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void BtnExportToExcel_Click(object sender, EventArgs e)
        {
            dgv.Title = "维护保养年度计划";
            dgv.Header.Clear();
            dgv.Header.Add("船名：" + ucShipSelect1.GetText() + "                          部门：" + cboDepartMent.Text + "                          年份：" + cboyear.Text);
            dgv.OutPutExcel();
        }

        #endregion
    }
}
