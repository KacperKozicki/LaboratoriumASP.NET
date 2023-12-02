using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class playlist15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3ab62436-9128-45f3-aede-a673e66302c7", "14ca071f-443b-4d5f-b72c-08b17605731e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ab62436-9128-45f3-aede-a673e66302c7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14ca071f-443b-4d5f-b72c-08b17605731e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "81631c20-aff8-4c5c-adeb-ea9cb90d1497", "81631c20-aff8-4c5c-adeb-ea9cb90d1497", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "15f524ac-9fce-46b9-bb71-cb5a23905d8c", 0, "6a27451f-0bc1-4693-8a34-2af55d1d9ecf", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEJsZ4LQvk0RzSFImcPSZjQUoR0g5XVAEjsZL6rtuNq+mksSJ3+tkwQDijvkGKUqtRw==", null, false, "b0c5fe91-e9df-4e97-b55b-30ce5ea2a0e0", false, "adam" });

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 19, 27, 39, 716, DateTimeKind.Local).AddTicks(8752));

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 19, 27, 39, 716, DateTimeKind.Local).AddTicks(8785));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 19, 27, 39, 714, DateTimeKind.Local).AddTicks(7093));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 19, 27, 39, 714, DateTimeKind.Local).AddTicks(7141));

            migrationBuilder.UpdateData(
                table: "playlists",
                keyColumn: "Id",
                keyValue: 1,
                column: "TotalDuration",
                value: new TimeSpan(0, 0, 8, 5, 0));

            migrationBuilder.UpdateData(
                table: "playlists",
                keyColumn: "Id",
                keyValue: 2,
                column: "TotalDuration",
                value: new TimeSpan(0, 0, 6, 10, 0));

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Duration",
                value: new TimeSpan(0, 0, 3, 45, 0));

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Duration",
                value: new TimeSpan(0, 0, 4, 20, 0));

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Duration",
                value: new TimeSpan(0, 0, 2, 55, 0));

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Duration",
                value: new TimeSpan(0, 0, 3, 15, 0));

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 5,
                column: "Duration",
                value: new TimeSpan(0, 0, 4, 40, 0));

            migrationBuilder.UpdateData(
                table: "tracks",
                keyColumn: "Id",
                keyValue: 6,
                column: "Duration",
                value: new TimeSpan(0, 0, 3, 30, 0));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "81631c20-aff8-4c5c-adeb-ea9cb90d1497", "15f524ac-9fce-46b9-bb71-cb5a23905d8c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "81631c20-aff8-4c5c-adeb-ea9cb90d1497", "15f524ac-9fce-46b9-bb71-cb5a23905d8c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81631c20-aff8-4c5c-adeb-ea9cb90d1497");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "15f524ac-9fce-46b9-bb71-cb5a23905d8c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3ab62436-9128-45f3-aede-a673e66302c7", "3ab62436-9128-45f3-aede-a673e66302c7", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "14ca071f-443b-4d5f-b72c-08b17605731e", 0, "6070e548-ea39-4346-afdf-54bf58752a83", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEAU3KLtzFWOvPIxso8Qwg8hlHWqZCOZCgWMMbsrWiA1feHqpsm4NEiv4Kf1iWe6YjQ==", null, false, "e7bc2af8-986f-431c-a4cc-c28db8af0727", false, "adam" });

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 19, 8, 0, 154, DateTimeKind.Local).AddTicks(6794));

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 19, 8, 0, 154, DateTimeKind.Local).AddTicks(6829));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 19, 8, 0, 152, DateTimeKind.Local).AddTicks(339));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 19, 8, 0, 152, DateTimeKind.Local).AddTicks(397));

            migrationBuilder.UpdateData(
                table: "playlists",
                keyColumn: "Id",
                keyValue: 1,
                column: "TotalDuration",
                value: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.UpdateData(
                table: "playlists",
                keyColumn: "Id",
                keyValue: 2,
                column: "TotalDuration",
                value: new TimeSpan(0, 0, 0, 0, 0));

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
                values: new object[] { "3ab62436-9128-45f3-aede-a673e66302c7", "14ca071f-443b-4d5f-b72c-08b17605731e" });
        }
    }
}
