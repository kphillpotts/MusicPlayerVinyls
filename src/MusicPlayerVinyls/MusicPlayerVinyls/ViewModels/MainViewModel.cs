using MusicPlayerVinyls.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayerVinyls.ViewModels  
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Album> Albums { get; set; }

        public MainViewModel()
        {
            Albums = new ObservableRangeCollection<Album>();

            Albums.Add(new Album()
            {
                AlbumName = "Horses",
                ArtistName = "Patti Smith",
                AlbumArt = "https://upload.wikimedia.org/wikipedia/en/8/88/PattiSmithHorses.jpg",
                AlbumNotes = "Horses is the debut studio album by American musician Patti Smith. It was released on November 10, 1975 by Arista Records. A fixture of the mid-1970s underground rock music scene in New York City, Smith signed to Arista in 1975 and recorded Horses with her band at Electric Lady Studios in August and September of that year. She enlisted former Velvet Underground member John Cale to produce the album.",
                AlbumYear = "1975",
                Duration = "43",
                Rating = 4.9,
                SongCount = 8,
                Tags = new List<Tag>() { new Tag { Name = "Punk" },
                    new Tag { Name = "Classic Rock" }, new Tag { Name = "Art Rock" } } 
                });

            Albums.Add(new Album()
            {
                AlbumName = "Songs in the Key of Life",
                ArtistName = "Stevie Wonder",
                AlbumArt = "https://upload.wikimedia.org/wikipedia/en/e/e2/Songs_in_the_key_of_life.jpg",
                AlbumNotes = "Songs in the Key of Life is the eighteenth studio album by American singer, songwriter and musician Stevie Wonder. It was released on September 28, 1976 by Tamla Records, a division of Motown. The double album has been regarded by music journalists as the culmination of Wonder's 'classic period' of recording.",
                AlbumYear = "1976",
                Duration = "104",
                Rating = 4.9,
                SongCount = 17,
                Tags = new List<Tag>() { new Tag { Name = "Motown" },
                    new Tag { Name = "Soul" }}
            });

            Albums.Add(new Album()
            {
                AlbumName = "The Number of the Beast",
                ArtistName = "Iron Maiden",
                AlbumArt = "https://upload.wikimedia.org/wikipedia/en/3/32/IronMaiden_NumberOfBeast.jpg",
                AlbumNotes = "The Number of the Beast is the third studio album by English heavy metal band Iron Maiden. It was released on 22 March 1982 in the United Kingdom by EMI Records and in the United States by Harvest and Capitol Records. The album was their first to feature vocalist Bruce Dickinson and their last with drummer Clive Burr.",
                AlbumYear = "1982",
                Duration = "39",
                Rating = 4.9,
                SongCount = 8,
                Tags = new List<Tag>() { new Tag { Name = "Heavy Metal" }}
            });
        }
    }
}
