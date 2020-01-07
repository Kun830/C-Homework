using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace KunWin
{
    public static class RegUtil
    {

        //创建或打开Key值
        [DllImport(@"Advapi32.dll")]
        public static extern int RegCreateKeyEx(uint hKey, string lpSubKey, uint reserved, string type, uint dwOptions, uint REGSAM, uint lpSecurityAttributes, ref uint phkResult,
                                                 ref uint lpdwDisposition);
        //设置Key值
        [DllImport(@"Advapi32.dll")]
        public static extern int RegSetValueEx(uint hKey, string lpValueName, uint unReserved, uint unType, string lpData, uint dataCount);

        [DllImport(@"Advapi32.dll")]
        public static extern int RegQueryValueEx(uint hKey,string lpValueName,IntPtr lpReserved,out uint lpType,System.Text.StringBuilder lpData,ref uint lpcbData);

        public const uint HKEY_CURRENT_USER = 0x80000001;
        // 系统重启后不存在
        public const uint REG_OPTION_VOLATILE = 1;
        public const uint STANDARD_RIGHTS_ALL = 0x1F0000;
        public const uint SYNCHRONIZE = 0x100000;
        public const uint READ_CONTROL = 0x20000;
        public const uint STANDARD_RIGHTS_READ = (READ_CONTROL);
        public const uint STANDARD_RIGHTS_WRITE = (READ_CONTROL);
        public const uint KEY_CREATE_LINK = 0x20;
        public const uint KEY_CREATE_SUB_KEY = 0x4;
        public const uint KEY_ENUMERATE_SUB_KEYS = 0x8;
        public const uint KEY_NOTIFY = 0x10;
        public const uint KEY_QUERY_VALUE = 0x1;
        public const uint KEY_SET_VALUE = 0x2;
        public const uint KEY_READ = ((STANDARD_RIGHTS_READ | KEY_QUERY_VALUE | KEY_ENUMERATE_SUB_KEYS | KEY_NOTIFY) & (~SYNCHRONIZE));
        public const uint KEY_WRITE = ((STANDARD_RIGHTS_WRITE | KEY_SET_VALUE | KEY_CREATE_SUB_KEY) & (~SYNCHRONIZE));
        public const uint KEY_EXECUTE = (KEY_READ);
        public const uint KEY_ALL_ACCESS = ((STANDARD_RIGHTS_ALL | KEY_QUERY_VALUE | KEY_SET_VALUE | KEY_CREATE_SUB_KEY | KEY_ENUMERATE_SUB_KEYS |
            KEY_NOTIFY | KEY_CREATE_LINK) & (~SYNCHRONIZE));
        
    }
}