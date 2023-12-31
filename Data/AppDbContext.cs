using Data.Entities;
using Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<AlbumEntity> Albums { get; set; }
        public DbSet<TrackEntity> Tracks { get; set; }

        public DbSet<OrganizationEntity> Organizations { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<PlaylistEntity> Playlists { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<PlaylistTagEntity> PlaylistTagEntity { get; set; }
        public DbSet<PlaylistTrackEntity> PlaylistTracks { get; set; }


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
            base.OnModelCreating(modelBuilder);

            string ADMIN_ID = Guid.NewGuid().ToString();
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();

            string USER_ROLE_ID = Guid.NewGuid().ToString();

            string ARTIST_ROLE_ID = Guid.NewGuid().ToString();

            string JULIA_ID = Guid.NewGuid().ToString();
            string TOMEK_ID = Guid.NewGuid().ToString();
            string MICHAEL_ID = Guid.NewGuid().ToString();



            var user = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "adam@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "adam",
                NormalizedEmail="ADAM@WSEI.EDU.PL",
                NormalizedUserName = "ADAM"

            };
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            user.PasswordHash = ph.HashPassword(user, "Admin123#");

            var julia = new IdentityUser
            {
                Id = JULIA_ID,
                Email = "julia@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "julia",
                NormalizedEmail = "JULIA@WSEI.EDU.PL",
                NormalizedUserName = "JULIA"

            };
            PasswordHasher<IdentityUser> pr = new PasswordHasher<IdentityUser>();
            julia.PasswordHash = pr.HashPassword(julia, "Julia123#");

            var tomek = new IdentityUser
            {
                Id = TOMEK_ID,
                Email = "tomek@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "tomek",
                NormalizedEmail = "TOMEK@WSEI.EDU.PL",
                NormalizedUserName = "TOMEK"
            };
            tomek.PasswordHash = ph.HashPassword(tomek, "Tomek123#");

            var michael = new IdentityUser
            {
                Id = MICHAEL_ID,
                Email = "michael@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "michael",
                NormalizedEmail = "MICHAEL@WSEI.EDU.PL",
                NormalizedUserName = "MICHAEL"
            };
            michael.PasswordHash = ph.HashPassword(michael, "Michael123#");



           

            var adminRole = new IdentityRole
            {
                Name = "ADMIN",
                NormalizedName = "ADMIN",
                Id = ADMIN_ROLE_ID,
                ConcurrencyStamp = ADMIN_ROLE_ID
            };

           

            var userRole = new IdentityRole
            {
                Name = "USER",
                NormalizedName = "USER",
                Id = USER_ROLE_ID,
                ConcurrencyStamp = USER_ROLE_ID
            };


            var artistRole = new IdentityRole
            {
                Name = "ARTIST",
                NormalizedName = "ARTIST",
                Id = ARTIST_ROLE_ID,
                ConcurrencyStamp = ARTIST_ROLE_ID
            };





            modelBuilder.Entity<IdentityUser>().HasData(user, julia, tomek, michael);
            modelBuilder.Entity<IdentityRole>().HasData(adminRole, userRole, artistRole);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = ADMIN_ROLE_ID, UserId = ADMIN_ID },
                new IdentityUserRole<string> { RoleId = USER_ROLE_ID, UserId = JULIA_ID },
                new IdentityUserRole<string> { RoleId = USER_ROLE_ID, UserId = TOMEK_ID },
                new IdentityUserRole<string> { RoleId = ARTIST_ROLE_ID, UserId = MICHAEL_ID }
            );


            modelBuilder.Entity<ContactEntity>()
                .HasOne(c => c.Ogranization)
                .WithMany(o => o.Contacts)
                .HasForeignKey(c => c.OrganizationId);

            modelBuilder.Entity<AlbumEntity>()
                .HasOne(c => c.Genre)
                .WithMany(o => o.Albums)
                .HasForeignKey(c => c.GenreId);

            modelBuilder.Entity<PlaylistEntity>()
                .HasOne(c => c.Genre)
                .WithMany(o => o.Playlists)
                .HasForeignKey(c => c.GenreId);


            // Konfiguracja dla TagEntity
            modelBuilder.Entity<TagEntity>()
                .HasKey(t => t.Id);

            // Konfiguracja dla PlaylistTag
            modelBuilder.Entity<PlaylistTagEntity>()
                .HasKey(pt => new { pt.PlaylistId, pt.TagId });

            modelBuilder.Entity<PlaylistTagEntity>()
                .HasOne(pt => pt.Playlist)
                .WithMany(p => p.PlaylistTags)
                .HasForeignKey(pt => pt.PlaylistId);

            modelBuilder.Entity<PlaylistTagEntity>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.PlaylistTags)
                .HasForeignKey(pt => pt.TagId);



            //dodanie organizacji
            modelBuilder.Entity<OrganizationEntity>()
                .HasData(
                    new OrganizationEntity()
                    {
                        Id = 1,
                        Name = "WSEI",
                        Description = "Uczelnia",
                    },
                    new OrganizationEntity()
                    {
                        Id = 2,
                        Name = "UJ",
                        Description = "Uczelnia",
                    },
                    new OrganizationEntity()
                    {
                        Id = 3,
                        Name = "AGH",
                        Description = "Uczelnia",
                    },
                    new OrganizationEntity()
                    {
                        Id = 4,
                        Name = "NOKIA",
                        Description = "Firma",
                    }
                );


            //dodanie organizacji
            modelBuilder.Entity<GenreEntity>()
                .HasData(
                    new GenreEntity()
                    {
                        Id = 1,
                        Name = "Rock",
                        Description = "Lorem",
                    },
                    new GenreEntity()
                    {
                        Id = 2,
                        Name = "Jazz",
                        Description = "Lorem",
                    },
                    new GenreEntity()
                    {
                        Id = 3,
                        Name = "Clasic",
                        Description = "Lorem",
                    },
                    new GenreEntity()
                    {
                        Id = 4,
                        Name = "Pop",
                        Description = "Lorem",
                    }
                );


            modelBuilder.Entity<TrackEntity>().HasKey(t => t.Id);
            modelBuilder.Entity<TrackEntity>().HasOne(t => t.Album).WithMany(a => a.Tracklist).HasForeignKey(t => t.AlbumEntityId);

           

            //dodanie kontaktów
            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity() { Id = 1, Name = "Adam", Email = "adam@wsei.edu.pl", Phone = "127813268163", Birth = new DateTime(2000, 10, 10), Priority = 1, Created = DateTime.Now , OrganizationId=1},
                new ContactEntity() { Id = 2, Name = "Ewa", Email = "ewa@wsei.edu.pl", Phone = "293443823478", Birth = new DateTime(1999, 8, 10), Priority = 2, Created = DateTime.Now , OrganizationId =1}
            );

            //zwiazek między klasą a encją, złączenie encji i pola klasy 
            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(o => o.Adress)
                .HasData(
                new { OrganizationEntityId = 1, City = "Kraków", Street = "Św. Filipa 17", PostalCode = "31-150" },
                new { OrganizationEntityId = 2, City = "Kraków", Street = "Gołębia 24", PostalCode = "31-007" },
                new { OrganizationEntityId = 3, City = "Kraków", Street = "al. Adama Mickiewicza 30", PostalCode = "31-059" },
                new { OrganizationEntityId = 4, City = "Kraków", Street = "Michała Bobrzyńskiego 46", PostalCode = "31-348" });


            modelBuilder.Entity<GenreEntity>()
                .OwnsOne(o => o.History)
                .HasData(
                new { GenreEntityId = 1, YearOfOrigin = 1951, Founder = "Alan Freed", Country = "USA" },
                new { GenreEntityId = 2, YearOfOrigin = 1951, Founder = "Ray Charles", Country = "USA" },
                new { GenreEntityId = 3, YearOfOrigin = 1750, Founder = "Johann Sebastian Bach", Country = "Germany" },
                new { GenreEntityId = 4, YearOfOrigin = 1960, Founder = "Michael Joseph Jackson", Country = "USA" }
                );


            modelBuilder.Entity<AlbumEntity>().HasData(
                new AlbumEntity()
                {
                    Id = 1,
                    Name = "Album1",
                    BandOrArtist = "Artist1",
                    ReleaseDate = new DateTime(2022, 1, 1),
                    Created = DateTime.Now,
                    ChartRanking = 1,
                    GenreId=1
                },
                new AlbumEntity()
                {
                    Id = 2,
                    Name = "Album2",
                    BandOrArtist = "Artist2",
                    ReleaseDate = new DateTime(2021, 11, 1),
                    Created = DateTime.Now,
                    ChartRanking = 3,
                    GenreId = 2

                },
                new AlbumEntity() { Id = 3, Name = "Echoes of Nature", BandOrArtist = "Nature Sound Band", ReleaseDate = new DateTime(2021, 5, 1), GenreId = 3, Created = DateTime.Now, ChartRanking = 2 },
                new AlbumEntity() { Id = 4, Name = "Rhythms of Space", BandOrArtist = "Galaxy Explorers", ReleaseDate = new DateTime(2022, 2, 15), GenreId = 4, Created = DateTime.Now, ChartRanking = 1 },
                new AlbumEntity() { Id = 5, Name = "Journey Through Time", BandOrArtist = "History Makers", ReleaseDate = new DateTime(2020, 12, 25), GenreId = 2, Created = DateTime.Now, ChartRanking = 3 }
   
                );

            modelBuilder.Entity<TrackEntity>().HasData(
                 new TrackEntity { Id = 1, Name = "Magical", AlbumEntityId = 1, Duration = TimeSpan.FromSeconds(225) },
                 new TrackEntity { Id = 2, Name = "England", AlbumEntityId = 1, Duration = TimeSpan.FromSeconds(260) },
                 new TrackEntity { Id = 3, Name = "Punchline", AlbumEntityId = 1, Duration = TimeSpan.FromSeconds(175) },
                 new TrackEntity { Id = 4, Name = "Shirtsleeves", AlbumEntityId = 2, Duration = TimeSpan.FromSeconds(195) },
                 new TrackEntity { Id = 5, Name = "One", AlbumEntityId = 2, Duration = TimeSpan.FromSeconds(280) },
                 new TrackEntity { Id = 6, Name = "The Man", AlbumEntityId = 2, Duration = TimeSpan.FromSeconds(210) }
                 new TrackEntity { Id = 7, Name = "Forest Whisper", AlbumEntityId = 3, Duration = TimeSpan.FromSeconds(180) },
                new TrackEntity { Id = 8, Name = "Ocean Wave", AlbumEntityId = 3, Duration = TimeSpan.FromSeconds(210) },
                new TrackEntity { Id = 9, Name = "Mountain Echo", AlbumEntityId = 3, Duration = TimeSpan.FromSeconds(200) },
                new TrackEntity { Id = 10, Name = "Starry Night", AlbumEntityId = 4, Duration = TimeSpan.FromSeconds(240) },
                new TrackEntity { Id = 11, Name = "Mystery of Nebula", AlbumEntityId = 4, Duration = TimeSpan.FromSeconds(260) },
                new TrackEntity { Id = 12, Name = "Ancient Roads", AlbumEntityId = 5, Duration = TimeSpan.FromSeconds(190) },
                new TrackEntity { Id = 13, Name = "Timeless Memories", AlbumEntityId = 5, Duration = TimeSpan.FromSeconds(220) },
                new TrackEntity { Id = 14, Name = "Sands of History", AlbumEntityId = 5, Duration = TimeSpan.FromSeconds(180) }
            );

            modelBuilder.Entity<PlaylistEntity>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<PlaylistTrackEntity>()
                .HasKey(pt => new { pt.PlaylistId, pt.TrackId });

            modelBuilder.Entity<PlaylistEntity>()
              .HasMany(p => p.PlaylistTracks)
              .WithOne(pt => pt.Playlist);

            modelBuilder.Entity<PlaylistTrackEntity>()
                .HasOne(pt => pt.Track)
                .WithMany();
            modelBuilder.Entity<TagEntity>().HasData(
                 new TagEntity { Id = 1, Name = "Radosny" },
                 new TagEntity { Id = 2, Name = "Spokojny" },
                 new TagEntity { Id = 3, Name = "Energetyczny" },
                 new TagEntity { Id = 4, Name = "Romantyczny" },
                 new TagEntity { Id = 5, Name = "Melancholijny" },
                 new TagEntity { Id = 6, Name = "Tęskny" },
                 new TagEntity { Id = 7, Name = "Wakacyjny" },
                 new TagEntity { Id = 8, Name = "Nostalgiczny" },
                 new TagEntity { Id = 9, Name = "Motywujący" },
                 new TagEntity { Id = 10, Name = "Relaksujący" },
                 new TagEntity { Id = 11, Name = "Imprezowy" },
                 new TagEntity { Id = 12, Name = "Na trening" },
                 new TagEntity { Id = 13, Name = "Do śpiewania" },
                 new TagEntity { Id = 14, Name = "Do tańca" },
                 new TagEntity { Id = 15, Name = "Do pracy" },
                 new TagEntity { Id = 16, Name = "Do nauki" },
                 new TagEntity { Id = 17, Name = "Do medytacji" },
                 new TagEntity { Id = 18, Name = "Inspirujący" },
                 new TagEntity { Id = 19, Name = "Do podróży" },
                 new TagEntity { Id = 20, Name = "Na dobry początek dnia" }
             // Dodaj więcej tagów według potrzeb
             );


            modelBuilder.Entity<PlaylistEntity>().HasData(
                 new PlaylistEntity
                 {
                     Id = 1,
                     Name = "Summer Hits",
                     GenreId = 1, // Zakładając, że GenreId = 1 istnieje
                     IsPublic = true,
                     TotalDuration = TimeSpan.FromSeconds(485),
                     Created= new DateTime(2005, 10, 1),
                     UserId=ADMIN_ID,
                 },
                 new PlaylistEntity
                 {
                     Id = 2,
                     Name = "Rock Classics",
                     GenreId = 2, // Zakładając, że GenreId = 2 istnieje
                     IsPublic = true,
                     TotalDuration = TimeSpan.FromSeconds(370),
                     Created = new DateTime(2022, 11, 8),
                     UserId = ADMIN_ID,
                 },
                new PlaylistEntity { Id = 3, Name = "Morning Vibes", GenreId = 1, IsPublic = true, TotalDuration = TimeSpan.FromSeconds(600), Created = DateTime.Now, UserId = JULIA_ID },
                new PlaylistEntity { Id = 4, Name = "Workout Energy", GenreId = 4, IsPublic = false, TotalDuration = TimeSpan.FromSeconds(500), Created = DateTime.Now, UserId = TOMEK_ID }
            );





            // Dodanie utworów do playlist
            modelBuilder.Entity<PlaylistTrackEntity>().HasData(
                new {  PlaylistId = 1, TrackId = 1 }, // Zakładając, że TrackId = 1 istnieje
                new {  PlaylistId = 1, TrackId = 2 }, // Zakładając, że TrackId = 2 istnieje
                new {  PlaylistId = 2, TrackId = 3 }, // Zakładając, że TrackId = 3 istnieje
                new {  PlaylistId = 2, TrackId = 4 } , // Zakładając, że TrackId = 4 istnieje
                     new { PlaylistId = 3, TrackId = 7 },
                new { PlaylistId = 3, TrackId = 8 },
                new { PlaylistId = 4, TrackId = 10 },
                new { PlaylistId = 4, TrackId = 11 }
            );





            // Dodanie tagów do playlist
            modelBuilder.Entity<PlaylistTagEntity>().HasData(
                // Przypisanie tagów do playlisty "Summer Hits"
                new { PlaylistId = 1, TagId = 7 }, // Tag "Wakacyjny"
                new { PlaylistId = 1, TagId = 19 }, // Tag "Do podróży"
                new { PlaylistId = 1, TagId = 20 }, // Tag "Na dobry początek dnia"

                // Przypisanie tagów do playlisty "Rock Classics"
                new { PlaylistId = 2, TagId = 1 }, // Tag "Radosny"
                new { PlaylistId = 2, TagId = 4 }, // Tag "Romantyczny"
                new { PlaylistId = 2, TagId = 14 },  // Tag "Do tańca"

                 new { PlaylistId = 3, TagId = 2 }, // Tag "Radosny"
                new { PlaylistId = 3, TagId = 5 }, // Tag "Romantyczny"
                new { PlaylistId = 3, TagId = 4 },  // Tag "Do tańca"

                 new { PlaylistId = 4, TagId = 10 }, // Tag "Radosny"
                new { PlaylistId = 4, TagId = 7 }, // Tag "Romantyczny"
                new { PlaylistId = 4, TagId = 3 }  // Tag "Do tańca"
                                                    // Dodaj więcej przypisań według potrzeb
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
                    else if (entry.Entity is PlaylistEntity playlist && playlist.Created == default)
                    {
                        playlist.Created = DateTime.Now;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
