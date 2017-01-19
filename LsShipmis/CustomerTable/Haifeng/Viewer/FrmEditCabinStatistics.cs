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

using CustomerTable.Haifeng.DataObject;
using CustomerTable.Haifeng.Services;

namespace CustomTable.Haifeng.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    /// 
    public partial class FrmEditCabinStatistics : CommonViewer.BaseForm.FormBase
    {

        #region 窗体对象
        bool editFlag = false;
        //存储格式为yyyy.MM
        string fileDateMonth;
        //船舶ID
        string shipID;
        ReportMajorEquipment nowObject = new ReportMajorEquipment();
        public ReportMajorEquipment NowObject
        {
            get { return nowObject; }
            set
            {
                if (null == value)
                {
                    return;
                }
                nowObject = value;
                showObject();
            }
        }

        #endregion

        #region 其它公共业务类

        private FormControlOption other = FormControlOption.Instance;
        Dictionary<string, string> discRate = new Dictionary<string, string>();

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmEditCabinStatistics()
        {
            InitializeComponent();
        }

        public FrmEditCabinStatistics(string shipid, ReportMajorEquipment nowObject)
        {
            InitializeComponent();

            if (nowObject != null)
            {
                NowObject = nowObject;
                editFlag = true;

                this.dtpTableWrited.Enabled = false;
            }
            
            shipID = shipid;
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

        public void FormToObject(out string err)
        {
            err = "";

            if (nowObject != null)
            {
                nowObject.Pump_BallastDisintegrationNO1 = this.txtBallastPDNO1.Text;
                nowObject.Pump_BallastDisintegrationNO2 = this.txtBallastPDNO2.Text;
                nowObject.Pump_BallastTotalNO1 = this.txtBallastPTNO1.Text;
                nowObject.Pump_BallastTotalNO2 = this.txtBallastPTNO2.Text;
                nowObject.Pump_CamshaftOilDisintegrationNO1 = this.txtBearOilPDNO1.Text;
                nowObject.Pump_CamshaftOilDisintegrationNO2 = this.txtBearOilPDNO2.Text;
                nowObject.Pump_CamshaftOilTotalNO1 = this.txtBearOilPTNO1.Text;
                nowObject.Pump_CamshaftOilTotalNO2 = this.txtBearOilPTNO2.Text;
                nowObject.Pump_BoilerDisintegration = this.txtBoilerPD.Text;
                nowObject.Pump_BoilerTotal = this.txtBoilerPT.Text;
                nowObject.ChiefSign = this.txtChiefSign.Text;
                nowObject.Host_ConnectRodBearNO1 = this.txtConnectBearNO1.Text;
                nowObject.Host_ConnectRodBearNO2 = this.txtConnectBearNO2.Text;
                nowObject.Host_ConnectRodBearNO3 = this.txtConnectBearNO3.Text;
                nowObject.Host_ConnectRodBearNO4 = this.txtConnectBearNO4.Text;
                nowObject.Host_ConnectRodBearNO5 = this.txtConnectBearNO5.Text;
                nowObject.Host_ConnectRodBearNO6 = this.txtConnectBearNO6.Text;
                nowObject.Host_ConnectRodBearNO7 = this.txtConnectBearNO7.Text;
                nowObject.Host_ConnectRodBearNO8 = this.txtConnectBearNO8.Text;
                nowObject.Host_ConnectRodBearNO9 = this.txtConnectBearNO9.Text;
                nowObject.Gas_AirCoolerNO1 = this.txtCoolerNO1.Text;
                nowObject.Gas_AirCoolerNO2 = this.txtCoolerNO2.Text;
                nowObject.Host_CrossheadBearNO1 = this.txtCrossBearNO1.Text;
                nowObject.Host_CrossheadBearNO2 = this.txtCrossBearNO2.Text;
                nowObject.Host_CrossheadBearNO3 = this.txtCrossBearNO3.Text;
                nowObject.Host_CrossheadBearNO4 = this.txtCrossBearNO4.Text;
                nowObject.Host_CrossheadBearNO5 = this.txtCrossBearNO5.Text;
                nowObject.Host_CrossheadBearNO6 = this.txtCrossBearNO6.Text;
                nowObject.Host_CrossheadBearNO7 = this.txtCrossBearNO7.Text;
                nowObject.Host_CrossheadBearNO8 = this.txtCrossBearNO8.Text;
                nowObject.Host_CrossheadBearNO9 = this.txtCrossBearNO9.Text;
                nowObject.Pump_CylinderDisintegrationNO1 = this.txtCylinderWaterPDNO1.Text;
                nowObject.Pump_CylinderDisintegrationNO2 = this.txtCylinderWaterPDNO2.Text;
                nowObject.Pump_CylinderTotalNO1 = this.txtCylinderWaterPTNO1.Text;
                nowObject.Pump_CylinderTotalNO2 = this.txtCylinderWaterPTNO2.Text;
                nowObject.Pump_DieselFuelDisintegration = this.txtDieselPD.Text;
                nowObject.Pump_DieselFuelTotal = this.txtDieselPT.Text;
                nowObject.Pump_EmergencyDisintegration = this.txtEmergencyPD.Text;
                nowObject.Pump_EmergencyTotal = this.txtEmergencyPT.Text;
                nowObject.Host_ExhaustExchangeNO1 = this.txtExhaustNO1.Text;
                nowObject.Host_ExhaustExchangeNO2 = this.txtExhaustNO2.Text;
                nowObject.Host_ExhaustExchangeNO3 = this.txtExhaustNO3.Text;
                nowObject.Host_ExhaustExchangeNO4 = this.txtExhaustNO4.Text;
                nowObject.Host_ExhaustExchangeNO5 = this.txtExhaustNO5.Text;
                nowObject.Host_ExhaustExchangeNO6 = this.txtExhaustNO6.Text;
                nowObject.Host_ExhaustExchangeNO7 = this.txtExhaustNO7.Text;
                nowObject.Host_ExhaustExchangeNO8 = this.txtExhaustNO8.Text;
                nowObject.Host_ExhaustExchangeNO9 = this.txtExhaustNO9.Text;
                nowObject.Pump_FireDisintegration = this.txtFirePD.Text;
                nowObject.Pump_FireTotal = this.txtFirePT.Text;

                nowObject.Pump_FuelCircleDisintegratinNO1 = this.txtFuelCirclePDNO1.Text;
                nowObject.Pump_FuelCircleDisintegratinNO2 = this.txtFuelCirclePDNO2.Text;
                nowObject.Pump_FuelCircleTotalNO1 = this.txtFuelCirclePTNO1.Text;
                nowObject.Pump_FuelCircleTotalNO2 = this.txtFuelCirclePTNO2.Text;
                nowObject.Pump_GeneralDisintegration = this.txtGeneralPD.Text;
                nowObject.Pump_GeneralToatl = this.txtGeneralPT.Text;
                nowObject.Gas_ACliftingCylinderNO1 = this.txtHAirLiftingCylinderNO1.Text;
                nowObject.Gas_ACliftingCylinderNO2 = this.txtHAirLiftingCylinderNO2.Text;
                nowObject.Gas_ACliftingCylinderNO3 = this.txtHAirLiftingCylinderNO3.Text;
                nowObject.Gas_ACTotalNO1 = this.txtHAirTNO1.Text;
                nowObject.Gas_ACTotalNO2 = this.txtHAirTNO2.Text;
                nowObject.Gas_ACTotalNO3 = this.txtHAirTNO3.Text;
                nowObject.Host_CylinderRenewalNO1 = this.txthCylinerRenewNO1.Text;
                nowObject.Host_CylinderRenewalNO2 = this.txthCylinerRenewNO2.Text;
                nowObject.Host_CylinderRenewalNO3 = this.txthCylinerRenewNO3.Text;
                nowObject.Host_CylinderRenewalNO4 = this.txthCylinerRenewNO4.Text;
                nowObject.Host_CylinderRenewalNO5 = this.txthCylinerRenewNO5.Text;
                nowObject.Host_CylinderRenewalNO6 = this.txthCylinerRenewNO6.Text;
                nowObject.Host_CylinderRenewalNO7 = this.txthCylinerRenewNO7.Text;
                nowObject.Host_CylinderRenewalNO8 = this.txthCylinerRenewNO8.Text;
                nowObject.Host_CylinderRenewalNO9 = this.txthCylinerRenewNO9.Text;
                nowObject.Pump_HeavyOilDisintegrationNO1 = this.txtHeavyOilPDNO1.Text;

                nowObject.Pump_HeavyOilDisintegrationNO2 = this.txtHeavyOilPDNO2.Text;
                nowObject.Pump_HeavyOilTotalNO1 = this.txtHeavyOilPTNO1.Text;
                nowObject.Pump_HeavyOilTotalNO2 = this.txtHeavyOilPTNO2.Text;
                nowObject.Host_MajorBearNO1 = this.txthMajorBearNO1.Text;
                nowObject.Host_MajorBearNO2 = this.txthMajorBearNO2.Text;
                nowObject.Host_MajorBearNO3 = this.txthMajorBearNO3.Text;
                nowObject.Host_MajorBearNO4 = this.txthMajorBearNO4.Text;
                nowObject.Host_MajorBearNO5 = this.txthMajorBearNO5.Text;
                nowObject.Host_MajorBearNO6 = this.txthMajorBearNO6.Text;
                nowObject.Host_MajorBearNO7 = this.txthMajorBearNO7.Text;
                nowObject.Host_MajorBearNO8 = this.txthMajorBearNO8.Text;
                nowObject.Host_MajorBearNO9 = this.txthMajorBearNO9.Text;
                nowObject.Host_HighPreesurePumpNO1 = this.txthPressureOilBearNO1.Text;
                nowObject.Host_HighPreesurePumpNO2 = this.txthPressureOilBearNO2.Text;
                nowObject.Host_HighPreesurePumpNO3 = this.txthPressureOilBearNO3.Text;
                nowObject.Host_HighPreesurePumpNO4 = this.txthPressureOilBearNO4.Text;
                nowObject.Host_HighPreesurePumpNO5 = this.txthPressureOilBearNO5.Text;
                nowObject.Host_HighPreesurePumpNO6 = this.txthPressureOilBearNO6.Text;
                nowObject.Host_HighPreesurePumpNO7 = this.txthPressureOilBearNO7.Text;
                nowObject.Host_HighPreesurePumpNO8 = this.txthPressureOilBearNO8.Text;
                nowObject.Host_HighPreesurePumpNO9 = this.txthPressureOilBearNO9.Text;
                nowObject.Host_LiftingCylinderNO1 = this.txtLiftingCylinderNO1.Text;
                nowObject.Host_LiftingCylinderNO2 = this.txtLiftingCylinderNO13.Text;
                nowObject.Host_LiftingCylinderNO3 = this.txtLiftingCylinderNO2.Text;
                nowObject.Host_LiftingCylinderNO4 = this.txtLiftingCylinderNO4.Text;
                nowObject.Host_LiftingCylinderNO5 = this.txtLiftingCylinderNO5.Text;
                nowObject.Host_LiftingCylinderNO6 = this.txtLiftingCylinderNO6.Text;
                nowObject.Host_LiftingCylinderNO7 = this.txtLiftingCylinderNO7.Text;
                nowObject.Host_LiftingCylinderNO8 = this.txtLiftingCylinderNO8.Text;
                nowObject.Host_LiftingCylinderNO9 = this.txtLiftingCylinderNO9.Text;
                nowObject.Pump_LowTemDisintegrationNO1 = this.txtLowTemWaterPDNO1.Text;
                nowObject.Pump_LowTemDisintegrationNO2 = this.txtLowTemWaterPDNO2.Text;
                nowObject.Pump_LowTemTotalNO1 = this.txtLowTemWaterPTNO1.Text;
                nowObject.Pump_LowTemTotalNO2 = this.txtLowTemWaterPTNO2.Text;

                nowObject.Gas_SMajorBearNO1 = this.txtMainBearNO1.Text;
                nowObject.Gas_SMajorBearNO2 = this.txtMainBearNO2.Text;
                nowObject.Gas_SMajorBearNO3 = this.txtMainBearNO3.Text;
                nowObject.Pump_MainOilDisintegrationNO1 = this.txtMainOilPDNO1.Text;
                nowObject.Pump_MainOilDisintegrationNO2 = this.txtMainOilPDNO2.Text;
                nowObject.Pump_MainOilTotalNO1 = this.txtMainOilPTNO1.Text;
                nowObject.Pump_MainOilTotalNO2 = this.txtMainOilPTNO2.Text;
                nowObject.Pump_MainSeaDisintegrationNO1 = this.txtMainSeaWaterPDNO1.Text;
                nowObject.Pump_MainSeaDisintegrationNO2 = this.txtMainSeaWaterPDNO2.Text;
                nowObject.Pump_MainSeaTotalNO1 = this.txtMainSeaWaterPTNO1.Text;
                nowObject.Pump_MainSeaTotalNO2 = this.txtMainSeaWaterPTNO2.Text;

                nowObject.Gas_MarblePanelNO1 = this.txtMarbleNO1.Text;
                nowObject.Gas_MarblePanelNO2 = this.txtMarbleNO2.Text;
                nowObject.Pump_OilDisintegrationNO1 = this.txtOilDividePDNO1.Text;
                nowObject.Pump_OilDisintegrationNO2 = this.txtOilDividePDNO2.Text;
                nowObject.Pump_OilTotalNO1 = this.txtOilDividePTNO1.Text;
                nowObject.Pump_OilTotalNO2 = this.txtOilDividePTNO2.Text;

                nowObject.Host_OilHeadCheckNO1 = this.txtOilHeadNO1.Text;
                nowObject.Host_OilHeadCheckNO2 = this.txtOilHeadNO2.Text;
                nowObject.Host_OilHeadCheckNO3 = this.txtOilHeadNO3.Text;
                nowObject.Host_OilHeadCheckNO4 = this.txtOilHeadNO4.Text;
                nowObject.Host_OilHeadCheckNO5 = this.txtOilHeadNO5.Text;
                nowObject.Host_OilHeadCheckNO6 = this.txtOilHeadNO6.Text;
                nowObject.Host_OilHeadCheckNO7 = this.txtOilHeadNO7.Text;
                nowObject.Host_OilHeadCheckNO8 = this.txtOilHeadNO8.Text;
                nowObject.Host_OilHeadCheckNO9 = this.txtOilHeadNO9.Text;

                nowObject.Pump_ParkLowTemDisintegration = this.txtParkLowWaterPD.Text;
                nowObject.Pump_ParkLowTemTotal = this.txtParkLowWaterPT.Text;
                nowObject.Gas_DismantNO1 = this.txtPreCheckNO1.Text;
                nowObject.Gas_DismantNO2 = this.txtPreCheckNO2.Text;
                nowObject.Pump_FuelPressureDisintegrationNO1 = this.txtPressureFuelPDNO1.Text;
                nowObject.Pump_FuelPressureDisintegrationNO2 = this.txtPressureFuelPDNO2.Text;
                nowObject.Pump_FuelPressureTotalNO1 = this.txtPressureFuelPTNO1.Text;
                nowObject.Pump_FuelPressureTotalNO2 = this.txtPressureFuelPTNO2.Text;
                nowObject.Gas_Remarks = this.txtRemarks.Text;
                nowObject.Gas_PPCheckNO1 = this.txtRudderCheckNO1.Text;
                nowObject.Gas_PPCheckNO2 = this.txtRudderCheckNO2.Text;
                nowObject.Gas_PPTotalNO1 = this.txtRudderNO1.Text;
                nowObject.Gas_PPTotalNO2 = this.txtRudderNO2.Text;
                nowObject.Pump_SecondSeaDisintegration = this.txtSecondSeaWaterPD.Text;
                nowObject.Pump_SecondSeaTotal = this.txtSecondSeaWaterPT.Text;
                nowObject.Gas_SExhaustExchangeNO1 = this.txtSExhaustNO1.Text;
                nowObject.Gas_SExhaustExchangeNO2 = this.txtSExhaustNO2.Text;
                nowObject.Gas_SExhaustExchangeNO3 = this.txtSExhaustNO3.Text;
                nowObject.Gas_SOilHeadNO1 = this.txtSOilHeaderNO1.Text;
                nowObject.Gas_SOilHeadNO2 = this.txtSOilHeaderNO2.Text;
                nowObject.Gas_SOilHeadNO3 = this.txtSOilHeaderNO3.Text;
                nowObject.Gas_STurbochargerNO1 = this.txtSPressureNO1.Text;
                nowObject.Gas_STurbochargerNO2 = this.txtSPressureNO2.Text;
                nowObject.Gas_STurbochargerNO3 = this.txtSPressureNO3.Text;
                nowObject.Gas_SLiftingCylinderNO1 = this.txtSTLiftCylinderNO1.Text;
                nowObject.Gas_SLiftingCylinderNO2 = this.txtSTLiftCylinderNO2.Text;
                nowObject.Gas_SLiftingCylinderNO3 = this.txtSTLiftCylinderNO3.Text;
                nowObject.Gas_STotalNO1 = this.txtSTNO1.Text;
                nowObject.Gas_STotalNO2 = this.txtSTNO2.Text;
                nowObject.Gas_STotalNO3 = this.txtSTNO3.Text;
                nowObject.Cabin_HostTotal = this.txtTotalTime.Text;
                nowObject.Voyage = this.txtVoyage.Text;
                nowObject.Cabin_StatisticsDate = this.dtpTableWrited.Value;

                fileDateMonth = this.dtpTableWrited.Value.ToString("yyyy.MM");

                nowObject.SHIP_ID = shipID;
                if(nowObject.File_ID == null)
                {
                    nowObject.File_ID = Guid.NewGuid().ToString();
                }
            }
        }

        /// <summary>
        /// 保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            string err = "";
            bool returnValue;

            if (!check(out err))
            {
                MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err);
                return;
            }

            this.FormToObject(out err);      //从界面获取数据到对象中.

            if(!editFlag)
            {
                //检查数据库是否已存在此条记录.
                if (ReportMajorEquipmentService.Instance.CheckSubDetail(fileDateMonth, shipID))
                {
                    MessageBoxEx.Show("已经存在此月的统计信息,请查看日期选择是否正确");
                    return;
                }
            }

            returnValue = ReportMajorEquipmentService.Instance.saveUnit(nowObject,out err);

            if (returnValue)
            {
                MessageBoxEx.Show("保存成功!", "", new MessageBoxButtons(), MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err);
                return;
            }
        }

        private bool check(out string err)
        {
            err = "";

            if (this.txtVoyage.Text.Length == 0)
            {
                err = "航次内容为空";
                return false;
            }
            return true;
        }

        private void showObject()
        {
            if (nowObject != null)
            {
                this.txtBallastPDNO1.Text = nowObject.Pump_BallastDisintegrationNO1;
                this.txtBallastPDNO2.Text = nowObject.Pump_BallastDisintegrationNO2;
                this.txtBallastPTNO1.Text = nowObject.Pump_BallastTotalNO1;
                this.txtBallastPTNO2.Text = nowObject.Pump_BallastTotalNO2;
                this.txtBearOilPDNO1.Text = nowObject.Pump_CamshaftOilDisintegrationNO1;
                this.txtBearOilPDNO2.Text = nowObject.Pump_CamshaftOilDisintegrationNO2;
                this.txtBearOilPTNO1.Text = nowObject.Pump_CamshaftOilTotalNO1;
                this.txtBearOilPTNO2.Text = nowObject.Pump_CamshaftOilTotalNO2;
                this.txtBoilerPD.Text = nowObject.Pump_BoilerDisintegration;
                this.txtBoilerPT.Text = nowObject.Pump_BoilerTotal;
                this.txtChiefSign.Text = nowObject.ChiefSign;
                this.txtConnectBearNO1.Text = nowObject.Host_ConnectRodBearNO1;
                this.txtConnectBearNO2.Text = nowObject.Host_ConnectRodBearNO2;
                this.txtConnectBearNO3.Text = nowObject.Host_ConnectRodBearNO3;
                this.txtConnectBearNO4.Text = nowObject.Host_ConnectRodBearNO4;
                this.txtConnectBearNO5.Text = nowObject.Host_ConnectRodBearNO5;
                this.txtConnectBearNO6.Text = nowObject.Host_ConnectRodBearNO6;
                this.txtConnectBearNO7.Text = nowObject.Host_ConnectRodBearNO7;
                this.txtConnectBearNO8.Text = nowObject.Host_ConnectRodBearNO8;
                this.txtConnectBearNO9.Text = nowObject.Host_ConnectRodBearNO9;
                this.txtCoolerNO1.Text = nowObject.Gas_AirCoolerNO1;
                this.txtCoolerNO2.Text = nowObject.Gas_AirCoolerNO2;
                this.txtCrossBearNO1.Text = nowObject.Host_CrossheadBearNO1;
                this.txtCrossBearNO2.Text = nowObject.Host_CrossheadBearNO2;
                this.txtCrossBearNO3.Text = nowObject.Host_CrossheadBearNO3;
                this.txtCrossBearNO4.Text = nowObject.Host_CrossheadBearNO4;
                this.txtCrossBearNO5.Text = nowObject.Host_CrossheadBearNO5;
                this.txtCrossBearNO6.Text = nowObject.Host_CrossheadBearNO6;
                this.txtCrossBearNO7.Text = nowObject.Host_CrossheadBearNO7;
                this.txtCrossBearNO8.Text = nowObject.Host_CrossheadBearNO8;
                this.txtCrossBearNO9.Text = nowObject.Host_ConnectRodBearNO9;
                this.txtCylinderWaterPDNO1.Text = nowObject.Pump_CylinderDisintegrationNO1;
                this.txtCylinderWaterPDNO2.Text = nowObject.Pump_CylinderDisintegrationNO2;
                this.txtCylinderWaterPTNO1.Text = nowObject.Pump_CylinderTotalNO1;
                this.txtCylinderWaterPTNO2.Text = nowObject.Pump_CylinderTotalNO2;
                this.txtDieselPD.Text = nowObject.Pump_DieselFuelDisintegration;
                this.txtDieselPT.Text = nowObject.Pump_DieselFuelTotal;
                this.txtEmergencyPD.Text = nowObject.Pump_EmergencyDisintegration;
                this.txtEmergencyPT.Text = nowObject.Pump_EmergencyTotal;
                this.txtExhaustNO1.Text = nowObject.Host_ExhaustExchangeNO1;
                this.txtExhaustNO2.Text = nowObject.Host_ExhaustExchangeNO2;
                this.txtExhaustNO3.Text = nowObject.Host_ExhaustExchangeNO3;
                this.txtExhaustNO4.Text = nowObject.Host_ExhaustExchangeNO4;
                this.txtExhaustNO5.Text = nowObject.Host_ExhaustExchangeNO5;
                this.txtExhaustNO6.Text = nowObject.Host_ExhaustExchangeNO6;
                this.txtExhaustNO7.Text = nowObject.Host_ExhaustExchangeNO7;
                this.txtExhaustNO8.Text = nowObject.Host_ExhaustExchangeNO8;
                this.txtExhaustNO9.Text = nowObject.Host_ExhaustExchangeNO9;
                this.txtFirePD.Text = nowObject.Pump_FireDisintegration;
                this.txtFirePT.Text = nowObject.Pump_FireTotal;

                this.txtFuelCirclePDNO1.Text = nowObject.Pump_FuelCircleDisintegratinNO1;
                this.txtFuelCirclePDNO2.Text = nowObject.Pump_FuelCircleDisintegratinNO2;
                this.txtFuelCirclePTNO1.Text = nowObject.Pump_FuelCircleTotalNO1;
                this.txtFuelCirclePTNO2.Text = nowObject.Pump_FuelCircleTotalNO2;
                this.txtGeneralPD.Text = nowObject.Pump_GeneralDisintegration;
                this.txtGeneralPT.Text = nowObject.Pump_GeneralToatl;
                this.txtHAirLiftingCylinderNO1.Text = nowObject.Gas_ACliftingCylinderNO1;
                this.txtHAirLiftingCylinderNO2.Text = nowObject.Gas_ACliftingCylinderNO2;
                this.txtHAirLiftingCylinderNO3.Text = nowObject.Gas_ACliftingCylinderNO3;
                this.txtHAirTNO1.Text = nowObject.Gas_ACTotalNO1;
                this.txtHAirTNO2.Text = nowObject.Gas_ACTotalNO2;
                this.txtHAirTNO3.Text = nowObject.Gas_ACTotalNO3;
                this.txthCylinerRenewNO1.Text = nowObject.Host_CylinderRenewalNO1;
                this.txthCylinerRenewNO2.Text = nowObject.Host_CylinderRenewalNO2;
                this.txthCylinerRenewNO3.Text = nowObject.Host_CylinderRenewalNO3;
                this.txthCylinerRenewNO4.Text = nowObject.Host_CylinderRenewalNO4;
                this.txthCylinerRenewNO5.Text = nowObject.Host_CylinderRenewalNO5;
                this.txthCylinerRenewNO6.Text = nowObject.Host_CylinderRenewalNO6;
                this.txthCylinerRenewNO7.Text = nowObject.Host_CylinderRenewalNO7;
                this.txthCylinerRenewNO8.Text = nowObject.Host_CylinderRenewalNO8;
                this.txthCylinerRenewNO9.Text = nowObject.Host_CylinderRenewalNO9;
                this.txtHeavyOilPDNO1.Text = nowObject.Pump_HeavyOilDisintegrationNO1;

                this.txtHeavyOilPDNO2.Text = nowObject.Pump_HeavyOilDisintegrationNO2;
                this.txtHeavyOilPTNO1.Text = nowObject.Pump_HeavyOilTotalNO1;
                this.txtHeavyOilPTNO2.Text = nowObject.Pump_HeavyOilTotalNO2;
                this.txthMajorBearNO1.Text = nowObject.Host_MajorBearNO1;
                this.txthMajorBearNO2.Text = nowObject.Host_MajorBearNO2;
                this.txthMajorBearNO3.Text = nowObject.Host_MajorBearNO3;
                this.txthMajorBearNO4.Text = nowObject.Host_MajorBearNO4;
                this.txthMajorBearNO5.Text = nowObject.Host_MajorBearNO5;
                this.txthMajorBearNO6.Text = nowObject.Host_MajorBearNO6;
                this.txthMajorBearNO7.Text = nowObject.Host_MajorBearNO7;
                this.txthMajorBearNO8.Text = nowObject.Host_MajorBearNO8;
                this.txthMajorBearNO9.Text = nowObject.Host_MajorBearNO9;
                this.txthPressureOilBearNO1.Text = nowObject.Host_HighPreesurePumpNO1;
                this.txthPressureOilBearNO2.Text = nowObject.Host_HighPreesurePumpNO2;
                this.txthPressureOilBearNO3.Text = nowObject.Host_HighPreesurePumpNO3;
                this.txthPressureOilBearNO4.Text = nowObject.Host_HighPreesurePumpNO4;
                this.txthPressureOilBearNO5.Text = nowObject.Host_HighPreesurePumpNO5;
                this.txthPressureOilBearNO6.Text = nowObject.Host_HighPreesurePumpNO6;
                this.txthPressureOilBearNO7.Text = nowObject.Host_HighPreesurePumpNO7;
                this.txthPressureOilBearNO8.Text = nowObject.Host_HighPreesurePumpNO8;
                this.txthPressureOilBearNO9.Text = nowObject.Host_HighPreesurePumpNO9;
                this.txtLiftingCylinderNO1.Text = nowObject.Host_LiftingCylinderNO1;
                this.txtLiftingCylinderNO13.Text = nowObject.Host_LiftingCylinderNO2;
                this.txtLiftingCylinderNO2.Text = nowObject.Host_LiftingCylinderNO3;
                this.txtLiftingCylinderNO4.Text = nowObject.Host_LiftingCylinderNO4;
                this.txtLiftingCylinderNO5.Text = nowObject.Host_LiftingCylinderNO5;
                this.txtLiftingCylinderNO6.Text = nowObject.Host_LiftingCylinderNO6;
                this.txtLiftingCylinderNO7.Text = nowObject.Host_LiftingCylinderNO7;
                this.txtLiftingCylinderNO8.Text = nowObject.Host_LiftingCylinderNO8;
                this.txtLiftingCylinderNO9.Text = nowObject.Host_LiftingCylinderNO9;
                this.txtLowTemWaterPDNO1.Text = nowObject.Pump_LowTemDisintegrationNO1;
                this.txtLowTemWaterPDNO2.Text = nowObject.Pump_LowTemDisintegrationNO2;
                this.txtLowTemWaterPTNO1.Text = nowObject.Pump_LowTemTotalNO1;
                this.txtLowTemWaterPTNO2.Text = nowObject.Pump_LowTemTotalNO2;

                this.txtMainBearNO1.Text = nowObject.Gas_SMajorBearNO1;
                this.txtMainBearNO2.Text = nowObject.Gas_SMajorBearNO2;
                this.txtMainBearNO3.Text = nowObject.Gas_SMajorBearNO3;
                this.txtMainOilPDNO1.Text = nowObject.Pump_MainOilDisintegrationNO1;
                this.txtMainOilPDNO2.Text = nowObject.Pump_MainOilDisintegrationNO2;
                this.txtMainOilPTNO1.Text = nowObject.Pump_MainOilTotalNO1;
                this.txtMainOilPTNO2.Text = nowObject.Pump_MainOilTotalNO2;
                this.txtMainSeaWaterPDNO1.Text = nowObject.Pump_MainSeaDisintegrationNO1;
                this.txtMainSeaWaterPDNO2.Text = nowObject.Pump_MainSeaDisintegrationNO2;
                this.txtMainSeaWaterPTNO1.Text = nowObject.Pump_MainSeaTotalNO1;
                this.txtMainSeaWaterPTNO2.Text = nowObject.Pump_MainSeaTotalNO2;

                this.txtMarbleNO1.Text = nowObject.Gas_MarblePanelNO1;
                this.txtMarbleNO2.Text = nowObject.Gas_MarblePanelNO2;
                this.txtOilDividePDNO1.Text = nowObject.Pump_OilDisintegrationNO1;
                this.txtOilDividePDNO2.Text = nowObject.Pump_OilDisintegrationNO2;
                this.txtOilDividePTNO1.Text = nowObject.Pump_OilTotalNO1;
                this.txtOilDividePTNO2.Text = nowObject.Pump_OilTotalNO2;

                this.txtOilHeadNO1.Text = nowObject.Host_OilHeadCheckNO1;
                this.txtOilHeadNO2.Text = nowObject.Host_OilHeadCheckNO2;
                this.txtOilHeadNO3.Text = nowObject.Host_OilHeadCheckNO3;
                this.txtOilHeadNO4.Text = nowObject.Host_OilHeadCheckNO4;
                this.txtOilHeadNO5.Text = nowObject.Host_OilHeadCheckNO5;
                this.txtOilHeadNO6.Text = nowObject.Host_OilHeadCheckNO6;
                this.txtOilHeadNO7.Text = nowObject.Host_OilHeadCheckNO7;
                this.txtOilHeadNO8.Text = nowObject.Host_OilHeadCheckNO8;
                this.txtOilHeadNO9.Text = nowObject.Host_OilHeadCheckNO9;

                this.txtParkLowWaterPD.Text = nowObject.Pump_ParkLowTemDisintegration;
                this.txtParkLowWaterPT.Text = nowObject.Pump_ParkLowTemTotal;
                this.txtPreCheckNO1.Text = nowObject.Gas_DismantNO1;
                this.txtPreCheckNO2.Text = nowObject.Gas_DismantNO2;
                this.txtPressureFuelPDNO1.Text = nowObject.Pump_FuelPressureDisintegrationNO1;
                this.txtPressureFuelPDNO2.Text = nowObject.Pump_FuelPressureDisintegrationNO2;
                this.txtPressureFuelPTNO1.Text = nowObject.Pump_FuelPressureTotalNO1;
                this.txtPressureFuelPTNO2.Text = nowObject.Pump_FuelPressureTotalNO2;
                this.txtRemarks.Text = nowObject.Gas_Remarks;
                this.txtRudderCheckNO1.Text = nowObject.Gas_PPCheckNO1;
                this.txtRudderCheckNO2.Text = nowObject.Gas_PPCheckNO2;
                this.txtRudderNO1.Text = nowObject.Gas_PPTotalNO1;
                this.txtRudderNO2.Text = nowObject.Gas_PPTotalNO2;
                this.txtSecondSeaWaterPD.Text = nowObject.Pump_SecondSeaDisintegration;
                this.txtSecondSeaWaterPT.Text = nowObject.Pump_SecondSeaTotal;
                this.txtSExhaustNO1.Text = nowObject.Gas_SExhaustExchangeNO1;
                this.txtSExhaustNO2.Text = nowObject.Gas_SExhaustExchangeNO2;
                this.txtSExhaustNO3.Text = nowObject.Gas_SExhaustExchangeNO3;
                this.txtSOilHeaderNO1.Text = nowObject.Gas_SOilHeadNO1;
                this.txtSOilHeaderNO2.Text = nowObject.Gas_SOilHeadNO2;
                this.txtSOilHeaderNO3.Text = nowObject.Gas_SOilHeadNO3;
                this.txtSPressureNO1.Text = nowObject.Gas_STurbochargerNO1;
                this.txtSPressureNO2.Text = nowObject.Gas_STurbochargerNO2;
                this.txtSPressureNO3.Text = nowObject.Gas_STurbochargerNO3;
                this.txtSTLiftCylinderNO1.Text = nowObject.Gas_SLiftingCylinderNO1;
                this.txtSTLiftCylinderNO2.Text = nowObject.Gas_SLiftingCylinderNO2;
                this.txtSTLiftCylinderNO3.Text = nowObject.Gas_SLiftingCylinderNO3;
                this.txtSTNO1.Text = nowObject.Gas_STotalNO1;
                this.txtSTNO2.Text = nowObject.Gas_STotalNO2;
                this.txtSTNO3.Text = nowObject.Gas_STotalNO3;
                this.txtTotalTime.Text = nowObject.Cabin_HostTotal;
                this.txtVoyage.Text = nowObject.Voyage;
                this.dtpTableWrited.Value = nowObject.Cabin_StatisticsDate;
            }
        }
    }
}