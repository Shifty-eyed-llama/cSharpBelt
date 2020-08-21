using Microsoft.EntityFrameworkCore.Migrations;

namespace cSharpBelt.Migrations
{
    public partial class Length : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Length",
                table: "Happenings",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Length",
                table: "Happenings");
        }
    }
}
