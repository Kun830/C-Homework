using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Sender.WinAPI;

namespace Sender
{
    public partial class SenderForm : Form
    {
        public SenderForm()
        {
            InitializeComponent();
            hWnd = FindWindow(null, "Project5_winform");
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
        private void Button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            if (hWnd != 0)
            {
                COPYDATASTRUCT cds;
                cds.lpData = text;
                cds.dwData = (IntPtr)100;
                byte[] arr = Encoding.UTF8.GetBytes(text);

                cds.cbData = arr.Length + 1;
                SendMessage(hWnd, WM_COPYDATA, IntPtr.Zero, ref cds);
            }
            textBox1.Text = "";
        }

    }
}
