using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectRestaurant.Migrations
{
    public partial class FoodChef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Chef",
                table: "Restaurant");

            migrationBuilder.AddColumn<int>(
                name: "ChefsID",
                table: "Restaurant",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoodTypeID",
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

            migrationBuilder.CreateTable(
                name: "FoodType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodType", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_ChefsID",
                table: "Restaurant",
                column: "ChefsID");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_FoodTypeID",
                table: "Restaurant",
                column: "FoodTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Chef_ChefsID",
                table: "Restaurant",
                column: "ChefsID",
                principalTable: "Chef",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_FoodType_FoodTypeID",
                table: "Restaurant",
                column: "FoodTypeID",
                principalTable: "FoodType",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Chef_ChefsID",
                table: "Restaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_FoodType_FoodTypeID",
                table: "Restaurant");

            migrationBuilder.DropTable(
                name: "Chef");

            migrationBuilder.DropTable(
                name: "FoodType");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_ChefsID",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_FoodTypeID",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "ChefsID",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "FoodTypeID",
                table: "Restaurant");

            migrationBuilder.AddColumn<string>(
                name: "Chef",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
