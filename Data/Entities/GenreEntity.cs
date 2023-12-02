using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("genres")]
    public class GenreEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public History History { get; set; }


        public ISet<AlbumEntity> Albums { get; set; }
        public ISet<PlaylistEntity> Playlists { get; set; }
    }
}
