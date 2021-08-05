using Microsoft.EntityFrameworkCore.Migrations;

namespace GOPR_HELP_API.Migrations
{
    public partial class TrailsAddId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Trails_Id",
                table: "Registrations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Trails_Id",
                table: "Registrations");
        }
    }
}
