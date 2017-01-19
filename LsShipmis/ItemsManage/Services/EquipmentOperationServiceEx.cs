/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技有限公司 版权所有
 * 文 件 名：EquipmentOperationService.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011/5/3
 * 标    题：数据操作类
 * 功能描述：T_EQUIPMENT_OPERATION数据操作类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using BaseInfo.Objects;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using ItemsManage.DataObject;

namespace ItemsManage.Services
{
    /// <summary>
    /// 数据层实例化接口类 dbo.T_EQUIPMENT_OPERATIONService.cs
    /// </summary>
    public partial class EquipmentOperationService
    {
        
        /// <summary>
        /// 获取设备的操作步骤数据，并以DataTable形式返回.
        /// </summary>
        public DataTable GetOperationByEquipment(ComponentUnit unit)
        {

            string err;
            DataTable dt;

            sql = "SELECT *  FROM T_EQUIPMENT_OPERATION t1";
            sql += " where t1.EQUIPMENTID = '" + unit.COMPONENT_TYPE_ID + "' order by SORTNO";

            dbAccess.GetDataTable(sql, out dt, out err);
            return dt;
        }

    }
}
