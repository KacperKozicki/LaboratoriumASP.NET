using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class playlist199 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "playlists",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "131b6117-cf6c-4753-a960-770ef3f0fc9f", "131b6117-cf6c-4753-a960-770ef3f0fc9f", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "91d3645e-7b94-41eb-a261-f40379c4e5aa", 0, "dd6251f6-22a3-4a07-adc0-61e4673d540d", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEJGYK1Ux/c7WtNvsQpNIWbJ8OQqc/fwOlaub1NzIjPbDHf/qcHdHFbEfP4uNN1TlmQ==", null, false, "17c9ff13-c26e-4ae9-b7cb-527c80aff1f7", false, "adam" });

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 21, 16, 11, 614, DateTimeKind.Local).AddTicks(5705));

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 21, 16, 11, 614, DateTimeKind.Local).AddTicks(5754));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 21, 16, 11, 611, DateTimeKind.Local).AddTicks(606));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 21, 16, 11, 611, DateTimeKind.Local).AddTicks(662));

            migrationBuilder.UpdateData(
                table: "playlists",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "playlists",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "131b6117-cf6c-4753-a960-770ef3f0fc9f", "91d3645e-7b94-41eb-a261-f40379c4e5aa" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "131b6117-cf6c-4753-a960-770ef3f0fc9f", "91d3645e-7b94-41eb-a261-f40379c4e5aa" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "131b6117-cf6c-4753-a960-770ef3f0fc9f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "91d3645e-7b94-41eb-a261-f40379c4e5aa");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "playlists");

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5a853679-f0fb-48ae-b13b-880a5b838a43", "415926f4-ce52-4549-ab4a-3da98cb58d1b" });
        }
    }
}
