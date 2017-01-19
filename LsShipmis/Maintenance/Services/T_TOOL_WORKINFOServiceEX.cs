/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：T_TOOL_WORKINFOService.cs
 * 创 建 人：黄家龙
 * 创建时间：2011/10/19
 * 标    题：数据操作类
 * 功能描述：T_TOOL_WORKINFO数据操作类
 * Codesmith DataAccessLayer.cst 1.01版本生成
 ****************************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BaseInfo.Objects;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using Maintenance.DataObject;

namespace  Maintenance.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_TOOL_WORKINFOService.cs
    /// </summary>
    public partial class T_TOOL_WORKINFOService
    {
		/// <summary>
		/// 得到  T_TOOL_WORKINFO 所有字段名和字段备注信息信息.
		/// </summary>
		/// <returns>T_TOOL_WORKINFO DataTable</returns>
        public DataTable getColumnsInfo(string tableName,out string err)
		{
            err = "";
            sql = "SELECT"
                + " 字段名=a.name,"
                + " 字段说明=isnull(g.[value],'')"
                + " FROM   syscolumns   a"
                + " left   join   systypes   b   on   a.xusertype=b.xusertype"
                + " inner   join   sysobjects   d   on   a.id=d.id     and   d.xtype='U'   and     d.name<>'dtproperties'"
                + " left   join   sys.extended_properties   g   on   a.id=g.major_id   and   a.colid=g.minor_id"
                + " left   join   sys.extended_properties   f   on   d.id=f.major_id   and   f.minor_id=0"
                + " where   d.name = '" + dbOperation.ReplaceSqlKeyStr(tableName.ToUpper()) + "'";
			DataTable dt;

			if(dbAccess.GetDataTable(sql,out dt, out err))
			{
				return dt;
			}
			else
			{
				throw new Exception(err);
			}
		}

        public DataTable getColumnsInfoTwo(string tableName,decimal type, out string err)
        {
            err = "";
            sql = "SELECT k.MAPID,k.TOOL_COLUMN_NAME,h.字段名,h.字段说明,k.ORDER_NUM FROM "
                + " (SELECT"
                + " 字段名=a.name"
                + " ,字段说明=isnull(g.[value],'')"
                + " FROM   syscolumns   a"
                + " left   join   systypes   b   on   a.xusertype=b.xusertype"
                + " inner   join   sysobjects   d   on   a.id=d.id     and   d.xtype='U'   and     d.name<>'dtproperties'"
                + " left   join   sys.extended_properties   g   on   a.id=g.major_id   and   a.colid=g.minor_id"
                + " left   join   sys.extended_properties   f   on   d.id=f.major_id   and   f.minor_id=0"
                + " where   d.name = '" + dbOperation.ReplaceSqlKeyStr(tableName.ToUpper()) + "'"
                + " ) H left join  T_TOOL_WORKINFO_COLUMN_MAP k on H.字段名 = K.WORK_COLUMN_NAME"
                + " and k.MAPTYPE = " + type
                + " order by k.ORDER_NUM";

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

        /// <summary>
        /// 得到  T_TOOL_WORKINFO 表部分字段信息.
        /// </summary>
        /// <returns>T_TOOL_WORKINFO DataTable</returns>
        public DataTable getLittleColumnsInfo(out string err)
        {
            err = "";
            sql = "SELECT  'ORDERNUM_SHOW' as 字段名 , '显示排序号' as 字段说明, '' as 映射EXCEL单元格 "
                + " UNION "
                + "SELECT  'CLASS1' as 字段名 , '一级分类' as 字段说明, '' as 映射EXCEL单元格 "
                + " UNION "
                + "SELECT  'CLASS2' as 字段名 , '二级分类' as 字段说明, '' as 映射EXCEL单元格 "
                + " UNION "
                + "SELECT 'WORKINFONAME' as 字段名 , '工作信息名称' as 字段说明, '' as 映射EXCEL单元格 "
                + " UNION "
                + "SELECT  'WORKINFODETAIL'as 字段名 , '工作信息内容' as 字段说明, '' as 映射EXCEL单元格 "
                + " UNION "
                + "SELECT  'CIRCLEORTIMING_INI'as 字段名 , '定期定时初始化项' as 字段说明, '' as 映射EXCEL单元格 "
                + " UNION "
                + "SELECT  'CIRCLEPERIOD'as 字段名 , '定期周期' as 字段说明, '' as 映射EXCEL单元格 "
                + " UNION "
                + "SELECT  'CIRCLEPERIOD_INI'as 字段名 , '定期周期初始化项' as 字段说明, '' as 映射EXCEL单元格 "
                + " UNION "
                + "SELECT  'TIMINGPERIOD'as 字段名 , '定时周期' as 字段说明, '' as 映射EXCEL单元格 "
                + " UNION "
                + "SELECT  'PRINCIPALPOST_INI'as 字段名 , '负责人岗位初始化项' as 字段说明, '' as 映射EXCEL单元格 "
                + " UNION "
                + "SELECT  'CONFIRMPOST_INI'as 字段名 , '确认人岗位初始化项' as 字段说明, '' as 映射EXCEL单元格 "
                + " UNION "
                + "SELECT  'ISCHECKPROJECT_INI'as 字段名 , '检验项目初始化项' as 字段说明, '' as 映射EXCEL单元格 "
                + " UNION "
                + "SELECT  'ISREPAIRPROJECT_INI'as 字段名 , '修理项目初始化项' as 字段说明, '' as 映射EXCEL单元格 "
                + " UNION "
                + "SELECT  'MONTHS_CHECK'as 字段名 , '月保养勾选' as 字段说明, '' as 映射EXCEL单元格 "
                + " UNION "
                + "SELECT  'EX1'as 字段名 , '扩展项1' as 字段说明, '' as 映射EXCEL单元格 "
                + " UNION "
                + "SELECT  'EX2'as 字段名 , '扩展项2' as 字段说明, '' as 映射EXCEL单元格 "
                + " UNION "
                + "SELECT  'EX3'as 字段名 , '扩展项3' as 字段说明, '' as 映射EXCEL单元格 "
                + " UNION "
                + "SELECT  'EX4'as 字段名 , '扩展项4' as 字段说明, '' as 映射EXCEL单元格 "
                + " UNION "
                + "SELECT  'EX5'as 字段名 , '扩展项5' as 字段说明, '' as 映射EXCEL单元格 ";
                //+ " UNION "
                //+ "SELECT  ''as 字段名 , '' as 字段说明, '' as 映射EXCEL单元格 "
                //+ " UNION "
                
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

        public DataTable getInitialData(string ship_id, int DEPARTMENT_TYPE, out string err)
        {
            err = "";
            sql = " SELECT "
            + " [EXCEL_ORDERNUM] " //0
            + " ,[ORDERNUM_SHOW] "
            + ",[CLASS1] "
            + ",[CLASS2] "
            + ",C.COMP_CHINESE_NAME"
            + ",[WORKINFONAME] "
            + ",[WORKINFODETAIL] "
            + ",CASE  WHEN [CIRCLEORTIMING] = '1' THEN '定期' WHEN [CIRCLEORTIMING] ='2'  THEN '定时' WHEN [CIRCLEORTIMING] ='3' THEN '定期定时' WHEN [CIRCLEORTIMING] ='4' THEN '非周期' ELSE '0'  END AS [CIRCLEORTIMING]"
            + ",[CIRCLEORTIMING_INI] "
            + ",[CIRCLEPERIOD] "
            + ",[CIRCLEPERIOD_INI] "//10
            + ",[CIRCLEUNIT] "
            + ",[CIRCLEFRONTLIMIT] "
            + ",[CIRCLEBACKLIMIT] "
            + ",[CIRCLELIMITUNIT] "
            + ",[TIMINGPERIOD] "
            + ",[TIMINGFRONTLIMIT] "
            + ",[TIMINGBACKLIMIT] "
            + ",[PRINCIPALPOST_INI] "
            + ",[CONFIRMPOST_INI] "
            + ",[ISCHECKPROJECT] "//20
            + ",[ISCHECKPROJECT_INI] "
            + ",[ISREPAIRPROJECT] "
            + ",[ISREPAIRPROJECT_INI] "
                //+ ",B.[SHIP_NAME] "
            + ",[MONTHS_CHECK] "
            + ",[ISBAK] "//25
            + ",[EX1] "
            + ",[EX2] "
            + ",[EX3] "
            + ",[EX4] "
            + ",[EX5] "//30
            + ",[WORKINFOID] "
            + ",[REFOBJID] "
            + ",[PRINCIPALPOST] "
            + ",[CONFIRMPOST] "
            + ",[WORKINFOTYPE] "//35
            + ",[ITEMTYPE]"
            + ",[DEPARTMENT_TYPE]"
            + " FROM [T_TOOL_WORKINFO] A LEFT JOIN [T_SHIP] B "
            + " ON A.SHIP_ID = B.SHIP_ID LEFT JOIN T_COMPONENT_UNIT C ON A.REFOBJID = C.COMPONENT_UNIT_ID"
            + " WHERE A.SHIP_ID = '" + dbOperation.ReplaceSqlKeyStr(ship_id.ToUpper()) + "'"
            + " AND A.DEPARTMENT_TYPE = " + DEPARTMENT_TYPE
            + " ORDER BY A.EXCEL_ORDERNUM";
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

        public DataTable getInitialInfo(out string err)
        {
            err = "";
            sql = "SELECT [MAPID]"
                + ",[TOOL_COLUMN_NAME]"
                + ",[WORK_COLUMN_NAME]"
                + ",[MAPTYPE]"
                + ",[ORDER_NUM]"
                + " FROM [T_TOOL_WORKINFO_COLUMN_MAP]";
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

        /// <summary>
        /// 清空临时表中所有数据.
        /// </summary>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool deleteAllData(string ship_id, int DEPARTMENT_TYPE, out string err)
        {
            err = "";
            sql = " DELETE FROM [T_TOOL_WORKINFO] "
                + " WHERE A.SHIP_ID = '" + dbOperation.ReplaceSqlKeyStr(ship_id.ToUpper()) + "'"
                + " AND A.DEPARTMENT_TYPE = " + DEPARTMENT_TYPE;
            if(!dbAccess.ExecSql(sql,out err))
            {
                return false;
            }
            return true;
        }

        public void deleteBatch(DataTable dtb, string sTableName, int mark, out string err)
        {
            dbOperation.SaveFormData(dtb, sTableName, mark,out err);
        }

        /// <summary>
        /// 获取所有船舶信息.
        /// </summary>
        public DataTable GetOwnerShip(out string err)
        {
            sql = "select a.*  from T_SHIP a ";
            sql += "\r order by a.SHIP_CODE,a.SHIP_NAME";
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

        #region FrmToolWorkInfoUnit窗体部分服务
        public DataTable getSomeInfo(string ship_id,int DEPARTMENT_TYPE, out string err)
        {
             err = "";
             sql = " SELECT "
                  + " [WORKINFOID] " //0
                  + ",[ORDERNUM_SHOW] "
                  + " ,B.[COMP_CHINESE_NAME]"
                  + ",[REFOBJID] "
                  + ",[CLASS1] "
                  + ",[CLASS2] "
                  + ",[WORKINFONAME] "
                  + ",[WORKINFODETAIL] "
                  + " FROM [T_TOOL_WORKINFO] A LEFT JOIN  T_COMPONENT_UNIT B"
                  + " ON A.REFOBJID = B.COMPONENT_UNIT_ID "
                  + " WHERE A.SHIP_ID = '" + dbOperation.ReplaceSqlKeyStr(ship_id.ToUpper())  + "'"
                  + " AND A.DEPARTMENT_TYPE = " + DEPARTMENT_TYPE
                  + " ORDER BY [EXCEL_ORDERNUM]";
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

        public DataTable getInitInfoTwo(out string err)
        {
            err = "";
            sql = "SELECT TOP 0 '' AS 设备名称 ,'' as 父设备名称 ,'' as 设备ID ";
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

        #endregion

        /// <summary>
        /// 导入功能.
        /// </summary>
        /// <param name="?"></param>
        /// <param name="?"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool importToTables(Dictionary<string, string> workinfo, Dictionary<string, string> WORKINFOHISTORY,int reporttype, string ship_id,string datetime,out string err)
        {
            err = "";
            string selectsql = "";
            sql = "INSERT INTO T_WORKINFO(";
            foreach(string key in workinfo.Keys)
            {
                sql += key + ",";
                if (!string.IsNullOrEmpty(workinfo[key]))
                {
                    selectsql += workinfo[key] + ",";
                }
                else
                {
                    selectsql += "null" + ",";
                }
            }
            sql = sql.Substring(0, sql.Length - 1);
            sql += ",WORKINFOSTATE";
            sql += ")SELECT ";
            sql += selectsql.Substring(0, selectsql.Length - 1)
                +",0"
                +" FROM T_TOOL_WORKINFO"
                + " WHERE SHIP_ID = " + "'" + ship_id.ToUpper() + "'"
                + " AND ITEMTYPE = '1'"
                + " AND DEPARTMENT_TYPE = '"+ reporttype+ "'";

            string sql1 = "";
            string selectsql1 = "";
            sql1 = "INSERT INTO T_WORKINFO_HISTORY_OUT(";
            foreach (string key in WORKINFOHISTORY.Keys)
            {
                sql1 += key + ",";
                if (!string.IsNullOrEmpty(WORKINFOHISTORY[key]))
                {
                    selectsql1 += WORKINFOHISTORY[key] + ",";
                }
                else
                {
                     selectsql1 += "null" + ",";
                }
            }
            sql1 = sql1.Substring(0, sql1.Length - 1);
            sql1 += ") SELECT ";
            sql1 += selectsql1.Substring(0, selectsql1.Length - 1);
            sql1 += " FROM T_TOOL_WORKINFO";
            sql1 += " WHERE SHIP_ID = " + "'" + dbOperation.ReplaceSqlKeyStr(ship_id.ToUpper()) + "'";
            sql1 += " AND DEPARTMENT_TYPE = '" + reporttype + "'";

            List<string> sqls = new List<string>();
            sqls.Add(sql);
            sqls.Add(sql1);
                
            return dbAccess.ExecSql(sqls,out err);
        }

        /// <summary>
        /// 获取岗位对应ID
        /// </summary>
        /// <param name="list"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public DataTable getPost(List<string> list,out string err)
        {
            err = "";
            sql = "SELECT SHIP_HEADSHIP_ID,HEADSHIP_NAME "
                + " FROM T_BASE_HEADSHIP ";
            if(list.Count > 0)
            {
                sql += " WHERE ";
                for (int I = 0; I < list.Count; I++)
                {
                    sql += "HEADSHIP_NAME = '" + dbOperation.ReplaceSqlKeyStr(list[I]) + "'";
                    if (I != list.Count - 1)
                    {
                        sql += " OR ";
                    }
                }
            }

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

        public void batchInsert(DataTable dtb, string sTableName, int mark, out string err)
        {
            err = "";
            dbOperation.SaveFormData(dtb, sTableName, mark, out err);
        }
    }
}
