﻿#pragma checksum "C:\Users\Alex\documents\visual studio 2010\Projects\SplitTheBill\SplitTheBill\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D91C60DEF633D63CA96E7A3FEFE8FE5E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Coding4Fun.Phone.Controls;
using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace SplitTheBill {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal Coding4Fun.Phone.Controls.RoundButton continueButton;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.Grid LayoutGrid;
        
        internal Coding4Fun.Phone.Controls.SuperSlider peopleSlider;
        
        internal System.Windows.Controls.Image UpButton;
        
        internal System.Windows.Controls.TextBlock sliderBlock;
        
        internal System.Windows.Controls.Image DownButton;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/SplitTheBill;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.continueButton = ((Coding4Fun.Phone.Controls.RoundButton)(this.FindName("continueButton")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.LayoutGrid = ((System.Windows.Controls.Grid)(this.FindName("LayoutGrid")));
            this.peopleSlider = ((Coding4Fun.Phone.Controls.SuperSlider)(this.FindName("peopleSlider")));
            this.UpButton = ((System.Windows.Controls.Image)(this.FindName("UpButton")));
            this.sliderBlock = ((System.Windows.Controls.TextBlock)(this.FindName("sliderBlock")));
            this.DownButton = ((System.Windows.Controls.Image)(this.FindName("DownButton")));
        }
    }
}

