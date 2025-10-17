using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vanilla_asterisk.Migrations
{
    /// <inheritdoc />
    public partial class AddStatCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scoreboards_StatCategory_CategoryId",
                table: "Scoreboards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatCategory",
                table: "StatCategory");

            migrationBuilder.RenameTable(
                name: "StatCategory",
                newName: "StatCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatCategories",
                table: "StatCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Scoreboards_StatCategories_CategoryId",
                table: "Scoreboards",
                column: "CategoryId",
                principalTable: "StatCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Scoreboards_StatCategories_CategoryId",
                table: "Scoreboards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StatCategories",
                table: "StatCategories");

            migrationBuilder.RenameTable(
                name: "StatCategories",
                newName: "StatCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StatCategory",
                table: "StatCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Scoreboards_StatCategory_CategoryId",
                table: "Scoreboards",
                column: "CategoryId",
                principalTable: "StatCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
