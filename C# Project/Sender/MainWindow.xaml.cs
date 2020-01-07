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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Sender.WinAPI;

namespace Sender
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            hWnd = FindWindow(null, "Project5_wpf");
        }
        // 用户文本消息
        const int WM_COPYDATA = 0x0004A;
        public int hWnd;

        [DllImport("user32.dll")]
        public static extern void SendMessage(
            int hWnd,
            int msg,
            IntPtr wParam,
            ref COPYDATASTRUCT lParam);

        [DllImport("user32.dll")]
        public static extern int FindWindow(
          string lpClassName,
          string lpWindowName
         );


        private void Btn_SendMsg_click(object sender, EventArgs e)
        {
            string text = txb_Msg.Text;
            if (hWnd != 0)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SenderForm pj = new SenderForm();
            pj.Show();
        }
    }
}
