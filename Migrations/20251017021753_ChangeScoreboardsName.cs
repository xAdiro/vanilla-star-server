using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vanilla_asterisk.Migrations
{
    /// <inheritdoc />
    public partial class ChangeScoreboardsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStats_Scoreboards_ScoreboardId",
                table: "PlayerStats");

            migrationBuilder.DropForeignKey(
                name: "FK_Scoreboards_StatCategories_CategoryId",
                table: "Scoreboards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Scoreboards",
                table: "Scoreboards");

            migrationBuilder.RenameTable(
                name: "Scoreboards",
                newName: "Stats");

            migrationBuilder.RenameIndex(
                name: "IX_Scoreboards_CategoryId",
                table: "Stats",
                newName: "IX_Stats_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stats",
                table: "Stats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStats_Stats_ScoreboardId",
                table: "PlayerStats",
                column: "ScoreboardId",
                principalTable: "Stats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stats_StatCategories_CategoryId",
                table: "Stats",
                column: "CategoryId",
                principalTable: "StatCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStats_Stats_ScoreboardId",
                table: "PlayerStats");

            migrationBuilder.DropForeignKey(
                name: "FK_Stats_StatCategories_CategoryId",
                table: "Stats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stats",
                table: "Stats");

            migrationBuilder.RenameTable(
                name: "Stats",
                newName: "Scoreboards");

            migrationBuilder.RenameIndex(
                name: "IX_Stats_CategoryId",
                table: "Scoreboards",
                newName: "IX_Scoreboards_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Scoreboards",
                table: "Scoreboards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStats_Scoreboards_ScoreboardId",
                table: "PlayerStats",
                column: "ScoreboardId",
                principalTable: "Scoreboards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scoreboards_StatCategories_CategoryId",
                table: "Scoreboards",
                column: "CategoryId",
                principalTable: "StatCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
