using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_albums", x => x.Id);
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
                    Priority = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
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

            migrationBuilder.InsertData(
                table: "albums",
                columns: new[] { "Id", "BandOrArtist", "ChartRanking", "created", "Duration", "Name", "release_date" },
                values: new object[,]
                {
                    { 1, "Artist1", 1, new DateTime(2023, 11, 12, 14, 44, 42, 284, DateTimeKind.Local).AddTicks(1363), null, "Album1", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Artist2", 3, new DateTime(2023, 11, 12, 14, 44, 42, 284, DateTimeKind.Local).AddTicks(1367), null, "Album2", new DateTime(2021, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "contacts",
                columns: new[] { "Id", "birth_date", "Created", "Email", "Name", "Phone", "Priority" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 12, 14, 44, 42, 284, DateTimeKind.Local).AddTicks(1177), "adam@wsei.edu.pl", "Adam", "127813268163", 1 },
                    { 2, new DateTime(1999, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 12, 14, 44, 42, 284, DateTimeKind.Local).AddTicks(1228), "ewa@wsei.edu.pl", "Ewa", "293443823478", 2 }
                });

            migrationBuilder.InsertData(
                table: "tracks",
                columns: new[] { "Id", "AlbumEntityId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Pierwszy utwór" },
                    { 2, 1, "Drugi utwór" },
                    { 3, 1, "Trzeci utwór" },
                    { 4, 2, "Pierwszy utwór" },
                    { 5, 2, "Drugi utwór" },
                    { 6, 2, "Trzeci utwór" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tracks_AlbumEntityId",
                table: "tracks",
                column: "AlbumEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contacts");

            migrationBuilder.DropTable(
                name: "tracks");

            migrationBuilder.DropTable(
                name: "albums");
        }
    }
}
