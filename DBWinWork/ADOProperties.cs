
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBWinWork
{
    class ADOProperties
    {
        //excel路径
        public static string xlsPath = @"D:\Documents\Visual Stdio Workplace\C# Project\data.xlsx;";
        //excel连接字符串
        public static string connExcelStr = "Provider = Microsoft.ACE.OLEDB.12.0;" +
                "Extended Properties = \"Excel 12.0;HDR=Yes;IMEX=3\";" +
                "Data Source=" + xlsPath;

        //数据库连接字符串
        public static string connDbStr = "Server=localhost;port=3307;Database =wintest;Uid=root;Pwd=01234567;";

        //用户查询
        public static string GetUser(string table, int id)
        {
            return string.Format("SELECT * from {0} WHERE `id` = {1}", table, id);
        }

        

        //获取所有用户
        public static string GetAll(string table)
        {
            return string.Format("SELECT * from {0}", table);
        }

        //降序获取用户
        public static string GetLastUser(string table)
        {
            return string.Format("SELECT * FROM {0} ORDER BY `id` DESC", table);
        }

        //添加用户
        public static string AddUser(string table, int id, string name, int age, string phone, string address)
        {
            return string.Format("INSERT INTO {0} (`id`,`name`,`age`,`phone`,`address`) VALUES ({1},\"{2}\",{3},\"{4}\",\"{5}\")",
                table, id, name, age,phone,address);
        }

        //更新用户
        public static string ChangeUser(string table, int id, string name, int age, string phone, string address)
        {
            return string.Format("UPDATE {0} SET `name` = \"{2}\", `age` = {3}, `phone` = \"{4}\"," +
                " `address` = \"{5}\" WHERE `id` = {1}", table, id, name, age, phone, address);
        }

        //删除用户
        public static string DeleteUser(string table, int id)
        {
            return string.Format("Delete FROM {0} WHERE `id` = {1}", table, id);
        }
    }
}
