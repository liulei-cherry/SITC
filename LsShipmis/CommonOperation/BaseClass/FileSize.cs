using System;
using System.Collections.Generic;
using System.Text;

namespace CommonOperation.BaseClass
{
    public class FileSize
    {

        static long _MbViewNumber = 20 * 1024 * 1024;
        static long _GbViewNumber = 20L * 1024 * 1024 * 1024;
        long fileSize;
        public override string ToString()
        {
            if (fileSize < 1024)
            {
                return addDispartChar(fileSize.ToString()) + " Byte";
            }
            else if (fileSize < _MbViewNumber) //20M以内显示Kb,以后显示兆.
            {
                return addDispartChar(((long)(fileSize / 1024)).ToString()) + " KB";
            }
            else if (fileSize < _GbViewNumber) // 20GB以内显示M,否则显示GB
            {
                return addDispartChar(((long)(fileSize / (1024 * 1024))).ToString()) + " MB";
            }
            else
            {
                return addDispartChar(((long)(fileSize / (1024L * 1024 * 1024))).ToString()) + " GB";
            }
        }
        private string addDispartChar(string theNumber)
        {
            int lenthOfNumber = theNumber.Length;
            if (lenthOfNumber == 0)
            {
                return "0";
            }
            if (lenthOfNumber <= 3)
            {
                return theNumber;
            }
            string reDispartChar = theNumber[0].ToString();
            for (int i = 1; i < lenthOfNumber; i++)
            {
                if ((lenthOfNumber - i) % 3 == 0)
                {
                    reDispartChar += ",";
                }
                reDispartChar += theNumber[i].ToString();
            }
            return reDispartChar;
        }
        public FileSize(long fileSizeIn)
        {
            fileSize = fileSizeIn;
        }
    }
}
