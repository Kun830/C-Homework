using System;
using System.Collections.Generic;
using System.Linq;
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
using CsharpDLL;

namespace SimpleCalc
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        enum operation { ADD,SUBSRACT,MULTIPLY,DIVIDE,NONE};
        //结果保存
        List<double> result = new List<double>();
        List<string> formulars = new List<string>();
        //最大结果保存个数
        int length = 10;
        //上一个结果
        double pre = 0;
        //前置操作数
        Boolean hasPre = false;

        //操作
        operation op = operation.NONE;

        public MainWindow()
        {
            InitializeComponent();
        }

        //操作结算
        void calc(double value)
        {
            switch (op)
            {
                case operation.ADD:
                    pre = CsharpDLL.CsharpDLL.Add(pre, value);
                    break;
                case operation.SUBSRACT:
                    pre = CsharpDLL.CsharpDLL.Subtract(pre, value);
                    break;
                case operation.MULTIPLY:
                    pre = CsharpDLL.CsharpDLL.Multi(pre, value);
                    break;
                case operation.DIVIDE:
                    pre = CsharpDLL.CsharpDLL.Divide(pre, value);
                    break;
                default:
                    pre = value;
                    break;
            }
            op = operation.NONE;
        }
        //获取输入
        void getInput()
        {
            double value;
            try
            {
                value = double.Parse(Value1.Text);
                if (value == 0&&op==operation.DIVIDE)
                {
                    MessageBox.Show("Divider can't be Zero!");
                    throw new ZeroException();
                }
                txb_Formular.Content = txb_Formular.Content + value.ToString(); 
                calc(value);
                CsharpResult.Content = pre;
                Value1.Text = "";
            }
            catch (ZeroException x)
            {
                throw x;
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Input");
                throw new ZeroException();
            }
        }

        //加
        private void CsharpA_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (hasPre)
                    hasPre = false;
                else getInput();
                op = operation.ADD;
                txb_Formular.Content = txb_Formular.Content + "+";
            }
            catch (ZeroException)
            {
                clear();
            }
        }

        //减
        private void CsharpS_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (hasPre)
                    hasPre = false;
                else getInput();
                op = operation.SUBSRACT;
                txb_Formular.Content = txb_Formular.Content + "-";
            }
            catch (ZeroException)
            {
                clear();
            }
        }

        //乘
        private void CsharpM_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (hasPre)
                    hasPre = false;
                else getInput();
                op = operation.MULTIPLY;
                txb_Formular.Content = txb_Formular.Content + "*";
            }
            catch (ZeroException)
            {
                clear();
            }
        }

        //除
        private void CsharpD_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (hasPre)
                    hasPre = false;
                else getInput();
                op = operation.DIVIDE;
                txb_Formular.Content = txb_Formular.Content + "/";
            }
            catch (ZeroException)
            {
                clear();
            }
        }

        //等于结算
        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (hasPre)
                    hasPre = false;
                else getInput();
                op = operation.NONE;
                result.Add(pre);
                formulars.Add((string)txb_Formular.Content);
                int len = result.Count;
                if (len == length + 1)
                {
                    result.RemoveAt(0);
                    formulars.RemoveAt(0);
                }
                txb_History.Text = txb_History.Text + (string)txb_Formular.Content + "=" + pre + "\n\n";
                txb_Formular.Content = pre;
                hasPre = true;
            }
            catch (ZeroException)
            {
                clear();
            }
        }

        //按钮输入
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Value1.Text = Value1.Text+(button.Content.ToString());
        }

        //删除一个输入字符
        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Value1.Text.Length > 0)
                Value1.Text = Value1.Text.Substring(0, Value1.Text.Length - 1);
        }

        //计算历史回退
        private void Btn_back_Click(object sender, RoutedEventArgs e)
        {
            int len = formulars.Count;
            if (len == 0)
            {
                MessageBox.Show("回退栈已空，无法回退");
                return;
            }
            string formular = formulars.ElementAt(len - 1);
            txb_Formular.Content = formular.Split('=')[0];
            pre = result.ElementAt(len - 1);
            CsharpResult.Content = pre;
            formulars.RemoveAt(len - 1);
            result.RemoveAt(len - 1);
            txb_History.Text = "";
            for(int i = 0; i < formulars.Count; i++)
            {
                txb_History.Text = txb_History.Text + formulars.ElementAt(i) + "=" + result.ElementAt(i) + "\n\n";
            }
            op = operation.NONE;
            hasPre = true;
        }

        //清空计算
        private void Btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        //计算初始化
        void clear()
        {
            txb_Formular.Content = "";
            hasPre = false;
            CsharpResult.Content = "0";
            Value1.Text = "";
            pre = 0;
            op = operation.NONE;
        }
    }
}
