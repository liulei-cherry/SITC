using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CommonViewer.BaseForm;
using GunterControl.Common;
using CommonViewer.BaseControl;
using CMSManage.DataObject;
using CMSManage.Services;

namespace CMSManage.Viewer
{
    public partial class FrmSetSelfCheckItems : FormBase
    {
        private CMSCheckLog theLogToEdit ;
        private FrmSetSelfCheckItems()
        {
            InitializeComponent();
        }
        public FrmSetSelfCheckItems(CMSCheckLog logToEdit)
        {
            InitializeComponent();           
            theLogToEdit = logToEdit;
        }

        private bool getAllData()
        {
            if (null == theLogToEdit) return false;
            try
            {

                string err;
                DataTable dt = CMSCheckService.Instance.GetAllSelfCheckItemOfOneLog(theLogToEdit.GetId());                
                List<UserColumn> listColumnIn = new List<UserColumn>();
                //id,检验名称，检验编码，检验方，检验日期.
                listColumnIn.Add(new UserColumn("id", 0, 1, GunterControl.Common.ValueType.String, false,false));
                listColumnIn.Add(new UserColumn("检验名称",200, 2, GunterControl.Common.ValueType.String, false));
                listColumnIn.Add(new UserColumn("预警日期", 80, 3, GunterControl.Common.ValueType.DateTime, false,false));
                listColumnIn.Add(new UserColumn("预计自检日期", 100, 4, GunterControl.Common.ValueType.DateTime, true));
                listColumnIn.Add(new UserColumn("检验编码", 100, 5, GunterControl.Common.ValueType.String, false));
                listColumnIn.Add(new UserColumn("检验方", 80, 6, GunterControl.Common.ValueType.String, false));

                if (!gunterBox1.RetrieveData(listColumnIn, dt, theLogToEdit.ToString() + "自检类项目的时间调整",true,true, out err))
                {
                    return false;
                }
                else
                {
                    gunterBox1.FilterDate();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
            } 
            return false;
        } 
        private void FrmSetSelfCheckItems_Load(object sender, EventArgs e)
        {
            bandFunction();
            if (getAllData())
                gunterToolBar1.ShowButtons();
            else
                timer1.Start();
        }
        private void bandFunction()
        {
            gunterToolBar1.saveItem += new GunterControl.GunterToolBar.SaveItem(gunterToolBar1_saveItem);
            gunterToolBar1.resetViewMode += new GunterControl.GunterToolBar.ResetViewMode(gunterToolBar1_resetViewMode);      
            gunterToolBar1.closeForm += new GunterControl.GunterToolBar.CloseForm(gunterToolBar1_closeForm);
            gunterBox1.saveButtonEnable += new GunterControl.ViewLayer.GunterBox.SaveButtonEnable(gunterBox1_saveButtonEnable);
            gunterBox1.itemSave2 += new GunterControl.ViewLayer.GunterBox.ItemSave2(gunterBox1_itemSave2);
            gunterBox1.changeGunterName += new GunterControl.ViewLayer.GunterBox.ChangeGunterName(gunterBox1_changeGunterName);
        }

        void gunterBox1_changeGunterName(string newGunterName)
        {
            gunterToolBar1.ChangeGunterName(newGunterName);
        }

        bool gunterBox1_itemSave2(string itemId, DateTime fromDate, DateTime endDate)
        {
            string err;
            CMSCheck item = CMSCheckService.Instance.getObject(itemId, out err);
            if (item != null && !item.IsWrong)
            { 
                item.PLAN_DATE=endDate;
                if (!item.Update(out err))
                {
                    MessageBoxEx.Show("保存失败,错误信息是" + err, "错误提示");
                    return false;
                }
                return true;
            }
            return false;
        }

        void gunterBox1_saveButtonEnable(bool enable)
        {
            gunterToolBar1.SaveButtonSetting(enable);
        }
        void gunterToolBar1_saveItem()
        {
            gunterBox1.SaveItem();
        }

        void gunterToolBar1_resetViewMode(GunterControl.DataControlLayer.GunterControlBaseData newGunterControlMode, bool doNothing)
        {
            gunterBox1.ResetViewMode(newGunterControlMode, doNothing);
            gunterBox1.Redraw(true);
        }

        private void gunterToolBar1_closeForm()
        {
            if (!gunterBox1.CanClose())
            {
                if (!gunterBox1.SaveAllItems())
                {
                    return;
                }
            }
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
