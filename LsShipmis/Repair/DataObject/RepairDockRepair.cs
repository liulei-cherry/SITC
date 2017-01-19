/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：RepairDockRepair.cs
 * 创 建 人：王鹏程
 * 创建时间：2012/4/12
 * 标    题：实体类
 * 功能描述：T_REPAIR_DOCKREPAIR数据实体类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using Repair.Services;

namespace Repair.DataObject
{
    /// <summary>
    ///T_REPAIR_DOCKREPAIR数据实体
    /// </summary>
    ///[Serializable]
    public partial class RepairDockRepair : CommonClass
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public RepairDockRepair()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public RepairDockRepair
        (
            string rEPAIR_DOCKREPAIR_ID,
            string sHIP_ID,
            string rEPAIR_ANNUAL,
            string rEMARK
        )
        {
            this.REPAIR_DOCKREPAIR_ID = rEPAIR_DOCKREPAIR_ID;
            this.SHIP_ID = sHIP_ID;
            this.REPAIR_ANNUAL = rEPAIR_ANNUAL;
            this.REMARK = rEMARK;

        }
        #endregion

        #region 公共属性

        ///<summary>
        ///主键ID
        ///</summary>
        public string REPAIR_DOCKREPAIR_ID { get; set; }

        ///<summary>
        ///船舶ID
        ///</summary>
        public string SHIP_ID { get; set; }

        ///<summary>
        ///厂修年度
        ///</summary>
        public string REPAIR_ANNUAL { get; set; }

        ///<summary>
        ///备注
        ///</summary>
        public string REMARK { get; set; }

        ///<summary>
        ///克隆一个对象
        ///</summary>
        /// <returns>克隆的新对象</returns>	
        public override CommonClass Clone()
        {
            RepairDockRepair Unit = new RepairDockRepair();
            Unit.REPAIR_DOCKREPAIR_ID = this.REPAIR_DOCKREPAIR_ID;
            Unit.SHIP_ID = this.SHIP_ID;
            Unit.REPAIR_ANNUAL = this.REPAIR_ANNUAL;
            Unit.REMARK = this.REMARK;
            return Unit;
        }
        #endregion

        public override string GetId()
        {
            return this.REPAIR_DOCKREPAIR_ID;
        }

        public override string GetTypeName()
        {
            return "RepairDockRepair";
        }

        public override bool Update(out string err)
        {
            return RepairDockRepairService.Instance.saveUnit(this, out err);
        }
        public void Update()
        {
            RepairDockRepairService.Instance.saveUnit(this);
        }
        public string UpdateSql()
        {
            return RepairDockRepairService.Instance.saveUnitSql(this);
        }

        public override bool Delete(out string err)
        {
            return RepairDockRepairService.Instance.deleteUnit(this.GetId(), out err);
        }
        public void Delete()
        {
            RepairDockRepairService.Instance.deleteUnit(this.GetId());
        }
        public string DeleteSql()
        {
            return RepairDockRepairService.Instance.deleteUnitSql(this.GetId());
        }
        public override void FillThisObject()
        {

        }
    }
}
