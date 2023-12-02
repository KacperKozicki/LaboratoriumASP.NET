using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class playlist19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5a853679-f0fb-48ae-b13b-880a5b838a43", "5a853679-f0fb-48ae-b13b-880a5b838a43", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "415926f4-ce52-4549-ab4a-3da98cb58d1b", 0, "1e428c81-3864-4315-9b5c-c7a17cba91c7", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEDSuUBueWzce+xVYI3bLbniYo5J/QFPDesT8KgxddaAR82STYKeHDeKQg6i/f9XGbA==", null, false, "04dcd442-036c-48c1-9c2c-3494bcb6766a", false, "adam" });

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 20, 39, 51, 812, DateTimeKind.Local).AddTicks(1248));

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 20, 39, 51, 812, DateTimeKind.Local).AddTicks(1287));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 20, 39, 51, 809, DateTimeKind.Local).AddTicks(6293));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 20, 39, 51, 809, DateTimeKind.Local).AddTicks(6342));

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Magical");

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "England");

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Punchline");

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Shirtsleeves");

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "One");

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "The Man");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5a853679-f0fb-48ae-b13b-880a5b838a43", "415926f4-ce52-4549-ab4a-3da98cb58d1b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5a853679-f0fb-48ae-b13b-880a5b838a43", "415926f4-ce52-4549-ab4a-3da98cb58d1b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a853679-f0fb-48ae-b13b-880a5b838a43");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "415926f4-ce52-4549-ab4a-3da98cb58d1b");

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

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Pierwszy utwór");

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Drugi utwór");

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Trzeci utwór");

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Pierwszy utwór");

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Drugi utwór");

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Trzeci utwór");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c68758ae-e7c4-43ba-a7c2-cc2e8df23342", "c116d688-32a7-47d0-8859-62c6790c5421" });
        }
    }
}
