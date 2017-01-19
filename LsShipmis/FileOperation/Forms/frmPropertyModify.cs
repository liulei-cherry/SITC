using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FileOperationBase.FileServices;
using FileOperationBase.Services;
using CommonViewer.BaseControl;
namespace FileOperation.Forms
{
    public partial class frmPropertyModify : CommonViewer.BaseForm.FormBase
    {
        public frmPropertyModify()
        {
            InitializeComponent();
        }
        public ourFile file;

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //加载传递过来的文件对象.
        public void ShowFileInfo()
        {
            txtLabel.Text = file.ObjectLabel;
            txtOperator.Text = CommonOperation.ConstParameter.UserName;
            txtDate.Text = DateTime.Now.ToShortDateString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ourFile tmpFile;
            tmpFile = new ourFile();
            string err;

            clone(file, tmpFile);

            tmpFile.ObjectLabel = txtLabel.Text.Replace("'", "''");
            tmpFile.Creator = txtOperator.Text;
            tmpFile.CreateDate = Convert.ToDateTime(txtDate.Text);

            if (FileDbService.Instance.UpdateAFile(tmpFile, "", out err) == true)
            {
                file.ObjectLabel = txtLabel.Text.Replace("'", "''");
                file.Creator = txtOperator.Text;
                file.CreateDate = Convert.ToDateTime(txtDate.Text);
            }
            else
            {
                MessageBoxEx.Show(err, "修改文件属性出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }
        private void clone(ourFile source, ourFile target)
        {
            target.CreateDate = source.CreateDate;
            target.Creator = source.Creator;
            target.FileId = source.FileId;
            target.FileName = source.FileName;
            target.Object_con_blob = source.Object_con_blob;
            target.Object_id = source.Object_id;
            target.ObjectLabel = source.ObjectLabel;
            target.Preserve1 = source.Preserve1;
            target.Preserve2 = source.Preserve2;
            target.Version = source.Version;
            target.File_Type = source.File_Type;
            target.Ref_Fileid = source.Ref_Fileid;
            target.RefEquipment = source.RefEquipment;
            target.ShipId = source.ShipId;
            target.UpdateDate = source.UpdateDate;
        }
    }
}