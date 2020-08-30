using Egor92.MvvmNavigation;
using Egor92.MvvmNavigation.Abstractions;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WebUrlSampleParser.Constants;
using WebUrlSampleParser.ViewModels.ViewModelBase;
using WebUrlSampleParser.Backend;
using System.Linq;

namespace WebUrlSampleParser.ViewModels
{
    public class LoginViewModel : MainViewModelBase, IGetLink
    {
        public string SelectedSite { get; set; }
        public RelayCommand SubmitCommand { get; private set; }

        public LoginViewModel(NavigationManager navigationManager) : base(navigationManager)
            => SubmitCommand = new RelayCommand(_ => Submit());      
        public void Submit()
        {
            if(!string.IsNullOrEmpty(SelectedSite)) IGetLink.Link = SelectedSite; // setting link for parsing tracks
         
            if (IGetLink.Link.Contains("allmusic.com/album"))
            {
                NavigationManager.Navigate(NavigationKeys.Main);
            }
            else
            {
                NavigationManager.Navigate(NavigationKeys.ArtistsAlbums);
            }       
        }        
    }
}
