using DBWinWork;
using Devart.Data.MySql;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace DBWinWork
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
        string table = "user";


        private void Dtg_Data_Loaded(object sender, RoutedEventArgs e)
        {
            dtg_Data.ItemsSource = GetData().DefaultView;
        }

        
        //获取数据库中所有数据
        private DataTable GetData()
        {
            string MySql_getAll = ADOProperties.GetAll(table);
            MySqlDataAdapter da;
            DataTable dts = new DataTable();

            string connStr = ADOProperties.connDbStr;
            MySqlConnection conn;

            //初始化连接，并打开
            conn = new MySqlConnection(connStr);
            conn.Open();

            //获取数据源的表定义元数据
            da = new MySqlDataAdapter(MySql_getAll, connStr);
            da.Fill(dts);

            conn.Close();
            return dts;
        }

        //增
        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            string name = txb_AddUserName.Text;
            int age;
            try {
                age = int.Parse(txb_AddUserAge.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("输入的年龄不合法，应当为整数");
                return;
            }
            string phone = txb_AddUserPhone.Text;
            string address = txb_AddUserAddress.Text;
            string connStr = ADOProperties.connDbStr;
            string MySql_getLast = ADOProperties.GetLastUser(table);
            DataTable dts = new DataTable();
            MySqlConnection conn;
            MySqlDataAdapter da;


            //初始化连接，并打开
            conn = new MySqlConnection(connStr);
            conn.Open();

            //获取数据源的表定义元数据
            da = new MySqlDataAdapter(MySql_getLast, connStr);
            da.Fill(dts);

            int id = 0;
            //获取最后一个用户的id
            if (dts.Rows.Count == 0)
            {
                id = 1;
            }
            else
            {
                id = int.Parse(dts.Rows[0][0].ToString()) + 1;
            }
            //添加用户
            string MySql_addUser = ADOProperties.AddUser(table, id, name, age,phone,address);
            MySqlCommand cmd = new MySqlCommand(MySql_addUser, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            //刷新表的值
            dtg_Data.Dispatcher.BeginInvoke(
                    new Action(() => {
                        dtg_Data.ItemsSource = GetData().DefaultView;
                    }));
        }

        //查
        private void Btn_Get_Click(object sender, RoutedEventArgs e)
        {
            int id;
            try
            {
                id = int.Parse(txb_GetUserId.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("输入的数字不合法，应当为整数");
                return;

            }
            string connStr = ADOProperties.connDbStr;
            string MySql_GetOne = ADOProperties.GetUser(table, id);
            MySqlConnection conn;
            MySqlDataAdapter da;
            DataTable dts = new DataTable();

            //初始化连接，并打开
            conn = new MySqlConnection(connStr);
            conn.Open();

            //获取数据源的表定义元数据
            da = new MySqlDataAdapter(MySql_GetOne, connStr);
            da.Fill(dts);

            conn.Close();

            //更新信息
            lb_UserInfo.Content = string.Format("ID:{0} Name:{1} Age:{2} Phone:{3} Address:{4}",
                dts.Rows[0][0].ToString(), dts.Rows[0][1].ToString(), dts.Rows[0][2].ToString(), dts.Rows[0][3].ToString(), dts.Rows[0][4].ToString());
        }

        //改
        private void Btn_Change_Click(object sender, RoutedEventArgs e)
        {
            string name = txb_ChangeUserName.Text;
            int age, id;
            try
            {
                age = int.Parse(txb_ChangeUserAge.Text);
                id = int.Parse(txb_ChangeUserId.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("输入的数字不合法，应当为整数");
                return;
            }
            string phone = txb_ChangeUserPhone.Text;
            string address = txb_ChangeUserAddress.Text;
            string connStr = ADOProperties.connDbStr;
            string MySql_Change = ADOProperties.ChangeUser(table, id, name, age,phone,address);
            MySqlConnection conn;
            DataTable dts = new DataTable();

            //初始化连接，并打开
            conn = new MySqlConnection(connStr);
            conn.Open();

            //获取数据源的表定义元数据
            MySqlCommand cmd = new MySqlCommand(MySql_Change, conn);
            cmd.ExecuteNonQuery();


            conn.Close();
            //刷新表的值
            dtg_Data.Dispatcher.BeginInvoke(
                    new Action(() => {
                        dtg_Data.ItemsSource = GetData().DefaultView;
                    }));
        }

        //删
        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            int id;
            try
            {
                id = int.Parse(txb_DeleteUserId.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("输入的数字不合法，应当为整数");
                return;

            }
            string connStr = ADOProperties.connDbStr;
            string MySql_GetOne = ADOProperties.GetUser(table, id);
            MySqlConnection conn;
            MySqlDataAdapter da;
            DataTable dts = new DataTable();

            //初始化连接，并打开
            conn = new MySqlConnection(connStr);
            conn.Open();

            //获取数据源的表定义元数据
            da = new MySqlDataAdapter(MySql_GetOne, connStr);
            da.Fill(dts);

            conn.Close();

            //信息
            string s = string.Format(" ID:\t{0}\n Name:\t{1}\n Age:\t{2}\n Phone:\t{3}\n Addr:\t{4}\n",
                dts.Rows[0][0].ToString(), dts.Rows[0][1].ToString(), dts.Rows[0][2].ToString(), dts.Rows[0][3].ToString(), dts.Rows[0][4].ToString());

            //删除确认信息
            MessageBoxResult dr = MessageBox.Show("确定要删除该用户吗?请确认：\n"+s, "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (dr == MessageBoxResult.OK)
            {
                string MysqlDelete = ADOProperties.DeleteUser(table, id);
                dts = new DataTable();

                //初始化连接，并打开
                conn = new MySqlConnection(connStr);
                conn.Open();

                //获取数据源的表定义元数据
                da = new MySqlDataAdapter(MysqlDelete, connStr);
                da.Fill(dts);

                conn.Close();

                //刷新表的值
                dtg_Data.Dispatcher.BeginInvoke(
                        new Action(() => {
                            dtg_Data.ItemsSource = GetData().DefaultView;
                        }));
            }
        }

    }
}
