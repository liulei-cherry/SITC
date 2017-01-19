using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer;
using Cost.Services;
using Cost.DataObject;
using CommonViewer.BaseControl;
using Repair.DataObject;
using Repair.Services;
using FileOperationBase.Services;
using CommonOperation.Enum;
using FileOperationBase.FileServices;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using FileOperation;

namespace Repair.Viewer
{
    public partial class FrmDockRepairRecord : CommonViewer.BaseForm.FormBase
    {
        #region 窗体单实例模型

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FrmDockRepairRecord instance = new FrmDockRepairRecord();

        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FrmDockRepairRecord Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmDockRepairRecord.instance = new FrmDockRepairRecord();
                }

                return FrmDockRepairRecord.instance;
            }
        }
        /// <summary>
        /// 构造函数.
        /// </summary>
        private FrmDockRepairRecord()
        {
            InitializeComponent();
        }
        #endregion
        private string lastCurrentID = "";
        private RepairDockRepair currentObj = null;
        private void FrmDockRepairRecord_Load(object sender, EventArgs e)
        {
            ucShipSelect1.ChangeSelectedState(true, true);
            dgvDockRepairRecord.DataSource = bdsDockRepairRecord;
            SetComboboxSource();
            SetBindingSource();
            SetDataGridView();
        }
        public void SetComboboxSource()
        {
            string lastSelectItem = cbxAnnual.Text;
            DataTable dt = RepairDockRepairService.Instance.GetAnnual(ucShipSelect1.GetId());
            DataRow dr = dt.NewRow();
            dr[0] = "全部";
            dt.Rows.InsertAt(dr, 0);
            cbxAnnual.DataSource = dt;
            if (!string.IsNullOrEmpty(lastSelectItem))
                if (dt.Select("REPAIR_ANNUAL='" + lastSelectItem + "'").Length > 0)
                    cbxAnnual.Text = lastSelectItem;
        }
        private void SetBindingSource()
        {
            string annual = "";
            if (cbxAnnual.SelectedValue != null && cbxAnnual.SelectedValue.ToString() != "全部")
                annual = cbxAnnual.SelectedValue.ToString();
            bdsDockRepairRecord.DataSource = RepairDockRepairService.Instance.GetInfo(ucShipSelect1.GetId(), annual);

            if (string.IsNullOrEmpty(ucShipSelect1.GetId()))
                bdsDockRepairRecord.Filter = ShipInfoService.Instance.GetOwnerShipFilter();
        }
        private void SetDataGridView()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("ship_name", "船舶");
            dic.Add("REPAIR_ANNUAL", "年度");
            dic.Add("REMARK", "备注");
            dgvDockRepairRecord.SetDgvGridColumns(dic);
            dgvDockRepairRecord.LoadGridView("FrmDockRepairRecord.dgvDockRepairRecord");
        }
        private void bdsDockRepairRecord_CurrentChanged(object sender, EventArgs e)
        {
            if (bdsDockRepairRecord.Current == null)
            {
                currentObj = null;
                return;
            }
            DataRowView drv = (DataRowView)bdsDockRepairRecord.Current;
            currentObj = RepairDockRepairService.Instance.getObject(drv.Row);
            string id = ((DataRowView)bdsDockRepairRecord.Current)["REPAIR_DOCKREPAIR_ID"].ToString();
            string ship_id = ((DataRowView)bdsDockRepairRecord.Current)["SHIP_ID"].ToString();
            string ship_name = ((DataRowView)bdsDockRepairRecord.Current)["ship_name"].ToString();
            string repair_annual = ((DataRowView)bdsDockRepairRecord.Current)["repair_annual"].ToString();

            FileBoundingOperation fbo = FileBoundingOperation.Instance;
            fbo.FileBoundCheck(id, ship_name + "/" + repair_annual + "年度厂修", CommonOperation.Enum.FileBoundingTypes.PROJECTMANAGE, ship_id);
            ourFolder theFolder = (ourFolder)fbo.BoundingObject;
            if (theFolder == null)
                return;
            ourFolder folder = theFolder;
            right oRight = fbo.ORight;
            FileBoundingTypes theType;
            try
            {
                theType = (FileBoundingTypes)folder.Node_Type;
            }
            catch
            {
                MessageBoxEx.Show("当前选中信息没有设置文件类型,运行态不应该出现此情况,请联系开发商处理此问题!");
                return;
            }
            ourFolder upFolder = FolderDbService.Instance.getFolderByFolderType((FileBoundingTypes)folder.Node_Type, folder.ShipId);
            if (upFolder == null)
            {
                string err;
                ShipInfo shipInfo = ShipInfoService.Instance.getObject(folder.ShipId, out err);
                //当时公司的,则初始化公司目录.
                if (shipInfo == null || shipInfo.IsWrong)
                {
                    if (!FolderDbService.Instance.InitFolders(null, null, out err))
                    {
                        throw new Exception(err);
                    }
                }
                //当是船舶的,则初始化指定船舶目录.
                else
                {
                    if (!FolderDbService.Instance.InitFolders(shipInfo.SHIP_NAME, folder.ShipId, out err))
                    {
                        throw new Exception(err);
                    }
                }
                upFolder = FolderDbService.Instance.getFolderByFolderType((FileBoundingTypes)folder.Node_Type, folder.ShipId);
                //初始化后还为空,则抛异常.
                if (upFolder == null) throw new Exception("开发态错误,未对类型" + ((FileBoundingTypes)folder.Node_Type).ToString() + "进行初始化设置!");
            }
            ourFolder tempfolder = FolderDbService.Instance.getOrCreateSubFolderByNameAndId(upFolder, folder.NodeName, folder.NodeId);
            if (tempfolder != null)
                folder = tempfolder;
            else
                return;
            ucFile1.oright = oRight;
            ucFile1.pnlBottom.Height = 0;
            ucFile1.nodeId = folder.NodeId;
            ucFile1.nodeName = folder.NodeName;
            ucFile1.shipId = folder.ShipId;
            ucFile1.LoadFile(folder.NodeId, folder.NodeName);
            ucFile1.columnHeader1.Width = 180;
            ucFile1.columnHeader2.Width = 60;
            ucFile1.columnHeader3.Width = 100;
        }
        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            SetComboboxSource();
            SetBindingSource();
        }
        private void cbxAnnual_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetBindingSource();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmDockRepairRecordEdit frm = new FrmDockRepairRecordEdit();
            frm.ShowDialog();
            SetComboboxSource();
            SetBindingSource();
        }
        /// <summary>
        /// 编辑修改.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (bdsDockRepairRecord.Current == null)
            {
                MessageBoxEx.Show("未选中任何行!");
            }
            lastCurrentID = currentObj.REPAIR_DOCKREPAIR_ID;
            FrmDockRepairRecordEdit frm = new FrmDockRepairRecordEdit(currentObj);
            frm.ShowDialog();
            SetComboboxSource();
            SetBindingSource();
            foreach (DataGridViewRow item in dgvDockRepairRecord.Rows)
            {
                if (item.Cells["REPAIR_DOCKREPAIR_ID"].Value.ToString() == lastCurrentID)
                {
                    dgvDockRepairRecord.CurrentCell = item.Cells["REPAIR_ANNUAL"];
                    break;
                }
            }
        }
        /// <summary>
        /// 删除.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (bdsDockRepairRecord.Current != null)
            {
                if (DialogResult.No == MessageBoxEx.Show("确认要删除该条信息吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    return;
                DataRowView drv = (DataRowView)bdsDockRepairRecord.Current;
                RepairDockRepairService.Instance.deleteUnit(drv["REPAIR_DOCKREPAIR_ID"].ToString());
                MessageBoxEx.Show("操作成功");
                SetBindingSource();
                SetComboboxSource();
            }
        }
        /// <summary>
        /// 正在关闭窗体.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDockRepairRecord_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvDockRepairRecord.SaveGridView("FrmDockRepairRecord.dgvDockRepairRecord");
            instance = null;
        }
        /// <summary>
        /// 关闭按钮.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
