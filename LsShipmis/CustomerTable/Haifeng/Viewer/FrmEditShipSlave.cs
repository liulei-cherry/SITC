/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：黄家龙
 * 创建时间：2011-08-30
 * 功能描述：船舶副机工况窗体
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
    public partial class FrmEditShipSlave : CommonViewer.BaseForm.FormBase
    {

        #region 窗体对象
        //存储格式为yyyy.MM
        string fileDateMonth;
        //存储格式为yyyy.MM.dd
        string fileDate;
        //是否为编辑 true编辑 false新增.
        bool editFlag = false;

        string shipID;
        ReportShipSlave nowObject = new ReportShipSlave();
        public ReportShipSlave NowObject
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
        private FrmEditShipSlave()
        {
            InitializeComponent();
        }

        public FrmEditShipSlave(string shipid, ReportShipSlave nowObject)
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

            //副机参数摘录明细信息.
            this.dtpItemDate.Value = DateTime.Now;
            this.txtEditId.Text = "";
            this.txtSmokeHighTem.Text = "";
            this.txtSmokehignNO.Text = "";
            this.txtSmokeLowTem.Text = "";
            this.txtSmokeLowNO.Text = "";
            this.txtCoolSystemInTem.Text = "";
            this.txtCoolSystemOutTem.Text = "";
            this.txtOilInTem.Text = "";
            this.txtOilOutTem.Text = "";
            this.txtFuelInTem.Text = "";
            this.txtPressureAirTem.Text = "";
            this.txtCoolWaterHighMPa.Text = "";
            this.txtCoolWaterLowMpa.Text = "";
            this.txtOilInMpa.Text = "";
            this.txtFuelInMpa.Text = "";
            this.txtPressureAirMpa.Text = "";
            this.txtGeneratorV.Text = "";
            this.txtGeneratorA.Text = "";
            this.txtGeneratorKW.Text = "";
        }

        public void FormToObject(out string err)
        {
            err = "";

            if (nowObject != null)
            {
                nowObject.Voyage = this.txtVoyage.Text;
                nowObject.Slave_ParaAbstractedDate = this.dtpAbstractDate.Value;
                nowObject.TableWritedDate = this.dtpTableWrited.Value;
                nowObject.Slave_ChiefSign = this.txtChiefSign.Text;
                nowObject.Slave_ChiefSignDate = this.dtpChiefSignDate.Value;
                nowObject.Slave_DirectorSign = this.txtDirectorSign.Text;
                nowObject.Slave_SecondChiefSign = this.txtSecondChiefSign.Text;
                nowObject.Slave_SecondChiefSignDate = this.dtpSecondChiefSignDate.Value;
                nowObject.Slave_DirectorSignDate = this.dtpDirectorSignDate.Value;

                nowObject.SS_DieselNoOne = this.txtSlaveID1.Text;
                nowObject.SS_DieselNoOnePressureNO1 = this.txtDetonationNO11.Text;
                nowObject.SS_DieselNoOnePressureNO2 = this.txtDetonationNO12.Text;
                nowObject.SS_DieselNoOnePressureNO3 = this.txtDetonationNO13.Text;
                nowObject.SS_DieselNoOnePressureNO4 = this.txtDetonationNO14.Text;
                nowObject.SS_DieselNoOnePressureNO5 = this.txtDetonationNO15.Text;
                nowObject.SS_DieselNoOnePressureNO6 = this.txtDetonationNO16.Text;
                nowObject.SS_DieselNoOnePressureNO7 = this.txtDetonationNO17.Text;
                nowObject.SS_DieselNoOnePressureNO8 = this.txtDetonationNO18.Text;
                nowObject.SS_DieselNoOneTemNO1 = this.txtSmokeNO11.Text;
                nowObject.SS_DieselNoOneTemNO2 = this.txtSmokeNO12.Text;
                nowObject.SS_DieselNoOneTemNO3 = this.txtSmokeNO13.Text;
                nowObject.SS_DieselNoOneTemNO4 = this.txtSmokeNO14.Text;
                nowObject.SS_DieselNoOneTemNO5 = this.txtSmokeNO15.Text;
                nowObject.SS_DieselNoOneTemNO6 = this.txtSmokeNO16.Text;
                nowObject.SS_DieselNoOneTemNO7 = this.txtSmokeNO17.Text;
                nowObject.SS_DieselNoOneTemNO8 = this.txtSmokeNO18.Text;

                nowObject.SS_DieselNoTwo = this.txtSlaveID2.Text;
                nowObject.SS_DieselNoTwoPressureNO1 = this.txtDenotationNo21.Text;
                nowObject.SS_DieselNoTwoPressureNO2 = this.txtDenotationNo22.Text;
                nowObject.SS_DieselNoTwoPressureNO3 = this.txtDenotationNo23.Text;
                nowObject.SS_DieselNoTwoPressureNO4 = this.txtDenotationNo24.Text;
                nowObject.SS_DieselNoTwoPressureNO5 = this.txtDenotationNo25.Text;
                nowObject.SS_DieselNoTwoPressureNO6 = this.txtDenotationNo26.Text;
                nowObject.SS_DieselNoTwoPressureNO7 = this.txtDenotationNo27.Text;
                nowObject.SS_DieselNoTwoPressureNO8 = this.txtDenotationNo28.Text;
                nowObject.SS_DieselNoTwoTemNO1 = this.txtSmokeNo21.Text;
                nowObject.SS_DieselNoTwoTemNO2 = this.txtSmokeNo22.Text;
                nowObject.SS_DieselNoTwoTemNO3 = this.txtSmokeNo23.Text;
                nowObject.SS_DieselNoTwoTemNO4 = this.txtSmokeNo24.Text;
                nowObject.SS_DieselNoTwoTemNO5 = this.txtSmokeNo25.Text;
                nowObject.SS_DieselNoTwoTemNO6 = this.txtSmokeNo26.Text;
                nowObject.SS_DieselNoTwoTemNO7 = this.txtSmokeNo27.Text;
                nowObject.SS_DieselNoTwoTemNO8 = this.txtSmokeNo28.Text;

                nowObject.SS_SDieselFuelConsumption1 = this.txtFuelConsuption1.Text;
                nowObject.SS_SDieselFuelConsumption2 = this.txtFuelConsuption2.Text;
                nowObject.SS_SDieselFuelConsumption3 = this.txtFuelConsuption3.Text;
                nowObject.SS_SDieselFuelConsumption4 = this.txtFuelConsuption4.Text;

                nowObject.SS_DieselFuelSpecifation = this.txtFuelSpec.Text;

                //副机参数摘录明细信息.
                nowObject.Slave_RecordDate = this.dtpItemDate.Value;
                nowObject.Slave_EditID = this.txtEditId.Text;
                nowObject.Slave_SmokeHignTem = this.txtSmokeHighTem.Text;
                nowObject.Slave_SmokeHignNO = this.txtSmokehignNO.Text;
                nowObject.Slave_SmokeLowTem = this.txtSmokeLowTem.Text;
                nowObject.Slave_SmokeLowNO = this.txtSmokeLowNO.Text;
                nowObject.Slave_CoolSystemInTem = this.txtCoolSystemInTem.Text;
                nowObject.Slave_CoolSystemOutTem = this.txtCoolSystemOutTem.Text;
                nowObject.Slave_OilinTem = this.txtOilInTem.Text;
                nowObject.Slave_OilOutTem = this.txtOilOutTem.Text;
                nowObject.Slave_FuelInTem = this.txtFuelInTem.Text;
                nowObject.Slave_PressureAirTem = this.txtPressureAirTem.Text;
                nowObject.Slave_CoolWaterHignMPa = this.txtCoolWaterHighMPa.Text;
                nowObject.Slave_CoolWaterLowMPa = this.txtCoolWaterLowMpa.Text;
                nowObject.Slave_OilInMpa = this.txtOilInMpa.Text;
                nowObject.Slave_FuelInMpa = this.txtFuelInMpa.Text;
                nowObject.Slave_PressureAirMPa = this.txtPressureAirMpa.Text;
                nowObject.Slave_GeneratorVoltage = this.txtGeneratorV.Text;
                nowObject.Slave_GeneratorCurrent = this.txtGeneratorA.Text;
                nowObject.Slavae_GeneratorKW = this.txtGeneratorKW.Text;

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
                MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err);
                return;
            }

            this.FormToObject(out err);      //从界面获取数据到对象中.

            if (!editFlag) //新.
            {
                nowObject.Report_ShipSlave_Id = null;

                //检查数据库是否已存在此条记录.
                if (ReportShipSlaveService.Instance.CheckSubDetail(fileDate, shipID))
                {
                    MessageBoxEx.Show("已经存在此日的处理信息,请查看日期选择是否正确");
                    return;
                }
            }

            returnValue = ReportShipSlaveService.Instance.UpdateSomeRecord(fileDate, shipID, nowObject);

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
                this.txtVoyage.Text = nowObject.Voyage;
                this.dtpAbstractDate.Value = nowObject.Slave_ParaAbstractedDate;
                this.dtpTableWrited.Value = nowObject.TableWritedDate;
                this.txtChiefSign.Text = nowObject.Slave_ChiefSign;
                this.dtpChiefSignDate.Value = nowObject.Slave_ChiefSignDate;
                this.txtDirectorSign.Text = nowObject.Slave_DirectorSign;
                this.txtSecondChiefSign.Text = nowObject.Slave_SecondChiefSign;
                this.dtpSecondChiefSignDate.Value = nowObject.Slave_SecondChiefSignDate;
                this.dtpDirectorSignDate.Value = nowObject.Slave_DirectorSignDate;

                this.txtSlaveID1.Text = nowObject.SS_DieselNoOne;
                this.txtDetonationNO11.Text = nowObject.SS_DieselNoOnePressureNO1;
                this.txtDetonationNO12.Text = nowObject.SS_DieselNoOnePressureNO2;
                this.txtDetonationNO13.Text = nowObject.SS_DieselNoOnePressureNO3;
                this.txtDetonationNO14.Text = nowObject.SS_DieselNoOnePressureNO4;
                this.txtDetonationNO15.Text = nowObject.SS_DieselNoOnePressureNO5;
                this.txtDetonationNO16.Text = nowObject.SS_DieselNoOnePressureNO6;
                this.txtDetonationNO17.Text = nowObject.SS_DieselNoOnePressureNO7;
                this.txtDetonationNO18.Text = nowObject.SS_DieselNoOnePressureNO8;
                this.txtSmokeNO11.Text = nowObject.SS_DieselNoOneTemNO1;
                this.txtSmokeNO12.Text = nowObject.SS_DieselNoOneTemNO2;
                this.txtSmokeNO13.Text = nowObject.SS_DieselNoOneTemNO3;
                this.txtSmokeNO14.Text = nowObject.SS_DieselNoOneTemNO4;
                this.txtSmokeNO15.Text = nowObject.SS_DieselNoOneTemNO5;
                this.txtSmokeNO16.Text = nowObject.SS_DieselNoOneTemNO6;
                this.txtSmokeNO17.Text = nowObject.SS_DieselNoOneTemNO7;
                this.txtSmokeNO18.Text = nowObject.SS_DieselNoOneTemNO8;

                this.txtSlaveID2.Text = nowObject.SS_DieselNoTwo;
                this.txtDenotationNo21.Text = nowObject.SS_DieselNoTwoPressureNO1;
                this.txtDenotationNo22.Text = nowObject.SS_DieselNoTwoPressureNO2;
                this.txtDenotationNo23.Text = nowObject.SS_DieselNoTwoPressureNO3;
                this.txtDenotationNo24.Text = nowObject.SS_DieselNoTwoPressureNO4;
                this.txtDenotationNo25.Text = nowObject.SS_DieselNoTwoPressureNO5;
                this.txtDenotationNo26.Text = nowObject.SS_DieselNoTwoPressureNO6;
                this.txtDenotationNo27.Text = nowObject.SS_DieselNoTwoPressureNO7;
                this.txtDenotationNo28.Text = nowObject.SS_DieselNoTwoPressureNO8;
                this.txtSmokeNo21.Text = nowObject.SS_DieselNoTwoTemNO1;
                this.txtSmokeNo22.Text = nowObject.SS_DieselNoTwoTemNO2;
                this.txtSmokeNo23.Text = nowObject.SS_DieselNoTwoTemNO3;
                this.txtSmokeNo24.Text = nowObject.SS_DieselNoTwoTemNO4;
                this.txtSmokeNo25.Text = nowObject.SS_DieselNoTwoTemNO5;
                this.txtSmokeNo26.Text = nowObject.SS_DieselNoTwoTemNO6;
                this.txtSmokeNo27.Text = nowObject.SS_DieselNoTwoTemNO7;
                this.txtSmokeNo28.Text = nowObject.SS_DieselNoTwoTemNO8;

                this.txtFuelConsuption1.Text = nowObject.SS_SDieselFuelConsumption1;
                this.txtFuelConsuption2.Text = nowObject.SS_SDieselFuelConsumption2;
                this.txtFuelConsuption3.Text = nowObject.SS_SDieselFuelConsumption3;
                this.txtFuelConsuption4.Text = nowObject.SS_SDieselFuelConsumption4;

                this.txtFuelSpec.Text = nowObject.SS_DieselFuelSpecifation;

                //副机参数摘录明细信息.
                this.dtpItemDate.Value = nowObject.Slave_RecordDate;
                this.txtEditId.Text = nowObject.Slave_EditID;
                this.txtSmokeHighTem.Text = nowObject.Slave_SmokeHignTem;
                this.txtSmokehignNO.Text = nowObject.Slave_SmokeHignNO;
                this.txtSmokeLowTem.Text = nowObject.Slave_SmokeLowTem;
                this.txtSmokeLowNO.Text = nowObject.Slave_SmokeLowNO;
                this.txtCoolSystemInTem.Text = nowObject.Slave_CoolSystemInTem;
                this.txtCoolSystemOutTem.Text = nowObject.Slave_CoolSystemOutTem;
                this.txtOilInTem.Text = nowObject.Slave_OilinTem;
                this.txtOilOutTem.Text = nowObject.Slave_OilinTem;
                this.txtFuelInTem.Text = nowObject.Slave_FuelInTem;
                this.txtPressureAirTem.Text = nowObject.Slave_PressureAirTem;
                this.txtCoolWaterHighMPa.Text = nowObject.Slave_CoolWaterHignMPa;
                this.txtCoolWaterLowMpa.Text = nowObject.Slave_CoolWaterLowMPa;
                this.txtOilInMpa.Text = nowObject.Slave_OilInMpa;
                this.txtFuelInMpa.Text = nowObject.Slave_FuelInMpa;
                this.txtPressureAirMpa.Text = nowObject.Slave_PressureAirMPa;
                this.txtGeneratorV.Text = nowObject.Slave_GeneratorVoltage;
                this.txtGeneratorA.Text = nowObject.Slave_GeneratorCurrent;
                this.txtGeneratorKW.Text = nowObject.Slavae_GeneratorKW;  
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}