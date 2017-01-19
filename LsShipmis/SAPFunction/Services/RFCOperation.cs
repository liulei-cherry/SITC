using System;
using System.Collections.Generic;
using System.Text;
using SAPFunction.DataObject;
using System.Data;
using VbSapRFCCall;
namespace SAPFunction.Services
{
    internal partial class RFCOperation
    {
        #region 单实例
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static RFCOperation instance = new RFCOperation();
        public static RFCOperation Instance
        {
            get
            {
                if (null == instance)
                {
                    RFCOperation.instance = new RFCOperation();
                }
                return RFCOperation.instance;
            }
        }
        private RFCOperation()
        {
            //仅提供private构造.

        }
        #endregion
        //SAPLogonCtrl.Connection conn = null;

        Functions sapFunctions = null;
        /// <summary>
        /// 初始化sap连接,VB 
        /// </summary>
        /// <returns></returns>
        private bool InitializeSapConnectionVB(out string err)
        {
            try
            {
                err = "";
                if (!CommonOperation.ConstParameter.ArgumentSetCollection.ContainsKey("SapLoginInfo"))
                    return false;
                string sapLoginInfo = CommonOperation.ConstParameter.ArgumentSetCollection["SapLoginInfo"];
                string[] splitStrings = sapLoginInfo.Split('&');
                if (splitStrings.Length < 7)
                {
                    err = "无法准确获取参数,可能是未配置SAP连接串SapLoginInfo";
                    return false;
                }
                string ApplicationServer = splitStrings[0];//服务器IP
                string Client = splitStrings[1]; //用户端.

                string User = splitStrings[2];//帐号.
                string Password = splitStrings[3];//密码.
                string System = splitStrings[4];//Syetem ID
                int SystemNumber = Convert.ToInt32(splitStrings[5]);//Instance No
                string Language = splitStrings[6];//语言编码.
                sapFunctions = new Functions(System, ApplicationServer, Client, SystemNumber.ToString());//传入SAP配置参数.
                if (!sapFunctions.ConnectToSAP(User, Password, Language))//登录SAP
                {
                    err = "登录sap失败";
                    return false;
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
            return true;
        }
        /// <summary>
        /// 导入报文头数据.
        /// </summary>
        /// <param name="ifunc"></param>
        /// <param name="mh"></param>
        private void setHeaderStructVB(SAPFunctionsOCX.IStructure headerStruct, MessageHeader mh)
        {
            headerStruct.set_Value("SY_SOURCE", mh.SY_SOURCE);
            headerStruct.set_Value("INT_ID", mh.INT_ID);
            headerStruct.set_Value("PKG_UUID", mh.PACKET_ID);
            headerStruct.set_Value("COMP_CODE", mh.COMPANY_CODE);
            headerStruct.set_Value("GEN_TIME", mh.PRODUCE.ToString());
            headerStruct.set_Value("TOTALROW", mh.QUANTITY);
            headerStruct.set_Value("BUS_DATE", mh.OCCUR.ToString());
            headerStruct.set_Value("PST_DATE", mh.ACCOUNT.ToString());
        }
        /// <summary>
        /// 接口一:发送报文.
        /// </summary>
        /// <param name="mh"></param>
        /// <param name="dt"></param>
        /// <param name="errorContent"></param>
        /// <param name="isValid"></param>
        /// <returns></returns>
        public bool SendMessageVB(MessageHeader mh, DataTable dt, out string errorContent, out bool isValid)
        {
            isValid = false;
            string err;
            errorContent = "";
            try
            {
                if (!InitializeSapConnectionVB(out errorContent))
                    return false;
                if (mh.MESSAGE_TYPE == "1")
                {
                    sapFunctions.SetFuncName("ZP01_BAPI_UPLOAD_PKG_JMM001");//执行的RFC名称.
                    SAPFunctionsOCX.IStructure funcStructure = sapFunctions.GetInputIStructureParam("IS_HEADER");
                    setHeaderStructVB(funcStructure, mh);
                    string str = "ROW_ID,MATERIEL_ID,QUANTITY,CURRENCY,AMOUNT,CST_ACCT,VSL_CDE,CLIO_FLG,VENDOR_ID,WARELST_ID,WARELST_ROWID,BUS_UUID";
                    DataTable newTable = sapFunctions.CreateTable(str);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow newRow = newTable.NewRow();
                        newRow["ROW_ID"] = dt.Rows[i]["LINENUM"].ToString();
                        newRow["MATERIEL_ID"] = dt.Rows[i]["MATERIAL_MAPPING"].ToString();
                        newRow["QUANTITY"] = dt.Rows[i]["QUANTITY"].ToString();
                        newRow["CURRENCY"] = dt.Rows[i]["CURRENCY"].ToString();
                        newRow["AMOUNT"] = dt.Rows[i]["AMOUNT"].ToString();
                        newRow["CST_ACCT"] = dt.Rows[i]["SUBJECT_MAPPING"].ToString();
                        newRow["VSL_CDE"] = dt.Rows[i]["SHIP_MAPPING"].ToString();
                        newRow["CLIO_FLG"] = dt.Rows[i]["INPUT_OUTPUT"].ToString();
                        newRow["VENDOR_ID"] = dt.Rows[i]["SUPPLIER_MAPPING"].ToString();
                        newRow["WARELST_ID"] = dt.Rows[i]["INPUT_ORDER"].ToString();
                        newRow["WARELST_ROWID"] = dt.Rows[i]["INPUT_OREER_ITEM"].ToString();
                        if (mh.PACKET_ID.Contains("-X"))
                            newRow["BUS_UUID"] = dt.Rows[i]["UUID"].ToString();
                        else
                            newRow["BUS_UUID"] = dt.Rows[i]["PURCHASE_MESSAGE_ID"].ToString();
                        newTable.Rows.Add(newRow);
                    }
                    sapFunctions.SetInPutTable("IT_ITEMS", newTable);//传入表.
                }
                else if (mh.MESSAGE_TYPE == "2")
                {
                    sapFunctions.SetFuncName("ZP01_BAPI_UPLOAD_PKG_JMM002");//执行的RFC名称.
                    SAPFunctionsOCX.IStructure funcStructure = sapFunctions.GetInputIStructureParam("IS_HEADER");
                    setHeaderStructVB(funcStructure, mh);
                    string str = "ROW_ID,VENDOR_ID,CURRENCY,AMOUNT,CST_ACCT,FRE_TYPE,INODR_CDE,VSL_CDE,BUS_UUID,TEXT";
                    DataTable newTable = sapFunctions.CreateTable(str);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow newRow = newTable.NewRow();
                        newRow["ROW_ID"] = dt.Rows[i]["LINENUM"].ToString();
                        newRow["VENDOR_ID"] = dt.Rows[i]["SUPPLIER_MAPPING"].ToString();
                        newRow["CURRENCY"] = dt.Rows[i]["CURRENCY"].ToString();
                        newRow["AMOUNT"] = dt.Rows[i]["AMOUNT"].ToString();
                        newRow["CST_ACCT"] = dt.Rows[i]["SUBJECT_MAPPING"].ToString();
                        newRow["FRE_TYPE"] = dt.Rows[i]["COST_TYPE"].ToString();
                        newRow["INODR_CDE"] = dt.Rows[i]["INNER_ORDER"].ToString();
                        newRow["VSL_CDE"] = dt.Rows[i]["SHIP_MAPPING"].ToString();
                        if (mh.PACKET_ID.Contains("-X"))
                            newRow["BUS_UUID"] = dt.Rows[i]["UUID"].ToString();
                        else
                            newRow["BUS_UUID"] = dt.Rows[i]["COST_MESSAGE_ID"].ToString();
                        newRow["TEXT"] = dt.Rows[i]["REMARK"].ToString();
                        newTable.Rows.Add(newRow);
                    }
                    sapFunctions.SetInPutTable("IT_ITEMS", newTable);//传入表.
                }
                else if (mh.MESSAGE_TYPE == "3")
                {
                    sapFunctions.SetFuncName("ZP01_BAPI_UPLOAD_PKG_JMM003");//执行的RFC名称.
                    SAPFunctionsOCX.IStructure funcStructure = sapFunctions.GetInputIStructureParam("IS_HEADER");
                    setHeaderStructVB(funcStructure, mh);
                    string str = "ROW_ID,MATERIEL_ID,QUANTITY,VSL_CDE,BUS_CODE,BUS_UUID";
                    DataTable newTable = sapFunctions.CreateTable(str);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow newRow = newTable.NewRow();
                        newRow["ROW_ID"] = dt.Rows[i]["LINENUM"].ToString();
                        newRow["MATERIEL_ID"] = dt.Rows[i]["MATERIAL_MAPPING"].ToString();
                        newRow["QUANTITY"] = dt.Rows[i]["QUANTITY"].ToString();
                        newRow["VSL_CDE"] = dt.Rows[i]["SHIP_MAPPING"].ToString();
                        newRow["BUS_CODE"] = "SLO";
                        if (mh.PACKET_ID.Contains("-X"))
                            newRow["BUS_UUID"] = dt.Rows[i]["UUID"].ToString();
                        else
                            newRow["BUS_UUID"] = dt.Rows[i]["OUTBOUND_MESSAGE_ID"].ToString();
                        newTable.Rows.Add(newRow);
                    }
                    sapFunctions.SetInPutTable("IT_ITEMS", newTable);//传入表.
                }
                else if (mh.MESSAGE_TYPE == "4")
                {
                    sapFunctions.SetFuncName("ZP01_BAPI_UPLOAD_PKG_JMM003");//执行的RFC名称.
                    SAPFunctionsOCX.IStructure funcStructure = sapFunctions.GetInputIStructureParam("IS_HEADER");
                    setHeaderStructVB(funcStructure, mh);
                    string str = "ROW_ID,MATERIEL_ID,QUANTITY,VSL_CDE,BUS_CODE,BUS_UUID";
                    DataTable newTable = sapFunctions.CreateTable(str);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow newRow = newTable.NewRow();
                        newRow["ROW_ID"] = dt.Rows[i]["LINENUM"].ToString();
                        newRow["MATERIEL_ID"] = dt.Rows[i]["MATERIAL_MAPPING"].ToString();
                        if (Convert.ToDecimal(dt.Rows[i]["QUANTITY"]) < 0)
                        {
                            newRow["QUANTITY"] = (-Convert.ToDecimal(dt.Rows[i]["QUANTITY"])).ToString();
                            newRow["BUS_CODE"] = "STO";
                        }
                        else
                        {
                            newRow["QUANTITY"] = dt.Rows[i]["QUANTITY"].ToString();
                            newRow["BUS_CODE"] = "STI";
                        }
                        newRow["VSL_CDE"] = dt.Rows[i]["SHIP_MAPPING"].ToString();
                        if (mh.PACKET_ID.Contains("-X"))
                            newRow["BUS_UUID"] = dt.Rows[i]["UUID"].ToString();
                        else
                            newRow["BUS_UUID"] = dt.Rows[i]["INVEN_MESSAGE_ID"].ToString();
                        newTable.Rows.Add(newRow);
                    }
                    sapFunctions.SetInPutTable("IT_ITEMS", newTable);//传入表.
                }
                sapFunctions.ExecFun();//执行这个RFC   
                string fields = "PACKG_UUID,ROW_ID,MSG_STR,MSG_TYPE,MSG_REF1,BUS_UUID";
                if (sapFunctions.GetOutPutParam("E_FLAG") == "E")
                {
                    DataTable outPutTable = sapFunctions.GetOutPutTable(fields, "IT_ERR_MSG", true);//返回的Table        
                    foreach (DataRow item in outPutTable.Rows)
                    {
                        errorContent += item[2].ToString() + "\r\n";
                    }
                }
                else
                {
                    isValid = true;
                }
                return true;
            }
            catch (Exception e)
            {
                errorContent = e.Message;
                return false;
            }
            finally
            {
                if (sapFunctions != null)
                    sapFunctions.DisConnectSAP();
            }
        }
        /// <summary>
        /// 接口二:Mapping有效性校验.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="type">type: 1=物料代码映射; 2=内部订单映射; 3=供应商映射; 4=费用映射; 5=船舶映射; </param>
        /// <returns></returns>
        public bool CheckIsValidVB(string code, int type, out bool isValid)
        {
            isValid = false;
            string err;
            try
            {
                if (!InitializeSapConnectionVB(out err))
                    return false;
                if (type == 1)
                {
                    sapFunctions.SetFuncName("ZP01_CHECK_MATERIEL_EXIST");//执行的RFC名称.
                    sapFunctions.SetParamName("I_MATNR", code);
                }
                else if (type == 2)
                {
                    sapFunctions.SetFuncName("ZP01_CHECK_INT_ORDER_EXIST");//执行的RFC名称.
                    sapFunctions.SetParamName("I_AUFNR", code);
                }
                else if (type == 3)
                {
                    sapFunctions.SetFuncName("ZP01_CHECK_VENDOR_EXIST");//执行的RFC名称.
                    sapFunctions.SetParamName("I_LIFNR", code);
                }
                else if (type == 4)
                {
                    sapFunctions.SetFuncName("ZP01_CHECK_ACCOUNT_EXIST");//执行的RFC名称.
                    sapFunctions.SetParamName("I_SAKNR", code);
                }
                else if (type == 5)
                {
                    sapFunctions.SetFuncName("ZP01_CHECK_COMPCDE_EXIST");//执行的RFC名称.
                    sapFunctions.SetParamName("I_BUKRS", code);
                }
                sapFunctions.ExecFun();//执行这个RFC   
                if (sapFunctions.GetOutPutParam("E_FLAG") == "S")
                    isValid = true;
                return true;
            }
            catch (Exception e)
            {
                err = e.Message;
                return false;
            }
            finally
            {
                if (sapFunctions != null)
                    sapFunctions.DisConnectSAP();
            }
        }
        /// <summary>
        /// 接口三:库存清单.
        /// </summary>
        public bool GetInventoryVB(string bukrs, out DataTable dt, out bool isValid, out string err)
        {
            isValid = false;
            dt = null;
            try
            {
                if (!InitializeSapConnectionVB(out err))
                    return false;
                sapFunctions.SetFuncName("ZP01_GET_STORAGE_LIST");//执行的RFC名称.
                sapFunctions.SetParamName("I_BUKRS", bukrs);
                sapFunctions.ExecFun();//执行这个RFC   
                if (sapFunctions.GetOutPutParam("E_FLAG") == "S")
                {
                    isValid = true;
                    string fields = "MATNR,LABST,MEINS";
                    dt = sapFunctions.GetOutPutTable(fields, "IT_ITEM", true);//返回的Table        
                }
                return true;
            }
            catch (Exception e)
            {
                err = e.Message;
                return false;
            }
            finally
            {
                if (sapFunctions != null)
                    sapFunctions.DisConnectSAP();
            }
        }

        #region C#方式连接调用sap
        ///// <summary>
        ///// 初始化sap连接.
        ///// </summary>
        ///// <returns></returns>
        //private bool InitializeSapConnection(out string err)
        //{
        //    err = "";
        //    if (conn == null || conn.IsConnected != SAPLogonCtrl.CRfcConnectionStatus.tloRfcConnected)
        //    {
        //        string sapLoginInfo = CommonOperation.ConstParameter.ArgumentSetCollection["SapLoginInfo"];
        //        SAPLogonCtrl.SAPLogonControlClass login = new SAPLogonCtrl.SAPLogonControlClass();
        //        login.ApplicationServer = sapLoginInfo.Split('&')[0];//服务器IP
        //        login.Client = sapLoginInfo.Split('&')[1]; //用户端.

        //        login.User = sapLoginInfo.Split('&')[2];//帐号.
        //        login.Password = sapLoginInfo.Split('&')[3];//密码.
        //        login.System = sapLoginInfo.Split('&')[4];//Syetem ID
        //        login.SystemNumber = Convert.ToInt32(sapLoginInfo.Split('&')[5]);//Instance No
        //        login.Language = sapLoginInfo.Split('&')[6];//语言编码.
        //        conn = (SAPLogonCtrl.Connection)login.NewConnection();
        //        if (!conn.Logon(0, true))
        //        {
        //            err = "SAP登录失败";
        //            return false;
        //        }
        //    }
        //    return true;
        //}
        ///// <summary>
        ///// 导入报文头数据.
        ///// </summary>
        ///// <param name="ifunc"></param>
        ///// <param name="mh"></param>
        //private void ImportHead(SAPFunctionsOCX.IFunction ifunc, MessageHeader mh)
        //{
        //    SAPFunctionsOCX.IStructure headerStruct = (SAPFunctionsOCX.IStructure)ifunc.get_Exports("IS_HEADER");  //Get the import paremeter
        //    headerStruct.set_Value("SY_SOURCE", mh.SY_SOURCE);
        //    headerStruct.set_Value("INT_ID", mh.INT_ID);
        //    headerStruct.set_Value("PKG_UUID", mh.PACKET_ID);
        //    headerStruct.set_Value("COMP_CODE", mh.COMPANY_CODE);
        //    headerStruct.set_Value("GEN_TIME", mh.PRODUCE.ToString());
        //    headerStruct.set_Value("TOTALROW", mh.QUANTITY);
        //    headerStruct.set_Value("BUS_DATE", mh.OCCUR.ToString());
        //    headerStruct.set_Value("PST_DATE", mh.ACCOUNT.ToString());
        //}
        ///// <summary>
        ///// 接口一:发送报文.
        ///// </summary>
        ///// <param name="mh">报文头</param>
        ///// <param name="dt">报文详细</param>
        ///// <param name="errorContent">rfc的返回错误</param>
        ///// <param name="err">程序的返回错误</param>
        ///// <returns></returns>
        //public bool SendMessage(MessageHeader mh, DataTable dt, out string errorContent, out bool isValid)
        //{
        //    isValid = false;
        //    string err;
        //    errorContent = "";
        //    if (!InitializeSapConnection(out err))
        //        return false;
        //    SAPFunctionsOCX.SAPFunctionsClass func = new SAPFunctionsOCX.SAPFunctionsClass();
        //    func.Connection = conn;
        //    SAPFunctionsOCX.IFunction ifunc = null;
        //    if (mh.MESSAGE_TYPE == "1")
        //    {
        //        ifunc = (SAPFunctionsOCX.IFunction)func.Add("ZP01_BAPI_UPLOAD_PKG_JMM001");
        //        ImportHead(ifunc, mh);
        //        SAPTableFactoryCtrl.Tables tbs = (SAPTableFactoryCtrl.Tables)ifunc.Tables;
        //        SAPTableFactoryCtrl.Table tb = (SAPTableFactoryCtrl.Table)tbs.get_Item("IT_ITEMS");
        //        //for (int i = 0; i < dt.Rows.Count; i++)
        //        //{
        //        //    DataTable newTable = sapFunctions.CreateTable(str);

        //        //    for (int i = 0; i < dt.Rows.Count; i++)
        //        //    {
        //        //        DataRow newRow = newTable.NewRow();
        //        //        newRow["ROW_ID"] = dt.Rows[i]["LINENUM"].ToString();
        //        //        newRow["MATERIEL_ID"] = dt.Rows[i]["MATERIAL_MAPPING"].ToString();
        //        //        newRow["QUANTITY"] = dt.Rows[i]["QUANTITY"].ToString();
        //        //        newRow["UNIT"] = "1";
        //        //        newRow["CURRENCY"] = dt.Rows[i]["CURRENCY"].ToString();
        //        //        newRow["AMOUNT"] = dt.Rows[i]["AMOUNT"].ToString();
        //        //        newRow["CST_ACCT"] = dt.Rows[i]["SUBJECT_MAPPING"].ToString();
        //        //        newRow["VSL_CDE"] = dt.Rows[i]["SHIP_MAPPING"].ToString();
        //        //        newRow["CLIO_FLG"] = dt.Rows[i]["INPUT_OUTPUT"].ToString();
        //        //        newRow["VENDOR_ID"] = dt.Rows[i]["SUPPLIER_MAPPING"].ToString();
        //        //        newRow["WARELST_ID"] = dt.Rows[i]["INPUT_ORDER"].ToString();
        //        //        newRow["WARELST_ROWID"] = dt.Rows[i]["INPUT_OREER_ITEM"].ToString();
        //        //        newRow["BUS_UUID"] = dt.Rows[i]["UUID"].ToString();
        //        //        newTable.Rows.Add(newRow);
        //        //    }
        //        //    VbSapRFCCall.IFunctions.SetInPutTable(ifunc, "IT_ITEMS", newTable);//传入表.

        //        //}
        //        // SAPTableFactoryCtrl.Column one = (SAPTableFactoryCtrl.Column)((SAPTableFactoryCtrl.Columns)tb.Columns).get_Item("ROW_ID");
        //        //tr.set_Value(1, 1);
        //        //tr.set_Value(2, "1");
        //        //tr.set_Value("MATERIEL_ID", dt.Rows[i]["MATERIAL_MAPPING"].ToString());
        //        //tr.set_Value("QUANTITY", dt.Rows[i]["QUANTITY"].ToString());
        //        //tr.set_Value("UNIT", 1);
        //        //tr.set_Value("CURRENCY", dt.Rows[i]["CURRENCY"].ToString());
        //        //tr.set_Value("CST_ACCT", dt.Rows[i]["AMOUNT"].ToString());
        //        //SAPTableFactoryCtrl.Row dr = ((SAPTableFactoryCtrl.Row)((SAPTableFactoryCtrl.Rows)tb.Rows).get_Item(1));
        //        //dr[4] = 200;
        //        //string[] sl = new string[3] {"uuu","yy","tt" };
        //        //((object[,])(tb.Data)).SetValue(sl, 5);
        //        //vbRfcOperation.SetupSAPTable((SAPTableFactoryCtrl.Table)tb, Convert.ToInt16(i), "ROW_ID", dt.Rows[i]["LINENUM"].ToString ());
        //        //vbRfcOperation.SetupSAPTable((SAPTableFactoryCtrl.Table)tb, Convert.ToInt16(i), "MATERIEL_ID", dt.Rows[i]["MATERIAL_MAPPING"].ToString());
        //        //vbRfcOperation.SetupSAPTable((SAPTableFactoryCtrl.Table)tb, Convert.ToInt16(i), "QUANTITY", dt.Rows[i]["QUANTITY"].ToString());
        //        //vbRfcOperation.SetupSAPTable((SAPTableFactoryCtrl.Table)tb, Convert.ToInt16(i), "UNIT", "1");
        //        //vbRfcOperation.SetupSAPTable((SAPTableFactoryCtrl.Table)tb, Convert.ToInt16(i), "CURRENCY", dt.Rows[i]["CURRENCY"].ToString());
        //        //vbRfcOperation.SetupSAPTable((SAPTableFactoryCtrl.Table)tb, Convert.ToInt16(i), "AMOUNT", dt.Rows[i]["AMOUNT"].ToString ());
        //        //vbRfcOperation.SetupSAPTable((SAPTableFactoryCtrl.Table)tb, Convert.ToInt16(i), "CST_ACCT", dt.Rows[i]["SUBJECT_MAPPING"].ToString());
        //        //vbRfcOperation.SetupSAPTable((SAPTableFactoryCtrl.Table)tb, Convert.ToInt16(i), "VSL_CDE", dt.Rows[i]["SHIP_MAPPING"].ToString());
        //        //vbRfcOperation.SetupSAPTable((SAPTableFactoryCtrl.Table)tb, Convert.ToInt16(i), "CLIO_FLG", dt.Rows[i]["INPUT_OUTPUT"].ToString());
        //        //vbRfcOperation.SetupSAPTable((SAPTableFactoryCtrl.Table)tb, Convert.ToInt16(i), "VENDOR_ID", dt.Rows[i]["SUPPLIER_MAPPING"].ToString());
        //        //vbRfcOperation.SetupSAPTable((SAPTableFactoryCtrl.Table)tb, Convert.ToInt16(i), "WARELST_ID", dt.Rows[i]["INPUT_ORDER"].ToString());
        //        //vbRfcOperation.SetupSAPTable((SAPTableFactoryCtrl.Table)tb, Convert.ToInt16(i), "WARELST_ROWID", dt.Rows[i]["INPUT_OREER_ITEM"].ToString());
        //        //vbRfcOperation.SetupSAPTable((SAPTableFactoryCtrl.Table)tb, Convert.ToInt16(i), "BUS_UUID", dt.Rows[i]["UUID"].ToString());

        //        //SAPTableFactoryCtrl.Row ss = (SAPTableFactoryCtrl.Row)tb.AppendRow();
        //        //((SAPTableFactoryCtrl.Rows)tb.Rows).Add(ss);

        //        //tb.AppendGridData(1, 10, 4, 44);
        //        //tb.AppendGridData(1, 1, 5, "255");
        //        //tb.AppendGridData( 5, 1, i+1, dt.Rows[i]["MATERIAL_MAPPING"].ToString());
        //        //tb.AppendGridData( 6, 1, i+1, Convert.ToInt32(dt.Rows[i]["QUANTITY"]));
        //        //tb.AppendGridData( 7, 1, i+1, 1);
        //        //tb.AppendGridData( 8, 1, i+1, dt.Rows[i]["CURRENCY"].ToString());
        //        //tb.AppendGridData( 9, 1, i+1, Convert.ToInt32(dt.Rows[i]["AMOUNT"]));
        //        //tb.AppendGridData( 10, 1, i+1, dt.Rows[i]["SUBJECT_MAPPING"].ToString());
        //        //tb.AppendGridData( 11, 1, i+1, dt.Rows[i]["SHIP_MAPPING"].ToString());
        //        //tb.AppendGridData( 12, 1, i+1, dt.Rows[i]["INPUT_OUTPUT"].ToString());
        //        //tb.AppendGridData( 13, 1, i+1, dt.Rows[i]["SUPPLIER_MAPPING"].ToString());
        //        //tb.AppendGridData( 14, 1, i+1, dt.Rows[i]["INPUT_ORDER"].ToString());
        //        //tb.AppendGridData( 15, 1, i+1, dt.Rows[i]["INPUT_OREER_ITEM"].ToString());
        //        //tb.AppendGridData( 16, 1, i+1, dt.Rows[i]["UUID"].ToString());

        //    }
        //    else if (mh.MESSAGE_TYPE == "2")
        //    {
        //        ifunc = (SAPFunctionsOCX.IFunction)func.Add("ZP01_BAPI_UPLOAD_PKG_JMM002");
        //        ImportHead(ifunc, mh);
        //        SAPTableFactoryCtrl.Tables tbs = (SAPTableFactoryCtrl.Tables)ifunc.Tables;
        //        SAPTableFactoryCtrl.Table tb = (SAPTableFactoryCtrl.Table)tbs.get_Item("IT_ITEMS");
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            tb.AppendGridData(i + 1, 4, 1, Convert.ToInt32(dt.Rows[i]["LINENUM"]));
        //            tb.AppendGridData(i + 1, 5, 1, dt.Rows[i]["SUPPLIER_MAPPING"].ToString());
        //            tb.AppendGridData(i + 1, 6, 1, dt.Rows[i]["CURRENCY"].ToString());
        //            tb.AppendGridData(i + 1, 7, 1, Convert.ToInt32(dt.Rows[i]["AMOUNT"]));
        //            tb.AppendGridData(i + 1, 8, 1, dt.Rows[i]["SUBJECT_MAPPING"].ToString());
        //            tb.AppendGridData(i + 1, 9, 1, dt.Rows[i]["COST_TYPE"].ToString());
        //            tb.AppendGridData(i + 1, 10, 1, dt.Rows[i]["INPUT_OUTPUT"].ToString());
        //            tb.AppendGridData(i + 1, 11, 1, dt.Rows[i]["SHIP_MAPPING"].ToString());
        //            tb.AppendGridData(i + 1, 12, 1, dt.Rows[i]["UUID"].ToString());
        //        }
        //    }
        //    else if (mh.MESSAGE_TYPE == "3")
        //    {
        //        ifunc = (SAPFunctionsOCX.IFunction)func.Add("ZP01_BAPI_UPLOAD_PKG_JMM003");
        //        ImportHead(ifunc, mh);
        //        SAPTableFactoryCtrl.Tables tbs = (SAPTableFactoryCtrl.Tables)ifunc.Tables;
        //        SAPTableFactoryCtrl.Table tb = (SAPTableFactoryCtrl.Table)tbs.get_Item("IT_ITEMS");
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            tb.AppendGridData(i + 1, 4, 1, Convert.ToInt32(dt.Rows[i]["LINENUM"]));
        //            tb.AppendGridData(i + 1, 5, 1, dt.Rows[i]["MATERIAL_MAPPING"].ToString());
        //            tb.AppendGridData(i + 1, 6, 1, Convert.ToInt32(dt.Rows[i]["QUANTITY"]));
        //            tb.AppendGridData(i + 1, 7, 1, 1);
        //            tb.AppendGridData(i + 1, 8, 1, dt.Rows[i]["SHIP_MAPPING"].ToString());
        //            tb.AppendGridData(i + 1, 9, 1, dt.Rows[i]["INPUT_OUTPUT"].ToString());
        //            tb.AppendGridData(i + 1, 10, 1, dt.Rows[i]["UUID"].ToString());
        //        }
        //    }
        //    if (ifunc.Call())
        //    {
        //        SAPFunctionsOCX.IParameter flag = (SAPFunctionsOCX.IParameter)ifunc.get_Imports("E_FLAG");
        //        if (flag.Value.ToString() == "E")
        //        {
        //            SAPTableFactoryCtrl.Tables tbs = (SAPTableFactoryCtrl.Tables)ifunc.Tables;
        //            SAPTableFactoryCtrl.Table tb = (SAPTableFactoryCtrl.Table)tbs.get_Item("IT_ERR_MSG");
        //            errorContent = tb.get_Cell(1, 3).ToString();
        //        }
        //        else
        //        {
        //            isValid = true;
        //        }
        //    }
        //    else
        //    {
        //        errorContent = "SAP方法调用失败";
        //        return false;
        //    }
        //    return true;
        //}

        ///// <summary>
        ///// 接口二:Mapping有效性校验.
        ///// </summary>
        ///// <param name="code"></param>
        ///// <param name="type">type: 1=物料代码映射; 2=内部订单映射; 3=供应商映射; 4=费用映射; 5=船舶映射; </param>
        ///// <returns></returns>
        //public bool CheckIsValid(string code, int type, out bool isValid)
        //{
        //    isValid = true;
        //    isValid = false;
        //    string err;
        //    if (!InitializeSapConnection(out err))
        //        return false;
        //    SAPFunctionsOCX.SAPFunctionsClass func = new SAPFunctionsOCX.SAPFunctionsClass();
        //    func.Connection = conn;
        //    SAPFunctionsOCX.IFunction ifunc = null;
        //    if (type == 1)
        //    {
        //        ifunc = (SAPFunctionsOCX.IFunction)func.Add("ZP01_CHECK_MATERIEL_EXIST");
        //        SAPFunctionsOCX.IParameter param1 = (SAPFunctionsOCX.IParameter)ifunc.get_Exports("I_MATNR");
        //        param1.Value = code;
        //    }
        //    else if (type == 2)
        //    {
        //        ifunc = (SAPFunctionsOCX.IFunction)func.Add("ZP01_CHECK_INT_ORDER_EXIST");
        //        SAPFunctionsOCX.IParameter param1 = (SAPFunctionsOCX.IParameter)ifunc.get_Exports("I_AUFNR");
        //        param1.Value = code;
        //    }
        //    else if (type == 3)
        //    {
        //        ifunc = (SAPFunctionsOCX.IFunction)func.Add("ZP01_CHECK_VENDOR_EXIST");
        //        SAPFunctionsOCX.IParameter param1 = (SAPFunctionsOCX.IParameter)ifunc.get_Exports("I_LIFNR");
        //        param1.Value = code;
        //    }
        //    else if (type == 4)
        //    {
        //        ifunc = (SAPFunctionsOCX.IFunction)func.Add("ZP01_CHECK_ACCOUNT_EXIST");
        //        SAPFunctionsOCX.IParameter param1 = (SAPFunctionsOCX.IParameter)ifunc.get_Exports("I_SAKNR");
        //        param1.Value = code;
        //    }
        //    else if (type == 5)
        //    {
        //        ifunc = (SAPFunctionsOCX.IFunction)func.Add("ZP01_CHECK_COMPCDE_EXIST");
        //        SAPFunctionsOCX.IParameter param1 = (SAPFunctionsOCX.IParameter)ifunc.get_Exports("I_BUKRS");
        //        param1.Value = code;
        //    }
        //    if (ifunc.Call())
        //    {
        //        SAPFunctionsOCX.IParameter flag = (SAPFunctionsOCX.IParameter)ifunc.get_Imports("E_FLAG");
        //        if (flag.Value.ToString() == "S")
        //            isValid = true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        ///// <summary>
        ///// 接口三:库存清单.
        ///// </summary>
        ///// <param name="shipName"></param>
        ///// <returns></returns>
        //public bool GetInventory(string bukrs, out DataTable dt, out bool isValid)
        //{
        //    isValid = false;
        //    dt = null;
        //    string err;
        //    if (!InitializeSapConnection(out err))
        //        return false;
        //    SAPFunctionsOCX.SAPFunctionsClass func = new SAPFunctionsOCX.SAPFunctionsClass();
        //    func.Connection = conn;
        //    SAPFunctionsOCX.IFunction ifunc = (SAPFunctionsOCX.IFunction)func.Add("ZP01_GET_STORAGE_LIST");
        //    SAPFunctionsOCX.IParameter param1 = (SAPFunctionsOCX.IParameter)ifunc.get_Exports("I_BUKRS");
        //    param1.Value = bukrs;
        //    if (ifunc.Call())
        //    {
        //        SAPFunctionsOCX.IParameter flag = (SAPFunctionsOCX.IParameter)ifunc.get_Imports("E_FLAG");
        //        if (flag.Value.ToString() == "S")
        //        {
        //            isValid = true;
        //            dt = new DataTable();
        //            dt.Columns.Add("MATNR", typeof(string));//物料号.
        //            dt.Columns.Add("LABST", typeof(int));//库存数量.
        //            dt.Columns.Add("MEINS", typeof(string));//数量单位.
        //            SAPTableFactoryCtrl.Tables tbs = (SAPTableFactoryCtrl.Tables)ifunc.Tables;
        //            SAPTableFactoryCtrl.Table tb = (SAPTableFactoryCtrl.Table)tbs.get_Item("IT_ITEMS");
        //            for (int i = 1; i <= tb.RowCount; i++)
        //            {
        //                DataRow dr = dt.NewRow();
        //                dr["MATNR"] = tb.get_Cell(i, 1).ToString();
        //                dr["LABST"] = Convert.ToInt32(tb.get_Cell(i, 2));
        //                dr["MEINS"] = tb.get_Cell(i, 3).ToString();
        //                dt.Rows.Add(dr);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        #endregion
    }
}
