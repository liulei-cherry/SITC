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
using System.Data;
using System.IO;
using System.Windows.Forms;
using CommonOperation.BaseClass;
using CommonViewer.BaseControlService;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
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
    public partial class FrmMechatronikMaintain : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmMechatronikMaintain instance = new FrmMechatronikMaintain();
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmMechatronikMaintain Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmMechatronikMaintain.instance = new FrmMechatronikMaintain();
                }
                return FrmMechatronikMaintain.instance;
            }
        }
        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmMechatronikMaintain()
        {
            InitializeComponent();
        }
        #endregion

        #region 窗体对象
        private ReportMechatronikMaintain currentObject; 
        bool isFirstLoadMain = true;
        #endregion

        #region 其它公共业务类
        static FileDbService filo = FileDbService.Instance;
        #endregion

        /// <summary>
        /// 主窗体加载.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMechatronikMaintain_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(false, "", true);
            loadMainData();
        }
        /// <summary>
        /// 加载dgv初始数据.
        /// </summary>
        public void loadMainData()
        {
            //获得船舶ID
            if (string.IsNullOrEmpty(ucShipSelect1.GetId())) return;
            string err = "";
            DataTable dtb;
            if (!ReportMechatronikMaintainService.Instance.GetInfoByYear(ucShipSelect1.GetId(), dateYear.Value, out dtb, out err))
            {
                MessageBoxEx.Show(err);
                return;
            }
            bindingSourceMain.DataSource = dtb;
            dgvMain.DataSource = bindingSourceMain;
            loadDataCol();
            if (dtb.Rows.Count == 0)
            {
                currentObject = null;// 没有对象则显示置空.
                this.showObject();
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
            //加载主列项.
            if (!isFirstLoadMain)
                return;
            Dictionary<string, string> dictColumns = new Dictionary<string, string>();
            //设置列标题.
            dictColumns.Add("VOYAGE", "航次");
            dictColumns.Add("REPORT_DATE", "日期");
            dictColumns.Add("BEGIN_DATE", "开始时间");
            dictColumns.Add("END_DATE", "结束时间");
            dgvMain.SetDgvGridColumns(dictColumns);
            dgvMain.LoadGridView("FrmMechatronikMaintain.dgvMain");
            isFirstLoadMain = false;
        }
        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            loadMainData();
        }
        private void dateYear_ValueChanged(object sender, EventArgs e)
        {
            loadMainData();
        }
        private void dgvMain_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvMain.CurrentRow != null && dgvMain.CurrentRow.Cells["REPORT_ID"].Value != null)
            {
                //string err = "";
                DataGridViewRow dr = dgvMain.CurrentRow;

                string objectFILE_DATE = "";
                if (DBNull.Value != dr.Cells["FILE_DATE"].Value && null != dr.Cells["FILE_DATE"].Value)
                    objectFILE_DATE = dr.Cells["FILE_DATE"].Value.ToString();
                string err;
                currentObject = ReportMechatronikMaintainService.Instance.getObject(dr.Cells["REPORT_ID"].Value.ToString(), out err);

                showObject();
            }
        }

        private void showObject()
        {
            if (currentObject != null)
            {
                txtVOYAGE.Text = currentObject.VOYAGE;
                txtBEGIN_DATE.Text = currentObject.BEGIN_DATE.ToString("yyyy/MM/dd");
                txtEND_DATE.Text = currentObject.END_DATE.ToString("yyyy/MM/dd");
                txtREPORT_DATE.Text = currentObject.REPORT_DATE.ToString("yyyy/MM/dd");
                txtCHUAN_ZHANG.Text = currentObject.CHUAN_ZHANG;
                txtLUN_JI_ZHANG.Text = currentObject.LUN_JI_ZHANG;
                txtDA_GUAN_LUN.Text = currentObject.DA_GUAN_LUN;
                txtER_GUAN_LUN.Text = currentObject.ER_GUAN_LUN;
                txtSAN_GUAN_LUN.Text = currentObject.SAN_GUAN_LUN;
                txtDIAN_JI_YUAN.Text = currentObject.DIAN_JI_YUAN;
                txtUSE_CONDITION.Text = currentObject.USE_CONDITION;
                txtUNDONE_PROJECT.Text = currentObject.UNDONE_PROJECT;
                txtPROBLEM.Text = currentObject.PROBLEM;
                txtTEMPORARY_PROJECT.Text = currentObject.TEMPORARY_PROJECT;
                txtVERIFY_SUGGESTION.Text = currentObject.VERIFY_SUGGESTION;
            }
            else
            {
                txtVOYAGE.Text = "";
                txtBEGIN_DATE.Text = "";
                txtEND_DATE.Text = "";
                txtREPORT_DATE.Text = "";
                txtCHUAN_ZHANG.Text = "";
                txtLUN_JI_ZHANG.Text = "";
                txtDA_GUAN_LUN.Text = "";
                txtER_GUAN_LUN.Text = "";
                txtSAN_GUAN_LUN.Text = "";
                txtDIAN_JI_YUAN.Text = "";
                txtUSE_CONDITION.Text = "";
                txtUNDONE_PROJECT.Text = "";
                txtPROBLEM.Text = "";
                txtTEMPORARY_PROJECT.Text = "";
                txtVERIFY_SUGGESTION.Text = "";
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
            ReportMechatronikMaintain currentObject = new ReportMechatronikMaintain();
            currentObject.SHIP_ID = ucShipSelect1.GetId();
            currentObject.REPORT_DATE = dateYear.Value;
            FrmMechatronikMaintainEdit frm = new FrmMechatronikMaintainEdit(currentObject);
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
            FrmMechatronikMaintainEdit frm = new FrmMechatronikMaintainEdit(currentObject);
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

            string err = "";                                 //错误信息参数.
            //string shipId = currentObject.SHIP_ID;       //取当前船舶Id
            string shipName = ucShipSelect1.GetText();
            string applyDate = currentObject.FILE_DATE.ToString("yyyy年MM");  //取申请日期.

            List<string> lstCols = new List<string>();                  //包含要在Excel报告上显示信息的列的名称.
            string fileId = currentObject.FILE_ID;                    //锅炉水质处理报告Id

            ////如果找到了相应的报告,则提示用户是否打开旧的.
            string fileName = "船舶机电设备维修保养月度报告" + currentObject.FILE_DATE.ToString("yyyy年MM");
            string fileid;
            if (FolderFileDbService.Instance.IfFolderHasTheFile(fileId, fileName + ".xls", out fileid))
            {
                if (MessageBoxEx.Show("找到了之前存储的报告文件" + fileName + ",是否要直接打开此文件?" +
                    "\r否：系统删除旧文件,以免存储多个报告的导出文件给其他人造成误导.", "系统提示", MessageBoxButtons.YesNo,
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
        public bool applyPrint(ReportMechatronikMaintain obj, string path, out string err)
        {
            err = "";

            if (string.IsNullOrEmpty(path))
            {
                err = "传入的path参数无效.";
                return false;
            }

            if (obj == null || obj.IsWrong)
            {
                err = "获取报告的数据时出错,请确认选择了有效数据.\r更多错误信息请参考::" + err;
                return false;
            }
            //   obj.FillThisObject();

            WorkModelType model = WorkModelTypeService.Instance.getModelObject(currentObject.SHIP_ID, CommonPrintTableName.CTNOfEquipmentMaintenance, out err);
            if (model == null || model.IsWrong || model.ModelFile.Trim().Length == 0)
            {
                err = "获取报告的表格时出错,请管理员从模板管理模块导入相应的表格.\r更多错误信息请参考:" + err;
                return false;
            }

            FileInfo f = new FileInfo(path);
            if (f.Exists) f.Delete();

            string path2;
            //获取模板文件,并保存到指定位置;
            if (!filo.GetABlobById(model.ModelFile, f.Name, out path2))
            {
                err = "获取报告的表格时出错,可能是大文件库连接串有问题,或者大文件数据库本身出现问题.\r更多错误信息请参考:" + err;
                return false;
            }

            OfficeOperation.Excel excel = new OfficeOperation.Excel();
            excel.OpenDocument(path2);
            //填充模板内容.
            string shipName = ShipInfoService.Instance.GetShipName(currentObject.SHIP_ID);
            excel.SetSingelCellValue(3, 6, shipName, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(5, 6, currentObject.VOYAGE, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(7, 6, currentObject.REPORT_DATE.ToString("yyyy/MM/dd"), XlHorizontalAlignment.xlLeft);
            string beginEndDate = "从" + currentObject.BEGIN_DATE.ToString("yyyy年MM月") + "至" + currentObject.END_DATE.ToString("yyyy年MM月");
            excel.SetSingelCellValue(8, 6, beginEndDate, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(3, 7, currentObject.CHUAN_ZHANG, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(7, 7, currentObject.DA_GUAN_LUN, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(10, 7, currentObject.SAN_GUAN_LUN, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(3, 8, currentObject.LUN_JI_ZHANG, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(7, 8, currentObject.ER_GUAN_LUN, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(10, 8, currentObject.DIAN_JI_YUAN, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(2, 10, currentObject.USE_CONDITION, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(11, 7, currentObject.UNDONE_PROJECT, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(11, 12, currentObject.PROBLEM, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(11, 17, currentObject.TEMPORARY_PROJECT, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(11, 22, currentObject.VERIFY_SUGGESTION, XlHorizontalAlignment.xlLeft);

            excel.SaveDocument(path2);
            excel.CloseDocument();
            Excel.release(excel.pt);

            File.Copy(path2, path);
            ourFile ofile;

            if (!BaseInfo.DataAccess.WorkModelTypeService.Instance.SetReport(CommonOperation.Enum.FileBoundingTypes.MEASUREREPORT, true, "锅炉水质处理", currentObject.FILE_ID,
                currentObject.FILE_DATE, CommonOperation.ConstParameter.UserName, currentObject.SHIP_ID, model.ModelFile, f.FullName, out ofile, out err))
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

        private void FrmMechatronikMaintain_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvMain.SaveGridView("FrmMechatronikMaintain.dgvMain");

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

    }

}