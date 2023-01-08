using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectRestaurant.Migrations
{
    public partial class Bucatar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChefsID",
                table: "Restaurant",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Chef",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chef", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_ChefsID",
                table: "Restaurant",
                column: "ChefsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Chef_ChefsID",
                table: "Restaurant",
                column: "ChefsID",
                principalTable: "Chef",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Chef_ChefsID",
                table: "Restaurant");

            migrationBuilder.DropTable(
                name: "Chef");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_ChefsID",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "ChefsID",
                table: "Restaurant");
        }
    }
}
