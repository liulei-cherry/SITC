using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CommonOperation.Interfaces;
using ItemsManage.DataObject;
using CommonOperation.Functions;
using ItemsManage.Services;
using CommonViewer.BaseControl;

namespace ItemsManage.Viewer
{
    public partial class UcEquipment : UserControl, IOneObjectViewer
    {
        bool loaded = false;
        private bool needRetrieve = false;
        public bool NeedRetrieve
        {
            get { return needRetrieve; } 
        } 
        public UcEquipment()
        {
            InitializeComponent(); 
        }

        ComponentUnit theEquipment;
        public ComponentUnit TheEquipment
        {
            get { return theEquipment; } 
        }

        ComponentType theEquipmentType; 
       
        #region IOneObjectViewer 成员

        public void ChangeData(CommonOperation.BaseClass.CommonClass toChangeData)
        {
            if (theEquipment == null || !theEquipment.EqualTo(toChangeData))
            {
                DirectlyChangeData(toChangeData);
            }
        }

        public void DirectlyChangeData(CommonOperation.BaseClass.CommonClass toChangeData)
        {
            if (toChangeData.GetType() == typeof(ComponentUnit))
            {
                theEquipment = (ComponentUnit)toChangeData;
                theEquipment.FillThisObject();
                if (theEquipment.TheComponentType != null)
                {
                    theEquipmentType = theEquipment.TheComponentType;
                    txtCompTypeName.Text = theEquipmentType.COMPTYPE_CHINESE_NAME;
                    txtCompTypeName.Tag = theEquipmentType.GetId();
                    txtCompTypeStyle.Text = theEquipmentType.COMPONENT_STYLE;
                    ucManufacturerSelect1.SelectedText(theEquipmentType.MANUFACTURER);
                    ucManufacturerSelect2.SelectedText(theEquipmentType.SERVICE_PROVIDER);
                    txtCompTypePara.Text = theEquipmentType.DETAIL;
                    ucPostSelect1.SelectedId(theEquipmentType.HEADSHIP);
                }
                txtCompName.Text = theEquipment.COMP_CHINESE_NAME;
                txtCompNo.Text = theEquipment.comp_serial_no;
                txtCompEnName.Text = theEquipment.COMP_ENGLISH_NAME;
                dtProduceDate.Value = theEquipment.PRODUCE_TIME;
                dtUseDate.Value = theEquipment.USE_TIME;
                radioButton1.Checked = (theEquipment.COMP_STATUS == 1); //1正常运行,2停止,设备正常,3停止,设备故障,4停止,设备报废.
                radioButton2.Checked = (theEquipment.COMP_STATUS == 2); //1正常运行,2停止,设备正常,3停止,设备故障,4停止,设备报废.
                radioButton3.Checked = (theEquipment.COMP_STATUS == 3); //1正常运行,2停止,设备正常,3停止,设备故障,4停止,设备报废.
                radioButton4.Checked = (theEquipment.COMP_STATUS == 4); //1正常运行,2停止,设备正常,3停止,设备故障,4停止,设备报废.
                txtCompCert.Text = theEquipment.certification;
                dtRepairDate.Value = theEquipment.repair_date;
                txtExamCode.Text = theEquipment.EXAMINATION_CODE; 
                txtCompPara.Text = theEquipment.Detail;
                trackBar1.Value = (int)(theEquipment.USE_RATE * 100);
            }
        }

        public void ClearData()
        {
            theEquipment = new ComponentUnit();
            theEquipmentType = new ComponentType();
            txtCompName.Text = "";
            txtCompTypeName.Text = "";
            txtCompNo.Text = "";
            txtCompEnName.Text = "";
            dtProduceDate.Text = "";
            dtUseDate.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            txtCompCert.Text = "";
            dtRepairDate.Text = "";
            trackBar1.Value = 100;
            txtExamCode.Text = ""; 
            txtCompPara.Text = "";
            txtCompTypeName.Text = "";
            txtCompTypeName.Tag = null;
            txtCompTypeStyle.Text = "";
            ucManufacturerSelect1.SelectedText("");
            ucManufacturerSelect2.SelectedText("");
            txtCompTypePara.Text = "";
            ucPostSelect1.Text = "";
        }

        public bool SetObject(out string err)
        {
            err = "";
            if (theEquipment != null)
            {
                #region 设置类型部分
                theEquipmentType.COMPTYPE_CHINESE_NAME = txtCompTypeName.Text;
                theEquipmentType.COMPONENT_STYLE = txtCompTypeStyle.Text;
                theEquipmentType.MANUFACTURER = ucManufacturerSelect1.GetText();
                theEquipmentType.SERVICE_PROVIDER = ucManufacturerSelect2.GetText();
                theEquipmentType.DETAIL = txtCompTypePara.Text;
                theEquipmentType.HEADSHIP = ucPostSelect1.GetId();
                ComponentType thisComponentType;
                if (string.IsNullOrEmpty(theEquipmentType.MANUFACTURER))
                {
                    thisComponentType = ComponentTypeService.Instance.GetComponentTypeByNameAndStyleNumber
                        (theEquipmentType.COMPTYPE_CHINESE_NAME, theEquipmentType.COMPONENT_STYLE);
                }
                else
                {
                    thisComponentType = ComponentTypeService.Instance.GetComponentTypeByNameAndStyleNumber
                        (theEquipmentType.COMPTYPE_CHINESE_NAME, theEquipmentType.COMPONENT_STYLE, theEquipmentType.MANUFACTURER);
                }
                if (thisComponentType == null || thisComponentType.IsWrong)
                {
                    thisComponentType = theEquipmentType;
                }
                else
                {
                    thisComponentType.MANUFACTURER = theEquipmentType.MANUFACTURER;
                    thisComponentType.SERVICE_PROVIDER = theEquipmentType.SERVICE_PROVIDER;
                    thisComponentType.DETAIL = theEquipmentType.DETAIL;
                    thisComponentType.HEADSHIP = theEquipmentType.HEADSHIP;
                }
                if (!thisComponentType.Update(out err))
                {
                    MessageBoxEx.Show("添加新的设备型号时出错,错误信息为:" + err);
                    return false;
                }
                theEquipmentType = thisComponentType;
                #endregion
                #region 设置设备部分
                theEquipment.IsWrong = false;
                theEquipment.COMPONENT_TYPE_ID = thisComponentType.GetId();
                theEquipment.COMP_CHINESE_NAME = txtCompName.Text;
                theEquipment.comp_serial_no = txtCompNo.Text;
                theEquipment.COMP_ENGLISH_NAME = txtCompEnName.Text;
                theEquipment.PRODUCE_TIME = dtProduceDate.Value;
                theEquipment.USE_TIME = dtUseDate.Value;
                if (radioButton1.Checked)
                    theEquipment.COMP_STATUS = 1;
                else if (radioButton2.Checked)
                    theEquipment.COMP_STATUS = 2;
                else if (radioButton3.Checked)
                    theEquipment.COMP_STATUS = 3;
                else if (radioButton4.Checked)
                    theEquipment.COMP_STATUS = 4;
                theEquipment.certification = txtCompCert.Text;
                theEquipment.repair_date = dtRepairDate.Value;
                theEquipment.EXAMINATION_CODE = txtExamCode.Text;
                theEquipment.USE_RATE = (decimal)trackBar1.Value / 100; 
                theEquipment.Detail = txtCompPara.Text;
                #endregion
                return true;
            }
            else
            {
                err = "当前对象无效!";
                MessageBoxEx.Show(err);
                return false;
            }
        }
        
        public void SetCanEdit(bool canEdit)
        {
            #region 设置类型部分
            txtCompTypeName.ReadOnly = !canEdit;
            txtCompTypeStyle.ReadOnly = !canEdit;
            ucManufacturerSelect1.Enabled = canEdit;
            ucManufacturerSelect2.Enabled = canEdit;
            txtCompTypePara.ReadOnly = !canEdit;
            ucPostSelect1.Enabled = canEdit;
            #endregion
            #region 设置设备部分
            txtCompName.ReadOnly = !canEdit;
            txtCompNo.ReadOnly = !canEdit;
            txtCompEnName.ReadOnly = !canEdit;
            dtProduceDate.ReadOnly = !canEdit;
            dtUseDate.ReadOnly = !canEdit;
            radioButton1.Enabled = canEdit;
            radioButton2.Enabled = canEdit;
            radioButton3.Enabled = canEdit;
            radioButton4.Enabled = canEdit;
            txtCompCert.ReadOnly = !canEdit;
            dtRepairDate.ReadOnly = !canEdit;
            txtExamCode.ReadOnly = !canEdit; 
            txtCompPara.Enabled = canEdit;
            trackBar1.Enabled = canEdit;
            ucPostSelect1.Enabled = canEdit; 
            #endregion
        } 
        #endregion

        private void btnRepairHis_Click(object sender, EventArgs e)
        {
            if (theEquipment == null || theEquipment.IsWrong) return;
            if (string.IsNullOrEmpty(theEquipment.COMPONENT_UNIT_ID))
            {
                MessageBoxEx.Show("请先保存设备信息", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (ItemsManageConfig.openComponentWorkListForm != null)
                    ItemsManageConfig.openComponentWorkListForm(theEquipment);
            }
        }
        
        /// <summary>
        /// 运转率bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            txtRate.Text = trackBar1.Value.ToString() + "% 日预计平均运转(daily average hours)" + ((int)24 * trackBar1.Value * 0.01).ToString() + "小时";
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void DeleteObject()
        {

            if (theEquipment.IsWrong || string.IsNullOrEmpty(theEquipment.GetId()))
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
                if (theEquipment.Delete(out err))
                {
                    MessageBoxEx.Show("删除成功");
                    needRetrieve = true;
                }
                else
                {
                    MessageBoxEx.Show("当前对象删除失败,错误原因是:\n\n" + err);
                }
            }
        }
        
        public bool UpdateObject()
        {
            string err;
            if (!SetObject(out err)) return false;
            if (theEquipment == null)
            {
                MessageBoxEx.Show("当前对象无效,不能保存!");
                return false;
            }
            else
            {
                if (ucManufacturerSelect1.GetText().Length == 0)
                {
                    MessageBoxEx.Show("设备生产厂家必填", "错误提示");
                    ucManufacturerSelect1.Focus();
                    return false;
                }
                if (txtCompTypeName.Text.Length == 0)
                {
                    MessageBoxEx.Show("设备型号全称必须填写,此属性同时作为相同型号设备资料的统一索引名称.", "错误提示");
                    txtCompTypeName.Focus();
                    return false;
                }
                if (txtCompName.Text.Length == 0)
                {
                    MessageBoxEx.Show("设备名称必须填写", "错误提示");
                    txtCompName.Focus();
                    return false;
                }
                if (txtCompTypeStyle.Text.Length == 0)
                {
                    MessageBoxEx.Show("设备型号必须填写", "错误提示");
                    txtCompTypeStyle.Focus();
                    return false;
                }
                if (!theEquipment.Update(out err))
                {
                    MessageBoxEx.Show("当前对象保存失败,错误原因是:" + err);
                    return false;
                }
            }
            MessageBoxEx.Show("保存成功!");
            return true;
        }

        private void ucManufacturerSelect1_theTextChanged(string theSelectedText)
        {
            if (txtCompTypeStyle.Text.Length > 0 && (string.IsNullOrEmpty(txtCompTypeName.Text) || txtCompTypeName.Text.EndsWith(txtCompTypeStyle.Text)))
                txtCompTypeName.Text = theSelectedText + txtCompTypeStyle.Text;
            if (string.IsNullOrEmpty(ucManufacturerSelect2.GetText())) ucManufacturerSelect2.SelectedText(theSelectedText);
        }

        private void txtCompTypeStyle_TextChanged(object sender, EventArgs e)
        {
            if (ucManufacturerSelect1.GetText().Length > 0 && (string.IsNullOrEmpty(txtCompTypeName.Text) || txtCompTypeName.Text.StartsWith(ucManufacturerSelect1.GetText())))
                txtCompTypeName.Text = ucManufacturerSelect1.GetText() + txtCompTypeStyle.Text; 
        }

        private void UcEquipment_Layout(object sender, LayoutEventArgs e)
        {
            if (!loaded)
            {
                ucManufacturerSelect1.ChangeMode(false, true, true);
                ucManufacturerSelect2.ChangeMode(false, true, true);
                loaded = true;
            }
        }

    }
}
