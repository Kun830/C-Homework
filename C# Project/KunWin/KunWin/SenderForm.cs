using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KunWin.WinAPI;

namespace KunWin
{
    public partial class SenderForm : Form
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

        public SenderForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            if (hWnd != null)
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
