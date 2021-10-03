using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_Access_layer.Migrations
{
    public partial class Einit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BILDTLs_BILHDRs_BILHDRBILCOD",
                table: "BILDTLs");

            migrationBuilder.DropForeignKey(
                name: "FK_BILDTLs_ITMDTLs_ITMDTLITMCOD",
                table: "BILDTLs");

            migrationBuilder.DropForeignKey(
                name: "FK_BILHDRs_VNDDTLs_VNDDTLVNDCOD",
                table: "BILHDRs");

            migrationBuilder.DropIndex(
                name: "IX_BILHDRs_VNDDTLVNDCOD",
                table: "BILHDRs");

            migrationBuilder.DropIndex(
                name: "IX_BILDTLs_BILHDRBILCOD",
                table: "BILDTLs");

            migrationBuilder.DropIndex(
                name: "IX_BILDTLs_ITMDTLITMCOD",
                table: "BILDTLs");

            migrationBuilder.DropColumn(
                name: "VNDDTLVNDCOD",
                table: "BILHDRs");

            migrationBuilder.DropColumn(
                name: "BILHDRBILCOD",
                table: "BILDTLs");

            migrationBuilder.DropColumn(
                name: "ITMDTLITMCOD",
                table: "BILDTLs");

            migrationBuilder.CreateIndex(
                name: "IX_BILHDRs_VNDCOD",
                table: "BILHDRs",
                column: "VNDCOD");

            migrationBuilder.CreateIndex(
                name: "IX_BILDTLs_BILCOD",
                table: "BILDTLs",
                column: "BILCOD");

            migrationBuilder.CreateIndex(
                name: "IX_BILDTLs_ITMCOD",
                table: "BILDTLs",
                column: "ITMCOD");

            migrationBuilder.AddForeignKey(
                name: "FK_BILDTLs_BILHDRs_BILCOD",
                table: "BILDTLs",
                column: "BILCOD",
                principalTable: "BILHDRs",
                principalColumn: "BILCOD",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BILDTLs_ITMDTLs_ITMCOD",
                table: "BILDTLs",
                column: "ITMCOD",
                principalTable: "ITMDTLs",
                principalColumn: "ITMCOD",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BILHDRs_VNDDTLs_VNDCOD",
                table: "BILHDRs",
                column: "VNDCOD",
                principalTable: "VNDDTLs",
                principalColumn: "VNDCOD",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BILDTLs_BILHDRs_BILCOD",
                table: "BILDTLs");

            migrationBuilder.DropForeignKey(
                name: "FK_BILDTLs_ITMDTLs_ITMCOD",
                table: "BILDTLs");

            migrationBuilder.DropForeignKey(
                name: "FK_BILHDRs_VNDDTLs_VNDCOD",
                table: "BILHDRs");

            migrationBuilder.DropIndex(
                name: "IX_BILHDRs_VNDCOD",
                table: "BILHDRs");

            migrationBuilder.DropIndex(
                name: "IX_BILDTLs_BILCOD",
                table: "BILDTLs");

            migrationBuilder.DropIndex(
                name: "IX_BILDTLs_ITMCOD",
                table: "BILDTLs");

            migrationBuilder.AddColumn<int>(
                name: "VNDDTLVNDCOD",
                table: "BILHDRs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BILHDRBILCOD",
                table: "BILDTLs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ITMDTLITMCOD",
                table: "BILDTLs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BILHDRs_VNDDTLVNDCOD",
                table: "BILHDRs",
                column: "VNDDTLVNDCOD");

            migrationBuilder.CreateIndex(
                name: "IX_BILDTLs_BILHDRBILCOD",
                table: "BILDTLs",
                column: "BILHDRBILCOD");

            migrationBuilder.CreateIndex(
                name: "IX_BILDTLs_ITMDTLITMCOD",
                table: "BILDTLs",
                column: "ITMDTLITMCOD");

            migrationBuilder.AddForeignKey(
                name: "FK_BILDTLs_BILHDRs_BILHDRBILCOD",
                table: "BILDTLs",
                column: "BILHDRBILCOD",
                principalTable: "BILHDRs",
                principalColumn: "BILCOD",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BILDTLs_ITMDTLs_ITMDTLITMCOD",
                table: "BILDTLs",
                column: "ITMDTLITMCOD",
                principalTable: "ITMDTLs",
                principalColumn: "ITMCOD",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BILHDRs_VNDDTLs_VNDDTLVNDCOD",
                table: "BILHDRs",
                column: "VNDDTLVNDCOD",
                principalTable: "VNDDTLs",
                principalColumn: "VNDCOD",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
