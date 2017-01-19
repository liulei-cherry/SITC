using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Login
{
    public class MD5Function
    {
        /// <summary>
        /// 对文件流进行MD5加密.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <example></example>
        public static string MD5Stream(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(fs);
            fs.Close();

            byte[] b = md5.Hash;
            md5.Clear();

            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < b.Length; i++)
            {
                sb.Append(b[i].ToString("X2"));
            }

            return sb.ToString();
        }
              
    }
}
