#pragma checksum "..\..\..\View\MasterAdmin.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4D16E42808E6CA9832EFE036409FD786CE9BF91237ED0BF18670AAEFC894E5C8"
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
    /// MasterAdmin
    /// </summary>
    public partial class MasterAdmin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\View\MasterAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnKeluar;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\View\MasterAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCari;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\View\MasterAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCari;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\View\MasterAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNama;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\View\MasterAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNotelp;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\View\MasterAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtUsername;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\View\MasterAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtEmail;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\View\MasterAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtPassword;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\View\MasterAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSimpan;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\View\MasterAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTambah;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\View\MasterAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHapus;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\View\MasterAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgAdmin;
        
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
            System.Uri resourceLocater = new System.Uri("/Aplikasi Perpustakaan;component/view/masteradmin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\MasterAdmin.xaml"
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
            this.btnKeluar = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\View\MasterAdmin.xaml"
            this.btnKeluar.Click += new System.Windows.RoutedEventHandler(this.btnKeluar_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtCari = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btnCari = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\View\MasterAdmin.xaml"
            this.btnCari.Click += new System.Windows.RoutedEventHandler(this.btnCari_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtNama = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtNotelp = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtUsername = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 9:
            this.btnSimpan = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\View\MasterAdmin.xaml"
            this.btnSimpan.Click += new System.Windows.RoutedEventHandler(this.btnSimpan_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnTambah = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\View\MasterAdmin.xaml"
            this.btnTambah.Click += new System.Windows.RoutedEventHandler(this.btnTambah_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.btnHapus = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\View\MasterAdmin.xaml"
            this.btnHapus.Click += new System.Windows.RoutedEventHandler(this.btnHapus_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.dgAdmin = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

