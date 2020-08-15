using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sattim.DataAccess.Migrations
{
    public partial class created_Tables_and_Reletonship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productTitle = table.Column<string>(maxLength: 80, nullable: false),
                    productExplain = table.Column<string>(maxLength: 250, nullable: false),
                    productCategory = table.Column<string>(maxLength: 50, nullable: false),
                    productPrice = table.Column<int>(nullable: false),
                    productFirstDate = table.Column<DateTime>(nullable: false),
                    productLasttDate = table.Column<DateTime>(nullable: false),
                    isSell = table.Column<bool>(nullable: false),
                    userId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productId);
                    table.ForeignKey(
                        name: "FK_Products_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    offerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    offer = table.Column<int>(nullable: false),
                    isDone = table.Column<bool>(nullable: false),
                    offerDate = table.Column<DateTime>(nullable: false),
                    offerByuserId = table.Column<int>(nullable: false),
                    productId = table.Column<int>(nullable: true),
                    userId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.offerId);
                    table.ForeignKey(
                        name: "FK_Offers_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Offers_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "userId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    pictureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pictureData = table.Column<string>(nullable: true),
                    productId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.pictureId);
                    table.ForeignKey(
                        name: "FK_Pictures_Products_productId",
                        column: x => x.productId,
                        principalTable: "Products",
                        principalColumn: "productId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_productId",
                table: "Offers",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_userId",
                table: "Offers",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_productId",
                table: "Pictures",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_userId",
                table: "Products",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
