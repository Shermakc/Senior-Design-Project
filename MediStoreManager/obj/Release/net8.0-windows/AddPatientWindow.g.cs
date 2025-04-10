﻿#pragma checksum "..\..\..\AddPatientWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C889B7D84DDA4DBE130D320B3E49FA76480839E4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MediStoreManager;
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


namespace MediStoreManager {
    
    
    /// <summary>
    /// AddPatientWindow
    /// </summary>
    public partial class AddPatientWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 22 "..\..\..\AddPatientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\AddPatientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MiddleNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\AddPatientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LastNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\AddPatientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox HomePhoneTextBox;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\AddPatientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CellPhoneTextBox;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\AddPatientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StreetAddressTextBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\AddPatientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CityTextBox;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\AddPatientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StateTextBox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\AddPatientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ZipTextBox;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\AddPatientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox InsuranceTextBox;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\AddPatientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddNewContactButton;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\AddPatientWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl ContactItemsControl;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MediStoreManager;component/addpatientwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddPatientWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 18 "..\..\..\AddPatientWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeletePatientButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.FirstNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.MiddleNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.LastNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.HomePhoneTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.CellPhoneTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.StreetAddressTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.CityTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.StateTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.ZipTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.InsuranceTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this.AddNewContactButton = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\AddPatientWindow.xaml"
            this.AddNewContactButton.Click += new System.Windows.RoutedEventHandler(this.AddNewContactButton_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.ContactItemsControl = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 15:
            
            #line 69 "..\..\..\AddPatientWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_OK);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 72 "..\..\..\AddPatientWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Cancel);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 14:
            
            #line 58 "..\..\..\AddPatientWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoveContactButton_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

