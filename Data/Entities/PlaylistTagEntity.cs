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
    [Table("playliststag")]
    public class PlaylistTagEntity
    {
        public int PlaylistId { get; set; }
        [ForeignKey(nameof(PlaylistId))]
        public PlaylistEntity Playlist { get; set; }

        public int TagId { get; set; }
        [ForeignKey(nameof(TagId))]
        public TagEntity Tag { get; set; }
    }

}
