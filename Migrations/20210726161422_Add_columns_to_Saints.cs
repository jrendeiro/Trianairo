using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trianairo.Migrations
{
    public partial class Add_columns_to_Saints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "beatifiedDate",
                table: "Saints",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "birthDate",
                table: "Saints",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "canonizedDate",
                table: "Saints",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "Saints",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deathDate",
                table: "Saints",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "feastDay",
                table: "Saints",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "beatifiedDate",
                table: "Saints");

            migrationBuilder.DropColumn(
                name: "birthDate",
                table: "Saints");

            migrationBuilder.DropColumn(
                name: "canonizedDate",
                table: "Saints");

            migrationBuilder.DropColumn(
                name: "country",
                table: "Saints");

            migrationBuilder.DropColumn(
                name: "deathDate",
                table: "Saints");

            migrationBuilder.DropColumn(
                name: "feastDay",
                table: "Saints");
        }
    }
}
