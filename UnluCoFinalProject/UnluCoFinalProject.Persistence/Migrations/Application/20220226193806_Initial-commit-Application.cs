using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnluCoFinalProject.Persistence.Migrations.Application
{
    public partial class InitialcommitApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IsSold",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsSold", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IsSold = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSoldUserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOfferable = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProductOffer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OfferPrice = table.Column<int>(type: "int", nullable: false),
                    OfferAccept = table.Column<bool>(type: "bit", nullable: false),
                    OfferDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductUserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProductOffer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProductOffer_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "BrandName" },
                values: new object[,]
                {
                    { 1, "Ferrari" },
                    { 2, "BMW" },
                    { 3, "VOLKSWAGEN" },
                    { 4, "OPEL" },
                    { 5, "FIAT" }
                });

            migrationBuilder.InsertData(
                table: "Color",
                columns: new[] { "Id", "ColorName" },
                values: new object[,]
                {
                    { 1, "MOR" },
                    { 2, "MAVI" },
                    { 3, "KIRMIZI" },
                    { 4, "LACIVERT" },
                    { 5, "PEMBE" },
                    { 6, "SIYAH" },
                    { 7, "SARI" }
                });

            migrationBuilder.InsertData(
                table: "IsSold",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Aktif" },
                    { 2, "Pasif" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProductOffer_ProductId",
                table: "UserProductOffer",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "IsSold");

            migrationBuilder.DropTable(
                name: "UserProductOffer");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
