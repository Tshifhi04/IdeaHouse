using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdeaHouse.Migrations
{
    /// <inheritdoc />
    public partial class inint5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Ideas_Categories_CategoryId1",
            //    table: "Ideas");

            //migrationBuilder.DropIndex(
            //    name: "IX_Ideas_CategoryId1",
            //    table: "Ideas");

            //migrationBuilder.DropColumn(
            //    name: "CategoryId1",
            //    table: "Ideas");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            //migrationBuilder.AddColumn<int>(
            //    name: "CategoryId1",
            //    table: "Ideas",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Ideas_CategoryId1",
            //    table: "Ideas",
            //    column: "CategoryId1");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Ideas_Categories_CategoryId1",
            //    table: "Ideas",
            //    column: "CategoryId1",
            //    principalTable: "Categories",
            //    principalColumn: "Id");
        }
    }
}
