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
using static KunWin.WinAPI;

namespace KunWin
{
    public partial class Project5_winform : Form
    {
        public Project5_winform()
        {
            InitializeComponent();
            initEvent();
            MessageBox.Show(this.Handle.ToString());
        }
        const int WM_COPYDATA = 0x0004A;
        Produce produce;


        // 消息处理函数
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_COPYDATA:
                    COPYDATASTRUCT cds = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));
                    string str = cds.lpData;
                    txb_Receiver.AppendText(DateTime.Now + "\n");
                    txb_Receiver.AppendText(str + "\n");
                    break;
                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }




        //定义委托类型
        public delegate void ProduceEventHandler(object sender, ProduceEventArgs fe);
        //定义事件参数
        public partial class ProduceEventArgs : EventArgs
        {
            public string name { set; get; }
            public int productNum { set; get; }
            public ProduceEventArgs(string name, int productNum)
            {
                this.name = name;
                this.productNum = productNum;
            }
        }

        public partial class Produce
        {
            //委托声明事件
            public event EventHandler<ProduceEventArgs> ProduceDone;

            //激活事件的方法, 发起事件，并将事件参数对象传递过去
            public void Done(string name, int cnt)
            {
                ProduceEventArgs produceArgs = new ProduceEventArgs(name, cnt);
                //执行对象事件处理函数指针，必须保证处理函数要和声明代理时的参数列表相同
                if (ProduceDone != null)
                    ProduceDone(this, produceArgs);
            }
        }
        //定义两个函数对应于生产完成事件
        public void ShowProducer(object sender, ProduceEventArgs e)
        {
            txb_EventMsg.AppendText("生产者为：" + e.name + "\n该消息来自ShowProducer()\n");
        }
        public void ShowProductNum(object sender, ProduceEventArgs e)
        {
            txb_EventMsg.AppendText("生产数为：" + e.productNum + "\n该消息来自ShowProductNum()\n");
        }
        //初始化时，注册事件
        private void initEvent()
        {
            produce = new Produce();
            produce.ProduceDone += ShowProducer;
            produce.ProduceDone += ShowProductNum;
        }


        //事件触发
        private void Button2_Click(object sender, EventArgs e)
        {
            string name = txb_ProducerName.Text;
            int cnt = int.Parse(txb_ProductNum.Text);
            //事件触发
            produce.Done(name, cnt);
            txb_ProductNum.Text = "";
            txb_ProducerName.Text = "";
        }
    }
}
