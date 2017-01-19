using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.Functions;
using CommonOperation.Interfaces;

namespace StorageManage.Services
{
    public class StorageCommonService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static StorageCommonService instance = new StorageCommonService();
        public static StorageCommonService Instance
        {
            get
            {
                if (null == instance)
                {
                    StorageCommonService.instance = new StorageCommonService();
                }
                return StorageCommonService.instance;
            }
        }
        #endregion
        
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation(); 

        private StorageCommonService()
        {

        }
      
        /// <summary>
        /// 出入库单编号（组成规则：B船舶编号+两位年份+两位月份+序列号(三位))
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <returns>返回加工好的物资出入库单编号</returns>
        public string GetSpareAndMaterialInOrOutCode(string shipId)
        {
            string err = ""; //错误信息返回参数.
            string sSql = "";           //SQL查询语句.
            string sShipCode = "";      //船舶编号.
            string sMaxNumb = "";       //出入库单最大序列号（字符型）.
            int maxNumb = 0;            //出入库单最大序列号（数值型）.
            string applyCode = "";      //出入库单.

            //1.取船舶编号.
            sSql = "select ship_code from t_ship where ship_Id = '" + shipId + "'";
            dbAccess.GetString(sSql, out sShipCode, out err);
            if (sShipCode.Length == 0) sShipCode = "NoShip";

            //2.取两位年份两位月份.
            string theYear = "";
            theYear = DateTime.Now.ToString("yyMM");

            //3.取最大序列号（取t_spare_apply与t_material_apply中的最大序列号）.

            sSql = "select max(OPERATION_CODE) from (";
            sSql += "select cast(right(OPERATION_CODE,3) as int) as OPERATION_CODE from T_SPARE_DEPOT_OPERATION where ship_id = '" + shipId + "'";
            sSql += "union ";
            sSql += "select cast(right(OPERATION_CODE,3) as int) as OPERATION_CODE from t_material_DEPOT_OPERATION where ship_id = '" + shipId + "') a";
            dbAccess.GetString(sSql, out sMaxNumb, out err);
            if (sMaxNumb == "") sMaxNumb = "0";
            maxNumb = int.Parse(sMaxNumb) + 1;

            if (maxNumb < 1000)
            {
                applyCode = "B" + sShipCode + "-" + theYear + string.Format("{0:000}", maxNumb);
            }
            else
            {
                applyCode = "B" + sShipCode + "-" + theYear + maxNumb.ToString();
            }

            return applyCode;
        }

        /// <summary>
        /// 盘点单编号（组成规则：C船舶编号+两位年份+两位月份+序列号(三位))
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <returns>返回加工好的物资出入库单编号</returns>
        public string GetSpareAndMaterialCheckCode(string shipId)
        {
            string err = ""; //错误信息返回参数.
            string sSql = "";           //SQL查询语句.
            string sShipCode = "";      //船舶编号.
            string sMaxNumb = "";       //出入库单最大序列号（字符型）.
            int maxNumb = 0;            //出入库单最大序列号（数值型）.
            string checkCode = "";      //出入库单.

            //1.取船舶编号.
            sSql = "select ship_code from t_ship where ship_Id = '" + shipId + "'";
            dbAccess.GetString(sSql, out sShipCode, out err);
            if (sShipCode.Length == 0) sShipCode = "NoShip";

            //2.取两位年份两位月份.
            string theYear = "";
            theYear = DateTime.Now.ToString("yyMM");

            //3.取最大序列号（取t_spare_apply与t_material_apply中的最大序列号）.

            sSql = "select max(CHECK_CODE) from (";
            sSql += "select cast(right(CHECK_CODE,3) as int) as CHECK_CODE from T_SPARE_DEPOT_CHECK where ship_id = '" + shipId + "'";
            sSql += "union ";
            sSql += "select cast(right(CHECK_CODE,3) as int) as CHECK_CODE from T_MATERIAL_DEPOT_CHECK where ship_id = '" + shipId + "') a";
            dbAccess.GetString(sSql, out sMaxNumb, out err);
            if (sMaxNumb == "") sMaxNumb = "0";
            maxNumb = int.Parse(sMaxNumb) + 1;

            if (maxNumb < 1000)
            {
                checkCode = "C" + sShipCode + "-" + theYear + string.Format("{0:000}", maxNumb);
            }
            else
            {
                checkCode = "C" + sShipCode + "-" + theYear + maxNumb.ToString();
            }

            return checkCode;
        }
      
    }
}
