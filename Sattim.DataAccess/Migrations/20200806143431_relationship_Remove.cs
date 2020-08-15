using Microsoft.EntityFrameworkCore.Migrations;

namespace Sattim.DataAccess.Migrations
{
    public partial class relationship_Remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Products_productId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Users_userId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_Products_productId",
                table: "Pictures");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_userId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_userId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Pictures_productId",
                table: "Pictures");

            migrationBuilder.DropIndex(
                name: "IX_Offers_productId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_userId",
                table: "Offers");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "Pictures",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Offers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "Offers",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "Pictures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Offers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "productId",
                table: "Offers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Products_userId",
                table: "Products",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_productId",
                table: "Pictures",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_productId",
                table: "Offers",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_userId",
                table: "Offers",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Products_productId",
                table: "Offers",
                column: "productId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Users_userId",
                table: "Offers",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_Products_productId",
                table: "Pictures",
                column: "productId",
                principalTable: "Products",
                principalColumn: "productId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_userId",
                table: "Products",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
