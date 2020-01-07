using System;
using System.Collections.Generic;
using System.Linq;
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

namespace KunWin
{
    /// <summary>
    /// Project4.xaml 的交互逻辑
    /// </summary>
    public partial class Project4 : Window
    {
        public Project4()
        {
            InitializeComponent();
        }
        //生产池容量
        int poolSize = 10;
        //生产目标
        int totalSize = 20;
        //生产数量
        int productCnt = 0;
        int preProductCnt = 0;
        int consumeCnt = 0;
        //生产消费者数量
        int producerCnt = 0;
        int consumerCnt = 0;
        //信号量
        Semaphore empty;
        Semaphore full;
        //生产完成互斥锁
        Mutex totalMutex = new Mutex();
        //防入取出互斥锁
        Mutex inMutex = new Mutex();
        Mutex outMutex = new Mutex();

        private void initProduct()
        {
            productCnt = 0;
            consumeCnt = 0;
            preProductCnt = 0;
            MessageBox.Show(string.Format("开始生产消费模拟，生产池容量为{0}",poolSize));
            txb_msg.Text = "";
        }

        private void Btn_begin_Click(object sender, RoutedEventArgs e)
        {
            initProduct();
            producerCnt = int.Parse(txb_Producer.Text);
            consumerCnt = int.Parse(txb_Consumer.Text);
            empty = new Semaphore(poolSize, poolSize);
            full = new Semaphore(0, poolSize);
            Btn_begin.IsEnabled = false;
            //开启生产者
            for(int i = 0; i < producerCnt; i++)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(Produce))
                {
                    Name = "第"+i+"号生产者"
                };
                thread.Start(thread.Name);
            }

            //开启消费者
            for (int i = 0; i < consumerCnt; i++)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(Consume))
                {
                    Name = "第" + i + "号消费者"
                };
                thread.Start(thread.Name);
            }

        }

        private void Consume(object obj)
        {
            while (true)
            {
                totalMutex.WaitOne();
                //生产满足要求
                if (consumeCnt >= totalSize)
                {
                    consumerCnt--;
                    MsgCommon(string.Format("------------------\n" +
                        "达到预定的生产目标{0}.{1}结束", totalSize, obj.ToString()));
                    totalMutex.ReleaseMutex();
                    if (producerCnt == 0 && consumerCnt == 0)
                    {
                        IsEnable(true);
                        MessageBox.Show("所有消费生产线程完成");
                    }
                    return;
                }
                //生产未满足要求
                totalMutex.ReleaseMutex();

                full.WaitOne();
                outMutex.WaitOne();
                MsgCommon(string.Format("------------------\n" +
                        "{0}开始消费", obj.ToString()));
                consumeCnt++;
                outMutex.ReleaseMutex();
                empty.Release();
                //模拟消费延时
                Thread.Sleep(1000);
                MsgCommon(string.Format("------------------\n" +
                        "{0}完成消费，当前消费数为{1}", obj.ToString(),consumeCnt));
            }
        }

        private void Produce(object obj)
        {
            while (true)
            {
                totalMutex.WaitOne();
                //生产完成
                if (preProductCnt >= totalSize)
                {
                    producerCnt--;
                    MsgCommon(string.Format("------------------\n" +
                        "达到预定的消费目标{0}.{1}结束", totalSize, obj.ToString()));
                    totalMutex.ReleaseMutex();
                    if (producerCnt == 0&&consumerCnt==0)
                    {
                        IsEnable(true);
                        MessageBox.Show("所有消费生产线程完成");
                    }
                    return;
                }
                //生产未完成
                preProductCnt++;
                totalMutex.ReleaseMutex();

                empty.WaitOne();
                inMutex.WaitOne();
                MsgCommon(string.Format("------------------\n" +
                        "{0}完成一次生产，当前生产数量为{1}",obj.ToString(), productCnt ));
                productCnt++;
                //模拟生产延时
                Thread.Sleep(1000);
                full.Release();
                inMutex.ReleaseMutex();
            }
        }

        private void IsEnable(Boolean enable)
        {
            Btn_begin.Dispatcher.BeginInvoke(new Action(() => {
                Btn_begin.IsEnabled = enable;
            }));
        }

        //消息显示
        private void MsgCommon(string v)
        {
            txb_msg.Dispatcher.BeginInvoke(new Action(() => {
                txb_msg.AppendText(v + "\n");
                txb_msg.ScrollToEnd();
            }));
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
