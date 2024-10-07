using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DariaVarya.Web.App.Migrations
{
    /// <inheritdoc />
    public partial class init10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_ChangeControl_ChangeControlId",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "ChangeControlId",
                table: "Departments",
                newName: "DepartemenId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_ChangeControlId",
                table: "Departments",
                newName: "IX_Departments_DepartemenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_ChangeControl_DepartemenId",
                table: "Departments",
                column: "DepartemenId",
                principalTable: "ChangeControl",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_ChangeControl_DepartemenId",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "DepartemenId",
                table: "Departments",
                newName: "ChangeControlId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_DepartemenId",
                table: "Departments",
                newName: "IX_Departments_ChangeControlId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_ChangeControl_ChangeControlId",
                table: "Departments",
                column: "ChangeControlId",
                principalTable: "ChangeControl",
                principalColumn: "Id");
        }
    }
}
