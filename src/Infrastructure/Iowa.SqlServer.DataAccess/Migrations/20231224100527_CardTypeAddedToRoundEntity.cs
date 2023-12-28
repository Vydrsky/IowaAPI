using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iowa.SqlServer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CardTypeAddedToRoundEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardChosen",
                table: "Rounds",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardChosen",
                table: "Rounds");
        }
    }
}
