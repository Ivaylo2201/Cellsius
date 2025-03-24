using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class SwappedFieldNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscountedPrice",
                table: "Phones",
                newName: "InitialPrice");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Phones",
                type: "TEXT",
                nullable: false,
                computedColumnSql: "[InitialPrice] * (1 - [DiscountPercentage] / 100.0)",
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                column: "InitialPrice",
                value: 1300m);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                column: "InitialPrice",
                value: 450m);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                column: "InitialPrice",
                value: 500m);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 4,
                column: "InitialPrice",
                value: 1200m);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 5,
                column: "InitialPrice",
                value: 2000m);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 6,
                column: "InitialPrice",
                value: 1750m);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 7,
                column: "InitialPrice",
                value: 300m);

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 9,
                column: "InitialPrice",
                value: 700m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InitialPrice",
                table: "Phones",
                newName: "DiscountedPrice");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Phones",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldComputedColumnSql: "[InitialPrice] * (1 - [DiscountPercentage] / 100.0)");

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DiscountedPrice", "Price" },
                values: new object[] { 0m, 1300m });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DiscountedPrice", "Price" },
                values: new object[] { 0m, 450m });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DiscountedPrice", "Price" },
                values: new object[] { 0m, 500m });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DiscountedPrice", "Price" },
                values: new object[] { 0m, 1200m });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DiscountedPrice", "Price" },
                values: new object[] { 0m, 2000m });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "DiscountedPrice", "Price" },
                values: new object[] { 0m, 1750m });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "DiscountedPrice", "Price" },
                values: new object[] { 0m, 300m });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "DiscountedPrice", "Price" },
                values: new object[] { 0m, 700m });
        }
    }
}
