using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Data.Entities
{
    [Table("playlist_tracks")]
    public class PlaylistTrackEntity
    {
        //[Key]
        //public int Id { get; set; }

        public int PlaylistId { get; set; }
        [ForeignKey(nameof(PlaylistId))]
        public PlaylistEntity Playlist { get; set; }

        public int TrackId { get; set; }
        [ForeignKey(nameof(TrackId))]
        public TrackEntity Track { get; set; }
    }

}
