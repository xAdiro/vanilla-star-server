using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vanilla_asterisk.Migrations
{
    /// <inheritdoc />
    public partial class UniqueRepeatingPlayerStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStats_Stats_ScoreboardId",
                table: "PlayerStats");

            migrationBuilder.DropIndex(
                name: "IX_PlayerStats_ScoreboardId",
                table: "PlayerStats");

            migrationBuilder.RenameColumn(
                name: "ScoreboardId",
                table: "PlayerStats",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "PlayerStats",
                newName: "StatId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStats_StatId",
                table: "PlayerStats",
                column: "StatId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStats_Value_PlayerId_StatId",
                table: "PlayerStats",
                columns: new[] { "Value", "PlayerId", "StatId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStats_Stats_StatId",
                table: "PlayerStats",
                column: "StatId",
                principalTable: "Stats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStats_Stats_StatId",
                table: "PlayerStats");

            migrationBuilder.DropIndex(
                name: "IX_PlayerStats_StatId",
                table: "PlayerStats");

            migrationBuilder.DropIndex(
                name: "IX_PlayerStats_Value_PlayerId_StatId",
                table: "PlayerStats");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "PlayerStats",
                newName: "ScoreboardId");

            migrationBuilder.RenameColumn(
                name: "StatId",
                table: "PlayerStats",
                newName: "Score");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStats_ScoreboardId",
                table: "PlayerStats",
                column: "ScoreboardId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStats_Stats_ScoreboardId",
                table: "PlayerStats",
                column: "ScoreboardId",
                principalTable: "Stats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
