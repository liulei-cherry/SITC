using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FileOperationBase.FileServices;
using FileOperationBase.Services;
using CommonOperation.Enum;
using BaseInfo.Objects;
using BaseInfo.DataAccess;
using CommonViewer.BaseControl;
namespace FileOperation.Forms
{
    public partial class frmFileBoundShow : CommonViewer.BaseForm.FormBase
    {
        public frmFileBoundShow()
        {
            InitializeComponent();
        }
        public ourFolder folder;
        public right oRight;
        private void frmFileBoundShow_Load(object sender, EventArgs e)
        {
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

            ourFolder tempfolder;
            tempfolder = FolderDbService.Instance.getOrCreateSubFolderByNameAndId(upFolder, folder.NodeName, folder.NodeId);
            if (tempfolder != null) folder = tempfolder;
            else return;
            ucFile.oright = oRight;
            ucFile.pnlBottom.Height = 0;
            ucFile.nodeId = folder.NodeId;
            ucFile.nodeName = folder.NodeName;
            ucFile.shipId = folder.ShipId;
            ucFile.LoadFile(folder.NodeId, folder.NodeName);
            ucFile.columnHeader1.Width = 180;
            ucFile.columnHeader2.Width = 60;
            ucFile.columnHeader3.Width = 100;

        }
    }
}