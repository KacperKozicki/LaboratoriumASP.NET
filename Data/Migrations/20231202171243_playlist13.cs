using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class playlist13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e1e5493d-1121-4ea8-b401-ee0e34acc808", "df478878-050e-484c-92fb-ffc24914644a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1e5493d-1121-4ea8-b401-ee0e34acc808");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df478878-050e-484c-92fb-ffc24914644a");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e1e5493d-1121-4ea8-b401-ee0e34acc808", "df478878-050e-484c-92fb-ffc24914644a" });
        }
    }
}
