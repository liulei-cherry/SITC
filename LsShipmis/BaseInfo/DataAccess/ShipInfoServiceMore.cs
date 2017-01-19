using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.Interfaces;
using BaseInfo.Objects;
using OfficeOperation;
using System.IO;
using System.Data;
using FileOperationBase.FileServices;
using FileOperationBase.Services;
using CommonOperation.Enum;

namespace BaseInfo.DataAccess
{
    partial class ShipInfoService : IObjectsService
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

            reValue.Add("SHIP_NAME", "船舶中文名");            
            reValue.Add("SHIP_CODE", "船舶编号");
            reValue.Add("SHIP_HH", "船舶呼号");
            reValue.Add("IMO", "船舶IMO号");
            reValue.Add("MMSI", "MMSI号码");
            reValue.Add("SHIP_EN_NAME", "船舶英文名");//zy-2012-12-12 增加
            return reValue;
        }

        #endregion

        public bool ExportItemToExcel(string fileFullName, ShipInfo toShowShipInfo)
        {
            Excel excel = new Excel();
            excel.OpenDocument(fileFullName);
            if (toShowShipInfo != null && !toShowShipInfo.IsWrong)
            {
                excel.SetValue("B1", "船舶综合信息表(" + toShowShipInfo.SHIP_NAME + ")");
                excel.SetValue("B4", toShowShipInfo.SHIP_NAME);
                excel.SetValue("B5", toShowShipInfo.SHIP_EN_NAME);
                excel.SetValue("B6", toShowShipInfo.CQG);
                excel.SetValue("B7", toShowShipInfo.CJFH);
                excel.SetValue("B8", toShowShipInfo.SHIP_TYPE);
                excel.SetValue("D8", toShowShipInfo.CD);
                excel.SetValue("B9", toShowShipInfo.HQ);
                excel.SetValue("D9", toShowShipInfo.SHIP_HH);
                excel.SetValue("B10", toShowShipInfo.CBZZC);
                if (CommonOperation.ConstParameter.DateTimeIsUsefull(toShowShipInfo.ZZRQ))
                {
                    excel.SetValue("D10", toShowShipInfo.ZZRQ.ToShortDateString());
                }
                excel.SetValue("B11", toShowShipInfo.ZC.ToString());
                excel.SetValue("D11", toShowShipInfo.XK.ToString());
                excel.SetValue("B12", toShowShipInfo.XS.ToString());
                excel.SetValue("D12", toShowShipInfo.ZD.ToString());
                excel.SetValue("B13", toShowShipInfo.HS.ToString());
                excel.SetValue("D13", toShowShipInfo.ZDHS.ToString());
                excel.SetValue("B14", toShowShipInfo.XHHL.ToString());
                excel.SetValue("D14", toShowShipInfo.XHTS.ToString());
                excel.SetValue("B15", toShowShipInfo.ZDPY.ToString());
                excel.SetValue("D15", toShowShipInfo.CW.ToString());
                excel.SetValue("B16", toShowShipInfo.XZTL.ToString());
                excel.SetValue("D16", toShowShipInfo.TLZJ.ToString());
                excel.SetValue("B17", toShowShipInfo.TLJTS.ToString());
                excel.SetValue("D17", toShowShipInfo.ZDJ.ToString());
                excel.SetValue("B19", toShowShipInfo.ZJXH);
                excel.SetValue("D19", toShowShipInfo.ZJTS.ToString());
                excel.SetValue("B20", toShowShipInfo.ZJZS.ToString());
                excel.SetValue("D20", toShowShipInfo.ZJGJ.ToString());
                excel.SetValue("B21", toShowShipInfo.ZJXC.ToString());
                excel.SetValue("D21", toShowShipInfo.ZJYH.ToString());
                excel.SetValue("B22", toShowShipInfo.ZJGL.ToString());
                excel.SetValue("D22", toShowShipInfo.ZJSBZK);
                excel.SetValue("B24", toShowShipInfo.FDJXH);
                excel.SetValue("D24", toShowShipInfo.FDJGL.ToString());
                excel.SetValue("B25", toShowShipInfo.FDJTS.ToString());
                excel.SetValue("D25", toShowShipInfo.FJKYSL.ToString());
                excel.SetValue("B27", toShowShipInfo.JSTSL.ToString());
                excel.SetValue("D27", toShowShipInfo.JZTSL.ToString());
                excel.SetValue("B30", toShowShipInfo.RYXH1);
                excel.SetValue("D30", toShowShipInfo.ZYCL.ToString());
                excel.SetValue("B31", toShowShipInfo.RYXH2);
                excel.SetValue("D31", toShowShipInfo.QYCL.ToString());
                excel.SetValue("B32", string.IsNullOrEmpty(toShowShipInfo.HYXH) ? "" : toShowShipInfo.HYXH.ToString());
                excel.SetValue("D32", toShowShipInfo.HYCR.ToString());
                excel.SetValue("D33", toShowShipInfo.DSCL.ToString());
                excel.SetValue("A35", toShowShipInfo.REMARK);
                string filename;

                if (FileDbService.Instance.GetABolbByFileId(toShowShipInfo.PICTURE, out filename))
                {
                    excel.InsertPicture("C4:D7", filename);
                }
                excel.CloseDocument();
                Excel.release(excel.pt);
                //try
                //{
                //    File.Delete(filename);
                //}
                //catch { }
                return true;
            }
            return false;
        }

        public bool InsertAPicToShip(ShipInfo obj, string fileName, out string err)
        {
            string pictureId = obj.PICTURE;
            string shipId = obj.SHIP_ID;
            if (string.IsNullOrEmpty(pictureId))
            {
                pictureId = Guid.NewGuid().ToString();
            }
            FileInfo f = new FileInfo(fileName);
            ourFile theNewFile;
            string theFileId;
            if (FileDbService.Instance.GetAFileById(pictureId, out theNewFile) || theNewFile == null)
            {
                theNewFile = new ourFile();
                theNewFile.FileName = f.Name;
                theNewFile.CreateDate = DateTime.Today;
                theNewFile.Size = f.Length;
                theNewFile.ShipId = shipId;
                if (!FileDbService.Instance.InsertAFile(theNewFile, fileName, out theFileId, out err))
                {
                    return false;
                }
            }
            else
            {
                theFileId = theNewFile.FileId;
                if (!FileDbService.Instance.UpdateABlob(theNewFile.Object_id, fileName))
                {
                    err = "更新一个图片时出错";
                    return false;
                }
            }

            string sUpdateSql = "update t_ship set picture = '" + theFileId + "' where upper(ship_id)='" + shipId.ToUpper() + "'";
            if (dbAccess.ExecSql(sUpdateSql, out err))
            {
                obj.PICTURE = theFileId;
                return FileDbService.Instance.UpdateABlob(pictureId, fileName);
            }
            else
                return false;
        }

        /// <summary>
        /// 删除船舶相关表的记录，仅在删除船舶时调用.
        /// </summary>
        /// <param name="shipId"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool DeleteShipRelationTableData(string shipId, out string err)
        {
            if (shipId.Length == 36)
            {
                List<string> sqls = new List<string>();
                #region 删除其设备


                string sql1 = "delete t_component_unit where ship_id = '" + shipId + "'";
                #endregion

                #region 删除其目录


                string sql2 = "delete t_folder where ship_id = '" + shipId + "'";
                #endregion
                sqls.Add(sql1);
                sqls.Add(sql2);
                return dbAccess.ExecSql(sqls, out err);
            }
            err = "传入的id无效！";
            return false;
        }

        public bool InitAShipWithAllRelationInfo(string shipID, out string err)
        {
            err = "";

            BaseInfo.Objects.ShipInfo theNewShip = (BaseInfo.Objects.ShipInfo)BaseInfo.DataAccess.ShipInfoService.Instance.GetOneObjectById(shipID);
            if (theNewShip.IsWrong)
            {
                err = theNewShip.WhyWrong;
                return false;
            }

            List<string> shipDatabase = new List<string>();
            #region 文件夹的初始化

            if (!FolderDbService.Instance.InitFolders(theNewShip.SHIP_NAME, shipID, out err))
            {
                return false;
            }
            //初始化完毕后的最后一步处理,把所有包含船舶id的资料变成不包含id的版本.
            shipDatabase.Add("update t_FOLDER set SHIP_ID = null where NODE_TYPE = " + (int)(FileBoundingTypes.COMPONENTFILES));
            #endregion

            #region 设备初始化

            //添加一个跟船舶一个名称的设备,id也一样.
            string sqli = "Insert into T_COMPONENT_UNIT(COMPONENT_UNIT_ID,COMPONENT_TYPE_ID, COMP_CHINESE_NAME, COMP_STATUS, SHIP_ID, CWBT_CODE, comp_serial_no)"
                + "\rselect newid(),null,'" + theNewShip.ToString() + "',1,'" + shipID + "','00000','" + theNewShip.SHIP_CODE + "' "
                + "\rfrom (select 0 a) t1 inner join (select count(1) b from T_COMPONENT_UNIT where upper(ship_ID) = '" +
                shipID + "' and PARENT_UNIT_ID is null) t2 on t1.a=t2.b";
            shipDatabase.Add(sqli);
            #endregion

            return dbAccess.ExecSql(shipDatabase, out err);

        }

        private bool checkFolder(string shipId)
        {
            string sql = "select * from T_FOLDER where upper(SHIP_ID)='" + shipId.ToUpper() + "'";
            string err;
            DataTable dt;
            if (!dbAccess.GetDataTable(sql, out dt, out err))
            {
                return false;
            }
            bool rtn = false;

            if (dt.Rows.Count > 0)
            {
                rtn = true;
            }

            return rtn;
        }

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

        public List<string> GetAllShipName()
        {
            string err;
            List<string> re = new List<string>();
            DataTable dt = GetOwnerShip(out err);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                re.Add(dt.Rows[i]["SHIP_NAME"].ToString());
            }
            return re;
        }

        public bool JustTheNameOrNoExist(string shipname, string shipcode, string shipid, out string err)
        {
            if (string.IsNullOrEmpty(shipcode) || string.IsNullOrEmpty(shipname))
            {
                err = "shipname 和 shipcode 均不允许为空!";
            }
            string sql = "select count(1) from t_ship where (SHIP_NAME = '" + shipname.Replace("'", "''") +
                "' or SHIP_CODE = '" + shipcode.Replace("'", "''") + "') and SHIP_ID != '" + shipid + "'";
            string shave;
            if (dbAccess.GetString(sql, out shave, out err) && shave == "0")
            {
                return true;
            }
            err = "已经包含船名为" + shipname + "或者船舶编号为" + shipcode + "的船舶,为了不造成业务冲突,不允许再次添加!";
            return false;
        }

        /// <summary>
        /// 得到登录用户管辖的船舶信息.
        /// </summary>
        public DataTable GetOwnerShip(string user_id, out string err)
        {
            if (CommonOperation.ConstParameter.IsLandVersion)
            {
                sql = "select a.*  from T_SHIP a,T_USER_SHIP u ";
                sql += "where a.ship_id = u.ship_id and  u.userid  ='" + user_id + "'";
            }
            else
            {
                sql = "select a.*  from T_SHIP a ";
            }
            //sql += "\r order by a.SHIP_CODE,a.SHIP_NAME";
            sql += "\r order by a.SHIP_EN_NAME";//zy-2012-12-12去掉原有排序SHIP_NAME SHIP_CODE
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
        public DataTable GetOwnerShip(out string err)
        {
            return GetOwnerShip(CommonOperation.ConstParameter.UserId, out err);
        }
        public string GetOwnerShipFilter()
        {
            string err;
            DataTable dtOwnerShip = GetOwnerShip(CommonOperation.ConstParameter.UserId, out err);
            StringBuilder ownerShipStr = new StringBuilder();
            ownerShipStr.Append(" ship_id in ('1'");
            foreach (DataRow item in dtOwnerShip.Rows)
                ownerShipStr.Append(",'" + item["ship_id"].ToString() + "'");
            ownerShipStr.Append(")");
            return ownerShipStr.ToString();
        }
        /// <summary>
        /// 取得船舶名称.
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <returns>返回船舶名称</returns>
        public string GetShipName(string shipId)
        {
            string sSql = "";               //查询树型数据所需的SQL语句.

            sSql += "select ";
            sSql += "SHIP_NAME ";       //船舶名称.
            sSql += "from T_Ship ";     //船舶信息表.
            sSql += "where Ship_Id = '" + shipId + "'";

            return dbAccess.GetString(sSql);
        }

        public DataTable GetShipUser(string sWhere)
        {
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询树型数据所需的SQL语句.

            sSql += "select shipuserid,";//主键.
            sSql += "username,";
            sSql += "ship_headship_id,";
            sSql += "ident,";
            sSql += "seanumb,";
            sSql += "ssnumb,";
            sSql += "sernumb,";
            sSql += "address,";
            sSql += "connection ";
            sSql += "from t_ship_user "; //船员信息表.
            sSql += "where username <> '超级用户' ";
            //设置查询的Where条件.
            if (sWhere.Trim().Length > 0)
            {
                sSql += sWhere;
            }
            sSql += "\rorder by username";
            dbAccess.GetDataTable(sSql, out dtb, out err);
            return dtb;
        }
    }
}
