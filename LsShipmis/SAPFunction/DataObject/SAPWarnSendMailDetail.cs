using System;
using System.Collections.Generic;
using System.Text;

namespace SAPFunction.DataObject
{
    public class SAPWarnSendMailDetail
    {
        #region 构造函数
        ///<summary> 
        ///
        ///</summary>
        public SAPWarnSendMailDetail()
        {
        }
        ///<summary>
        ///
        ///</summary>
        public SAPWarnSendMailDetail
        (
            string pSendMailId,
            string pSendMailDetailId,
            string Start,
            string UserNumb,
            string UserName,
            string TransFerMail
        )
        {
            this.SEND_MAIL_ID = pSendMailId;
            this.SEND_MAIL_DETAIL_ID = pSendMailDetailId;
            this.START = Start;
            this.USER_NUMB = UserNumb;
            this.USER_NAME = UserName;
            this.TRANS_FER_MAIL = TransFerMail;

        }
        #endregion

        #region 公共属性
        ///<summary>
        /// 邮件报警明细ID
        ///</summary>
        public string SEND_MAIL_DETAIL_ID { get; set; }

        ///<summary>
        ///邮件报警ID
        ///</summary>
        public string SEND_MAIL_ID { get; set; }

        ///<summary>
        ///是否启动
        ///</summary>
        public string START { get; set; }

        ///<summary>
        ///用户序列号
        ///</summary>
        public string USER_NUMB { get; set; }

        ///<summary>
        ///用户名称
        ///</summary>
        public string USER_NAME { get; set; }

        ///<summary>
        ///用户报警邮件
        ///</summary>
        public string TRANS_FER_MAIL { get; set; }
        #endregion
    }
}
