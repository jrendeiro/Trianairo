using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trianairo.Migrations
{
    public partial class startingOver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Saints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    biography = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saints", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Saints");
        }
    }
}
