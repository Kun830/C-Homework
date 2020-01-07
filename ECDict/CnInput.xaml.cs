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

namespace ECDict
{
    /// <summary>
    /// CnInput.xaml 的交互逻辑
    /// </summary>
    public partial class CnInput : Window
    {
        //输入完成事件
        public delegate void FinishHandler(string newCn);
        public FinishHandler finishHandler;

        public CnInput()
        {
            InitializeComponent();
        }

        //输入修改
        private void Btn_Confirm_Click(object sender, RoutedEventArgs e)
        {
            string newCn = txb_Cn.Text;
            if (newCn == "")
            {
                MessageBox.Show("请输入新的中文释义！");
                return;
            }
            finishHandler(newCn);
            Close();
        }
    }
}
