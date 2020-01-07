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

namespace KunWin
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Project1_Click(object sender, RoutedEventArgs e)
        {
            Project1 pj = new Project1();
            Application.Current.MainWindow = pj;
            this.Close();
            pj.Show();
        }

        private void Project2_Click(object sender, RoutedEventArgs e)
        {
            Project2 pj  = new Project2();
            Application.Current.MainWindow = pj ;
            this.Close();
            pj.Show();
        }

        private void Project3_Click(object sender, RoutedEventArgs e)
        {
            Project3 pj = new Project3();
            Application.Current.MainWindow = pj;
            this.Close();
            pj.Show();
        }

        private void Project4_Click(object sender, RoutedEventArgs e)
        {
            Project4 pj = new Project4();
            Application.Current.MainWindow = pj;
            this.Close();
            pj.Show();
        }
        private void Btn_Project5_1_Click(object sender, RoutedEventArgs e)
        {
            Project5_wpf pj = new Project5_wpf();
            Application.Current.MainWindow = pj;
            this.Close();
            pj.Show();
        }

        private void Btn_Project5_2_Click(object sender, RoutedEventArgs e)
        {
            Project5_winform pj = new Project5_winform();
            pj.Show();
        }

        private void Btn_Project6_1_Click(object sender, RoutedEventArgs e)
        {
            Project6_excel pj = new Project6_excel();
            Application.Current.MainWindow = pj;
            this.Close();
            pj.Show();
        }

        private void Btn_Project6_2_Click(object sender, RoutedEventArgs e)
        {
            Project6_db pj = new Project6_db();
            Application.Current.MainWindow = pj;
            this.Close();
            pj.Show();
        }
    }
}
