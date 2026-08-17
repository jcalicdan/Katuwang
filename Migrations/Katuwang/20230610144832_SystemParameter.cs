using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Katuwang.Migrations.Katuwang
{
    public partial class SystemParameter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SystemParameter",
                columns: table => new
                {
                    entryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", nullable: true),
                    code = table.Column<string>(type: "varchar(100)", nullable: true),
                    description = table.Column<string>(type: "varchar(100)", nullable: true),
                    createdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    createby = table.Column<string>(type: "varchar(100)", nullable: true),
                    modifieddate = table.Column<DateTime>(type: "date", nullable: false),
                    modifiedby = table.Column<string>(type: "varchar(100)", nullable: true),
                    isdeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemParameter", x => x.entryid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SystemParameter");
        }
    }
}
