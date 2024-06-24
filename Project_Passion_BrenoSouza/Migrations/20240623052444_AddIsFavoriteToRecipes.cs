using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_Passion_BrenoSouza.Migrations
{
    /// <inheritdoc />
    public partial class AddIsFavoriteToRecipes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Recipes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Recipes");
        }
    }
}
