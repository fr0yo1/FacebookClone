using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookClone.Models
{
    public class AlbumViewModel
    {

        public List<String> albumPicturesRelativePath { get; set; }
        public string albumName { get; set; }
        public string appLocation { get; set; }


        public AlbumViewModel(List<string> albumPicturesRelativePath, string albumName, string appLocation)
        {
            this.albumPicturesRelativePath = albumPicturesRelativePath;
            this.albumName = albumName;
            this.appLocation = appLocation;
        }
    }
}