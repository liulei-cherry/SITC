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
using Oil.DataObject;
using Oil.Services;
using CommonViewer.BaseControlService;
using CommonOperation.Functions;
using ShipMisZHJ_WorkFlow.Forms;
using ShipMisZHJ_WorkFlow.Services;
using ShipMisZHJ_WorkFlow.BusinessClasses;

namespace Oil.Viewer
{
    /// <summary>
    /// 申请业务窗体.
    /// </summary>
    public partial class FrmOilOrder : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型
        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmOilOrder instance = new FrmOilOrder();
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmOilOrder Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmOilOrder.instance = new FrmOilOrder();
                }
                return FrmOilOrder.instance;
            }
        }
        #endregion

        #region 业务对象等
        private string portName = "";
        private string portType = "";
        private string supplier = "";

        private HOilOrder currentObject;
        public HOilOrder CurrentObject
        {
            get { return currentObject; }
            set
            {
                currentObject = value;
                if (currentObject != null)
                {
                    showObject();
                    checkRight();//控制审核按钮.
                }
            }
        }

        private IDBOperation commonOpt = CommonOperation.Functions.InterfaceInstantiation.NewADBOperation();//定义一个公共类CommonOpt对象.
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;//权限代理业务类.
        private FormControlOption other = FormControlOption.Instance;
        private bool loaded = false;

        bool isFirstLoadMain = true;
        bool isFirstLoadSub = true;

        static FileDbService filo = FileDbService.Instance;

        #endregion

        /// <summary>
        /// 构造函数.
        /// </summary>
        public FrmOilOrder()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体启动时执行的一些操作.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOilOrder_Load(object sender, EventArgs e)
        {
            if ("总经理岗位".Equals(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME))
            {
                bdNgAddNewItem.Visible = false;
                bdNgEditItem.Visible = false;
                bdNgDeleteItem.Visible = false;
                btnEstimate.Visible = false;
                btnPrint.Visible = false;
            }

            dgvMatApplyDetail.DataSource = bindingSourceDetail;
            dgvMatApply.DataSource = bindingSourceMain;
            ucShipSelect1.ChangeSelectedState(true, true);
            //查询条件默认为三个月的数据.
            if (dtpStartDate.Value > DateTime.Now.AddMonths(-3)) dtpStartDate.Value = DateTime.Now.AddMonths(-3);
            dtpEndDate.Value = DateTime.Now.AddMonths(1);
            setRightIni();//设置权限.
            loaded = true;
            this.setBindingSource();//设置数据源.
            loadDataCol();
            if (dgvMatApply.Rows.Count == 0)
                CurrentObject = null;// 没有对象则显示置空.
        }

        /// <summary>
        /// 设置船岸端界面功能按钮(初始设定)
        /// </summary>
        private void setRightIni()
        {
            bdNgAddNewItem.Visible = CommonOperation.ConstParameter.IsLandVersion;
            bdNgDeleteItem.Visible = CommonOperation.ConstParameter.IsLandVersion;
            bdNgEditItem.Visible = CommonOperation.ConstParameter.IsLandVersion;
            btnEstimate.Visible = CommonOperation.ConstParameter.IsLandVersion;
            btnCheck.Visible = CommonOperation.ConstParameter.IsLandVersion;
            btnPrint.Visible = CommonOperation.ConstParameter.IsLandVersion;

        }

        /// <summary>
        /// 设置信息的bindingSource数据源.
        /// </summary>
        private void setBindingSource()
        {
            if (!loaded) return;
            string shipId = ucShipSelect1.GetId();
            string startDate = dtpStartDate.Value.ToShortDateString();  //起始日期.
            string endDate = dtpEndDate.Value.ToShortDateString();      //结束日期.
            //取得申请信息的DataTable对象.
            DataTable dtb = HOilOrderService.Instance.GetOrder(shipId, startDate, endDate);
            bindingSourceMain.DataSource = dtb;

            if (dtb.Rows.Count == 0)
                CurrentObject = null;// 没有对象则置空.
        }

        /// <summary>
        /// 设置主列项.
        /// </summary>
        private void loadDataCol()
        {
            if (!isFirstLoadMain) return;
            isFirstLoadMain = false;
            Dictionary<string, string> dictColumns = new Dictionary<string, string>();
            dictColumns.Add("ship_name", "船舶");
            dictColumns.Add("ORDER_DATE", "订购日期");
            dictColumns.Add("SUPPLY_DATE", "送船日期");
            dictColumns.Add("CNAME", "港口");
            dictColumns.Add("MANUFACTURER_NAME", "供应商");
            dictColumns.Add("CHECKED", "审核状态");
            dictColumns.Add("CURRENT_POSTID", "当前审核岗位");
            dictColumns.Add("remark", "备注");

            dgvMatApply.LoadGridView("FrmOilOrder.dgvMatApply", dictColumns);
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
                DataGridViewRow dr = dgvMatApply.Rows[e.RowIndex];

                string objectID = "";
                if (DBNull.Value != dr.Cells["ORDER_ID"].Value && null != dr.Cells["ORDER_ID"].Value)
                    objectID = dr.Cells["ORDER_ID"].Value.ToString();
                if (string.IsNullOrEmpty(objectID))
                    return;
                portName = dr.Cells["CNAME"].Value.ToString();
                supplier = dr.Cells["MANUFACTURER_NAME"].Value.ToString();
                portType = dr.Cells["Current_postID"].Value.ToString();
                CurrentObject = HOilOrderService.Instance.GetObject(objectID);
                //加载申请明细.
                this.setBindingSourceDetail(objectID);
            }
        }

        private void checkRight()
        {
            btnCheck.Enabled = (currentObject.CHECKED != 0);
            bdNgEditItem.Enabled = false;
            bdNgDeleteItem.Enabled = false;
            btnEstimate.Enabled = false;
            string postName = CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME;

            bdNgDeleteItem.Enabled = postName == "机务主管岗位" && (currentObject.CHECKED == 0 || currentObject.CHECKED == 2);
            if (currentObject.CHECKED == 0
                || (currentObject.CHECKED != 0 && postName == portType))
            {
                bdNgEditItem.Enabled = true;
            }
            if (currentObject != null)
            {
                if ((currentObject.CHECKED == 5 && (postName == "财务经理岗位")))
                    btnEstimate.Enabled = true;
            }
        }

        private void showObject()
        {
            if (currentObject != null)
            {
                dtpApplyDate.Value = currentObject.ORDER_DATE;
                dtpArriveDate.Value = currentObject.SUPPLY_DATE;
                txtPort.Text = portName;
                txtManufacturer.Text = supplier;

                txtLandChecker.Text = currentObject.APPROVER;
                txtRemark.Text = currentObject.REMARK;
            }
            else
            {
                dtpApplyDate.Value = DateTime.Now;
                dtpArriveDate.Value = DateTime.Now;
                txtLandChecker.Text = "";
                txtRemark.Text = "";
            }
        }

        /// <summary>
        /// 设置物料申请单明细信息的bindingSource数据源，每次查询的都是指定申请单的明细信息数据.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <param name="materielApplyId">申请单信息Id</param>
        private void setBindingSourceDetail(string OrderId)
        {
            DataTable dtb = HOilOrderDetailService.Instance.GetOrderDatas(OrderId);//取得订购单明细信息的DataTable对象.
            bindingSourceDetail.DataSource = dtb;                                  //订购明细信息的数据源设置.
            loadDataColSub();
        }

        /// <summary>
        /// 设置次列项.
        /// </summary>
        private void loadDataColSub()
        {
            if (!isFirstLoadSub) return;
            Dictionary<string, string> dictColumnsSub = new Dictionary<string, string>();
            //设置列标题.
            dictColumnsSub.Add("TRADEMARK", "牌号");
            dictColumnsSub.Add("NUM", "订购数量");
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                dictColumnsSub.Add("CURRENCYNAME", "币种");
                dictColumnsSub.Add("AMOUNT", "金额");
            }
            dgvMatApplyDetail.SetDgvGridColumns(dictColumnsSub);
            dgvMatApplyDetail.LoadGridView("FrmOilOrder.dgvMatApplyDetail");
            isFirstLoadSub = false;
        }

        /// <summary>
        /// 新加操作.
        /// </summary>
        private void bdNgAddNewItem_Click(object sender, EventArgs e)
        {
            string shipId = ucShipSelect1.GetId();
            if (string.IsNullOrEmpty(shipId))
            {
                MessageBoxEx.Show("请先选择船舶");
                return;
            }
            HOilOrder tempObject = new HOilOrder(null, null, shipId, "", DateTime.Now, DateTime.Now.AddMonths(1), null, null, "", 0M, "");

            FrmOilOrderEdit frm = new FrmOilOrderEdit(tempObject);
            frm.ShowDialog();
            this.Search();
        }

        /// <summary>
        /// 修改操作.
        /// </summary>
        private void bdNgEditItem_Click(object sender, EventArgs e)
        {
            if (currentObject != null)
            {
                FrmOilOrderEdit frm = new FrmOilOrderEdit(currentObject);
                frm.ShowDialog();
                this.Search();
            }

        }

        /// <summary>
        /// 删除操作.
        /// </summary>
        private void bdNgDeleteItem_Click(object sender, EventArgs e)
        {
            string err = ""; //错误信息参数.
            if (currentObject != null)
            {
                if (MessageBoxEx.Show("确认您要删除此信息？", "警告", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                    return;

                if (HOilOrderService.Instance.deleteParentAndSub(currentObject.GetId(), out err))
                {
                    MessageBoxEx.Show("删除成功！", "删除成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Search();
                }
                else
                {
                    MessageBoxEx.Show(err, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// 审核操作.
        /// </summary>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            string err = "";
            if (currentObject == null)
            {
                MessageBoxEx.Show("未选中任何行!");
                return;
            } 
            using (TransactionClass tc = new TransactionClass())
            {

                FrmCheck frm = new FrmCheck(HOilOrderService.Instance.GetOilOrderCheckObjByOilOrderId(currentObject.GetId()), 2);
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.Cancel) return;

                if (frm.Current_State == 1)
                {
                    currentObject.CHECKED = 1;
                }
                else if (frm.Current_State == 3)
                {
                    currentObject.CHECKED = 5;
                }
                else if (frm.Current_State == 2)
                {
                    currentObject.CHECKED = 2;
                }
                currentObject.Update(out err);
                tc.CommitTransaction();
            }
            this.Search();//刷新列表和状态.
        }

        /// <summary>
        /// 把预估同步到SAP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEstimate_Click(object sender, EventArgs e)
        {
            string err = "";
            if (currentObject != null)
            {
                DataTable dtb;
                if (!HOilOrderService.Instance.GetOrderExpenseToSAP(currentObject.GetId(), out dtb, out err))
                {
                    MessageBoxEx.Show(err, "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                List<string> sqlList = new List<string>();
                if (!Oil.OilConfig.createMessageSql(currentObject.SHIP_ID, currentObject.ORDER_DATE, currentObject.ORDER_DATE, currentObject.GetId(), dtb, "1", "3", sqlList, out err))
                {
                    MessageBoxEx.Show("将变化数据发送给SAP时发生错误,错误信息请参考:\r" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                    return;
                }
                MessageBoxEx.Show("操作成功!", "提示", new MessageBoxButtons(), MessageBoxIcon.Information);
                currentObject.CHECKED = 6;
                sqlList.Add(currentObject.UpdateSql());
                IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
                if (!dbAccess.ExecSql(sqlList, out err))
                {
                    MessageBoxEx.Show(err, "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                setBindingSource();
            }
            else
            {
                MessageBoxEx.Show("请先选择一条可同步的订单记录!", "警告提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// 打印功能.
        /// </summary>
        private void bdNgPrintItem_Click(object sender, EventArgs e)
        {

            if (currentObject == null)
            {
                MessageBoxEx.Show("无可打印的信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (dgvMatApplyDetail.Rows.Count == 0)
            {
                MessageBoxEx.Show("当前订购单没有明细信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string err = "";                                 //错误信息参数.
            string shipId = currentObject.SHIP_ID;       //取当前船舶Id
            string shipName = ShipInfoService.Instance.getObject(shipId, out err).SHIP_NAME;
            string orderDate = currentObject.ORDER_DATE.ToShortDateString();  //取订购日期.

            List<string> lstCols = new List<string>();                  //包含要在Excel申请单上显示信息的列的名称.
            string orderId = currentObject.ORDER_ID;                    //订购单Id

            //如果找到了相应的申请单,则提示用户是否打开旧的.
            string fileName = "润滑油订购单" + currentObject.ORDER_DATE.ToLongDateString();
            string fileid;
            if (FolderFileDbService.Instance.IfFolderHasTheFile(orderId, fileName + ".xls", out fileid))
            {
                if (MessageBoxEx.Show("找到了之前形成的订购单文件" + fileName + ",是否要直接打开此文件?" +
                    "\r选择否,系统推荐您删除旧文件,以免形成多个订购单的导出文件给其他人造成误导.", "系统提示", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    ourFile ofile;

                    if (!FileDbService.Instance.GetAFileById(fileid, out ofile))
                    {
                        MessageBoxEx.Show("非常抱歉,没有成功获取此文档,下面将重新形成新文件!", "系统提示", new MessageBoxButtons(), MessageBoxIcon.Warning);
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
                    if (!FolderFileDbService.Instance.DeleteAFile(orderId, fileid, out err))
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
                    MessageBoxEx.Show("操作失败,错误原因是:" + err, "错误", new MessageBoxButtons(), MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 打印输出.
        /// </summary>
        public bool printOut(HOilOrder obj, string path, out string err)
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

            WorkModelType model = WorkModelTypeService.Instance.getModelObject(obj.SHIP_ID, CommonPrintTableName.CTNOfOilOrder, out err);
            if (model == null || model.IsWrong || model.ModelFile.Trim().Length == 0)
            {
                err = "获取润滑油订购单的表格时出错,请管理员从模板管理模块导入相应的表格.\r更多错误信息请参考:" + err;
                return false;
            }

            FileInfo f = new FileInfo(path);
            if (f.Exists) f.Delete();

            string path2;
            //获取模板文件,并保存到指定位置;
            if (!filo.GetABlobById(model.ModelFile, f.Name, out path2))
            {
                err = "获取润滑油订购单的表格时出错,可能是大文件库连接串有问题,或者大文件数据库本身出现问题.\r更多错误信息请参考:" + err;
                return false;
            }

            int rowIndexStart = 6;//开始行.

            OfficeOperation.Excel excel = new OfficeOperation.Excel();
            excel.OpenDocument(path2);

            string supplier = ManufacturerService.Instance.getObject(currentObject.SUPPLIER_ID, out err).MANUFACTURER_NAME;//供货商名称.
            //填充模板内容.
            string shipName = ShipInfoService.Instance.GetShipName(currentObject.SHIP_ID);
            string portName = PortInfoService.Instance.getObject(currentObject.PORT_ID, out err).CNAME;
            excel.SetSingelCellValue(2, 3, shipName, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(6, 3, supplier, XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(2, 4, currentObject.ORDER_DATE.ToLongDateString(), XlHorizontalAlignment.xlLeft);
            excel.SetSingelCellValue(6, 4, currentObject.SUPPLY_DATE.ToLongDateString(), XlHorizontalAlignment.xlLeft);

            DataTable dt = HOilOrderDetailService.Instance.GetOrderDatas(currentObject.GetId());
            int i = 0;
            for (; i < dt.Rows.Count; i++)
            {
                excel.CopyRowToRow(i + rowIndexStart);

                HOilApplyDetail rowObject = HOilApplyDetailService.Instance.getObject(dt.Rows[i]["ORDER_DETAIL_ID"].ToString(), out err);

                excel.SetSingelCellValue(1, i + rowIndexStart, (i + 1).ToString(), XlHorizontalAlignment.xlCenter);
                excel.SetSingelCellValue(2, i + rowIndexStart, dt.Rows[i]["TRADEMARK"].ToString(), XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(3, i + rowIndexStart, "L", XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(4, i + rowIndexStart, dt.Rows[i]["NUM"].ToString(), XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(5, i + rowIndexStart, portName, XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(6, i + rowIndexStart, dt.Rows[i]["CURRENCYNAME"].ToString(), XlHorizontalAlignment.xlLeft);
                excel.SetSingelCellValue(7, i + rowIndexStart, dt.Rows[i]["AMOUNT"].ToString(), XlHorizontalAlignment.xlLeft);
            }

            excel.SetSingelCellValue(1, i + rowIndexStart + 1, currentObject.REMARK, XlHorizontalAlignment.xlLeft,XlVerticalAlignment.xlTop);
            excel.SetSingelCellValue(2, i + rowIndexStart + 6, "审批人:", XlHorizontalAlignment.xlRight);
            excel.SetSingelCellValue(3, i + rowIndexStart + 6, currentObject.APPROVER, XlHorizontalAlignment.xlLeft);

            excel.SaveDocument(path2);
            excel.CloseDocument();
            Excel.release(excel.pt);

            File.Copy(path2, path);
            ourFile ofile;

            if (!BaseInfo.DataAccess.WorkModelTypeService.Instance.SetReport(CommonOperation.Enum.FileBoundingTypes.OILAPPLY, true, currentObject.GetId(), currentObject.GetId(),
                currentObject.ORDER_DATE, CommonOperation.ConstParameter.UserName, currentObject.SHIP_ID, model.ModelFile, f.FullName, out ofile, out err))
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
        /// 申请单记录筛选.
        /// </summary>
        private void Search()
        {
            this.setBindingSource();
            //如果订购单没有记录，则订购单明细也不应该有数据.
            if (loaded && dgvMatApply.Rows.Count == 0)
            {
                this.setBindingSourceDetail("");
            }
        }

        /// <summary>
        /// 订购单记录筛选（在起始日期事件中执行）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStartDate_CloseUp(object sender, EventArgs e)
        {
            this.Search();
        }

        /// <summary>
        /// 订购单记录筛选（在结束日期事件中执行）.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpEndDate_CloseUp(object sender, EventArgs e)
        {
            this.Search();
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            this.Search();
        }

        /// <summary>
        /// 释放窗体实例变量.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmOilOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvMatApply.SaveGridView("FrmOilOrder.dgvMatApply");
            dgvMatApplyDetail.SaveGridView("FrmOilOrder.dgvMatApplyDetail");

            instance = null;    //释放窗体实例变量.
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
