using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayerVinyls.Models
{
    public class Album
    {
        public string AlbumName { get; set; }
        public string AlbumArt { get; set; }
        public string ArtistName { get; set; }
        public string AlbumYear { get; set; }
        public int SongCount { get; set; }
        public string Duration { get; set; }
        public string AlbumNotes { get; set; }
        public List<Tag> Tags { get; set; }
        public double Rating { get; set; }
    }
}
