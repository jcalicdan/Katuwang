using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Katuwang.Migrations.Katuwang
{
    public partial class TransferandR401Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "R401",
                columns: table => new
                {
                    entryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    masterlistid = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "varchar(100)", nullable: true),
                    year = table.Column<int>(type: "int", nullable: false),
                    month = table.Column<string>(type: "varchar(20)", nullable: false),
                    destinadoid = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<string>(type: "varchar(5)", nullable: false),
                    ismk = table.Column<int>(type: "int", nullable: false),
                    entrydate = table.Column<DateTime>(type: "datetime", nullable: false),
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
                    table.PrimaryKey("PK_R401", x => x.entryid);
                    table.ForeignKey(
                        name: "FK_R401_Masterlist_masterlistid",
                        column: x => x.masterlistid,
                        principalTable: "Masterlist",
                        principalColumn: "entryid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transfer",
                columns: table => new
                {
                    entryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    masterlistid = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    weeknum = table.Column<int>(type: "int", nullable: false),
                    transferdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    code = table.Column<string>(type: "varchar(1)", nullable: true),
                    lokal = table.Column<string>(type: "varchar(100)", nullable: true),
                    lcode = table.Column<string>(type: "varchar(20)", nullable: true),
                    distrito = table.Column<string>(type: "varchar(100)", nullable: true),
                    dcode = table.Column<string>(type: "varchar(20)", nullable: true),
                    address = table.Column<string>(type: "varchar(100)", nullable: true),
                    isletter = table.Column<int>(type: "int", nullable: false),
                    secretariatid = table.Column<int>(type: "int", nullable: false),
                    createdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    createby = table.Column<string>(type: "varchar(100)", nullable: true),
                    modifieddate = table.Column<DateTime>(type: "date", nullable: false),
                    modifiedby = table.Column<string>(type: "varchar(100)", nullable: true),
                    isdeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfer", x => x.entryid);
                    table.ForeignKey(
                        name: "FK_Transfer_Masterlist_masterlistid",
                        column: x => x.masterlistid,
                        principalTable: "Masterlist",
                        principalColumn: "entryid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_R401_masterlistid",
                table: "R401",
                column: "masterlistid");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_masterlistid",
                table: "Transfer",
                column: "masterlistid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "R401");

            migrationBuilder.DropTable(
                name: "Transfer");
        }
    }
}
