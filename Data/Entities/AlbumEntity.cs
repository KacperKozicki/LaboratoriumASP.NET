using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("albums")]
    public class AlbumEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(70)]
        [Required]
        public string Name { get; set; }

        [MaxLength(70)]
        [Required]
        public string BandOrArtist { get; set; }

        // Adjust the data type based on your requirements
        [Column("release_date")]
        public DateTime? ReleaseDate { get; set; }

        // Adjust the data type based on your requirements
        public TimeSpan? Duration { get; set; }

        // Assuming you have a separate entity for AlbumChartRanking
        public int ChartRanking { get; set; }

        // Adjust the data type based on your requirements
        public ICollection<TrackEntity> Tracklist { get; set; }

        // You might need to change this based on your requirements
        public DateTime Created { get; set; }
        public GenreEntity Genre { get; set; }
        public int GenreId { get; set; }
    }

    
}
