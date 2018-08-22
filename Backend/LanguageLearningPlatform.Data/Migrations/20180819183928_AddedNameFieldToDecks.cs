using Microsoft.EntityFrameworkCore.Migrations;

namespace LanguageLearningPlatform.Data.Migrations
{
    public partial class AddedNameFieldToDecks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Decks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Decks");
        }
    }
}
