using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GunterControl.Common;
using ShipCertification.Services;
using ShipCertification.DataObject;
using ShipCertification.Report;
using CommonViewer.BaseControl;
using GunterControl.DataControlLayer;

namespace ShipCertification.Viewer
{
    public partial class FrmShipCertificationManage : CommonViewer.BaseForm.FormBase
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static FrmShipCertificationManage instance = new FrmShipCertificationManage();
        public static FrmShipCertificationManage Instance
        {
            get
            {
                if (null == instance)
                {
                    FrmShipCertificationManage.instance = new FrmShipCertificationManage();
                }
                return FrmShipCertificationManage.instance;
            }
        }
        #endregion
        string nowId;
        string shipId;
        private CommonOperation.Functions.ProxyRight proxyRight = CommonOperation.Functions.ProxyRight.Instance;//权限代理业务类.
        bool SHIPCERT_EDIT;

        private void bandingFunction(bool CanEdit)
        {
            gunterBox1.reloadData = new GunterControl.ViewLayer.GunterBox.ReloadData(regetAllData);
            gunterToolBar1.changingDropDown += new ShipCertGunterToolBar.ChangingDropDowne(gunterToolBar1_changingDropDown);
            if (CanEdit)
            {
                gunterBox1.saveButtonEnable += new GunterControl.ViewLayer.GunterBox.SaveButtonEnable(gunterBox1_saveButtonEnable);
                gunterBox1.itemChanged += new GunterControl.ViewLayer.GunterBox.ItemChanged(gunterBox1_itemChanged);
                gunterBox1.itemSave2 += new GunterControl.ViewLayer.GunterBox.ItemSave2(gunterBox21_itemSave);
                gunterBox1.doubleClickARow += new GunterControl.ViewLayer.GunterBox.DoubleClickARow(gunterBox1_doubleClickARow);
                gunterToolBar1.addItem += new ShipCertGunterToolBar.AddItem(gunterToolBar1_addItem);
                gunterToolBar1.saveItem += new ShipCertGunterToolBar.SaveItem(gunterToolBar1_saveItem);
                gunterToolBar1.editItem += new ShipCertGunterToolBar.EditItem(gunterToolBar1_editItem);
                gunterToolBar1.checkCertification += new ShipCertGunterToolBar.CheckCertification(gunterToolBar1_checkCertification);
                gunterToolBar1.deleteItem += new ShipCertGunterToolBar.DeleteItem(gunterToolBar1_deleteItem);
            }
            gunterToolBar1.printCert += new ShipCertGunterToolBar.PrintCert(gunterToolBar1_printCert);
            gunterToolBar1.closeForm += new ShipCertGunterToolBar.CloseForm(gunterToolBar1_closeForm);
        }

        void gunterBox1_itemChanged(string itemId)
        {
            nowId = itemId;
            ShipCertRegister ob = (ShipCertRegister)ShipCertRegisterService.Instance.GetOneObjectById(itemId);
            ob.FillThisObject();
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck(ob.SHIP_CERT_ID, (ob.ThisCert == null ? "" : ob.SHIP_CERT_NAME),
                CommonOperation.Enum.FileBoundingTypes.SHIPCERTREGISTER, ob.SHIP_ID);
        }

        void gunterToolBar1_printCert()
        {
            FrmCertificationReportOfOneShip frm = FrmCertificationReportOfOneShip.Instance;
            if (this.MdiParent != null)
            {
                frm.MdiParent = this.MdiParent;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.WindowState = FormWindowState.Maximized;
            }
            frm.Show();
        }

        void gunterToolBar1_checkCertification()
        {
            ShipCertRegister ob = (ShipCertRegister)ShipCertRegisterService.Instance.GetOneObjectById(nowId);

            if (ob != null && !ob.IsWrong)
            {
                if (ob.SHIPCERTTYPE != 1 && ob.SHIPCERTTYPE != 4)
                {

                    FrmShipCertificationCheck frm = new FrmShipCertificationCheck(ob);//修改船期时不可以修改船舶名称,false为不可以改，true可以.
                    frm.ShowDialog();
                    if (frm.needRetrieve) getAllData();
                }
                else
                {
                    MessageBoxEx.Show("长期证书和存档的证书不需要检查,如希望记录临时记录,请直接在注释中标明即可!");
                }
            }
        }
        void gunterBox1_doubleClickARow(string itemId)
        {
            nowId = itemId;
            if (SHIPCERT_EDIT) gunterToolBar1_editItem();
        }
        void gunterToolBar1_editItem()
        {
            ShipCertRegister ob = (ShipCertRegister)ShipCertRegisterService.Instance.GetOneObjectById(nowId);

            if (ob != null && !ob.IsWrong)
            {
                FrmEditOneShipCertRegister frm = new FrmEditOneShipCertRegister(ob);//修改船期时不可以修改船舶名称,false为不可以改，true可以.
                frm.ShowDialog();
                if (frm.NeedRetrieve) getAllData();
            }
        }

        void gunterToolBar1_deleteItem()
        {
            string err;

            if (nowId != null && nowId.Length == 36 && MessageBoxEx.Show("是否删除当前数据,如果挂结果具体任务的船期将不能被删除!", "提示", MessageBoxButtons.OKCancel,
                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                if (!ShipCertRegisterService.Instance.deleteUnit(nowId, out err))
                {
                    MessageBoxEx.Show(err, "删除当前数据失败!");
                    return;
                }
                getAllData();
            }
        }

        void gunterToolBar1_addItem()
        {
            FrmEditOneShipCertRegister frmNewShipCertRegister;
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                frmNewShipCertRegister = new FrmEditOneShipCertRegister(shipId);
            }
            else
            {
                frmNewShipCertRegister = new FrmEditOneShipCertRegister(CommonOperation.ConstParameter.ShipId);
            }

            frmNewShipCertRegister.ShowDialog();
            if (frmNewShipCertRegister.NeedRetrieve)
            {
                getAllData();
            }
        }
        void gunterToolBar1_closeForm()
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
        void gunterToolBar1_saveItem()
        {
            gunterBox1.SaveItem();
        }
        void gunterToolBar1_changingDropDown(string value)
        {
            shipId = value;
            getAllData();
        }
        void gunterBox1_saveButtonEnable(bool enable)
        {
            gunterToolBar1.SaveButtonSetting(enable);
        }

        private FrmShipCertificationManage()
        {
            InitializeComponent();
            string sChkMessage;
            SHIPCERT_EDIT = proxyRight.CheckRight(CommonOperation.ConstParameter.SHIPCERTIFICATION_EDIT, out sChkMessage);
            bandingFunction(SHIPCERT_EDIT);
        }

        private void FrmShipCertificationManage_Load(object sender, EventArgs e)
        {
            getAllData();
            gunterToolBar1.ShowButtons();
        }
        private DataTable regetAllData()
        {
            shipId = gunterToolBar1.GetShipID();
            return ShipCertRegisterService.Instance.GetAllShipCertificationOfShip(shipId);
        }
        private void getAllData()
        {
            try
            {
                string err;
                DataTable dt = regetAllData();
                List<UserColumn> listColumnIn = new List<UserColumn>();

                listColumnIn.Add(new UserColumn("id", 0, 1, GunterControl.Common.ValueType.String, false, false));
                listColumnIn.Add(new UserColumn("船舶", 100, 2, GunterControl.Common.ValueType.String, false));
                listColumnIn.Add(new UserColumn("预警时间", 80, 3, GunterControl.Common.ValueType.DateTime, true, false));
                listColumnIn.Add(new UserColumn("检验时间", 80, 4, GunterControl.Common.ValueType.DateTime, true));
                listColumnIn.Add(new UserColumn("证书名称", 160, 5, GunterControl.Common.ValueType.String, false));
                listColumnIn.Add(new UserColumn("发证时间", 80, 6, GunterControl.Common.ValueType.DateTime, false));
                listColumnIn.Add(new UserColumn("证书有效期", 80, 7, GunterControl.Common.ValueType.DateTime, false));
                listColumnIn.Add(new UserColumn("证书编号", 80, 8, GunterControl.Common.ValueType.Number, false, false));
                listColumnIn.Add(new UserColumn("有效期长(年)", 80, 8, GunterControl.Common.ValueType.Number, false));
                listColumnIn.Add(new UserColumn("发证地点", 80, 8, GunterControl.Common.ValueType.Number, false, false));
                listColumnIn.Add(new UserColumn("主管机关", 80, 9, GunterControl.Common.ValueType.String, false, false));

                GunterControlBaseData theGunterControlBaseData = new GunterControlBaseData();

                if (!gunterBox1.RetrieveData(listColumnIn, dt, theGunterControlBaseData, true, true, out err))
                {
                    MessageBoxEx.Show(err, "加载原数据出错");
                }
                else
                {
                    gunterBox1.FilterDate();
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message);
            }
        }
        bool gunterBox21_itemSave(string itemId, DateTime fromDate, DateTime endDate)
        {
            nowId = itemId;
            ShipCertRegister item = (ShipCertRegister)ShipCertRegisterService.Instance.GetOneObjectById(itemId);
            if (item != null && !item.IsWrong)
            {
                string err;
                TimeSpan diff = endDate - fromDate;
                item.ALERTDAYS = diff.Days;
                item.MATUREDATE = endDate;
                if (!item.Update(out err))
                {
                    MessageBoxEx.Show("保存失败,错误信息是" + err, "错误提示");
                    return false;
                }
                return true;
            }
            return false;
        }

        private void FrmShipCertificationManage_FormClosed(object sender, FormClosedEventArgs e)
        {
            //清除大文档绑定功能.
            FileOperation.FileBoundingOperation.Instance.FileBoundCheck("", "", 0, "");
            instance = null;
        }
    }
}
