using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;
using CommonOperation.Interfaces;

namespace BaseInfo.BaseClass
{
    public abstract class Task:CommonClass
    {
        protected string taskName;
        protected string taskDetail;
        static private Dictionary<int, string> taskState = new Dictionary<int,string> ();
        static private List<int> notFinishList = new List<int>();
        protected int nowState;
        protected DateTime taskPlanDate;
        protected DateTime taskPlanStartDate;
        protected DateTime taskPlanEndDate;
        protected string confirmPerson;
        protected delegate string TaskMoreDetail();
        protected TaskMoreDetail taskMoreDetail;
        protected bool needAlert;

        public bool NeedAlert
        {
            get { return needAlert; }
            set { needAlert = value; }
        }
        protected string whyAlert;

        public string WhyAlert
        {
            get { return whyAlert; }
            set { whyAlert = value; }
        }

        #region 属性
        public string TaskName
        {
            get { return taskName; }
            set { taskName = value; }
        }

        public string TaskDetail
        {
            get 
            { 
                if(taskMoreDetail != null)
                {
                    return taskMoreDetail();
                }
                else
                {
                    return taskDetail; 
                }
            }
            set { taskDetail = value; }
        }
 
        public DateTime TaskPlanDate
        {
            get { return taskPlanDate; }
            set { taskPlanDate = value; }
        }

        public DateTime TaskPlanStartDate
        {
            get { return taskPlanStartDate; }
            set { taskPlanStartDate = value; }
        }

        public DateTime TaskPlanEndDate
        {
            get { return taskPlanEndDate; }
            set { taskPlanEndDate = value; }
        }

        public int NowState
        {
            set
            {
                nowState = value;
            }
            get
            {
                return nowState;
            }
        }
        public string ConfirmPerson
        {
            get { return confirmPerson; }
            set { confirmPerson = value; }
        }
        
        #endregion

        public Task()
        {
            InitStates();
        }
        public  static void InitState(int state,string stateName,bool isFinish)
        {
            if (!taskState.ContainsKey(state))
            {
                taskState.Add(state, stateName);
            }
            else
            {
                taskState[state] = stateName;
            }
            if (!isFinish && !notFinishList.Contains(state))
            {
                notFinishList.Add(state);
            }
        }
        public string StateName
        { 
            get
            {
                return getState ();
            }
        }
        public string getState()
        {
            return getState(nowState);
        }
        public string getState(int state)
        {            
            if(taskState.ContainsKey(state ))
            {
                return taskState[state];
            }
            else
            {
                return "未配置的状态项.当前状态值为"+ state.ToString () ;
            }
        }
        public string TaskType
        {
            get
            {
                return GetTaskType();
            }
        }
        //public abstract void InitStates();
        public static void InitStates()
        {
            InitState(1, "新任务", false);
            InitState(2, "已完成", true);
            InitState(3, "已取消", true);
        }
        public void setFinishState()
        {
            nowState = 2;
        }
        public void setDissolveState()
        {
            nowState = 3;
        }
        public void setNewState()
        {
            nowState = 1;
        }
        public void setContactState()
        {
            nowState = 4;
        }
        public abstract string GetTaskType();
        public static string GetNotFinishStateList()
        {
            string re = "";           
            foreach (int i in notFinishList)
            {
                if (re.Length != 0) re += ",";
                re += i.ToString();
            }
            return re;
        }

        /// <summary>
        /// 重新设置数据是否需要报警.
        /// </summary>
        /// <returns>是否有alert</returns>
        public abstract bool ResetAlert();
    }
}
