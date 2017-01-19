/****************************************************************************************************
 * Copyright (C) 2008 大连陆海科技有限公司 版权所有
 * 文 件 名：MessageAlert.cs
 * 创 建 人：王鹏程
 * 创建时间：2011-06-23
 * 标    题：报文报警
 * 功能描述：
 * 修 改 人： 
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using System.Windows.Forms;
using SAPFunction.Viewer;
using SAPFunction.DataObject;
using CommonOperation;
namespace SAPFunction.Services
{
    public class MessageAlert : CommonOperation.Interfaces.IRemind
    {
        static Smtp smtp = null;

        public static String errMessage = String.Empty;

        private static string message = "";
        /// <summary>
        /// 当前对象的报警颜色，以及鼠标tag信息.
        /// </summary>
        /// <param name="tag">图标上显示的鼠标tag</param>
        /// <returns>报警颜色值</returns>
        public remindColor getStatus(out string tag)
        {
            tag = message;
            return remindColor.Red;
        }

        /// <summary>
        /// 点击报警图标后需要打开的窗体或处理的事件.
        /// </summary>
        public void viewInfo()
        {
            FrmMessage frm = FrmMessage.Instance;
            if (CommonViewer.CommonViewConfig.MainForm != null) frm.MdiParent = CommonViewer.CommonViewConfig.MainForm;
            frm.BringToFront();
            frm.Show();
        }

        public static IRemind GetAlarmObject()
        {
            var subject = "SAP报警";
            var title = String.Empty;
            var toAddress = new List<String>();
            String sendTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ssss"); ;
            String sendFrom = "";
            String strToAddress = "";
            String sendContent = "";

            #region 邮件发送对象
            DataTable dtmailsource = SAPWarnSendMailService.Instance.SelectMailAlertTable(out errMessage);
            DataTable dtdetailsource = SAPWarnSendMailService.Instance.SelectMailAlertDetailTable(1, out errMessage);
            if (dtmailsource != null && dtdetailsource != null && dtmailsource.Rows.Count > 0 && dtdetailsource.Rows.Count > 0)
            {
                smtp = new Smtp(dtmailsource.Rows[0]["SmtpServer"].ToString(), dtmailsource.Rows[0]["SmtpUserName"].ToString(), dtmailsource.Rows[0]["MailPass"].ToString());
                var from = dtmailsource.Rows[0]["SmtpUserName"].ToString();



                var attachmentList = new List<String>();
                var content = String.Empty;
                var addresslist = String.Empty;
                //构造邮件
                for (int k = 0, mailCount = dtdetailsource.Rows.Count; k < mailCount; k++)
                {
                    if (dtdetailsource.Rows[k]["Start"] != null)
                    {
                        if (!String.IsNullOrEmpty(dtdetailsource.Rows[k]["Start"].ToString()))
                        {
                            Boolean isStart = Convert.ToBoolean(dtdetailsource.Rows[k]["Start"].ToString() == "1" ? true : false);
                            if (isStart)
                            {
                                title += dtdetailsource.Rows[k]["MailAlertSendTitle"] + ",";
                                toAddress.Add(dtdetailsource.Rows[k]["MailAlertAddress"].ToString());
                                addresslist += dtdetailsource.Rows[k]["MailAlertAddress"].ToString() + ",";
                            }
                        }
                    }
                }

                sendFrom = from;
                strToAddress = addresslist;



                //#region 记录发送内容

                //Boolean isExist = SAPWarnSendMailService.Instance.SelectSendContentByHashCode(contentHashCode);
                //#endregion
                //if (!isExist)
                //{
                //    SAPWarnSendMailService.Instance.InsertSendMailContent(sendTime, sendContent, sendFrom, strToAddress, contentHashCode, out errMessage);

                //    title = title.Substring(0, title.Length - 1) + " 你好:\r\n";
                //    sContent.Insert(0, title);
                //    sContent.AppendLine("\r\n\r\n\r\n若不想收到此类邮件请在SAP报警中删除！");
                //    if (smtp != null)
                //    {
                //        try
                //        {
                //            smtp.SendMail(from, toAddress, subject, sContent.ToString(), false);
                //        }
                //        catch { }
                //        finally { }
                //    }
                //}
            }

            #endregion

            var sContent = new StringBuilder();
            var err = "";         //错误信息返回参数.
            DataTable dtSource2 = MessageHeaderService.Instance.GetInfo(null, null, null, "2", null, out err);
            DataTable dtSource3 = MessageHeaderService.Instance.GetInfo(null, null, null, "3", null, out err);
            DataTable dtSource4 = MessageHeaderService.Instance.GetInfo(null, null, null, "4", null, out err);
            DataTable dtSource7 = MessageHeaderService.Instance.GetInfo(null, null, null, "7", null, out err);

            Int32 rowCount2 = dtSource2.Rows.Count;
            Int32 rowCount3 = dtSource3.Rows.Count;
            Int32 rowCount4 = dtSource4.Rows.Count;
            Int32 rowCount7 = dtSource7.Rows.Count;

            if (rowCount2 > 0)
            {
                for (int i = 0; i < rowCount2; i++)
                {
                    Int32 contentHashCode = dtSource2.Rows[i]["BUSINESS_CODE"].ToString().GetHashCode(); 
                    Boolean isExist = SAPWarnSendMailService.Instance.SelectSendContentByHashCode(contentHashCode);
                    if (!isExist)
                    {
                        sendContent = dtSource2.Rows[i]["BUSINESS_CODE"].ToString();
                        SAPWarnSendMailService.Instance.InsertSendMailContent(sendTime, sendContent, sendFrom, strToAddress, contentHashCode, out errMessage);
                        sContent.AppendLine(dtSource2.Rows[i]["ship_name"] + "(" + dtSource2.Rows[i]["COMPANY_CODE"] + ")业务代码为" + dtSource2.Rows[i]["BUSINESS_CODE"] + "数据出现错误内容如下：" + dtSource2.Rows[i]["MESSAGE_ERROR"].ToString().Replace("\r", "").Replace("\n", ""));
                    }
                }
            }

            if (rowCount3 > 0)
            {
                for (int i = 0; i < rowCount3; i++)
                {
                    Int32 contentHashCode = dtSource3.Rows[i]["BUSINESS_CODE"].ToString().GetHashCode(); 
                    Boolean isExist = SAPWarnSendMailService.Instance.SelectSendContentByHashCode(contentHashCode);
                    if (!isExist)
                    {
                        sendContent = dtSource3.Rows[i]["BUSINESS_CODE"].ToString();
                        SAPWarnSendMailService.Instance.InsertSendMailContent(sendTime, sendContent, sendFrom, strToAddress, contentHashCode, out errMessage);
                        sContent.AppendLine(dtSource3.Rows[i]["ship_name"] + "(" + dtSource3.Rows[i]["COMPANY_CODE"] + ")业务代码为" + dtSource3.Rows[i]["BUSINESS_CODE"] + "数据出现错误内容如下：" + dtSource3.Rows[i]["MESSAGE_ERROR"].ToString().Replace("\r", "").Replace("\n", ""));
                    }
                }
            }
            if (rowCount4 > 0)
            {
                for (int i = 0; i < rowCount4; i++)
                {
                    Int32 contentHashCode = dtSource4.Rows[i]["BUSINESS_CODE"].ToString().GetHashCode(); 
                    Boolean isExist = SAPWarnSendMailService.Instance.SelectSendContentByHashCode(contentHashCode);
                    if (!isExist)
                    {
                        sendContent = dtSource4.Rows[i]["BUSINESS_CODE"].ToString();
                        SAPWarnSendMailService.Instance.InsertSendMailContent(sendTime, sendContent, sendFrom, strToAddress, contentHashCode, out errMessage);
                        sContent.AppendLine(dtSource4.Rows[i]["ship_name"] + "(" + dtSource4.Rows[i]["COMPANY_CODE"] + ")业务代码为" + dtSource4.Rows[i]["BUSINESS_CODE"] + "数据出现错误内容如下：" + dtSource4.Rows[i]["MESSAGE_ERROR"].ToString().Replace("\r", "").Replace("\n", ""));
                    }
                }
            }
            if (rowCount7 > 0)
            {
                for (int i = 0; i < rowCount7; i++)
                {
                    Int32 contentHashCode = dtSource7.Rows[i]["BUSINESS_CODE"].ToString().GetHashCode(); 
                    Boolean isExist = SAPWarnSendMailService.Instance.SelectSendContentByHashCode(contentHashCode);
                    if (!isExist)
                    {
                        sendContent = dtSource7.Rows[i]["BUSINESS_CODE"].ToString();
                        SAPWarnSendMailService.Instance.InsertSendMailContent(sendTime, sendContent, sendFrom, strToAddress, contentHashCode, out errMessage);
                        sContent.AppendLine(dtSource7.Rows[i]["ship_name"] + "(" + dtSource7.Rows[i]["COMPANY_CODE"] + ")业务代码为" + dtSource7.Rows[i]["BUSINESS_CODE"] + "数据出现错误内容如下：" + dtSource7.Rows[i]["MESSAGE_ERROR"].ToString().Replace("\r", "").Replace("\n", ""));
                    }
                }
            }


            #region 邮件发送
            if (!String.IsNullOrEmpty(sContent.ToString()))
            {
                title = title.Substring(0, title.Length - 1) + " 你好:\r\n";
                sContent.Insert(0, title);
                sContent.AppendLine("\r\n\r\n\r\n若不想收到此类邮件请在SAP报警中删除！");
                if (smtp != null)
                {
                    try
                    {
                        smtp.SendMail(sendFrom, toAddress, subject, sContent.ToString(), false);
                    }
                    catch { }
                    finally { }
                }
            }
            #endregion

            if (rowCount2 > 0)
            {
                message = "存在未通过映射的报文";
                return (IRemind)new MessageAlert();
            }
            if (rowCount3 > 0)
            {
                message = "存在待发送的报文";
                return (IRemind)new MessageAlert();
            }
            if (rowCount4 > 0)
            {
                message = "存在被SAP打回的错误报文";
                return (IRemind)new MessageAlert();
            }
            if (rowCount7 > 0)
            {
                message = "存在SAP方法调用失败的报文";
                return (IRemind)new MessageAlert();
            }

            return null;
        }
    }
}
