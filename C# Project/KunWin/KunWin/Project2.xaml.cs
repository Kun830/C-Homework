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
using Microsoft.Office;
using MyCOM;
using MsWord = Microsoft.Office.Interop.Word;
using Window = System.Windows.Window;
using Microsoft.Office.Core;

namespace KunWin
{
    /// <summary>
    /// Project2.xaml 的交互逻辑
    /// </summary>
    public partial class Project2 : Window
    {
        MyCOM.MyClass com = new MyClass();
        public Project2()
        {
            InitializeComponent();
        }

        //Com （+ -） 操作
        private void ComA_Click(object sender, RoutedEventArgs e)
        {
            double value1, value2;
            try
            {
                
                value1 = double.Parse(Value1.Text);
                value2 = double.Parse(Value2.Text);
                ComOperation.Content = "+";
                ComResult.Content = com.Add(value1, value2);

            }
            catch (Exception)
            {
                ComResult.Content = "Invalid Input";
            }
        }

        private void ComS_Click(object sender, RoutedEventArgs e)
        {
            double value1, value2;
            try
            {

                value1 = double.Parse(Value1.Text);
                value2 = double.Parse(Value2.Text);
                ComOperation.Content = "-";
                ComResult.Content = com.Subtract(value1, value2);

            }
            catch (Exception)
            {
                ComResult.Content = "Invalid Input";
            }
        }

        //word 参数
        private string header = "KunWin Word";
        private string title = "First Chapter: Word Operation";
        private string content = "使用标头(索引) 或页脚(索引), 其中索引是WdHeaderFooterIndex常量之一 " +
            "(wdHeaderFooterEvenPages、 wdHeaderFooterFirstPage或wdHeaderFooterPrimary), 以返回单个HeaderFooter对象。" +
            " 下面的示例更改主页眉和活动文档第一节的主页脚的文字。";
        private string[] references = { "刘国钧，陈绍业.图书馆目录[M].北京：高等教育出版社，1957.15-18.",
            "OU J P，SOONG T T，et al.Recent advance in research on applications of passive energy dissipation systems[J].Earthquack Eng,1997,38(3):358-361.",
            "谢希德.创造学习的新思路[N].人民日报，1998-12-25（10）.",
            "王明亮.关于中国学术期刊标准化数据库系统工程的进展[EB/OL]." };
        private string filename = @"C:\Users\kun\Desktop\Test";

        //开始使用word com 进行操作
        private void Word_Click(object sender, RoutedEventArgs e)
        {
            MsWord.Application wordApp = new MsWord.Application();
            wordApp.Visible = false;

            object missing = System.Reflection.Missing.Value;
            MsWord.Document doc = wordApp.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            doc.Activate();

            //设置节位置
            int curSelectionNum = 1;
            wordApp.Options.Overtype = false;
            MsWord.Selection curSelection = wordApp.Selection;

            //插入页眉
            wordApp.ActiveWindow.ActivePane.View.Type = MsWord.WdViewType.wdPrintView;
            wordApp.ActiveWindow.View.SeekView = MsWord.WdSeekView.wdSeekCurrentPageHeader;
            wordApp.Selection.HeaderFooter.Range.ParagraphFormat.Alignment = MsWord.WdParagraphAlignment.wdAlignParagraphCenter;
            wordApp.Selection.HeaderFooter.Range.Text = header;

            //插入章节标题，大小为H1
            object titleStyle = MsWord.WdBuiltinStyle.wdStyleHeading1;
            doc.Sections[curSelectionNum].Range.Select();
            curSelection.TypeText(title);
            curSelection.TypeParagraph();

            //插入章节内容
            curSelection.TypeText(content);
            curSelection.TypeParagraph();

            //插入艺术字
            float leftPosition = (float)wordApp.Selection.Information[MsWord.WdInformation.wdHorizontalPositionRelativeToPage];
            float topPosition = (float)wordApp.Selection.Information[MsWord.WdInformation.wdVerticalPositionRelativeToPage];
            wordApp.ActiveDocument.Shapes.AddTextEffect(
                MsoPresetTextEffect.msoTextEffect29, "Beyond the Game",
                "Arial Black", 24, MsoTriState.msoFalse,
                MsoTriState.msoFalse, 0, 0);
            curSelection.TypeParagraph();

            curSelection.TypeText("参考文献");
            curSelection.TypeParagraph();
            for (int i = 0; i < references.Length; i++)
            {
                curSelection.TypeText(string.Format("[{0}] {1}", i, references[i]));
                curSelection.TypeParagraph();
            }

            //储存文件
            object file = filename;
            doc.SaveAs2(ref file);
            doc.Close();

            

            // 释放COM资源
            System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
            doc = null;
            wordApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
            wordApp = null;
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
