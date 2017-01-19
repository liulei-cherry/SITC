using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.Functions;
using System.Data;
using CommonOperation.Interfaces;

namespace Maintenance.Services
{
    /// <summary>
    /// 跟CMS结合的服务类.
    /// </summary>
    public class CMSCheckingService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static CMSCheckingService instance = new CMSCheckingService();
        public static CMSCheckingService Instance
        {
            get
            {
                if (null == instance)
                {
                    CMSCheckingService.instance = new CMSCheckingService();
                }
                return CMSCheckingService.instance;
            }
        }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";
          
        /// <summary>
        /// 引用的工作信息必须是‘检验类’项目，且没有被引用过，且状态必须是正常运行。.
        /// 注：软件可以考虑增加如下功能“检验类的工作信息周期仅允许是定期周期的”。.
        /// 然而这个功能在PMS检验中不适用，如果纯执行PMS检验的话，定时周期更为有效。所以暂时不考虑.
        /// </summary>
        /// <param name="shipId">那个船舶的工作信息</param>
        /// <param name="dtb">输出的数据</param>
        /// <param name="err">错误描述</param>
        /// <returns>是否成功</returns>
        public bool GetAllWorkInfoOfChecking(string shipId,out DataTable dtb, out string err)
        {
            sql = " SELECT t1.[WORKINFOID], t1.[WORKINFONAME], t1.[WORKINFODETAIL]"
                + "\rFROM [T_WORKINFO] t1 left join T_CMS_CONFIG t2 on t1.WORKINFOID = t2.WORKINFOID"
                + "\rwhere t2.WORKINFOID is null and t1.ischeckproject = 1 and t1.WORKINFOSTATE = 1 "
                + "and t1.ship_id = '" + shipId + "' order by t1.REFOBJID, t1.WORKINFONAME";
            //定期定时（1定期，2定时，3定期＋定时）.
            return dbAccess.GetDataTable(sql, out dtb, out err);
           
        }
    }
}
