using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _14._10_ASP.Migrations
{
    /// <inheritdoc />
    public partial class m3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CharacteristicsId",
                table: "Phones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Characteristicss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Memory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Battery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Screen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Camera = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characteristicss", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phones_CharacteristicsId",
                table: "Phones",
                column: "CharacteristicsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Characteristicss_CharacteristicsId",
                table: "Phones",
                column: "CharacteristicsId",
                principalTable: "Characteristicss",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Characteristicss_CharacteristicsId",
                table: "Phones");

            migrationBuilder.DropTable(
                name: "Characteristicss");

            migrationBuilder.DropIndex(
                name: "IX_Phones_CharacteristicsId",
                table: "Phones");

            migrationBuilder.DropColumn(
                name: "CharacteristicsId",
                table: "Phones");
        }
    }
}
