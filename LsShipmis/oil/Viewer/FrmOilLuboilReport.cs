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
using CommonOperation.Functions;

namespace Oil.Viewer
{
    /// <summary>
    /// 船舶分类信息管理窗体.
    /// </summary>
    /// 
    public partial class FrmOilLuboilReport : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmOilLuboilReport instance = new FrmOilLuboilReport();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmOilLuboilReport Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmOilLuboilReport.instance = new FrmOilLuboilReport();
                }
                return FrmOilLuboilReport.instance;
            }
        }
        #endregion

        #region 窗体对象

        private HOilLuboilReport currentObject;
        public HOilLuboilReport CurrentObject
        {
            get { return currentObject; }
            set
            {
                currentObject = value;
                showObject();
                setRight(currentObject);
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
        static FileDbService filo = FileDbService.Instance;

        bool isFirstLoadMain = true;
        bool isFirstLoadSub = true;
        Dictionary<string, string> dictColumns = new Dictionary<string, string>();
        Dictionary<string, string> dictColumnsSub = new Dictionary<string, string>();

        #endregion

        #region 其它公共业务类

        private FormControlOption other = FormControlOption.Instance;
        Dictionary<string, string> discRate = new Dictionary<string, string>();

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmOilLuboilReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOilLuboilReport_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(false, true);
            dateYear.Value = DateTime.Today;
            loadMainData();

            setRight(currentObject);//设置船岸端按钮权限.

        }

        /// <summary>
        /// 设置船岸端界面功能按钮.
        /// </summary>
        private void setRight(HOilLuboilReport cuObject)
        {
            //设置船岸端按钮权限.

            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                //岸端权限.
                AddButton.Visible = false;
                deleteButton.Visible = false;
                SaveButton.Visible = false;
                btnShipCheck.Visible = false;

                //业务权限.
                bool sapRight = (cuObject != null && cuObject.CHECKED == 2M);
                btnBackToLand.Enabled = !sapRight;
                btnCheck.Enabled = !sapRight;
                btnReverse1.Enabled = sapRight;
            }
            else
            {
                //船端权限.
                btnReverse1.Visible = false;
                btnCheck.Visible = false;
                btnBackToLand.Visible = false;

                //业务权限.
                bool landRight = (cuObject != null && (cuObject.CHECKED == 1M || cuObject.CHECKED == 2M));

                btnShipCheck.Enabled = !landRight;
                deleteButton.Enabled = !landRight;
                SaveButton.Enabled = !landRight;
            }

        }

        private void FrmOilLuboilReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvMain.SaveGridView("FrmOilLuboilReport.dgvMain");
            dgvDetail.SaveGridView("FrmOilLuboilReport.dgvDetail");
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

            DataTable dtb = HOilLuboilReportService.Instance.getInfoByYear(shipID, yearMonth, out err);
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

            }
        }

        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataCol()
        {
            dictColumns.Clear();
            dgvMain.LoadGridView("FrmOilLuboilReport.dgvMain");
            //设置列标题.

            dictColumns.Add("REPORT_DATE", "报告月份");
            dictColumns.Add("REMARK", "备注");
            dictColumns.Add("APPROVER", "轮机长");
            dictColumns.Add("APPROVER2", "船长");
            dictColumns.Add("CHECKED", "状态");

            dgvMain.SetDgvGridColumns(dictColumns);
            isFirstLoadMain = false;
        }

        private void cboShip_SelectedValueChanged(object sender, EventArgs e)
        {
            loadMainData();
        }

        private void dateYear_ValueChanged(object sender, EventArgs e)
        {
            date1.MinDate = new DateTime(1753, 1, 1);
            date1.MaxDate = new DateTime(9998, 12, 31);
            date1.MinDate = new DateTime(dateYear.Value.Year, 1, 1);
            date1.MaxDate = new DateTime(dateYear.Value.Year, 12, 31,23,59,59);
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

                CurrentObject = HOilLuboilReportService.Instance.getObject(objectID, out err);

                //加载明细.
                this.loadSubData(currentObject.SHIP_ID, currentObject.REPORT_DATE, out err);
            }
        }

        /// <summary>
        /// 加载明细信息数据.
        /// </summary>
        private void loadSubData(string ship_id, DateTime yearMonth, out string err)
        {

            DataTable dtb = HOilLuboilConsumeService.Instance.getMainInfoByMonth(ship_id, yearMonth, true, out err);
            dgvDetail.DataSource = dtb;

            //加载主列项.
            if (isFirstLoadSub)
            {
                loadDataColSub();
            }
        }

        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataColSub()
        {
            dictColumnsSub.Clear();
            dgvDetail.LoadGridView("FrmOilLuboilReport.dgvDetail");
            //设置列标题.

            dictColumnsSub.Add("TRADEMARK", "润滑油牌号");
            dictColumnsSub.Add("LOIL_TYPE", "润滑油类型");
            dictColumnsSub.Add("LASTMONTH_LEFT", "上月结存");
            dictColumnsSub.Add("THISMONTH_ADD", "本月增加");
            dictColumnsSub.Add("THISMONTH_CONSUME", "本月消耗");
            dictColumnsSub.Add("THISMONTH_STORE", "本月末库存");

            dgvDetail.SetDgvGridColumns(dictColumnsSub);
            isFirstLoadSub = false;
        }

        private void showObject()
        {
            if (currentObject != null)
            {
                
                date1.Value = currentObject.REPORT_DATE;
                txtMan1.Text = currentObject.APPROVER;
                txtMan2.Text = currentObject.APPROVER2;
                txtRemark.Text = currentObject.REMARK;
            }
            else
            {
                txtMan1.Text = "";
                txtMan2.Text = "";
                txtRemark.Text = "";
            }
        }

        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            if (CommonOperation.ConstParameter.IsLandVersion || (!CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS
                && !(CommonOperation.ConstParameter.LoginUserInfo.ISSHIPHEADER && CommonOperation.ConstParameter.LoginUserInfo.ISMACHINEMAN)))
            {
                MessageBoxEx.Show("只有船舶端的船长和轮机长才可以添加滑油月报!",
                    "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime date = new DateTime(dateYear.Value.Year, DateTime.Today.Month, DateTime.Today.Day);
            HOilLuboilReport tempObject = new HOilLuboilReport(null, shipID, date, "", null, null, 0M);
            FrmOilLuboilReportEdit formNew = new FrmOilLuboilReportEdit(tempObject);
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
                currentObject.APPROVER = txtMan1.Text;
                currentObject.APPROVER2 = txtMan2.Text;
                currentObject.REMARK = txtRemark.Text;
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
                if (!HOilLuboilReportService.Instance.saveUnit(currentObject, out err))
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

        /// <summary>
        /// 打印功能.
        /// </summary>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (currentObject == null)
            {
                MessageBoxEx.Show("无可打印的信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgvDetail.Rows.Count == 0)
            {
                MessageBoxEx.Show("当前报表没有明细信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string err = "";                                 //错误信息参数.
            string shipId = currentObject.SHIP_ID;       //取当前船舶Id
            string shipName = ShipInfoService.Instance.getObject(shipId, out err).SHIP_NAME;
            string reportDate = currentObject.REPORT_DATE.ToShortDateString();  //取报表日期.

            List<string> lstCols = new List<string>();                  //包含要在Excel申请单上显示信息的列的名称.

            string objectID = currentObject.GetId();                     //b报表ID

            //如果找到了相应的申请单,则提示用户是否打开旧的.
            string fileName = "月度润滑油报表" + currentObject.REPORT_DATE.ToLongDateString();
            string fileid;
            if (FolderFileDbService.Instance.IfFolderHasTheFile(objectID, fileName + ".xls", out fileid))
            {
                if (MessageBoxEx.Show("找到了之前形成的报表文件" + fileName + ",是否要直接打开此文件?" +
                    "\r选择否,系统推荐您删除旧文件,以免形成多个申请单的导出文件给其他人造成误导.", "系统提示", MessageBoxButtons.YesNo,
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
        public bool printOut(HOilLuboilReport obj, string path, out string err)
        {
            err = "";

            if (string.IsNullOrEmpty(path))
            {
                err = "传入的path参数无效.";
                return false;
            }

            if (obj == null || obj.IsWrong)
            {
                err = "获取报表的数据时出错,请确认选择了有效数据.\r更多错误信息请参考::" + err;
                return false;
            }

            WorkModelType model = WorkModelTypeService.Instance.getModelObject(obj.SHIP_ID, CommonPrintTableName.CTNOfHLuboilOilReport, out err);
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

            int rowIndexStart = 5;//开始行.

            OfficeOperation.Excel excel = new OfficeOperation.Excel();
            excel.OpenDocument(path2);

            //填充模板内容.
            string shipName = ShipInfoService.Instance.GetShipName(currentObject.SHIP_ID);
            excel.SetSingelCellValue(1, 3, shipName, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(4, 3, currentObject.REPORT_DATE.ToString("yyyy年MM月"), XlHorizontalAlignment.xlLeft);

            DataTable dt = HOilLuboilConsumeService.Instance.getMainInfoByMonth(currentObject.SHIP_ID, currentObject.REPORT_DATE, false, out err);
            int i = 0;
            for (; i < dt.Rows.Count; i++)
            {
                excel.CopyRowToRow(i + rowIndexStart);

                excel.SetSingelCellValue(1, i + rowIndexStart, dt.Rows[i]["LOIL_TYPE"].ToString(), XlHorizontalAlignment.xlCenter);
                excel.SetSingelCellValue(2, i + rowIndexStart, dt.Rows[i]["LASTMONTH_LEFT"].ToString(), XlHorizontalAlignment.xlCenter);
                excel.SetSingelCellValue(3, i + rowIndexStart, dt.Rows[i]["THISMONTH_ADD"].ToString(), XlHorizontalAlignment.xlCenter);
                excel.SetSingelCellValue(4, i + rowIndexStart, dt.Rows[i]["THISMONTH_CONSUME"].ToString(), XlHorizontalAlignment.xlCenter);
                excel.SetSingelCellValue(5, i + rowIndexStart, dt.Rows[i]["THISMONTH_STORE"].ToString(), XlHorizontalAlignment.xlCenter);
            }

            excel.SetSingelCellValue(1, i + rowIndexStart + 1, currentObject.REMARK, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(1, i + rowIndexStart + 6, "船长:" + currentObject.APPROVER2, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(4, i + rowIndexStart + 6, "轮机长:" + currentObject.APPROVER, XlHorizontalAlignment.xlLeft);

            excel.SaveDocument(path2);
            excel.CloseDocument();
            Excel.release(excel.pt);

            File.Copy(path2, path);
            ourFile ofile;

            if (!BaseInfo.DataAccess.WorkModelTypeService.Instance.SetReport(CommonOperation.Enum.FileBoundingTypes.MEASUREREPORT, true, currentObject.REPORT_ID, currentObject.GetId(),
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

        /// <summary>
        /// 同步到SAP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSame_Click(object sender, EventArgs e)
        {
            string err = "";
            if (currentObject != null && currentObject.CHECKED == 1)
            {
                //生成同步数据.
                DataTable dtb;
                if (!HOilLuboilReportService.Instance.GetLubOilExpenseToSAP(currentObject.GetId(), out dtb, out err))
                {
                    MessageBoxEx.Show(err, "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtb.Rows.Count == 0)
                {
                    MessageBoxEx.Show("没有需要同步到SAP的润滑油油品!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
                }
                else
                {
                    if (Oil.OilConfig.createMessage != null && !Oil.OilConfig.createMessage(currentObject.SHIP_ID, currentObject.REPORT_DATE, currentObject.REPORT_DATE, currentObject.GetId(), dtb, "3", "3", out err))
                    {
                        MessageBoxEx.Show("将变化数据发送给SAP时发生错误,错误信息请参考:\r" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {

                        currentObject.CHECKED = 2;
                        if (!currentObject.Update(out err))
                        {
                            MessageBoxEx.Show(err, "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        MessageBoxEx.Show("确认并同步成功!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
                        loadMainData();
                    }
                }

            }
            else
            {
                MessageBoxEx.Show("当前记录未经过船端审核或者已经发送给SAP,不能进行当前操作!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 反冲账.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReverse_Click(object sender, EventArgs e)
        {
            string err = "";
            if (currentObject != null && currentObject.CHECKED == 2)
            {
                List<string> sqlList = new List<string>();
                int stateCode;
                if (!Oil.OilConfig.reverseAccount(currentObject.GetId(), sqlList, out stateCode, out err))
                {
                    MessageBoxEx.Show(err, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                currentObject.CHECKED = 1;
                sqlList.Add(currentObject.Update());
                if (!InterfaceInstantiation.NewADbAccess().ExecSql(sqlList, out err))
                {
                    MessageBoxEx.Show(err, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    if (stateCode == 0)
                        MessageBoxEx.Show("成功撤销上报SAP操作.");
                    else
                        MessageBoxEx.Show("此预算已经导入到SAP中,无法撤销,已经做SAP冲账处理.");
                    loadMainData();
                }
            }
            else
            {
                MessageBoxEx.Show("请先选择一条岸端审核通过的记录!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            loadMainData();
        }

        private void btnShipCheck_Click(object sender, EventArgs e)
        {
            string err = "";
            if (currentObject != null && currentObject.CHECKED == 0)
            {
                string captainName = PostService.Instance.GetShipCaptainName();
                string chiefEngineerName = PostService.Instance.GetShipChiefEngineer();
                if (string.IsNullOrEmpty(captainName) || string.IsNullOrEmpty(chiefEngineerName))
                {
                    MessageBoxEx.Show("未能获取本船的船长或轮机长的姓名,请管理员在用户岗位处进行设置后再进行此操作!",
                       "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataTable dt = (DataTable)dgvDetail.DataSource;

                if (dt.Rows.Count < 3)
                {
                    MessageBoxEx.Show("月度滑油报告应包含主机汽缸油、主机系统油、副机系统油三种油品,请在本月滑油消耗界面中填写相应的消耗记录");
                    return;
                }
                currentObject.CHECKED = 1;
                currentObject.APPROVER = chiefEngineerName;
                currentObject.APPROVER2 = captainName;
                if (!currentObject.Update(out err))
                {
                    MessageBoxEx.Show(err, "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                loadMainData();
            }
            else
            {
                MessageBoxEx.Show("请先选择一条船端未审核通过的记录!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBackToLand_Click(object sender, EventArgs e)
        {
            string err = "";
            if (currentObject != null && currentObject.CHECKED == 1)
            {
                currentObject.REMARK = txtRemark.Text;
                currentObject.CHECKED = 0;
                if (!currentObject.Update(out err))
                {
                    MessageBoxEx.Show(err, "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                loadMainData();
            }
            else
            {
                MessageBoxEx.Show("请先选择一条船端审核通过的记录!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}