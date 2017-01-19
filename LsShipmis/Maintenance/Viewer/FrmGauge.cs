using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ItemsManage.Services;
using ItemsManage.DataObject;

namespace Maintenance.Viewer
{
    public partial class FrmGauge : CommonViewer.BaseForm.FormBase
    {
        DateTime recordSpot;
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmGauge instance = new FrmGauge();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmGauge Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmGauge.instance = new FrmGauge();
                }

                return FrmGauge.instance;
            }
        }

        #endregion

        /// <summary>
        /// 存放列与列标题的集合.
        /// </summary>
        private Dictionary<string, string> dictColumns = new Dictionary<string, string>();

        private Gauge gauge;
        public Gauge TheGauge
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

        public FrmGauge()
        {
            InitializeComponent();
        }

        private void FrmGauge_Load(object sender, EventArgs e)
        {
            this.loadTimingMainEquip();         //加载有计时工作的主设备列表信息.
            this.timingMainEquipInit();
            //加载网格控件默认的列宽信息.
            dgvEquip.LoadGridView("FrmGauge.dgvEquip");
            recordSpot = DateTime.Now;
        }

        /// <summary>
        ///构建(抄表类型)的指定DataTable
        /// </summary>
        private DataTable buildDataTable()
        {
            DataTable t_gauge = new DataTable();
            t_gauge.Columns.Add("RECORD_TYPE", typeof(int));
            t_gauge.Columns.Add("NAME", typeof(string));
            DataRow row1 = t_gauge.NewRow();
            row1["RECORD_TYPE"] = 1;
            row1["NAME"] = "总值抄表";
            t_gauge.Rows.Add(row1);
            row1 = t_gauge.NewRow();
            row1["RECORD_TYPE"] = 2;
            row1["NAME"] = "递增抄表";
            t_gauge.Rows.Add(row1);

            return t_gauge;
        }

        /// <summary>
        /// 有计时工作的主设备列表信息.
        /// </summary>
        private void loadTimingMainEquip()
        {
            //取得未初始化的父子设备信息的DataTable对象.
            DataTable dtbTimingMainComp = GaugeService.Instance.GetTimingMainComp();
            dgvEquip.DataSource = dtbTimingMainComp;
        }

        /// <summary>
        /// 显示列初始化.
        /// </summary>
        private void timingMainEquipInit()
        {
            //设置列标题.
            dictColumns.Clear();
            dictColumns.Add("comp_chinese_name", "设备名称");
            dictColumns.Add("total_workhours", "总运转小时");
            dictColumns.Add("gauge_time", "上次抄表时间");
            dictColumns.Add("typename", "抄表方式和设置");

            dgvEquip.SetDgvGridColumns(dictColumns);
            dgvEquip.Columns["comp_chinese_name"].Tag = 0;

            Font font = new Font("Arial", 11, FontStyle.Underline);
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.Font = font;
            dgvEquip.Columns["typename"].DefaultCellStyle = cellStyle;

            //给网格dgvEquip动态添加一个按钮列(抄表)
            DataGridViewButtonColumn dgvBtnColEx = new DataGridViewButtonColumn();
            dgvBtnColEx.Name = "select";
            dgvBtnColEx.HeaderText = "抄表";
            dgvBtnColEx.UseColumnTextForButtonValue = true;
            dgvBtnColEx.Text = "…";
            dgvBtnColEx.Width = 50;
            dgvBtnColEx.ReadOnly = true;
            dgvBtnColEx.Resizable = DataGridViewTriState.False;
            //dgvBtnColEx.DataPropertyName

            dgvEquip.Columns.Add(dgvBtnColEx);

        }

        /// <summary>
        /// 单元内点击.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEquip_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string err;
            //设置选定的抄表记录.
            if (e.RowIndex < 0)
            {
                return;
            }
            else
            {
                DataGridViewRow dr = dgvEquip.Rows[e.RowIndex];
                string gaugeID = "";
                if (DBNull.Value != dr.Cells["gauge_id"].Value)
                    gaugeID = dr.Cells["gauge_id"].Value.ToString();
                gauge = GaugeService.Instance.getObject(gaugeID, out err);

            }
            if (e.ColumnIndex >= 0)
            {

                //保存当前行.
                int currentRow = e.RowIndex;
                int currentCol = e.ColumnIndex;

                if (dgvEquip.Columns[e.ColumnIndex].Name == "typename")
                {
                    FrmSetGaugeType frm = FrmSetGaugeType.Instance;
                    frm.TheGauge = gauge;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                    loadTimingMainEquip();

                }

                if (dgvEquip.Columns[e.ColumnIndex].Name == "select")
                {
                    if (gauge.RECORD_TYPE == 1)
                    {
                        FrmTotalGauge frm = FrmTotalGauge.Instance;
                        frm.Gauge = gauge;
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
                        loadTimingMainEquip();

                    }
                    else
                    {
                        FrmIncreaseGauge frm = FrmIncreaseGauge.Instance;
                        frm.Gauge = gauge;
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
                        loadTimingMainEquip();
                    }
                }

                //显示上次的行焦点.
                //this.dgvEquip.CurrentCell = dgvEquip["comp_chinese_name", currentRow];
                this.dgvEquip.CurrentCell = dgvEquip[currentCol, currentRow];
            }
        }

        private void FrmGauge_FormClosing(object sender, FormClosingEventArgs e)
        {
            //保存网格控件各列的列宽信息.
            dgvEquip.SaveGridView("FrmGauge.dgvEquip");
            instance = null;
        }

        private void bdNgClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bdNgSearch_Click(object sender, EventArgs e)
        {
            dgvEquip.SearchInfo();
        }

    }
}