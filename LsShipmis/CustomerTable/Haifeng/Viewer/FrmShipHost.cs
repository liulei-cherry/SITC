/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：黄家龙
 * 创建时间：2011-08-25
 * 功能描述：船舶主机工况报表
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
    public partial class FrmShipHost : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmShipHost instance = new FrmShipHost();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmShipHost Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmShipHost.instance = new FrmShipHost();
                }
                return FrmShipHost.instance;
            }
        }

        #endregion

        #region 窗体对象

        private ReportShipHost currentObject;
        public ReportShipHost CurrentObject
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
        private FrmShipHost()
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
            dateMonth.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
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
            yearMonth = new DateTime(dateYear.Value.Year, dateMonth.Value.Month, 1);

            DataTable dtb = ReportShipHostService.Instance.getInfoByYear(shipID, yearMonth, out err);
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
            dictColumns.Add("Host_RecordDate", "记录日期");
            dictColumns.Add("Host_Speed", " 主机转速");
            dictColumns.Add("Host_LoadInstruction", "负荷指示");
            dictColumns.Add("Host_SmokeHign_Tem", "排烟温度最高温度");
            dictColumns.Add("Host_SmokeHign_CylinderNO", "排烟温度最高缸号");
            dictColumns.Add("Host_SmokeLow_Tem", "排烟温度最低温度");
            dictColumns.Add("Host_SmokeLow_CylinderNO", "排烟温度最低缸号");
            dictColumns.Add("Host_LinerCoolWaterIn_Tem", "缸套冷却水进机温度");
            dictColumns.Add("Host_LinerCoolWaterOut_Tem", "缸套冷却水出机温度");
            dictColumns.Add("Host_PistonCoolantIn_Tem", "活塞冷却液进机温度");
            dictColumns.Add("Host_PistonCoolanOut_Tem", "活塞冷却液出机温度");
            dictColumns.Add("Host_CoolerBeforeNO1_Tem", "空气冷却器冷却前No.1温度");
            dictColumns.Add("Host_CoolerBeforeNO2_Tem", "空气冷却器冷却前No.2温度");
            dictColumns.Add("Host_CoolerBeforeNO3_Tem", "空气冷却器冷却前No.3温度");
            dictColumns.Add("Host_CoolerAfterNO1_Tem", "空气冷却器冷却后No.1温度");
            dictColumns.Add("Host_CoolerAfterNO2_Tem", "空气冷却器冷却后No.2温度");
            dictColumns.Add("Host_CoolerAfterNO3_Tem", "空气冷却器冷却后No.3温度");
            dictColumns.Add("Host_SternTube_Tem", "艉轴温度");
            dictColumns.Add("Host_Cabin_Tem", "机舱");
            dictColumns.Add("Host_SeaWater_Tem", "海水");
            dictColumns.Add("Host_CoolWaterHigh_MPa", "冷却淡水高温压力");
            dictColumns.Add("Host_CoolWaterLow_MPa", "冷却淡水低温压力");
            dictColumns.Add("Host_OilMain_Mpa", "滑油主轴承压力");
            dictColumns.Add("Host_OilCrosshead_Mpa", "滑油十字头压力");
            dictColumns.Add("Host_PressurizedAir_Mpa", "增压空气压力");
            dictColumns.Add("Host_FuelInto_Mpa", "燃油进机压力");
            dictColumns.Add("Host_ActualSpeed", "实际航速KN");
            dictColumns.Add("Host_LossRate", "滑失率%");
            dictColumns.Add("Host_TurbochargerSpeedNO1", "增压器转速No.1(r/min)");
            dictColumns.Add("Host_TurbochargerSpeedNO2", "增压器转速No.2(r/min)");
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

        private void dateMonth_ValueChanged(object sender, EventArgs e)
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
                if (DBNull.Value != dr.Cells["Report_ShipHost_Id"].Value && null != dr.Cells["Report_ShipHost_Id"].Value)
                    objectId = dr.Cells["Report_ShipHost_Id"].Value.ToString();

                //初始化当前对象.
                CurrentObject = ReportShipHostService.Instance.getObject(objectId, out err);
            }
        }

        private void showObject(ReportShipHost tempObject)
        {
            if (tempObject != null)
            {
                this.txtVoyage.Text = tempObject.Voyage;
                this.txtParaYearMonth.Text = tempObject.Host_ParaAbstractedDate.ToString("yyyy/MM");
                this.txtTableWriteDate.Text = tempObject.TableWritedDate.ToString("yyyy/MM/dd");
                this.txtChiefSign.Text = tempObject.HH_ChiefSign;
                if (string.IsNullOrEmpty(tempObject.HH_ChiefSign))
                {
                    this.txtChiefSignDate.Text = tempObject.HH_ChiefSignDate.ToString("yyyy/MM/dd");
                }

                if (string.IsNullOrEmpty(tempObject.HH_DirectorSign))
                {
                    this.txtDirectorSignDate.Text = tempObject.HH_DirectorSignDate.ToString("yyyy/MM/dd");
                }
                this.txtDirectorSign.Text = tempObject.HH_DirectorSign;   
                this.txtHighOil1.Text = tempObject.HH_HighPumpNO1;
                this.txtHighOil2.Text = tempObject.HH_HighPumpNO2;
                this.txtHighOil3.Text = tempObject.HH_HighPumpNO3;
                this.txtHighOil4.Text = tempObject.HH_HighPumpNO4;
                this.txtHighOil5.Text = tempObject.HH_HighPumpNO5;
                this.txtHighOil6.Text = tempObject.HH_HighPumpNO6;
                this.txtHighOil7.Text = tempObject.HH_HighPumpNO7;
                this.txtHighOil8.Text = tempObject.HH_HighPumpNO8;
                this.txtHighOilAverage.Text = tempObject.HH_HighPumpAverage;
                this.txtVIT1.Text = tempObject.HH_VITNO1;
                this.txtVIT2.Text = tempObject.HH_VITNO2;
                this.txtVIT3.Text = tempObject.HH_VITNO3;
                this.txtVIT4.Text = tempObject.HH_VITNO4;
                this.txtVIT5.Text = tempObject.HH_VITNO5;
                this.txtVIT6.Text = tempObject.HH_VITNO6;
                this.txtVIT7.Text = tempObject.HH_VITNO7;
                this.txtVIT8.Text = tempObject.HH_VITNO8;
                this.txtVITAverage.Text = tempObject.HH_VITAverage;
                this.txtSmoke1.Text = tempObject.HH_SmokeTemNO1;
                this.txtSmoke2.Text = tempObject.HH_SmokeTemNO2;
                this.txtSmoke3.Text = tempObject.HH_SmokeTemNO3;
                this.txtSmoke4.Text = tempObject.HH_SmokeTemNO4;
                this.txtSmoke5.Text = tempObject.HH_SmokeTemNO5;
                this.txtSmoke6.Text = tempObject.HH_SmokeTemNO6;
                this.txtSmoke7.Text = tempObject.HH_SmokeTemNO7;
                this.txtSmoke8.Text = tempObject.HH_SmokeTemNO8;
                this.txtSmokeAverage.Text = tempObject.HH_SmokeTemAverage;
                this.txtCopress1.Text = tempObject.HH_CompressionPressNO1;
                this.txtCopress2.Text = tempObject.HH_CompressionPressNO2;
                this.txtCopress3.Text = tempObject.HH_CompressionPressNO3;
                this.txtCopress4.Text = tempObject.HH_CompressionPressNO4;
                this.txtCopress5.Text = tempObject.HH_CompressionPressNO5;
                this.txtCopress6.Text = tempObject.HH_CompressionPressNO6;
                this.txtCopress7.Text = tempObject.HH_CompressionPressNO7;
                this.txtCopress8.Text = tempObject.HH_CompressionPressNO8;
                this.txtCopressAverage.Text = tempObject.HH_CompressionPressAverage;
                this.txtExplosion1.Text = tempObject.HH_BoomPressNO1;
                this.txtExplosion2.Text = tempObject.HH_BoomPressNO2;
                this.txtExplosion3.Text = tempObject.HH_BoomPressNO3;
                this.txtExplosion4.Text = tempObject.HH_BoomPressNO4;
                this.txtExplosion5.Text = tempObject.HH_BoomPressNO5;
                this.txtExplosion6.Text = tempObject.HH_BoomPressNO6;
                this.txtExplosion7.Text = tempObject.HH_BoomPressNO7;
                this.txtExplosion8.Text = tempObject.HH_BoomPressNO8;
                this.txtExplosionAverage.Text = tempObject.HH_BoomPressAverage;

                this.txtMeasureDate.Text = tempObject.HH_MeasureDate.ToString("yyyy/MM/dd");
                this.txtSeaArea.Text = tempObject.HH_SeaArea;
                this.txtWind.Text = tempObject.HH_Wind;
                this.txtWave.Text = tempObject.HH_Wave;
                this.txtBeforeWater.Text = tempObject.HH_BowDraft;
                this.txtAfterWater.Text = tempObject.HH_PoopDraft;
                this.txtHostCatagory.Text = tempObject.HH_Model;
                this.txtFireSequence.Text = tempObject.HH_FireSequence;
                this.txtDayConsum.Text = tempObject.HH_DailyConsumption;
                this.txtLinerConstant.Text = tempObject.HH_CylinderConstant;
                this.txtTotalKWS.Text = tempObject.HH_TotalKW;
                this.txtRatedKW.Text = tempObject.HH_TotalRatedPower;
                this.txtTotalKW.Text = tempObject.HH_TotalPower;
                this.txtSpeed.Text = tempObject.HH_Speed;
                this.txtSlipRate.Text = tempObject.HH_SlipRate;
                this.txtOilSpe.Text = tempObject.HH_FuelSpecification;
                this.txtOilInTem.Text = tempObject.HH_FuelInTem;
                this.txtOilInV.Text = tempObject.HH_FuelInViscosity;
                this.txtLoad.Text = tempObject.HH_Load;
                this.txtCompressDiff.Text = tempObject.HH_MaxCompressionPressDifference;
                this.txtExhaustTemDiff.Text = tempObject.HH_MaxExhaustTempDifference;
                this.txtBurstTemDiff.Text = tempObject.HH_DetonationPressDifference;
                this.txtRemarks.Text = tempObject.HH_Remarks;
            }
            else
            {
                this.txtVoyage.Text = "";
                this.txtParaYearMonth.Text = "";
                this.txtTableWriteDate.Text = "";
                this.txtChiefSign.Text = "";
                this.txtChiefSignDate.Text = "";
                this.txtDirectorSign.Text = "";
                this.txtDirectorSignDate.Text = "";
                this.txtHighOil1.Text = "";
                this.txtHighOil2.Text = "";
                this.txtHighOil3.Text = "";
                this.txtHighOil4.Text = "";
                this.txtHighOil5.Text = "";
                this.txtHighOil6.Text = "";
                this.txtHighOil7.Text = "";
                this.txtHighOil8.Text = "";
                this.txtHighOilAverage.Text = "";
                this.txtVIT1.Text = "";
                this.txtVIT2.Text = "";
                this.txtVIT3.Text = "";
                this.txtVIT4.Text = "";
                this.txtVIT5.Text = "";
                this.txtVIT6.Text = "";
                this.txtVIT7.Text = "";
                this.txtVIT8.Text = "";
                this.txtVITAverage.Text = "";
                this.txtSmoke1.Text = "";
                this.txtSmoke2.Text = "";
                this.txtSmoke3.Text = "";
                this.txtSmoke4.Text = "";
                this.txtSmoke5.Text = "";
                this.txtSmoke6.Text = "";
                this.txtSmoke7.Text = "";
                this.txtSmoke8.Text = "";
                this.txtSmokeAverage.Text = "";
                this.txtCopress1.Text = "";
                this.txtCopress2.Text = "";
                this.txtCopress3.Text = "";
                this.txtCopress4.Text = "";
                this.txtCopress5.Text = "";
                this.txtCopress6.Text = "";
                this.txtCopress7.Text = "";
                this.txtCopress8.Text = "";
                this.txtCopressAverage.Text = "";
                this.txtExplosion1.Text = "";
                this.txtExplosion2.Text = "";
                this.txtExplosion3.Text = "";
                this.txtExplosion4.Text = "";
                this.txtExplosion5.Text = "";
                this.txtExplosion6.Text = "";
                this.txtExplosion7.Text = "";
                this.txtExplosion8.Text = "";
                this.txtExplosionAverage.Text = "";

                this.txtMeasureDate.Text = "";
                this.txtSeaArea.Text = "";
                this.txtWind.Text = "";
                this.txtWave.Text = "";
                this.txtBeforeWater.Text = "";
                this.txtAfterWater.Text = "";
                this.txtHostCatagory.Text = "";
                this.txtFireSequence.Text = "";
                this.txtDayConsum.Text = "";
                this.txtLinerConstant.Text = "";
                this.txtTotalKWS.Text = "";
                this.txtRatedKW.Text = "";
                this.txtTotalKW.Text = "";
                this.txtSpeed.Text = "";
                this.txtSlipRate.Text = "";
                this.txtOilSpe.Text = "";
                this.txtOilInTem.Text = "";
                this.txtOilInV.Text = "";
                this.txtLoad.Text = "";
                this.txtCompressDiff.Text = "";
                this.txtExhaustTemDiff.Text = "";
                this.txtBurstTemDiff.Text = "";
                this.txtRemarks.Text = "";
            }
        }

        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            CustomTable.Haifeng.Viewer.FrmEditShipHost frm = new CustomTable.Haifeng.Viewer.FrmEditShipHost(ShipID, null);
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
                    MessageBoxEx.Show("删除成功", "", new MessageBoxButtons(), MessageBoxIcon.Information);
                    loadMainData();
                }
                else
                {
                    MessageBoxEx.Show("删除失败,原因:" + err, "", new MessageBoxButtons(), MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBoxEx.Show("请先选择一条记录", "", new MessageBoxButtons(), MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 编辑操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgEditItem_Click(object sender, EventArgs e)
        {
            CustomTable.Haifeng.Viewer.FrmEditShipHost frm = new CustomTable.Haifeng.Viewer.FrmEditShipHost(ShipID, CurrentObject);
            frm.ShowDialog();

            ////刷新列表.
            loadMainData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (currentObject == null && this.dgvMain.Rows.Count == 0)
            {
                MessageBoxEx.Show("无可打印的信息", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string err = "";                                 //错误信息参数.
            string shipName = ShipInfoService.Instance.getObject(shipID, out err).SHIP_NAME;
            string applyDate = currentObject.Host_RecordDate.ToString("yyyy.MM"); //取处理年月.

            string fileId = currentObject.File_ID;                    //船舶主机工况报表Id

            ////如果找到了相应的船舶主机工况报表,则提示用户是否打开旧的.
            string fileName = "船舶主机工况报表" + currentObject.Host_RecordDate.ToString("yyyy年MM");
            string fileid;
            if (FolderFileDbService.Instance.IfFolderHasTheFile(fileId, fileName + ".xls", out fileid))
            {
                if (MessageBoxEx.Show("找到了之前形成的船舶主机工况报表文件" + fileName + ",是否要直接打开此文件?" +
                    "\r否,系统删除旧文件,以免形成多个船舶主机工况报表的导出文件给其他人造成误导.", "系统提示", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ourFile ofile;

                    if (!FileDbService.Instance.GetAFileById(fileid, out ofile))
                    {
                        MessageBoxEx.Show("非常抱歉,没有成功获取此文档,下面将重新形成新文件", "系统提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                    else
                    {
                        openFile opf = new openFile();
                        opf.FileOpen(ofile, right.U);
                        return;
                    }
                }
                else//删除旧文件.
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
                        "\r是,系统覆盖当前文件.\r否,系统为您新生成的文件添加一个随机后缀,以免发生冲突.",
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
                    MessageBoxEx.Show(err, "信息提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 打印输出.
        /// </summary>
        public bool applyPrint(ReportShipHost obj, string path, out string err)
        {
            err = "";

            if (string.IsNullOrEmpty(path))
            {
                err = "传入的path参数无效.";
                return false;
            }

            if (obj == null || obj.IsWrong)
            {
                err = "获取船舶主机工况报表的数据时出错,请确认选择了有效数据.\r更多错误信息请参考::" + err;
                return false;
            }
            //   obj.FillThisObject();

            WorkModelType model = WorkModelTypeService.Instance.getModelObject(currentObject.SHIP_ID, CommonPrintTableName.CTNOfHostInfo, out err);
            if (model == null || model.IsWrong || model.ModelFile.Trim().Length == 0)
            {
                err = "获取船舶主机工况报表的表格时出错,请管理员从模板管理模块导入相应的表格.\r更多错误信息请参考:" + err;
                return false;
            }

            FileInfo f = new FileInfo(path);
            if (f.Exists) f.Delete();

            string path2;
            //获取模板文件,并保存到指定位置;
            if (!filo.GetABlobById(model.ModelFile, f.Name, out path2))
            {
                err = "获取船舶主机工况报表的表格时出错,可能是大文件库连接串有问题,或者大文件数据库本身出现问题.\r更多错误信息请参考:" + err;
                return false;
            }

            int rowIndexStart = 8;//开始行.

            OfficeOperation.Excel excel = new OfficeOperation.Excel();
            excel.OpenDocument(path2);

            //填充模板内容.
            string shipName = ShipInfoService.Instance.GetShipName(currentObject.SHIP_ID);
            excel.SetSingelCellValue(3, 3, shipName, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(11, 3, currentObject.Voyage, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(17, 3, currentObject.Host_ParaAbstractedDate.Year.ToString() + " 年 "+currentObject.Host_ParaAbstractedDate.Month.ToString() +" 月  ", XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(25, 3, currentObject.TableWritedDate.Year.ToString() + "  年  " + currentObject.TableWritedDate.Month.ToString() + " 月  " +currentObject.TableWritedDate.Day.ToString() + " 日", XlHorizontalAlignment.xlRight);

            DataTable dt = ReportShipHostService.Instance.GetApplyDatas(currentObject.Host_RecordDate.ToString("yyyy.MM"), currentObject.SHIP_ID);

            int i = 0;
            for (; i < dt.Rows.Count; i++)
            {
                ReportShipHost rowObject = ReportShipHostService.Instance.GetMainDetail(dt.Rows[i]["Host_RecordDate"].ToString(), currentObject.SHIP_ID, out err);

                excel.SetSingelCellValue(1, i + rowIndexStart, rowObject.Host_RecordDate.ToString("MM.dd"), XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(2, i + rowIndexStart, rowObject.Host_Speed, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(3, i + rowIndexStart, rowObject.Host_LoadInstruction, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(4, i + rowIndexStart, rowObject.Host_SmokeHign_Tem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(5, i + rowIndexStart, rowObject.Host_SmokeHign_CylinderNO, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(6, i + rowIndexStart, rowObject.Host_SmokeLow_Tem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(7, i + rowIndexStart, rowObject.Host_SmokeLow_CylinderNO, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(8, i + rowIndexStart, rowObject.Host_LinerCoolWaterIn_Tem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(9, i + rowIndexStart, rowObject.Host_LinerCoolWaterOut_Tem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(10, i + rowIndexStart, rowObject.Host_PistonCoolantIn_Tem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(11, i + rowIndexStart, rowObject.Host_PistonCoolanOut_Tem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(12, i + rowIndexStart, rowObject.Host_CoolerBeforeNO1_Tem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(13, i + rowIndexStart, rowObject.Host_CoolerBeforeNO2_Tem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(14, i + rowIndexStart, rowObject.Host_CoolerBeforeNO3_Tem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(15, i + rowIndexStart, rowObject.Host_CoolerAfterNO1_Tem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(16, i + rowIndexStart, rowObject.Host_CoolerAfterNO2_Tem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(17, i + rowIndexStart, rowObject.Host_CoolerAfterNO3_Tem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(18, i + rowIndexStart, rowObject.Host_SternTube_Tem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(19, i + rowIndexStart, rowObject.Host_Cabin_Tem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(20, i + rowIndexStart, rowObject.Host_SeaWater_Tem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(21, i + rowIndexStart, rowObject.Host_CoolWaterHigh_MPa, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(22, i + rowIndexStart, rowObject.Host_CoolWaterLow_MPa, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(23, i + rowIndexStart, rowObject.Host_OilMain_Mpa, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(24, i + rowIndexStart, rowObject.Host_OilCrosshead_Mpa, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(25, i + rowIndexStart, rowObject.Host_PressurizedAir_Mpa, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(26, i + rowIndexStart, rowObject.Host_FuelInto_Mpa, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(27, i + rowIndexStart, rowObject.Host_ActualSpeed, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(28, i + rowIndexStart, rowObject.Host_LossRate, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(29, i + rowIndexStart, rowObject.Host_TurbochargerSpeedNO1, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(30, i + rowIndexStart, rowObject.Host_TurbochargerSpeedNO2, XlHorizontalAlignment.xlLeft);
            }

            excel.SetSingelCellValue(19, 15, currentObject.HH_MeasureDate.ToString("yyyy.MM.dd"), XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(25, 15, currentObject.HH_SeaArea, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(28, 15, currentObject.HH_Wind, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(30, 15, currentObject.HH_Wave, XlHorizontalAlignment.xlLeft);

            excel.SetSingelCellValue(6, 16, currentObject.HH_HighPumpNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(7, 16, currentObject.HH_HighPumpNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(8, 16, currentObject.HH_HighPumpNO3, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(9, 16, currentObject.HH_HighPumpNO4, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(10, 16, currentObject.HH_HighPumpNO5, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(11, 16, currentObject.HH_HighPumpNO6, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(12, 16, currentObject.HH_HighPumpNO7, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(13, 16, currentObject.HH_HighPumpNO8, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(14, 16, currentObject.HH_HighPumpAverage, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(20, 16, currentObject.HH_Load, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(26, 16, currentObject.HH_BowDraft, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(30, 16, currentObject.HH_PoopDraft, XlHorizontalAlignment.xlLeft);

            excel.SetSingelCellValue(6, 17, currentObject.HH_VITNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(7, 17, currentObject.HH_VITNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(8, 17, currentObject.HH_VITNO3, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(9, 17, currentObject.HH_VITNO4, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(10, 17, currentObject.HH_VITNO5, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(11, 17, currentObject.HH_VITNO6, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(12, 17, currentObject.HH_VITNO7, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(13, 17, currentObject.HH_VITNO8, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(14, 17, currentObject.HH_VITAverage, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(18, 17, currentObject.HH_Model, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(26, 17, currentObject.HH_FireSequence, XlHorizontalAlignment.xlLeft);

            excel.SetSingelCellValue(6, 18, currentObject.HH_SmokeTemNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(7, 18, currentObject.HH_SmokeTemNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(8, 18, currentObject.HH_SmokeTemNO3, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(9, 18, currentObject.HH_SmokeTemNO4, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(10, 18, currentObject.HH_SmokeTemNO5, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(11, 18, currentObject.HH_SmokeTemNO6, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(12, 18, currentObject.HH_SmokeTemNO7, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(13, 18, currentObject.HH_SmokeTemNO8, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(14, 18, currentObject.HH_SmokeTemAverage, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(19, 18, currentObject.HH_FuelSpecification, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(25, 18, currentObject.HH_DailyConsumption, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(29, 18, currentObject.HH_CylinderConstant, XlHorizontalAlignment.xlCenter);

            excel.SetSingelCellValue(6, 19, currentObject.HH_CompressionPressNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(7, 19, currentObject.HH_CompressionPressNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(8, 19, currentObject.HH_CompressionPressNO3, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(9, 19, currentObject.HH_CompressionPressNO4, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(10, 19, currentObject.HH_CompressionPressNO5, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(11, 19, currentObject.HH_CompressionPressNO6, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(12, 19, currentObject.HH_CompressionPressNO7, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(13, 19, currentObject.HH_CompressionPressNO8, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(14, 19, currentObject.HH_CompressionPressAverage, XlHorizontalAlignment.xlLeft);

            excel.SetSingelCellValue(6, 20, currentObject.HH_BoomPressNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(7, 20, currentObject.HH_BoomPressNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(8, 20, currentObject.HH_BoomPressNO3, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(9, 20, currentObject.HH_BoomPressNO4, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(10, 20, currentObject.HH_BoomPressNO5, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(11, 20, currentObject.HH_BoomPressNO6, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(12, 20, currentObject.HH_BoomPressNO7, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(13, 20, currentObject.HH_BoomPressNO8, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(14, 20, currentObject.HH_BoomPressAverage, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(19, 20, currentObject.HH_TotalKW, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(25, 20, currentObject.HH_TotalRatedPower, XlHorizontalAlignment.xlCenter);
            excel.SetSingelCellValue(30, 20, currentObject.HH_TotalPower, XlHorizontalAlignment.xlCenter);

            excel.SetSingelCellValue(1, 21, "备注：" + currentObject.HH_Remarks, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(19, 21, currentObject.HH_Speed, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(27, 21, currentObject.HH_SlipRate, XlHorizontalAlignment.xlLeft);

            excel.SetSingelCellValue(19, 22, currentObject.HH_MaxExhaustTempDifference, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(25, 22, currentObject.HH_MaxCompressionPressDifference, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(30, 22, currentObject.HH_DetonationPressDifference, XlHorizontalAlignment.xlLeft);

            excel.SetSingelCellValue(19, 23, currentObject.HH_FuelInTem, XlHorizontalAlignment.xlLeft);

            excel.SetSingelCellValue(19, 24, currentObject.HH_FuelInViscosity, XlHorizontalAlignment.xlLeft);

            if (currentObject.HH_ChiefSign != null && !(currentObject.HH_ChiefSign.Length == 0))
            {
                excel.SetSingelCellValue(5, 25, currentObject.HH_ChiefSign + "    " + currentObject.HH_ChiefSignDate.Year.ToString() + "年    " + currentObject.HH_ChiefSignDate.Month.ToString() + "    月    " + currentObject.HH_ChiefSignDate.Day.ToString() + "  日  ", XlHorizontalAlignment.xlRight);
            }
            if (currentObject.HH_DirectorSign !=null && !(currentObject.HH_DirectorSign.Length == 0))
            {
                excel.SetSingelCellValue(20, 25, currentObject.HH_DirectorSign + "     " + currentObject.HH_DirectorSignDate.Year.ToString() + "年    " + currentObject.HH_DirectorSignDate.Month.ToString() + "    月    " + currentObject.HH_DirectorSignDate.Day.ToString() + "  日 ", XlHorizontalAlignment.xlRight);
            }

            excel.SaveDocument(path2);
            excel.CloseDocument();
            Excel.release(excel.pt);

            File.Copy(path2, path);
            ourFile ofile;

            if (!BaseInfo.DataAccess.WorkModelTypeService.Instance.SetReport(CommonOperation.Enum.FileBoundingTypes.MEASUREREPORT, true, "船舶主机工况", currentObject.File_ID,
                currentObject.Host_ParaAbstractedDate, CommonOperation.ConstParameter.UserName, currentObject.SHIP_ID, model.ModelFile, f.FullName, out ofile, out err))
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