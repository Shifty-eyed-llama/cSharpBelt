using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cSharpBelt.Migrations
{
    public partial class HappeningAttending : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Happening",
                columns: table => new
                {
                    HappeningID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HappeningTitle = table.Column<string>(nullable: false),
                    HappeningDay = table.Column<DateTime>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Happening", x => x.HappeningID);
                    table.ForeignKey(
                        name: "FK_Happening_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attending",
                columns: table => new
                {
                    AttendingID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    HappeningID = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attending", x => x.AttendingID);
                    table.ForeignKey(
                        name: "FK_Attending_Happening_HappeningID",
                        column: x => x.HappeningID,
                        principalTable: "Happening",
                        principalColumn: "HappeningID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attending_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attending_HappeningID",
                table: "Attending",
                column: "HappeningID");

            migrationBuilder.CreateIndex(
                name: "IX_Attending_UserID",
                table: "Attending",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Happening_UserID",
                table: "Happening",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attending");

            migrationBuilder.DropTable(
                name: "Happening");
        }
    }
}
