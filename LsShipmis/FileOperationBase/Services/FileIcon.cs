/****************************************************************************************************
 * Copyright (C) 2007 大连陆海科技有限公司 版权所有
 * 文 件 名：WorkInfoService.cs
 * 创 建 人：牛振军
 * 创建时间：2008-05-12
 * 标    题：工作信息业务信息
 * 功能描述：文件、文件夹系统图标的获取。
 * 修 改 人：
 * 修改时间：
 * 修改内容：
 ****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace FileOperationBase.Services
{
    public class FileIcon
    {
        /// <summary>
        ///  获取文件的默认图标.
        /// </summary>
        /// <param name="fileName">文件名。.
        ///     可以只是文件名，甚至只是文件的扩展名(.*)；.
        ///     如果想获得.ICO文件所表示的图标，则必须是文件的完整路径。.
        /// </param>
        /// <param name="largeIcon">是否大图标</param>
        /// <returns>文件的默认图标</returns>
        public static Icon GetFileIcon(string fileName, bool largeIcon)
        {
            SHFILEINFO info = new SHFILEINFO(true);
            int cbFileInfo = Marshal.SizeOf(info);
            SHGFI flags;
            if (largeIcon)
                flags = SHGFI.Icon | SHGFI.LargeIcon | SHGFI.UseFileAttributes;
            else
                flags = SHGFI.Icon | SHGFI.SmallIcon | SHGFI.UseFileAttributes;

            SHGetFileInfo(fileName, 256, out info, (uint)cbFileInfo, flags);
            return Icon.FromHandle(info.hIcon);
        }

        [DllImport("Shell32.dll")]
        private static extern int SHGetFileInfo
          (
          string pszPath, uint dwFileAttributes,
          out   SHFILEINFO psfi,
          uint cbfileInfo,
          SHGFI uFlags
          );
        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public SHFILEINFO(bool b)
            {
                hIcon = IntPtr.Zero;
                iIcon = 0;
                dwAttributes = 0;
                szDisplayName = "";
                szTypeName="";
            }
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.LPStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.LPStr, SizeConst = 80)]
            public string szTypeName;
        };

    }

    enum SHGFI
    {
        SmallIcon = 0x00000001,
        LargeIcon = 0x00000000,
        Icon = 0x00000100,
        DisplayName = 0x00000200,
        Typename = 0x00000400,
        SysIconIndex = 0x00004000,
        UseFileAttributes = 0x00000010
    }
}
