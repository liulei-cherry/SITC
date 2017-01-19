/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：黄家龙
 * 创建时间：2011-08-30
 * 功能描述：机舱主要设备运行时间统计表
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
using CommonViewer.BaseControl;

using CustomerTable.Haifeng.Services;
using CustomerTable.Haifeng.DataObject;
using FileOperationBase.FileServices;
using OfficeOperation;
using FileOperationBase.Services;

namespace CustomTable.Haifeng.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    /// 
    public partial class FrmCabinStatistics : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmCabinStatistics instance = new FrmCabinStatistics();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmCabinStatistics Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmCabinStatistics.instance = new FrmCabinStatistics();
                }
                return FrmCabinStatistics.instance;
            }
        }

        #endregion

        #region 窗体对象

        private ReportMajorEquipment currentObject;
        public ReportMajorEquipment CurrentObject
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

        private DateTime month;
        public DateTime Month
        {
            get { return month; }
            set { month = value; }
        }

        bool isFirstLoadMain = true;
        Dictionary<string, string> dictColumns = new Dictionary<string, string>();

        #endregion

        #region 其它公共业务类

        private FormControlOption other = FormControlOption.Instance;
        Dictionary<string, string> discRate = new Dictionary<string, string>();

        static FileDbService filo = FileDbService.Instance;
        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmCabinStatistics()
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
            setComboBox();                 //设置窗体所需的下拉列表框的数据源.
            loadMainData();
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
            string err;
            DataTable dtbShip = ShipInfoService.Instance.GetOwnerShip(out err);

            cboShip.SelectedValueChanged -= new EventHandler(cboShip_SelectedValueChanged);
            other.SetComboBoxValue(cboShip, dtbShip);
            cboShip.SelectedValueChanged += new EventHandler(cboShip_SelectedValueChanged);
        }

        /// <summary>
        /// 加载dgv初始数据.
        /// </summary>
        public void loadMainData()
        {
            //获得船舶ID
            if (cboShip.SelectedValue == null || cboShip.SelectedValue.ToString() == "System.Data.DataRowView") return;
            shipID = cboShip.SelectedValue.ToString();
            string err = "";
            yearMonth = new DateTime(dateYear.Value.Year, 1, 1);

            DataTable dtb = ReportMajorEquipmentService.Instance.getInfoByYear(shipID, yearMonth, out err);
            bindingSourceMain.DataSource = dtb;
            dgvMain.DataSource = dtb;

            //加载主列项.
            if (isFirstLoadMain)
            {
                loadDataCol();
            }

            if (dtb.Rows.Count == 0)
            {
                CurrentObject = null;// 没有对象则显示置空.
                this.bdNgEditItem.Enabled = false;//编辑按钮可用性.
            }
            else
            {
                this.bdNgEditItem.Enabled = true;
            }
        }

        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataCol()
        {
            dictColumns.Clear();
            //设置列标题.
            dictColumns.Add("Cabin_StatisticsDate", "统计日期");
            dictColumns.Add("Voyage", " 航次");
            dictColumns.Add("Cabin_HostTotal", " 总运行小时");
            dictColumns.Add("ChiefSign", "轮机长签字");
            dgvMain.SetDgvGridColumns(dictColumns);
            isFirstLoadMain = false;
        }

        private void cboShip_SelectedValueChanged(object sender, EventArgs e)
        {
            loadMainData();
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

                string objectId = "";
                if (DBNull.Value != dr.Cells["Report_MajorEquipTime_Id"].Value && null != dr.Cells["Report_MajorEquipTime_Id"].Value)
                    objectId = dr.Cells["Report_MajorEquipTime_Id"].Value.ToString();

                //初始化当前对象.
                CurrentObject = ReportMajorEquipmentService.Instance.getObject(objectId, out err);
            }
        }

        private void showObject(ReportMajorEquipment tempObject)
        {
            if (tempObject != null)
            {
                this.txtBallastPDNO1.Text = tempObject.Pump_BallastDisintegrationNO1;
                this.txtBallastPDNO2.Text = tempObject.Pump_BallastDisintegrationNO2;
                this.txtBallastPTNO1.Text = tempObject.Pump_BallastTotalNO1;
                this.txtBallastPTNO2.Text = tempObject.Pump_BallastTotalNO2;
                this.txtBearOilPDNO1.Text = tempObject.Pump_CamshaftOilDisintegrationNO1;
                this.txtBearOilPDNO2.Text = tempObject.Pump_CamshaftOilDisintegrationNO2;
                this.txtBearOilPTNO1.Text = tempObject.Pump_CamshaftOilTotalNO1;
                this.txtBearOilPTNO2.Text = tempObject.Pump_CamshaftOilTotalNO2;
                this.txtBoilerPD.Text = tempObject.Pump_BoilerDisintegration;
                this.txtBoilerPT.Text = tempObject.Pump_BoilerTotal;
                this.txtConnectBearNO1.Text = tempObject.Host_ConnectRodBearNO1;
                this.txtConnectBearNO2.Text = tempObject.Host_ConnectRodBearNO2;
                this.txtConnectBearNO3.Text = tempObject.Host_ConnectRodBearNO3;
                this.txtConnectBearNO4.Text = tempObject.Host_ConnectRodBearNO4;
                this.txtConnectBearNO5.Text = tempObject.Host_ConnectRodBearNO5;
                this.txtConnectBearNO6.Text = tempObject.Host_ConnectRodBearNO6;
                this.txtConnectBearNO7.Text = tempObject.Host_ConnectRodBearNO7;
                this.txtConnectBearNO8.Text = tempObject.Host_ConnectRodBearNO8;
                this.txtConnectBearNO9.Text = tempObject.Host_ConnectRodBearNO9;
                this.txtCoolerNO1.Text = tempObject.Gas_AirCoolerNO1;
                this.txtCoolerNO2.Text = tempObject.Gas_AirCoolerNO2;
                this.txtCrossBearNO1.Text = tempObject.Host_CrossheadBearNO1;
                this.txtCrossBearNO2.Text = tempObject.Host_CrossheadBearNO2;
                this.txtCrossBearNO3.Text = tempObject.Host_CrossheadBearNO3;
                this.txtCrossBearNO4.Text = tempObject.Host_CrossheadBearNO4;
                this.txtCrossBearNO5.Text = tempObject.Host_CrossheadBearNO5;
                this.txtCrossBearNO6.Text = tempObject.Host_CrossheadBearNO6;
                this.txtCrossBearNO7.Text = tempObject.Host_CrossheadBearNO7;
                this.txtCrossBearNO8.Text = tempObject.Host_CrossheadBearNO8;
                this.txtCrossBearNO9.Text = tempObject.Host_CrossheadBearNO9;

                this.txtCylinderWaterPDNO1.Text = tempObject.Pump_CylinderDisintegrationNO1;
                this.txtCylinderWaterPDNO2.Text = tempObject.Pump_CylinderDisintegrationNO2;
                this.txtCylinderWaterPTNO1.Text = tempObject.Pump_CylinderTotalNO1;
                this.txtCylinderWaterPTNO2.Text = tempObject.Pump_CylinderTotalNO2;
                this.txtDieselPD.Text = tempObject.Pump_DieselFuelDisintegration;
                this.txtDieselPT.Text = tempObject.Pump_DieselFuelTotal;
                this.txtEmergencyPD.Text = tempObject.Pump_EmergencyDisintegration;
                this.txtEmergencyPT.Text = tempObject.Pump_EmergencyTotal;
                this.txtExhaustNO1.Text = tempObject.Host_ExhaustExchangeNO1;
                this.txtExhaustNO2.Text = tempObject.Host_ExhaustExchangeNO2;
                this.txtExhaustNO3.Text = tempObject.Host_ExhaustExchangeNO3;
                this.txtExhaustNO4.Text = tempObject.Host_ExhaustExchangeNO4;
                this.txtExhaustNO5.Text = tempObject.Host_ExhaustExchangeNO5;
                this.txtExhaustNO6.Text = tempObject.Host_ExhaustExchangeNO6;
                this.txtExhaustNO7.Text = tempObject.Host_ExhaustExchangeNO7;
                this.txtExhaustNO8.Text = tempObject.Host_ExhaustExchangeNO8;
                this.txtExhaustNO9.Text = tempObject.Host_ExhaustExchangeNO9;

                this.txtFirePD.Text = tempObject.Pump_FireDisintegration;
                this.txtFirePT.Text = tempObject.Pump_FireTotal;

                this.txtFuelCirclePDNO1.Text = tempObject.Pump_FuelCircleDisintegratinNO1;
                this.txtFuelCirclePDNO2.Text = tempObject.Pump_FuelCircleDisintegratinNO2;
                this.txtFuelCirclePTNO1.Text = tempObject.Pump_FuelCircleTotalNO1;
                this.txtFuelCirclePTNO2.Text = tempObject.Pump_FuelCircleTotalNO2;
                this.txtGeneralPD.Text = tempObject.Pump_GeneralDisintegration;
                this.txtGeneralPT.Text = tempObject.Pump_GeneralToatl;
                this.txtHAirLiftingCylinderNO1.Text = tempObject.Gas_ACliftingCylinderNO1;
                this.txtHAirLiftingCylinderNO2.Text = tempObject.Gas_ACliftingCylinderNO2;
                this.txtHAirLiftingCylinderNO3.Text = tempObject.Gas_ACliftingCylinderNO3;
                this.txtHAirTNO1.Text = tempObject.Gas_ACTotalNO1;
                this.txtHAirTNO2.Text = tempObject.Gas_ACTotalNO2;
                this.txtHAirTNO3.Text = tempObject.Gas_ACTotalNO3;
                this.txthCylinerRenewNO1.Text = tempObject.Host_CylinderRenewalNO1;
                this.txthCylinerRenewNO2.Text = tempObject.Host_CylinderRenewalNO2;
                this.txthCylinerRenewNO3.Text = tempObject.Host_CylinderRenewalNO3;
                this.txthCylinerRenewNO4.Text = tempObject.Host_CylinderRenewalNO4;
                this.txthCylinerRenewNO5.Text = tempObject.Host_CylinderRenewalNO5;
                this.txthCylinerRenewNO6.Text = tempObject.Host_CylinderRenewalNO6;
                this.txthCylinerRenewNO7.Text = tempObject.Host_CylinderRenewalNO7;
                this.txthCylinerRenewNO8.Text = tempObject.Host_CylinderRenewalNO8;
                this.txthCylinerRenewNO9.Text = tempObject.Host_CylinderRenewalNO9;
                this.txtHeavyOilPDNO1.Text = tempObject.Pump_HeavyOilDisintegrationNO1;

                this.txtHeavyOilPDNO2.Text = tempObject.Pump_HeavyOilDisintegrationNO2;
                this.txtHeavyOilPTNO1.Text = tempObject.Pump_HeavyOilTotalNO1;
                this.txtHeavyOilPTNO2.Text = tempObject.Pump_HeavyOilTotalNO2;
                this.txthMajorBearNO1.Text = tempObject.Host_MajorBearNO1;
                this.txthMajorBearNO2.Text = tempObject.Host_MajorBearNO2;
                this.txthMajorBearNO3.Text = tempObject.Host_MajorBearNO3;
                this.txthMajorBearNO4.Text = tempObject.Host_MajorBearNO4;
                this.txthMajorBearNO5.Text = tempObject.Host_MajorBearNO5;
                this.txthMajorBearNO6.Text = tempObject.Host_MajorBearNO6;
                this.txthMajorBearNO7.Text = tempObject.Host_MajorBearNO7;
                this.txthMajorBearNO8.Text = tempObject.Host_MajorBearNO8;
                this.txthMajorBearNO9.Text = tempObject.Host_MajorBearNO9;
                this.txthPressureOilBearNO1.Text = tempObject.Host_HighPreesurePumpNO1;
                this.txthPressureOilBearNO2.Text = tempObject.Host_HighPreesurePumpNO2;
                this.txthPressureOilBearNO3.Text = tempObject.Host_HighPreesurePumpNO3;
                this.txthPressureOilBearNO4.Text = tempObject.Host_HighPreesurePumpNO4;
                this.txthPressureOilBearNO5.Text = tempObject.Host_HighPreesurePumpNO5;
                this.txthPressureOilBearNO6.Text = tempObject.Host_HighPreesurePumpNO6;
                this.txthPressureOilBearNO7.Text = tempObject.Host_HighPreesurePumpNO7;
                this.txthPressureOilBearNO8.Text = tempObject.Host_HighPreesurePumpNO8;
                this.txthPressureOilBearNO9.Text = tempObject.Host_HighPreesurePumpNO9;
                this.txtLiftingCylinderNO1.Text = tempObject.Host_LiftingCylinderNO1;
                this.txtLiftingCylinderNO13.Text = tempObject.Host_LiftingCylinderNO2;
                this.txtLiftingCylinderNO2.Text = tempObject.Host_LiftingCylinderNO3;
                this.txtLiftingCylinderNO4.Text = tempObject.Host_LiftingCylinderNO4;
                this.txtLiftingCylinderNO5.Text = tempObject.Host_LiftingCylinderNO5;
                this.txtLiftingCylinderNO6.Text = tempObject.Host_LiftingCylinderNO6;
                this.txtLiftingCylinderNO7.Text = tempObject.Host_LiftingCylinderNO7;
                this.txtLiftingCylinderNO8.Text = tempObject.Host_LiftingCylinderNO8;
                this.txtLiftingCylinderNO9.Text = tempObject.Host_LiftingCylinderNO9;
                this.txtLowTemWaterPDNO1.Text = tempObject.Pump_LowTemDisintegrationNO1;
                this.txtLowTemWaterPDNO2.Text = tempObject.Pump_LowTemDisintegrationNO2;
                this.txtLowTemWaterPTNO1.Text = tempObject.Pump_LowTemTotalNO1;
                this.txtLowTemWaterPTNO2.Text = tempObject.Pump_LowTemTotalNO2;

                this.txtMainBearNO1.Text = tempObject.Gas_SMajorBearNO1;
                this.txtMainBearNO2.Text = tempObject.Gas_SMajorBearNO2;
                this.txtMainBearNO3.Text = tempObject.Gas_SMajorBearNO3;
                this.txtMainOilPDNO1.Text = tempObject.Pump_MainOilDisintegrationNO1;
                this.txtMainOilPDNO2.Text = tempObject.Pump_MainOilDisintegrationNO2;
                this.txtMainOilPTNO1.Text = tempObject.Pump_MainOilTotalNO1;
                this.txtMainOilPTNO2.Text = tempObject.Pump_MainOilTotalNO2;
                this.txtMainSeaWaterPDNO1.Text = tempObject.Pump_MainSeaDisintegrationNO1;
                this.txtMainSeaWaterPDNO2.Text = tempObject.Pump_MainSeaDisintegrationNO2;
                this.txtMainSeaWaterPTNO1.Text = tempObject.Pump_MainSeaTotalNO1;
                this.txtMainSeaWaterPTNO2.Text = tempObject.Pump_MainSeaTotalNO2;

                this.txtMarbleNO1.Text = tempObject.Gas_MarblePanelNO1;
                this.txtMarbleNO2.Text = tempObject.Gas_MarblePanelNO2;
                this.txtOilDividePDNO1.Text = tempObject.Pump_OilDisintegrationNO1;
                this.txtOilDividePDNO2.Text = tempObject.Pump_OilDisintegrationNO2;
                this.txtOilDividePTNO1.Text = tempObject.Pump_OilTotalNO1;
                this.txtOilDividePTNO2.Text = tempObject.Pump_OilTotalNO2;

                this.txtOilHeadNO1.Text = tempObject.Host_OilHeadCheckNO1;
                this.txtOilHeadNO2.Text = tempObject.Host_OilHeadCheckNO2;
                this.txtOilHeadNO3.Text = tempObject.Host_OilHeadCheckNO3;
                this.txtOilHeadNO4.Text = tempObject.Host_OilHeadCheckNO4;
                this.txtOilHeadNO5.Text = tempObject.Host_OilHeadCheckNO5;
                this.txtOilHeadNO6.Text = tempObject.Host_OilHeadCheckNO6;
                this.txtOilHeadNO7.Text = tempObject.Host_OilHeadCheckNO7;
                this.txtOilHeadNO8.Text = tempObject.Host_OilHeadCheckNO8;
                this.txtOilHeadNO9.Text = tempObject.Host_OilHeadCheckNO9;

                this.txtParkLowWaterPD.Text = tempObject.Pump_ParkLowTemDisintegration;
                this.txtParkLowWaterPT.Text = tempObject.Pump_ParkLowTemTotal;
                this.txtPreCheckNO1.Text = tempObject.Gas_DismantNO1;
                this.txtPreCheckNO2.Text = tempObject.Gas_DismantNO2;
                this.txtPressureFuelPDNO1.Text = tempObject.Pump_FuelPressureDisintegrationNO1;
                this.txtPressureFuelPDNO2.Text = tempObject.Pump_FuelPressureDisintegrationNO2;
                this.txtPressureFuelPTNO1.Text = tempObject.Pump_FuelPressureTotalNO1;
                this.txtPressureFuelPTNO2.Text = tempObject.Pump_FuelPressureTotalNO2;
                this.txtRemarks.Text = tempObject.Gas_Remarks;
                this.txtRudderCheckNO1.Text = tempObject.Gas_PPCheckNO1;
                this.txtRudderCheckNO2.Text = tempObject.Gas_PPCheckNO2;
                this.txtRudderNO1.Text = tempObject.Gas_PPTotalNO1;
                this.txtRudderNO2.Text = tempObject.Gas_PPTotalNO2;
                this.txtSecondSeaWaterPD.Text = tempObject.Pump_SecondSeaDisintegration;
                this.txtSecondSeaWaterPT.Text = tempObject.Pump_SecondSeaTotal;
                this.txtSExhaustNO1.Text = tempObject.Gas_SExhaustExchangeNO1;
                this.txtSExhaustNO2.Text = tempObject.Gas_SExhaustExchangeNO2;
                this.txtSExhaustNO3.Text = tempObject.Gas_SExhaustExchangeNO3;
                this.txtSOilHeaderNO1.Text = tempObject.Gas_SOilHeadNO1;
                this.txtSOilHeaderNO2.Text = tempObject.Gas_SOilHeadNO2;
                this.txtSOilHeaderNO3.Text = tempObject.Gas_SOilHeadNO3;
                this.txtSPressureNO1.Text = tempObject.Gas_STurbochargerNO1;
                this.txtSPressureNO2.Text = tempObject.Gas_STurbochargerNO2;
                this.txtSPressureNO3.Text = tempObject.Gas_STurbochargerNO3;
                this.txtSTLiftCylinderNO1.Text = tempObject.Gas_SLiftingCylinderNO1;
                this.txtSTLiftCylinderNO2.Text = tempObject.Gas_SLiftingCylinderNO2;
                this.txtSTLiftCylinderNO3.Text = tempObject.Gas_SLiftingCylinderNO3;
                this.txtSTNO1.Text = tempObject.Gas_STotalNO1;
                this.txtSTNO2.Text = tempObject.Gas_STotalNO2;
                this.txtSTNO3.Text = tempObject.Gas_STotalNO3;

                this.txtTotaltime.Text = tempObject.Cabin_HostTotal;
                this.txtVoyage.Text = tempObject.Voyage;
                this.txtStatisticsDate.Text = tempObject.Cabin_StatisticsDate.ToString("yyyy年MM月dd日");
                this.txtChiefSign.Text = tempObject.ChiefSign;
            }
            else
            {
                this.txtBallastPDNO1.Text = "";
                this.txtBallastPDNO2.Text = "";
                this.txtBallastPTNO1.Text = "";
                this.txtBallastPTNO2.Text = "";
                this.txtBearOilPDNO1.Text = "";
                this.txtBearOilPDNO2.Text = "";
                this.txtBearOilPTNO1.Text = "";
                this.txtBearOilPTNO2.Text = "";
                this.txtBoilerPD.Text = "";
                this.txtBoilerPT.Text = "";
              
                this.txtConnectBearNO1.Text = "";
                this.txtConnectBearNO2.Text = "";
                this.txtConnectBearNO3.Text = "";
                this.txtConnectBearNO4.Text = "";
                this.txtConnectBearNO5.Text = "";
                this.txtConnectBearNO6.Text = "";
                this.txtConnectBearNO7.Text = "";
                this.txtConnectBearNO8.Text = "";
                this.txtConnectBearNO9.Text = "";

                this.txtCoolerNO1.Text = "";
                this.txtCoolerNO2.Text = "";
                this.txtCrossBearNO1.Text = "";
                this.txtCrossBearNO2.Text = "";
                this.txtCrossBearNO3.Text = "";
                this.txtCrossBearNO4.Text = "";
                this.txtCrossBearNO5.Text = "";
                this.txtCrossBearNO6.Text = "";
                this.txtCrossBearNO7.Text = "";
                this.txtCrossBearNO8.Text = "";
                this.txtCrossBearNO9.Text = "";

                this.txtCylinderWaterPDNO1.Text = "";
                this.txtCylinderWaterPDNO2.Text = "";
                this.txtCylinderWaterPTNO1.Text = "";
                this.txtCylinderWaterPTNO2.Text = "";
                this.txtDieselPD.Text = "";
                this.txtDieselPT.Text = "";
                this.txtEmergencyPD.Text = "";
                this.txtEmergencyPT.Text = "";
                this.txtExhaustNO1.Text = "";
                this.txtExhaustNO2.Text = "";
                this.txtExhaustNO3.Text = "";
                this.txtExhaustNO4.Text = "";
                this.txtExhaustNO5.Text = "";
                this.txtExhaustNO6.Text = "";
                this.txtExhaustNO7.Text = "";
                this.txtExhaustNO8.Text = "";
                this.txtExhaustNO9.Text = "";

                this.txtFirePD.Text = "";
                this.txtFirePT.Text = "";

                this.txtFuelCirclePDNO1.Text = "";
                this.txtFuelCirclePDNO2.Text = "";
                this.txtFuelCirclePTNO1.Text = "";
                this.txtFuelCirclePTNO2.Text = "";
                this.txtGeneralPD.Text = "";
                this.txtGeneralPT.Text = "";
                this.txtHAirLiftingCylinderNO1.Text = "";
                this.txtHAirLiftingCylinderNO2.Text = "";
                this.txtHAirLiftingCylinderNO3.Text = "";
                this.txtHAirTNO1.Text = "";
                this.txtHAirTNO2.Text = "";
                this.txtHAirTNO3.Text = "";
                this.txthCylinerRenewNO1.Text = "";
                this.txthCylinerRenewNO2.Text = "";
                this.txthCylinerRenewNO3.Text = "";
                this.txthCylinerRenewNO4.Text = "";
                this.txthCylinerRenewNO5.Text = "";
                this.txthCylinerRenewNO6.Text = "";
                this.txthCylinerRenewNO7.Text = "";
                this.txthCylinerRenewNO8.Text = "";
                this.txthCylinerRenewNO9.Text = "";
                this.txtHeavyOilPDNO1.Text = "";

                this.txtHeavyOilPDNO2.Text = "";
                this.txtHeavyOilPTNO1.Text = "";
                this.txtHeavyOilPTNO2.Text = "";
                this.txthMajorBearNO1.Text = "";
                this.txthMajorBearNO2.Text = "";
                this.txthMajorBearNO3.Text = "";
                this.txthMajorBearNO4.Text = "";
                this.txthMajorBearNO5.Text = "";
                this.txthMajorBearNO6.Text = "";
                this.txthMajorBearNO7.Text = "";
                this.txthMajorBearNO8.Text = "";
                this.txthMajorBearNO9.Text = "";

                this.txthPressureOilBearNO1.Text = "";
                this.txthPressureOilBearNO2.Text = "";
                this.txthPressureOilBearNO3.Text = "";
                this.txthPressureOilBearNO4.Text = "";
                this.txthPressureOilBearNO5.Text = "";
                this.txthPressureOilBearNO6.Text = "";
                this.txthPressureOilBearNO7.Text = "";
                this.txthPressureOilBearNO8.Text = "";
                this.txthPressureOilBearNO9.Text = "";

                this.txtLiftingCylinderNO1.Text = "";
                this.txtLiftingCylinderNO13.Text = "";
                this.txtLiftingCylinderNO2.Text = "";
                this.txtLiftingCylinderNO4.Text = "";
                this.txtLiftingCylinderNO5.Text = "";
                this.txtLiftingCylinderNO6.Text = "";
                this.txtLiftingCylinderNO7.Text = "";
                this.txtLiftingCylinderNO8.Text = "";
                this.txtLiftingCylinderNO9.Text = "";

                this.txtLowTemWaterPDNO1.Text = "";
                this.txtLowTemWaterPDNO2.Text = "";
                this.txtLowTemWaterPTNO1.Text = "";
                this.txtLowTemWaterPTNO2.Text = "";

                this.txtMainBearNO1.Text = "";
                this.txtMainBearNO2.Text = "";
                this.txtMainBearNO3.Text = "";
                this.txtMainOilPDNO1.Text = "";
                this.txtMainOilPDNO2.Text = "";
                this.txtMainOilPTNO1.Text = "";
                this.txtMainOilPTNO2.Text = "";
                this.txtMainSeaWaterPDNO1.Text = "";
                this.txtMainSeaWaterPDNO2.Text = "";
                this.txtMainSeaWaterPTNO1.Text = "";
                this.txtMainSeaWaterPTNO2.Text = "";

                this.txtMarbleNO1.Text = "";
                this.txtMarbleNO2.Text = "";
                this.txtOilDividePDNO1.Text = "";
                this.txtOilDividePDNO2.Text = "";
                this.txtOilDividePTNO1.Text = "";
                this.txtOilDividePTNO2.Text = "";

                this.txtOilHeadNO1.Text = "";
                this.txtOilHeadNO2.Text = "";
                this.txtOilHeadNO3.Text = "";
                this.txtOilHeadNO4.Text = "";
                this.txtOilHeadNO5.Text = "";
                this.txtOilHeadNO6.Text = "";
                this.txtOilHeadNO7.Text = "";
                this.txtOilHeadNO8.Text = "";
                this.txtOilHeadNO9.Text = "";

                this.txtParkLowWaterPD.Text = "";
                this.txtParkLowWaterPT.Text = "";
                this.txtPreCheckNO1.Text = "";
                this.txtPreCheckNO2.Text = "";
                this.txtPressureFuelPDNO1.Text = "";
                this.txtPressureFuelPDNO2.Text = "";
                this.txtPressureFuelPTNO1.Text = "";
                this.txtPressureFuelPTNO2.Text = "";
                this.txtRemarks.Text = "";
                this.txtRudderCheckNO1.Text = "";
                this.txtRudderCheckNO2.Text = "";
                this.txtRudderNO1.Text = "";
                this.txtRudderNO2.Text = "";
                this.txtSecondSeaWaterPD.Text = "";
                this.txtSecondSeaWaterPT.Text = "";
                this.txtSExhaustNO1.Text = "";
                this.txtSExhaustNO2.Text = "";
                this.txtSExhaustNO3.Text = "";
                this.txtSOilHeaderNO1.Text = "";
                this.txtSOilHeaderNO2.Text = "";
                this.txtSOilHeaderNO3.Text = "";
                this.txtSPressureNO1.Text = "";
                this.txtSPressureNO2.Text = "";
                this.txtSPressureNO3.Text = "";
                this.txtSTLiftCylinderNO1.Text = "";
                this.txtSTLiftCylinderNO2.Text = "";
                this.txtSTLiftCylinderNO3.Text = "";
                this.txtSTNO1.Text = "";
                this.txtSTNO2.Text = "";
                this.txtSTNO3.Text = "";

                this.txtTotaltime.Text = "";
                this.txtVoyage.Text = "";
                this.txtStatisticsDate.Text = "";
                this.txtChiefSign.Text = "";
            }
        }
        
        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            FrmEditCabinStatistics frm = new FrmEditCabinStatistics(ShipID, null);
            frm.ShowDialog();

            ////刷新列表.
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

        /// <summary>
        /// 编辑操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgEditItem_Click(object sender, EventArgs e)
        {
            CustomTable.Haifeng.Viewer.FrmEditCabinStatistics frm = new CustomTable.Haifeng.Viewer.FrmEditCabinStatistics(ShipID, CurrentObject);
            frm.ShowDialog();

            ////刷新列表.
            loadMainData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (currentObject == null && this.dgvMain.Rows.Count == 0)
            {
                MessageBoxEx.Show("无可打印的信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string err = "";                                 //错误信息参数.
            string shipName = ShipInfoService.Instance.getObject(shipID, out err).SHIP_NAME;
            string applyDate = currentObject.Cabin_StatisticsDate.ToString("yyyy.MM"); //取处理年月.

            string fileId = currentObject.File_ID;                    //机舱主要设备运行时间统计表Id

            ////如果找到了相应的机舱主要设备运行时间统计表,则提示用户是否打开旧的.
            string fileName = "机舱主要设备运行时间统计表" + currentObject.Cabin_StatisticsDate.ToString("yyyy年MM月");
            string fileid;
            if (FolderFileDbService.Instance.IfFolderHasTheFile(fileId, fileName + ".xls", out fileid))
            {
                if (MessageBoxEx.Show("找到了之前形成的机舱主要设备运行时间统计表文件" + fileName + ",是否要直接打开此文件?" +
                    "\r选择否,系统推荐您删除旧文件,以免形成多个机舱主要设备运行时间统计表的导出文件给其他人造成误导.", "系统提示", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ourFile ofile;

                    if (!FileDbService.Instance.GetAFileById(fileid, out ofile))
                    {
                        MessageBoxEx.Show("非常抱歉,没有成功获取此文档,下面将重新形成新文件!", "系统提示");
                    }
                    else
                    {
                        openFile opf = new openFile();
                        opf.FileOpen(ofile, right.U);
                        return;
                    }
                }
                else
                {
                    if (!FolderFileDbService.Instance.DeleteAFile(fileId, fileid, out err))
                    {
                        MessageBoxEx.Show("删除旧文件失败" + err, "提示");
                        return;
                    }
                }
            }

            //调用导出报表打印功能.
            DialogResult dr = FolderBrowserDialogEx.ShowDialog(folderBD);
            if (dr == DialogResult.OK)
            {
                string path;
                path = folderBD.SelectedPath.ToString();
                if (System.IO.File.Exists(path + "\\" + fileName + ".xls"))
                {
                    if (MessageBoxEx.Show("您选择的文件夹已经包含了指定文件,是否覆盖此文件?" +
                        "\r选择是,系统将覆盖当前文件.\r选择否,系统推荐为您新生成的文件添加一个随机后缀,让其不发生冲突.",
                        "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        path = path + "\\" + fileName + ".xls";
                        FileInfo fTemp = new FileInfo(path);
                        fTemp.Delete();
                    }
                    else
                    {
                        path = path + "\\" + fileName + Guid.NewGuid().ToString().Substring(0, 5) + ".xls";
                    }
                }
                else path = path + "\\" + fileName + ".xls";

                if (!applyPrint(currentObject, path, out err))
                {
                    MessageBoxEx.Show(err, "信息提示");
                }
            }
        }

         //<summary>
         ////打印输出.
         //</summary>
        public bool applyPrint(ReportMajorEquipment obj, string path, out string err)
        {
            err = "";

            if (string.IsNullOrEmpty(path))
            {
                err = "传入的path参数无效.";
                return false;
            }

            if (obj == null || obj.IsWrong)
            {
                err = "获取机舱主要设备运行时间统计表的数据时出错,请确认选择了有效数据.\r更多错误信息请参考::" + err;
                return false;
            }
            //   obj.FillThisObject();

            WorkModelType model = WorkModelTypeService.Instance.getModelObject(obj.SHIP_ID, CommonPrintTableName.CTNOfCabinStatistics, out err);
            if (model == null || model.IsWrong || model.ModelFile.Trim().Length == 0)
            {
                err = "获取机舱主要设备运行时间统计表的表格时出错,请管理员从模板管理模块导入相应的表格.\r更多错误信息请参考:" + err;
                return false;
            }

            FileInfo f = new FileInfo(path);
           
            if (f.Exists) f.Delete();

            string path2;
            //获取模板文件,并保存到指定位置;
            if (!filo.GetABlobById(model.ModelFile, f.Name, out path2))
            {
                err = "获取机舱主要设备运行时间统计表的表格时出错,可能是大文件库连接串有问题,或者大文件数据库本身出现问题.\r更多错误信息请参考:" + err;
                return false;
            }

            OfficeOperation.Excel excel = new OfficeOperation.Excel();
            excel.OpenDocument(path2);

            //填充模板内容.
            string shipName = ShipInfoService.Instance.GetShipName(currentObject.SHIP_ID);
            excel.SetSingelCellValue(1, 3, "船名：" + shipName, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(4, 4, obj.Cabin_HostTotal, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(6, 4, obj.Voyage, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(11, 4, obj.Cabin_StatisticsDate.Year.ToString() + "年 " + obj.Cabin_StatisticsDate.Month.ToString() + "月 " + obj.Cabin_StatisticsDate.Day.ToString() + "日", XlHorizontalAlignment.xlRight);

            excel.SetSingelCellValue(2, 7, obj.Host_CylinderRenewalNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(3, 7, obj.Host_CylinderRenewalNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(4, 7, obj.Host_CylinderRenewalNO3, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(5, 7, obj.Host_CylinderRenewalNO4, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(6, 7, obj.Host_CylinderRenewalNO5, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(8, 7, obj.Host_CylinderRenewalNO6, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(10, 7, obj.Host_CylinderRenewalNO7, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(11, 7, obj.Host_CylinderRenewalNO8, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(13, 7, obj.Host_CylinderRenewalNO9, XlHorizontalAlignment.xlLeft);

            excel.SetSingelCellValue(2, 8, obj.Host_LiftingCylinderNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(3, 8, obj.Host_LiftingCylinderNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(4, 8, obj.Host_LiftingCylinderNO3, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(5, 8, obj.Host_LiftingCylinderNO4, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(6, 8, obj.Host_LiftingCylinderNO5, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(8, 8, obj.Host_LiftingCylinderNO6, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(10, 8, obj.Host_LiftingCylinderNO7, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(11,8, obj.Host_LiftingCylinderNO8, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(13, 8, obj.Host_LiftingCylinderNO9, XlHorizontalAlignment.xlLeft);

            excel.SetSingelCellValue(2, 9, obj.Host_ExhaustExchangeNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(3, 9, obj.Host_ExhaustExchangeNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(4, 9, obj.Host_ExhaustExchangeNO3, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(5, 9, obj.Host_ExhaustExchangeNO4, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(6, 9, obj.Host_ExhaustExchangeNO5, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(8, 9, obj.Host_ExhaustExchangeNO6, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(10, 9, obj.Host_ExhaustExchangeNO7, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(11, 9, obj.Host_ExhaustExchangeNO8, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(13, 9, obj.Host_ExhaustExchangeNO9, XlHorizontalAlignment.xlLeft);

            excel.SetSingelCellValue(2, 10, obj.Host_OilHeadCheckNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(3, 10, obj.Host_OilHeadCheckNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(4, 10, obj.Host_OilHeadCheckNO3, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(5, 10, obj.Host_OilHeadCheckNO4, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(6, 10, obj.Host_OilHeadCheckNO5, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(8, 10, obj.Host_OilHeadCheckNO6, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(10, 10, obj.Host_OilHeadCheckNO7, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(11, 10, obj.Host_OilHeadCheckNO8, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(13, 10, obj.Host_OilHeadCheckNO9, XlHorizontalAlignment.xlLeft);

            excel.SetSingelCellValue(2, 11, obj.Host_CrossheadBearNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(3, 11, obj.Host_CrossheadBearNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(4, 11, obj.Host_CrossheadBearNO3, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(5, 11, obj.Host_CrossheadBearNO4, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(6, 11, obj.Host_CrossheadBearNO5, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(8, 11, obj.Host_CrossheadBearNO6, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(10, 11, obj.Host_CrossheadBearNO7, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(11, 11, obj.Host_CrossheadBearNO8, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(13, 11, obj.Host_CrossheadBearNO9, XlHorizontalAlignment.xlLeft);

            excel.SetSingelCellValue(2, 12, obj.Host_ConnectRodBearNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(3, 12, obj.Host_ConnectRodBearNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(4, 12, obj.Host_ConnectRodBearNO3, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(5, 12, obj.Host_ConnectRodBearNO4, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(6, 12, obj.Host_ConnectRodBearNO5, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(8, 12, obj.Host_ConnectRodBearNO6, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(10, 12, obj.Host_ConnectRodBearNO7, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(11, 12, obj.Host_ConnectRodBearNO8, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(13, 12, obj.Host_ConnectRodBearNO9, XlHorizontalAlignment.xlLeft);

            excel.SetSingelCellValue(2, 13, obj.Host_MajorBearNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(3, 13, obj.Host_MajorBearNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(4, 13, obj.Host_MajorBearNO3, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(5, 13, obj.Host_MajorBearNO4, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(6, 13, obj.Host_MajorBearNO5, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(8, 13, obj.Host_MajorBearNO6, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(10, 13, obj.Host_MajorBearNO7, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(11, 13, obj.Host_MajorBearNO8, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(13, 13, obj.Host_MajorBearNO9, XlHorizontalAlignment.xlLeft);

            excel.SetSingelCellValue(2, 14, obj.Host_HighPreesurePumpNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(3, 14, obj.Host_HighPreesurePumpNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(4, 14, obj.Host_HighPreesurePumpNO3, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(5, 14, obj.Host_HighPreesurePumpNO4, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(6, 14, obj.Host_HighPreesurePumpNO5, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(8, 14, obj.Host_HighPreesurePumpNO6, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(10, 14, obj.Host_HighPreesurePumpNO7, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(11, 14, obj.Host_HighPreesurePumpNO8, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(13, 14, obj.Host_HighPreesurePumpNO9, XlHorizontalAlignment.xlLeft);

            excel.SetSingelCellValue(3, 17, obj.Gas_DismantNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(6, 17, obj.Gas_DismantNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(3, 18, obj.Gas_MarblePanelNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(6, 18, obj.Gas_MarblePanelNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(3, 19, obj.Gas_AirCoolerNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(6, 19, obj.Gas_AirCoolerNO2, XlHorizontalAlignment.xlLeft);

            excel.SetSingelCellValue(3, 21, obj.Gas_STotalNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(5, 21, obj.Gas_STotalNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(7, 21, obj.Gas_STotalNO3, XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(3, 22, obj.Gas_SLiftingCylinderNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(5, 22, obj.Gas_SLiftingCylinderNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(7, 22, obj.Gas_SLiftingCylinderNO3, XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(3, 23, obj.Gas_SExhaustExchangeNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(5, 23, obj.Gas_SExhaustExchangeNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(7, 23, obj.Gas_SExhaustExchangeNO3, XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(3, 24, obj.Gas_SOilHeadNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(5, 24, obj.Gas_SOilHeadNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(7, 24, obj.Gas_SOilHeadNO3, XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(3, 25, obj.Gas_SMajorBearNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(5, 25, obj.Gas_SMajorBearNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(7, 25, obj.Gas_SMajorBearNO3, XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(3, 26, obj.Gas_STurbochargerNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(5, 26, obj.Gas_STurbochargerNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(7, 26, obj.Gas_STurbochargerNO3, XlHorizontalAlignment.xlRight); 

            excel.SetSingelCellValue(3, 28, obj.Gas_ACTotalNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(5, 28, obj.Gas_ACTotalNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(7, 28, obj.Gas_ACTotalNO3, XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(3, 29, obj.Gas_ACliftingCylinderNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(5, 29, obj.Gas_ACliftingCylinderNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(7, 29, obj.Gas_ACliftingCylinderNO3, XlHorizontalAlignment.xlRight);

            excel.SetSingelCellValue(3, 31, obj.Gas_PPTotalNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(6, 31, obj.Gas_PPTotalNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(3, 32, obj.Gas_PPCheckNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(6, 32, obj.Gas_PPCheckNO2, XlHorizontalAlignment.xlLeft);

            //主机泵浦.
            excel.SetSingelCellValue(12, 18, obj.Pump_MainSeaTotalNO1+" / "+obj.Pump_MainSeaDisintegrationNO1, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(12, 19, obj.Pump_MainSeaTotalNO2 + " / " + obj.Pump_MainSeaDisintegrationNO2, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(11, 20, obj.Pump_SecondSeaTotal + " / " + obj.Pump_SecondSeaDisintegration, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(12, 21, obj.Pump_CylinderTotalNO1 + " / " + obj.Pump_CylinderDisintegrationNO1, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(12, 22, obj.Pump_CylinderTotalNO2 + " / " + obj.Pump_CylinderDisintegrationNO2, XlHorizontalAlignment.xlCenter);

            excel.SetSingelCellValue(12, 23, obj.Pump_LowTemTotalNO1 + " / " + obj.Pump_LowTemDisintegrationNO1, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(12, 24, obj.Pump_LowTemTotalNO2 + " / " + obj.Pump_LowTemDisintegrationNO2, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(11, 25, obj.Pump_ParkLowTemTotal + " / " + obj.Pump_ParkLowTemDisintegration, XlHorizontalAlignment.xlCenter);

            excel.SetSingelCellValue(12, 26, obj.Pump_MainOilTotalNO1 + " / " + obj.Pump_MainOilDisintegrationNO1, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(12, 27, obj.Pump_MainOilTotalNO2 + " / " + obj.Pump_MainOilDisintegrationNO2, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(12, 28, obj.Pump_CamshaftOilTotalNO1 + " / " + obj.Pump_CamshaftOilDisintegrationNO1, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(12, 29, obj.Pump_CamshaftOilTotalNO2 + " / " + obj.Pump_CamshaftOilDisintegrationNO2, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(11, 30, obj.Pump_BoilerTotal + " / " + obj.Pump_BoilerDisintegration, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(11, 31, obj.Pump_GeneralToatl + " / " + obj.Pump_GeneralDisintegration, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(11, 32, obj.Pump_FireTotal + " / " + obj.Pump_FireDisintegration, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(12, 33, obj.Pump_FuelCircleTotalNO1 + " / " + obj.Pump_FuelCircleDisintegratinNO1, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(12, 34, obj.Pump_FuelCircleTotalNO2 + " / " + obj.Pump_FuelCircleDisintegratinNO2, XlHorizontalAlignment.xlCenter);

            excel.SetSingelCellValue(12, 35, obj.Pump_FuelPressureTotalNO1 + " / " + obj.Pump_FuelPressureDisintegrationNO1, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(12, 36, obj.Pump_FuelPressureTotalNO2 + " / " + obj.Pump_FuelPressureDisintegrationNO2, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(12, 37, obj.Pump_HeavyOilTotalNO1 + " / " + obj.Pump_HeavyOilDisintegrationNO1, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(12, 38, obj.Pump_HeavyOilTotalNO2 + " / " + obj.Pump_HeavyOilDisintegrationNO2, XlHorizontalAlignment.xlCenter);

            excel.SetSingelCellValue(11, 39, obj.Pump_DieselFuelTotal + " / " + obj.Pump_DieselFuelDisintegration, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(12, 40, obj.Pump_OilTotalNO1 + " / " + obj.Pump_OilDisintegrationNO1, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(12, 41, obj.Pump_OilTotalNO2 + " / " + obj.Pump_OilDisintegrationNO2, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(12, 42, obj.Pump_BallastTotalNO1 + " / " + obj.Pump_BallastDisintegrationNO1, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(12, 43, obj.Pump_BallastTotalNO2 + " / " + obj.Pump_BallastDisintegrationNO2, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(11, 44, obj.Pump_EmergencyTotal + " / " + obj.Pump_EmergencyDisintegration, XlHorizontalAlignment.xlCenter);

            //附记.
            excel.SetSingelCellValue(1, 33, "附记： " + obj.Gas_Remarks, XlHorizontalAlignment.xlLeft);
            //轮机长签字.
            excel.SetSingelCellValue(1, 44, "轮机长：(签字)     " + obj.ChiefSign, XlHorizontalAlignment.xlLeft);
            
            excel.SaveDocument(path2);
            excel.CloseDocument();
            Excel.release(excel.pt);

            File.Copy(path2, path);
            ourFile ofile;

            if (!BaseInfo.DataAccess.WorkModelTypeService.Instance.SetReport(CommonOperation.Enum.FileBoundingTypes.MEASUREREPORT, true, "机舱主要设备运行时间统计", obj.File_ID,
                obj.Cabin_StatisticsDate, CommonOperation.ConstParameter.UserName, obj.SHIP_ID, model.ModelFile, f.FullName, out ofile, out err))
            {
                return false;
            }
            else
            {
                openFile opf = new openFile();
                opf.FileOpen(ofile, right.U);
            }
            return true;
        }
    }
}