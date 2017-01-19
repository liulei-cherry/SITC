/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：黄家龙
 * 创建时间：2011-08-30
 * 功能描述：船舶副机工况报表
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
    public partial class FrmShipSlave : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmShipSlave instance = new FrmShipSlave();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmShipSlave Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmShipSlave.instance = new FrmShipSlave();
                }
                return FrmShipSlave.instance;
            }
        }

        #endregion

        #region 窗体对象

        private ReportShipSlave currentObject;
        public ReportShipSlave CurrentObject
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
        private FrmShipSlave()
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

            DataTable dtb = ReportShipSlaveService.Instance.getInfoByYear(shipID, yearMonth, out err);
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
            dictColumns.Add("Slave_RecordDate", " 记录日期");
            dictColumns.Add("Slave_EditID", " 副机编号");
            dictColumns.Add("Slave_SmokeHignNO", "排烟温度最高缸号");
            dictColumns.Add("Slave_SmokeHignTem", "排烟温度最高温度");
            dictColumns.Add("Slave_SmokeLowNO", "排烟温度最低缸号");
            dictColumns.Add("Slave_SmokeLowTem", "排烟温度最低温度");
            dictColumns.Add("Slave_CoolSystemInTem", "机器冷却系统水温进机温度");
            dictColumns.Add("Slave_CoolSystemOutTem", "机器冷却系统水温出机温度");
            dictColumns.Add("Slave_OilinTem", "滑油进机温度");
            dictColumns.Add("Slave_OilOutTem", "滑油出机温度");
            dictColumns.Add("Slave_FuelInTem", "燃油进机温度");
            dictColumns.Add("Slave_PressureAirTem", "增压空气温度");
            dictColumns.Add("Slave_CoolWaterHignMPa", "冷却淡水高温压力");
            dictColumns.Add("Slave_CoolWaterLowMPa", "冷却淡水低温压力");
            dictColumns.Add("Slave_OilInMpa", "滑油进机压力");
            dictColumns.Add("Slave_FuelInMpa", "燃油进机压力");
            dictColumns.Add("Slave_PressureAirMPa", "增压空气压力");
            dictColumns.Add("Slave_GeneratorVoltage", "发电机打压V");
            dictColumns.Add("Slave_GeneratorCurrent", "发电机电流A");
            dictColumns.Add("Slavae_GeneratorKW", "发电机功率KW");
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
                if (DBNull.Value != dr.Cells["Report_ShipSlave_Id"].Value && null != dr.Cells["Report_ShipSlave_Id"].Value)
                    objectId = dr.Cells["Report_ShipSlave_Id"].Value.ToString();

                //初始化当前对象.
                CurrentObject = ReportShipSlaveService.Instance.getObject(objectId, out err);
            }
        }

        private void showObject(ReportShipSlave tempObject)
        {
            if (tempObject != null)
            {
                    this.txtVoyage.Text = tempObject.Voyage;
                    this.txtParaYearMonth.Text = tempObject.Slave_ParaAbstractedDate.ToString("yyyy/MM");
                    this.txtTableWriteDate.Text = tempObject.TableWritedDate.ToString("yyyy/MM/dd");
                    this.txtChiefSign.Text = tempObject.Slave_ChiefSign;
                    if (string.IsNullOrEmpty(tempObject.Slave_ChiefSign))
                    {
                        this.txtChiefSignDate.Text = tempObject.Slave_ChiefSignDate.ToString("yyyy/MM/dd");
                    }

                    this.txtDirectorSign.Text = tempObject.Slave_DirectorSign;
                    if (string.IsNullOrEmpty(tempObject.Slave_DirectorSign))
                    {
                        this.txtDirectorSignDate.Text = tempObject.Slave_DirectorSignDate.ToString("yyyy/MM/dd");
                    }
                      
                    this.txtSecondChiefSign.Text=tempObject.Slave_SecondChiefSign;
                    
                    if (string.IsNullOrEmpty(tempObject.Slave_SecondChiefSign))
                    {
                        this.txtSecondChiefSignDate.Text = tempObject.Slave_SecondChiefSignDate.ToString("yyyy/MM/dd");
                    }

                    this.txtSlaveID1.Text = tempObject.SS_DieselNoOne;
                    this.txtDetonationNO11.Text = tempObject.SS_DieselNoOnePressureNO1;
                    this.txtDetonationNO12.Text = tempObject.SS_DieselNoOnePressureNO2;
                    this.txtDetonationNO13.Text = tempObject.SS_DieselNoOnePressureNO3;
                    this.txtDetonationNO14.Text = tempObject.SS_DieselNoOnePressureNO4;
                    this.txtDetonationNO15.Text = tempObject.SS_DieselNoOnePressureNO5;
                    this.txtDetonationNO16.Text = tempObject.SS_DieselNoOnePressureNO6;
                    this.txtDetonationNO17.Text = tempObject.SS_DieselNoOnePressureNO7;
                    this.txtDetonationNO18.Text = tempObject.SS_DieselNoOnePressureNO8;
                    this.txtSmokeNO11.Text = tempObject.SS_DieselNoOneTemNO1;
                    this.txtSmokeNO12.Text = tempObject.SS_DieselNoOneTemNO2;
                    this.txtSmokeNO13.Text = tempObject.SS_DieselNoOneTemNO3;
                    this.txtSmokeNO14.Text = tempObject.SS_DieselNoOneTemNO4;
                    this.txtSmokeNO15.Text = tempObject.SS_DieselNoOneTemNO5;
                    this.txtSmokeNO16.Text = tempObject.SS_DieselNoOneTemNO6;
                    this.txtSmokeNO17.Text = tempObject.SS_DieselNoOneTemNO7;
                    this.txtSmokeNO18.Text = tempObject.SS_DieselNoOneTemNO8;

                    this.txtSlaveID2.Text = tempObject.SS_DieselNoTwo;
                    this.txtDenotationNo21.Text = tempObject.SS_DieselNoTwoPressureNO1;
                    this.txtDenotationNo22.Text = tempObject.SS_DieselNoTwoPressureNO2;
                    this.txtDenotationNo23.Text = tempObject.SS_DieselNoTwoPressureNO3;
                    this.txtDenotationNo24.Text = tempObject.SS_DieselNoTwoPressureNO4;
                    this.txtDenotationNo25.Text = tempObject.SS_DieselNoTwoPressureNO5;
                    this.txtDenotationNo26.Text = tempObject.SS_DieselNoTwoPressureNO6;
                    this.txtDenotationNo27.Text = tempObject.SS_DieselNoTwoPressureNO7;
                    this.txtDenotationNo28.Text = tempObject.SS_DieselNoTwoPressureNO8;
                    this.txtSmokeNo21.Text = tempObject.SS_DieselNoTwoTemNO1;
                    this.txtSmokeNo22.Text = tempObject.SS_DieselNoTwoTemNO2;
                    this.txtSmokeNo23.Text = tempObject.SS_DieselNoTwoTemNO3;
                    this.txtSmokeNo24.Text = tempObject.SS_DieselNoTwoTemNO4;
                    this.txtSmokeNo25.Text = tempObject.SS_DieselNoTwoTemNO5;
                    this.txtSmokeNo26.Text = tempObject.SS_DieselNoTwoTemNO6;
                    this.txtSmokeNo27.Text = tempObject.SS_DieselNoTwoTemNO7;
                    this.txtSmokeNo28.Text = tempObject.SS_DieselNoTwoTemNO8;    
                    
                    this.txtFuelConsuption1.Text=tempObject.SS_SDieselFuelConsumption1;
                    this.txtFuelConsuption2.Text=tempObject.SS_SDieselFuelConsumption2;
                    this.txtFuelConsuption3.Text=tempObject.SS_SDieselFuelConsumption3;
                    this.txtFuelConsuption4.Text=tempObject.SS_SDieselFuelConsumption4;

                    this.txtFuelSpec.Text = tempObject.SS_DieselFuelSpecifation;
                }
                else
                {
                    this.txtSlaveID1.Text = "";
                    this.txtDetonationNO11.Text =  "";
                    this.txtDetonationNO12.Text =  "";
                    this.txtDetonationNO13.Text =  "";
                    this.txtDetonationNO14.Text =  "";
                    this.txtDetonationNO15.Text =  "";
                    this.txtDetonationNO16.Text =  "";
                    this.txtDetonationNO17.Text =  "";
                    this.txtDetonationNO18.Text =  "";
                    this.txtSmokeNO11.Text =  "";
                    this.txtSmokeNO12.Text =  "";
                    this.txtSmokeNO13.Text =  "";
                    this.txtSmokeNO14.Text =  "";
                    this.txtSmokeNO15.Text =  "";
                    this.txtSmokeNO16.Text =  "";
                    this.txtSmokeNO17.Text =  "";
                    this.txtSmokeNO18.Text =  "";

                    this.txtSlaveID2.Text = "";
                    this.txtDenotationNo21.Text = "";
                    this.txtDenotationNo22.Text = "";
                    this.txtDenotationNo23.Text = "";
                    this.txtDenotationNo24.Text = "";
                    this.txtDenotationNo25.Text = "";
                    this.txtDenotationNo26.Text = "";
                    this.txtDenotationNo27.Text = "";
                    this.txtDenotationNo28.Text = "";
                    this.txtSmokeNo21.Text = "";
                    this.txtSmokeNo22.Text = "";
                    this.txtSmokeNo23.Text = "";
                    this.txtSmokeNo24.Text = "";
                    this.txtSmokeNo25.Text = "";
                    this.txtSmokeNo26.Text = "";
                    this.txtSmokeNo27.Text = "";
                    this.txtSmokeNo28.Text = "";    
                    
                    this.txtFuelConsuption1.Text = "";
                    this.txtFuelConsuption2.Text = "";
                    this.txtFuelConsuption2.Text = "";
                    this.txtFuelConsuption2.Text = "";
                    this.txtFuelSpec.Text = "";
                    
                    this.txtChiefSignDate.Text = "";
                    this.txtDirectorSignDate.Text = "";
                    this.txtSecondChiefSignDate.Text = "";
                }
            }
        
        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            
            FrmEditShipSlave frm = new FrmEditShipSlave(ShipID, null);
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
            CustomTable.Haifeng.Viewer.FrmEditShipSlave frm = new CustomTable.Haifeng.Viewer.FrmEditShipSlave(ShipID, CurrentObject);
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
            string applyDate = currentObject.Slave_RecordDate.ToString("yyyy.MM"); //取处理年月.

            string fileId = currentObject.File_ID;                    //船舶副机工况报表Id

            ////如果找到了相应的船舶副机工况报表,则提示用户是否打开旧的.
            string fileName = "船舶副机工况报表" + currentObject.Slave_RecordDate.ToString("yyyy.MM");
            string fileid;
            if (FolderFileDbService.Instance.IfFolderHasTheFile(fileId, fileName + ".xls", out fileid))
            {
                if (MessageBoxEx.Show("找到了之前形成的船舶副机工况报表文件" + fileName + ",是否要直接打开此文件?" +
                    "\r选择否,系统推荐您删除旧文件,以免形成多个船舶副机工况报表的导出文件给其他人造成误导.", "系统提示", MessageBoxButtons.YesNo,
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

        /// <summary>
        /// 打印输出.
        /// </summary>
        public bool applyPrint(ReportShipSlave obj, string path, out string err)
        {
            err = "";

            if (string.IsNullOrEmpty(path))
            {
                err = "传入的path参数无效.";
                return false;
            }

            if (obj == null || obj.IsWrong)
            {
                err = "获取船舶副机工况报表的数据时出错,请确认选择了有效数据.\r更多错误信息请参考::" + err;
                return false;
            }
            //   obj.FillThisObject();

            WorkModelType model = WorkModelTypeService.Instance.getModelObject(currentObject.SHIP_ID, CommonPrintTableName.CTNOfSlaveInfo, out err);
            if (model == null || model.IsWrong || model.ModelFile.Trim().Length == 0)
            {
                err = "获取船舶副机工况报表的表格时出错,请管理员从模板管理模块导入相应的表格.\r更多错误信息请参考:" + err;
                return false;
            }

            FileInfo f = new FileInfo(path);
            if (f.Exists) f.Delete();

            string path2;
            //获取模板文件,并保存到指定位置;
            if (!filo.GetABlobById(model.ModelFile, f.Name, out path2))
            {
                err = "获取船舶副机工况报表的表格时出错,可能是大文件库连接串有问题,或者大文件数据库本身出现问题.\r更多错误信息请参考:" + err;
                return false;
            }

            int rowIndexStart = 9;//开始行.

            OfficeOperation.Excel excel = new OfficeOperation.Excel();
            excel.OpenDocument(path2);

            //填充模板内容.
            string shipName = ShipInfoService.Instance.GetShipName(currentObject.SHIP_ID);
            excel.SetSingelCellValue(3, 3, shipName, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(9, 3, currentObject.Voyage, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(15, 3, currentObject.Slave_ParaAbstractedDate.Year.ToString() + " 年 " + currentObject.Slave_ParaAbstractedDate.Month.ToString() + " 月  ", XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(21, 3, currentObject.TableWritedDate.Year.ToString() + "  年  " + currentObject.TableWritedDate.Month.ToString() + " 月  " + currentObject.TableWritedDate.Day.ToString() + " 日", XlHorizontalAlignment.xlRight);

            DataTable dt = ReportShipSlaveService.Instance.GetApplyDatas(currentObject.Slave_RecordDate.ToString("yyyy.MM"), currentObject.SHIP_ID);

            int i = 0;
            for (; i < dt.Rows.Count; i++)
            {
                ReportShipSlave rowObject = ReportShipSlaveService.Instance.GetMainDetail(dt.Rows[i]["Slave_RecordDate"].ToString(), currentObject.SHIP_ID, out err);

                excel.SetSingelCellValue(1, 2*i + rowIndexStart, rowObject.Slave_RecordDate.ToString("MM.dd"), XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(2, 2*i + rowIndexStart, rowObject.Slave_EditID, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(3, 2*i + rowIndexStart, rowObject.Slave_SmokeHignNO, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(4, 2*i + rowIndexStart, rowObject.Slave_SmokeHignTem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(5, 2*i + rowIndexStart, rowObject.Slave_SmokeLowNO, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(6, 2*i + rowIndexStart, rowObject.Slave_SmokeLowTem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(7, 2*i + rowIndexStart, rowObject.Slave_CoolSystemInTem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(8, 2*i + rowIndexStart, rowObject.Slave_CoolSystemOutTem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(9, 2*i + rowIndexStart, rowObject.Slave_OilinTem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(10, 2*i + rowIndexStart, rowObject.Slave_OilOutTem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(11, 2*i + rowIndexStart, rowObject.Slave_FuelInTem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(12, 2*i + rowIndexStart, rowObject.Slave_PressureAirTem, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(13, 2*i + rowIndexStart, rowObject.Slave_CoolWaterHignMPa, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(14, 2*i + rowIndexStart, rowObject.Slave_CoolWaterLowMPa, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(15, 2*i + rowIndexStart, rowObject.Slave_OilInMpa, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(16, 2*i + rowIndexStart, rowObject.Slave_FuelInMpa, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(17, 2*i + rowIndexStart, rowObject.Slave_PressureAirMPa, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(18, 2*i + rowIndexStart, rowObject.Slave_GeneratorVoltage, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(19, 2*i + rowIndexStart, rowObject.Slave_GeneratorCurrent, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(20, 2*i + rowIndexStart, rowObject.Slavae_GeneratorKW, XlHorizontalAlignment.xlLeft);
            }

            excel.SetSingelCellValue(22, 6, currentObject.SS_DieselNoOne, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(24, 6, currentObject.SS_DieselNoOnePressureNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(24, 7, currentObject.SS_DieselNoOnePressureNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(24, 8, currentObject.SS_DieselNoOnePressureNO3, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(24, 9, currentObject.SS_DieselNoOnePressureNO4, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(24, 10, currentObject.SS_DieselNoOnePressureNO5, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(24, 11, currentObject.SS_DieselNoOnePressureNO6, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(24, 12, currentObject.SS_DieselNoOnePressureNO7, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(24, 13, currentObject.SS_DieselNoOnePressureNO8, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(26, 6, currentObject.SS_DieselNoOneTemNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(26, 7, currentObject.SS_DieselNoOneTemNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(26, 8, currentObject.SS_DieselNoOneTemNO3, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(26, 9, currentObject.SS_DieselNoOneTemNO4, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(26, 10, currentObject.SS_DieselNoOneTemNO5, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(26, 11, currentObject.SS_DieselNoOneTemNO6, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(26, 12, currentObject.SS_DieselNoOneTemNO7, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(26, 13, currentObject.SS_DieselNoOneTemNO8, XlHorizontalAlignment.xlLeft);

            excel.SetSingelCellValue(22, 14, currentObject.SS_DieselNoTwo, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(24, 14, currentObject.SS_DieselNoTwoPressureNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(24, 15, currentObject.SS_DieselNoTwoPressureNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(24, 16, currentObject.SS_DieselNoTwoPressureNO3, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(24, 17, currentObject.SS_DieselNoTwoPressureNO4, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(24, 18, currentObject.SS_DieselNoTwoPressureNO5, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(24, 19, currentObject.SS_DieselNoTwoPressureNO6, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(24, 20, currentObject.SS_DieselNoTwoPressureNO7, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(24, 21, currentObject.SS_DieselNoTwoPressureNO8, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(26, 14, currentObject.SS_DieselNoTwoTemNO1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(26, 15, currentObject.SS_DieselNoTwoTemNO2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(26, 16, currentObject.SS_DieselNoTwoTemNO3, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(26, 17, currentObject.SS_DieselNoTwoTemNO4, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(26, 18, currentObject.SS_DieselNoTwoTemNO5, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(26, 19, currentObject.SS_DieselNoTwoTemNO6, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(26, 20, currentObject.SS_DieselNoTwoTemNO7, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(26, 21, currentObject.SS_DieselNoTwoTemNO8, XlHorizontalAlignment.xlLeft);

            excel.SetSingelCellValue(24, 22, currentObject.SS_DieselFuelSpecifation, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(24, 24, currentObject.SS_SDieselFuelConsumption1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(25, 24, currentObject.SS_SDieselFuelConsumption2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(26, 24, currentObject.SS_SDieselFuelConsumption3, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(27, 24, currentObject.SS_SDieselFuelConsumption4, XlHorizontalAlignment.xlLeft);
            
            if (currentObject.Slave_SecondChiefSign !=null && currentObject.Slave_SecondChiefSign.Length != 0)
            {
                excel.SetSingelCellValue(4, 25, currentObject.Slave_SecondChiefSign + "  " + currentObject.Slave_SecondChiefSignDate.Year.ToString() + "年  " + currentObject.Slave_SecondChiefSignDate.Month.ToString() + "月 " + currentObject.Slave_SecondChiefSignDate.Day.ToString() + "日 ", XlHorizontalAlignment.xlRight);
            }

            if (currentObject.Slave_ChiefSign != null && currentObject.Slave_ChiefSign.Length != 0)
            {
                excel.SetSingelCellValue(11, 25, currentObject.Slave_ChiefSign + "   " + currentObject.Slave_ChiefSignDate.Year.ToString() + "年  " + currentObject.Slave_ChiefSignDate.Month.ToString() + "月  " + currentObject.Slave_ChiefSignDate.Day.ToString() + "日  ", XlHorizontalAlignment.xlRight);
            }

            if (currentObject.Slave_DirectorSign != null && currentObject.Slave_DirectorSign.Length != 0)
            {
                excel.SetSingelCellValue(19, 25, currentObject.Slave_DirectorSign + "     " + currentObject.Slave_DirectorSignDate.Year.ToString() + "年  " + currentObject.Slave_DirectorSignDate.Month.ToString() + "月  " + currentObject.Slave_ChiefSignDate.Day.ToString() + "日 ", XlHorizontalAlignment.xlRight);
            }

            excel.SaveDocument(path2);
            excel.CloseDocument();
            Excel.release(excel.pt);

            File.Copy(path2, path);
            ourFile ofile;

            if (!BaseInfo.DataAccess.WorkModelTypeService.Instance.SetReport(CommonOperation.Enum.FileBoundingTypes.MEASUREREPORT, true, "船舶副机工况", currentObject.File_ID,
                currentObject.Slave_ParaAbstractedDate, CommonOperation.ConstParameter.UserName, currentObject.SHIP_ID, model.ModelFile, f.FullName, out ofile, out err))
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