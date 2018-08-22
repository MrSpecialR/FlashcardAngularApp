using Microsoft.EntityFrameworkCore.Migrations;

namespace LanguageLearningPlatform.Data.Migrations
{
    public partial class AddedDeckDescriptionAndPoster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Decks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Decks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PosterURL",
                table: "Decks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "PosterURL",
                table: "Decks");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Decks",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
