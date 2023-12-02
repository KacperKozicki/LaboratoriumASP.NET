using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class playlist14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "109b3916-669d-480a-aae6-e9144a844bf9", "98cf3827-b2da-496b-9f6a-8ad279bfecc5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "109b3916-669d-480a-aae6-e9144a844bf9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98cf3827-b2da-496b-9f6a-8ad279bfecc5");

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3ab62436-9128-45f3-aede-a673e66302c7", "14ca071f-443b-4d5f-b72c-08b17605731e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "109b3916-669d-480a-aae6-e9144a844bf9", "109b3916-669d-480a-aae6-e9144a844bf9", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "98cf3827-b2da-496b-9f6a-8ad279bfecc5", 0, "c4af8350-936e-4d98-ad52-42f074feef1c", "adam@wsei.edu.pl", true, false, null, "ADAM@WSEI.EDU.PL", "ADAM", "AQAAAAEAACcQAAAAEDIChj+8SBIq8C6rB8pWXLJCtLJq8lW/l1xOPNvD/8SboIDCncG/VTYggyaWYFmjnA==", null, false, "70399867-09cb-4601-8de7-1ce6a75af44d", false, "adam" });

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 18, 12, 43, 484, DateTimeKind.Local).AddTicks(7937));

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 18, 12, 43, 484, DateTimeKind.Local).AddTicks(7959));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 12, 2, 18, 12, 43, 482, DateTimeKind.Local).AddTicks(278));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 12, 2, 18, 12, 43, 482, DateTimeKind.Local).AddTicks(333));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "109b3916-669d-480a-aae6-e9144a844bf9", "98cf3827-b2da-496b-9f6a-8ad279bfecc5" });
        }
    }
}
