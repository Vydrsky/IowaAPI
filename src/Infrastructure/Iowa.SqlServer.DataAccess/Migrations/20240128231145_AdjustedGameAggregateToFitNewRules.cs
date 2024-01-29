using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iowa.SqlServer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AdjustedGameAggregateToFitNewRules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Won",
                table: "Rounds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<long>(
                name: "PunishmentValueUpper",
                table: "Cards",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "PunishmentValueLower",
                table: "Cards",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "PunishmentValueDefault",
                table: "Cards",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Won",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "PunishmentValueDefault",
                table: "Cards");

            migrationBuilder.AlterColumn<long>(
                name: "PunishmentValueUpper",
                table: "Cards",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PunishmentValueLower",
                table: "Cards",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }
    }
}
