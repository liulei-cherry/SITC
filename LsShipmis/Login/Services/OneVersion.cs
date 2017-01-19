/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有

 * 文 件 名：OneVersion.cs
 * 创 建 人：徐正本

 * 创建时间：2011/12/3
 * 标    题：实体类

 * 功能描述：T_AutoUpdateVersion数据实体类

 * 修 改 人：
 * 修改时间：

 * 修改内容：

 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Services
{
    /// <summary>
    ///T_AutoUpdateVersion数据实体.
    /// </summary>
    ///[Serializable]
    public partial class OneVersion 
    {
        #region 构造函数

        ///<summary> 
        ///
        ///</summary>
        public OneVersion()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public OneVersion
        (
            string autoUpdateID,
            string versionNo,
            decimal isValid,
            DateTime effectiveStartTime,
            DateTime createDate,
            string oBJECT_ID
        )
        {
            this.AutoUpdateID = autoUpdateID;
            this.VersionNo = versionNo;
            this.IsValid = isValid;
            this.EffectiveStartTime = effectiveStartTime;
            this.CreateDate = createDate;
            this.OBJECT_ID = oBJECT_ID;

        }
        #endregion

        #region 公共属性


        ///<summary>
        ///主键.
        ///</summary>
        public string AutoUpdateID { get; set; }

        ///<summary>
        ///版本号(123.456.789.012)也可以4位以上.
        ///</summary>
        public string VersionNo { get; set; }

        ///<summary>
        ///是否有效1有效0无效.
        ///</summary>
        public decimal IsValid { get; set; }

        ///<summary>
        ///有效开启时间（目前未开启）.
        ///</summary>
        public DateTime EffectiveStartTime { get; set; }

        ///<summary>
        ///创建时间.
        ///</summary>
        public DateTime CreateDate { get; set; }

        ///<summary>
        ///大文件ID即XML存储ID
        ///</summary>
        public string OBJECT_ID { get; set; }

        #endregion

        public string GetId()
        {
            return this.AutoUpdateID;
        }

        public bool Update(out string err)
        {
            return OneVersionService.Instance.saveUnit(this, out err);
        }

        public bool Delete(out string err)
        {
            return OneVersionService.Instance.deleteUnit(this, out err);
        }

        public void FillThisObject()
        {

        }
    }
}
