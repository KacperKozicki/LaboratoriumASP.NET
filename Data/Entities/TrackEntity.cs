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
    [Table("tracks")]
    public class TrackEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        // Inne właściwości utworu

        public int AlbumEntityId { get; set; }

        [ForeignKey(nameof(AlbumEntityId))]
        public AlbumEntity Album { get; set; }
    }
}
