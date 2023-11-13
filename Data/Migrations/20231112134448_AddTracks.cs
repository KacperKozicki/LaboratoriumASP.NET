using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTracks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "created",
                value: new DateTime(2023, 11, 12, 14, 44, 48, 528, DateTimeKind.Local).AddTicks(1386));

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "created",
                value: new DateTime(2023, 11, 12, 14, 44, 48, 528, DateTimeKind.Local).AddTicks(1391));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 12, 14, 44, 48, 528, DateTimeKind.Local).AddTicks(1202));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 11, 12, 14, 44, 48, 528, DateTimeKind.Local).AddTicks(1266));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 1,
                column: "created",
                value: new DateTime(2023, 11, 12, 14, 44, 42, 284, DateTimeKind.Local).AddTicks(1363));

            migrationBuilder.UpdateData(
                table: "albums",
                keyColumn: "Id",
                keyValue: 2,
                column: "created",
                value: new DateTime(2023, 11, 12, 14, 44, 42, 284, DateTimeKind.Local).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2023, 11, 12, 14, 44, 42, 284, DateTimeKind.Local).AddTicks(1177));

            migrationBuilder.UpdateData(
                table: "contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2023, 11, 12, 14, 44, 42, 284, DateTimeKind.Local).AddTicks(1228));
        }
    }
}
