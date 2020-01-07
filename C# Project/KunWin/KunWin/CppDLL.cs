using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace KunWin
{
    class CppDLL
    {
            [DllImport("MyDLL.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double Add(double a, double b);
            [DllImport("MyDLL.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double Subtract(double a, double b);
            [DllImport("MyDLL.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double Multiply(double a, double b);
            [DllImport("MyDLL.dll", CallingConvention = CallingConvention.Cdecl)]
            public static extern double Divide(double a, double b);
    }
}
