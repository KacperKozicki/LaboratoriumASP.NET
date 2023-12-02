using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class playlist18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "be6a5d81-1bfe-4464-92ff-555a2756a9fc", "baef5380-20ad-4d38-a296-57de482cf478" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be6a5d81-1bfe-4464-92ff-555a2756a9fc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "baef5380-20ad-4d38-a296-57de482cf478");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "playlist_tracks");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c68758ae-e7c4-43ba-a7c2-cc2e8df23342", "c68758ae-e7c4-43ba-a7c2-cc2e8df23342", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c116d688-32a7-47d0-8859-62c6790c5421", 0, "46b63d13-dc7d-4407-b92a-fe860610b0f1", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEJAjnDF1vwxaj3kEBG7w/kqF11+2uLmw5kLFMBN7eV+x3ogNK+csgFloa9XlLYz8dA==", null, false, "a7f263cf-b8a5-44d8-b0dc-8f451cc689dd", false, "adam" });

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 20, 26, 48, 577, DateTimeKind.Local).AddTicks(4978));

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 20, 26, 48, 577, DateTimeKind.Local).AddTicks(5006));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 20, 26, 48, 574, DateTimeKind.Local).AddTicks(8068));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 20, 26, 48, 574, DateTimeKind.Local).AddTicks(8121));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c68758ae-e7c4-43ba-a7c2-cc2e8df23342", "c116d688-32a7-47d0-8859-62c6790c5421" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c68758ae-e7c4-43ba-a7c2-cc2e8df23342", "c116d688-32a7-47d0-8859-62c6790c5421" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c68758ae-e7c4-43ba-a7c2-cc2e8df23342");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c116d688-32a7-47d0-8859-62c6790c5421");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "playlist_tracks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "be6a5d81-1bfe-4464-92ff-555a2756a9fc", "be6a5d81-1bfe-4464-92ff-555a2756a9fc", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "baef5380-20ad-4d38-a296-57de482cf478", 0, "01bb34ac-623b-4e12-be53-74aa49f657b2", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEKuKtsS8mThOyTrBpbQPeVrBaW6EjMq02fmp0v/m/EK7MtNiioBiTMsH8MVYqqamAw==", null, false, "37a5e23d-4f3e-4a28-94ba-78fd8431bf60", false, "adam" });

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 20, 25, 38, 284, DateTimeKind.Local).AddTicks(6641));

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 20, 25, 38, 284, DateTimeKind.Local).AddTicks(6670));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 20, 25, 38, 281, DateTimeKind.Local).AddTicks(9148));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 20, 25, 38, 281, DateTimeKind.Local).AddTicks(9202));

            migrationBuilder.UpdateData(
                table: "playlist_tracks",
                keyColumns: new[] { "PlaylistId", "TrackId" },
                keyValues: new object[] { 1, 1 },
                column: "Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "playlist_tracks",
                keyColumns: new[] { "PlaylistId", "TrackId" },
                keyValues: new object[] { 1, 2 },
                column: "Id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "playlist_tracks",
                keyColumns: new[] { "PlaylistId", "TrackId" },
                keyValues: new object[] { 2, 3 },
                column: "Id",
                value: 3);

            migrationBuilder.UpdateData(
                table: "playlist_tracks",
                keyColumns: new[] { "PlaylistId", "TrackId" },
                keyValues: new object[] { 2, 4 },
                column: "Id",
                value: 4);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "be6a5d81-1bfe-4464-92ff-555a2756a9fc", "baef5380-20ad-4d38-a296-57de482cf478" });
        }
    }
}
