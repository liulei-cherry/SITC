using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SAPFunction.DataObject;
using ItemsManage.Services;
using VbSapRFCCall;
using ItemsManage.DataObject;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using BaseInfo.DataAccess;
using BaseInfo.Objects;
using Oil.Services;

namespace SAPFunction.Services
{
    public class MappingOperation
    {
        #region 单实例

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static MappingOperation instance = new MappingOperation();
        public static MappingOperation Instance
        {
            get
            {
                if (null == instance)
                {
                    MappingOperation.instance = new MappingOperation();
                }
                return MappingOperation.instance;
            }
        }
        private MappingOperation()
        {
            //仅提供private构造.

        }
        #endregion
        /*映射的做法         * 本地查找映射,如果没有插入一条新映射数据,状态为1,报警时用
         * 如果有,状态为3,进行RFC检查有效性,无效就更改状态为2,报警时用,有效就更改状态为4
         *        状态为4,直接返回
         * 1=表示缺少映射
         * 2=表示在财务系统无效         * 3=还没经过有效性校验         * 4=正确的         * 5=sap调用失败
         */
        /// <summary>
        /// 物料映射(普通映射,不是成本类科目的)
        /// </summary>
        public bool MaterialMapping(string management, out string finance, MessageHeader mh, out string err)
        {
            finance = null;
            DataTable dt;
            if (!MaterialMappingService.Instance.GetMapping(management, null, null, out dt, out err))
                return false;
            if (dt.Rows.Count != 0)
            {
                MaterialMapping mapping = MaterialMappingService.Instance.getObject(dt.Rows[0]);
                if ("1,2,3,5".Contains(mapping.STATUS))
                {
                    bool isValid;
                    if (!RFCOperation.Instance.CheckIsValidVB(mapping.MATERIAL_FINANCE, 1, out isValid))
                    {
                        mapping.STATUS = "5";
                        if (mh != null)
                            mh.MESSAGE_ERROR += ("\r\n映射时SAP方法调用失败");
                    }
                    else
                    {
                        if (!isValid)
                        {
                            mapping.STATUS = "2";
                            if (mh != null)
                                mh.MESSAGE_ERROR += "\r\n映射时在SAP端不存在机务机务物资(物料/备件/油料)";
                        }
                        else
                        {
                            mapping.STATUS = "4";
                            finance = mapping.MATERIAL_FINANCE;
                        }
                    }
                    if (!MaterialMappingService.Instance.saveUnit(mapping, out err))
                        return false;
                }
                else if (mapping.STATUS == "4")
                {
                    finance = mapping.MATERIAL_FINANCE;
                }
            }
            else
            {
                if (mh != null)
                    mh.MESSAGE_ERROR += ("\r\n机务物资(物料/备件/油料) 映射不存在");
                if (!MaterialMappingService.Instance.saveUnit(new MaterialMapping(null, management, null, null, "1"), out err))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 物资映射(没有就映射成本类科目,再没有就插入一条新的映射信息)
        /// </summary>
        /// <param name="management"></param>
        /// <param name="mapping"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool MaterialOrCostMapping(string management, out string material_mapping, out string cost_finance, string material_type, MessageHeader mh, out string err)
        {
            material_mapping = null;
            cost_finance = null;
            DataTable dtMaterialOrCost;
            if (!MaterialMappingService.Instance.GetMapping(management, null, null, out dtMaterialOrCost, out err))
                return false;
            if (dtMaterialOrCost.Rows.Count == 0)
            {
                MaterialMapping mapping = null;
                DataTable dtMaterial = MaterialInfoService.Instance.getInfo(management, out err);
                string type = dtMaterial.Rows[0]["MATERIAL_TYPE_ID"].ToString();
                DataTable dtType;
                if (!MaterialInfoService.Instance.GetMaterialSuperiorType(type, out dtType, out err))
                    return false;
                for (int i = 0; i < dtType.Rows.Count; i++)
                {
                    DataTable dt;
                    if (!MaterialMappingService.Instance.GetMapping(dtType.Rows[i]["MATERIAL_TYPE_ID"].ToString(), null, null, out dt, out err))
                        return false;
                    if (dt.Rows.Count != 0)
                    {
                        mapping = MaterialMappingService.Instance.getObject(dt.Rows[0]);
                        if ("1,2,3,5".Contains(mapping.STATUS))
                        {
                            bool isValid;
                            if (!RFCOperation.Instance.CheckIsValidVB(mapping.COST_FINANCE, 4, out isValid))
                            {
                                mapping.STATUS = "5";
                                if (mh != null)
                                    mh.MESSAGE_ERROR += ("\r\n映射时SAP方法调用失败");
                            }
                            else
                            {
                                if (!isValid)
                                {
                                    mapping.STATUS = "2";
                                    if (mh != null)
                                        mh.MESSAGE_ERROR += ("\r\n映射时在SAP端不存在机务物料 " + MessageHeaderService.Instance.getCustomErrorInfo(management, "T_MATERIAL", out err));
                                }
                                else
                                {
                                    mapping.STATUS = "4";
                                    cost_finance = mapping.COST_FINANCE;
                                }
                            }
                            if (!MaterialMappingService.Instance.saveUnit(mapping, out err))
                                return false;
                        }
                        else if (mapping.STATUS == "4")
                        {
                            cost_finance = mapping.COST_FINANCE;
                        }
                        return true;
                    }
                }
                if (string.IsNullOrEmpty(cost_finance) && dtMaterialOrCost.Rows.Count == 0)
                {
                    if (CommonOperation.ConstParameter.ArgumentSetCollection.ContainsKey("otherSubject"))
                    {
                        string otherSubject = CommonOperation.ConstParameter.ArgumentSetCollection["otherSubject"];
                        if (!MaterialMappingService.Instance.saveUnit(new MaterialMapping(null, management, null, otherSubject, "4"), out err))
                            return false;
                    }
                }
            }
            else if (dtMaterialOrCost.Rows.Count != 0 && (!string.IsNullOrEmpty(dtMaterialOrCost.Rows[0]["COST_FINANCE"].ToString())))
            {
                cost_finance = dtMaterialOrCost.Rows[0]["COST_FINANCE"].ToString();
            }
            else
            {
                if (!MappingOperation.Instance.MaterialMapping(management, out material_mapping, mh, out err))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 得到物资费用映射.
        /// </summary>
        public bool GetMaterialCostMapping(string management, out string cost_finance, out string costName, out string err)
        {
            costName = null;
            cost_finance = null;
            MaterialMapping mapping = null;
            DataTable dtMaterial = MaterialInfoService.Instance.getInfo(management, out err);
            string type = dtMaterial.Rows[0]["MATERIAL_TYPE_ID"].ToString();
            DataTable dtType;
            if (!MaterialInfoService.Instance.GetMaterialSuperiorType(type, out dtType, out err))
                return false;
            for (int i = 0; i < dtType.Rows.Count; i++)
            {
                DataTable dt;
                if (!MaterialMappingService.Instance.GetMapping(dtType.Rows[i]["MATERIAL_TYPE_ID"].ToString(), null, null, out dt, out err))
                    return false;
                if (dt.Rows.Count != 0 && !string.IsNullOrEmpty(dt.Rows[0]["COST_FINANCE"].ToString()))
                {
                    mapping = MaterialMappingService.Instance.getObject(dt.Rows[0]);
                    costName = dt.Rows[0]["MATERIAL_NAME"].ToString();
                    cost_finance = mapping.COST_FINANCE;
                    return true;
                }
            }
            return true;
        }

        /// <summary>
        /// 得到滑油费用映射.
        /// </summary>
        /// <param name="management"></param>
        /// <param name="cost_finance"></param>
        /// <param name="costName"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool GetHoilCostMapping(string management, out string cost_finance, out string costName, out string err)
        {
            costName = null;
            cost_finance = null;
            MaterialMapping mapping = null;
            DataTable dtHoil = HOilService.Instance.getInfo(management, out err);
            string type = dtHoil.Rows[0]["LOIL_TYPE"].ToString();
            DataTable dt;
            if (!MaterialMappingService.Instance.GetHoilMapping(type, null, null, out dt, out err))
                return false;
            if (dt.Rows.Count != 0 && !string.IsNullOrEmpty(dt.Rows[0]["COST_FINANCE"].ToString()))
            {
                mapping = MaterialMappingService.Instance.getObject(dt.Rows[0]);
                cost_finance = mapping.COST_FINANCE;
                return true;
            }
            return true;
        }

        /// <summary>
        /// 备件映射(没有就映射成本类科目,再没有就插入一条新的映射信息)
        ///得到第一个设备.
        ///循环体.
        ///判断当前设备是否是船舶本身(根据设备是否有上级设备判断,最顶级设备就是船舶),是,则返回其他备件(其实这说明有数据问题)
        ///根据当前设备找其分类,
        ///当分类有效,则跳出循环体.
        ///当分类无效,则继续找上一级别的设备,重新进入循环.
        /// </summary>
        /// <param name="management"></param>
        /// <param name="cost_finance"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool SpareOrCostMapping(string management, out string material_mapping, out string cost_finance, string material_type, MessageHeader mh, out string err)
        {
            material_mapping = null;
            cost_finance = null;
            DataTable dtMaterialOrCost;
            if (!MaterialMappingService.Instance.GetMapping(management, null, null, out dtMaterialOrCost, out err))
                return false;
            if (dtMaterialOrCost.Rows.Count == 0)
            {
                DataTable dtComponentUnit = SpareInfoService.Instance.GetOneSpareComponentUnit(management);
                if (dtComponentUnit.Rows.Count == 0)
                {
                    if (CommonOperation.ConstParameter.ArgumentSetCollection.ContainsKey("otherSubject"))
                    {
                        cost_finance = CommonOperation.ConstParameter.ArgumentSetCollection["otherSubject"];
                        if (!MaterialMappingService.Instance.saveUnit(new MaterialMapping(null, management, null, cost_finance, "4"), out err))
                            return false;
                        return true;
                    }
                }
                DataTable dtSuperEquipment;
                if (!ComponentUnitService.Instance.GetSuperEquipment(dtComponentUnit.Rows[0]["COMPONENT_UNIT_ID"].ToString(), out dtSuperEquipment, out err))
                    return false;
                foreach (DataRow item in dtSuperEquipment.Rows)
                {
                    ComponentUnit cu = ComponentUnitService.Instance.getObject(item["COMPONENT_UNIT_ID"].ToString(), out err);
                    if (cu.PARENT_UNIT_ID == null)
                    {
                        if (CommonOperation.ConstParameter.ArgumentSetCollection.ContainsKey("otherSubject"))
                        {
                            cost_finance = CommonOperation.ConstParameter.ArgumentSetCollection["otherSubject"];
                            if (!MaterialMappingService.Instance.saveUnit(new MaterialMapping(null, management, null, cost_finance, "4"), out err))
                                return false;
                            return true;
                        }
                        string CLASSID = EquipmentClassService.Instance.GetEquipmentBelongClass(item["COMPONENT_UNIT_ID"].ToString());
                        DataTable dtClass;
                        if (!EquipmentClassService.Instance.GetSuperClass(CLASSID, out dtClass, out err))
                            return false;
                        for (int i = 0; i < dtClass.Rows.Count; i++)
                        {
                            DataTable dt;
                            if (!MaterialMappingService.Instance.GetMapping(dtClass.Rows[i]["CLASSID"].ToString(), null, null, out dt, out err))
                                return false;
                            if (dt.Rows.Count != 0)
                            {
                                MaterialMapping mapping = MaterialMappingService.Instance.getObject(dt.Rows[0]);
                                if ("1,2,3,5".Contains(mapping.STATUS))
                                {
                                    bool isValid;
                                    if (!RFCOperation.Instance.CheckIsValidVB(mapping.COST_FINANCE, 4, out isValid))
                                    {
                                        mapping.STATUS = "5";
                                        if (mh != null)
                                            mh.MESSAGE_ERROR += ("\r\n映射时SAP方法调用失败");
                                    }
                                    else
                                    {
                                        if (!isValid)
                                        {
                                            mapping.STATUS = "2";
                                            if (mh != null)
                                                mh.MESSAGE_ERROR += ("\r\n映射时在SAP端不存在机务备件 " + MessageHeaderService.Instance.getCustomErrorInfo(management, "T_SPARE", out err));
                                        }
                                        else
                                        {
                                            mapping.STATUS = "4";
                                            cost_finance = mapping.COST_FINANCE;
                                        }
                                    }
                                    if (!MaterialMappingService.Instance.saveUnit(mapping, out err))
                                        return false;
                                }
                                else if (mapping.STATUS == "4")
                                {
                                    cost_finance = mapping.COST_FINANCE;
                                }
                                return true;
                            }
                        }
                    }
                }
            }
            else if (dtMaterialOrCost.Rows.Count != 0 && (!string.IsNullOrEmpty(dtMaterialOrCost.Rows[0]["COST_FINANCE"].ToString())))
            {
                cost_finance = dtMaterialOrCost.Rows[0]["COST_FINANCE"].ToString();
            }
            else
            {
                if (!MappingOperation.Instance.MaterialMapping(management, out material_mapping, mh, out err))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 得到备件费用映射.
        /// </summary>
        public bool GetSpareCostMapping(string shipID, string management, out string cost_finance, out string costName, out string err)
        {
            costName = "";
            err = "";
            cost_finance = null;
            DataTable dtComponentUnit = SpareInfoService.Instance.GetOneSpareComponentUnit(shipID, management);
            if (dtComponentUnit.Rows.Count != 0)
            {
                DataTable dtSuperEquipment;
                if (!ComponentUnitService.Instance.GetSuperEquipment(dtComponentUnit.Rows[0]["COMPONENT_UNIT_ID"].ToString(), out dtSuperEquipment, out err))
                    return false;
                foreach (DataRow item in dtSuperEquipment.Rows)
                {
                    ComponentUnit cu = ComponentUnitService.Instance.getObject(item["COMPONENT_UNIT_ID"].ToString(), out err);
                    if (cu.PARENT_UNIT_ID != null)
                    {
                        string CLASSID = EquipmentClassService.Instance.GetEquipmentBelongClass(item["COMPONENT_UNIT_ID"].ToString());
                        DataTable dtClass;
                        if (!EquipmentClassService.Instance.GetSuperClass(CLASSID, out dtClass, out err))
                            return false;
                        for (int i = 0; i < dtClass.Rows.Count; i++)
                        {
                            DataTable dt;
                            if (!MaterialMappingService.Instance.GetMapping(dtClass.Rows[i]["CLASSID"].ToString(), null, null, out dt, out err))
                                return false;
                            if (dt.Rows.Count != 0 && !string.IsNullOrEmpty(dt.Rows[0]["COST_FINANCE"].ToString()))
                            {
                                MaterialMapping mapping = MaterialMappingService.Instance.getObject(dt.Rows[0]);
                                costName = dt.Rows[0]["MATERIAL_NAME"].ToString();
                                cost_finance = mapping.COST_FINANCE;
                                return true;
                            }
                        }
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 内部订单映射.
        /// </summary>
        /// <param name="ship_code"></param>
        /// <param name="item_code"></param>
        /// <param name="mapping"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool InternalOrderMapping(string ship_code, string item_code, out string finance, MessageHeader mh, out string err)
        {
            finance = null;
            DataTable dt;
            if (!InternalOrderMappingService.Instance.GetMapping(ship_code, item_code, null, null, out dt, out err))
                return false;
            if (dt.Rows.Count != 0)
            {
                InternalOrderMapping mapping = InternalOrderMappingService.Instance.getObject(dt.Rows[0]);
                if ("1,2,3,5".Contains(mapping.STATUS))
                {
                    bool isValid;
                    if (!RFCOperation.Instance.CheckIsValidVB(mapping.INTERNAL_ORDER_FINANCE, 2, out isValid))
                    {
                        mapping.STATUS = "5";
                        if (mh != null)
                            mh.MESSAGE_ERROR += ("\r\n映射时SAP方法调用失败");
                    }
                    else
                    {
                        if (!isValid)
                        {
                            mapping.STATUS = "2";
                            if (mh != null)
                                mh.MESSAGE_ERROR += ("\r\n映射时在SAP端不存在机务内部订单 " + MessageHeaderService.Instance.getCustomErrorInfo(ship_code, "T_SHIP", out err) + "---" + MessageHeaderService.Instance.getCustomErrorInfo(item_code, "T_COST_ACCOUNT", out err));
                        }
                        else
                        {
                            mapping.STATUS = "4";
                            finance = mapping.INTERNAL_ORDER_FINANCE;
                        }
                    }
                    if (!InternalOrderMappingService.Instance.saveUnit(mapping, out err))
                        return false;
                }
                else if (mapping.STATUS == "4")
                {
                    finance = mapping.INTERNAL_ORDER_FINANCE;
                }
            }
            else
            {
                if (mh != null)
                    mh.MESSAGE_ERROR += ("\r\n机务内部订单 " + MessageHeaderService.Instance.getCustomErrorInfo(ship_code, "T_SHIP", out err) + "---" + MessageHeaderService.Instance.getCustomErrorInfo(item_code, "T_COST_ACCOUNT", out err) + " 映射不存在");
                if (!InternalOrderMappingService.Instance.saveUnit(new InternalOrderMapping(null, ship_code, item_code, null, "1"), out err))
                    return false;
            }
            return true;
        }
        /// <summary>
        /// 供应商映射.
        /// </summary>
        /// <param name="management"></param>
        /// <param name="mapping"></param>
        /// <param name="err"></param>
        /// <returns></returns>
        public bool SupplierMapping(string management, out string finance, MessageHeader mh, out string err)
        {
            finance = null;
            DataTable dt;
            if (!SupplierMappingService.Instance.GetMapping(management, null, null, out dt, out err))
                return false;
            if (dt.Rows.Count != 0)
            {
                SupplierMapping mapping = SupplierMappingService.Instance.getObject(dt.Rows[0]);
                if ("1,2,3,5".Contains(mapping.STATUS))
                {
                    bool isValid;
                    if (!RFCOperation.Instance.CheckIsValidVB(mapping.FINANCE, 3, out isValid))
                    {
                        mapping.STATUS = "5";
                        if (mh != null)
                            mh.MESSAGE_ERROR += ("\r\n映射时SAP方法调用失败");
                    }
                    else
                    {
                        if (!isValid)
                        {
                            mapping.STATUS = "2";
                            if (mh != null)
                                mh.MESSAGE_ERROR += ("\r\n映射时在SAP端不存在机务供应商 " + MessageHeaderService.Instance.getCustomErrorInfo(management, "T_MANUFACTURER", out err));
                        }
                        else
                        {
                            mapping.STATUS = "4";
                            finance = mapping.FINANCE;
                        }
                    }
                    if (!SupplierMappingService.Instance.saveUnit(mapping, out err))
                        return false;
                }
                else if (mapping.STATUS == "4")
                {
                    finance = mapping.FINANCE;
                }
            }
            else
            {
                if (mh != null)
                    mh.MESSAGE_ERROR += ("\r\n机务供应商 " + MessageHeaderService.Instance.getCustomErrorInfo(management, "T_MANUFACTURER", out err) + " 映射不存在");
                if (!SupplierMappingService.Instance.saveUnit(new SupplierMapping(null, management, null, "1"), out err))
                    return false;
            }
            return true;
        }
    }
}
