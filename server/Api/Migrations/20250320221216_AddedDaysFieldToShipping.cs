using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AddedDaysFieldToShipping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Days",
                table: "Shippings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Shippings",
                keyColumn: "Id",
                keyValue: 1,
                column: "Days",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Shippings",
                keyColumn: "Id",
                keyValue: 2,
                column: "Days",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Shippings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Days", "Type" },
                values: new object[] { 1, "Next-Day" });

            migrationBuilder.UpdateData(
                table: "Shippings",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Days", "Type" },
                values: new object[] { 0, "Same-Day" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Days",
                table: "Shippings");

            migrationBuilder.UpdateData(
                table: "Shippings",
                keyColumn: "Id",
                keyValue: 3,
                column: "Type",
                value: "Same-Day");

            migrationBuilder.UpdateData(
                table: "Shippings",
                keyColumn: "Id",
                keyValue: 4,
                column: "Type",
                value: "Next-Day");
        }
    }
}
