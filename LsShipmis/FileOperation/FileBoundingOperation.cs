using System;
using System.Collections.Generic;
using System.Text;
using FileOperationBase.Services;
using FileOperation.Forms;
using System.Data;
using CommonOperation.Enum;
using FileOperationBase.FileServices;

namespace FileOperation
{
    public class FileBoundingOperation
    {
        private right oRight;               //设定对文档操作的权限.

        public right ORight
        {
            get { return oRight; }
        }
        private Object boundingObject;
        public Object BoundingObject
        {
            get { return boundingObject; }
        }

        private IFileBoundShow fileBoundShow;
        public IFileBoundShow FileBoundShow
        {
            get { return fileBoundShow; }
            set { fileBoundShow = value; }
        }

        /// <summary>
        /// 当前窗体的静态实例对象.
        /// </summary>
        private static FileBoundingOperation instance;
        /// <summary>
        /// 当前窗体的静态实例属性.
        /// </summary>
        public static FileBoundingOperation Instance
        {
            get
            {
                if (null == instance)
                {
                    FileBoundingOperation.instance = new FileBoundingOperation();
                }

                return FileBoundingOperation.instance;
            }
        }
         
        /// <summary>
        /// 文件绑定到对象ID
        /// 例子：FileOperation.FileBoundingOperation.Instance.FileBoundCheck("2131123123", "测试文件夹", 1, EnvironmentParm.ShipId);
        /// </summary>
        /// <param name="Id">当前对象(记录)的GUID</param>
        /// <param name="name">名称</param>
        /// <param name="type">FileBoundingTypes文件绑定类型</param>
        /// <param name="shipId">船舶ID</param>
        public void FileBoundCheck(string Id, string name, FileBoundingTypes type, string shipId)
        {
            SetFilePicture(Id);
            BoundFolderInfo(Id, name, (int)type, shipId);
        }

        /// <summary>
        /// 文件绑定到对象ID
        /// </summary>
        /// <param name="Id">当前对象(记录)的GUID</param>
        /// <param name="name">名称</param>
        /// <param name="type">FileBoundingTypes文件绑定类型</param>
        /// <param name="shipId">船舶ID</param>
        /// <param name="Right">权限</param>
        public void FileBoundCheck(string Id, string name, FileBoundingTypes type, string shipId, right Right)
        {
            oRight = Right;
            FileBoundCheck(Id, name, type, shipId);
        }

        /// <summary>
        /// 绑定GUID到文件夹.
        /// </summary>
        /// <param name="Id">当前对象(记录)的GUID</param>
        /// <param name="name">文件夹名称</param>
        /// <param name="type">FileBoundingTypes文件绑定类型</param>
        /// <param name="shipId">船舶ID</param>
        private void BoundFolderInfo(string Id, string name, int type, string shipId)
        {
            if (Id == null || Id.Length <= 0 || type <= 0)
            {
                boundingObject = null;
            }
            else
            {
                ourFolder folder = new ourFolder();
                folder.NodeId = Id;
                folder.Node_Type = (decimal)type;
                folder.NodeName = name;
                folder.ShipId = shipId;
                boundingObject = folder;
            }
        }

        /// <summary>
        /// 绑定文件到GUID（Id为空则解除绑定）.
        /// </summary>
        /// <param name="Id">对象的GUID</param>
        private void SetFilePicture(string Id)
        {
            if( fileBoundShow == null) return;

            DataTable dat = FolderFileDbService.Instance.GetFileByFolder(Id);

            if (dat != null && dat.Rows.Count > 0)
            {
                fileBoundShow.ChangeToFull();
            }
            else
            {
                fileBoundShow.ChangeToEmpty();
            }
        }

        /// <summary>
        /// 实现绑定文件.
        /// </summary>
        public void FileBoundOperation()
        {
            ourFolder theFolder = (ourFolder)boundingObject;
            if (theFolder == null)
                return;

            frmFileBoundShow frm = new frmFileBoundShow();
            frm.oRight = oRight;
            frm.folder = theFolder;
            frm.ShowDialog();
            SetFilePicture(theFolder.NodeId);
        } 
    }  
}
