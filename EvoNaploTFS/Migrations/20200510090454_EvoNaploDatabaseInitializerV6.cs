using Microsoft.EntityFrameworkCore.Migrations;

namespace EvoNaplo.Migrations
{
    public partial class EvoNaploDatabaseInitializerV6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Semesters",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Semesters");
        }
    }
}
