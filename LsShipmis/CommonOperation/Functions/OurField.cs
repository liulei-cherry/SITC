using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.Interfaces;
using CommonOperation.Functions;

namespace CommonOperation.Functions
{
    /// <summary>
    /// 数据表的字段实体.
    /// </summary>
    public class OurField : CommonItem
    {
        private string thisFieldName;
        private string thisTableId;
        private int thisFieldType; //0：普通 1：主键 2：外键 ;
        private string thisFkTableId;//外键表id;
        private int thisFieldSortNum;
        private int thisValueType;//0,string,1,number,2,datetime,3,blob

        public override string ToString()
        {
            return thisFieldName;
        }

        public int ThisFieldType
        {
            get
            {
                return thisFieldType;
            }
        }
        public string ThisFkTableId
        {
            get
            {
                return thisFkTableId;
            }
        }
        public OurField(string itemId, string fieldname, string tableid, int fieldtype, string fktableid, int sortnumIn, int valueTypeIn)
        {
            if (itemId.Length == 0)
            {
                this.IsWrong = true;
                this.WhyWrong = thisFieldName;
            }
            else
            {
                this.ItemGuid = itemId;
                thisTableId = tableid;
                thisFieldName = fieldname;
                thisFieldType = fieldtype;
                thisFkTableId = fktableid;
                thisFieldSortNum = sortnumIn;
                thisValueType = valueTypeIn;
            }
        }
        public OurField GetACopyOurField()
        {
            OurField reOurField = new OurField(this.ItemGuid.ToString(), thisFieldName, thisTableId, thisFieldType, thisFkTableId, thisFieldSortNum, thisValueType);
            if (this.IsWrong)
            {
                reOurField.IsWrong = true;
                reOurField.WhyWrong = this.WhyWrong;
            }
            return reOurField;
        }

        public string FieldTableName
        {
            get
            {
                return OurTableServices.GetInstance.LoadATableById(thisTableId).TableName;
            }
        }
        public string FieldPrimaryTableName
        {
            get
            {
                return OurTableServices.GetInstance.LoadATableById(thisFkTableId).TableName;
            }
        }
        public string ThisFieldName
        {
            get
            {
                return thisFieldName;
            }
            set
            {
                thisFieldName = value;
            }
        }

        public string ThisTableId
        {
            get
            {
                return thisTableId;
            }
            set
            {
                thisTableId = value;
            }
        }

        public int ThisFieldSortNum
        {
            get
            {
                return thisFieldSortNum;
            }
            set
            {
                thisFieldSortNum = value;
            }
        }
        public int ThisValueType
        {
            get
            {
                return thisValueType;
            }
            set
            {
                thisValueType = value;
            }
        }
    }

    /// <summary>
    /// 数据表字段实体.
    /// </summary>
    public class OurFieldServiecs
    {
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private static OurFieldServiecs instance;
        /// <summary>
        /// 实例化.
        /// </summary>
        public static OurFieldServiecs GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OurFieldServiecs();
                }
                return instance;
            }
        }
        public OurTable LoadThisFieldTable(OurField theField)
        {
            return OurTableServices.GetInstance.LoadATableById(theField.ThisTableId);
        }
        public OurField LoadAFieldById(string id)
        {
            OurField toReOurField;
            string sql = "select ";
            sql += "field_id,field_name,field_type,table_id,fk_table_id,sortnum ,value_type ";
            sql += " from t_table_field where field_id = '" + id + "'";
            string sqlErr;
            DataTable toReOurFieldTable;
            if (dbAccess.GetDataTable(sql, out toReOurFieldTable, out sqlErr) && toReOurFieldTable.Rows.Count == 1)
            {
                toReOurField = new OurField(toReOurFieldTable.Rows[0]["field_id"].ToString(),
                                            toReOurFieldTable.Rows[0]["field_name"].ToString(),
                                            toReOurFieldTable.Rows[0]["table_id"].ToString(),
                                            int.Parse(toReOurFieldTable.Rows[0]["field_type"].ToString()),
                                            toReOurFieldTable.Rows[0]["fk_table_id"].ToString(),
                                            int.Parse(toReOurFieldTable.Rows[0]["sortnum"].ToString()),
                                            int.Parse(toReOurFieldTable.Rows[0]["value_type"].ToString()));
            }
            else
            {
                toReOurField = new OurField("", " 无法加载id为'" + id + "'的t_data_view_controlitems的数据，其错误信息可能为：" + sqlErr,"",0,"",0,0);
            }
            return toReOurField;
        }
    }
}
