﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("Data.Entities.AlbumEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BandOrArtist")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("TEXT");

                    b.Property<int>("ChartRanking")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT")
                        .HasColumnName("created");

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("release_date");

                    b.HasKey("Id");

                    b.ToTable("albums");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BandOrArtist = "Artist1",
                            ChartRanking = 1,
                            Created = new DateTime(2023, 11, 12, 14, 44, 48, 528, DateTimeKind.Local).AddTicks(1386),
                            Name = "Album1",
                            ReleaseDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            BandOrArtist = "Artist2",
                            ChartRanking = 3,
                            Created = new DateTime(2023, 11, 12, 14, 44, 48, 528, DateTimeKind.Local).AddTicks(1391),
                            Name = "Album2",
                            ReleaseDate = new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Data.Entities.ContactEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Birth")
                        .HasColumnType("TEXT")
                        .HasColumnName("birth_date");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birth = new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Created = new DateTime(2023, 11, 12, 14, 44, 48, 528, DateTimeKind.Local).AddTicks(1202),
                            Email = "adam@wsei.edu.pl",
                            Name = "Adam",
                            Phone = "127813268163",
                            Priority = 1
                        },
                        new
                        {
                            Id = 2,
                            Birth = new DateTime(1999, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Created = new DateTime(2023, 11, 12, 14, 44, 48, 528, DateTimeKind.Local).AddTicks(1266),
                            Email = "ewa@wsei.edu.pl",
                            Name = "Ewa",
                            Phone = "293443823478",
                            Priority = 2
                        });
                });

            modelBuilder.Entity("Data.Entities.TrackEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlbumEntityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AlbumEntityId");

                    b.ToTable("tracks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlbumEntityId = 1,
                            Name = "Pierwszy utwór"
                        },
                        new
                        {
                            Id = 2,
                            AlbumEntityId = 1,
                            Name = "Drugi utwór"
                        },
                        new
                        {
                            Id = 3,
                            AlbumEntityId = 1,
                            Name = "Trzeci utwór"
                        },
                        new
                        {
                            Id = 4,
                            AlbumEntityId = 2,
                            Name = "Pierwszy utwór"
                        },
                        new
                        {
                            Id = 5,
                            AlbumEntityId = 2,
                            Name = "Drugi utwór"
                        },
                        new
                        {
                            Id = 6,
                            AlbumEntityId = 2,
                            Name = "Trzeci utwór"
                        });
                });

            modelBuilder.Entity("Data.Entities.TrackEntity", b =>
                {
                    b.HasOne("Data.Entities.AlbumEntity", "Album")
                        .WithMany("Tracklist")
                        .HasForeignKey("AlbumEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("Data.Entities.AlbumEntity", b =>
                {
                    b.Navigation("Tracklist");
                });
#pragma warning restore 612, 618
        }
    }
}
