using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebUrlSampleParser.ViewModels.ViewModelBase
{
    [AddINotifyPropertyChangedInterface]
    public class TabViewModelBase
    {
        public string Title { get; set; }
        public string Url { get; set; }//if you`ll need to have specific url to parse from you can put it here for each tab
        public TabViewModelBase(string title, string url)
        {
            Title = title;
            Url = url;
        }

    }
}
