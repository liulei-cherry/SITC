using System;
using System.Collections.Generic;
using System.Text;

namespace CommonOperation.Interfaces
{
    public interface IBandingFiles
    {
        /// <summary>
        /// 得到要绑定文件的对象的信息.
        /// </summary>
        /// <param name="itemid">对象id</param>
        /// <param name="itemType">对象类别</param>
        /// <returns>是否成功,如果对象无效则无法继续帮顶</returns>
        bool GetBandingItemMessage(out string itemid, out string itemType);
    }
}
