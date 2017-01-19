using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace StorageManage.Services
{
    public partial class SparePurchaseApplyService
    {
        /// <summary>
        /// 得到  T_SPARE_PURCHASE_APPLY 所有数据信息.
        /// </summary>
        /// <returns>T_SPARE_PURCHASE_APPLY DataTable</returns>
        public DataTable GetInfo(List<String> PURCHASE_APPLYIDs, string SHIP_ID, string DEPART_ID, string PURCHASE_APPLY_PERSON_POSTID, string STATE)
        {
            string PURCHASE_APPLYID_string = "";
            if (PURCHASE_APPLYIDs != null)
            {
                foreach (string id in PURCHASE_APPLYIDs)
                {
                    PURCHASE_APPLYID_string += "'" + id + "',";
                }
                if (PURCHASE_APPLYID_string.Length > 0) PURCHASE_APPLYID_string = PURCHASE_APPLYID_string.Remove(PURCHASE_APPLYID_string.Length - 1);
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("spa.PURCHASE_APPLYID");
            sb.AppendLine(",spa.PURCHASE_APPLY_CODE");
            sb.AppendLine(",spa.SHIP_ID");
            sb.AppendLine(",s.SHIP_NAME");
            sb.AppendLine(",spa.PURCHASE_APPLY_DATE");
            sb.AppendLine(",spa.STATE");
            sb.AppendLine(" ,case spa.STATE ");
            sb.AppendLine("  when '0' then '未填写完毕'");
            sb.AppendLine("  when '1' then '等待部门长审核'");
            sb.AppendLine("  when '2' then '等待船长确认'");
            sb.AppendLine("  when '3' then '等待岸端机务主管审批'");
            sb.AppendLine("  when '4' then '等待岸端机务经理审批'");
            sb.AppendLine("  when '5' then '等待船管总经理审批'");
            sb.AppendLine("  when '6' then '审核通过'");
            sb.AppendLine("  when '7' then '取消'");
            sb.AppendLine("  when '8' then '被打回'");
            sb.AppendLine("  when '9' then '已订购'");
            sb.AppendLine("  end as STATE_NAME");
            sb.AppendLine(",spa.COMPONENT_UNIT_ID");
            sb.AppendLine(",cu.COMP_CHINESE_NAME");
            sb.AppendLine(",dbo.F_Get_Comp_Full_name(spa.COMPONENT_UNIT_ID,1) COMP_FULL_NAME");
            sb.AppendLine(",cu.COMPONENT_TYPE_ID");
            sb.AppendLine(",spa.PURCHASE_APPLY_PERSON");
            sb.AppendLine(",spa.PURCHASE_APPLY_PERSON_POSTID");
            sb.AppendLine(",bh.HEADSHIP_NAME");
            sb.AppendLine(",bh.ISLANDPOST");
            sb.AppendLine(",spa.DEPART_ID");
            sb.AppendLine(",d.DEPARTNAME");
            sb.AppendLine(",spa.ISCOMPLETE");
            sb.AppendLine(" ,case spa.ISCOMPLETE ");
            sb.AppendLine("  when '0' then '未填写完毕'");
            sb.AppendLine("  when '1' then '填写完毕'");
            sb.AppendLine("  end as ISCOMPLETE_NAME");
            sb.AppendLine(",spa.SHIP_LEADER_CHECKER");
            sb.AppendLine(",spa.SHIP_LEADER_CHECKDATE");
            sb.AppendLine(",spa.SHIP_BOSS_CHECKER");
            sb.AppendLine(",spa.SHIP_BOSS_CHECKDATE");
            sb.AppendLine(",spa.LANDCHECKER");
            sb.AppendLine(",spa.CHECKDATE");
            sb.AppendLine(",spa.REMARK");
            sb.AppendLine(" from T_SPARE_PURCHASE_APPLY spa");
            sb.AppendLine(" inner join T_SHIP s on s.SHIP_ID=spa.SHIP_ID ");
            if (CommonOperation.ConstParameter.IsLandVersion)
                sb.AppendLine("  inner join T_USER_SHIP us on us.ship_id=spa.SHIP_ID and us.userid = '" + CommonOperation.ConstParameter.UserId + "'");
            sb.AppendLine(" inner join T_BASE_HEADSHIP bh on bh.SHIP_HEADSHIP_ID=spa.PURCHASE_APPLY_PERSON_POSTID ");
            sb.AppendLine(" inner join T_DEPARTMENT d on d.DEPARTMENTID=spa.DEPART_ID ");
            sb.AppendLine(" left join T_COMPONENT_UNIT cu on cu.COMPONENT_UNIT_ID=spa.COMPONENT_UNIT_ID ");
            sb.AppendLine(" where 1=1 ");
            if (!string.IsNullOrEmpty(PURCHASE_APPLYID_string))
                sb.AppendLine(" and spa.PURCHASE_APPLYID  in (" + PURCHASE_APPLYID_string + ")");
            if (!string.IsNullOrEmpty(SHIP_ID))
                sb.AppendLine(" and spa.SHIP_ID='" + SHIP_ID + "'");
            if (!string.IsNullOrEmpty(DEPART_ID))
                sb.AppendLine(" and spa.DEPART_ID='" + DEPART_ID + "'");
            if (!string.IsNullOrEmpty(PURCHASE_APPLY_PERSON_POSTID))
                sb.AppendLine(" and spa.PURCHASE_APPLY_PERSON_POSTID='" + PURCHASE_APPLY_PERSON_POSTID + "'");
            if (!string.IsNullOrEmpty(STATE))
                sb.AppendLine(" and spa.STATE in (" + STATE + ")");
            sb.AppendLine(" order by spa.PURCHASE_APPLY_DATE desc");
            DataTable dt;
            string err;
            if (dbAccess.GetDataTable(sb.ToString(), out dt, out err))
            {
                return dt;
            }
            else
            {
                throw new Exception(err);
            }
        }
        #region 2014-12-03-根据下拉框选择的状态，返回对应的备件申请状态字符串用逗号隔开
        /// <summary>
        /// 根据下拉框选择的状态，返回对应的备件申请状态字符串用逗号隔开.
        /// </summary>
        /// <param name="viewerState">下拉框选择的状态.</param>
        /// <returns>对应的备件申请状态字符串用逗号隔开.</returns>
        internal string GetBusinessStateByViewerState(string viewerState)
        {
            switch (viewerState)
            {
                case "2":
                    return "1,2,3,4,5,8";

                case "3":
                    return "6";

                case "4":
                    return "7,9";
#if DEBUG
                default:
                    throw new Exception("getBusinessStateByViewerState 调用异常，传入参数无效！");
            }
#else
            }
            return "";
#endif
        }

        #endregion

        #region 检索备件申请信息 xiaxf-2013-6-26
        /// <summary>
        /// 得到  T_SPARE_PURCHASE_APPLY 所有数据信息.
        /// </summary>
        /// <param name="SHIP_ID">船舶id</param>
        /// <param name="APPLY_DATE">申请时间</param>
        /// <returns>T_SPARE_PURCHASE_APPLY DataTable</returns>
        public DataTable GetApplyInfo(string SHIP_ID, string APPLY_DATE)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("spa.PURCHASE_APPLYID");
            sb.AppendLine(",spa.PURCHASE_APPLY_CODE");
            sb.AppendLine(",spa.SHIP_ID");
            sb.AppendLine(",s.SHIP_NAME");
            sb.AppendLine(",spa.PURCHASE_APPLY_DATE");
            sb.AppendLine(",spa.STATE");
            sb.AppendLine(" ,case spa.STATE ");
            sb.AppendLine("  when '0' then '未填写完毕'");
            sb.AppendLine("  when '1' then '等待部门长审核'");
            sb.AppendLine("  when '2' then '等待船长确认'");
            sb.AppendLine("  when '3' then '等待岸端机务主管审批'");
            sb.AppendLine("  when '4' then '等待岸端机务经理审批'");
            sb.AppendLine("  when '5' then '等待船管总经理审批'");
            sb.AppendLine("  when '6' then '审核通过'");
            sb.AppendLine("  when '7' then '取消'");
            sb.AppendLine("  when '8' then '被打回'");
            sb.AppendLine("  when '9' then '已订购'");
            sb.AppendLine("  end as STATE_NAME");
            sb.AppendLine(",spa.COMPONENT_UNIT_ID");
            sb.AppendLine(",cu.COMP_CHINESE_NAME");
            sb.AppendLine(",dbo.F_Get_Comp_Full_name(spa.COMPONENT_UNIT_ID,1) COMP_FULL_NAME");
            sb.AppendLine(",cu.COMPONENT_TYPE_ID");
            sb.AppendLine(",spa.PURCHASE_APPLY_PERSON");
            sb.AppendLine(",spa.PURCHASE_APPLY_PERSON_POSTID");
            sb.AppendLine(",bh.HEADSHIP_NAME");
            sb.AppendLine(",bh.ISLANDPOST");
            sb.AppendLine(",spa.DEPART_ID");
            sb.AppendLine(",d.DEPARTNAME");
            sb.AppendLine(",spa.ISCOMPLETE");
            sb.AppendLine(" ,case spa.ISCOMPLETE ");
            sb.AppendLine("  when '0' then '未填写完毕'");
            sb.AppendLine("  when '1' then '填写完毕'");
            sb.AppendLine("  end as ISCOMPLETE_NAME");
            sb.AppendLine(",spa.SHIP_LEADER_CHECKER");
            sb.AppendLine(",spa.SHIP_LEADER_CHECKDATE");
            sb.AppendLine(",spa.SHIP_BOSS_CHECKER");
            sb.AppendLine(",spa.SHIP_BOSS_CHECKDATE");
            sb.AppendLine(",spa.LANDCHECKER");
            sb.AppendLine(",spa.CHECKDATE");
            sb.AppendLine(",spa.REMARK");
            sb.AppendLine(" from T_SPARE_PURCHASE_APPLY spa");
            sb.AppendLine(" inner join T_SHIP s on s.SHIP_ID=spa.SHIP_ID ");
            if (CommonOperation.ConstParameter.IsLandVersion)
                sb.AppendLine("  inner join T_USER_SHIP us on us.ship_id=spa.SHIP_ID and us.userid = '" + CommonOperation.ConstParameter.UserId + "'");
            sb.AppendLine(" inner join T_BASE_HEADSHIP bh on bh.SHIP_HEADSHIP_ID=spa.PURCHASE_APPLY_PERSON_POSTID ");
            sb.AppendLine(" inner join T_DEPARTMENT d on d.DEPARTMENTID=spa.DEPART_ID ");
            sb.AppendLine(" left join T_COMPONENT_UNIT cu on cu.COMPONENT_UNIT_ID=spa.COMPONENT_UNIT_ID ");
            sb.AppendLine(" where spa.STATE >= 3 ");
            if (!string.IsNullOrEmpty(SHIP_ID))
                sb.AppendLine(" and spa.SHIP_ID='" + SHIP_ID + "'");
            if (!string.IsNullOrEmpty(APPLY_DATE))
            {
                sb.AppendLine(" and spa.PURCHASE_APPLY_DATE >='" + APPLY_DATE + "'");
            }
            sb.AppendLine(" order by spa.PURCHASE_APPLY_DATE desc");
            
            DataTable dt;
            string err;
            if (dbAccess.GetDataTable(sb.ToString(), out dt, out err))
            {
                return dt;
            }
            else
            {
                throw new Exception(err);
            }
        } 
        #endregion

        /// <summary>
        /// 处理单号（组成规则：B船舶编号+两位年份+两位月份+序列号(三位))
        /// </summary>
        /// <param name="shipId">船舶Id</param>
        /// <returns>返回加工好的物资出入库单编号</returns>
        public string GetPurchaseApplyCode(string shipId)
        {
            string err = ""; //错误信息返回参数.
            string sSql = "";           //SQL查询语句.
            string sShipCode = "";      //船舶编号.
            string sMaxNumb = "";       //出入库单最大序列号（字符型）.
            int maxNumb = 0;            //出入库单最大序列号（数值型）.
            string applyCode = "";      //出入库单.

            //1.取船舶编号.
            sSql = "select ship_code from t_ship where ship_Id = '" + shipId + "'";
            dbAccess.GetString(sSql, out sShipCode, out err);
            if (sShipCode.Length == 0) sShipCode = "NoShip";

            //2.取两位年份两位月份.
            string theYear = "";
            theYear = DateTime.Now.ToString("yyMM");

            //3.取最大序列号（取t_spare_apply与t_material_apply中的最大序列号）.

            sSql = "select max(PURCHASE_APPLY_CODE) from (";
            sSql += "select cast(right(PURCHASE_APPLY_CODE,3) as int) as PURCHASE_APPLY_CODE from T_SPARE_PURCHASE_APPLY where ship_id = '" + shipId + "') a";
            dbAccess.GetString(sSql, out sMaxNumb, out err);
            if (sMaxNumb == "") sMaxNumb = "0";
            maxNumb = int.Parse(sMaxNumb) + 1;
            string difference = CommonOperation.ConstParameter.IsLandVersion ? "L" : "S";
            if (maxNumb < 1000)
            {
                applyCode = difference + sShipCode + "-" + theYear + string.Format("{0:000}", maxNumb);
            }
            else
            {
                applyCode = difference + sShipCode + "-" + theYear + maxNumb.ToString();
            }
            return applyCode;
        }

    }
}
