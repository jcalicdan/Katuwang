using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Katuwang.Migrations.Katuwang
{
    public partial class InitializeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Masterlist",
                columns: table => new
                {
                    entryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    givenname = table.Column<string>(type: "varchar(100)", nullable: true),
                    mothersname = table.Column<string>(type: "varchar(100)", nullable: true),
                    fathersname = table.Column<string>(type: "varchar(100)", nullable: true),
                    spousename = table.Column<string>(type: "varchar(100)", nullable: true),
                    suffix = table.Column<string>(type: "varchar(10)", nullable: true),
                    gender = table.Column<string>(type: "varchar(1)", nullable: true),
                    birthdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    civilstatus = table.Column<string>(type: "varchar(1)", nullable: true),
                    spouse = table.Column<string>(type: "varchar(100)", nullable: true),
                    weddingdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    contactnum = table.Column<string>(type: "varchar(20)", nullable: true),
                    address = table.Column<string>(type: "varchar(200)", nullable: true),
                    barangay = table.Column<string>(type: "varchar(50)", nullable: true),
                    purok = table.Column<int>(type: "int", nullable: false),
                    grupo = table.Column<int>(type: "int", nullable: false),
                    newpurok = table.Column<int>(type: "int", nullable: false),
                    newgrupo = table.Column<int>(type: "int", nullable: false),
                    organization = table.Column<string>(type: "varchar(6)", nullable: true),
                    baptismdate = table.Column<DateTime>(type: "date", nullable: false),
                    firstlokal = table.Column<string>(type: "varchar(100)", nullable: true),
                    firstdistrito = table.Column<string>(type: "varchar(100)", nullable: true),
                    minister = table.Column<string>(type: "varchar(100)", nullable: true),
                    entrynum = table.Column<string>(type: "varchar(20)", nullable: true),
                    idnum = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true),
                    registrynum = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true),
                    sambahayan = table.Column<int>(type: "int", nullable: false),
                    relasyon = table.Column<string>(type: "varchar(20)", nullable: true),
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
                    table.PrimaryKey("PK_Masterlist", x => x.entryid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Masterlist");
        }
    }
}
