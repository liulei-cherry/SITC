using System;
using System.Collections.Generic;
using System.Text;
using BaseInfo.Objects;
using System.Data;
using System.IO;
using FileOperationBase.Services;
using CommonOperation.Interfaces;
using FileOperationBase.FileServices;
using CommonOperation.Enum;

namespace BaseInfo.DataAccess
{
    public partial class WorkModelTypeService : IObjectsService
    {
        //获取原模板文件信息.
        public string GetModelFileInfo(WorkModelType workModelType)
        {
            string fpath = "";
            if (workModelType != null)
            {
                string fileid = workModelType.ModelFile;
                if (!FileDbService.Instance.GetABolbByFileId(fileid, out fpath))
                {
                    fpath = "";
                }
            }
            return fpath;
        }
        public WorkModelType getModelObject(string shipid, string modelName, out string err)
        {
            DataTable dt = getModelInfo(shipid, modelName, out err);
            if (dt != null && dt.Rows.Count > 0)
                return getObject(dt.Rows[0]);
            return null;
        }

        public DataTable getModelInfo(string shipid, string modelName, out string err)
        {
            modelName = dbOperation.ReplaceSqlKeyStr(modelName);
            sql = "select  ModelID , [type] , ModelName , ContentExp , ModelFile , DateCol ,DateRow, SHIP_ID"
                + " from T_WorkModelType "
                + " where upper(ship_id)='" + shipid.ToUpper() + "'"
                + (string.IsNullOrEmpty(modelName) ? "" : " and upper(T_WorkModelType.modelName)='" + modelName.ToUpper() + "'");
            sql += " order by  [type]";
            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);
            return dt;
        }
        public DataTable getModelInfo(string shipid, out string err)
        {
            sql = "select  ModelID , [type] , ModelName , ContentExp , ModelFile , DateCol ,DateRow, SHIP_ID"
                + " from T_WorkModelType "
                + " where upper(ship_id)='" + shipid.ToUpper() + "'  order by type, ModelName ";
            DataTable dt;
            dbAccess.GetDataTable(sql, out dt, out err);
            return dt;
        }
        public void InsertModel(WorkModelType unit, out string err)
        {
            sql = "INSERT INTO [T_WorkModelType] ("
                             + "[ModelID]"
             + ","
              + "[ModelName]"
             + ","
             + "[type]"
             + ","
             + "[ContentExp]"
             + ","
             + "[ModelFile]"
             + ","
             + "[DateCol]"
             + ","
             + "[DateRow]"
             + ","
             + "[SHIP_ID]"
             + ") VALUES( '" + unit.ModelID + "'"
             + ", '" + dbOperation.ReplaceSqlKeyStr(unit.ModelName) + "'"
             + "," + unit.type
             + ", '" + dbOperation.ReplaceSqlKeyStr(unit.ContentExp) + "'"
             + ",'" + dbOperation.ReplaceSqlKeyStr(unit.ModelFile) + "'"
             + ",0,0,'" + unit.SHIP_ID + "')";
            dbAccess.ExecSql(sql, out err);
        }
        /// <summary>
        /// 把某条船的某个模板配置拷贝到其他船舶上.
        /// </summary>
        /// <param name="shipid"></param>
        /// <param name="modelName"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool CopyConfigToAllShip(WorkModelType workModelType, out string err)
        {
            if (workModelType == null || workModelType.IsWrong || string.IsNullOrEmpty(workModelType.SHIP_ID)
                || string.IsNullOrEmpty(workModelType.ModelName))
            {
                err = "传入的模板数据有误,不能进行克隆操作";
                return false;
            }
            err = "";
            List<string> otherShipIds = new List<string>();
            DataTable dt;
            sql = "select ship_id from t_ship where ship_id <>'" + workModelType.SHIP_ID + "'";
            if (!dbAccess.GetDataTable(sql, out dt, out err))
            {
                return false;
            }
            foreach (DataRow dr in dt.Rows)
            {
                if (!otherShipIds.Contains(dr[0].ToString())) otherShipIds.Add(dr[0].ToString());
            }
            ourFile theFile;
            if (!FileDbService.Instance.GetAFileById(workModelType.ModelFile, out theFile))
            {
                err = "从数据库获取模版文件时失败,无法继续进行,请重新为其导入模版文件后再重试!";
                return false;
            }
            foreach (string shipId in otherShipIds)
            {
                ourFolder folderISM = FolderDbService.Instance.getFolderByFolderType(CommonOperation.Enum.FileBoundingTypes.SHIPISMFILES, shipId);
                if (folderISM == null)
                {
                    err = "请初始化文档模板类型的文件夹节点,到船舶基本信息管理页面点击初始化即可!";
                    return false;
                }
                ourFolder folder = FolderDbService.Instance.getOrCreateSubFolderByName(folderISM, "体系文件模板", CommonOperation.Enum.FileBoundingTypes.ISMMODELS);
                string oldFileId;
                ourFile theCloneFile = new ourFile();
                theCloneFile.FileName = theFile.FileName;
                theCloneFile.File_Type = theFile.File_Type;
                theCloneFile.Object_id = theFile.Object_id;
                theCloneFile.CreateDate = DateTime.Today;
                theCloneFile.Creator = CommonOperation.ConstParameter.UserName;
                theCloneFile.ShipId = shipId;
                theCloneFile.Size = theFile.Size;
                theCloneFile.Version = theFile.Version;
                if (FolderFileDbService.Instance.IfFolderHasTheFile(folder.NodeId, theFile.FileName, out oldFileId))
                {
                    theCloneFile.FileId = oldFileId;
                    if (!FileDbService.Instance.UpdateAFile(theFile, "", out err)) return false;
                }
                else
                {
                    if (!FileDbService.Instance.UpdateAFile(theCloneFile, "", out err)) return false;
                    sql = @"insert into T_FILE_REF(ID,NODE_ID,FILE_ID) 
                        values(newid() ,'" + folder.NodeId + "','" + theCloneFile.FileId + "') ";
                    if (!dbAccess.ExecSql(sql, out err))
                    {
                        return false;
                    }
                }
                List<string> sqls = new List<string>();
                //获取剩余船舶的模版文件T_FILE_MANAGE,如果获取不到,就增加,增加时,注意应该先获取对应的folder,再往T_FILE_MANAGE和T_FILE_REF中插入值.
                sql = "delete T_WorkModelType where ModelName = '" + dbOperation.ReplaceSqlKeyStr(workModelType.ModelName) + "' and ship_id='" + shipId + "'";
                sqls.Add(sql);
                sql = "insert into T_WorkModelType([ModelID],[ModelName],[type],[ContentExp],[ModelFile],[DateCol],[Daterow],[SHIP_ID])"
                    + "\rselect newid(),t1.[ModelName],t1.[type],t1.[ContentExp],'" + theCloneFile.FileId + "' ,t1.[DateCol],t1.[Daterow],'" + shipId + "'"
                    + "\rfrom T_WorkModelType t1"
                    + "\rwhere t1.ship_id = '" + workModelType.SHIP_ID + "' and ModelName = '" + dbOperation.ReplaceSqlKeyStr(workModelType.ModelName) + "'";
                sqls.Add(sql);

                if (!dbAccess.ExecSql(sqls, out err)) return false;
            }
            return true;
        }

        public bool SetReport(FileBoundingTypes fileType, bool usingMoreFolder, string folderName, string folderId, DateTime createDate, string personName,
            string ship_id, string modelfileId, string fileAddress, out ourFile ofile, out string err)
        {
            FileInfo f = new FileInfo(fileAddress);
            ofile = new ourFile();
            ofile.CreateDate = createDate;
            ofile.Creator = personName;
            ofile.File_Type = "DOC";
            ofile.FileName = f.Name;
            ofile.Size = f.Length;
            ofile.ShipId = ship_id;
            ofile.Ref_Fileid = modelfileId;
            return FolderFileDbService.Instance.InsertAFile(fileType, usingMoreFolder, folderName, folderId, ofile, fileAddress, out err);
        }

        #region IObjectsService 成员

        public CommonOperation.BaseClass.CommonClass GetOneObjectById(string id)
        {
            string err;
            return getObject(id, out err);
        }

        public Dictionary<string, string> GetObjectDisplaySetting()
        {
            Dictionary<string, string> reValue = new Dictionary<string, string>();
            reValue.Add("SHIP_NAME", "船舶");
            reValue.Add("ModelName", "模板名称");
            reValue.Add("ContentExp", "模板描述");
            reValue.Add("DateCol", "配置起始列");
            reValue.Add("Daterow", "配置起始行");
            return reValue;
        }

        #endregion

        public List<string> GetModelRight(string modelName)
        {
            sql = "SELECT [HeadShipId]"
                + "\rFROM [dbo].[T_ModelTypeRight]"
                + "\rwhere upper(ModelTypeName)='" + modelName.ToUpper() + "'";
            DataTable dt;
            string err;
            List<string> re = new List<string>();
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    re.Add(dr["HeadShipId"].ToString());
                }
            }
            return re;
        }

        public List<string> GetHeadShipRight(string HeadShipId)
        {
            sql = "SELECT [ModelTypeName]"
              + "\rFROM [dbo].[T_ModelTypeRight]"
              + "\rwhere upper(HeadShipId)='" + HeadShipId.ToUpper() + "'";
            DataTable dt;
            string err;
            List<string> re = new List<string>();
            if (dbAccess.GetDataTable(sql, out dt, out err))
            {
                foreach (DataRow dr in dt.Rows)
                {
                    re.Add(dr["ModelTypeName"].ToString());
                }
            }
            return re;
        }
        public bool SetModelRight(string modelName, List<string> allHeaderIds, out string err)
        {
            List<string> sqls = new List<string>();
            sqls.Add("delete T_ModelTypeRight where upper(ModelTypeName)='" + modelName.ToUpper() + "'");
            foreach (string headerid in allHeaderIds)
            {
                sqls.Add("INSERT INTO T_ModelTypeRight([WorkModelRightId],[HeadShipId],[ModelTypeName],[onlyRead])"
                + "\rvalues (newid(),'" + headerid + "','" + modelName + "',1)");
            }
            return dbAccess.ExecSql(sqls, out err);
        }
    }
}
