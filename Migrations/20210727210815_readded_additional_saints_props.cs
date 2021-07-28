using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Trianairo.Migrations
{
    public partial class readded_additional_saints_props : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "beatifiedYear",
                table: "Saints",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "birthDate",
                table: "Saints",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "canonizedYear",
                table: "Saints",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "deathYear",
                table: "Saints",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "feastDay",
                table: "Saints",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "martyr",
                table: "Saints",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "beatifiedYear",
                table: "Saints");

            migrationBuilder.DropColumn(
                name: "birthDate",
                table: "Saints");

            migrationBuilder.DropColumn(
                name: "canonizedYear",
                table: "Saints");

            migrationBuilder.DropColumn(
                name: "deathYear",
                table: "Saints");

            migrationBuilder.DropColumn(
                name: "feastDay",
                table: "Saints");

            migrationBuilder.DropColumn(
                name: "martyr",
                table: "Saints");
        }
    }
}
