using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAPFunction.DataObject;

namespace SAPFunction.Services
{
    public class MessageOperation
    {
        #region 单实例

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static MessageOperation instance = new MessageOperation();
        public static MessageOperation Instance
        {
            get
            {
                if (null == instance)
                {
                    MessageOperation.instance = new MessageOperation();
                }
                return MessageOperation.instance;
            }
        }
        private MessageOperation()
        {
            //仅提供private构造.

        }
        #endregion

        #region 报文处理
        /*报文处理的做法         * 得到该类型所有报文         * 映射报文中需要翻译的项         * 数据包ID,需要船东代码,所以 也要在这里做映射
         * 出现翻译不了了,把报文头状态改成2,表示未处理或出现错误需要再次处理         * 全部翻译通过,保存报文,报文头状态改成3,表示待发送         * 
         * 2=表示未处理或出现错误需要再次处理         * 3=表示待发送         * 4=发送成功,但在财务系统端出错被打回
         * 5=发送成功,财务系统端也成功
         * 6=作废
         * 7=SAP方法调用失败'"
         */
        /// <summary>
        /// 采购报文处理.
        /// </summary>
        /// <param name="mh"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool PurchaseGenerate(MessageHeader mh, out string err)
        {
            err = "";
            mh.MESSAGE_ERROR = "";
            bool isMappingSucceed = true;
            DataTable dt = PurchaseMessageService.Instance.GetInfoByHeaderID(mh.MESSAGE_HEADER_ID, out err);
            List<PurchaseMessage> dataList = new List<PurchaseMessage>();
            foreach (DataRow dr in dt.Rows)
            {
                PurchaseMessage item = PurchaseMessageService.Instance.getObject(dr);
                if (!string.IsNullOrEmpty(item.MATERIAL.Trim()))
                {
                    string material_mapping = "";
                    #region 备份
                    //if ("1" == mh.BUSINESS_TYPE)
                    //{
                    //    if (!MappingOperation.Instance.MaterialOrCostMapping(item.MATERIAL, out material_mapping, out cost_finance, mh.BUSINESS_TYPE, mh, out err))
                    //        return false;
                    //}
                    //else if ("2" == mh.BUSINESS_TYPE)
                    //{
                    //    if (!MappingOperation.Instance.SpareOrCostMapping(item.MATERIAL, out material_mapping, out cost_finance, mh.BUSINESS_TYPE, mh, out err))
                    //        return false;
                    //}
                    //else
                    //{
                    //    if (!MappingOperation.Instance.MaterialMapping(item.MATERIAL, out material_mapping, mh.BUSINESS_TYPE, mh, out err))
                    //        return false;
                    //}
                    //if (string.IsNullOrEmpty(material_mapping) && string.IsNullOrEmpty(cost_finance))
                    //{
                    //    isMappingSucceed = false;
                    //    mh.MESSAGE_ERROR += ("\r\n机务(物料或备件或油料 )" + item.MATERIAL + " 映射错误或不存在");
                    //}
                    //else if (!string.IsNullOrEmpty(material_mapping))
                    //{
                    //    item.SUBJECT_MAPPING = "";
                    //    item.MATERIAL_MAPPING = material_mapping;
                    //}
                    //else if (!string.IsNullOrEmpty(cost_finance))
                    //{
                    //    item.SUBJECT_MAPPING = cost_finance;
                    //    item.MATERIAL_MAPPING = "";
                    //}       
                    #endregion
                    if (!MappingOperation.Instance.MaterialMapping(item.MATERIAL, out material_mapping, mh, out err))
                        return false;
                    if (string.IsNullOrEmpty(material_mapping))
                        isMappingSucceed = false;
                    else if (!string.IsNullOrEmpty(material_mapping))
                        item.MATERIAL_MAPPING = material_mapping;
                }

                string supplier_mapping;
                if (!MappingOperation.Instance.SupplierMapping(item.SUPPLIER, out supplier_mapping, mh, out err))
                    return false;
                if (string.IsNullOrEmpty(supplier_mapping))
                    isMappingSucceed = false;
                else
                    item.SUPPLIER_MAPPING = supplier_mapping;

                item.SHIP_MAPPING = mh.COMPANY_CODE;
                dataList.Add(item);
            }
            if (isMappingSucceed)
            {
                mh.STATUS = "3";
                if (!PurchaseMessageService.Instance.saveUnitTransaction(mh, dataList, out err))
                    return false;
            }
            else
            {
                if (!mh.Update(out err))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 费用报文处理.
        /// </summary>
        /// <param name="mh"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool CostGenerate(MessageHeader mh, out string err)
        {
            err = "";
            mh.MESSAGE_ERROR = "";
            bool isMappingSucceed = true;
            DataTable dt = CostMessageService.Instance.GetInfoByHeaderID(mh.MESSAGE_HEADER_ID, out err);
            List<CostMessage> dataList = new List<CostMessage>();
            foreach (DataRow dr in dt.Rows)
            {
                CostMessage item = CostMessageService.Instance.getObject(dr);
                string supplier_mapping;
                if (!MappingOperation.Instance.SupplierMapping(item.SUPPLIER, out supplier_mapping, mh, out err))
                    return false;
                if (string.IsNullOrEmpty(supplier_mapping))
                    isMappingSucceed = false;
                else
                    item.SUPPLIER_MAPPING = supplier_mapping;
                if (item.COST_TYPE == "A")
                {
                    string inner_order;
                    if (!MappingOperation.Instance.InternalOrderMapping(item.SHIP_ID, item.SUBJECT, out inner_order, mh, out err))
                        return false;
                    if (string.IsNullOrEmpty(inner_order))
                        isMappingSucceed = false;
                    else
                        item.INNER_ORDER = inner_order;
                }
                item.SHIP_MAPPING = mh.COMPANY_CODE;
                dataList.Add(item);
            }
            if (isMappingSucceed)
            {
                mh.STATUS = "3";
                if (!CostMessageService.Instance.saveUnitTransaction(mh, dataList, out err))
                    return false;
            }
            else
            {
                if (!mh.Update(out err))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 物资领用报文处理.
        /// </summary>
        /// <param name="mh"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool OutboundGenerate(MessageHeader mh, out string err)
        {
            err = "";
            mh.MESSAGE_ERROR = "";
            bool isMappingSucceed = true;
            DataTable dt = OutboundMessageService.Instance.GetInfoByHeaderID(mh.MESSAGE_HEADER_ID, out err);
            List<OutboundMessage> dataList = new List<OutboundMessage>();
            foreach (DataRow dr in dt.Rows)
            {
                OutboundMessage item = OutboundMessageService.Instance.getObject(dr);
                if (string.IsNullOrEmpty(item.MATERIAL_MAPPING))
                {
                    string material_mapping;
                    if (!MappingOperation.Instance.MaterialMapping(item.MATERIAL, out material_mapping, mh, out err))
                        return false;
                    if (string.IsNullOrEmpty(material_mapping))
                        isMappingSucceed = false;
                    else
                    {
                        item.MATERIAL_MAPPING = material_mapping;
                    }
                }
                if (!string.IsNullOrEmpty(item.MATERIAL_MAPPING))
                {
                    DataTable dtb;
                    MaterialMappingService.Instance.GetSAPStorageQuantity(item.MATERIAL, item.SHIP_ID, out dtb);
                    decimal STORAGE_QUANTITY = 0;
                    string materialMappingID = "";
                    STORAGE_QUANTITY = Convert.ToDecimal(dtb.Rows[0]["STORAGE_QUANTITY"]);
                    materialMappingID = dtb.Rows[0]["MATERIAL_MAPPING_ID"].ToString();

                    decimal quantity = item.QUANTITY;
                    if (STORAGE_QUANTITY != 0)
                    {
                        if (quantity <= STORAGE_QUANTITY)
                        {
                            STORAGE_QUANTITY = STORAGE_QUANTITY - quantity;
                            if (!MaterialMappingService.Instance.GetUpdateStorageQuantity(item.SHIP_ID, materialMappingID, STORAGE_QUANTITY, out err))
                                return false;
                            if (!item.Delete(out err))
                                return false;
                            continue;
                        }
                        else
                        {
                            quantity = quantity - STORAGE_QUANTITY;
                            STORAGE_QUANTITY = 0;
                            MaterialMappingService.Instance.GetUpdateStorageQuantity(item.SHIP_ID, materialMappingID, STORAGE_QUANTITY, out err);
                        }
                    }
                    item.QUANTITY = quantity;
                }
                item.SHIP_MAPPING = mh.COMPANY_CODE;
                item.LINENUM = dataList.Count + 1;
                dataList.Add(item);
            }
            if (isMappingSucceed)
            {
                if (dataList.Count == 0)
                {
                    if (!mh.Delete(out err))
                        return false;
                    return true;
                }
                mh.STATUS = "3";
                mh.QUANTITY = dataList.Count;
                if (!OutboundMessageService.Instance.saveUnitTransaction(mh, dataList, out err))
                    return false;
            }
            else
            {
                mh.QUANTITY = dataList.Count;
                if (!mh.Update(out err))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 盘点报文处理.
        /// </summary>
        /// <param name="mh"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool InvenGenerate(MessageHeader mh, out string err)
        {
            err = "";
            mh.MESSAGE_ERROR = "";
            bool isMappingSucceed = true;
            DataTable dt = InvenMessageService.Instance.GetInfoByHeaderID(mh.MESSAGE_HEADER_ID, out err);
            List<InvenMessage> dataList = new List<InvenMessage>();
            foreach (DataRow dr in dt.Rows)
            {
                InvenMessage item = InvenMessageService.Instance.getObject(dr);
                string material_mapping;
                if (!MappingOperation.Instance.MaterialMapping(item.MATERIAL, out material_mapping, mh, out err))
                    return false;
                if (string.IsNullOrEmpty(material_mapping))
                    isMappingSucceed = false;
                else
                    item.MATERIAL_MAPPING = material_mapping;

                item.SHIP_MAPPING = mh.COMPANY_CODE;
                dataList.Add(item);
            }
            if (isMappingSucceed)
            {
                mh.STATUS = "3";
                if (!InvenMessageService.Instance.saveUnitTransaction(mh, dataList, out err))
                    return false;
            }
            else
            {
                if (!mh.Update(out err))
                    return false;
            }
            return true;
        }
        #endregion

        #region 报文发送

        /*找出待发送报文发送出去
         * 返回错误,更改报文头状态为4,表示报文发送失败,并存储报文错误
         */
        /// <summary>
        /// 发送报文,并接受错误.
        /// </summary>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool SendMessage(out string err)
        {
            err = "";
            string errorMessage;
            DataTable dt = MessageHeaderService.Instance.GetInfo(null,null,null, "3", null, out err);
            foreach (DataRow item in dt.Rows)
            {
                DataTable dtMessage = null;
                MessageHeader mh = MessageHeaderService.Instance.getObject(item);
                if (mh.MESSAGE_TYPE == "1")
                {
                    dtMessage = PurchaseMessageService.Instance.GetInfoByHeaderID(mh.MESSAGE_HEADER_ID, out err);
                }
                else if (mh.MESSAGE_TYPE == "2")
                {
                    dtMessage = CostMessageService.Instance.GetInfoByHeaderID(mh.MESSAGE_HEADER_ID, out err);
                }
                else if (mh.MESSAGE_TYPE == "3")
                {
                    dtMessage = OutboundMessageService.Instance.GetInfoByHeaderID(mh.MESSAGE_HEADER_ID, out err);
                }
                else if (mh.MESSAGE_TYPE == "4")
                {
                    dtMessage = InvenMessageService.Instance.GetInfoByHeaderID(mh.MESSAGE_HEADER_ID, out err);
                }
                bool isValid;
                if (RFCOperation.Instance.SendMessageVB(mh, dtMessage, out errorMessage, out isValid))
                {
                    if (isValid)
                    {
                        mh.STATUS = "5";
                    }
                    else
                    {
                        mh.STATUS = "4";
                    }
                }
                else
                {
                    mh.STATUS = "7";
                }
                mh.MESSAGE_ERROR = errorMessage;
                if (!MessageHeaderService.Instance.saveUnit(mh, out err))
                    return false;
            }
            return true;
        }
        #endregion

        public void MappingMessage(out string err)
        {
            DataTable dt = MessageHeaderService.Instance.GetInfo(null,null,null, "2','4','7", null, out err);
            if (dt != null && dt.Rows.Count != 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    MessageHeader hm = MessageHeaderService.Instance.getObject(item);
                    switch (hm.MESSAGE_TYPE)
                    {
                        case "1":
                            MessageOperation.Instance.PurchaseGenerate(hm, out err);
                            break;
                        case "2":
                            MessageOperation.Instance.CostGenerate(hm, out err);
                            break;
                        case "3":
                            MessageOperation.Instance.OutboundGenerate(hm, out err);
                            break;
                        case "4":
                            MessageOperation.Instance.InvenGenerate(hm, out err);
                            break;
                    }
                }
            }
        }

    }
}
