using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using Data.Entities;

namespace Laboratorium3___App.Models
{
    public class Playlist
    {
        [HiddenInput]
        public DateTime Created { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }

       
        [ValidateNever]
        public string GenreName { get; set; }
        [ValidateNever]
        public List<SelectListItem> Genres { get; set; }


        public List<int> TrackIds { get; set; }
        public List<int> TagIds { get; set; }
        public TimeSpan TotalDuration { get; set; }
        public bool IsPublic { get; set; }
        public List<string> TrackNames { get; set; }
        public List<TrackDetails> TrackDetails { get; set; }
        public List<SelectListItem> Tags { get; set; }
        public List<string> TagNames { get; set; } // Dodane pole


        public Playlist()
        {
            TrackIds = new List<int>();
            TrackNames = new List<string>();
            TagNames = new List<string>();
            TagIds = new List<int>();
            //Tags= new List<TagEntity>();
            TrackDetails = new List<TrackDetails>(); // Inicjalizacja listy
        }
    }

    // Klasa pomocnicza do przechowywania szczegółów utworu
    public class TrackDetails
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string BandOrArtist { get; set; }
        public TimeSpan Duration { get; set; }
        public string AlbumName { get; set; }
    }

}
