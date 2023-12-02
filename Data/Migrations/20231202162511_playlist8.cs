using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class playlist8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "18041102-7ac1-4b6d-ba82-550fff79bf0f", "18041102-7ac1-4b6d-ba82-550fff79bf0f", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "88f07642-b5c6-45eb-a71e-9fd2d5663846", 0, "2bd2050a-b23f-4a44-9092-4d19813586ea", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAECN0KcJTzdtZTwZSIS1hUc2/CWv4C7xibq+ouCOXxcrFL8SFzGCvxoflgzkm9qXOhA==", null, false, "03cac430-1238-478e-9564-ed5676a28a4f", false, "adam" });

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 17, 25, 11, 165, DateTimeKind.Local).AddTicks(9713));

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 17, 25, 11, 165, DateTimeKind.Local).AddTicks(9751));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 17, 25, 11, 163, DateTimeKind.Local).AddTicks(1019));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 17, 25, 11, 163, DateTimeKind.Local).AddTicks(1069));

            migrationBuilder.InsertData(
                table: "playlists",
                columns: new[] { "Id", "GenreId", "IsPublic", "Name", "Tags", "TotalDuration" },
                values: new object[,]
                {
                    { 1, 1, true, "Summer Hits", "summer, hits", new TimeSpan(0, 0, 0, 0, 0) },
                    { 2, 2, true, "Rock Classics", "rock, classics", new TimeSpan(0, 0, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "18041102-7ac1-4b6d-ba82-550fff79bf0f", "88f07642-b5c6-45eb-a71e-9fd2d5663846" });

            migrationBuilder.InsertData(
                table: "playlist_tracks",
                columns: new[] { "Id", "PlaylistId", "TrackId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 },
                    { 4, 2, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "18041102-7ac1-4b6d-ba82-550fff79bf0f", "88f07642-b5c6-45eb-a71e-9fd2d5663846" });

            migrationBuilder.DeleteData(
                table: "playlist_tracks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "playlist_tracks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "playlist_tracks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "playlist_tracks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18041102-7ac1-4b6d-ba82-550fff79bf0f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88f07642-b5c6-45eb-a71e-9fd2d5663846");

            migrationBuilder.DeleteData(
                table: "playlists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "playlists",
                keyColumn: "Id",
                keyValue: 2);

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a8c26e98-0622-4c2a-961e-ec450be6cf17", "238fc42c-3e66-4bbd-969c-06daf7f00373" });
        }
    }
}
