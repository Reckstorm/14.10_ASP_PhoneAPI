using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _14._10_ASP.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Manufacturers_ManufacturerId",
                table: "Phones");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Manufacturers_ManufacturerId",
                table: "Phones",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Manufacturers_ManufacturerId",
                table: "Phones");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Manufacturers_ManufacturerId",
                table: "Phones",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id");
        }
    }
}
