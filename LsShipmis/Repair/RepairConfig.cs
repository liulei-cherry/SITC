using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Repair.Viewer;

namespace Repair
{
    public class RepairConfig
    {
        public static void InitConfig()
        {
            ItemsManage.ItemsManageConfig.repairHistory = new ItemsManage.ItemsManageConfig.RepairHistory(RepairHistory);
        }

        //修理历史.
        public static void RepairHistory(string componentUnitID)
        {
            FrmRepairHistory frm = new FrmRepairHistory(componentUnitID);
            frm.ShowDialog();
        }

        //备件物料申请的客户化实现.
        public delegate bool CustomRepairApplyPrint(List<string> applyList, out string err);
        public static CustomRepairApplyPrint customRepairApplyPrint;
        //坞修总结的客户化实现.
        public delegate bool CustomDockRepairSummarizePrint(DataTable dt, out string err);
        public static CustomDockRepairSummarizePrint customDockRepairSummarizePrint;

    }
}
