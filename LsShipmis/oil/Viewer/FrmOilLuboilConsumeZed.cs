/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：夏喜龙
 * 创建时间：2012-12-12
 * 功能描述：滑油消耗汇总的功能管理
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
using ZedGraph;

namespace Oil.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    /// 
    public partial class FrmOilLuboilConsumeZed : CommonViewer.BaseForm.BaseMdiChildForm
    {

        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmOilLuboilConsumeZed instance = new FrmOilLuboilConsumeZed();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmOilLuboilConsumeZed Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmOilLuboilConsumeZed.instance = new FrmOilLuboilConsumeZed();
                }
                return FrmOilLuboilConsumeZed.instance;
            }
        }

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmOilLuboilConsumeZed()
        {
            InitializeComponent();
        }

        #endregion


        #region 窗体对象

        DataTable dtShipMul = new DataTable();                                         //图形绘制多船数据表数据对象
        DataTable dtShipSig = new DataTable();                                         //图形绘制单船数据表数据对象
        Dictionary<string, bool> dShips = new Dictionary<string, bool>();              //声明船舶选中状态数组.

        bool isFirstLoadMain = true;                                                   //是否第一次加载主表.
        Dictionary<string, string> dictColumns = new Dictionary<string, string>();     //声明主表数据对象.
        Dictionary<string, string> dictColumnsSub = new Dictionary<string, string>();  //声明子表数据对象.

        #endregion


        #region 其它公共业务类
        Dictionary<string, string> discRate = new Dictionary<string, string>();

        /// <summary>
        /// 根据传入序号，取色；.
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public Color getMyColor(Color[] myColor, int order)
        {
            order = order % myColor.Length;
            return myColor[order];
        }

        /// <summary>
        /// 设置自己的色系；.
        /// </summary>
        public Color[] setMyColor()
        {
            Color[] setColor = new Color[20];

            setColor[0] = Color.Blue;
            setColor[1] = Color.Green;
            setColor[2] = Color.Chocolate; //巧克力;
            setColor[3] = Color.Cyan;//青色.
            setColor[4] = Color.Brown;
            setColor[5] = Color.Coral;
            setColor[6] = Color.Gray; //珊瑚色.
            setColor[7] = Color.Crimson; //暗深红色.
            setColor[8] = Color.Violet;
            setColor[9] = Color.DarkOliveGreen;//绿色.

            setColor[10] = Color.DarkSalmon;
            setColor[11] = Color.DarkTurquoise;
            setColor[12] = Color.Cornsilk;
            setColor[13] = Color.CornflowerBlue;
            setColor[14] = Color.CadetBlue;
            setColor[15] = Color.BurlyWood; // 
            setColor[16] = Color.Black; // 
            setColor[17] = Color.Azure; // 
            setColor[18] = Color.AliceBlue;// 
            setColor[19] = Color.DarkKhaki;// 

            return setColor;
        }

        /// <summary>
        /// 对单列数据的画图.
        /// </summary>
        /// <param name="displayName"></param>
        /// <param name="ppl"></param>
        /// <param name="order"></param>
        public void drawGraphByOneData(string displayName, GraphPane graphPane, PointPairList ppl, int order)
        {
            Color[] myColor = setMyColor();

            BarItem myBar = graphPane.AddBar(displayName, ppl, this.getMyColor(myColor, order));
            myBar.Bar.Fill = new Fill(this.getMyColor(myColor, order), Color.White, this.getMyColor(myColor, order));
        }

        #endregion


        #region 多船数据

        /// <summary>
        /// 加载多船数据.
        /// </summary>
        private void loadMulData()
        {
            string err = "";

            DateTime sDate = new DateTime(dateStart.Value.Year, dateStart.Value.Month, 1);
            DateTime eDate = new DateTime(dateEnd.Value.Year, dateEnd.Value.Month, 1);
            eDate = eDate.AddMonths(1).AddDays(-1);

            DataTable dtb = HOilLuboilConsumeService.Instance.getYearSum(sDate, eDate, out err);
            dtShipMul = dtb;

            if (dtb.Rows.Count == 0)
            {
                dtb = null;
            }
            else
            {
                //设置多船列项.
                loadDataMul();

                //设置船舶列表并设置状态.
                foreach (DataRow rows in dtb.Rows)
                {
                    string tmpName = rows["船舶"].ToString();
                    string tmpId = rows["ship_id"].ToString();
                    if (!dShips.ContainsKey(tmpName + tmpId))
                    {
                        dShips.Add(tmpName + tmpId, false);
                    }
                }

                //根据数据添加多选控件项
                foreach (string shipNameId in dShips.Keys)
                {
                    string tmpName = shipNameId.ToString().Substring(0, shipNameId.ToString().Length - 36);
                    string tmpId = shipNameId.ToString().Substring(shipNameId.ToString().Length - 36, 36);

                    if (this.cklShips.Items.IndexOf(tmpName) == -1)
                    {
                        this.cklShips.Items.Add(tmpName);
                    }
                    if (this.lstShip.Items.IndexOf(tmpName) == -1)
                    {
                        this.lstShip.Items.Add(tmpName);
                    }
                }
            }

            changeShowData();
            Zed_ShowGraphMul(dtShipMul);
        }

        /// <summary>
        /// 设置多船列项.
        /// </summary>
        private void loadDataMul()
        {
            //设置列标题.
            dtShipMul.Columns["SHIP_NAME"].ColumnName = "船舶";
            dtShipMul.Columns["TYPE1SUME"].ColumnName = "主机气缸油消耗";
            dtShipMul.Columns["TYPE2SUME"].ColumnName = "主机系统油消耗";
            dtShipMul.Columns["TYPE3SUME"].ColumnName = "副机系统油消耗";
        }

        /// <summary>
        /// 更改显示数据.
        /// </summary>
        private void changeShowData()
        {
            string sel = "";      //声明条件查询语句
            int i = 0;
            DataRow[] drs = null; //声明查询结果临时数组

            //根据控件选项更改船舶数组状态
            for (int tmpi = 0; tmpi < this.cklShips.Items.Count; tmpi++)
            {
                if (!this.cklShips.GetItemChecked(tmpi))
                {
                    foreach (string tmp in dShips.Keys)
                    {
                        if (tmp.Contains(this.cklShips.Items[tmpi].ToString()))
                        {
                            dShips[tmp] = false;
                            break;
                        }
                    }
                }
                else if (this.cklShips.GetItemChecked(tmpi))
                {
                    foreach (string tmp in dShips.Keys)
                    {
                        if (tmp.Contains(this.cklShips.Items[tmpi].ToString()))
                        {
                            dShips[tmp] = true;
                            break;
                        }
                    }
                }
            }

            //根据数组状态拼写查询语句
            foreach (string tmp in dShips.Keys)
            {
                string tmpName = tmp.ToString().Substring(0, tmp.ToString().Length - 36);

                if (!dShips[tmp]) continue;
                else if (dShips.Count == 1) sel = "船舶 = '" + tmpName + "'";
                else if (i == 0) sel += "船舶 = '" + tmpName + "'";
                else
                {
                    sel += "or 船舶 = '" + tmpName + "'";
                }
                i++;
            }

            //临时表复制多船数据
            DataTable dtTemp = dtShipMul.Copy();

            //清空多船数据
            dtShipMul.Clear();

            //根据查询结果导入多船数据
            if (sel != "" && dtTemp.Rows.Count != 0)
            {
                drs = dtTemp.Select(sel);
                foreach (DataRow dr in drs)
                {
                    dtShipMul.ImportRow(dr);
                }
            }
        }

        /// <summary>
        /// 显示多船统计图.
        /// </summary>
        private void Zed_ShowGraphMul(DataTable dt)
        {
            string[] xLabels = null;

            //获取画板
            GraphPane graphPane = this.zedMulShips.GraphPane;
            graphPane.CurveList.Clear();

            //设置标题和坐标轴的文字.
            graphPane.Title.Text = "" + dateStart.Value.Year + "年" + dateStart.Value.Month + "月 至 " + dateEnd.Value.Year + "年" + dateEnd.Value.Month + "月 润滑油月消耗统计图";
            graphPane.XAxis.Title.Text = "船舶";
            graphPane.YAxis.Title.Text = "润滑油量 (单位:升)";
            xLabels = new string[dt.Rows.Count];
            graphPane.XAxis.Type = AxisType.Text;

            //准备数据.
            int Order = 0;
            double TYPE1SUME_Weight = 0.00;
            double TYPE2SUME_Weight = 0.00;
            double TYPE3SUME_Weight = 0.00;
            PointPairList TYPE1SUME_WeightPointPairList = new PointPairList();
            PointPairList TYPE2SUME_WeightPointPairList = new PointPairList();
            PointPairList TYPE3SUME_WeightPointPairList = new PointPairList();

            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                Order = ++i;
                TYPE1SUME_Weight = DBNull.Value != dr["主机气缸油消耗"] ? Convert.ToDouble(dr["主机气缸油消耗"].ToString()) : 0.0;
                TYPE2SUME_Weight = DBNull.Value != dr["主机系统油消耗"] ? Convert.ToDouble(dr["主机系统油消耗"].ToString()) : 0.0;
                TYPE3SUME_Weight = DBNull.Value != dr["副机系统油消耗"] ? Convert.ToDouble(dr["副机系统油消耗"].ToString()) : 0.0;

                if (i <= dt.Rows.Count || i == 1)
                {
                    xLabels[i - 1] = dr["船舶"].ToString();
                    TYPE1SUME_WeightPointPairList.Add(Order, TYPE1SUME_Weight);
                    TYPE2SUME_WeightPointPairList.Add(Order, TYPE2SUME_Weight);
                    TYPE3SUME_WeightPointPairList.Add(Order, TYPE3SUME_Weight);
                }
            }

            this.drawGraphByOneData("主机气缸油消耗", graphPane, TYPE1SUME_WeightPointPairList, 1);
            this.drawGraphByOneData("主机系统油消耗", graphPane, TYPE2SUME_WeightPointPairList, 2);
            this.drawGraphByOneData("副机系统油消耗", graphPane, TYPE3SUME_WeightPointPairList, 3);

            //重画坐标比例.
            graphPane.XAxis.Scale.TextLabels = xLabels;

            //重绘统计图
            this.zedMulShips.AxisChange();
            this.zedMulShips.Refresh();

        }

        /// <summary>
        /// 全选按钮触发事件.
        /// </summary>
        private void selectAllByBtnChange()
        {
            if (cklShips.Items.Count == 0) return;

            if (this.btnSelectAll.Text == "全选")
            {

                this.btnSelectAll.Text = "清空";

                for (int i = 0; i < this.cklShips.Items.Count; i++)
                {
                    this.cklShips.SetItemChecked(i, true);
                }
            }
            else
            {
                this.btnSelectAll.Text = "全选";

                for (int i = 0; i < this.cklShips.Items.Count; i++)
                {
                    this.cklShips.SetItemChecked(i, false);
                }
            }


            loadMulData();
        }

        /// <summary>
        /// 事件触发全选按钮.
        /// </summary>
        private void btnChangeBySelect()
        {
            if (cklShips.Items.Count == 0) return;

            bool allSelect = true;

            for (int i = 0; i < this.cklShips.Items.Count; i++)
            {
                if (!this.cklShips.GetItemChecked(i)) allSelect = false;
                else if (this.btnSelectAll.Text == "全选" && this.cklShips.GetItemChecked(i))
                {
                    this.btnSelectAll.Text = "清空";
                    break;
                }
                else if (this.btnSelectAll.Text == "清空" && !this.cklShips.GetItemChecked(i))
                {
                    this.btnSelectAll.Text = "全选";
                }
            }

            if (this.btnSelectAll.Text == "全选" && allSelect) this.btnSelectAll.Text = "清空";
        }

        #endregion


        #region 单船数据

        /// <summary>
        /// 通过船名取得ID.
        /// </summary>
        private void getShipIdByNameToLoadData()
        {
            string tmpName = this.lstShip.SelectedItem == null ? "" : this.lstShip.SelectedItem.ToString();
            string tmpId = "";

            foreach (string tmpNameId in dShips.Keys)
            {
                if (tmpNameId.Contains(tmpName) && tmpName != "")
                {
                    tmpId = tmpNameId.Substring(tmpNameId.Length - 36, 36);
                    break;
                }
            }

            loadSigData(tmpId);
        }

        /// <summary>
        /// 加载单船数据.
        /// </summary>
        private void loadSigData(string ship_id)
        {
            string err = "";

            DateTime sDate = new DateTime(dateStart.Value.Year, dateStart.Value.Month, 1);
            DateTime eDate = new DateTime(dateEnd.Value.Year, dateEnd.Value.Month, 1);
            eDate = eDate.AddMonths(1).AddDays(-1);

            DataTable dtb = HOilLuboilConsumeService.Instance.getMonthSum(ship_id, sDate, eDate, out err);
            dtShipSig = dtb;

            if (dtb.Rows.Count == 0)
            {
                dtb = null;
            }
            else
            {
                //设置单船列项.
                loadDataSig();
            }

            Zed_ShowGraphSig(dtShipSig);
        }

        /// <summary>
        /// 设置单船列项.
        /// </summary>
        private void loadDataSig()
        {
            //设置列标题.
            dtShipSig.Columns["SHIP_NAME"].ColumnName = "船舶";
            dtShipSig.Columns["RECORD_DATE"].ColumnName = "月份";
            dtShipSig.Columns["TYPE1SUME"].ColumnName = "主机气缸油消耗";
            dtShipSig.Columns["TYPE2SUME"].ColumnName = "主机系统油消耗";
            dtShipSig.Columns["TYPE3SUME"].ColumnName = "副机系统油消耗";
        }

        /// <summary>
        /// 显示单船统计图.
        /// </summary>
        private void Zed_ShowGraphSig(DataTable dt)
        {
            string[] xLabels = null;
            string shipName = this.lstShip.SelectedItem == null ? "" : this.lstShip.SelectedItem.ToString();

            //获取画板
            GraphPane graphPane = this.zedSigShip.GraphPane;
            graphPane.CurveList.Clear();

            //设置标题和坐标轴的文字.
            graphPane.Title.Text = shipName + " " + dateStart.Value.Year + "年" + dateStart.Value.Month + "月 至 " + dateEnd.Value.Year + "年" + dateEnd.Value.Month + "月 润滑油月消耗统计图";
            graphPane.XAxis.Title.Text = "月份";
            graphPane.YAxis.Title.Text = "润滑油量 (单位:升)";
            xLabels = new string[dt.Rows.Count];
            graphPane.XAxis.Type = AxisType.Text;

            //准备数据.
            int Order = 0;
            double TYPE1SUME_Weight = 0.00;
            double TYPE2SUME_Weight = 0.00;
            double TYPE3SUME_Weight = 0.00;
            PointPairList TYPE1SUME_WeightPointPairList = new PointPairList();
            PointPairList TYPE2SUME_WeightPointPairList = new PointPairList();
            PointPairList TYPE3SUME_WeightPointPairList = new PointPairList();

            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                Order = ++i;
                TYPE1SUME_Weight = DBNull.Value != dr["主机气缸油消耗"] ? Convert.ToDouble(dr["主机气缸油消耗"].ToString()) : 0.0;
                TYPE2SUME_Weight = DBNull.Value != dr["主机系统油消耗"] ? Convert.ToDouble(dr["主机系统油消耗"].ToString()) : 0.0;
                TYPE3SUME_Weight = DBNull.Value != dr["副机系统油消耗"] ? Convert.ToDouble(dr["副机系统油消耗"].ToString()) : 0.0;

                if (i <= dt.Rows.Count || i == 1)
                {
                    xLabels[i - 1] = dr["月份"].ToString();
                    TYPE1SUME_WeightPointPairList.Add(Order, TYPE1SUME_Weight);
                    TYPE2SUME_WeightPointPairList.Add(Order, TYPE2SUME_Weight);
                    TYPE3SUME_WeightPointPairList.Add(Order, TYPE3SUME_Weight);
                }
            }

            this.drawGraphByOneData("主机气缸油消耗", graphPane, TYPE1SUME_WeightPointPairList, 1);
            this.drawGraphByOneData("主机系统油消耗", graphPane, TYPE2SUME_WeightPointPairList, 2);
            this.drawGraphByOneData("副机系统油消耗", graphPane, TYPE3SUME_WeightPointPairList, 3);

            //重画坐标比例.
            graphPane.XAxis.Scale.TextLabels = xLabels;

            //重绘统计图
            this.zedSigShip.AxisChange();
            this.zedSigShip.Refresh();

        }

        #endregion


        #region 主子表数据

        /// <summary>
        /// 加载主数据.
        /// </summary>
        private void loadMainData()
        {
            string err = "";

            DateTime sDate = new DateTime(dateStart.Value.Year, dateStart.Value.Month, 1);
            DateTime eDate = new DateTime(dateEnd.Value.Year, dateEnd.Value.Month, 1);
            eDate = eDate.AddMonths(1).AddDays(-1);

            DataTable dtb = HOilLuboilConsumeService.Instance.getYearSum(sDate, eDate, out err);
            dgvMain.DataSource = dtb;

            //加载主列项.
            if (isFirstLoadMain)
            {
                loadDataCol();
            }

            if (dgvMain.Rows.Count == 0)
            {
                dgvSub.DataSource = null;
            }
        }

        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataCol()
        {
            dictColumns.Clear();

            //设置列标题.
            dictColumns.Add("SHIP_NAME", "船舶");
            dictColumns.Add("TYPE1SUME", "主机气缸油消耗");
            dictColumns.Add("TYPE2SUME", "主机系统油消耗");
            dictColumns.Add("TYPE3SUME", "副机系统油消耗");

            dgvMain.SetDgvGridColumns(dictColumns);
            isFirstLoadMain = false;
        }

        /// <summary>
        /// 加载子数据.
        /// </summary>
        private void loadSubData(string ship_id)
        {
            string err = "";

            DateTime sDate = new DateTime(dateStart.Value.Year, dateStart.Value.Month, 1);
            DateTime eDate = new DateTime(dateEnd.Value.Year, dateEnd.Value.Month, 1);
            eDate = eDate.AddMonths(1).AddDays(-1);

            DataTable dtb = HOilLuboilConsumeService.Instance.getMonthSum(ship_id, sDate, eDate, out err);
            dgvSub.DataSource = dtb;

            //加载列项.
            loadDataColSub();

        }

        /// <summary>
        /// 设置子列项.
        /// </summary>
        private void loadDataColSub()
        {
            dictColumnsSub.Clear();

            //设置列标题.
            dictColumnsSub.Add("SHIP_NAME", "船舶");
            dictColumnsSub.Add("RECORD_DATE", "月份");
            dictColumnsSub.Add("TYPE1SUME", "主机气缸油消耗");
            dictColumnsSub.Add("TYPE2SUME", "主机系统油消耗");
            dictColumnsSub.Add("TYPE3SUME", "副机系统油消耗");

            dgvSub.SetDgvGridColumns(dictColumnsSub);
        }

        #endregion


        #region 窗体事件

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOilLuboilConsume_Load(object sender, EventArgs e)
        {
            dateStart.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dateEnd.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            loadMulData();
            getShipIdByNameToLoadData();
            loadMainData();
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
        /// 窗体起始日期更改事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateYear_ValueChanged(object sender, EventArgs e)
        {
            loadMulData();
            getShipIdByNameToLoadData();
            loadMainData();

            btnChangeBySelect();
        }

        /// <summary>
        /// 窗体终止日期更改事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateEnd_ValueChanged(object sender, EventArgs e)
        {
            loadMulData();
            getShipIdByNameToLoadData();
            loadMainData();

            btnChangeBySelect();
        }

        /// <summary>
        /// 多船选择更改事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cklShips_SelectedValueChanged(object sender, EventArgs e)
        {
            loadMulData();

            btnChangeBySelect();
        }

        /// <summary>
        /// 单船选择更改事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstShip_SelectedValueChanged(object sender, EventArgs e)
        {
            getShipIdByNameToLoadData();
        }

        /// <summary>
        /// 全选按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            selectAllByBtnChange();
        }

        /// <summary>
        /// DGV列表事件.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMain_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMain.Rows[e.RowIndex].Cells["ship_id"].Value != null)
            {
                string ShipId = dgvMain.Rows[e.RowIndex].Cells["ship_id"].Value.ToString();
                loadSubData(ShipId);
            }


        }

        private void FrmOilLuboilConsume_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        #endregion


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


    }
}