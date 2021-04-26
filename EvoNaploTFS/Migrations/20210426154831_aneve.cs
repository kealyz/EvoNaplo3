using Microsoft.EntityFrameworkCore.Migrations;

namespace EvoNaplo.Migrations
{
    public partial class aneve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_StudentDatas_StudentDataId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StudentDataId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StudentDataId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentDataId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_StudentDataId",
                table: "Users",
                column: "StudentDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_StudentDatas_StudentDataId",
                table: "Users",
                column: "StudentDataId",
                principalTable: "StudentDatas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
