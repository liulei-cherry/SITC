/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：黄家龙
 * 创建时间：2011-08-15
 * 功能描述：锅炉水质处理功能
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
    public partial class FrmBoilerWater : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmBoilerWater instance = new FrmBoilerWater();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmBoilerWater Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmBoilerWater.instance = new FrmBoilerWater();
                }
                return FrmBoilerWater.instance;
            }
        }

        #endregion

        #region 窗体对象

        private ReportBoilerwater currentObject;
        public ReportBoilerwater CurrentObject
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

        bool isFirstLoadMain = true;
        bool isFirstLoadSub = true;
        Dictionary<string, string> dictColumns = new Dictionary<string, string>();
        Dictionary<string, string> dictColumnsSub = new Dictionary<string, string>();

        #endregion

        #region 其它公共业务类

        private FormControlOption other = FormControlOption.Instance;
        Dictionary<string, string> discRate = new Dictionary<string, string>();

        static FileDbService filo = FileDbService.Instance;
        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmBoilerWater()
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
            YearMonth = new DateTime(dateYear.Value.Year, 1, 1);

            DataTable dtb = ReportBoilerwaterService.Instance.getInfoByYear(shipID, yearMonth, out err);
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

            //刷新(清空)明细信息列表.
            if (CurrentObject == null && dgvMain.Rows.Count == 0)
            {
                if (bindingSourceDetail.DataSource != null)
                {
                    DataTable dt = (DataTable)bindingSourceDetail.DataSource;
                    dt.Rows.Clear();
                }
            }
        }

        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataCol()
        {
            dictColumns.Clear();

            //设置列标题.
            dictColumns.Add("FileDate", "处理年月");
            dictColumns.Add("BoilerCategory", " 锅炉种类");
            dictColumns.Add("BoilerAirPressure", "锅炉气压");
            dictColumns.Add("BoilerWaterQuantity", "炉水吨数");
            dictColumns.Add("ExperimentOrHandlePersonName", "试验及处理人姓名");
            dictColumns.Add("ChiefEngineerName", "轮机长");
            dgvMain.SetDgvGridColumns(dictColumns);
            isFirstLoadMain = false;
        }

        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataColSub()
        {
            dictColumnsSub.Clear();

            //设置列标题.
            dictColumnsSub.Add("FileDate", "处理年月日");
            dictColumnsSub.Add("PhenolphthaleinAlkalinity", "酚酞碱度C.C");
            dictColumnsSub.Add("SaltAmount", "含盐量C.C");
            dictColumnsSub.Add("Hardness", "硬度");
            dictColumnsSub.Add("PHValue", "PH值");
            dictColumnsSub.Add("SewageOnAmount", "排污(上)水量(吨)");
            dictColumnsSub.Add("SewageNextAmount", "排污(下)水量(吨)");
            dictColumnsSub.Add("Medicine1", "药剂名称1");
            dictColumnsSub.Add("Medicine2", "药剂名称2");
            dictColumnsSub.Add("Medicine3", "药剂名称3");
            dictColumnsSub.Add("Medicine1Value", "药剂1投药量(千克/吨)");
            dictColumnsSub.Add("Medicine2Value", "药剂2投药量(千克/吨)");
            dictColumnsSub.Add("Medicine3Value", "药剂3投药量(千克/吨)");
            dictColumnsSub.Add("CondensateLevel", "凝结水");
            dictColumnsSub.Add("CondensateSilverNitrateDrops", "凝结水硝酸银滴数C.C");
            dictColumnsSub.Add("TankWaterLeverl", "装水时水柜水");
            dictColumnsSub.Add("TankWateSilverNitrateDrops", "装水时水柜水硝酸银滴数C.C");
            dictColumnsSub.Add("Remarks", "备注");

            dgvSecond.SetDgvGridColumns(dictColumnsSub);
            isFirstLoadSub = false;
        }

        /// <summary>
        /// 设置锅炉水质处理报告表明细信息的bindingSource数据源，每次查询的都是指定水质处理报告表的明细信息数据.
        /// </summary>
        /// <param name="shipId">年月</param>
        /// <param name="materialApplyId">船ID</param>
        private void setBindingSourceDetail(string ApplyId, string shipID)
        {
            DataTable dtb = ReportBoilerwaterService.Instance.GetApplyDatas(ApplyId, shipID);//取得水质处理明细信息的DataTable对象.
            bindingSourceDetail.DataSource = dtb;                                  //水质处理明细信息的数据源设置.
            dgvSecond.DataSource = dtb;
            //加载主列项.
            if (isFirstLoadSub)
            {
                loadDataColSub();
            }
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
                //string err = "";
                DataGridViewRow dr = dgvMain.Rows[e.RowIndex];

                string objectFileDate = "";
                if (DBNull.Value != dr.Cells["FileDate"].Value && null != dr.Cells["FileDate"].Value)
                    objectFileDate = dr.Cells["FileDate"].Value.ToString();

                //加载申请明细.
                this.setBindingSourceDetail(objectFileDate, shipID);
            }
        }

        private void dgvSecond_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string err = "";
            if (e.RowIndex >= 0)
            {
                //string err = "";
                DataGridViewRow dr = this.dgvSecond.Rows[e.RowIndex];

                string objectFileDate = "";
                if (DBNull.Value != dr.Cells["FileDate"].Value && null != dr.Cells["FileDate"].Value)
                    objectFileDate = dr.Cells["FileDate"].Value.ToString();

                CurrentObject = ReportBoilerwaterService.Instance.GetMainDetail(objectFileDate, shipID, out err);
            }
        }

        private void showObject(ReportBoilerwater tempObject)
        {
            if (tempObject != null)
            {
                txtBoilerCategory.Text = tempObject.BoilerCategory;
                txtPressure.Text = tempObject.BoilerAirPressure;
                txtWaterMount.Text = tempObject.BoilerWaterQuantity;
                txtYear.Text = tempObject.FileDate.ToString("yyyy/MM");
                txtHandlePerson.Text = tempObject.ExperimentOrHandlePersonName;
                txtChief.Text = tempObject.ChiefEngineerName;
                txtMedcine1.Text = tempObject.Medicine1;
                txtMedcine2.Text = tempObject.Medicine2;
                txtMedcine3.Text = tempObject.Medicine3;
            }
            else
            {
                txtBoilerCategory.Text = "";
                txtPressure.Text = "";
                txtWaterMount.Text = "";
                txtYear.Text = "";
                txtHandlePerson.Text = "";
                txtChief.Text = "";
                txtMedcine1.Text = "";
                txtMedcine2.Text = "";
                txtMedcine3.Text = "";
            }
        }

        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            string yearV = "";
            yearV = dateYear.Value.Year.ToString();

            CustomTable.Haifeng.Viewer.FrmEditOneBoilerWater frm = new CustomTable.Haifeng.Viewer.FrmEditOneBoilerWater(yearV, ShipID, null);
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
                    MessageBoxEx.Show("当前数据删除失败,原因:" + err, "", new MessageBoxButtons(), MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBoxEx.Show("请先选择一条数据", "", new MessageBoxButtons(), MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 编辑操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgEditItem_Click(object sender, EventArgs e)
        {
            string yearV = "";
            yearV = dateYear.Value.Year.ToString();

            CustomTable.Haifeng.Viewer.FrmEditOneBoilerWater frm = new CustomTable.Haifeng.Viewer.FrmEditOneBoilerWater(yearV, ShipID, CurrentObject);
            frm.ShowDialog();

            ////刷新列表.
            loadMainData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (currentObject == null)
            {
                MessageBoxEx.Show("无可打印的信息", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.dgvSecond.Rows.Count == 0)
            {
                MessageBoxEx.Show("当前处理报告没有明细信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string err = "";                                 //错误信息参数.
            //string shipId = currentObject.SHIP_ID;       //取当前船舶Id
            string shipName = ShipInfoService.Instance.getObject(shipID, out err).SHIP_NAME;
            string applyDate = currentObject.FileDate.ToString("yyyy年MM");  //取申请日期.

            List<string> lstCols = new List<string>();                  //包含要在Excel锅炉水质处理报告上显示信息的列的名称.
            string fileId = currentObject.File_ID;                    //锅炉水质处理报告Id

            ////如果找到了相应的锅炉水质处理报告,则提示用户是否打开旧的.
            string fileName = "锅炉水质处理报告" + currentObject.FileDate.ToString("yyyy年MM");
            string fileid;
            if (FolderFileDbService.Instance.IfFolderHasTheFile(fileId, fileName + ".xls", out fileid))
            {
                if (MessageBoxEx.Show("找到了之前存储的锅炉水质处理报告文件" + fileName + ",是否要直接打开此文件?" +
                    "\r否：系统删除旧文件,以免存储多个锅炉水质处理报告的导出文件给其他人造成误导.", "系统提示", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ourFile ofile;

                    if (!FileDbService.Instance.GetAFileById(fileid, out ofile))
                    {
                        MessageBoxEx.Show("非常抱歉,没有成功获取此文档,下面将重新形成新文件", "系统提示");
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
                        "\r是,系统将覆盖当前文件.\r否,系统为新生成的文件添加一个随机后缀,让其不发生冲突.",
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
        public bool applyPrint(ReportBoilerwater obj, string path, out string err)
        {
            err = "";

            if (string.IsNullOrEmpty(path))
            {
                err = "传入的path参数无效.";
                return false;
            }

            if (obj == null || obj.IsWrong)
            {
                err = "获取锅炉水质处理报告的数据时出错,请确认选择了有效数据.\r更多错误信息请参考::" + err;
                return false;
            }
            //   obj.FillThisObject();

            WorkModelType model = WorkModelTypeService.Instance.getModelObject(currentObject.SHIP_ID, CommonPrintTableName.CTNOfBoilerWater, out err);
            if (model == null || model.IsWrong || model.ModelFile.Trim().Length == 0)
            {
                err = "获取锅炉水质处理报告的表格时出错,请管理员从模板管理模块导入相应的表格.\r更多错误信息请参考:" + err;
                return false;
            }

            FileInfo f = new FileInfo(path);
            if (f.Exists) f.Delete();

            string path2;
            //获取模板文件,并保存到指定位置;
            if (!filo.GetABlobById(model.ModelFile, f.Name, out path2))
            {
                err = "获取锅炉水质处理报告的表格时出错,可能是大文件库连接串有问题,或者大文件数据库本身出现问题.\r更多错误信息请参考:" + err;
                return false;
            }

            int rowIndexStart = 9;//开始行.

            OfficeOperation.Excel excel = new OfficeOperation.Excel();
            excel.OpenDocument(path2);

            //填充模板内容.
            string shipName = ShipInfoService.Instance.GetShipName(currentObject.SHIP_ID);
            excel.SetSingelCellValue(2, 3, shipName, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(3, 4, currentObject.BoilerCategory, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(8, 4, currentObject.BoilerAirPressure, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(11, 4, currentObject.BoilerWaterQuantity, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(13, 4, currentObject.FileDate.Year.ToString() + " 年" + currentObject.FileDate.Month.ToString() + "  月", XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(8, 7, currentObject.Medicine1, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(9, 7, currentObject.Medicine2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(10, 7, currentObject.Medicine3, XlHorizontalAlignment.xlLeft);

            DataTable dt = ReportBoilerwaterService.Instance.GetApplyDatas(currentObject.FileDate.ToString("yyyy.MM"), currentObject.SHIP_ID);

            int j = 0;
            int i = 0;
            for (; i < dt.Rows.Count; i++)
            {
                j = 0;

                ReportBoilerwater rowObject = ReportBoilerwaterService.Instance.GetMainDetail(dt.Rows[i]["FileDate"].ToString(), currentObject.SHIP_ID, out err);

                j = j + rowObject.FileDate.Day;

                excel.SetSingelCellValue(2, j + rowIndexStart, rowObject.PhenolphthaleinAlkalinity, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(3, j + rowIndexStart, rowObject.SaltAmount, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(4, j + rowIndexStart, rowObject.Hardness, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(5, j + rowIndexStart, rowObject.PHValue, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(6, j + rowIndexStart, rowObject.SewageOnAmount, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(7, j + rowIndexStart, rowObject.SewageNextAmount, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(8, j + rowIndexStart, rowObject.Medicine1Value, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(9, j + rowIndexStart, rowObject.Medicine2Value, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(10, j + rowIndexStart, rowObject.Medicine3Value, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(11, j + rowIndexStart, rowObject.CondensateLevel, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(12, j + rowIndexStart, rowObject.CondensateSilverNitrateDrops, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(13, j + rowIndexStart, rowObject.TankWaterLeverl, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(14, j + rowIndexStart, rowObject.TankWateSilverNitrateDrops, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(15, j + rowIndexStart, rowObject.Remarks, XlHorizontalAlignment.xlLeft);
            }

            if (currentObject.ExperimentOrHandlePersonName != null)
            {
                excel.SetSingelCellValue(6, 41, currentObject.ExperimentOrHandlePersonName, XlHorizontalAlignment.xlRight);
            }

            if (currentObject.ChiefEngineerName != null)
            {
                excel.SetSingelCellValue(13, 41, currentObject.ChiefEngineerName, XlHorizontalAlignment.xlLeft);
            }

            excel.SaveDocument(path2);
            excel.CloseDocument();
            Excel.release(excel.pt);

            File.Copy(path2, path);
            ourFile ofile;

            if (!BaseInfo.DataAccess.WorkModelTypeService.Instance.SetReport(CommonOperation.Enum.FileBoundingTypes.MEASUREREPORT, true, "锅炉水质处理", currentObject.File_ID,
                currentObject.FileDate, CommonOperation.ConstParameter.UserName, currentObject.SHIP_ID, model.ModelFile, f.FullName, out ofile, out err))
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