using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trianairo.Migrations
{
    public partial class temporary_remove_saints_props : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "deathDate",
                table: "Saints");

            migrationBuilder.DropColumn(
                name: "feastDay",
                table: "Saints");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
