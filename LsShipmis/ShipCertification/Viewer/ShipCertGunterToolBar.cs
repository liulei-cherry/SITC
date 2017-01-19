using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using GunterControl.DataControlLayer;
using GunterControl.Common;
using GunterControl.ViewLayer;
using System.Drawing;
using BaseInfo.DataAccess;

namespace ShipCertification.Viewer
{
    public partial class ShipCertGunterToolBar : UserControl
    {
        GunterControlBaseData thisGunterControlBaseData = GunterControlBaseData.GetAClientUserSettingData();//控制数据.

        public ShipCertGunterToolBar()
        {
            InitializeComponent();
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                ucShipSelect1.ChangeSelectedState(false, true);
            }
            else
            {
                txtDropDown.Visible = false;
                ucShipSelect1.Visible = false;
            }

            if (resetViewMode != null)
            {
                thisGunterControlBaseData.MinWidth = 1;
                thisGunterControlBaseData.FirstStep = TimeStepType.Year;
                thisGunterControlBaseData.FirstStepStyle = "YYYY年";
                thisGunterControlBaseData.SencondStep = TimeStepType.Quarter;
                thisGunterControlBaseData.SencondStepStyle = "第N季";
                thisGunterControlBaseData.ThirdStep = TimeStepType.Month;
                thisGunterControlBaseData.ThirdStepStyle = "N月"; 
                //thisGunterControlBaseData.SaveToReg();

                resetViewMode(thisGunterControlBaseData, false);
            }
        }
 
        public void ShowButtons()
        {
            if (saveItem != null)
            {
                SaveButton.Visible = true;
            }
            if (addItem != null)
            {
                AddButton.Visible = true;
            }
            if (deleteItem != null)
            {
                deleteButton.Visible = true;
            }
            if (editItem != null)
            {
                btnEdit.Visible  = true;
            }
            if (checkCertification != null)
            {
                buttonEx2.Visible = true;
            }
        }
        
        #region 委托区域,所有按钮的实现均由委托调用

        public delegate void ResetViewMode(GunterControlBaseData newGunterControlMode, bool doNothing);
        public event ResetViewMode resetViewMode;

        public delegate void SaveItem();
        public event SaveItem saveItem;

        public delegate void EditItem();
        public event EditItem editItem;

        public delegate void AddItem();
        public event AddItem addItem;

        public delegate void DeleteItem();
        public event DeleteItem deleteItem;

        public delegate void CloseForm();
        public event CloseForm closeForm;

        public delegate void CheckCertification();
        public event CheckCertification checkCertification;        

        public delegate void ChangingDropDowne(string value);
        public event ChangingDropDowne changingDropDown;

        public delegate void PrintCert();
        public event PrintCert printCert;        

        #endregion        
        
        public void SaveButtonSetting(bool enabled)
        {            
            SaveButton.Enabled = enabled;
        }

        #region 工具条控制区域
         
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (addItem != null)
            {
                addItem();
            }
        }
        /// <summary>
        /// 关闭按钮按下.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (closeForm != null)
            {
                closeForm();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (saveItem != null)
            {
                saveItem();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (deleteItem != null)
            {
                deleteItem();
            }
        }
        #endregion

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (editItem != null)
            {
                editItem();
            }
        } 

        private void buttonEx2_Click(object sender, EventArgs e)
        {
            if (checkCertification != null)
            {
                checkCertification();
            }
        }

        private void buttonEx4_Click(object sender, EventArgs e)
        {
            if (printCert != null)
            {
                printCert();
            } 
        }

        private void ucShipSelect1_TheSelectedChanged(string theSelectedObject)
        {
            if(changingDropDown!=null) changingDropDown(theSelectedObject);
        }

        public string GetShipID()
        {
            return ucShipSelect1.GetId();
        }
    }
}
