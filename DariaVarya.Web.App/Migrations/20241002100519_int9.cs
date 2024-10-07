using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DariaVarya.Web.App.Migrations
{
    /// <inheritdoc />
    public partial class int9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_ChangeControl_ChangeControlId",
                table: "Department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "Departments");

            migrationBuilder.RenameIndex(
                name: "IX_Department_ChangeControlId",
                table: "Departments",
                newName: "IX_Departments_ChangeControlId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_ChangeControl_ChangeControlId",
                table: "Departments",
                column: "ChangeControlId",
                principalTable: "ChangeControl",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_ChangeControl_ChangeControlId",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "Department");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_ChangeControlId",
                table: "Department",
                newName: "IX_Department_ChangeControlId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_ChangeControl_ChangeControlId",
                table: "Department",
                column: "ChangeControlId",
                principalTable: "ChangeControl",
                principalColumn: "Id");
        }
    }
}
