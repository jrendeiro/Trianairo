using Microsoft.EntityFrameworkCore.Migrations;

namespace Trianairo.Migrations
{
    public partial class Add_Status_column_to_Saint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Saints",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Saints");
        }
    }
}
