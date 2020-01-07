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
using System.Windows.Shapes;

namespace KunWin
{
    /// <summary>
    /// Project6_db.xaml 的交互逻辑
    /// </summary>
    public partial class Project6_db : Window
    {
        public Project6_db()
        {
            InitializeComponent();
        }
        string table = "user";


        private void Dtg_Data_Loaded(object sender, RoutedEventArgs e)
        {
            dtg_Data.ItemsSource = GetData().DefaultView;
        }

        private DataTable GetData()
        {
            string connStr = ADOProperties.connDbStr;
            string MySql_getAll = ADOProperties.GetAll(table);
            DataTable dts = new DataTable();
            MySqlConnection conn;
            MySqlDataAdapter da;

            //初始化连接，并打开
            conn = new MySqlConnection(connStr);
            conn.Open();

            //获取数据源的表定义元数据
            da = new MySqlDataAdapter(MySql_getAll, connStr);
            da.Fill(dts);

            conn.Close();
            return dts;
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            string name = txb_AddUserName.Text;
            int age = int.Parse(txb_AddUserAge.Text);
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
            string MySql_addUser = ADOProperties.AddUser(table, id, name, age);
            MySqlCommand cmd = new MySqlCommand(MySql_addUser, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            //刷新表的值
            dtg_Data.Dispatcher.BeginInvoke(
                    new Action(() => {
                        dtg_Data.ItemsSource = GetData().DefaultView;
                    }));
        }

        private void Btn_Get_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txb_GetUserId.Text);
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
            lb_UserInfo.Content = string.Format("Name:{0} Age:{1}", dts.Rows[0][1].ToString(), dts.Rows[0][2].ToString());
        }

        private void Btn_Change_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txb_ChangeUserId.Text);
            string name = txb_ChangeUserName.Text;
            int age = int.Parse(txb_ChangeUserAge.Text);
            string connStr = ADOProperties.connDbStr;
            string MySql_Change = ADOProperties.ChangeUser(table, id, name, age);
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

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txb_DeleteUserId.Text);
            string connStr = ADOProperties.connDbStr;
            string MySql_GetOne = ADOProperties.DeleteUser(table, id);
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

            //刷新表的值
            dtg_Data.Dispatcher.BeginInvoke(
                    new Action(() => {
                        dtg_Data.ItemsSource = GetData().DefaultView;
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
