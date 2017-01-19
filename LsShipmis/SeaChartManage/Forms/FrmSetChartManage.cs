using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SeaChartManage.Services;
using SeaChartManage.BusinessClasses;
using CommonViewer.BaseControlService;
using CommonViewer.BaseForm;
using CommonViewer.BaseControl;

namespace SeaChartManage.Forms
{
    public partial class FrmSetChartManage : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmSetChartManage instance;

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmSetChartManage Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmSetChartManage.instance = new FrmSetChartManage();
                }
                return FrmSetChartManage.instance;
            }
        }
        #endregion

        public FrmSetChartManage()
        {
            InitializeComponent();
        }

        private void FrmSetChartManage_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(false, true);

            LoadChartData();
            
        }
 
        private void LoadChartData()
        {
            string err;

            DataTable dt = t_chartService.Instance.getInfo(out err);
            if (dt != null)
            {
                dataGridView.DataSource = dt;
                this.dataGridView.DataSource = dt;
                dataGridView.LoadGridView("FrmSetChartManage");
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
                dataGridView.ReadOnly = false;
            }
            addSelectColumn();
            getData();
        }

        private void addSelectColumn()
        {
            DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn();
            chkCol.Name = "select";
            chkCol.HeaderText = "";
            this.dataGridView.Columns.Insert(0, chkCol);
            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                col.ReadOnly = true;
            }
            chkCol.ReadOnly = false;
            chkCol.Width = 40;
        }

        //在窗口加载的时候，显示当前船舶已经选中的海图信息.
        private void getData()
        {
            string shipId = ucShipSelect1.GetId();
            DataTable dt_ship = t_chart_shipService.Instance.getChartId(shipId, out err);

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                string chartId = row.Cells["chartid"].Value.ToString();
                if (dt_ship.Select("chartid='" + chartId + "'").Length > 0)
                {
                    row.Cells["select"].Value = "True";
                }
            }

        }
        //----------保存---------
        string chartid = "";//被选择的海图信息id
        string shipId = ""; //船舶Id
        string err;

        private void SToolStripButton_Click(object sender, EventArgs e)
        {
            dataGridView.EndEdit();
            shipId = ucShipSelect1.GetId();
            t_chart_shipService.Instance.delete(shipId, out err);

            if (dataGridView.RowCount >= 0)
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.Cells["select"].Value != null)
                    {
                        if (row.Cells["select"].Value.ToString() == "True")
                        {
                            t_chart_ship chartship = new t_chart_ship();
                            chartid = row.Cells["chartid"].Value.ToString();
                            chartship.chartid = chartid;
                            chartship.ship_id = shipId;
                            chartship.portid = "";
                            if (!t_chart_shipService.Instance.saveUnit(chartship, out err))
                                MessageBoxEx.Show("保存失败", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                MessageBoxEx.Show("保存成功", "提示信息", MessageBoxButtons.OK);
                this.Close();
            }
        }
         //----------保存结束---------
        private void FrmSetChartManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance = null;
            dataGridView.SaveGridView("FrmSetChartManage");
        }

        private void bdNgClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// 当船舶下拉列表值改变时重新查询.
        private void cboShip_DropDownClosed(object sender, EventArgs e)
        {
            this.LoadChartData(); 
        }

    }
}