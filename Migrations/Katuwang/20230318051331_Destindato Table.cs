using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Katuwang.Migrations.Katuwang
{
    public partial class DestindatoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Destinado",
                columns: table => new
                {
                    entryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    givenname = table.Column<string>(type: "varchar(100)", nullable: true),
                    mothersname = table.Column<string>(type: "varchar(100)", nullable: true),
                    fathersname = table.Column<string>(type: "varchar(100)", nullable: true),
                    suffix = table.Column<string>(type: "varchar(10)", nullable: true),
                    type = table.Column<string>(type: "varchar(20)", nullable: true),
                    assignednum = table.Column<string>(type: "varchar(10)", nullable: true),
                    entrydate = table.Column<DateTime>(type: "datetime", nullable: false),
                    enddate = table.Column<DateTime>(type: "datetime", nullable: false),
                    purok = table.Column<int>(type: "int", nullable: false),
                    grupostart = table.Column<int>(type: "int", nullable: false),
                    grupoend = table.Column<int>(type: "int", nullable: false),
                    isactive = table.Column<int>(type: "int", nullable: false),
                    remarks1 = table.Column<string>(type: "varchar(250)", nullable: true),
                    remarks2 = table.Column<string>(type: "varchar(250)", nullable: true),
                    remarks3 = table.Column<string>(type: "varchar(250)", nullable: true),
                    createdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    createby = table.Column<string>(type: "varchar(100)", nullable: true),
                    modifieddate = table.Column<DateTime>(type: "date", nullable: false),
                    modifiedby = table.Column<string>(type: "varchar(100)", nullable: true),
                    isdeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinado", x => x.entryid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Destinado");
        }
    }
}
