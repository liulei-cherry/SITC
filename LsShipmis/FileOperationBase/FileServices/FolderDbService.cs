using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using FileOperationBase.Services;
using CommonOperation.Enum;

namespace FileOperationBase.FileServices
{
    public class FolderDbService
    {
        #region 构造函数

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static FolderDbService instance = new FolderDbService();
        public static FolderDbService Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new FolderDbService();
                }
                return instance;
            }
        }
        private FolderDbService()
        {
        }
        #endregion

        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        public bool InsertAFolder(ourFolder folder,ourFolder newFolder, out string errMessage)
        {
            string sSql = "";
            errMessage = "";
            string guid;
            if ((newFolder.NodeId == null) || (newFolder.NodeId==""))
            {
                guid = Guid.NewGuid().ToString();
            }
            else
            {
                //判断是否存在该文件夹，如果存在直接返回.
                sSql="SELECT NODE_ID FROM T_FOLDER";
                sSql+=" WHERE (NODE_ID = '"+ newFolder.NodeId +"')";
                sSql+=" AND (NODE_TYPE = "+ newFolder.Node_Type +")" ;
                if (folder.ShipId != null && folder.ShipId.Length>0)
                {
                    sSql += " AND (SHIP_ID " + (newFolder.ShipId == null ? ("is null ") : ("= '" + newFolder.ShipId + "'")) + ")";
                }
                DataTable fdtb;
                if (dbAccess.GetDataTable(sSql, out fdtb, out errMessage) && fdtb.Rows.Count > 0)
                {
                    return true;
                }
                guid = newFolder.NodeId;
            }
            sSql = "select max(FSORT) from T_FOLDER where upper(PARENT_NODE_ID)='" + folder.NodeId.ToUpper() + "' or NODE_ID = '" + folder.NodeId.ToUpper() + "' ";
            DataTable dtb;
            if(!dbAccess.GetDataTable(sSql,out dtb, out errMessage))            
            {
                return false;
            }
            
            int nSort = -1;
            if (dtb.Rows[0][0] == null || dtb.Rows[0][0].ToString().Equals("") || dtb.Rows[0][0].ToString().Equals("0"))
            {
                nSort = 1;
            }
            else
            {
                if (!int.TryParse(dtb.Rows[0][0].ToString(), out nSort))
                {
                    errMessage = "sort字段数据出错！";
                    return false;
                } 
                nSort++;
            }
           
            sSql = "insert into t_folder(NODE_ID,NODE,PARENT_NODE_ID,FSORT,NODE_TYPE";
            if ((newFolder.ShipId!=null) && (newFolder.ShipId.Length>0))
            {
                sSql += ",SHIP_ID";
            }
            sSql += ") values('";
            sSql += guid;
            sSql += "',N'";
            sSql += dbOperation.ReplaceSqlKeyStr (newFolder.NodeName);
            sSql += "','";
            sSql += folder.NodeId.ToString();
            sSql += "',";
            sSql += nSort.ToString();
            sSql += ",";
            sSql += newFolder.Node_Type;
            if (newFolder.ShipId != null && newFolder.ShipId.Length>0)
            {
                sSql += ",'";
                sSql += newFolder.ShipId;
                sSql += "'";
            }
            sSql += ")";
            if(dbAccess.ExecSql(sSql, out errMessage))
            {
                newFolder.NodeId = guid;
                return true;
            }
            return false;
        }

        public bool UpdateAFolder(ourFolder folder, out string errMessage)
        {
            errMessage = "";
            string sSql = "select count(1) from t_folder where NODE_ID = '" +folder.NodeId+ "'";
            if (dbAccess.GetString(sSql).Length == 0)
            {
                //插入.
                ourFolder parent = GetAnOurFoldById(folder.ParentNodeId, out errMessage);
                return InsertAFolder(parent, folder, out errMessage);
            }
            else
            {
                sSql = "update t_folder set NODE=N'" + dbOperation.ReplaceSqlKeyStr (folder.NodeName) + "',NODE_TYPE=" + folder.Node_Type + " where upper(NODE_ID)='" + folder.NodeId.ToUpper() + "' ";
                return dbAccess.ExecSql(sSql, out errMessage);           
            }             
        }

        public bool MoveAFolder(ourFolder toResetFolder, ourFolder theNewParentFolder, out string err)
        {
            string sSql = "";
            err = "";
            
            sSql += "update T_folder ";
            sSql += "set PARENT_NODE_ID='";
            sSql += theNewParentFolder.NodeId;
            sSql += "' ";
            sSql += " where NODE_ID='";
            sSql += toResetFolder.NodeId;
            sSql += "' ";
            return dbAccess.ExecSql(sSql, out err);
        }

        public bool DeleteAFolder(ourFolder folder, out string err)
        {
            string sSql = "select count(1) from (select PARENT_NODE_ID from T_folder where PARENT_NODE_ID = '" + folder.NodeId
                + "' union select node_id from t_file_ref where node_id = '" + folder.NodeId + "')t";
            string count;
            if (!dbAccess.GetString(sSql, out count, out err))return false;

            if (count != "0")
            {
                err = "文件夹下存在文件,不能删除!";
                return false;
            }

            sSql = "delete from T_folder where NODE_ID='"+ folder.NodeId + "'";
            return dbAccess.ExecSql(sSql, out err);
        }

        public bool GetSubFolders(ourFolder folder, out List<ourFolder> subFolders, out string errMessage)
        {
            DataTable dtb = GetSubFolder(folder, out errMessage);
            return GetListFolder(dtb, out subFolders);
            
        }
       
        /// 当找不到返回null         
        public ourFolder GetAnOurFoldById(string folderId,out string err)
        {
            string sSql = "";

            sSql += "SELECT T_FOLDER.NODE_ID, T_FOLDER.NODE, T_FOLDER.PARENT_NODE_ID, T_FOLDER.FSORT, T_FOLDER.NODE_TYPE, T_FOLDER.SHIP_ID ";
            sSql += "FROM T_FOLDER ";
            sSql += "where upper(NODE_ID)='";
            sSql += folderId.ToUpper();
            sSql += "' ";
            
            DataTable dtb ;
            List<ourFolder> folders = new List<ourFolder>();
            dbAccess.GetDataTable(sSql, out dtb, out err);
            if (GetListFolder(dtb, out folders) && folders.Count > 0)
            {
                return folders[0];
            }
            err = "无法获得此id的文件夹！";
            return null;
            
        }

        //得到某文件夹下所有文件夹和文件.
        public void GetSubFoldersAndFiles(ourFolder folder, out List<ourFolder> subFolders, out List<ourFile> subFiles)
        {
            subFiles = new List<ourFile>();
            string err;
            if (!GetSubFolders(folder, out subFolders, out err))
            {
                subFolders = new List<ourFolder>();
                return;
            }
            DataTable dtb = FolderFileDbService.Instance.GetFileByFolder(folder.NodeId);
            if (dtb == null)
            {
                subFiles.Clear();
                return;
            } 
            if (!FileDbService.Instance.formListFiles(dtb, out subFiles, out err))
            {
                subFiles.Clear();
                return;
            }
            List<ourFolder> newFolders;
            List<ourFile> newFiles;
            List<ourFolder> addFolders = new List<ourFolder>();
            foreach (ourFolder newFolder in subFolders)
            {
                GetSubFoldersAndFiles(newFolder, out newFolders, out newFiles);
                addFolders.AddRange(newFolders);
                subFiles.AddRange(newFiles);
            }
            subFolders.AddRange(addFolders);
        }

        public ourFolder getFolderByFolderType(FileBoundingTypes folderType)
        {
            string err;
            string sSql = "select * from T_FOLDER where node_type=" + (int)folderType + " order by FSORT";
            DataTable dtb ;
            dbAccess.GetDataTable(sSql, out dtb, out err);
            List<ourFolder> folders = new List<ourFolder>();
            if (GetListFolder(dtb, out folders) )
            {
                if (folders.Count > 0)
                {
                    return folders[0];
                }                
            } 
            err = "无法获得此id的文件夹！";
            return null;
        }

        public ourFolder getFolderByFolderType(FileBoundingTypes folderType, string shipid)
        {
            string err;
            if (string.IsNullOrEmpty(shipid)) shipid = "";
            string sSql = "select t1.* from T_FOLDER t1 inner join T_FOLDER t2 on t1.parent_node_id = t2.node_id where t1.node_type="
                + (int)folderType + " and t2.node_type <> " + (int)folderType + " and lower(isnull(t1.ship_id,''))='" + shipid.ToLower() + "' order by t1.FSORT";
            DataTable dtb ;
            dbAccess.GetDataTable(sSql, out dtb, out err);
            List<ourFolder> folders = new List<ourFolder>();
            if (GetListFolder(dtb, out folders) && folders.Count > 0)
            {
                return folders[0];
            }
            err = "无法获得类型为" + folderType.ToString() + "的文件夹,可以尝试在船舶基础信息模块中点击[船舶更新初始化]！";
            return null;
        }
        public bool InitFolders(string shipName, string shipID, out string err)
        {
            bool onlyCompany = string.IsNullOrEmpty(shipID);
            #region 文件夹的初始化

            //插入ISM节点及子节点.
            string folderId = "";
            string subId = "";
            string subID1 = "";
            string sql = "select * from T_FOLDER where NODE_TYPE = " + (int)(FileBoundingTypes.ISMFILESROOT) + " and parent_node_id is null";
            DataTable dt;
            if (!dbAccess.GetDataTable(sql, out dt, out err))
            {
                return false;
            }
            if (dt.Rows.Count == 0)
            {
                folderId = Guid.NewGuid().ToString().ToLower();              
            } 
            if (!makesql(folderId, "ISM库", "", (int)(FileBoundingTypes.ISMFILESROOT), null, 1, true, out folderId, out err)) return false;
            if (!onlyCompany)
            {
                //子节点船名.
                subId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(subId, shipName + "ISM库", folderId, (int)(FileBoundingTypes.SHIPISMFILES), shipID, 2, true, out subId, out err)) return false;

                subID1 = Guid.NewGuid().ToString().ToLower();
                if (!makesql(subID1, "体系文件模板", subId, (int)(FileBoundingTypes.ISMMODELS), shipID, 3, true, out subID1, out err)) return false;

                subID1 = Guid.NewGuid().ToString().ToLower();
                if (!makesql(subID1, "工作报告模板", subId, (int)(FileBoundingTypes.MEASUREREPORTMODEL), shipID, 3, true, out subID1, out err)) return false;
            }

            //船舶特有部分.
            //00000000-0000-0000-0000-000000000000	公司根节点	NULL	1	0	NULL	NULL
            subId = "00000000-0000-0000-0000-000000000000";
            if (!makesql(subId, "文件库", "", (int)(FileBoundingTypes.COMMONFILESROOT), null, 1, true, out subId, out err)) return false;

            subId = Guid.NewGuid().ToString().ToLower();
            if (!makesql(subId, "公司资料", "00000000-0000-0000-0000-000000000000", (int)(FileBoundingTypes.COMPONYFILES), null, 1, true, out subId, out err)) return false;
            subID1 = Guid.NewGuid().ToString().ToLower();
            if (!makesql(subID1, "设备资料", subId, (int)(FileBoundingTypes.COMPONENTFILES), null, 1, false, out subID1, out err)) return false;
            subID1 = Guid.NewGuid().ToString().ToLower();
            if (!makesql(subID1, "设备类别资料", subId, (int)(FileBoundingTypes.COMPONENTSYSTEMFILES), null, 2, false, out subID1, out err)) return false;
            subID1 = Guid.NewGuid().ToString().ToLower();
            if (!makesql(subID1, "操作说明(Operation)", subId, (int)(FileBoundingTypes.COMPONENTOPERATION), null, 3, false, out subID1, out err)) return false;

            if (!onlyCompany)
            {
                subId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(subId, shipName + "资料", "00000000-0000-0000-0000-000000000000", (int)(FileBoundingTypes.SHIPINFO), shipID, 2, true, out subId, out err)) return false;

                subID1 = Guid.NewGuid().ToString().ToLower();
                if (!makesql(subID1, "工作报告文件", subId, (int)(FileBoundingTypes.MEASUREREPORT), shipID, 1, true, out subID1, out err)) return false;

                subID1 = Guid.NewGuid().ToString().ToLower();
                if (!makesql(subID1, "船员管理", subId, (int)(FileBoundingTypes.SHIPMAN), shipID, 2, false, out subID1, out err)) return false;

                subID1 = Guid.NewGuid().ToString().ToLower();
                if (!makesql(subID1, "修理工程", subId, (int)(FileBoundingTypes.PROJECTMANAGE), shipID, 3, true, out subID1, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "工程原始文档", subID1, (int)(FileBoundingTypes.PROJECTORIGINAL), shipID, 1, false, out folderId, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "合同相关文档", subID1, (int)(FileBoundingTypes.PROJECTCONTRACT), shipID, 2, false, out folderId, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "完工相关文档", subID1, (int)(FileBoundingTypes.PROJECTFINISH), shipID, 3, false, out folderId, out err)) return false;

                subID1 = Guid.NewGuid().ToString().ToLower();
                if (!makesql(subID1, "工单管理", subId, (int)(FileBoundingTypes.WORKINFOFILES), shipID, 4, false, out subID1, out err)) return false;
                //备件管理.
                subID1 = Guid.NewGuid().ToString().ToLower();
                if (!makesql(subID1, "备件管理", subId, (int)(FileBoundingTypes.SPEARINFO), shipID, 5, true, out subID1, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "备件申请", subID1, (int)(FileBoundingTypes.SPEARAPPLY), shipID, 1, false, out folderId, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "备件订单", subID1, (int)(FileBoundingTypes.SPEARORDER), shipID, 2, false, out folderId, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "备件库存", subID1, (int)(FileBoundingTypes.SPEARSTOCK), shipID, 3, false, out folderId, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "备件盘点", subID1, (int)(FileBoundingTypes.SPEARCOUNT), shipID, 4, false, out folderId, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "备件入库", subID1, (int)(FileBoundingTypes.SPEARIN), shipID, 5, false, out folderId, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "备件出库", subID1, (int)(FileBoundingTypes.SPEAROUT), shipID, 6, false, out folderId, out err)) return false;

                //物资管理.
                subID1 = Guid.NewGuid().ToString().ToLower();
                if (!makesql(subID1, "物资管理", subId, (int)(FileBoundingTypes.ITEMSMANAGE), shipID, 6, true, out subID1, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "物资申请", subID1, (int)(FileBoundingTypes.ITEMSAPPLY), shipID, 1, false, out folderId, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "物资订单", subID1, (int)(FileBoundingTypes.ITEMSORDER), shipID, 2, false, out folderId, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "物资库存", subID1, (int)(FileBoundingTypes.ITEMSSTOCK), shipID, 3, false, out folderId, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "物资盘点", subID1, (int)(FileBoundingTypes.ITEMSCOUNT), shipID, 4, false, out folderId, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "物资入库", subID1, (int)(FileBoundingTypes.ITEMSIN), shipID, 5, false, out folderId, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "物资出库", subID1, (int)(FileBoundingTypes.ITEMSOUT), shipID, 6, false, out folderId, out err)) return false;
                //证书资料.
                subID1 = Guid.NewGuid().ToString().ToLower();
                if (!makesql(subID1, "证书资料", subId, (int)(FileBoundingTypes.SHIPCERTIFILES), shipID, 7, true, out subID1, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "标准船舶证书", subID1, (int)(FileBoundingTypes.BASESHIPCERT), shipID, 1, false, out folderId, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "船舶证书检验", subID1, (int)(FileBoundingTypes.SHIPCERTCHECK), shipID, 2, false, out folderId, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "船舶证书登记", subID1, (int)(FileBoundingTypes.SHIPCERTREGISTER), shipID, 3, false, out folderId, out err)) return false;

                //维护保养.
                subID1 = Guid.NewGuid().ToString().ToLower();
                if (!makesql(subID1, "维护保养", subId, (int)(FileBoundingTypes.MAINTENANCE), shipID, 8, true, out subID1, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "甲板月度计划", subID1, (int)(FileBoundingTypes.DECKWORKMONTHPLAN), shipID, 1, false, out folderId, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "轮机月度计划", subID1, (int)(FileBoundingTypes.MACHINEWORKMONTHPLAN), shipID, 2, false, out folderId, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "甲板月度完成", subID1, (int)(FileBoundingTypes.DECKWORKMONTHFINISH), shipID, 3, false, out folderId, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "轮机月度完成", subID1, (int)(FileBoundingTypes.MACHINEWORKMONTHFINISH), shipID, 4, false, out folderId, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "甲板年度计划", subID1, (int)(FileBoundingTypes.DECKWORKYEARPLAN), shipID, 5, false, out folderId, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "轮机年度计划", subID1, (int)(FileBoundingTypes.MACHINEWORKYEARPLAN), shipID, 6, false, out folderId, out err)) return false;

                //油料管理.
                subID1 = Guid.NewGuid().ToString().ToLower();
                if (!makesql(subID1, "油料管理", subId, (int)(FileBoundingTypes.OILMANAGE), shipID, 9, true, out subID1, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "油料申请", subID1, (int)(FileBoundingTypes.OILAPPLY), shipID, 1, false, out folderId, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "油料库存", subID1, (int)(FileBoundingTypes.OILSTOCK), shipID, 2, false, out folderId, out err)) return false;

                //费用管理.
                subID1 = Guid.NewGuid().ToString().ToLower();
                if (!makesql(subID1, "费用管理", subId, (int)(FileBoundingTypes.COSTMANAGE), shipID, 10, true, out subID1, out err)) return false;
                folderId = Guid.NewGuid().ToString().ToLower();
                if (!makesql(folderId, "单日凭证", subID1, (int)(FileBoundingTypes.VOUCHERFILES), shipID, 1, false, out folderId, out err)) return false;

                folderId = Guid.NewGuid().ToString().ToLower();
                
            }
            #endregion
            return true;
        }
       
        private bool makesql(string folderId, string node, string parentId, int nodeType, string shipID, int fsort, bool deleteErr, out string id, out string err)
        {
            id = folderId;
            //找一下有多少个存在,找到0,添加,找到1,update,并返回其id,找到2,删除其他的,把文件全部移到这个后面去.
            //order by 后的语法是徐正本2012年2月21日修改添加的,当一个目录的上级恰好是传入参数是,其优先级比较高,
            //但并不排除,目录排放错了位置,都不在这个指定上级下,要移动回来,这种情况下,用文件夹的排序号进行排序(实际是不太负责任的,但是也不大好实现其它方式)
            string sql = "select top 1 node_id id from t_folder where isnull(ltrim(upper(t_folder.ship_id)),'') ='" + (string.IsNullOrEmpty(shipID) ? "" : shipID.ToUpper()) +
                  "'" + "\rand ( node_id = '" + folderId.ToString() + "' or node_Type = " + nodeType.ToString() + ")"
                  + "\rorder by case when node_id = '" + folderId.ToString() + "' then 1 else 2 end , case when node_Type = "
                  + nodeType.ToString() + " then 1 else 2 end,case when PARENT_NODE_ID = '" + parentId + "' then 1 else 2 end,fsort";

            DataTable dt;
            if (!dbAccess.GetDataTable(sql, out dt, out err) || dt == null)
            {
                return false;
            }

            List<string> lstSql = new List<string>();
            if (dt.Rows.Count == 0)
            {
                sql = "insert into t_folder (node_id,node,parent_node_id,node_type,ship_id,fsort) " +
                      "\rvalues( '" + folderId + "',N'" + node + "'," + (string.IsNullOrEmpty(parentId) ? "null" : " '" + parentId + "'") + "," + nodeType + ",'" +
                      (string.IsNullOrEmpty(shipID) ? "" : shipID) + "'," + fsort.ToString() + ")";
                return dbAccess.ExecSql(sql, out err);
            }
            else
            {
                id = dt.Rows[0][0].ToString();
                if (deleteErr)
                {
                    lstSql.Add("update t_folder set parent_node_id = '" + id + "' where parent_node_id in(select node_id from t_folder where  upper(t_folder.ship_id) " + (string.IsNullOrEmpty(shipID) ? " is null " : " ='" + shipID.ToUpper() + "'") +
                           " and node_Type = " + nodeType.ToString() + " and node_id <> '" + id + "')");
                    lstSql.Add("update T_FILE_REF set NODE_ID = '" + id + "' where NODE_ID in(select node_id from t_folder where  upper(t_folder.ship_id) " + (string.IsNullOrEmpty(shipID) ? " is null " : " ='" + shipID.ToUpper() + "'") +
                           " and node_Type = " + nodeType.ToString() + " and node_id <> '" + id + "')");
                    lstSql.Add("delete t_folder where node_id in(select node_id from t_folder where  upper(t_folder.ship_id) " + (string.IsNullOrEmpty(shipID) ? " is null " : " ='" + shipID.ToUpper() + "'") +
                       " and node_Type = " + nodeType.ToString() + " and node_id <> '" + id + "')");

                }
                lstSql.Add("update t_folder set parent_node_id = " + (string.IsNullOrEmpty(parentId) ? "null" : " '" + parentId + "'") + ",node =N'"
                    + node + "',fsort = " + fsort.ToString() + ",node_type = " + nodeType.ToString() 
                    + "\r where node_id = '" + id + "'");
                return dbAccess.ExecSql(lstSql, out err);
            }
        }
        
        public ourFolder getOrCreateSubFolderByName(ourFolder theFolder, string theName)
        {
            if (theFolder == null) return null;
            return getOrCreateSubFolderByNameAndId(theFolder, theName, Guid.NewGuid().ToString(),(int)(theFolder.Node_Type));
        }
        public ourFolder getOrCreateSubFolderByName(ourFolder theFolder, string theName,FileBoundingTypes fileType)
        {
            if (theFolder == null) return null;
            return getOrCreateSubFolderByNameAndId(theFolder, theName, Guid.NewGuid().ToString(), (int)fileType);
        }
        public ourFolder getOrCreateSubFolderByNameAndId(ourFolder theFolder, string theName, string folderId)
        {
            if (theFolder == null) return null;
            return getOrCreateSubFolderByNameAndId(theFolder, theName, folderId, (int)(theFolder.Node_Type));
        }
        public ourFolder getOrCreateSubFolderByNameAndId(ourFolder theFolder, string theName, string folderId, FileBoundingTypes fileType)
        {
            if (theFolder == null) return null;
            return getOrCreateSubFolderByNameAndId(theFolder, theName, folderId, (int)fileType);
        }
        public ourFolder getOrCreateSubFolderByNameAndId(ourFolder theFolder, string theName, string folderId, int folderType)
        {
            if (theFolder == null) return null;
            string err;
            string sSql = ""; 
                sSql = "select t1.NODE_ID from T_FOLDER t1 where NODE_ID = '" + folderId
                + "' or ( t1.PARENT_NODE_ID = '" + theFolder.NodeId + "' and NODE = N'" + dbOperation.ReplaceSqlKeyStr (theName) + "')";
            string theId;
            if (!dbAccess.GetString(sSql, out theId, out err) || theId.Length != 36)
            {
                sSql = "INSERT INTO [dbo].[T_FOLDER] ([NODE_ID],[NODE],[PARENT_NODE_ID],[FSORT],[NODE_TYPE],[SHIP_ID])"
                    + "\r select '" + folderId + "',N'" + dbOperation.ReplaceSqlKeyStr (theName) + "','" + theFolder.NodeId + "',(select count(1) +1 from T_FOLDER t1 where t1.PARENT_NODE_ID = '" + theFolder.NodeId + "'),"
                    + folderType.ToString() + ",'" + theFolder.ShipId.ToString() + "'";
                if (!dbAccess.ExecSql(sSql, out err))
                    return null;
                theId = folderId;
            }
            return getFolderByFolderID(theId);
        }

        public ourFolder getFolderByFolderID(string folderId)
        {
             if (string.IsNullOrEmpty(folderId)) return null;
             string err;
             string sSql = "select * from T_FOLDER where upper(node_id)='" + folderId.ToUpper() + "'";
             DataTable dtb ;
             dbAccess.GetDataTable(sSql, out dtb, out err);
             List<ourFolder> folders = new List<ourFolder>();
             if (GetListFolder(dtb, out folders) && folders.Count > 0)
             {
                 return folders[0];
             }
             err = "无法获得此id的文件夹！";
             return null;
         }

        //根据id得到文件夹的路径，出错返回空字符串.
        public string GetPathByFolderId(string sFolderId,out string errMessage)
        {
            errMessage = "";
            ourFolder folder;
            string rePath = "";

            folder = GetAnOurFoldById(sFolderId, out errMessage);
            if (folder == null)
            {
                return "";
            }
            
            while (folder.ParentNodeId.Trim() != "0")
            {
                string nodeName = folder.NodeName;
                rePath = nodeName + @"\" + rePath;
                folder = GetAnOurFoldById(folder.ParentNodeId,out errMessage);
                if (folder == null)
                {
                    errMessage = nodeName + "上级节点不存在";
                    return "";
                }
            }

            rePath = folder.NodeName + @"\"+rePath;
            return rePath;
            
        }
        //构造ourFolder对象.
        public bool GetListFolder(DataTable dtb,out List<ourFolder>folders)
        {
            folders = new List<ourFolder>();
            if (dtb == null)
            {
                return false;
            }
            if (dtb.Rows.Count == 0)
            {
                return true;
            }
            foreach (DataRow row in dtb.Rows)
            {
                ourFolder reFolder = new ourFolder();
                reFolder.NodeId = row["NODE_ID"].ToString();
                reFolder.NodeName = row["NODE"].ToString();
                reFolder.ParentNodeId = row["PARENT_NODE_ID"].ToString();
                reFolder.ShipId = row["SHIP_ID"].ToString();
                reFolder.Node_Type = (Decimal)row["NODE_TYPE"]; 
                if (row["FSORT"]!=DBNull.Value) reFolder.Fsort = Convert.ToDecimal(row["FSORT"]);
                int i = -1;

                if (int.TryParse(row["FSORT"].ToString(), out i))
                {
                    reFolder.Fsort = i;
                }
                folders.Add(reFolder);
            }
            return true;
        }

        public  DataTable GetSubFolder(ourFolder folder, out string errMessage)
        {
            string sSql = "";
            errMessage = "";  
            sSql +=  "SELECT T_FOLDER.NODE_ID, T_FOLDER.NODE, T_FOLDER.PARENT_NODE_ID, T_FOLDER.FSORT, T_FOLDER.NODE_TYPE, T_FOLDER.SHIP_ID ";
            sSql +="FROM T_FOLDER  ";
            sSql+= " where upper(PARENT_NODE_ID)='";
            sSql += folder.NodeId.ToUpper();
            sSql += "' ";
            DataTable dtb;
            if (dbAccess.GetDataTable(sSql, out dtb, out errMessage))
            {
                return dtb;
            }
            return null;
        }
      
        public bool GetFolderTypeByFolderId(string folderId,out DataTable dtb,out string errMessage)
        {
            string sSql = "SELECT NODE_TYPE, NODE_ID FROM T_FOLDER WHERE (upper(NODE_ID) = '" + folderId.ToUpper() + "')";
            return dbAccess.GetDataTable(sSql, out dtb, out errMessage);      
        }

        public System.Data.DataTable getParentFolder(decimal typeId, string shipId, out string errMessage)
        {
            string sSql = "";
            errMessage = "";

            sSql = "SELECT T_FOLDER.NODE_ID, T_FOLDER.NODE, T_FOLDER.PARENT_NODE_ID, T_FOLDER.FSORT,  T_FOLDER.NODE_TYPE, ";
            sSql+=" T_FOLDER.SHIP_ID FROM T_FOLDER ";
            sSql+=" WHERE  (T_FOLDER.NODE_TYPE =" + typeId + ")";
            if((shipId!=null) && shipId.Length>0 )
            {
                sSql+=" AND (T_FOLDER.SHIP_ID = '"+ shipId +"')";
            }
            sSql += "  order by fsort";
            DataTable dtb;
            if (dbAccess.GetDataTable(sSql, out dtb, out errMessage))
            {
                return dtb;
            }
            return null;
        }

        /// <summary>
        /// 获取ISM下发的船舶视图，FOLDER.NODE_TYPE>=5000
        /// </summary>
        /// <returns></returns>
        public DataTable GetIsmShipView(out string errMessage)
        {
            string sSql = "";
            sSql = "SELECT NODE_ID, NODE, PARENT_NODE_ID, FSORT, NODE_TYPE, SHIP_ID";
            sSql+=" FROM T_FOLDER WHERE (NODE_TYPE >= 5000)";
            DataTable dt;
            if (dbAccess.GetDataTable(sSql, out dt, out errMessage))
            {
                return dt;
            }
            return null;
        }

        /// <summary>
        /// 获取普通船舶文件夹的视图FOLDER.NODE_TYPE<5000
        /// </summary>
        /// <returns></returns>
        public DataTable GetCommonShipView(out string errMessage)
        {
            string sSql = "";
            sSql = "SELECT NODE_ID, NODE, PARENT_NODE_ID, FSORT, NODE_TYPE, SHIP_ID ";
            sSql += " FROM T_FOLDER WHERE (NODE_TYPE < 5000)";
            DataTable dt;
            if (dbAccess.GetDataTable(sSql, out dt, out errMessage))
            {
                return dt;
            }
            return null;
        }

        public void CheckingUsefullessFolderType()
        {
            string sql = "update t_folder set NODE_TYPE = " + (int)FileBoundingTypes.COMMONDIR
                + "\rwhere NODE_TYPE not in (" + EnumConfig.Instance.GetFileTypeLinkedString() + ")";
            string err;
            dbAccess.ExecSql(sql, out err);
        }

        public void ClearAllEmptyFolderOfWhichType(FileBoundingTypes whichTypeToClear)
        {
            //任何没有下级目录以及没有下级文件且类型为whichTypeToClear的目录都会被删除.
            string sql = "delete t_folder from t_folder t1 "
            +"\rwhere NODE_TYPE = " + (int)whichTypeToClear + " and (select count(1) from t_folder t2 where t2.PARENT_NODE_ID = t1.NODE_ID) = 0"
            +"\rand (select count(1) from t_file_ref t3 where t3.NODE_ID = t1.NODE_ID) = 0";
            string err;
            dbAccess.ExecSql(sql,out err); 
        }
    }
}
