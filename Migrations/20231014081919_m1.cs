using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _14._10_ASP.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "Phones");

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "Phones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phones_ManufacturerId",
                table: "Phones",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Manufacturers_ManufacturerId",
                table: "Phones",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Manufacturers_ManufacturerId",
                table: "Phones");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropIndex(
                name: "IX_Phones_ManufacturerId",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "Phones");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "Phones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
