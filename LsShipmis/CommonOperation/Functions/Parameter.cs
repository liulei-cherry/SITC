using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Reflection;
using CommonOperation;
using CommonOperation.Interfaces;

namespace CommonOperation.Functions
{
    public class tableException : Exception
    {
        public tableException() { }
    }

    public static class Parameter
    {
        private static IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();

        public static IDBAccess DbAccess
        {
            get
            {
                return Parameter.dbAccess;
            }
            set
            {
                Parameter.dbAccess = value;
            }
        }
        public static Dictionary<string, string> ParameterArr = new Dictionary<string, string>();

        public static DataTable GetParameter(string connectString)
        {
            DbAccess = InterfaceInstantiation.NewADbAccess(connectString);
            return GetParameter();
        }

        public static DataTable GetParameter()
        {
            DataTable dtb;//定义一个DataTable对象.
            string sErrMessage = "";        //错误信息返回参数.
            string sSql;
            sSql = "select VERSION,ISSHIPVERSION,T_PARAMETER.SHIP_ID,t_ship.ship_name,otherid1,otherid2,otherid3,otherid4,otherid5 from T_PARAMETER left join t_ship on t_ship.ship_id=T_PARAMETER.ship_id";

            if (!dbAccess.GetDataTable(sSql, out dtb, out sErrMessage))
            {
                throw new Exception(sErrMessage);
            }

            if (dtb.Rows.Count != 1)
            {
                throw new Exception("T_Parameter中未配置正确,当前系统无法读取足够的支持信息,很多系统功能将无法正常使用");
            }
            ParameterArr.Clear();
            ParameterArr.Add("Version", dtb.Rows[0][0].ToString());
            ParameterArr.Add("ISSHIPVERSION", dtb.Rows[0][1].ToString());
            ParameterArr.Add("SHIP_ID", dtb.Rows[0][2].ToString());
            ParameterArr.Add("SHIP_NAME", dtb.Rows[0][3].ToString());
            ParameterArr.Add("OTHERID1", dtb.Rows[0][4].ToString());
            ParameterArr.Add("OTHERID2", dtb.Rows[0][5].ToString());
            ParameterArr.Add("OTHERID3", dtb.Rows[0][6].ToString());
            ParameterArr.Add("OTHERID4", dtb.Rows[0][7].ToString());
            ParameterArr.Add("OTHERID5", dtb.Rows[0][8].ToString());

            return dtb;

        }
        private static void doing()
        {
            if (ParameterArr.Count == 0)
            {
                GetParameter();
            }
        }

        public static string GetShipId()
        {
            doing();
            return ParameterArr["SHIP_ID"];
        }

        public static string GetIsShipVersion()
        {
            doing();
            return ParameterArr["ISSHIPVERSION"];
        }

        public static string GetVersion()
        {
            doing();
            return ParameterArr["Version"];
        }

        public static string GetShipName()
        {
            doing();
            return ParameterArr["SHIP_NAME"];
        }
        public static string GetXMLShipPostConfigure()
        {
            doing();
            return ParameterArr["OTHERID1"];
        }

        /// <summary>
        /// 用于 T_ARGUMENT_SET 表：得到  T_ARGUMENT_SET 所有数据信息.
        /// </summary>
        public static DataTable getInfo(out string err)
        {
            string sql = "select	"
                  + "SYS_ID"
                  + ",CODE"
                  + ",CODE_VALUE"
                  + ",INTRO"
                  + "  from T_ARGUMENT_SET ";
            DataTable dt;
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                return dt;
            }
            else
            { 
                throw new Exception(err);
            }
        }
    }
}
