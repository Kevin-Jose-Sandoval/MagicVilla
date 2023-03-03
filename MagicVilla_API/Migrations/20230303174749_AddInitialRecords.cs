using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "Capacity", "Cost", "CreatedDate", "Detail", "ImageUrl", "Name", "SquareMeter", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "", 5, 200.0, new DateTime(2023, 3, 3, 11, 47, 49, 298, DateTimeKind.Local).AddTicks(369), "Detalle de la Villa...", "", "Villa Real", 50, new DateTime(2023, 3, 3, 11, 47, 49, 298, DateTimeKind.Local).AddTicks(439) },
                    { 2, "", 4, 150.0, new DateTime(2023, 3, 3, 11, 47, 49, 298, DateTimeKind.Local).AddTicks(446), "Detalle de la Villa...", "", "Premium Vista a la Piscina", 40, new DateTime(2023, 3, 3, 11, 47, 49, 298, DateTimeKind.Local).AddTicks(448) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
