﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium3___App.Models
{
    public class Album
    {
        [HiddenInput]
        public DateTime Created { get; set; }

        [HiddenInput]
        public int Id { get; set; } 

        [Required(ErrorMessage = "Musisz podać nazwę albumu!")]
        [StringLength(maximumLength: 70, ErrorMessage = "Zbyt długa nazwa albumu, max 70 znaków")]
        [Display(Name = "Nazwa albumu")]
        public string Name { get; set; } 

        [Required(ErrorMessage = "Musisz podać nazwę wykonawcy!")]
        [StringLength(maximumLength: 70, ErrorMessage = "Zbyt długa nazwa wykonawcy, max 70 znaków")]
        [Display(Name = "Zespół / Artysta")]
        public string BandOrArtist { get; set; }

        [Required(ErrorMessage = "Musisz podać conajmniej jeden utwór!")]
        [MinLength(1, ErrorMessage = "Musisz podać conajmniej jeden utwór!")]
        [Display(Name = "Lista piosenek")]
        public List<Track> Tracklist { get; set; }


        [Display(Name = "Notowania")]
        public AlbumChartRanking ChartRanking { get; set; } 

        [DataType(DataType.Date)]
        [Display(Name = "Data wydania")]
        public DateTime? ReleaseDate { get; set; }
        [ValidateNever]
        public TimeSpan? Duration
        {
            get
            {
                if (Tracklist == null || !Tracklist.Any())
                    return null;

                return TimeSpan.FromSeconds(Tracklist.Sum(track => track.Duration.TotalSeconds));
            }
            set { }
        }




        //[ValidateNever]
        [Display(Name = "Gatunek")]
        [Required(ErrorMessage = "Musisz podać gatunek!")]
        public int? GenreId { get; set; }
        [ValidateNever]
        public string GenreName { get; set; }
        [ValidateNever]
        public List<SelectListItem> Genres { get; set; }


        public Album()
        {
            Tracklist = new List<Track>();
        }

        public class Track
        {
            [Required(ErrorMessage = "Musisz podać nazwę utworu!")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Musisz podać czas trwania utworu!")]
            public TimeSpan Duration { get; set; }
        }
    }
    
}
