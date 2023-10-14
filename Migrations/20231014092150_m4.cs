using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _14._10_ASP.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Characteristicss_CharacteristicsId",
                table: "Phones");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Characteristicss_CharacteristicsId",
                table: "Phones",
                column: "CharacteristicsId",
                principalTable: "Characteristicss",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Characteristicss_CharacteristicsId",
                table: "Phones");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Characteristicss_CharacteristicsId",
                table: "Phones",
                column: "CharacteristicsId",
                principalTable: "Characteristicss",
                principalColumn: "Id");
        }
    }
}
