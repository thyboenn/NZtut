using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZtut.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("ca71359b-5198-4aba-8bb7-673c8d881d45"), "Medium" },
                    { new Guid("e6426a88-6e27-4283-b2c4-55c5488e0b9c"), "Hard" },
                    { new Guid("f341e365-576e-4325-84c5-5dc0cb5a0808"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1419e0fe-b92b-4cf3-9d0d-ef7332310c70"), "WGN", "Wellington", "https://images.pexels.com/photos/31008251/pexels-photo-31008251/free-photo-of-delicious-french-pastry-with-whipped-cream-and-mimosa.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("3d22a598-e59e-4c7e-b2a2-a07f5686d362"), "STL", "Southland", null },
                    { new Guid("463b3c10-baab-4229-9fc6-b7317bcf32e6"), "NSN", "Nelson", "https://images.pexels.com/photos/31633701/pexels-photo-31633701/free-photo-of-man-in-traditional-african-clothing-in-desert.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("4d5e9b47-81a8-4170-9322-68262f7a9581"), "AKL", "Auckland", "https://images.pexels.com/photos/30650062/pexels-photo-30650062/free-photo-of-black-and-white-fishing-scene-in-duzce-turkiye.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load" },
                    { new Guid("9c32bfac-b1ea-4ff3-81de-f7526de92044"), "NTL", "Northland", "https://images.pexels.com/photos/6964308/pexels-photo-6964308.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("c6b4f5b1-f000-4342-8fbb-c30584c55f81"), "BOP", "Bay of Plenty", "https://images.pexels.com/photos/31633279/pexels-photo-31633279/free-photo-of-joyful-surfer-tossing-surfboard-on-sunny-beach.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ca71359b-5198-4aba-8bb7-673c8d881d45"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("e6426a88-6e27-4283-b2c4-55c5488e0b9c"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f341e365-576e-4325-84c5-5dc0cb5a0808"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1419e0fe-b92b-4cf3-9d0d-ef7332310c70"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3d22a598-e59e-4c7e-b2a2-a07f5686d362"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("463b3c10-baab-4229-9fc6-b7317bcf32e6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4d5e9b47-81a8-4170-9322-68262f7a9581"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9c32bfac-b1ea-4ff3-81de-f7526de92044"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c6b4f5b1-f000-4342-8fbb-c30584c55f81"));
        }
    }
}
