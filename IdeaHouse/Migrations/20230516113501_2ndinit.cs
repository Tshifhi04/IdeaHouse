using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdeaHouse.Migrations
{
    /// <inheritdoc />
    public partial class _2ndinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Ideas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Ideas");
        }
    }
}
