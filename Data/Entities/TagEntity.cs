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
    [Table("tags")]
    public class TagEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PlaylistTagEntity> PlaylistTags { get; set; }
    }

}
