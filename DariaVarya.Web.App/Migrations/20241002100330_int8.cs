using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DariaVarya.Web.App.Migrations
{
    /// <inheritdoc />
    public partial class int8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DepartemenId",
                table: "ChangeControl",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartemenId",
                table: "ChangeControl");
        }
    }
}
