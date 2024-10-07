using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DariaVarya.Web.App.Migrations
{
    /// <inheritdoc />
    public partial class init14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Departments",
                newName: "CCDepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CCDepartmentId",
                table: "Departments",
                newName: "DepartmentId");
        }
    }
}
