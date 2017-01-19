using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.Interfaces;
using BaseInfo.Objects;
using OfficeOperation;
using System.IO;
using System.Data;
using FileOperationBase.FileServices;

namespace BaseInfo.DataAccess
{
    partial class ShipHoldService : IObjectsService
    {
        #region IObjectsService 成员

        public CommonOperation.BaseClass.CommonClass GetOneObjectById(string id)
        {
            string err;
            return getObject(id, out err);
        }

        public Dictionary<string, string> GetObjectDisplaySetting()
        {
            Dictionary<string, string> reValue = new Dictionary<string, string>();

            reValue.Add("hcbh", "货舱编号");
            reValue.Add("ckcd", "舱口长度");
            reValue.Add("ckkd", "舱口宽度");
            reValue.Add("cncd", "舱内长度");
            reValue.Add("cnkd", "舱内宽度");
            reValue.Add("cngd", "舱内高度");
            reValue.Add("szrj", "散装容积");
            reValue.Add("bzrj", "包装容积");
            reValue.Add("qhsb", "起货设备");
            return reValue;
        }

        #endregion

        /// <summary>
        ///  取得指定船舶的货舱信息.
        /// </summary>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetShipHold(string shipId)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql += "select ";
            sSql += "hold_id, ship_id, hcbh, ckcd, ckkd,";
            sSql += "cncd, cnkd, cngd, szrj, bzrj, qhsb, remark, creator ";
            sSql += "from t_ship_hold where ship_id = '" + shipId + "'";
            sSql += "order by hcbh";

            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }
    }
}
