using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskApp.Data.Migrations
{
    public partial class mg9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InComingDescription",
                table: "Tasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InComingFinishDate",
                table: "Tasks",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InComingDescription",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "InComingFinishDate",
                table: "Tasks");
        }
    }
}
