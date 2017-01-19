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
    partial class ShipOilWareHouseService : IObjectsService
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

            reValue.Add("cgxh", "舱柜编号");
            reValue.Add("xrj", "舱柜型容积");
            reValue.Add("jrj", "舱柜净容积");
            reValue.Add("wz", "舱柜位置");
            return reValue;
        }

        #endregion

        /// <summary>
        ///  取得指定船舶的油水舱柜信息.
        /// </summary>
        /// <returns>返回一个DataTable对象</returns>
        public DataTable GetShipWare(string shipId)
        {
            //变量定义部分.
            DataTable dtb;    //定义一个DataTable对象.
            string err = "";         //错误信息返回参数.
            string sSql = "";                   //查询数据所需的SQL语句.

            //Select语句加工部分.
            sSql += "select ";
            sSql += "owWareHouse_id, ship_id, cgxh, wz, xrj,";
            sSql += "jrj, remark, creator ";
            sSql += "from t_ship_owWareHouse where ship_id = '" + shipId + "'";
            sSql += "order by cgxh";

            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }
    }
}
