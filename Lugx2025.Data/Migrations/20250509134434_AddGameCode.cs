using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lugx2025.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGameCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Genres");
        }
    }
}
