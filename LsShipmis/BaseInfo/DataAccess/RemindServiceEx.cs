using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BaseInfo.Objects;

namespace BaseInfo.DataAccess
{
    public partial class RemindService
    {
        /// <summary>
        /// 得到  T_REMIND 所有数据信息.
        /// </summary>
        /// <returns>T_REMIND DataTable</returns>
        public bool GetInfoByCondition(int REMIND_TYPE, out DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("r.ID");
            sb.AppendLine(",r.BUSINESSID");
            sb.AppendLine(",r.REMIND_TYPE");
            sb.AppendLine(",r.POST_TYPE");
            sb.AppendLine(",r.SHIP_ID");
            sb.AppendLine("  from T_REMIND r");
            sb.AppendLine(" inner join T_USER_SHIP us on us.ship_id=r.ship_id  and us.userid = '" + CommonOperation.ConstParameter.UserId + "'");
            sb.AppendLine(" where 1=1");
            sb.AppendLine(" and r.POST_TYPE='" + CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME + "'");
            sb.AppendLine(" and r.REMIND_TYPE=" + REMIND_TYPE);
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }

        /// <summary>
        /// 得到  T_REMIND 所有数据信息.不按照船舶
        /// </summary>
        /// <returns>T_REMIND DataTable</returns>
        public bool GetByConditionIgnoreShip(int REMIND_TYPE, out DataTable dt, out string err)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("select	");
            sb.AppendLine("r.ID");
            sb.AppendLine(",r.BUSINESSID");
            sb.AppendLine(",r.REMIND_TYPE");
            sb.AppendLine(",r.POST_TYPE");
            sb.AppendLine(",r.SHIP_ID");
            sb.AppendLine("  from T_REMIND r");
            sb.AppendLine(" where 1=1");
            sb.AppendLine(" and r.POST_TYPE='" + CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME + "'");
            sb.AppendLine(" and r.REMIND_TYPE=" + REMIND_TYPE);
            return dbAccess.GetDataTable(sb.ToString(), out dt, out err);
        }
             
        /// <summary>
        /// 添加一次性报警(自动排除当前审批人岗位,添加其他岗位提醒)
        /// </summary>
        /// <param name="REMIND_TYPE"></param>
        /// <param name="EXCLUDE_POST_TYPE"></param>
        /// <param name="SHIP_ID"></param>
        /// <param name="BUSINESSID"></param>
        public void CreateRemindOnce(int REMIND_TYPE, string SHIP_ID, string BUSINESSID)
        {
            string err;
            List<string> postTypeList = new List<string>();
            if (REMIND_TYPE < 6)
            {
                if (postTypeList.Count == 0)
                {
                    postTypeList.Add("机务主管岗位");
                }
            }
            else if (REMIND_TYPE == 6)
            {
                postTypeList.Add("机务主管岗位");
            }
            else if (REMIND_TYPE == 7)
            {
                postTypeList.Add("机务主管岗位");
            }
            else if (REMIND_TYPE == 8)
            {
                postTypeList.Add("机务主管岗位");
                postTypeList.Add("机务经理岗位");
                postTypeList.Add("总经理岗位");
            }
            postTypeList.Remove(CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME);
            foreach (string item in postTypeList)
            {
                Remind remind = new Remind();
                remind.BUSINESSID = BUSINESSID;
                remind.POST_TYPE = item;
                remind.REMIND_TYPE = REMIND_TYPE;
                remind.SHIP_ID = SHIP_ID;
                remind.Update(out err);
            }
        }

        /// <summary>
        /// 根据业务码,删除数据表T_REMIND中的一条记录.
        /// </summary>
        public bool DeleteUnitByBusinessid(string BUSINESSID)
        {
            string err;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("delete from T_REMIND");
            sb.AppendLine("where 1=1");
            sb.AppendLine("and upper(BUSINESSID)='" + BUSINESSID.ToUpper() + "'");
            sb.AppendLine("and post_type='" + CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME + "'");
            sb.AppendLine("and ship_id in (select ship_id from T_USER_SHIP where userid = '" + CommonOperation.ConstParameter.UserId + "')");
            return dbAccess.ExecSql(sb.ToString(), out err);
        }
        /// <summary>
        /// 根据报警类型删除数据.
        /// </summary>
        public bool DeleteByType(int REMIND_TYPE)
        {
            string err;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("delete from T_REMIND");
            sb.AppendLine("where 1=1");
            sb.AppendLine("and REMIND_TYPE=" + REMIND_TYPE);
            sb.AppendLine("and post_type='" + CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME + "'");
            sb.AppendLine("and ship_id in (select ship_id from T_USER_SHIP where userid = '" + CommonOperation.ConstParameter.UserId + "')");
            return dbAccess.ExecSql(sb.ToString(), out err);
        }
    }
}
