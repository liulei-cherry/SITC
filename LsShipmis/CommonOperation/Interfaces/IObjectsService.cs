using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass; 

namespace CommonOperation.Interfaces
{
    public interface IObjectsService
    {
        CommonClass GetOneObjectById(string id);
        Dictionary<string,string> GetObjectDisplaySetting();
    }
}
