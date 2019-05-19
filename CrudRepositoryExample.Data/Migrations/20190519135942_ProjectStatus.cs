using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudRepositoryExample.Data.Migrations
{
    public partial class ProjectStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "project",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "project");
        }
    }
}
