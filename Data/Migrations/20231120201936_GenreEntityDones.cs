using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class GenreEntityDones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 20, 21, 19, 35, 948, DateTimeKind.Local).AddTicks(1410));

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 11, 20, 21, 19, 35, 948, DateTimeKind.Local).AddTicks(1438));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 20, 21, 19, 35, 945, DateTimeKind.Local).AddTicks(7683));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 11, 20, 21, 19, 35, 945, DateTimeKind.Local).AddTicks(7742));

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Rock");

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Jazz");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 20, 21, 14, 46, 472, DateTimeKind.Local).AddTicks(3801));

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 11, 20, 21, 14, 46, 472, DateTimeKind.Local).AddTicks(3827));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 20, 21, 14, 46, 470, DateTimeKind.Local).AddTicks(552));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 11, 20, 21, 14, 46, 470, DateTimeKind.Local).AddTicks(599));

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "RockAndRoll");

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Jezz");
        }
    }
}
