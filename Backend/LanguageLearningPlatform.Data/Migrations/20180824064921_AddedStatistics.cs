using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LanguageLearningPlatform.Data.Migrations
{
    public partial class AddedStatistics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                table: "Decks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                table: "Cards",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    DeckId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    CardId = table.Column<int>(nullable: false),
                    LastCheckedOn = table.Column<DateTime>(nullable: true),
                    CheckedTimes = table.Column<int>(nullable: false),
                    CorrectTimes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => new { x.CardId, x.UserId, x.DeckId });
                    table.ForeignKey(
                        name: "FK_Statistics_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Statistics_UserSubsrcriptionDecks_DeckId_UserId",
                        columns: x => new { x.DeckId, x.UserId },
                        principalTable: "UserSubsrcriptionDecks",
                        principalColumns: new[] { "DeckId", "UserId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_DeckId_UserId",
                table: "Statistics",
                columns: new[] { "DeckId", "UserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                table: "Cards");
        }
    }
}
