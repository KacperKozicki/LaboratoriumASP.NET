﻿using Data.Entities;
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
            string ROLE_ID = Guid.NewGuid().ToString();


            var user = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "adam@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "adam@wsei.edu.pl",
                NormalizedUserName = "adam@wsei.edu.pl"

            };
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            user.PasswordHash = ph.HashPassword(user, "Admin123#");



            modelBuilder.Entity<IdentityUser>()
                .HasData(user);

            var adminRole = new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            };





            modelBuilder.Entity<IdentityRole>()
                .HasData(adminRole);

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ROLE_ID,
                    UserId = ADMIN_ID,
                });

            modelBuilder.Entity<ContactEntity>()
                .HasOne(c => c.Ogranization)
                .WithMany(o => o.Contacts)
                .HasForeignKey(c => c.OrganizationId);

            modelBuilder.Entity<AlbumEntity>()
                .HasOne(c => c.Genre)
                .WithMany(o => o.Albums)
                .HasForeignKey(c => c.GenreId);


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
