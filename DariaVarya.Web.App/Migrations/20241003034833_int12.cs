﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DariaVarya.Web.App.Migrations
{
    /// <inheritdoc />
    public partial class int12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "ChangeControl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "ChangeControl");
        }
    }
}
