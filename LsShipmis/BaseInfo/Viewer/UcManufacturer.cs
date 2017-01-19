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
using CommonViewer.BaseControl;
using CommonOperation.Functions;
namespace BaseInfo.Viewer
{
    public partial class UcManufacturer : UserControl, IOneObjectViewer
    {
        #region 对象初始化

        Manufacturer theObject = new Manufacturer();
        #endregion
        public bool needRetrieve = false;
        public UcManufacturer()
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
            resetValue((Manufacturer)toChangeData);
        }

        /// <summary>
        /// 清空.
        /// </summary>
        public void ClearData()
        {
            theObject = new Manufacturer();
            MANUFACTURER_CODE.Text = "";
            MANUFACTURER_NAME.Text = "";
            ADDR.Text = "";
            FAX.Text = "";
            LINKER.Text = "";
            EMAIL.Text = "";
            NETADDR.Text = "";
            POSTALCODE.Text = "";
            MOBILPHONE.Text = "";
            TELEPHONE.Text = "";
            REMARK.Text = "";
            lbNoUse.Visible = false;
            chk1.Checked = false;
            chk2.Checked = false;
            chk3.Checked = false;
            chk4.Checked = false;
            chk5.Checked = false;
        }
        /// <summary>
        /// 把用户所输入数据存放到theObject属性中.
        /// </summary>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool SetObject(out string err)
        {
            err = "";
            //decimal res;
            if (!theObject.IsWrong)
            {
                theObject.MANUFACTURER_CODE = MANUFACTURER_CODE.Text;
                //if (decimal.TryParse(MANUFACTURER_TYPE.Text, out res))
                //{
                theObject.MANUFACTURER_TYPE = (chk1.Checked ? "A," : "") + (chk2.Checked ? "B," : "") + (chk3.Checked ? "C," : "") + (chk4.Checked ? "D," : "") + (chk5.Checked ? "E," : "");
                //}
                //else
                //{
                //    MessageBoxEx.Show("厂家类型请输入数字");
                //    return false;
                //} 
                theObject.MANUFACTURER_NAME = MANUFACTURER_NAME.Text;
                theObject.MANUFACTURER_ENAME = MANUFACTURER_ENAME.Text;
                theObject.MOBILPHONE = MOBILPHONE.Text;
                theObject.TELEPHONE = TELEPHONE.Text;
                theObject.LINKER = LINKER.Text;
                theObject.REMARK = REMARK.Text;
                theObject.FAX = FAX.Text;
                theObject.POSTALCODE = POSTALCODE.Text;
                theObject.NETADDR = NETADDR.Text;
                theObject.ADDR = ADDR.Text;
                theObject.EMAIL = EMAIL.Text;
            }
            return true;
        }
        public void SetCanEdit(bool canEdit)
        {
            MANUFACTURER_CODE.ReadOnly = canEdit;
            MANUFACTURER_NAME.ReadOnly = canEdit;
            MANUFACTURER_ENAME.ReadOnly = canEdit;
            MOBILPHONE.ReadOnly = canEdit;
            TELEPHONE.ReadOnly = canEdit;
            LINKER.ReadOnly = canEdit;
            REMARK.ReadOnly = canEdit;
            FAX.ReadOnly = canEdit;
            POSTALCODE.ReadOnly = canEdit;
            NETADDR.ReadOnly = canEdit;
            ADDR.ReadOnly = canEdit;
            EMAIL.ReadOnly = canEdit;
            chk1.Enabled = canEdit;
            chk2.Enabled = canEdit;
            chk3.Enabled = canEdit;
            chk4.Enabled = canEdit;
            chk5.Enabled = canEdit;
        }
        #endregion

        /// <summary>
        /// 重置数据.
        /// </summary>
        private void resetValue(Manufacturer toResetObject)
        {
            if (theObject != null) theObject = (Manufacturer)theObject.Clone();
            if (toResetObject != null && !toResetObject.IsWrong)
            {
                MANUFACTURER_CODE.Text = toResetObject.MANUFACTURER_CODE;
                MANUFACTURER_NAME.Text = toResetObject.MANUFACTURER_NAME;
                MANUFACTURER_ENAME.Text = toResetObject.MANUFACTURER_ENAME;
                MOBILPHONE.Text = toResetObject.MOBILPHONE;
                TELEPHONE.Text = toResetObject.TELEPHONE;
                LINKER.Text = toResetObject.LINKER;
                REMARK.Text = toResetObject.REMARK;
                FAX.Text = toResetObject.FAX;
                POSTALCODE.Text = toResetObject.POSTALCODE;
                NETADDR.Text = toResetObject.NETADDR;
                ADDR.Text = toResetObject.ADDR;
                EMAIL.Text = toResetObject.EMAIL;
                lbNoUse.Visible = (toResetObject.MANUFACTURER_NULLIFY == "1");
                theObject = toResetObject;
                string MANUFACTURER_TYPETemp = "";
                if (!string.IsNullOrEmpty(toResetObject.MANUFACTURER_TYPE))
                {
                    MANUFACTURER_TYPETemp = toResetObject.MANUFACTURER_TYPE.Replace("修船", "A").Replace("油类", "B").Replace("备件", "C").Replace("物资", "D").Replace("其他", "E") + ",";
                }

                chk1.Checked = MANUFACTURER_TYPETemp.Contains("A,");
                chk2.Checked = MANUFACTURER_TYPETemp.Contains("B,");
                chk3.Checked = MANUFACTURER_TYPETemp.Contains("C,");
                chk4.Checked = MANUFACTURER_TYPETemp.Contains("D,");
                chk5.Checked = MANUFACTURER_TYPETemp.Contains("E,");
            }
            else ClearData();
        }

        #region wanhw-2014-10-02-作废供应商
        /// <summary>
        /// 作废供应商.
        /// </summary>
        /// <returns></returns>
        public bool NullifyObject()
        {
            theObject.MANUFACTURER_NULLIFY = "1";
            lbNoUse.Visible = true;

            string err;
            bool returnValue = false;
            if (BeforeUpdateObject())
            {
                if (theObject.Update(out err))
                {
                    returnValue = true;
                }
            }
            return returnValue;
        }
        #endregion

        #region wanhw-2014-10-02-重新启用供应商
        /// <summary>
        /// 重新启用供应商.
        /// </summary>
        /// <returns></returns>
        public bool ReUseObject()
        {
            theObject.MANUFACTURER_NULLIFY = "0";
            lbNoUse.Visible = false;
            string err;
            bool returnValue = false;
            if (BeforeUpdateObject())
            {
                if (theObject.Update(out err))
                {
                    returnValue = true;
                }
            }
            return returnValue;
        }
        #endregion

        private Boolean BeforeUpdateObject()
        {
            string err;
            bool returnValue = false;


            if (string.IsNullOrEmpty(MANUFACTURER_NAME.Text.Trim()))
            {
                MessageBoxEx.Show("厂家名称不允许为空!");
                MANUFACTURER_NAME.Focus();
                return false;
            }

            IDBOperation dbOper = InterfaceInstantiation.NewADBOperation();
            if (dbOper.DbHaveThisData(MANUFACTURER_NAME.Text.Trim(), "T_MANUFACTURER", "MANUFACTURER_ID", "MANUFACTURER_NAME", theObject.GetId()))
            {
                MessageBoxEx.Show("厂家名称不允许重复!");
                MANUFACTURER_NAME.Focus();
                return false;
            }

            if (theObject.IsWrong)
            {
                MessageBoxEx.Show("当前对象无效,不能保存!");
            }
            else
            {
                returnValue = SetObject(out err);
            }
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool UpdateObject()
        {
            string err;
            bool returnValue = false;
            if (BeforeUpdateObject())
            {
                if (!theObject.Update(out err))
                {
                    MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err);
                    MANUFACTURER_NAME.Focus();
                }
                else
                {
                    MessageBoxEx.Show("保存成功!");
                    returnValue = true;
                }
            }
            return returnValue;
        }
        /// <summary>
        /// 
        /// </summary>
        public void DeleteObject()
        {

            if (theObject.IsWrong || string.IsNullOrEmpty(theObject.MANUFACTURER_ID))
            {
                MessageBoxEx.Show("当前对象无效,不能删除!");
            }
            else
            {
                string err;
                DialogResult response = MessageBoxEx.Show("您确定要删除该条数据吗？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (response == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
                if (ManufacturerService.Instance.deleteUnit(theObject.MANUFACTURER_ID, out err))
                {
                    MessageBoxEx.Show("删除成功!");
                    needRetrieve = true;
                }
                else
                {
                    MessageBoxEx.Show("当前对象删除失败,错误原因是:\n\n" + err);
                }
            }
        }

        /// <summary>
        /// 修改数据表DataTable某一列的记录值(这里修改的是manufacturer_type 厂商类型)
        /// </summary>
        /// <param name="argDataTable">数据表DataTable</param>
        /// <returns>数据表DataTable</returns>
        public DataTable UpdateDataTable(DataTable argDataTable)
        {
            foreach (DataRow row in argDataTable.Rows)
            {
                string value = "", temp = "";
                Type type = row["manufacturer_type"].GetType();
                if (type.FullName.Equals("System.String"))
                {
                    temp = row["manufacturer_type"].ToString();
                    value = temp.Replace("A", "修船供应商").Replace("B", "油类供应商").Replace("C", "备件供应商").Replace("D", "物资供应商").Replace("E", "其他"); //修改记录值.
                    value = value.Length > 0 ? (value.Remove(value.LastIndexOf(","), 1)) : "";
                }
                row["manufacturer_type"] = value;
            }

            //返回希望的结果.
            return argDataTable;
        }
    }
}
