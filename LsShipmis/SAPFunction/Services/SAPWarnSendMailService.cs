using CommonOperation.Functions;
using CommonOperation.Interfaces;
using SAPFunction.DataObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SAPFunction.Services
{
    public class SAPWarnSendMailService
    {
        private IDBAccess dbAccess = InterfaceInstantiation.NewADbAccess();
        private IDBOperation dbOperation = InterfaceInstantiation.NewADBOperation();

        #region 构造函数
        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static SAPWarnSendMailService instance = new SAPWarnSendMailService();
        public static SAPWarnSendMailService Instance
        {
            get
            {
                if (null == instance)
                {
                    SAPWarnSendMailService.instance = new SAPWarnSendMailService();
                }
                return SAPWarnSendMailService.instance;
            }
        }
        private SAPWarnSendMailService() { }
        #endregion

        #region 读取邮件配置 zhangy-2013-7-26
        /// <summary>
        /// 读取邮件配置
        /// </summary>
        /// <param name="errMessage"></param>
        /// <returns></returns>
        public DataTable SelectMailAlertTable(out String errMessage)
        {
            String strSql = String.Format(@"SELECT * FROM T_MAIL_ALERT");
            return dbAccess.GetDataTable(strSql, out errMessage);
        }

        #endregion

        #region 读取SAP报警字表明细 zhangy-2013-7-26
        public DataTable SelectMailAlertDetailTable(Int32 mailAlertType, out String errMessage)
        {
            String strSql = String.Format(@"SELECT MailAlertDetailId, MailAlertId, IsSend as start, MailAlertSendIndex, MailAlertSendTitle, MailAlertAddress, MailAlertType 
FROM T_MAIL_ALERT_DETAIL 
WHERE MailAlertType={0}
order by MailAlertSendIndex", mailAlertType);

            DataTable DtSource = dbAccess.GetDataTable(strSql, out errMessage);
            return DtSource;

        }
        #endregion

        #region 保存邮件配置 zhangy-2013-7-26
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="madmList"></param>
        /// <returns></returns>
        public Boolean SaveMailAlertTable(MailAlertModel model, List<MailAlertDetailModel> madmList, out string errMessage)
        {
            try
            {


                String strSql = String.Format(@"SELECT MailAlertId FROM T_MAIL_ALERT ");
                String alertId = dbAccess.GetString(strSql, out errMessage);
                if (String.IsNullOrEmpty(alertId))
                {
                    strSql = String.Format(@"INSERT INTO T_MAIL_ALERT (MailAlertId, MailAlertSiteName, SmtpUserName, SmtpServer, MailPass, SSLPort)
                                        VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')",
                                            model.MailAlertId, model.MailAlertSiteName, model.SmtpUserName, model.SmtpServer, model.MailPass, model.SSLPort);
                    dbAccess.ExecSql(strSql, out errMessage);
                }
                else
                {
                    strSql = String.Format(@"UPDATE T_MAIL_ALERT SET MailAlertSiteName='{0}',SmtpUserName='{1}',
                                        SmtpServer='{2}',MailPass='{3}',SSLPort='{4}'
                                        WHERE MailAlertId='{5}'",
                                            model.MailAlertSiteName, model.SmtpUserName, model.SmtpServer, model.MailPass, model.SSLPort, alertId);
                    dbAccess.ExecSql(strSql, out errMessage);
                }
                strSql = String.Format(@"DELETE T_MAIL_ALERT_DETAIL WHERE MailAlertType=1");
                dbAccess.ExecSql(strSql, out errMessage);

                foreach (MailAlertDetailModel mail in madmList)
                {
                    if (!String.IsNullOrEmpty(alertId))
                    { mail.MailAlertId = alertId; }
                    strSql = String.Format(@"INSERT INTO T_MAIL_ALERT_DETAIL (MailAlertDetailId, MailAlertId, IsSend, MailAlertSendIndex, MailAlertSendTitle, MailAlertAddress, MailAlertType)
                                        VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                                            mail.MailAlertDetailId, mail.MailAlertId, mail.IsSend, mail.MailAlertSendIndex,
                                            mail.MailAlertSendTitle, mail.MailAlertAddress, mail.MailAlertType);
                    dbAccess.ExecSql(strSql, out errMessage);
                }


                return true;
            }
            catch (Exception ex)
            {

                errMessage = ex.Message;
                return false;
            }

        }
        #endregion

        #region 删除邮件明细
        public Boolean DeleteMailAlertDetail(String businessId, out String errMessage)
        {
            String strSql = String.Format(@"delete T_MAIL_ALERT_DETAIL where MailAlertDetailId='{0}'", businessId);

            return dbAccess.ExecSql(strSql, out errMessage);
        }
        #endregion

        #region 读取最近发送的文件内容
        public String SelectTheLastSendMailContent()
        {
            String sSql =
                String.Format("SELECT TOP 1 SEND_CONTENT FROM T_MAIL_SENDCONTENT ORDER BY SEND_DATE");
            return dbAccess.GetString(sSql);
        }
        #endregion

        #region 插入邮件发送内容
        public bool InsertSendMailContent(String sendDate, String sendContent, String from, String to,Int32 sContentHash, out string errMessage)
        {
            String strSql =
                String.Format(@"INSERT INTO T_MAIL_SENDCONTENT (SEND_ID, SEND_DATE, SEND_CONTENT, SEND_FROM, TO_ADDRESS,SEND_CONTENT_HASHCODE)
                                VALUES ('{0}','{1}','{2}','{3}','{4}','{5}')",
                                Guid.NewGuid().ToString(), sendDate, sendContent, from, to,sContentHash);
            return dbAccess.ExecSql(strSql, out errMessage);
        }
        #endregion

        #region SAP邮件报警发送内容按照HashCode进行检索
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contentHashCode"></param>
        /// <returns></returns>
        public Boolean SelectSendContentByHashCode(Int32 contentHashCode)
        {
            String strSql =
                String.Format(@"SELECT COUNT(1) FROM T_MAIL_SENDCONTENT WHERE SEND_CONTENT_HASHCODE='{0}'", contentHashCode);
            String sRowCount = dbAccess.GetString(strSql);
            if (!String.IsNullOrEmpty(sRowCount))
            {
                if (sRowCount == "0") { return false; } else { return true; }
            }
            else { return false; }
        }
        #endregion
    }
}
