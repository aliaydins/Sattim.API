using Microsoft.EntityFrameworkCore.Migrations;

namespace Sattim.DataAccess.Migrations
{
    public partial class initialCrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userEmail = table.Column<string>(nullable: false),
                    userPassword = table.Column<string>(nullable: false),
                    userName = table.Column<string>(maxLength: 50, nullable: false),
                    userSurname = table.Column<string>(maxLength: 50, nullable: false),
                    userImg = table.Column<string>(nullable: true),
                    userBank = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
