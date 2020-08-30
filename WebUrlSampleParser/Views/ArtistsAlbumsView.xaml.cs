using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WebUrlSampleParser.ViewModels;
using WebUrlSampleParser.Backend;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Documents;
using WebUrlSampleParser.Backend.Model;
using Egor92.MvvmNavigation;
using Egor92.MvvmNavigation.Abstractions;
using WebUrlSampleParser.Constants;
using WebUrlSampleParser.ViewModels.ViewModelBase;

namespace WebUrlSampleParser.Views
{
    /// <summary>
    /// Interaction logic for ArtistsAlbumsView.xaml
    /// </summary>
    public partial class ArtistsAlbumsView : UserControl, IGetLink
    {
        private Parser _dataRos = new Parser(IGetLink.Link);
        private List<Album> _MyAlbums { get; set; }
        private void clickAlbum(object sender, EventArgs e)

        {
            int i = lvAlbums.SelectedIndex;
            IGetLink.Link = _MyAlbums[i].ToTracks;
        }
        public ArtistsAlbumsView()
        {
            InitializeComponent();

            var myList = _dataRos.GetAlbums().GetAwaiter().GetResult();
            lvAlbums.ItemsSource = myList;
            _MyAlbums = myList;
        }
    }
}
