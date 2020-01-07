using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
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
    /// Project3.xaml 的交互逻辑
    /// </summary>
    public partial class Project3 : Window
    {
        // 管道名称
        const string PIPE_NAME = "KunPipe";
        // 声明管道
        NamedPipeClientStream pipeClient = null;
        NamedPipeServerStream pipeServer = null;
        StreamWriter sw = null;
        StreamReader sr = null;
        public Project3()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern void SendMessage(IntPtr hWnd,int msg,
            IntPtr wParam,ref COPYDATASTRUCT lParam);

        private void StartCmd_Click(object sender, RoutedEventArgs e)
        {
            string cmd = CmdIn.Text;
            RedirectCMD(cmd);
            CmdIn.Text = "";
        }

        //异步重定向
        private void RedirectCMD(string command)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            //执行过程中按钮不可用
            StartCmd.IsEnabled = false;
            try
            {
                process.Start();
                process.StandardInput.WriteLine(command);
                process.StandardInput.WriteLine("exit");

                process.OutputDataReceived += AddResult;
                process.Exited += (s, _e) => StartCmd.Dispatcher.BeginInvoke(
                    new Action(() => StartCmd.IsEnabled = true));
                process.EnableRaisingEvents = true;
                process.BeginOutputReadLine();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void AddResult(object sender, DataReceivedEventArgs e)
        {
            CmdOut.Dispatcher.BeginInvoke(new Action(
                () => CmdOut.AppendText(e.Data + "\n")));
        }


        private void PipeBegin_Click(object sender, RoutedEventArgs e)
        {
            // 初始化管道
            pipeServer = new NamedPipeServerStream(PIPE_NAME, PipeDirection.InOut, 1,
                PipeTransmissionMode.Message, PipeOptions.Asynchronous);
            pipeClient = new NamedPipeClientStream("localhost", PIPE_NAME, PipeDirection.InOut,
                PipeOptions.Asynchronous, TokenImpersonationLevel.None);

            ConnectPipe();
            WaitForMessage();
        }

        // 连接管道
        private void ConnectPipe()
        {
            try
            {
                pipeClient.Connect(5000);
                sw = new StreamWriter(pipeClient);
                sr = new StreamReader(pipeServer);
                sw.AutoFlush = true;
                MessageBox.Show("连接成功！", "Success");
            }
            catch (Exception)
            {
                MessageBox.Show("连接超时。", "Error");
            }
        }


        // Server开启线程等待接收消息
        private void WaitForMessage()
        {
            Thread thread = new Thread(() =>
            {
                pipeServer.WaitForConnection();
                while (true)
                {
                    try
                    {
                        string line = sr.ReadLine();
                        // 异步更新
                        Server.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            Server.AppendText(DateTime.Now.ToUniversalTime().ToString() + "\n");
                            Server.AppendText(line + "\n");
                        }));
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine("{0}", ex);
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
            });
            //挂起为后台线程
            thread.IsBackground = true;
            thread.Start();
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sw.WriteLine(Client.Text);
                Client.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("未连接。", "Error");
            }
        }

        private void Btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow pj = new MainWindow();
            Application.Current.MainWindow = pj;
            this.Close();
            pj.Show();
        }
    }
}
