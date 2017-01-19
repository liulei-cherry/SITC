/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：CommonOpt.cs
 * 创 建 人：李景育
 * 创建时间：2007-04-17
 * 标    题：执行一些通用的操作的类
 * 功能描述：对于系统中一些通用的操作在此类中实现。
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using CommonOperation.BaseClass;
using CommonViewer.BaseControl;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
namespace LSShipMis_Ship.Common.Classes
{
    /// <summary>
    /// 可引用所有无参数方法的委托.
    /// </summary>
    public delegate void DelegateShipMisPub();

    /// <summary>
    /// 可引用所有有一个参数方法的委托.
    /// </summary>
    /// <param name="param">参数</param>
    public delegate void DelegatePub(string param);

    /// <summary>
    /// 执行一些通用的操作的类.
    /// </summary>
    public class CommonOpt
    {
        //定义数据操作层对象.
        private static IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();

        /// <summary>
        /// 十、保存dtb中的数据到tableName表中去.
        /// </summary>
        /// <param name="dtb">包含数据的DataTable对象</param>
        /// <param name="sTableName">要保存到数据的表名</param>
        /// <param name="mark">标记：0表示是添加BindingSource中的数据；1表示是要修改DataTable中的数据</param>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public void SaveFormData(DataTable dtb, string sTableName, int mark, out string err)
        {
            //得到dtb数据的一份克隆（注意不能是dtb，因为它是引用类型，数据一改变影响其它组件的显示）.
            DataTable dtbForSave = dtb.Copy();

            //把dtbForSave中所有新添加、删除及修改过的数据组装成相应的Insert、Delete和Update语句放到一个泛型集合中去.

            List<string> lstSqlOpt = new List<string>();
            if (mark == 0)
            {
                lstSqlOpt = this.getOptSqlFromTable(dtbForSave, sTableName, out err);
            }
            else
            {
                lstSqlOpt = this.getInsSqlFromTable(dtbForSave, sTableName, out err);
            }

            if (err.Equals(""))
            {
                //执行数据更新.
                dbAccess.ExecSql(lstSqlOpt, out err);

                //如果所有语句执行正确，则提交修改结果.

                if (err.Equals(""))
                {
                    dtb.AcceptChanges();
                }
            }
        }

        /// <summary>
        /// 十一、把DataTable中所有新增加的、删除的和更新的数据取出来分别组成相应的Insert、Delete和Update的.
        /// 操作语句放到一个泛型集合中去。由于DataTable中包含的数据可能是包含关联表的连接数据，因此无法使用.
        /// Adapter的Update语句进行成批更新。这里只能把所有新变化的数据取出来组成相关的操作语句来执行。.
        /// 需要注意的是：dtb的源Select语句必须写上主键列并且要把主键写在第1列。.
        /// 这个函数与getOptInsFromTable函数的不同点是，它是更新BindingSource数据源中的数据，.
        /// 而前者是更新DataTable中的数据。.
        /// 需要注意一点：如果是在程序中直接调用本函数而得到对dtb表的编辑语句，那么在调用时不能用原DataTable，.
        /// 必须使用如DataTable dtbForSave = dtb.Copy()的语句生成一个原DataTable的复本，因为本函数中要对传入.
        /// 的DataTable进行加工（删除列），从而使显示时出现问题。.
        /// </summary>
        /// <param name="dtb">包含数据的DataTable</param>
        /// <param name="tableName">要更新数据的表名</param>
        /// <returns>返回一个包含增、删、改的操作语句的泛型集合</returns>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        public List<string> getOptSqlFromTable(DataTable dtb, string tableName, out string err)
        {
            List<string> lstSqlOpt = new List<string>();//定义一个用于包含增、删、改的操作语句的泛型集合.

            //得到一个泛型的哈希表集合，里边存放着表tableName中每个字段的属性信息（如长度，是否为空等），哈希表的Key值用字段名表示.
            //这个主要用于下边判断列是不是布尔型时使用（注意，有时抛出异常KeyNotFoundException并说给定的关键字不在字典中，这种.
            //错误情况是因为字段的大小写不一致引起的，另外，对于Oracle数据库中的表如果存在BLOB字段，也会抛出此异常）.
            Dictionary<string, FldProperty> dictDtb = dbAccess.GetTbColumnSize(tableName, out err);

            //在数据库中取实际表tableName的所有列名放到泛型集合lstColName中.

            List<string> lstColName = dbAccess.GetTablesColNames(tableName, out err);

            //取出dtb中所有不存在于集合lstColName（也即是实际表tableName）中的列名放到泛型集合lstColNameNo中.
            List<string> lstColNameNo = new List<string>();
            foreach (DataColumn dataColumn in dtb.Columns)
            {
                if (dataColumn.DataType.Name.Equals("Byte[]"))
                {
                    lstColNameNo.Add(dataColumn.ColumnName);
                    continue;
                }

                if (lstColName.Contains(dataColumn.ColumnName.ToUpper()) == false)
                {
                    lstColNameNo.Add(dataColumn.ColumnName);
                }
            }

            //在dtb中删除所有不属于实际表tableName中的列名以便为数据插入准备好条件，.
            //因为必须保证dtb与实际表tableName的结构完毕一致才能使数据插入的成功。.
            foreach (string sColNameNo in lstColNameNo)
            {
                dtb.Columns.Remove(dtb.Columns[sColNameNo]);
            }

            DataView dv = new DataView(dtb);//取得当前表dtb的视图对象dv

            //***（1）加工插入语句***************************************************************************/
            //取出所有新添加的数据.

            dv.RowStateFilter = DataViewRowState.Added;
            DataTable dtbAdded = dv.ToTable();

            //建立Insert Into语句.
            string sInsertSql = "";
            string sInsertFld = "insert into " + tableName + " (";
            string sInsertVal = " values (";
            foreach (DataColumn dataColumn in dtbAdded.Columns)
            {
                sInsertFld += dataColumn.ColumnName + ",";
            }
            sInsertFld = sInsertFld.Substring(0, sInsertFld.Length - 1) + ")";//去掉最后的逗号.

            //把dtbAdded中所有的数据取出来组成Insert Into语句.
            foreach (DataRow dataRow in dtbAdded.Rows)
            {
                foreach (DataColumn dataColumn in dtbAdded.Columns)
                {
                    //字符型数据.

                    if (dataColumn.DataType.Name.Equals("String"))
                    {
                        if (dataRow[dataColumn].ToString().Trim().Length == 0)
                        {
                            sInsertVal += "null,";//如果字符串为空字符，那么在数据库中插入Null值（处理SQL Server外键插入空字符串时出错问题）.
                        }
                        else
                        {
                            sInsertVal += "'" + VarcharExchangeOfOracle(dataRow[dataColumn].ToString()) + "',";
                        }
                    }
                    //数值型数据.
                    else if (dataColumn.DataType.Name.Equals("Decimal"))
                    {
                        if (dataRow[dataColumn].ToString().Trim().Length == 0)
                        {
                            //得到包含当前字段dataColumn的属性信息的容器类fldProperty
                            FldProperty fldProperty = dictDtb[dataColumn.ColumnName.ToUpper()];
                            //如果当前字段的精度为1,小数位数为0,则应该是布尔类型数据,这时设置值为默认的0
                            if (fldProperty.NumericPrecision == 1 && fldProperty.NumericScale == 0)
                            {
                                sInsertVal += "0,";
                            }
                            else
                            {
                                sInsertVal += "null,";//如果没有任何值，则赋值为null
                            }
                        }
                        else
                        {
                            sInsertVal += dataRow[dataColumn].ToString() + ",";
                        }
                    }
                    //日期型数据.

                    else if (dataColumn.DataType.Name.Equals("DateTime"))
                    {
                        if (dataRow[dataColumn].ToString().Trim().Length == 0 || dataRow[dataColumn].ToString().Trim() == "0001-1-1 0:00:00")
                        {
                            sInsertVal += "null,";//如果没有任何值，则赋值为null
                        }
                        else
                        {
                            sInsertVal +=  " cast('" + dataRow[dataColumn].ToString()  + "' as datetime),";
                        }
                    }
                    //其它类型数据.
                    else
                    {
                        sInsertVal += "'" + VarcharExchangeOfOracle(dataRow[dataColumn].ToString()) + "',";
                    }
                }
                sInsertVal = sInsertVal.Substring(0, sInsertVal.Length - 1) + ")";//去掉最后的逗号.
                sInsertSql = sInsertFld + sInsertVal;

                lstSqlOpt.Add(sInsertSql);//把组装好的Insert操作语句放到泛型集合中去.
                sInsertVal = " values ("; //初始化sInsertVal
            }
            /***插入语句加工结束***************************************************************************/
            //***（2）加工删除语句***************************************************************************/
            //取出所有删除的数据.
            dv.RowStateFilter = DataViewRowState.Deleted;
            DataTable dtbDeleted = dv.ToTable();

            //建立Delete语句.
            string sDeleteSql = "";

            foreach (DataRow dataRow in dtbDeleted.Rows)
            {
                sDeleteSql = "delete from " + tableName + " where " + dtbDeleted.Columns[0].ColumnName + " = ";
                sDeleteSql += "'" + dataRow[0].ToString() + "'";

                lstSqlOpt.Add(sDeleteSql);//把组装好的Delete操作语句放到泛型集合中去.
            }

            /***删除语句加工结束***************************************************************************/
            //***（3）加工修改语句***************************************************************************/
            //取出所有修改过的数据.
            dv.RowStateFilter = DataViewRowState.ModifiedCurrent;
            DataTable dtbUpdated = dv.ToTable();
            List<string> lstUpdatedSql = this.getLstUpdateSql(dtbUpdated, tableName, lstColName);

            //取出所有修改过的数据的修改前的值.
            dv.RowStateFilter = DataViewRowState.ModifiedOriginal;
            DataTable dtbOriginal = dv.ToTable();
            List<string> lstOriginalSql = this.getLstUpdateSql(dtbOriginal, tableName, lstColName);

            //以修改前的值为参照，判断lstUpdatedSql中包含的update语句是否真修改过数据，如果确未修改过，则删除该语句。.
            //（bindingSource存在一个缺陷，也就是说当焦点放在某一个记录上时，并未修改该记录任何值，但却仍然被打上了.
            //修改标记，这样在生成修改语句时仍能生成update语句，本代码块是为了解决这个问题）.
            foreach (string sSql in lstOriginalSql)
            {
                if (lstUpdatedSql.Contains(sSql))
                {
                    lstUpdatedSql.Remove(sSql);
                }
            }

            //把可能包含的修改语句添加到集合lstSqlOpt中去.
            lstSqlOpt.AddRange(lstUpdatedSql);

            /***修改语句加工结束***************************************************************************/
            return lstSqlOpt;
        }

        /// <summary>
        /// 十二、把DataTable中所有的数据取出来组成相应的Insert的操作语句放到一个泛型集合中去。.
        /// 需要注意的是：dtb的源Select语句必须写上主键列并且要把主键写在第1列。这个函数与getOptSqlFromTable函数.
        /// 的不同点是，它是更新DataTable中的数据，而前者是更新BindingSource数据源中的数据。.
        /// </summary>
        /// <param name="dtb">包含数据的DataTable</param>
        /// <param name="tableName">要更新数据的表名</param>
        /// <returns>返回一个包含添加的操作语句的泛型集合</returns>
        /// <param name="err">返回参数，返回一个出错信息，如果为ok，则表示正常</param>
        private List<string> getInsSqlFromTable(DataTable dtb, string tableName, out string err)
        {
            List<string> lstSqlOpt = new List<string>();//定义一个用于包含增、删、改的操作语句的泛型集合.

            //得到一个泛型的哈希表集合，里边存放着表tableName中每个字段的属性信息（如长度，是否为空等），哈希表的Key值用字段名表示.
            //这个主要用于下边判断列是不是布尔型时使用.
            Dictionary<string, FldProperty> dictDtb = dbAccess.GetTbColumnSize(tableName, out err);

            //在数据库中取实际表tableName的所有列名放到泛型集合lstColName中.
            List<string> lstColName = dbAccess.GetTablesColNames(tableName, out err);

            //取出dtb中所有不存在于集合lstColName（也即是实际表tableName）中的列名放到泛型集合lstColNameNo中.
            List<string> lstColNameNo = new List<string>();
            foreach (DataColumn dataColumn in dtb.Columns)
            {
                if (lstColName.Contains(dataColumn.ColumnName.ToUpper()) == false)
                {
                    lstColNameNo.Add(dataColumn.ColumnName);
                }
            }

            //在dtb中删除所有不属于实际表tableName中的列名以便为数据插入准备好条件，.
            //因为必须保证dtb与实际表tableName的结构完毕一致才能使数据插入的成功。.
            foreach (string sColNameNo in lstColNameNo)
            {
                dtb.Columns.Remove(dtb.Columns[sColNameNo]);
            }

            //***（1）加工插入语句***************************************************************************/
            //取出所有新添加的数据.
            DataTable dtbAdded = dtb;

            //建立Insert Into语句.
            string sInsertSql = "";
            string sInsertFld = "insert into " + tableName + " (";
            string sInsertVal = " values (";
            foreach (DataColumn dataColumn in dtbAdded.Columns)
            {
                sInsertFld += dataColumn.ColumnName + ",";
            }
            sInsertFld = sInsertFld.Substring(0, sInsertFld.Length - 1) + ")";//去掉最后的逗号.

            //把dtbAdded中所有的数据取出来组成Insert Into语句.
            foreach (DataRow dataRow in dtbAdded.Rows)
            {
                foreach (DataColumn dataColumn in dtbAdded.Columns)
                {
                    //字符型数据.
                    if (dataColumn.DataType.Name.Equals("String"))
                    {
                        if (dataRow[dataColumn].ToString().Trim().Length == 0)
                        {
                            sInsertVal += "null,";//如果字符串为空字符，那么在数据库中插入Null值（处理SQL Server外键插入空字符串时出错问题）.
                        }
                        else
                        {
                            sInsertVal += "'" + VarcharExchangeOfOracle(dataRow[dataColumn].ToString()) + "',";
                        }
                    }
                    //数值型数据.
                    else if (dataColumn.DataType.Name.Equals("Decimal"))
                    {
                        if (dataRow[dataColumn].ToString().Trim().Length == 0)
                        {
                            //得到包含当前字段dataColumn的属性信息的容器类fldProperty
                            FldProperty fldProperty = dictDtb[dataColumn.ColumnName.ToUpper()];
                            //如果当前字段的精度为1,小数位数为0,则应该是布尔类型数据,这时设置值为默认的0
                            if (fldProperty.NumericPrecision == 1 && fldProperty.NumericScale == 0)
                            {
                                sInsertVal += "0,";
                            }
                            else
                            {
                                sInsertVal += "null,";//如果没有任何值，则赋值为null
                            }
                        }
                        else
                        {
                            sInsertVal += dataRow[dataColumn].ToString() + ",";
                        }
                    }
                    //日期型数据.
                    else if (dataColumn.DataType.Name.Equals("DateTime"))
                    {
                        if (dataRow[dataColumn].ToString().Trim().Length == 0 || dataRow[dataColumn].ToString().Trim() == "0001-1-1 0:00:00")
                        {
                            sInsertVal += "null,";//如果没有任何值，则赋值为null
                        }
                        else
                        {
                            sInsertVal += " cast('" + dataRow[dataColumn].ToString() + "' as datetime) ,";
                        }
                    }
                    //其它类型数据.
                    else
                    {
                        sInsertVal += "'" + VarcharExchangeOfOracle(dataRow[dataColumn].ToString()) + "',";
                    }
                }
                sInsertVal = sInsertVal.Substring(0, sInsertVal.Length - 1) + ")";//去掉最后的逗号.
                sInsertSql = sInsertFld + sInsertVal;

                lstSqlOpt.Add(sInsertSql);//把组装好的Insert操作语句放到泛型集合中去.
                sInsertVal = " values ("; //初始化sInsertVal
            }
            /***插入语句加工结束***************************************************************************/
            return lstSqlOpt;
        }

        /// <summary>
        /// 将dtb中的每条记录生成对应的update语句.
        /// </summary>
        /// <param name="dtb">包含数据的DataTable对象</param>
        /// <param name="tableName">要操作的表名</param>
        /// <param name="lstColName">表中的各个列名</param>
        /// <returns>返回一个包含update语句的List泛型集合</returns>
        private List<string> getLstUpdateSql(DataTable dtb, string tableName, List<string> lstColName)
        {
            List<string> lstUpdateSql = new List<string>();

            //建立Update语句.
            string sUpdateSql = "update " + tableName + " set ";

            //把dtbUpdated中所有的数据取出来组成Update语句.
            foreach (DataRow dataRow in dtb.Rows)
            {
                for (int iCount = 1; iCount < dtb.Columns.Count; iCount++)
                {
                    DataColumn dataColumn = dtb.Columns[iCount];//取得当前列.
                    //字符型数据.
                    if (dataColumn.DataType.Name.Equals("String"))
                    {
                        if (dataRow[dataColumn].ToString().Trim().Length == 0)
                        {
                            sUpdateSql += dataColumn.ColumnName + " = null,";//如果字符串为空字符，那么在数据库中插入Null值（处理SQL Server外键插入空字符串时出错问题）.
                        }
                        else
                        {
                            sUpdateSql += dataColumn.ColumnName + " = '" + VarcharExchangeOfOracle(dataRow[dataColumn].ToString()) + "',";
                        }
                    }
                    //数值型数据.
                    else if (dataColumn.DataType.Name.Equals("Decimal"))
                    {
                        if (dataRow[dataColumn].ToString().Trim().Length == 0)
                        {
                            sUpdateSql += dataColumn.ColumnName + " = null,";//如果没有赋值，则为null
                        }
                        else
                        {
                            sUpdateSql += dataColumn.ColumnName + " = " + dataRow[dataColumn].ToString() + ",";
                        }
                    }
                    //日期型数据.
                    else if (dataColumn.DataType.Name.Equals("DateTime"))
                    {
                        if (dataRow[dataColumn].ToString().Trim().Length == 0 || dataRow[dataColumn].ToString().Trim() == "0001-1-1 0:00:00")
                        {
                            sUpdateSql += dataColumn.ColumnName + " = null,";//如果没有赋值，则为null
                        }
                        else
                        {
                            sUpdateSql += dataColumn.ColumnName + " = cast('" + dataRow[dataColumn].ToString() + "' as datetime) ";
                        }
                    }
                    //其它型数据.
                    else
                    {
                        sUpdateSql += dataColumn.ColumnName + " = '" + VarcharExchangeOfOracle(dataRow[dataColumn].ToString()) + "',";
                    }
                }

                //在修改时如果当前业务表存在UPDATETIME字段，则用系统日期来更新该字段（2007-08-21添加此功能）.
                if (lstColName.Contains("UPDATETIME"))
                {
                    sUpdateSql += "UpdateTime = getdate(),";
                }
                //组装好更新当前行的Update语句.
                sUpdateSql = sUpdateSql.Substring(0, sUpdateSql.Length - 1) + " where " + dtb.Columns[0] + "='" + dataRow[0].ToString() + "'";

                lstUpdateSql.Add(sUpdateSql);//把组装好的Update操作语句放到泛型集合中去.
                sUpdateSql = "update " + tableName + " set ";
            }

            return lstUpdateSql;
        }

        /// <summary>
        /// 十三、填充TreeView中指定节点的子节点.
        /// </summary>
        /// <param name="treeNode">TreeView控件中的当前指定节点</param>
        /// <param name="dtbCurNode">包含TreeNode所需数据的DataTable</param>
        /// <param name="isLeaf">是否是叶子节点</param>
        public void FillTreeNode(TreeNode treeNode, DataTable dtbCurNode, bool isLeaf)
        {
            //用dtbCurNode中的值填充当前节点treeNode
            foreach (DataRow dataRow in dtbCurNode.Rows)
            {
                string sId = dataRow[0].ToString();  //取出Id用于设置子节点的Tag属性.

                string sName = dataRow[1].ToString();//取出名称用于设置子节点的Text属性.

                TreeNode newNode = new TreeNode();   //建立一个新的节点对象.

                newNode.Tag = sId;                   //设置子节点的Tag属性；.
                newNode.Name = sId;                  //设置子节点的Name属性；.
                newNode.Text = sName;                //设置子节点的Text属性.

                if (isLeaf == false)
                {
                    newNode.ImageIndex = 1;              //设置子节点的图标.
                    newNode.SelectedImageIndex = 2;      //设置子节点的打开图标.
                }
                else
                {
                    newNode.ImageIndex = 3;              //设置子节点的图标.
                    newNode.SelectedImageIndex = 3;      //设置子节点的打开图标.
                }
                treeNode.Nodes.Add(newNode);         //把newNode节点做为子节点添加到treeNode节点对象中去.
            }
        }

        /// <summary>
        /// 十四、填充TreeView中指定节点的子节点.
        /// </summary>
        /// <param name="treeNode">TreeView控件中的当前指定节点</param>
        /// <param name="dtbCurNode">包含TreeNode所需数据的DataTable</param>
        /// <param name="imgIndex">要显示的图标索引</param>
        /// <param name="selImgIndex">选择的图标索引</param>
        public void FillTreeNode(TreeNode treeNode, DataTable dtbCurNode, int imgIndex, int selImgIndex)
        {
            //用dtbCurNode中的值填充当前节点treeNode
            foreach (DataRow dataRow in dtbCurNode.Rows)
            {
                string sId = dataRow[0].ToString();  //取出Id用于设置子节点的Tag属性.
                string sName = dataRow[1].ToString();//取出名称用于设置子节点的Text属性.
                TreeNode newNode = new TreeNode();   //建立一个新的节点对象.
                newNode.Tag = sId;                   //设置子节点的Tag属性；.
                newNode.Name = sId;                  //设置子节点的Name属性；.
                newNode.Text = sName;                //设置子节点的Text属性.
                newNode.ImageIndex = imgIndex;       //设置子节点的图标.
                newNode.SelectedImageIndex = selImgIndex;//设置子节点的打开图标.
                treeNode.Nodes.Add(newNode);         //把newNode节点做为子节点添加到treeNode节点对象中去.
            }
        }

        /// <summary>
        /// 十五、当前TreeView中当前节点选中时，选中其所有的子节点；反之，当未选中时，取消所有子节点的选择.
        /// </summary>
        /// <param name="treeNode">TreeView控件中的当前节点</param>
        public void SetChildNodeCheck(TreeNode treeNode)
        {
            foreach (TreeNode curNode in treeNode.Nodes)
            {
                curNode.Checked = treeNode.Checked;
            }
        }

        /// <summary>
        /// 在指定的树控件（treeView）上，从当前节点（curNode）出发，逐级搜索要搜索的内容（sContent）.
        /// </summary>
        /// <param name="treeView">树控件</param>
        /// <param name="curNode">树控件上的当前节点</param>
        /// <param name="sContent">要搜索的内容</param>
        /// <param name="bln">
        /// 如果开始搜索时curNode的内容就已经等于sContent，这时无法前进，.
        /// 所以在调用时要传一个false值.
        /// </param>
        /// <param name="mark">0表示按节点的文本搜索，1表示按节点的tag值搜索</param>
        public void TreeSearch(TreeView treeView, TreeNode curNode, string sContent, bool bln, int mark)
        {
            treeView.SelectedNode = curNode;//把焦点移到当前节点上.

            if (mark == 0) //按节点的文本搜索.
            {
                if (bln == true && curNode.Text.IndexOf(sContent) != -1)
                {
                    //如果找到了则退出.
                    return;
                }
            }
            //按节点的tag值搜索.
            else
            {
                if (bln == true && curNode.Tag.ToString().Equals(sContent))
                {
                    //如果找到了则退出.
                    return;
                }
            }

            //下级节点搜索.
            if (curNode.Nodes.Count > 0)
            {
                TreeSearch(treeView, curNode.Nodes[0], sContent, true, mark);
            }
            //同级节点搜索.
            else if (curNode.NextNode != null)
            {
                TreeSearch(treeView, curNode.NextNode, sContent, true, mark);
            }
            //上级节点搜索.
            else
            {
                TreeNode thisnode = curNode;
                while (thisnode.Parent != null)
                {
                    thisnode = thisnode.Parent;
                    if (thisnode.NextNode != null)
                    {
                        TreeSearch(treeView, thisnode.NextNode, sContent, true, mark);
                        return;
                    }
                }
                if (mark == 0) //按节点的文本搜索.
                {
                    if (thisnode.Parent == null && thisnode.Text.IndexOf(sContent) == -1)
                    {
                        MessageBoxEx.Show("已搜索到结尾，未找到符合条件的内容", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                //按节点的tag值搜索.
                else
                {
                    if (thisnode.Parent == null && thisnode.Tag.ToString().Equals(sContent))
                    {
                        MessageBoxEx.Show("已搜索到结尾，未找到符合条件的内容");
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// 根据当前TreeNode节点的选择状态来决定所有父节点和子节点的选择状态。.
        /// 对于父节点：如果当前节点被选择，那么其上的所有的父节点都必须被选择（根节点除外）；.
        /// 对于子节点：如果当前节点被取消选择，那么其下的所有子节点都必须被取消选择。.
        /// （使用递归算法）.
        /// </summary>
        /// <param name="curNode">树的当前节点</param>
        public void MakeTreeViewNode(TreeNode curNode)
        {
            //对于父节点的处理：如果当前节点被选择，那么其上的所有的父节点都必须被选择（根节点除外）。.

            if (curNode.Checked == true && curNode.Parent != null && curNode.Parent != curNode.TreeView.Nodes[0])
            {
                curNode.Parent.Checked = true;
                MakeTreeViewNode(curNode.Parent);//上级递归调用.
            }
            //对于子节点的处理：如果当前节点被取消选择，那么其下的所有子节点都必须被取消选择。.

            else if (curNode.Checked == false)
            {
                foreach (TreeNode theNode in curNode.Nodes)
                {
                    if (theNode.Parent != null && theNode.Parent != theNode.TreeView.Nodes[0])
                    {
                        theNode.Checked = false;
                    }

                    MakeTreeViewNode(theNode);  //下级递归调用.
                }
            }
        }

        /// <summary>
        /// 取得树treeView的当前选中节点的最顶级的父节点的文本信息（但不是根节点）.
        /// （本函数示例如何取得返回值的递归函数）.
        /// </summary>
        /// <param name="treeView">树控件</param>
        /// <param name="curNode">树的当前选中的节点</param>
        /// <returns>返回符合要求的父节点的文件信息</returns>
        public string GetSecondNodeText(TreeView treeView, TreeNode curNode)
        {
            string sNdText = "";    //要返回的文本信息.

            //如果当前选中的节点不是根节点，并且它的父节点不是顶级节点，那么逐层取它的上级节点.

            if (curNode != treeView.Nodes[0] && curNode.Parent != treeView.Nodes[0])
            {
                curNode = curNode.Parent;
                sNdText = GetSecondNodeText(treeView, curNode);
                return sNdText;
            }
            else
            {
                return curNode.Text;
            }
        }

        /// <summary>
        /// 十六、根据指定的查询数据填充ListView控件.
        /// </summary>
        /// <param name="listView">ListView控件</param>
        /// <param name="dtb">用于查询数据的SQL语句</param>
        public void FillListView(ListView listView, DataTable dtb)
        {
            listView.Clear();
            if (dtb == null)
            {
                return;
            }
            //填充列标头部分（i没有从0开始循环是因为第0列是Id,没有必要显示到ListView上）.
            //徐正本改过这里,Add(name,string,....);
            for (int i = 1; i < dtb.Columns.Count; i++)
            {
                listView.Columns.Add(dtb.Columns[i].ColumnName, dtb.Columns[i].ColumnName, 120);
            }

            //填充数据部分.
            for (int i = 0; i < dtb.Rows.Count; i++)
            {
                //填充lstItem当前行的第1列（使用名称填充）.

                ListViewItem lstItem = listView.Items.Add(dtb.Rows[i][1].ToString(), dtb.Rows[i][1].ToString());//把dtb的第2列(索引是1)做为lstItem的显示文本.

                lstItem.Tag = dtb.Rows[i][0].ToString();//把Id（第1列(索引是0)）设置为lstItem的Tag属性.

                //填充lstItem当前行的其它各列（从dtb的第3列(索引是2)开始）.
                for (int j = 2; j < dtb.Columns.Count; j++)
                {
                    lstItem.SubItems.Add(dtb.Rows[i][j].ToString()).Name = dtb.Rows[i][j].ToString();
                }
            }
        }

        /// <summary>
        /// 十七、在两个ListView控件之间移动数据.
        /// </summary>
        /// <param name="lstViewSource">源ListView控件</param>
        /// <param name="lstViewDestin">目标ListView控件</param>
        public void MoveItemInLstView(ListView lstViewSource, ListView lstViewDestin)
        {
            //循环源ListView控件中的每个选中的项，将其先删除（必须先删除）后再添加到目标ListView控件中去.
            foreach (ListViewItem lstItem in lstViewSource.CheckedItems)
            {
                lstItem.Remove();
                lstItem.Checked = false;
                lstViewDestin.Items.Add(lstItem);
            }
        }

        /// <summary>
        /// 十九、判断指定的bindingSource中的数据是否有改变，有返回true，否则返回false
        /// </summary>
        /// <param name="bds">bindingSource组件</param>
        /// <returns>返回一个bool型值</returns>
        public bool BdsHasChanged(BindingSource bds)
        {
            DataTable dtb = (DataTable)bds.DataSource;
            if (dtb == null)
            {
                return false;
            }

            if (dtb.GetChanges() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 二十、取当指定的DataTable的主键组成的用逗号连接的字符串.
        /// </summary>
        /// <param name="dtb">在船信息人员DataTable对象</param>
        /// <returns></returns>
        public string GetDataTableIds(DataTable dtb, string Id)
        {
            string sIds = "";

            if (dtb.Rows.Count > 0)
            {
                sIds += "('" + dtb.Rows[0][Id].ToString() + "'";
                for (int i = 1; i < dtb.Rows.Count; i++)
                {
                    sIds += ",'" + dtb.Rows[i][Id].ToString() + "'";
                }
                sIds += ")";
            }

            return sIds;
        }

        /// <summary>
        /// 二十一、取得Blob二进制流对象.
        /// </summary>
        /// <param name="filePath">文件的全路径</param>
        /// <returns>返回字节型的二进制流对象</returns>
        public byte[] GetBlobData(string filePath)
        {
            //建立读取文件的流对象.
            FileStream fsobj = null;
            BinaryReader reader = null;

            try
            {
                fsobj = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                reader = new BinaryReader(fsobj);
                byte[] blobData = reader.ReadBytes((int)fsobj.Length);
                return blobData;
            }
            catch (IOException)
            {
                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                reader.Close();
                fsobj.Close();
            }
        }

        /// <summary>
        /// 二十二、取得当前系统中的指定路径.
        /// </summary>
        /// <param name="sPath"></param>
        /// <returns></returns>
        public string GetCurrentPath(string sPath)
        {
            string startPath = Application.StartupPath;
            string curPath = "";
            int binPos = startPath.IndexOf("\\bin");

            if (binPos >= 0)
            {
                curPath = startPath.Substring(0, binPos) + sPath;
            }
            else
            {
                curPath = startPath + sPath;
            }
            return curPath;
        }

        /// <summary>
        /// 二十三、从数据库中取出的大对象文档要保存的临时文件名（规则为Temp+年月日时分秒）.
        /// </summary>
        /// <param name="ext">文件扩展名</param>
        /// <returns></returns>
        public string GetTempFileName(string ext)
        {
            string sFileName = "";//文件名.
            //根据扩展名称带"."与否来分别处理文件名.
            if (ext.IndexOf(".") >= 0)
            {
                sFileName = "Temp" + DateTime.Now.ToString("yyyyMMddhhmmss") + ext;
            }
            else
            {
                sFileName = "Temp" + DateTime.Now.ToString("yyyyMMddhhmmss") + "." + ext;
            }

            return sFileName;
        }

        /// <summary>
        /// 判断网格dgv的列colname中是否存在不为空的单元格，如果有则返回true
        /// </summary>
        /// <param name="dgv">DataGridView网格控件</param>
        /// <param name="colname">要校验的列名称</param>
        /// <returns>返回bool值，如果存在一个不为空的单元格，则返回true，全空返回false</returns>
        public bool HasEmptyVal(DataGridView dgv, string colname)
        {
            bool blnResult = false;

            foreach (DataGridViewRow dgvRow in dgv.Rows)
            {
                string sCurCell = dgvRow.Cells[colname].Value.ToString();
                if (sCurCell.Trim().Length == 0)
                {
                    blnResult = true;
                    break;
                }
            }

            return blnResult;
        }

        /// 判断当前值在表中是否有重复值.
        public bool HasRepliVal(string curVal, string tableName, string colName, string whereOp)
        {
            string sql = "";
            string err = "";
            bool blnResult = false;
            DataTable dt = new DataTable();

            //值curVal为空时不进行判断.
            if (curVal.Trim().Equals(""))
            {
                return false;
            }

            sql = "select " + colName;
            sql += "  from " + tableName + " ";
            sql += " where " + colName + "  = '" + curVal + "'";
            if (!string.IsNullOrEmpty(whereOp))
            {
                sql += " and " + whereOp;
            }

            dt = dbAccess.GetDataTable(sql, out err);
            if (dt.Rows.Count > 0)
            {
                blnResult = true;
            }

            return blnResult;
        }

        private void removeMark(DataTable dtb)
        {
            DataRow[] dataRow = dtb.Select(null, null, DataViewRowState.Added);

            foreach (DataRow row in dataRow)
            {
                dtb.Rows.Remove(row);
            }
        }

        /// <summary>
        /// 判断当前的操作是否是添加操作.
        /// </summary>
        /// <param name="dtb">包含数据的DataTable对象</param>
        /// <returns>添加操作返回true，否则返回false</returns>
        public bool IsInsertOpt(DataTable dtb)
        {
            bool blResult = false;

            DataTable dtbAdded = dtb.GetChanges(DataRowState.Added);
            if (dtbAdded != null && dtbAdded.Rows.Count > 0)
            {
                blResult = true;
            }

            return blResult;
        }

        /// <summary>
        /// 判断当前的操作是否是删除操作.
        /// </summary>
        /// <param name="dtb">包含数据的DataTable对象</param>
        /// <returns>添加操作返回true，否则返回false</returns>
        public bool IsDeleteOpt(DataTable dtb)
        {
            bool blResult = false;

            DataTable dtbDel = dtb.GetChanges(DataRowState.Deleted);
            if (dtbDel != null && dtbDel.Rows.Count > 0)
            {
                blResult = true;
            }

            return blResult;
        }

        /// <summary>
        /// 用于判断在保存明细数据时，主数据是否已被保存过，如果没有保存过，则先保存主数据。.
        /// 在主表/子表界面上一般需要调用此功能，用户在添加完主表数据后没有立即保存接着就输入.
        /// 明细数据，在此时调用本函数可判断主表数据是否保存过.
        /// </summary>
        /// <param name="bds"></param>
        /// <returns></returns>
        public bool IsMainSaved(BindingSource bds)
        {
            bool blResult = true;
            bds.EndEdit();
            DataTable dtb = (DataTable)bds.DataSource;//从BindingSource组件中取得信息集放到DataTable中去.

            if (dtb != null && this.IsInsertOpt(dtb))
            {
                blResult = false;
            }

            return blResult;
        }

        /// <summary>
        /// 用于判断指定的数据源是不更改过.
        /// </summary>
        /// <param name="bds">BindingSource数据源</param>
        /// <returns>更改过返回true，否则返回false</returns>
        public bool IsBdsUpdate(BindingSource bds)
        {
            bool blResult = false;

            bds.EndEdit();
            DataTable dtb = (DataTable)bds.DataSource;  //从BindingSource组件中取得信息集放到DataTable中去.

            DataTable dtbModified = dtb.GetChanges(DataRowState.Modified);
            if (dtbModified != null && dtbModified.Rows.Count > 0)
            {
                blResult = true;
            }

            return blResult;
        }

        /// <summary>
        /// 取消指定的DataGridView组件的各个列的排序功能.
        /// </summary>
        /// <param name="dgv">要取消列排序功能的DataGridView组件</param>
        public void SetDataGridViewNoSort(DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        /// <summary>
        /// 设置窗体中的TableLayoutPanel容器中的控件可用或者不可用。.
        /// 本函数主要用于当界面无数据时Form容器中的控件为不可用。.
        /// </summary>
        /// <param name="tbLayPanel">TableLayoutPanel容器</param>
        /// <param name="blEnable">控件可用，则为true；否则为false</param>
        public void EnableOrDisableCtrls(TableLayoutPanel tbLayPanel, bool blEnable)
        {
            foreach (Control control in tbLayPanel.Controls)
            {
                if (control is TextBox)
                {
                    TextBox curTxt = (TextBox)control;
                    if (curTxt.ReadOnly == false)
                    {
                        curTxt.Enabled = blEnable;
                    }
                }
                else
                {
                    control.Enabled = blEnable;
                }

                /*
                if (control is TextBox)
                {
                    TextBox curTxt = (TextBox)control;
                    if (curTxt.ReadOnly == false)
                    {
                        curTxt.Enabled = blEnable;
                    }
                }
                if (control is ComboBox)
                {
                    ComboBox curCbo = (ComboBox)control;
                    curCbo.Enabled = blEnable;
                }
                if (control is DateTimePicker)
                {
                    DateTimePicker curDtPicker = (DateTimePicker)control;
                    curDtPicker.Enabled = blEnable;
                }
                if (control is CheckBox)
                {
                    CheckBox curDChk = (CheckBox)control;
                    curDChk.Enabled = blEnable;
                }
                if (control is MaskedTextBox)
                {
                    MaskedTextBox curMask = (MaskedTextBox)control;
                    curMask.Enabled = blEnable;
                }
                if (control is Button)
                {
                    Button curBtn = (Button)control;
                    curBtn.Enabled = blEnable;
                }
                if (control is BasicData.UcCboShip)
                {
                    BasicData.UcCboShip curUcCboShip = (BasicData.UcCboShip)control;
                    curUcCboShip.Enabled = blEnable;
                }
                if (control is CommonViewer.DateTimePickerEx)
                {
                    CommonViewer.DateTimePickerEx ucDtp = (CommonViewer.DateTimePickerEx)control;
                    ucDtp.Enabled = blEnable;
                }
                if (control is GroupBox)
                {
                    GroupBox curGrpBox = (GroupBox)control;
                    curGrpBox.Enabled = blEnable;
                }
                if (control is FlowLayoutPanel)
                {
                    FlowLayoutPanel curflowLyout = (FlowLayoutPanel)control;
                    curflowLyout.Enabled = blEnable;
                }*/
            }
        }

        /// <summary>
        /// 在文本框中过滤可能存在的单引号.
        /// </summary>
        /// <param name="toBeExchanged">要过程的文本框的内容</param>
        /// <returns></returns>
        public string VarcharExchangeOfOracle(string toBeExchanged)
        {
            string beExchanged;
            beExchanged = toBeExchanged.Replace("'", "''");
            return beExchanged;
        }

        /// <summary>
        /// 判断数据库操作错误是否是由违返完整性约束引起的。.
        /// Oracle驱动程序引起的错误号：-2146232008；.
        /// SQL Server驱动程序引起的错误号：-2146232060；.
        /// OleDb驱动程序引起的错误号：-2147217873。.
        /// </summary>
        /// <param name="sErrMessage">错误信息</param>
        /// <returns>是返回true，否则返回false</returns>
        public bool IsAgainstReference(string sErrMessage)
        {
            bool blnResult = false;
            if (sErrMessage.StartsWith("(-2146232008)")
                || sErrMessage.StartsWith("(-2146232060)")
                || sErrMessage.StartsWith("(-2147217873)"))
            {
                blnResult = true;
            }
            return blnResult;
        }

        /// <summary>
        /// 用于判断明细网格当前操作的行是添加操作还是修改操作。判断的原理是：.
        /// 当前行的主键值sId在指定的数据表sTableName中是否已存在，如果存在，说明.
        /// 当前是修改操作，否则就是添加操作。.
        /// </summary>
        /// <param name="sId">主键值</param>
        /// <param name="sTableName">表名</param>
        /// <returns>添加操作返回true，修改操作返回false</returns>
        public bool IsDetailAddOpt(string sId, string sIdName, string sTableName)
        {
            //变量定义部分.
            DataTable dtb;//定义一个DataTable对象.
            string err = "";     //错误信息返回参数.
            string sSql = "";               //查询数据所需的SQL语句.
            bool blnResult = true;          //返回值.

            sSql = "select " + sIdName + " from " + sTableName;
            sSql += " where " + sIdName + " = '" + sId + "'";
            dtb = dbAccess.GetDataTable(sSql, out err);

            //如果主键值sId在指定的数据表sTableName中存在，则说明当前是修改操作.
            if (dtb.Rows.Count > 0)
            {
                blnResult = false;
            }

            return blnResult;
        }
    }
}