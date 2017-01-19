using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAPFunction.DataObject;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using BaseInfo.Objects;
using BaseInfo.DataAccess;

namespace SAPFunction.Services
{
    public partial class SAPFunctionOperation
    {
        #region 单实例

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static SAPFunctionOperation instance = new SAPFunctionOperation();
        public static SAPFunctionOperation Instance
        {
            get
            {
                if (null == instance)
                {
                    SAPFunctionOperation.instance = new SAPFunctionOperation();
                }
                return SAPFunctionOperation.instance;
            }
        }
        private SAPFunctionOperation()
        {
            //仅提供private构造.

        }
        #endregion
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();
        #region 生成待发送报文

        /// <summary>
        /// 检查数据有效性.
        /// </summary>
        /// <param name="occur"></param>
        /// <param name="account"></param>
        /// <param name="business_code"></param>
        /// <param name="dtb"></param>
        /// <param name="messageType"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool CheckDataValid(string shipID, DateTime occur, DateTime account, string business_code, DataTable dtb,
            string messageType, string businessType, out string err)
        {
            err = "";
            if (occur == DateTime.MinValue)
            {
                err = "业务发生日期不能为空";
                return false;
            }
            if (account == DateTime.MinValue)
            {
                err = "实际记账日期不能为空";
                return false;
            }
            if (string.IsNullOrEmpty(business_code))
            {
                err = "管理系统业务代码不能为空";
                return false;
            }
            if (dtb.Rows.Count == 0)
            {
                err = "业务详细信息不能为空";
                return false;
            }
            if (!"1,2,3,4".Contains(messageType))
            {
                err = "报文类型不正确";
                return false;
            }
            if (!"1,2,3,4".Contains(businessType))
            {
                err = "业务类型不正确";
                return false;
            }
            DataTable dt;
            if (!MessageHeaderService.Instance.GetWantCreateOrReverseInfo(null, business_code, true, out dt, out err))
                return false;
            foreach (DataRow item in dt.Rows)
            {
                if (item["STATUS"].ToString() != "5")
                {
                    err = "该预算存在未同步到SAP系统的冲账报文,请先保证冲账报文已同步到SAP系统";
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// 生成待发送报文,用在出库和盘点接口.
        /// </summary>
        /// <param name="shipID">船舶ID,映射船东时用</param>
        /// <param name="occur">业务发生日期(与实际记账日期相同)</param>
        /// <param name="account">实际记账日期(与业务发生日期相同)</param>
        /// <param name="business_code">对应该报文的业务数据ID,(入库ID,费用ID,出库单ID,盘点ID),冲账时用</param>
        /// <param name="dtb">根据不同类型接口,传入不同格式的DataTable</param>
        /// 采购接口格式:MATERIAL,QUANTITY,CURRENCY,AMOUNT,SHIP_ID,SUPPLIER,INPUT_ORDER,INPUT_OREER_ITEM,UUID,SUBJECT_MAPPING
        /// 费用接口格式:SUPPLIER,CURRENCY,AMOUNT,SUBJECT,COST_TYPE,SHIP_ID,UUID,REMARK,SUBJECT_MAPPING
        /// 领用接口格式:MATERIAL,QUANTITY,SHIP_ID,UUID,MATERIAL_MAPPING_ID,STORAGE_QUANTITY
        /// 盘点接口格式:MATERIAL,QUANTITY,SHIP_ID,UUID,MATERIAL_MAPPING_ID,STORAGE_QUANTITY,materialStock
        /// <param name="messageType">报文接口类型:   1=采购接口(入库); 2=费用接口; 3=领用接口(出库); 4=盘点接口;</param>
        /// <param name="businessType">业务类型: 1=物料; 2=备件; 3=油料; 4=其他;</param>
        /// <param name="err">输出参数,错误消息</param>
        /// <returns></returns>
        public bool CreateMessage(string shipID, DateTime occur, DateTime account, string business_code, DataTable dtb,
            string messageType, string businessType, out string err)
        {
            err = "";
            if (!CheckDataValid(shipID, occur, account, business_code, dtb, messageType, businessType, out err))
                return false;
            MessageHeader mh = new MessageHeader();
            mh.SY_SOURCE = "0003";//机务系统.
            mh.SHIP_ID = shipID;
            ShipInfo ship = ShipInfoService.Instance.getObject(shipID, out err);
            if (!string.IsNullOrEmpty(err))
                return false;
            mh.COMPANY_CODE = ship.SHIP_CODE;
            mh.PRODUCE = Convert.ToDecimal(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            mh.OCCUR = Convert.ToDecimal(occur.ToString("yyyyMMdd"));
            mh.ACCOUNT = Convert.ToDecimal(account.ToString("yyyyMMdd"));
            mh.BUSINESS_CODE = business_code;
            mh.MESSAGE_TYPE = messageType;
            mh.BUSINESS_TYPE = businessType;
            mh.STATUS = "2";
            int linenum = 1;
            if (mh.MESSAGE_TYPE == "3")
            {
                mh.INT_ID = "JMM003";
                List<OutboundMessage> list = new List<OutboundMessage>();
                List<string> sqlList = new List<string>();
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(dtb.Rows[i]["QUANTITY"]) == 0)
                        continue;
                    OutboundMessage message = new OutboundMessage();
                    message.LINENUM = linenum;
                    message.MATERIAL = dtb.Rows[i]["MATERIAL"].ToString();
                    message.MATERIAL_MAPPING = dtb.Rows[i]["MATERIAL_FINANCE"].ToString();
                    message.QUANTITY = Convert.ToDecimal(dtb.Rows[i]["QUANTITY"]);
                    message.SHIP_ID = dtb.Rows[i]["SHIP_ID"].ToString();
                    message.INPUT_OUTPUT = "O";
                    message.UUID = dtb.Rows[i]["UUID"].ToString();
                    list.Add(message);
                    linenum++;
                }
                if (list.Count > 0)
                {
                    mh.PACKET_ID = mh.SY_SOURCE + "-" + mh.COMPANY_CODE + "-" + mh.INT_ID + "-" + mh.PRODUCE;
                    mh.QUANTITY = list.Count;
                    sqlList.AddRange(OutboundMessageService.Instance.GetSaveUnitTransactionSql(mh, list));
                }
                return dbAccess.ExecSql(sqlList, out err);
            }
            else if (mh.MESSAGE_TYPE == "4")
            {
                mh.INT_ID = "JMM003";
                List<InvenMessage> list = new List<InvenMessage>();
                List<string> sqlList = new List<string>();
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    if (Convert.ToDecimal(dtb.Rows[i]["QUANTITY"]) == 0)
                        continue;
                    string materialMappingID = dtb.Rows[i]["MATERIAL_MAPPING_ID"].ToString();
                    decimal STORAGE_QUANTITY = 0;
                    if (!string.IsNullOrEmpty(dtb.Rows[i]["STORAGE_QUANTITY"].ToString()))
                        STORAGE_QUANTITY = Convert.ToDecimal(dtb.Rows[i]["STORAGE_QUANTITY"]);
                    decimal quantity = Convert.ToDecimal(dtb.Rows[i]["QUANTITY"]);//盘盈或盘亏的数量,有正负数.

                    decimal materialStock = Convert.ToDecimal(dtb.Rows[i]["materialStock"]);//物料总库存.
                    if (STORAGE_QUANTITY == materialStock)//库存总数等于映射库存数,就是跟sap没关.
                    {
                        STORAGE_QUANTITY = STORAGE_QUANTITY + quantity;//同步加减库存.
                        sqlList.Add(MaterialMappingService.Instance.GetUpdateStorageQuantitySql(dtb.Rows[i]["SHIP_ID"].ToString(), materialMappingID, STORAGE_QUANTITY));
                        continue;//不走sap
                    }
                    else
                    {
                        if (quantity < 0)//盘亏(盘盈就给sap)
                        {
                            quantity = quantity + STORAGE_QUANTITY;//映射库存-盘亏数(就相当于出库)
                            STORAGE_QUANTITY = quantity <= 0 ? 0 : quantity;//映射库存不够 就变成0
                            sqlList.Add(MaterialMappingService.Instance.GetUpdateStorageQuantitySql(dtb.Rows[i]["SHIP_ID"].ToString(), materialMappingID, STORAGE_QUANTITY));
                            if (quantity >= 0)//映射库存够 就不走sap 否则就算sap盘亏.
                                continue;
                        }
                    }
                    InvenMessage message = new InvenMessage();
                    message.LINENUM = linenum;
                    message.MATERIAL = dtb.Rows[i]["MATERIAL"].ToString();
                    message.QUANTITY = Convert.ToDecimal(dtb.Rows[i]["QUANTITY"]);
                    message.SHIP_ID = dtb.Rows[i]["SHIP_ID"].ToString();
                    message.INPUT_OUTPUT = "";
                    message.UUID = dtb.Rows[i]["UUID"].ToString();
                    list.Add(message);
                    linenum++;
                }
                if (list.Count > 0)
                {
                    mh.PACKET_ID = mh.SY_SOURCE + "-" + mh.COMPANY_CODE + "-" + mh.INT_ID + "-" + mh.PRODUCE;
                    mh.QUANTITY = list.Count;
                    sqlList.AddRange(InvenMessageService.Instance.GetSaveUnitTransactionSql(mh, list));
                }
                return dbAccess.ExecSql(sqlList, out err);

            }
            return true;
        }
        /// <summary>
        /// 返回生成报文的语句,用在采购和费用接口,因为返回语句可以走事务,如果有精力也可以把出库和盘点改成这样.
        /// </summary>
        public bool CreateMessageSql(string shipID, DateTime occur, DateTime account, string business_code, DataTable dtb,
            string messageType, string businessType, List<string> sqlList, out string err)
        {
            err = "";
            if (!CheckDataValid(shipID, occur, account, business_code, dtb, messageType, businessType, out err))
                return false;
            MessageHeader mh = new MessageHeader();
            mh.SY_SOURCE = "0003";//机务系统.
            mh.SHIP_ID = shipID;
            ShipInfo ship = ShipInfoService.Instance.getObject(shipID, out err);
            if (!string.IsNullOrEmpty(err))
                return false;
            mh.COMPANY_CODE = ship.SHIP_CODE;
            mh.PRODUCE = Convert.ToDecimal(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
            mh.OCCUR = Convert.ToDecimal(occur.ToString("yyyyMMdd"));
            mh.ACCOUNT = Convert.ToDecimal(account.ToString("yyyyMMdd"));
            mh.BUSINESS_CODE = business_code;
            mh.MESSAGE_TYPE = messageType;
            mh.BUSINESS_TYPE = businessType;
            mh.STATUS = "2";
            int linenum = 1;
            if (mh.MESSAGE_TYPE == "1")
            {
                mh.INT_ID = "JMM001";
                List<PurchaseMessage> list = new List<PurchaseMessage>();
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(dtb.Rows[i]["MATERIAL"].ToString()) && Convert.ToDecimal(dtb.Rows[i]["QUANTITY"]) == 0)
                        continue;
                    PurchaseMessage message = new PurchaseMessage();
                    message.LINENUM = linenum;
                    message.MATERIAL = dtb.Rows[i]["MATERIAL"].ToString();
                    if (dtb.Columns.Contains("SUBJECT_MAPPING") && dtb.Rows[i]["SUBJECT_MAPPING"] != null)
                        message.SUBJECT_MAPPING = dtb.Rows[i]["SUBJECT_MAPPING"].ToString();
                    message.QUANTITY = Convert.ToDecimal(dtb.Rows[i]["QUANTITY"]);
                    message.CURRENCY = dtb.Rows[i]["CURRENCY"].ToString();
                    message.AMOUNT = Convert.ToDecimal(dtb.Rows[i]["AMOUNT"]);
                    message.SHIP_ID = dtb.Rows[i]["SHIP_ID"].ToString();
                    message.INPUT_OUTPUT = "I";
                    message.SUPPLIER = dtb.Rows[i]["SUPPLIER"].ToString();
                    message.INPUT_ORDER = dtb.Rows[i]["INPUT_ORDER"].ToString();
                    message.INPUT_OREER_ITEM = linenum;
                    message.UUID = dtb.Rows[i]["UUID"].ToString();
                    list.Add(message);
                    linenum++;
                }
                if (list.Count == 0)
                    return true;
                mh.PACKET_ID = mh.SY_SOURCE + "-" + mh.COMPANY_CODE + "-" + mh.INT_ID + "-" + mh.PRODUCE;
                mh.QUANTITY = list.Count;
                PurchaseMessageService.Instance.saveUnitSql(mh, list, sqlList);
            }
            else if (mh.MESSAGE_TYPE == "2")
            {
                mh.INT_ID = "JMM002";
                List<CostMessage> list = new List<CostMessage>();
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    CostMessage message = new CostMessage();
                    message.LINENUM = linenum;
                    message.SUPPLIER = dtb.Rows[i]["SUPPLIER"].ToString();
                    message.CURRENCY = dtb.Rows[i]["CURRENCY"].ToString();
                    message.AMOUNT = Convert.ToDecimal(dtb.Rows[i]["AMOUNT"]);
                    message.SUBJECT = dtb.Rows[i]["SUBJECT"].ToString();
                    message.SUBJECT_MAPPING = dtb.Rows[i]["SUBJECT_MAPPING"].ToString();
                    message.COST_TYPE = dtb.Rows[i]["COST_TYPE"].ToString();
                    message.SHIP_ID = dtb.Rows[i]["SHIP_ID"].ToString();
                    message.UUID = dtb.Rows[i]["UUID"].ToString();
                    message.REMARK = dtb.Rows[i]["REMARK"].ToString();
                    list.Add(message);
                    linenum++;
                }
                if (list.Count == 0)
                    return true;
                mh.PACKET_ID = mh.SY_SOURCE + "-" + mh.COMPANY_CODE + "-" + mh.INT_ID + "-" + mh.PRODUCE;
                mh.QUANTITY = list.Count;
                CostMessageService.Instance.saveUnitSql(mh, list, sqlList);
            }
            return true;
        }
        /// <summary>
        /// 只生成创建采购报文的sql,用在备件,物料,油料的生成凭证功能里,为了能与凭证一起参加审批流程.
        /// </summary>
        /// <param name="dtb"></param>
        /// <returns></returns>
        public List<string> CreatePurchaseMessageSql(DataTable dtb)
        {
            List<string> sqlList = new List<string>();
            foreach (DataRow item in dtb.Rows)
            {
                PurchaseMessage pm = new PurchaseMessage();
                pm.UUID = item["UUID"].ToString();
                pm.MATERIAL = item["MATERIAL"].ToString();
                pm.QUANTITY = Convert.ToDecimal(item["QUANTITY"]);
                pm.SHIP_ID = item["SHIP_ID"].ToString();
                pm.CURRENCY = item["CURRENCY"].ToString();
                pm.AMOUNT = Convert.ToDecimal(item["AMOUNT"]);
                pm.SUPPLIER = item["SUPPLIER"].ToString();
                pm.INPUT_ORDER = item["INPUT_ORDER"].ToString();
                pm.REBATE = Convert.ToDecimal(item["REBATE"]);
                pm.ORDER_AMOUNT = Convert.ToDecimal(item["ORDER_AMOUNT"]);
                pm.ACCOUNT_CODE = item["ACCOUNT_CODE"].ToString();
                pm.ACCOUNT_NAME = item["ACCOUNT_NAME"].ToString();
                pm.BUSINESS_CODE = item["BUSINESS_CODE"].ToString();
                sqlList.Add(PurchaseMessageService.Instance.saveUnit(pm));
            }
            return sqlList;
        }
        #endregion

        #region 冲账
        /*冲账的做法
         * 根据管理系统标识ID和要冲账的类型,取得关联的报文
         * 把需要填负号的项 填上负号
         * 新增进数据库,等待处理和发送
         */
        /// <summary>
        /// 冲账功能.
        /// </summary>
        /// <param name="stateCode">状态码,用来表示冲账是直接删除的报文=0,还是发送sap冲账报文=1</param>
        /// <returns></returns>
        public bool ReverseAccount(string businessCode, List<string> sqlList, out int stateCode, out string err)
        {
            err = "";
            stateCode = 0;
            DataTable dt;
            if (!MessageHeaderService.Instance.GetWantCreateOrReverseInfo(null, businessCode, false, out dt, out err))
                return false;
            if (dt.Rows.Count == 0)
            {
                err = "对应需要冲账的数据不存在";
                return false;
            }
            else
            {
                int finishCount = 0;
                int unfinishCount = 0;
                foreach (DataRow item in dt.Rows)
                {
                    if (item["STATUS"].ToString() != "5")
                        unfinishCount++;
                    else
                        finishCount++;
                }
                if (finishCount > 0 && unfinishCount > 0)
                {
                    err = "同时存在发送完成和未发送完成的SAP报文,请先保证SAP报文全部发送完成才能冲账.(费用和物料一起上报sap情况下)";
                    return false;
                }
                foreach (DataRow item in dt.Rows)
                {
                    MessageHeader mh = MessageHeaderService.Instance.getObject(item);
                    if (item["STATUS"].ToString() != "5")
                    {
                        sqlList.AddRange(MessageHeaderService.Instance.DeleteDetailAndUnit(mh));
                        stateCode = 0;
                    }
                    else
                    {
                        mh.BUSINESS_CODE += "-C";
                        sqlList.Add(mh.Update());
                        stateCode = 1;
                    }
                }
                if (finishCount == 0 && unfinishCount > 0)
                    return true;
            }
            foreach (DataRow itemrow in dt.Rows)
            {
                MessageHeader mh = MessageHeaderService.Instance.getObject(itemrow);
                string mhID = mh.MESSAGE_HEADER_ID;
                mh.MESSAGE_HEADER_ID = null;
                mh.MESSAGE_ERROR = null;
                mh.STATUS = "3";
                mh.PACKET_ID = mh.PACKET_ID.Trim() + "-X";
                if (mh.MESSAGE_TYPE == "1")
                {
                    List<PurchaseMessage> dataList = new List<PurchaseMessage>();
                    DataTable dtb = PurchaseMessageService.Instance.GetInfoByHeaderID(mhID, out err);
                    foreach (DataRow item in dtb.Rows)
                    {
                        PurchaseMessage mess = PurchaseMessageService.Instance.getObject(item);
                        mess.PURCHASE_MESSAGE_ID = null;
                        mess.MESSAGE_HEADER_ID = null;
                        mess.QUANTITY = -mess.QUANTITY;
                        mess.AMOUNT = -mess.AMOUNT;
                        dataList.Add(mess);
                    }
                    PurchaseMessageService.Instance.saveUnitSql(mh, dataList, sqlList);
                }
                else if (mh.MESSAGE_TYPE == "2")
                {
                    List<CostMessage> dataList = new List<CostMessage>();
                    DataTable dtb = CostMessageService.Instance.GetInfoByHeaderID(mhID, out err);
                    foreach (DataRow item in dtb.Rows)
                    {
                        CostMessage mess = CostMessageService.Instance.getObject(item);
                        mess.COST_MESSAGE_ID = null;
                        mess.MESSAGE_HEADER_ID = null;
                        mess.AMOUNT = -mess.AMOUNT;
                        dataList.Add(mess);
                    }
                    CostMessageService.Instance.saveUnitSql(mh, dataList, sqlList);

                }
                else if (mh.MESSAGE_TYPE == "3")
                {
                    List<OutboundMessage> dataList = new List<OutboundMessage>();
                    DataTable dtb = OutboundMessageService.Instance.GetInfoByHeaderID(mhID, out err);
                    foreach (DataRow item in dtb.Rows)
                    {
                        OutboundMessage mess = OutboundMessageService.Instance.getObject(item);
                        mess.OUTBOUND_MESSAGE_ID = null;
                        mess.MESSAGE_HEADER_ID = null;
                        mess.QUANTITY = -mess.QUANTITY;
                        dataList.Add(mess);
                    }
                    sqlList.AddRange(OutboundMessageService.Instance.GetSaveUnitTransactionSql(mh, dataList));

                }
                else if (mh.MESSAGE_TYPE == "4")
                {
                    List<InvenMessage> dataList = new List<InvenMessage>();
                    DataTable dtb = InvenMessageService.Instance.GetInfoByHeaderID(mhID, out err);
                    foreach (DataRow item in dtb.Rows)
                    {
                        InvenMessage mess = InvenMessageService.Instance.getObject(item);
                        mess.INVEN_MESSAGE_ID = null;
                        mess.MESSAGE_HEADER_ID = null;
                        mess.QUANTITY = -mess.QUANTITY;
                        dataList.Add(mess);
                    }
                    sqlList.AddRange(InvenMessageService.Instance.GetSaveUnitTransactionSql(mh, dataList));
                }
            }
            return true;
        }

        public bool ReverseAccount(string businessCode, out int stateCode, out string err)
        {
            List<string> sqlList = new List<string>();
            if (!ReverseAccount(businessCode, sqlList, out stateCode, out err))
                return false;
            return dbAccess.ExecSql(sqlList, out err);

        }
        public bool ResetDateToLastMonth(string businessCode, out string err)
        {
            string sql = string.Format(@"update [T_MESSAGE_HEADER]
set occur = CONVERT( numeric(8), convert (char(8), dateadd(DAY,-1,CAST(  substring( cast(occur as char(8)) ,1,4) + SUBSTRING ( cast(occur as char(8)),5,2)+ '01' as DATE)),112)),
account = occur
where [BUSINESS_CODE] like '{0}%'", dbOperation.ReplaceSqlKeyStr(businessCode ));

            return dbAccess.ExecSql(sql, out err);
        }
        #endregion
    }
}
