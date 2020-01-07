using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static KunWin.WinAPI;

namespace KunWin
{
    /// <summary>
    /// SendWin.xaml 的交互逻辑
    /// </summary>
    public partial class SendWin : Window
    {
        // 用户文本消息
        const int WM_COPYDATA = 0x00001;
        public IntPtr hWnd;

        [DllImport("user32.dll")]
        public static extern void SendMessage(
            IntPtr hWnd,
            int msg,
            IntPtr wParam,
            ref COPYDATASTRUCT lParam);
        public SendWin()
        {
            InitializeComponent();
        }

        private void Btn_SendMsg_click(object sender, RoutedEventArgs e)
        {
            string text = txb_Msg.Text;
            if (hWnd != null)
            {
                COPYDATASTRUCT cds;
                cds.lpData = text;
                cds.dwData = (IntPtr)100;
                byte[] arr = Encoding.UTF8.GetBytes(text);

                cds.cbData = arr.Length + 1;
                SendMessage(hWnd, WM_COPYDATA, IntPtr.Zero, ref cds);
            }
            txb_Msg.Text = "";
        }
    }
}
