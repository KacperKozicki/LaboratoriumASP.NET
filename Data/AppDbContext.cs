using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<AlbumEntity> Albums { get; set; }
        public DbSet<TrackEntity> Tracks { get; set; } 

        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "labASP.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrackEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<TrackEntity>().HasOne(t => t.Album).WithMany(a => a.Tracklist).HasForeignKey(t => t.AlbumEntityId);

            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity() { Id = 1, Name = "Adam", Email = "adam@wsei.edu.pl", Phone = "127813268163", Birth = new DateTime(2000, 10, 10), Priority = 1, Created = DateTime.Now },
                new ContactEntity() { Id = 2, Name = "Ewa", Email = "ewa@wsei.edu.pl", Phone = "293443823478", Birth = new DateTime(1999, 8, 10), Priority = 2, Created = DateTime.Now }
            );

            modelBuilder.Entity<AlbumEntity>().HasData(
                new AlbumEntity()
                {
                    Id = 1,
                    Name = "Album1",
                    BandOrArtist = "Artist1",
                    ReleaseDate = new DateTime(2022, 1, 1),
                    Created = DateTime.Now,
                    ChartRanking = 1
                },
                new AlbumEntity()
                {
                    Id = 2,
                    Name = "Album2",
                    BandOrArtist = "Artist2",
                    ReleaseDate = new DateTime(2021, 11, 1),
                    Created = DateTime.Now,
                    ChartRanking = 3
                });

            modelBuilder.Entity<TrackEntity>().HasData(
                new TrackEntity { Id = 1, Name = "Pierwszy utwór", AlbumEntityId = 1 },
                new TrackEntity { Id = 2, Name = "Drugi utwór", AlbumEntityId = 1 },
                new TrackEntity { Id = 3, Name = "Trzeci utwór", AlbumEntityId = 1 },
                new TrackEntity { Id = 4, Name = "Pierwszy utwór", AlbumEntityId = 2 },
                new TrackEntity { Id = 5, Name = "Drugi utwór", AlbumEntityId = 2 },
                new TrackEntity { Id = 6, Name = "Trzeci utwór", AlbumEntityId = 2 }
            );
        }




        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    if (entry.Entity is ContactEntity contact && contact.Created == default)
                    {
                        contact.Created = DateTime.Now;
                    }
                    else if (entry.Entity is AlbumEntity album && album.Created == default)
                    {
                        album.Created = DateTime.Now;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
