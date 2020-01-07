using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KunWin
{
    class ADOProperties
    {
        public static string xlsPath = @"D:\Documents\Visual Stdio Workplace\C# Project\data.xlsx;";
        public static string connExcelStr = "Provider = Microsoft.ACE.OLEDB.12.0;" +
                "Extended Properties = \"Excel 12.0;HDR=Yes;IMEX=3\";" +
                "Data Source=" + xlsPath;

        public static string connDbStr = "Server=localhost;port=3307;Database =wintest;Uid=root;Pwd=01234567;";
        public static string GetUser(string table,int id)
        {
            return string.Format("SELECT * from {0} WHERE `id` = {1}", table, id);
        }

        public static string GetLastUser(string table)
        {
            return string.Format("SELECT * FROM {0} ORDER BY `id` DESC", table);
        }

        public static string GetAll(string table)
        {
            return string.Format("SELECT * from {0}", table);
        }

        public static string AddUser(string table, int id, string name,int age)
        {
            return string.Format("INSERT INTO {0} (`id`,`name`,`age`) VALUES ({1},\"{2}\",{3})", table, id, name, age);
        }

        public static string ChangeUser(string table, int id, string name, int age)
        {
            return string.Format("UPDATE {0} SET `name` = \"{2}\", `age` = {3} WHERE `id` = {1}", table, id, name, age);
        }

        public static string DeleteUser(string table, int id)
        {
            return string.Format("Delete FROM {0} WHERE `id` = {1}", table, id);
        }
    }
}
