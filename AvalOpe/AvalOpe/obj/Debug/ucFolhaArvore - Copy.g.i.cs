﻿#pragma checksum "..\..\ucFolhaArvore - Copy.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7C5D1CDA2065C97DC464BB3FDEA5168D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AvalOpe;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace AvalOpe {
    
    
    /// <summary>
    /// ucFolhaArvore
    /// </summary>
    public partial class ucFolhaArvore : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\ucFolhaArvore - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas fundo;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ucFolhaArvore - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Titulo;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ucFolhaArvore - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblPeso;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\ucFolhaArvore - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblDesvio;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ucFolhaArvore - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Peso;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\ucFolhaArvore - Copy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Desvio;
        
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
            System.Uri resourceLocater = new System.Uri("/AvalOpe;component/ucfolhaarvore%20-%20copy.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ucFolhaArvore - Copy.xaml"
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
            this.fundo = ((System.Windows.Controls.Canvas)(target));
            return;
            case 2:
            this.Titulo = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.lblPeso = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lblDesvio = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.Peso = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\ucFolhaArvore - Copy.xaml"
            this.Peso.LostFocus += new System.Windows.RoutedEventHandler(this.Peso_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Desvio = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\ucFolhaArvore - Copy.xaml"
            this.Desvio.LostFocus += new System.Windows.RoutedEventHandler(this.Desvio_LostFocus);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

