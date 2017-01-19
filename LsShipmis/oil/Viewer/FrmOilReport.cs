/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：夏喜龙
 * 创建时间：2011-5-12
 * 功能描述：实际发生费用的管理
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
using FileOperationBase.FileServices;
using FileOperationBase.Services;
using OfficeOperation;
using System.Runtime.InteropServices;
using Oil.DataObject;
using Oil.Services;
using Oil.Viewer;
using CommonViewer.BaseControl;

namespace Oil.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    /// 
    public partial class FrmOilReport : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型


        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmOilReport instance = new FrmOilReport();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmOilReport Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmOilReport.instance = new FrmOilReport();
                }
                return FrmOilReport.instance;
            }
        }
        #endregion

        #region 窗体对象

        private HOilReport currentObject;
        public HOilReport CurrentObject
        {
            get { return currentObject; }
            set
            {
                currentObject = value;
                showObject();
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
        bool isFirstLoadSub2 = true;
        bool isFirstLoadSub3 = true;
        Dictionary<string, string> dictColumns = new Dictionary<string, string>();
        Dictionary<string, string> dictColumnsSub = new Dictionary<string, string>();
        Dictionary<string, string> dictColumnsSub2 = new Dictionary<string, string>();
        Dictionary<string, string> dictColumnsSub3 = new Dictionary<string, string>();
        #endregion

        #region 其它公共业务类


        private FormControlOption other = FormControlOption.Instance;
        static FileDbService filo = FileDbService.Instance;

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmOilReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOilReport_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(false, true);
            dateYear.Value = DateTime.Today;
            loadMainData();

            setRight();//设置船岸端按钮权限.
        }

        /// <summary>
        /// 设置船岸端界面功能按钮.
        /// </summary>
        private void setRight()
        {
            // HOIL_OPERATION
            AddButton.Visible = !CommonOperation.ConstParameter.IsLandVersion;
        }

        /// <summary>
        /// 主窗体关闭.
        /// </summary>
        private void FrmOilReport_FormClosing(object sender, FormClosedEventArgs e)
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
        /// 加载主数据.
        /// </summary>
        public void loadMainData()
        {

            shipID = ucShipSelect1.GetId();
            if (string.IsNullOrEmpty(shipID)) return;

            string err = "";
            YearMonth = new DateTime(dateYear.Value.Year, 1, 1);

            DataTable dtb = HOilReportService.Instance.getInfoByYear(shipID, yearMonth, out err);
            dgvMain.DataSource = dtb;

            //加载主列项.
            if (isFirstLoadMain)
            {
                loadDataCol();
            }

            if (dtb.Rows.Count == 0)
            {
                CurrentObject = null;// 没有对象则显示置空.
                if (dgvDetail.DataSource != null)
                {
                    DataTable dt = (DataTable)dgvDetail.DataSource;
                    dt.Rows.Clear();
                }
                if (dgvDetail2.DataSource != null)
                {
                    DataTable dt = (DataTable)dgvDetail2.DataSource;
                    dt.Rows.Clear();
                }
                if (dgvDetail3.DataSource != null)
                {
                    DataTable dt = (DataTable)dgvDetail3.DataSource;
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
            dgvMain.LoadGridView("FrmOilReport.dgvMain");
            //设置列标题.
            dictColumns.Add("REPORT_DATE", "报告月份");
            dictColumns.Add("WLEFT_AMOUNT", "重油数量(吨)");
            dictColumns.Add("LLEFT_AMOUNT", "轻油数量(吨)");
            dictColumns.Add("SAIL_DAY", "本月航行时间");

            dgvMain.SetDgvGridColumns(dictColumns);
            isFirstLoadMain = false;
        }

        private void dateYear_ValueChanged(object sender, EventArgs e)
        {
            date1.MinDate = new DateTime(1753, 1, 1);
            date1.MaxDate = new DateTime(9998, 12, 31);
            date1.MinDate = new DateTime(dateYear.Value.Year, 1, 1);
            date1.MaxDate = new DateTime(dateYear.Value.Year, 12, 31);
            loadMainData();
        }

        private void dgvMain_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string err = "";
                DataGridViewRow dr = dgvMain.Rows[e.RowIndex];

                string objectID = "";
                if (DBNull.Value != dr.Cells["REPORT_ID"].Value && null != dr.Cells["REPORT_ID"].Value)
                    objectID = dr.Cells["REPORT_ID"].Value.ToString();

                CurrentObject = HOilReportService.Instance.getObject(objectID, out err);

                //加载明细.
                this.loadSubData(currentObject.SHIP_ID, currentObject.REPORT_DATE, out err);

            }
        }

        /// <summary>
        /// 加载明细信息数据.
        /// </summary>
        private void loadSubData(string ship_id, DateTime yearMonth, out string err)
        {
            //加油列表.
            DataTable dtb2 = HOilAddService.Instance.getInfoByMonth(ship_id, yearMonth, out err);
            dgvDetail2.DataSource = dtb2;
            //加载主列项.
            if (isFirstLoadSub2)
            {
                loadDataColSub2();
            }

            //消耗列表.
            DataTable dtb3 = HOilConsumeService.Instance.getInfoByMonth(ship_id, yearMonth, out err);
            dgvDetail3.DataSource = dtb3;
            //加载主列项.
            if (isFirstLoadSub3)
            {
                loadDataColSub3();
            }

            //滑油列表.
            DataTable dtb = HOilLuboilConsumeService.Instance.getMainInfoByYearMonth(ship_id, yearMonth, out err);
            dgvDetail.DataSource = dtb;
            //加载主列项.
            if (isFirstLoadSub)
            {
                loadDataColSub();
            }
        }

        /// <summary>
        /// 设置子列项.
        /// </summary>
        private void loadDataColSub()
        {
            dictColumnsSub.Clear();
            dgvDetail.LoadGridView("FrmOilReport.dgvDetail");
            //设置列标题.
            dictColumnsSub.Add("ForWhichType", "类别");
            dictColumnsSub.Add("TRADEMARK", "牌号");
            dictColumnsSub.Add("LASTMONTH_LEFT", "上月结存");
            dictColumnsSub.Add("THISMONTH_ADD", "本月增加");
            dictColumnsSub.Add("THISMONTH_CONSUME", "本月消耗");
            dictColumnsSub.Add("THISMONTH_STORE", "本月末库存");

            dgvDetail.SetDgvGridColumns(dictColumnsSub);
            isFirstLoadSub = false;
        }

        /// <summary>
        /// 设置子列项2
        /// </summary>
        private void loadDataColSub2()
        {
            dictColumnsSub2.Clear();
            dgvDetail2.LoadGridView("FrmOilReport.dgvDetail2");
            //设置列标题.
            dictColumnsSub2.Add("ADD_DATE", "加油日期");
            dictColumnsSub2.Add("CNAME", "港口");
            dictColumnsSub2.Add("OIL_TYPE", "燃油类型");
            dictColumnsSub2.Add("SPECIFICATION", "规格型号");
            dictColumnsSub2.Add("AMOUNT", "数量(吨)");
            dictColumnsSub2.Add("SULPHUR", "含硫量(%)");
            dictColumnsSub2.Add("DENSITY", "比重(KG/L)");

            dgvDetail2.SetDgvGridColumns(dictColumnsSub2);
            isFirstLoadSub2 = false;
        }

        /// <summary>
        /// 设置子列项3
        /// </summary>
        private void loadDataColSub3()
        {
            dictColumnsSub3.Clear();
            dgvDetail3.LoadGridView("FrmOilReport.dgvDetail3");
            //设置列标题.
            dictColumnsSub3.Add("OIL_TYPE", "燃油类型");
            dictColumnsSub3.Add("CONSUME_TYPE", "燃油消耗类型");
            dictColumnsSub3.Add("SPECIFICATION", "规格型号");
            dictColumnsSub3.Add("AMOUNT", "数量(吨)");
            dictColumnsSub3.Add("SULPHUR", "含硫量(%)");
            dictColumnsSub3.Add("DENSITY", "比重(KG/L)");

            dgvDetail3.SetDgvGridColumns(dictColumnsSub3);
            isFirstLoadSub3 = false;
        }

        private void showObject()
        {
            if (currentObject != null)
            {
                date1.Value = currentObject.REPORT_DATE;
                dateStart.Value = currentObject.START_DATE;
                dateEnd.Value = currentObject.END_DATE;
                numDay.Value = currentObject.SAIL_DAY;
                numHour.Value = currentObject.SAIL_HOUR;
                txtSpec1.Text = currentObject.W_SPECIFICATION;
                txtSpec2.Text = currentObject.L_SPECIFICATION;
                numLeft1.Value = currentObject.WLEFT_AMOUNT;
                numLeft2.Value = currentObject.LLEFT_AMOUNT;
                numSu1.Value = currentObject.W_SULPHUR;
                numSu2.Value = currentObject.L_SULPHUR;
                numDen1.Value = currentObject.W_DENSITY;
                numDen2.Value = currentObject.L_DENSITY;
            }
            else
            {
                numDay.Value = 0;
                numHour.Value = 0;
                txtSpec1.Text = "";
                txtSpec2.Text = "";
                numLeft1.Value = 0;
                numLeft2.Value = 0;
                numSu1.Value = 0;
                numSu2.Value = 0;
                numDen1.Value = 0;
                numDen2.Value = 0;
            }
        }

        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(shipID)) return;
            DateTime date = new DateTime(dateYear.Value.Year, DateTime.Today.Month, DateTime.Today.Day);
            HOilReport tempObject = new HOilReport(null, shipID, date, date.AddMonths(1), date, "", "", 0M, 0M, 0M, "", 0M, 0M, 0M, 0, 0);
            FrmOilReportEdit formNew = new FrmOilReportEdit(tempObject);
            formNew.ShowDialog();

            //刷新列表.
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
                    MessageBoxEx.Show("删除成功!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
                    loadMainData();
                }
                else
                {
                    MessageBoxEx.Show("当前对象删除失败,错误原因是:\n\n" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBoxEx.Show("请先选择一条记录!", "警告", new MessageBoxButtons(), MessageBoxIcon.Warning);
            }

        }

        private bool check(out string err)
        {
            err = "";

            //if ("".Equals(cob3.Text))
            //{
            //    MessageBoxEx.Show("润滑油不能为空!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            return true;
        }

        public void FormToObject(out string err)
        {
            err = "";
            if (currentObject != null)
            {
                currentObject.REPORT_DATE = date1.Value;
                currentObject.START_DATE = dateStart.Value;
                currentObject.END_DATE = dateEnd.Value;
                currentObject.SAIL_DAY = decimal.ToInt32(numDay.Value);
                currentObject.SAIL_HOUR = decimal.ToInt32(numHour.Value);
                currentObject.W_SPECIFICATION = txtSpec1.Text;
                currentObject.L_SPECIFICATION = txtSpec2.Text;
                currentObject.WLEFT_AMOUNT = numLeft1.Value;
                currentObject.LLEFT_AMOUNT = numLeft2.Value;
                currentObject.W_SULPHUR = numSu1.Value;
                currentObject.L_SULPHUR = numSu2.Value;
                currentObject.W_DENSITY = numDen1.Value;
                currentObject.L_DENSITY = numDen2.Value;
            }

        }

        /// <summary>
        /// 保存操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {

            string err;

            if (currentObject != null)
            {
                if (!check(out err))
                {
                    return;
                }

                this.FormToObject(out err);      //从界面获取数据到对象中.

                //保存对象.
                if (!currentObject.Update(out err))
                {
                    MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBoxEx.Show("保存成功!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
                    //刷新列表.
                    loadMainData();
                }
            }
        }

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

        //打印报表.
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (currentObject == null)
            {
                MessageBoxEx.Show("无可打印的信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string err = "";                                 //错误信息参数.
            string shipId = currentObject.SHIP_ID;       //取当前船舶Id
            string shipName = ShipInfoService.Instance.getObject(shipId, out err).SHIP_NAME;
            string reportDate = currentObject.REPORT_DATE.ToShortDateString();  //取报告日期.
            string objectID = currentObject.REPORT_ID;                          //主对象ID

            List<string> lstCols = new List<string>();                  //包含要在Excel申请单上显示信息的列的名称.

            //如果找到了相应的申请单,则提示用户是否打开旧的.
            string fileName = "船舶燃、润油月度消耗报表" + currentObject.REPORT_DATE.ToLongDateString();
            string fileid;
            if (FolderFileDbService.Instance.IfFolderHasTheFile(objectID, fileName + ".xls", out fileid))
            {
                if (MessageBoxEx.Show("找到了之前形成的报告文件" + fileName + ",是否要直接打开此文件?" +
                    "\r选择否,系统推荐您删除旧文件,以免形成多个报告的导出文件给其他人造成误导.", "系统提示", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ourFile ofile;

                    if (!FileDbService.Instance.GetAFileById(fileid, out ofile))
                    {
                        MessageBoxEx.Show("非常抱歉,没有成功获取此文档,下面将重新形成新文件!", "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
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
                    if (!FolderFileDbService.Instance.DeleteAFile(objectID, fileid, out err))
                    {
                        MessageBoxEx.Show("删除旧文件失败" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
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

                if (!printOut(currentObject, path, out err))
                {
                    MessageBoxEx.Show(err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 打印输出.
        /// </summary>
        public bool printOut(HOilReport obj, string path, out string err)
        {
            err = "";

            if (string.IsNullOrEmpty(path))
            {
                err = "传入的path参数无效.";
                return false;
            }

            if (obj == null || obj.IsWrong)
            {
                err = "获取订购单的数据时出错,请确认选择了有效数据.\r更多错误信息请参考::" + err;
                return false;
            }

            WorkModelType model = WorkModelTypeService.Instance.getModelObject(obj.SHIP_ID, CommonPrintTableName.CTNOfHOilReport, out err);
            if (model == null || model.IsWrong || model.ModelFile.Trim().Length == 0)
            {
                err = "获取模板表格时出错,请管理员从模板管理模块导入相应的表格.\r更多错误信息请参考:" + err;
                return false;
            }

            FileInfo f = new FileInfo(path);
            if (f.Exists) f.Delete();

            string path2;
            //获取模板文件,并保存到指定位置;
            if (!filo.GetABlobById(model.ModelFile, f.Name, out path2))
            {
                err = "获取模板表格时出错,可能是大文件库连接串有问题,或者大文件数据库本身出现问题.\r更多错误信息请参考:" + err;
                return false;
            }

            OfficeOperation.Excel excel = new OfficeOperation.Excel();
            excel.OpenDocument(path2);

            //   string supplier = ManufacturerService.Instance.getObject(currentObject.SUPPLIER_ID, out err).MANUFACTURER_NAME;//供货商名称.
            //填充模板内容.
            //主信息.
            string shipName = ShipInfoService.Instance.GetShipName(currentObject.SHIP_ID);
            string startEndDate = "自" + currentObject.START_DATE.ToString("yyyy年MM月dd日") + "至" + currentObject.END_DATE.ToString("yyyy年MM月dd日");
            excel.SetSingelCellValue(1, 3, shipName + " 轮", XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(7, 3, startEndDate, XlHorizontalAlignment.xlLeft);



            //本月加油.
            DataTable dt = HOilAddService.Instance.getInfoByMonth(currentObject.SHIP_ID, currentObject.REPORT_DATE, out err);

            int rowNum = 8;
            decimal WSum = 0M;//重油合计.
            decimal LSum = 0M;//轻油合计.
            string lastPort = "";
            int i = 0;
            DateTime lastDate = new DateTime(1900, 1, 1);

            for (; i < dt.Rows.Count; i++)
            {
                HOilAdd rowObject = HOilAddService.Instance.getObject(dt.Rows[i]["FUEL_ID"].ToString(), out err);

                if (i > 1 && (lastDate.Date != rowObject.ADD_DATE.Date || lastPort != dt.Rows[i]["CNAME"].ToString()))
                {
                    rowNum = 9;
                }

                string port = (rowNum - 7).ToString() + ". " + rowObject.ADD_DATE.ToString("M月d日") + "在" + dt.Rows[i]["CNAME"].ToString() + "港";
                lastDate = rowObject.ADD_DATE;
                lastPort = dt.Rows[i]["CNAME"].ToString();
                excel.SetSingelCellValue(2, rowNum, port, XlHorizontalAlignment.xlCenter);

                int startX = 0;
                if ("A".Equals(rowObject.OIL_TYPE))//重油和轻油的合计.
                {
                    WSum += rowObject.AMOUNT;
                }
                else
                {
                    LSum += rowObject.AMOUNT;
                    startX = 4;
                }
                excel.SetSingelCellValue(5 + startX, rowNum, rowObject.SPECIFICATION, XlHorizontalAlignment.xlRight);
                excel.SetSingelCellValue(6 + startX, rowNum, rowObject.AMOUNT.ToString(), XlHorizontalAlignment.xlRight);
                excel.SetSingelCellValue(7 + startX, rowNum, rowObject.SULPHUR.ToString(), XlHorizontalAlignment.xlRight);
                excel.SetSingelCellValue(8 + startX, rowNum, rowObject.DENSITY.ToString(), XlHorizontalAlignment.xlRight);
            }

            excel.SetSingelCellValue(6, 10, WSum.ToString(), XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(10, 10, LSum.ToString(), XlHorizontalAlignment.xlRight);

            //本月消耗.
            decimal WSum2 = 0M;//重油合计.
            decimal LSum2 = 0M;//轻油合计.
            HOilConsume a = HOilConsumeService.Instance.getObjectByMonth(currentObject.SHIP_ID, currentObject.REPORT_DATE, "A", "A", out err);
            if (a != null)
            {
                excel.SetSingelCellValue(5, 11, a.SPECIFICATION, XlHorizontalAlignment.xlRight);
                excel.SetSingelCellValue(6, 11, a.AMOUNT.ToString(), XlHorizontalAlignment.xlRight);
                excel.SetSingelCellValue(7, 11, a.SULPHUR.ToString(), XlHorizontalAlignment.xlRight);
                excel.SetSingelCellValue(8, 11, a.DENSITY.ToString(), XlHorizontalAlignment.xlRight);
                WSum2 += a.AMOUNT;
            }
            HOilConsume b = HOilConsumeService.Instance.getObjectByMonth(currentObject.SHIP_ID, currentObject.REPORT_DATE, "B", "A", out err);
            if (b != null)
            {
                excel.SetSingelCellValue(9, 12, b.SPECIFICATION, XlHorizontalAlignment.xlRight);
                excel.SetSingelCellValue(10, 12, b.AMOUNT.ToString(), XlHorizontalAlignment.xlRight);
                excel.SetSingelCellValue(11, 12, b.SULPHUR.ToString(), XlHorizontalAlignment.xlRight);
                excel.SetSingelCellValue(12, 12, b.DENSITY.ToString(), XlHorizontalAlignment.xlRight);
                LSum2 += b.AMOUNT;
            }
            HOilConsume c = HOilConsumeService.Instance.getObjectByMonth(currentObject.SHIP_ID, currentObject.REPORT_DATE, "A", "B", out err);
            if (c != null)
            {
                excel.SetSingelCellValue(5, 13, c.SPECIFICATION, XlHorizontalAlignment.xlRight);
                excel.SetSingelCellValue(6, 13, c.AMOUNT.ToString(), XlHorizontalAlignment.xlRight);
                excel.SetSingelCellValue(7, 13, c.SULPHUR.ToString(), XlHorizontalAlignment.xlRight);
                excel.SetSingelCellValue(8, 13, c.DENSITY.ToString(), XlHorizontalAlignment.xlRight);
                WSum2 += c.AMOUNT;
            }
            HOilConsume d = HOilConsumeService.Instance.getObjectByMonth(currentObject.SHIP_ID, currentObject.REPORT_DATE, "B", "B", out err);
            if (d != null)
            {
                excel.SetSingelCellValue(9, 14, d.SPECIFICATION, XlHorizontalAlignment.xlRight);
                excel.SetSingelCellValue(10, 14, d.AMOUNT.ToString(), XlHorizontalAlignment.xlRight);
                excel.SetSingelCellValue(11, 14, d.SULPHUR.ToString(), XlHorizontalAlignment.xlRight);
                excel.SetSingelCellValue(12, 14, d.DENSITY.ToString(), XlHorizontalAlignment.xlRight);
                LSum2 += d.AMOUNT;
            }
            HOilConsume e = HOilConsumeService.Instance.getObjectByMonth(currentObject.SHIP_ID, currentObject.REPORT_DATE, "A", "C", out err);
            if (e != null)
            {
                excel.SetSingelCellValue(5, 15, e.SPECIFICATION, XlHorizontalAlignment.xlRight);
                excel.SetSingelCellValue(6, 15, e.AMOUNT.ToString(), XlHorizontalAlignment.xlRight);
                excel.SetSingelCellValue(7, 15, e.SULPHUR.ToString(), XlHorizontalAlignment.xlRight);
                excel.SetSingelCellValue(8, 15, e.DENSITY.ToString(), XlHorizontalAlignment.xlRight);
                WSum2 += e.AMOUNT;
            }
            HOilConsume f1 = HOilConsumeService.Instance.getObjectByMonth(currentObject.SHIP_ID, currentObject.REPORT_DATE, "B", "C", out err);
            if (f1 != null)
            {
                excel.SetSingelCellValue(9, 16, f1.SPECIFICATION, XlHorizontalAlignment.xlRight);
                excel.SetSingelCellValue(10, 16, f1.AMOUNT.ToString().ToString(), XlHorizontalAlignment.xlRight);
                excel.SetSingelCellValue(11, 16, f1.SULPHUR.ToString().ToString(), XlHorizontalAlignment.xlRight);
                excel.SetSingelCellValue(12, 16, f1.DENSITY.ToString().ToString(), XlHorizontalAlignment.xlRight);
                LSum2 += f1.AMOUNT;
            }
            excel.SetSingelCellValue(6, 17, WSum2.ToString(), XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(10, 17, LSum2.ToString(), XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(6, 18, (currentObject.WLEFT_AMOUNT).ToString(), XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(10, 18, (currentObject.LLEFT_AMOUNT).ToString(), XlHorizontalAlignment.xlRight);
            //上月末库存. xuzb 2014年8月15日 修改这里的计算公式，以前错误的，把当月库存当成了上月库存，算出数据非常大。
            excel.SetSingelCellValue(5, 7, currentObject.W_SPECIFICATION, XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(6, 7, (currentObject.WLEFT_AMOUNT - WSum + WSum2).ToString(), XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(7, 7, currentObject.W_SULPHUR.ToString(), XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(8, 7, currentObject.W_DENSITY.ToString(), XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(9, 7, currentObject.L_SPECIFICATION, XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(10, 7, (currentObject.LLEFT_AMOUNT - LSum + LSum2).ToString(), XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(11, 7, currentObject.L_SULPHUR.ToString(), XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(12, 7, currentObject.L_DENSITY.ToString(), XlHorizontalAlignment.xlRight);
            //本月航行时间.
            string date1 = "本月航行时间：" + currentObject.SAIL_DAY.ToString() + " 天" + currentObject.SAIL_HOUR.ToString() + " 小时";
            excel.SetSingelCellValue(1, 19, date1, XlHorizontalAlignment.xlLeft);

            //润滑油.
            int rowIndexStart = 21;//开始行.
            DataTable dt2 = HOilLuboilConsumeService.Instance.getMainInfoByYearMonth(currentObject.SHIP_ID, currentObject.REPORT_DATE, out err);
            i = 0;
            for (; i < dt2.Rows.Count; i++)
            {
                excel.SetSingelCellValue(2, i + rowIndexStart, dt2.Rows[i]["ForWhichType"].ToString(), XlHorizontalAlignment.xlCenter);
                excel.SetSingelCellValue(4, i + rowIndexStart, dt2.Rows[i]["TRADEMARK"].ToString(), XlHorizontalAlignment.xlCenter);
                excel.SetSingelCellValue(6, i + rowIndexStart, dt2.Rows[i]["LASTMONTH_LEFT"].ToString(), XlHorizontalAlignment.xlCenter);
                excel.SetSingelCellValue(8, i + rowIndexStart, dt2.Rows[i]["THISMONTH_ADD"].ToString(), XlHorizontalAlignment.xlCenter);
                excel.SetSingelCellValue(10, i + rowIndexStart, dt2.Rows[i]["THISMONTH_CONSUME"].ToString(), XlHorizontalAlignment.xlCenter);
                excel.SetSingelCellValue(12, i + rowIndexStart, dt2.Rows[i]["THISMONTH_STORE"].ToString(), XlHorizontalAlignment.xlCenter);
            }

            excel.SetSingelCellValue(8, 36, currentObject.REPORT_DATE.ToString("yyyy年MM月dd日"), XlHorizontalAlignment.xlCenter);

            excel.SaveDocument(path2);
            excel.CloseDocument();
            Excel.release(excel.pt);

            File.Copy(path2, path);
            ourFile ofile;

            if (!BaseInfo.DataAccess.WorkModelTypeService.Instance.SetReport(CommonOperation.Enum.FileBoundingTypes.MEASUREREPORT, true, currentObject.GetId(), currentObject.GetId(),
                currentObject.REPORT_DATE, CommonOperation.ConstParameter.UserName, currentObject.SHIP_ID, model.ModelFile, f.FullName, out ofile, out err))
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

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            loadMainData();
        }

        private void FrmOilReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvMain.SaveGridView("FrmOilReport.dgvMain");
            dgvDetail.SaveGridView("FrmOilReport.dgvDetail");
            dgvDetail2.SaveGridView("FrmOilReport.dgvDetail2");
            dgvDetail3.SaveGridView("FrmOilReport.dgvDetail3");
            instance = null;
        }

    }
}