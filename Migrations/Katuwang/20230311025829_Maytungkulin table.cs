using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Katuwang.Migrations.Katuwang
{
    public partial class Maytungkulintable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Maytungkulin",
                columns: table => new
                {
                    entryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    masterlistid = table.Column<int>(type: "int", nullable: false),
                    tungkulin = table.Column<string>(type: "varchar(100)", nullable: true),
                    section = table.Column<string>(type: "varchar(100)", nullable: true),
                    gampanin = table.Column<string>(type: "varchar(100)", nullable: true),
                    level = table.Column<string>(type: "varchar(100)", nullable: true),
                    entrydate = table.Column<DateTime>(type: "datetime", nullable: false),
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
                    table.PrimaryKey("PK_Maytungkulin", x => x.entryid);
                    table.ForeignKey(
                        name: "FK_Maytungkulin_Masterlist_masterlistid",
                        column: x => x.masterlistid,
                        principalTable: "Masterlist",
                        principalColumn: "entryid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maytungkulin_masterlistid",
                table: "Maytungkulin",
                column: "masterlistid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maytungkulin");
        }
    }
}
