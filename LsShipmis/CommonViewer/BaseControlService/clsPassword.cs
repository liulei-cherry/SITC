using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Security.Cryptography;
using System.IO;

namespace CommonViewer.BaseControlService
{
    /// <summary>
    /// 密码控制.
    /// </summary>
    public class clsPassword
    {
        const string KEY_64 = "Maritech";//注意了，是8个字符，64位.
        const string IV_64 = "Maritech";

        public clsPassword()
        {
            //
            // TODO: 在此处添加构造函数逻辑.
            //
        }
   
        #region DeCode 解密
        /// <summary>
        /// DeCode 解密.
        /// </summary>
        /// <param name="str">要解密的字符串</param>
        /// <returns></returns>
        public string DeCode(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(KEY_64);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(IV_64);
            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }
        #endregion
    }
}