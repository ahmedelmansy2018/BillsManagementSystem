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
                    ITMNAM = table.Column<string>(nullable: false),
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
                    VNDNAM = table.Column<string>(nullable: false)
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
                    ITMPRC = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    BILIMG = table.Column<string>(nullable: true),
                    VNDCOD = table.Column<int>(nullable: false),
                    VNDDTLVNDCOD = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BILHDRs", x => x.BILCOD);
                    table.ForeignKey(
                        name: "FK_BILHDRs_VNDDTLs_VNDDTLVNDCOD",
                        column: x => x.VNDDTLVNDCOD,
                        principalTable: "VNDDTLs",
                        principalColumn: "VNDCOD",
                        onDelete: ReferentialAction.Restrict);
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
                    BILHDRBILCOD = table.Column<int>(nullable: true),
                    ITMCOD = table.Column<int>(nullable: false),
                    ITMDTLITMCOD = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BILDTLs", x => x.DTLCOD);
                    table.ForeignKey(
                        name: "FK_BILDTLs_BILHDRs_BILHDRBILCOD",
                        column: x => x.BILHDRBILCOD,
                        principalTable: "BILHDRs",
                        principalColumn: "BILCOD",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BILDTLs_ITMDTLs_ITMDTLITMCOD",
                        column: x => x.ITMDTLITMCOD,
                        principalTable: "ITMDTLs",
                        principalColumn: "ITMCOD",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_BILDTLs_BILHDRBILCOD",
                table: "BILDTLs",
                column: "BILHDRBILCOD");

            migrationBuilder.CreateIndex(
                name: "IX_BILDTLs_ITMDTLITMCOD",
                table: "BILDTLs",
                column: "ITMDTLITMCOD");

            migrationBuilder.CreateIndex(
                name: "IX_BILHDRs_VNDDTLVNDCOD",
                table: "BILHDRs",
                column: "VNDDTLVNDCOD");
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
