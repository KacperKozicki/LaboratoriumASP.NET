using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class playlist11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_playlist_tracks",
                table: "playlist_tracks");

            migrationBuilder.DropIndex(
                name: "IX_playlist_tracks_PlaylistId",
                table: "playlist_tracks");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e39730a9-7038-4a76-815c-44a97d197f00", "6bcbde45-23ad-4cde-b4d6-b4a111520dae" });

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
                keyValue: "e39730a9-7038-4a76-815c-44a97d197f00");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bcbde45-23ad-4cde-b4d6-b4a111520dae");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "playlist_tracks",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_playlist_tracks",
                table: "playlist_tracks",
                columns: new[] { "PlaylistId", "TrackId" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e1e5493d-1121-4ea8-b401-ee0e34acc808", "e1e5493d-1121-4ea8-b401-ee0e34acc808", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "df478878-050e-484c-92fb-ffc24914644a", 0, "a52febd7-4447-467e-b00c-7ccb783943b3", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEPIA5Xr0z/EZNSzXIQ4yNEBMeAJheLNe1fAsqXk1UhdSq9kmi+nSzwNZUaxRXnGW/Q==", null, false, "3743e126-cedb-4c16-a17c-bd24cf680caa", false, "adam" });

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 18, 6, 17, 380, DateTimeKind.Local).AddTicks(5561));

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 18, 6, 17, 380, DateTimeKind.Local).AddTicks(5611));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 18, 6, 17, 377, DateTimeKind.Local).AddTicks(4583));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 18, 6, 17, 377, DateTimeKind.Local).AddTicks(4634));

            migrationBuilder.InsertData(
                table: "playlist_tracks",
                columns: new[] { "PlaylistId", "TrackId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 1, 2, 2 },
                    { 2, 3, 3 },
                    { 2, 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e1e5493d-1121-4ea8-b401-ee0e34acc808", "df478878-050e-484c-92fb-ffc24914644a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_playlist_tracks",
                table: "playlist_tracks");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e1e5493d-1121-4ea8-b401-ee0e34acc808", "df478878-050e-484c-92fb-ffc24914644a" });

            migrationBuilder.DeleteData(
                table: "playlist_tracks",
                keyColumns: new[] { "PlaylistId", "TrackId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "playlist_tracks",
                keyColumns: new[] { "PlaylistId", "TrackId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "playlist_tracks",
                keyColumns: new[] { "PlaylistId", "TrackId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "playlist_tracks",
                keyColumns: new[] { "PlaylistId", "TrackId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1e5493d-1121-4ea8-b401-ee0e34acc808");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df478878-050e-484c-92fb-ffc24914644a");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "playlist_tracks",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_playlist_tracks",
                table: "playlist_tracks",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e39730a9-7038-4a76-815c-44a97d197f00", "e39730a9-7038-4a76-815c-44a97d197f00", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6bcbde45-23ad-4cde-b4d6-b4a111520dae", 0, "712dcd6b-14b7-4123-bf41-de4f472dba9f", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEA0hUhzjJ6bJsH5t16EawKxNue66U/vDW4BBAdnCJf2RiTxmJHLz4FzOAZvuWRYANQ==", null, false, "c2165d7b-8c28-44df-89a0-a7958a7fa807", false, "adam" });

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 18, 3, 20, 66, DateTimeKind.Local).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 18, 3, 20, 66, DateTimeKind.Local).AddTicks(6552));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 18, 3, 20, 63, DateTimeKind.Local).AddTicks(6598));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 18, 3, 20, 63, DateTimeKind.Local).AddTicks(6649));

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e39730a9-7038-4a76-815c-44a97d197f00", "6bcbde45-23ad-4cde-b4d6-b4a111520dae" });

            migrationBuilder.CreateIndex(
                name: "IX_playlist_tracks_PlaylistId",
                table: "playlist_tracks",
                column: "PlaylistId");
        }
    }
}
