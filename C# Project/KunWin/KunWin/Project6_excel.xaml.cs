using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
    /// Project6_excel.xaml 的交互逻辑
    /// </summary>
    public partial class Project6_excel : Window
    {
        string table = "[Sheet1$]";
        public Project6_excel()
        {
            InitializeComponent();
        }


        private void Dtg_ExcelData_Loaded(object sender, RoutedEventArgs e)
        {
            dtg_ExcelData.ItemsSource = GetData().DefaultView;
        }

        private DataTable GetData()
        {
            string connStr = ADOProperties.connExcelStr;
            string sql_getAll = ADOProperties.GetAll(table);
            DataTable dts = new DataTable();
            OleDbConnection conn;
            OleDbDataAdapter da;

            //初始化连接，并打开
            conn = new OleDbConnection(connStr);
            conn.Open();

            //获取数据源的表定义元数据
            da = new OleDbDataAdapter(sql_getAll, connStr);
            da.Fill(dts);

            conn.Close();
            return dts;
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            string name = txb_AddUserName.Text;
            int age = int.Parse(txb_AddUserAge.Text);
            string connStr = ADOProperties.connExcelStr;
            string sql_getLast = ADOProperties.GetLastUser(table);
            DataTable dts = new DataTable();
            OleDbConnection conn;
            OleDbDataAdapter da;
            

            //初始化连接，并打开
            conn = new OleDbConnection(connStr);
            conn.Open();

            //获取数据源的表定义元数据
            da = new OleDbDataAdapter(sql_getLast, connStr);
            da.Fill(dts);

            //获取最后一个用户的id
            int id = int.Parse(dts.Rows[0][0].ToString())+1;
            //添加用户
            string sql_addUser = ADOProperties.AddUser(table, id,name,age);
            OleDbCommand cmd = new OleDbCommand(sql_addUser, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            //刷新表的值
            dtg_ExcelData.Dispatcher.BeginInvoke(
                    new Action(() => {
                        dtg_ExcelData.ItemsSource = GetData().DefaultView;
            }));
        }

        private void Btn_Get_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txb_GetUserId.Text);
            string connStr = ADOProperties.connExcelStr;
            string sql_GetOne = ADOProperties.GetUser(table,id);
            OleDbConnection conn;
            OleDbDataAdapter da;
            DataTable dts = new DataTable();

            //初始化连接，并打开
            conn = new OleDbConnection(connStr);
            conn.Open();

            //获取数据源的表定义元数据
            da = new OleDbDataAdapter(sql_GetOne, connStr);
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
            string connStr = ADOProperties.connExcelStr;
            string sql_Change = ADOProperties.ChangeUser(table, id,name,age);
            OleDbConnection conn;
            DataTable dts = new DataTable();

            //初始化连接，并打开
            conn = new OleDbConnection(connStr);
            conn.Open();

            //获取数据源的表定义元数据
            OleDbCommand cmd = new OleDbCommand(sql_Change, conn);
            cmd.ExecuteNonQuery();


            conn.Close();
            //刷新表的值
            dtg_ExcelData.Dispatcher.BeginInvoke(
                    new Action(() => {
                        dtg_ExcelData.ItemsSource = GetData().DefaultView;
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
