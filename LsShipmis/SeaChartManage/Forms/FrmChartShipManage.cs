using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SeaChartManage.Services;
using SeaChartManage.BusinessClasses;

using CommonViewer.BaseControlService;

namespace SeaChartManage.Forms
{
    public partial class FrmChartShipManage : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmChartShipManage instance = new FrmChartShipManage();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmChartShipManage Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmChartShipManage.instance = new FrmChartShipManage();
                }
                return FrmChartShipManage.instance;
            }
        }
        #endregion

        public FrmChartShipManage()
        {
            InitializeComponent();
        }

        private void FrmChartShipManage_Load(object sender, EventArgs e)
        {
            //设置窗体所需的下拉列表框的数据源.
            this.setComboBox();

            LoadChartData();
            DataGridViewExt.loadGridView(dataGridView, CommonOperation.ConstParameter.UserId, "SeaChartManage.Forms.FrmChartShipManage.dataGridView");
        }

        ///设置数据的下拉列表控件.
        private void setComboBox()
        {
            string err;
            //船舶选择的DataTable对象.
            DataTable dtbShip = BaseInfo.DataAccess.ShipInfoService.Instance.GetOwnerShip(out err);

            //船名下拉列表.
            cboShip.DataSource = dtbShip;
            cboShip.DisplayMember = "ship_name";
            cboShip.ValueMember = "ship_id";
        }

        private void LoadChartData()
        {
            string err;

            string shipId = ""; //船舶Id
            if (cboShip.SelectedValue != null) shipId = cboShip.SelectedValue.ToString();

            DataTable dt_ship = t_chart_shipService.Instance.getInfo(shipId, out err);

            if (dt_ship != null)
            {
                dataGridView.DataSource = dt_ship.DefaultView;
                dataGridView.LoadGridView("FrmChartShipManage");
                Dictionary<string, string> columns = new Dictionary<string, string>();
                columns.Add("chartnum", "图号");
                columns.Add("chartname", "图名(中文)");
                columns.Add("chartenglishname", "图名(英文)");
                columns.Add("chartrule", "比例尺1：N");
                columns.Add("paperchart", "纸质图");
                columns.Add("changedate", "改版日期");
                columns.Add("chartformat", "图积");
                columns.Add("sailtellnum", "航告期数");
                columns.Add("publishdept", "发布部门");
                columns.Add("remark", "备注");
                dataGridView.SetDgvGridColumns(columns);
            }
        }

        /// 当船舶下拉列表值改变时重新查询网格.
        private void cboShip_DropDownClosed(object sender, EventArgs e)
        {
            this.LoadChartData();
        }

        private void FrmChartShipManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridView.SaveGridView("FrmChartShipManage");
            instance = null;
        }

        private void bdNgClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //转到设置船配海图界面.
            SeaChartManage.Forms.FrmSetChartManage frm = SeaChartManage.Forms.FrmSetChartManage.Instance;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            LoadChartData();
        }

    }
}