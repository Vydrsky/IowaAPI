using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iowa.SqlServer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RoundIdAdjusted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoundId",
                table: "Rounds",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rounds",
                newName: "RoundId");
        }
    }
}
