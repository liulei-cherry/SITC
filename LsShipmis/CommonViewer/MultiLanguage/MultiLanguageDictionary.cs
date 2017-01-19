using System;
using System.Collections.Generic;
using System.Text;
using OfficeOperation;
using System.Text.RegularExpressions;
using System.Xml;
using System.Data;
namespace CommonViewer.MultiLanguage
{
    public enum customLanguage
    {
        ENGLISH = 1,
        CHINESE = 2,
    }

    /// <summary>
    /// 全局唯一的多语言字典,暂时具备中文和英文的翻译.
    /// 资源文件暂时用Excel文件,第一列为原值,第二列为中文值,第三列为英文值;
    /// </summary>
    public class MultiLanguageDictionary
    {
        #region 单实例

        /// <summary>
        /// 静态实例对象.
        /// </summary>
        private static MultiLanguageDictionary instance = new MultiLanguageDictionary();
        public static MultiLanguageDictionary Instance
        {
            get
            {
                if (null == instance)
                {
                    MultiLanguageDictionary.instance = new MultiLanguageDictionary();
                }
                return MultiLanguageDictionary.instance;
            }
        }

        private MultiLanguageDictionary()
        {
            //仅提供private构造.
        }
        #endregion
        public customLanguage CustomLanguage { set; get; }
        //存放一般字符的Dictionary
        Dictionary<string, DictionaryItem> dic = new Dictionary<string, DictionaryItem>();
        //存放正则表达式的Dictionary
        Dictionary<string, DictionaryItem> dicRegex = new Dictionary<string, DictionaryItem>();
        //存放控件格式的List
        List<string> controlTypeList = new List<string>();
        Excel theFile = null;

        int row = 1;
        int ctwrow = 1;
        public string Translate(string toTrans)
        {
            if (String.IsNullOrEmpty(toTrans)) return "";
            string re = "";
            Regex objPatt = null;
            string old = toTrans.Trim();//存储 去了空格 和 最后一位是"*"号 待翻译的值.
            //下面一个判断代码功能是为去掉最后一位"*"号.
            if (old.LastIndexOf("*") != 0 && old.LastIndexOf("*") == old.Length - 1)
            {
                old = old.Substring(0, old.LastIndexOf("*"));
            }
            if (dic.ContainsKey(old))
            {
                //若待翻译的字符串在dic中存在.
                if (CustomLanguage == customLanguage.CHINESE)
                {
                    if (string.IsNullOrEmpty(dic[old].TransChinese))
                    {
                        re = toTrans;
                    }
                    else
                    {
                        re = toTrans.Replace(old, dic[old].TransChinese);//替换掉只需要翻译的值,这样就可以保留 前后空格 和 "*" 
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(dic[old].TransEnglish))
                    {
                        re = toTrans;
                    }
                    else
                    {
                        re = toTrans.Replace(old, dic[old].TransEnglish);
                    }
                }
            }
            else
            {
                //用dicRegex中的正则表达式匹配待翻译的字符串.
                //该处理函数建立在原始值（要匹配的字符串）与正则表达式只是动态变量不一样的情况.
                //如：.
                //正则表达式:“打印\w*出错，请参见出错信息：\\w*”.
                //原始值:“打印表格1出错，请参见出错信息:主键不能为空”.
                foreach (string key in dicRegex.Keys)
                {
                    objPatt = new Regex(key);//由key建立正则表达式.
                    //正则表达式与toTrans匹配.
                    if (objPatt.IsMatch(toTrans))
                    {
                        //取出toTrans中的动态变量值.
                        string[] variable = parseWithRegex(toTrans, key);

                        if (CustomLanguage == customLanguage.CHINESE)
                        {
                            if (string.IsNullOrEmpty(dicRegex[key].TransChinese))
                            {
                                re = toTrans;
                            }
                            else
                            {
                                string temp = dicRegex[key].TransChinese;
                                //用variable数组一次替换每一个出现的变量,variable[i]替换"w" + i
                                for (int i = 0; i < variable.Length; i++)
                                {
                                    temp = temp.Replace("w" + i, variable[i]);
                                }
                                re = temp;
                            }
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(dicRegex[key].TransEnglish))
                            {
                                re = toTrans;
                            }
                            else
                            {
                                string temp = dicRegex[key].TransEnglish;
                                for (int i = 0; i < variable.Length; i++)
                                {
                                    temp = temp.Replace("w" + i, variable[i]);

                                }
                                re = temp;
                            }
                        }
                        break;
                    }
                }
                //dic中不包含，且与dicRegex正则表达式也不匹配的，把原始值写入excel中.
                //如何判断与正则表达式不匹配:只要在这里判断re是空的即可.
                //if (string.IsNullOrEmpty(re))
                //{
                //    if (CustomLanguage == customLanguage.CHINESE)
                //        writeToExcel(toTrans.Trim());
                //}
            }
            if (string.IsNullOrEmpty(re)) re = toTrans;
            return re;
        }

        /* 根据正则表达式解析待翻译的字符串，主要把动态变量取出来，作为数组返回*/
        public string[] parseWithRegex(string toTrans, string regexKey)
        {
            //由 "\\w*"分割成字符数组，以确定变量的个数.
            string[] splitStr = regexKey.Split(new string[] { "\\w*" }, StringSplitOptions.None);
            //变量的个数为数组的长度-1
            int count = splitStr.Length - 1;
            //startIndex数组存放每个动态变量在字符串中的起始位置.
            int[] startIndex = new int[count];
            //endIndex数组存放每个动态变量在字符串中的结束位置.
            int[] endIndex = new int[count];
            //variable数组存放每个动态变量的值.
            string[] variable = new string[count];
            for (int i = 0; i < count; i++)
            {
                startIndex[i] = toTrans.IndexOf(splitStr[i]) + splitStr[i].Length;
                //  \\.\\w{3}表明是文件扩展名如：船舶证书一览表.xls ;那么endIndex[i]应该为toTrans.IndexOf(".") + 4
                if (splitStr[i + 1].Contains("\\.\\w{3}"))
                {
                    endIndex[i] = toTrans.IndexOf(".") + 4;//文件扩展名加4
                }
                else
                {
                    endIndex[i] = toTrans.IndexOf(splitStr[i + 1]);
                }
                //当变量正好是字符串末尾时；.
                if (i == count - 1 && splitStr[i + 1].Equals(""))
                {
                    variable[i] = toTrans.Substring(startIndex[i]);
                }
                else
                {
                    variable[i] = toTrans.Substring(startIndex[i], endIndex[i] - startIndex[i]);
                }
            }
            return variable;
        }

        public void writeToExcel(string toTrans)
        {
            //执行写excel操作.
            if (theFile != null && !dic.ContainsKey(toTrans))
            {
                theFile.SetSingelCellValue(1, row, toTrans);//设置Excel中第row行第1列的值.
                row++;
                //应该在dic中加入该值，以进行下一次的判断，不然会有插入重复数据.
                DictionaryItem theItem = new DictionaryItem();
                theItem.Original = toTrans;
                theItem.TransChinese = "";
                theItem.TransEnglish = "";
                dic.Add(toTrans, theItem);
            }
        }

        public void ControlTypeWriteToExcel(string typeName)
        {

            if (theFile != null)
            {
                theFile.SetSingelCellValue(5, ctwrow, typeName);//设置Excel中第row行第1列的值.
                if (!controlTypeList.Contains(typeName))
                {
                    controlTypeList.Add(typeName);
                    ctwrow++;
                }
            }

        }

        public bool InitCustomDictionary(string fileAddress, out String err)
        {
            try
            {
                err = "";
                
                string originalString;   //原始列名称Key
                string transChineseString;   //中文名称CName
                string transEnglishString;   //英文名称EName
                //String pageKey = "";   //定义变量
                DataSet dsSource = new DataSet();
                dsSource.ReadXml(fileAddress);   //读取Xml文件
                if (dsSource != null && dsSource.Tables.Count > 0)
                {
                    //读取DataTable
                    DataTable dtSource = dsSource.Tables[0];
                    //pageKey = dtSource.Rows[0][0].ToString();
                    //查询Key值所对应的DataRow的信息
                    //DataRow[] drSource = dtSource.Select("Key=" + pageKey + "");
                    
                    for (int i = 0; i < dtSource.Rows.Count; i++)
                    {
                        DictionaryItem nowItem = new DictionaryItem();
                        originalString = dtSource.Rows[i][0].ToString();   //原始列名称Key
                        transChineseString = dtSource.Rows[i][1].ToString();   //中文名称CName
                        transEnglishString = dtSource.Rows[i][2].ToString();   //英文名称EName
                        if (string.IsNullOrEmpty(originalString))
                        break;

                        originalString = string.IsNullOrEmpty(originalString) ? originalString : originalString.Trim();
                        transChineseString = string.IsNullOrEmpty(transChineseString) ? transChineseString : transChineseString.Trim();
                        transEnglishString = string.IsNullOrEmpty(transEnglishString) ? transEnglishString : transEnglishString.Trim();

                        nowItem.Original = originalString;
                        nowItem.TransChinese = transChineseString;
                        nowItem.TransEnglish = transEnglishString;
                        #region MyRegion
                        //if (drSource.Length > 0)
                        //{
                        //DataRow dr = drSource[0];   //只取第一个符合的值
                        //originalString = dr[0].ToString();   //原始列名称Key
                        //transChineseString = dr[1].ToString();   //中文名称CName
                        //transEnglishString = dr[2].ToString();   //英文名称EName
                        //}
                        //else
                        //{
                        //    originalString = pageKey;   //原始列名称Key
                        //    //transChineseString = pageKey;   //中文名称CName
                        //    //transEnglishString = pageKey;   //英文名称EName
                        //} 
                        #endregion

                        //原来的程序在key相同的时候，会导致死循环，应该把row的变化放在前面.
                        if (originalString.Contains("\\w*"))
                        {
                            dicRegex.Add(originalString, nowItem);//若是正则表达式，则放在dicRegex中.
                        }
                        else
                        {
                            if (dic.ContainsKey(originalString))
                            {
                                row++;
                                continue;
                            }
                            dic.Add(originalString, nowItem);
                        }
                        row++;
                    }
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                return false;
            }
            
            #region 读取xls文件
            //读取xls文件,把所有行读入,前三列,如果第二列为空或者第三列为空,均使用第一列进行填充.
            //err = "";
            //if (theFile != null) Excel.release(theFile.pt);
            //theFile = new Excel();
            //try
            //{
            //    theFile.OpenDocument(fileAddress);

            //    string originalString;
            //    string transChineseString;
            //    string transEnglishString;
            //    while (true)
            //    {
            //        DictionaryItem nowItem = new DictionaryItem();
            //        originalString = theFile.GetValue(theFile.GetSingleCellRange(1, row));
            //        transChineseString = theFile.GetValue(theFile.GetSingleCellRange(2, row));
            //        transEnglishString = theFile.GetValue(theFile.GetSingleCellRange(3, row));
            //        if (string.IsNullOrEmpty(originalString))
            //            break;

            //        originalString = string.IsNullOrEmpty(originalString) ? originalString : originalString.Trim();
            //        transChineseString = string.IsNullOrEmpty(transChineseString) ? transChineseString : transChineseString.Trim();
            //        transEnglishString = string.IsNullOrEmpty(transEnglishString) ? transEnglishString : transEnglishString.Trim();

            //        nowItem.Original = originalString;
            //        nowItem.TransChinese = transChineseString;
            //        nowItem.TransEnglish = transEnglishString;
            //        //原来代码为(下面两行)(如果为空就赋原始值),现在修改成不赋原始值,之后再翻译时判断为空就把待翻译值返回.

            //        //nowItem.TransChinese = string.IsNullOrEmpty(transChineseString) ? originalString : transChineseString;
            //        //nowItem.TransEnglish = string.IsNullOrEmpty(transEnglishString) ? originalString : transEnglishString;

            //        //原来的程序在key相同的时候，会导致死循环，应该把row的变化放在前面.

            //        if (originalString.Contains("\\w*"))
            //        {
            //            dicRegex.Add(originalString, nowItem);//若是正则表达式，则放在dicRegex中.

            //        }
            //        else
            //        {

            //            if (dic.ContainsKey(originalString))
            //            {
            //                row++;
            //                continue;
            //            }
            //            dic.Add(originalString, nowItem);
            //        }
            //        row++;

            //        //dic.Add(originalString, nowItem);
            //        //row++;
            //    }
            //}
            //catch (Exception e)
            //{
            //    err = " 无法打开文件[" + fileAddress + "],通常有3种可能性"
            //           + "\r1.如果文件不是Excel类型;2.本地没有安装Office软件,3.没有文件访问或操作权限!"
            //           + "\r 更多系统提示:" + e.Message;
            //    return false;
            //}
            //finally
            //{
            //    closeExcel();
            //} 
            #endregion

            return true;
        }

        public void closeExcel()
        {
            if (theFile != null)
            {
                try
                {
                    theFile.CloseDocument();
                    Excel.release(theFile.pt);
                    theFile.Dispose();
                }
                catch
                {
                    //此处不捕获错误.
                }
            }
        }

        public void saveExcel()
        {
            if (theFile != null)
            {
                string path = Environment.CurrentDirectory;//获得应用程序的当前路径.

                try
                {
                    theFile.SaveDocument(path + "\\translate.xls");
                }
                catch
                { }
            }
        }
    }
    internal class DictionaryItem
    {
        public string Original;
        public string TransChinese;
        public string TransEnglish;
    }
}
