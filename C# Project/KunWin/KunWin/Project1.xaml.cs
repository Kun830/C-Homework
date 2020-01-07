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
using System.Windows.Shapes;
using CsharpDLL;
using Microsoft.Win32;

namespace KunWin
{
    /// <summary>
    /// Project1.xaml 的交互逻辑
    /// </summary>
    public partial class Project1 : Window
    {
        public Project1()
        {
            InitializeComponent();
            //读取注册表值
            Reg_Value.Content = ReadReg();
        }
        //注册表路径以及键值
        string KEY_NAME = "KunWin";


        //CsharpDLL （+ - * /） 操作
        private void CsharpA_Click(object sender, RoutedEventArgs e)
        {

            double value1, value2;
            try
            {
                value1 = double.Parse(Value1.Text);
                value2 = double.Parse(Value2.Text);
                CsharpOpetion.Content = "+";
                CsharpResult.Content = CsharpDLL.CsharpDLL.Add(value1, value2);

            }
            catch (Exception)
            {
                CsharpResult.Content = "Invalid Input";
            }
        }

        private void CsharpS_Click(object sender, RoutedEventArgs e)
        {
            double value1, value2;
            try
            {
                value1 = double.Parse(Value1.Text);
                value2 = double.Parse(Value2.Text);
                CsharpOpetion.Content = "-";
                CsharpResult.Content = CsharpDLL.CsharpDLL.Subtract(value1, value2);

            }
            catch (Exception)
            {
                CsharpResult.Content = "Invalid Input";
            }
        }

        private void CsharpM_Click(object sender, RoutedEventArgs e)
        {
            double value1, value2;
            try
            {
                value1 = double.Parse(Value1.Text);
                value2 = double.Parse(Value2.Text);
                CsharpOpetion.Content = "*";
                CsharpResult.Content = CsharpDLL.CsharpDLL.Multi(value1, value2);

            }
            catch (Exception)
            {
                CsharpResult.Content = "Invalid Input";
            }
        }

        private void CsharpD_Click(object sender, RoutedEventArgs e)
        {
            double value1, value2;
            try
            {
                value1 = double.Parse(Value1.Text);
                value2 = double.Parse(Value2.Text);
                CsharpOpetion.Content = "/";
                CsharpResult.Content = CsharpDLL.CsharpDLL.Divide(value1, value2);

            }
            catch (Exception)
            {
                CsharpResult.Content = "Invalid Input";
            }
        }


        //CppDLL (+ - * /) 操作
        private void CppA_Click(object sender, RoutedEventArgs e)
        {
            double value1, value2;
            try
            {
                value1 = double.Parse(Value3.Text);
                value2 = double.Parse(Value4.Text);
                CppOpetion.Content = "+";
                CppResult.Content = CppDLL.Add(value1, value2);

            }
            catch (Exception er)
            {
                CppResult.Content = "Invalid Input";
                MessageBox.Show(er.Message);
            }
        }

        private void CppS_Click(object sender, RoutedEventArgs e)
        {
            double value1, value2;
            try
            {
                value1 = double.Parse(Value3.Text);
                value2 = double.Parse(Value4.Text);
                CppOpetion.Content = "-";
                CppResult.Content = CppDLL.Subtract(value1, value2);

            }
            catch (Exception)
            {
                CppResult.Content = "Invalid Input";
            }
        }

        private void CppM_Click(object sender, RoutedEventArgs e)
        {
            double value1, value2;
            try
            {
                value1 = double.Parse(Value3.Text);
                value2 = double.Parse(Value4.Text);
                CppOpetion.Content = "*";
                CppResult.Content = CppDLL.Multiply(value1, value2);

            }
            catch (Exception)
            {
                CppResult.Content = "Invalid Input";
            }
        }

        private void CppD_Click(object sender, RoutedEventArgs e)
        {
            double value1, value2;
            try
            {
                value1 = double.Parse(Value3.Text);
                value2 = double.Parse(Value4.Text);
                CppOpetion.Content = "/";
                CppResult.Content = CppDLL.Divide(value1, value2);

            }
            catch (Exception)
            {
                CppResult.Content = "Invalid Input";
            }
        }

        private string ReadReg()
        {
            uint type;
            string keyValue = null;
            StringBuilder keyBuffer = new StringBuilder();
            uint size = 1024;
            if (RegUtil.RegQueryValueEx(RegUtil.HKEY_CURRENT_USER, KEY_NAME,
                IntPtr.Zero, out type, keyBuffer, ref size) == 0)
            {
                keyValue = keyBuffer.ToString();
            }
            else
            {
                MessageBox.Show("注册表读取失败");
            }
            return keyValue;
        }

        //注册表创建并写入
        private void Reg_Change_Click(object sender, RoutedEventArgs e)
        {
            uint result = 0;
            uint ret = 0;
            RegUtil.RegCreateKeyEx(RegUtil.HKEY_CURRENT_USER, KEY_NAME, 0,
                "REG_SZ", RegUtil.REG_OPTION_VOLATILE, RegUtil.KEY_ALL_ACCESS, 0,
                ref result, ref ret);
            if (result == 0)
            {
                MessageBox.Show("创建注册表失败");
            }
            else
            {
                MessageBox.Show("创建注册表成功");
            }
            string val = Reg_Text.Text;
            byte[] value = Encoding.UTF8.GetBytes(val);
            int flag = RegUtil.RegSetValueEx(RegUtil.HKEY_CURRENT_USER, KEY_NAME,
                0, (uint)RegistryValueKind.String, val, (uint)(value.Length) + 1);
            if (flag != 0)
            {
                MessageBox.Show("注册表写入失败");
            }
            else
            {
                MessageBox.Show("注册表写入成功");
            }

            Reg_Value.Content = ReadReg();
            Reg_Text.Text = "";
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
