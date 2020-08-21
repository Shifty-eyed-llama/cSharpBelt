using Microsoft.EntityFrameworkCore.Migrations;

namespace cSharpBelt.Migrations
{
    public partial class Oops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attending_Happening_HappeningID",
                table: "Attending");

            migrationBuilder.DropForeignKey(
                name: "FK_Attending_Users_UserID",
                table: "Attending");

            migrationBuilder.DropForeignKey(
                name: "FK_Happening_Users_UserID",
                table: "Happening");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Happening",
                table: "Happening");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attending",
                table: "Attending");

            migrationBuilder.RenameTable(
                name: "Happening",
                newName: "Happenings");

            migrationBuilder.RenameTable(
                name: "Attending",
                newName: "Attendings");

            migrationBuilder.RenameIndex(
                name: "IX_Happening_UserID",
                table: "Happenings",
                newName: "IX_Happenings_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Attending_UserID",
                table: "Attendings",
                newName: "IX_Attendings_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Attending_HappeningID",
                table: "Attendings",
                newName: "IX_Attendings_HappeningID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Happenings",
                table: "Happenings",
                column: "HappeningID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attendings",
                table: "Attendings",
                column: "AttendingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendings_Happenings_HappeningID",
                table: "Attendings",
                column: "HappeningID",
                principalTable: "Happenings",
                principalColumn: "HappeningID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendings_Users_UserID",
                table: "Attendings",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Happenings_Users_UserID",
                table: "Happenings",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendings_Happenings_HappeningID",
                table: "Attendings");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendings_Users_UserID",
                table: "Attendings");

            migrationBuilder.DropForeignKey(
                name: "FK_Happenings_Users_UserID",
                table: "Happenings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Happenings",
                table: "Happenings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attendings",
                table: "Attendings");

            migrationBuilder.RenameTable(
                name: "Happenings",
                newName: "Happening");

            migrationBuilder.RenameTable(
                name: "Attendings",
                newName: "Attending");

            migrationBuilder.RenameIndex(
                name: "IX_Happenings_UserID",
                table: "Happening",
                newName: "IX_Happening_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Attendings_UserID",
                table: "Attending",
                newName: "IX_Attending_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Attendings_HappeningID",
                table: "Attending",
                newName: "IX_Attending_HappeningID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Happening",
                table: "Happening",
                column: "HappeningID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attending",
                table: "Attending",
                column: "AttendingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Attending_Happening_HappeningID",
                table: "Attending",
                column: "HappeningID",
                principalTable: "Happening",
                principalColumn: "HappeningID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attending_Users_UserID",
                table: "Attending",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Happening_Users_UserID",
                table: "Happening",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
