using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vanilla_asterisk.Migrations
{
    /// <inheritdoc />
    public partial class UUIDUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Players_UUID",
                table: "Players",
                column: "UUID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Players_UUID",
                table: "Players");
        }
    }
}
