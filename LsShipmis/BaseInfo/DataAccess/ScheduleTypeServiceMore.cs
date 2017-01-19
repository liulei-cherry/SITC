using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.Interfaces;
using BaseInfo.Objects;

namespace BaseInfo.DataAccess
{
    partial class ScheduleTypeService : IObjectsService
    {
        #region IObjectsService 成员

        public CommonOperation.BaseClass.CommonClass GetOneObjectById(string id)
        {
            //throw new Exception("The method or operation is not implemented.");
            string err;
            return getObject(id, out err);
        }

        public Dictionary<string, string> GetObjectDisplaySetting()
        {
            //throw new Exception("The method or operation is not implemented.");
            Dictionary<string, string> reValue = new Dictionary<string, string>();

            //reValue.Add("SCHEDULETYPEID", "类型");
            reValue.Add("TYPENAME", "类型名称");
            reValue.Add("DETAIL", "详细描述");
            reValue.Add("ISWORKING", "是否计算可用率");
            reValue.Add("SORT", "排序");
            return reValue;
        }

        #endregion
    }
}
