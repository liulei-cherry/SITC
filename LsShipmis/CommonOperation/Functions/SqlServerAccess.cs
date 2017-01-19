using System;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using CommonOperation.Interfaces;
using CommonOperation.BaseClass;
using System.Drawing;

namespace CommonOperation.Functions
{
    public class SqlServerAccess : IDBAccess
    {

        private SqlConnection sqlSvrDbCnt = null;  //数据库连接对象.
        private SqlDataAdapter sqlSvrDbAdp = null;                 //数据适配器对象.
        private SqlCommand sqlSvrDbCmd = null;                 //数据命令处理对象.
        private SqlDataReader sqlSvrDbReader = null;              //只进读取器对象.
        private SqlTransaction objTrans = null;              //事务对象.
        private List<string> sqlList = new List<string>();
        private bool isTransactioning = false;
        private bool CanNotUse = true;//不能使用,当如果没有更换过连接串时?不再进行连接测试!

        public bool GetCanNotUse
        {
            get { return CanNotUse; }
        }
        private string sCannotUse = "DB connect string is invalid";
        public SqlServerAccess(string connectionString)
        {
            CanNotUse = true;
            if (sqlSvrDbCnt == null)
            {
                sqlSvrDbCnt = new SqlConnection();
            }
            sqlSvrDbCnt.ConnectionString = connectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                CanNotUse = false;
            }
            catch
            {
                CanNotUse = true;
            }
        }

        /// <summary>
        /// 数据增、删、改操作（单条语句操作）.
        /// </summary>
        public bool ExecSql(string sSql, out string sErrMessage)
        {
            #region 判断数据库当前连接串是否有效的片段

            if (CanNotUse)
            {
                sErrMessage = sCannotUse;
                return false;
            }
            #endregion
            //sErrMessage = "";
            //sqlSvrDbCmd = new SqlCommand(); //建立数据命令对象的.
            //sqlSvrDbCnt.Open();              //打开数据库连接.

            //try
            //{
            //    sqlSvrDbCmd = new SqlCommand(sSql, sqlSvrDbCnt);//实例化命令对象.

            //    sqlSvrDbCmd.ExecuteNonQuery();//执行命令.
            //    return true;
            //}
            //catch (SqlException e)
            //{
            //    //给错误信息赋值.
            //    sErrMessage = getDbError(e);
            //}
            //catch (Exception e)
            //{
            //    //给错误信息赋值.
            //    sErrMessage = e.Message;
            //}
            //finally
            //{
            //    //释放资源.
            //    if (sqlSvrDbCmd != null)
            //    {
            //        sqlSvrDbCmd.Dispose();
            //    }
            //    if (sqlSvrDbCnt.State == ConnectionState.Open)
            //    {
            //        sqlSvrDbCnt.Close();
            //    }
            //}
            //return false;

            //2011年7月22日 修改.
            sErrMessage = "";
            if (isTransactioning)
            {
                sqlList.Add(sSql);
                return true;
            }
            try
            {
                if (sqlSvrDbCnt.State == System.Data.ConnectionState.Closed)//打开数据库连接.
                {
                    sqlSvrDbCnt.Open();
                }

                CommandTransactionAdd(sSql);        //command 加事务.

                sqlSvrDbCmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException e)
            {
                //给错误信息赋值.
                sErrMessage = getDbError(e);
            }
            catch (Exception e)
            {
                //给错误信息赋值.
                sErrMessage = e.Message;
            }
            finally
            {
                sqlSvrDbCmd.Parameters.Clear();

                if ((sqlSvrDbCnt.State == ConnectionState.Open) && (objTrans == null))
                {
                    sqlSvrDbCnt.Close();
                }
            }

            return false;
        }

        /// <summary>
        /// 数据增、删、改操作（集合与事务操作）.
        /// </summary>
        public bool ExecSql(List<string> lstSql, out string sErrMessage)
        {
            #region 判断数据库当前连接串是否有效的片段

            if (CanNotUse)
            {
                sErrMessage = sCannotUse;
                return false;
            }
            #endregion
            sErrMessage = "";
            if (lstSql.Count == 0)
            {
                return true;
            }
            if (isTransactioning)
            {
                sqlList.AddRange(lstSql);
                return true;
            }
            SqlCommand[] sqlSvrDbCmdlst = new SqlCommand[lstSql.Count];//建立数据命令对象的数组.

            SqlTransaction objTrans;                    //建立一个事务对象.

            if (sqlSvrDbCnt.State == System.Data.ConnectionState.Closed)
                sqlSvrDbCnt.Open();                        //打开数据库连接.

            objTrans = sqlSvrDbCnt.BeginTransaction(); //开始事务.

            try
            {
                //循环执行泛型集合lstSql中的每一个SQL语句.
                for (int i = 0; i < lstSql.Count; i++)
                {
                    sqlSvrDbCmdlst[i] = new SqlCommand(lstSql[i], sqlSvrDbCnt, objTrans);//实例化命令对象.

                    sqlSvrDbCmdlst[i].ExecuteNonQuery();//执行命令.
                }
                objTrans.Commit();//提交事务.
                return true;
            }
            catch (SqlException e)
            {
                objTrans.Rollback();//回滚事务.

                //释放资源.
                for (int i = 0; i < lstSql.Count; i++)
                {
                    if (sqlSvrDbCmdlst[i] != null)
                    {
                        sqlSvrDbCmdlst[i].Dispose();
                    }
                }
                if (sqlSvrDbCnt.State == ConnectionState.Open)
                {
                    sqlSvrDbCnt.Close();
                }
                //给错误信息赋值.
                sErrMessage = getDbError(e);
            }
            catch (Exception e)
            {
                //给错误信息赋值.
                sErrMessage = e.Message;
                objTrans.Rollback();//回滚事务.
            }
            finally
            {
                //释放资源.
                for (int i = 0; i < lstSql.Count; i++)
                {
                    if (sqlSvrDbCmdlst[i] != null)
                    {
                        sqlSvrDbCmdlst[i].Dispose();
                    }
                }
                if (sqlSvrDbCnt.State == ConnectionState.Open)
                {
                    sqlSvrDbCnt.Close();
                }
            }
            return false;
        }

        /// <summary>
        /// 开始事务.
        /// </summary>
        public void BeginTransaction()
        {
            isTransactioning = true;
            sqlList.Clear();
        }
        /// <summary>
        /// 结束事务.
        /// </summary>
        public void EndTransaction()
        {
            isTransactioning = false;
            sqlList.Clear();
        }
        /// <summary>
        /// 提交事务.
        /// </summary>
        public void CommitTransaction()
        {
            if (isTransactioning == false)
                throw new Exception("出现了多次提交事务");
            if (sqlList.Count == 0)
                return;
            //throw new Exception("事务中没有可执行语句");
            isTransactioning = false;
            string err;
            if (!this.ExecSql(sqlList, out err))
                throw new Exception(err);
        }

        /// <summary>
        /// 给COMMAND加事务.
        /// </summary>
        public void CommandTransactionAdd(string sql)
        {
            //if (sqlSvrDbCmd == null)
            //{
            sqlSvrDbCmd = new SqlCommand("", sqlSvrDbCnt);
            //}
            if (objTrans != null)
            {
                sqlSvrDbCmd.Transaction = objTrans;
            }
            sqlSvrDbCmd.CommandText = sql;
        }

        /// <summary>
        /// 根据用户查询的SQL语句返回一个DataTable数据表对象.
        /// </summary>
        /// <param name="sSql">查询的SQL语句</param>
        /// <returns>返回一个DataTable数据表对象</returns>
        /// <summary>
        public DataTable GetDataTable(string sSql, out string sErrMessage)
        {
            DataTable dt;
            this.GetDataTable(sSql, out dt, out sErrMessage);
            return dt;
        }

        /// <summary>
        /// 根据用户查询的SQL语句返回一个DataTable数据表对象.
        /// </summary>
        /// <param name="sSql">查询的SQL语句</param>
        /// <param name="sErrMessage">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        /// <returns>返回一个DataTable数据表对象</returns>
        /// <summary>
        public bool GetDataTable(string sSql, out DataTable dataTable, out string sErrMessage)
        {
            sErrMessage = "";
            dataTable = new DataTable();//声明一个数据表对象.
            #region 判断数据库当前连接串是否有效的片段

            if (CanNotUse)
            {
                sErrMessage = sCannotUse;
                return false;
            }
            #endregion
            sqlSvrDbAdp = new SqlDataAdapter();//实例化数据适配器.

            CommandTransactionAdd(sSql);        //command 加事务.

            sqlSvrDbAdp.SelectCommand = sqlSvrDbCmd;

            try
            {
                sqlSvrDbAdp.Fill(dataTable);//填充数据表.
                return true;
            }
            catch (SqlException e)
            {
                //给错误信息赋值.
                sErrMessage = getDbError(e);
                dataTable = null;
                return false;
            }
            catch (Exception e)
            {
                //给错误信息赋值.
                sErrMessage = e.Message;
                dataTable = null;
                return false;
            }
            finally
            {
                //释放资源.
                if (sqlSvrDbAdp != null)
                {
                    sqlSvrDbAdp.Dispose();
                }
                if ((sqlSvrDbCnt.State == ConnectionState.Open) && (objTrans == null))
                {
                    sqlSvrDbCnt.Close();
                }
            }
        }

        public string GetString(string sSql, out string err)
        {
            string sContent = "";
            this.GetString(sSql, out sContent, out err);
            return sContent;
        }

        /// <summary>
        /// 返回单值的查询.
        /// </summary>
        /// <param name="sSql">包含单值的SQL语句</param>
        /// <param name="sErrMessage">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        /// <returns>返回一个字符串</returns>
        public bool GetString(string sSql, out string sContent, out string sErrMessage)
        {
            sErrMessage = "";
            sContent = "";
            #region 判断数据库当前连接串是否有效的片段

            if (CanNotUse)
            {
                sErrMessage = sCannotUse;
                return false;
            }
            #endregion
            sqlSvrDbCmd = new SqlCommand(sSql, sqlSvrDbCnt);//实例化数据命令对象.

            try
            {
                if (sqlSvrDbCnt.State == System.Data.ConnectionState.Closed)
                    sqlSvrDbCnt.Open();
                sqlSvrDbReader = sqlSvrDbCmd.ExecuteReader();
                if (sqlSvrDbReader.Read())
                {
                    sContent = sqlSvrDbReader[0].ToString();
                }
                return true;
            }
            catch (SqlException e)
            {
                //给错误信息赋值.
                sErrMessage = getDbError(e);
                return false;
            }
            catch (Exception e)
            {
                sErrMessage = e.Message;
                return false;
            }
            finally
            {
                //释放资源.
                if (sqlSvrDbReader != null)
                {
                    sqlSvrDbReader.Close();
                }
                if (sqlSvrDbCnt.State == ConnectionState.Open)
                {
                    sqlSvrDbCnt.Close();
                }
            }
        }

        /// <summary>
        /// 返回单值的查询.
        /// </summary>
        /// <param name="sSql">包含单值的SQL语句</param> 
        /// <returns>返回一个字符串</returns>
        public string GetString(string sSql)
        {
            #region 判断数据库当前连接串是否有效的片段

            if (CanNotUse)
            {
                throw new Exception(sCannotUse);
            }
            #endregion
            string sContent = "";
            sqlSvrDbCmd = new SqlCommand(sSql, sqlSvrDbCnt);//实例化数据命令对象.

            try
            {
                if (sqlSvrDbCnt.State == System.Data.ConnectionState.Closed)
                    sqlSvrDbCnt.Open();
                sqlSvrDbReader = sqlSvrDbCmd.ExecuteReader();
                if (sqlSvrDbReader.Read())
                {
                    sContent = sqlSvrDbReader[0].ToString();
                }
                return sContent;
            }
            finally
            {
                //释放资源.
                if (sqlSvrDbReader != null)
                {
                    sqlSvrDbReader.Close();
                }
                if (sqlSvrDbCnt.State == ConnectionState.Open)
                {
                    sqlSvrDbCnt.Close();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlException"></param>
        /// <returns></returns>
        private string getDbError(SqlException sqlException)
        {
            string errText = "";
            string dbErrText = sqlException.Message.ToLower();
            switch (sqlException.Number)
            {
                case -3:
                    errText = "本次修改内容,被其他用户修改过";
                    break;
                case 2601://唯一索引yys
                    errText = "破获了唯一约束! More Error Info:\r" + sqlException.Message;
                    break;
                case 547://外键约束.
                    if (CommonOperation.ConstParameter.isFristLoaded)
                    {
                        OurTableServices.GetInstance.RetrieveTable();
                        CommonOperation.ConstParameter.isFristLoaded = false;
                    }
                    //DELETE 语句与 REFERENCE 约束"FK_T_MATOUT_SHIP"冲突。该冲突发生于数据库"Wuhai4500KK"，表"dbo.T_MATERIAL_OUT", column 'SHIP_ID'。.
                    //UPDATE 语句与 FOREIGN KEY 约束"FK_SPARE_STOCK_R_SHIP"冲突。该冲突发生于数据库"shipmis_hf"，表"dbo.T_SHIP", column 'SHIP_ID'。.
                    //INSERT 语句与 FOREIGN KEY 约束"FK_SPARESTOCK_SPARE"冲突。该冲突发生于数据库"shipmis_hf"，表"dbo.T_SPARE", column 'SPARE_ID'。.
                    string fkeyTablename;
                    OurTable theFkeyTable;
                    OurTable theMkeyTable;
                    string fkeycoulumnname;
                    string MkeyTablename = "";//删除时,MkeyTablename为主表名称,插入删除时为从表名称.
                    fkeycoulumnname = dbErrText.Substring(dbErrText.IndexOf("fk_"), dbErrText.IndexOf("\"", dbErrText.IndexOf("fk_")) - dbErrText.IndexOf("fk_"));
                    fkeyTablename = dbErrText.Substring(dbErrText.IndexOf("dbo.t_"), dbErrText.IndexOf("\"", dbErrText.IndexOf("dbo.t_")) - dbErrText.IndexOf("dbo.t_"));
                    fkeyTablename = fkeyTablename.Substring(4);
                    MkeyTablename = dbErrText.Substring(0, 8).Contains("delete") ? OurTableServices.GetInstance.LoadTableNameByFkName(fkeycoulumnname) : OurTableServices.GetInstance.LoadForeignTableNameByFkName(fkeycoulumnname);
                    MkeyTablename = string.IsNullOrEmpty(MkeyTablename) ? fkeycoulumnname : MkeyTablename;
                    theMkeyTable = OurTableServices.GetInstance.LoadATableByName(MkeyTablename);
                    theFkeyTable = OurTableServices.GetInstance.LoadATableByName(fkeyTablename);
                    if (!theMkeyTable.IsWrong)
                    {
                        MkeyTablename = theMkeyTable.TableChineseName;
                    }
                    if (!theFkeyTable.IsWrong)
                    {
                        fkeyTablename = theFkeyTable.TableChineseName;
                    }
                    if (dbErrText.Substring(0, 8).Contains("update") || dbErrText.Substring(0, 8).Contains("insert"))
                    {
                        errText = "您正在保存的[" + MkeyTablename + "]信息使用了无效的[" + fkeyTablename + "]信息.";
                    }
                    else if (dbErrText.Substring(0, 8).Contains("delete"))
                    {
                        errText = "由于[" + fkeyTablename + "]信息中使用了您正要删除的[" + MkeyTablename + "]信息,当前删除操作不能完成\r\n"
                            + "如您依然希望删除当前信息,请先删除[" + fkeyTablename + "]信息中所有使用当前信息的条目.";
                    }
                    break;
                case 2627://主键约束.
                    errText = "破获了唯一约束! More Error Info:\r" + sqlException.Message;
                    break;
                case 242://日期出错误.

                    errText = "日期必须大于1753年1月1日";
                    break;
                case 7391://启动分布式事务.

                    errText = "启动分布式事务";
                    break;
                case 208://检索的表不存在.
                    errText = "检索的表不存在!";
                    break;
                case 241://日期数据不正确.

                    errText = "日期数据不正确!";
                    break;
                case 999://有打印脚本存在.

                    errText = "有打印脚本存在";
                    break;
                case 1205:// DeadLock Victim 
                    errText = "数据库发生死锁，如果是偶然发生此问题，请关闭页面或关闭程序后，重新执行当前操作，如果是经常发生此错误，请将发生此错误的具体情况形成文档并适当截图，发送给管理员！";
                    break;
                case 8114:
                    errText = "数据类型转化错误，如某字段为必填项，但用户未进行填写而保持其默认空值时，经常会发生此问题！";
                    break;
                case 8152:
                    errText = "当前提交的数据中某列长度超出原要求!";
                    break;
                default:
                    errText = "发生未知的数据库执行脚本错误，可能是必填数据未进行填写造成，\n更多错误信息请关注以下内容："
                            + sqlException.Message;
                    break;
            }
            return errText;
        }

        public bool ReadBlobFromDb(string sSelectSql, out Stream sPath, out string sErrMessage)
        {
            sErrMessage = "";
            sPath = null;
            #region 判断数据库当前连接串是否有效的片段

            if (CanNotUse)
            {
                sErrMessage = sCannotUse;
                return false;
            }
            #endregion
            try
            {
                //把文件流读取到一个byte数组btyeBlob变量中去.
                if (sqlSvrDbCnt.State == System.Data.ConnectionState.Closed)
                    sqlSvrDbCnt.Open();
                sqlSvrDbCmd = new SqlCommand(sSelectSql, sqlSvrDbCnt);
                sqlSvrDbReader = sqlSvrDbCmd.ExecuteReader();
                sqlSvrDbReader.Read();

                byte[] btyeBlob = new byte[sqlSvrDbReader.GetBytes(0, 0, null, 0, int.MaxValue)];
                sqlSvrDbReader.GetBytes(0, 0, btyeBlob, 0, btyeBlob.Length);

                // 把 byte[] 转换成 Stream 
                sPath = new MemoryStream(btyeBlob);

                return true;
            }
            catch (Exception e)
            {
                sErrMessage = e.Message; //给错误信息赋值.
                return false;
            }
            finally
            {
                ////释放资源.
                //if (fs != null)
                //{
                //    fs.Close();
                //}
                if (sqlSvrDbReader != null)
                {
                    sqlSvrDbReader.Close();
                }
                if (sqlSvrDbCmd != null)
                {
                    sqlSvrDbCmd.Dispose();
                }
                if (sqlSvrDbCnt.State == ConnectionState.Open)
                {
                    sqlSvrDbCnt.Close();
                }
            }
        }

        public bool ReadBlobFromDb(string sSelectSql, string sPath, out string sErrMessage)
        {
            FileCompress f = new FileCompress();
            FileStream fs = null;   //声明一个文件流对象.
            sErrMessage = "";
            #region 判断数据库当前连接串是否有效的片段

            if (CanNotUse)
            {
                sErrMessage = sCannotUse;
                return false;
            }
            #endregion
            try
            {
                //把文件流读取到一个byte数组btyeBlob变量中去.
                if (sqlSvrDbCnt.State == System.Data.ConnectionState.Closed)
                    sqlSvrDbCnt.Open();
                sqlSvrDbCmd = new SqlCommand(sSelectSql, sqlSvrDbCnt);
                sqlSvrDbReader = sqlSvrDbCmd.ExecuteReader();
                sqlSvrDbReader.Read();

                byte[] btyeBlob = new byte[sqlSvrDbReader.GetBytes(0, 0, null, 0, int.MaxValue)];
                sqlSvrDbReader.GetBytes(0, 0, btyeBlob, 0, btyeBlob.Length);

                FileInfo fInfo = new FileInfo(sPath + ".zip");
                fs = new FileStream(fInfo.FullName, FileMode.Create);
                fs.Write(btyeBlob, 0, btyeBlob.Length);
                fs.Close();
                string err;
                if (!f.winRarUnPress(fInfo, "", out err) || fInfo.Directory.GetDirectories().Length + fInfo.Directory.GetFiles().Length > 2)
                {
                    fInfo.MoveTo(sPath);
                }
                else
                {
                    fInfo.Delete();
                }
                return true;
            }
            catch (Exception e)
            {
                sErrMessage = e.Message; //给错误信息赋值.
                return false;
            }
            finally
            {
                //释放资源.
                if (fs != null)
                {
                    fs.Close();
                }
                if (sqlSvrDbReader != null)
                {
                    sqlSvrDbReader.Close();
                }
                if (sqlSvrDbCmd != null)
                {
                    sqlSvrDbCmd.Dispose();
                }
                if (sqlSvrDbCnt.State == ConnectionState.Open)
                {
                    sqlSvrDbCnt.Close();
                }
            }
        }

        public bool WriteBlobToDbWithIns(string sInsertSql, string sUpdateSql, string fileName, string param, out string sErrMessage)
        {
            FileStream fs = null; //声明一个文件流对象.
            #region 判断数据库当前连接串是否有效的片段

            if (CanNotUse)
            {
                sErrMessage = sCannotUse;
                return false;
            }
            #endregion
            //在更新BLOB值之前先插入一条空BLOB值（"empty_blob"），注意：在SQL Server中这不是必须的，.
            //只是为了保持与Oracle数据访问层中写法的一致性.
            sErrMessage = "";
            if (sInsertSql.Length > 0)
            {
                if (!this.ExecSql(sInsertSql, out sErrMessage))
                {
                    return false;//如果这条空值插入失败，则返回，不必再执行下边的操作.
                }
            }

            //复制fileName文件的一个复本.
            FileInfo file = new FileInfo(fileName);
            string sFileCopy = "s" + DateTime.Now.ToFileTimeUtc().ToString();
            if (File.Exists(sFileCopy))
            {
                //删除可能已存在的同名文件.
                File.Delete(sFileCopy);
            }

            try
            {
                File.Copy(fileName, sFileCopy);

                //将文件生成流写入BLOB中.

                fs = new FileStream(sFileCopy, FileMode.Open, FileAccess.Read);
                byte[] btyeBlob = new byte[fs.Length];
                fs.Read(btyeBlob, 0, btyeBlob.Length);

                //将BLOB内容插入到数据库中去.
                sqlSvrDbCmd = new SqlCommand(sUpdateSql, sqlSvrDbCnt);
                sqlSvrDbCmd.Parameters.Add(param, SqlDbType.VarBinary).Value = btyeBlob;
                if (sqlSvrDbCnt.State == System.Data.ConnectionState.Closed)
                    sqlSvrDbCnt.Open();
                sqlSvrDbCmd.ExecuteNonQuery();

                //删除复制的文件.
                fs.Close();
                try
                {
                    File.Delete(sFileCopy);
                }
                catch { }
                return true;
            }
            catch (Exception e)
            {
                sErrMessage = e.Message; //给错误信息赋值.
                return false;
            }
            finally
            {
                //释放资源.
                if (fs != null)
                {
                    fs.Close();
                }
                if (sqlSvrDbCmd != null)
                {
                    sqlSvrDbCmd.Dispose();
                }
                if (sqlSvrDbCnt.State == ConnectionState.Open)
                {
                    sqlSvrDbCnt.Close();
                }
            }
        }

        public string GetConectString()
        {
            return sqlSvrDbCnt.ConnectionString;
        }

        /// <summary>
        /// 执行一个无返回值的存储过程.
        /// </summary>
        /// <param name="sProcName">存储过程名</param>
        /// <param name="dictPara">存储过程的参数名及值集合</param>
        /// <param name="sErrMessage">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public bool ExecProce(string sProcName, Dictionary<string, string> dictInPara, out string sErrMessage)
        {
            sErrMessage = "";
            sqlSvrDbCmd = new SqlCommand(); //建立数据命令对象的.
            #region 判断数据库当前连接串是否有效的片段

            if (CanNotUse)
            {
                sErrMessage = sCannotUse;
                return false;
            }
            #endregion
            try
            {
                if (sqlSvrDbCnt.State == System.Data.ConnectionState.Closed)
                    sqlSvrDbCnt.Open();//打开数据库连接.
                sqlSvrDbCmd = new SqlCommand(sProcName, sqlSvrDbCnt);//实例化命令对象.
                sqlSvrDbCmd.CommandType = CommandType.StoredProcedure;

                //赋参数值.
                foreach (string param in dictInPara.Keys)
                {
                    sqlSvrDbCmd.Parameters.Add(param, SqlDbType.VarChar).Value = dictInPara[param];
                }

                sqlSvrDbCmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException e)
            {
                //给错误信息赋值.
                sErrMessage = getDbError(e);
                return false;
            }
            catch (Exception e)
            {
                //给错误信息赋值.
                sErrMessage = e.Message;
                return false;
            }
            finally
            {
                //释放资源.
                if (sqlSvrDbCmd != null)
                {
                    sqlSvrDbCmd.Dispose();
                }
                if (sqlSvrDbCnt.State == ConnectionState.Open)
                {
                    sqlSvrDbCnt.Close();
                }
            }
        }

        /// <summary>
        /// 执行一个存储过程返回一个结果集（使用DataAdapter对象）.
        /// </summary>
        /// <param name="sProcName">存储过程名</param>
        /// <param name="dictPara">存储过程的参数名及值集合</param>
        /// <param name="sErrMessage">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        /// <returns>返回一个DataTable对象</returns>
        public bool ExecProce(string sProcName, Dictionary<string, string> dictInPara, out DataTable dtb, out string sErrMessage)
        {
            sErrMessage = "";
            dtb = null;
            sqlSvrDbAdp = new SqlDataAdapter(); //实例化数据适配器.
            sqlSvrDbCmd = new SqlCommand();     //建立数据命令对象的.
            #region 判断数据库当前连接串是否有效的片段

            if (CanNotUse)
            {
                sErrMessage = sCannotUse;
                return false;
            }
            #endregion
            try
            {
                sqlSvrDbCmd = new SqlCommand(sProcName, sqlSvrDbCnt);   //实例化命令对象.
                sqlSvrDbCmd.CommandType = CommandType.StoredProcedure;

                //赋参数值.
                foreach (string param in dictInPara.Keys)
                {
                    sqlSvrDbCmd.Parameters.Add(param, SqlDbType.VarChar).Value = dictInPara[param];
                }

                sqlSvrDbAdp.SelectCommand = sqlSvrDbCmd;
                dtb = new DataTable();

                sqlSvrDbAdp.Fill(dtb);
                return true;
            }
            catch (SqlException e)
            {
                //给错误信息赋值.
                sErrMessage = getDbError(e);
                return false;
            }
            catch (Exception e)
            {
                //给错误信息赋值.
                sErrMessage = e.Message;
                return false;
            }
            finally
            {
                //释放资源.
                if (sqlSvrDbCmd != null)
                {
                    sqlSvrDbCmd.Dispose();
                }
                if (sqlSvrDbCnt.State == ConnectionState.Open)
                {
                    sqlSvrDbCnt.Close();
                }
            }
        }

        /// <summary>
        /// 根据指定的表名在数据库中查找该表的所有字段名称后将其放到一个泛型集合中返回.
        /// </summary>
        /// <param name="sTableName">表名</param>
        /// <returns>返回一个包含表的所有字段名的泛型集合</returns>
        public List<string> GetTablesColNames(string sTableName, out string sErrMessage)
        {
            #region 判断数据库当前连接串是否有效的片段

            if (CanNotUse)
            {
                throw new Exception(sCannotUse);
            }
            #endregion
            DataTable dtb = new DataTable();//声明一个数据表对象.
            List<string> lstColName = new List<string>();
            string sSql = "select * from " + sTableName + " where 1 = 2";
            sqlSvrDbAdp = new SqlDataAdapter(sSql, sqlSvrDbCnt);//实例化数据适配器.

            try
            {
                sqlSvrDbAdp.Fill(dtb);//填充数据表.

                foreach (DataColumn dataColumn in dtb.Columns)
                {
                    lstColName.Add(dataColumn.ColumnName.ToUpper());//全部转换成大写后再加入集合.

                }
                sErrMessage = "";
                return lstColName;
            }
            catch (SqlException e)
            {
                //给错误信息赋值.

                sErrMessage = getDbError(e);
                return null;
            }
            catch (Exception e)
            {
                //给错误信息赋值.

                sErrMessage = e.Message;
                return null;
            }
            finally
            {
                //释放资源.
                if (sqlSvrDbAdp != null)
                {
                    sqlSvrDbAdp.Dispose();
                }
            }
        }

        /// <summary>
        /// 返回存放指定表的每个字段的属性信息的泛型集合。.
        /// 这些属性信息有：字段的名称（用于设置集合的Key值）、字段的长度、是否允许为空和数据类型。.
        /// 取这些属性信息的目的是为了在界面上执行保存功能时可以对相应的控件进行校验（如长度校验、为空校验等）.
        /// </summary>
        /// <param name="tableName">指定的表名</param>
        /// <param name="sErrMessage">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        /// <returns>泛型集合</returns>
        public Dictionary<string, FldProperty> GetTbColumnSize(string tableName, out string sErrMessage)
        {
            //定义一个Dictionary的泛型集合.
            #region 判断数据库当前连接串是否有效的片段

            if (CanNotUse)
            {
                throw new Exception(sCannotUse);
            }
            #endregion
            Dictionary<string, FldProperty> dictColumn = new Dictionary<string, FldProperty>();
            sqlSvrDbCmd = new SqlCommand("select * from " + tableName, sqlSvrDbCnt);//实例化数据命令对象.
            try
            {
                if (sqlSvrDbCnt.State == System.Data.ConnectionState.Closed)
                    sqlSvrDbCnt.Open();
                sqlSvrDbReader = sqlSvrDbCmd.ExecuteReader(CommandBehavior.KeyInfo);
                DataTable dtbSchema = sqlSvrDbReader.GetSchemaTable();
                foreach (DataRow dataRow in dtbSchema.Rows)
                {
                    FldProperty fldProperty = new FldProperty();//定义一个属性信息容器类.
                    string sColName = dataRow["ColumnName"].ToString().ToUpper();//取出字段名并把它所有字母转换成大写.
                    fldProperty.ColumnSize = int.Parse(dataRow["ColumnSize"].ToString());   //取字段的长度属性信息放到fldProperty容器中.
                    fldProperty.NumericPrecision = int.Parse(dataRow["NumericPrecision"].ToString());//取字段的最大精度属性信息放到fldProperty容器中.
                    fldProperty.NumericScale = int.Parse(dataRow["NumericScale"].ToString());   //取字段的小数位数属性信息放到fldProperty容器中.
                    fldProperty.AllowDBNull = bool.Parse(dataRow["AllowDBNull"].ToString());//取字段是否为空属性信息放到fldProperty容器中.
                    fldProperty.DataType = dataRow["DataType"].ToString();                  //取字段的数据类型属性信息放到fldProperty容器中.
                    dictColumn.Add(sColName, fldProperty);  //把包含字段属性信息的容器类放到泛型集合中去.
                }
                sErrMessage = "";
                return dictColumn;
            }
            catch (Exception e)
            {
                sErrMessage = e.Message;
                return null;
            }
            finally
            {
                //释放资源.
                if (sqlSvrDbReader != null)
                {
                    sqlSvrDbReader.Close();
                }
                if (sqlSvrDbCnt.State == ConnectionState.Open)
                {
                    sqlSvrDbCnt.Close();
                }
            }
        }

        public string GetSysDate()
        {
            return " getdate() ";
        }

        /// <summary>
        /// 从Blob字段中读取图片.
        /// </summary>
        /// <param name="sSelectSql">读取图片的SQL语句</param>
        /// <param name="sErrMessage">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        /// <returns>返回一个图片的Image对象</returns>
        public Image GetImageFromDb(string sSelectSql, out string sErrMessage)
        {
            MemoryStream memStreamPic = null;

            try
            {
                //把文件流读取到一个byte数组btyeBlob变量中去.
                if (sqlSvrDbCnt.State == System.Data.ConnectionState.Closed)
                    sqlSvrDbCnt.Open();
                sqlSvrDbCmd = new SqlCommand(sSelectSql, sqlSvrDbCnt);
                sqlSvrDbReader = sqlSvrDbCmd.ExecuteReader();
                sqlSvrDbReader.Read();

                byte[] btyeBlob = new byte[sqlSvrDbReader.GetBytes(0, 0, null, 0, int.MaxValue)];
                sqlSvrDbReader.GetBytes(0, 0, btyeBlob, 0, btyeBlob.Length);

                memStreamPic = new MemoryStream(btyeBlob);
                Image image = Image.FromStream(memStreamPic);
                sErrMessage = "";//如果执行正确，则出错误信息为"";
                return image;
            }
            catch (Exception e)
            {
                sErrMessage = e.Message; //给错误信息赋值.
                return null;
            }
            finally
            {
                //释放资源.
                if (memStreamPic != null)
                {
                    memStreamPic.Close();
                }
                if (sqlSvrDbReader != null)
                {
                    sqlSvrDbReader.Close();
                }
                if (sqlSvrDbCmd != null)
                {
                    sqlSvrDbCmd.Dispose();
                }
                if (sqlSvrDbCnt.State == ConnectionState.Open)
                {
                    sqlSvrDbCnt.Close();
                }
            }
        }
    }
}
