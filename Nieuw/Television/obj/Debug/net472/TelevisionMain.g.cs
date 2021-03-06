#pragma checksum "..\..\..\TelevisionMain.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7A3B34B12DDBE47770A6C9EB38E43E55256803A2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Television;


namespace Television {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\TelevisionMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_OnOff;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\TelevisionMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Source;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\TelevisionMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_ChannelUp;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\TelevisionMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_Channel;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\TelevisionMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_ChannelDown;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\TelevisionMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_VolumeUp;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\TelevisionMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txt_Volume;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\TelevisionMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_VolumeDown;
        
        #line default
        #line hidden
        
        /// <summary>
        /// txt_CurrentSource Name Field
        /// </summary>
        
        #line 26 "..\..\..\TelevisionMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.TextBlock txt_CurrentSource;
        
        #line default
        #line hidden
        
        /// <summary>
        /// txt_CurrentChannel Name Field
        /// </summary>
        
        #line 27 "..\..\..\TelevisionMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.TextBlock txt_CurrentChannel;
        
        #line default
        #line hidden
        
        /// <summary>
        /// txt_CurrentVolume Name Field
        /// </summary>
        
        #line 28 "..\..\..\TelevisionMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        public System.Windows.Controls.TextBlock txt_CurrentVolume;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Television;component/televisionmain.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\TelevisionMain.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\TelevisionMain.xaml"
            ((Television.MainWindow)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_OnOff = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\TelevisionMain.xaml"
            this.btn_OnOff.Click += new System.Windows.RoutedEventHandler(this.btn_OnOff_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_Source = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\TelevisionMain.xaml"
            this.btn_Source.Click += new System.Windows.RoutedEventHandler(this.btn_Source_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_ChannelUp = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\TelevisionMain.xaml"
            this.btn_ChannelUp.Click += new System.Windows.RoutedEventHandler(this.btn_ChannelUp_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txt_Channel = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.btn_ChannelDown = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\TelevisionMain.xaml"
            this.btn_ChannelDown.Click += new System.Windows.RoutedEventHandler(this.btn_ChannelDown_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btn_VolumeUp = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\TelevisionMain.xaml"
            this.btn_VolumeUp.Click += new System.Windows.RoutedEventHandler(this.btn_VolumeUp_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.txt_Volume = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.btn_VolumeDown = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\TelevisionMain.xaml"
            this.btn_VolumeDown.Click += new System.Windows.RoutedEventHandler(this.btn_VolumeDown_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.txt_CurrentSource = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.txt_CurrentChannel = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.txt_CurrentVolume = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

