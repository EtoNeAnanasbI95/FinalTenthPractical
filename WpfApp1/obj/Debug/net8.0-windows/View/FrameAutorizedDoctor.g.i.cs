﻿#pragma checksum "..\..\..\..\View\FrameAutorizedDoctor.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52AF6CC7A29DA7ECBE01A1A271FB57F05265697C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using FinalTenthPractical.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using Wpf.Ui;
using Wpf.Ui.Controls;
using Wpf.Ui.Converters;
using Wpf.Ui.Markup;


namespace FinalTenthPractical.View {
    
    
    /// <summary>
    /// FrameAutorizedDoctor
    /// </summary>
    public partial class FrameAutorizedDoctor : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\View\FrameAutorizedDoctor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumberOfDoctor;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\View\FrameAutorizedDoctor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PasswordDoctor;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FinalTenthPractical;V1.0.0.0;component/view/frameautorizeddoctor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\FrameAutorizedDoctor.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.NumberOfDoctor = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\..\..\View\FrameAutorizedDoctor.xaml"
            this.NumberOfDoctor.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus1);
            
            #line default
            #line hidden
            
            #line 37 "..\..\..\..\View\FrameAutorizedDoctor.xaml"
            this.NumberOfDoctor.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.PasswordDoctor = ((System.Windows.Controls.TextBox)(target));
            
            #line 42 "..\..\..\..\View\FrameAutorizedDoctor.xaml"
            this.PasswordDoctor.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 43 "..\..\..\..\View\FrameAutorizedDoctor.xaml"
            this.PasswordDoctor.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 44 "..\..\..\..\View\FrameAutorizedDoctor.xaml"
            ((Wpf.Ui.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 45 "..\..\..\..\View\FrameAutorizedDoctor.xaml"
            ((Wpf.Ui.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

