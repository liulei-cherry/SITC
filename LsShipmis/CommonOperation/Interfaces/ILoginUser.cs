using System;
using System.Collections.Generic;
using System.Text;

namespace CommonOperation.Interfaces
{
    public interface ILoginUser
    {
        /// <summary>
        /// 是否是高级船员.
        /// </summary>
        bool ISHIGHLEVELSHIPMAN { get; }
        /// <summary>
        /// 是否是岸端人员.
        /// </summary>
        bool ISLANDPERSON { get; }
        /// <summary>
        /// 是否是部门长.
        /// </summary>
        bool ISSHIPHEADER { get; }
        /// <summary>
        /// 是否是船长.
        /// </summary>
        bool ISSHIPBOSS { get; }
        /// <summary>
        /// 是否是甲板部.
        /// </summary>
        bool ISDECKMAN { get; }
        /// <summary>
        /// 是否是轮机部.
        /// </summary>
        bool ISMACHINEMAN { get; }
        /// <summary>
        /// 岗位名称.
        /// </summary>
        string ShipHeadShipName { get; }
        /// <summary>
        /// 部门id
        /// </summary>
        string DepartmentId { get; }
        string DepartmentName { get; }
        /// <summary>
        /// 岗位id
        /// </summary>
        string PostId { get; }

        /// <summary>
        /// 岗位类型名称.
        /// </summary>
        string POSTTYPENAME { get; }
    }
}
