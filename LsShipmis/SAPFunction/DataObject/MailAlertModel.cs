using CommonOperation.BaseClass;
using SAPFunction.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAPFunction.DataObject
{
    public class MailAlertModel
    {


        ///<summary>
        /// 邮件报警的id
        ///</summary>
        public string MailAlertId { get; set; }

        ///<summary>
        ///站点名称
        ///</summary>
        public string MailAlertSiteName { get; set; }

        ///<summary>
        ///SMTP用户名
        ///</summary>
        public string SmtpUserName { get; set; }

        ///<summary>
        ///SMTP服务器
        ///</summary>
        public string SmtpServer { get; set; }

        ///<summary>
        ///端口号
        ///</summary>
        public int SSLPort { get; set; }

        ///<summary>
        ///邮箱密码
        ///</summary>
        public string MailPass { get; set; }




    }

    public class MailAlertDetailModel
    {
        ///<summary>
        /// 邮件报警的id
        ///</summary>
        public string MailAlertId { get; set; }

        ///<summary>
        ///主键
        ///</summary>
        public string MailAlertDetailId { get; set; }

        ///<summary>
        ///S是否发送
        ///</summary>
        public int IsSend { get; set; }

        ///<summary>
        ///排序号
        ///</summary>
        public string MailAlertSendIndex { get; set; }

        ///<summary>
        ///称呼人名船名等
        ///</summary>
        public string MailAlertSendTitle { get; set; }

        ///<summary>
        ///To的地址
        ///</summary>
        public string MailAlertAddress { get; set; }

        ///<summary>
        ///报警类型1SAP2其他
        ///</summary>
        public int MailAlertType { get; set; }
    }
}
