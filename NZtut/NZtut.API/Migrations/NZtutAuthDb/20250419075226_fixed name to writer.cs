using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZtut.API.Migrations.NZtutAuthDb
{
    /// <inheritdoc />
    public partial class fixednametowriter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffc3b840-ce56-4940-8318-6464867ffa09",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Writer", "WRITER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffc3b840-ce56-4940-8318-6464867ffa09",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Admin", "ADMIN" });
        }
    }
}
