/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：T_WorkFlowServiceLEx.cs
 * 创 建 人：李景育
 * 创建时间：2009-09-27
 * 标    题：流程管理操作业务类
 * 功能描述：实现流程管理的各种操作的业务类
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BaseInfo.Objects;
using ShipMisZHJ_WorkFlow.BusinessClasses;

namespace ShipMisZHJ_WorkFlow.Services
{

    /// <summary>
    /// 流程管理操作业务类.
    /// 这里的工作流处理仅支持串行的，同岗位不会出现两次的简单流程。
    /// </summary>
    public partial class T_WorkFlowService
    {
        /// <summary>
        /// 根据工作流id，得到工作流岗位列表（数组）
        /// </summary>
        /// <param name="workflowId">工作流id</param>
        /// <returns>岗位数组</returns>
        private string[] GetWorkflowPostList(string workflowId)
        {
            string sSql = "select WorkFlow from T_WorkFlow where WorkFlow_Id = '" + workflowId + "'";
            string workflowFullPostList = dbAccess.GetString(sSql);
            return workflowFullPostList.Split(new char[] { ',' });
        }

        /// <summary>
        /// 根据流程名称获得流程ID
        /// </summary>
        /// <param name="workFlowObjectName"></param>
        /// <returns></returns>
        public string GetWorkFlowIdByWorkfolwName(string workFlowObjectName)
        {
            string sSql = "";               //查询数据所需的SQL语句. 

            //Select语句加工部分.
            sSql += "select WorkFlow_Id ";
            sSql += "from T_WorkFlow_Entrance a ";
            sSql += "inner join T_WorkFlow_Object b on a.WorkFlow_Object_Id = b.WorkFlow_Object_Id ";
            sSql += "where b.WorkFlow_Object_Name = '" + workFlowObjectName + "' ";

            return dbAccess.GetString(sSql);
        }

        /// <summary>
        /// 取得流程workFlowId中第一个审核的岗位类型.
        /// </summary>
        /// <param name="workFlowId">流程Id</param>
        /// <returns>返回第一个审核的岗位Id</returns>
        public string GetFirstCheckPostType(string workFlowId)
        {
            return GetWorkflowPostList(workFlowId)[0];
        }

        /// <summary>
        /// 取得流程中当前审核岗位Id的上一个审核岗位Id
        /// </summary>
        /// <param name="checkedId">审核业务Id</param>
        /// <returns>返回上一个审核岗位Id</returns>
        public string GetPreCheckPostType(string checkedId)
        {
            string sMidErrMessage = "";     //错误信息返回参数.  
            T_Checked thisCheck = T_CheckedService.Instance.GetObject(checkedId, out sMidErrMessage);
            return GetPreCheckPostType(thisCheck.WorkFlow_Id, thisCheck.CurrentPostName);
        }

        /// <summary>
        /// 得到审批流程的上一个节点信息，如果没有，则返回空
        /// </summary>
        /// <param name="workFlowId">工作流id</param>
        /// <param name="checkPost">当前检验岗位（一个岗位在流程中只能在一个位置）</param>
        /// <returns>上一个岗位名</returns>
        public string GetPreCheckPostType(string workFlowId, string checkPost)
        {
            string[] checkPosts = GetWorkflowPostList(workFlowId);

            if (string.IsNullOrEmpty(checkPost))
            {
                return checkPosts[checkPosts.Length - 1];
            }

            //取得流程中当前审核岗位Id的下一个审核岗位Id
            for (int i = 1; i < checkPosts.Length; i++)
            {
                if (checkPosts[i] == checkPost)
                {
                    return checkPosts[i - 1];
                }
            }
            // 本来应该 throw new Exception("没有办法找到上一个岗位，可能是流程已经结束，或流程刚刚开始");但考虑实际情况，返回空
            return "";
        }
        
        /// <summary>
        /// 取得流程中当前审核岗位Id的下一个审核岗位类型(重载)
        /// </summary>
        /// <param name="workFlowId">工作流id</param>
        /// <param name="checkPost">当前检验岗位（一个岗位在流程中只能在一个位置）</param>
        /// <returns>下一个岗位名</returns>
        public string GetNextCheckPost(string workFlowId, string checkPost)
        {
            string[] checkPosts = GetWorkflowPostList(workFlowId);

            //取得流程中当前审核岗位Id的下一个审核岗位Id
            for (int i = 0; i < checkPosts.Length; i++)
            {
                if (checkPosts[i] == checkPost)
                {
                    //当时最后一个匹配上，任务流程结束返回空，否则返回下一个
                    if (i != checkPosts.Length - 1) return checkPosts[i + 1];
                    else return "";
                }
            }
            //当前岗位完全没有找到，实际是流程的问题，本应该报异常，但实际流程多作为发起流程，继续从头来。
            return checkPosts[0];
        }

        /// <summary>
        /// 根据业务id得到其检验流程id
        /// </summary>
        public string GetCheckIdByBusinessID(string business_id)
        {
            sql = string.Format(@" select  t1.Checked_Id
from T_Checked t1
where upper(t1.Business_Object_Id)='{0}'", business_id.ToUpper());
            return dbAccess.GetString(sql);
        }

        /// <summary>
        /// 私有方法：
        /// 根据相关业务id，当前工作流信息、当前状态等，得到数据库操作语法，
        /// 目的是更新T_Checked表，把当前业务更新或插入进去。
        /// </summary>
        /// <param name="shipId">船舶id</param>
        /// <param name="businessObjectId">业务id</param>
        /// <param name="checkedId">检验id，如有</param>
        /// <param name="currentWorkFlowId">当前工作流id</param>
        /// <param name="newState">最新状态</param>
        /// <param name="postName">处理人</param>
        /// <returns>sql语句</returns>
        private string GetSqlOfInsertOrUpdateCheckedInfo(string shipId, string businessObjectId, ref string checkedId, string currentWorkFlowId, int newState, string postName)
        {
            if (!string.IsNullOrEmpty(checkedId))
            {
                return GetSqlOfUpdateCheckedInfo(checkedId, newState, postName);
            }
            else
            {
                //添加审核主表信息.
                checkedId = Guid.NewGuid().ToString();//当前是提交新业务.
                return string.Format(@"insert into T_Checked(Checked_Id, WorkFlow_Id, Current_WorkFlow_Id,
Current_PostId, Current_State, Business_Object_Id,Ship_Id)
values('{0}','{1}','{1}','{2}',{3},'{4}','{5}')",
                checkedId, currentWorkFlowId, postName, newState.ToString(), businessObjectId, shipId);
            }
        }

        /// <summary>
        /// 私有方法：
        /// 得到更新语法，具体描述见上一个函数
        /// </summary>
        /// <param name="checkedId">检验id，如有</param>
        /// <param name="newState">最新状态</param>
        /// <param name="postName">处理人</param>
        /// <returns>更新sql语句</returns>
        private string GetSqlOfUpdateCheckedInfo(string checkedId, int newState, string postName)
        {
            return "update T_Checked set Current_PostId = '" + postName + "',  Current_State = " + newState + " where Checked_Id = '" + checkedId + "'";
        }
        /// <summary>
        /// 增加审核明细（返回字符串）
        /// </summary> 
        /// <param name="checkedId">检查表id</param>
        /// <param name="checkor">审核人</param>
        /// <param name="post">岗位</param>
        /// <param name="remark">审批内容</param>
        /// <param name="shipId">船舶id</param>
        /// <returns>插入语句</returns>
        public string GetSqlOfAddCheckDetail(string checkedId, string checkor, string post, string remark, string shipId)
        {
            return string.Format(@"insert into T_Checked_Detail(Checked_Detail_Id, Checked_Id, PostId, Checkor, CheckDate, Remark, Ship_Id)
values(newid(),'{0}','{1}','{2}',getdate(),'{3}','{4}')", checkedId, post, checkor, dbOperation.ReplaceSqlKeyStr(remark), shipId);
        }

        /// <summary>
        /// 私有方法：
        /// 执行操作，实际是把实际操作反应到T_Check表和T_check_detail表上。
        /// 此操作并不影响实际业务表，业务表的具体状态修改在之后才修改。
        /// </summary>
        /// <param name="shipId">船舶id</param>
        /// <param name="businessObjectId">业务id</param>
        /// <param name="workFlowId">工作流id</param>
        /// <param name="nextCheckPost">下一个岗位</param>
        /// <param name="checkor">审批人</param>
        /// <param name="state">传入状态：1同意，2不同意，3同意并结束流程，4打回到根</param>
        /// <param name="remark">审批内容</param>
        /// <param name="err">错误信息</param>
        /// <returns>是否成功</returns>
        private bool DoTheBusiness(string shipId, string businessObjectId, string workFlowId, string nextCheckPost, string checkor, int state, string remark, out string err)
        {
            List<string> lstSqlOpt = new List<string>(); //包含操作语句的List泛型集合.  
            //添加主表
            string checkedId = GetCheckIdByBusinessID(businessObjectId);
            lstSqlOpt.Add(GetSqlOfInsertOrUpdateCheckedInfo(shipId, businessObjectId, ref checkedId, workFlowId, state, nextCheckPost));
            //添加审核明细表信息.
            lstSqlOpt.Add(GetSqlOfAddCheckDetail(checkedId, checkor, CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME, remark, shipId));
            //调用dbAccess的execSql执行lstSqlOpt中的所有的操作语句.
            return dbAccess.ExecSql(lstSqlOpt, out err);
        }

        /// <summary>
        /// 内部方法，不可被外部dll直接调用
        /// 同意操作最终执行的方法
        /// </summary>
        /// <param name="shipId">船舶id</param>
        /// <param name="businessObjectId">业务对象id</param>
        /// <param name="workFlowId">工作流id</param>
        /// <param name="endFlow">是否结束流程</param>
        /// <param name="sMidErrMessage">错误信息</param>
        /// <param name="remark">审批内容</param>
        /// <returns>返回状态：1，同意；3，同意并结束流程；-1，异常</returns>
        internal int AgreeBusinessByWorkflowId(string shipId, string businessObjectId, string workFlowId, bool endFlow, out string sMidErrMessage, string remark = "")
        {
            string nextCheckPost = "";    //当前审核岗位Id对应的下一个审核岗位.
            int state = -1;
            string checkor = CommonOperation.ConstParameter.UserName;  //审核人.

            nextCheckPost = this.GetNextCheckPost(workFlowId, CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME);
            if (string.IsNullOrEmpty(nextCheckPost)) endFlow = true;
            if (string.IsNullOrEmpty(remark)) remark = (endFlow ? "提交并完成审核" : "提交");
            if (endFlow) nextCheckPost = "";
            state = (endFlow ? 3 : 1);
            if (DoTheBusiness(shipId, businessObjectId, workFlowId, nextCheckPost, checkor, state, remark, out sMidErrMessage))
                return state;
            else return -1;
        }

        /// <summary>
        /// 同意某流程
        /// </summary>
        /// <param name="shipId">船舶id</param>
        /// <param name="businessObjectId">业务id，未必是主键，只要唯一即可</param>
        /// <param name="workFlowObjectName">流程名</param>
        /// <param name="endFlow">是否流程提前完结</param>
        /// <param name="sMidErrMessage">错误信息</param>
        /// <param name="remark">备注</param>
        /// <returns>-1执行失败，1，正常执行一步，3，流程完毕</returns>
        public int AgreeBusiness(string shipId, string businessObjectId, string workFlowObjectName, bool endFlow, out string sMidErrMessage, string remark = "")
        {
            string workFlowId = this.GetWorkFlowIdByWorkfolwName(workFlowObjectName);
            if (string.IsNullOrEmpty(workFlowId))
            {
                sMidErrMessage = "当前登录用户所在的部门没有定义[" + workFlowObjectName + "]的流程！";
                return -1;
            }
            return AgreeBusinessByWorkflowId(shipId, businessObjectId, this.GetWorkFlowIdByWorkfolwName(workFlowObjectName), endFlow, out sMidErrMessage, remark);
        }

        /// <summary>
        /// 拒绝某流程
        /// </summary>
        /// <param name="shipId">船舶id</param>
        /// <param name="businessObjectId">业务id，未必是主键，只要唯一即可</param>
        /// <param name="workFlowObjectName">流程名</param>
        /// <param name="rejectToBegin">是否流程打回到根（发起者）</param>
        /// <param name="sMidErrMessage">错误信息</param>
        /// <param name="remark">备注</param>
        /// <returns>-1执行失败，2，打回一级，4，打回到根</returns>
        public int RejectBusiness(string shipId, string businessObjectId, string workFlowObjectName, bool rejectToBegin, out string sMidErrMessage, string remark = "")
        {
            string workFlowId = this.GetWorkFlowIdByWorkfolwName(workFlowObjectName);
            if (string.IsNullOrEmpty(workFlowId))
            {
                sMidErrMessage = "当前登录用户所在的部门没有定义[" + workFlowObjectName + "]的流程！";
                return -1;
            }
            return RejectBusinessByWorkflowId(shipId, businessObjectId, this.GetWorkFlowIdByWorkfolwName(workFlowObjectName), rejectToBegin, out sMidErrMessage, remark);
        }


        /// <summary>
        /// 内部方法，不可被外部dll直接调用
        /// 不同意操作最终执行的方法
        /// </summary>
        /// <param name="shipId">船舶id</param>
        /// <param name="businessObjectId">业务对象id</param>
        /// <param name="workFlowId">工作流id</param> 
        /// <param name="rejectToBegin">是否流程打回到根（发起者）</param>
        /// <param name="sMidErrMessage">错误信息</param>
        /// <param name="remark">备注</param>
        /// <returns>-1执行失败，2，打回一级，4，打回到根</returns>
        internal int RejectBusinessByWorkflowId(string shipId, string businessObjectId, string workFlowId, bool rejectToBegin, out string sMidErrMessage, string remark = "")
        {
            string preCheckPost;    //当前审核岗位Id对应的下一个审核岗位.
            int state = -1;
            string checkor = CommonOperation.ConstParameter.UserName;  //审核人.

            if (rejectToBegin) preCheckPost = GetFirstCheckPostType(workFlowId);
            else preCheckPost = this.GetPreCheckPostType(workFlowId, CommonOperation.ConstParameter.LoginUserInfo.POSTTYPENAME);
            state = (rejectToBegin ? 4 : 2);
            if (DoTheBusiness(shipId, businessObjectId, workFlowId, preCheckPost, checkor, state, remark, out sMidErrMessage))
                return state;
            else return -1;
        }
    }
}