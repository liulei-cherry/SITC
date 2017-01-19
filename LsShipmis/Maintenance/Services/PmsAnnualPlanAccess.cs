using CommonOperation.Functions;
using CommonOperation.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Maintenance.Services
{
    public class PmsAnnualPlanAccess
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static PmsAnnualPlanAccess instance = new PmsAnnualPlanAccess();
        public static PmsAnnualPlanAccess Instance
        {
            get
            {
                if (null == instance)
                {
                    PmsAnnualPlanAccess.instance = new PmsAnnualPlanAccess();
                }
                return PmsAnnualPlanAccess.instance;
            }
        }
        private PmsAnnualPlanAccess() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();

        public DataTable GetPmsAnnualPlan(String shipId, String departmentHeaderPostId,String beginDate,String endDate,out String errMessage)
        {
            String sql = String.Format(@" EXEC [dbo].[P_Get_YearWorkOrderPlan]
		@shipid = '{0}',
		@departhead = '{1}',
		@datebegin = '{2}',
		@dateend = '{3}'", shipId, departmentHeaderPostId,beginDate,endDate);

            return dbAccess.GetDataTable(sql,out errMessage);
        }
    }
}
