using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WebUrlSampleParser.ViewModels;
using WebUrlSampleParser.Backend;


namespace WebUrlSampleParser.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl, IGetLink
    {
        private Parser _dataRos = new Parser(IGetLink.Link);

        public MainView()
        {
            InitializeComponent();

            // start parsing
            var myList = _dataRos.GetTracks().GetAwaiter().GetResult();

            // setting parsed items for view
            lvTracks.ItemsSource = myList;

            // setting  parsed image link album for view            
            var uriSource = new Uri(_dataRos.ImageAlbum);
            AlbumImg.Source = new BitmapImage(uriSource);
        }
    }
}
