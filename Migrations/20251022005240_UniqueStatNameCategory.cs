using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vanilla_asterisk.Migrations
{
    /// <inheritdoc />
    public partial class UniqueStatNameCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Stats_Name_CategoryId",
                table: "Stats",
                columns: new[] { "Name", "CategoryId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stats_Name_CategoryId",
                table: "Stats");
        }
    }
}
