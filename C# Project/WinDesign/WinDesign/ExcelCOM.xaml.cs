using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.IO;
using MSExcel = Microsoft.Office.Interop.Excel;

namespace WinDesign
{
    /// <summary>
    /// ExcelCOM.xaml 的交互逻辑
    /// </summary>
    public partial class ExcelCOM : Window
    {
        public ExcelCOM()
        {
            InitializeComponent();
            ShowDataInExcel();
        }

        private void ShowDataInExcel()
        {
            MSExcel.Application excelApp;
            excelApp = new MSExcel.Application();
            object Nothing = Missing.Value;
            string path = "D://Documents//test.xls";
            if (!File.Exists(path))
            {
                return;
            }
            MSExcel.Workbook openwb = excelApp.Workbooks.Open(path,
                Nothing, Nothing, Nothing, Nothing,Nothing, Nothing, Nothing, Nothing,
                Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);
            MSExcel.Worksheet ws = (MSExcel.Worksheet)openwb.Worksheets.get_Item(1);
            int columns = ws.UsedRange.Columns.Count;
            int rows = ws.UsedRange.Rows.Count;
            List<List<string>> table = new List<List<string>>();
            for(int i = 1; i < rows; i++)
            {
                List<string> tmp = new List<string>();
                for(int j = 0; j < columns; j++)
                {
                    tmp.Add(((MSExcel.Range)ws.Cells[i, j]).Text.ToString());
                }
                table.Add(tmp);
            }
            ExcelCOM_Data.ItemsSource=table;
        }

        private void ExcelCOM_Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
