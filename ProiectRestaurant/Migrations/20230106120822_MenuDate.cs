using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectRestaurant.Migrations
{
    public partial class MenuDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MenuDate",
                table: "Restaurant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuDate",
                table: "Restaurant");
        }
    }
}
