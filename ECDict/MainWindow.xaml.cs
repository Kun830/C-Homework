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

namespace ECDict
{
    public partial class MainWindow : Window
    {
        //连接字符串
        private const string connStr = "127.0.0.1:6379,password=,DefaultDatabase=0";
        private string curKey;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                RedisOperator.setCon(connStr);
                MessageBox.Show("Redis连接成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //单词查询
        private void Btn_Query_Click(object sender, RoutedEventArgs e)
        {
            string queryStr = txb_Query.Text;
            if (!RedisOperator.isExist(queryStr))
            {
                MessageBox.Show("该单词不存在！");
                return;
            }
            Word res = (Word)RedisOperator.getObj(queryStr);
            txb_Result.Text = res.ToString();
            curKey = queryStr;
        }

        //添加词条
        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            string eng = txb_InsertEng.Text;
            string cn = txb_InsertCn.Text;
            if (eng == "" || cn == "")
            {
                MessageBox.Show("中英文词条信息缺失，请填写完整！");
                return;
            }
            if (!isEnglishWord(eng))
            {
                MessageBox.Show("英文单词格式错误！");
                return;
            }
            if (RedisOperator.isExist(eng))
            {
                MessageBox.Show("单词已存在，信息覆盖！");
                Word word = new Word(eng, cn);
                RedisOperator.set(eng, word);
            }
            else
            {
                Word word = new Word(eng, cn);
                RedisOperator.set(eng, word);
                MessageBox.Show(String.Format("添加单词{0}成功！", eng));
            }
        }

        //判断是否为英文单词
        private bool isEnglishWord(string word)
        {
            foreach (char ch in word)
            {
                // 不是字母或连词符
                if (!Char.IsLetter(ch) && ch != '-')
                {
                    return false;
                }
            }
            return true;
        }

        //修改单词中文释义
        private void Btn_Change_Click(object sender, RoutedEventArgs e)
        {
            if (curKey == null || curKey == "")
            {
                MessageBox.Show("请先查询单词！");
                return;
            }
            if (!RedisOperator.isExist(curKey))
            {
                MessageBox.Show("查询不到该单词，\n无法修改！");
                return;
            }
            //输入界面
            CnInput cnInput = new CnInput();
            cnInput.finishHandler += Modify;
            cnInput.ShowDialog();
        }
        private void Modify(string newCn)
        {
            RedisOperator.set(curKey, new Word(curKey, newCn));
            MessageBox.Show("修改成功！");
        }


        //删除单词
        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if (curKey == null || curKey == "")
            {
                MessageBox.Show("请先查询单词！");
                return;
            }
            if (!RedisOperator.isExist(curKey))
            {
                MessageBox.Show("该单词不存在，\n删除失败！");
                return;
            }
            MessageBoxResult rs = MessageBox.Show("是否删除单词: " + curKey,
                "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (rs == MessageBoxResult.OK)
            {
                RedisOperator.remove(curKey);
                MessageBox.Show("删除成功！");
                txb_Query.Text = "";
                txb_Result.Text = "";
            }
        }
    }
}
