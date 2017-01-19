using System;
using System.Collections.Generic;
using System.Text;

namespace ShipMisZHJ_WorkFlow.BusinessClasses
{
    public class CheckObj
    { 
        public CheckObj(string businessId, string objBusinessName, string objBusinessDetail)
        { 
            ObjBusinessId = businessId;
            ObjBusinessName = objBusinessName;
            ObjBusinessDetail = objBusinessDetail; 
        }

        public string ObjBusinessId{ private set;get;}//check对象的业务主键，未必是char(36)
        public string ObjBusinessName { private set; get; }
        public string ObjBusinessDetail { private set; get; }
    }
}
