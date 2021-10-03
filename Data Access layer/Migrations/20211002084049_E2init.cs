using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_Access_layer.Migrations
{
    public partial class E2init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ITMPRC",
                table: "BILHDRs",
                newName: "BILPRC");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BILPRC",
                table: "BILHDRs",
                newName: "ITMPRC");
        }
    }
}
