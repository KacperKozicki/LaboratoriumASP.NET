using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("playlists")]
    public class PlaylistEntity
    {
        public DateTime Created { get; set; }
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        public int GenreId { get; set; }
        [ForeignKey(nameof(GenreId))]
        public GenreEntity Genre { get; set; }

        public ICollection<PlaylistTrackEntity> PlaylistTracks { get; set; }

        public string Tags { get; set; } // Rozważ użycie innego typu dla tagów
        public TimeSpan TotalDuration { get; set; }
        public bool IsPublic { get; set; }
    }

}
