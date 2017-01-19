using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonOperation.Interfaces;
using CommonOperation.BaseClass;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using BaseInfo.Viewer;
using ShipCertification.DataObject;
using ShipCertification.Services;
using CommonViewer.BaseControl;

namespace ShipCertification.Viewer
{
    public partial class UcShipCertDepart : UserControl, IOneObjectViewer
    {
        #region 对象初始化
        ShipCertDepart theObject = new ShipCertDepart(); 
        public bool needRetrieve = false;
        #endregion

        public UcShipCertDepart()
        {
            InitializeComponent();           
        }

        #region IOneObjectViewer成员
        /// <summary>
        /// 获取当前所选数据的对象.
        /// </summary>
        /// <param name="toChangeData"></param>
        public void ChangeData(CommonClass toChangeData)
        {
            
            if (!toChangeData.EqualTo(theObject))
            {
                DirectlyChangeData(toChangeData);
            }
        } 
        public void DirectlyChangeData(CommonClass toChangeData)
        {
            resetValue((ShipCertDepart)toChangeData);
        }
 
        /// <summary>
        /// 清空.
        /// </summary>
        public void ClearData()
        {
            theObject = new ShipCertDepart();            
            txtDepartName.Text = "";
            txtDepartCountry.Text = "";
        }
        /// <summary>
        /// 把用户所输入数据存放到theObject属性中.
        /// </summary>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool SetObject(out string err)
        {
            err = "";
            if (!theObject.IsWrong)
            {
                theObject.SHIPCERTDEPARTNAME = txtDepartName.Text;
                theObject.COUNTRY = txtDepartCountry.Text;
            }
            return true;
        }
        public void SetCanEdit(bool canEdit)
        {  
            txtDepartName.ReadOnly = !canEdit;
            txtDepartCountry.ReadOnly = !canEdit;
        }
        #endregion

        /// <summary>
        /// 重置数据.
        /// </summary>
        private void resetValue(ShipCertDepart toResetObject)
        {
            if (toResetObject != null && !toResetObject.IsWrong)
            {
                txtDepartName.Text = toResetObject.SHIPCERTDEPARTNAME;
                txtDepartCountry.Text = toResetObject.COUNTRY;
                theObject = toResetObject;
            }
            else ClearData();
        }
      
        public bool  UpdateObject()
        {
            string err;
            if (!beforeSaveCheck(out err))
            {
                MessageBoxEx.Show(err);
                return false;
            }
            if (theObject.IsWrong)
            {                
                MessageBoxEx.Show("当前对象无效,不能保存!");
                return false;                
            }
            else
            {
                if (SetObject(out err))
                {
                    if (!theObject.Update(out err))
                    {
                        MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err);
                        return false;
                    }
                    else
                    {
                        needRetrieve = true;
                        MessageBoxEx.Show("保存成功");
                        return true;
                    }
                }
                else
                {
                    MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err);
                    return false;
                }

            }
        }
        /// <summary>
        /// save之前检验.
        /// </summary>
        /// <param name="err"></param>
        /// <returns></returns>
        private bool beforeSaveCheck(out string err)
        {
            if (string.IsNullOrEmpty(txtDepartName.Text))
            {
                err = "机构名称不允许为空";
                txtDepartName.Focus();
                return false;
            }
            else if (!ShipCertDepartService.Instance.HaveNotTheDepart(theObject.GetId(), txtDepartName.Text, txtDepartCountry.Text, out err))
            {
                return false;
            }
            else
            {
                err = "";
                return true;
            }
        }
        public void DeleteObject()
        {
            if (theObject.IsWrong || string.IsNullOrEmpty(theObject.GetId ()))
            {
                MessageBoxEx.Show("当前对象无效,不能删除!");
                return;
            }
            else
            {
                string err;
                DialogResult response = MessageBoxEx.Show("您确定要删除该条数据吗？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (response == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                if (ShipCertification.Services.ShipCertDepartService.Instance.deleteUnit(theObject.GetId(),out err))
                {
                    needRetrieve = true;
                    MessageBoxEx.Show("删除成功");
                }
                else
                {
                    MessageBoxEx.Show("当前对象删除失败,错误原因是:\n\n" + err);
                }
            }
        }        
    }
}
