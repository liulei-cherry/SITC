using System;
using System.Collections.Generic;
using System.Text;
using BaseInfo.DataAccess;
using CommonOperation.BaseClass;
using ItemsManage.Services;
namespace ItemsManage.DataObject
{
    partial class ComponentType : CommonClass
    {
        public override string GetId()
        {
            return _cOMPONENT_TYPE_ID;
            //throw new Exception("The method or operation is not implemented.");
        }

        public override string GetTypeName()
        {
            return "component_type";
        }

        public override bool Update(out string err)
        {
            return ComponentTypeService.Instance.saveUnit(this, out err);
        }

        public override bool Delete(out string err)
        {
            return ComponentTypeService.Instance.deleteUnit(this, out err);
        }

        public override void FillThisObject()
        {
            if (thePrincipalPost == null)
            {
                if (string.IsNullOrEmpty(_hEADSHIP))
                {
                    thePrincipalPost = new BaseInfo.Objects.Post();
                    thePrincipalPost.IsWrong = false;
                }
                else if (_hEADSHIP.Length == 36)
                {
                    string err;
                    thePrincipalPost = PostService.Instance.getObject(_hEADSHIP, out err);
                }
                else
                {
                    thePrincipalPost = new BaseInfo.Objects.Post();
                    thePrincipalPost.IsWrong = true;
                }
            }
        }
    }
}
