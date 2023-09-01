using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class DataInsert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "IdVilla", "Amenity", "Capacity", "CreationDate", "Details", "Dimensions", "ImageUrl", "Name", "Price", "UpdateTime" },
                values: new object[] { 1, "", 100, new DateTime(2023, 9, 1, 17, 57, 40, 678, DateTimeKind.Local).AddTicks(509), "All details", 100.0, "", "Villa Bayamo", 85.5, new DateTime(2023, 9, 1, 17, 57, 40, 678, DateTimeKind.Local).AddTicks(557) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "IdVilla",
                keyValue: 1);
        }
    }
}
