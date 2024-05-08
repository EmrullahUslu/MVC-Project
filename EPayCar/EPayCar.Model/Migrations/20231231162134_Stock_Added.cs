using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPayCar.Model.Migrations
{
    /// <inheritdoc />
    public partial class Stock_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Carscs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Carscs");
        }
    }
}
