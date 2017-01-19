using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ItemsManage.DataObject;
using ItemsManage.Services;
using CommonViewer.BaseControl;

namespace Maintenance.Viewer
{
    public partial class FrmTotalGauge : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmTotalGauge instance = new FrmTotalGauge();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmTotalGauge Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmTotalGauge.instance = new FrmTotalGauge();
                }

                return FrmTotalGauge.instance;
            }
        }

        #endregion

        /// <summary>
        /// 存放列与列标题的集合.
        /// </summary>
        private Dictionary<string, string> dictColumns = new Dictionary<string, string>();
        private Dictionary<string, string> dictColumnsSun = new Dictionary<string, string>();

        private Gauge gauge;
        public Gauge Gauge
        {
            get { return gauge; }
            set
            {
                if (null == value)
                {
                    gauge = null;
                    return;
                }
                gauge = value;
            }
        }

        public FrmTotalGauge()
        {
            InitializeComponent();
            this.AcceptButton = btnSave;
        }

        private void FrmTotalGauge_Load(object sender, EventArgs e)
        {
            this.loadGauge();                   //加载当前表值.
            this.loadFiveGauge();               //加载5次抄表记录.
            this.loadSunComponent();            //加载子设备列表.

            ////加载网格控件默认的列宽信息.
            dgvGauge.LoadGridView("FrmTotalGauge.dgvGauge");
            dgvSunComponent.LoadGridView("FrmTotalGauge.dgvSunComponent");
        }

        private void loadGauge()
        {
            string err;
            ComponentUnit component = new ComponentUnit();
            component = ComponentUnitService.Instance.getObject(gauge.COMPONENT_UNIT_ID, out err);
            if (component == null) return;
            lbComponentName.Text = component.COMP_CHINESE_NAME;

            lbLastGauge.Text = gauge.TOTAL_WORKHOURS.ToString();
            if (!gauge.GAUGE_TIME.ToShortDateString().Equals("0001-1-1"))
            {
                lbLastTime.Text = gauge.GAUGE_TIME.ToShortDateString();
            }
        }

        private void loadFiveGauge()
        {
            string err;
            DataTable dtbGaugeLog = GaugeLogService.Instance.getInfoTopFive(gauge.COMPONENT_UNIT_ID, out err);
            dgvGauge.DataSource = dtbGaugeLog;

            //设置列标题.
            dictColumns.Clear();
            dictColumns.Add("total_workhours", "总运转小时");
            dictColumns.Add("increase_hours", "递增值");
            dictColumns.Add("gauge_time", "抄表时间");
            dictColumns.Add("inputor", "抄表人");
            dgvGauge.SetDgvGridColumns(dictColumns);
        }

        private void loadSunComponent()
        {
            DataTable dtbSunComponent = GaugeService.Instance.GetSunComponent(gauge.COMPONENT_UNIT_ID);
            dgvSunComponent.DataSource = dtbSunComponent;

            //设置列标题.
            dictColumnsSun.Clear();
            dictColumnsSun.Add("comp_chinese_name", "设备名称");
            dictColumnsSun.Add("total_workhours", "当前总运转小时");

            dgvSunComponent.SetDgvGridColumns(dictColumnsSun);
        }
        private void FrmTotalGauge_FormClosing(object sender, FormClosingEventArgs e)
        {
            //保存网格控件各列的列宽信息.
            dgvGauge.SaveGridView("FrmTotalGauge.dgvGauge");
            dgvSunComponent.SaveGridView("FrmTotalGauge.dgvSunComponent");
            instance = null;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string err;
            if (!checkForm())
            {
                return;
            }

            Gauge tempGauge = formToObject();
            if (!CheckHours(tempGauge, out err))
            {
                return;
            }
            if (GaugeService.Instance.saveUnitAndLog(tempGauge, out err))
            {
                if (!UpdateCollect(tempGauge, out err))
                {
                    return;
                }
                this.DialogResult = DialogResult.OK;
                MessageBoxEx.Show("保存成功", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.No;
                MessageBoxEx.Show("保存失败", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool checkForm()
        {
            TimeSpan ts = dateGauge.Value - gauge.GAUGE_TIME;
            if (gauge.GAUGE_TIME.ToShortDateString().Equals("0001-1-1"))    //如果设备没有定时初始化则要求进行初始化.
            {
                MessageBoxEx.Show("请对设备进行定时初始化!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (numCurValue.Value <= gauge.TOTAL_WORKHOURS)
            {
                MessageBoxEx.Show("抄表值必须大于上次抄表值!", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numCurValue.Focus();
                return false;
            }
            else if ((numCurValue.Value - gauge.TOTAL_WORKHOURS) > (int)ts.TotalHours)
            {
                string mess = "抄表时间: " + dateGauge.Value.ToString() + " 不可能比上次抄表时间: "
                    + gauge.GAUGE_TIME.ToString() + " 多 " + (numCurValue.Value - gauge.TOTAL_WORKHOURS) + "小时的时间间隔!";
                MessageBoxEx.Show(mess, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);

                numCurValue.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool UpdateCollect(Gauge tempGauge, out string err)
        {
            if (MaintenanceConfig.reinitializeCollect == null)
            {
                err = "";
                return true;
            }
            if (!MaintenanceConfig.reinitializeCollect(tempGauge.COMPONENT_UNIT_ID, Convert.ToDouble(tempGauge.TOTAL_WORKHOURS), out err))
            {
                MessageBoxEx.Show("更新采集信息失败", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            DataTable dtbSunComponent = GaugeService.Instance.GetSunComponent(tempGauge.COMPONENT_UNIT_ID);
            if (dtbSunComponent.Rows.Count > 0)
            {
                foreach (DataRow dr in dtbSunComponent.Rows)
                {
                    if (!MaintenanceConfig.reinitializeCollect(dr["component_unit_id"].ToString(), Convert.ToDouble(dr["total_workhours"]) + Convert.ToDouble(tempGauge.INCREASE_HOURS), out err))
                    {
                        MessageBoxEx.Show("更新子设备采集信息失败", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;
        }
        private bool CheckHours(Gauge tempGauge, out string err)
        {
            if (MaintenanceConfig.getTotalHours == null)
            {
                err = "";
                return true;
            }
            double nowTotalHours = 0;
            if (!MaintenanceConfig.getTotalHours(tempGauge.COMPONENT_UNIT_ID, out nowTotalHours, out err))
            {
                MessageBoxEx.Show("获取采集小时数失败", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            err = "";
            if (Convert.ToDouble(numCurValue.Value) > nowTotalHours)
            {
                if (DialogResult.No == MessageBoxEx.Show("抄表值大于采集设备采集到的表值" + nowTotalHours + ",确认输入的表值正确吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    numCurValue.Focus();
                    return false;
                }
            }
            return true;
        }

        private Gauge formToObject()
        {
            Gauge tempGauge = (Gauge)gauge.Clone();
            tempGauge.GAUGE_TIME = dateGauge.Value;

            //缺输入时间.

            tempGauge.TOTAL_WORKHOURS = numCurValue.Value;
            tempGauge.INCREASE_HOURS = numCurValue.Value - gauge.TOTAL_WORKHOURS;

            return tempGauge;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void dateGauge_ValueChanged(object sender, EventArgs e)
        {
            if (dateGauge.Value.Date > DateTime.Now.Date)
            {
                MessageBoxEx.Show("抄表时间不允许大于当前时间!");
                dateGauge.Value = DateTime.Now;
            }
        }
    }
}