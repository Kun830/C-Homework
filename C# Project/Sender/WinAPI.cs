using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sender
{
    public class WinAPI
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;   // 传入自定义的数据
            public int cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;   // 消息字符串

        }
    }
}
