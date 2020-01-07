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

namespace WinDesign
{
    /// <summary>
    /// Project1.xaml 的交互逻辑
    /// </summary>
    public partial class Project1 : Window
    {
        public Project1()
        {
            InitializeComponent();
            Load();
        }
        string Winrarpath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\WinRAR archiver";
        string key = "DisplayVersion";

        private void Load()
        {
            //获取注册表值（32位和64位都可以）
            string value = RegUtil.GetRegistryValue(Winrarpath, key);
            Project1_Version.Content = value;
        }

        private void Project1_Change_Click(object sender, RoutedEventArgs e)
        {
            string value = Project1_NewVersion.Text.ToString();
            RegUtil.SetRegistryKey("HKEY_LOCAL_MACHINE", Winrarpath, "DisPlayVersion", value);
            string newValue = RegUtil.GetRegistryValue(Winrarpath, "DisPlayVersion");
            Project1_Version.Content = newValue;
        }
    }
}
