/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：黄家龙
 * 创建时间：2011-08-25
 * 功能描述：船舶主机工况窗体
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
    public partial class FrmEditShipHost : CommonViewer.BaseForm.FormBase
    {

        #region 窗体对象
        //存储格式为yyyy.MM
        string fileDateMonth;
        //存储格式为yyyy.MM.dd
        string fileDate;
        //是否为编辑 true编辑 false新增.
        bool editFlag = false;

        string shipID;
        ReportShipHost nowObject = new ReportShipHost();
        public ReportShipHost NowObject
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
        private FrmEditShipHost()
        {
            InitializeComponent();
        }

        public FrmEditShipHost(string shipid, ReportShipHost nowObject)
        {
            InitializeComponent();

            if (nowObject != null)
            {
                NowObject = nowObject;
                editFlag = true;
            }
            else
            {
                this.AddDetailButton.Visible = false;
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

        /// <summary>
        /// 增加日详细信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddDetailButton_Click(object sender, EventArgs e)
        {
            //编辑为true  新增为false
            this.editFlag = false;

            //主机参数摘录明细信息.
            this.dtpItemDate.Value = DateTime.Now;
            this.txthSpeed.Text = "";
            this.txthLoad.Text = "";
            this.txtSmokeHighTem.Text = "";
            this.txtSmokehignliner.Text = "";
            this.txtSmokeLowTem.Text = "";
            this.txtSmokeLowNO.Text = "";
            this.txtLinerIn.Text = "";
            this.txtLinerOut.Text = "";
            this.txtPostionIn.Text = "";
            this.txtPostionOut.Text = "";
            this.txtBeforeNo1.Text = "";
            this.txtBeforeNo2.Text = "";
            this.txtBeforeNo3.Text = "";
            this.txtAfterNO1.Text = "";
            this.txtAfterNO2.Text = "";
            this.txtAfterNO3.Text = "";
            this.txtTurbeTem.Text = "";
            this.txtCabinTem.Text = "";
            this.txtSeaArea.Text = "";
            this.txtCoolHighTem.Text = "";
            this.txtCoolLowTem.Text = "";
            this.txtMainBear.Text = "";
            this.txtCross.Text = "";
            this.txtPressAir.Text = "";
            this.txtFuelInto.Text = "";
            this.txtActualSpeed.Text = "";
            this.txtSlipRate.Text = "";
            this.txtTurboChargerNO1.Text = "";
            this.txtTurboChargerNO2.Text = "";
        }

        public void FormToObject(out string err)
        {
            err = "";

            if (nowObject != null)
            {
                nowObject.Voyage = this.txtVoyage.Text;
                nowObject.Host_ParaAbstractedDate = this.dtpAbstractDate.Value;
                nowObject.TableWritedDate = this.dtpTableWrited.Value;
                nowObject.HH_ChiefSign = this.txtChiefSign.Text;
                nowObject.HH_ChiefSignDate = this.dtpChiefSignDate.Value;
                nowObject.HH_DirectorSign = this.txtDirectorSign.Text;
                nowObject.HH_DirectorSignDate = this.dtpDirectorSignDate.Value;
                nowObject.HH_HighPumpNO1 = this.txtHighOil1.Text;
                nowObject.HH_HighPumpNO2 = this.txtHighOil2.Text;
                nowObject.HH_HighPumpNO3 = this.txtHighOil3.Text;
                nowObject.HH_HighPumpNO4 = this.txtHighOil4.Text;
                nowObject.HH_HighPumpNO5 = this.txtHighOil5.Text;
                nowObject.HH_HighPumpNO6 = this.txtHighOil6.Text;
                nowObject.HH_HighPumpNO7 = this.txtHighOil7.Text;
                nowObject.HH_HighPumpNO8 = this.txtHighOil8.Text;
                nowObject.HH_HighPumpAverage = this.txtHighOilAverage.Text;
                nowObject.HH_VITNO1 = this.txtVIT1.Text;
                nowObject.HH_VITNO2 = this.txtVIT2.Text;
                nowObject.HH_VITNO3 = this.txtVIT3.Text;
                nowObject.HH_VITNO4 = this.txtVIT4.Text;
                nowObject.HH_VITNO5 = this.txtVIT5.Text;
                nowObject.HH_VITNO6 = this.txtVIT6.Text;
                nowObject.HH_VITNO7 = this.txtVIT7.Text;
                nowObject.HH_VITNO8 = this.txtVIT8.Text;
                nowObject.HH_VITAverage = this.txtVITAverage.Text;
                nowObject.HH_SmokeTemNO1 = this.txtSmoke1.Text;
                nowObject.HH_SmokeTemNO2 = this.txtSmoke2.Text;
                nowObject.HH_SmokeTemNO3 = this.txtSmoke3.Text;
                nowObject.HH_SmokeTemNO4 = this.txtSmoke4.Text;
                nowObject.HH_SmokeTemNO5 = this.txtSmoke5.Text;
                nowObject.HH_SmokeTemNO6 = this.txtSmoke6.Text;
                nowObject.HH_SmokeTemNO7 = this.txtSmoke7.Text;
                nowObject.HH_SmokeTemNO8 = this.txtSmoke8.Text;
                nowObject.HH_SmokeTemAverage = this.txtSmokeAverage.Text;
                nowObject.HH_CompressionPressNO1 = this.txtCopress1.Text;
                nowObject.HH_CompressionPressNO2 = this.txtCopress2.Text;
                nowObject.HH_CompressionPressNO3 = this.txtCopress3.Text;
                nowObject.HH_CompressionPressNO4 = this.txtCopress4.Text;
                nowObject.HH_CompressionPressNO5 = this.txtCopress5.Text;
                nowObject.HH_CompressionPressNO6 = this.txtCopress6.Text;
                nowObject.HH_CompressionPressNO7 = this.txtCopress7.Text;
                nowObject.HH_CompressionPressNO8 = this.txtCopress8.Text;
                nowObject.HH_CompressionPressAverage = this.txtCopressAverage.Text;
                nowObject.HH_BoomPressNO1 = this.txtExplosion1.Text;
                nowObject.HH_BoomPressNO2 = this.txtExplosion2.Text;
                nowObject.HH_BoomPressNO3 = this.txtExplosion3.Text;
                nowObject.HH_BoomPressNO4 = this.txtExplosion4.Text;
                nowObject.HH_BoomPressNO5 = this.txtExplosion5.Text;
                nowObject.HH_BoomPressNO6 = this.txtExplosion6.Text;
                nowObject.HH_BoomPressNO7 = this.txtExplosion7.Text;
                nowObject.HH_BoomPressNO8 = this.txtExplosion8.Text;
                nowObject.HH_BoomPressAverage = this.txtExplosionAverage.Text;
                nowObject.HH_MeasureDate = this.dtpMeasureDate.Value;
                nowObject.HH_SeaArea = this.txtSeaArea.Text;
                nowObject.HH_Wind = this.txtWind.Text;
                nowObject.HH_Wave = this.txtWave.Text;
                nowObject.HH_BowDraft = this.txtBeforeWater.Text;
                nowObject.HH_PoopDraft = this.txtAfterWater.Text;
                nowObject.HH_Model = this.txtHostCatagory.Text;
                nowObject.HH_FireSequence = this.txtFireSequence.Text;
                nowObject.HH_DailyConsumption = this.txtDayConsum.Text;
                nowObject.HH_CylinderConstant = this.txtLinerConstant.Text;
                nowObject.HH_TotalKW = this.txtTotalKWS.Text;
                nowObject.HH_TotalRatedPower = this.txtRatedKW.Text;
                nowObject.HH_TotalPower = this.txtTotalKW.Text;
                nowObject.HH_Speed = this.txtSpeed.Text;
                nowObject.HH_SlipRate = this.txtSlipRate.Text;
                nowObject.HH_FuelSpecification = this.txtOilSpe.Text;
                nowObject.HH_FuelInTem = this.txtOilInTem.Text;
                nowObject.HH_FuelInViscosity = this.txtOilInV.Text;
                nowObject.HH_Load = this.txtLoad.Text;
                nowObject.HH_MaxCompressionPressDifference = this.txtCompressDiff.Text;
                nowObject.HH_MaxExhaustTempDifference = this.txtExhaustTemDiff.Text;
                nowObject.HH_DetonationPressDifference = this.txtBurstTemDiff.Text;
                nowObject.HH_Remarks = this.txtRemarks.Text;

                //主机参数摘录明细信息.
                nowObject.Host_RecordDate = this.dtpItemDate.Value;
                nowObject.Host_Speed = this.txthSpeed.Text;
                nowObject.Host_LoadInstruction = this.txthLoad.Text;
                nowObject.Host_SmokeHign_Tem = this.txtSmokeHighTem.Text;
                nowObject.Host_SmokeHign_CylinderNO = this.txtSmokehignliner.Text;
                nowObject.Host_SmokeLow_Tem = this.txtSmokeLowTem.Text;
                nowObject.Host_SmokeLow_CylinderNO = this.txtSmokeLowNO.Text;
                nowObject.Host_LinerCoolWaterIn_Tem = this.txtLinerIn.Text;
                nowObject.Host_LinerCoolWaterOut_Tem = this.txtLinerOut.Text;
                nowObject.Host_PistonCoolantIn_Tem = this.txtPostionIn.Text;
                nowObject.Host_PistonCoolanOut_Tem = this.txtPostionOut.Text;
                nowObject.Host_CoolerBeforeNO1_Tem = this.txtBeforeNo1.Text;
                nowObject.Host_CoolerBeforeNO2_Tem = this.txtBeforeNo2.Text;
                nowObject.Host_CoolerBeforeNO3_Tem = this.txtBeforeNo3.Text;
                nowObject.Host_CoolerAfterNO1_Tem = this.txtAfterNO1.Text;
                nowObject.Host_CoolerAfterNO2_Tem = this.txtAfterNO2.Text;
                nowObject.Host_CoolerAfterNO3_Tem = this.txtAfterNO3.Text;
                nowObject.Host_SternTube_Tem = this.txtTurbeTem.Text;
                nowObject.Host_Cabin_Tem = this.txtCabinTem.Text;
                nowObject.Host_SeaWater_Tem = this.txtSeaWateTem.Text;
                nowObject.Host_CoolWaterHigh_MPa = this.txtCoolHighTem.Text;
                nowObject.Host_CoolWaterLow_MPa = this.txtCoolLowTem.Text;
                nowObject.Host_OilMain_Mpa = this.txtMainBear.Text;
                nowObject.Host_OilCrosshead_Mpa = this.txtCross.Text;
                nowObject.Host_PressurizedAir_Mpa = this.txtPressAir.Text;
                nowObject.Host_FuelInto_Mpa = this.txtFuelInto.Text;
                nowObject.Host_ActualSpeed = this.txtActualSpeed.Text;
                nowObject.Host_LossRate = this.txtLoosRate.Text;
                nowObject.Host_TurbochargerSpeedNO1 = this.txtTurboChargerNO1.Text;
                nowObject.Host_TurbochargerSpeedNO2 = this.txtTurboChargerNO2.Text;
                nowObject.Host_LossRate = this.txtLoosRate.Text;
           
                fileDate = this.dtpItemDate.Value.ToString("yyyy.MM.dd");
                fileDateMonth = this.dtpItemDate.Value.ToString("yyyy.MM");

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
                MessageBoxEx.Show("保存失败,原因:" + err);
                return;
            }

            this.FormToObject(out err);      //从界面获取数据到对象中.

            if (!editFlag) //新.
            {
                nowObject.Report_ShipHost_Id = null;

                //检查数据库是否已存在此条记录.
                if (ReportShipHostService.Instance.CheckSubDetail(fileDate, shipID))
                {
                    MessageBoxEx.Show("数据库已经存在此日的处理信息,请查看日期选择是否正确");
                    return;
                }
            }

            returnValue = ReportShipHostService.Instance.UpdateSomeRecord(fileDate, shipID, nowObject);

            if (returnValue)
            {
                MessageBoxEx.Show("保存成功", "", new MessageBoxButtons(), MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBoxEx.Show("保存失败,原因:" + err);
                return;
            }
        }

        private bool check(out string err)
        {
            err = "";

            if (this.txtVoyage.Text.Length == 0)
            {
                err = "航次内容为必填信息";
                this.txtVoyage.Focus(); ;
                return false;
            }
            return true;
        }

        private void showObject()
        {
            if (nowObject != null)
            {
                this.txtVoyage.Text = nowObject.Voyage;
                this.dtpAbstractDate.Value = nowObject.Host_ParaAbstractedDate;
                this.dtpTableWrited.Value = nowObject.TableWritedDate;
                this.txtChiefSign.Text = nowObject.HH_ChiefSign;
                this.dtpChiefSignDate.Value = nowObject.HH_ChiefSignDate;
                this.txtDirectorSign.Text = nowObject.HH_DirectorSign;
                this.dtpDirectorSignDate.Value = nowObject.HH_DirectorSignDate;
                this.txtHighOil1.Text = nowObject.HH_HighPumpNO1;
                this.txtHighOil2.Text = nowObject.HH_HighPumpNO2;
                this.txtHighOil3.Text = nowObject.HH_HighPumpNO3;
                this.txtHighOil4.Text = nowObject.HH_HighPumpNO4;
                this.txtHighOil5.Text = nowObject.HH_HighPumpNO5;
                this.txtHighOil6.Text = nowObject.HH_HighPumpNO6;
                this.txtHighOil7.Text = nowObject.HH_HighPumpNO7;
                this.txtHighOil8.Text = nowObject.HH_HighPumpNO8;
                this.txtHighOilAverage.Text = nowObject.HH_HighPumpAverage;
                this.txtVIT1.Text = nowObject.HH_VITNO1;
                this.txtVIT2.Text = nowObject.HH_VITNO2;
                this.txtVIT3.Text = nowObject.HH_VITNO3;
                this.txtVIT4.Text = nowObject.HH_VITNO4;
                this.txtVIT5.Text = nowObject.HH_VITNO5;
                this.txtVIT6.Text = nowObject.HH_VITNO6;
                this.txtVIT7.Text = nowObject.HH_VITNO7;
                this.txtVIT8.Text = nowObject.HH_VITNO8;
                this.txtVITAverage.Text = nowObject.HH_VITAverage;
                this.txtSmoke1.Text = nowObject.HH_SmokeTemNO1;
                this.txtSmoke2.Text = nowObject.HH_SmokeTemNO2;
                this.txtSmoke3.Text = nowObject.HH_SmokeTemNO3;
                this.txtSmoke4.Text = nowObject.HH_SmokeTemNO4;
                this.txtSmoke5.Text = nowObject.HH_SmokeTemNO5;
                this.txtSmoke6.Text = nowObject.HH_SmokeTemNO6;
                this.txtSmoke7.Text = nowObject.HH_SmokeTemNO7;
                this.txtSmoke8.Text = nowObject.HH_SmokeTemNO8;
                this.txtSmokeAverage.Text = nowObject.HH_SmokeTemAverage;
                this.txtCopress1.Text = nowObject.HH_CompressionPressNO1;
                this.txtCopress2.Text = nowObject.HH_CompressionPressNO2;
                this.txtCopress3.Text = nowObject.HH_CompressionPressNO3;
                this.txtCopress4.Text = nowObject.HH_CompressionPressNO4;
                this.txtCopress5.Text = nowObject.HH_CompressionPressNO5;
                this.txtCopress6.Text = nowObject.HH_CompressionPressNO6;
                this.txtCopress7.Text = nowObject.HH_CompressionPressNO7;
                this.txtCopress8.Text = nowObject.HH_CompressionPressNO8;
                this.txtCopressAverage.Text = nowObject.HH_CompressionPressAverage;
                this.txtExplosion1.Text = nowObject.HH_BoomPressNO1;
                this.txtExplosion2.Text = nowObject.HH_BoomPressNO2;
                this.txtExplosion3.Text = nowObject.HH_BoomPressNO3;
                this.txtExplosion4.Text = nowObject.HH_BoomPressNO4;
                this.txtExplosion5.Text = nowObject.HH_BoomPressNO5;
                this.txtExplosion6.Text = nowObject.HH_BoomPressNO6;
                this.txtExplosion7.Text = nowObject.HH_BoomPressNO7;
                this.txtExplosion8.Text = nowObject.HH_BoomPressNO8;
                this.txtExplosionAverage.Text = nowObject.HH_BoomPressAverage;
                this.dtpMeasureDate.Value = nowObject.HH_MeasureDate;
                this.txtSeaArea.Text = nowObject.HH_SeaArea;
                this.txtWind.Text = nowObject.HH_Wind;
                this.txtWave.Text = nowObject.HH_Wave;
                this.txtBeforeWater.Text = nowObject.HH_BowDraft;
                this.txtAfterWater.Text = nowObject.HH_PoopDraft;
                this.txtHostCatagory.Text = nowObject.HH_Model;
                this.txtFireSequence.Text = nowObject.HH_FireSequence;
                this.txtDayConsum.Text = nowObject.HH_DailyConsumption;
                this.txtLinerConstant.Text = nowObject.HH_CylinderConstant;
                this.txtTotalKWS.Text = nowObject.HH_TotalKW;
                this.txtRatedKW.Text = nowObject.HH_TotalRatedPower;
                this.txtTotalKW.Text = nowObject.HH_TotalPower;
                this.txtSpeed.Text = nowObject.HH_Speed;
                this.txtSlipRate.Text = nowObject.HH_SlipRate;
                this.txtOilSpe.Text = nowObject.HH_FuelSpecification;
                this.txtOilInTem.Text = nowObject.HH_FuelInTem;
                this.txtOilInV.Text = nowObject.HH_FuelInViscosity;
                this.txtLoad.Text = nowObject.HH_Load;
                this.txtCompressDiff.Text = nowObject.HH_MaxCompressionPressDifference;
                this.txtExhaustTemDiff.Text = nowObject.HH_MaxExhaustTempDifference;
                this.txtBurstTemDiff.Text = nowObject.HH_DetonationPressDifference;
                this.txtRemarks.Text = nowObject.HH_Remarks;

                //主机参数摘录明细信息.
                this.dtpItemDate.Value = nowObject.Host_RecordDate;
                this.txthSpeed.Text = nowObject.Host_Speed;
                this.txthLoad.Text = nowObject.Host_LoadInstruction;
                this.txtSmokeHighTem.Text = nowObject.Host_SmokeHign_Tem;
                this.txtSmokehignliner.Text = nowObject.Host_SmokeHign_CylinderNO;
                this.txtSmokeLowTem.Text = nowObject.Host_SmokeLow_Tem;
                this.txtSmokeLowNO.Text = nowObject.Host_SmokeLow_CylinderNO;
                this.txtLinerIn.Text = nowObject.Host_LinerCoolWaterIn_Tem;
                this.txtLinerOut.Text = nowObject.Host_LinerCoolWaterOut_Tem;
                this.txtPostionIn.Text = nowObject.Host_PistonCoolantIn_Tem;
                this.txtPostionOut.Text = nowObject.Host_PistonCoolanOut_Tem;
                this.txtBeforeNo1.Text = nowObject.Host_CoolerBeforeNO1_Tem;
                this.txtBeforeNo2.Text = nowObject.Host_CoolerBeforeNO2_Tem;
                this.txtBeforeNo3.Text = nowObject.Host_CoolerBeforeNO3_Tem;
                this.txtAfterNO1.Text = nowObject.Host_CoolerAfterNO1_Tem;
                this.txtAfterNO2.Text = nowObject.Host_CoolerAfterNO2_Tem;
                this.txtAfterNO3.Text = nowObject.Host_CoolerAfterNO3_Tem;
                this.txtTurbeTem.Text = nowObject.Host_SternTube_Tem;
                this.txtCabinTem.Text = nowObject.Host_Cabin_Tem;
                this.txtSeaWateTem.Text = nowObject.Host_SeaWater_Tem;
                this.txtCoolHighTem.Text = nowObject.Host_CoolWaterHigh_MPa;
                this.txtCoolLowTem.Text = nowObject.Host_CoolWaterLow_MPa;
                this.txtMainBear.Text = nowObject.Host_OilMain_Mpa;
                this.txtCross.Text = nowObject.Host_OilCrosshead_Mpa;
                this.txtPressAir.Text = nowObject.Host_PressurizedAir_Mpa;
                this.txtFuelInto.Text = nowObject.Host_FuelInto_Mpa;
                this.txtActualSpeed.Text = nowObject.Host_ActualSpeed;
                this.txtLoosRate.Text = nowObject.Host_LossRate;
                this.txtTurboChargerNO1.Text = nowObject.Host_TurbochargerSpeedNO1;
                this.txtTurboChargerNO2.Text = nowObject.Host_TurbochargerSpeedNO2;

            }
        }

    }
}