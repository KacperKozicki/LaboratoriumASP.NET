using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class playlist17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "be6a5d81-1bfe-4464-92ff-555a2756a9fc", "baef5380-20ad-4d38-a296-57de482cf478" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "81631c20-aff8-4c5c-adeb-ea9cb90d1497", "15f524ac-9fce-46b9-bb71-cb5a23905d8c" });
        }
    }
}
