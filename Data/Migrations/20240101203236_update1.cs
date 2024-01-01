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
                    { "0832b66e-81ac-4238-994a-39be288341d9", "0832b66e-81ac-4238-994a-39be288341d9", "ARTIST", "ARTIST" },
                    { "b371a530-8def-40d7-bb6f-eabe3482fc5d", "b371a530-8def-40d7-bb6f-eabe3482fc5d", "USER", "USER" },
                    { "e62b00a8-2d92-46e3-803a-628b8d997d2f", "e62b00a8-2d92-46e3-803a-628b8d997d2f", "ADMIN", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2229335b-be2d-4825-a55f-c91252bb6cb2", 0, "19b453a3-ea05-41a7-8aa3-af71e6edaa6b", "tomek@wsei.edu.pl", true, false, null, "TOMEK@WSEI.EDU.PL", "TOMEK", "AQAAAAEAACcQAAAAEJtUpQClmducr1yayVrXkp+WBMWCrR3elF3vrwOkkl5dPqXZesXeebj1rdHc5bbuDg==", null, false, "2097ab36-a863-49c7-a8cc-641f0e5811b8", false, "tomek" },
                    { "75eee478-a030-489f-9e40-3ad96fbfbc1b", 0, "0abd5016-6a17-4858-95ac-fafc2dbfaf21", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEFh80vgRnCooj0j+HnktHkksgnMI31PI7jvvZ/F4slCcTiW4mmel1PT/pg5IFzcRXg==", null, false, "386fbe5b-6b6a-4c49-bcb3-0c388d56a1f3", false, "adam" },
                    { "b327fc8b-827d-4a4b-bbe1-bdb624302eb3", 0, "491574c0-f615-48a1-8279-f14a6bbd4f36", "julia@wsei.edu.pl", true, false, null, "JULIA@WSEI.EDU.PL", "JULIA", "AQAAAAEAACcQAAAAEOGRBunZunH0iEbLEWFMkwFBqADwzjgYQqAEfU825rCUiGohS04k7kD8Hu+LpyoT3g==", null, false, "73bb6de5-f911-4588-be91-0e68578e2817", false, "julia" },
                    { "e0ad3fb3-3fc0-43cf-993f-b1df98cd29a4", 0, "46a36b2b-92be-4b75-9553-e3f3d09c74c3", "michael@wsei.edu.pl", true, false, null, "MICHAEL@WSEI.EDU.PL", "MICHAEL", "AQAAAAEAACcQAAAAELFmjT+JkP/FgEgdIeh5gP67l5F5filtjB9L/O1nbD5vMqHOoNBK/E1lHLQ2t6kmVQ==", null, false, "101842e1-d826-444c-839a-9e7fd9da9f9b", false, "michael" }
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
                    { "b371a530-8def-40d7-bb6f-eabe3482fc5d", "2229335b-be2d-4825-a55f-c91252bb6cb2" },
                    { "e62b00a8-2d92-46e3-803a-628b8d997d2f", "75eee478-a030-489f-9e40-3ad96fbfbc1b" },
                    { "b371a530-8def-40d7-bb6f-eabe3482fc5d", "b327fc8b-827d-4a4b-bbe1-bdb624302eb3" },
                    { "0832b66e-81ac-4238-994a-39be288341d9", "e0ad3fb3-3fc0-43cf-993f-b1df98cd29a4" }
                });

            migrationBuilder.InsertData(
                table: "albums",
                columns: new[] { "Id", "BandOrArtist", "ChartRanking", "Created", "Duration", "GenreId", "Name", "release_date" },
                values: new object[,]
                {
                    { 1, "Artist1", 1, new DateTime(2024, 1, 1, 21, 32, 36, 270, DateTimeKind.Local).AddTicks(2783), null, 1, "Album1", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Artist2", 3, new DateTime(2024, 1, 1, 21, 32, 36, 270, DateTimeKind.Local).AddTicks(2863), null, 2, "Album2", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Nature Sound Band", 2, new DateTime(2024, 1, 1, 21, 32, 36, 270, DateTimeKind.Local).AddTicks(2868), null, 3, "Echoes of Nature", new DateTime(2021, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Galaxy Explorers", 1, new DateTime(2024, 1, 1, 21, 32, 36, 270, DateTimeKind.Local).AddTicks(2875), null, 4, "Rhythms of Space", new DateTime(2022, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "History Makers", 3, new DateTime(2024, 1, 1, 21, 32, 36, 270, DateTimeKind.Local).AddTicks(2880), null, 2, "Journey Through Time", new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "birth_date", "Created", "Email", "Name", "OrganizationId", "Phone", "Priority" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 21, 32, 36, 265, DateTimeKind.Local).AddTicks(7191), "adam@wsei.edu.pl", "Adam", 1, "127813268163", 1 },
                    { 2, new DateTime(1999, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 21, 32, 36, 265, DateTimeKind.Local).AddTicks(7326), "ewa@wsei.edu.pl", "Ewa", 1, "293443823478", 2 }
                });

            migrationBuilder.InsertData(
                table: "playlists",
                columns: new[] { "Id", "Created", "GenreId", "IsPublic", "Name", "TotalDuration", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2005, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, "Summer Hits", new TimeSpan(0, 0, 8, 5, 0), "75eee478-a030-489f-9e40-3ad96fbfbc1b" },
                    { 2, new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, "Rock Classics", new TimeSpan(0, 0, 6, 10, 0), "75eee478-a030-489f-9e40-3ad96fbfbc1b" },
                    { 3, new DateTime(2024, 1, 1, 21, 32, 36, 271, DateTimeKind.Local).AddTicks(7100), 1, true, "Morning Vibes", new TimeSpan(0, 0, 10, 0, 0), "b327fc8b-827d-4a4b-bbe1-bdb624302eb3" },
                    { 4, new DateTime(2024, 1, 1, 21, 32, 36, 271, DateTimeKind.Local).AddTicks(7134), 4, false, "Workout Energy", new TimeSpan(0, 0, 8, 20, 0), "2229335b-be2d-4825-a55f-c91252bb6cb2" }
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
                    { 2, 14 },
                    { 3, 2 },
                    { 3, 4 },
                    { 3, 5 },
                    { 4, 3 },
                    { 4, 7 },
                    { 4, 10 }
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
                    { 6, 2, new TimeSpan(0, 0, 3, 30, 0), "The Man" },
                    { 7, 3, new TimeSpan(0, 0, 3, 0, 0), "Forest Whisper" },
                    { 8, 3, new TimeSpan(0, 0, 3, 30, 0), "Ocean Wave" },
                    { 9, 3, new TimeSpan(0, 0, 3, 20, 0), "Mountain Echo" },
                    { 10, 4, new TimeSpan(0, 0, 4, 0, 0), "Starry Night" },
                    { 11, 4, new TimeSpan(0, 0, 4, 20, 0), "Mystery of Nebula" },
                    { 12, 5, new TimeSpan(0, 0, 3, 10, 0), "Ancient Roads" },
                    { 13, 5, new TimeSpan(0, 0, 3, 40, 0), "Timeless Memories" },
                    { 14, 5, new TimeSpan(0, 0, 3, 0, 0), "Sands of History" }
                });

            migrationBuilder.InsertData(
                table: "playlist_tracks",
                columns: new[] { "PlaylistId", "TrackId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 7 },
                    { 3, 8 },
                    { 4, 10 },
                    { 4, 11 }
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
