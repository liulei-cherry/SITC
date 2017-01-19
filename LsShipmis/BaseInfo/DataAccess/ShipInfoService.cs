/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：ShipInfoService.cs
 * 创 建 人：xuzhengben
 * 创建时间：2009-10-22
 * 标    题：数据操作类
 * 功能描述：T_SHIP数据操作类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
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

namespace BaseInfo.DataAccess
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_SHIPService.cs
    /// </summary>
    public partial class ShipInfoService
    {
        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static ShipInfoService instance = new ShipInfoService();
        public static ShipInfoService Instance
        {
            get
            {
                if (null == instance)
                {
                    ShipInfoService.instance = new ShipInfoService();
                }
                return ShipInfoService.instance;
            }
        }
        private ShipInfoService() { }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        string sql = "";

        #region 添加更新删除

        /// <summary>
        /// 向数据库中保存一条新记录。.
        /// </summary>
        /// <param name="unit">ShipInfo对象</param>
        /// <returns>插入的对象更新</returns>	
        internal bool saveUnit(ShipInfo unit, out string err)
        {
            if (unit.SHIP_ID != null && unit.SHIP_ID.Length > 0) //edit
            {
                sql = "UPDATE [T_SHIP] SET "
                    + " [SHIP_ID] = " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , [SHIP_NAME] = " + (unit.SHIP_NAME == null ? "''" : "'" + unit.SHIP_NAME.Replace("'", "''") + "'")
                    + " , [SHIP_EN_NAME] = " + (unit.SHIP_EN_NAME == null ? "''" : "'" + unit.SHIP_EN_NAME.Replace("'", "''") + "'")
                    + " , [SHIP_CODE] = " + (unit.SHIP_CODE == null ? "''" : "'" + unit.SHIP_CODE.Replace("'", "''") + "'")
                    + " , [SHIP_HH] = " + (unit.SHIP_HH == null ? "''" : "'" + unit.SHIP_HH.Replace("'", "''") + "'")
                    + " , [IMO] = " + (unit.IMO == null ? "''" : "'" + unit.IMO.Replace("'", "''") + "'")
                    + " , [MMSI] = " + (unit.MMSI == null ? "''" : "'" + unit.MMSI.Replace("'", "''") + "'")
                    + " , [CBDJH] = " + (unit.CBDJH == null ? "''" : "'" + unit.CBDJH.Replace("'", "''") + "'")
                    + " , [CQG] = " + (unit.CQG == null ? "''" : "'" + unit.CQG.Replace("'", "''") + "'")
                    + " , [CJG] = " + (unit.CJG == null ? "''" : "'" + unit.CJG.Replace("'", "''") + "'")
                    + " , [HQ] = " + (unit.HQ == null ? "''" : "'" + unit.HQ.Replace("'", "''") + "'")
                    + " , [CBSYR] = " + (unit.CBSYR == null ? "''" : "'" + unit.CBSYR.Replace("'", "''") + "'")
                    + " , [SHIP_TYPE] = " + (unit.SHIP_TYPE == null ? "''" : "'" + unit.SHIP_TYPE.Replace("'", "''") + "'")
                    + " , [XK] = " + unit.XK.ToString()
                    + " , [XS] = " + unit.XS.ToString()
                    + " , [ZC] = " + unit.ZC.ToString()
                    + " , [LZJC] = " + unit.LZJC.ToString()
                    + " , [QZCS] = " + unit.QZCS.ToString()
                    + " , [SJCS] = " + unit.SJCS.ToString()
                    + " , [QZPSL] = " + unit.QZPSL.ToString()
                    + " , [MZPSL] = " + unit.MZPSL.ToString()
                    + " , [ZD] = " + unit.ZD.ToString()
                    + " , [JD] = " + unit.JD.ToString()
                    + " , [ZZD] = " + unit.ZZD.ToString()
                    + " , [SYSZD] = " + unit.SYSZD.ToString()
                    + " , [BNMZD] = " + unit.BNMZD.ToString()
                    + " , [HS] = " + unit.HS.ToString()
                    + " , [ZDPY] = " + unit.ZDPY.ToString()
                    + " , [ZJXH] = " + (unit.ZJXH == null ? "''" : "'" + unit.ZJXH.Replace("'", "''") + "'")
                    + " , [ZJTS] = " + unit.ZJTS.ToString()
                    + " , [ZJGL] = " + unit.ZJGL.ToString()
                    + " , [ZJZS] = " + unit.ZJZS.ToString()
                    + " , [ZJJZC] = " + (unit.ZJJZC == null ? "''" : "'" + unit.ZJJZC.Replace("'", "''") + "'")
                    + " , [ZJCZRQ] = " + dbOperation.DbToDate(unit.ZJCZRQ)
                    + " , [FDJYDJXH] = " + (unit.FDJYDJXH == null ? "''" : "'" + unit.FDJYDJXH.Replace("'", "''") + "'")
                    + " , [FDJYDJTS] = " + unit.FDJYDJTS.ToString()
                    + " , [FDJYDJGL] = " + unit.FDJYDJGL.ToString()
                    + " , [FDJYDJZS] = " + unit.FDJYDJZS.ToString()
                    + " , [FDJXH] = " + (unit.FDJXH == null ? "''" : "'" + unit.FDJXH.Replace("'", "''") + "'")
                    + " , [FDJTS] = " + unit.FDJTS.ToString()
                    + " , [ZYCL] = " + unit.ZYCL.ToString()
                    + " , [QYCL] = " + unit.QYCL.ToString()
                    + " , [DSCL] = " + unit.DSCL.ToString()
                    + " , [YYKSRQ] = " + dbOperation.DbToDate(unit.YYKSRQ)
                    + " , [YYJSRQ] = " + dbOperation.DbToDate(unit.YYJSRQ)
                    + " , [CBZZC] = " + (unit.CBZZC == null ? "''" : "'" + unit.CBZZC.Replace("'", "''") + "'")
                    + " , [ZZRQ] = " + dbOperation.DbToDate(unit.ZZRQ)
                    + " , [ZDHS] = " + unit.ZDHS.ToString()
                    + " , [CD] = " + (unit.CD == null ? "''" : "'" + unit.CD.Replace("'", "''") + "'")
                    + " , [CW] = " + unit.CW.ToString()
                    + " , [ZJGJ] = " + unit.ZJGJ.ToString()
                    + " , [ZJXC] = " + unit.ZJXC.ToString()
                    + " , [ZJYH] = " + unit.ZJYH.ToString()
                    + " , [ZJSBZK] = " + (unit.ZJSBZK == null ? "''" : "'" + unit.ZJSBZK.Replace("'", "''") + "'")
                    + " , [FJKYSL] = " + unit.FJKYSL.ToString()
                    + " , [RYXH1] = " + (unit.RYXH1 == null ? "''" : "'" + unit.RYXH1.Replace("'", "''") + "'")
                    + " , [RYXH2] = " + (unit.RYXH2 == null ? "''" : "'" + unit.RYXH2.Replace("'", "''") + "'")
                    + " , [HYXH] = " + (unit.HYXH == null ? "''" : "'" + unit.HYXH.Replace("'", "''") + "'")
                    + " , [HYCR] = " + unit.HYCR.ToString()
                    + " , [PICTURE] = " + (unit.PICTURE == null ? "''" : "'" + unit.PICTURE.Replace("'", "''") + "'")
                    + " , [XHHL] = " + unit.XHHL.ToString()
                    + " , [XHTS] = " + unit.XHTS.ToString()
                    + " , [XZTL] = " + unit.XZTL.ToString()
                    + " , [TLZJ] = " + unit.TLZJ.ToString()
                    + " , [TLJTS] = " + unit.TLJTS.ToString()
                    + " , [ZDJ] = " + unit.ZDJ.ToString()
                    + " , [JSTSL] = " + unit.JSTSL.ToString()
                    + " , [JZTSL] = " + unit.JZTSL.ToString()
                    + " , [FDJGL] = " + unit.FDJGL.ToString()
                    + " , [MAINENGINE_EXAUST_M] = " + unit.MAINENGINE_EXAUST_M.ToString()
                    + " , [AUXILIARY_EXAUST_M] = " + unit.AUXILIARY_EXAUST_M.ToString()
                    + " , [AUXILIARY_EXAUST_G] = " + unit.AUXILIARY_EXAUST_G.ToString()
                    + " , [mainEngine_TowNum] = " + unit.mainEngine_TowNum.ToString()
                    + " , [mainEngine_MaxSpeedNum] = " + unit.mainEngine_MaxSpeedNum.ToString()
                    + " , [mainEngine_EcoSpeedNum] = " + unit.mainEngine_EcoSpeedNum.ToString()
                    + " , [mainEngine_CruiseNum] = " + unit.mainEngine_CruiseNum.ToString()
                    + " , [cjfh] = " + (unit.CJFH == null ? "''" : "'" + unit.CJFH.Replace("'", "''") + "'")
                    + " , [remark] = " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " , [SSFGS] = " + (unit.SSFGS == null ? "''" : "'" + unit.SSFGS.Replace("'", "''") + "'")
                    + " where upper(SHIP_ID) = '" + unit.SHIP_ID.ToUpper() + "'";
            }
            else
            {
                unit.SHIP_ID = Guid.NewGuid().ToString();
                sql = "INSERT INTO [T_SHIP] ("
                    + "[SHIP_ID],"
                    + "[SHIP_NAME],"
                    + "[SHIP_EN_NAME],"
                    + "[SHIP_CODE],"
                    + "[SHIP_HH],"
                    + "[IMO],"
                    + "[MMSI],"
                    + "[CBDJH],"
                    + "[CQG],"
                    + "[CJG],"
                    + "[HQ],"
                    + "[CBSYR],"
                    + "[SHIP_TYPE],"
                    + "[XK],"
                    + "[XS],"
                    + "[ZC],"
                    + "[LZJC],"
                    + "[QZCS],"
                    + "[SJCS],"
                    + "[QZPSL],"
                    + "[MZPSL],"
                    + "[ZD],"
                    + "[JD],"
                    + "[ZZD],"
                    + "[SYSZD],"
                    + "[BNMZD],"
                    + "[HS],"
                    + "[ZDPY],"
                    + "[ZJXH],"
                    + "[ZJTS],"
                    + "[ZJGL],"
                    + "[ZJZS],"
                    + "[ZJJZC],"
                    + "[ZJCZRQ],"
                    + "[FDJYDJXH],"
                    + "[FDJYDJTS],"
                    + "[FDJYDJGL],"
                    + "[FDJYDJZS],"
                    + "[FDJXH],"
                    + "[FDJTS],"
                    + "[ZYCL],"
                    + "[QYCL],"
                    + "[DSCL],"
                    + "[YYKSRQ],"
                    + "[YYJSRQ],"
                    + "[CBZZC],"
                    + "[ZZRQ],"
                    + "[ZDHS],"
                    + "[CD],"
                    + "[CW],"
                    + "[ZJGJ],"
                    + "[ZJXC],"
                    + "[ZJYH],"
                    + "[ZJSBZK],"
                    + "[FJKYSL],"
                    + "[RYXH1],"
                    + "[RYXH2],"
                    + "[HYXH],"
                    + "[HYCR],"
                    + "[PICTURE],"
                    + "[XHHL],"
                    + "[XHTS],"
                    + "[XZTL],"
                    + "[TLZJ],"
                    + "[TLJTS],"
                    + "[ZDJ],"
                    + "[JSTSL],"
                    + "[JZTSL],"
                    + "[FDJGL],"
                    + "[MAINENGINE_EXAUST_M],"
                    + "[AUXILIARY_EXAUST_M],"
                    + "[AUXILIARY_EXAUST_G],"
                    + "[mainEngine_TowNum],"
                    + "[mainEngine_MaxSpeedNum],"
                    + "[mainEngine_EcoSpeedNum],"
                    + "[mainEngine_CruiseNum],"
                    + "[cjfh],"
                    + "[remark],"
                    + "[SSFGS]"
                    + ") VALUES( "
                    + " " + (string.IsNullOrEmpty(unit.SHIP_ID) ? "null" : "'" + unit.SHIP_ID.Replace("'", "''") + "'")
                    + " , " + (unit.SHIP_NAME == null ? "''" : "'" + unit.SHIP_NAME.Replace("'", "''") + "'")
                    + " , " + (unit.SHIP_EN_NAME == null ? "''" : "'" + unit.SHIP_EN_NAME.Replace("'", "''") + "'")
                    + " , " + (unit.SHIP_CODE == null ? "''" : "'" + unit.SHIP_CODE.Replace("'", "''") + "'")
                    + " , " + (unit.SHIP_HH == null ? "''" : "'" + unit.SHIP_HH.Replace("'", "''") + "'")
                    + " , " + (unit.IMO == null ? "''" : "'" + unit.IMO.Replace("'", "''") + "'")
                    + " , " + (unit.MMSI == null ? "''" : "'" + unit.MMSI.Replace("'", "''") + "'")
                    + " , " + (unit.CBDJH == null ? "''" : "'" + unit.CBDJH.Replace("'", "''") + "'")
                    + " , " + (unit.CQG == null ? "''" : "'" + unit.CQG.Replace("'", "''") + "'")
                    + " , " + (unit.CJG == null ? "''" : "'" + unit.CJG.Replace("'", "''") + "'")
                    + " , " + (unit.HQ == null ? "''" : "'" + unit.HQ.Replace("'", "''") + "'")
                    + " , " + (unit.CBSYR == null ? "''" : "'" + unit.CBSYR.Replace("'", "''") + "'")
                    + " , " + (unit.SHIP_TYPE == null ? "''" : "'" + unit.SHIP_TYPE.Replace("'", "''") + "'")
                    + " ," + unit.XK.ToString()
                    + " ," + unit.XS.ToString()
                    + " ," + unit.ZC.ToString()
                    + " ," + unit.LZJC.ToString()
                    + " ," + unit.QZCS.ToString()
                    + " ," + unit.SJCS.ToString()
                    + " ," + unit.QZPSL.ToString()
                    + " ," + unit.MZPSL.ToString()
                    + " ," + unit.ZD.ToString()
                    + " ," + unit.JD.ToString()
                    + " ," + unit.ZZD.ToString()
                    + " ," + unit.SYSZD.ToString()
                    + " ," + unit.BNMZD.ToString()
                    + " ," + unit.HS.ToString()
                    + " ," + unit.ZDPY.ToString()
                    + " , " + (unit.ZJXH == null ? "''" : "'" + unit.ZJXH.Replace("'", "''") + "'")
                    + " ," + unit.ZJTS.ToString()
                    + " ," + unit.ZJGL.ToString()
                    + " ," + unit.ZJZS.ToString()
                    + " , " + (unit.ZJJZC == null ? "''" : "'" + unit.ZJJZC.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.ZJCZRQ)
                    + " , " + (unit.FDJYDJXH == null ? "''" : "'" + unit.FDJYDJXH.Replace("'", "''") + "'")
                    + " ," + unit.FDJYDJTS.ToString()
                    + " ," + unit.FDJYDJGL.ToString()
                    + " ," + unit.FDJYDJZS.ToString()
                    + " , " + (unit.FDJXH == null ? "''" : "'" + unit.FDJXH.Replace("'", "''") + "'")
                    + " ," + unit.FDJTS.ToString()
                    + " ," + unit.ZYCL.ToString()
                    + " ," + unit.QYCL.ToString()
                    + " ," + unit.DSCL.ToString()
                    + " ," + dbOperation.DbToDate(unit.YYKSRQ)
                    + " ," + dbOperation.DbToDate(unit.YYJSRQ)
                    + " , " + (unit.CBZZC == null ? "''" : "'" + unit.CBZZC.Replace("'", "''") + "'")
                    + " ," + dbOperation.DbToDate(unit.ZZRQ)
                    + " ," + unit.ZDHS.ToString()
                    + " , " + (unit.CD == null ? "''" : "'" + unit.CD.Replace("'", "''") + "'")
                    + " ," + unit.CW.ToString()
                    + " ," + unit.ZJGJ.ToString()
                    + " ," + unit.ZJXC.ToString()
                    + " ," + unit.ZJYH.ToString()
                    + " , " + (unit.ZJSBZK == null ? "''" : "'" + unit.ZJSBZK.Replace("'", "''") + "'")
                    + " ," + unit.FJKYSL.ToString()
                    + " , " + (unit.RYXH1 == null ? "''" : "'" + unit.RYXH1.Replace("'", "''") + "'")
                    + " , " + (unit.RYXH2 == null ? "''" : "'" + unit.RYXH2.Replace("'", "''") + "'")
                    + " , " + (unit.HYXH == null ? "''" : "'" + unit.HYXH.Replace("'", "''") + "'")
                    + " ," + unit.HYCR.ToString()
                    + " , " + (unit.PICTURE == null ? "''" : "'" + unit.PICTURE.Replace("'", "''") + "'")
                    + " ," + unit.XHHL.ToString()
                    + " ," + unit.XHTS.ToString()
                    + " ," + unit.XZTL.ToString()
                    + " ," + unit.TLZJ.ToString()
                    + " ," + unit.TLJTS.ToString()
                    + " ," + unit.ZDJ.ToString()
                    + " ," + unit.JSTSL.ToString()
                    + " ," + unit.JZTSL.ToString()
                    + " ," + unit.FDJGL.ToString()
                    + " ," + unit.MAINENGINE_EXAUST_M.ToString()
                    + " ," + unit.AUXILIARY_EXAUST_M.ToString()
                    + " ," + unit.AUXILIARY_EXAUST_G.ToString()
                    + " ," + unit.mainEngine_TowNum.ToString()
                    + " ," + unit.mainEngine_MaxSpeedNum.ToString()
                    + " ," + unit.mainEngine_EcoSpeedNum.ToString()
                    + " ," + unit.mainEngine_CruiseNum.ToString()
                    + " , " + (unit.CJFH == null ? "''" : "'" + unit.CJFH.Replace("'", "''") + "'")
                    + " , " + (unit.REMARK == null ? "''" : "'" + unit.REMARK.Replace("'", "''") + "'")
                    + " , " + (unit.SSFGS == null ? "''" : "'" + unit.SSFGS.Replace("'", "''") + "'")
                    + ")";
            }

            return dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 删除数据表T_SHIP中的对象.
        /// </summary>
        /// <param name="unit">要删除的T_SHIP对象</param>
        internal bool deleteUnit(ShipInfo unit, out string err)
        {
            return deleteUnit(unit.SHIP_ID, out err);
        }

        /// <summary>
        /// 删除数据表T_SHIP中的一条记录.
        /// </summary>
        /// <param name="unit">要删除的T_SHIP.sHIP_ID主键</param>
        public bool deleteUnit(string unitid, out string err)
        {
            sql = "delete from T_SHIP where "
                + " upper(T_SHIP.SHIP_ID)='" + unitid.ToUpper() + "'";
            return dbAccess.ExecSql(sql, out err);
        }
        #endregion

        #region 数据实体
        /// <summary>
        /// 得到  T_SHIP 所有数据信息.
        /// </summary>
        /// <returns>T_SHIP DataTable</returns>
        public DataTable getInfo(out string err)
        {
            sql = "select	"
                + "SHIP_ID"
                + ",SHIP_NAME"
                + ",SHIP_EN_NAME"
                + ",SHIP_CODE"
                + ",SHIP_HH"
                + ",IMO"
                + ",MMSI"
                + ",CBDJH"
                + ",CQG"
                + ",CJG"
                + ",HQ"
                + ",CBSYR"
                + ",SHIP_TYPE"
                + ",XK"
                + ",XS"
                + ",ZC"
                + ",LZJC"
                + ",QZCS"
                + ",SJCS"
                + ",QZPSL"
                + ",MZPSL"
                + ",ZD"
                + ",JD"
                + ",ZZD"
                + ",SYSZD"
                + ",BNMZD"
                + ",HS"
                + ",ZDPY"
                + ",ZJXH"
                + ",ZJTS"
                + ",ZJGL"
                + ",ZJZS"
                + ",ZJJZC"
                + ",ZJCZRQ"
                + ",FDJYDJXH"
                + ",FDJYDJTS"
                + ",FDJYDJGL"
                + ",FDJYDJZS"
                + ",FDJXH"
                + ",FDJTS"
                + ",ZYCL"
                + ",QYCL"
                + ",DSCL"
                + ",YYKSRQ"
                + ",YYJSRQ"
                + ",CBZZC"
                + ",ZZRQ"
                + ",ZDHS"
                + ",CD"
                + ",CW"
                + ",ZJGJ"
                + ",ZJXC"
                + ",ZJYH"
                + ",ZJSBZK"
                + ",FJKYSL"
                + ",RYXH1"
                + ",RYXH2"
                + ",HYXH"
                + ",HYCR"
                + ",PICTURE"
                + ",XHHL"
                + ",XHTS"
                + ",XZTL"
                + ",TLZJ"
                + ",TLJTS"
                + ",ZDJ"
                + ",JSTSL"
                + ",JZTSL"
                + ",FDJGL"
                + ",MAINENGINE_EXAUST_M"
                + ",AUXILIARY_EXAUST_M"
                + ",AUXILIARY_EXAUST_G"
                + ",mainEngine_TowNum"
                + ",mainEngine_MaxSpeedNum"
                + ",mainEngine_EcoSpeedNum"
                + ",mainEngine_CruiseNum"
                + ",cjfh"
                + ",remark"
                + ",SSFGS"
                +  " from T_SHIP "
                + (CommonOperation.ConstParameter.IsLandVersion?
            @" where ship_id in ( select    tt1.Ship_Id  
from
(select SHIP_NAME,SHIP_ID ,case when charindex([SHIP_CODE],(select top 1 isnull([CODE_VALUE],'')
from [T_ARGUMENT_SET] where [CODE] = 'shandongship') )>0 then 1 else 0 end isShandong 
from T_SHIP) tt1 inner join 
(select top 1 t3.USERID ,case when substring(t2.HEADSHIP_NAME,1,2)= '山东' then 1 else 0 end ISShandong,t3.[USERLOGINNAME]
from T_SHIP_USER_HEAD t1
inner join T_BASE_HEADSHIP t2 on t1.SHIP_HEADSHIP_ID = t2.SHIP_HEADSHIP_ID
inner join T_SYS_USER t3 on t1.SHIPUSERID = t3.SHIPUSERID  and t3.USERID = '"+ CommonOperation.ConstParameter.UserId+@"'
) tt2 on (case when charindex(tt2.USERLOGINNAME,(select top 1 isnull([CODE_VALUE],'')
from [T_ARGUMENT_SET] where [CODE] = 'allshipperson') )>0 then 1 else 0 end ) = 1 or tt1.isshandong = tt2.isshandong  ) 
            order by SHIP_EN_NAME":""); //20150924 xuzb 船舶端不过滤，岸端要根据岗位过滤。烂代码，多包涵！
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
        /// 根据一个主键ID,得到 T_SHIP 的DataTable
        /// </summary>
        /// <param name="Id">主键ID</param>
        /// <returns>ShipInfo DataTable</returns>
        public DataTable getInfo(string Id, out string err)
        {
            sql = "select "
                + "SHIP_ID"
                + ",SHIP_NAME"
                + ",SHIP_EN_NAME"
                + ",SHIP_CODE"
                + ",SHIP_HH"
                + ",IMO"
                + ",MMSI"
                + ",CBDJH"
                + ",CQG"
                + ",CJG"
                + ",HQ"
                + ",CBSYR"
                + ",SHIP_TYPE"
                + ",XK"
                + ",XS"
                + ",ZC"
                + ",LZJC"
                + ",QZCS"
                + ",SJCS"
                + ",QZPSL"
                + ",MZPSL"
                + ",ZD"
                + ",JD"
                + ",ZZD"
                + ",SYSZD"
                + ",BNMZD"
                + ",HS"
                + ",ZDPY"
                + ",ZJXH"
                + ",ZJTS"
                + ",ZJGL"
                + ",ZJZS"
                + ",ZJJZC"
                + ",ZJCZRQ"
                + ",FDJYDJXH"
                + ",FDJYDJTS"
                + ",FDJYDJGL"
                + ",FDJYDJZS"
                + ",FDJXH"
                + ",FDJTS"
                + ",ZYCL"
                + ",QYCL"
                + ",DSCL"
                + ",YYKSRQ"
                + ",YYJSRQ"
                + ",CBZZC"
                + ",ZZRQ"
                + ",ZDHS"
                + ",CD"
                + ",CW"
                + ",ZJGJ"
                + ",ZJXC"
                + ",ZJYH"
                + ",ZJSBZK"
                + ",FJKYSL"
                + ",RYXH1"
                + ",RYXH2"
                + ",HYXH"
                + ",HYCR"
                + ",PICTURE"
                + ",XHHL"
                + ",XHTS"
                + ",XZTL"
                + ",TLZJ"
                + ",TLJTS"
                + ",ZDJ"
                + ",JSTSL"
                + ",JZTSL"
                + ",FDJGL"
                + ",MAINENGINE_EXAUST_M"
                + ",AUXILIARY_EXAUST_M"
                + ",AUXILIARY_EXAUST_G"
                + ",mainEngine_TowNum"
                + ",mainEngine_MaxSpeedNum"
                + ",mainEngine_EcoSpeedNum"
                + ",mainEngine_CruiseNum"
                + ",cjfh"
                + ",remark"
                + ",SSFGS"
                + " from T_SHIP "
                + " where upper(SHIP_ID)='" + Id.ToUpper() + "'";
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
        /// 根据shipinfo 的DataRow封装对象.
        /// </summary>
        /// <param name="dr">一个选定的DataRow对象</param>
        /// <returns>shipinfo 数据实体</returns>
        ///从DataGridView的数据源获取当前选定DataRow的方法.
        ///DataRow dr=((DataTable)dataGridView.DataSource).Rows[e.RowIndex];
        ///string o = dr["COMPTYPE_CHINESE_NAME"].ToString();
        ///MessageBox.Show(o);
        public ShipInfo getObject(DataRow dr)
        {
            ShipInfo unit = new ShipInfo();
            if (null == dr)
            {
                unit.IsWrong = true;
                unit.WhyWrong = "从数据库获取信息时出错,未成功构造ShipInfo类对象!";
                return unit;
            }
            if (DBNull.Value != dr["SHIP_ID"])
                unit.SHIP_ID = dr["SHIP_ID"].ToString();
            if (DBNull.Value != dr["SHIP_NAME"])
                unit.SHIP_NAME = dr["SHIP_NAME"].ToString();
            if (DBNull.Value != dr["SHIP_EN_NAME"])
                unit.SHIP_EN_NAME = dr["SHIP_EN_NAME"].ToString();
            if (DBNull.Value != dr["SHIP_CODE"])
                unit.SHIP_CODE = dr["SHIP_CODE"].ToString();
            if (DBNull.Value != dr["SHIP_HH"])
                unit.SHIP_HH = dr["SHIP_HH"].ToString();
            if (DBNull.Value != dr["IMO"])
                unit.IMO = dr["IMO"].ToString();
            if (DBNull.Value != dr["MMSI"])
                unit.MMSI = dr["MMSI"].ToString();
            if (DBNull.Value != dr["CBDJH"])
                unit.CBDJH = dr["CBDJH"].ToString();
            if (DBNull.Value != dr["CQG"])
                unit.CQG = dr["CQG"].ToString();
            if (DBNull.Value != dr["CJG"])
                unit.CJG = dr["CJG"].ToString();
            if (DBNull.Value != dr["HQ"])
                unit.HQ = dr["HQ"].ToString();
            if (DBNull.Value != dr["CBSYR"])
                unit.CBSYR = dr["CBSYR"].ToString();
            if (DBNull.Value != dr["SHIP_TYPE"])
                unit.SHIP_TYPE = dr["SHIP_TYPE"].ToString();
            if (DBNull.Value != dr["XK"])
                unit.XK = Convert.ToDecimal(dr["XK"]);
            if (DBNull.Value != dr["XS"])
                unit.XS = Convert.ToDecimal(dr["XS"]);
            if (DBNull.Value != dr["ZC"])
                unit.ZC = Convert.ToDecimal(dr["ZC"]);
            if (DBNull.Value != dr["LZJC"])
                unit.LZJC = Convert.ToDecimal(dr["LZJC"]);
            if (DBNull.Value != dr["QZCS"])
                unit.QZCS = Convert.ToDecimal(dr["QZCS"]);
            if (DBNull.Value != dr["SJCS"])
                unit.SJCS = Convert.ToDecimal(dr["SJCS"]);
            if (DBNull.Value != dr["QZPSL"])
                unit.QZPSL = Convert.ToDecimal(dr["QZPSL"]);
            if (DBNull.Value != dr["MZPSL"])
                unit.MZPSL = Convert.ToDecimal(dr["MZPSL"]);
            if (DBNull.Value != dr["ZD"])
                unit.ZD = Convert.ToDecimal(dr["ZD"]);
            if (DBNull.Value != dr["JD"])
                unit.JD = Convert.ToDecimal(dr["JD"]);
            if (DBNull.Value != dr["ZZD"])
                unit.ZZD = Convert.ToDecimal(dr["ZZD"]);
            if (DBNull.Value != dr["SYSZD"])
                unit.SYSZD = Convert.ToDecimal(dr["SYSZD"]);
            if (DBNull.Value != dr["BNMZD"])
                unit.BNMZD = Convert.ToDecimal(dr["BNMZD"]);
            if (DBNull.Value != dr["HS"])
                unit.HS = Convert.ToDecimal(dr["HS"]);
            if (DBNull.Value != dr["ZDPY"])
                unit.ZDPY = Convert.ToDecimal(dr["ZDPY"]);
            if (DBNull.Value != dr["ZJXH"])
                unit.ZJXH = dr["ZJXH"].ToString();
            if (DBNull.Value != dr["ZJTS"])
                unit.ZJTS = Convert.ToDecimal(dr["ZJTS"]);
            if (DBNull.Value != dr["ZJGL"])
                unit.ZJGL = Convert.ToDecimal(dr["ZJGL"]);
            if (DBNull.Value != dr["ZJZS"])
                unit.ZJZS = Convert.ToDecimal(dr["ZJZS"]);
            if (DBNull.Value != dr["ZJJZC"])
                unit.ZJJZC = dr["ZJJZC"].ToString();
            if (DBNull.Value != dr["ZJCZRQ"])
                unit.ZJCZRQ = (DateTime)dr["ZJCZRQ"];
            if (DBNull.Value != dr["FDJYDJXH"])
                unit.FDJYDJXH = dr["FDJYDJXH"].ToString();
            if (DBNull.Value != dr["FDJYDJTS"])
                unit.FDJYDJTS = Convert.ToDecimal(dr["FDJYDJTS"]);
            if (DBNull.Value != dr["FDJYDJGL"])
                unit.FDJYDJGL = Convert.ToDecimal(dr["FDJYDJGL"]);
            if (DBNull.Value != dr["FDJYDJZS"])
                unit.FDJYDJZS = Convert.ToDecimal(dr["FDJYDJZS"]);
            if (DBNull.Value != dr["FDJXH"])
                unit.FDJXH = dr["FDJXH"].ToString();
            if (DBNull.Value != dr["FDJTS"])
                unit.FDJTS = Convert.ToDecimal(dr["FDJTS"]);
            if (DBNull.Value != dr["ZYCL"])
                unit.ZYCL = Convert.ToDecimal(dr["ZYCL"]);
            if (DBNull.Value != dr["QYCL"])
                unit.QYCL = Convert.ToDecimal(dr["QYCL"]);
            if (DBNull.Value != dr["DSCL"])
                unit.DSCL = Convert.ToDecimal(dr["DSCL"]);
            if (DBNull.Value != dr["YYKSRQ"])
                unit.YYKSRQ = (DateTime)dr["YYKSRQ"];
            if (DBNull.Value != dr["YYJSRQ"])
                unit.YYJSRQ = (DateTime)dr["YYJSRQ"];
            if (DBNull.Value != dr["CBZZC"])
                unit.CBZZC = dr["CBZZC"].ToString();
            if (DBNull.Value != dr["ZZRQ"])
                unit.ZZRQ = (DateTime)dr["ZZRQ"];
            if (DBNull.Value != dr["ZDHS"])
                unit.ZDHS = Convert.ToDecimal(dr["ZDHS"]);
            if (DBNull.Value != dr["CD"])
                unit.CD = dr["CD"].ToString();
            if (DBNull.Value != dr["CW"])
                unit.CW = Convert.ToDecimal(dr["CW"]);
            if (DBNull.Value != dr["ZJGJ"])
                unit.ZJGJ = Convert.ToDecimal(dr["ZJGJ"]);
            if (DBNull.Value != dr["ZJXC"])
                unit.ZJXC = Convert.ToDecimal(dr["ZJXC"]);
            if (DBNull.Value != dr["ZJYH"])
                unit.ZJYH = Convert.ToDecimal(dr["ZJYH"]);
            if (DBNull.Value != dr["ZJSBZK"])
                unit.ZJSBZK = dr["ZJSBZK"].ToString();
            if (DBNull.Value != dr["FJKYSL"])
                unit.FJKYSL = Convert.ToDecimal(dr["FJKYSL"]);
            if (DBNull.Value != dr["RYXH1"])
                unit.RYXH1 = dr["RYXH1"].ToString();
            if (DBNull.Value != dr["RYXH2"])
                unit.RYXH2 = dr["RYXH2"].ToString();
            if (DBNull.Value != dr["HYXH"])
                unit.HYXH = dr["HYXH"].ToString();
            if (DBNull.Value != dr["HYCR"])
                unit.HYCR = Convert.ToDecimal(dr["HYCR"]);
            if (DBNull.Value != dr["PICTURE"])
                unit.PICTURE = dr["PICTURE"].ToString();
            if (DBNull.Value != dr["XHHL"])
                unit.XHHL = Convert.ToDecimal(dr["XHHL"]);
            if (DBNull.Value != dr["XHTS"])
                unit.XHTS = Convert.ToDecimal(dr["XHTS"]);
            if (DBNull.Value != dr["XZTL"])
                unit.XZTL = Convert.ToDecimal(dr["XZTL"]);
            if (DBNull.Value != dr["TLZJ"])
                unit.TLZJ = Convert.ToDecimal(dr["TLZJ"]);
            if (DBNull.Value != dr["TLJTS"])
                unit.TLJTS = Convert.ToDecimal(dr["TLJTS"]);
            if (DBNull.Value != dr["ZDJ"])
                unit.ZDJ = Convert.ToDecimal(dr["ZDJ"]);
            if (DBNull.Value != dr["JSTSL"])
                unit.JSTSL = Convert.ToDecimal(dr["JSTSL"]);
            if (DBNull.Value != dr["JZTSL"])
                unit.JZTSL = Convert.ToDecimal(dr["JZTSL"]);
            if (DBNull.Value != dr["FDJGL"])
                unit.FDJGL = Convert.ToDecimal(dr["FDJGL"]);
            if (DBNull.Value != dr["MAINENGINE_EXAUST_M"])
                unit.MAINENGINE_EXAUST_M = Convert.ToDecimal(dr["MAINENGINE_EXAUST_M"]);
            if (DBNull.Value != dr["AUXILIARY_EXAUST_M"])
                unit.AUXILIARY_EXAUST_M = Convert.ToDecimal(dr["AUXILIARY_EXAUST_M"]);
            if (DBNull.Value != dr["AUXILIARY_EXAUST_G"])
                unit.AUXILIARY_EXAUST_G = Convert.ToDecimal(dr["AUXILIARY_EXAUST_G"]);
            if (DBNull.Value != dr["mainEngine_TowNum"])
                unit.mainEngine_TowNum = Convert.ToInt32(dr["mainEngine_TowNum"]);
            if (DBNull.Value != dr["mainEngine_MaxSpeedNum"])
                unit.mainEngine_MaxSpeedNum = Convert.ToInt32(dr["mainEngine_MaxSpeedNum"]);
            if (DBNull.Value != dr["mainEngine_EcoSpeedNum"])
                unit.mainEngine_EcoSpeedNum = Convert.ToInt32(dr["mainEngine_EcoSpeedNum"]);
            if (DBNull.Value != dr["mainEngine_CruiseNum"])
                unit.mainEngine_CruiseNum = Convert.ToInt32(dr["mainEngine_CruiseNum"]);
            if (DBNull.Value != dr["cjfh"])
                unit.CJFH = dr["cjfh"].ToString();
            if (DBNull.Value != dr["remark"])
                unit.REMARK = dr["remark"].ToString();
            if (DBNull.Value != dr["SSFGS"])
                unit.SSFGS = dr["SSFGS"].ToString();

            return unit;
        }

        /// <summary>
        /// 根据ID,返回一个ShipInfo对象.
        /// </summary>
        /// <param name="sHIP_ID">sHIP_ID</param>
        /// <returns>ShipInfo对象</returns>
        public ShipInfo getObject(string Id, out string err)
        {
            err = "";
            try
            {
                DataTable dt = getInfo(Id, out err);
                return getObject(dt.Rows[0]);
            }
            catch
            {
                return getObject(null);
            }
        }
        #endregion	

        #region 获取所有船舶数据,无数据过滤-liulei-2016/01/29
        /// <summary>
        /// 得到  T_SHIP 所有数据信息.
        /// </summary>
        /// <returns>T_SHIP DataTable</returns>
        public DataTable getAllShipInfo(out string err)
        {
            sql = String.Format(@"select SHIP_ID ,SHIP_NAME
                ,SHIP_EN_NAME
                ,SHIP_CODE
                ,SHIP_HH
                ,IMO
                ,MMSI
                ,CBDJH
                ,CQG
                ,CJG
                ,HQ
                ,CBSYR
                ,SHIP_TYPE
                ,XK
                ,XS
                ,ZC
                ,LZJC
                ,QZCS
                ,SJCS
                ,QZPSL
                ,MZPSL
                ,ZD
                ,JD
                ,ZZD
                ,SYSZD
                ,BNMZD
                ,HS
                ,ZDPY
                ,ZJXH
                ,ZJTS
                ,ZJGL
                ,ZJZS
                ,ZJJZC
                ,ZJCZRQ
                ,FDJYDJXH
                ,FDJYDJTS
                ,FDJYDJGL
                ,FDJYDJZS
                ,FDJXH
                ,FDJTS
                ,ZYCL
                ,QYCL
                ,DSCL
                ,YYKSRQ
                ,YYJSRQ
                ,CBZZC
                ,ZZRQ
                ,ZDHS
                ,CD
                ,CW
                ,ZJGJ
                ,ZJXC
                ,ZJYH
                ,ZJSBZK
                ,FJKYSL
                ,RYXH1
                ,RYXH2
                ,HYXH
                ,HYCR
                ,PICTURE
                ,XHHL
                ,XHTS
                ,XZTL
                ,TLZJ
                ,TLJTS
                ,ZDJ
                ,JSTSL
                ,JZTSL
                ,FDJGL
                ,MAINENGINE_EXAUST_M
                ,AUXILIARY_EXAUST_M
                ,AUXILIARY_EXAUST_G
                ,mainEngine_TowNum
                ,mainEngine_MaxSpeedNum
                ,mainEngine_EcoSpeedNum
                ,mainEngine_CruiseNum
                ,cjfh
                ,remark
                ,SSFGS
                 from T_SHIP  ORDER BY SHIP_EN_NAME");
                
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
    }
}
