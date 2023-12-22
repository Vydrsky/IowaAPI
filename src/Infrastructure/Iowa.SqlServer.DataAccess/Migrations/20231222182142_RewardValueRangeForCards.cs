using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iowa.SqlServer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RewardValueRangeForCards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PunishmentValue",
                table: "Cards",
                newName: "PunishmentValueUpper");

            migrationBuilder.AddColumn<long>(
                name: "PunishmentValueLower",
                table: "Cards",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PunishmentValueLower",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "PunishmentValueUpper",
                table: "Cards",
                newName: "PunishmentValue");
        }
    }
}
