using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrderModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneUser");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", nullable: false),
                    Items = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Mint" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Galaxy S24 Ultra");

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BrandId", "Name" },
                values: new object[] { 1, "Galaxy S25" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BrandId", "Name" },
                values: new object[] { 1, "Galaxy A16" });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "BrandId", "Name" },
                values: new object[,]
                {
                    { 4, 1, "Galaxy Z Flip 6" },
                    { 5, 2, "iPhone 16 Pro Max" },
                    { 6, 2, "iPhone 15" },
                    { 7, 2, "iPhone 14" },
                    { 8, 3, "14T Pro" },
                    { 9, 3, "Redmi Note 12 Pro" },
                    { 10, 3, "13" }
                });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ColorId", "ImagePath", "Memory", "Price" },
                values: new object[] { 5, "/uploads/samsung-galaxy-s24ultra.jpg", 512, 1300m });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BrandId", "ColorId", "ImagePath", "Memory", "Price" },
                values: new object[] { 1, 7, "/uploads/samsung-galaxy-s25.jpg", 64, 450m });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BrandId", "ImagePath", "Memory", "Price" },
                values: new object[] { 1, "/uploads/samsung-galaxy-a16.jpg", 128, 500m });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "BrandId", "ColorId", "ImagePath", "Memory", "ModelId", "Price" },
                values: new object[,]
                {
                    { 4, 1, 3, "/uploads/samsung-galaxy-zflip6.jpg", 512, 4, 1200m },
                    { 5, 2, 2, "/uploads/apple-iphone-16promax.jpg", 512, 5, 2000m },
                    { 6, 2, 1, "/uploads/apple-iphone-15.jpg", 256, 6, 1750m },
                    { 7, 3, 1, "/uploads/xiaomi-14t-pro.jpg", 128, 8, 300m },
                    { 9, 3, 6, "/uploads/xiaomi-redmi-13.jpg", 256, 10, 700m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DeleteData(
                table: "Colors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.CreateTable(
                name: "PhoneUser",
                columns: table => new
                {
                    LikedById = table.Column<int>(type: "INTEGER", nullable: false),
                    LikedPhonesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneUser", x => new { x.LikedById, x.LikedPhonesId });
                    table.ForeignKey(
                        name: "FK_PhoneUser_Phones_LikedPhonesId",
                        column: x => x.LikedPhonesId,
                        principalTable: "Phones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneUser_Users_LikedById",
                        column: x => x.LikedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Galaxy S23");

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BrandId", "Name" },
                values: new object[] { 2, "IPhone 14" });

            migrationBuilder.UpdateData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BrandId", "Name" },
                values: new object[] { 3, "Redmi Note 13 Pro" });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ColorId", "ImagePath", "Memory", "Price" },
                values: new object[] { 6, "/uploads/samsung-galaxy-s23.jpg", 128, 750m });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BrandId", "ColorId", "ImagePath", "Memory", "Price" },
                values: new object[] { 2, 1, "/uploads/apple-iphone-14.jpg", 512, 1500m });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BrandId", "ImagePath", "Memory", "Price" },
                values: new object[] { 3, "/uploads/xiaomi-redminote-13-pro.jpg", 256, 300m });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneUser_LikedPhonesId",
                table: "PhoneUser",
                column: "LikedPhonesId");
        }
    }
}
