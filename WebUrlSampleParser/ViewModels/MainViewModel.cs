using AngleSharp.Attributes;
using Egor92.MvvmNavigation;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using WebUrlSampleParser.ViewModels.ViewModelBase;
using WebUrlSampleParser.Backend;

namespace WebUrlSampleParser.ViewModels
{
   public class MainViewModel : MainViewModelBase
    {
        public MainViewModel(NavigationManager navigationManager) : base(navigationManager)
        {
            Tabs.Add(new TabViewModelBase("MyTab", "gg"));//here you just add your tabs 
        }       
    }
}
