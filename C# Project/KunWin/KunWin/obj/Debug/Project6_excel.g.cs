﻿#pragma checksum "..\..\Project6_excel.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E590FB0935DE6E483D4F9180A1A0708361AEFA1D835AAB89D2743DE14CD1C3B4"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using KunWin;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace KunWin {
    
    
    /// <summary>
    /// Project6_excel
    /// </summary>
    public partial class Project6_excel : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Project6_excel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtg_ExcelData;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Project6_excel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Add;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Project6_excel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Get;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Project6_excel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Change;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Project6_excel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txb_AddUserName;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Project6_excel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txb_AddUserAge;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Project6_excel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txb_GetUserId;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Project6_excel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lb_UserInfo;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Project6_excel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txb_ChangeUserId;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Project6_excel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txb_ChangeUserName;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Project6_excel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txb_ChangeUserAge;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Project6_excel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Exit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/KunWin;component/project6_excel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Project6_excel.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dtg_ExcelData = ((System.Windows.Controls.DataGrid)(target));
            
            #line 10 "..\..\Project6_excel.xaml"
            this.dtg_ExcelData.Loaded += new System.Windows.RoutedEventHandler(this.Dtg_ExcelData_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_Add = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\Project6_excel.xaml"
            this.btn_Add.Click += new System.Windows.RoutedEventHandler(this.Btn_Add_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_Get = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\Project6_excel.xaml"
            this.btn_Get.Click += new System.Windows.RoutedEventHandler(this.Btn_Get_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_Change = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\Project6_excel.xaml"
            this.btn_Change.Click += new System.Windows.RoutedEventHandler(this.Btn_Change_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txb_AddUserName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txb_AddUserAge = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txb_GetUserId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.lb_UserInfo = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.txb_ChangeUserId = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.txb_ChangeUserName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.txb_ChangeUserAge = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.btn_Exit = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\Project6_excel.xaml"
            this.btn_Exit.Click += new System.Windows.RoutedEventHandler(this.Btn_Exit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

