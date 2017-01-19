using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using CustomerTable.Forms;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using CommonOperation.BaseClass;
using BaseInfo.Objects;
using CustomerTable.BaseServices;
using ShipCertification;
using Maintenance;
using StorageManage;
using CommonViewer.BaseControl;
using Repair;

namespace CustomerTable
{
    public class CustomerTableConfig
    {

        /// <summary>
        /// 获取所有纯粹定制表格（业务定制表格不在这里加载）.
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllCustomerTables()
        {
            List<string> allCustomerTables = new List<string>();

            //海丰（不需要模板的业务报表）.
            StorageManage.StorageConfig.customSparePurchaseApplyPrint = CustomerTable.Haifeng.Services.AllCustomerReport.Instance.customSpareApplyPrint;
            StorageManage.StorageConfig.customSparePurchaseAskPricePrint = CustomerTable.Haifeng.Services.AllCustomerReport.Instance.customAskPricePrint;
            StorageManage.StorageConfig.customMaterialPurchaseApplyPrint = CustomerTable.Haifeng.Services.AllCustomerReport.Instance.customMaterialApplyPrint;
            StorageManage.StorageConfig.customMaterialPurchaseAskPricePrint = CustomerTable.Haifeng.Services.AllCustomerReport.Instance.customMaterialAskPricePrint;
           
            ShipCertificationConfig.customShipCertificationReport = CustomerTable.Haifeng.Services.AllCustomerReport.Instance.customShipCertificationReport;
            MaintenanceConfig.customMonthlyCompleteReport = CustomerTable.Haifeng.Services.AllCustomerReport.Instance.customMonthlyCompleteReport;
            RepairConfig.customRepairApplyPrint = CustomerTable.Haifeng.Services.AllCustomerReport.Instance.customRepairApplyPrint;
            RepairConfig.customDockRepairSummarizePrint = CustomerTable.Haifeng.Services.AllCustomerReport.Instance.customDockRepairSummarizePrint;

            //海丰（需要模板的纯粹报表）.
            allCustomerTables.Add(CommonPrintTableName.CTNOfBoilerWater);
            allCustomerTables.Add(CommonPrintTableName.CTNOfCoolWater);
            allCustomerTables.Add(CommonPrintTableName.CTNOfHostInfo);
            allCustomerTables.Add(CommonPrintTableName.CTNOfSlaveInfo);
            allCustomerTables.Add(CommonPrintTableName.CTNOfCabinStatistics);
            allCustomerTables.Add(CommonPrintTableName.CTNOfEquipmentMaintenance);
            allCustomerTables.Add(CommonPrintTableName.CTNOfDeckMaintenance);
            allCustomerTables.Add(CommonPrintTableName.CTNofXFJSTJB);
            allCustomerTables.Add(CommonPrintTableName.CTNofTDSBTJB);
            //allCustomerTables.Add(CommonPrintTableName.CTNofTDSBTJJCB);//liulei-2015/11/10-新增通信导航设备统计和检查表
            return allCustomerTables;
        }
        public static Form OpenForm(string formName, Form mdiParent)
        {
            Form frm = null;
            if (formName == CommonPrintTableName.CTNOfShipCertification)
                frm = ShipCertificationConfig.getCertificationReportOfOneShip();
            else if (formName == CommonPrintTableName.CTNOfCabinStatistics)
                frm = CustomTable.Haifeng.Viewer.FrmCabinStatistics.Instance;
            else if (formName == CommonPrintTableName.CTNOfSlaveInfo)
                frm = CustomTable.Haifeng.Viewer.FrmShipSlave.Instance;
            else if (formName == CommonPrintTableName.CTNOfHostInfo)
                frm = CustomTable.Haifeng.Viewer.FrmShipHost.Instance;
            else if (formName == CommonPrintTableName.CTNOfCoolWater)
                frm = CustomTable.Haifeng.Viewer.FrmCoolWater.Instance;
            else if (formName == CommonPrintTableName.CTNOfBoilerWater)
                frm = CustomTable.Haifeng.Viewer.FrmBoilerWater.Instance;
            else if (formName == CommonPrintTableName.CTNOfEquipmentMaintenance)
                frm = CustomTable.Haifeng.Viewer.FrmMechatronikMaintain.Instance;
            else if (formName == CommonPrintTableName.CTNOfDeckMaintenance)
                frm = CustomTable.Haifeng.Viewer.FrmDeckMaintain.Instance;
            else if (formName == CommonPrintTableName.CTNofXFJSTJB)
                frm = CustomTable.Haifeng.Viewer.FrmXFJSTJB.Instance;
            else if (formName == CommonPrintTableName.CTNofTDSBTJB)
                frm = CustomTable.Haifeng.Viewer.FrmTDSBTJB.Instance;
            else
            {
                MessageBoxEx.Show("系统中未发现名称为【" + formName + "】的客户定制化窗体，敬请期待！", "提示");
                return null;
            }
            return frm;
        }
    }
}
