using System;
using System.Collections.Generic;
using System.Text;

namespace CommonOperation.Functions
{
    public class StringOperation
    {
        static char[] common16chars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
        static List<char> Common16Chars = new List<char>( common16chars);
        
        public string ChangeInsideCodeToWord(string str)
        {
            #region 校验。。str是否符合 4位的要求
            str = str.ToLower ();
            if (str.Length != 4)
            {
                throw new Exception("[" + str + "]并非标准的4位长,16进制的字符串,本方法无法解析!");
            }
            
            foreach (char tempc in str.ToCharArray())
            {
                if (!Common16Chars.Contains(tempc))
                {
                    throw new Exception("[" + str + "]并非标准的4位长,16进制的字符串,本方法无法解析!");
                }
            }
            #endregion

            byte[] array = new byte[2];
            string str1 = str.Substring(0, 2);
            string str2 = str.Substring(2, 2);
            int front = Convert.ToInt32(str1, 16);
            int back = Convert.ToInt32(str2, 16);
            array[0] = (byte)front;
            array[1] = (byte)back;
            return System.Text.Encoding.Default.GetString(array);
        }
        public string ChangeRichBoxTextToCommonText(string str)
        {
            //顺序读下去,按照分支往下走.
            string re = "";
            char[] strToChar = str.ToCharArray();

            //state 0:正常接收模式.
            //state 1:读到转义符模式.
            //state 2:舍弃后面的字体,直到转义符或者空格.
            for (int i = 0,state = 0; i < strToChar.Length; i++)
            {
                switch (state)
                {
                    #region state 0:正常接收模式
                    case 0:
                        if (strToChar[i].Equals('\\'))
                        {
                            state = 1;
                        }
                        else
                        {
                            re += strToChar[i].ToString();
                        }
                        break;
                    #endregion
                    #region state 1:读到转义符模式

                    case 1:
                        switch (strToChar[i])
                        {
                            case '\\':
                                re += "\\";
                                state = 0; 
                                break;
                            case '\'':
                                //需要连续几个字母的格式为 \'##\'##
                                //如果剩余长度不足6,则有问题.
                                if (i + 6 >= strToChar.Length)
                                {
                                    throw new Exception("读入到全角字符,却不完整,无法继续解析");
                                }
                                //其他情况全部交给全角转换函数处理.
                                re += ChangeInsideCodeToWord(strToChar[i + 1].ToString() + strToChar[i + 2].ToString() + strToChar[i + 5].ToString() + strToChar[i + 6].ToString());
                                state = 0;
                                i = i + 6;
                                break;
                            default://其他情况全部变成舍弃模式.
                                state = 2;
                                break;
                        }
                        break;
                    #endregion
                    #region state 2:舍弃后面的字体,直到转义符或者空格

                    case 2:
                        if (strToChar[i].Equals('\\'))
                        {
                            state = 1;
                        }
                        else if (strToChar[i].Equals(' '))
                        {
                            state = 0;
                        }
                        break;
                    default:
                        throw new Exception("");
                    #endregion
                }
            }
            return re.Trim();
        }
        /// <summary>
        /// 类似数据库的trim函数，去掉字符串前后的空格、回车、换行符号（注意不包括中间的内容）.
        /// </summary>
        /// <param name="toTrimString"></param>
        /// <returns></returns>
        public static string AllTrim(string toTrimString)
        {
            int start;
            int end;
            for (end = toTrimString.Length; end > 0; end--)
            {
                string temp = toTrimString.Substring(end - 1, 1);
                if (temp == " " || temp == "\r" || temp == "\n")
                {
                    continue;
                }
                break;
            }
            if (end < 0)
            {
                return toTrimString;
            }
            for (start = 0; start < end; start++)
            {
                string temp = toTrimString.Substring(start, 1);
                if (temp == " " || temp == "\r" || temp == "\n")
                {
                    continue;
                }
                break;
            }
            return toTrimString.Substring(start, end - start);
        }

        //-------------------------------------------------------------------
        //其他类型转化成整数类型
        //-------------------------------------------------------------------
        public int Fn_ToInt(object objNumData)
        {
            int intResult;
            try
            {
                if (Convert.IsDBNull(objNumData) || (objNumData == null))
                {
                    intResult = 0;
                }
                else
                {
                    try
                    {
                        intResult = int.Parse(objNumData.ToString());
                    }
                    catch
                    {
                        intResult = 0;
                    }

                }
                return intResult;
            }
            catch
            {
                return 0;
            }

        }

        //-------------------------------------------------------------------
        //其他类型转化成双精度数类型
        //-------------------------------------------------------------------
        public double Fn_ToDbl(object objNumData)
        {
            double dblResult;
            try
            {
                if (Convert.IsDBNull(objNumData) || (objNumData == null))
                {
                    dblResult = 0;
                }
                else
                {
                    try
                    {
                        dblResult = double.Parse(objNumData.ToString());
                    }
                    catch
                    {
                        dblResult = 0;
                    }

                }
                return dblResult;
            }
            catch
            {
                return 0;
            }
        }


        //-------------------------------------------------------------------
        //其他类型转化成字符串类型
        //-------------------------------------------------------------------
        public string Fn_Chr(object objChrData)
        {
            try
            {
                if (Convert.IsDBNull(objChrData) || (objChrData == null))
                {
                    return "";
                }
                else
                {
                    return Convert.ToString(objChrData);
                }
            }
            catch
            {
                return "";
            }

        }
    }
}
