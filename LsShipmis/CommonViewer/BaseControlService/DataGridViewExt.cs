using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using CommonViewer.BaseForm;

namespace CommonViewer.BaseControlService
{
    struct field
    {
        public string Name;
        public int DisplayIndex;
        public int Width;
        public bool Visible;
    }

    public class DataGridViewExt
    {
        private static bool tableHave = false;
        private static IDBAccess dba = InterfaceInstantiation.NewADbAccess();
        /// <summary>
        /// 保存当前DataGridView的列显示顺序及宽窄、是否可见.
        /// </summary>
        /// <param name="dgv">DataGridView对象</param>
        /// <param name="userId">当前用户</param>
        /// <param name="posionId">使用的位置</param>
        public static void saveGridView(DataGridView dgv, string userId, string posionId)
        {
            int columns = dgv.ColumnCount;
            List<field> fields = new List<field>();

            for (int i = 0; i < columns; i++)
            {
                field tmpfield = new field();
                tmpfield.Name = dgv.Columns[i].Name;
                tmpfield.DisplayIndex = dgv.Columns[i].DisplayIndex;
                tmpfield.Width = dgv.Columns[i].Width;
                tmpfield.Visible = dgv.Columns[i].Visible;
                fields.Add(tmpfield);
            }
            save(userId, posionId, fields);
        }
        //实际保存到数据库内.
        private static void save(string userId, string posionId, List<field> fields)
        {
            if (!tableHave) CheckDataBaseHasTheTableOf_DATAGRIDVIEWINFO();
            List<string> lists = new List<string>();
            string sql;
            string err;
            if (fields.Count > 0)
            {
                sql = "SELECT * FROM T_DATAGRIDVIEWINFO ";
                sql += "WHERE (GRID_POSITION = '" + posionId + "') AND (USER_ID = '" + userId + "')";
                DataTable dt;
                if (dba.GetDataTable(sql, out dt, out err))
                {
                    if (dt.Rows.Count > 0)  //update
                    {
                        for (int i = 0; i < fields.Count; i++)
                        {
                            #region 更新记录，考虑增加新列的情况

                            string filter = "GRID_POSITION = '" + posionId + "' AND FIELD_NAME = '" + fields[i].Name.Replace("'", "''") + "' AND USER_ID = '" + CommonOperation.ConstParameter.UserId + "'";
                            DataRow[] drs = dt.Select(filter);
                            if (drs.Length > 0)
                            {

                                sql = "UPDATE T_DATAGRIDVIEWINFO ";
                                sql += "SET  FIELD_INDEX = ";
                                sql += fields[i].DisplayIndex;
                                sql += ", FIELD_WIDTH = " + fields[i].Width + ", FIELD_VISIBLE =";
                                sql += (fields[i].Visible) ? 1 : 0;
                                sql += " WHERE  (GRID_POSITION = '" + posionId + "') AND (FIELD_NAME = '" + fields[i].Name + "') AND (USER_ID = '" + CommonOperation.ConstParameter.UserId + "')";
                            }
                            else
                            {
                                sql = "INSERT INTO T_DATAGRIDVIEWINFO ";
                                sql += "(FIELD_NAME, FIELD_INDEX, FIELD_WIDTH, FIELD_VISIBLE, GRID_POSITION, USER_ID) ";
                                sql += "VALUES";
                                sql += "('" + fields[i].Name + "',";
                                sql += fields[i].DisplayIndex + "," + fields[i].Width + ",";
                                sql += (fields[i].Visible) ? 1 : 0;
                                sql += ",'" + posionId + "','" + CommonOperation.ConstParameter.UserId + "')";
                            }
                            lists.Add(sql);
                            #endregion
                        }
                    }
                    else  //insert
                    {
                        for (int i = 0; i < fields.Count; i++)
                        {
                            #region insert a record
                            sql = "INSERT INTO T_DATAGRIDVIEWINFO ";
                            sql += "(FIELD_NAME, FIELD_INDEX, FIELD_WIDTH, FIELD_VISIBLE, GRID_POSITION, USER_ID) ";
                            sql += "VALUES";
                            sql += "('" + fields[i].Name + "',";
                            sql += fields[i].DisplayIndex + "," + fields[i].Width + ",";
                            sql += (fields[i].Visible) ? 1 : 0;
                            sql += ",'" + posionId + "','" + userId + "')";
                            lists.Add(sql);
                            #endregion
                        }
                    }
                    dba.ExecSql(lists, out err);
                }
            }
        }

        /// <summary>
        /// 读取当前DataGridView的列显示顺序及宽窄、是否可见.
        /// </summary>
        /// <param name="dgv">DataGridView对象</param>
        /// <param name="userId">当前用户</param>
        /// <param name="posionId">使用的位置</param>
        public static void loadGridView(DataGridView dgv, string userId, string posionId)
        {
            if (!tableHave) CheckDataBaseHasTheTableOf_DATAGRIDVIEWINFO();
            string sql = "";
            string err;

            if (userId == "" || posionId == "") return;

            sql = "SELECT  FIELD_NAME, FIELD_INDEX, FIELD_VISIBLE, FIELD_WIDTH, USER_ID ";
            sql += "FROM T_DAtAGRIDVIEWINFO WHERE ";
            sql += "(USER_ID = '" + userId + "') AND (GRID_POSITION = '" + posionId + "') ";
            sql += " ORDER BY FIELD_VISIBLE DESC, FIELD_INDEX";

            DataTable dat;
            if (!dba.GetDataTable(sql, out dat, out err)) return;
            if (dat.Rows.Count < 1)
            {
                saveGridView(dgv, userId, posionId);
                if (!dba.GetDataTable(sql, out dat, out err)) return;
            }

            DataGridViewColumn column;
            for (int i = 0; i < dat.Rows.Count; i++)
            {
                try
                {
                    if (dgv.Columns.Contains(dat.Rows[i]["field_name"].ToString().Trim()))
                    {
                        column = dgv.Columns[dat.Rows[i]["field_name"].ToString().Trim()];
                        column.DisplayIndex = Convert.ToInt32(dat.Rows[i]["field_index"]);
                        column.Visible = ((int)dat.Rows[i]["field_visible"] == 0) ? false : true;
                        if (column.Visible)
                        {
                            column.Width = Convert.ToInt32(dat.Rows[i]["field_width"]) > 4 ? Convert.ToInt32(dat.Rows[i]["field_width"]) : 120;
                        }
                    }
                }
                catch
                { }
            }
        }
        /// <summary>
        /// 设定当前的列哪些显示，对于隐藏并不需要设定的列，设定它的tag＝0
        /// </summary>
        /// <param name="dgv">需要设定的DataGridView</param>
        public static void columnSet(DataGridView dgv)
        {
            frmColumnSet frm = new frmColumnSet();
            frm.dgv = dgv;
            frm.ShowDialog();
        }

        /// <summary>
        /// 这里最好分oracle和sqlserver，暂时仅sqlserver版本.
        /// </summary>
        public static void CheckDataBaseHasTheTableOf_DATAGRIDVIEWINFO()
        {
            string err;
            string sqlCheck = "select count(1) from sysobjects where name = 'T_DATAGRIDVIEWINFO' and xtype = 'U' ";
            string answer = dba.GetString(sqlCheck);
            if (answer == "1")
            {
                tableHave = true;
                return;
            }

            string sqlCreate = "CREATE TABLE [dbo].[T_DATAGRIDVIEWINFO]([ID] [int] IDENTITY(1,1) NOT NULL,[FIELD_NAME] [char](50) NOT NULL,[FIELD_INDEX] [decimal](18, 0) NOT NULL,[FIELD_WIDTH] [decimal](18, 0) NOT NULL,"
                + "[FIELD_VISIBLE] [int] NOT NULL,[GRID_POSITION] [char](200) NOT NULL,[USER_ID] [char](36) NOT NULL,CONSTRAINT [PK_T_DATAGRIDVIEWINFO]"
                + "PRIMARY KEY CLUSTERED ([ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]";
            dba.ExecSql(sqlCreate, out err);
            tableHave = true;
        }

    }
}
