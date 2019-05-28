using Microsoft.EntityFrameworkCore.Migrations;

namespace EffectiveEmployee.Migrations
{
    public partial class NewMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Deadline",
                table: "Projects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Education",
                table: "Employees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "Education",
                table: "Employees");
        }
    }
}
