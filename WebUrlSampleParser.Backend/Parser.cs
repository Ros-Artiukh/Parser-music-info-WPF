using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using SampleProject.Backend.Model;
using WebUrlSampleParser.Backend.Model;

namespace WebUrlSampleParser.Backend
{
    public class Parser
    {
        private string _link;
        // for tracks
        private List<Track> _tracksList = new List<Track>();
        // for albums
        private List<Album> _albumsList = new List<Album>();
        // Main Image for tracklist page
        public string ImageAlbum { get; set; }
        public Parser(string link)
        {
            if (string.IsNullOrEmpty(link)) throw new ArgumentNullException(nameof(link));
            _link = link;
        }
        // getting out html 
        public string getResponse()
        {            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_link);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default, true, 8192))
            {
                return reader.ReadToEnd();
            }
        }
        //getting album list
        public async Task<List<Album>> GetAlbums()
        {
            var context = BrowsingContext.New(Configuration.Default);
            var document = await context.OpenAsync(req => req.Content(getResponse()));    
            
            var name = document.QuerySelectorAll("li .info .title");
            var link = (document.QuerySelectorAll(".album-highlights .title > a").Attr("href")).ToArray();
            var nameGroup = document.QuerySelector("li .info .artist");
            var image = (document.QuerySelectorAll(".album-highlights img.lazy").Attr("src")).ToArray();
            for (var i = 0; i < name.Length; i++)
            {
                _albumsList.Add(new Album()
                {
                    Image = image[i],
                    Group = nameGroup.TextContent.Trim(),
                    Name =  name[i].TextContent.Trim(),
                    ToTracks = link[i]
                });
            }                
            return _albumsList;
        }
        // using html content from the  getResponse() and parsing info with AngleSharp
        public async Task<List<Track>> GetTracks()
        {
            var context = BrowsingContext.New(Configuration.Default);
            var document = await context.OpenAsync(req => req.Content(getResponse()));
            var listNames = document.QuerySelectorAll(".title > a:first-child");
            var listDurations = document.QuerySelectorAll("td.time");            
            var nameGroup = document.QuerySelector(".album-artist a");
            var nameAlbum = document.QuerySelector(".album-title");
                ImageAlbum = document.QuerySelector(".album-contain img").GetAttribute("src");
            for (var i = 0; i < listNames.Length; i++)
            {
                _tracksList.Add(new Track()
                {
                    Album = nameAlbum.Text(),
                    Artist = nameGroup.Text(),
                    Duration = listDurations[i].TextContent.Trim(),
                    Title = listNames[i].Text()
                });
            }        
            return _tracksList;
        }
   }
}
