using Egor92.MvvmNavigation;
using Egor92.MvvmNavigation.Abstractions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WebUrlSampleParser.Constants;
using WebUrlSampleParser.ViewModels;
using WebUrlSampleParser.Views;

namespace WebUrlSampleParser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //here you define all your vm`s you`ll need to navigate with
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = new MainWindow();
            var navigationManager = new NavigationManager(mainWindow);
            navigationManager.Register<AuthorizeView>(NavigationKeys.Login, () => new LoginViewModel(navigationManager));
            navigationManager.Register<MainView>(NavigationKeys.Main, () => new MainViewModel(navigationManager));
            navigationManager.Register<ArtistsAlbumsView>(NavigationKeys.ArtistsAlbums, () => new LoginViewModel(navigationManager));
            mainWindow.Show();
            navigationManager.Navigate(NavigationKeys.Login);
        }
    }
}
