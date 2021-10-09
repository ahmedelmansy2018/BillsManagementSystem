using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_Access_layer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ITMDTLs",
                columns: table => new
                {
                    ITMCOD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ITMNAM = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ITMPRC = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITMDTLs", x => x.ITMCOD);
                });

            migrationBuilder.CreateTable(
                name: "VNDDTLs",
                columns: table => new
                {
                    VNDCOD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VNDNAM = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VNDDTLs", x => x.VNDCOD);
                });

            migrationBuilder.CreateTable(
                name: "BILHDRs",
                columns: table => new
                {
                    BILCOD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BILDAT = table.Column<DateTime>(nullable: false),
                    BILPRC = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    BILIMG = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    VNDCOD = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BILHDRs", x => x.BILCOD);
                    table.ForeignKey(
                        name: "FK_BILHDRs_VNDDTLs_VNDCOD",
                        column: x => x.VNDCOD,
                        principalTable: "VNDDTLs",
                        principalColumn: "VNDCOD",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BILDTLs",
                columns: table => new
                {
                    DTLCOD = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ITMPRC = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    ITMQTY = table.Column<int>(nullable: false),
                    BILCOD = table.Column<int>(nullable: false),
                    ITMCOD = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BILDTLs", x => x.DTLCOD);
                    table.ForeignKey(
                        name: "FK_BILDTLs_BILHDRs_BILCOD",
                        column: x => x.BILCOD,
                        principalTable: "BILHDRs",
                        principalColumn: "BILCOD",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BILDTLs_ITMDTLs_ITMCOD",
                        column: x => x.ITMCOD,
                        principalTable: "ITMDTLs",
                        principalColumn: "ITMCOD",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "ITMDTLs",
                columns: new[] { "ITMCOD", "ITMNAM", "ITMPRC" },
                values: new object[,]
                {
                    { 1, "panana", 50m },
                    { 2, "tea", 30m },
                    { 3, "suger", 40m }
                });

            migrationBuilder.InsertData(
                table: "VNDDTLs",
                columns: new[] { "VNDCOD", "VNDNAM" },
                values: new object[,]
                {
                    { 1, "Ahmed" },
                    { 2, "ALi" },
                    { 3, "Saad" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BILDTLs_BILCOD",
                table: "BILDTLs",
                column: "BILCOD");

            migrationBuilder.CreateIndex(
                name: "IX_BILDTLs_ITMCOD",
                table: "BILDTLs",
                column: "ITMCOD");

            migrationBuilder.CreateIndex(
                name: "IX_BILHDRs_VNDCOD",
                table: "BILHDRs",
                column: "VNDCOD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BILDTLs");

            migrationBuilder.DropTable(
                name: "BILHDRs");

            migrationBuilder.DropTable(
                name: "ITMDTLs");

            migrationBuilder.DropTable(
                name: "VNDDTLs");
        }
    }
}
