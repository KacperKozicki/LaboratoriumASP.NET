using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    History_YearOfOrigin = table.Column<int>(type: "INTEGER", nullable: false),
                    History_Founder = table.Column<string>(type: "TEXT", nullable: false),
                    History_Country = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Adress_City = table.Column<string>(type: "TEXT", nullable: false),
                    Adress_Street = table.Column<string>(type: "TEXT", nullable: false),
                    Adress_PostalCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 70, nullable: false),
                    BandOrArtist = table.Column<string>(type: "TEXT", maxLength: 70, nullable: false),
                    release_date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "TEXT", nullable: true),
                    ChartRanking = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_albums_genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "playlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    TotalDuration = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    IsPublic = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_playlists_genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 12, nullable: true),
                    birth_date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false),
                    OrganizationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_contacts_organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Duration = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    AlbumEntityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tracks_albums_AlbumEntityId",
                        column: x => x.AlbumEntityId,
                        principalTable: "albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "playliststag",
                columns: table => new
                {
                    PlaylistId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playliststag", x => new { x.PlaylistId, x.TagId });
                    table.ForeignKey(
                        name: "FK_playliststag_playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_playliststag_tags_TagId",
                        column: x => x.TagId,
                        principalTable: "tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "playlist_tracks",
                columns: table => new
                {
                    PlaylistId = table.Column<int>(type: "INTEGER", nullable: false),
                    TrackId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlist_tracks", x => new { x.PlaylistId, x.TrackId });
                    table.ForeignKey(
                        name: "FK_playlist_tracks_playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_playlist_tracks_tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64ba4eb2-e335-4907-80ef-a281db8445f6", "64ba4eb2-e335-4907-80ef-a281db8445f6", "USER", "USER" },
                    { "a096b0dc-156d-402e-a4d6-eae2918841ed", "a096b0dc-156d-402e-a4d6-eae2918841ed", "ARTIST", "ARTIST" },
                    { "b3924cd1-a2d1-48c3-9a2b-470337307e1a", "b3924cd1-a2d1-48c3-9a2b-470337307e1a", "ADMIN", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "69961c9f-9c0d-44c2-9d8f-2c870713e312", 0, "324fbd80-92bf-4f78-a11b-a6cdb73150d2", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAECH7FSuA+hguK0Ds4wh8IjfDmHFL3VxHjs1TgnuiQQpDnpIHDRQdxps6q1j2QGW5Sg==", null, false, "fcc044ae-a322-4728-bfd5-c036c2e66abf", false, "adam" },
                    { "8bdc2986-9d5f-4be4-b5dc-f62550c1ed8d", 0, "16fd431e-e199-4edd-8e93-078eb5c9621c", "michael@wsei.edu.pl", true, false, null, "MICHAEL@WSEI.EDU.PL", "MICHAEL", "AQAAAAEAACcQAAAAEDxsLJQYCLR6WLa6lujiDn7AmC/gzPjd3tIrl6VV0YRHi2yh9MbbzZTautRXy3OQ0A==", null, false, "64b6f316-5092-42b0-95ea-4db2653b3d84", false, "michael" },
                    { "df872a0f-8646-4307-93bf-3f7ccbc0e911", 0, "7d97966b-d195-4a5d-bb9e-0992811e9bfe", "julia@wsei.edu.pl", true, false, null, "JULIA@WSEI.EDU.PL", "JULIA", "AQAAAAEAACcQAAAAECgHNUiIeY4xwTKX1XGtQLxcmH6cgYUOBj1ebpDiPp8miBsTy3e45Crk+2NIXjRHmw==", null, false, "b9a5d114-969c-442c-9b17-b9ee3bddcb16", false, "julia" },
                    { "edf1c309-d578-4514-8674-e45939fac80d", 0, "6abb239a-a80d-4656-ab9f-cf70c239636b", "tomek@wsei.edu.pl", true, false, null, "TOMEK@WSEI.EDU.PL", "TOMEK", "AQAAAAEAACcQAAAAEJU2wkUdubtrGdohdirQmXzFjfSCLd8DCk09g/CNVACtenu9qS1pdNXmJvWVuSzLBw==", null, false, "06b79eba-8528-45e6-ac19-a72f33af1c1a", false, "tomek" }
                });

            migrationBuilder.InsertData(
                table: "genres",
                columns: new[] { "Id", "Description", "Name", "History_Country", "History_Founder", "History_YearOfOrigin" },
                values: new object[,]
                {
                    { 1, "Lorem", "Rock", "USA", "Alan Freed", 1951 },
                    { 2, "Lorem", "Jazz", "USA", "Ray Charles", 1951 },
                    { 3, "Lorem", "Clasic", "Germany", "Johann Sebastian Bach", 1750 },
                    { 4, "Lorem", "Pop", "USA", "Michael Joseph Jackson", 1960 }
                });

            migrationBuilder.InsertData(
                table: "organizations",
                columns: new[] { "Id", "Description", "Name", "Adress_City", "Adress_PostalCode", "Adress_Street" },
                values: new object[,]
                {
                    { 1, "Uczelnia", "WSEI", "Kraków", "31-150", "Św. Filipa 17" },
                    { 2, "Uczelnia", "UJ", "Kraków", "31-007", "Gołębia 24" },
                    { 3, "Uczelnia", "AGH", "Kraków", "31-059", "al. Adama Mickiewicza 30" },
                    { 4, "Firma", "NOKIA", "Kraków", "31-348", "Michała Bobrzyńskiego 46" }
                });

            migrationBuilder.InsertData(
                table: "tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Radosny" },
                    { 2, "Spokojny" },
                    { 3, "Energetyczny" },
                    { 4, "Romantyczny" },
                    { 5, "Melancholijny" },
                    { 6, "Tęskny" },
                    { 7, "Wakacyjny" },
                    { 8, "Nostalgiczny" },
                    { 9, "Motywujący" },
                    { 10, "Relaksujący" },
                    { 11, "Imprezowy" },
                    { 12, "Na trening" },
                    { 13, "Do śpiewania" },
                    { 14, "Do tańca" },
                    { 15, "Do pracy" },
                    { 16, "Do nauki" },
                    { 17, "Do medytacji" },
                    { 18, "Inspirujący" },
                    { 19, "Do podróży" },
                    { 20, "Na dobry początek dnia" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b3924cd1-a2d1-48c3-9a2b-470337307e1a", "69961c9f-9c0d-44c2-9d8f-2c870713e312" },
                    { "a096b0dc-156d-402e-a4d6-eae2918841ed", "8bdc2986-9d5f-4be4-b5dc-f62550c1ed8d" },
                    { "64ba4eb2-e335-4907-80ef-a281db8445f6", "df872a0f-8646-4307-93bf-3f7ccbc0e911" },
                    { "64ba4eb2-e335-4907-80ef-a281db8445f6", "edf1c309-d578-4514-8674-e45939fac80d" }
                });

            migrationBuilder.InsertData(
                table: "albums",
                columns: new[] { "Id", "BandOrArtist", "ChartRanking", "Created", "Duration", "GenreId", "Name", "release_date" },
                values: new object[,]
                {
                    { 1, "Artist1", 1, new DateTime(2023, 12, 30, 17, 55, 17, 9, DateTimeKind.Local).AddTicks(8637), null, 1, "Album1", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Artist2", 3, new DateTime(2023, 12, 30, 17, 55, 17, 10, DateTimeKind.Local).AddTicks(58), null, 2, "Album2", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "birth_date", "Created", "Email", "Name", "OrganizationId", "Phone", "Priority" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 30, 17, 55, 17, 6, DateTimeKind.Local).AddTicks(8793), "adam@wsei.edu.pl", "Adam", 1, "127813268163", 1 },
                    { 2, new DateTime(1999, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 30, 17, 55, 17, 6, DateTimeKind.Local).AddTicks(8849), "ewa@wsei.edu.pl", "Ewa", 1, "293443823478", 2 }
                });

            migrationBuilder.InsertData(
                table: "playlists",
                columns: new[] { "Id", "Created", "GenreId", "IsPublic", "Name", "TotalDuration", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2005, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, "Summer Hits", new TimeSpan(0, 0, 8, 5, 0), "69961c9f-9c0d-44c2-9d8f-2c870713e312" },
                    { 2, new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, "Rock Classics", new TimeSpan(0, 0, 6, 10, 0), "69961c9f-9c0d-44c2-9d8f-2c870713e312" }
                });

            migrationBuilder.InsertData(
                table: "playliststag",
                columns: new[] { "PlaylistId", "TagId" },
                values: new object[,]
                {
                    { 1, 7 },
                    { 1, 19 },
                    { 1, 20 },
                    { 2, 1 },
                    { 2, 4 },
                    { 2, 14 }
                });

            migrationBuilder.InsertData(
                table: "tracks",
                columns: new[] { "Id", "AlbumEntityId", "Duration", "Name" },
                values: new object[,]
                {
                    { 1, 1, new TimeSpan(0, 0, 3, 45, 0), "Magical" },
                    { 2, 1, new TimeSpan(0, 0, 4, 20, 0), "England" },
                    { 3, 1, new TimeSpan(0, 0, 2, 55, 0), "Punchline" },
                    { 4, 2, new TimeSpan(0, 0, 3, 15, 0), "Shirtsleeves" },
                    { 5, 2, new TimeSpan(0, 0, 4, 40, 0), "One" },
                    { 6, 2, new TimeSpan(0, 0, 3, 30, 0), "The Man" }
                });

            migrationBuilder.InsertData(
                table: "playlist_tracks",
                columns: new[] { "PlaylistId", "TrackId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_albums_GenreId",
                table: "albums",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_contacts_OrganizationId",
                table: "contacts",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_playlist_tracks_TrackId",
                table: "playlist_tracks",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_playlists_GenreId",
                table: "playlists",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_playliststag_TagId",
                table: "playliststag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_tracks_AlbumEntityId",
                table: "tracks",
                column: "AlbumEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "playlist_tracks");

            migrationBuilder.DropTable(
                name: "playliststag");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "organizations");

            migrationBuilder.DropTable(
                name: "tracks");

            migrationBuilder.DropTable(
                name: "playlists");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "albums");

            migrationBuilder.DropTable(
                name: "genres");
        }
    }
}
