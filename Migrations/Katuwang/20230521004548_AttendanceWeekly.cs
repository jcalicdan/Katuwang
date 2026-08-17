using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Katuwang.Migrations.Katuwang
{
    public partial class AttendanceWeekly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttendanceWeekly",
                columns: table => new
                {
                    entryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year = table.Column<int>(type: "int", nullable: false),
                    weeknum = table.Column<int>(type: "int", nullable: false),
                    purok = table.Column<int>(type: "int", nullable: false),
                    grupo = table.Column<int>(type: "int", nullable: false),
                    destinadoid = table.Column<int>(type: "int", nullable: false),
                    serialnumber = table.Column<int>(type: "int", nullable: false),
                    porsyento = table.Column<decimal>(type: "decimal", nullable: false),
                    createdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    createby = table.Column<string>(type: "varchar(100)", nullable: true),
                    modifieddate = table.Column<DateTime>(type: "date", nullable: false),
                    modifiedby = table.Column<string>(type: "varchar(100)", nullable: true),
                    isdeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceWeekly", x => x.entryid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceWeekly");
        }
    }
}
