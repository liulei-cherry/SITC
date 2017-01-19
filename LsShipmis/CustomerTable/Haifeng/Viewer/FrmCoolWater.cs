/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 创 建 人：黄家龙
 * 创建时间：2011-08-15
 * 功能描述：冷却水化验及处理
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
    public partial class FrmCoolWater : CommonViewer.BaseForm.BaseMdiChildForm
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmCoolWater instance = new FrmCoolWater();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmCoolWater Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmCoolWater.instance = new FrmCoolWater();
                }
                return FrmCoolWater.instance;
            }
        }

        #endregion

        #region 窗体对象

        private ReportCoolwater currentObject;
        public ReportCoolwater CurrentObject
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
        private FrmCoolWater()
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

            DataTable dtb = ReportCoolwaterService.Instance.getInfoByYear(shipID, yearMonth, out err);

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
            dictColumns.Add("ExperimentDealDate", "化验及处理日期");
            dictColumns.Add("Medcine", " 处理剂名称");
            dictColumns.Add("MainLinerConcentration", "主机缸套冷却水浓度");
            dictColumns.Add("MainLInerDosage", "主机缸套冷却水投药量");
            dictColumns.Add("MainPistonConcentration", "主机活塞冷却水浓度");
            dictColumns.Add("MainPistonDosage", "主机活塞冷却水投药量");
            dictColumns.Add("MainOilConcentration", "主机油头冷却水浓度");
            dictColumns.Add("MainOilDosage", "主机油头冷却水投药量");
            dictColumns.Add("SecondConcentration", "副机冷却水浓度");
            dictColumns.Add("SecondDosage", "副机冷却水投药量");
            dictColumns.Add("ExperimentDealSign", "化验及处理人签名");
            dictColumns.Add("ExperimentDealSignDate", "化验及处理人签名日期");
            dictColumns.Add("ChiefSign", "轮机长签名");
            dictColumns.Add("ChiefSignData", "轮机长签名日期");

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
                if (DBNull.Value != dr.Cells["Report_CoolWater_Id"].Value && null != dr.Cells["Report_CoolWater_Id"].Value)
                    objectId = dr.Cells["Report_CoolWater_Id"].Value.ToString();

                //初始化当前对象.
                CurrentObject = ReportCoolwaterService.Instance.getObject(objectId, out err);
            }
        }

        private void showObject(ReportCoolwater tempObject)
        {
            if (tempObject != null)
            {
                txtMedcine.Text = tempObject.Medcine;
                txtLinerConcentration.Text = tempObject.MainLinerConcentration;
                txtLInerDosage.Text = tempObject.MainLInerDosage;
                txtPistonConcentration.Text = tempObject.MainPistonConcentration;
                txtPistonDosage.Text = tempObject.MainPistonDosage;
                txtOilConcentration.Text = tempObject.MainOilConcentration;
                txtOilDosage.Text = tempObject.MainOilDosage;
                txtSecondConcentration.Text = tempObject.SecondConcentration;
                txtSecondDosage.Text = tempObject.SecondDosage;
                txtExperimentDealSign.Text = tempObject.ExperimentDealSign;

                if (tempObject.ExperimentDealSignDate.Equals(DateTime.MinValue))
                {
                    textExperimentDealSignDate.Text = "";
                }
                else
                {
                    textExperimentDealSignDate.Text = tempObject.ExperimentDealSignDate.ToString("yyyy/MM/dd");
                }
                txtChiefSign.Text = tempObject.ChiefSign;

                if (tempObject.ChiefSignData.Equals(DateTime.MinValue))
                {
                    txtChiefSignData.Text = "";
                }
                else
                {
                    txtChiefSignData.Text = tempObject.ChiefSignData.ToString("yyyy/MM/dd");
                }

                txtExperimentDealDate.Text = tempObject.ExperimentDealDate.ToString("yyyy/MM/dd");

            }
            else
            {
                txtMedcine.Text = "";
                txtLinerConcentration.Text = "";
                txtLInerDosage.Text = "";
                txtPistonConcentration.Text = "";
                txtPistonDosage.Text = "";
                txtOilConcentration.Text = "";
                txtOilDosage.Text = "";
                txtSecondConcentration.Text = "";
                txtSecondDosage.Text = "";
                txtExperimentDealSign.Text = "";
                textExperimentDealSignDate.Text = "";
                txtChiefSign.Text = "";
                txtChiefSignData.Text = "";
                txtExperimentDealDate.Text = "";
            }
        }

        /// <summary>
        /// 添加操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            CustomTable.Haifeng.Viewer.FrmEditCoolWater frm = new CustomTable.Haifeng.Viewer.FrmEditCoolWater(ShipID, null);
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
            CustomTable.Haifeng.Viewer.FrmEditCoolWater frm = new CustomTable.Haifeng.Viewer.FrmEditCoolWater(ShipID, CurrentObject);
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
            string applyDate = currentObject.ExperimentDealDate.ToString("yyyy.MM"); //取处理年月.

            string fileId = currentObject.File_ID;                    //冷却水化验及处理Id

            ////如果找到了相应的冷却水化验及处理,则提示用户是否打开旧的.
            string fileName = "冷却水化验及处理" + currentObject.ExperimentDealDate.ToString("yyyy年MM");
            string fileid;
            if (FolderFileDbService.Instance.IfFolderHasTheFile(fileId, fileName + ".xls", out fileid))
            {
                if (MessageBoxEx.Show("找到了之前形成的冷却水化验及处理文件" + fileName + ",是否要直接打开此文件?" +
                    "\r否,系统删除旧文件,以免形成多个冷却水化验及处理的导出文件给其他人造成误导.", "系统提示", MessageBoxButtons.YesNo,
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
                else//删除旧文件.
                {
                    if (!FolderFileDbService.Instance.DeleteAFile(fileId, fileid, out err))
                    {
                        MessageBoxEx.Show("删除旧文件失败"+err,"提示");
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
                        "\r是,系统将覆盖当前文件.\r否,系统为新生成的文件添加一个随机后缀,以免发生冲突.",
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
        public bool applyPrint(ReportCoolwater obj, string path, out string err)
        {
            err = "";

            if (string.IsNullOrEmpty(path))
            {
                err = "传入的path参数无效.";
                return false;
            }

            if (obj == null || obj.IsWrong)
            {
                err = "获取冷却水化验及处理的数据时出错,请确认选择了有效数据.\r更多错误信息请参考::" + err;
                return false;
            }
            //   obj.FillThisObject();

            WorkModelType model = WorkModelTypeService.Instance.getModelObject(obj.SHIP_ID, CommonPrintTableName.CTNOfCoolWater, out err);
            if (model == null || model.IsWrong || model.ModelFile.Trim().Length == 0)
            {
                err = "获取冷却水化验及处理的表格时出错,请管理员从模板管理模块导入相应的表格.\r更多错误信息请参考:" + err;
                return false;
            }

            FileInfo f = new FileInfo(path);
            if (f.Exists) f.Delete();

            string path2;
            //获取模板文件,并保存到指定位置;
            if (!filo.GetABlobById(model.ModelFile, f.Name, out path2))
            {
                err = "获取冷却水化验及处理的表格时出错,可能是大文件库连接串有问题,或者大文件数据库本身出现问题.\r更多错误信息请参考:" + err;
                return false;
            }

            int rowIndexStart = 8;//开始行.

            OfficeOperation.Excel excel = new OfficeOperation.Excel();
            excel.OpenDocument(path2);

            //填充模板内容.
            string shipName = ShipInfoService.Instance.GetShipName(obj.SHIP_ID);
            excel.SetSingelCellValue(3, 3, shipName, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(8, 3, obj.Medcine, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(10, 6, obj.ExperimentDealDate.Year.ToString() + " 年", XlHorizontalAlignment.xlRight);

            DataTable dt = ReportCoolwaterService.Instance.GetApplyDatas(obj.ExperimentDealDate.ToString("yyyy.MM"), obj.SHIP_ID);

            int i = 0;
            for (; i < dt.Rows.Count; i++)
            {
                ReportCoolwater rowObject = ReportCoolwaterService.Instance.GetMainDetail(dt.Rows[i]["ExperimentDealDate"].ToString(), obj.SHIP_ID, out err);

                excel.SetSingelCellValue(2, i + rowIndexStart, rowObject.MainLinerConcentration, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(3, i + rowIndexStart, rowObject.MainLInerDosage, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(4, i + rowIndexStart, rowObject.MainPistonConcentration, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(5, i + rowIndexStart, rowObject.MainPistonDosage, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(6, i + rowIndexStart, rowObject.MainOilConcentration, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(7, i + rowIndexStart, rowObject.MainOilDosage, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(8, i + rowIndexStart, rowObject.SecondConcentration, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(9, i + rowIndexStart, rowObject.SecondDosage, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(10, i + rowIndexStart, rowObject.ExperimentDealDate.Month.ToString() + " 月 " + rowObject.ExperimentDealDate.Day.ToString() + " 日 " , XlHorizontalAlignment.xlCenter);
            }

            if (obj.ExperimentDealSign != null &&!(obj.ExperimentDealSign.Length == 0))
            {
                excel.SetSingelCellValue(4, 37, obj.ExperimentDealSign + "  " + obj.ExperimentDealSignDate.Year.ToString() + "年 " + obj.ExperimentDealSignDate.Month.ToString() + "月 " + obj.ExperimentDealSignDate.Day.ToString() + "日", XlHorizontalAlignment.xlRight);
            }
            if (obj.ChiefSign != null && !(obj.ChiefSign.Length == 0))
            {
                excel.SetSingelCellValue(9, 37, obj.ChiefSign + "  " + obj.ChiefSignData.Year.ToString() + "年" + obj.ChiefSignData.Month.ToString() + " 月" + obj.ChiefSignData.Day.ToString() + " 日", XlHorizontalAlignment.xlRight);
            }
            
            excel.SaveDocument(path2);
            excel.CloseDocument();
            Excel.release(excel.pt);

            File.Copy(path2, path);
            ourFile ofile;

            if (!BaseInfo.DataAccess.WorkModelTypeService.Instance.SetReport(CommonOperation.Enum.FileBoundingTypes.MEASUREREPORT, true, "冷却水化验及处理", obj.File_ID,
                obj.ExperimentDealDate, CommonOperation.ConstParameter.UserName, obj.SHIP_ID, model.ModelFile, f.FullName, out ofile, out err))
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