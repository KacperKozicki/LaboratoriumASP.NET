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

        [Required(ErrorMessage = "Musisz podać nazwę Playlisty!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Musisz podać gatunek Playlisty!")]
        public int GenreId { get; set; }
        [ValidateNever]
        public string UserId { get; set; }

       
        [ValidateNever]
        public string GenreName { get; set; }
        [ValidateNever]
        public List<SelectListItem> Genres { get; set; }

        [ValidateNever]
        public List<int> TrackIds { get; set; }
        [Required(ErrorMessage = "Musisz podać tagi dla Playlisty!")]
        public List<int> TagIds { get; set; }

        [ValidateNever]
        public TimeSpan TotalDuration { get; set; }

        [Required(ErrorMessage = "Musisz określić status!")]
        public bool IsPublic { get; set; }
        [Required(ErrorMessage = "Musisz dodać utwory dla Playlisty!")]
        public List<string> TrackNames { get; set; }
        [ValidateNever]
        public List<TrackDetails> TrackDetails { get; set; }
        [ValidateNever]
        public List<SelectListItem> Tags { get; set; }
        [ValidateNever]
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
}
