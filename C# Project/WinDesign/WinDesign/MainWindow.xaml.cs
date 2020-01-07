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
using Microsoft.Win32;
using CsharpDLL;
using MSWord =  Microsoft.Office.Interop.Word;
using System.IO;
using System.Reflection;
using Microsoft.Office;
using Window = System.Windows.Window;

namespace WinDesign
{

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            MyInitial();
        }

        private void MyInitial()
        {
            this.Project1.Visibility = Visibility.Hidden;
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            MyInitial();
            Project1.Visibility = Visibility.Visible;
        }

        private void Project1_Read_Click(object sender, RoutedEventArgs e)
        {
            RegistryKey rkLocalMachine = Registry.LocalMachine;
            RegistryKey rkChild;
            if (Project1_ReadKey.Text != null && !Project1_ReadKey.Equals("") &&
                (rkChild = rkLocalMachine.OpenSubKey("SOFTWARE\\" + Project1_ReadKey.Text, true))!=null){
                string[] names = rkChild.GetValueNames();
                string value = "";
                int count = 0;
                foreach (string name in names)
                {
                    if (count == 2)
                    {
                        value += "...";
                        break;
                    }
                    value += name+": "+rkChild.GetValue(name).ToString();
                    count++;
                    value += "\t";
                }
                Project1_ReadContent.Content = value;
            }
            else
            {
                Project1_ReadContent.Content = "Invalid Input";
            }
            
        }

        private void Project1_Create_Click(object sender, RoutedEventArgs e)
        {
            RegistryKey rkLocalMachine = Registry.LocalMachine;
            if (rkLocalMachine.OpenSubKey(Project1_CreatePos.Text) == null)
            {
                RegistryKey tmp = rkLocalMachine.CreateSubKey("SOFTWARE\\"+Project1_CreatePos.Text);
                tmp.Close();
            }
            RegistryKey rkChild = rkLocalMachine.OpenSubKey("SOFTWARE\\"+Project1_CreatePos.Text, true);
            string name = Project1_CreateKey.Text;
            string value = Project1_CreateValue.Text;
            rkChild.SetValue(name, value);
        }

        private void Project1_Delete_Click(object sender, RoutedEventArgs e)
        {
            RegistryKey rkLocalMachine = Registry.LocalMachine;
            rkLocalMachine.DeleteSubKey("SOFTWARE\\" + Project1_DeleteKey.Text);
        }


        private void Project1_Csharp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem tmp = (ComboBoxItem)Project1_Csharp.SelectedValue;
            string method = tmp.Content.ToString();

            double value1, value2;
            try
            {
                value1 = double.Parse(Project1_Value3.Text);
                value2 = double.Parse(Project1_Value4.Text);
                switch (method)
                {
                    case "+":
                        Project1_Result2.Content = CsharpDLL.CsharpDLL.Add(value1, value2);
                        break;
                    case "-":
                        Project1_Result2.Content = CsharpDLL.CsharpDLL.Subtract(value1, value2);
                        break;
                    case "*":
                        Project1_Result2.Content = CsharpDLL.CsharpDLL.Multi(value1, value2);
                        break;
                    case "/":
                        Project1_Result2.Content = CsharpDLL.CsharpDLL.Divide(value1, value2);
                        break;
                }

            }
            catch (Exception)
            {
                Project1_Result2.Content = "Invalid Input";
            }
        }

        private void Project1_C2Plus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem tmp = (ComboBoxItem)Project1_C2Plus.SelectedItem;
            string method = tmp.Content.ToString();
            double value1, value2;
            try
            {
                value1 = double.Parse(Project1_Value1.Text);
                value2 = double.Parse(Project1_Value2.Text);
                switch (method)
                {
                    case "+":
                        Project1_Result1.Content = C2plusDLL.Add(value1, value2);
                        break;
                    case "-":
                        Project1_Result1.Content = C2plusDLL.Subtract(value1, value2);
                        break;
                    case "*":
                        Project1_Result1.Content = C2plusDLL.Multiply(value1, value2);
                        break;
                    case "/":
                        Project1_Result1.Content = C2plusDLL.Divide(value1, value2);
                        break;
                }
            }
            catch (Exception)
            {
                Project1_Result1.Content = "Invalid Input";
            }
        }

        private void Project2_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {             
                double value1, value2;
                value1 = double.Parse(Project2_Value1.Text);
                value2 = double.Parse(Project2_Value2.Text);
                Project2_Result1.Content = (new MyCOM.MyClass()).Add(value1, value2);
            }
            catch (Exception)
            {
                Project2_Result1.Content = "Invalid Input";
            }
        }

        private void Project2_Subtract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double value1, value2;
                value1 = double.Parse(Project2_Value3.Text);
                value2 = double.Parse(Project2_Value4.Text);
                Project2_Result2.Content = (new MyCOM.MyClass()).Subtract(value1, value2);
            }
            catch (Exception)
            {
                Project2_Result2.Content = "Invalid Input";
            }
        }

        private void Project2_WordCOM_Click(object sender, RoutedEventArgs e)
        {
            object path;
            string strContent;
            MSWord.Application wordApp;
            MSWord.Document wordDoc;
            path = "D://Documents//myWord.doc";
            wordApp = new MSWord.Application();
            if (File.Exists((string)path))
            {
                File.Delete((string)path);
            }
            Object Nothing = Missing.Value;
            wordDoc = wordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);

            wordDoc.Sections.Add(Nothing, wordDoc.Paragraphs.Last);
            wordApp.Selection.ParagraphFormat.LineSpacing = 35f;
            wordApp.Selection.ParagraphFormat.FirstLineIndent = 30;
            strContent = "文献引用:\n【1】https://docs.microsoft.com/zh-cn";
            wordDoc.Paragraphs.Last.Range.Text = strContent;
            wordDoc.Sections.Add(ref Nothing, ref Nothing);

            float leftPosition = (float)wordApp.Selection.Information[
    MSWord.WdInformation.wdHorizontalPositionRelativeToPage];
            float topPosition = (float)wordApp.Selection.Information[
                MSWord.WdInformation.wdVerticalPositionRelativeToPage];
            wordApp.ActiveDocument.Shapes.AddTextEffect(
    Microsoft.Office.Core.MsoPresetTextEffect.msoTextEffect29, "SampleText",
    "Arial Black", 24, Microsoft.Office.Core.MsoTriState.msoFalse,
    Microsoft.Office.Core.MsoTriState.msoFalse, leftPosition, topPosition);

            foreach(MSWord.Section section in wordApp.ActiveDocument.Sections)
            {
                MSWord.Range headRange = section.Headers[MSWord.WdHeaderFooterIndex.
                    wdHeaderFooterPrimary].Range;
                headRange.Font.ColorIndex = MSWord.WdColorIndex.wdDarkRed;
                headRange.Font.Size = 20;
                headRange.Text = "添加页眉";
            }

            object format = MSWord.WdSaveFormat.wdFormatDocument;
            wordDoc.SaveAs(ref path, ref format, ref Nothing, ref Nothing,
                ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing,
                ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
            wordDoc.Close(ref Nothing, ref Nothing, ref Nothing);
            wordApp.Quit(ref Nothing, ref Nothing, ref Nothing);
        }

        private void Project2_ExcelCOM_Click(object sender, RoutedEventArgs e)
        {
            ExcelCOM excelCOM = new ExcelCOM();
            excelCOM.Show();
            this.Close();
        }
    }
}
