using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class playlist9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "18041102-7ac1-4b6d-ba82-550fff79bf0f", "88f07642-b5c6-45eb-a71e-9fd2d5663846" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18041102-7ac1-4b6d-ba82-550fff79bf0f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "88f07642-b5c6-45eb-a71e-9fd2d5663846");

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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e39730a9-7038-4a76-815c-44a97d197f00", "6bcbde45-23ad-4cde-b4d6-b4a111520dae" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e39730a9-7038-4a76-815c-44a97d197f00", "6bcbde45-23ad-4cde-b4d6-b4a111520dae" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e39730a9-7038-4a76-815c-44a97d197f00");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6bcbde45-23ad-4cde-b4d6-b4a111520dae");

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
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "18041102-7ac1-4b6d-ba82-550fff79bf0f", "88f07642-b5c6-45eb-a71e-9fd2d5663846" });
        }
    }
}
