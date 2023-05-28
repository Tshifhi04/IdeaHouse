using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdeaHouse.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Ideas_IdeaId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_IdeaId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IdeaId",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdeaId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_IdeaId",
                table: "Categories",
                column: "IdeaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Ideas_IdeaId",
                table: "Categories",
                column: "IdeaId",
                principalTable: "Ideas",
                principalColumn: "Id");
        }
    }
}
