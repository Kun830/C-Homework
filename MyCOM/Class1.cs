
using System;

using System.Collections.Generic;

using System.Text;

using System.Runtime.InteropServices;

namespace MyCOM
{
    [ComVisible(true)]
    [Guid("6B88CFAD-C23A-415B-92B7-DE4E29F0557C")]
    public interface IClass
    {
        double Add(double x, double y);
        double Subtract(double x, double y);
    }

    [ComVisible(true)]
    [Guid("C19CAA41-576C-491D-B204-A93FEC2736F3")]
    [ProgId("MyCOM.MyClass")]
    public class MyClass : IClass
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Subtract(double x, double y)
        {
            return x - y;
        }
    }

}
