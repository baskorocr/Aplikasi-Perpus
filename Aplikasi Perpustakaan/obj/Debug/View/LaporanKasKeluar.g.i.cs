﻿#pragma checksum "..\..\..\View\LaporanKasKeluar.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "69209B838CCF299355A5FDE589BF26D0F9198CFD98C03939B6C8718A3E47B2AC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Aplikasi_Perpustakaan.View;
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


namespace Aplikasi_Perpustakaan.View {
    
    
    /// <summary>
    /// LaporanKasKeluar
    /// </summary>
    public partial class LaporanKasKeluar : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\View\LaporanKasKeluar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCetakKasMasuk;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\View\LaporanKasKeluar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbLaporanKK;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\View\LaporanKasKeluar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCariKM;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\View\LaporanKasKeluar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgLaporanKK;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\View\LaporanKasKeluar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTotal;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\View\LaporanKasKeluar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnKeluar;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\View\LaporanKasKeluar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCetakKasMasuk_Copy;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\View\LaporanKasKeluar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTotalKeluar;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\View\LaporanKasKeluar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTotalKeseluruhan;
        
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
            System.Uri resourceLocater = new System.Uri("/Aplikasi Perpustakaan;component/view/laporankaskeluar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\LaporanKasKeluar.xaml"
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
            this.btnCetakKasMasuk = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\View\LaporanKasKeluar.xaml"
            this.btnCetakKasMasuk.Click += new System.Windows.RoutedEventHandler(this.btnCetakKasMasuk_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cmbLaporanKK = ((System.Windows.Controls.ComboBox)(target));
            
            #line 34 "..\..\..\View\LaporanKasKeluar.xaml"
            this.cmbLaporanKK.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbDisplay_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtCariKM = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\..\View\LaporanKasKeluar.xaml"
            this.txtCariKM.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtCariKM_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dgLaporanKK = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.lblTotal = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.btnKeluar = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\View\LaporanKasKeluar.xaml"
            this.btnKeluar.Click += new System.Windows.RoutedEventHandler(this.btnKeluar_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnCetakKasMasuk_Copy = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.lblTotalKeluar = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.lblTotalKeseluruhan = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
