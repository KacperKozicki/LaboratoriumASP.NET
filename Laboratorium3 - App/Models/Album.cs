using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium3___App.Models
{
    public class Album
    {

        [HiddenInput]
        public int Id { get; set; } // Unique identifier for the album

        [Required(ErrorMessage = "Musisz podać nazwę albumu!")]
        [StringLength(maximumLength: 70, ErrorMessage = "Zbyt długa nazwa albumu, max 70 znaków")]
        public string Name { get; set; } // Name of the album

        [Required(ErrorMessage = "Musisz podać nazwę wykonawcy!")]
        [StringLength(maximumLength: 70, ErrorMessage = "Zbyt długa nazwa wykonawcy, max 70 znaków")]
        public string BandOrArtist { get; set; } // Name of the band or artist

        [Required(ErrorMessage = "Musisz podać conajmniej jeden utwór!")]
        public List<string> Tracklist { get; set; } // List of songs on the album


        public string? ChartRanking { get; set; } // Chart ranking (e.g., Billboard 200)
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; } // Release date of the album
        public TimeSpan? Duration { get; set; } // Duration of the album

        // Constructor to initialize the properties
        public Album()
        {
            Tracklist = new List<string>();
        }

    }
}
