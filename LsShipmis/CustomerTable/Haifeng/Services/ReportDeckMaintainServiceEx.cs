using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CustomerTable.Haifeng.Services
{
    public partial class ReportDeckMaintainService
    {
        /// <summary>
        /// 得到  T_REPORT_DECK_MAINTAIN 所有数据信息.
        /// </summary>
        /// <returns>T_REPORT_DECK_MAINTAIN DataTable</returns>
        public bool GetInfoByYear(string SHIP_ID, DateTime YEAR, out  DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("REPORT_ID");
            sb.AppendLine(",FILE_ID");
            sb.AppendLine(",FILE_DATE");
            sb.AppendLine(",SHIP_ID");
            sb.AppendLine(",VOYAGE");
            sb.AppendLine(",REPORT_DATE");
            sb.AppendLine(",BEGIN_DATE");
            sb.AppendLine(",END_DATE");
            sb.AppendLine(",AIR_LINE");
            sb.AppendLine(",CHUAN_ZHANG");
            sb.AppendLine(",DA_FU");
            sb.AppendLine(",ER_FU");
            sb.AppendLine(",SAN_FU");
            sb.AppendLine(",SHUI_SHOU");
            sb.AppendLine(",MU_JIANG");
            sb.AppendLine(",CTJG");
            sb.AppendLine(",CKB");
            sb.AppendLine(",XZ_SHQ");
            sb.AppendLine(",JB");
            sb.AppendLine(",JBSB");
            sb.AppendLine(",CG");
            sb.AppendLine(",YST");
            sb.AppendLine(",DBSC");
            sb.AppendLine(",YZSC");
            sb.AppendLine(",JBGX");
            sb.AppendLine(",XF");
            sb.AppendLine(",JS");
            sb.AppendLine(",SMM_C");
            sb.AppendLine(",TQG");
            sb.AppendLine(",TFSB");
            sb.AppendLine(",QT");
            sb.AppendLine(",UNDONE_PROJECT");
            sb.AppendLine(",PROBLEM");
            sb.AppendLine(",TEMPORARY_PROJECT");
            sb.AppendLine(",VERIFY_SUGGESTION");
            sb.AppendLine("  from T_REPORT_DECK_MAINTAIN ");
            sb.AppendLine("where 1=1");
            if (!string.IsNullOrEmpty(SHIP_ID))
                sb.AppendLine(" and SHIP_ID ='" + SHIP_ID + "'");
            if (YEAR != DateTime.MinValue)
                sb.AppendLine(" and datediff(year,REPORT_DATE,'" + YEAR + "')=0");
            sb.AppendLine(" order by REPORT_DATE desc");
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }
    }
}
