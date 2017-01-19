using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.Interfaces;
using CommonOperation.Functions;

namespace CommonOperation.Functions
{
    public class OurTable : CommonItem
    {
        public string TableId
        {
            get
            {
                if (this.ItemGuid == null)
                {
                    return "";
                }
                return this.ItemGuid.ToString().ToLower();
            }
        }
        private string tableName;
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        private string tableBackupName;
        public string TableBackupName
        {
            get
            {
                if (string.IsNullOrEmpty(tableBackupName))
                    tableBackupName = "B" + tableName.Substring(1, tableName.Length - 1);

                return tableBackupName;
            }
            set { tableBackupName = value; }
        }

        private string tableChineseName;// 表的显示名，用于同步表名的显示.
        public string TableChineseName
        {
            get { return tableChineseName; }
            set { tableChineseName = value; }
        }
        private int tableStatus;//表的状态，1表示同步表,0表示不同步表.

        public int TableStatus
        {
            get { return tableStatus; }
            set { tableStatus = value; }
        }

        private int tableBelong;//0,仅船舶端可以操作;1,仅公司端可以操作;2,双方都可以操作.

        public int TableBelong
        {
            get { return tableBelong; }
            set { tableBelong = value; }
        }

        private int synchronousOrder;//同步优先级.

        public int SynchronousOrder
        {
            get { return synchronousOrder; }
            set { synchronousOrder = value; }
        }
        private bool selfLink;//是否是自连接的表1是0否.

        public bool SelfLink
        {
            get { return selfLink; }
            set { selfLink = value; }
        }

        private List<string> thisTableFiledNames = new List<string>();
        private List<OurField> thisTableFields = new List<OurField>();
        private OurField thisPkField = null;
        private List<OurField> thisFkFields = new List<OurField>();

        private string showColumnName;

        public string ShowColumnName
        {
            get
            {
                if (showColumnName.Trim().Length == 0)
                {
                    return ThisPkField.ThisFieldName;
                }
                else
                {
                    return showColumnName;
                }
            }
            set { showColumnName = value; }
        }

        private string synchFilterOfLand;

        public string SynchFilterOfLand
        {
            get { return synchFilterOfLand; }
            set { synchFilterOfLand = value; }
        }

        private string synchFilterOfShip;

        public string SynchFilterOfShip
        {
            get { return synchFilterOfShip; }
            set { synchFilterOfShip = value; }
        }

        private string synchShip;

        public string SynchShip
        {
            get { return synchShip; }
            set { synchShip = value; }
        }

        public override string ToString()
        {
            return tableChineseName;
        }

        public OurTable(bool isWrong, string whyWrong)
        {
            this.IsWrong = true;
            this.WhyWrong = whyWrong;
        }

        public OurTable(DataTable toReOurTablefield, string itemId, string tableNameIn, string tableChineseNameIn, int tableStatusIn, int tableBelongIn, string showColumnNameIn,
            string synchFilterOfLandIn, string synchFilterOfShipIn, string synchShipIn, int synchronousorderIn)
        {
            this.ItemGuid = itemId;
            tableName = tableNameIn;
            tableChineseName = tableChineseNameIn;
            tableStatus = tableStatusIn;
            tableBelong = tableBelongIn;
            synchronousOrder = 0;
            selfLink = false;
            showColumnName = showColumnNameIn;
            string err;
            if (!loadAllField(toReOurTablefield, out err))
            {
                WhyWrong = err;
                this.IsWrong = false;
            }
            else
            {
                foreach (OurField of in thisFkFields)
                {
                    if (!string.IsNullOrEmpty(of.ThisFkTableId))
                    {
                        if (this.TableId.ToLower().Equals(of.ThisFkTableId.ToLower()))
                        {
                            this.selfLink = true;
                        }
                    }
                }
            }
            synchFilterOfLand = synchFilterOfLandIn;
            synchFilterOfShip = synchFilterOfShipIn;
            synchShip = synchShipIn;
            synchronousOrder = synchronousorderIn;
        }

        private bool loadAllField(DataTable toReOurTablefield, out string errText)
        {
            errText = "";
            if (toReOurTablefield.Rows.Count > 0)
            {
                thisTableFields.Clear();
                thisTableFiledNames.Clear();
                DataRow[] drs = toReOurTablefield.Select("table_id = '" + this.ItemGuid + "'");
                foreach (DataRow dr in drs)
                {
                    string fieldName = dr["field_name"].ToString();
                    OurField field = new OurField(dr["field_id"].ToString(), fieldName,
                                        dr["table_id"].ToString(),
                                        int.Parse(dr["field_type"].ToString()),
                                        dr["fk_table_id"].ToString(),
                                        int.Parse(dr["sortnum"].ToString()),
                                        int.Parse(dr["value_type"].ToString()));
                    if (field == null)
                    {
                        errText += field.WhyWrong + ";\n";
                    }
                    else
                    {
                        if (field.ThisFieldType == 1)
                        {
                            if (thisPkField != null && thisPkField.IsWrong == false)
                            {
                                errText = tableName + "表主键已经存在,为" + thisPkField.ThisFieldName + ",现数据库不支持双主键表,无法为其加载第二个主键[" + field.ThisFieldName + "]";
                                return false;
                            }
                            else
                            {
                                thisPkField = field;
                            }
                        }
                        else if (field.ThisFieldType == 2)
                        {
                            thisFkFields.Add(field);
                        }
                        thisTableFields.Add(field);
                        thisTableFiledNames.Add(fieldName);
                    }
                }
            }
            else
            {
                errText = "没有从t_table_field表中得到[" + tableName + "]的column信息！";
                return false;
            }
            return true;
        }

        public OurField ThisPkField
        {
            get
            {
                return this.thisPkField;
            }
        }
        public List<OurField> ThisFkFieldList
        {
            get
            {
                return this.thisFkFields;
            }
        }
        public List<OurField> ThisFieldList { get { return this.thisTableFields; } }
        public List<string> ThisTableFiledNames { get { return thisTableFiledNames; } }
    }

}
