using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frameworks.Data.Migrations
{
    /// <inheritdoc />
    public partial class next : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Progres_AspNetUsers_UsersId",
                table: "Progres");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgresLocs_AspNetUsers_UsersId",
                table: "ProgresLocs");

            migrationBuilder.DropIndex(
                name: "IX_ProgresLocs_UsersId",
                table: "ProgresLocs");

            migrationBuilder.DropIndex(
                name: "IX_Progres_UsersId",
                table: "Progres");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "ProgresLocs");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Progres");

            migrationBuilder.AlterColumn<string>(
                name: "FrameworksUserId",
                table: "ProgresLocs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FrameworksUserId",
                table: "Progres",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ProgresLocs_FrameworksUserId",
                table: "ProgresLocs",
                column: "FrameworksUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Progres_FrameworksUserId",
                table: "Progres",
                column: "FrameworksUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Progres_AspNetUsers_FrameworksUserId",
                table: "Progres",
                column: "FrameworksUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgresLocs_AspNetUsers_FrameworksUserId",
                table: "ProgresLocs",
                column: "FrameworksUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Progres_AspNetUsers_FrameworksUserId",
                table: "Progres");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgresLocs_AspNetUsers_FrameworksUserId",
                table: "ProgresLocs");

            migrationBuilder.DropIndex(
                name: "IX_ProgresLocs_FrameworksUserId",
                table: "ProgresLocs");

            migrationBuilder.DropIndex(
                name: "IX_Progres_FrameworksUserId",
                table: "Progres");

            migrationBuilder.AlterColumn<int>(
                name: "FrameworksUserId",
                table: "ProgresLocs",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "ProgresLocs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FrameworksUserId",
                table: "Progres",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "Progres",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProgresLocs_UsersId",
                table: "ProgresLocs",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Progres_UsersId",
                table: "Progres",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Progres_AspNetUsers_UsersId",
                table: "Progres",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgresLocs_AspNetUsers_UsersId",
                table: "ProgresLocs",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
