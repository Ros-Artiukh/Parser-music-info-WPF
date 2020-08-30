using Egor92.MvvmNavigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using WebUrlSampleParser.Backend;

namespace WebUrlSampleParser.ViewModels.ViewModelBase
{
    public class MainViewModelBase
    {
        public ObservableCollection<TabViewModelBase> Tabs { get; set; } = new ObservableCollection<TabViewModelBase>();//you could dynamically add\remove tabs
        public NavigationManager NavigationManager { get; set; }
        public TabViewModelBase SelectedTab { get; set; }
        public MainViewModelBase(NavigationManager navigation)
        {
            NavigationManager = navigation;
        }
        public static void BeginInvokeOnMainThread(Action action)
        {
            Application.Current.Dispatcher.Invoke(action);
        }
    }
}
