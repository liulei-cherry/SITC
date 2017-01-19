/****************************************************************************************************
 * Copyright (C) 2011 大连陆海科技股份有限公司 版权所有
 * 文 件 名：Tools.cs
 * 创 建 人：夏喜龙
 * 创建时间：2011/7/4
 * 标    题：工具类
 * 功能描述：系统中起到工具作用的类和功能
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using CommonOperation.Interfaces;
using CommonOperation.Functions;
using System.Runtime.InteropServices;

namespace CommonOperation
{

    public class Tools
    {
        /// <summary>
        /// 由小写数字转换成大写文字（主要用于财务系统）.
        /// xuzhengben,2011.06
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string numberToChinese(Decimal d)
        {
            if (d == 0)
                return "零元整";
            if (d < 0M)
                return "负数或冲账数据";

            List<string> zwsz = new List<string> { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
            List<string> zwdw = new List<string> { "", "拾", "百", "仟", "万", "拾", "百", "仟", "亿", "拾", "百" };
            long zs = (long)decimal.Truncate(d);
            d = d - zs;
            StringBuilder re = new StringBuilder();

            char[] cZS = zs.ToString().ToCharArray();
            char[] cXS = 0.ToString().ToCharArray();
            if (d != 0)
                cXS = d.ToString().Substring(2).ToCharArray();
            bool needZero = false;
            bool allJumpIs0 = false;
            for (int i = 0; i < cZS.Length; i++)
            {
                int r = cZS.Length - i - 1;
                bool isJump = (r % 4 == 0);

                if (cZS[i] == '0')
                {
                    if (isJump)
                    {
                        if (!allJumpIs0) re.Append(zwdw[r]);
                    }
                    else if (!needZero) needZero = true;
                }
                else
                {
                    allJumpIs0 = false;
                    if (needZero) re.Append(zwsz[0]);
                    re.Append(zwsz[cZS[i] - 48] + zwdw[r]);
                    needZero = false;
                }
                if (isJump)
                {
                    allJumpIs0 = true;
                    needZero = false;
                }
            }
            re.Append("元");
            if (d == 0)
            {
                re.Append("整");
            }
            else
            {

                if (cXS.Length == 1)
                {
                    re.Append(zwsz[cXS[0] - 48] + "角");
                }
                else
                {
                    if (cXS[0] != '0')
                    {
                        re.Append(zwsz[cXS[0] - 48] + "角");
                    }
                    re.Append(zwsz[cXS[1] - 48] + "分");
                }
            }
            return re.ToString();
        }

        #region 外部文件操作部分
        [DllImport("kernel32.dll")]
        public static extern int WinExec(string exeName, int operType);

        public static void FileOpen(string fileLocation)
        {
            if (fileLocation != "")
            {
                try
                {
                    System.Diagnostics.Process.Start(fileLocation);
                }
                catch
                {
                    WinExec("rundll32.exe shell32.dll,OpenAs_RunDLL " + fileLocation, 5);
                }

            }
        }
        #endregion
    }
}
