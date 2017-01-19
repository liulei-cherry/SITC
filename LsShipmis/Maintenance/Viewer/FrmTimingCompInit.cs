/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmTimingCompInit.cs
 * 创 建 人：李景育
 * 创建时间：2009-05-15
 * 标    题：定时设备初始化业务窗体
 * 功能描述：实现定时设备信息的分组功能与抄表功能
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
using System.Windows.Forms;
using Maintenance.Services;
using CommonViewer.BaseControl; 

namespace Maintenance.Viewer
{
    /// <summary>
    /// 定时设备初始化业务窗体.
    /// </summary>
    public partial class FrmTimingCompInit : CommonViewer.BaseForm.FormBase
    {
        /// <summary>
        /// 存放列与列标题的集合.
        /// </summary>
        private Dictionary<string, string> dictColumns = new Dictionary<string, string>();

        /// <summary>
        /// 保存网格dgvUnInitComp所有组dictGroupUnCompInit的显示信息.
        /// </summary>
        private Dictionary<string, string> dictGroupUnCompInit = new Dictionary<string, string>();

        /// <summary>
        /// 保存网格dgvInitComp所有组dictGroupCompInit的显示信息.
        /// </summary>
        private Dictionary<string, string> dictGroupCompInit = new Dictionary<string, string>();

        # region 上下文菜单定义

        /// <summary>
        /// 全部展开的上下文菜单.
        /// </summary>
        private ToolStripMenuItem tspMnuAllExpand = new ToolStripMenuItem("全部展开(&-)");

        /// <summary>
        /// 全部收缩的上下文菜单.
        /// </summary>
        private ToolStripMenuItem tspMnuAllCollapse = new ToolStripMenuItem("全部收缩(&+)");

        /// <summary>
        /// 设置为组的上下文菜单.
        /// </summary>
        private ToolStripMenuItem tspMnuSetGrp = new ToolStripMenuItem("设置为组(&G)");

        /// <summary>
        /// 设置为成员的上下文菜单.
        /// </summary>
        private ToolStripMenuItem tspMnuSetMember = new ToolStripMenuItem("设置为成员(…)");

        #endregion

        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmTimingCompInit instance = new FrmTimingCompInit();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmTimingCompInit Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmTimingCompInit.instance = new FrmTimingCompInit();
                }

                return FrmTimingCompInit.instance;
            }
        }

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmTimingCompInit()
        {
            InitializeComponent();

            //为上下文菜单项定义单击事件.
            tspMnuAllExpand.Click += new EventHandler(tspMnuAllExpand_Click);
            tspMnuAllCollapse.Click += new EventHandler(tspMnuAllCollapse_Click);
            tspMnuSetGrp.Click += new EventHandler(tspMnuSetGrp_Click);
            tspMnuSetMember.Click += new EventHandler(tspMnuSetMember_Click);
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTimingCompInit_Load(object sender, EventArgs e)
        {
            this.setGridShortCutBtn();          //设置界面上的网格的一些常用的快捷菜单的事件处理.
            this.loadData_TimingUnCompInit();   //加载未初始化的父子设备信息.
            this.loadData_TimingCompInit();     //加载已初始化的设备计时组信息.
            this.WindowState = FormWindowState.Maximized;//窗体最大化.

            //加载网格控件默认的列宽信息.
            dgvUnInitComp.LoadGridView("FrmTimingCompInit.dgvUnInitComp");
            dgvInitComp.LoadGridView("FrmTimingCompInit.dgvInitComp");

            dgvUnInitComp.Columns["rowHeader"].Width = 20;
            dgvInitComp.Columns["rowHeader"].Width = 20;
        }

        /// <summary>
        /// 设置界面上的网格的一些常用的快捷菜单的事件处理，.
        /// </summary>
        private void setGridShortCutBtn()
        {
            dgvUnInitComp.AllowUserToOrderColumns = false;
            dgvInitComp.AllowUserToOrderColumns = false;
        }

        /// <summary>
        /// 加载未初始化的父子设备信息.
        /// </summary>
        private void loadData_TimingUnCompInit()
        {
            string shipId = CommonOperation.ConstParameter.ShipId; //船舶Id

            //取得未初始化的父子设备信息的DataTable对象.
            //modify by lipeng 2013-12-27
            #region 新的显示方法
            //这个暂时没编写完
            //DataTable dt = WorkOrderService.Instance.GetUnInitComp();
            ////配置显示结果
            //DataTable dtbUnInitComp =dt.Clone();

            //DataColumn dc = new DataColumn("push");
            //dtbUnInitComp.Columns.Add(dc);
            //for (int i = 0; i < dtbUnInitComp.Rows.Count; i++)
            //{
            //    //从父节点开始操作
            //    if (dt.Rows[i][1].ToString() == "1")
            //    {
            //        //找它的直接子节点，如果存在，加载它到显示去，否则不加载它。
            //        DataRow[] dataRows = dtbUnInitComp.Select("parent_unit_id = '" + dt.Rows[i][0].ToString() + "' and topunit='0'");
            //        if (dataRows.Length > 0)
            //        {
            //            DataRow dr = dtbUnInitComp.NewRow();
            //            for (int j = 0; j < dtbUnInitComp.Columns.Count; j++)
            //            {
            //                dr[j] = dataRows[j].ToString().Trim();
            //            }


            //        }
            //    }
                
            //}



            //bdsUnInitComp.DataSource = dtbUnInitComp;   //未初始化的父子设备信息的数据源设置.
            //dgvUnInitComp.DataSource = bdsUnInitComp;

            ////设置列标题.
            //dictColumns.Clear();
            //dictColumns.Add("comp_chinese_name", "设备名称");
            //dictColumns.Add("total_workhours", "上次抄表值");
            //dgvUnInitComp.Columns["total_workhours"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dgvUnInitComp.SetDgvGridColumns(dictColumns);
            //dgvUnInitComp.SetDataGridViewNoSort();

            ////网格dgvUnInitComp动态添加一个组标头列rowHeader
            //if (dgvUnInitComp.Columns["rowHeader"] == null)
            //{
            //    DataGridViewTextBoxColumn dgvCol = new DataGridViewTextBoxColumn();
            //    dgvCol.Name = "rowHeader";
            //    dgvCol.HeaderText = "";
            //    dgvCol.Width = 20;
            //    dgvCol.Resizable = DataGridViewTriState.False;
            //    dgvCol.DefaultCellStyle.BackColor = this.BackColor;
            //    dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    dgvUnInitComp.Columns.Insert(0, dgvCol);
            //}
            //else
            //{
            //    dgvUnInitComp.Columns["rowHeader"].Visible = true;
            //}

            #endregion

            #region 旧的显示方法
            DataTable dtbUnInitComp = WorkOrderService.Instance.GetUnInitComp(shipId);
            bdsUnInitComp.DataSource = dtbUnInitComp;   //未初始化的父子设备信息的数据源设置.
            dgvUnInitComp.DataSource = bdsUnInitComp;

            //设置列标题.
            dictColumns.Clear();
            dictColumns.Add("comp_chinese_name", "设备名称");
            dictColumns.Add("total_workhours", "上次抄表值");
            dgvUnInitComp.Columns["total_workhours"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvUnInitComp.SetDgvGridColumns(dictColumns);
            dgvUnInitComp.SetDataGridViewNoSort();

            //网格dgvUnInitComp动态添加一个组标头列rowHeader
            if (dgvUnInitComp.Columns["rowHeader"] == null)
            {
                DataGridViewTextBoxColumn dgvCol = new DataGridViewTextBoxColumn();
                dgvCol.Name = "rowHeader";
                dgvCol.HeaderText = "";
                dgvCol.Width = 20;
                dgvCol.Resizable = DataGridViewTriState.False;
                dgvCol.DefaultCellStyle.BackColor = this.BackColor;
                dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvUnInitComp.Columns.Insert(0, dgvCol);
            }
            else
            {
                dgvUnInitComp.Columns["rowHeader"].Visible = true;
            }
            #endregion

        }

        /// <summary>
        /// 加载已初始化的设备计时组信息.
        /// </summary>
        private void loadData_TimingCompInit()
        {
            string shipId = CommonOperation.ConstParameter.ShipId; //船舶Id

            //取得已初始化的设备计时组单信息的DataTable对象.
            DataTable dtbInitComp = WorkOrderService.Instance.GetInitComp(shipId);
            bdsInitComp.DataSource = dtbInitComp;//已初始化的设备计时组信息的数据源设置.
            dgvInitComp.DataSource = bdsInitComp;

            //设置列标题.
            dictColumns.Clear();
            dictColumns.Add("comp_chinese_name", "设备名称");
            dictColumns.Add("gauge_time", "抄表时间");
            dictColumns.Add("total_workhours", "总运转小时");
            dgvInitComp.Columns["gauge_time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvInitComp.Columns["total_workhours"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvInitComp.SetDgvGridColumns(dictColumns);
            dgvInitComp.SetDataGridViewNoSort();

            //网格dgvInitComp动态添加一个组标头列rowHeader
            if (dgvInitComp.Columns["rowHeader"] == null)
            {
                DataGridViewTextBoxColumn dgvCol = new DataGridViewTextBoxColumn();
                dgvCol.Name = "rowHeader";
                dgvCol.HeaderText = "";
                dgvCol.Width = 20;
                dgvCol.Resizable = DataGridViewTriState.False;
                dgvCol.DefaultCellStyle.BackColor = this.BackColor;
                dgvCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvInitComp.Columns.Insert(0, dgvCol);
            }
            else
            {
                dgvInitComp.Columns["rowHeader"].Visible = true;
            }

            //给网格dgvInitComp动态添加一个按钮列.
            if (dgvInitComp.Columns["select"] == null)
            {
                DataGridViewButtonColumn dgvBtnCol = new DataGridViewButtonColumn();
                dgvBtnCol.Name = "select";
                dgvBtnCol.HeaderText = "";
                dgvBtnCol.UseColumnTextForButtonValue = true;
                dgvBtnCol.Text = "…";
                dgvBtnCol.Width = 25;
                dgvBtnCol.ReadOnly = true;
                dgvBtnCol.Resizable = DataGridViewTriState.False;
                dgvInitComp.Columns.Add(dgvBtnCol);
            }
            else
            {
                dgvInitComp.Columns["select"].Visible = true;
            }
        }

        /// <summary>
        /// 界面启动后在网格dgvUnInitComp与dgvInitComp加载数据后给其列rowHeader添加伸缩标记（+与-）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTimingCompInit_Shown(object sender, EventArgs e)
        {
            //在网格dgvUnInitComp中给组标头列rowHeader加上符号-（界面启动时默认所有的信息是展开的）.
            foreach (DataGridViewRow dgvRow in dgvUnInitComp.Rows)
            {
                string topunit = dgvRow.Cells["topunit"].Value.ToString();
                if (topunit == "1")
                {
                    dgvRow.Cells["rowHeader"].Value = "-";
                }
            }

            //在网格dgvInitComp中给组标头列rowHeader加上符号-（界面启动时默认所有的信息是展开的）.
            foreach (DataGridViewRow dgvRow in dgvInitComp.Rows)
            {
                string topunit = dgvRow.Cells["topunit"].Value.ToString();
                if (topunit == "1")
                {
                    dgvRow.Cells["rowHeader"].Value = "-";
                }
            }

            //界面启动后把网格dgvInitComp中的组标头中的伸缩信息放到集合dictGroupCompInit中去；.
            //把网格dgvUnInitComp中的组标头中的伸缩信息放到集合dictGroupUnCompInit中去.
            this.makedictGroupCompInit();

            //设置网格dgvUnInitComp中组的显示风格（组的展开与收缩标记、组的背景和组的字体）；.
            this.makeRowStyleInUnCompInit();

            //设置网格dgvInitComp中组的显示风格（组的展开与收缩标记、组的背景和组的字体）；.
            this.makeRowStyleInCompInit();
        }

        /// <summary>
        /// 界面启动时把网格dgvUnInitComp中的组标头中的伸缩信息放到集合dictGroupUnCompInit中去，.
        /// 把dgvInitComp中的组标头中的伸缩信息放到集合dictGroupCompInit中去.
        /// </summary>
        private void makedictGroupCompInit()
        {
            //1.设置网格dgvUnInitComp的信息.
            foreach (DataGridViewRow dgvRow in dgvUnInitComp.Rows)
            {
                string topunit = dgvRow.Cells["topunit"].Value.ToString();//组标记（1表示是组标头，0表示组成员）.
                if (topunit == "1")
                {
                    //把当前组的显示信息添加到集合dictGroupUnCompInit中去.
                    string rowHeader = dgvRow.Cells["rowHeader"].Value.ToString();//组信息（符号：-或者+）.
                    string componentUnitId = dgvRow.Cells["component_unit_id"].Value.ToString();//当前组的设备Id

                    if (dictGroupUnCompInit.ContainsKey(componentUnitId) == false)
                    {
                        dictGroupUnCompInit.Add(componentUnitId, rowHeader);
                    }
                }
            }

            //2.设置网格dgvInitComp的信息.
            foreach (DataGridViewRow dgvRow in dgvInitComp.Rows)
            {
                string topunit = dgvRow.Cells["topunit"].Value.ToString();//组标记（1表示是组标头，0表示组成员）.
                if (topunit == "1")
                {
                    //把当前组的显示信息添加到集合dictGroupCompInit中去.
                    string rowHeader = dgvRow.Cells["rowHeader"].Value.ToString();//组信息（符号：-或者+）.
                    string componentUnitId = dgvRow.Cells["component_unit_id"].Value.ToString();//当前组的设备Id

                    if (dictGroupCompInit.ContainsKey(componentUnitId) == false)
                    {
                        dictGroupCompInit.Add(componentUnitId, rowHeader);
                    }
                }
            }
        }

        /// <summary>
        /// 设置dgvUnInitComp中组的显示风格（组的展开与收缩标记、组的背景和组的字体）.
        /// </summary>
        private void makeRowStyleInUnCompInit()
        {
            string topunit = "";        //组标记（1表示是组标头，0表示组成员）.
            string componentUnitId = "";//当前组的设备Id

            foreach (DataGridViewRow dgvRow in dgvUnInitComp.Rows)
            {
                topunit = dgvRow.Cells["topunit"].Value.ToString();
                if (topunit == "1")
                {
                    dgvRow.DefaultCellStyle.BackColor = this.BackColor;
                    Font font = new Font("宋体", 9, FontStyle.Bold);
                    dgvRow.DefaultCellStyle.Font = font;

                    //把dictGroupCompInit中的组标头的状态信息显示到rowHeader字段上.
                    componentUnitId = dgvRow.Cells["component_unit_id"].Value.ToString();
                    dgvRow.Cells["rowHeader"].Value = dictGroupUnCompInit[componentUnitId];
                }
            }
        }

        /// <summary>
        /// 设置网格dgvInitComp中组的显示风格（组的展开与收缩标记、组的背景和组的字体）.
        /// </summary>
        private void makeRowStyleInCompInit()
        {
            string topunit = "";        //组标记（1表示是组标头，0表示组成员）.
            string componentUnitId = "";//当前组的设备Id

            foreach (DataGridViewRow dgvRow in dgvInitComp.Rows)
            {
                topunit = dgvRow.Cells["topunit"].Value.ToString();
                if (topunit == "1")
                {
                    dgvRow.DefaultCellStyle.BackColor = this.BackColor;
                    Font font = new Font("宋体", 9, FontStyle.Bold);
                    dgvRow.DefaultCellStyle.Font = font;

                    //把dictGroupCompInit中的组标头的状态信息显示到rowHeader字段上.
                    componentUnitId = dgvRow.Cells["component_unit_id"].Value.ToString();
                    dgvRow.Cells["rowHeader"].Value = dictGroupCompInit[componentUnitId];
                }
            }
        }

        /// <summary>
        /// 初始化网格dgvInitComp中的指定设备的总运转小时.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvInitComp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string err = "";     //错误信息参数.
            string componentUnitId = "";    //当前定时设备Id
            string compChineseName = "";    //当前定时设备名称.
            string topunit = "";            //网格dgvInitComp上的组标记（1表示组，0表示成员）.
            DataRow[] dataRows = null;      //如果当前选择的设备是个组，那么取它的所有成员.
            string oldTotalWorkHours = "";  //当前定时设备的原总运转小时.
            string newTotalWorkHours = "";  //当前定时设备的新总运转小时.
            string gaugeTime = "";          //初始抄表时间.

            if (dgvInitComp.Columns[e.ColumnIndex].Name == "select")
            {
                componentUnitId = dgvInitComp.Rows[e.RowIndex].Cells["component_unit_id"].Value.ToString();
                compChineseName = dgvInitComp.Rows[e.RowIndex].Cells["comp_chinese_name"].Value.ToString();
                topunit = dgvInitComp.Rows[e.RowIndex].Cells["topunit"].Value.ToString();
                oldTotalWorkHours = dgvInitComp.Rows[e.RowIndex].Cells["total_workhours"].Value.ToString();

                //打开对话框取新的总运转小时.
                FrmTimingCompFirstVal frm = new FrmTimingCompFirstVal(compChineseName, oldTotalWorkHours);
                DialogResult diaLog = frm.ShowDialog();

                //如果对话框选择的是取消按钮则不执行任何操作.
                if (diaLog == DialogResult.Cancel)
                {
                    return;
                }

                //取对话框传过来的初次总运转小时和初次抄表时间.
                newTotalWorkHours = frm.TotalWorkHours;
                gaugeTime = frm.GaugeTime;

                //如果当前选择的要移动的设备为组，那么把它的所有子设备信息也取出来放到一个DataRow集合中去.
                if (topunit == "1")
                {
                    BindingSource bds = (BindingSource)dgvInitComp.DataSource;
                    DataTable dtb = (DataTable)bds.DataSource;
                    dataRows = dtb.Select("topunit <> 1 and parent_unit_id = '" + componentUnitId + "'");
                } 
                //更新结果报告.
               if (WorkOrderService.Instance.InitTotalWorkhours(componentUnitId, newTotalWorkHours, gaugeTime, dataRows, out err))
                {
                    //重新加载数据.
                    this.loadData_TimingCompInit();
                    //在网格加载数据后给其列rowHeader添加伸缩标记（+与-）并设置列的显示风格.
                    this.FrmTimingCompInit_Shown(sender, e);
                    //重新根据dictGroupCompInit中的信息过滤数据.
                    this.dgvInitCompRowFilter();
                }
                else
                {
                    MessageBoxEx.Show(err, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// 单击网格dgvUnInitComp的组标头时展开或者收缩明细信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvUnInitComp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string rowHeader = "";          //组信息（符号：-或者+）.
            string topunit = "";            //组标记（1表示是组标头，0表示组成员）.
            string componentUnitId = "";    //当前组的设备Id

            if (e.RowIndex >= 0)
            {
                topunit = dgvUnInitComp.Rows[e.RowIndex].Cells["topunit"].Value.ToString();

                //如果当前是组标头.
                if (topunit == "1")
                {
                    //仅当单击到列rowHeader才执行伸缩功能.
                    if (dgvUnInitComp.Columns[e.ColumnIndex].Name == "rowHeader")
                    {
                        rowHeader = dgvUnInitComp.Rows[e.RowIndex].Cells["rowHeader"].Value.ToString();
                        componentUnitId = dgvUnInitComp.Rows[e.RowIndex].Cells["component_unit_id"].Value.ToString();

                        //改变组标头集合dictGroupUnCompInit的伸缩标记（把当前状态改为相反的状态：+改为-；-改为+）.
                        if (rowHeader == "-")
                        {
                            dictGroupUnCompInit[componentUnitId] = "+";
                        }
                        else
                        {
                            dictGroupUnCompInit[componentUnitId] = "-";
                        }

                        //根据dictGroupUnCompInit中的伸缩信息过程网格dgvUnInitComp的显示信息.
                        this.dgvUnInitCompRowFilter();
                    }
                }

                //设置成员上下文快捷菜单.
                dgvUnInitComp.CtxMenu.Items.Add(tspMnuAllExpand);
                dgvUnInitComp.CtxMenu.Items.Add(tspMnuAllCollapse);
            }
        }

        /// <summary>
        /// 单击网格dgvInitComp的组标头时展开或者收缩明细信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvInitComp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string rowHeader = "";          //组信息（符号：-或者+）.
            string topunit = "";            //组标记（1表示是组标头，0表示组成员）.
            string componentUnitId = "";    //当前组的设备Id

            if (e.RowIndex >= 0)
            {
                topunit = dgvInitComp.Rows[e.RowIndex].Cells["topunit"].Value.ToString();

                //如果当前是组标头.
                if (topunit == "1")
                {
                    //去掉组上下文快捷菜单.
                    dgvInitComp.CtxMenu.Items.Remove(tspMnuSetGrp);

                    //仅当单击到列rowHeader才执行伸缩功能.
                    if (dgvInitComp.Columns[e.ColumnIndex].Name == "rowHeader")
                    {
                        rowHeader = dgvInitComp.Rows[e.RowIndex].Cells["rowHeader"].Value.ToString();
                        componentUnitId = dgvInitComp.Rows[e.RowIndex].Cells["component_unit_id"].Value.ToString();

                        //改变组标头集合dictGroupCompInit的伸缩标记（把当前状态改为相反的状态：+改为-；-改为+）.
                        if (rowHeader == "-")
                        {
                            dictGroupCompInit[componentUnitId] = "+";
                        }
                        else
                        {
                            dictGroupCompInit[componentUnitId] = "-";
                        }

                        //根据dictGroupCompInit中的伸缩信息过程网格dgvInitComp的显示信息.
                        this.dgvInitCompRowFilter();
                    }
                }
                else
                {
                    //设置组上下文快捷菜单.
                    dgvInitComp.CtxMenu.Items.Add(tspMnuSetGrp);
                }

                //设置成员上下文快捷菜单.
                dgvInitComp.CtxMenu.Items.Add(tspMnuSetMember);
                dgvInitComp.CtxMenu.Items.Add(tspMnuAllExpand);
                dgvInitComp.CtxMenu.Items.Add(tspMnuAllCollapse);
            }
        }

        /// <summary>
        /// [未初始化的父子设备]网格dgvUnInitComp的信息过滤（使用DataView功能避免每次过滤都与后台打交道）.
        /// </summary>
        private void dgvUnInitCompRowFilter()
        {
            string sFilter = "topunit = 1"; //初始过滤条件（所有的组标头都必须显示）.
            string rowHeader = "";          //当前组标头的伸缩状态.

            //取组标头集合dictGroupUnCompInit中的每一项，根据其它伸缩状态来其显示或者隐藏其明细信息（把条件追加到sFilter变量中去）.
            foreach (string componentUnitId in dictGroupUnCompInit.Keys)
            {
                rowHeader = dictGroupUnCompInit[componentUnitId];
                if (rowHeader == "-")
                {
                    sFilter += " or parent_unit_id = '" + componentUnitId + "'";
                }
            }

            //进行数据过滤（使用DataView）.
            DataTable dtbUnInitComp = (DataTable)bdsUnInitComp.DataSource;
            DataView dvUnInitComp = dtbUnInitComp.DefaultView;
            dvUnInitComp.RowFilter = sFilter;

            //设置网格dgvUnInitComp中组的显示风格（组的展开与收缩标记、组的背景和组的字体）；.
            this.makeRowStyleInUnCompInit();
        }

        /// <summary>
        /// [已初始化的设备计时组]网格dgvInitComp的信息过滤（使用DataView功能避免每次过滤都与后台打交道）.
        /// </summary>
        private void dgvInitCompRowFilter()
        {
            string sFilter = "topunit = 1"; //初始过滤条件（所有的组标头都必须显示）.
            string rowHeader = "";          //当前组标头的伸缩状态.

            //取组标头集合dictGroupCompInit中的每一项，根据其它伸缩状态来其显示或者隐藏其明细信息（把条件追加到sFilter变量中去）.
            foreach (string componentUnitId in dictGroupCompInit.Keys)
            {
                rowHeader = dictGroupCompInit[componentUnitId];
                if (rowHeader == "-")
                {
                    sFilter += " or parent_unit_id = '" + componentUnitId + "'";
                }
            }

            //进行数据过滤（使用DataView）.
            DataTable dtbInitComp = (DataTable)bdsInitComp.DataSource;
            DataView dvInitComp = dtbInitComp.DefaultView;
            dvInitComp.RowFilter = sFilter;

            //设置网格dgvInitComp中组的显示风格（组的展开与收缩标记、组的背景和组的字体）；.
            this.makeRowStyleInCompInit();
        }

        /// <summary>
        /// 上下文菜单中的全部展开的事件处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspMnuAllExpand_Click(object sender, EventArgs e)
        {
            List<string> lstKeys = new List<string>();

            if (this.ActiveControl.Name == "dgvUnInitComp")
            {
                foreach (string key in dictGroupUnCompInit.Keys)
                {
                    lstKeys.Add(key);
                }

                foreach (string key in lstKeys)
                {
                    dictGroupUnCompInit[key] = "-";
                }

                //根据dictGroupUnCompInit中的伸缩信息过程网格dgvInitComp的显示信息.
                this.dgvUnInitCompRowFilter();
            }
            else if (this.ActiveControl.Name == "dgvInitComp")
            {
                foreach (string key in dictGroupCompInit.Keys)
                {
                    lstKeys.Add(key);
                }

                foreach (string key in lstKeys)
                {
                    dictGroupCompInit[key] = "-";
                }

                //根据dictGroupCompInit中的伸缩信息过程网格dgvInitComp的显示信息.
                this.dgvInitCompRowFilter();
            }
            else
            {
                MessageBoxEx.Show("请选择要操作的网格！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 上下文菜单中的全部收缩的事件处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspMnuAllCollapse_Click(object sender, EventArgs e)
        {
            List<string> lstKeys = new List<string>();

            if (this.ActiveControl.Name == "dgvUnInitComp")
            {
                foreach (string key in dictGroupUnCompInit.Keys)
                {
                    lstKeys.Add(key);
                }

                foreach (string key in lstKeys)
                {
                    dictGroupUnCompInit[key] = "+";
                }

                //根据dictGroupUnCompInit中的伸缩信息过程网格dgvInitComp的显示信息.
                this.dgvUnInitCompRowFilter();
            }
            else if (this.ActiveControl.Name == "dgvInitComp")
            {
                foreach (string key in dictGroupCompInit.Keys)
                {
                    lstKeys.Add(key);
                }

                foreach (string key in lstKeys)
                {
                    dictGroupCompInit[key] = "+";
                }

                //根据dictGroupCompInit中的伸缩信息过程网格dgvInitComp的显示信息.
                this.dgvInitCompRowFilter();
            }
            else
            {
                MessageBoxEx.Show("请选择要操作的网格！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 上下文菜单中的设置为组的事件处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspMnuSetGrp_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            string gaugeId = "";        //当前已初始化设备的记录Id
            string topunit = "";        //组标记（1表示组，0表示成员）.

            if (dgvInitComp.CurrentRow == null)
            {
                return;
            }

            gaugeId = dgvInitComp.CurrentRow.Cells["gauge_id"].Value.ToString();
            topunit = dgvInitComp.CurrentRow.Cells["topunit"].Value.ToString();

            if (topunit == "1")
            {
                MessageBoxEx.Show("当前行已经是组，不能重复设置！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
 
            //更新结果报告.
            if (WorkOrderService.Instance.SetToGroup(gaugeId, out err))
            {
                //重新加载数据.
                this.loadData_TimingCompInit();
                //在网格加载数据后给其列rowHeader添加伸缩标记（+与-）并设置列的显示风格.
                this.FrmTimingCompInit_Shown(sender, e);
                //重新根据dictGroupCompInit中的信息过滤数据.
                this.dgvInitCompRowFilter();
            }
            else
            {
                MessageBoxEx.Show(err, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 上下文菜单中的设置为成员的事件处理.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspMnuSetMember_Click(object sender, EventArgs e)
        {
            string err = "";     //错误信息参数.
            string memGaugeId = "";         //当前成员所在的行Id
            string grpGaugeId = "";         //可用的组Id
            string topunit = "";            //组标记（1表示组，0表示成员）.
            string memGrpParentId = "";     //当前成员所在的组的设备Id

            if (dgvInitComp.CurrentRow == null)
            {
                return;
            }

            memGaugeId = dgvInitComp.CurrentRow.Cells["gauge_id"].Value.ToString();
            topunit = dgvInitComp.CurrentRow.Cells["topunit"].Value.ToString();

            if (topunit == "0")
            {
                //如果当前行是成员行，那么取parent_unit_id
                memGrpParentId = dgvInitComp.CurrentRow.Cells["parent_unit_id"].Value.ToString();
            }
            else
            {
                //如果当前行本身是组行，那么取component_unit_id
                memGrpParentId = dgvInitComp.CurrentRow.Cells["component_unit_id"].Value.ToString();
            }

            //打开弹出对话框选择要设置成其成员的组名.
            FrmTimingCompGrpSel frm = new FrmTimingCompGrpSel(memGrpParentId);
            frm.ShowDialog();
            grpGaugeId = frm.GaugeId;
 
            //更新结果报告.
            if (WorkOrderService.Instance.SetToMember(memGaugeId, grpGaugeId, out err))
            {
                //重新加载数据.
                this.loadData_TimingCompInit();
                //在网格加载数据后给其列rowHeader添加伸缩标记（+与-）并设置列的显示风格.
                this.FrmTimingCompInit_Shown(sender, e);
                //重新根据dictGroupCompInit中的信息过滤数据.
                this.dgvInitCompRowFilter();
            }
            else
            {
                MessageBoxEx.Show(err, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 把未初始化的定时设备设置为组或者组的成员.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToGroup_Click(object sender, EventArgs e)
        {
            string err = "";     //错误信息参数.
            string topunitUnInitComp = "";  //网格dgvUnInitComp上的组标记（1表示组，0表示成员）.
            string topunitInitComp = "";    //网格dgvInitComp上的组标记（1表示组，0表示成员）.
            string grpComponentUnitId = ""; //要并入的组的设备Id
            string componentUnitId = "";    //要移动的设备Id
            string totalWorkhours = "";     //要移动的设备的总运转小时数（也就是上次抄表值）.
            DataRow[] dataRows = null;      //如果当前选择的设备是个组，那么取它的所有成员（注意是网格dgvUnInitComp）.

            if (dgvUnInitComp.Rows.Count > 0)
            {
                //网格dgvUnInitComp上的组标记（1表示组，0表示成员）.
                topunitUnInitComp = dgvUnInitComp.CurrentRow.Cells["topunit"].Value.ToString();

                //取要并入的组的设备Id（当前行不能为空）.
                if (dgvInitComp.CurrentRow != null)
                {
                    //网格dgvInitComp上的组标记（1表示组，0表示成员）.
                    topunitInitComp = dgvInitComp.CurrentRow.Cells["topunit"].Value.ToString();

                    //如果网格dgvInitComp当前选择行是组，则取该组的设备Id；如果选择行是成员，那么取该成员所在的组的设备Id（parent_unit_id）.
                    if (topunitInitComp == "1")
                    {
                        grpComponentUnitId = dgvInitComp.CurrentRow.Cells["component_unit_id"].Value.ToString();
                    }
                    else
                    {
                        grpComponentUnitId = dgvInitComp.CurrentRow.Cells["parent_unit_id"].Value.ToString();
                    }
                }

                //取要移动的设备Id和总运转小时数.
                componentUnitId = dgvUnInitComp.CurrentRow.Cells["component_unit_id"].Value.ToString();
                totalWorkhours = dgvUnInitComp.CurrentRow.Cells["total_workhours"].Value.ToString();
                if (totalWorkhours == "") totalWorkhours = "0";

                //如果当前选择的要移动的设备为组，那么把它的所有子设备信息也取出来放到一个DataRow集合中去.
                if (topunitUnInitComp == "1")
                {
                    BindingSource bds = (BindingSource)dgvUnInitComp.DataSource;
                    DataTable dtb = (DataTable)bds.DataSource;
                    dataRows = dtb.Select("topunit <> 1 and parent_unit_id = '" + componentUnitId + "'");
                }

                //把未初始化的定时设备设置为组或者组的成员.
                if (WorkOrderService.Instance.SetToGroup(grpComponentUnitId, topunitUnInitComp, componentUnitId, totalWorkhours, dataRows, out err))
                {
                    //重新加载数据.
                    this.loadData_TimingUnCompInit();
                    this.loadData_TimingCompInit();                    
                    //在网格加载数据后给其列rowHeader添加伸缩标记（+与-）并设置列的显示风格.
                    this.FrmTimingCompInit_Shown(sender, e);
                    //重新根据dictGroupUnCompInit中的信息过滤数据.
                    this.dgvUnInitCompRowFilter();
                    //重新根据dictGroupCompInit中的信息过滤数据.
                    this.dgvInitCompRowFilter();
                }
                else
                {
                    MessageBoxEx.Show(err, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// 把已初始化的设备从组中移除.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelFromGroup_Click(object sender, EventArgs e)
        {
            string err = "";     //错误信息参数.
            string componentUnitId = "";    //要移除的设备Id

            if (dgvInitComp.Rows.Count > 0)
            {
                if (MessageBoxEx.Show("确定要执行此操作吗？", "确认对话框", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                componentUnitId = dgvInitComp.CurrentRow.Cells["component_unit_id"].Value.ToString();

                //把已初始化的设备从组中移除.
                if (WorkOrderService.Instance.RemoveFromGroup(componentUnitId, out err))
                {
                    //重新加载数据.
                    this.loadData_TimingUnCompInit();
                    this.loadData_TimingCompInit();
                    //在网格加载数据后给其列rowHeader添加伸缩标记（+与-）并设置列的显示风格.
                    this.FrmTimingCompInit_Shown(sender, e);
                    //重新根据dictGroupUnCompInit中的信息过滤数据.
                    this.dgvUnInitCompRowFilter();
                    //重新根据dictGroupCompInit中的信息过滤数据.
                    this.dgvInitCompRowFilter();
                }
                else
                {
                    MessageBoxEx.Show(err, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// 全部收缩操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgCollapse_Click(object sender, EventArgs e)
        {            
            this.tspMnuAllCollapse.PerformClick();
        }

        /// <summary>
        /// 全部展开操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgExpand_Click(object sender, EventArgs e)
        {
            this.tspMnuAllExpand.PerformClick();
        }

        /// <summary>
        /// dgvInitComp网格中设置为组的操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSetToGroup_Click(object sender, EventArgs e)
        {
            string topunit = "";

            if (dgvInitComp.CurrentRow != null)
            {

                if (MessageBoxEx.Show("确定要执行此操作吗？", "确认对话框", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                topunit = dgvInitComp.CurrentRow.Cells["topunit"].Value.ToString();
                if (topunit == "1")
                {
                    MessageBoxEx.Show("当前选择的行已经是组，不能再设置成组！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.tspMnuSetGrp.PerformClick();
            }
        }

        /// <summary>
        /// dgvInitComp网格中设置为成员的操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgSetToMember_Click(object sender, EventArgs e)
        {
            if (dgvInitComp.CurrentRow != null)
            {
                if (MessageBoxEx.Show("确定要执行此操作吗？", "确认对话框", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                this.tspMnuSetMember.PerformClick();
            }
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
        /// 窗体关闭时释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTimingCompInit_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvUnInitComp.SaveGridView("FrmTimingCompInit.dgvUnInitComp");
            dgvInitComp.SaveGridView("FrmTimingCompInit.dgvInitComp");
            instance = null;    //释放窗体实例变量.
        }
    }
}