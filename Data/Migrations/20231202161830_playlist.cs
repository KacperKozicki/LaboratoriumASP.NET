using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class playlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e0857d04-bc70-4038-a51a-bba8f03d058f", "f3016a76-cb81-41d6-8500-bcb7fcc1d3c0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0857d04-bc70-4038-a51a-bba8f03d058f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3016a76-cb81-41d6-8500-bcb7fcc1d3c0");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "tracks",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateTable(
                name: "playlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false),
                    Tags = table.Column<string>(type: "TEXT", nullable: false),
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
                name: "playlist_tracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlaylistId = table.Column<int>(type: "INTEGER", nullable: false),
                    TrackId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playlist_tracks", x => x.Id);
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
                values: new object[] { "a8c26e98-0622-4c2a-961e-ec450be6cf17", "a8c26e98-0622-4c2a-961e-ec450be6cf17", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "238fc42c-3e66-4bbd-969c-06daf7f00373", 0, "d1e0eae0-c961-40bf-864c-6ee5ff2fe6cf", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAENhVqxON1cVLYYtCNDIe6jzry+lHtu47ivltC5/YCyzBLNua7Uctm1sNmjiOibIBng==", null, false, "4d509336-e187-45fd-ba43-fc75c3614383", false, "adam" });

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 17, 18, 30, 150, DateTimeKind.Local).AddTicks(8619));

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 17, 18, 30, 150, DateTimeKind.Local).AddTicks(8657));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 17, 18, 30, 148, DateTimeKind.Local).AddTicks(2067));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 17, 18, 30, 148, DateTimeKind.Local).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Duration",
                value: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Duration",
                value: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Duration",
                value: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Duration",
                value: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 5,
                column: "Duration",
                value: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Duration",
                value: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a8c26e98-0622-4c2a-961e-ec450be6cf17", "238fc42c-3e66-4bbd-969c-06daf7f00373" });

            migrationBuilder.CreateIndex(
                name: "IX_playlist_tracks_PlaylistId",
                table: "playlist_tracks",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_playlist_tracks_TrackId",
                table: "playlist_tracks",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IX_playlists_GenreId",
                table: "playlists",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "playlist_tracks");

            migrationBuilder.DropTable(
                name: "playlists");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a8c26e98-0622-4c2a-961e-ec450be6cf17", "238fc42c-3e66-4bbd-969c-06daf7f00373" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8c26e98-0622-4c2a-961e-ec450be6cf17");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "238fc42c-3e66-4bbd-969c-06daf7f00373");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "tracks");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e0857d04-bc70-4038-a51a-bba8f03d058f", "e0857d04-bc70-4038-a51a-bba8f03d058f", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f3016a76-cb81-41d6-8500-bcb7fcc1d3c0", 0, "3c3e90c8-f8d9-4c5a-a163-2d5b1d4f7921", "adam", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEGheBd7lB+X8lsiEObfLsH9ELJ9Fc5HqFj3AL9tWncrvK5Hrw3+BMNiuSUpvT0SdhA==", null, false, "f3d93240-93d1-4942-adf2-6ac89937089b", false, "adam@wsei.edu.pl" });

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 28, 13, 44, 28, 940, DateTimeKind.Local).AddTicks(884));

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 11, 28, 13, 44, 28, 940, DateTimeKind.Local).AddTicks(940));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 28, 13, 44, 28, 928, DateTimeKind.Local).AddTicks(4832));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 11, 28, 13, 44, 28, 928, DateTimeKind.Local).AddTicks(5089));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e0857d04-bc70-4038-a51a-bba8f03d058f", "f3016a76-cb81-41d6-8500-bcb7fcc1d3c0" });
        }
    }
}
