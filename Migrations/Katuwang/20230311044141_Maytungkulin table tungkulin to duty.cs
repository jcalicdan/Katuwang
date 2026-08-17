using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Katuwang.Migrations.Katuwang
{
    public partial class Maytungkulintabletungkulintoduty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tungkulin",
                table: "Maytungkulin",
                newName: "task");

            migrationBuilder.RenameColumn(
                name: "gampanin",
                table: "Maytungkulin",
                newName: "duty");

            migrationBuilder.AddColumn<DateTime>(
                name: "enddate",
                table: "Maytungkulin",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "enddate",
                table: "Maytungkulin");

            migrationBuilder.RenameColumn(
                name: "task",
                table: "Maytungkulin",
                newName: "tungkulin");

            migrationBuilder.RenameColumn(
                name: "duty",
                table: "Maytungkulin",
                newName: "gampanin");
        }
    }
}
