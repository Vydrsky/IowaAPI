using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Iowa.SqlServer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UserIsArchivedField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Users",
                newName: "IsArchived");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsArchived",
                table: "Users",
                newName: "IsActive");
        }
    }
}
