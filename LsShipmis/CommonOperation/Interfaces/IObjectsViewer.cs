using System;
using System.Collections.Generic;
using System.Text;
using CommonOperation.BaseClass;

namespace CommonOperation.Interfaces
{
    public interface IObjectsViewer
    {
        void ReloadData();
        CommonClass GetObject(int rowNumber);
    }
}
