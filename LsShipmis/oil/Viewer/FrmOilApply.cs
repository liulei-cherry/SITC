/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：FrmOilApply.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011-08-01
 * 标    题：申请业务窗体
 * 功能描述：实现申请业务窗体上的相关功能
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using FileOperationBase.FileServices;
using FileOperationBase.Services;
using System.IO;
using CommonOperation.BaseClass;
using CommonOperation.Interfaces;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using CommonViewer.BaseControl;

using OfficeOperation;
using ShipMisZHJ_WorkFlow.Forms;
using ShipMisZHJ_WorkFlow.Services;
using ShipMisZHJ_WorkFlow.BusinessClasses;
//using ShipMisZHJ_Ship_Oil.Services;
using Oil.DataObject;
using Oil.Services;
using CommonViewer.BaseControlService;

namespace Oil.Viewer
{
    /// <summary>
    /// 申请业务窗体.
    /// </summary>
    public partial class FrmOilApply : CommonViewer.BaseForm.FormBase, IRemindViewState
    {

        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmOilApply instance = new FrmOilApply();
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmOilApply Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmOilApply.instance = new FrmOilApply();
                }
                return FrmOilApply.instance;
            }
        }
        #endregion

        #region 业务对象等


        private HOilApply currentObject;
        public HOilApply CurrentObject
        {
            get { return currentObject; }
            set
            {
                currentObject = value;
                showObject(currentObject);
                checkRight(currentObject);//控制审核按钮.
            }
        }

        private IDBOperation commonOpt = CommonOperation.Functions.InterfaceInstantiation.NewADBOperation();//定义一个公共类CommonOpt对象.
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;//权限代理业务类.
        private FormControlOption other = FormControlOption.Instance;
        private bool loaded = false;

        bool isFirstLoadMain = true;
        bool isFirstLoadSub = true;
        Dictionary<string, string> dictColumns = new Dictionary<string, string>();
        Dictionary<string, string> dictColumnsSub = new Dictionary<string, string>();

        static FileDbService filo = FileDbService.Instance;

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmOilApply()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOilApply_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(true, true);
            //查询条件默认为三个月的数据.
            if (dtpStartDate.Value > DateTime.Now.AddMonths(-3))
                dtpStartDate.Value = DateTime.Now.AddMonths(-3);
            dtpEndDate.Value = DateTime.Now;
            setRight();
            this.setComboBox();     //设置窗体所需的下拉列表框的数据源.

            this.WindowState = FormWindowState.Maximized;//窗体最大化.
            loaded = true;
            this.setBindingSource();//设置数据源.
            //加载主列项.
            if (isFirstLoadMain)
            {
                loadDataCol();
            }
            if (dgvMatApply.Rows.Count == 0) CurrentObject = null;// 没有对象则显示置空.

        }
        /// <summary>
        /// 设置船岸端界面功能按钮.
        /// </summary>
        private void setRight()
        {
            bdNgAddNewItem.Visible = !CommonOperation.ConstParameter.IsLandVersion && !CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS;
            bdNgDeleteItem.Visible = !CommonOperation.ConstParameter.IsLandVersion && !CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS;
            bdNgEditItem.Visible = !CommonOperation.ConstParameter.IsLandVersion && !CommonOperation.ConstParameter.LoginUserInfo.ISSHIPBOSS;
        }

        /// <summary>
        /// 设置信息的bindingSource数据源.
        /// </summary>
        private void setBindingSource()
        {
            if (!loaded) return;

            string shipId = ucShipSelect1.GetId();
            string startDate = dtpStartDate.Value.ToShortDateString();  //起始日期.
            string endDate = dtpEndDate.Value.AddDays(1).ToShortDateString();      //结束日期.
            string chkState = cboChkState.SelectedValue.ToString();     //审核状态.
            if (chkState == "全部")
                chkState = "";
            //取得申请信息的DataTable对象.
            DataTable dtb = HOilApplyService.Instance.GetApply(shipId, startDate, endDate, chkState);
            bindingSourceMain.DataSource = dtb;
            dgvMatApply.DataSource = bindingSourceMain;

            if (dtb.Rows.Count == 0)
            {
                CurrentObject = null;// 没有对象则置空.
                FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, "");
            }
        }
        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataCol()
        {
            dictColumns.Clear();
            dgvMatApply.LoadGridView("FrmOilApply.dgvMatApply");

            //设置列标题.
            dictColumns.Add("APPLY_DATE", "申请日期");
            dictColumns.Add("SUPPLY_DATE", "送船日期");
            dictColumns.Add("VOYAGE", "航次");
            dictColumns.Add("CNAME", "港口");
            dictColumns.Add("CHECKED", "审核状态");
            dictColumns.Add("post", "当前审核职务");
            dictColumns.Add("remark", "备注");
            if (CommonOperation.ConstParameter.IsLandVersion)
                dictColumns.Add("SHIP_NAME", "船舶");


            dgvMatApply.SetDgvGridColumns(dictColumns);
            isFirstLoadMain = false;
        }

        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataColSub()
        {
            dictColumnsSub.Clear();
            dgvMatApplyDetail.LoadGridView("FrmOilApply.dgvMatApplyDetail");

            //设置列标题.
            dictColumnsSub.Add("TRADEMARK", "牌号");
            dictColumnsSub.Add("NUM", "申请数量");
            dictColumnsSub.Add("THISMONTH_STORE", "上月库存数量");
            dictColumnsSub.Add("remark", "备注");

            dgvMatApplyDetail.SetDgvGridColumns(dictColumnsSub);
            isFirstLoadSub = false;
        }

        /// <summary>
        ///设置窗体上的需要绑定业务数据的下拉列表控件.
        /// </summary>
        private void setComboBox()
        {
            string err = "";

            //港口.
            DataTable dtb1 = PortInfoService.Instance.getInfo(out err);
            other.SetComboBoxValue(cobPort, dtb1);

            //审核类型.
            DataTable dtb2 = HOilService.Instance.getCheckType(out err);
            other.SetComboBoxValue(cboChkState, dtb2);
        }

        private void showObject(HOilApply tempObject)
        {
            if (tempObject != null && !tempObject.IsWrong)
            {
                dtpApplyDate.Value = tempObject.APPLY_DATE;
                dtpArriveDate.Value = tempObject.SUPPLY_DATE;
                cobPort.SelectedValue = tempObject.PORT_ID;
                txtVoyage.Text = tempObject.VOYAGE;

                txtCheckor.Text = tempObject.APPROVER;
                txtLeader.Text = tempObject.APPROVER2;
                txtLandChecker.Text = tempObject.CHECKED.Equals(2M) || tempObject.CHECKED.Equals(9M) ? "已审核" : "未审核";
                txtRemark.Text = tempObject.REMARK;
            }
            else
            {
                dtpApplyDate.Value = DateTime.Now;
                dtpArriveDate.Value = DateTime.Now;
                txtVoyage.Text = "";

                txtCheckor.Text = "";
                txtLeader.Text = "";
                txtLandChecker.Text = "";
                txtRemark.Text = "";
            }
        }

        private void checkRight(HOilApply tempObject)
        {
            if (tempObject != null)
            {
                btnCheck.Enabled = true;
                // 2 判断对象是否能被修改.
                bdNgEditItem.Enabled = (currentObject.CHECKED.Equals(0M)) ? true : false;

                // 3 判断对象是否能删除的状态.
                bdNgDeleteItem.Enabled = (currentObject.CHECKED.Equals(0M)) ? true : false;
            }
            else
            {
                //没有对象则不能显示审核按钮.
                btnCheck.Enabled = false;
                bdNgEditItem.Enabled = false;
                bdNgDeleteItem.Enabled = false;
            }
        }

        /// <summary>
        /// 申请单记录筛选.
        /// </summary>
        private void Search()
        {
            this.setBindingSource();
            //如果申请单没有记录，则申请单明细也不应该有数据.
            if (loaded && dgvMatApply.Rows.Count == 0)
            {
                this.setBindingSourceDetail("", "", DateTime.Now);
            }
        }

        /// <summary>
        /// 船舶.
        /// </summary>
        private void cboShip_SelectedValueChanged(object sender, EventArgs e)
        {
            this.Search();
        }

        /// <summary>
        /// 申请单记录筛选（在起始日期事件中执行）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStartDate_CloseUp(object sender, EventArgs e)
        {
            this.Search();
        }

        /// <summary>
        /// 申请单记录筛选（在结束日期事件中执行）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpEndDate_CloseUp(object sender, EventArgs e)
        {
            this.Search();
        }

        /// <summary>
        /// 申请单记录筛选（在审核状态事件中执行）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboChkState_SelectedValueChanged(object sender, EventArgs e)
        {
            this.Search();
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
        /// 当申请单信息网格行改变时，显示当前行的申请单明细信息.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMatApply_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string err = "";
                DataGridViewRow dr = dgvMatApply.Rows[e.RowIndex];

                string objectID = "";
                if (DBNull.Value != dr.Cells["APPLY_ID"].Value && null != dr.Cells["APPLY_ID"].Value)
                    objectID = dr.Cells["APPLY_ID"].Value.ToString();
                string SHIP_NAME = dr.Cells["SHIP_NAME"].Value.ToString();
                CurrentObject = HOilApplyService.Instance.getObject(objectID, out err);
                //加载申请明细.
                this.setBindingSourceDetail(CurrentObject.APPLY_ID, CurrentObject.SHIP_ID, CurrentObject.APPLY_DATE);
                FileOperation.FileBoundingOperation.Instance.FileBoundCheck(objectID, SHIP_NAME + "(" + currentObject.APPLY_DATE + ")",
                    CommonOperation.Enum.FileBoundingTypes.OILAPPLY, CurrentObject.SHIP_ID);
            }
        }

        /// <summary>
        /// 设置物料申请单明细信息的bindingSource数据源，每次查询的都是指定申请单的明细信息数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="materialApplyId">申请单信息Id</param>
        private void setBindingSourceDetail(string ApplyId, string shipID, DateTime applyDate)
        {
            DataTable dtb = HOilApplyDetailService.Instance.GetApplyDatas(ApplyId, shipID, applyDate);//取得申请单明细信息的DataTable对象.
            bindingSourceDetail.DataSource = dtb;                                  //申请明细信息的数据源设置.
            dgvMatApplyDetail.DataSource = bindingSourceDetail;
            //加载主列项.
            if (isFirstLoadSub)
            {
                loadDataColSub();
            }
        }

        private void bdNgPrintItem_Click(object sender, EventArgs e)
        {

            if (currentObject == null)
            {
                MessageBoxEx.Show("无可打印的信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgvMatApplyDetail.Rows.Count == 0)
            {
                MessageBoxEx.Show("当前申请单没有明细信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string err = "";                                 //错误信息参数.
            string shipId = currentObject.SHIP_ID;       //取当前船舶Id
            string shipName = ShipInfoService.Instance.getObject(shipId, out err).SHIP_NAME;
            string applyDate = currentObject.APPLY_DATE.ToShortDateString();  //取申请日期.

            List<string> lstCols = new List<string>();                  //包含要在Excel申请单上显示信息的列的名称.
            string applyId = currentObject.APPLY_ID;                    //申请单Id

            //如果找到了相应的申请单,则提示用户是否打开旧的.
            string fileName = "润滑油采购申请单" + currentObject.APPLY_DATE.ToLongDateString();
            string fileid;
            if (FolderFileDbService.Instance.IfFolderHasTheFile(applyId, fileName + ".xls", out fileid))
            {
                if (MessageBoxEx.Show("找到了之前形成的申请单文件" + fileName + ",是否要直接打开此文件?" +
                    "\r选择否,系统推荐您删除旧文件,以免形成多个申请单的导出文件给其他人造成误导.", "系统提示", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ourFile ofile;

                    if (!FileDbService.Instance.GetAFileById(fileid, out ofile))
                    {
                        MessageBoxEx.Show("非常抱歉,没有成功获取此文档,下面将重新形成新文件!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
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
                    if (!FolderFileDbService.Instance.DeleteAFile(applyId, fileid, out err))
                    {
                        MessageBoxEx.Show("删除旧文件失败:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
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
                    MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);

                }
            }

        }

        /// <summary>
        /// 打印输出.
        /// </summary>
        public bool applyPrint(HOilApply obj, string path, out string err)
        {
            err = "";

            if (string.IsNullOrEmpty(path))
            {
                err = "传入的path参数无效.";
                return false;
            }

            if (obj == null || obj.IsWrong)
            {
                err = "获取申请单的数据时出错,请确认选择了有效数据.\r更多错误信息请参考::" + err;
                return false;
            }
            //   obj.FillThisObject();

            WorkModelType model = WorkModelTypeService.Instance.getModelObject(obj.SHIP_ID, CommonPrintTableName.CTNOfOilApply, out err);
            if (model == null || model.IsWrong || model.ModelFile.Trim().Length == 0)
            {
                err = "获取润滑油申请单的表格时出错,请管理员从模板管理模块导入相应的表格.\r更多错误信息请参考:" + err;
                return false;
            }

            FileInfo f = new FileInfo(path);
            if (f.Exists) f.Delete();

            string path2;
            //获取模板文件,并保存到指定位置;
            if (!filo.GetABlobById(model.ModelFile, f.Name, out path2))
            {
                err = "获取润滑油申请单的表格时出错,可能是大文件库连接串有问题,或者大文件数据库本身出现问题.\r更多错误信息请参考:" + err;
                return false;
            }

            int rowIndexStart = 6;//开始行.

            OfficeOperation.Excel excel = new OfficeOperation.Excel();
            excel.OpenDocument(path2);

            //填充模板内容.
            string shipName = ShipInfoService.Instance.GetShipName(currentObject.SHIP_ID);
            string portName = PortInfoService.Instance.getObject(currentObject.PORT_ID, out err).CNAME;
            excel.SetSingelCellValue(2, 3, shipName, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(6, 3, currentObject.VOYAGE, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(2, 4, currentObject.APPLY_DATE.ToLongDateString(), XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(6, 4, currentObject.SUPPLY_DATE.ToLongDateString(), XlHorizontalAlignment.xlLeft);

            DataTable dt = HOilApplyDetailService.Instance.GetApplyDatas(currentObject.GetId(), currentObject.SHIP_ID, currentObject.APPLY_DATE);
            int i = 0;
            for (; i < dt.Rows.Count; i++)
            {
                excel.CopyRowToRow(i + rowIndexStart);

                HOilApplyDetail rowObject = HOilApplyDetailService.Instance.getObject(dt.Rows[i]["APPLY_DETAIL_ID"].ToString(), out err);

                excel.SetSingelCellValue(1, i + rowIndexStart, (i + 1).ToString(), XlHorizontalAlignment.xlCenter);
                excel.SetSingelCellValue(2, i + rowIndexStart, dt.Rows[i]["TRADEMARK"].ToString(), XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(3, i + rowIndexStart, "L", XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(4, i + rowIndexStart, dt.Rows[i]["NUM"].ToString(), XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(5, i + rowIndexStart, portName, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(6, i + rowIndexStart, dt.Rows[i]["REMARK"].ToString(), XlHorizontalAlignment.xlLeft);
            }

            excel.SetSingelCellValue(1, i + rowIndexStart + 1, currentObject.REMARK, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(2, i + rowIndexStart + 6, "轮机长", XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(3, i + rowIndexStart + 6, currentObject.APPROVER, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(5, i + rowIndexStart + 6, "船长", XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(6, i + rowIndexStart + 6, currentObject.APPROVER2, XlHorizontalAlignment.xlLeft);

            excel.SaveDocument(path2);
            excel.CloseDocument();
            Excel.release(excel.pt);

            File.Copy(path2, path);
            ourFile ofile;

            if (!BaseInfo.DataAccess.WorkModelTypeService.Instance.SetReport(CommonOperation.Enum.FileBoundingTypes.OILAPPLY, true, currentObject.VOYAGE, currentObject.GetId(),
                currentObject.APPLY_DATE, CommonOperation.ConstParameter.UserName, currentObject.SHIP_ID, model.ModelFile, f.FullName, out ofile, out err))
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
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterialApply_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;    //释放窗体实例变量.
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, "");
            dgvMatApplyDetail.SaveGridView("FrmOilApply.dgvMatApplyDetail");
            dgvMatApply.SaveGridView("FrmOilApply.dgvMatApply");
        }

        private void openform(int function)
        {
            if (dgvMatApply.CurrentRow != null)
            {
                FrmOilApplyEdit frm = new FrmOilApplyEdit(currentObject.GetId(), function);
                frm.ShowDialog();
                this.Search();
            }
        }

        /// <summary>
        /// 新加操作.
        /// </summary>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            if (!loaded) return;
            FrmOilApplyEdit frm = new FrmOilApplyEdit();
            frm.ShowDialog();
            this.Search();
        }

        /// <summary>
        /// 删除操作.
        /// </summary>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            if (currentObject != null)
            {
                //根据权限，只要能看到这条数据的，就可以对其进行操作不需要再次进行判断.
                //提醒是否级联删除其子数据.
                if (dgvMatApplyDetail.Rows.Count > 0)
                {
                    if (MessageBoxEx.Show("当前备件申请单存在明细数据，删除此信息时会同时删掉其明细数据，请确认您要删除此信息？！",
                        "警告", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        return;
                }

                if (HOilApplyService.Instance.deleteParentAndSub(currentObject.GetId(), out err))
                {
                    MessageBoxEx.Show("删除成功！", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBoxEx.Show(err, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                Search();
            }
        }

        /// <summary>
        /// 修改操作.
        /// </summary>
        private void bdNgEditItem_Click(object sender, EventArgs e)
        {
            if (currentObject != null)
            {
                openform(3);
            }

        }

        /// <summary>
        /// 审核操作.
        /// </summary>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (currentObject == null)
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            }

            //审核通过后(最终通过)，如果是机务主管或机务经理.
            if ("机务主管岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME) ||
                "机务经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
            {
                //弹出窗体
                string err = "";
                FrmOilAudit frmAudit = new FrmOilAudit(currentObject.APPLY_ID);
                frmAudit.MaximizeBox = false;
                frmAudit.ShowDialog();
                if (frmAudit.IsArgee == 1)
                {
                    currentObject = HOilApplyService.Instance.getObject(currentObject.APPLY_ID, out err);
                    currentObject.CHECKED = 2;
                    currentObject.Update(out err);
                    T_WorkFlowService.Instance.AgreeBusiness(currentObject.SHIP_ID, currentObject.GetId(), "海丰润滑油申请", true, out err);
                    RemindService.Instance.CreateRemindOnce(6, currentObject.SHIP_ID, currentObject.APPLY_ID);
                } 
                this.Search();//刷新列表和状态.
            }
            else
            {

                FrmCheck frm = new FrmCheck(HOilApplyService.Instance.GetOilApplyCheckObjByOilApplyId(currentObject.GetId()), 1);
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.Yes)
                {
                    string err = "";
                    //审核通过后，如果是轮机长，则更新报表数据.
                    if ("轮机长".Equals(CommonOperation.ConstParameter.LoginUserInfo.ShipHeadShipName))
                    {
                        currentObject.APPROVER = CommonOperation.ConstParameter.UserName;
                        currentObject.Update(out err);
                    }
                    //审核通过后，如果是船长，则更新报表数据.

                    if ("船长".Equals(CommonOperation.ConstParameter.LoginUserInfo.ShipHeadShipName))
                    {
                        currentObject.APPROVER2 = CommonOperation.ConstParameter.UserName;
                        currentObject.Update(out err);
                    } 
                    this.Search();//刷新列表和状态.
                }
                else if (frm.DialogResult == DialogResult.No)
                {
                    string err = "";
                    currentObject.CHECKED = 0M;
                    currentObject.Update(out err);
                    this.Search();//刷新列表和状态.
                }
            }
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            this.Search();
        }

        private void dgvMatApply_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (currentObject != null && currentObject.CHECKED == 0M)
            {
                openform(3);
            }
        }


        public void SetRemindViewApprovalState()
        {
            if (CommonOperation.ConstParameter.IsLandVersion)
                ucShipSelect1.SelectedText("所有船");
            cboChkState.Text = "审核中";
            Search();
        }

        public void SetRemindViewInformState()
        {
            if (CommonOperation.ConstParameter.IsLandVersion)
                ucShipSelect1.SelectedText("所有船");
            cboChkState.Text = "已批准";
            Search();
        }
    }
}
